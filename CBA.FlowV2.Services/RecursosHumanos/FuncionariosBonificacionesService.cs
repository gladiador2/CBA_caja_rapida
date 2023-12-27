#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class FuncionariosBonificacionesService
    {
        #region Propiedades
        private abstract class ColumnasImportadas
        {
            public const string CI = "CEDULA DE IDENTIDAD";
            public const string MONTO = "MONTO";
            public const string FECHA = "FECHA";
            public const string BONIFICACION = "MOTIVO DE BONIFICACION";
            public const string NOMBRE_COMPLETO = "NOMBRE Y APELLIDO";
            public const string OBSERVACIONES = "OBSERVACIONES";
        }
        #endregion

        #region EstaActivo

        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="bonificacion_id">The bonificacion_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal bonificacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOS_BONIFICACIONESRow row = sesion.Db.FUNCIONARIOS_BONIFICACIONESCollection.GetByPrimaryKey(bonificacion_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo

        # region SetLiquidacionAsociada
        /// <summary>
        /// Sets the liquidacion asociada. 
        /// </summary>
        /// <param name="bonificacionFuncionario_id">The bonificacion funcionario_id.</param>
        /// <param name="liquidacionAsociada_id">The liquidacion asociada_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void SetLiquidacionAsociada(decimal bonificacionFuncionario_id, decimal liquidacionAsociada_id, SessionService sesion)
        {
            
                
                FUNCIONARIOS_BONIFICACIONESRow row = sesion.Db.FUNCIONARIOS_BONIFICACIONESCollection.GetByPrimaryKey(bonificacionFuncionario_id);
                String valorAnterior = row.ToString();
                // se revisa si el nuevo valor es valido , sino se convierte a nul el valor de la liquidacion asociada
                if(!BonificacionesService.EsUnica(row.BONIFICACION_ID))return;
                if (liquidacionAsociada_id == Definiciones.Error.Valor.EnteroPositivo)
                {
                    row.IsLIQUIDACION_ASOCIADA_IDNull = true;

                }
                else
                {
                    row.LIQUIDACION_ASOCIADA_ID = liquidacionAsociada_id;
                }
                sesion.Db.FUNCIONARIOS_BONIFICACIONESCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                
           

        }
        #endregion SetLiquidacionAsociada

        #region GetFuncionariosBonificacionesDataTable

        /// <summary>
        /// Gets the funcionarios bonificaciones data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFuncionariosBonificacionesDataTable()
        {
            return GetFuncionariosBonificacionesDataTable(string.Empty, string.Empty, false);
        }

        /// <summary>
        /// Gets the funcionarios bonificaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFuncionariosBonificacionesDataTable(String clausulas, String orden)
        {
            return GetFuncionariosBonificacionesDataTable(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the funcionarios bonificaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetFuncionariosBonificacionesDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = "1=1";
                if (soloActivos)estado = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.FUNCIONARIOS_BONIFICACIONESCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.FUNCIONARIOS_BONIFICACIONESCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetFuncionariosBonificacionesDataTable

        #region GetFuncionariosBonificacionesInfoCompleta

        /// <summary>
        /// Gets the funcionarios bonificaciones data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFuncionariosBonificacionesInfoCompleta()
        {
            return GetFuncionariosBonificacionesInfoCompleta(string.Empty, string.Empty, false);
        }

        /// <summary>
        /// Gets the funcionarios bonificaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFuncionariosBonificacionesInfoCompleta(String clausulas, String orden)
        {
            return GetFuncionariosBonificacionesInfoCompleta(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the funcionarios bonificaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetFuncionariosBonificacionesInfoCompleta(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (soloActivos) estado += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.FUNCIONARIOS_BONIF_INFO_COMPLCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.FUNCIONARIOS_BONIF_INFO_COMPLCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetFuncionariosBonificacionesInfoCompleta

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
                    sesion.BeginTransaction();
                    decimal id = Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();
                    return id;
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                FUNCIONARIOS_BONIFICACIONESRow row = new FUNCIONARIOS_BONIFICACIONESRow();
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_bonif_sqc");
                    row.USUARIO_CREACION_ID = sesion.Usuario.ID;
                    row.ESTADO = (string)campos[Estado_NombreCol];
                }
                else
                {
                    row = sesion.Db.FUNCIONARIOS_BONIFICACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }

                row.ESTADO = (string)campos[Estado_NombreCol];
                if (row.BONIFICACION_ID.Equals(DBNull.Value) || row.BONIFICACION_ID != (decimal)campos[BonificacionId_NombreCol])
                {
                    if (!BonificacionesService.EstaActivo((decimal)campos[BonificacionId_NombreCol]))
                    {
                        throw new System.Exception(Traducciones.la_Bonificacion + " no está activa.");
                    }
                    else
                    {
                        row.BONIFICACION_ID = (decimal)campos[BonificacionId_NombreCol];
                    }
                }
                   
                if (row.FUNCIONARIO_ID.Equals(DBNull.Value) || row.FUNCIONARIO_ID != (decimal)campos[FuncionarioId_NombreCol])
                {
                    if (!FuncionariosService.EstaActivo((decimal)campos[FuncionarioId_NombreCol]))
                    {
                        throw new System.Exception("El funcionario no está activo.");
                    }
                    else 
                    {
                        row.FUNCIONARIO_ID = (decimal)campos[FuncionarioId_NombreCol];
                    }
                }
                
                row.FECHA_CREACION = (DateTime)campos[FechaCreacion_NombreCol];

                if (campos.Contains(EmpresaSeccionId_NombreCol))
                {
                    if (row.IsEMPRESA_SECCION_IDNull || row.EMPRESA_SECCION_ID != (decimal)campos[EmpresaSeccionId_NombreCol])
                    {
                        if (!EmpresaSeccionesService.EstaActivo((decimal)campos[EmpresaSeccionId_NombreCol]))
                        {
                            throw new System.Exception("La sección no está activa.");
                        }
                        else
                        {
                            row.EMPRESA_SECCION_ID = (decimal)campos[EmpresaSeccionId_NombreCol];
                        }
                    } 
                }
                
                row.OBSERVACION = (string)campos[Observacion_NombreCol];
                
                if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[FuncionariosBonificacionesService.MonedaId_NombreCol])
                {
                    if (!MonedasService.EstaActivo((decimal)campos[MonedaId_NombreCol]))
                    {
                        throw new System.Exception("La moneda se encuentra inactiva.");
                    }
                    else
                    {
                        row.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];
                        FUNCIONARIOSRow funcionarioRow = sesion.Db.FUNCIONARIOSCollection.GetByPrimaryKey(row.FUNCIONARIO_ID);
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(funcionarioRow.SUCURSAL_ID), row.MONEDA_ID, row.FECHA_CREACION, sesion);

                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");
                    }
                }
                
                row.MONTO = (decimal)campos[Monto_NombreCol];
                row.UTILIZAR_PORCENTAJE = (string)campos[UtilizarPorcentaje_NombreCol];
                                  
                if (insertarNuevo) sesion.Db.FUNCIONARIOS_BONIFICACIONESCollection.Insert(row);
                else sesion.Db.FUNCIONARIOS_BONIFICACIONESCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        throw new System.ArgumentException("Ya existe un registro con ese nombre.");
                    default: throw exp;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void GuardarDatosImportados(DataTable dtDatos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    foreach (DataRow dr in dtDatos.Rows)
                    {
                        if (decimal.Parse(dr[ColumnasImportadas.MONTO].ToString()) > 0)
                        {
                            decimal funcionarioId = FuncionariosService.GetFuncionarioIdPorNroDocumento(dr[ColumnasImportadas.CI].ToString());

                            if (funcionarioId != Definiciones.Error.Valor.EnteroPositivo)
                            {
                                string where = "upper(" + BonificacionesService.Nombre_NombreCol + ") like upper('%" + dr[ColumnasImportadas.BONIFICACION].ToString() + "%')";
                                where += " and " + BonificacionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                                DataTable dtBonificacion = BonificacionesService.GetBonificacionesDataTable(where, BonificacionesService.Id_NombreCol);

                                if (dtBonificacion.Rows.Count > 0)
                                {
                                    FUNCIONARIOS_BONIFICACIONESRow row = new FUNCIONARIOS_BONIFICACIONESRow();
                                    String valorAnterior = string.Empty;

                                    valorAnterior = Definiciones.Log.RegistroNuevo;
                                    row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_bonif_sqc");
                                    row.USUARIO_CREACION_ID = sesion.Usuario.ID;
                                    row.ESTADO = Definiciones.Estado.Activo;

                                    if (!FuncionariosService.EstaActivo(funcionarioId))
                                        throw new Exception("El funcionario no está activo.");
                                    else
                                        row.FUNCIONARIO_ID = funcionarioId;

                                    if (dr[ColumnasImportadas.FECHA].ToString() != string.Empty)
                                        row.FECHA_CREACION = DateTime.Parse(dr[ColumnasImportadas.FECHA].ToString());
                                    else
                                        row.FECHA_CREACION = DateTime.Now;

                                    row.BONIFICACION_ID = (decimal)dtBonificacion.Rows[0][BonificacionesService.Id_NombreCol];
                                    row.OBSERVACION = dr[ColumnasImportadas.OBSERVACIONES].ToString();
                                    row.MONEDA_ID = FuncionariosService.GetMonedaSalario(funcionarioId);
                                    FUNCIONARIOSRow funcionarioRow = sesion.Db.FUNCIONARIOSCollection.GetByPrimaryKey(row.FUNCIONARIO_ID);
                                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(funcionarioRow.SUCURSAL_ID), row.MONEDA_ID, row.FECHA_CREACION, sesion);
                                    
                                    row.MONTO = decimal.Parse(dr[ColumnasImportadas.MONTO].ToString());                                   
                                    row.UTILIZAR_PORCENTAJE = Definiciones.SiNo.No;

                                    sesion.Db.FUNCIONARIOS_BONIFICACIONESCollection.Insert(row);

                                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);
                                }
                                else
                                {
                                    throw new Exception("El motivo de bonificación " + dr[ColumnasImportadas.BONIFICACION].ToString() + " no se encuentra activo o disponible en el sistema ");
                                }
                            }
                            else
                            {
                                throw new Exception("No se ha encontrado al funcionario " + dr[ColumnasImportadas.NOMBRE_COMPLETO].ToString() + " con cedula " + dr[ColumnasImportadas.CI].ToString());
                            }
                        }
                    }

                    sesion.Db.CommitTransaction();
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
            get { return "FUNCIONARIOS_BONIFICACIONES"; }
        }
        public static string BonificacionId_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.BONIFICACION_IDColumnName; } }

        public static string CotizacionMoneda_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.COTIZACION_MONEDAColumnName; } }

        public static string EmpresaSeccionId_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.EMPRESA_SECCION_IDColumnName; } }

        public static string Estado_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.ESTADOColumnName; } }

        public static string FechaCreacion_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.FECHA_CREACIONColumnName; } }

        public static string FuncionarioId_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.FUNCIONARIO_IDColumnName; } }

        public static string Id_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.IDColumnName; } }

        public static string LiquidacionAsociadaId_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.LIQUIDACION_ASOCIADA_IDColumnName; } }

        public static string MonedaId_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.MONEDA_IDColumnName; } }

        public static string Monto_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.MONTOColumnName; } }

        public static string Observacion_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.OBSERVACIONColumnName; } }

        public static string UsuarioCreacionId_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.USUARIO_CREACION_IDColumnName; } }

        public static string UtilizarPorcentaje_NombreCol
        { get { return FUNCIONARIOS_BONIFICACIONESCollection.UTILIZAR_PORCENTAJEColumnName; } }
       
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "funcionarios_bonif_info_compl"; }
        }
        
        public static string VistaBonificacionNombre_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.BONIFICACION_NOMBREColumnName; } }

        public static string VistaBonificacionUnica_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.BONIFICAION_UNICAColumnName; } }

        public static string VistaEmpresaDepartamento_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.EMPRESA_DEPARTAMENTO_IDColumnName; } }

        public static string VistaEmpresaSeccionNombre_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.EMPRESA_SECCION_NOMBREColumnName; } }

        public static string VistaEntidadId_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.ENTIDAD_IDColumnName; } }

        public static string VistaFuncionarioNombre_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.FUNCIONARIO_NOMBREColumnName; } }

        public static string VistaMonedaNombre_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.MONEDA_NOMBREColumnName; } }

        public static string VistaMonedaSimbolo_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; } }
        public static string VistaMonedaCantidadDecimales_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.MONEDA_CANTIDA_DECIMALESColumnName; } }
        public static string VistaMonedaCadenaDecimales_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.MONEDA_CADENA_DECIMALESColumnName; } }

        public static string VistaSucursalAbreviatura_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.SUCURSAL_ABREVIATURAColumnName; } }

        public static string VistaSucursalNombre_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; } }

        public static string VistaUsuarioCreacionNombre_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.USUARIO_CREACION_NOMBREColumnName; } }

        public static string VistaDescontar_NombreCol
        { get { return FUNCIONARIOS_BONIF_INFO_COMPLCollection.DESCONTARColumnName; } }
        #endregion Vista
        #endregion Accessors
    }
}
