using CBA.FlowV2.Db;
using System.Data;
using System;
using CBA.FlowV2.Services.Sesion;


namespace CBA.FlowV2.Services.Base
{
    public class VariablesSistemaService
    {
        #region GetDescripcion
        public static string GetDescripcion(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDescripcion(id, sesion);
            }
        }

        /// <summary>
        /// Obtener la descripcion de la variable sistema
        /// </summary>
        /// <param name="variable_sistema_id">The variable_sistema_id.</param>
        /// <returns>La cadena de texto con el valor</returns>
        public static string GetDescripcion(decimal id, SessionService sesion)
        {
            DataTable dt;
            string clausulas;

            decimal entidadId = sesion.Entidad == null ? 1 : sesion.Entidad.ID;

            clausulas = Id_NombreCol + " = " + id;

            dt = sesion.Db.VARIABLES_SISTEMACollection.GetAsDataTable(clausulas, string.Empty);                        

            return dt.Rows[0][Descripcion_NombreCol].ToString();
        }
        #endregion GetDescripcion

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "VARIABLES_SISTEMA"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return VARIABLES_SISTEMACollection.DESCRIPCIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return VARIABLES_SISTEMACollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return VARIABLES_SISTEMACollection.NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
