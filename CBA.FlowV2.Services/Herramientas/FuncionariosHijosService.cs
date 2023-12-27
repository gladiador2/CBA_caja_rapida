using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Herramientas
{
    public class FuncionariosHijosService
    {
        #region GetFuncionariosHijosInfoCompleta

        /// <summary>
        /// Gets the funcionarios hijos info completa.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public DataTable GetFuncionariosHijosInfoCompleta(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
               return sesion.Db.FUNC_HIJOS_INFO_COMPLCollection.GetAsDataTable(FuncionarioId_NombreCol+"="+funcionario_id,VistaEdad_NombreCol);
            }
        }
        #endregion GetFuncionariosHijosInfoCompleta

        #region GetCantidadHijosMenores
        /// <summary>
        /// Gets the cantidad hijos menores.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public decimal GetCantidadHijosMenores(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {

                FUNC_HIJOS_MENORESRow[] row;
                 
                row=sesion.Db.FUNC_HIJOS_MENORESCollection.GetAsArray(FuncionarioId_NombreCol + "=" + funcionario_id,string.Empty);
                if (row.Length == 1) return row[0].CANTIDAD;
                else return Definiciones.Error.Valor.EnteroPositivo;
            }
        }
        #endregion GetCantidadHijosMenores
        
        #region Borrar
        /// <summary>
        /// Borrars the specified funcionario_hijo_id.
        /// </summary>
        /// <param name="funcionario_hijo_id">The funcionario_hijo_id.</param>
        public void Borrar(decimal funcionario_hijo_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    FUNCIONARIOS_HIJOSRow row = new FUNCIONARIOS_HIJOSRow();
                    row = sesion.Db.FUNCIONARIOS_HIJOSCollection.GetByPrimaryKey(funcionario_hijo_id);
                    String valorAnterior = row.ToString();

                   
                    sesion.Db.FUNCIONARIOS_HIJOSCollection.Delete(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

                    sesion.Db.CommitTransaction();
                }
                
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

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

                    FUNCIONARIOS_HIJOSRow row = new FUNCIONARIOS_HIJOSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.Db.GetSiguienteSecuencia("FUNCIONARIOS_HIJOS_SQC");
                    }
                    else
                    {
                        row = sesion.Db.FUNCIONARIOS_HIJOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.FUNCIONARIO_ID = decimal.Parse(campos[FuncionarioId_NombreCol].ToString());
                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.FECHA_NACIMIENTO = DateTime.Parse(campos[FechaNacimiento_NombreCol].ToString());

                    if (insertarNuevo) sesion.Db.FUNCIONARIOS_HIJOSCollection.Insert(row);
                    else sesion.Db.FUNCIONARIOS_HIJOSCollection.Update(row);

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
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "FUNCIONARIOS_HIJOS"; }
        }
        public static string Id_NombreCol
        { get { return FUNCIONARIOS_HIJOSCollection.IDColumnName; } }
        public static string Nombre_NombreCol
        { get { return FUNCIONARIOS_HIJOSCollection.NOMBREColumnName; } }
        public static string FechaNacimiento_NombreCol
        { get { return FUNCIONARIOS_HIJOSCollection.FECHA_NACIMIENTOColumnName; } }
        public static string FuncionarioId_NombreCol
        { get { return FUNCIONARIOS_HIJOSCollection.FUNCIONARIO_IDColumnName; } }
        #endregion Tabla

        #region Vista
        public static string VistaFuncionarioNombre_NombreCol
        { get { return FUNC_HIJOS_INFO_COMPLCollection.FUNCIONARIO_NOMBREColumnName; } }
        public static string VistaFuncionarioCodigo_NombreCol
        { get { return FUNC_HIJOS_INFO_COMPLCollection.FUNCIONARIO_CODIGOColumnName; } }
        public static string VistaEdad_NombreCol
        { get { return FUNC_HIJOS_INFO_COMPLCollection.EDADColumnName; } }
        public static string VistaCantidadHijosMenores_NombreCol
        { get { return FUNC_HIJOS_MENORESCollection.CANTIDADColumnName; } }
        
        #endregion Vista
        #endregion Accessors
    }
}
