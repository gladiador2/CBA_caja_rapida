using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PermisosAceleradorService
    {
        #region GetPermisosAceleradorDataTable
        /// <summary>
        /// Gets the permisos visualizacion flujos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <returns></returns>
        public static DataTable GetPermisosVisualizacionFlujosDataTable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PERMISOS_ACELERADORCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }
        #endregion GetPermisosAceleradorDataTable

        #region Metodos Estaticos
        public static string Nombre_Vista
        { get { return "PERMISOS_ACELERADOR"; } }

        public static string VistaEntidadId_NombreCol
        { 
            get { return PERMISOS_ACELERADORCollection.ENTIDAD_IDColumnName; } 
        }
        public static string VistaEstado_NombreCol
        {
            get { return PERMISOS_ACELERADORCollection.ESTADOColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return PERMISOS_ACELERADORCollection.FLUJO_IDColumnName; }
        }
        public static string VistaRolId_NombreCol
        {
            get { return PERMISOS_ACELERADORCollection.ROL_IDColumnName; }
        }
        public static string VistaTransicionOcurridaId_NombreCol
        {
            get { return PERMISOS_ACELERADORCollection.TRANSICION_OCURRIDA_IDColumnName; }
        }
        public static string VistaTransicionSiguienteId_NombreCol
        {
            get { return PERMISOS_ACELERADORCollection.TRANSICION_SIGUIENTE_IDColumnName; }
        }

        public static string VistaUsuarioId_NombreCol
        {
            get { return PERMISOS_ACELERADORCollection.USUARIO_IDColumnName; }
        }
        #endregion Metodos Estaticos
    }
}