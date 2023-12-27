#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoProveedor;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteRetencionesEmitidasDetalleService
    {
        #region GetCuentaCorrienteRetencionesEmitidasDetalleDataTable
        /// <summary>
        /// Gets the cuenta corriente retenciones emitidas detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteRetencionesEmitidasDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetCuentaCorrienteRetencionesEmitidasDetalleDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }

        #endregion GetCuentaCorrienteRetencionesEmitidasDetalleDataTable

        #region GetCuentaCorrienteRetencionesEmitidasDetalleInfoCompleta

        /// <summary>
        /// Gets the cuenta corriente retenciones recibidas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteRetencionesEmitidasDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_RETENC_EMIT_DET_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrienteRetencionesEmitidasDetalleInfoCompleta

        #region ActualizarDatosRetencion
        public static void ActualizarDatosRetencion(decimal retencionIdAnterior, decimal retencionIdNuevo, SessionService sesion)
        {
            try
            {
                CTACTE_RETENCIONES_EMIT_DETRow[] rowAnterior = sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.GetAsArray(CtacteRetencionEmitidaId_NombreCol + " = " + retencionIdAnterior, string.Empty);
                CTACTE_RETENCIONES_EMIT_DETRow[] rowNuevo = rowAnterior;

                //Insertar Valores con el Nuevo ID
                for (int i = 0; i < rowNuevo.Length; i++)
                {
                    rowNuevo[i].ID = sesion.Db.GetSiguienteSecuencia("ctacte_retenciones_emi_det_sqc");
                    rowNuevo[i].CTACTE_RETENCION_EMITIDA_ID = retencionIdNuevo;
                    sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.Insert(rowNuevo[i]);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion ActualizarDatosRetencion

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public decimal Guardar(Hashtable campos, SessionService sesion)
        {
            try
            {
                CTACTE_RETENCIONES_EMIT_DETRow row = new CTACTE_RETENCIONES_EMIT_DETRow();
                CuentaCorrienteRetencionesEmitidasService ctacteRetencion = new CuentaCorrienteRetencionesEmitidasService();
                string valorAnterior = string.Empty;

                if (campos.Contains(CuentaCorrienteRetencionesEmitidasDetalleService.Id_NombreCol))
                {
                    row = sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.GetByPrimaryKey((decimal)campos[CuentaCorrienteRetencionesEmitidasDetalleService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }
                else
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_retenciones_emi_det_sqc");
                    row.CTACTE_RETENCION_EMITIDA_ID = (decimal)campos[CuentaCorrienteRetencionesEmitidasDetalleService.CtacteRetencionEmitidaId_NombreCol];
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }

                //Si cambia
                row.CASO_ID = (decimal)campos[CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol];
                row.MONTO = (decimal)campos[CuentaCorrienteRetencionesEmitidasDetalleService.Monto_NombreCol];
                row.RETENCION_TIPO_ID = (decimal)campos[CuentaCorrienteRetencionesEmitidasDetalleService.RetencionTipoId_NombreCol];

                if (campos.Contains(CuentaCorrienteRetencionesEmitidasDetalleService.Id_NombreCol))
                    sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.Update(row);
                else
                    sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.Insert(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                CuentaCorrienteRetencionesEmitidasService.ActualizarTotal(row.CTACTE_RETENCION_EMITIDA_ID, sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_retencion_emitida_detalle_id.
        /// </summary>
        /// <param name="ctacte_retencion_emitida_detalle_id">The ctacte_retencion_emitida_detalle_id.</param>
        public void Borrar(decimal ctacte_retencion_emitida_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CTACTE_RETENCIONES_EMIT_DETRow row = sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.GetByPrimaryKey(ctacte_retencion_emitida_detalle_id);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CTACTE_RETENCIONES_EMIT_DETCollection.Delete(row);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "CTACTE_RETENCIONES_EMIT_DET"; }
        }
        public static string CasoId_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMIT_DETCollection.CASO_IDColumnName; }
        }
        public static string CtacteRetencionEmitidaId_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMIT_DETCollection.CTACTE_RETENCION_EMITIDA_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMIT_DETCollection.IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMIT_DETCollection.MONTOColumnName; }
        }
        public static string RetencionTipoId_NombreCol
        {
            get { return CTACTE_RETENCIONES_EMIT_DETCollection.RETENCION_TIPO_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_DET_INFO_CCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoNroComprobante_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_DET_INFO_CCollection.CASO_NRO_COMPROBANTEColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_DET_INFO_CCollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_DET_INFO_CCollection.FLUJO_IDColumnName; }
        }
        public static string VistaRetencionTipoNombre_NombreCol
        {
            get { return CTACTE_RETENC_EMIT_DET_INFO_CCollection.RETENCION_TIPO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
