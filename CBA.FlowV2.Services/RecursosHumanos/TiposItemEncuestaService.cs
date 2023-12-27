using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class TiposItemEncuestaService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="tipo_item_encuesta_id">The tipo_item_encuesta_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal tipo_item_encuesta_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_ITEM_ENCUESTARow row = sesion.Db.TIPOS_ITEM_ENCUESTACollection.GetByPrimaryKey(tipo_item_encuesta_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo

        #region GetTiposItemEncuestaDataTable
        /// <summary>
        /// Gets the tipos item encuesta data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetTiposItemEncuestaDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TIPOS_ITEM_ENCUESTACollection.GetAsDataTable("","upper(nombre)");
            }
        }
        #endregion GetTiposItemEncuestaDataTable

        #region Nombre de Columnas
        public static string TiposItemEncuestaId_NombreCol
        {
            get { return TIPOS_ITEM_ENCUESTACollection.IDColumnName; }
        }

        public static string TiposItemEncuestaNombre_NombreCol
        {
            get { return TIPOS_ITEM_ENCUESTACollection.NOMBREColumnName; }
        }

        public static string TiposItemEncuestaDescripcion_NombreCol
        {
            get { return TIPOS_ITEM_ENCUESTACollection.DESCRIPCIONColumnName; }
        }

        public static string TiposItemEncuestaEstado_NombreCol
        {
            get { return TIPOS_ITEM_ENCUESTACollection.ESTADOColumnName; }
        }
        #endregion Nombre de Columnas
    }
}
