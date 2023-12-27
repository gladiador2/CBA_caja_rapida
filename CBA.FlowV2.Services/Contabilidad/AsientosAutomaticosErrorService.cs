#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Contabilidad;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class AsientosAutomaticosErrorService
    {
        #region RegistrarError
        public static void RegistrarError(decimal ctb_asiento_automatico_id, CTB_ASIENTOS_DETALLERow ctb_asiento_detalle_row, string motivo_error)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_ASIENTOS_AUTOMATICOS_ERRORRow row = new CTB_ASIENTOS_AUTOMATICOS_ERRORRow();

                    row.COTIZACION_MONEDA = ctb_asiento_detalle_row.COTIZACION_MONEDA;

                    if (!ctb_asiento_detalle_row.IsCOTIZACION_MONEDA_ORIGENNull)
                        row.COTIZACION_MONEDA_ORIGEN = ctb_asiento_detalle_row.COTIZACION_MONEDA_ORIGEN;

                    row.CTB_ASIENTO_AUTOMATICO_ID = ctb_asiento_automatico_id;

                    if(!ctb_asiento_detalle_row.CTB_CUENTA_ID.Equals(DBNull.Value))
                        row.CTB_CUENTA_ID = ctb_asiento_detalle_row.CTB_CUENTA_ID;

                    if (!ctb_asiento_detalle_row.DEBE.Equals(DBNull.Value))
                        row.DEBE = ctb_asiento_detalle_row.DEBE;

                    if (!ctb_asiento_detalle_row.IsDEBE_ORIGENNull)
                        row.DEBE_ORIGEN = ctb_asiento_detalle_row.DEBE_ORIGEN;

                    if (!ctb_asiento_detalle_row.FECHA.Equals(DBNull.Value))
                        row.FECHA = ctb_asiento_detalle_row.FECHA;

                    if (!ctb_asiento_detalle_row.HABER.Equals(DBNull.Value))
                        row.HABER = ctb_asiento_detalle_row.HABER;

                    if (!ctb_asiento_detalle_row.IsHABER_ORIGENNull)
                        row.HABER_ORIGEN = ctb_asiento_detalle_row.HABER_ORIGEN;

                    row.ID = sesion.Db.GetSiguienteSecuencia("ctb_asientos_autom_error_sqc");

                    if (!ctb_asiento_detalle_row.MONEDA_ID.Equals(DBNull.Value))
                        row.MONEDA_ID = ctb_asiento_detalle_row.MONEDA_ID;

                    if (!ctb_asiento_detalle_row.IsMONEDA_ORIGEN_IDNull)
                        row.MONEDA_ORIGEN_ID = ctb_asiento_detalle_row.MONEDA_ORIGEN_ID;

                    row.MOTIVO_ERROR = motivo_error;

                    if (!ctb_asiento_detalle_row.OBSERVACION_SISTEMA.Equals(DBNull.Value))
                        row.OBSERVACION_SISTEMA = ctb_asiento_detalle_row.OBSERVACION_SISTEMA;

                    if (!ctb_asiento_detalle_row.IsORDENNull)
                        row.ORDEN = ctb_asiento_detalle_row.ORDEN;

                    row.REVISADO = Definiciones.SiNo.No;

                    sesion.Db.CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion CrearAsientos

        #region SetRevisado
        /// <summary>
        /// Sets the revisado.
        /// </summary>
        /// <param name="ctb_asiento_automatico_error_id">The ctb_asiento_automatico_error_id.</param>
        public void SetRevisado(decimal ctb_asiento_automatico_error_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_ASIENTOS_AUTOMATICOS_ERRORRow row = sesion.Db.CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.GetByPrimaryKey(ctb_asiento_automatico_error_id);
                string valorAnterior = row.ToString();

                row.REVISADO = Definiciones.SiNo.Si;
                row.USUARIO_REVISADO_ID = sesion.Usuario.ID;
                row.FECHA_REVISADO = DateTime.Now;

                sesion.Db.CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion GetAsientosAutomaticosDataTable

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "CTB_ASIENTOS_AUTOMATICOS_ERROR"; } 
        }
        public static string CotizacionMonedaOrigen_NombreCol
        { 
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.COTIZACION_MONEDA_ORIGENColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtbAsientoAutomaticoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.CTB_ASIENTO_AUTOMATICO_IDColumnName; }
        }
        public static string CtbCuentaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.CTB_CUENTA_IDColumnName; }
        }
        public static string DebeOrigen_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.DEBE_ORIGENColumnName; }
        }
        public static string Debe_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.DEBEColumnName; }
        }
        public static string FechaRevisado_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.FECHA_REVISADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.FECHAColumnName; }
        }
        public static string HaberOrigen_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.HABER_ORIGENColumnName; }
        }
        public static string Haber_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.HABERColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.MONEDA_IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MotivoError_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.MOTIVO_ERRORColumnName; }
        }
        public static string ObservacionSistema_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.OBSERVACION_SISTEMAColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.ORDENColumnName; }
        }
        public static string Revisado_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.REVISADOColumnName; }
        }
        public static string UsuarioRevisadoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTOMATICOS_ERRORCollection.USUARIO_REVISADO_IDColumnName; }
        }
        #endregion Accesors
    }
}
