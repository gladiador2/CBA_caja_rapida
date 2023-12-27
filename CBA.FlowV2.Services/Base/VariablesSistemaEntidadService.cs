using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Base
{
    public class VariablesSistemaEntidadService
    {
        #region GetValorStringWorkaround
        /// <summary>
        /// Gets the valor string sin sesion workaround.
        /// </summary>
        /// <param name="variable_sistema_id">The variable_sistema_id.</param>
        /// <returns></returns>
        public static string GetValorStringSinSesionWorkaround(decimal variable_sistema_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                string clausulas;

                clausulas = VariablesSistemaEntidadService.VariableSistemaId_NombreCol + " = " + variable_sistema_id;

                dt = sesion.Db.VARIABLES_SISTEMA_ENTIDADCollection.GetAsDataTable(clausulas, VariablesSistemaEntidadService.EntidadId_NombreCol);

                //Si la entidad no tiene un valor para la variable en cuestion
                //se lanza una excepcion
                if (dt.Rows.Count <= 0)
                    throw new Exception("La entidad no posee un valor para la variable de sistema " + variable_sistema_id + ".");

                return dt.Rows[0][VariablesSistemaEntidadService.Valor_NombreCol].ToString();
            }
        }
        #endregion GetValorStringWorkaround

        #region GetValorString
        public static string GetValorString(decimal variable_sistema_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetValorString(variable_sistema_id, sesion);
            }
        }
        
        /// <summary>
        /// Obtener el valor de la variable de sistema para la entidad. El valor es devuelto como cadena de texto
        /// </summary>
        /// <param name="variable_sistema_id">The variable_sistema_id.</param>
        /// <returns>La cadena de texto con el valor</returns>
        public static string GetValorString(decimal variable_sistema_id, SessionService sesion)
        {
            DataTable dt;
            string clausulas;

            decimal entidadId = sesion.Entidad == null ? 1 : sesion.Entidad.ID;

            clausulas = VariablesSistemaEntidadService.EntidadId_NombreCol + " = " + entidadId + " and " +
                        VariablesSistemaEntidadService.VariableSistemaId_NombreCol + " = " + variable_sistema_id;

            dt = sesion.Db.VARIABLES_SISTEMA_ENTIDADCollection.GetAsDataTable(clausulas, string.Empty);

            //Si la entidad no tiene un valor para la variable en cuestion
            //se lanza una excepcion
            if (dt.Rows.Count <= 0) 
                throw new Exception("La entidad no posee un valor para la variable de sistema " + variable_sistema_id + ".");

            return dt.Rows[0][VariablesSistemaEntidadService.Valor_NombreCol].ToString();
        }
        #endregion GetValorString

        #region GetValorDecimal
        public static decimal GetValorDecimal(decimal variable_sistema_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetValorDecimal(variable_sistema_id, sesion);
            }
        }

        /// <summary>
        /// Obtener el valor de la variable de sistema para la entidad. El valor es devuelto como decimal
        /// </summary>
        /// <param name="variable_sistema_id">The variable_sistema_id.</param>
        /// <returns></returns>
        public static decimal GetValorDecimal(decimal variable_sistema_id, SessionService sesion)
        {
            decimal valorDecimal;
            string valorStr;

            valorStr = GetValorString(variable_sistema_id, sesion);

            if (!decimal.TryParse(valorStr, out valorDecimal))
                throw new Exception("El valor de la variable de sistema no puede ser convertido a decimal.");

            return valorDecimal;
        }
        #endregion GetValorDecimal
        
        #region GetValorInt
        /// <summary>
        /// Obtener el valor de la variable de sistema para la entidad. El valor es devuelto como int
        /// </summary>
        /// <param name="variable_sistema_id">The variable_sistema_id.</param>
        /// <returns></returns>
        public static int GetValorInt(decimal variable_sistema_id)
        {
            return int.Parse(GetValorDecimal(variable_sistema_id).ToString());
        }
        #endregion GetValorInt

        #region GetVariablesSistemaEntidadInfoCompleta
        /// <summary>
        /// Gets the variables sistema entidad info completa.
        /// </summary>
        /// <returns></returns>
        public DataTable GetVariablesSistemaEntidadInfoCompleta(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return VariablesSistemaEntidadService.GetVariablesSistemaEntidadInfoCompleta(clausulas, string.Empty);
            }
        }

        /// <summary>
        /// Gets the variables sistema entidad info completa.
        /// </summary>
        /// <returns></returns>
        public DataTable GetVariablesSistemaEntidadInfoCompleta()
        {
            using (SessionService sesion = new SessionService())
            {
                return VariablesSistemaEntidadService.GetVariablesSistemaEntidadInfoCompleta(string.Empty, string.Empty);
            }
        }

        /// <summary>
        /// Gets the variables sistema entidad info completa.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVariablesSistemaEntidadInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetVariablesSistemaEntidadInfoCompleta(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the variables sistema entidad info completa.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVariablesSistemaEntidadInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            decimal entidadId = sesion.Entidad == null ? 1 : sesion.Entidad.ID;

            string where = VariablesSistemaEntidadService.EntidadId_NombreCol + " = " + entidadId;
            
            if (clausulas.Length > 0)
                where += " and " + clausulas;

            return sesion.Db.VARIABLES_SIS_ENT_INFO_COMPLCollection.GetAsDataTable(where, orden);
        }
        #endregion GetFacturaClienteInfoCompleta

        #region Guardar
        public static void Guardar(Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    VariablesSistemaEntidadService.Guardar(campos, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        /// <summary>
        /// Guardar the specified valor_id.
        /// </summary>
        /// <param name="valor_id">The valor_id.</param>
        
        public static void Guardar(Hashtable campos, SessionService sesion)
        {
            try
            {
                VARIABLES_SISTEMA_ENTIDADRow row = new VARIABLES_SISTEMA_ENTIDADRow();
                decimal entidadId = sesion.Entidad == null ? 1 : sesion.Entidad.ID;
                string where = VariablesSistemaEntidadService.EntidadId_NombreCol + " = " + entidadId + " and " +
                    VariableSistemaId_NombreCol + " = " + decimal.Parse((string)campos[VariableSistemaId_NombreCol]);

                string valorAnterior = string.Empty;
                row = sesion.Db.VARIABLES_SISTEMA_ENTIDADCollection.GetRow(where);
                valorAnterior = row.ToString();
                row.VALOR = campos[Valor_NombreCol].ToString();

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                sesion.db.VARIABLES_SISTEMA_ENTIDADCollection.Update(row);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "VARIABLES_SISTEMA_ENTIDAD"; }
        }
        public static string Nombre_Vista
        {
            get { return "VARIABLES_SIS_ENT_INFO_COMPL"; }
        }
        public static string EntidadId_NombreCol
        {
            get { return VARIABLES_SISTEMA_ENTIDADCollection.ENTIDAD_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return VARIABLES_SISTEMA_ENTIDADCollection.IDColumnName; }
        }
        public static string Valor_NombreCol
        {
            get { return VARIABLES_SISTEMA_ENTIDADCollection.VALORColumnName; }
        }
        public static string VariableSistemaId_NombreCol
        {
            get { return VARIABLES_SISTEMA_ENTIDADCollection.VARIABLE_SISTEMA_IDColumnName; }
        }        
        public static string VistaVariableSistemaNombre_NombreCol
        {
            get { return VARIABLES_SIS_ENT_INFO_COMPLCollection.VARIABLE_SISTEMA_NOMBREColumnName; }
        }
        public static string VistaVariableSistemaDescripcion_NombreCol
        {
            get { return VARIABLES_SIS_ENT_INFO_COMPLCollection.VARIABLE_SISTEMA_DESCRIPCIONColumnName; }
        }
        #endregion Accessors
    }
}
