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
    public class ArticulosLineasService
    {
        #region GetArticulosLineasDataTable
        /// <summary>
        /// Gets the articulos lineas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosLineasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_LINEASCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosLineasDataTable

        #region GetArticulosLineasInfoCompleta
        /// <summary>
        /// Gets the articulos lineas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosLineasInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_LINEAS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosLineasInfoCompleta

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

                    ARTICULOS_LINEASRow row = new ARTICULOS_LINEASRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ARTICULOS_LINEAS_SQC");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_LINEASCollection.GetByPrimaryKey((decimal)campos[ArticulosLineasService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[ArticulosLineasService.Nombre_NombreCol].ToString();
                    row.DESCRIPCION = campos[ArticulosLineasService.Descripcion_NombreCol].ToString();
                    row.ARTICULOS_FAMILIA = (decimal)campos[ArticulosLineasService.ArticulosFamilia_NombreCol];
                    row.ESTADO = campos[ArticulosLineasService.Estado_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_LINEASCollection.Insert(row);
                    else sesion.Db.ARTICULOS_LINEASCollection.Update(row);
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
        /// Borrars the specified articulo_linea_id.
        /// </summary>
        /// <param name="articulo_linea_id">The articulo_linea_id.</param>
        public void Borrar(decimal articulo_linea_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ARTICULOS_LINEASRow row = sesion.Db.ARTICULOS_LINEASCollection.GetRow(Id_NombreCol + "= " + articulo_linea_id);
                    String valorAnterior = row.ToString();

                    sesion.Db.ARTICULOS_LINEASCollection.DeleteByPrimaryKey(articulo_linea_id);
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
            get { return "ARTICULOS_LINEAS"; }
        }
        public static string ArticulosFamilia_NombreCol
        {
            get { return ARTICULOS_LINEASCollection.ARTICULOS_FAMILIAColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ARTICULOS_LINEASCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ARTICULOS_LINEASCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_LINEASCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ARTICULOS_LINEASCollection.NOMBREColumnName; }
        }
        public static string VistaArticulosFamiliaNombre_NombreCol
        {
            get { return ARTICULOS_LINEAS_INFO_COMPLETACollection.ARTICULOS_FAMILIA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
