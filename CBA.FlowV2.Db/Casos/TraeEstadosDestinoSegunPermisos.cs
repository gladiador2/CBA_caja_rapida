
using System;
using System.Data;

using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Db.Casos
{
    public class TraeEstadosDestinoSegunPermisos 
    {
       

        #region Accessors
        public static string Id_NombreCol
        {
            get { return "ID"; }
        }
        public static string Alias_NombreCol
        {
            get { return "ALIAS"; }
        }
        public static string ColorHexadecimal_NombreCol
        {
            get { return "COLOR_HEXADECIMAL"; }
        }
        public static string SQL_NombreCol
        {
            get { return "SQL"; }
        }
        #endregion Accessors
    }
}
