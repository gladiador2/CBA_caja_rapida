using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Reportes
{
    public class TiposReporteService
    {

        #region GetTiposReporteDataTable
        /// <summary>
        /// Gets the tipos reporte data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetTiposReporteDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TIPOS_REPORTECollection.GetAllAsDataTable();
            }
        }
        #endregion GetTiposReporteDataTable

        #region Metodos estaticos
        public static string TiposReporteId_NombreCol
        {
            get { return TIPOS_REPORTECollection.IDColumnName; }
        }
        public static string TiposReporteNombre_NombreCol
        {
            get { return TIPOS_REPORTECollection.NOMBREColumnName; }
        }
        #endregion Metodos estaticos

    }
}
