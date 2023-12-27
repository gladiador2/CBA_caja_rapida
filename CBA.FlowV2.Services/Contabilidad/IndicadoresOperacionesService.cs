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
   public class IndicadoresOperacionesService
   {
        #region GetIndicadoresOperacionesDataTable

       /// <summary>
       /// Gets the indicadores operaciones data table.
       /// </summary>
       /// <param name="clausulas">The clausulas.</param>
       /// <param name="orden">The orden.</param>
       /// <returns></returns>
        public DataTable GetIndicadoresOperacionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_INDICADORES_OPERACIONESCollection.GetAsDataTable(clausulas, orden);               
            }
        }
        #endregion GetIndicadoresOperacionesDataTable

        #region GetSimbolo

        /// <summary>
        /// Gets the simbolo.
        /// </summary>
        /// <param name="operacion_id">The operacion_id.</param>
        /// <returns></returns>
        public string GetSimbolo(decimal operacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_INDICADORES_OPERACIONESRow row = sesion.Db.CTB_INDICADORES_OPERACIONESCollection.GetByPrimaryKey(operacion_id);
                return row.SIMBOLO;
            }
        }

        #endregion GetSimbolo

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "CTB_INDICADORES_OPERACIONES"; }
        }

        public static string Id_NombreCol
        {
            get { return CTB_INDICADORES_OPERACIONESCollection.IDColumnName; }
        }

        public static string Nombre_NombreCol
        {
            get { return CTB_INDICADORES_OPERACIONESCollection.NOMBREColumnName; }
        }

        public static string Simbolo_NombreCol
        {
            get { return CTB_INDICADORES_OPERACIONESCollection.SIMBOLOColumnName; }
        } 
       
        #endregion Accessors
    }
}
