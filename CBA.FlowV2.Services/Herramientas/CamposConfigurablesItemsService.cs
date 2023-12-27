#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
#endregion using

namespace CBA.FlowV2.Services.Herramientas
{
    public class CamposConfigurablesItemsService
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

                    return sesion.Db.CAMPOS_CONFIGURABLES_ITEMSCollection.GetAsDataTable(where, Nombre_NombreCol);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetTablasDataTable

        #region GetTablasDataTableInfoCompleta
        public static DataTable GetTablasDataTableInfoCompleta()
        {
            return GetTablasDataTableInfoCompleta(string.Empty);
        }

        public static DataTable GetTablasDataTableInfoCompleta(string clausulas)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = " 1=1 ";
                    if (clausulas != string.Empty) where += " and " + clausulas;

                    return sesion.Db.CAMPOS_CONF_ITEMS_INFO_COMPCollection.GetAsDataTable(where, Nombre_NombreCol);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetTablasDataTableInfoCompleta

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CAMPOS_CONFIGURABLES_ITEMS"; }
        }
        public static string Id_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_ITEMSCollection.IDColumnName; }
        }
        public static string CamposConfigurablesGrupoId_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_ITEMSCollection.CAMPOS_CONF_GRUPO_IDColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_ITEMSCollection.FLUJO_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_ITEMSCollection.NOMBREColumnName; }
        }
        public static string TablaId_NombreCol
        {
            get { return CAMPOS_CONFIGURABLES_ITEMSCollection.TABLA_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "CAMPOS_CONF_ITEMS_INFO_COMP"; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return CAMPOS_CONF_ITEMS_INFO_COMPCollection.FLUJO_IDColumnName; }
        }
        public static string VistaGrupoId_NombreCol
        {
            get { return CAMPOS_CONF_ITEMS_INFO_COMPCollection.CAMPOS_CONF_GRUPO_IDColumnName; }
        }
        public static string VistaTablaNombre_NombreCol
        {
            get { return CAMPOS_CONF_ITEMS_INFO_COMPCollection.TABLA_NOMBREColumnName; }
        }
        public static string VistaGrupoNombre_NombreCol
        {
            get { return CAMPOS_CONF_ITEMS_INFO_COMPCollection.GRUPO_NOMBREColumnName; }
        }
        public static string VistaFlujoNombre_NombreCol
        {
            get { return CAMPOS_CONF_ITEMS_INFO_COMPCollection.FLUJO_NOMBREColumnName; }
        }
        #endregion Vista

        #endregion Accessors

    }
}
