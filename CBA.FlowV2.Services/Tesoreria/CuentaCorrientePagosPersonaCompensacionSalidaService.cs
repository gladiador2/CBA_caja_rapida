#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Common;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePagosPersonaCompensacionSalidaService
    {
        #region GetCuentaCorrientePagosPersonaCompensacionSalidaDataTable
        /// <summary>
        /// Gets the cuenta corriente pagos persona compensacion salida data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaCompensacionSalidaDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCuentaCorrientePagosPersonaCompensacionSalidaDataTable(clausulas, orden, sesion);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Gets the cuenta corriente pagos persona compensacion salida data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaCompensacionSalidaDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = CuentaCorrientePagosPersonaCompensacionSalidaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CTACTE_PAGOS_PER_COMPEN_SALIDACollection.GetAsDataTable(where, orden);
        }
        #endregion GetCuentaCorrientePagosPersonaCompensacionSalidaDataTable

        #region GetCuentaCorrientePagosPersonaCompensacionSalidaInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente pagos persona compensacion salida information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaCompensacionSalidaInfoCompleta(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCuentaCorrientePagosPersonaCompensacionSalidaInfoCompleta(clausulas, orden, sesion);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Gets the cuenta corriente pagos persona compensacion salida information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaCompensacionSalidaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = CuentaCorrientePagosPersonaCompensacionSalidaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CTACTE_PAGOS_PER_COMP_SAL_IN_CCollection.GetAsDataTable(where, orden);
        }
        #endregion GetCuentaCorrientePagosPersonaCompensacionSalidaDataTable

        #region GetTotal
        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <returns></returns>
        public static decimal GetTotal(decimal ctacte_pago_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CuentaCorrientePagosPersonaCompensacionSalidaService.CtactePagoPersonaId_NombreCol + " = " + ctacte_pago_persona_id + " and " +
                                   CuentaCorrientePagosPersonaCompensacionSalidaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                DataTable dtDetallesCompensacion = GetCuentaCorrientePagosPersonaCompensacionSalidaInfoCompleta(clausulas, string.Empty);
                DataTable dtPago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pago_persona_id, string.Empty);
                decimal total = 0;
                decimal monedaPagoId = (decimal)dtPago.Rows[0][PagosDePersonaService.MonedaId_NombreCol];
                decimal cotizacionPago = (decimal)dtPago.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                for (int i = 0; i < dtDetallesCompensacion.Rows.Count; i++)
                {
                    if (monedaPagoId == (decimal)dtDetallesCompensacion.Rows[i][CuentaCorrientePagosPersonaCompensacionSalidaService.VistaMonedaId_NombreCol])
                    {
                        total += (decimal)dtDetallesCompensacion.Rows[i][CuentaCorrientePagosPersonaCompensacionSalidaService.VistaMonto_NombreCol];
                    }
                    else
                    {
                        total += (decimal)dtDetallesCompensacion.Rows[i][CuentaCorrientePagosPersonaCompensacionSalidaService.VistaMonto_NombreCol]
                                 / (decimal)dtDetallesCompensacion.Rows[i][CuentaCorrientePagosPersonaCompensacionSalidaService.VistaCotizacionMoneda_NombreCol]
                                 * cotizacionPago;
                    }
                }

                return total;
            }
        }
        #endregion GetTotal

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="ctacte_pago_persona_documento_id">The ctacte_pago_persona_documento_id.</param>
        public static void Guardar(decimal ctacte_pago_persona_documento_id)
        {
            CTACTE_PAGOS_PER_COMPEN_SALIDARow row;
            using (SessionService sesion = new SessionService())
            {
                #region Validaciones
                DataTable dtPagoPersonaDoc = CuentaCorrientePagosPersonaDocumentoService.GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol + " = " + ctacte_pago_persona_documento_id, string.Empty, sesion);

                //No puede quitarse si es un recargo que ya fue facturado
                if (!Interprete.EsNullODBNull(dtPagoPersonaDoc.Rows[0][CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol]))
                {
                    DataTable dtRecargos = CuentaCorrienteRecargosService.GetCtacteRecargosDataTable(CuentaCorrienteRecargosService.CtactePagoPersonaDocId_NombreCol + " = " + dtPagoPersonaDoc.Rows[0][CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol], string.Empty);
                    if (!Interprete.EsNullODBNull(dtRecargos.Rows[0][CuentaCorrienteRecargosService.CasoFacturaId_NombreCol]))
                        throw new Exception("No puede descompensarse el pago de recargos.");
                }
                #endregion Validaciones

                row = new CTACTE_PAGOS_PER_COMPEN_SALIDARow();
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_pagos_per_comp_sal_sqc");
                row.FECHA_CREACION = DateTime.Now;
                row.CTACTE_PAGOS_PERSONA_DOC_ID = ctacte_pago_persona_documento_id;
                row.CTACTE_PAGOS_PERSONA_ID = (decimal)dtPagoPersonaDoc.Rows[0][CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol];
                row.ESTADO = Definiciones.Estado.Activo;
                sesion.Db.CTACTE_PAGOS_PER_COMPEN_SALIDACollection.Insert(row);
            }

            PagosDePersonaService.ActualizarCompensacionAnticipoPorVuelto(row.CTACTE_PAGOS_PERSONA_ID);
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_pago_persona_documento_id.
        /// </summary>
        /// <param name="ctacte_pago_persona_documento_id">The ctacte_pago_persona_documento_id.</param>
        public static void Borrar(decimal ctacte_pago_persona_documento_id)
        {
            CTACTE_PAGOS_PER_COMPEN_SALIDARow[] rows;
            using (SessionService sesion = new SessionService())
            {
                //Borrar solo las activas, ya que las inactivas son parte de compensaciones anteriores
                string clausulas = CuentaCorrientePagosPersonaCompensacionSalidaService.CtactePagoPersonaDocId_NombreCol + " = " + ctacte_pago_persona_documento_id + " and " +
                                   CuentaCorrientePagosPersonaCompensacionSalidaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                rows = sesion.Db.CTACTE_PAGOS_PER_COMPEN_SALIDACollection.GetAsArray(clausulas, string.Empty);

                for (int i = 0; i < rows.Length; i++)
                {
                    sesion.Db.CTACTE_PAGOS_PER_COMPEN_SALIDACollection.DeleteByPrimaryKey(rows[i].ID);
                }
            }

            if(rows.Length > 0)
                PagosDePersonaService.ActualizarCompensacionAnticipoPorVuelto(rows[0].CTACTE_PAGOS_PERSONA_ID);
        }
        #endregion Borrar

        #region Inactivar
        /// <summary>
        /// Inactivars the specified ctacte_pago_persona_compensacion_salida_id.
        /// </summary>
        /// <param name="ctacte_pago_persona_compensacion_salida_id">The ctacte_pago_persona_compensacion_salida_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Inactivar(decimal ctacte_pago_persona_compensacion_salida_id, SessionService sesion)
        {
            CTACTE_PAGOS_PER_COMPEN_SALIDARow row = sesion.Db.CTACTE_PAGOS_PER_COMPEN_SALIDACollection.GetByPrimaryKey(ctacte_pago_persona_compensacion_salida_id);
            row.ESTADO = Definiciones.Estado.Inactivo;
            sesion.Db.CTACTE_PAGOS_PER_COMPEN_SALIDACollection.Update(row);
        }
        #endregion Inactivar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PAGOS_PER_COMPEN_SALIDA"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTACTE_PAGOS_PER_COMP_SAL_IN_C"; }
        }
        public static string CtactePagoPersonaDocId_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_SALIDACollection.CTACTE_PAGOS_PERSONA_DOC_IDColumnName; }
        }
        public static string CtactePagoPersonaId_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_SALIDACollection.CTACTE_PAGOS_PERSONA_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_SALIDACollection.ESTADOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_SALIDACollection.FECHA_CREACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_SALIDACollection.IDColumnName; }
        }
        public static string VistaCotizacionMoneda_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_SAL_IN_CCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_SAL_IN_CCollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonto_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_SAL_IN_CCollection.MONTOColumnName; }
        }
        #endregion Accessors
    }
}
