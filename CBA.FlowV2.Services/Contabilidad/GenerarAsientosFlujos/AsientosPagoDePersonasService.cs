#region Using
using System.Collections;
using CBA.FlowV2.Services.Base;
using System;
using System.Data;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.NotasCreditoPersona;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosPagoDePersonasService : AsientosAutomaticosService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacionCabecera : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacionCabecera(object caso_cabecera, object caso_detalle, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                var cabecera = (PagosDePersonaService)caso_cabecera;
                decimal porcentaje = 100;

                this.porcentajeDetalleSobreTotal.Add(cabecera.Id ?? (decimal)1, porcentaje);
            }
            #endregion Constructor
        }

        private class CentrosCostoAplicacionDocumentos : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacionDocumentos(object caso_cabecera, object caso_detalle, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                var cabecera = (PagosDePersonaService)caso_cabecera;
                var detalles = (CuentaCorrientePagosPersonaDocumentoService[])caso_detalle;

                decimal suma = 0;
                for (int i = 0; i < detalles.Length; i++)
                    suma += detalles[i].Monto.Value / detalles[i].CotizacionMoneda.Value;
                
                if (suma > 0)
                {
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        decimal porcentaje = detalles[i].Monto.Value / detalles[i].CotizacionMoneda.Value / suma;
                        this.porcentajeDetalleSobreTotal.Add(detalles[i].Id ?? (decimal)i, porcentaje);
                    }
                }
            }
            #endregion Constructor
        }

        private class CentrosCostoAplicacionValores : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacionValores(object caso_cabecera, object caso_detalle, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                var cabecera = (PagosDePersonaService)caso_cabecera;
                var detalles = (CuentaCorrientePagosPersonaDetalleService[])caso_detalle;

                decimal suma = 0;
                for (int i = 0; i < detalles.Length; i++)
                    suma += detalles[i].Monto.Value / detalles[i].CotizacionMoneda;

                if (suma > 0)
                {
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        decimal porcentaje = detalles[i].Monto.Value / detalles[i].CotizacionMoneda / suma;
                        this.porcentajeDetalleSobreTotal.Add(detalles[i].Id ?? (decimal)i, porcentaje);
                    }
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region Constructor
        public AsientosPagoDePersonasService(int asiento_automatico_id)
            : base(asiento_automatico_id){}
        #endregion Constructor

        #region CalcularObservacion
        protected override string CalcularObservacionCabecera(CasosService caso, object cabecera, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(this.EstructuraObservacion);
            var casoCabecera = (PagosDePersonaService)cabecera;

            foreach (string campo in eo.Campos)
            {
                switch (campo)
                {
                    case EstructuraObservacionHelper.Campo.CasoId:
                        eo.Set(campo, casoCabecera.CasoId);
                        break;
                    case EstructuraObservacionHelper.Campo.CasoNroComprobante:
                        eo.Set(campo, caso.NroComprobante);
                        break;
                    case EstructuraObservacionHelper.Campo.Sucursal:
                        eo.Set(campo, caso.Sucursal.Nombre);
                        break;
                    case EstructuraObservacionHelper.Campo.Persona:
                        eo.Set(campo, caso.PersonaId.HasValue ? caso.Persona.NombreCompleto : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.Proveedor:
                        eo.Set(campo, caso.ProveedorId.HasValue ? caso.Proveedor.RazonSocial : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.FuncionarioCabecera:
                        eo.Set(campo, caso.FuncionarioId.HasValue ? caso.Funcionario.Persona.NombreCompleto : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.FuncionarioDetalle:
                        eo.Set(campo, casoCabecera.FuncionarioCobradorExternoId.HasValue ? casoCabecera.FuncionarioCobradorExterno.Persona.NombreCompleto : string.Empty);
                        break;
                    default:
                        throw new Exception("Campo no implementado");
                }
            }

            return eo.observacion.Length > 0 ? eo.observacion : this.Nombre;
        }

        private string CalcularObservacionValor(CuentaCorrientePagosPersonaDetalleService valor, SessionService sesion)
        {
            string observacion = string.Empty;

            switch ((int)valor.CtacteValorId)
            {
                case Definiciones.CuentaCorrienteValores.Cheque:
                    if (valor.ChequeCtacteBancoId.HasValue)
                    {
                        var dtCtacteBanco = CuentaCorrienteBancosService.GetBancosDataTable(CuentaCorrienteBancosService.Id_NombreCol + " = " + valor.ChequeCtacteBancoId, string.Empty, false, sesion);
                        observacion = dtCtacteBanco.Rows[0][CuentaCorrienteBancosService.Abreviatura_NombreCol] + ", Nº " + valor.ChequeNroCheque +
                                      ", Vto " + valor.ChequeFechaVencimiento.Value.ToShortDateString();
                        if (valor.ChequeDeTerceros == Definiciones.SiNo.Si)
                            observacion += ", de terceros";
                        if (valor.ChequeEsDiferido == Definiciones.SiNo.Si)
                            observacion += " diferido";
                    }
                    break;
                case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                    observacion = valor.TarjetaNro + "  " + valor.TarjetaTitular;
                    break;
                case Definiciones.CuentaCorrienteValores.Anticipo:
                    if (valor.AnticipoId.HasValue)
                    {
                        var dtAnticipo = AnticiposPersonaService.GetAnticipoPersonaInfoCompleta(AnticiposPersonaService.Id_NombreCol + " = " + valor.AnticipoId, string.Empty, sesion);
                        if (dtAnticipo.Rows.Count > 0)
                        {
                            observacion = "Caso Nº" + dtAnticipo.Rows[0][AnticiposPersonaService.CasoId_NombreCol] +
                                          " saldo: " + dtAnticipo.Rows[0][AnticiposPersonaService.VistaMonedaSimbolo_NombreCol] + "." + ((decimal)dtAnticipo.Rows[0][AnticiposPersonaService.SaldoPorAplicar_NombreCol]).ToString(valor.Moneda.CadenaDecimales);
                        }
                    }
                    break;
                case Definiciones.CuentaCorrienteValores.NotaDeCredito:
                    if (valor.NotaCreditoId.HasValue)
                    {
                        var dtNotaCredito = NotasCreditoPersonaService.GetNotaCreditoPersonaInfoCompleta2(NotasCreditoPersonaService.Id_NombreCol + " = " + valor.NotaCreditoId, string.Empty, sesion);
                        if (dtNotaCredito.Rows.Count > 0)
                        {
                            observacion = "Caso " + dtNotaCredito.Rows[0][NotasCreditoPersonaService.CasoId_NombreCol] + " Nº Comp: " + dtNotaCredito.Rows[0][NotasCreditoPersonaService.NroComprobante_NombreCol] +
                                          " saldo: " + dtNotaCredito.Rows[0][NotasCreditoPersonaService.VistaMonedaSimbolo_NombreCol] + "." + ((decimal)dtNotaCredito.Rows[0][NotasCreditoPersonaService.SaldoPorAplicar_NombreCol]).ToString(valor.Moneda.CadenaDecimales);
                        }
                    }
                    break;
                case Definiciones.CuentaCorrienteValores.DepositoBancario:
                    if (valor.DepositoCtacteBancariasId.HasValue)
                    {
                        var ctacteBancaria = new CuentaCorrienteCuentasBancariasService(valor.DepositoCtacteBancariasId.Value, sesion);
                        observacion = "Cta. " + ctacteBancaria.NumeroCuenta + ", boleta " + valor.DepositoNroBoleta;
                    }
                    break;
                case Definiciones.CuentaCorrienteValores.RetencionIVA:
                    var dtTipoRetencion = TiposRetencionesService.GetTiposRetencionesDataTable(TiposRetencionesService.Id_NombreCol + " = " + (valor.RetencionTipoId.HasValue ? valor.RetencionTipoId : Definiciones.TiposRetenciones.IVA), string.Empty, sesion);
                    var casoRetenido = new CasosService(valor.RetencionCasoId.Value, sesion);
                    observacion = "Retención " + dtTipoRetencion.Rows[0][TiposRetencionesService.Nombre_NombreCol] + " " + valor.RetencionNroComprobante + " del " + valor.RetencionFecha.Value.ToShortDateString() +
                                  " sobre Caso Nº" + casoRetenido.Id + " con comprobante " + casoRetenido.NroComprobante + ".";
                    break;
                case Definiciones.CuentaCorrienteValores.TransferenciaCtacte:
                    if (valor.TransferenciaCtactePersId.HasValue)
                    {
                        var dtTransferenciaCtacte = TransferenciasCtaCtePersonasService.GetTransferenciaInfoCompleta(TransferenciasCtaCtePersonasService.Id_NombreCol + " = " + valor.TransferenciaCtactePersId, string.Empty, sesion);
                        if (dtTransferenciaCtacte.Rows.Count > 0)
                        {
                            observacion = "Caso Nº" + dtTransferenciaCtacte.Rows[0][TransferenciasCtaCtePersonasService.CasoId_NombreCol] +
                                          " saldo: " + valor.Moneda.Simbolo + "." + ((decimal)dtTransferenciaCtacte.Rows[0][TransferenciasCtaCtePersonasService.VistaMontoSaldoDebito_NombreCol]).ToString(valor.Moneda.CadenaDecimales);
                        }
                    }
                    break;
                case Definiciones.CuentaCorrienteValores.Giro:
                    observacion = valor.GiroComprobante;
                    break;
            }

            return observacion;
        }
        #endregion CalcularObservacion

        #region AsentarBorradorAAprobado
        /// <summary>
        /// Asentars the borrador A aprobado.
        /// - Debe en (Activo) Disponibilidades por Valores Vencidos Recibidos
        /// - Debe en (Activo) Disponibilidades por Valores a Vencer Recibidos
        /// - Haber en (Activo) Recaudaciones en Proceso por pago de documentos contado
        /// - Haber en (Activo) Clientes por pago de documentos credito
        /// - Haber en (Activo) Disponibilidades por vuelto
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarBorradorAAprobado(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Documentos,
                Definiciones.Contabilidad.ClavesDatos.Valores,
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (PagosDePersonaService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDocumentos = (CuentaCorrientePagosPersonaDocumentoService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Documentos];
            var casoValores = (CuentaCorrientePagosPersonaDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Valores];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux = 0;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacionCabecera centrosCostoApCabecera = new CentrosCostoAplicacionCabecera(casoCabecera, null, new PagosDePersonaService(), sesion);
            CentrosCostoAplicacionDocumentos centrosCostoApDocumentos = new CentrosCostoAplicacionDocumentos(casoCabecera, casoDocumentos, new PagosDePersonaService(), sesion);
            CentrosCostoAplicacionValores centrosCostoApValores = new CentrosCostoAplicacionValores(casoCabecera, casoValores, new PagosDePersonaService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaCompra(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.Fecha, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if (casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.CasoId);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, CalcularObservacionCabecera(casoCabecera.Caso, casoCabecera, sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.Activo_AumentarDisponibilidadesValoresVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            //Asentar solo si el valor esta vencido
                            if (casoValores[j].ChequeFechaVencimiento.HasValue && casoValores[j].ChequeFechaVencimiento.Value.Date > casoCabecera.Fecha.Date)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);

                            if (casoValores[j].CtacteValorId == Definiciones.CuentaCorrienteValores.TransferenciaBancaria && casoValores[j].TransferenciaBancariaId.HasValue)
                            {
                                DataTable dtTransferenciaBancaria = TransferenciasBancariasService.GetDataTable(TransferenciasBancariasService.Id_NombreCol + " = " +  casoValores[j].TransferenciaBancariaId.Value, string.Empty);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.CtacteBancariaDestinoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.TextoPredefinidoId_NombreCol]);
                            }
                            else if (casoValores[j].CtacteValorId == Definiciones.CuentaCorrienteValores.DepositoBancario && casoValores[j].DepositoCtacteBancariasId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].DepositoCtacteBancariasId.Value);
                            }
                            else if (casoValores[j].CtacteValorId == Definiciones.CuentaCorrienteValores.TarjetaDeCredito && casoValores[j].CtacteProcesadoraTarjetaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol, casoValores[j].CtacteProcesadoraTarjetaId);
                            }
                            
                            if (!parametrosElegirCuenta.ContainsKey(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].ChequeCtacteBancoId);
                            if (!parametrosElegirCuenta.ContainsKey(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);

                            if (casoValores[j].CtacteChequeRecibidoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesRecibidosService.GetEstado(casoValores[j].CtacteChequeRecibidoId.Value, sesion));

                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].Monto.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = CalcularObservacionValor(casoValores[j], sesion);

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoValores[j].MonedaId, casoValores[j].CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApValores, casoValores[j].Id ?? j, 100,
                                             centrosCostoApValores.Seleccionar(casoValores[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso,casoCabecera, casoValores[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApValores, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.Activo_AumentarDisponibilidadesValoresAVencer:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            //Asentar solo si el valor es cheque y no esta vencido
                            if (casoValores[j].CtacteValorId != Definiciones.CuentaCorrienteValores.Cheque)
                                continue;
                            if (casoValores[j].ChequeFechaVencimiento.HasValue && casoValores[j].ChequeFechaVencimiento.Value.Date <= casoCabecera.Fecha.Date)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].ChequeCtacteBancoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);
                            if (casoValores[j].CtacteChequeRecibidoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesRecibidosService.GetEstado(casoValores[j].CtacteChequeRecibidoId.Value, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].Monto.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = CalcularObservacionValor(casoValores[j], sesion);

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoValores[j].MonedaId, casoValores[j].CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApValores, casoValores[j].Id ?? j, 100,
                                             centrosCostoApValores.Seleccionar(casoValores[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso,casoCabecera, casoValores[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApValores, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.Activo_DisminuirRecaudacionesEnProceso:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            FacturasClienteService facturaCliente = null;
                            CuentaCorrientePersonasService ccpp = new CuentaCorrientePersonasService(casoDocumentos[j].CtactePersonaId.Value, sesion);

                            if (casoDocumentos[j].CtactePersonaId.HasValue  )
                            {
                                if (ccpp.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                                    facturaCliente = FacturasClienteService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                            }
                            if (facturaCliente != null && facturaCliente.TipoFacturaId == Definiciones.TipoFactura.Contado)
                            {
                                for (int k = 0; k < facturaCliente.FacturaClienteDetalles.Length; k++)
                                {
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, facturaCliente.FacturaClienteDetalles[k].ArticuloId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.FamiliaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.GrupoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.SubGrupoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].ImpuestoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, facturaCliente.DepositoId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;

                                    montoAux = facturaCliente.FacturaClienteDetalles[k].TotalNeto * casoDocumentos[j].Monto.Value / facturaCliente.TotalNeto.Value;

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = CalcularObservacionValor(casoValores[j], sesion);

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    decimal cotizacionCompra = CotizacionesService.GetCotizacionMonedaCompra(Definiciones.Paises.Paraguay, monedaPais, facturaCliente.Fecha.Value);

                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionCompra, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                                    #endregion seleccionar cuentas contables
                                }
                            }
                            else
                            {
                                //Se asienta si:
                                //  - Es un recargo y se emiten facturas contado
                                //  - Es un pago sobre una factura de personas contado
                                // Si es Credito de Personas se asienta solo intereses y gasto administrativo si esta configurado para facturar al cobrar
                                
                                if ((casoDocumentos[j].CtactePersonaId.HasValue || casoDocumentos[j].CtactePersona != null))
                                {
                                    //if (casoDocumentos[j].CtactePersona.TipoDocumento != Definiciones.TipoFactura.Contado)
                                    if (ccpp.TipoDocumento != Definiciones.TipoFactura.Contado)
                                        continue;
                                }

                                if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                    continue;

                                if (casoDocumentos[j].CtactePagoPersonaRecargoId.HasValue && !casoCabecera.FCCliente1CompAutonId.HasValue)
                                    continue;
                                
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables
                                
                                montoAux = casoDocumentos[j].Monto.Value;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoDocumentos[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDocumentos, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.Activo_DisminuirClientes:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            FacturasClienteService facturaCliente = null;
                            CuentaCorrientePersonasService ccpp = new CuentaCorrientePersonasService(casoDocumentos[j].CtactePersonaId.Value, sesion);

                            if (casoDocumentos[j].CtactePersonaId.HasValue)
                            {
                                if (ccpp.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                                    facturaCliente = FacturasClienteService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                            }

                            if (facturaCliente != null && facturaCliente.TipoFacturaId == Definiciones.TipoFactura.Credito)
                            {
                                for (int k = 0; k < facturaCliente.FacturaClienteDetalles.Length; k++)
                                {
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, facturaCliente.FacturaClienteDetalles[k].ArticuloId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.FamiliaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.GrupoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.SubGrupoId);
									parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].ImpuestoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, facturaCliente.DepositoId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;

                                    montoAux = facturaCliente.FacturaClienteDetalles[k].TotalNeto * casoDocumentos[j].Monto.Value / facturaCliente.TotalNeto.Value;

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = CalcularObservacionValor(casoValores[j], sesion);

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    decimal cotizacionCompra = CotizacionesService.GetCotizacionMonedaCompra(Definiciones.Paises.Paraguay, monedaPais, facturaCliente.Fecha.Value);

                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionCompra, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                  centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                  centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                             asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                             asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                             asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                             casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                                    #endregion seleccionar cuentas contables
                                }
                            }
                            else
                            {
                                if ((casoDocumentos[j].CtactePersonaId.HasValue || casoDocumentos[j].CtactePersona != null))
                                {
                                    //if(casoDocumentos[j].CtactePersona.TipoDocumento != Definiciones.TipoFactura.Credito)
                                    if (ccpp.TipoDocumento != Definiciones.TipoFactura.Credito)
                                        continue;
                                }

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                //Se asienta si:
                                //  - No es un recargo y se emiten facturas contado
                                //  - No es un pago sobre una factura de personas contado
                                // Si es un Credito de Personas se asienta por capital o capital + intereses + gastos administrativos segun la configuracion del caso
                                #region permitir asentar o continuar con la iteracion
                                bool noAsentar = false;
                                if (casoDocumentos[j].CtactePagoPersonaRecargoId.HasValue && casoCabecera.FCCliente1CompAutonId.HasValue)
                                    noAsentar = true;

                                montoAux = 0;

                                if (casoDocumentos[j].CtactePersonaId.HasValue)
                                {
                                    if(facturaCliente != null  && facturaCliente.TipoFacturaId == Definiciones.TipoFactura.Contado)
                                        noAsentar = true;
                                    else if (casoDocumentos[j].CtactePersonaId.HasValue) 
                                        if (ccpp.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                            noAsentar = true;
                                }

                                if (noAsentar)
                                    continue;

                                // si no cumplió con los requisitos anteriores entonces se toma el monto pagado del documento
                                if (!casoDocumentos[j].CtactePersonaId.HasValue || ccpp.Caso.FlujoId != Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                                    montoAux = casoDocumentos[j].Monto.Value;
                                #endregion permitir asentar o continuar con la iteracion

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoDocumentos[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDocumentos, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.FacturasProveedor:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if(casoDocumentos[j].CtactePersonaId.HasValue || casoDocumentos[j].CtactePersona != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            if (!casoDocumentos[j].CtactePersonaId.HasValue || casoDocumentos[j].CtactePersona.Caso.FlujoId != Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                                continue;

                            montoAux = casoDocumentos[j].Monto.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = casoDocumentos[j].Observacion;

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDocumentos, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.Activo_DisminuirDisponibilidadesPorVuelto:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = casoCabecera.MontoTotalVuelto;

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                            observacion = casoCabecera.Persona.NombreCompleto;

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaTotalVueltoId, casoCabecera.CotizacionMonedaTotalVuelto, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoApCabecera, casoCabecera.Id, 100,
                                         centrosCostoApCabecera.Seleccionar(casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    casoCabecera.Caso, casoCabecera, null, sesion));
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.PrestamosAClientesNoVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            CuentaCorrientePersonasService ccpp = new CuentaCorrientePersonasService(casoDocumentos[j].CtactePersonaId.Value, sesion);
                            if (casoDocumentos[j].CtactePersonaId.HasValue)
                            {
                                if (ccpp.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                {
                                    var credito = CreditosService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                                    credito.IniciarUsingSesion(sesion);

                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                    if (credito.PersonaGarante1Id != null)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);

                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida(casoDocumentos[j].CtactePersona.CasoId.Value);
                                    if (!fechaCuotaMasVencida.HasValue || fechaCuotaMasVencida.Value.Date > casoDocumentos[j].CtactePersona.FechaVencimiento.Date)
                                        fechaCuotaMasVencida = casoDocumentos[j].CtactePersona.FechaVencimiento.Date;

                                    DateTime fechaCobranza = casoCabecera.Fecha;

                                    double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                    if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays > limiteDias)
                                        continue;

                                    var cuota = casoDocumentos[j].CtactePersona.CalendarioPagosCRCli;
                                    decimal saldoCapital = cuota.MontoCapital + cuota.MontoImpuesto;
                                    decimal saldoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                    decimal totalPagosAnterioresCuota = CuentaCorrientePersonasService.GetPagosAnterioresCuota(casoDocumentos[j].CtactePersonaId.Value, casoCabecera.Fecha);
                                    decimal pagoInteres = Math.Min(saldoInteres, totalPagosAnterioresCuota);
                                    decimal pagoCapital = totalPagosAnterioresCuota - pagoInteres;
                                    saldoInteres -= pagoInteres;

                                    decimal pagoActual = casoDocumentos[j].Monto.Value;
                                    pagoInteres = Math.Min(saldoInteres, pagoActual);
                                    pagoCapital = pagoActual - pagoInteres;

                                    montoAux = pagoCapital;

                                    credito.FinalizarUsingSesion();

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = casoDocumentos[j].Observacion;

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                     centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                                }
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);
                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.InteresesACobrarNoVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            CuentaCorrientePersonasService ccpp = new CuentaCorrientePersonasService(casoDocumentos[j].CtactePersonaId.Value, sesion);
                            if (casoDocumentos[j].CtactePersonaId.HasValue)
                            {
                                if (ccpp.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                {
                                    var credito = CreditosService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                                    credito.IniciarUsingSesion(sesion);

                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                    if (credito.PersonaGarante1Id != null)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida(casoDocumentos[j].CtactePersona.CasoId.Value);
                                    if (!fechaCuotaMasVencida.HasValue || fechaCuotaMasVencida.Value.Date > casoDocumentos[j].CtactePersona.FechaVencimiento.Date)
                                        fechaCuotaMasVencida = casoDocumentos[j].CtactePersona.FechaVencimiento.Date;

                                    DateTime fechaCobranza = casoCabecera.Fecha;
                                    double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                    if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays > limiteDias)
                                        continue;

                                    var cuota = casoDocumentos[j].CtactePersona.CalendarioPagosCRCli;

                                    decimal saldoCapital = cuota.MontoCapital + cuota.MontoImpuesto;
                                    decimal saldoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                    decimal totalPagosAnterioresCuota = CuentaCorrientePersonasService.GetPagosAnterioresCuota(casoDocumentos[j].CtactePersonaId.Value, casoCabecera.Fecha);
                                    decimal pagoInteres = Math.Min(saldoInteres, totalPagosAnterioresCuota);
                                    decimal pagoCapital = totalPagosAnterioresCuota - pagoInteres;
                                    saldoInteres -= pagoInteres;

                                    decimal pagoActual = casoDocumentos[j].Monto.Value;
                                    pagoInteres = Math.Min(saldoInteres, pagoActual);
                                    pagoCapital = pagoActual - pagoInteres;

                                    montoAux = pagoInteres;

                                    credito.FinalizarUsingSesion();

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = casoDocumentos[j].Observacion;

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                     centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                                }
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);
                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.PrestamosAClientesVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            CuentaCorrientePersonasService ccpp = new CuentaCorrientePersonasService(casoDocumentos[j].CtactePersonaId.Value, sesion);
                            if (casoDocumentos[j].CtactePersonaId.HasValue)
                            {
                                if (ccpp.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                {
                                    var credito = CreditosService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                                    credito.IniciarUsingSesion(sesion);

                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                    if (credito.PersonaGarante1Id != null)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida(casoDocumentos[j].CtactePersona.CasoId.Value);
                                    if (!fechaCuotaMasVencida.HasValue || fechaCuotaMasVencida.Value.Date > casoDocumentos[j].CtactePersona.FechaVencimiento.Date)
                                        fechaCuotaMasVencida = casoDocumentos[j].CtactePersona.FechaVencimiento.Date;

                                    DateTime fechaCobranza = casoCabecera.Fecha;
                                    double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                    if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays <= limiteDias)
                                        continue;

                                    var cuota = casoDocumentos[j].CtactePersona.CalendarioPagosCRCli;

                                    decimal saldoCapital = cuota.MontoCapital + cuota.MontoImpuesto;
                                    decimal saldoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                    decimal totalPagosAnterioresCuota = CuentaCorrientePersonasService.GetPagosAnterioresCuota(casoDocumentos[j].CtactePersonaId.Value, casoCabecera.Fecha);
                                    decimal pagoInteres = Math.Min(saldoInteres, totalPagosAnterioresCuota);
                                    decimal pagoCapital = totalPagosAnterioresCuota - pagoInteres;
                                    saldoInteres -= pagoInteres;

                                    decimal pagoActual = casoDocumentos[j].Monto.Value;
                                    pagoInteres = Math.Min(saldoInteres, pagoActual);
                                    pagoCapital = pagoActual - pagoInteres;

                                    montoAux = pagoCapital;

                                    credito.FinalizarUsingSesion();


                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = casoDocumentos[j].Observacion;

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                     centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                                }
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);
                        break;


                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.InteresesACobrarVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            CuentaCorrientePersonasService ccpp = new CuentaCorrientePersonasService(casoDocumentos[j].CtactePersonaId.Value, sesion);
                            if (casoDocumentos[j].CtactePersonaId.HasValue)
                            {
                                if (ccpp.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                {
                                    var credito = CreditosService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                                    credito.IniciarUsingSesion(sesion);

                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                    if (credito.PersonaGarante1Id != null)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida(casoDocumentos[j].CtactePersona.CasoId.Value);
                                    if (!fechaCuotaMasVencida.HasValue || fechaCuotaMasVencida.Value.Date > casoDocumentos[j].CtactePersona.FechaVencimiento.Date)
                                        fechaCuotaMasVencida = casoDocumentos[j].CtactePersona.FechaVencimiento.Date;

                                    DateTime fechaCobranza = casoCabecera.Fecha;
                                    double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                    if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays <= limiteDias)
                                        continue;

                                    var cuota = casoDocumentos[j].CtactePersona.CalendarioPagosCRCli;

                                    decimal saldoCapital = cuota.MontoCapital + cuota.MontoImpuesto;
                                    decimal saldoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                    decimal totalPagosAnterioresCuota = CuentaCorrientePersonasService.GetPagosAnterioresCuota(casoDocumentos[j].CtactePersonaId.Value, casoCabecera.Fecha);
                                    decimal pagoInteres = Math.Min(saldoInteres, totalPagosAnterioresCuota);
                                    decimal pagoCapital = totalPagosAnterioresCuota - pagoInteres;
                                    saldoInteres -= pagoInteres;

                                    decimal pagoActual = casoDocumentos[j].Monto.Value;
                                    pagoInteres = Math.Min(saldoInteres, pagoActual);
                                    pagoCapital = pagoActual - pagoInteres;

                                    montoAux = pagoInteres;

                                    credito.FinalizarUsingSesion();


                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = casoDocumentos[j].Observacion;

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                     centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                                }
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);
                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.DiferenciaDeCambio:

                        # region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = 0;

                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            if (casoValores[j].MonedaId == monedaPais)
                                montoAux += casoValores[j].Monto.Value;
                            else
                                montoAux += casoValores[j].Monto.Value / casoValores[j].CotizacionMoneda * cotizacionMonedaPais;
                        }

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].MonedaId == monedaPais)
                            {
                                montoAux -= casoDocumentos[j].Monto.Value;
                            }
                            else
                            {
                                if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                                {
                                    decimal cotizacionCompra = CotizacionesService.GetCotizacionMonedaCompra(Definiciones.Paises.Paraguay, monedaPais, casoDocumentos[j].CtactePersona.Caso.FechaFormulario.Value);
                                    montoAux -= casoDocumentos[j].Monto.Value * cotizacionCompra;
                                }
                                else
                                {
                                    montoAux -= casoDocumentos[j].Monto.Value;
                                }
                            }
                        }

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        decimal haber = montoAux < 0 ? 0 : Math.Abs(montoAux);
                        decimal debe = montoAux < 0 ? Math.Abs(montoAux) : 0;

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, debe, haber, monedaPais, cotizacionMonedaPais, monedaPais, cotizacionMonedaPais, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoApDocumentos, casoCabecera.Id, 100,
                                         centrosCostoApDocumentos.Seleccionar(casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    casoCabecera.Caso, casoCabecera, null, sesion));
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDocumentos, sesion);
                        break;

                }
            }

            casoCabecera.FinalizarUsingSesion();

            if (this.UnificarDetallesMismaCuenta == Definiciones.SiNo.Si)
                EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarBorradorAAprobado

        #region AsentarAprobadoABorrador
        public decimal AsentarAprobadoABorrador(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Documentos,
                Definiciones.Contabilidad.ClavesDatos.Valores,
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (PagosDePersonaService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDocumentos = (CuentaCorrientePagosPersonaDocumentoService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Documentos];
            var casoValores = (CuentaCorrientePagosPersonaDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Valores];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux = 0;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacionCabecera centrosCostoApCabecera = new CentrosCostoAplicacionCabecera(casoCabecera, null, new PagosDePersonaService(), sesion);
            CentrosCostoAplicacionDocumentos centrosCostoApDocumentos = new CentrosCostoAplicacionDocumentos(casoCabecera, casoDocumentos, new PagosDePersonaService(), sesion);
            CentrosCostoAplicacionValores centrosCostoApValores = new CentrosCostoAplicacionValores(casoCabecera, casoValores, new PagosDePersonaService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaCompra(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.Fecha, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if (casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.CasoId);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, CalcularObservacionCabecera(casoCabecera.Caso, casoCabecera, sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Aprobado_a_Borrador.Activo_DisminuirDisponibilidadesValoresVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            //Asentar solo si el valor esta vencido
                            if (casoValores[j].ChequeFechaVencimiento.HasValue && casoValores[j].ChequeFechaVencimiento.Value.Date > casoCabecera.Fecha.Date)
                                continue;
                            
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].ChequeCtacteBancoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);

                            if (casoValores[j].CtacteValorId == Definiciones.CuentaCorrienteValores.TransferenciaBancaria && casoValores[j].TransferenciaBancariaId.HasValue)
                            {
                                DataTable dtTransferenciaBancaria = TransferenciasBancariasService.GetDataTable(TransferenciasBancariasService.Id_NombreCol + " = " + casoValores[j].TransferenciaBancariaId.Value, string.Empty);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.CtacteBancariaDestinoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.TextoPredefinidoId_NombreCol]);
                            }
                            else if (casoValores[j].CtacteValorId == Definiciones.CuentaCorrienteValores.DepositoBancario && casoValores[j].DepositoCtacteBancariasId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].DepositoCtacteBancariasId.Value);
                            }
                            else if (casoValores[j].CtacteValorId == Definiciones.CuentaCorrienteValores.TarjetaDeCredito && casoValores[j].CtacteProcesadoraTarjetaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol, casoValores[j].CtacteProcesadoraTarjetaId);
                            }
                            else
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            }

                            if (casoValores[j].CtacteChequeRecibidoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesRecibidosService.GetEstado(casoValores[j].CtacteChequeRecibidoId.Value, sesion));

                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].Monto.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = CalcularObservacionValor(casoValores[j], sesion);

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta #1
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoValores[j].MonedaId, casoValores[j].CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApValores, casoValores[j].Id ?? j, 100,
                                             centrosCostoApValores.Seleccionar(casoValores[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso,casoCabecera, casoValores[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApValores, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Aprobado_a_Borrador.Activo_DisminuirDisponibilidadesValoresAVencer:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            //Asentar solo si el valor es cheque y no esta vencido
                            if (casoValores[j].CtacteValorId != Definiciones.CuentaCorrienteValores.Cheque)
                                continue;
                            if (casoValores[j].ChequeFechaVencimiento.HasValue && casoValores[j].ChequeFechaVencimiento.Value.Date <= casoCabecera.Fecha.Date)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].ChequeCtacteBancoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);
                            if (casoValores[j].CtacteChequeRecibidoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesRecibidosService.GetEstado(casoValores[j].CtacteChequeRecibidoId.Value, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].Monto.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = CalcularObservacionValor(casoValores[j], sesion);

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta #2
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoValores[j].MonedaId, casoValores[j].CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApValores, casoValores[j].Id ?? j, 100,
                                             centrosCostoApValores.Seleccionar(casoValores[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso,casoCabecera, casoValores[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApValores, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Aprobado_a_Borrador.Activo_AumentarRecaudacionesEnProceso:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            bool asentar = false;
                            FacturasClienteService facturaCliente = null;

                            if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                                facturaCliente = FacturasClienteService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);

                            if (facturaCliente != null && facturaCliente.TipoFacturaId == Definiciones.TipoFactura.Contado)
                            {
                                for (int k = 0; k < facturaCliente.FacturaClienteDetalles.Length; k++)
                                {
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, facturaCliente.FacturaClienteDetalles[k].ArticuloId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.FamiliaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.GrupoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.SubGrupoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].ImpuestoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, facturaCliente.DepositoId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;

                                    montoAux = facturaCliente.FacturaClienteDetalles[k].TotalNeto * casoDocumentos[j].Monto.Value / facturaCliente.TotalNeto.Value;
                                    
                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = CalcularObservacionValor(casoValores[j], sesion);

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    decimal cotizacionCompra = CotizacionesService.GetCotizacionMonedaCompra(Definiciones.Paises.Paraguay, monedaPais, facturaCliente.Fecha.Value);
                                    
                                    detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionCompra, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                                    #endregion seleccionar cuentas contables
                                }
                            }
                            else
                            {
                                if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                                {
                                    facturaCliente = FacturasClienteService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                                    if (facturaCliente.TipoFacturaId == Definiciones.TipoFactura.Contado)
                                        continue;
                                }

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                //Se asienta si:
                                //  - Es un recargo y se emiten facturas contado
                                //  - Es un pago sobre una factura de personas contado
                                // Si es Credito de Personas se asienta solo intereses y gasto administrativo si esta configurado para facturar al cobrar
                                #region permitir asentar o continuar con la iteracion
                                
                                if (casoDocumentos[j].CtactePagoPersonaRecargoId.HasValue && casoCabecera.FCCliente1CompAutonId.HasValue)
                                {
                                    asentar = true;
                                    montoAux = casoDocumentos[j].Monto.Value;
                                }

                                if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                    asentar = false;

                                if (!asentar)
                                    continue;

                                #endregion permitir asentar o continuar con la iteracion

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoDocumentos[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDocumentos, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Aprobado_a_Borrador.Activo_AumentarClientes:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            FacturasClienteService facturaCliente = null;

                            if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                                facturaCliente = FacturasClienteService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);

                            if (facturaCliente != null && facturaCliente.TipoFacturaId == Definiciones.TipoFactura.Credito)
                            {
                                for (int k = 0; k < facturaCliente.FacturaClienteDetalles.Length; k++)
                                {
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, facturaCliente.FacturaClienteDetalles[k].ArticuloId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.FamiliaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.GrupoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].Articulo.SubGrupoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, facturaCliente.FacturaClienteDetalles[k].ImpuestoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, facturaCliente.DepositoId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;

                                    montoAux = facturaCliente.FacturaClienteDetalles[k].TotalNeto * casoDocumentos[j].Monto.Value / facturaCliente.TotalNeto.Value;

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = CalcularObservacionValor(casoValores[j], sesion);

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    decimal cotizacionCompra = CotizacionesService.GetCotizacionMonedaCompra(Definiciones.Paises.Paraguay, monedaPais, casoDocumentos[j].CtactePersona.Caso.FechaFormulario.Value);

                                    detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionCompra, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                  centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                  centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                             asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                             asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                             asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                             casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                                    #endregion seleccionar cuentas contables

                                }
                            }
                            else
                            {
                                if (facturaCliente != null && facturaCliente.TipoFacturaId == Definiciones.TipoFactura.Credito)
                                    continue; 

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                //Se asienta si:
                                //  - No es un recargo y se emiten facturas contado
                                //  - No es un pago sobre una factura de personas contado
                                // Si es un Credito de Personas se asienta por capital o capital + intereses + gastos administrativos segun la configuracion del caso
                                #region permitir asentar o continuar con la iteracion
                                bool noAsentar = false;
                                if (casoDocumentos[j].CtactePagoPersonaRecargoId.HasValue && casoCabecera.FCCliente1CompAutonId.HasValue)
                                    noAsentar = true;

                                montoAux = 0;

                                if (casoDocumentos[j].CtactePersonaId.HasValue)
                                {
                                    if (facturaCliente != null && facturaCliente.TipoFacturaId == Definiciones.TipoFactura.Contado)
                                        noAsentar = true;
                                    else if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                        noAsentar = true;
                                }

                                if (noAsentar)
                                    continue;

                                // si no cumplió con los requisitos anteriores entonces se toma el monto pagado del documento
                                if (!casoDocumentos[j].CtactePersonaId.HasValue || casoDocumentos[j].CtactePersona.Caso.FlujoId != Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                                    montoAux = casoDocumentos[j].Monto.Value;

                                #endregion permitir asentar o continuar con la iteracion

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoDocumentos[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                            }

                        }


                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDocumentos, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Aprobado_a_Borrador.Activo_AumentarDisponibilidadesPorVuelto:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = casoCabecera.MontoTotalVuelto;

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                            observacion = casoCabecera.Persona.NombreCompleto;

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta #5
                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaTotalVueltoId, casoCabecera.CotizacionMonedaTotalVuelto, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoApCabecera, casoCabecera.Id, 100,
                                         centrosCostoApCabecera.Seleccionar(casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    casoCabecera.Caso, casoCabecera, null, sesion));
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.InteresesACobrarNoVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                            {
                                var credito = CreditosService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                                credito.IniciarUsingSesion(sesion);

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                if (credito.PersonaGarante1Id != null)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida(casoDocumentos[j].CtactePersona.CasoId.Value);
                                if (!fechaCuotaMasVencida.HasValue || fechaCuotaMasVencida.Value.Date > casoDocumentos[j].CtactePersona.FechaVencimiento.Date)
                                    fechaCuotaMasVencida = casoDocumentos[j].CtactePersona.FechaVencimiento.Date;
                                
                                DateTime fechaCobranza = casoCabecera.Fecha;
                                double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays > limiteDias)
                                    continue;

                                var cuota = casoDocumentos[j].CtactePersona.CalendarioPagosCRCli;

                                decimal MontoCapital = cuota.MontoCapital + cuota.MontoImpuesto;
                                decimal MontoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                // cuotas pagadas
                                decimal totalPagosAnterioresCuota = CuentaCorrientePersonasService.GetPagosAnterioresCuota(casoDocumentos[j].CtactePersonaId.Value, casoCabecera.Fecha);

                                if (totalPagosAnterioresCuota > 0)
                                {
                                    if (totalPagosAnterioresCuota >= MontoInteres)
                                    {
                                        MontoCapital = MontoCapital - totalPagosAnterioresCuota + MontoInteres;
                                        MontoInteres = 0;

                                    }
                                    else
                                    {
                                        MontoInteres = totalPagosAnterioresCuota - MontoInteres;
                                        MontoCapital = MontoCapital - totalPagosAnterioresCuota + MontoInteres;
                                    }

                                }
                                else
                                {
                                    decimal pagoActual = casoDocumentos[j].Monto.Value;

                                    decimal auxInteres = MontoInteres - pagoActual;

                                    MontoInteres = (auxInteres > 0) ? auxInteres : MontoInteres;
                                    MontoCapital = pagoActual - MontoInteres;
                                }

                                montoAux = MontoInteres;

                                credito.FinalizarUsingSesion();

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoDocumentos[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);
                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.PrestamosAClientesVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                            {
                                var credito = CreditosService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                                credito.IniciarUsingSesion(sesion);

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                if (credito.PersonaGarante1Id != null)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida(casoDocumentos[j].CtactePersona.CasoId.Value);
                                if (!fechaCuotaMasVencida.HasValue || fechaCuotaMasVencida.Value.Date > casoDocumentos[j].CtactePersona.FechaVencimiento.Date)
                                    fechaCuotaMasVencida = casoDocumentos[j].CtactePersona.FechaVencimiento.Date;
                                
                                DateTime fechaCobranza = casoCabecera.Fecha;
                                double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays <= limiteDias)
                                    continue;

                                var cuota = casoDocumentos[j].CtactePersona.CalendarioPagosCRCli;

                                decimal MontoCapital = cuota.MontoCapital + cuota.MontoImpuesto;
                                decimal MontoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                // cuotas pagadas
                                decimal totalPagosAnterioresCuota = CuentaCorrientePersonasService.GetPagosAnterioresCuota(casoDocumentos[j].CtactePersonaId.Value, casoCabecera.Fecha);

                                if (totalPagosAnterioresCuota > 0)
                                {
                                    if (totalPagosAnterioresCuota >= MontoInteres)
                                    {
                                        MontoCapital = MontoCapital - totalPagosAnterioresCuota + MontoInteres;
                                        MontoInteres = 0;

                                    }
                                    else
                                    {
                                        MontoInteres = totalPagosAnterioresCuota - MontoInteres;
                                        MontoCapital = MontoCapital - totalPagosAnterioresCuota + MontoInteres;
                                    }

                                }
                                else
                                {
                                    decimal pagoActual = casoDocumentos[j].Monto.Value;

                                    decimal auxInteres = MontoInteres - pagoActual;

                                    MontoInteres = (auxInteres > 0) ? auxInteres : MontoInteres;
                                    MontoCapital = pagoActual - MontoInteres;
                                }

                                montoAux = MontoCapital;

                                credito.FinalizarUsingSesion();


                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoDocumentos[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);
                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.PrestamosAClientesNoVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                            {
                                var credito = CreditosService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                                credito.IniciarUsingSesion(sesion);

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                if (credito.PersonaGarante1Id != null)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida(casoDocumentos[j].CtactePersona.CasoId.Value);
                                if (!fechaCuotaMasVencida.HasValue || fechaCuotaMasVencida.Value.Date > casoDocumentos[j].CtactePersona.FechaVencimiento.Date)
                                    fechaCuotaMasVencida = casoDocumentos[j].CtactePersona.FechaVencimiento.Date;
                                
                                DateTime fechaCobranza = casoCabecera.Fecha;

                                double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays > limiteDias)
                                    continue;

                                var cuota = casoDocumentos[j].CtactePersona.CalendarioPagosCRCli;

                                decimal MontoCapital = cuota.MontoCapital + cuota.MontoImpuesto;
                                decimal MontoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                // cuotas pagadas
                                decimal totalPagosAnterioresCuota = CuentaCorrientePersonasService.GetPagosAnterioresCuota(casoDocumentos[j].CtactePersonaId.Value, casoCabecera.Fecha);

                                if (totalPagosAnterioresCuota > 0)
                                {
                                    if (totalPagosAnterioresCuota >= MontoInteres)
                                    {
                                        MontoCapital = MontoCapital - totalPagosAnterioresCuota + MontoInteres;
                                        MontoInteres = 0;

                                    }
                                    else
                                    {
                                        MontoInteres = totalPagosAnterioresCuota - MontoInteres;
                                        MontoCapital = MontoCapital - totalPagosAnterioresCuota + MontoInteres;
                                    }

                                }
                                else
                                {
                                    decimal pagoActual = casoDocumentos[j].Monto.Value;

                                    decimal auxInteres = MontoInteres - pagoActual;

                                    MontoInteres = (auxInteres > 0) ? auxInteres : MontoInteres;
                                    MontoCapital = pagoActual - MontoInteres;
                                }

                                montoAux = MontoCapital;

                                credito.FinalizarUsingSesion();


                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoDocumentos[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);
                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Borrador_a_Aprobado.InteresesACobrarVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CtactePersonaId.HasValue  && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                            {
                                var credito = CreditosService.GetPorCaso(casoDocumentos[j].CtactePersona.CasoId.Value, sesion);
                                credito.IniciarUsingSesion(sesion);

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                if (credito.PersonaGarante1Id != null)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida(casoDocumentos[j].CtactePersona.CasoId.Value);
                                if (!fechaCuotaMasVencida.HasValue || fechaCuotaMasVencida.Value.Date > casoDocumentos[j].CtactePersona.FechaVencimiento.Date)
                                    fechaCuotaMasVencida = casoDocumentos[j].CtactePersona.FechaVencimiento.Date;

                                DateTime fechaCobranza = casoCabecera.Fecha;
                                double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays <= limiteDias)
                                    continue;

                                var cuota = casoDocumentos[j].CtactePersona.CalendarioPagosCRCli;

                                decimal MontoCapital = cuota.MontoCapital + cuota.MontoImpuesto;
                                decimal MontoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                // cuotas pagadas
                                decimal totalPagosAnterioresCuota = CuentaCorrientePersonasService.GetPagosAnterioresCuota(casoDocumentos[j].CtactePersonaId.Value, casoCabecera.Fecha);

                                if (totalPagosAnterioresCuota > 0)
                                {
                                    if (totalPagosAnterioresCuota >= MontoInteres)
                                    {
                                        MontoCapital = MontoCapital - totalPagosAnterioresCuota + MontoInteres;
                                        MontoInteres = 0;

                                    }
                                    else
                                    {
                                        MontoInteres = totalPagosAnterioresCuota - MontoInteres;
                                        MontoCapital = MontoCapital - totalPagosAnterioresCuota + MontoInteres;
                                    }

                                }
                                else
                                {
                                    decimal pagoActual = casoDocumentos[j].Monto.Value;

                                    decimal auxInteres = MontoInteres - pagoActual;

                                    MontoInteres = (auxInteres > 0) ? auxInteres : MontoInteres;
                                    MontoCapital = pagoActual - MontoInteres;
                                }

                                montoAux = MontoInteres;

                                credito.FinalizarUsingSesion();

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoDocumentos[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApCabecera, sesion);
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Aprobado_a_Borrador.FacturasProveedor:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoDocumentos[j].CtactePersona.CtacteValorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                                montoAux = casoDocumentos[j].Monto.Value;
                            else
                                continue;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = casoDocumentos[j].Observacion;

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoDocumentos[j].MonedaId, casoDocumentos[j].CotizacionMoneda.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApDocumentos, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoApDocumentos.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDocumentos, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PagoDePersonas_Aprobado_a_Borrador.DiferenciaDeCambio:

                        # region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = 0;

                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            if (casoValores[j].MonedaId == monedaPais)
                                montoAux += casoValores[j].Monto.Value;
                            else
                                montoAux += casoValores[j].Monto.Value / casoValores[j].CotizacionMoneda * cotizacionMonedaPais;
                        }

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].MonedaId == monedaPais)
                            {
                                montoAux -= casoDocumentos[j].Monto.Value;
                            }
                            else
                            {
                                if (casoDocumentos[j].CtactePersonaId.HasValue && casoDocumentos[j].CtactePersona.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                                {
                                    decimal cotizacionCompra = CotizacionesService.GetCotizacionMonedaCompra(Definiciones.Paises.Paraguay, monedaPais, casoDocumentos[j].CtactePersona.Caso.FechaFormulario.Value);
                                    montoAux -= casoDocumentos[j].Monto.Value * cotizacionCompra;
                                }
                                else
                                {
                                    montoAux -= casoDocumentos[j].Monto.Value;
                                }
                            }
                        }

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        decimal debe = montoAux < 0 ? 0 : Math.Abs(montoAux);
                        decimal haber = montoAux < 0 ? Math.Abs(montoAux) : 0;

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, debe, haber, monedaPais, cotizacionMonedaPais, monedaPais, cotizacionMonedaPais, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoApDocumentos, casoCabecera.Id, 100,
                                         centrosCostoApDocumentos.Seleccionar(casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    casoCabecera.Caso, casoCabecera, null, sesion));
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDocumentos, sesion);
                        break;
                }
            }

            casoCabecera.FinalizarUsingSesion();

            if (this.UnificarDetallesMismaCuenta == Definiciones.SiNo.Si)
                EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarAprobadoABorrador
    }
}
