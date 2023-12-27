using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EmpresaDepartamentosService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="empresa_departamento_id">The empresa_departamento_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal empresa_departamento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                EMPRESA_DEPARTAMENTOSRow row = sesion.Db.EMPRESA_DEPARTAMENTOSCollection.GetRow(EmpresaDepartamentosService.Nombre_NombreCol + " = " + empresa_departamento_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetDepartamentosDataTable
        /// <summary>
        /// Gets the departamentos data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartamentosDataTable()
        {
            return GetDepartamentosDataTable("", "upper("+ Nombre_NombreCol +")", false);
        }

        /// <summary>
        /// Gets the departamentos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetDepartamentosDataTable(String clausulas, String orden)
        {
            return GetDepartamentosDataTable(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the departamentos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetDepartamentosDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = ESTADO_NombreColumn + " = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.EMPRESA_DEPARTAMENTOSCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.EMPRESA_DEPARTAMENTOSCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetDepartamentosDataTable

        #region GetDepartamento
        public DataTable GetDepartamento(String departamento_nombre)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.EMPRESA_DEPARTAMENTOSCollection.GetAsDataTable(Nombre_NombreCol + " = " + departamento_nombre, "");
                return tabla;
            }
        }
        #endregion GetDepartamento
        
        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    EMPRESA_DEPARTAMENTOSRow row = new EMPRESA_DEPARTAMENTOSRow();
                    String valorAnterior = "";

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        //El nombre es el ID principal, por lo que no puede
                        //modificarse si el registro ya estaba creado
                        row.NOMBRE = (string)campos[Nombre_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.EMPRESA_DEPARTAMENTOSCollection.GetRow(Nombre_NombreCol + "  = '" + (string)campos[Nombre_NombreCol] + "'");
                        valorAnterior = row.ToString();
                    }

                    row.DESCRIPCION = (string)campos[DESCRIPCION_NombreColumn];
                    row.ESTADO = (string)campos[ESTADO_NombreColumn];

                    if (insertarNuevo) sesion.Db.EMPRESA_DEPARTAMENTOSCollection.Insert(row);
                    else sesion.Db.EMPRESA_DEPARTAMENTOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe un registro con ese nombre.");
                        default: throw exp;
                    }
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "EMPRESA_DEPARTAMENTOS"; }
        }
        public static string Nombre_NombreCol
        { get { return EMPRESA_DEPARTAMENTOSCollection.NOMBREColumnName; } }

        public static string DESCRIPCION_NombreColumn
        { get { return EMPRESA_DEPARTAMENTOSCollection.DESCRIPCIONColumnName; } }

        public static string ESTADO_NombreColumn
        { get { return EMPRESA_DEPARTAMENTOSCollection.ESTADOColumnName; } }

        #endregion Accessors
    }
}
