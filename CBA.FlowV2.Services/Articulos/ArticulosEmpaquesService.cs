using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosEmpaquesService
    {

        #region GetArticulosEmpaquesDataTable
        /// <summary>
        /// Gets the articulos empaques data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosEmpaquesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_EMPAQUESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosEmpaquesDataTable

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

                    ARTICULOS_EMPAQUESRow row = new ARTICULOS_EMPAQUESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_empaques_sqc");
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_EMPAQUESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[Nombre_NombreColumn].ToString();
                    row.DESCRIPCION = campos[Descripcion_NombreColumn].ToString();
                    row.ESTADO = campos[Estado_NombreColumn].ToString();

                    if (insertarNuevo) sesion.Db.ARTICULOS_EMPAQUESCollection.Insert(row);
                    else sesion.Db.ARTICULOS_EMPAQUESCollection.Update(row);
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
        public static bool EstaActivo(decimal empaque_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_EMPAQUESRow empaque = sesion.Db.ARTICULOS_EMPAQUESCollection.GetRow(ArticulosEmpaquesService.Id_NombreCol + " = " + empaque_id);
                return empaque.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region Accesors
        public static string Nombre_Tabla
        { get { return "ARTICULOS_EMPAQUES"; } }

        public static string Id_NombreCol
        { get { return ARTICULOS_EMPAQUESCollection.IDColumnName; } }

        public static string Descripcion_NombreColumn
        { get { return ARTICULOS_EMPAQUESCollection.DESCRIPCIONColumnName; } }

        public static string Estado_NombreColumn
        { get { return ARTICULOS_EMPAQUESCollection.ESTADOColumnName; } }

        public static string Nombre_NombreColumn
        { get { return ARTICULOS_EMPAQUESCollection.NOMBREColumnName; } }

        
        #endregion Accesors
    }
}
