using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Facturacion;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class PlanillasPagosDetallesService
    {
        #region GetPlanillaDetalles
        /// <summary>
        /// Gets the plantilla detalles.
        /// </summary>
        /// <param name="plantilla_detalle_id">The plantilla_detalle_id.</param>
        /// <returns></returns>
        public DataTable GetPlanillaDetalles(decimal planilla_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANTILLAS_DETALLESCollection.GetAsDataTable(PlanillasPagosDetallesService.Id_NombreCol + " = " + planilla_detalle_id, Id_NombreCol);
            }

        }
        #endregion GetPlanillaDetalles

        #region GetPlanillaDetallesPorPlanilla

        /// <summary>
        /// Gets the planilla detalles por planilla.
        /// </summary>
        /// <param name="plantilla_id">The plantilla_id.</param>
        /// <returns></returns>
        public DataTable GetPlanillaDetallesPorPlanilla(decimal planilla_id)
        {
            string where = PlanillasPagosDetallesService.PlanillaPagoId_NombreCol + "=" + planilla_id;
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANILLA_PAGO_DET_INFO_COMPLCollection.GetAsDataTable(where, PlanillasPagosDetallesService.CtaCteProveedorFechaVencimiento_NombreCol);
            }
        }
        #endregion GetPlanillaDetallesPorPlanilla

        #region VerificarRepeticion
        public bool EsRepetido(decimal planilla_id, decimal ctacteProveedorId)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    PLANILLA_PAGOS_DETALLESRow[] row = sesion.Db.PLANILLA_PAGOS_DETALLESCollection.GetByPLANILLA_PAGO_ID(planilla_id);
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i].CTACTE_PROVEEDOR_ID == ctacteProveedorId)
                        {
                            return true;
                        }
                    }
                    return false;

                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion VerificarRepeticion

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PLANILLA_PAGOS_DETALLESRow row = new PLANILLA_PAGOS_DETALLESRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("planilla_pagos_detalle_sqc");
                    }
                    else
                    {
                        row = sesion.Db.PLANILLA_PAGOS_DETALLESCollection.GetByPrimaryKey(decimal.Parse(campos[PlanillasPagosDetallesService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.CTACTE_PROVEEDOR_ID = decimal.Parse(campos[PlanillasPagosDetallesService.CtaCteProveedorId_NombreCol].ToString());
                    row.PLANILLA_PAGO_ID = decimal.Parse(campos[PlanillasPagosDetallesService.PlanillaPagoId_NombreCol].ToString());
                    row.MONTO_BRUTO = decimal.Parse(campos[PlanillasPagosDetallesService.MontoBruto_NombreCol].ToString());
                    DataTable dt = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(CuentaCorrienteProveedoresService.Id_NombreCol + " = " + row.CTACTE_PROVEEDOR_ID, string.Empty, sesion);

                    if (dt.Rows.Count > 0)
                    {
                        row.MONTO_PAGAR = (decimal)dt.Rows[0][CuentaCorrienteProveedoresService.VistaSaldoCredito_NombreCol];
                        row.CTACTE_PROV_CASO_ID = (decimal)dt.Rows[0][CuentaCorrienteProveedoresService.CasoId_NombreCol];
                    }

                    sesion.Db.PLANILLA_PAGOS_DETALLESCollection.Insert(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    PlanillasPagosService.ActualizarTotal(row.PLANILLA_PAGO_ID, CalcularTotalAPagarPorPlanilla(row.PLANILLA_PAGO_ID, sesion), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified detalle_plantilla_id.
        /// </summary>
        /// <param name="detalle_plantilla_id">The detalle_plantilla_id.</param>
        public void Borrar(decimal detalle_planilla_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                Borrar(detalle_planilla_id, sesion);
                sesion.CommitTransaction();
            }
        }

        public void Borrar(decimal detalle_planilla_id, SessionService sesion)
        {
            PLANILLA_PAGOS_DETALLESRow row = sesion.Db.PLANILLA_PAGOS_DETALLESCollection.GetByPrimaryKey(detalle_planilla_id);

            sesion.Db.PLANILLA_PAGOS_DETALLESCollection.DeleteByPrimaryKey(detalle_planilla_id);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

            PlanillasPagosService.ActualizarTotal(row.PLANILLA_PAGO_ID, CalcularTotalAPagarPorPlanilla(row.PLANILLA_PAGO_ID, sesion), sesion);
        }
        #endregion Borrar

        #region CalcularTotalPorPlanilla
        public decimal CalcularTotalAPagarPorPlanilla(decimal planilla_id, SessionService sesion)
        {
            try
            {
                PLANILLA_PAGOSRow pl = sesion.Db.PLANILLA_PAGOSCollection.GetByPrimaryKey(planilla_id);
                decimal cotizacionMonedaPlanilla = pl.COTIZACION_MONEDA;
                string where = PlanillasPagosDetallesService.PlanillaPagoId_NombreCol + " = " + planilla_id;
                PLANILLA_PAGO_DET_INFO_COMPLRow[] row = sesion.Db.PLANILLA_PAGO_DET_INFO_COMPLCollection.GetAsArray(where, PlanillasPagosDetallesService.Id_NombreCol);

                decimal total = 0;
                for (int i = 0; i < row.Length; i++)
                {
                    if (pl.MONEDA_ID == row[i].CTACTE_MONEDA_ID)
                    {
                        total += row[i].MONTO_PAGAR;
                    }
                    else
                    {
                        total += row[i].MONTO_PAGAR / row[i].CTACTE_MONEDA_COTIZACION * cotizacionMonedaPlanilla;
                    }

                }
                return total;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion CalcularTotalPorPlanilla

        #region ActualizarMontoPago
        public void ActualizarMontoPago(decimal id, decimal monto, SessionService sesion)
        {
            try
            {
                string valorAnterior = string.Empty;

                PLANILLA_PAGOS_DETALLESRow row = sesion.Db.PLANILLA_PAGOS_DETALLESCollection.GetByPrimaryKey(id);
                valorAnterior = row.ToString();
                row.MONTO_PAGAR = monto;

                sesion.Db.PLANILLA_PAGOS_DETALLESCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                PlanillasPagosService.ActualizarTotal(row.PLANILLA_PAGO_ID, CalcularTotalAPagarPorPlanilla(row.PLANILLA_PAGO_ID, sesion), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion ActualizarMontoPago

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "PLANILLA_PAGOS_DETALLES"; }
        }
        public static string Id_NombreCol
        {
            get { return PLANILLA_PAGOS_DETALLESCollection.IDColumnName; }
        }
        public static string PlanillaPagoId_NombreCol
        {
            get { return PLANILLA_PAGOS_DETALLESCollection.PLANILLA_PAGO_IDColumnName; }
        }
        public static string CtaCteProveedorId_NombreCol
        {
            get { return PLANILLA_PAGOS_DETALLESCollection.CTACTE_PROVEEDOR_IDColumnName; }
        }
        public static string OpCasoId_NombreCol
        {
            get { return PLANILLA_PAGOS_DETALLESCollection.OP_CASO_IDColumnName; }
        }
        public static string MontoAPagar_NombreCol
        {
            get { return PLANILLA_PAGOS_DETALLESCollection.MONTO_PAGARColumnName; }
        }
        public static string CtaCteProvCasoId_NombreCol
        {
            get { return PLANILLA_PAGOS_DETALLESCollection.CTACTE_PROV_CASO_IDColumnName; }
        }
        public static string MontoBruto_NombreCol
        {
            get { return PLANILLA_PAGOS_DETALLESCollection.MONTO_BRUTOColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string CtaCteProveedorFechaVencimiento_NombreCol
        {
            get { return PLANILLA_PAGO_DET_INFO_COMPLCollection.CTACTE_FECHA_VENCIMIENTOColumnName; }
        }

        public static string CtaCteProveedorMonedaId_NombreCol
        {
            get { return PLANILLA_PAGO_DET_INFO_COMPLCollection.CTACTE_MONEDA_IDColumnName; }
        }
        public static string CtaCteProveedorMonedaNombre_NombreCol
        {
            get { return PLANILLA_PAGO_DET_INFO_COMPLCollection.CTACTE_MONEDA_NOMBREColumnName; }
        }
        public static string CtaCteProveedorMonedaSimbolo_NombreCol
        {
            get { return PLANILLA_PAGO_DET_INFO_COMPLCollection.CTACTE_MONEDA_SIMBOLOColumnName; }
        }
        public static string CtaCteProveedorProveedorId_NombreCol
        {
            get { return PLANILLA_PAGO_DET_INFO_COMPLCollection.PROVEEDOR_IDColumnName; }
        }
        public static string CtaCteProveedorProveedorNombre_NombreCol
        {
            get { return PLANILLA_PAGO_DET_INFO_COMPLCollection.PROVEEDOR_NOMBREColumnName; }
        }
        public static string CtaCteProveedorSaldoCredito_NombreCol
        {
            get { return PLANILLA_PAGO_DET_INFO_COMPLCollection.SALDO_CTACTEColumnName; }
        }
        public static string CtaCteCasoId_NombreCol
        {
            get { return PLANILLA_PAGO_DET_INFO_COMPLCollection.CTACTE_CASO_IDColumnName; }
        }
        public static string CtaCteNroComprobante_NombreCol
        {
            get { return PLANILLA_PAGO_DET_INFO_COMPLCollection.CTACTE_NRO_COMPROBANTEColumnName; }
        }

        #endregion Vista
        #endregion Accessors
    }
}
