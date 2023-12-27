#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteRetencionesRecDetService
    {   
        #region GetCuentaCorrienteRetencionesRecibidasDataTable
        /// <summary>
        /// Gets the cuenta corriente retenciones recibidas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteRetencionesRecDetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteRetencionesRecDetDataTable(clausulas, orden, sesion);
            }
        }
        public static DataTable GetCuentaCorrienteRetencionesRecDetDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_RETENCIONES_REC_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrienteRetencionesRecDetDataTable

        #region GetCuentaCorrienteRetencionesRecDetInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente retenciones recibidas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteRetencionesRecDetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteRetencionesRecDetInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrienteRetencionesRecDetInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_RET_REC_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrienteRetencionesRecDetInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <returns></returns>
        public static decimal Guardar(Hashtable campos, SessionService sesion)
        {
            try
            {
                CTACTE_RETENCIONES_REC_DETRow row = new CTACTE_RETENCIONES_REC_DETRow();
                CuentaCorrienteRetencionesRecibidasService ctacteRetencion = new CuentaCorrienteRetencionesRecibidasService();
                string valorAnterior = string.Empty;

                if (campos.Contains(CuentaCorrienteRetencionesRecDetService.Id_NombreCol))
                {
                    row = sesion.Db.CTACTE_RETENCIONES_REC_DETCollection.GetByPrimaryKey((decimal)campos[CuentaCorrienteRetencionesRecDetService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }
                else
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_retenciones_rec_det_sqc");
                    row.CTACTE_RETENCION_RECIBIDA_ID = (decimal)campos[CuentaCorrienteRetencionesRecDetService.CtacteRetencionRecibidaId_NombreCol];
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }

                //Si cambia
                if (row.CASO_ID.Equals(DBNull.Value) || row.CASO_ID != (decimal)campos[CuentaCorrienteRetencionesRecDetService.CasoId_NombreCol])
                {
                    row.CASO_ID = (decimal)campos[CuentaCorrienteRetencionesRecDetService.CasoId_NombreCol];
                    row.FLUJO_ID = CasosService.GetFlujo(row.CASO_ID, sesion);
                }

                row.MONTO = (decimal)campos[CuentaCorrienteRetencionesRecDetService.Monto_NombreCol];
                row.TIPO_ID = (decimal)campos[CuentaCorrienteRetencionesRecDetService.TipoId_NombreCol];

                if (campos.Contains(CuentaCorrienteRetencionesRecDetService.Id_NombreCol))
                    sesion.Db.CTACTE_RETENCIONES_REC_DETCollection.Update(row);
                else 
                    sesion.Db.CTACTE_RETENCIONES_REC_DETCollection.Insert(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                CuentaCorrienteRetencionesRecibidasService.ActualizarTotal(row.CTACTE_RETENCION_RECIBIDA_ID, sesion);

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
        /// Borrars the specified ctacte_retencion_rec_det_id.
        /// </summary>
        /// <param name="ctacte_retencion_rec_det_id">The ctacte_retencion_rec_det_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal ctacte_retencion_rec_det_id, SessionService sesion)
        {
            try
            {
                sesion.Db.CTACTE_RETENCIONES_REC_DETCollection.Delete(CuentaCorrienteRetencionesRecDetService.Id_NombreCol + " = " + ctacte_retencion_rec_det_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_RETENCIONES_REC_DET"; }
        }
        public static string CasoId_NombreCol
        {
            get { return CTACTE_RETENCIONES_REC_DETCollection.CASO_IDColumnName; }
        }
        public static string CtacteRetencionRecibidaId_NombreCol
        {
            get { return CTACTE_RETENCIONES_REC_DETCollection.CTACTE_RETENCION_RECIBIDA_IDColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return CTACTE_RETENCIONES_REC_DETCollection.FLUJO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_RETENCIONES_REC_DETCollection.IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_RETENCIONES_REC_DETCollection.MONTOColumnName; }
        }
        public static string TipoId_NombreCol
        {
            get { return CTACTE_RETENCIONES_REC_DETCollection.TIPO_IDColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return CTACTE_RET_REC_DET_INFO_COMPLCollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaTipoNombre_NombreCol
        {
            get { return CTACTE_RET_REC_DET_INFO_COMPLCollection.TIPO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
