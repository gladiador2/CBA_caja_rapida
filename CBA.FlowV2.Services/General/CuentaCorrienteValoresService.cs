#region Using
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;

#endregion Using

namespace CBA.FlowV2.Services.General
{
    public class CuentaCorrienteValoresService
    {
        #region GetCtacteValoresDataTable
        /// <summary>
        /// Gets the ctacte valores data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCtacteValoresDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_VALORESCollection.GetAsDataTable(string.Empty, CuentaCorrienteValoresService.Nombre_NombreCol);
            }
        }
        #endregion GetCtacteValoresDataTable

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_VALORES"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return CTACTE_VALORESCollection.DESCRIPCIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_VALORESCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_VALORESCollection.NOMBREColumnName; }
        }
        public static string TipoTalonario_NombreCol
        {
            get { return CTACTE_VALORESCollection.TIPO_TALONARIOColumnName; }
        }
        #endregion Accessors
    }
}
