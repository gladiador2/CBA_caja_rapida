using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TipoEventoCalendarioService
    {

        #region accesors
         public static string Nombre_Tabla
        { get { return "TIPO_EVENTO_CALENDARIO"; } }

        public static string Nombre_NombreCol
        { get { return TIPOS_EVENTO_CALENDARIOCollection.NOMBREColumnName; } }

        public static string Descripcion_NombreCol
        { get { return TIPOS_EVENTO_CALENDARIOCollection.DESCRIPCIONColumnName; } }

        public static string Laborable_NombreCol
        { get { return TIPOS_EVENTO_CALENDARIOCollection.LABORABLEColumnName; } }

        public static string Estado_NombreCol
        { get { return TIPOS_EVENTO_CALENDARIOCollection.ESTADOColumnName; } }

       
#endregion

        #region EstaActivo

        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="nombre">The nombre.</param>
        /// <returns></returns>
        public static bool EstaActivo(string nombre)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_EVENTO_CALENDARIORow row = sesion.Db.TIPOS_EVENTO_CALENDARIOCollection.GetRow(" " + TipoEventoCalendarioService.Nombre_NombreCol + "=" + nombre);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetTipoEventoCalendarioDataTable
     
        public DataTable GetTipoEventoCalendarioDataTable()
        {
            return GetTipoEventoCalendarioDataTable("", "upper("+TipoEventoCalendarioService.Nombre_NombreCol+")", false);
        }

       
        public DataTable GetTipoEventoCalendarioDataTable(string clausulas, string orden) 
        {
            return GetTipoEventoCalendarioDataTable(clausulas, orden, false);
        }

       
        public DataTable GetTipoEventoCalendarioDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = " "+TipoEventoCalendarioService.Estado_NombreCol +" = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.TIPOS_EVENTO_CALENDARIOCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.TIPOS_EVENTO_CALENDARIOCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetTipoEventoCalendarioDataTable

        #region GetTipoEventosCAlendarioActivos
        
        public DataTable GetTipoEventoCalendarioActivos()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TIPOS_EVENTO_CALENDARIOCollection.GetAsDataTable(TipoEventoCalendarioService.Estado_NombreCol+"='A' ", "upper("+TipoEventoCalendarioService.Nombre_NombreCol+")");
                return table;
            }
        }
        #endregion 

       
    }
}
