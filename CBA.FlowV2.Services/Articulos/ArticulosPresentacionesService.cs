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
    public class ArticulosPresentacionesService
    {
        #region GetArticulosPresentacionesDataTable
        /// <summary>
        /// Gets the articulos presentaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosPresentacionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return  sesion.Db.ARTICULOS_PRESENTACIONESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosPresentacionesDataTable

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

                    ARTICULOS_PRESENTACIONESRow row = new ARTICULOS_PRESENTACIONESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_presentaciones_sqc");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_PRESENTACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    
                    if (insertarNuevo) sesion.Db.ARTICULOS_PRESENTACIONESCollection.Insert(row);
                    else sesion.Db.ARTICULOS_PRESENTACIONESCollection.Update(row);
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
        /// <param name="presentacion_id">The presentacion_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal presentacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_PRESENTACIONESRow presentacion = sesion.Db.ARTICULOS_PRESENTACIONESCollection.GetByPrimaryKey(presentacion_id);
                return presentacion.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region Accesors
        public static string Nombre_Tabla
        { get { return "ARTICULOS_PRESENTACIONES"; } }

        public static string Id_NombreCol
        { get { return ARTICULOS_PRESENTACIONESCollection.IDColumnName; } }

        public static string Descripcion_NombreCol
        { get { return ARTICULOS_PRESENTACIONESCollection.DESCRIPCIONColumnName; } }

        public static string Nombre_NombreCol
        { get { return ARTICULOS_PRESENTACIONESCollection.NOMBREColumnName; } }

        public static string Estado_NombreCol
        { get { return ARTICULOS_PRESENTACIONESCollection.ESTADOColumnName; } }
        #endregion Accesors
    }
}
