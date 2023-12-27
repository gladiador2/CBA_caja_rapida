using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosColoresService
    {
        #region GetArticulosColoresDataTable
        /// <summary>
        /// Gets the articulos colores data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosColoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_COLORESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosColoresDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ARTICULOS_COLORESRow row = new ARTICULOS_COLORESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_colores_sqc");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_COLORESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[Nombre_NombreColumn].ToString();
                    row.DESCRIPCION = campos[Descripcion_NombreColumn].ToString();
                    row.ESTADO = campos[Estado_NombreColumn].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_COLORESCollection.Insert(row);
                    else sesion.Db.ARTICULOS_COLORESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="color_id">The color_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal color_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_COLORESRow color = sesion.Db.ARTICULOS_COLORESCollection.GetRow(Id_NombreCol + " = " + color_id);
                return color.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo
        
        #region Accesors
        public static string Nombre_Tabla
        { get { return "ARTICULOS_COLORES"; } }

        public static string Id_NombreCol
        { get { return ARTICULOS_COLORESCollection.IDColumnName; } }

        public static string Descripcion_NombreColumn
        { get { return ARTICULOS_COLORESCollection.DESCRIPCIONColumnName; } }

        public static string Estado_NombreColumn
        { get { return ARTICULOS_COLORESCollection.ESTADOColumnName; } }

        public static string Nombre_NombreColumn
        { get { return ARTICULOS_COLORESCollection.NOMBREColumnName; } }
        #endregion Accesors
    }
}
