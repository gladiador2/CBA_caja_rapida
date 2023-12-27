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
    public class CustodiaValoresDetalleSalidaService
    {
        #region GetCustodiaValoresDetalleSalidaDataTable
        /// <summary>
        /// Gets the cuenta corriente pagos persona compensacion salida data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCustodiaValoresDetalleSalidaDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCustodiaValoresDetalleSalidaDataTable(clausulas, orden, sesion);
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
        public static DataTable GetCustodiaValoresDetalleSalidaDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = CustodiaValoresDetalleSalidaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CUSTODIA_VALORES_DET_SALIDACollection.GetAsDataTable(where, orden);
        }
        #endregion GetCustodiaValoresDetalleSalidaDataTable

        #region GetCustodiaValoresDetalleSalidaInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente pagos persona compensacion salida information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCustodiaValoresDetalleSalidaInfoCompleta(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCustodiaValoresDetalleSalidaInfoCompleta(clausulas, orden, sesion);
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
        public static DataTable GetCustodiaValoresDetalleSalidaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = CustodiaValoresDetalleSalidaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CUSTODIA_VALORES_DET_SAL_IN_CCollection.GetAsDataTable(where, orden);
        }
        #endregion GetCustodiaValoresDetalleSalidaInfoCompleta

        #region GetTotal
        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <param name="custodia_valores_id">The custodia_valores_id.</param>
        /// <returns></returns>
        public static decimal GetTotal(decimal custodia_valores_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CustodiaValoresDetalleSalidaService.CustodiaValorId_NombreCol + " = " + custodia_valores_id + " and " +
                                   CustodiaValoresDetalleSalidaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                DataTable dtDetalles = GetCustodiaValoresDetalleSalidaInfoCompleta(clausulas, string.Empty);
                DataTable dtCabecera = CustodiaValoresService.GetCustodiaValoresDataTable(CustodiaValoresService.Id_NombreCol + " = " + custodia_valores_id, string.Empty);
                decimal total = 0;
                decimal monedaCabeceraId = (decimal)dtCabecera.Rows[0][CustodiaValoresService.MonedaId_NombreCol];
                decimal cotizacionPago = (decimal)dtCabecera.Rows[0][CustodiaValoresService.CotizacionMoneda_NombreCol];

                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    if (monedaCabeceraId == (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleSalidaService.VistaMonedaId_NombreCol])
                    {
                        total += (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleSalidaService.VistaMonto_NombreCol];
                    }
                    else
                    {
                        total += (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleSalidaService.VistaMonto_NombreCol]
                                 / (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleSalidaService.VistaCotizacionMoneda_NombreCol]
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
        public static void Guardar(decimal custodia_valor_det_id)
        {
            CUSTODIA_VALORES_DET_SALIDARow row;
            using (SessionService sesion = new SessionService())
            {
                #region Validaciones
                DataTable dtDetalle = CustodiaValoresDetalleService.GetCustodiaValoresDetalleDataTable(CustodiaValoresDetalleService.Id_NombreCol + " = " + custodia_valor_det_id, string.Empty);
                
                if (!dtDetalle.Rows[0][CustodiaValoresDetalleService.Estado_NombreCol].Equals(Definiciones.Estado.Activo))
                    throw new Exception("El detalle debe estar activo.");

                if (!dtDetalle.Rows[0][CustodiaValoresDetalleService.ValorRetirado_NombreCol].Equals(Definiciones.SiNo.No))
                    throw new Exception("El detalle no debe haber sido retirado.");
                #endregion Validaciones

                row = new CUSTODIA_VALORES_DET_SALIDARow();
                row.ID = sesion.Db.GetSiguienteSecuencia("custodia_valores_det_sal_sqc");
                row.FECHA = DateTime.Now;
                row.CUSTODIA_VALOR_DET_ID = custodia_valor_det_id;
                row.CUSTODIA_VALOR_ID = (decimal)dtDetalle.Rows[0][CustodiaValoresDetalleService.CustodiaValorId_NombreCol];
                row.ESTADO = Definiciones.Estado.Activo;
                sesion.Db.CUSTODIA_VALORES_DET_SALIDACollection.Insert(row);
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified custodia_valores_det_id.
        /// </summary>
        /// <param name="custodia_valores_det_id">The custodia_valores_det_id.</param>
        public static void Borrar(decimal custodia_valores_det_id)
        {
            CUSTODIA_VALORES_DET_SALIDARow[] rows;
            using (SessionService sesion = new SessionService())
            {
                //Borrar solo las activas, ya que las inactivas son parte de compensaciones anteriores
                string clausulas = CustodiaValoresDetalleSalidaService.CustodiaValorDetId_NombreCol + " = " + custodia_valores_det_id + " and " +
                                   CustodiaValoresDetalleSalidaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                rows = sesion.Db.CUSTODIA_VALORES_DET_SALIDACollection.GetAsArray(clausulas, string.Empty);

                for (int i = 0; i < rows.Length; i++)
                {
                    sesion.Db.CUSTODIA_VALORES_DET_SALIDACollection.DeleteByPrimaryKey(rows[i].ID);
                }
            }
        }
        #endregion Borrar

        #region ConfirmarCanje
        /// <summary>
        /// Confirmars the canje.
        /// </summary>
        /// <param name="custodia_valor_id">The custodia_valor_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ConfirmarCanje(decimal custodia_valor_id, SessionService sesion)
        {
            try
            {
                CUSTODIA_VALORES_DET_SALIDARow[] rows = sesion.db.CUSTODIA_VALORES_DET_SALIDACollection.GetByCUSTODIA_VALOR_ID(custodia_valor_id);

                //Desactivar los datalles que salen y los datos del canje
                for (int i = 0; i < rows.Length; i++)
                {
                    CustodiaValoresDetalleService.SetEstado(rows[i].CUSTODIA_VALOR_DET_ID, Definiciones.Estado.Inactivo, sesion);
                    rows[i].ESTADO = Definiciones.Estado.Inactivo;
                    sesion.db.CUSTODIA_VALORES_DET_SALIDACollection.Update(rows[i]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion ConfirmarCanje

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CUSTODIA_VALORES_DET_SALIDA"; }
        }
        public static string Nombre_Vista
        {
            get { return "CUSTODIA_VALORES_DET_SAL_IN_C"; }
        }
        public static string CustodiaValorDetId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_SALIDACollection.CUSTODIA_VALOR_DET_IDColumnName; }
        }
        public static string CustodiaValorId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_SALIDACollection.CUSTODIA_VALOR_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_SALIDACollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_SALIDACollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_SALIDACollection.IDColumnName; }
        }
        public static string VistaCotizacionMoneda_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_SAL_IN_CCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_SAL_IN_CCollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonto_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_SAL_IN_CCollection.MONTOColumnName; }
        }
        #endregion Accessors
    }
}
