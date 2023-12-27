using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PerfilesService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="perfil_id">The perfil_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal perfil_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERFILESRow row = sesion.Db.PERFILESCollection.GetByPrimaryKey(perfil_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetPerfilesDataTable
        public DataTable GetPerfilesDataTable(string clausulas, string orden) 
        {
            using (SessionService sesion = new SessionService()) 
            {
                return sesion.Db.PERFILESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPerfilesDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            PERFILESRow perfil = new PERFILESRow();
            String valorAnterior = string.Empty;

            if (!campos.Contains(PerfilesService.Descripcion_NombreCol))
                throw new Exception("Debe Ingresar la Descripción");
            if (!campos.Contains(Estado_NombreCol))
                throw new Exception("Debe Ingresar el Estado");


            if (insertarNuevo)
            {
                perfil.ID = sesion.Db.GetSiguienteSecuencia("perfiles_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                if (!campos.Contains(Id_NombreCol))
                    throw new Exception("Falta el Id del Pefil");
                perfil = sesion.Db.PERFILESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                valorAnterior = perfil.ToString();
            }

            perfil.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
            perfil.ESTADO = campos[Estado_NombreCol].ToString();
            perfil.ENTIDAD_ID = sesion.Entidad.ID;
            if (insertarNuevo)
                sesion.db.PERFILESCollection.Insert(perfil);
            else
                sesion.db.PERFILESCollection.Update(perfil);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, perfil.ID, valorAnterior, perfil.ToString(), sesion);

        }
        
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PERFILES"; }
        }
        public static string Id_NombreCol
        {
            get { return PERFILESCollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return PERFILESCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return PERFILESCollection.ESTADOColumnName; }
        }
        #endregion Accessors
    }
}
