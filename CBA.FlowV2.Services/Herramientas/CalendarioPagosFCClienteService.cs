using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;
using System.Collections;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Tesoreria;

namespace CBA.FlowV2.Services.Herramientas
{
    public class CalendarioPagosFCClienteService
    {
        #region GetCalendarioPagosDataTable
        /// <summary>
        /// Gets the calendario pagos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCalendarioPagosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCalendarioPagosDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCalendarioPagosDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = CalendarioPagosFCClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetAsDataTable(where, orden);
        }
        #endregion GetTotal

        #region GetCalendariosPagosPorFactura
        public static DataTable GetCalendariosPagosPorFactura(decimal factura_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCalendariosPagosPorFactura(factura_cliente_id, sesion);
            }
        }

        public static DataTable GetCalendariosPagosPorFactura(decimal factura_cliente_id, SessionService sesion)
        {
            string clausulas = CalendarioPagosFCClienteService.FacturaClienteId_NombreCol + "=" + factura_cliente_id + " AND " +
                                   CalendarioPagosFCClienteService.Estado_NombreCol + " = " + " 'A' ";
            return GetCalendarioPagosDataTable(clausulas, CalendarioPagosFCClienteService.NumeroCuota_NombreCol, sesion);
        }
        #endregion GetCalendariosPagosPorFactura

        #region SetEstado
        public static void SetEstado(decimal calendario_pagos_factura_id, string estado, SessionService sesion)
        {
            CALENDARIO_PAGOS_FC_CLIENTERow row = sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetByPrimaryKey(calendario_pagos_factura_id);
            row.ESTADO = estado;
            sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(row);
        }
        #endregion SetEstado

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                CALENDARIO_PAGOS_FC_CLIENTERow row = new CALENDARIO_PAGOS_FC_CLIENTERow();
                string valorAnterior = string.Empty;

                row.ID = sesion.Db.GetSiguienteSecuencia("calendario_pagos_fc_cli_sqc");
                row.FACTURA_CLIENTE_ID = decimal.Parse(campos[CalendarioPagosFCClienteService.FacturaClienteId_NombreCol].ToString());
                row.MONTO_CAPITAL = decimal.Parse(campos[CalendarioPagosFCClienteService.MontoCapital_NombreCol].ToString());
                row.MONTO_INTERES = decimal.Parse(campos[CalendarioPagosFCClienteService.MontoInteres_NombreCol].ToString());
                row.FECHA_VENCIMIENTO = DateTime.Parse(campos[CalendarioPagosFCClienteService.FechaVencimiento_NombreCol].ToString());
                row.NUMERO_CUOTA = decimal.Parse(campos[CalendarioPagosFCClienteService.NumeroCuota_NombreCol].ToString());
                row.ESTADO = Definiciones.Estado.Activo;

                sesion.Db.CALENDARIO_PAGOS_FC_CLIENTECollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the por factura.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        public static void BorrarPorFactura(decimal factura_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    BorrarPorFactura(factura_cliente_id, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        /// <summary>
        /// Borrars the por factura.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void BorrarPorFactura(decimal factura_cliente_id, SessionService sesion)
        {
            try
            {
                string clausulas = CalendarioPagosFCClienteService.FacturaClienteId_NombreCol + " = " + factura_cliente_id + " and " +
                                   CalendarioPagosFCClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                CALENDARIO_PAGOS_FC_CLIENTERow[] rows = sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetAsArray(clausulas, string.Empty);
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].ESTADO = Definiciones.Estado.Inactivo;
                    sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(rows[i]);
                }

                DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.Id_NombreCol + " = " + factura_cliente_id, string.Empty, sesion);
                FacturasClienteService.ActualizarFechaVencimiento(factura_cliente_id, (DateTime)dtFactura.Rows[0][FacturasClienteService.Fecha_NombreCol], true, true, sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Borrar

        #region GetTotal
        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <returns></returns>
        public static decimal GetTotal(decimal factura_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTotal(factura_cliente_id, sesion);
            }
        }

        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetTotal(decimal factura_cliente_id, SessionService sesion)
        {
            decimal total = 0;
            DataTable dt = GetCalendariosPagosPorFactura(factura_cliente_id, sesion);

            for (int i = 0; i < dt.Rows.Count; i++)
                total += (decimal)dt.Rows[i][CalendarioPagosFCClienteService.MontoCapital_NombreCol];

            return total;
        }
        #endregion GetTotal

        #region GetCantidadCuotas
        public static int GetCantidadCuotas(decimal factura_cliente_id, SessionService sesion)
        {
            DataTable dt = GetCalendariosPagosPorFactura(factura_cliente_id, sesion);
            return dt.Rows.Count;
        }
        #endregion GetCantidadCuotas

        #region CrearCuotas
        public static void CrearCuotas(decimal factura_cliente_id, decimal monto_cuota, DateTime fecha_base, DateTime fecha_primer_vencimiento, bool usar_fecha_primer_vencimiento, DateTime fecha_segundo_vencimiento, bool usar_fecha_segundo_vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    #region obtener fecha vencimiento estrategia es por WebService
                    //Si la estrategia de precios es webservice deben actualizarse los totales por cada articulo
                    if ((VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio) == Definiciones.EstrategiaPrecio.WebService))
                    {
                        List<decimal> listArticulos = new List<decimal>();
                        List<decimal> listArticulosCantidades = new List<decimal>();
                        List<decimal> listArticulosDescuentoPorcentaje = new List<decimal>();
                        decimal[] articulosId, articulosCantidades, articulosDescuentoPorcentaje;
                        decimal[] articulosPrecios;
                        decimal monedaOrigen, cotizacionOrigen, listaPrecioId;
                        DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.Id_NombreCol + " = " + factura_cliente_id, string.Empty);
                        DataTable dtDetalles = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + dtFactura.Rows[0][FacturasClienteService.Id_NombreCol], string.Empty);

                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            if (!ArticulosService.GetControlarPrecio((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.ArticuloId_NombreCol]))
                                continue;

                            listArticulos.Add((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.ArticuloId_NombreCol]);
                            listArticulosCantidades.Add((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol]);
                            listArticulosDescuentoPorcentaje.Add((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.PorcentajeDescuento_NombreCol]);
                        }

                        articulosId = listArticulos.ToArray();
                        articulosCantidades = listArticulosCantidades.ToArray();
                        articulosDescuentoPorcentaje = listArticulosDescuentoPorcentaje.ToArray();

                        if (Interprete.EsNullODBNull(dtFactura.Rows[0][FacturasClienteService.ListaPrecioId_NombreCol]))
                            listaPrecioId = Definiciones.Error.Valor.EnteroPositivo;
                        else
                            listaPrecioId = (decimal)dtFactura.Rows[0][FacturasClienteService.ListaPrecioId_NombreCol];

                        PreciosService.GetPrecioPorArticulo((decimal)dtFactura.Rows[0][FacturasClienteService.PersonaId_NombreCol],
                                                            articulosId,
                                                            articulosCantidades,
                                                            (decimal)dtFactura.Rows[0][FacturasClienteService.MonedaDestinoId_NombreCol],
                                                            (decimal)dtFactura.Rows[0][FacturasClienteService.SucursalId_NombreCol],
                                                            (decimal)dtFactura.Rows[0][FacturasClienteService.CasoId_NombreCol], 
                                                            (decimal)dtFactura.Rows[0][FacturasClienteService.CotizacionDestino_NombreCol],
                                                            listaPrecioId,
                                                            (decimal)dtFactura.Rows[0][FacturasClienteService.CondicionPagoId_NombreCol],
                                                            (decimal)dtFactura.Rows[0][FacturasClienteService.TotalEntregaInicial_NombreCol],
                                                            (DateTime)dtFactura.Rows[0][FacturasClienteService.Fecha_NombreCol],
                                                            ref articulosDescuentoPorcentaje, out articulosPrecios,
                                                            out monedaOrigen, out cotizacionOrigen,
                                                            out fecha_primer_vencimiento, out usar_fecha_primer_vencimiento,
                                                            out fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento,
                                                            false,
                                                            sesion);
                    }
                    #endregion obtener fecha vencimiento estrategia es por WebService

                    CrearCuotas(factura_cliente_id, monto_cuota, fecha_base, fecha_primer_vencimiento, usar_fecha_primer_vencimiento, fecha_segundo_vencimiento, usar_fecha_segundo_vencimiento, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static void CrearCuotas(decimal factura_cliente_id, decimal monto_cuota, DateTime fecha_base, DateTime fecha_primer_vencimiento, bool usar_fecha_primer_vencimiento, DateTime fecha_segundo_vencimiento, bool usar_fecha_segundo_vencimiento, SessionService sesion)
        {
            try
            {
                DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.Id_NombreCol + " = " + factura_cliente_id, string.Empty, sesion);
                DataTable dtDetalles = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + dtFactura.Rows[0][FacturasClienteService.Id_NombreCol], string.Empty, sesion);
                DateTime vencimiento = (DateTime)dtFactura.Rows[0][FacturasClienteService.Fecha_NombreCol];
                decimal sumaRedondeo, montoRedondeado, idAux;
                decimal[] impuestoId, monto, montoCuota;
                decimal montoVerificacion;
                Hashtable montoPorImpuesto = new Hashtable();
                int indiceAux, cantidadDecimales;
                string casoEstadoId = CasosService.GetEstadoCaso((decimal)dtFactura.Rows[0][FacturasClienteService.CasoId_NombreCol], sesion);
                    
                bool generarCtacte = casoEstadoId == Definiciones.EstadosFlujos.Caja || casoEstadoId == Definiciones.EstadosFlujos.Cerrado;

                int cantidadCuotas = Convert.ToInt32(CondicionesPagoService.GetCantidadPagos((decimal)dtFactura.Rows[0][FacturasClienteService.CondicionPagoId_NombreCol]));

                //Se borran las cuotas de la ctacte
                CuentaCorrientePersonasService.DeshacerAgregarCreditoPorCaso((decimal)dtFactura.Rows[0][FacturasClienteService.CasoId_NombreCol], sesion);

                //Se borran las cuotas del calendario
                CalendarioPagosFCClienteService.BorrarPorFactura(factura_cliente_id, sesion);

                cantidadDecimales = MonedasService.CantidadDecimalesStatic((decimal)dtFactura.Rows[0][FacturasClienteService.MonedaDestinoId_NombreCol]);
                montoRedondeado = Math.Round(monto_cuota, cantidadDecimales);
                sumaRedondeo = (monto_cuota - montoRedondeado) * cantidadCuotas;

                #region Calcular monto por tipo de impuesto
                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    if (montoPorImpuesto.Contains((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.ImpuestoId_NombreCol]))
                        montoPorImpuesto[(decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[(decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.ImpuestoId_NombreCol]] + (decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.TotalNeto_NombreCol] * (100 - (decimal)dtFactura.Rows[0][FacturasClienteService.PorcentajeDescSobreTotal_NombreCol]) / 100;
                    else
                        montoPorImpuesto.Add((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.ImpuestoId_NombreCol], (decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.TotalNeto_NombreCol] * (100 - (decimal)dtFactura.Rows[0][FacturasClienteService.PorcentajeDescSobreTotal_NombreCol]) / 100);
                }

                impuestoId = new decimal[montoPorImpuesto.Count];
                monto = new decimal[montoPorImpuesto.Count];
                indiceAux = 0;
                montoVerificacion = 0;
                foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                {
                    impuestoId[indiceAux] = (decimal)par.Key;
                    monto[indiceAux] = (decimal)par.Value;

                    montoVerificacion += (decimal)par.Value;

                    indiceAux++;
                }

                if (Math.Round((decimal)dtFactura.Rows[0][FacturasClienteService.TotalNeto_NombreCol], cantidadDecimales) != Math.Round(montoVerificacion, cantidadDecimales))
                    throw new Exception("Error en CalendarioPagosFCClienteService.CrearCuotas(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + dtFactura.Rows[0][FacturasClienteService.TotalNeto_NombreCol] + ".");
                #endregion Calcular monto por tipo de impuesto

                for (int i = 0; i < cantidadCuotas; i++)
                {
                    Hashtable campos = new Hashtable();

                    vencimiento = CondicionesPagoService.GetVencimiento((decimal)dtFactura.Rows[0][FacturasClienteService.CondicionPagoId_NombreCol], i + 1, fecha_base);

                    if (i == 0 && usar_fecha_primer_vencimiento)
                    {
                        fecha_base = CondicionesPagoService.GetFechaBaseAPartirDeFechaCuota((decimal)dtFactura.Rows[0][FacturasClienteService.CondicionPagoId_NombreCol], 1, fecha_primer_vencimiento);
                        vencimiento = fecha_primer_vencimiento;
                    }
                    else if (i == 1 && usar_fecha_segundo_vencimiento)
                    {
                        fecha_base = CondicionesPagoService.GetFechaBaseAPartirDeFechaCuota((decimal)dtFactura.Rows[0][FacturasClienteService.CondicionPagoId_NombreCol], 2, fecha_segundo_vencimiento);
                        vencimiento = fecha_segundo_vencimiento;
                    }

                    if (i == 0)
                    {
                        if (vencimiento < ((DateTime)dtFactura.Rows[0][FacturasClienteService.Fecha_NombreCol]).Date)
                            throw new Exception("La primera fecha de vencimiento no puede ser anterior a la fecha de la factura.");
                    }

                    if (i < cantidadCuotas - 1)
                        campos.Add(CalendarioPagosFCClienteService.MontoCapital_NombreCol, montoRedondeado);
                    else
                        campos.Add(CalendarioPagosFCClienteService.MontoCapital_NombreCol, montoRedondeado + sumaRedondeo);

                    campos.Add(CalendarioPagosFCClienteService.FacturaClienteId_NombreCol, factura_cliente_id);
                    campos.Add(CalendarioPagosFCClienteService.MontoInteres_NombreCol, (decimal)0);
                    campos.Add(CalendarioPagosFCClienteService.NumeroCuota_NombreCol, (decimal)1 + i);
                    campos.Add(CalendarioPagosFCClienteService.FechaVencimiento_NombreCol, vencimiento);

                    idAux = CalendarioPagosFCClienteService.Guardar(campos, sesion);

                    if (generarCtacte)
                    {
                        montoCuota = new decimal[monto.Length];

                        //Como el monto por impuesto contiene el total de la factura
                        //Se distribuye dicho total segun el monto de la cuota
                        for (int j = 0; j < monto.Length; j++)
                        {
                            if ((decimal)campos[CalendarioPagosFCClienteService.MontoCapital_NombreCol] != 0)
                                montoCuota[j] = monto[j] / (decimal)dtFactura.Rows[0][FacturasClienteService.TotalNeto_NombreCol] * (decimal)campos[CalendarioPagosFCClienteService.MontoCapital_NombreCol];
                            else
                                montoCuota[j] = 0;
                        }

                        CuentaCorrientePersonasService.AgregarCredito((decimal)(decimal)dtFactura.Rows[0][FacturasClienteService.PersonaId_NombreCol],
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                                (decimal)dtFactura.Rows[0][FacturasClienteService.CasoId_NombreCol],
                                                                (decimal)dtFactura.Rows[0][FacturasClienteService.MonedaDestinoId_NombreCol],
                                                                (decimal)dtFactura.Rows[0][FacturasClienteService.CotizacionDestino_NombreCol],
                                                                impuestoId,
                                                                montoCuota,
                                                                string.Empty,
                                                                vencimiento,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                idAux,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                Definiciones.Error.Valor.EnteroPositivo,
                                                                i + 1,
                                                                cantidadCuotas,
                                                                sesion);
                    }
                }

                // se actualiza el vencimiento de la factura
                FacturasClienteService.ActualizarFechaVencimiento(factura_cliente_id, vencimiento, false, false, sesion);
            }
            catch
            {
                throw;
            }
        }
        #endregion CrearCuotas

        #region AgregarCuotaNueva
        /// <summary>
        /// Agregars the cuota.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="monto_cuota">The monto_cuota.</param>
        /// <param name="vencimiento">The vencimiento.</param>
        /// <param name="insertar_atras">if set to <c>true</c> inserta como primera cuota, si no como ultima cuota.</param>
        public static void AgregarCuotaNueva(decimal factura_cliente_id, decimal monto_cuota, DateTime vencimiento, bool insertar_atras)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    if (monto_cuota <= 0)
                        throw new Exception("El monto de la cuota debe ser mayor a 0.");

                    DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(factura_cliente_id);
                    string clausulas = CalendarioPagosFCClienteService.FacturaClienteId_NombreCol + " = " + factura_cliente_id + " and " +
                                       CalendarioPagosFCClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    CALENDARIO_PAGOS_FC_CLIENTERow[] rows = sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetAsArray(clausulas, CalendarioPagosFCClienteService.NumeroCuota_NombreCol);

                    if (rows.Length <= 0)
                        throw new Exception("No existe cuotas definidas.");

                    //Validar que el vencimiento sera el primero o el ultimo
                    if (insertar_atras)
                    {
                        if (rows[rows.Length - 1].FECHA_VENCIMIENTO > vencimiento)
                            throw new Exception("Si desea insertar la cuota al final, la fecha de vencimiento debe ser posterior al " + rows[rows.Length - 1].FECHA_VENCIMIENTO.ToShortDateString());
                    }
                    else
                    {
                        if (rows[0].FECHA_VENCIMIENTO < vencimiento)
                            throw new Exception("Si desea insertar la cuota al inicio, la fecha de vencimiento debe ser anterior al " + rows[0].FECHA_VENCIMIENTO.ToShortDateString());
                    }

                    for (int i = 0; i < rows.Length; i++)
                    {
                        rows[i].NUMERO_CUOTA++;
                        sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(rows[i]);
                    }

                    #region guardar nueva cuota
                    Hashtable campos = new Hashtable();

                    campos.Add(CalendarioPagosFCClienteService.FacturaClienteId_NombreCol, factura_cliente_id);
                    campos.Add(CalendarioPagosFCClienteService.MontoCapital_NombreCol, monto_cuota);
                    campos.Add(CalendarioPagosFCClienteService.MontoInteres_NombreCol, (decimal)0);
                    campos.Add(CalendarioPagosFCClienteService.NumeroCuota_NombreCol, insertar_atras ? (decimal)2 + rows.Length : (decimal)1);
                    campos.Add(CalendarioPagosFCClienteService.FechaVencimiento_NombreCol, vencimiento);

                    CalendarioPagosFCClienteService.Guardar(campos, sesion);
                    #endregion guardar nueva cuota

                    if (vencimiento > (DateTime)dtFactura.Rows[0][FacturasClienteService.FechaVencimiento_NombreCol])
                        FacturasClienteService.ActualizarFechaVencimiento(factura_cliente_id, vencimiento, false, false, sesion);

                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion AgregarCuotaNueva

        #region AgregarMontoACuota
        /// <summary>
        /// Agregars the monto A cuota.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="monto_capital_agregado">The monto_capital_agregado.</param>
        /// <param name="monto_interes_agregado">The monto_interes_agregado.</param>
        /// <param name="numero_cuota">The numero_cuota.</param>
        public static void AgregarMontoACuota(decimal factura_cliente_id, decimal monto_capital_agregado, decimal monto_interes_agregado, int numero_cuota)
        {
            using (SessionService sesion = new SessionService())
            {
                if (monto_capital_agregado + monto_interes_agregado <= 0)
                    throw new Exception("El monto agregado debe ser mayor a 0.");

                string clausulas = CalendarioPagosFCClienteService.FacturaClienteId_NombreCol + " = " + factura_cliente_id + " and " +
                                   CalendarioPagosFCClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                   CalendarioPagosFCClienteService.NumeroCuota_NombreCol + " = " + numero_cuota;

                CALENDARIO_PAGOS_FC_CLIENTERow[] rows = sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetAsArray(clausulas, string.Empty);
                string valorAnterior;

                if (rows.Length <= 0)
                    throw new Exception("No se encontró la cuota a modificar.");

                valorAnterior = rows[0].ToString();

                rows[0].MONTO_CAPITAL += monto_capital_agregado;
                rows[0].MONTO_INTERES += monto_interes_agregado;
                sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(rows[0]);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].ID, valorAnterior, rows[0].ToString(), sesion);
            }
        }
        #endregion AgregarMontoACuota

        #region DesplazarVencimientos
        /// <summary>
        /// Desplazars the vencimientos.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="cantidad_desplazamiento">The cantidad_desplazamiento.</param>
        /// <param name="tipo_desplazamiento">The tipo_desplazamiento.</param>
        /// <param name="monto_capital_agregado">The monto_capital_agregado.</param>
        /// <param name="monto_interes_agregado">The monto_interes_agregado.</param>
        /// <param name="distribuir_equitativamente">Toma precedencia sobre aumentar_inicio y aumentar_final.</param>
        /// <param name="aumentar_inicio">Toma precendencia sobre aumentar_final.</param>
        /// <param name="aumentar_final">if set to <c>true</c> [aumentar_final].</param>
        public static void DesplazarVencimientos(decimal factura_cliente_id, int cantidad_desplazamiento, string tipo_desplazamiento, decimal monto_capital_agregado, decimal monto_interes_agregado, bool distribuir_equitativamente, bool aumentar_inicio, bool aumentar_final)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    string clausulas = CalendarioPagosFCClienteService.FacturaClienteId_NombreCol + " = " + factura_cliente_id + " and " +
                                       CalendarioPagosFCClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                    CALENDARIO_PAGOS_FC_CLIENTERow[] rows = sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetAsArray(clausulas, CalendarioPagosFCClienteService.NumeroCuota_NombreCol);
                    string valorAnterior;

                    if (rows.Length <= 0)
                        throw new Exception("No se encontró la cuota a modificar.");

                    #region agregar monto
                    if (distribuir_equitativamente)
                    {
                        decimal montoCapital = monto_capital_agregado / rows.Length;
                        decimal montoInteres = monto_interes_agregado / rows.Length;

                        for (int i = 0; i < rows.Length; i++)
                        {
                            valorAnterior = rows[i].ToString();
                            rows[i].MONTO_CAPITAL += montoCapital;
                            rows[i].MONTO_INTERES += montoInteres;
                            sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(rows[i]);
                            LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
                        }
                    }
                    else if (aumentar_inicio)
                    {
                        valorAnterior = rows[0].ToString();
                        rows[0].MONTO_CAPITAL += monto_capital_agregado;
                        rows[0].MONTO_INTERES += monto_interes_agregado;
                        sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(rows[0]);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].ID, valorAnterior, rows[0].ToString(), sesion);
                    }
                    else if (aumentar_final)
                    {
                        valorAnterior = rows[rows.Length - 1].ToString();
                        rows[rows.Length - 1].MONTO_CAPITAL += monto_capital_agregado;
                        rows[rows.Length - 1].MONTO_INTERES += monto_interes_agregado;
                        sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(rows[rows.Length - 1]);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[rows.Length - 1].ID, valorAnterior, rows[rows.Length - 1].ToString(), sesion);
                    }
                    else
                    {
                        throw new NotImplementedException("CalendarioPagosFCClienteService.DesplazarVencimientos(). Configuración inconsistente");
                    }
                    #endregion agregar monto

                    #region desplazar fecha
                    switch (tipo_desplazamiento)
                    {
                        case Definiciones.CondicionPagoTipoCalculo.Dias:
                            for (int i = 0; i < rows.Length; i++)
                            {
                                valorAnterior = rows[i].ToString();
                                rows[i].FECHA_VENCIMIENTO = rows[i].FECHA_VENCIMIENTO.AddDays(cantidad_desplazamiento);
                                sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(rows[i]);
                                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
                            }
                            break;
                        case Definiciones.CondicionPagoTipoCalculo.Meses:
                            for (int i = 0; i < rows.Length; i++)
                            {
                                valorAnterior = rows[i].ToString();
                                rows[i].FECHA_VENCIMIENTO = rows[i].FECHA_VENCIMIENTO.AddMonths(cantidad_desplazamiento);
                                sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(rows[i]);
                                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
                            }
                            break;
                        default: throw new NotImplementedException("CalendarioPagosFCClienteService.DesplazarVencimientos(). Tipo de desplazamiento no implementado");
                    }
                    #endregion desplazar fecha

                    FacturasClienteService.ActualizarFechaVencimiento(factura_cliente_id, rows[rows.Length - 1].FECHA_VENCIMIENTO, true, false, sesion);

                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion DesplazarVencimientos

        #region ModificarVencimiento
        /// <summary>
        /// Modificars the vencimiento.
        /// </summary>
        /// <param name="calendario_pago_id">The calendario_pago_id.</param>
        /// <param name="vencimiento">The vencimiento.</param>
        public static void ModificarVencimiento(decimal calendario_pago_id, DateTime vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ModificarVencimiento(calendario_pago_id, vencimiento, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static void ModificarVencimiento(decimal calendario_pago_id, DateTime vencimiento, SessionService sesion)
        {
            CALENDARIO_PAGOS_FC_CLIENTERow row = sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetByPrimaryKey(calendario_pago_id);
            DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(row.FACTURA_CLIENTE_ID);
            string valorAnterior = row.ToString();

            row.FECHA_VENCIMIENTO = vencimiento;
            sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            if (vencimiento > (DateTime)dtFactura.Rows[0][FacturasClienteService.FechaVencimiento_NombreCol])
                FacturasClienteService.ActualizarFechaVencimiento(row.FACTURA_CLIENTE_ID, vencimiento, false, false, sesion);
        }
        #endregion ModificarVencimiento

        #region ModificarMontoCapital
        /// <summary>
        /// Modificars the monto capital.
        /// </summary>
        /// <param name="calendario_pago_id">The calendario_pago_id.</param>
        /// <param name="monto_capital">The monto_capital.</param>
        public static void ModificarMontoCapital(decimal calendario_pago_id, decimal monto_capital)
        {
            using (SessionService sesion = new SessionService())
            {
                if (monto_capital < 0)
                    throw new Exception("El monto no puede ser negativo.");

                CALENDARIO_PAGOS_FC_CLIENTERow row = sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetByPrimaryKey(calendario_pago_id);
                string valorAnterior = row.ToString();

                row.MONTO_CAPITAL = monto_capital;
                sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion ModificarMontoCapital

        #region Redondeo de Cuotas
        public static DataTable RedondeoCuotasFc(FACTURAS_CLIENTERow cabeceraRow, SessionService sesion, DataTable dtPagos)
        {
            //Si la variable tiene como valor S, entonces se pasa a realizar las operaciones necesarias
            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CalendarioPagosRedondearCuotas) == Definiciones.SiNo.Si)
            {
                if (dtPagos.Rows.Count > 0)
                {
                    decimal sumarMontoCuotas = 0;

                    foreach (DataRow row in dtPagos.Rows)
                    {
                        sumarMontoCuotas += decimal.Parse(row[CalendarioPagosFCClienteService.MontoCapital_NombreCol].ToString());
                    }

                    DataTable auxdtPagos = dtPagos.Clone();

                    if (!sumarMontoCuotas.Equals(cabeceraRow.TOTAL_NETO - cabeceraRow.TOTAL_ENTREGA_INICIAL))
                    {
                        decimal montoRedondeadoTotal = 0;

                        //Sumamos todas las cuotas excepto la última
                        int cantidadFilas = dtPagos.Rows.Count - 1;
                        for (int i = 0; i < cantidadFilas; i++)
                        {
                            decimal montoRedondeado = Interprete.Redondear(decimal.Parse(dtPagos.Rows[i][CalendarioPagosFCClienteService.MontoCapital_NombreCol].ToString()), MonedasService.CantidadDecimalesStatic(cabeceraRow.MONEDA_DESTINO_ID));
                            montoRedondeadoTotal += montoRedondeado;
                            DataRow row = auxdtPagos.NewRow();
                            row[CalendarioPagosFCClienteService.Id_NombreCol] = (decimal)dtPagos.Rows[i][CalendarioPagosFCClienteService.Id_NombreCol];
                            row[CalendarioPagosFCClienteService.FacturaClienteId_NombreCol] = (decimal)dtPagos.Rows[i][CalendarioPagosFCClienteService.FacturaClienteId_NombreCol];
                            row[CalendarioPagosFCClienteService.FechaVencimiento_NombreCol] = dtPagos.Rows[i][CalendarioPagosFCClienteService.FechaVencimiento_NombreCol];
                            row[CalendarioPagosFCClienteService.NumeroCuota_NombreCol] = dtPagos.Rows[i][CalendarioPagosFCClienteService.NumeroCuota_NombreCol];
                            row[CalendarioPagosFCClienteService.MontoInteres_NombreCol] = dtPagos.Rows[i][CalendarioPagosFCClienteService.MontoInteres_NombreCol];
                            row[CalendarioPagosFCClienteService.MontoCapital_NombreCol] = montoRedondeado;
                            row[CalendarioPagosFCClienteService.Estado_NombreCol] = "A";
                            auxdtPagos.Rows.Add(row);
                        }


                        DataRow fila = auxdtPagos.NewRow();
                        fila[CalendarioPagosFCClienteService.Id_NombreCol] = (decimal)dtPagos.Rows[dtPagos.Rows.Count - 1][CalendarioPagosFCClienteService.Id_NombreCol];
                        fila[CalendarioPagosFCClienteService.FacturaClienteId_NombreCol] = (decimal)dtPagos.Rows[dtPagos.Rows.Count - 1][CalendarioPagosFCClienteService.FacturaClienteId_NombreCol];
                        fila[CalendarioPagosFCClienteService.FechaVencimiento_NombreCol] = dtPagos.Rows[dtPagos.Rows.Count - 1][CalendarioPagosFCClienteService.FechaVencimiento_NombreCol];
                        fila[CalendarioPagosFCClienteService.NumeroCuota_NombreCol] = dtPagos.Rows[dtPagos.Rows.Count - 1][CalendarioPagosFCClienteService.NumeroCuota_NombreCol];
                        fila[CalendarioPagosFCClienteService.MontoInteres_NombreCol] = dtPagos.Rows[dtPagos.Rows.Count - 1][CalendarioPagosFCClienteService.MontoInteres_NombreCol];
                        decimal montoCuotaFinal = cabeceraRow.TOTAL_NETO - cabeceraRow.TOTAL_ENTREGA_INICIAL - montoRedondeadoTotal;
                        fila[CalendarioPagosFCClienteService.MontoCapital_NombreCol] = montoCuotaFinal;
                        fila[CalendarioPagosFCClienteService.Estado_NombreCol] = "A";
                        auxdtPagos.Rows.Add(fila);

                    }
                    else
                    {
                        return dtPagos;
                    }

                    return auxdtPagos;
                }
            }

            return dtPagos;
        }
        #endregion Redondeo de Cuotas

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CALENDARIO_PAGOS_FC_CLIENTE"; }
        }
        public static string Estado_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_CLIENTECollection.ESTADOColumnName; }
        }
        public static string FacturaClienteId_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_CLIENTECollection.FACTURA_CLIENTE_IDColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_CLIENTECollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_CLIENTECollection.IDColumnName; }
        }
        public static string MontoCapital_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_CLIENTECollection.MONTO_CAPITALColumnName; }
        }
        public static string MontoInteres_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_CLIENTECollection.MONTO_INTERESColumnName; }
        }
        public static string NumeroCuota_NombreCol
        {
            get { return CALENDARIO_PAGOS_FC_CLIENTECollection.NUMERO_CUOTAColumnName; }
        }
        #endregion Accessors
    }
}
