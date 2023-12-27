#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
#endregion Using

namespace CBA.FlowV2.Services.TextosPredefinidos
{
    public class TiposTextosPredefinidosService
    {
        #region GetTiposTextosPredefinidosDataTable
        /// <summary>
        /// Gets the tipos Textos Predefinidos data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetTiposTextosPredefinidosDataTable()
        {
            string clausulas = string.Empty;
            string orden = string.Empty;
            return this.GetTiposTextosPredefinidosDataTable(clausulas, orden);
        }
        
        /// <summary>
        /// Gets the tipos Textos Predefinidos data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetTiposTextosPredefinidosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TIPOS_TEXTOS_PREDEFINIDOSCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetTiposTextosPredefinidosDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TIPOS_TEXTOS_PREDEFINIDOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetTiposTextosPredefinidosDataTable

        #region Metodos estaticos
        public static string Id_NombreCol
        {
            get { return TIPOS_TEXTOS_PREDEFINIDOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TIPOS_TEXTOS_PREDEFINIDOSCollection.NOMBREColumnName; }
        }
        #endregion Metodos estaticos
    }
}
