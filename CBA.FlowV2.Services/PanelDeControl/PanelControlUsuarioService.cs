#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.PanelDeControl
{
    public class PanelControlUsuarioService
    {
        #region GetPanelControlUsuarioDataTable
        /// <summary>
        /// Gets the bancos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetPanelControlUsuarioDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PANEL_CONTROL_USUARIOCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPanelControlUsuarioDataTable

        #region GetPanelControlUsuarioInfoCompleta
        /// <summary>
        /// Gets the bancos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetPanelControlUsuarioInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PANEL_CONTROL_USUARIO_INF_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPanelControlUsuarioInfoCompleta

        #region GetPanelControlDisponiblePorUsuario
        /// <summary>
        /// Obtener los paneles disponibles a un usuario segun roles
        /// </summary>
        /// <returns></returns>
        public DataTable GetPanelControlDisponiblePorUsuario()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtPaneles = (new PanelControlService()).GetPanelControlDataTable(PanelControlService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", string.Empty);

                for (int i = dtPaneles.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtPaneles.Rows[i][PanelControlService.RolId_NombreCol] == DBNull.Value)
                        continue;

                    if (!RolesService.Tiene((decimal)dtPaneles.Rows[i][PanelControlService.RolId_NombreCol]))
                        dtPaneles.Rows[i].Delete();
                }

                return dtPaneles;
            }
        }
        #endregion GetPanelControlUsuarioInfoCompleta

        #region GetPanelControlDisponiblePorUsuario
        /// <summary>
        /// Obtener los paneles que estan siendo utilizados por un usuario
        /// </summary>
        /// <returns></returns>
        public DataTable GetPanelControlEnUsoPorUsuario()
        {
            using (SessionService sesion = new SessionService())
            { 
                string clausulas = PanelControlUsuarioService.UsuarioId_NombreCol + " = " + sesion.Usuario.ID + " and " +
                                   PanelControlUsuarioService.VistaPanelControlEstado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                return this.GetPanelControlUsuarioInfoCompleta(clausulas, PanelControlUsuarioService.VistaPanelControlNombre_NombreCol);
            }
        }
        #endregion GetPanelControlUsuarioInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="panel_control_id">The panel_control_id.</param>
        public void Guardar(decimal panel_control_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PANEL_CONTROL_USUARIORow row = new PANEL_CONTROL_USUARIORow();

                    row.ID = sesion.Db.GetSiguienteSecuencia("panel_control_usuario_sqc");
                    row.USUARIO_ID = sesion.Usuario.ID;

                    if(!PanelControlService.EstaActivo(panel_control_id))
                        throw new Exception("El panel de control no se encuentra activo.");
                    row.PANEL_CONTROL_ID = panel_control_id;
                    
                    sesion.Db.PANEL_CONTROL_USUARIOCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion guardar

        #region Borrar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="panel_control_id">The panel_control_id.</param>
        public void Borrar(decimal panel_control_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    string clausulas = PanelControlUsuarioService.UsuarioId_NombreCol + " = " + sesion.Usuario.ID + " and " +
                                       PanelControlUsuarioService.PanelControlId_NombreCol + " = " + panel_control_id; 
                    PANEL_CONTROL_USUARIORow[] rows = sesion.Db.PANEL_CONTROL_USUARIOCollection.GetAsArray(clausulas, string.Empty);

                    if (rows.Length > 0)
                    {
                        sesion.Db.PANEL_CONTROL_USUARIOCollection.Delete(rows[0]);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].ID, rows[0].ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    }
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PANEL_CONTROL_USUARIO"; }
        }
        public static string Id_NombreCol
        {
            get { return PANEL_CONTROL_USUARIOCollection.IDColumnName; }
        }
        public static string PanelControlId_NombreCol
        {
            get { return PANEL_CONTROL_USUARIOCollection.PANEL_CONTROL_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return PANEL_CONTROL_USUARIOCollection.USUARIO_IDColumnName; }
        }
        public static string VistaPanelControlEstado_NombreCol
        {
            get { return PANEL_CONTROL_USUARIO_INF_CCollection.PANEL_CONTROL_ESTADOColumnName; }
        }
        public static string VistaPanelControlNombre_NombreCol
        {
            get { return PANEL_CONTROL_USUARIO_INF_CCollection.PANEL_CONTROL_NOMBREColumnName; }
        }
        public static string VistaPanelControlObservacion_NombreCol
        {
            get { return PANEL_CONTROL_USUARIO_INF_CCollection.PANEL_CONTROL_OBSERVACIONColumnName; }
        }
        public static string VistaPanelControlTipoId_NombreCol
        {
            get { return PANEL_CONTROL_USUARIO_INF_CCollection.PANEL_CONTROL_TIPO_IDColumnName; }
        }
        #endregion Accessors
    }
}
