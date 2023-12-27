using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EstadoMorosidadService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="estadoMorosidad_id">The estadoMorosidad_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal estadoMorosidad_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ESTADO_MOROSIDADRow row = sesion.Db.ESTADO_MOROSIDADCollection.GetRow(ID_ColumnName + " = " + estadoMorosidad_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetEstadoMorosidadDataTable
        /// <summary>
        /// Gets the estadoMorosidad data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEstadoMorosidadDataTable()
        {
            return GetEstadoMorosidadDataTable(string.Empty, "upper(" + Nombre_ColumnName + ")", false);
        }

        /// <summary>
        /// Gets the estadoMorosidad data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetEstadoMorosidadDataTable(String clausulas, String orden) 
        {
            return GetEstadoMorosidadDataTable(clausulas, orden, true);
        }

        /// <summary>
        /// Gets the tipoClientes data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetEstadoMorosidadDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_ColumnName+"  = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.ESTADO_MOROSIDADCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.ESTADO_MOROSIDADCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetEstadoMorosidadDataTable

        #region GetEstadoMorosidadActivos
        /// <summary>
        /// Gets the estadoMorosidad activos.
        /// </summary>
        /// <returns></returns>
        public DataTable GetEstadoMorosidadActivos()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.ESTADO_MOROSIDADCollection.GetAsDataTable(Estado_ColumnName + " ='" + Definiciones.Estado.Activo + "' ", "upper(" + Nombre_ColumnName + ")");
                return table;
            }
        }
        #endregion GetEstadoMorosidadActivos

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
                    ESTADO_MOROSIDADRow row = new ESTADO_MOROSIDADRow();
                    String valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("estado_morosidad_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ORDEN = row.ID;
                    }
                    else
                    {
                        row = sesion.Db.ESTADO_MOROSIDADCollection.GetRow(ID_ColumnName + " = " + decimal.Parse((string)campos[ID_ColumnName]));
                        valorAnterior = row.ToString();
                    }

                    row.CODIGO = (string)campos[Codigo_ColumnName];
                    row.NOMBRE = (string)campos[Nombre_ColumnName];
                    row.ESTADO = (string)campos[Estado_ColumnName];
                    row.ENTIDAD_ID = decimal.Parse(sesion.EntidadActual_Id);

                    if (campos.Contains(Orden_ColumnName))
                        row.ORDEN = decimal.Parse(campos[Orden_ColumnName].ToString());

                    if (insertarNuevo) sesion.Db.ESTADO_MOROSIDADCollection.Insert(row);
                    else sesion.Db.ESTADO_MOROSIDADCollection.Update(row);

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
            get { return "ESTADO_MOROSIDAD"; }
        }
        public static string ID_ColumnName
        {
            get { return ESTADO_MOROSIDADCollection.IDColumnName; }
        }
        public static string Codigo_ColumnName
        {
            get { return ESTADO_MOROSIDADCollection.CODIGOColumnName; }
        }
        public static string Nombre_ColumnName
        {
            get { return ESTADO_MOROSIDADCollection.NOMBREColumnName; }
        }
        public static string Estado_ColumnName
        {
            get { return ESTADO_MOROSIDADCollection.ESTADOColumnName; }
        }
        public static string Orden_ColumnName
        {
            get { return ESTADO_MOROSIDADCollection.ORDENColumnName; }
        }
        #endregion Accessors
    }
}
