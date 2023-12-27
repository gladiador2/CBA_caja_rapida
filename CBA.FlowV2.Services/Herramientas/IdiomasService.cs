using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class IdiomasService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="idioma_id">The idioma_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal idioma_id)
        {
            using (SessionService sesion = new SessionService())
            {
                IDIOMASRow row = sesion.Db.IDIOMASCollection.GetRow(ID_ColumnName+" = " + idioma_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetIdiomasDataTable
        /// <summary>
        /// Gets the idiomas data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetIdiomasDataTable()
        {
            return GetIdiomasDataTable(string.Empty, "upper("+NOMBRE_ColumnName+")", false);
        }

        /// <summary>
        /// Gets the idiomas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetIdiomasDataTable(String clausulas, String orden) 
        {
            return GetIdiomasDataTable(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the idiomas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetIdiomasDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_ColumnName+"  = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.IDIOMASCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.IDIOMASCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetIdiomasDataTable

        #region GetIdiomasActivos
        /// <summary>
        /// Gets the idiomas activos.
        /// </summary>
        /// <returns></returns>
        public DataTable GetIdiomasActivos()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IDIOMASCollection.GetAsDataTable(Estado_ColumnName+" ='"+Definiciones.Estado.Activo+"' ", "upper("+NOMBRE_ColumnName+")");
                return table;
            }
        }
        #endregion GetIdiomasActivos

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

                    IDIOMASRow row = new IDIOMASRow();
                    String valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("idiomas_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.IDIOMASCollection.GetRow(ID_ColumnName+" = " + decimal.Parse((string)campos[ID_ColumnName]));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = (string)campos[NOMBRE_ColumnName];
                    row.ESTADO = (string)campos[Estado_ColumnName];
                    
                    if (insertarNuevo) sesion.Db.IDIOMASCollection.Insert(row);
                    else sesion.Db.IDIOMASCollection.Update(row);

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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "IDIOMAS"; }
        }
        public static string ID_ColumnName
        {
            get { return IDIOMASCollection.IDColumnName; }
        }
        public static string NOMBRE_ColumnName
        {
            get { return IDIOMASCollection.NOMBREColumnName; }
        }
        public static string Estado_ColumnName
        {
            get { return IDIOMASCollection.ESTADOColumnName; }
        }
        #endregion Accessors
    }
}
