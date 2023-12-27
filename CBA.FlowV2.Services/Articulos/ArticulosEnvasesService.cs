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
    public class ArticulosEnvasesService
    {
        #region GetArticulosEnvasesDataTable
        /// <summary>
        /// Gets the articulos lineas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosEnvasesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ENVASESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosEnvasesDataTable

        #region GetArticulosEnvasesInfoCompleta
        /// <summary>
        /// Gets the articulos lineas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosEnvasesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ENVASESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosEnvasesInfoCompleta

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

                    ENVASESRow row = new ENVASESRow ();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ARTICULOS_ENVASES_SQC");
                    }
                    else
                    {
                        row = sesion.Db.ENVASESCollection.GetByPrimaryKey((decimal)campos[ArticulosEnvasesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[ArticulosEnvasesService.Nombre_NombreCol].ToString();
                    row.CODIGO = campos[ArticulosEnvasesService.Codigo_NombreCol].ToString();
                    row.UNIDAD_ID = campos[ArticulosEnvasesService.UnidadId_NombreCol].ToString();
                    row.PESABLE = campos[ArticulosEnvasesService.Pesable_NombreCol].ToString();
                    row.PESO = (decimal)campos[ArticulosEnvasesService.Peso_NombreCol];

                    if (insertarNuevo) sesion.Db.ENVASESCollection.Insert(row);
                    else sesion.Db.ENVASESCollection.Update(row);
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
        public void Borrar(decimal articulo_envase_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ENVASESRow row = sesion.Db.ENVASESCollection.GetRow(Id_NombreCol + "= " + articulo_envase_id);
                    String valorAnterior = row.ToString();

                    sesion.Db.ENVASESCollection.DeleteByPrimaryKey(articulo_envase_id);
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
            get { return "ENVASES"; }
        }
        public static string Codigo_NombreCol
        {
            get { return ENVASESCollection.CODIGOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ENVASESCollection.NOMBREColumnName; }
        }
        public static string UnidadId_NombreCol
        {
            get { return ENVASESCollection.UNIDAD_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ENVASESCollection.IDColumnName; }
        }
        public static string Pesable_NombreCol
        {
            get { return ENVASESCollection.PESABLEColumnName; }
        }
        public static string Peso_NombreCol
        {
            get { return ENVASESCollection.PESOColumnName; }
        }
        #endregion Accessors
    }
}
