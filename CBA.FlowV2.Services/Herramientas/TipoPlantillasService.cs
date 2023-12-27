using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TipoPlantillasService
    {
        #region GetTiposPlantilla



        /// <summary>
        /// Gets the tipos plantilla.
        /// </summary>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetTiposPlantilla( bool soloActivos) 
        {
            using(SessionService sesion = new SessionService())
            {
                string where = EntidadId_NombreCol +"="+sesion.EntidadActual_Id;
                if (soloActivos) where +=" and " +Estado_NombreCol + " = " + Definiciones.Estado.Activo;
                return sesion.Db.TIPOS_PLANTILLASCollection.GetAsDataTable(where,Id_NombreCol);
            }

        }
        #endregion GetTiposPlantilla

        #region EstaActivo

        public bool EstaActivo(decimal tipo_plantilla_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_PLANTILLASRow row = new TIPOS_PLANTILLASRow();
                row = sesion.Db.TIPOS_PLANTILLASCollection.GetByPrimaryKey(tipo_plantilla_id);
                bool estado = false;
                if (row.ESTADO.Equals(Definiciones.Estado.Activo)) estado = true;
                return estado;
            }

        }
        #endregion EstaActivo
     
        #region Constructor
        public TipoPlantillasService()
        {

        }
        #endregion Constructor

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TIPOS_PLANTILLAS"; }
        }
        public static string Id_NombreCol
        {
            get { return TIPOS_PLANTILLASCollection.IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TIPOS_PLANTILLASCollection.ESTADOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TIPOS_PLANTILLASCollection.NOMBREColumnName; }
        }
        public static string Decripcion_NombreCol
        {
            get { return TIPOS_PLANTILLASCollection.DESCRIPCIONColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return TIPOS_PLANTILLASCollection.ENTIDAD_IDColumnName; }
        }

        #endregion Accessors
    }
}
