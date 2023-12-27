#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
   public class IndicadoresDetalleService
   {
        #region GetIndicadoresDetalleDataTable

       /// <summary>
       /// Gets the indicadores detalle data table.
       /// </summary>
       /// <param name="clausulas">The clausulas.</param>
       /// <param name="orden">The orden.</param>
       /// <returns></returns>
        public DataTable GetIndicadoresDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_INDICADORES_DETALLECollection.GetAsDataTable(clausulas, orden);               
            }
        }
        #endregion GetIndicadoresDetalleDataTable

        #region GetIndicadoresDetalleInfoCompleta

        /// <summary>
        /// Gets the indicadores detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetIndicadoresDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_INDICADORES_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetIndicadoresDetalleInfoCompleta

        #region Borrar

        /// <summary>
        /// Borrars the specified indicador_detalle_id.
        /// </summary>
        /// <param name="indicador_detalle_id">The indicador_detalle_id.</param>
        public void Borrar(decimal indicador_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_INDICADORES_DETALLERow row;
                IndicadoresDetalleService indicadorDetalle = new IndicadoresDetalleService();
               
                row = sesion.Db.CTB_INDICADORES_DETALLECollection.GetByPrimaryKey(indicador_detalle_id);

                sesion.Db.CTB_INDICADORES_DETALLECollection.DeleteByPrimaryKey(indicador_detalle_id);
                
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
        }
        #endregion borrar
       
        #region Guardar

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_INDICADORES_DETALLERow row = new CTB_INDICADORES_DETALLERow();
                    
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctb_indicadores_detalle_sqc");
                    }
                    else
                    {
                        row = sesion.Db.CTB_INDICADORES_DETALLECollection.GetByPrimaryKey((decimal)campos[IndicadoresDetalleService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.CTB_INDICADOR_ID = (decimal)campos[IndicadoresDetalleService.CtbIndicadorId_NombreCol];

                    if (campos.Contains(IndicadoresDetalleService.CtbCuentaId_NombreCol))
                        row.CTB_CUENTA = (decimal)campos[IndicadoresDetalleService.CtbCuentaId_NombreCol];

                    if (campos.Contains(IndicadoresDetalleService.CtbIndicadoresDetalle1_NombreCol))
                        row.CTB_INDICADORES_DETALLE_1 = (decimal)campos[IndicadoresDetalleService.CtbIndicadoresDetalle1_NombreCol];

                    if (campos.Contains(IndicadoresDetalleService.CtbIndicadoresDetalle2_NombreCol))
                        row.CTB_INDICADORES_DETALLE_2 = (decimal)campos[IndicadoresDetalleService.CtbIndicadoresDetalle2_NombreCol];

                    if (campos.Contains(IndicadoresDetalleService.CtbIndicadoresDetallePadre_NombreCol))
                        row.CTB_INDICADORES_DETALLE_PADRE = (decimal)campos[IndicadoresDetalleService.CtbIndicadoresDetallePadre_NombreCol];

                    if (campos.Contains(IndicadoresDetalleService.Operacion_NombreCol))
                        row.OPERACION = (decimal)campos[IndicadoresDetalleService.Operacion_NombreCol];

                    if (insertarNuevo) sesion.Db.CTB_INDICADORES_DETALLECollection.Insert(row);
                    else sesion.Db.CTB_INDICADORES_DETALLECollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exc)
                {
                    sesion.Db.RollbackTransaction();
                    throw exc;
                }
            }
        }
        #endregion Guardar

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "CTB_INDICADORES_DETALLE"; }
        }

        public static string CtbCuentaId_NombreCol
        {
            get { return CTB_INDICADORES_DETALLECollection.CTB_CUENTAColumnName; }
        }

        public static string CtbIndicadorId_NombreCol
        {
            get { return CTB_INDICADORES_DETALLECollection.CTB_INDICADOR_IDColumnName; }
        }

        public static string CtbIndicadoresDetalle1_NombreCol
        {
            get { return CTB_INDICADORES_DETALLECollection.CTB_INDICADORES_DETALLE_1ColumnName; }
        }

        public static string CtbIndicadoresDetalle2_NombreCol
        {
            get { return CTB_INDICADORES_DETALLECollection.CTB_INDICADORES_DETALLE_2ColumnName; }
        }

        public static string CtbIndicadoresDetallePadre_NombreCol
        {
            get { return CTB_INDICADORES_DETALLECollection.CTB_INDICADORES_DETALLE_PADREColumnName; }
        }

        public static string Id_NombreCol
        {
            get { return CTB_INDICADORES_DETALLECollection.IDColumnName; }
        }

        public static string Operacion_NombreCol
        {
            get { return CTB_INDICADORES_DETALLECollection.OPERACIONColumnName; }
        }

        public static string VistaCtbCuentaNombre_NombreCol
        {
            get { return CTB_INDICADORES_DET_INFO_COMPLCollection.CTB_CUENTA_NOMBREColumnName; }
        }

        public static string VistaCtbIndicadorNombre_NombreCol
        {
            get { return CTB_INDICADORES_DET_INFO_COMPLCollection.CTB_INDICADOR_NOMBREColumnName; }
        }

        public static string VistaOperacionNombre_NombreCol
        {
            get { return CTB_INDICADORES_DET_INFO_COMPLCollection.OPERACION_NOMBREColumnName; }
        }
        
        public static string VistaOperacionSimbolo_NombreCol
        {
            get { return CTB_INDICADORES_DET_INFO_COMPLCollection.OPERACION_SIMBOLOColumnName; }
        }

        #endregion Accessors
    }
}
