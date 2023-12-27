using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PermisosVisualizacionFlujosService
    {
        #region GetPermisosVisualizacionFlujosDataTable
        /// <summary>
        /// Gets the permisos visualizacion flujos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <returns></returns>
        public static DataTable GetPermisosVisualizacionFlujosDataTable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PERMISOS_VISUALIZACION_FLUJOSCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }
        #endregion GetPermisosDataTable

        #region Metodos Estaticos
        public static string Nombre_Tabla
        { get { return "PERMISOS_VISUALIZACION_FLUJOS"; } }

        public static string EstadoId_NombreCol
        { 
            get { return PERMISOS_VISUALIZACION_FLUJOSCollection.ESTADO_IDColumnName; } 
        }
        public static string FlujoId_NombreCol
        {
            get { return PERMISOS_VISUALIZACION_FLUJOSCollection.FLUJO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PERMISOS_VISUALIZACION_FLUJOSCollection.IDColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return PERMISOS_VISUALIZACION_FLUJOSCollection.ROL_IDColumnName; }
        }

        public static string TipoEspecifico_NombreCol
        {
            get { return PERMISOS_VISUALIZACION_FLUJOSCollection.TIPO_ESPECIFICOColumnName; }
        }

        #endregion Metodos Estaticos
    }
}