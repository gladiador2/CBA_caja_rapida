using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.EgresosVariosCaja;
using CBA.FlowV2.Services.Casos;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteProveedoresService
    {
        #region GetCuentaCorrienteProveedoresDataTable
        /// <summary>
        /// Gets the cuenta corriente proveedores data table.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteProveedoresDataTable(decimal proveedor_id)
        {
            return GetCuentaCorrienteProveedoresDataTable(CuentaCorrienteProveedoresService.ProveedorId_NombreCol + " = " + proveedor_id, CuentaCorrienteProveedoresService.Id_NombreCol);
        }

        public DataTable GetCuentaCorrienteProveedoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteProveedoresDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrienteProveedoresDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteProveedoresDataTable(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the cuenta corriente proveedores data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteProveedoresDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_PROVEEDORESCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrienteProveedoresDataTable

        #region GetProveedorId
        /// <summary>
        /// Gets the proveedor id.
        /// </summary>
        /// <param name="ctacte_id">The ctacte_id.</param>
        /// <returns></returns>
        public static decimal GetProveedorId(decimal ctacte_id)
        {
            CTACTE_PROVEEDORESRow row = new CTACTE_PROVEEDORESRow();
            try
            {
                using (SessionService sesion = new SessionService())
                {

                    row = sesion.Db.CTACTE_PROVEEDORESCollection.GetByPrimaryKey(ctacte_id);
                    return row.PROVEEDOR_ID;
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetProveedorId

        #region GetCuentaCorrienteProveedoresInfoCompleta
        public static DataTable GetCuentaCorrienteProveedoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteProveedoresInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrienteProveedoresInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            try
            {
                if (!clausulas.Equals(string.Empty))
                    clausulas += " and ";

                clausulas += CuentaCorrienteProveedoresService.VistaCasoEntidadId_NombreCol + "=" + sesion.Entidad.ID;
                return sesion.Db.CTACTE_PROVEEDORES_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        #endregion GetCuentaCorrienteProveedoresInfoCompleta

        #region GetDeudaALaFecha
        /// <summary>
        /// Gets the deuda A la fecha.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <param name="fecha">The fecha.</param>
        /// <returns></returns>
        public decimal GetDeudaALaFecha(decimal proveedor_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtCtacte;
                string clausulas;
                decimal total = 0;

                clausulas = CuentaCorrienteProveedoresService.ProveedorId_NombreCol + " = " + proveedor_id + " and " +
                            CuentaCorrienteProveedoresService.FechaVencimiento_NombreCol + " <= to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy') ";

                dtCtacte = this.GetCuentaCorrienteProveedoresDataTable(clausulas, CuentaCorrienteProveedoresService.FechaInsercion_NombreCol);

                for (int i = 0; i < dtCtacte.Rows.Count; i++)
                {
                    total += (decimal)dtCtacte.Rows[i][CuentaCorrienteProveedoresService.Credito_NombreCol] -
                             (decimal)dtCtacte.Rows[i][CuentaCorrienteProveedoresService.Debito_NombreCol];
                }

                return total;
            }
        }
        #endregion GetDeudaALaFecha

        #region GetDeudaDeMovimiento
        /// <summary>
        /// Gets the deuda de movimiento.
        /// </summary>
        /// <param name="ctacte_proveedor_id">The ctacte_proveedor_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetDeudaDeMovimiento(decimal ctacte_proveedor_id, SessionService sesion)
        {
            DataTable dtCtacte;
            dtCtacte = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresDataTable(CuentaCorrienteProveedoresService.Id_NombreCol + " = " + ctacte_proveedor_id, string.Empty, sesion);

            return (decimal)dtCtacte.Rows[0][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacte.Rows[0][CuentaCorrienteProveedoresService.Debito_NombreCol];
        }
        #endregion GetDeudaDeMovimiento

        #region GetDeudaTotal
        /// <summary>
        /// Gets the deuda total.
        /// </summary>
        /// <param name="ctacte_proveedor_id">The ctacte_proveedor_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetDeudaTotal(decimal ctacte_proveedor_id, SessionService sesion)
        {
            CTACTE_PROVEEDORESRow rowMovimiento = sesion.db.CTACTE_PROVEEDORESCollection.GetByPrimaryKey(ctacte_proveedor_id);
            CTACTE_PROVEEDORESRow[] rows = sesion.db.CTACTE_PROVEEDORESCollection.GetByCASO_ID(rowMovimiento.CASO_ID);
            decimal saldo = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                saldo += rows[i].CREDITO - rows[i].DEBITO;
            }

            return saldo;
        }
        #endregion GetDeudaTotal

        #region GetTotalPorCaso
        public static decimal GetTotalPorCaso(string columna, decimal caso_id, decimal ctacte_concepto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTotalPorCaso(columna, caso_id, ctacte_concepto_id, sesion);
            }
        }
        public static decimal GetTotalPorCaso(string columna, decimal caso_id, decimal ctacte_concepto_id, SessionService sesion)
        {
            string sql = "select nvl(sum(" + columna + "),0)" +
                         "  from " + CuentaCorrienteProveedoresService.Nombre_Tabla +
                         " where " + CuentaCorrienteProveedoresService.CasoId_NombreCol + " = " + caso_id +
                         "   and " + CuentaCorrienteProveedoresService.CtaCteConceptoId_NombreCol + " = " + ctacte_concepto_id +
                         "   and " + CuentaCorrienteProveedoresService.CtacteProveedorRelacId_NombreCol + " is null";

            DataTable dt = sesion.db.EjecutarQuery(sql);
            if (Services.Common.Interprete.EsNullODBNull(dt.Rows[0][0]))
                return 0;
            else
                return (decimal)dt.Rows[0][0];
        }
        #endregion GetTotalPorCaso

        #region GetSaldoPorCaso
        public static decimal GetSaldoPorCaso(string columna, decimal caso_id, decimal ctacte_concepto_id, DateTime? fecha_corte)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSaldoPorCaso(columna, caso_id, ctacte_concepto_id, fecha_corte, sesion);
            }
        }

        public static decimal GetSaldoPorCaso(string columna, decimal caso_id, decimal ctacte_concepto_id, DateTime? fecha_corte, SessionService sesion)
        {
            string col1, col2;
            if (columna == CuentaCorrienteProveedoresService.Credito_NombreCol)
            {
                col1 = CuentaCorrienteProveedoresService.Credito_NombreCol;
                col2 = CuentaCorrienteProveedoresService.Debito_NombreCol;
            }
            else
            {
                col1 = CuentaCorrienteProveedoresService.Debito_NombreCol;
                col2 = CuentaCorrienteProveedoresService.Credito_NombreCol;
            }

            string sql = "select sum(saldo) from \n" +
                  "(select cp1." + col1 + " - \n" +
                  "       nvl((select sum(cp2." + col2 + ") \n" +
                  "              from " + CuentaCorrienteProveedoresService.Nombre_Tabla + " cp2 \n" +
                  "             where cp1." + CuentaCorrienteProveedoresService.Id_NombreCol + " = cp2." + CuentaCorrienteProveedoresService.CtacteProveedorRelacId_NombreCol + "\n";
            if (fecha_corte.HasValue)
                sql += " and trunc(cp2." + CuentaCorrienteProveedoresService.FechaVencimiento_NombreCol + ") <= to_date('" + fecha_corte.Value.ToShortDateString() + "', 'dd/mm/yyyy')";
            sql += " ), 0) saldo " + "\n" +
                   "  from " + CuentaCorrienteProveedoresService.Nombre_Tabla + " cp1 \n" +
                   " where cp1." + CuentaCorrienteProveedoresService.CasoId_NombreCol + " = " + caso_id + "\n" +
                   "   and cp1." + CuentaCorrienteProveedoresService.CtaCteConceptoId_NombreCol + " = " + ctacte_concepto_id + "\n" +
                   "   and cp1." + CuentaCorrienteProveedoresService.CtacteProveedorRelacId_NombreCol + " is null)";

            DataTable dt = sesion.db.EjecutarQuery(sql);
            if (Services.Common.Interprete.EsNullODBNull(dt.Rows[0][0]))
                return 0;
            else
                return (decimal)dt.Rows[0][0];
        }
        #endregion GetSaldoPorCaso

        #region GetCasosPaganCaso
        public static DataTable GetCasosPaganCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas;
                clausulas = "select distinct cp2." + CuentaCorrienteProveedoresService.CasoId_NombreCol +
                        "      from " + Nombre_Tabla + " cp1, " + Nombre_Tabla + " cp2 " +
                        "     where cp1." + CuentaCorrienteProveedoresService.CasoId_NombreCol + " = " + caso_id +
                        "       and cp1." + CuentaCorrienteProveedoresService.Id_NombreCol + " = cp2." + CuentaCorrienteProveedoresService.CtacteProveedorRelacId_NombreCol;
                DataTable dt = CasosService.GetCasosInfoCompleta(CasosService.Id_NombreCol + " in (" + clausulas + ")", CasosService.FechaFormulario_NombreCol, sesion);
                return dt;
            }
        }
        #endregion GetListaCasosPaganCaso

        #region TienePagoCaso
        public static bool TienePagoCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return TienePagoCaso(caso_id, sesion);
            }
        }
        public static bool TienePagoCaso(decimal caso_id, SessionService sesion)
        {
            CTACTE_PROVEEDORESRow[] deudas = sesion.db.CTACTE_PROVEEDORESCollection.GetByCASO_ID(caso_id);
            for (int i = 0; i < deudas.Length; i++)
            {
                if (deudas[i].DEBITO > 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion TienePagoCaso

        #region Borrar
        public static void BorrarPorCalendarioPagoId(decimal calendario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    BorrarPorCalendarioPagoId(calendario_id, sesion);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void BorrarPorCalendarioPagoId(decimal calendario_id, SessionService sesion)
        {
            try
            {
                CTACTE_PROVEEDORESRow[] ctacte = sesion.db.CTACTE_PROVEEDORESCollection.GetByCALENDARIO_PAGOS_FC_PROV_ID(calendario_id);
                for (int i = 0; i < ctacte.Length; i++)
                {
                    BorrarPorId(ctacte[i].ID, sesion);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void BorrarPorId(decimal ctacte_proveedor_id, SessionService sesion)
        {
            try
            {
                string verificacion = VerificarReferencias(ctacte_proveedor_id, sesion);
                if (verificacion.Equals(string.Empty))
                    sesion.db.CTACTE_PROVEEDORESCollection.DeleteByPrimaryKey(ctacte_proveedor_id);
                else
                    throw new Exception(verificacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string VerificarReferencias(decimal ctacte_proveedor_id, SessionService sesion)
        {
            decimal caso_id;
            decimal detalle_id;
            string query = " select evc." + EgresosVariosCajaService.CasoId_NombreCol + " as caso_id ,evcd." + EgresosVariosCajaDetalleService.Id_NombreCol + " as detalle_id";
            query += " from " + EgresosVariosCajaDetalleService.Nombre_Tabla + " evcd, " + EgresosVariosCajaService.Nombre_Tabla + " evc";
            query += " where evc." + EgresosVariosCajaService.Id_NombreCol + "= evcd." + EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol;
            query += " and evcd." + EgresosVariosCajaDetalleService.CtacteProveedorId_NombreCol + " =" + ctacte_proveedor_id;
            query += " union ";
            query += " select op." + OrdenesPagoService.CasoId_NombreCol + " as caso_id, opd." + OrdenesPagoDetalleService.Id_NombreCol + " as detalle_id";
            query += " from " + OrdenesPagoService.Nombre_Tabla + " op, " + OrdenesPagoDetalleService.Nombre_Tabla + " opd ";
            query += " where op." + OrdenesPagoService.Id_NombreCol + " = opd." + OrdenesPagoDetalleService.OrdenPagoId_NombreCol;
            query += " and opd." + OrdenesPagoDetalleService.CtacteProveedorId_NombreCol + " = " + ctacte_proveedor_id;
            query += " union ";
            query += " select null as caso_id, ppd." + PlanillasPagosDetallesService.Id_NombreCol + " as detalle_id ";
            query += " from " + PlanillasPagosService.Nombre_Tabla + " pp, " + PlanillasPagosDetallesService.Nombre_Tabla + " ppd ";
            query += " where pp." + PlanillasPagosService.Id_NombreCol + "= ppd." + PlanillasPagosDetallesService.PlanillaPagoId_NombreCol;
            query += " and ppd." + PlanillasPagosDetallesService.CtaCteProveedorId_NombreCol + "=" + ctacte_proveedor_id;
            DataTable dt = sesion.db.EjecutarQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                detalle_id = decimal.Parse(dt.Rows[i]["detalle_id"].ToString());
                if (!dt.Rows[i]["caso_id"].ToString().Equals(string.Empty))
                {
                    caso_id = decimal.Parse(dt.Rows[i]["caso_id"].ToString());
                    if (CasosService.GetEstadoCaso(caso_id, sesion).Equals(Definiciones.EstadosFlujos.Borrador) || CasosService.GetEstadoCaso(caso_id, sesion).Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        int flujo_id = int.Parse(CasosService.GetFlujo(caso_id, sesion).ToString());

                        if (flujo_id == Definiciones.FlujosIDs.ORDEN_DE_PAGO)
                            OrdenesPagoDetalleService.Borrar(detalle_id, sesion);

                        if (flujo_id == Definiciones.FlujosIDs.EGRESO_VARIO_CAJA)
                            EgresosVariosCajaDetalleService.Borrar(detalle_id, sesion);
                    }
                    else
                    {
                        return "Las Cuotas de la Factura ya se encuentran en el caso: " + caso_id + ". Favor Verificar";
                    }

                }
                else
                {
                    (new PlanillasPagosDetallesService()).Borrar(detalle_id, sesion);
                }

            }
            return string.Empty;
        }
        #endregion Borrar

        #region ActualizarVencimiento
        /// <summary>
        /// Actualizars the vencimiento.
        /// </summary>
        /// <param name="ctacte_proveedor_id">The ctacte_proveedor_id.</param>
        /// <param name="fecha_vencimiento">The fecha_vencimiento.</param>
        public void ActualizarVencimiento(decimal ctacte_proveedor_id, DateTime fecha_vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PROVEEDORESRow row = sesion.Db.CTACTE_PROVEEDORESCollection.GetByPrimaryKey(ctacte_proveedor_id);
                string valorAnterior = row.FECHA_VENCIMIENTO.ToString();

                row.FECHA_VENCIMIENTO = fecha_vencimiento;

                sesion.Db.CTACTE_PROVEEDORESCollection.Update(row);
                LogCambiosService.LogDeColumna(Nombre_Tabla, CuentaCorrienteProveedoresService.FechaVencimiento_NombreCol, row.ID, valorAnterior, row.FECHA_VENCIMIENTO.ToString(), sesion);
            }
        }
        #endregion ActualizarVencimiento

        #region AgregarCredito
        /// <summary>
        /// Agregars the credito.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <param name="ctacte_proveedor_relacionada_id">The ctacte_proveedor_relacionada_id.</param>
        /// <param name="ctacte_valor_id">The ctacte_valor_id.</param>
        /// <param name="concepto_id">The concepto_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="total">The total.</param>
        /// <param name="comentario">The comentario.</param>
        /// <param name="fecha_vencimiento">The fecha_vencimiento.</param>
        /// <param name="calendario_pagos_proveedor_id">The calendario_pagos_proveedor_id.</param>
        /// <param name="credito_proveedor_id">The credito_proveedor_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void AgregarCredito(decimal proveedor_id, decimal ctacte_proveedor_relacionada_id, decimal ctacte_valor_id, decimal concepto_id, decimal caso_id, decimal moneda_id, decimal total, string comentario, DateTime fecha_vencimiento, decimal calendario_pagos_proveedor_id, decimal credito_proveedor_id, decimal orden_pago_valor_id, SessionService sesion)
        {
            try
            {
                CTACTE_PROVEEDORESRow row = new CTACTE_PROVEEDORESRow();
                CTACTE_PROVEEDORESRow rowPrincipal;
                string valorAnterior;

                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_proveedores_sqc");
                row.PROVEEDOR_ID = proveedor_id;

                //Se redonde a la cantidad de decimales de la moneda
                total = Math.Round(total, MonedasService.CantidadDecimalesStatic(moneda_id, sesion));

                if (caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCASO_IDNull = true;
                else
                    row.CASO_ID = caso_id;

                row.FECHA_INSERCION = DateTime.Now;
                row.FECHA_VENCIMIENTO = fecha_vencimiento;

                row.MONEDA_ID = moneda_id;
                row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(sesion.SucursalActiva.PAIS_ID, moneda_id, row.FECHA_INSERCION, sesion);

                row.CTACTE_CONCEPTO_ID = concepto_id;
                row.CTACTE_VALOR_ID = ctacte_valor_id;

                //Si el movimiento es principal entonces debe guardarse el numero de caso y el debito debe ser 0
                //Si no es principal, entonces el debito es igual al credito (ya que tambien se actualiza el credito
                //del movimiento principal y el numero de caso no es almacenado.
                if (ctacte_proveedor_relacionada_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    row.DEBITO = 0;
                }
                else
                {
                    //El debito es igual al credito para no duplicar el debe.
                    //ya que se afecta el credito al movimiento principal
                    row.DEBITO = total;
                    row.CTACTE_PROVEEDOR_RELAC_ID = ctacte_proveedor_relacionada_id;

                    rowPrincipal = sesion.Db.CTACTE_PROVEEDORESCollection.GetByPrimaryKey(ctacte_proveedor_relacionada_id);
                    valorAnterior = rowPrincipal.ToString();
                    rowPrincipal.CREDITO += total;

                    //Se actualiza el movimiento principal
                    sesion.Db.CTACTE_PROVEEDORESCollection.Update(rowPrincipal);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPrincipal.ID, valorAnterior, rowPrincipal.ToString(), sesion);
                }

                row.MONEDA_ID = moneda_id;
                row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(sesion.SucursalActiva.PAIS_ID, moneda_id, row.FECHA_INSERCION, sesion);

                //falta ctacte_pagare_det_id

                row.CREDITO = total;
                row.CONCEPTO = comentario;
                row.FECHA_INSERCION = DateTime.Now;
                row.FECHA_VENCIMIENTO = fecha_vencimiento;

                if (calendario_pagos_proveedor_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCALENDARIO_PAGOS_FC_PROV_IDNull = true;
                else
                    row.CALENDARIO_PAGOS_FC_PROV_ID = calendario_pagos_proveedor_id;

                if (credito_proveedor_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCREDITO_PROVEEDOR_DET_IDNull = true;
                else
                    row.CREDITO_PROVEEDOR_DET_ID = credito_proveedor_id;

                if (orden_pago_valor_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsORDEN_PAGO_VALOR_IDNull = true;
                else
                    row.ORDEN_PAGO_VALOR_ID = orden_pago_valor_id;

                sesion.Db.CTACTE_PROVEEDORESCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        #endregion AgregarCredito

        #region DeshacerPagarCredito
        public static void DeshacerPagarCredito(decimal ctacte_proveedor_id, decimal caso_id,SessionService sesion)
        {
            try
            {
                string flujoId = string.Empty;
                string estadoActual = string.Empty;
                DataTable ctacteProveedores;
                string query = "select * from ctacte_proveedores ccp where ccp.ctacte_proveedor_relac_id = " + ctacte_proveedor_id + " and ccp.caso_id = " + caso_id;
                ctacteProveedores = sesion.db.EjecutarQuery(query);

                foreach (DataRow row in ctacteProveedores.Rows)
                {
                    CTACTE_PROVEEDORESRow rowPrincipal = sesion.db.CTACTE_PROVEEDORESCollection.GetByPrimaryKey((decimal)row["CTACTE_PROVEEDOR_RELAC_ID"]);
                    rowPrincipal.DEBITO -= (decimal)row["DEBITO"];
                    sesion.db.CTACTE_PROVEEDORESCollection.Update(rowPrincipal);
                    sesion.db.CTACTE_PROVEEDORESCollection.DeleteByPrimaryKey((decimal)row["ID"]);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, (decimal)row["ID"], row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    //Segun sea el flujo, el caso pudo cambiar de estado si se habia finiquitado
                    #region cambiar estado segun flujo
                    if (!rowPrincipal.IsCASO_IDNull)
                    {
                        CasosService.GetFlujoYEstado(rowPrincipal.CASO_ID, ref flujoId, ref estadoActual, sesion);

                        switch (int.Parse(flujoId))
                        {
                            case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                    CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Cerrado, sesion);
                                break;
                            case Definiciones.FlujosIDs.CREDITOS_PROVEEDOR:
                                if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                    CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Vigente, Definiciones.EstadosFlujos.Cerrado, sesion);
                                break;
                            case Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR:
                                if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                    CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Cerrado, sesion);
                                break;
                        }
                    }
                    #endregion cambiar estado segun flujo
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion DeshacerPagarCredito

        #region AgregarDebito
        /// <summary>
        /// Agregars the debito.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <param name="ctacte_proveedor_relacionado_id">The ctacte_proveedor_relacionado_id.</param>
        /// <param name="concepto_id">The concepto_id.</param>
        /// <param name="ctacte_valor_id">The ctacte_valor_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="total">The total.</param>
        /// <param name="comentario">The comentario.</param>
        /// <param name="fecha_vencimiento">The fecha_vencimiento.</param>
        /// <param name="orden_pago_id">The orden_pago_id.</param>
        /// <param name="movimiento_vario_tesoreria_id">The movimiento_vario_tesoreria_id.</param>
        /// <param name="egreso_vario_caja_id">The egreso_vario_caja_id.</param>
        /// <param name="pagare_detalle_id">The pagare_detalle_id.</param>
        public static void AgregarDebito(decimal proveedor_id, decimal ctacte_proveedor_relacionado_id, decimal concepto_id, decimal ctacte_valor_id, decimal caso_id, decimal moneda_id, decimal total, string comentario, DateTime fecha_vencimiento, decimal orden_pago_id, decimal movimiento_vario_tesoreria_id, decimal egreso_vario_caja_id, decimal pagare_detalle_id, decimal nc_aplicacion_id, decimal nc_aplicacion_detalle_id, SessionService sesion)
        {
            try
            {
                CTACTE_PROVEEDORESRow row = new CTACTE_PROVEEDORESRow();
                CTACTE_PROVEEDORESRow rowPrincipal;
                string valorAnterior;

                //Se redonde a la cantidad de decimales de la moneda
                total = Math.Round(total, MonedasService.CantidadDecimalesStatic(moneda_id, sesion));

                #region Creacion del row a insertar
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_proveedores_sqc");
                row.PROVEEDOR_ID = proveedor_id;

                row.MONEDA_ID = moneda_id;
                row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(sesion.SucursalActiva.PAIS_ID, moneda_id, DateTime.Now, sesion);

                if (orden_pago_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsORDEN_PAGO_IDNull = true;
                else
                    row.ORDEN_PAGO_ID = orden_pago_id;

                if (movimiento_vario_tesoreria_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsMOVIMIENTO_VARIO_TESORERIA_IDNull = true;
                else
                    row.MOVIMIENTO_VARIO_TESORERIA_ID = movimiento_vario_tesoreria_id;

                if (egreso_vario_caja_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsEGRESO_VARIO_CAJA_IDNull = true;
                else
                    row.EGRESO_VARIO_CAJA_ID = egreso_vario_caja_id;

                if (pagare_detalle_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCTACTE_PAGARE_DET_IDNull = true;
                else
                    row.CTACTE_PAGARE_DET_ID = pagare_detalle_id;

                if (nc_aplicacion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsNC_APLICACION_IDNull = true;
                else
                    row.NC_APLICACION_ID = nc_aplicacion_id;

                if (nc_aplicacion_detalle_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsNC_APLICACION_DET_IDNull = true;
                else
                    row.NC_APLICACION_DET_ID = nc_aplicacion_detalle_id;

                row.CTACTE_CONCEPTO_ID = concepto_id;
                row.CTACTE_VALOR_ID = ctacte_valor_id;

                if (ctacte_proveedor_relacionado_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCTACTE_PROVEEDOR_RELAC_IDNull = true;
                else row.CTACTE_PROVEEDOR_RELAC_ID = ctacte_proveedor_relacionado_id;

                if (caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    row.IsCASO_IDNull = true;
                else
                    row.CASO_ID = caso_id;

                row.DEBITO = total;
                row.CONCEPTO = comentario;
                row.FECHA_INSERCION = DateTime.Now;
                row.FECHA_VENCIMIENTO = fecha_vencimiento;
                #endregion Creacion del row a insertar

                //Si el movimiento de debito es por pago a un credito, se debe
                //haber indicado ctacte_proveedor_relacionado_id.
                //Si dicho campo es -1 entonces se trata de un debito por Anticipo
                //o algun flujo equivalente y no hay un credito que se este pagando
                #region Actualizacion del movimiento principal
                if (!ctacte_proveedor_relacionado_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    rowPrincipal = sesion.Db.CTACTE_PROVEEDORESCollection.GetByPrimaryKey(ctacte_proveedor_relacionado_id);
                    valorAnterior = rowPrincipal.ToString();
                    rowPrincipal.DEBITO += row.DEBITO;

                    //El credito es igual al debito para no duplicar el haber.
                    //ya que se afecta el debito al movimiento principal
                    row.CREDITO = total;

                    //Se actualiza el movimiento principal
                    sesion.Db.CTACTE_PROVEEDORESCollection.Update(rowPrincipal);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPrincipal.ID, valorAnterior, rowPrincipal.ToString(), sesion);
                }
                #endregion Actualizacion del movimiento principal

                //Se inserta el movimiento nuevo
                sesion.Db.CTACTE_PROVEEDORESCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion AgregarDebito

        #region DeshacerAgregarDebito
        public static void DeshacerAgregarDebito(decimal caso_id, SessionService sesion)
        {
            try
            {
                CTACTE_PROVEEDORESRow[] rows = sesion.db.CTACTE_PROVEEDORESCollection.GetByCASO_ID(caso_id);
                for (int i = 0; i < rows.Length; i++)
                {
                    sesion.db.CTACTE_PROVEEDORESCollection.Delete(rows[i]);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[i].ID, rows[i].ToString(), Definiciones.Log.RegistroBorrado, sesion);
                }
            }
            catch
            {
                throw;
            }
        }

        public static void DeshacerAgregarDebitoDesdeOP(decimal orden_pago_valor_id, SessionService sesion)
        {
            try
            {
                string flujoId = string.Empty;
                string estadoActual = string.Empty;

                CTACTE_PROVEEDORESRow[] rowRelacionado = sesion.db.CTACTE_PROVEEDORESCollection.GetByORDEN_PAGO_VALOR_ID(orden_pago_valor_id);
                if (rowRelacionado.Length > 0)
                {
                    CTACTE_PROVEEDORESRow rowPrincipal = sesion.db.CTACTE_PROVEEDORESCollection.GetByPrimaryKey(rowRelacionado[0].CTACTE_PROVEEDOR_RELAC_ID);
                    rowPrincipal.CREDITO -= rowRelacionado[0].CREDITO;
                    sesion.db.CTACTE_PROVEEDORESCollection.Update(rowPrincipal);
                    sesion.db.CTACTE_PROVEEDORESCollection.DeleteByPrimaryKey(rowRelacionado[0].ID);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rowRelacionado[0].ID, rowRelacionado.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    //Segun sea el flujo, el caso pudo cambiar de estado si se habia finiquitado
                    #region cambiar estado segun flujo
                    if (!rowPrincipal.IsCASO_IDNull)
                    {
                        CasosService.GetFlujoYEstado(rowPrincipal.CASO_ID, ref flujoId, ref estadoActual, sesion);

                        switch (int.Parse(flujoId))
                        {
                            case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                    CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Cerrado, Definiciones.EstadosFlujos.Aprobado, sesion);
                                break;
                            case Definiciones.FlujosIDs.CREDITOS_PROVEEDOR:
                                if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                    CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Vigente, Definiciones.EstadosFlujos.Cerrado, sesion);
                                break;
                            case Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR:
                                if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                    CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Cerrado, sesion);
                                break;
                        }
                    }
                    #endregion cambiar estado segun flujo
                }
            }
            catch
            {
                throw;
            }
        }

        public static void DeshacerAgregarDebitoDesdeEgresoVario(decimal egreso_vario_caja_id, SessionService sesion)
        {
            try
            {
                string flujoId = string.Empty;
                string estadoActual = string.Empty;

                CTACTE_PROVEEDORESRow[] rowRelacionado = sesion.db.CTACTE_PROVEEDORESCollection.GetByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id);
                if (rowRelacionado.Length > 0)
                {
                    CTACTE_PROVEEDORESRow rowPrincipal = sesion.db.CTACTE_PROVEEDORESCollection.GetByPrimaryKey(rowRelacionado[0].CTACTE_PROVEEDOR_RELAC_ID);
                    rowPrincipal.CREDITO -= rowRelacionado[0].CREDITO;
                    sesion.db.CTACTE_PROVEEDORESCollection.Update(rowPrincipal);
                    sesion.db.CTACTE_PROVEEDORESCollection.DeleteByPrimaryKey(rowRelacionado[0].ID);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rowRelacionado[0].ID, rowRelacionado.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    //Segun sea el flujo, el caso pudo cambiar de estado si se habia finiquitado
                    #region cambiar estado segun flujo
                    if (!rowPrincipal.IsCASO_IDNull)
                    {
                        CasosService.GetFlujoYEstado(rowPrincipal.CASO_ID, ref flujoId, ref estadoActual, sesion);

                        switch (int.Parse(flujoId))
                        {
                            case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                    CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Cerrado, Definiciones.EstadosFlujos.Aprobado, sesion);
                                break;
                            case Definiciones.FlujosIDs.CREDITOS_PROVEEDOR:
                                if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                    CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Vigente, Definiciones.EstadosFlujos.Cerrado, sesion);
                                break;
                            case Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR:
                                if (estadoActual == Definiciones.EstadosFlujos.Cerrado)
                                    CambioEstadoCasoService.BorrarCambioEstado(rowPrincipal.CASO_ID, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Cerrado, sesion);
                                break;
                        }
                    }
                    #endregion cambiar estado segun flujo
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion DeshacerAgregarDebito

        #region GetRetencionesExistentes
        public static Dictionary<decimal, string> GetRetencionesExistentes(int flujo_id, decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                var retenciones = new Dictionary<decimal, List<string>>();
                var resultado = new Dictionary<decimal, string>();

                string fromFlujo, whereFlujo, whereCaso;
                string selectCasoRetiene = "caso_reteniendo";
                string selectCasoRetenido = "caso_retenido";

                switch (flujo_id)
                {
                    case Definiciones.FlujosIDs.EGRESO_VARIO_CAJA:
                        fromFlujo = EgresosVariosCajaDetalleService.Nombre_Vista + " x";
                        whereFlujo = "x." + EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol + " = " + cabecera_id;
                        whereCaso = "x." + EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol;

                        DataTable dtEgresoVarioDet = EgresosVariosCajaDetalleService.GetEgresosVariosCajaDetallesInfoCompleta(EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol + " = " + cabecera_id, string.Empty, sesion);
                        for (int i = 0; i < dtEgresoVarioDet.Rows.Count; i++)
                        {
                            if (!retenciones.ContainsKey((decimal)dtEgresoVarioDet.Rows[i][EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol]))
                                retenciones.Add((decimal)dtEgresoVarioDet.Rows[i][EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol], new List<string>());
                        }
                        break;
                    case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                        fromFlujo = OrdenesPagoDetalleService.Nombre_Tabla + " x";
                        whereFlujo = "x." + OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + cabecera_id;
                        whereCaso = "x." + OrdenesPagoDetalleService.CasoReferidoId_NombreCol;

                        DataTable dtOrdenPagoDet = OrdenesPagoDetalleService.GetOrdenesPagoDetallesDataTable2(OrdenesPagoDetalleService.OrdenPagoId_NombreCol + " = " + cabecera_id, string.Empty, sesion);
                        for (int i = 0; i < dtOrdenPagoDet.Rows.Count; i++)
                        {
                            if (!retenciones.ContainsKey((decimal)dtOrdenPagoDet.Rows[i][OrdenesPagoDetalleService.CasoReferidoId_NombreCol]))
                                retenciones.Add((decimal)dtOrdenPagoDet.Rows[i][OrdenesPagoDetalleService.CasoReferidoId_NombreCol], new List<string>());
                        }
                        break;
                    default: throw new Exception("CuentaCorrienteProveedoresService.GetRetencionesExistentes(). Flujo no implementado.");
                }

                string sql = string.Empty;
                sql += "select " + OrdenesPagoValoresService.VistaOrdenPagoCasoId_NombreCol + " " + selectCasoRetiene + ", " + OrdenesPagoValoresService.RetencionAuxCasos_NombreCol + " " + selectCasoRetenido +
                       "  from " + OrdenesPagoValoresService.Nombre_Vista + " opvic, " + fromFlujo +
                       " where " + whereFlujo +
                       "   and " + OrdenesPagoValoresService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.RetencionIVA +
                       "   and " + OrdenesPagoValoresService.VistaOrdenPagoCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                       "   and " + OrdenesPagoValoresService.RetencionAuxCasos_NombreCol + " like '%' || " + whereCaso + " || '%'" +
                       " union " +
                       "select " + EgresosVariosCajaValoresService.VistaCasoId_NombreCol + " " + selectCasoRetiene + ", " + EgresosVariosCajaValoresService.RetencionAuxCasos_NombreCol + " " + selectCasoRetenido +
                       "  from " + EgresosVariosCajaValoresService.Nombre_Vista + " evcic, " + fromFlujo +
                       " where " + whereFlujo +
                       "   and " + EgresosVariosCajaValoresService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.RetencionIVA +
                       "   and " + EgresosVariosCajaValoresService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                       "   and " + EgresosVariosCajaValoresService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                       "   and " + EgresosVariosCajaValoresService.RetencionAuxCasos_NombreCol + " like '%' || " + whereCaso + " || '%'" +
                       " order by 2, 1";

                DataTable dt = sesion.db.EjecutarQuery(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string[] separar = ((string)dt.Rows[i][selectCasoRetenido]).Split('@');
                    for (int j = 0; j < separar.Length; j++)
                    {
                        decimal casoRetenidoId = decimal.Parse(separar[j]);
                        if (retenciones.ContainsKey(casoRetenidoId))
                            retenciones[casoRetenidoId].Add(dt.Rows[i][selectCasoRetiene].ToString());
                    }
                }

                foreach (KeyValuePair<decimal, List<string>> item in retenciones)
                    resultado[item.Key] = string.Join(", ", item.Value.ToArray());

                return resultado;
            }
        }
        #endregion GetRetencionesExistentes

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PROVEEDORES"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTACTE_PROVEEDORES_INFO_COMPL"; }
        }
        public static string CasoId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.CASO_IDColumnName; }
        }
        public static string Concepto_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.CONCEPTOColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string Credito_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.CREDITOColumnName; }
        }
        public static string CreditoProveedorDetId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.CREDITO_PROVEEDOR_DET_IDColumnName; }
        }
        public static string CtaCteConceptoId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.CTACTE_CONCEPTO_IDColumnName; }
        }
        public static string CtactePagareDetId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.CTACTE_PAGARE_DET_IDColumnName; }
        }
        public static string CtacteProveedorRelacId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.CTACTE_PROVEEDOR_RELAC_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string Debito_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.DEBITOColumnName; }
        }
        public static string EgresoVarioCajaId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.EGRESO_VARIO_CAJA_IDColumnName; }
        }
        public static string FechaInsercion_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.FECHA_INSERCIONColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.MONEDA_IDColumnName; }
        }
        public static string MovimientoVarioTesoreriaId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.MOVIMIENTO_VARIO_TESORERIA_IDColumnName; }
        }
        public static string OrdenPagoId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.ORDEN_PAGO_IDColumnName; }
        }
        public static string OrdenPagoValorId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.ORDEN_PAGO_VALOR_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.PROVEEDOR_IDColumnName; }
        }
        public static string CalendarioPagosFcProvId_NombreCol
        {
            get { return CTACTE_PROVEEDORESCollection.CALENDARIO_PAGOS_FC_PROV_IDColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaFechaVencimientoTexto_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.FECHA_VENCIMIENTO_TEXTOColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.FLUJO_IDColumnName; }
        }
        public static string VistaCtacteConceptoDescripcion_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.CTACTE_CONCEPTO_DESCRIPCIONColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaSaldoCredito_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.SALDO_CREDITOColumnName; }
        }
        public static string VistaProveedorNombre_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.PROVEEDOR_NOMBREColumnName; }
        }
        public static string VistaCasoEntidadId_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.CASO_ENTIDAD_IDColumnName; }
        }
        public static string VistaCasoFechaFormulario_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.CASO_FECHA_FORMULARIOColumnName; }
        }
        public static string VistaFCCtacteFondoFijoId_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.FC_PROV_CTACTE_FONDO_FIJO_IDColumnName; }
        }
        public static string VistaFCProvPagarPorFondoFijo_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.FC_PROV_PAGAR_POR_FONDO_FIJOColumnName; }
        }
        public static string VistaRetencionAplicada_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.RETENCION_APLICADAColumnName; }
        }
        public static string VistaObservacion_NombreCol
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.OBSERVACIONColumnName; }
        }
        public static string VistaSucursalId
        {
            get { return CTACTE_PROVEEDORES_INFO_COMPLCollection.SUCURSAL_IDColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrienteProveedoresService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrienteProveedoresService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected CTACTE_PROVEEDORESRow row;
        protected CTACTE_PROVEEDORESRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? CalendarioPagosFCProvId { get { if (row.IsCALENDARIO_PAGOS_FC_PROV_IDNull) return null; else return row.CALENDARIO_PAGOS_FC_PROV_ID; } set { if (value.HasValue) row.CALENDARIO_PAGOS_FC_PROV_ID = value.Value; else row.IsCALENDARIO_PAGOS_FC_PROV_IDNull = true; } }
        public decimal? CasoId { get { if (row.IsCASO_IDNull) return null; else return row.CASO_ID; } set { if (value.HasValue) row.CASO_ID = value.Value; else row.IsCASO_IDNull = true; } }
        public string Concepto { get { return ClaseCBABase.GetStringHelper(row.CONCEPTO); } set { row.CONCEPTO = value; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal Credito { get { return row.CREDITO; } set { row.CREDITO = value; } }
        public decimal? CreditoProveedorDetId { get { if (row.IsCREDITO_PROVEEDOR_DET_IDNull) return null; else return row.CREDITO_PROVEEDOR_DET_ID; } set { if (value.HasValue) row.CREDITO_PROVEEDOR_DET_ID = value.Value; else row.IsCREDITO_PROVEEDOR_DET_IDNull = true; } }
        public decimal CtacteConceptoId { get { return row.CTACTE_CONCEPTO_ID; } set { row.CTACTE_CONCEPTO_ID = value; } }
        public decimal? CtactePagareDetId { get { if (row.IsCTACTE_PAGARE_DET_IDNull) return null; else return row.CTACTE_PAGARE_DET_ID; } set { if (value.HasValue) row.CTACTE_PAGARE_DET_ID = value.Value; else row.IsCTACTE_PAGARE_DET_IDNull = true; } }
        public decimal? CtacteProveedorRelacId { get { if (row.IsCTACTE_PROVEEDOR_RELAC_IDNull) return null; else return row.CTACTE_PROVEEDOR_RELAC_ID; } set { if (value.HasValue) row.CTACTE_PROVEEDOR_RELAC_ID = value.Value; else row.IsCTACTE_PROVEEDOR_RELAC_IDNull = true; } }
        public decimal? CtacteValorId { get { if (row.IsCTACTE_VALOR_IDNull) return null; else return row.CTACTE_VALOR_ID; } set { if (value.HasValue) row.CTACTE_VALOR_ID = value.Value; else row.IsCTACTE_VALOR_IDNull = true; } }
        public decimal Debito { get { return row.DEBITO; } set { row.DEBITO = value; } }
        public decimal? EgresoVarioCajaId { get { if (row.IsEGRESO_VARIO_CAJA_IDNull) return null; else return row.EGRESO_VARIO_CAJA_ID; } set { if (value.HasValue) row.EGRESO_VARIO_CAJA_ID = value.Value; else row.IsEGRESO_VARIO_CAJA_IDNull = true; } }
        public DateTime FechaInsercion { get { return row.FECHA_INSERCION; } set { row.FECHA_INSERCION = value; } }
        public DateTime FechaVencimiento { get { return row.FECHA_VENCIMIENTO; } set { row.FECHA_VENCIMIENTO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal? MovimientoVarioTesoreriaId { get { if (row.IsMOVIMIENTO_VARIO_TESORERIA_IDNull) return null; else return row.MOVIMIENTO_VARIO_TESORERIA_ID; } set { if (value.HasValue) row.MOVIMIENTO_VARIO_TESORERIA_ID = value.Value; else row.IsMOVIMIENTO_VARIO_TESORERIA_IDNull = true; } }
        public decimal? NCAplicacionDetId { get { if (row.IsNC_APLICACION_DET_IDNull) return null; else return row.NC_APLICACION_DET_ID; } set { if (value.HasValue) row.NC_APLICACION_DET_ID = value.Value; else row.IsNC_APLICACION_DET_IDNull = true; } }
        public decimal? NCAplicacionId { get { if (row.IsNC_APLICACION_IDNull) return null; else return row.NC_APLICACION_ID; } set { if (value.HasValue) row.NC_APLICACION_ID = value.Value; else row.IsNC_APLICACION_IDNull = true; } }
        public decimal? OrdenPagoId { get { if (row.IsORDEN_PAGO_IDNull) return null; else return row.ORDEN_PAGO_ID; } set { if (value.HasValue) row.ORDEN_PAGO_ID = value.Value; else row.IsORDEN_PAGO_IDNull = true; } }
        public decimal? OrdenPagoValorId { get { if (row.IsORDEN_PAGO_VALOR_IDNull) return null; else return row.ORDEN_PAGO_VALOR_ID; } set { if (value.HasValue) row.ORDEN_PAGO_VALOR_ID = value.Value; else row.IsORDEN_PAGO_VALOR_IDNull = true; } }
        public decimal ProveedorId { get { return row.PROVEEDOR_ID; } set { row.PROVEEDOR_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CuentaCorrienteConceptosService _ctacte_concepto;
        public CuentaCorrienteConceptosService CtacteConcepto
        {
            get
            {
                if (this._ctacte_concepto == null)
                    this._ctacte_concepto = new CuentaCorrienteConceptosService(this.CtacteConceptoId);
                return this._ctacte_concepto;
            }
        }
        
        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    //Descomentar cuando la clase sea orientada a objetos
                    //if(this.sesion != null)
                    //    this._caso = new CasosService(this.CasoId.Value, this.sesion);
                    //else
                    this._caso = new CasosService(this.CasoId.Value);
                }
                return this._caso;
            }
        }

        private CuentaCorrienteProveedoresService _ctacte_proveedor_relac;
        public CuentaCorrienteProveedoresService CtacteProveedorRelac
        {
            get
            {
                if (this._ctacte_proveedor_relac == null)
                    this._ctacte_proveedor_relac = new CuentaCorrienteProveedoresService(this.CtacteProveedorRelacId.Value);
                return this._ctacte_proveedor_relac;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = MonedasService.Instancia.Get<MonedasService>(this.MonedaId);
                return this._moneda;
            }
        }

        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                {
                    //Descomentar cuando la clase sea orientada a objetos
                    //if (this.sesion != null)
                    //    this._proveedor = new ProveedoresService(this.ProveedorId, this.sesion);
                    //else
                    this._proveedor = new ProveedoresService(this.ProveedorId);
                }
                return this._proveedor;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_PROVEEDORESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_PROVEEDORESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_PROVEEDORESRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrienteProveedoresService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteProveedoresService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteProveedoresService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private CuentaCorrienteProveedoresService(CTACTE_PROVEEDORESRow row)
        {
            Inicializar(row);
        }

        //Constructor temporal hasta que la clase se convierta a orientacion a objetos y pueda usarse el metodo Get
        public CuentaCorrienteProveedoresService(string columna, decimal id, SessionService sesion)
        {
            string clausulas = columna + " = " + id;

            var rows = sesion.db.CTACTE_PROVEEDORESCollection.GetAsArray(clausulas, CTACTE_PROVEEDORESCollection.IDColumnName);
            if (rows.Length > 0)
            {
                this.row = rows[0];
            }
            else
            {
                this.row = new CTACTE_PROVEEDORESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        public CuentaCorrienteProveedoresService(EdiCBA.CtacteProveedor edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = CuentaCorrientePagosPersonaDocumentoService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            if (edi.caso_id.HasValue)
                this.CasoId = edi.caso_id.Value;

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.venta;

            this.Credito = edi.credito;
            this.Debito = edi.debito;
            this.FechaInsercion = edi.fecha_creacion;
            this.FechaVencimiento = edi.fecha_vencimiento;
            this.CtacteValorId = edi.tipo_valor;

            #region ctacte proveedor relacionada
            if (!string.IsNullOrEmpty(edi.ctacte_proveedor_relacionada_uuid))
                this._ctacte_proveedor_relac = CuentaCorrienteProveedoresService.GetPorUUID(edi.ctacte_proveedor_relacionada_uuid, sesion);
            if (this._ctacte_proveedor_relac == null && edi.ctacte_proveedor_relacionada != null)
                this._ctacte_proveedor_relac = new CuentaCorrienteProveedoresService(edi.ctacte_proveedor_relacionada, almacenar_localmente, sesion);
            if (this._ctacte_proveedor_relac != null)
            {
                if (!this.CtacteProveedorRelac.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.CtacteProveedorRelac.Id.HasValue)
                    this.CtacteProveedorRelacId = this.CtacteProveedorRelac.Id.Value;
            }
            #endregion ctacte proveedor relacionada

            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda

            #region proveedor
            if (!string.IsNullOrEmpty(edi.proveedor_uuid))
                this._proveedor = ProveedoresService.GetPorUUID(edi.proveedor_uuid, sesion);
            if (this._proveedor == null && edi.proveedor != null)
                this._proveedor = new ProveedoresService(edi.proveedor, almacenar_localmente, sesion);
            if (this._proveedor == null)
                throw new Exception("No se encontró el UUID " + edi.proveedor_uuid + " ni se definieron los datos del objeto.");

            if (!this.Proveedor.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Proveedor.Id.HasValue)
                this.ProveedorId = this.Proveedor.Id.Value;
            #endregion proveedor
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._caso = null;
            this._ctacte_proveedor_relac = null;
            this._moneda = null;
            this._proveedor = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        public static CuentaCorrienteProveedoresService[] Buscar(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return Buscar(clausulas, orden, sesion);
            }
        }

        public static CuentaCorrienteProveedoresService[] Buscar(string clausulas, string orden, SessionService sesion)
        {
            var rows = sesion.db.CTACTE_PROVEEDORESCollection.GetAsArray(clausulas, orden);
            var cp = new CuentaCorrienteProveedoresService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cp[i] = new CuentaCorrienteProveedoresService(rows[i]);
            return cp;
        }
        #endregion Buscar

        #region DebitoAFecha
        public decimal DebitoAFecha(DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return DebitoAFecha(fecha, sesion);
            }
        }

        public decimal DebitoAFecha(DateTime fecha, SessionService sesion)
        {

            string sql = "select nvl(sum(" + CuentaCorrienteProveedoresService.Debito_NombreCol + "), 0)" +
                         "  from " + CuentaCorrienteProveedoresService.Nombre_Tabla + " cp," +
                         "       " + CasosService.Nombre_Tabla + " c" +
                         " where cp." + CuentaCorrienteProveedoresService.CtacteProveedorRelacId_NombreCol + " = " + this.Id.Value +
                         "   and cp." + CuentaCorrienteProveedoresService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +
                         "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                         "   and c." + CasosService.FechaFormatoNumero_NombreCol + " < " + fecha.Year.ToString() + fecha.Month.ToString("00") + fecha.Day.ToString("00");
            DataTable dt = sesion.db.EjecutarQuery(sql);
            return (decimal)dt.Rows[0][0];
        }
        #endregion DebitoAFecha

        #region PagosAFecha
        public CuentaCorrienteProveedoresService[] PagosAFecha(DateTime? fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return PagosAFecha(fecha, sesion);
            }
        }

        public CuentaCorrienteProveedoresService[] PagosAFecha(DateTime? fecha, SessionService sesion)
        {
            //Obtener los pagos de casos cuya fecha sea anterior a la fecha de corte.
            //Si es una orden de pago, usar la fecha en que pasó a cerrado y no la del caso.
            string sql = "exists(" +
                         "select cp." + CuentaCorrienteProveedoresService.Id_NombreCol +
                         "  from " + CuentaCorrienteProveedoresService.Nombre_Tabla + " cp," +
                         "       " + CasosService.Nombre_Tabla + " c" +
                         " where cp." + CuentaCorrienteProveedoresService.Id_NombreCol + " = " + CuentaCorrienteProveedoresService.Nombre_Tabla + "." + CuentaCorrienteProveedoresService.Id_NombreCol +
                         "   and cp." + CuentaCorrienteProveedoresService.CtacteProveedorRelacId_NombreCol + " = " + this.Id.Value +
                         "   and cp." + CuentaCorrienteProveedoresService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +
                         "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            if (fecha.HasValue)
            {
                sql += "   and nvl(c." + CasosService.FechaFormFormatoNumero_NombreCol + ", " +
                       "              " + CasosService.FechaFormatoNumero_NombreCol + 
                       "       ) < " + fecha.Value.Year.ToString() + fecha.Value.Month.ToString("00") + fecha.Value.Day.ToString("00") +
                       ")";
            }
            var rows = sesion.db.CTACTE_PROVEEDORESCollection.GetAsArray(sql, CuentaCorrienteProveedoresService.FechaVencimiento_NombreCol + ", " + CuentaCorrienteProveedoresService.Id_NombreCol);
            var cp = new CuentaCorrienteProveedoresService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cp[i] = new CuentaCorrienteProveedoresService(rows[i]);
            return cp;
        }
        #endregion PagosAFecha

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.CtacteProveedor()
            {
                caso_id = this.CasoId,
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, CuentaCorrienteProveedoresService.CotizacionMoneda_NombreCol, this.Id.Value, sesion),
                credito = this.Credito,
                ctacte_proveedor_relacionada_uuid = this.CtacteProveedorRelacId.HasValue ? this.CtacteProveedorRelac.GetOrCreateUUID(sesion) : null,
                cuota_numero = 1, //TODO: buscar el número de esta cuota respecto al total
                cuota_total = 1, //TODO: buscar la cantidad total de cuotas
                debito = this.Debito,
                fecha_creacion = this.FechaInsercion,
                fecha_vencimiento = this.FechaVencimiento,
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                proveedor_uuid = this.Proveedor.GetOrCreateUUID(sesion),
                tipo_valor = (int)this.CtacteValorId.Value
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.ctacte_proveedor_relacionada = (EdiCBA.CtacteProveedor)this.CtacteProveedorRelac.ToEDI(nueva_profundidad, sesion);
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.CasoId.HasValue ? this.Caso.FechaFormulario.Value : this.FechaInsercion,
                    moneda_uuid = e.moneda_uuid,
                    venta = this.CotizacionMoneda
                };
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
                e.proveedor = (EdiCBA.Proveedor)this.Proveedor.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
