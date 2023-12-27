using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EmpresaCargosFuncionariosService
    {
        #region GetEmpresaCargosFuncionariosInfoCompleta

        /// <summary>
        /// Gets the empresa cargos funcionarios info completa.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public static DataTable GetEmpresaCargosFuncionariosInfoCompleta(decimal funcionario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEmpresaCargosFuncionariosInfoCompleta(funcionario_id, sesion);
            }
        }

        public static DataTable GetEmpresaCargosFuncionariosInfoCompleta(decimal funcionario_id, SessionService sesion)
        {
            string where = FuncionarioId_NombreCol + " = " + funcionario_id;
            return GetEmpresaCargosFuncionariosInfoCompleta(where, sesion);
        }

        public static DataTable GetEmpresaCargosFuncionariosInfoCompleta(string where)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEmpresaCargosFuncionariosInfoCompleta(where, sesion);
            }
        }

        public static DataTable GetEmpresaCargosFuncionariosInfoCompleta(string where, SessionService sesion)
        {
            return sesion.Db.EMPRESA_CARGOS_FUNC_INFO_COMPCollection.GetAsDataTable(where, PorcentajeCargo_NombreCol);
        }

        public static DataTable GetEmpresaCargosFuncionariosDataTable()
        {
            return GetEmpresaCargosFuncionariosDataTable(string.Empty);
        }

        public static DataTable GetEmpresaCargosFuncionariosDataTable(string where)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.EMPRESA_CARGOS_FUNCIONARIOSCollection.GetAsDataTable(where, string.Empty);
            }
        }

        #endregion GetEmpresaCargosFuncionariosInfoCompleta

        #region GetFuncionariosPorSeccionInfoCompleta

        /// <summary>
        /// Gets the funcionarios por seccion info completa.
        /// </summary>
        /// <param name="seccion_id">The seccion_id.</param>
        /// <returns></returns>
        public DataTable GetFuncionariosPorSeccionInfoCompleta(decimal seccion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = VistaEmpresaSeccionesId_NombreCol + " = " + seccion_id;
                return sesion.Db.EMPRESA_CARGOS_FUNC_INFO_COMPCollection.GetAsDataTable(where, string.Empty);
            }
        }

        #endregion GetFuncionariosPorSeccionInfoCompleta

        #region GetFuncionariosPorDepartamentoInfoCompleta

        /// <summary>
        /// Gets the funcionarios por seccion info completa.
        /// </summary>
        /// <param name="seccion_id">The seccion_id.</param>
        /// <returns></returns>
        public static DataTable GetFuncionariosPorDepartamentoInfoCompleta(string depto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = VistaEmpresaDepartamentoId_NombreCol + " = '" + depto_id + "'";
                return sesion.Db.EMPRESA_CARGOS_FUNC_INFO_COMPCollection.GetAsDataTable(where, string.Empty);
            }
        }

        #endregion GetFuncionariosPorSeccionInfoCompleta

        #region CalcularPorcentajes
        /// <summary>
        /// Calculars the porcentajes.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <returns></returns>
        public decimal CalcularPorcentajes(decimal funcionario_id)
        {
            decimal porcentaje = 0;
            using (SessionService sesion = new SessionService())
            {
                EMPRESA_CARGOS_FUNCIONARIOSRow[] row = sesion.Db.EMPRESA_CARGOS_FUNCIONARIOSCollection.GetByFUNCIONARIO_ID(funcionario_id);
                for (int i = 0; i < row.Length; i++)
                {
                    porcentaje += row[i].PORCENTAJE_CARGO; 
                }
            }
            return porcentaje;
        }
        #endregion CalcularPorcentajes

        #region Agregar
        /// <summary>
        /// Agregars the specified funcionario_id.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <param name="empresa_cargo_id">The empresa_cargo_id.</param>
        public void Agregar(decimal funcionario_id, decimal empresa_cargo_id, decimal porcentaje)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    EMPRESA_CARGOS_FUNCIONARIOSRow row = new EMPRESA_CARGOS_FUNCIONARIOSRow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.FUNCIONARIO_ID = funcionario_id;
                    row.EMPRESA_CARGO_ID = empresa_cargo_id;
                    row.PORCENTAJE_CARGO = porcentaje;

                    if (!FuncionariosService.EstaActivo(funcionario_id))
                        throw new System.ArgumentException("El funcionario se encuentra inactivo. Los cambios no fueron guardados.");

                    if (!EmpresaCargosService.EstaActivo(empresa_cargo_id))
                        throw new System.ArgumentException("El cargo seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    decimal totalPorcentaje = CalcularPorcentajes(funcionario_id) + porcentaje;
                    if (totalPorcentaje > 100)
                        throw new System.ArgumentException("El porcentaje no debe ser mayor a 100 %");
                    sesion.Db.EMPRESA_CARGOS_FUNCIONARIOSCollection.Insert(row);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.FUNCIONARIO_ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Agregar

        #region Quitar
        /// <summary>
        /// Quitars the specified funcionario_id.
        /// </summary>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <param name="empresa_cargo_id">The empresa_cargo_id.</param>
        public void Quitar(decimal funcionario_id, decimal empresa_cargo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    EMPRESA_CARGOS_FUNCIONARIOSRow[] rows;
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    string where = FuncionarioId_NombreCol + " = " + funcionario_id + " and " + 
                                   EmpresaCargoId_NombreCol + " = " + empresa_cargo_id;

                    rows = sesion.Db.EMPRESA_CARGOS_FUNCIONARIOSCollection.GetAsArray(where, string.Empty);

                    sesion.Db.EMPRESA_CARGOS_FUNCIONARIOSCollection.Delete(rows[0]);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rows[0].FUNCIONARIO_ID, rows[0].ToString(), valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Quitar

        #region Accessors
        public static string Nombre_Tabla
        { get { return "EMPRESA_CARGOS_FUNCIONARIOS"; } }
        public static string EmpresaCargoId_NombreCol
        { get { return EMPRESA_CARGOS_FUNCIONARIOSCollection.EMPRESA_CARGO_IDColumnName; } }
        public static string FuncionarioId_NombreCol
        { get { return EMPRESA_CARGOS_FUNCIONARIOSCollection.FUNCIONARIO_IDColumnName; } }
        public static string PorcentajeCargo_NombreCol
        { get { return EMPRESA_CARGOS_FUNCIONARIOSCollection.PORCENTAJE_CARGOColumnName; } }
        public static string VistaEmpresaCargoNombre_NombreCol
        { get { return EMPRESA_CARGOS_FUNC_INFO_COMPCollection.EMPRESA_CARGO_NOMBREColumnName; } }
        public static string VistaEmpresaDepartamentoId_NombreCol
        { get { return EMPRESA_CARGOS_FUNC_INFO_COMPCollection.EMPRESA_DEPARTAMENTO_IDColumnName; } }
        public static string VistaFuncionarioApellido_NombreCol
        { get { return EMPRESA_CARGOS_FUNC_INFO_COMPCollection.FUNCIONARIO_APELLIDOColumnName; } }
        public static string VistaFuncionarioNombreCompleto_NombreCol
        { get { return EMPRESA_CARGOS_FUNC_INFO_COMPCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; } }
        public static string VistaFuncionarioNombre_NombreCol
        { get { return EMPRESA_CARGOS_FUNC_INFO_COMPCollection.FUNCIONARIO_NOMBREColumnName; } }
        public static string VistaEmpresaSeccionesId_NombreCol
        { get { return EMPRESA_CARGOS_FUNC_INFO_COMPCollection.EMPRESA_SECCION_IDColumnName; } }
        public static string VistaEmpresaSeccionesNombre_NombreCol
        { get { return EMPRESA_CARGOS_FUNC_INFO_COMPCollection.EMPRESA_SECCIONES_NOMBREColumnName; } }
        public static string VistaFuncionarioMarcacionesId_NombreCol
        { get { return EMPRESA_CARGOS_FUNC_INFO_COMPCollection.MARCACIONES_IDColumnName; } }
        #endregion Accessors
    }
}
