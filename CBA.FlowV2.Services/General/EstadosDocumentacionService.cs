using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.General
{
    public class EstadosDocumentacionService
    {
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="estado_documentacion_id">The estado_documentacion_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal estado_documentacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ESTADOS_DOCUMENTACIONRow estado = sesion.Db.ESTADOS_DOCUMENTACIONCollection.GetByPrimaryKey(estado_documentacion_id);
                return estado.ESTADO == Definiciones.Estado.Activo;
            }
        }

        /// <summary>
        /// Gets the estados data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetEstadosDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.ESTADOS_DOCUMENTACIONCollection.GetAsDataTable(string.Empty, EstadosDocumentacionService.Nombre_NombreCol);
                return table;
            }
        }

        public static DataTable GetEstadosDataTable(string clausulas, string order_by)
        {
            using (SessionService sesion = new SessionService()) {
                DataTable table = sesion.Db.ESTADOS_DOCUMENTACIONCollection.GetAsDataTable(clausulas, order_by);
                return table;
            }
        }

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ESTADO_DOCUMENTACION"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ESTADOS_DOCUMENTACIONCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ESTADOS_DOCUMENTACIONCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ESTADOS_DOCUMENTACIONCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ESTADOS_DOCUMENTACIONCollection.NOMBREColumnName; }
        }

        #endregion Accessors
    }
}
