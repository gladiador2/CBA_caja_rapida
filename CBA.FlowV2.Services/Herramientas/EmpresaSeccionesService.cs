using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EmpresaSeccionesService
    {
        #region EstaActivo

        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="empresa_seccion_id">The empresa_seccion_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal empresa_seccion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                EMPRESA_SECCIONESRow row = sesion.Db.EMPRESA_SECCIONESCollection.GetRow(EmpresaSeccionesService.Id_NombreCol + " = " + empresa_seccion_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetSeccionesDataTable

        /// <summary>
        /// Gets the secciones data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetSeccionesDataTable()
        {
            return GetSeccionesDataTable("", "upper("+ Nombre_NombreCol +")", false);
        }


        /// <summary>
        /// Gets the secciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetSeccionesDataTable(String clausulas, String orden)
        {
            return GetSeccionesDataTable(clausulas, orden, false);
        }


        /// <summary>
        /// Gets the secciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetSeccionesDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.EMPRESA_SECCIONESCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.EMPRESA_SECCIONESCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetSeccionesDataTable

        #region GetSeccion
        /// <summary>
        /// Gets the seccion.
        /// </summary>
        /// <param name="seccion_id">The seccion_id.</param>
        /// <returns></returns>
        public DataTable GetSeccion(decimal seccion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.EMPRESA_SECCIONESCollection.GetAsDataTable(Id_NombreCol + " = " + seccion_id, "");
                return tabla;
            }
        }
        #endregion GetSeccion

        #region GetSeccionesPorDpto
        /// <summary>
        /// Gets the secciones por dpto.
        /// </summary>
        /// <param name="departamento_id">The departamento_id.</param>
        /// <returns></returns>
        public DataTable GetSeccionesPorDpto(string departamento_id, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas;
                DataTable tabla;
                if (soloActivos)
                {
                    clausulas = EmpresaSeccionesService.EmpresaDepartamento_NombreCol + " = '" + departamento_id + "' and " + EmpresaSeccionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    tabla = sesion.Db.EMPRESA_SECCIONESCollection.GetAsDataTable(clausulas, string.Empty);
                }
                else
                {
                    clausulas = EmpresaSeccionesService.EmpresaDepartamento_NombreCol + " = '" + departamento_id + "' ";
                    tabla = sesion.Db.EMPRESA_SECCIONESCollection.GetAsDataTable(clausulas, string.Empty);
                }
                return tabla;
            }
        }
        #endregion GetSeccionesPorDpto

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

                    EMPRESA_SECCIONESRow row = new EMPRESA_SECCIONESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("empresa_secciones_sqc");
                        row.ORDEN = row.ID;
                        //El nombre es el ID principal, por lo que no puede
                        //modificarse si el registro ya estaba creado
                        
                    }
                    else
                    {
                        row = sesion.Db.EMPRESA_SECCIONESCollection.GetRow(Id_NombreCol + "  =  " + campos[Id_NombreCol].ToString());
                        valorAnterior = row.ToString();
                    }
                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    if(campos.Contains(Descripcion_NombreCol))row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.EMPRESA_DEPARTAMENTO_ID = campos[EmpresaDepartamento_NombreCol].ToString();
                    if (campos.Contains(Orden_NombreCol)) row.ORDEN = decimal.Parse(campos[Orden_NombreCol].ToString());

                    if (insertarNuevo) sesion.Db.EMPRESA_SECCIONESCollection.Insert(row);
                    else sesion.Db.EMPRESA_SECCIONESCollection.Update(row);

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
            get { return "EMPRESA_SECCIONES"; }
        }
        public static string Descripcion_NombreCol
        { get { return EMPRESA_SECCIONESCollection.DESCRIPCIONColumnName; } }
        
        public static string EmpresaDepartamento_NombreCol
        { get { return EMPRESA_SECCIONESCollection.EMPRESA_DEPARTAMENTO_IDColumnName; } }
        
        public static string Estado_NombreCol
        { get { return EMPRESA_SECCIONESCollection.ESTADOColumnName; } }

        public static string Id_NombreCol
        { get { return EMPRESA_SECCIONESCollection.IDColumnName; } }

        public static string Nombre_NombreCol
        { get { return EMPRESA_SECCIONESCollection.NOMBREColumnName; } }

        public static string Orden_NombreCol
        { get { return EMPRESA_SECCIONESCollection.ORDENColumnName; } }

      

        #endregion Accessors
    }
}
