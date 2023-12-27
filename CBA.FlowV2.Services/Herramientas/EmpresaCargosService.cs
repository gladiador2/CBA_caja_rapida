using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EmpresaCargosService
    {
        #region GetCargosDataTable
        /// <summary>
        /// Gets the cargos data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetCargosDataTable()
        {
            return GetCargosDataTable("", "upper("+VistaEmpresaSeccionesNombre_Columna+" || ' ' || "+Nombre_Columna+")", false);
        }

        /// <summary>
        /// Gets the cargos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCargosDataTable(String clausulas, String orden)
        {
            return GetCargosDataTable(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the cargos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetCargosDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = " estado = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.EMPRESA_CARGOS_INFO_COMPCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.EMPRESA_CARGOS_INFO_COMPCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }

        public static DataTable GetCargosDatable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.EMPRESA_CARGOS_INFO_COMPCollection.GetAsDataTable(where, orderBy);
            }
        }

        public static DataTable GetCargosInfoCompleta() 
        {
            return GetCargosInfoCompleta(string.Empty);
        }
        public static DataTable GetCargosInfoCompleta(string where) 
        {
            return GetCargosInfoCompleta(where, string.Empty);
        }
        public static DataTable GetCargosInfoCompleta(string where, string orderBy) 
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.EMPRESA_CARGOS_INFO_COMPCollection.GetAsDataTable(where, orderBy);
            }
        }

        #endregion GetCargosDataTable

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="empresa_cargo_id">The empresa_cargo_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal empresa_cargo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                EMPRESA_CARGOSRow row = sesion.Db.EMPRESA_CARGOSCollection.GetRow(" id = " + empresa_cargo_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    EMPRESA_CARGOSRow row = new EMPRESA_CARGOSRow();
                    EMPRESA_SECCIONESRow SeccionRow = new EMPRESA_SECCIONESRow();
                    String valorAnterior = "";

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("empresa_cargos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.EMPRESA_CARGOSCollection.GetRow(Id_Columna +"= " + decimal.Parse(campos[Id_Columna].ToString()));
                        valorAnterior = row.ToString();
                    }


                    SeccionRow = sesion.Db.EMPRESA_SECCIONESCollection.GetByPrimaryKey(decimal.Parse(campos[EmpresaSeccionId_Columna].ToString()));
                    if (SeccionRow.ESTADO.Equals(Definiciones.Estado.Inactivo))
                        throw new System.Exception("La Seccion " + SeccionRow.NOMBRE+ " se encuentra inactiva.");
                   

                    row.EMPRESA_SECCION_ID = decimal.Parse(campos[EmpresaSeccionId_Columna].ToString());
                    row.NOMBRE = campos[Nombre_Columna].ToString();
                    row.DESCRIPCION = campos[Descripcion_Columna].ToString();
                    row.ESTADO = campos[Estado_Columna].ToString();
                    row.EMPRESA_FAJA_ID = decimal.Parse(campos[EmpresaFajaId_Columna].ToString());

                    if (insertarNuevo) sesion.Db.EMPRESA_CARGOSCollection.Insert(row);
                    else sesion.Db.EMPRESA_CARGOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro("empresa_cargos", row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe un cargo con el mismo nombre en el mismo departamento.");
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
            get { return "EMPRESA_CARGOS"; }
        }
        public static string Descripcion_Columna
        {
            get { return EMPRESA_CARGOSCollection.DESCRIPCIONColumnName; }
        }
        public static string EmpresaSeccionId_Columna
        {
            get { return EMPRESA_CARGOSCollection.EMPRESA_SECCION_IDColumnName; }
        }
        public static string Estado_Columna
        {
            get { return EMPRESA_CARGOSCollection.ESTADOColumnName; }
        }
        public static string Id_Columna
        {
            get { return EMPRESA_CARGOSCollection.IDColumnName; }
        }
        public static string Nombre_Columna
        {
            get { return EMPRESA_CARGOSCollection.NOMBREColumnName; }
        }
        public static string EmpresaFajaId_Columna
        {
            get { return EMPRESA_CARGOSCollection.EMPRESA_FAJA_IDColumnName; }
        }
        public static string VistaEmpresaSeccionesNombre_Columna
        {
            get { return EMPRESA_CARGOS_INFO_COMPCollection.EMPRESA_SECCIONES_NOMBREColumnName; }
        }
        public static string VistaSeccionesDpto_Columna
        {
            get { return EMPRESA_CARGOS_INFO_COMPCollection.EMPRESA_DEPARTAMENTO_IDColumnName; }
        }
        public static string VistaEmpresaFajaNombre_Columna
        {
            get { return EMPRESA_CARGOS_INFO_COMPCollection.EMPRESA_FAJA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
