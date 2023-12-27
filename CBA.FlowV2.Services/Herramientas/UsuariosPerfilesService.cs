using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class UsuariosPerfilesService
    {
        #region GetUsuariosPerfilesInfoCompleta
        /// <summary>
        /// Gets the usuarios perfiles info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetUsuariosPerfilesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = UsuariosPerfilesService.VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.USUARIOS_PERFILES_INFO_COMPCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetUsuariosPerfilesInfoCompleta

        #region GetUsuariosPerfilesDataTable
        /// <summary>
        /// Gets the usuarios perfiles data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetUsuariosPerfilesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.USUARIOS_PERFILESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetUsuariosPerfilesDataTable

        #region Tiene
        /// <summary>
        /// Tienes the specified perfil.
        /// </summary>
        /// <param name="perfil">The perfil.</param>
        /// <returns></returns>
        public static bool Tiene(string perfil)
        {

            using (SessionService sesion = new SessionService())
            {

                PERFILESRow perfilRow = sesion.Db.PERFILESCollection.GetRow(" upper(" +PerfilesService.Descripcion_NombreCol + ") = '" + perfil.ToUpper() + "'");
                if (perfilRow != null)
                {
                    USUARIOS_PERFILESRow permiso = sesion.Db.USUARIOS_PERFILESCollection.GetRow(UsuariosPerfilesService.UsuraioId_NombreCol + " = " + sesion.Usuario_Id + " and " + UsuariosPerfilesService.PerfilId_NombreCol + " = " + perfilRow.ID);
                    return permiso == null ? false : true;
                }
                return false;

            }
        }
        #endregion Tiene

        #region Guardar
        /// <summary>
        /// Guardars the specified usuario_id.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="rol_id">The rol_id.</param>
        public void Guardar(decimal usuario_id, decimal perfil_id, DateTime fecha_caducidad, bool usar_caducidad)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    USUARIOS_PERFILESRow row = new USUARIOS_PERFILESRow();
                                        
                    row.USUARIO_ID = usuario_id;
                    row.PERFIL_ID = perfil_id;

                    sesion.Db.USUARIOS_PERFILESCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.USUARIO_ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);

                    //Agregar los roles al usuario
                    (new UsuariosRolesService()).AsignarRolesPorPerfil(perfil_id, usuario_id, fecha_caducidad, usar_caducidad);

                    sesion.CommitTransaction();
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exp)
                {
                    sesion.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("El usuario ya cuenta con el perfil.");
                        default:
                            throw exp;
                    }
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar
        
        #region Borrar
        /// <summary>
        /// Borrars the specified usuario_id.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="perfil_id">The perfil_id.</param>
        public void Borrar(decimal usuario_id, decimal perfil_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    string clausulas = UsuariosPerfilesService.UsuraioId_NombreCol + " = " + usuario_id + " and " +
                                       UsuariosPerfilesService.PerfilId_NombreCol + " = " + perfil_id;
                    USUARIOS_PERFILESRow[] rows = sesion.Db.USUARIOS_PERFILESCollection.GetAsArray(clausulas, string.Empty);

                    if (rows.Length > 0)
                    {
                        sesion.Db.USUARIOS_PERFILESCollection.Delete(rows[0]);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].USUARIO_ID, rows[0].ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    }
                    
                    //Quitar efectivamente los roles al usuario
                    (new UsuariosRolesService()).DesasignarRolesPorPerfil(perfil_id, usuario_id);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "USUARIOS_PERFILES"; }
        }
        public static string PerfilId_NombreCol
        {
            get { return USUARIOS_PERFILESCollection.PERFIL_IDColumnName; }
        }
        public static string UsuraioId_NombreCol
        {
            get { return USUARIOS_PERFILESCollection.USUARIO_IDColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return USUARIOS_PERFILES_INFO_COMPCollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaPerfilDescripcion_NombreCol
        {
            get { return USUARIOS_PERFILES_INFO_COMPCollection.PERFIL_DESCRIPCIONColumnName; }
        }
        public static string VistaPerfilEstado_NombreCol
        {
            get { return USUARIOS_PERFILES_INFO_COMPCollection.PERFIL_ESTADOColumnName; }
        }
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return USUARIOS_PERFILES_INFO_COMPCollection.USUARIO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
