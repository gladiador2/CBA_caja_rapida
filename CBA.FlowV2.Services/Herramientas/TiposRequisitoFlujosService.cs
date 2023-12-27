using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TiposRequisitoFlujosService
    {
        #region GetTiposRequisitoFlujoDataTable
        public DataTable GetTiposRequisitoFlujoDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TIPOS_REQUISITO_FLUJOCollection.GetAsDataTable("", "upper("+TiposRequisitoFlujoNombre_NombreCol+")");
                return table;
            }
        }
        #endregion GetTiposRequisitoFlujoDataTable

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "TIPOS_REQUISITO_FLUJO"; }
        }
        public static string TiposRequisitoFlujoNombre_NombreCol
        {
            get { return TIPOS_REQUISITO_FLUJOCollection.NOMBREColumnName; }
        }
        public static string TiposRequisitoFlujoDescripcion_NombreCol
        {
            get { return TIPOS_REQUISITO_FLUJOCollection.DESCRIPCIONColumnName; }
        }
        #endregion Metodos estaticos

    }
}
