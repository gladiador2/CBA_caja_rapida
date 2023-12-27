using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Collections;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PerfilesRolesService
    {
        #region Getters
        /// <summary>
        /// Gets the perfiles roles data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetPerfilesRolesDataTable(string clausulas, string orden) 
        {
            using (SessionService sesion = new SessionService()) 
            {
                return sesion.Db.PERFILES_ROLESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        public static DataTable GetPerfilesRolesInfoCompletaPorPerfil(decimal PerfilId)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.PERFILES_ROLES_INFO_COMPLCollection.GetAsDataTable(PerfilesRolesService.PerfilId_NombreCol +"="+PerfilId,PerfilesRolesService.VistaRolDescripcion_NombreCol);
            }
        }

        #endregion GetPerfilesRolesDataTable

        #region Borrar
        /// <summary>
        /// Borrars the specified clausulas.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        public void Borrar(string[] perfiles, string[] roles)
        {
            using (SessionService sesion = new SessionService())
            {
                UsuariosRolesService usuariosRoles = new UsuariosRolesService();
                string clausulas = PerfilesRolesService.RolId_NombreCol + " in (" + String.Join(",", roles) + ") and " +
                                   PerfilesRolesService.PerfilId_NombreCol + " in (" + String.Join(",", perfiles) + ") ";

                sesion.Db.PERFILES_ROLESCollection.Delete(clausulas);

                //Actualizar los roles asignados a los usuarios
                //siendo que cambiaron los roles incluidos en los perfiles
                for (int i = 0; i < perfiles.Length; i++)
                {
                    for (int j = 0; j < roles.Length; j++)
                    {
                        usuariosRoles.DesasignarRolAUsuariosConPerfil(decimal.Parse(roles[j]), decimal.Parse(perfiles[i]), sesion);
                    }
                }
            }
        }
        public static void Borrar(decimal perfil_id, decimal rol_id, SessionService sesion)
        {
           try
            {
               
                UsuariosRolesService usuariosRoles = new UsuariosRolesService();
                string clausulas = PerfilesRolesService.RolId_NombreCol + " = " +rol_id + " and " +
                                   PerfilesRolesService.PerfilId_NombreCol + " = " + perfil_id + " ";

                sesion.Db.PERFILES_ROLESCollection.Delete(clausulas);

                //Actualizar los roles asignados a los usuarios
                //siendo que cambiaron los roles incluidos en los perfiles

                usuariosRoles.DesasignarRolAUsuariosConPerfil(rol_id, perfil_id, sesion);
            }
           catch (Exception exp)
           {
               throw exp;
           }      
            
        }

        public static void Borrar(decimal perfil_id, decimal rol_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    sesion.db.BeginTransaction();
                    Borrar(perfil_id, rol_id, sesion);
                    sesion.db.CommitTransaction();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }


        }
        #endregion Borrar

        #region Guardar
        /// <summary>
        /// Guardars the specified clausulas.
        /// </summary>
        /// <param name="perfiles">Perfiles a los que se asignaran roles.</param>
        /// <param name="roles">Roles que seran asignados.</param>
        public void Guardar(string[] perfiles, string[] roles)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    UsuariosRolesService usuariosRoles = new UsuariosRolesService();

                    //Primero se borran para que no haya duplicados
                    this.Borrar(perfiles, roles);

                    sesion.BeginTransaction();

                    for (int i = 0; i < perfiles.Length; i++)
                    {
                        for (int j = 0; j < roles.Length; j++)
                        {
                            PERFILES_ROLESRow row = new PERFILES_ROLESRow();
                            row.PERFIL_ID = decimal.Parse(perfiles[i]);
                            row.ROL_ID = decimal.Parse(roles[j]);

                            sesion.Db.PERFILES_ROLESCollection.Insert(row);
                            LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);

                            //Actualizar los roles asignados a los usuarios
                            //siendo que cambiaron los roles incluidos en los perfiles
                            usuariosRoles.AsignarRolAUsuariosConPerfil(row.ROL_ID, row.PERFIL_ID, sesion);
                        }
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
        public static void Guardar(Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    UsuariosRolesService usuariosRoles = new UsuariosRolesService();

                    sesion.BeginTransaction();

                    PERFILES_ROLESRow row = new PERFILES_ROLESRow();
                    row.PERFIL_ID = decimal.Parse(campos[PerfilId_NombreCol].ToString());
                    row.ROL_ID = decimal.Parse(campos[RolId_NombreCol].ToString());

                    //Primero se borran para que no haya duplicados
                    Borrar(row.PERFIL_ID, row.ROL_ID, sesion);
                    sesion.Db.PERFILES_ROLESCollection.Insert(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);

                    //Actualizar los roles asignados a los usuarios
                    //siendo que cambiaron los roles incluidos en los perfiles
                    usuariosRoles.AsignarRolAUsuariosConPerfil(row.ROL_ID, row.PERFIL_ID, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "PERFILES_ROLES"; }
        }
        public static string PerfilId_NombreCol
        {
            get { return PERFILES_ROLESCollection.PERFIL_IDColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return PERFILES_ROLESCollection.ROL_IDColumnName; }
        }
        #endregion 

        #region Vista
        public static string Nombre_Vista
        {
            get { return "perfiles_roles_info_compl"; }
        }
        public static string VistaPerfilDescripcion_NombreCol
        {
            get { return PERFILES_ROLES_INFO_COMPLCollection.PERFIL_DESCRIPCIONColumnName; }
        }
        public static string VistaRolDescripcion_NombreCol
        {
            get { return PERFILES_ROLES_INFO_COMPLCollection.ROL_DESCRIPCIONColumnName; }
        }
        #endregion

        #endregion Accessors
    }
}
