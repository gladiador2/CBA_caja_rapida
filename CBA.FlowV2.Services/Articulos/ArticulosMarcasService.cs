using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosMarcasService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="articulosMarcas_id">The articulosMarcas_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal articulosMarcas_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_MARCASRow row = sesion.Db.ARTICULOS_MARCASCollection.GetRow(ID_ColumnName + " = " + articulosMarcas_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetArticulosMarcasDataTable
        /// <summary>
        /// Gets the articulosMarcas data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticulosMarcasDataTable()
        {
            return GetArticulosMarcasDataTable(string.Empty, "upper(" + Nombre_ColumnName + ")", false);
        }

        /// <summary>
        /// Gets the ArticulosMarcas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetArticulosMarcasDataTable(String clausulas, String orden) 
        {
            return GetArticulosMarcasDataTable(clausulas, orden, true);
        }

        /// <summary>
        /// Gets the articulosMarcas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetArticulosMarcasDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_ColumnName+"  = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.ARTICULOS_MARCASCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.ARTICULOS_MARCASCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetArticulosMarcasDataTable

        #region GetArticulosMarcasActivos
        /// <summary>
        /// Gets the articulosMarcas activos.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticulosMarcasActivos()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.ARTICULOS_MARCASCollection.GetAsDataTable(Estado_ColumnName+" ='"+Definiciones.Estado.Activo+"' ", "upper("+Nombre_ColumnName+")");
                return table;
            }
        }
        #endregion GetArticulosMarcasActivos

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ARTICULOS_MARCASRow row = new ARTICULOS_MARCASRow();
                    String valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("articulos_marcas_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.ARTICULOS_MARCASCollection.GetRow(ID_ColumnName+" = " + decimal.Parse((string)campos[ID_ColumnName]));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = (string)campos[Nombre_ColumnName];
                    row.ESTADO = (string)campos[Estado_ColumnName];

                    if (insertarNuevo) sesion.Db.ARTICULOS_MARCASCollection.Insert(row);
                    else sesion.Db.ARTICULOS_MARCASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                    return row.ID;

                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_MARCAS"; }
        }
        public static string ID_ColumnName
        {
            get { return ARTICULOS_MARCASCollection.IDColumnName; }
        }
        public static string Nombre_ColumnName
        {
            get { return ARTICULOS_MARCASCollection.NOMBREColumnName; }
        }
        public static string Estado_ColumnName
        {
            get { return ARTICULOS_MARCASCollection.ESTADOColumnName; }
        }
        #endregion Accessors
    }
}
