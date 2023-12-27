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
    public class ArticulosTallesService
    {
        #region GetArticulosTallesDataTable
        /// <summary>
        /// Gets the articulos talles data table.
        /// </summary>
        /// <param name="clausules">The clausules.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosTallesDataTable(string clausules, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.ARTICULOS_TALLESCollection.GetAsDataTable(clausules, orden);
                return table;
            }
        }
        #endregion GetArticulosTallesDataTable

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

                    ARTICULOS_TALLESRow row = new ARTICULOS_TALLESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_talles_sqc");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_TALLESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.NUMERO_DESDE = (decimal)campos[NumeroDesde_NombreCol];
                    row.NUMERO_HASTA = (decimal)campos[NumeroHasta_NombreCol];

                    if (insertarNuevo) sesion.Db.ARTICULOS_TALLESCollection.Insert(row);
                    else sesion.Db.ARTICULOS_TALLESCollection.Update(row);
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
        public static bool EstaActivo(decimal talle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_TALLESRow talle = sesion.Db.ARTICULOS_TALLESCollection.GetRow(ArticulosTallesService.Id_NombreCol + " = " + talle_id);
                return talle.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region Accesors
        public static string Nombre_Tabla
        { get { return "ARTICULOS_TALLES"; } }

        public static string Id_NombreCol
        { get { return ARTICULOS_TALLESCollection.IDColumnName; } }

        public static string Descripcion_NombreCol
        { get { return ARTICULOS_TALLESCollection.DESCRIPCIONColumnName; } }

        public static string Estado_NombreCol
        { get { return ARTICULOS_TALLESCollection.ESTADOColumnName; } }

        public static string Nombre_NombreCol
        { get { return ARTICULOS_TALLESCollection.NOMBREColumnName; } }

        public static string NumeroDesde_NombreCol
        { get { return ARTICULOS_TALLESCollection.NUMERO_DESDEColumnName; } }

        public static string NumeroHasta_NombreCol
        { get { return ARTICULOS_TALLESCollection.NUMERO_HASTAColumnName; } }
        #endregion Accesors
    }
}
