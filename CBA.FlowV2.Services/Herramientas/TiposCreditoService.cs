using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Articulos;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TiposCreditoService : ClaseCBA<TiposCreditoService>
    {
        #region subclase TirNoPer
        //Basado en https://stackoverflow.com/questions/5179866/xirr-calculation
        public class TirNoPer
        {
            public const double tol = 0.0000000001;
            public delegate double fx(double x);

            public static fx composeFunctions(fx f1, fx f2)
            {
                return (double x) => f1(x) + f2(x);
            }

            public static fx f_xirr(double p, double dt, double dt0)
            {
                return (double x) => p * Math.Pow((1.0 + x), ((dt0 - dt) / 365.0));
            }

            public static fx df_xirr(double p, double dt, double dt0)
            {
                return (double x) => (1.0 / 365.0) * (dt0 - dt) * p * Math.Pow((x + 1.0), (((dt0 - dt) / 365.0) - 1.0));
            }

            public static fx total_f_xirr(double[] payments, double[] days)
            {
                fx resf = (double x) => 0.0;

                for (int i = 0; i < payments.Length; i++)
                {
                    resf = composeFunctions(resf, f_xirr(payments[i], days[i], days[0]));
                }

                return resf;
            }

            public static fx total_df_xirr(double[] payments, double[] days)
            {
                fx resf = (double x) => 0.0;

                for (int i = 0; i < payments.Length; i++)
                {
                    resf = composeFunctions(resf, df_xirr(payments[i], days[i], days[0]));
                }

                return resf;
            }

            public static double Newtons_method(double guess, fx f, fx df)
            {
                double x0 = guess;
                double x1 = 0.0;
                double err = 1e+100;

                while (err > tol)
                {
                    x1 = x0 - f(x0) / df(x0);
                    err = Math.Abs(x1 - x0);
                    x0 = x1;
                }

                return x0;
            }

            public static double Calcular(CreditosService credito)
            {
                List<double> lMontos = new List<double>();
                List<double> lVencimientos = new List<double>();
                CreditosService.CalendarioService[] calendario;
                bool tieneFechaRetiro = credito.FechaRetiro.HasValue;

                //Si se esta simulando el credito entonces no existe en base de datos ni tiene fecha de retiro
                if (credito.ExisteEnDB && credito.FechaRetiro.HasValue)
                {
                    calendario = credito.Calendario;
                }
                else
                {
                    if (!tieneFechaRetiro)
                        credito.FechaRetiro = credito.FechaSolicitud;

                    if (credito.ExisteEnDB)
                        calendario = credito.Calendario;
                    else
                        calendario = TiposCreditoService.CalcularCuotasPorTipo(credito);
                }

                decimal totalInteresSinIva = 0;
                foreach (var c in calendario)
                    totalInteresSinIva += c.MontoInteresADevengar + c.MontoInteresDevengado + c.MontoInteresEnSuspenso;

                //Desembolso
                lMontos.Add((double)-(credito.MontoTotal - totalInteresSinIva));
                lVencimientos.Add(0);

                //Pago en cada vencimiento
                foreach (var c in calendario)
                {
                    //Sumar capital mas intereses, sin impuesto
                    lMontos.Add((double)Math.Round(c.MontoCapital + c.MontoInteresADevengar + c.MontoInteresDevengado + c.MontoInteresEnSuspenso + c.MontoImpuesto, credito.Moneda.CantidadDecimales));
                    lVencimientos.Add((double)(c.FechaVencimiento.Date - credito.FechaRetiro.Value.Date).Days);
                }

                if (!tieneFechaRetiro)
                    credito.FechaRetiro = null;

                double[] payments = lMontos.ToArray();
                double[] days = lVencimientos.ToArray();
                double aproximacion = 0.1;

                if(credito.PorcentajeInteres.HasValue)
                    aproximacion = (double)credito.PorcentajeInteres.Value / 100;

                double xirr = Newtons_method(aproximacion,
                                             total_f_xirr(payments, days),
                                             total_df_xirr(payments, days));

                return xirr * 100;
            }
        }
        #endregion subclase TirNoPer

        #region GetTiposCreditoDataTable
        public static DataTable GetTiposCreditoDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                //Se ordena por id debido a que Frances es el mas utilizado, luego aleman y por ultimo americano
                return sesion.Db.TIPOS_CREDITOCollection.GetAsDataTable(string.Empty, TiposCreditoService.Id_NombreCol);
            }
        }
        #endregion GetTiposCreditoDataTable

        #region CalcularCuotasPorTipo
        public static CreditosService.CalendarioService[] CalcularCuotasPorTipo(CreditosService credito)
        {
            if (credito.CantidadCuotas <= 0)
                throw new Exception("La cantidad de cuotas debe ser mayor a cero.");

            if (credito.Frecuencia <= 0)
                throw new Exception("La frecuencia debe ser mayor a cero.");

            var cuotas = new CreditosService.CalendarioService[0];
            if (credito.MontoCapitalAprobado > 0)
            {
                switch ((int)credito.TipoCreditoId)
                {
                    case Definiciones.TiposCredito.Frances: cuotas = CalcularMetodoFrances(credito); break;
                    case Definiciones.TiposCredito.Aleman: cuotas = CalcularMetodoAleman(credito); break;
                    case Definiciones.TiposCredito.Americano: cuotas = CalcularMetodoAmericano(credito); break;
                    case Definiciones.TiposCredito.InteresDirecto: cuotas = CalcularMetodoInteresDirecto(credito); break;
                }
            }

            credito.MontoTotal = 0;
            foreach (var c in cuotas)
                credito.MontoTotal += c.MontoCapital + c.MontoInteresADevengar + c.MontoImpuesto;

            return cuotas;
        }

        public static CreditosService.CalendarioService[] CalcularCuotasPorTipo(int tipo_credito_id, string tipo_frecuencia, int frecuencia, DateTime fecha_solicitud, DateTime primer_vencimiento, decimal total_capital, int cantidad_cuotas, decimal porcentaje_interes, decimal monto_redondeo_cuotas, bool interes_incluye_impuesto)
        {
            CreditosService credito = CreditosService.Instancia;
            credito.TipoCreditoId = tipo_credito_id;
            credito.InteresCompuesto = Definiciones.SiNo.Si;
            credito.TipoFrecuencia = tipo_frecuencia;
            credito.Frecuencia = frecuencia;
            credito.FechaSolicitud = fecha_solicitud;
            credito.FechaPrimerVencimiento = primer_vencimiento;
            credito.MontoCapitalAprobado = total_capital;
            credito.MontoCapitalSolicitado = total_capital;
            credito.CantidadCuotas = cantidad_cuotas;
            credito.InteresIncluyeImpuesto = interes_incluye_impuesto ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            credito.PorcentajeInteres = porcentaje_interes;
            credito.MontoRedondeo = monto_redondeo_cuotas;

            return CalcularCuotasPorTipo(credito);
        }
        #endregion CalcularCuotasPorTipo

        #region CalcularMetodoFrances
        public static CreditosService.CalendarioService[] CalcularMetodoFrances(CreditosService credito)
        {
            CreditosService.CalendarioService[] cuotas = new CreditosService.CalendarioService[(int)credito.CantidadCuotas];
            TiposArticuloFinancieroRangoService tipoRangoInteres = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);
            decimal porcentajeImpuesto = ImpuestosService.GetPorcentajePorId(tipoRangoInteres.Articulo.ImpuestoId);
            decimal totalPagoCapital;
            double tasaDiaria = 0, interesCorriente, montoCuotaRedondeado, errorRedondeoCuota = 0;
            double redondeoCuotas = (double)credito.MontoRedondeo;
            DateTime fechaInicial;
            int[] diasTranscurridos = new int[cuotas.Length];

            decimal[] montoCuota = new decimal[3];
            decimal[] error = new decimal[3];
            decimal errorMaximo = 0.00001m;
            int maxIteraciones = 1000, contador;

            var tipo = new { Minimo = 0, Maximo = 1, Proximo = 2 };

            //Se agrega el impuesto si no estaba incluido
            interesCorriente = (double)credito.PorcentajeInteres.Value;
            if (credito.InteresIncluyeImpuesto == Definiciones.SiNo.No)
                interesCorriente *= (double)(100 + porcentajeImpuesto) / 100;

            int diasEnAnho = credito.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;
            if (credito.InteresCompuesto == Definiciones.SiNo.Si)
                tasaDiaria = Math.Pow(interesCorriente / 100 + 1, 1.00 / diasEnAnho) - 1;
            else
                tasaDiaria = interesCorriente / 100 / diasEnAnho;
            
            fechaInicial = credito.FechaRetiro.HasValue ? credito.FechaRetiro.Value.Date : credito.FechaSolicitud.Date;

            #region calcular fechas de vencimiento y numero cuota
            for (int i = 0; i < credito.CantidadCuotas; i++)
            {
                cuotas[i] = new CreditosService.CalendarioService();
                if (credito.Id.HasValue)
                    cuotas[i].CreditoId = credito.Id.Value;

                switch (credito.TipoFrecuencia)
                {
                    case Definiciones.TiposIntervalo.Anhos: cuotas[i].FechaVencimiento = credito.FechaPrimerVencimiento.AddYears(i * (int)credito.Frecuencia); break;
                    case Definiciones.TiposIntervalo.Dias: cuotas[i].FechaVencimiento = credito.FechaPrimerVencimiento.AddDays(i * (int)credito.Frecuencia); break;
                    case Definiciones.TiposIntervalo.Meses: cuotas[i].FechaVencimiento = credito.FechaPrimerVencimiento.AddMonths(i * (int)credito.Frecuencia); break;
                    case Definiciones.TiposIntervalo.Semanas: cuotas[i].FechaVencimiento = credito.FechaPrimerVencimiento.AddDays(i * 7 * (int)credito.Frecuencia); break;
                }

                if (i == 0)
                    diasTranscurridos[i] = (cuotas[i].FechaVencimiento.Date - fechaInicial).Days;
                else
                    diasTranscurridos[i] = (cuotas[i].FechaVencimiento.Date - cuotas[i - 1].FechaVencimiento.Date).Days;

                cuotas[i].NumeroCuota = i + 1;
            }
            #endregion calcular fechas de vencimiento y numero cuota

            if (tasaDiaria > 0)
            {
                #region aproximar monto de la cuota
                double[] deudaSinPagos = new double[cuotas.Length];
                double[] pagoMensualValorizado = new double[cuotas.Length];
                double[] capitalVivo = new double[cuotas.Length];
                
                #region Inicializar topes maximo y minimo de cuota con su error respectivo
                montoCuota[tipo.Maximo] = credito.MontoCapitalAprobado * (1 + (decimal)tasaDiaria * credito.CantidadDias) / credito.CantidadCuotas;
                error[tipo.Maximo] = CalcularErrorCuota(montoCuota[tipo.Maximo], tasaDiaria, credito, cuotas, diasTranscurridos, ref deudaSinPagos, ref pagoMensualValorizado, ref capitalVivo);

                montoCuota[tipo.Minimo] = credito.MontoCapitalAprobado / credito.CantidadCuotas;
                error[tipo.Minimo] = CalcularErrorCuota(montoCuota[tipo.Minimo], tasaDiaria, credito, cuotas, diasTranscurridos, ref deudaSinPagos, ref pagoMensualValorizado, ref capitalVivo);
                #endregion Inicializar topes maximo y minimo de cuota con su error respectivo

                contador = 0;
                do
                {
                    //Sea una recta definida por los puntos <cuota minim; error minimo> y <cuota maxima; error maximo>
                    //El nuevo monto de cuota a utilizar sera donde la recta intersecte al eje Y (error = 0)
                    if (montoCuota[tipo.Minimo] == montoCuota[tipo.Maximo])
                        montoCuota[tipo.Proximo] = montoCuota[tipo.Maximo];
                    else
                        montoCuota[tipo.Proximo] = montoCuota[tipo.Minimo] - error[tipo.Minimo] * (montoCuota[tipo.Maximo] - montoCuota[tipo.Minimo]) / (error[tipo.Maximo] - error[tipo.Minimo]);
                    error[tipo.Proximo] = CalcularErrorCuota(montoCuota[tipo.Proximo], tasaDiaria, credito, cuotas, diasTranscurridos, ref deudaSinPagos, ref pagoMensualValorizado, ref capitalVivo);

                    if (error[tipo.Proximo] > 0)
                    {
                        montoCuota[tipo.Maximo] = montoCuota[tipo.Proximo];
                        error[tipo.Maximo] = error[tipo.Proximo];
                    }
                    else
                    {
                        montoCuota[tipo.Minimo] = montoCuota[tipo.Proximo];
                        error[tipo.Minimo] = error[tipo.Proximo];
                    }
                }
                while (Math.Abs(error[tipo.Proximo]) > errorMaximo && contador++ < maxIteraciones);
                #endregion aproximar monto de la cuota

                //Redondear el monto de la cuota segun politica
                if (credito.MontoRedondeo <= 0)
                {
                    montoCuotaRedondeado = (double)montoCuota[tipo.Proximo];
                    errorRedondeoCuota = 0;
                }
                else
                {
                    montoCuotaRedondeado = Math.Round((double)montoCuota[tipo.Proximo] / redondeoCuotas) * redondeoCuotas;

                    if ((double)montoCuota[tipo.Proximo] > montoCuotaRedondeado)
                        montoCuotaRedondeado += redondeoCuotas;
                    errorRedondeoCuota = (double)montoCuota[tipo.Proximo] - montoCuotaRedondeado;
                }

                totalPagoCapital = 0;
                for (int i = 0; i < credito.CantidadCuotas; i++)
                {
                    if (i == 0)
                    {
                        cuotas[i].MontoInteresADevengar = (decimal)deudaSinPagos[i] - credito.MontoCapitalAprobado;
                    }
                    else
                    {
                        if (credito.InteresCompuesto == Definiciones.SiNo.Si)
                            cuotas[i].MontoInteresADevengar = (decimal)(capitalVivo[i - 1] * Math.Pow(1 + tasaDiaria, diasTranscurridos[i]) - capitalVivo[i - 1]);
                        else
                            cuotas[i].MontoInteresADevengar = (decimal)(capitalVivo[i - 1] * (1 + tasaDiaria * diasTranscurridos[i]) - capitalVivo[i - 1]);
                    }

                    cuotas[i].MontoCapital = (decimal)montoCuotaRedondeado - cuotas[i].MontoInteresADevengar;
                    totalPagoCapital += cuotas[i].MontoCapital;

                    cuotas[i].MontoImpuesto = cuotas[i].MontoInteresADevengar / (1 + 100 / porcentajeImpuesto);
                    cuotas[i].MontoInteresADevengar -= cuotas[i].MontoImpuesto;
                }

                //Se modifica en el error por redondeo
                cuotas[cuotas.Length - 1].MontoCapital += error[tipo.Proximo];
            }
            else
            {
                montoCuota[tipo.Proximo] = credito.MontoCapitalAprobado / credito.CantidadCuotas;

                //Redondear el monto de la cuota segun politica
                montoCuotaRedondeado = MonedasService.Redondear((double)montoCuota[tipo.Proximo]);

                for (int i = 0; i < credito.CantidadCuotas; i++)
                {
                    cuotas[i].MontoInteresADevengar = 0;
                    cuotas[i].MontoImpuesto = 0;
                    cuotas[i].MontoCapital = (decimal)montoCuotaRedondeado;
                }

                totalPagoCapital = (decimal)montoCuotaRedondeado * credito.CantidadCuotas;
            }

            //Se modifica el capital de la ultima cuota por el error arrastrado
            cuotas[cuotas.Length - 1].MontoCapital += (decimal)errorRedondeoCuota * credito.CantidadCuotas;

            return cuotas;
        }
        #endregion CalcularMetodoFrances

        #region CalcularErrorCuota
        private static decimal CalcularErrorCuota(decimal monto_cuota, double tasa_diaria, CreditosService credito, CreditosService.CalendarioService[] cuotas, int[] dias_transcurridos, ref double[] deuda_sin_pagos, ref double[] pago_mensual_valorizado, ref double[] capital_vivo)
        {
            double totalPagoMensualValorizado = 0;

            for (int i = 0; i < credito.CantidadCuotas; i++)
            {
                if (i == 0)
                {
                    if (credito.InteresCompuesto == Definiciones.SiNo.Si)
                        deuda_sin_pagos[i] = (double)credito.MontoCapitalAprobado * Math.Pow(1 + tasa_diaria, dias_transcurridos[i]);
                    else
                        deuda_sin_pagos[i] = (double)credito.MontoCapitalAprobado * (1 + tasa_diaria * dias_transcurridos[i]);
                    capital_vivo[i] = deuda_sin_pagos[i] - (double)monto_cuota;
                }
                else
                {
                    if (credito.InteresCompuesto == Definiciones.SiNo.Si)
                    {
                        deuda_sin_pagos[i] = deuda_sin_pagos[i - 1] * Math.Pow(1 + tasa_diaria, dias_transcurridos[i]);
                        capital_vivo[i] = capital_vivo[i - 1] * Math.Pow(1 + tasa_diaria, dias_transcurridos[i]) - (double)monto_cuota;
                    }
                    else
                    {
                        deuda_sin_pagos[i] = deuda_sin_pagos[i - 1] * (1 + tasa_diaria * dias_transcurridos[i]);
                        capital_vivo[i] = capital_vivo[i - 1] * (1 + tasa_diaria * dias_transcurridos[i]) - (double)monto_cuota;
                    }
                }

                if (credito.InteresCompuesto == Definiciones.SiNo.Si)
                    pago_mensual_valorizado[i] = (double)monto_cuota * Math.Pow(1 + tasa_diaria, (cuotas[cuotas.Length - 1].FechaVencimiento.Date - cuotas[i].FechaVencimiento.Date).Days);
                else
                    pago_mensual_valorizado[i] = (double)monto_cuota * (1 + tasa_diaria * (cuotas[cuotas.Length - 1].FechaVencimiento.Date - cuotas[i].FechaVencimiento.Date).Days);

                totalPagoMensualValorizado += pago_mensual_valorizado[i];
            }

            //return (decimal)(deuda_sin_pagos[cuotas.Length - 1] - totalPagoMensualValorizado);
            return (decimal)capital_vivo[cuotas.Length - 1];
        }
        #endregion CalcularErrorCuota

        //TODO: falta implementar
        #region CalcularMetodoAleman
        private static CreditosService.CalendarioService[] CalcularMetodoAleman(CreditosService credito)
        {
            throw new NotImplementedException("Tipo de cálculo aún no implementado");
        }
        #endregion CalcularMetodoAleman

        //TODO: falta implementar
        #region CalcularMetodoAmericano
        private static CreditosService.CalendarioService[] CalcularMetodoAmericano(CreditosService credito)
        {
            throw new NotImplementedException("Tipo de cálculo aún no implementado");
        }
        #endregion CalcularMetodoAmericano

        #region CalcularMetodoInteresDirecto
        /// <summary>
        /// Calculars the metodo interes directo.
        /// </summary>
        /// <param name="credito">The credito.</param>
        /// <param name="monto_redondeo_cuotas">The monto_redondeo_cuotas.</param>
        /// <returns></returns>
        private static CreditosService.CalendarioService[] CalcularMetodoInteresDirecto(CreditosService credito)
        {
            CreditosService.CalendarioService[] cuotas = new CreditosService.CalendarioService[(int)credito.CantidadCuotas];
            TiposArticuloFinancieroRangoService tipoRangoInteres = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);
            decimal porcentajeImpuesto = ImpuestosService.GetPorcentajePorId(tipoRangoInteres.Articulo.ImpuestoId);

            double montoCuota, montoCuotaRedondeado, montoInteres, calculoInteres;
            DateTime ultimoVencimiento = credito.FechaPrimerVencimiento;
            TimeSpan span;
            double montoRedondeoCuotas = double.Parse(credito.MontoRedondeo.ToString());

            switch (credito.TipoFrecuencia)
            {
                case Definiciones.TiposIntervalo.Anhos: ultimoVencimiento = credito.FechaPrimerVencimiento.AddYears((int)(credito.Frecuencia * credito.CantidadCuotas)); break;
                case Definiciones.TiposIntervalo.Dias: ultimoVencimiento = credito.FechaPrimerVencimiento.AddDays((int)(credito.Frecuencia * credito.CantidadCuotas)); break;
                case Definiciones.TiposIntervalo.Meses: ultimoVencimiento = credito.FechaPrimerVencimiento.AddMonths((int)(credito.Frecuencia * credito.CantidadCuotas)); break;
                case Definiciones.TiposIntervalo.Semanas: ultimoVencimiento = credito.FechaPrimerVencimiento.AddDays((int)(7 * credito.Frecuencia * credito.CantidadCuotas)); break;
            }
            span = ultimoVencimiento - credito.FechaPrimerVencimiento;

            if (credito.TipoInteresAnual == Definiciones.SiNo.Si)
            {
                if (credito.AnhoComercial == Definiciones.SiNo.Si)
                    calculoInteres = (double)(credito.PorcentajeInteres / 360);
                else
                    calculoInteres = (double)(credito.PorcentajeInteres / 365);
                calculoInteres *= span.Days;
                montoInteres = calculoInteres / 100 * (double)(credito.MontoCapitalSolicitado / credito.CantidadCuotas);
            }
            else
            {
                //Cantidad de meses exacta o aproximada si la frecuencia no es mensual
                if(credito.TipoFrecuencia == Definiciones.TiposIntervalo.Meses)
                    calculoInteres = (double)credito.PorcentajeInteres;
                else
                    calculoInteres = (double)(credito.PorcentajeInteres / span.Days / 30);

                montoInteres = calculoInteres / 100 * (double)credito.MontoCapitalSolicitado;
            }

            //Se agrega el impuesto a tasa periodica, si no lo tiene incluido para que el redondeo sea sobre la cuota total
            if (credito.InteresIncluyeImpuesto == Definiciones.SiNo.No)
                montoInteres *= (double)(100 + porcentajeImpuesto) / 100;
            
            montoCuota = montoInteres + (double)(credito.MontoCapitalSolicitado / credito.CantidadCuotas);

            //Redondear el monto de la cuota segun politica
            if (credito.MontoRedondeo <= 0)
            {
                montoCuotaRedondeado = montoCuota;
            }
            else
            {
                montoCuotaRedondeado = double.Parse((Math.Round(montoCuota / montoRedondeoCuotas) * montoRedondeoCuotas).ToString());

                if (montoCuota > montoCuotaRedondeado)
                    montoCuotaRedondeado += montoRedondeoCuotas;
            }

            decimal montoCapital = credito.MontoCapitalAprobado / credito.CantidadCuotas;
            for (int i = 0; i < credito.CantidadCuotas; i++)
            {
                cuotas[i] = new CreditosService.CalendarioService();
                if (credito.Id.HasValue)
                    cuotas[i].CreditoId = credito.Id.Value;
                cuotas[i].MontoCapital = montoCapital;
                cuotas[i].MontoInteresADevengar = (decimal)montoCuotaRedondeado - montoCapital;
                
                cuotas[i].MontoImpuesto = cuotas[i].MontoInteresADevengar / (1 + 100 / porcentajeImpuesto);
                cuotas[i].MontoInteresADevengar -= cuotas[i].MontoImpuesto;

                cuotas[i].NumeroCuota = i + 1;

                switch (credito.TipoFrecuencia)
                {
                    case Definiciones.TiposIntervalo.Anhos: cuotas[i].FechaVencimiento = credito.FechaPrimerVencimiento.AddYears(i * (int)credito.Frecuencia); break;
                    case Definiciones.TiposIntervalo.Dias: cuotas[i].FechaVencimiento = credito.FechaPrimerVencimiento.AddDays(i * (int)credito.Frecuencia); break;
                    case Definiciones.TiposIntervalo.Meses: cuotas[i].FechaVencimiento = credito.FechaPrimerVencimiento.AddMonths(i * (int)credito.Frecuencia); break;
                    case Definiciones.TiposIntervalo.Semanas: cuotas[i].FechaVencimiento = credito.FechaPrimerVencimiento.AddDays(i * 7 * (int)credito.Frecuencia); break;
                }
            }

            return cuotas;
        }
        #endregion CalcularMetodoInteresDirecto

        #region GetCapitalMetodoFrances
        public static decimal GetCapitalMetodoFrances(bool intervalo_en_meses, int intervalo, decimal total, int cantidad_cuotas, decimal porcentaje_interes, decimal porcentaje_gastos_administrativos, bool interes_incluye_impuesto)
        {
            if (cantidad_cuotas <= 0)
                throw new Exception("La cantidad de cuotas debe ser mayor a cero.");

            double relacionInteresGastoAdmin;
            double montoCuota, capital;
            double periodicidad, tasaPeriodica;

            periodicidad = double.Parse((360 / intervalo).ToString());
            if (intervalo_en_meses)
                periodicidad /= 30;

            tasaPeriodica = double.Parse((porcentaje_interes + porcentaje_gastos_administrativos).ToString()) / periodicidad;

            if (porcentaje_interes + porcentaje_gastos_administrativos > 0)
                relacionInteresGastoAdmin = double.Parse((porcentaje_interes / (porcentaje_interes + porcentaje_gastos_administrativos)).ToString());
            else
                relacionInteresGastoAdmin = 0;

            montoCuota = double.Parse((total / ((decimal)0 + cantidad_cuotas)).ToString());

            if (interes_incluye_impuesto)
            {
                TiposArticuloFinancieroRangoService interes = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);
                montoCuota /= (double)(1 + (100 / ImpuestosService.GetPorcentajePorId(interes.Articulo.ImpuestoId)));
            }

            /*
             Basado en:
             http://www.zonabancos.com/ar/analisis/blogs/10-matematica-financiera-aplicada-al-negocio-bancario-14616-sistemas-de-amortizacion-de-prestamos-sistema-frances.aspx
             http://es.wikipedia.org/wiki/Hipoteca#C.C3.A1lculo_de_la_cuota_peri.C3.B3dica_.28otros.29
             */

            if (tasaPeriodica > 0)
                capital = montoCuota * double.Parse((100 * (1 - Math.Pow(1 + tasaPeriodica / 100, -cantidad_cuotas))).ToString()) / tasaPeriodica;
            else
                capital = montoCuota * cantidad_cuotas;

            return decimal.Parse(capital.ToString());
        }
        #endregion GetCapitalMetodoFrances

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TIPOS_CREDITO"; }
        }
        public static string Id_NombreCol
        {
            get { return TIPOS_CREDITOCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TIPOS_CREDITOCollection.NOMBREColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TIPOS_CREDITOCollection.OBSERVACIONColumnName; }
        }
        #endregion Accessors

        #region Propiedades
        protected TIPOS_CREDITORow row;
        protected TIPOS_CREDITORow rowSinModificar;
        public class Modelo : TIPOS_CREDITOCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TIPOS_CREDITOCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TIPOS_CREDITORow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(TIPOS_CREDITORow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public TiposCreditoService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TiposCreditoService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TiposCreditoService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private TiposCreditoService(TIPOS_CREDITORow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            throw new Exception("No puede modificarse.");
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override TiposCreditoService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.IDColumnName:
                            sb.Append(f.Columna + " = " + f.Valor);
                            break;
                        case Modelo.NOMBREColumnName:
                        case Modelo.OBSERVACIONColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.NOMBREColumnName);
            TIPOS_CREDITORow[] rows = sesion.db.TIPOS_CREDITOCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            TiposCreditoService[] b = new TiposCreditoService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                b[i] = new TiposCreditoService(rows[i]);
            return b;
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("Falta implementar.");
        }
        #endregion ToEDI

    }
}
