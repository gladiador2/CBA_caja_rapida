using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TiposVehiculoService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="tipo_vehiculo_id">The tipo_vehiculo_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal tipo_vehiculo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_VEHICULORow row = sesion.Db.TIPOS_VEHICULOCollection.GetByPrimaryKey(tipo_vehiculo_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetTiposVehiculoDataTable
        /// <summary>
        /// Gets the tipos vehiculo data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetTiposVehiculoDataTable()
        {
            return GetTiposVehiculoDataTable(string.Empty, TiposVehiculoService.Orden_NombreCol);
        }


        /// <summary>
        /// Gets the tipos vehiculo data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTiposVehiculos(string clausulas, string orden) 
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TIPOS_VEHICULOCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetTiposVehiculos()
        {
            return GetTiposVehiculos(string.Empty, TiposVehiculoService.Orden_NombreCol);
        }

        /// <summary>
        /// Gets the tipos vehiculo data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetTiposVehiculoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TIPOS_VEHICULOCollection.GetAsDataTable(clausulas, orden);
            }
        }
        public static string NombreTipoVehiculoPorId(decimal tipo_id )
        {
            using (SessionService sesion = new SessionService())
            {
                return NombreTipoVehiculoPorId(tipo_id,sesion);
            }
        }
        public static string NombreTipoVehiculoPorId(decimal tipo_id, SessionService sesion)
        {

            TIPOS_VEHICULORow row = sesion.Db.TIPOS_VEHICULOCollection.GetByPrimaryKey(tipo_id);
            if (row == null)
                return string.Empty;
            else
               return row.NOMBRE;
            
        }

        #endregion GetTiposVehiculoDataTable

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "TIPOS_VEHICULO"; }
        }
        public static string Estado_NombreCol
        {
            get { return TIPOS_VEHICULOCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TIPOS_VEHICULOCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TIPOS_VEHICULOCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return TIPOS_VEHICULOCollection.ORDENColumnName; }
        }
        #endregion Metodos estaticos
    }
}
