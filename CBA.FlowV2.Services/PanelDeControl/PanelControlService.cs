using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;


namespace CBA.FlowV2.Services.PanelDeControl
{
    public class PanelControlService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="panel_control_id">The panel_control_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal panel_control_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PANEL_CONTROLRow row = sesion.Db.PANEL_CONTROLCollection.GetByPrimaryKey(panel_control_id);

                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetPanelControlDataTable
        /// <summary>
        /// Gets the panel control data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetPanelControlDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PANEL_CONTROLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPanelControlDataTable

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PANEL_CONTROL"; }
        }
        public static string Estado_NombreCol
        {
            get { return PANEL_CONTROLCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PANEL_CONTROLCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return PANEL_CONTROLCollection.NOMBREColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return PANEL_CONTROLCollection.OBSERVACIONColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return PANEL_CONTROLCollection.ROL_IDColumnName; }
        }
        public static string TipoPanelControl_NombreCol
        {
            get { return PANEL_CONTROLCollection.TIPO_PANEL_CONTROLColumnName; }
        }
        #endregion Accessors
    }
}
