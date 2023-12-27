#region Usings
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using System.Data;
#endregion

namespace CBA.FlowV2.Services.Herramientas
{
    public abstract class CambiarContrasenhaService
    {
        public static bool ComprobarContrasenhaActual(SessionService sesion, string contrasenhaActual)
        {
            bool existe = false;
            ////string where = USUARIOSCollection.PASSWDColumnName + "='" + contrasenhaActual + "'";

            //DataTable dt = sesion.Db.USUARIOSCollection.GetAsDataTable(where, "");

            //if (dt.Rows.Count > 0)
            //{
            //    existe = true;
            //}

            return existe;
        }
    }
}
