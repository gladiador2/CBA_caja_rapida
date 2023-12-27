#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.ToolbarFlujo;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class TransferenciaCajasSucursalDetalleService
    {
        #region GetTransCajasSucDetalleInfoCompleta
        public static DataTable GetTransCajasSucDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTransCajasSucDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetTransCajasSucDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.TRANSF_CAJ_SUC_DET_INF_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetTransCajasSucDetalleInfoCompleta

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Guardar(campos, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                { throw; }
            }

        }
        

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
                try
                {
                    TRANSFERENCIA_CAJAS_SUC_DETRow row = new TRANSFERENCIA_CAJAS_SUC_DETRow();
                    if (!campos.Contains(Id_NombreCol))
                        row.ID = sesion.Db.GetSiguienteSecuencia("TRANSF_CAJAS_SUC_DET_SQC");
                    else
                        row = sesion.Db.TRANSFERENCIA_CAJAS_SUC_DETCollection.GetByPrimaryKey(decimal.Parse(campos[RendicionCobradorDetalleService.Id_NombreCol].ToString()));

                    if (campos.Contains(TransfCajaSucId_NombreCol))
                        row.TRANS_CAJAS_SUC_ID = (decimal)campos[TransferenciaCajasSucursalDetalleService.TransfCajaSucId_NombreCol];
                    
                    if (campos.Contains(MonedaId_NombreCol))
                        row.MONEDA_ID = (decimal)campos[TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol];

                    if (campos.Contains(Monto_NombreCol))
                        row.MONTO = (decimal)campos[TransferenciaCajasSucursalDetalleService.Monto_NombreCol];

                    if (campos.Contains(CtaCteValorId_NombreCol))
                        row.CTACTE_VALOR_ID = (decimal)campos[TransferenciaCajasSucursalDetalleService.CtaCteValorId_NombreCol];

                    if (campos.Contains(CtaCteChqRecId_NombreCol))
                        row.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)campos[TransferenciaCajasSucursalDetalleService.CtaCteChqRecId_NombreCol];

                    if(campos.Contains(CotizacionMoneda_NombreCol))
                        row.COTIZACION_MONEDA = (decimal)campos[CotizacionMoneda_NombreCol];

                    if (campos.Contains(Id_NombreCol))
                        sesion.Db.TRANSFERENCIA_CAJAS_SUC_DETCollection.Update(row);
                    else
                        sesion.Db.TRANSFERENCIA_CAJAS_SUC_DETCollection.Insert(row);
                }
                catch (Exception exp)
                {                    
                    sesion.Db.RollbackTransaction();
                    throw new Exception("Error al guardar el detalle de la transferencia");
                }
            
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal transf_cajas_suc_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRANSFERENCIA_CAJAS_SUC_DETRow row = sesion.Db.TRANSFERENCIA_CAJAS_SUC_DETCollection.GetByPrimaryKey(transf_cajas_suc_detalle_id);

                    sesion.Db.TRANSFERENCIA_CAJAS_SUC_DETCollection.DeleteByPrimaryKey(transf_cajas_suc_detalle_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar        
        
        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "TRANSFERENCIA_CAJAS_SUC_DET"; }
        }
        public static string Id_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_DETCollection.IDColumnName; }
        }
        public static string TransfCajaSucId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_DETCollection.TRANS_CAJAS_SUC_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_DETCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_DETCollection.MONTOColumnName; }
        }

        public static string CotizacionMoneda_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_DETCollection.COTIZACION_MONEDAColumnName; }
        }

        public static string CtaCteValorId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_DETCollection.CTACTE_VALOR_IDColumnName; }
        }

        public static string CtaCteChqRecId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        #endregion Tabla
      
        #region Vista
        public static string MonedaNombre_NombreCol
        {
            get { return TRANSF_CAJ_SUC_DET_INF_CCollection.MONEDA_NOMBREColumnName; }
        }

        public static string MonedaSimbolo_NombreCol
        {
            get { return TRANSF_CAJ_SUC_DET_INF_CCollection.SIMBOLOColumnName; }
        }

        public static string MonedaCantidadDecimales_NombreCol
        {
            get { return TRANSF_CAJ_SUC_DET_INF_CCollection.CANTIDADES_DECIMALESColumnName; }
        }

        public static string NombreValor_NombreCol
        {
            get { return TRANSF_CAJ_SUC_DET_INF_CCollection.NOMBREColumnName; }
        }

        public static string NumeroCheque_NombreCol
        {
            get { return TRANSF_CAJ_SUC_DET_INF_CCollection.NUMERO_CHEQUEColumnName; }
        }

        public static string NombreEmisor_NombreCol
        {
            get { return TRANSF_CAJ_SUC_DET_INF_CCollection.NOMBRE_EMISORColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}




