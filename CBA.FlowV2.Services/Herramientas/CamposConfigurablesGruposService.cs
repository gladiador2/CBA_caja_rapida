#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
#endregion using

namespace CBA.FlowV2.Services.Herramientas
{
    public class CamposConfigurablesGruposService
    {
        #region GetTablasDataTable
        public  static DataTable GetTablasDataTable() 
        {
            return GetTablasDataTable(string.Empty);
        }

        public static DataTable GetTablasDataTable(string clausulas)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = " 1=1 ";
                    if (clausulas != string.Empty) where += " and " + clausulas;

                    return sesion.Db.CAMPOS_CONFIGURABLES_GRUPOSCollection.GetAsDataTable(where, Nombre_NombreCol);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetTablasDataTable

        #region getTipoDato
        public static int getTipoDato(decimal grupo_id)
        {
            int tipoDato;
            using (CBAV2 db = new CBAV2())
            {
                tipoDato = (int)db.CAMPOS_CONFIGURABLES_GRUPOSCollection.GetByPrimaryKey(grupo_id).TIPO_DATO_ID;
            }
            return tipoDato;
        }
        #endregion getTipoDato

        #region GetTipoTextoPredefinidoId
        public static int GetTipoTextoPredefinidoId(decimal grupo_id)
        {
            int tipoTextoPredefinidoId;
            using (CBAV2 db = new CBAV2())
            {
                tipoTextoPredefinidoId = (int)db.CAMPOS_CONFIGURABLES_GRUPOSCollection.GetByPrimaryKey(grupo_id).TIPO_TEXTO_PREDEFINIDO_ID;
            }
            return tipoTextoPredefinidoId;
        }
        #endregion GetTipoTextoPredefinidoId

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CAMPOS_CONFIGURABLES_GRUPOS"; }
        }
        public static string Id_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_GRUPOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_GRUPOSCollection.NOMBREColumnName; }
        }
        public static string TipoDatoId_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_GRUPOSCollection.TIPO_DATO_IDColumnName; }
        }
        public static string TipoTextoPredefinidoId_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_GRUPOSCollection.TIPO_TEXTO_PREDEFINIDO_IDColumnName; }
        }
        #endregion Accessors

    }
}
