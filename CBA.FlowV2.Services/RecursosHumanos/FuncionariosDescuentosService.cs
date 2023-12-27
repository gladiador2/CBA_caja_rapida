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
    public class FuncionariosDescuentosService
    {
        #region Propiedades
        private abstract class ColumnasImportadas
        {
            public const string CI = "CEDULA DE IDENTIDAD";
            public const string MONTO = "MONTO";
            public const string FECHA = "FECHA";
            public const string DESCUENTO = "MOTIVO DE DESCUENTO";
            public const string NOMBRE_COMPLETO = "NOMBRE Y APELLIDO";
            public const string OBSERVACIONES = "OBSERVACIONES";
        }
        #endregion

        #region EstaActivo

        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="descuento_id">The descuento_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal descuento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FUNCIONARIOS_DESCUENTOSRow row = sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.GetByPrimaryKey(descuento_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo

        #region GetFuncionariosDescuentosDataTable

        /// <summary>
        /// Gets the funcionarios descuentos data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetFuncionariosDescuentosDataTable()
        {
            return GetFuncionariosDescuentosDataTable(string.Empty, string.Empty, false);
        }

        /// <summary>
        /// Gets the funcionarios descuentos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetFuncionariosDescuentosDataTable(String clausulas, String orden)
        {
            return GetFuncionariosDescuentosDataTable(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the funcionarios descuentos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetFuncionariosDescuentosDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFuncionariosDescuentosDataTable(clausulas, orden, soloActivos, sesion);
            }
        }

        public DataTable GetFuncionariosDescuentosDataTable(String clausulas, String orden, bool soloActivos, SessionService sesion)
        {
            DataTable table;
            String estado = "1=1";
            if (soloActivos) estado = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            if (!clausulas.Equals(string.Empty))
            {
                table = sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.GetAsDataTable(clausulas + " and " + estado, orden);
            }
            else
            {
                table = sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.GetAsDataTable(estado, orden);
            }
            return table;
        }
        #endregion GetFuncionariosDescuentosDataTable

        #region GetFuncionariosDescuentosInfoCompleta

        /// <summary>
        /// Gets the funcionarios descuentos info completa.
        /// </summary>
        /// <returns></returns>
        public DataTable GetFuncionariosDescuentosInfoCompleta()
        {
            return GetFuncionariosDescuentosInfoCompleta(string.Empty, string.Empty, false);
        }

        /// <summary>
        /// Gets the funcionarios descuentos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetFuncionariosDescuentosInfoCompleta(String clausulas, String orden)
        {
            return GetFuncionariosDescuentosInfoCompleta(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the funcionarios descuentos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetFuncionariosDescuentosInfoCompleta(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (soloActivos) estado += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.FUNCIONARIOS_DESC_INFO_COMPLCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.FUNCIONARIOS_DESC_INFO_COMPLCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetFuncionariosDescuentosInfoCompleta

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
                    sesion.db.BeginTransaction();
                    decimal exito = Guardar(campos, insertarNuevo, sesion);
                    sesion.db.CommitTransaction();
                    
                    return exito;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                FUNCIONARIOS_DESCUENTOSRow row = new FUNCIONARIOS_DESCUENTOSRow();
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_desc_sqc");
                    row.USUARIO_CREACION_ID = sesion.Usuario.ID;
                }
                else
                {
                    row = sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }

                if (campos.Contains(FuncionariosDescuentosService.FechaCreacion_NombreCol))
                    row.FECHA_CREACION = DateTime.Parse(campos[FuncionariosDescuentosService.FechaCreacion_NombreCol].ToString());
                else
                    row.FECHA_CREACION = DateTime.Now;

                row.ESTADO = (string)campos[Estado_NombreCol];

                if (row.DESCUENTO_ID.Equals(DBNull.Value) || row.DESCUENTO_ID != (decimal)campos[DescuentoId_NombreCol])
                {
                    if (!DescuentosService.EstaActivo((decimal)campos[DescuentoId_NombreCol]))
                    {
                        throw new System.Exception("El descuento no está activo.");
                    }
                    else
                    {
                        row.DESCUENTO_ID = (decimal)campos[DescuentoId_NombreCol];
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

                if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != decimal.Parse(campos[FuncionariosDescuentosService.MonedaId_NombreCol].ToString()))
                {
                    if (!MonedasService.EstaActivo(decimal.Parse(campos[MonedaId_NombreCol].ToString())))
                    {
                        throw new System.Exception("La moneda se encuentra inactiva.");
                    }
                    else
                    {
                        row.MONEDA_ID = decimal.Parse(campos[MonedaId_NombreCol].ToString());
                        FUNCIONARIOSRow funcionarioRow = sesion.Db.FUNCIONARIOSCollection.GetByPrimaryKey(row.FUNCIONARIO_ID);
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(funcionarioRow.SUCURSAL_ID), row.MONEDA_ID, row.FECHA_CREACION, sesion);

                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");
                    }
                }

                if (campos.Contains(ConsumoVisitas_NombreCol))
                {
                    row.CONSUMO_VISITAS = (string)campos[ConsumoVisitas_NombreCol];
                }
                else
                    row.CONSUMO_VISITAS = Definiciones.SiNo.No;

                if (campos.Contains(CasoOrigenId_NombreCol))
                    row.CASO_ORIGEN_ID = decimal.Parse(campos[CasoOrigenId_NombreCol].ToString());

                row.MONTO = (decimal)campos[Monto_NombreCol];
                row.UTILIZAR_PORCENTAJE = (string)campos[UtilizarPorcentaje_NombreCol];

                if (insertarNuevo) sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.Insert(row);
                else sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.Update(row);

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
                                string where = "upper(" + DescuentosService.Nombre_NombreCol + ") like upper('%" + dr[ColumnasImportadas.DESCUENTO].ToString() + "%')";
                                where += " and " + DescuentosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                                DataTable dtDescuento = DescuentosService.GetDescuentosDataTable(where, DescuentosService.Id_NombreCol);

                                if (dtDescuento.Rows.Count > 0)
                                {
                                    FUNCIONARIOS_DESCUENTOSRow row = new FUNCIONARIOS_DESCUENTOSRow();
                                    String valorAnterior = string.Empty;

                                    valorAnterior = Definiciones.Log.RegistroNuevo;
                                    row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_desc_sqc");
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

                                    row.DESCUENTO_ID = (decimal)dtDescuento.Rows[0][DescuentosService.Id_NombreCol];
                                    row.OBSERVACION = dr[ColumnasImportadas.OBSERVACIONES].ToString();
                                    row.MONEDA_ID = FuncionariosService.GetMonedaSalario(funcionarioId);
                                    FUNCIONARIOSRow funcionarioRow = sesion.Db.FUNCIONARIOSCollection.GetByPrimaryKey(row.FUNCIONARIO_ID);
                                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(funcionarioRow.SUCURSAL_ID), row.MONEDA_ID, row.FECHA_CREACION, sesion);

                                    //if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    //    throw new Exception("Debe actualizarse la cotización de la moneda.");

                                    row.MONTO = decimal.Parse(dr[ColumnasImportadas.MONTO].ToString());
                                    row.CONSUMO_VISITAS = Definiciones.SiNo.No;
                                    row.UTILIZAR_PORCENTAJE = Definiciones.SiNo.No;

                                    sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.Insert(row);

                                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);
                                }
                                else
                                {
                                    throw new Exception("El motivo de descuento " + dr[ColumnasImportadas.DESCUENTO].ToString() + " no se encuentra activo o disponible en el sistema ");
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

        #region Borrar
        public void Borrar(decimal descuento_id)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    FUNCIONARIOS_DESCUENTOSRow row = new FUNCIONARIOS_DESCUENTOSRow();
                    row = sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.GetByPrimaryKey(descuento_id);
                    string valorAnterior = row.ToString();
                    sesion.Db.BeginTransaction();
                    sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.DeleteByPrimaryKey(row.ID);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
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

        # region SetLiquidacionAsociada
        public void SetLiquidacionAsociada(decimal descuentoFuncionario_id, decimal liquidacionAsociada_id, SessionService sesion)
        {
            FUNCIONARIOS_DESCUENTOSRow row = sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.GetByPrimaryKey(descuentoFuncionario_id);
            String valorAnterior = row.ToString();
            if (!DescuentosService.EsUnica(row.DESCUENTO_ID)) return;
            //se revisa si el nuevo valor es valido, sino se convierte a null el valor de la liquidacion asociada
            if (liquidacionAsociada_id == Definiciones.Error.Valor.EnteroPositivo)
            {
                row.IsLIQUIDACION_ASOCIADA_IDNull = true;

            }
            else
            {
                row.LIQUIDACION_ASOCIADA_ID = liquidacionAsociada_id;
            }
            sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion SetLiquidacionAsociada

        # region SetMonto
        public void SetMonto(decimal descuentoFuncionario_id, decimal monto, SessionService sesion)
        {


            FUNCIONARIOS_DESCUENTOSRow row = sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.GetByPrimaryKey(descuentoFuncionario_id);
            String valorAnterior = row.ToString();
            
            if (monto == Definiciones.Error.Valor.EnteroPositivo)
            {
                return;

            }
            else
            {
                row.MONTO = monto;
            }
            sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion SetMonto

        public static void ActualizarFecha(string caso_origen_id, SessionService sesion, DateTime fecha)
        {
            String clausulas = CasoOrigenId_NombreCol + " = " + caso_origen_id;
            DataTable table = sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.GetAsDataTable(clausulas, string.Empty);

            if (table.Rows.Count == 0)
                return;

            System.Collections.Hashtable campos = new System.Collections.Hashtable();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Rows[0][i] != DBNull.Value)
                {
                    campos.Add(table.Columns[i].ColumnName, table.Rows[0][i]);
                }
            }
            campos[FechaCreacion_NombreCol] = fecha;
            FuncionariosDescuentosService descuento = new FuncionariosDescuentosService();
            descuento.Guardar(campos, false, sesion);
        }

        /// <summary>
        /// Gets bool, existencia de descuento creado a partir de un caso.
        /// </summary>
        /// <param name="caso_origen_id">The caso origen id.</param>
        /// <returns></returns>
        public static bool GetExisteDescuento(string caso_origen_id, SessionService sesion)
        {
            if (caso_origen_id == string.Empty)
                return false;

            String clausulas = CasoOrigenId_NombreCol + " = " + caso_origen_id;
            DataTable table = sesion.Db.FUNCIONARIOS_DESCUENTOSCollection.GetAsDataTable(clausulas, string.Empty);
            return table.Rows.Count > 0;
        }

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "FUNCIONARIOS_DESCUENTOS"; }
        }

        public static string CasoOrigenId_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.CASO_ORIGEN_IDColumnName; } }

        public static string CotizacionMoneda_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.COTIZACION_MONEDAColumnName; } }

        public static string DescuentoId_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.DESCUENTO_IDColumnName; } }

        public static string EmpresaSeccionId_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.EMPRESA_SECCION_IDColumnName; } }

        public static string Estado_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.ESTADOColumnName; } }

        public static string FechaCreacion_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.FECHA_CREACIONColumnName; } }

        public static string FuncionarioId_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.FUNCIONARIO_IDColumnName; } }

        public static string Id_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.IDColumnName; } }

        public static string LiquidacionAsociadaId_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.LIQUIDACION_ASOCIADA_IDColumnName; } }

        public static string MonedaId_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.MONEDA_IDColumnName; } }

        public static string Monto_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.MONTOColumnName; } }

        public static string Observacion_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.OBSERVACIONColumnName; } }

        public static string UsuarioCreacionId_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.USUARIO_CREACION_IDColumnName; } }

        public static string UtilizarPorcentaje_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.UTILIZAR_PORCENTAJEColumnName; } }


        public static string Nombre_Vista
        {
            get { return "funcionarios_desc_info_compl"; }
        }

        public static string ConsumoVisitas_NombreCol
        { get { return FUNCIONARIOS_DESCUENTOSCollection.CONSUMO_VISITASColumnName; } }

        public static string VistaDescuentoUnico_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.DESCUENTO_UNICOColumnName; } }
        
        public static string VistaDescuentoNombre_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.DESCUENTO_NOMBREColumnName; } }

        public static string VistaEmpresaDepartamento_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.EMPRESA_DEPARTAMENTO_IDColumnName; } }

        public static string VistaEmpresaSeccionNombre_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.EMPRESA_SECCION_NOMBREColumnName; } }

        public static string VistaEntidadId_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.ENTIDAD_IDColumnName; } }

        public static string VistaFuncionarioNombre_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.FUNCIONARIO_NOMBREColumnName; } }

        public static string VistaMonedaNombre_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.MONEDA_NOMBREColumnName; } }

        public static string VistaMonedaCadenaDecimales_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.MONEDA_CADENA_DECIMALESColumnName; } }

        public static string VistaMonedaCantidadDecimales_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.MONEDA_CANTIDAD_DECIMALESColumnName; } }

        public static string VistaMonedaSimbolo_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; } }

        public static string VistaPorcentajeSugerido_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.PORCENTAJE_SUGERIDOColumnName; } }

        public static string VistaSucursalAbreviatura_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.SUCURSAL_ABREVIATURAColumnName; } }

        public static string VistaSucursalNombre_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; } }

        public static string VistaUsuarioCreacionNombre_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.USUARIO_CREACION_NOMBREColumnName; } }

        public static string VistaUDescuentoConsumo_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.DESCUENTO_CONSUMOColumnName; } }

        public static string VistaLiquidacionAsociada_NombreCol
        { get { return FUNCIONARIOS_DESC_INFO_COMPLCollection.LIQUIDACION_ASOCIADA_IDColumnName; } }

        #endregion Accessors
    }
}
