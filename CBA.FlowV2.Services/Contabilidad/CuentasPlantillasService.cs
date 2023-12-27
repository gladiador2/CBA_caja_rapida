#region Using
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class CuentasPlantillasService
    {
        #region TieneHijos

        /// <summary>
        /// Tienes the hijos.
        /// </summary>
        /// <param name="ctb_cuenta_plantilla_id">The ctb_cuenta_plantilla_id.</param>
        /// <returns></returns>
        static public bool TieneHijos(decimal ctb_cuenta_plantilla_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CuentasPlantillasService cuentaPlantilla = new CuentasPlantillasService();
                DataTable dt = cuentaPlantilla.GetCuentasPlantillasDataTable(CuentasPlantillasService.CtbCuentaMadreId_NombreCol + " = " + ctb_cuenta_plantilla_id, string.Empty);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }
        #endregion TieneHijos

        #region GetCuentasPlantillasDataTable
        /// <summary>
        /// Gets the cuentas plantillas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCuentasPlantillasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_CUENTAS_PLANTILLASCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentasPlantillasDataTable

        #region Accessors

        public static string Nombre_Tabla
        { get { return "CTB_CUENTAS_PLANTILLAS"; } }

        public static string Asentable_NombreCol
        { get { return CTB_CUENTAS_PLANTILLASCollection.ASENTABLEColumnName; } }

        public static string CodigoBase_NombreCol
        { get { return CTB_CUENTAS_PLANTILLASCollection.CODIGO_BASEColumnName; } }
        
        public static string Codigo_NombreCol
        { get { return CTB_CUENTAS_PLANTILLASCollection.CODIGOColumnName; } }

        public static string CtbCuentaMadreId_NombreCol
        { get { return CTB_CUENTAS_PLANTILLASCollection.CTB_CUENTA_MADRE_IDColumnName; } }

        public static string Editable_NombreCol
        { get { return CTB_CUENTAS_PLANTILLASCollection.EDITABLEColumnName; } }

        public static string Id_NombreCol
        { get { return CTB_CUENTAS_PLANTILLASCollection.IDColumnName; } }

        public static string Nivel_NombreCol
        { get { return CTB_CUENTAS_PLANTILLASCollection.NIVELColumnName; } }

        public static string Nombre_NombreCol
        { get { return CTB_CUENTAS_PLANTILLASCollection.NOMBREColumnName; } }
        #endregion Accessors
    }
}
