using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PersonasNivelesCreditoService
    {
        #region GetPersonasNivelesCreditoDataTable
        [Obsolete("utilizar metodos estaticos")]
        public DataTable GetPersonasNivelesCreditoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PERSONAS_NIVELES_CREDITOCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }

        public static DataTable GetPersonasNivelesCreditoDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService()) {
                DataTable table;
                table = sesion.Db.PERSONAS_NIVELES_CREDITOCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPersonasNivelesCreditoDataTable

        #region GetPersonasNivelesCredito
        public DataRow GetPersonasNivelesCredito(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string clausulas = Id_NombreCol + " = " + id.ToString();
                table = sesion.Db.PERSONAS_NIVELES_CREDITOCollection.GetAsDataTable(clausulas, string.Empty);
                return table.Rows[0];
            }
        }
        #endregion GetPersonasNivelesCredito

        #region GetCantidadDiasGracia
        /// <summary>
        /// Gets the cantidad dias gracia.
        /// </summary>
        /// <param name="nivel_credito_id">The nivel_credito_id.</param>
        /// <returns></returns>
        public static decimal GetCantidadDiasGracia(decimal nivel_credito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONAS_NIVELES_CREDITORow row = sesion.db.PERSONAS_NIVELES_CREDITOCollection.GetByPrimaryKey(nivel_credito_id);
                return row.DIAS_GRACIA;
            }
        }
        #endregion GetCantidadDiasGracia

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PERSONAS_NIVELES_CREDITO"; }
        }
        public static string Id_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITOCollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITOCollection.DESCRIPCIONColumnName; }
        }
        public static string DiasGracia_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITOCollection.DIAS_GRACIAColumnName; }
        }
        public static string LimiteCredito_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITOCollection.LIMITE_CREDITOColumnName; }
        }
        public static string LimiteInferiorCredito_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITOCollection.LIMITE_INFERIOR_CREDITOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITOCollection.NOMBREColumnName; }
        }
        public static string RolDesbloqueo1_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITOCollection.ROL_DESBLOQUEO1ColumnName; }
        }
        public static string RolDesbloqueo2_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITOCollection.ROL_DESBLOQUEO2ColumnName; }
        }
        public static string RolDesbloqueo3_NombreCol
        {
            get { return PERSONAS_NIVELES_CREDITOCollection.ROL_DESBLOQUEO3ColumnName; }
        }
        #endregion Accessors
    }
}
