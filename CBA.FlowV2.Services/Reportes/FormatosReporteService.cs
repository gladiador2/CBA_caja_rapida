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
    public class FormatosReporteService
    {
        #region GetDataTable
        public static DataTable GetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FORMATOS_REPORTECollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetDataTable

        #region Accessors
        public static string Id_NombreCol
        {
            get { return FORMATOS_REPORTECollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return FORMATOS_REPORTECollection.NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
