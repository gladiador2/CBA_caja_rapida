using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Base
{
    public class LogActividadesService
    {
        #region GetUltimasActividades
        /// <summary>
        /// Gets the log actividades data table.
        /// </summary>
        /// <param name="tns_name">The tns_name.</param>
        /// <param name="cantidad_ultimas_actividades">The cantidad_ultimas_actividades.</param>
        /// <returns></returns>
        public static DataTable GetUltimasActividades(string tns_name, decimal cantidad_ultimas_actividades)
        {
            using (SessionService sesion = new SessionService())
            { 
                string clausulas;
                clausulas = "select " + LogActividadesService.FechaActividad_NombreCol + ", " + LogActividadesService.FechaProximaEstimada_NombreCol + " from " +
                            "    ( select * from " + LogActividadesService.Nombre_Tabla +
                            "       where " + LogActividadesService.TnsName_NombreCol + " = '" + tns_name + "' " +
                            "    order by " + LogActividadesService.FechaActividad_NombreCol + " desc " +
                            "    ) " +
                            " where rownum <= " + cantidad_ultimas_actividades;
                
                return sesion.Db.EjecutarQuery(clausulas);
            }
        }
        #endregion GetUltimasActividades

        #region GetDistintosTNSName
        /// <summary>
        /// Gets the name of the distintos TNS.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDistintosTNSName()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.GetDistintos(LogActividadesService.Nombre_Tabla, LogActividadesService.TnsName_NombreCol, string.Empty);
            }
        }
        #endregion GetDistintosTNSName

        #region Guardar
        /// <summary>
        /// Guardars the specified tns_name.
        /// </summary>
        /// <param name="tns_name">The tns_name.</param>
        /// <param name="fecha_proxima_estimada">The fecha_proxima_estimada.</param>
        /// <param name="identificador">The identificador.</param>
        public static void Guardar(string tns_name, DateTime fecha_proxima_estimada, string identificador)
        {
            using (SessionService sesion = new SessionService())
            {
                LOG_ACTIVIDADESRow row = new LOG_ACTIVIDADESRow();
                row.ID = sesion.Db.GetSiguienteSecuencia("log_actividades_sqc");
                row.FECHA_ACTIVIDAD = DateTime.Now;
                row.FECHA_PROXIMA_ESTIMADA = fecha_proxima_estimada;
                row.IDENTIFICADOR = identificador;
                row.IP = SessionService.GetClienteIP();
                row.TNS_NAME = tns_name;

                sesion.Db.LOG_ACTIVIDADESCollection.Insert(row);
            }
        }
        #endregion GetLogCamposDataTable

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "LOG_ACTIVIDADES"; }
        }
        public static string FechaActividad_NombreCol
        {
            get { return LOG_ACTIVIDADESCollection.FECHA_ACTIVIDADColumnName; }
        }
        public static string FechaProximaEstimada_NombreCol
        {
            get { return LOG_ACTIVIDADESCollection.FECHA_PROXIMA_ESTIMADAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return LOG_ACTIVIDADESCollection.IDColumnName; }
        }
        public static string Identificador_NombreCol
        {
            get { return LOG_ACTIVIDADESCollection.IDENTIFICADORColumnName; }
        }
        public static string Ip_NombreCol
        {
            get { return LOG_ACTIVIDADESCollection.IPColumnName; }
        }
        public static string TnsName_NombreCol
        {
            get { return LOG_ACTIVIDADESCollection.TNS_NAMEColumnName; }
        }
        #endregion Accessors
    }
}
