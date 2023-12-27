using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.General
{
    public class TablasService
    {
        #region GetTablasDataTable
        public  DataTable GetTablasDataTable() 
        {
            return GetTablasDataTable(string.Empty);
        }

        public static DataTable GetTablasDataTableStatic(string clausulas)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = " 1=1 ";
                    if (clausulas != string.Empty) where += " and " + clausulas;

                    return sesion.Db.TABLASCollection.GetAsDataTable(where, Nombre_NombreCol);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public DataTable GetTablasDataTable(string clausulas)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = " 1=1 ";
                    if (clausulas != string.Empty) where += " and " + clausulas;

                    return sesion.Db.TABLASCollection.GetAsDataTable(where, Nombre_NombreCol);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetTablasDataTable

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TABLAS"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return TABLASCollection.DESCRIPCIONColumnName; }
        }



        public static string Nombre_NombreCol
        {
            get { return TABLASCollection.NOMBREColumnName; }
        }
        #endregion Accessors

    }
}
