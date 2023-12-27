using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.Herramientas
{
    public class RolesService
    {
        /// <summary>
        /// Tienes the specified rol.
        /// </summary>
        /// <param name="rol">The rol.</param>
        /// <returns></returns>
        public static bool Tiene(string rol_descripcion)
        {
            return UsuariosRolesService.Tiene(rol_descripcion);
        }

        public static bool[] Tiene(string[] rol_descripcion)
        {
            using (SessionService sesion = new SessionService())
            {
                return Tiene(rol_descripcion, sesion); 
            }
        }

        public static bool[] Tiene(string[] rol_descripcion, SessionService sesion)
        {
            bool[] resultado = new bool[rol_descripcion.Length];
            for (int i = 0; i < rol_descripcion.Length; i++)
                resultado[i] = UsuariosRolesService.Tiene(rol_descripcion[i], sesion);

            return resultado;
        }


        public static bool Tiene(decimal rol_id)
        {
            return UsuariosRolesService.Tiene(rol_id);
        }

        public static ROLESRow GetRolPorDescripcion(string descripcion)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ROLESCollection.GetRow(RolesService.EntidadID_NombreCol + " = " + sesion.Entidad.ID + " and upper(" + RolesService.Descripcion_NombreCol + ") = '" + descripcion.ToUpper() + "'");
            }
        }

        /// <summary>
        /// Dado un array de descripciones de roles y un usuario_id, devuelve el conjunto de aquellos roles que tiene el usuario
        /// </summary>
        /// <param name="array_descripcion">The array_descripcion.</param>
        /// <returns></returns>
        public static decimal[] TieneArray(string[] array_descripcion, decimal usuario_id) 
        {
            using (SessionService sesion = new SessionService()) {
                string where = RolesService.Descripcion_NombreCol + " in (";
                for (int i = 0; i < array_descripcion.Length; i++) {
                    if (i != 0)
                        where += ", ";
                    where += "'" + array_descripcion[i] + "'";
                }
                where += ")";
                DataTable table = sesion.Db.ROLESCollection.GetAsDataTable(where, RolesService.Id_NombreCol);
                List<decimal> roles = new List<decimal>();
                foreach (DataRow dr in table.Rows) {
                    roles.Add((decimal)dr[RolesService.Id_NombreCol]);
                }
                return UsuariosRolesService.Tiene(roles.ToArray() , usuario_id);
            }
        }

        /// <summary>
        /// Devuelve todos los roles de un usuario particular. Se carga al loguear
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <returns>Data table con los roles de los usuarios.</returns>
        public DataTable GetRolesUsuarioDataTable(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.USUARIOS_ROLESCollection.GetByUSUARIO_IDAsDataTable(usuario_id);
            }
        }

        public static List<string> GetRolesUsuarioList(decimal usuario_id)
        {
            var dt = new DataTable();
            var roles = new List<string>();
            using (SessionService sesion = new SessionService())
            {
                int id = (int)usuario_id;
                dt = sesion.Db.USUARIOS_ROLES_INFO_COMPLETACollection.GetAsDataTable(USUARIOS_ROLES_INFO_COMPLETACollection.USUARIO_IDColumnName + " = " + id.ToString(), USUARIOS_ROLES_INFO_COMPLETACollection.ROL_DESCRIPCIONColumnName + " ASC");
                foreach (DataRow dr in dt.Rows)
                {
                    if (!roles.Contains(dr[USUARIOS_ROLES_INFO_COMPLETACollection.ROL_DESCRIPCIONColumnName].ToString()))
                        roles.Add(dr[USUARIOS_ROLES_INFO_COMPLETACollection.ROL_DESCRIPCIONColumnName].ToString());
                }
            }
            return roles;
        }

        /// <summary>
        /// Gets the roles data table filtrando por la entidad del usuario logueado.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRolesDataTable()
        {
            return RolesService.GetRolesDataTable(false);
        }

        /// <summary>
        /// Gets the flujos data table agregando o no un registro inicial "Todos".
        /// </summary>
        /// <param name="entidad_id">The entidad_id.</param>
        /// <param name="incluirRegistroTodos">if set to <c>true</c> [incluir registro todos].</param>
        /// <returns></returns>
        public static DataTable GetRolesDataTable(bool incluirRegistroTodos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = RolesService.GetRolesDataTable(string.Empty);

                if (incluirRegistroTodos)
                {
                    DataRow row = table.NewRow();
                    row[ROLESCollection.IDColumnName] = Definiciones.IdNull;
                    row[ROLESCollection.ENTIDAD_IDColumnName] = sesion.Entidad.ID;
                    row[ROLESCollection.DESCRIPCIONColumnName] = "Todos";
                    table.Rows.InsertAt(row, 0);
                }

                return table;
            }
        }
        
        /// <summary>
        /// Gets the roles data table.
        /// </summary>
        /// <param name="entidad_id">The entidad_id.</param>
        /// <param name="parteDescripcion">The parte descripcion.</param>
        /// <returns></returns>
        public static DataTable GetRolesDataTable(string parteDescripcion)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = EntidadID_NombreCol + " = " + sesion.Entidad.ID;
                if (parteDescripcion != string.Empty) where += " and upper("+Descripcion_NombreCol+") like '%" + parteDescripcion.ToUpper() + "%'";

                DataTable table = sesion.Db.ROLESCollection.GetAsDataTable(where, ROLESCollection.DESCRIPCIONColumnName);

                return table;
            }
        }

        /// <summary>
        /// Gets the roles data table.
        /// </summary>
        /// <param name="entidad_id">The entidad_id.</param>
        /// <param name="parteDescripcion">The parte descripcion.</param>
        /// <param name="incluirRegistroTodos">if set to <c>true</c> [incluir registro todos].</param>
        /// <returns></returns>
        public static DataTable GetRolesDataTable(decimal entidad_id, string parteDescripcion, bool incluirRegistroTodos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = EntidadID_NombreCol + "= " + entidad_id;
                if (parteDescripcion != string.Empty) where += " and upper("+Descripcion_NombreCol+") like '%" + parteDescripcion.ToUpper() + "%'";

                DataTable table = sesion.Db.ROLESCollection.GetAsDataTable(where, ROLESCollection.DESCRIPCIONColumnName);

                if (incluirRegistroTodos)
                {
                    DataRow row = table.NewRow();
                    row[ROLESCollection.IDColumnName] = Definiciones.IdNull;
                    row[ROLESCollection.ENTIDAD_IDColumnName] = sesion.Entidad.ID;
                    row[ROLESCollection.DESCRIPCIONColumnName] = "Todos";
                    table.Rows.InsertAt(row, 0);
                }
                return table;
            }
        }
        public static DataTable GetRolesDataTable(string where, string order)
        {
            using (SessionService sesion = new SessionService())
            {
                if(!where.Equals(string.Empty))
                    where+=" and ";
                where += EntidadID_NombreCol + "= " + sesion.Entidad.ID;
                

                DataTable table = sesion.Db.ROLESCollection.GetAsDataTable(where, ROLESCollection.DESCRIPCIONColumnName);

                
                return table;
            }
        }
        public DataTable GetRol(Decimal rol_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.ROLESCollection.GetAsDataTable(Id_NombreCol+" = " + rol_id, string.Empty);
                return tabla;
            }
        }

        private ROLESRow rol;

        public RolesService(decimal rol_id) {
            using (SessionService sesion = new SessionService())
            {
                this.rol = sesion.Db.ROLESCollection.GetByPrimaryKey(rol_id);
            }
        }

        public RolesService() {
            this.rol = new ROLESRow();
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ROLESRow rol = new ROLESRow();
                    string valorAnterior = string.Empty;
                    Decimal aux;

                    if (insertarNuevo)
                    {
                        rol.ID = sesion.Db.GetSiguienteSecuencia("roles_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        rol = sesion.Db.ROLESCollection.GetRow(Id_NombreCol+" = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = rol.ToString();
                    }

                    aux = Decimal.Parse((string)campos[EntidadID_NombreCol]);
                    if (rol.ENTIDAD_ID != aux)
                    {
                        if (EntidadesService.EstaActivo(aux)) rol.ENTIDAD_ID = aux;
                        else throw new System.ArgumentException("La entidad seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                    
                    rol.DESCRIPCION = (string)campos[Descripcion_NombreCol];

                    if (insertarNuevo) sesion.Db.ROLESCollection.Insert(rol);
                    else sesion.Db.ROLESCollection.Update(rol);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rol.ID, valorAnterior, rol.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public void Borrar(decimal rol_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ROLESRow rol = sesion.Db.ROLESCollection.GetRow(Id_NombreCol+"= " + rol_id);
                    String valorAnterior = rol.ToString();

                    sesion.Db.ROLESCollection.DeleteByPrimaryKey(rol_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rol.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        #region Accessors
        public static string Nombre_Tabla
        { get { return "ROLES"; } }

        public static string Id_NombreCol
        { get { return ROLESCollection.IDColumnName; } }
        public static string EntidadID_NombreCol
        { get { return ROLESCollection.ENTIDAD_IDColumnName; } }
        public static string Descripcion_NombreCol
        { get { return ROLESCollection.DESCRIPCIONColumnName; } }
        #endregion Accessors         
    }
}
