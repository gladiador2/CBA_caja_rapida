#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosPadresService
    {
        #region GetArticulosPadresDataTable
        /// <summary>
        /// Gets the articulos padres data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosPadresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_PADRESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosPadresDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ARTICULOS_PADRESRow row = new ARTICULOS_PADRESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ARTICULOS_PADRES_SQC");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_PADRESCollection.GetByPrimaryKey((decimal)campos[ArticulosPadresService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[ArticulosPadresService.Nombre_NombreCol].ToString();
                    row.DESCRIPCION = campos[ArticulosPadresService.Descripcion_NombreCol].ToString();
                    row.CODIGO = campos[ArticulosPadresService.Codigo_NombreCol].ToString();
                    row.ESTADO = campos[ArticulosPadresService.Estado_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_PADRESCollection.Insert(row);
                    else sesion.Db.ARTICULOS_PADRESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar
        
        #region Borrar
        /// <summary>
        /// Borrars the specified articulo_padre_id.
        /// </summary>
        /// <param name="articulo_padre_id">The articulo_padre_id.</param>
        public void Borrar(decimal articulo_padre_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ARTICULOS_PADRESRow row = sesion.Db.ARTICULOS_PADRESCollection.GetRow(Id_NombreCol + "= " + articulo_padre_id);
                    String valorAnterior = row.ToString();

                    sesion.Db.ARTICULOS_PADRESCollection.DeleteByPrimaryKey(articulo_padre_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_PADRES"; }
        }
        public static string Codigo_NombreCol
        {
            get { return ARTICULOS_PADRESCollection.CODIGOColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ARTICULOS_PADRESCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ARTICULOS_PADRESCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_PADRESCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ARTICULOS_PADRESCollection.NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
