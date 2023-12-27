using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Collections.Generic;
using System.Collections;

namespace CBA.FlowV2.Services.Herramientas
{
    public class UsuariosRolesService
    {
        #region GetUsuariosRolesInfoCompleta
        public static DataTable GetUsuariosRolesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUsuariosRolesInfoCompleta(clausulas, orden, sesion);
            }
        }
        public static DataTable GetUsuariosRolesInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = "(" + UsuariosRolesService.FechaCaducidad_NombreCol + " is null or trunc(" + UsuariosRolesService.FechaCaducidad_NombreCol + ") >= to_date('" + DateTime.Now.ToShortDateString() + "', 'dd/mm/yyyy'))";
            if (clausulas.Length > 0)
                where += " and (" + clausulas + ")";
                
            return sesion.Db.USUARIOS_ROLES_INFO_COMPLETACollection.GetAsDataTable(where, orden);
        }
        #endregion GetUsuariosRolesDataTable

        #region GetUsuariosRolesDataTable
        public static DataTable GetUsuariosRolesDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = "(" + UsuariosRolesService.FechaCaducidad_NombreCol + " is null or " + UsuariosRolesService.FechaCaducidad_NombreCol + " >= to_date('" + DateTime.Now.ToShortDateString() + "', 'dd/mm/yyyy'))";
            if (clausulas.Length > 0)
                where += " and (" + clausulas + ")";
            return sesion.Db.USUARIOS_ROLESCollection.GetAsDataTable(where, orden);
        }
        #endregion GetUsuariosRolesInfoCompleta

        #region GetDistintosRolesPorUsuario
        public static DataTable GetDistintosRolesPorUsuario(decimal usuario_id, SessionService sesion)
        {
            string clausulas = UsuariosRolesService.UsuarioId_NombreCol + " = " + usuario_id + " and " +
                               "(" + UsuariosRolesService.FechaCaducidad_NombreCol + " is null or " + UsuariosRolesService.FechaCaducidad_NombreCol + " >= to_date('" + DateTime.Now.Date + "', 'dd/mm/yyyy hh24:mi:ss'))";

            return sesion.db.EjecutarQuery("select distinct " + UsuariosRolesService.VistaRolDescripcion_NombreCol + " from " + UsuariosRolesService.Nombre_Vista + " where " + clausulas);
        }
        #endregion GetDistintosRolesPorUsuario

        #region Tiene
        public static bool Tiene(string rol_descripcion)
        {
            using (SessionService sesion = new SessionService())
            {
                return Tiene(rol_descripcion, sesion);
            }
        }

        public static bool Tiene(string rol_descripcion, SessionService sesion)
        {
            if (sesion.Roles != null)
            {
                return sesion.Roles.Contains(rol_descripcion.ToUpper());
            }
            else
            {
                string clausules = "upper(" + UsuariosRolesService.VistaRolDescripcion_NombreCol + ") = '" + rol_descripcion.ToUpper() + "' and " +
                                   UsuariosRolesService.UsuarioId_NombreCol + " = " + sesion.Usuario_Id;
                DataTable dt = GetUsuariosRolesInfoCompleta(clausules, string.Empty, sesion);

                return dt.Rows.Count > 0;
            }
        }

        public static bool Tiene(decimal rol_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Tiene(rol_id, sesion);
            }
        }

        public static bool Tiene(decimal rol_id, SessionService sesion)
        {
            string clausules = UsuariosRolesService.RolId_NombreCol + " = " + rol_id + " and " +
                               UsuariosRolesService.UsuarioId_NombreCol + " = " + sesion.Usuario_Id;
            DataTable dt = GetUsuariosRolesInfoCompleta(clausules, string.Empty, sesion);

            return dt.Rows.Count > 0;
        }

        /// <summary>
        /// dado un array de ids de roles, retorna el array que el usuario dado tiene
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <returns></returns>
        public static decimal[] Tiene(decimal[] roles, decimal usuario_id) 
        {
            List<decimal> rolesTiene = new List<decimal>();
            using (SessionService sesion = new SessionService()) 
            { 
                string where = UsuariosRolesService.RolId_NombreCol + " in (";
                for (int i = 0; i < roles.Length; i++) {
                    if (i != 0)
                        where += ", ";
                    where += roles[i];
                }
                where += ") and " + UsuariosRolesService.UsuarioId_NombreCol + " = " + usuario_id;
                
                DataTable table = GetUsuariosRolesDataTable(where, string.Empty, sesion);
             
                foreach (DataRow dr in table.Rows) 
                    rolesTiene.Add((decimal)dr[UsuariosRolesService.RolId_NombreCol]);
            }
            return rolesTiene.ToArray();
        }

        public static bool Tiene(Dictionary<string, int> roles, string rol_descripcion)
        {
            return roles.ContainsKey(rol_descripcion.ToUpper());
        }
        #endregion Tiene

        #region AsignarRolesPorPerfil
        /// <summary>
        /// Asignars the roles por perfil.
        /// </summary>
        /// <param name="perfil_id">The perfil_id.</param>
        /// <param name="usuario_id">The usuario_id.</param>
        public void AsignarRolesPorPerfil(decimal perfil_id, decimal usuario_id, DateTime fecha_caducidad, bool usar_caducidad)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    PerfilesRolesService perfilesRoles = new PerfilesRolesService();
                    DataTable dtRolesPerfil = perfilesRoles.GetPerfilesRolesDataTable(PerfilesRolesService.PerfilId_NombreCol + " = " + perfil_id, string.Empty);

                    for (int i = 0; i < dtRolesPerfil.Rows.Count; i++)
                    {
                        Hashtable campos = new Hashtable();
                        campos.Add(UsuariosRolesService.UsuarioId_NombreCol, usuario_id);
                        campos.Add(UsuariosRolesService.RolId_NombreCol, dtRolesPerfil.Rows[i][PerfilesRolesService.RolId_NombreCol]);
                        campos.Add(UsuariosRolesService.PerfilId_NombreCol, perfil_id);
                        if(usar_caducidad)
                            campos.Add(UsuariosRolesService.FechaCaducidad_NombreCol, fecha_caducidad);

                        UsuariosRolesService.Guardar(campos, sesion);
                    }

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion AsignarRolesPorPerfil

        #region DesasignarRolesPorPerfil
        /// <summary>
        /// Desasignars the roles por perfil.
        /// </summary>
        /// <param name="perfil_id">The perfil_id.</param>
        /// <param name="usuario_id">The usuario_id.</param>
        public void DesasignarRolesPorPerfil(decimal perfil_id, decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string clausulas = UsuariosRolesService.UsuarioId_NombreCol + " = " + usuario_id + " and " +
                                       UsuariosRolesService.PerfilId_NombreCol +  " = " + perfil_id;

                    USUARIOS_ROLESRow[] rows = sesion.Db.USUARIOS_ROLESCollection.GetAsArray(clausulas, string.Empty);

                    for (int i = 0; i < rows.Length; i++)
                    { 
                        sesion.Db.USUARIOS_ROLESCollection.Delete(rows[i]);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].USUARIO_ID, rows[0].ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    }
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion DesasignarRolesPorPerfil

        #region AsignarRolAUsuariosConPerfil
        /// <summary>
        /// Asignars the rol A usuarios con perfil.
        /// </summary>
        /// <param name="rol_id">The rol_id.</param>
        /// <param name="perfil_id">The perfil_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void AsignarRolAUsuariosConPerfil(decimal rol_id, decimal perfil_id, SessionService sesion)
        {
            string clausulas = UsuariosPerfilesService.PerfilId_NombreCol + " = " + perfil_id;
            DataTable dtUsuariosPerfil = (new UsuariosPerfilesService()).GetUsuariosPerfilesDataTable(clausulas, string.Empty);

            //Asignar el rol a cada usuario que posee el perfil
            for (int i = 0; i < dtUsuariosPerfil.Rows.Count; i++)
            {
                Hashtable campos = new Hashtable();
                campos.Add(UsuariosRolesService.RolId_NombreCol, rol_id);
                campos.Add(UsuariosRolesService.PerfilId_NombreCol, perfil_id);
                campos.Add(UsuariosRolesService.UsuarioId_NombreCol, dtUsuariosPerfil.Rows[i][UsuariosPerfilesService.UsuraioId_NombreCol]);
                UsuariosRolesService.Guardar(campos, sesion);
            }
        }
        #endregion AsignarRolAUsuariosConPerfil

        #region DesasignarRolAUsuariosConPerfil
        /// <summary>
        /// Desasignars the rol A usuarios con perfil.
        /// </summary>
        /// <param name="rol_id">The rol_id.</param>
        /// <param name="perfil_id">The perfil_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void DesasignarRolAUsuariosConPerfil(decimal rol_id, decimal perfil_id, SessionService sesion)
        {
            string clausulas = UsuariosPerfilesService.PerfilId_NombreCol + " = " + perfil_id;
            DataTable dtUsuariosPerfil = (new UsuariosPerfilesService()).GetUsuariosPerfilesDataTable(clausulas, string.Empty);

            //Asignar el rol a cada usuario que posee el perfil
            for (int i = 0; i < dtUsuariosPerfil.Rows.Count; i++)
            {
                UsuariosRolesService.Borrar((decimal)dtUsuariosPerfil.Rows[i][UsuariosPerfilesService.UsuraioId_NombreCol], rol_id, perfil_id);
            }
        }
        #endregion DesasignarRolAUsuariosConPerfil

        #region Guardar
        public static void Guardar(Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    UsuariosRolesService.Guardar(campos, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        /// <summary>
        /// Guardars the specified usuario_id.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="rol_id">The rol_id.</param>
        /// <param name="perfil_id">The perfil_id.</param>
        public static void Guardar(Hashtable campos, SessionService sesion)
        {
            try
            {
                USUARIOS_ROLESRow row = new USUARIOS_ROLESRow();
                row.ID = sesion.Db.GetSiguienteSecuencia("usuarios_roles_sqc");
                row.USUARIO_ID = (decimal)campos[UsuariosRolesService.UsuarioId_NombreCol];
                row.ROL_ID = (decimal)campos[UsuariosRolesService.RolId_NombreCol];

                if (campos.Contains(UsuariosRolesService.PerfilId_NombreCol))
                {
                    row.PERFIL_ID = (decimal)campos[UsuariosRolesService.PerfilId_NombreCol];
                    if (!PerfilesService.EstaActivo(row.PERFIL_ID))
                        throw new Exception("El perfil no se encuentra activo.");
                }

                if (campos.Contains(UsuariosRolesService.FechaCaducidad_NombreCol))
                    row.FECHA_CADUCIDAD = (DateTime)campos[UsuariosRolesService.FechaCaducidad_NombreCol];

                sesion.Db.USUARIOS_ROLESCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.USUARIO_ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        throw new System.ArgumentException("El usuario ya cuenta con el rol.");
                    default:
                        throw exp;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar
        
        #region Borrar
        /// <summary>
        /// Borrars the specified usuario_id.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="rol_id">The rol_id.</param>
        /// <param name="perfil_id">The perfil_id.</param>
        public static void Borrar(decimal usuario_id, decimal rol_id, decimal perfil_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    string clausulas = UsuariosRolesService.UsuarioId_NombreCol + " = " + usuario_id + " and " +
                                       UsuariosRolesService.RolId_NombreCol + " = " + rol_id;

                    if (perfil_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        clausulas += " and " + UsuariosRolesService.PerfilId_NombreCol + " is null ";
                    else
                        clausulas += " and " + UsuariosRolesService.PerfilId_NombreCol + " = " + perfil_id;

                    USUARIOS_ROLESRow[] rows = sesion.Db.USUARIOS_ROLESCollection.GetAsArray(clausulas, string.Empty);

                    if (rows.Length > 0)
                    {
                        sesion.Db.USUARIOS_ROLESCollection.Delete(rows[0]);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].USUARIO_ID, rows[0].ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    }
                    
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
            get { return "USUARIOS_ROLES"; }
        }
        public static string Nombre_Vista
        {
            get { return "USUARIOS_ROLES_INFO_COMPLETA"; }
        }
        public static string Id_NombreCol
        {
            get { return USUARIOS_ROLESCollection.IDColumnName; }
        }
        public static string FechaCaducidad_NombreCol
        {
            get { return USUARIOS_ROLESCollection.FECHA_CADUCIDADColumnName; }
        }
        public static string PerfilId_NombreCol
        {
            get { return USUARIOS_ROLESCollection.PERFIL_IDColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return USUARIOS_ROLESCollection.ROL_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return USUARIOS_ROLESCollection.USUARIO_IDColumnName; }
        }        
        public static string VistaRolDescripcion_NombreCol
        {
            get { return USUARIOS_ROLES_INFO_COMPLETACollection.ROL_DESCRIPCIONColumnName; }
        }
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return USUARIOS_ROLES_INFO_COMPLETACollection.USUARIO_NOMBREColumnName; }
        }
        public static string VistaPerfilDescripcion_NombreCol
        {
            get { return USUARIOS_ROLES_INFO_COMPLETACollection.PERFIL_DESCRIPCIONColumnName; }
        }
        
        #endregion Accessors
    }
}
