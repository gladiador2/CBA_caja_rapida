using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;
using System.Text;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCuentasBancariasService : ClaseCBA<CuentaCorrienteCuentasBancariasService>
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="ctacte_bancaria_id">The ctacte_bancaria_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal ctacte_bancaria_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_BANCARIASRow row = sesion.Db.CTACTE_BANCARIASCollection.GetRow(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + ctacte_bancaria_id);
                
                return row.ESTADO == Definiciones.Estado.Activo;
                
            }
        }
        #endregion EstaActivo

        #region GetMoneda
        /// <summary>
        /// Gets the moneda.
        /// </summary>
        /// <param name="ctacte_bancaria_id">The ctacte_bancaria_id.</param>
        /// <returns></returns>
        public static decimal GetMoneda(decimal ctacte_bancaria_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_BANCARIASCollection.GetByPrimaryKey(ctacte_bancaria_id).MONEDA_ID;
            }
        }
        #endregion GetMoneda

        #region GetTitular
        /// <summary>
        /// Gets the moneda.
        /// </summary>
        /// <param name="ctacte_bancaria_id">The ctacte_bancaria_id.</param>
        /// <returns>string</returns>
        public static string GetTitular(decimal ctacte_bancaria_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_BANCARIASCollection.GetByPrimaryKey(ctacte_bancaria_id).TITULAR;
            }
        }
        #endregion GetTitular

        #region GetCtacteBancoId
        /// <summary>
        /// Gets the ctacte banco id.
        /// </summary>
        /// <param name="ctacte_bancaria_id">The ctacte_bancaria_id.</param>
        /// <returns></returns>
        public static decimal GetCtacteBancoId(decimal ctacte_bancaria_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_BANCARIASCollection.GetByPrimaryKey(ctacte_bancaria_id).CTACTE_BANCO_ID;
            }
        }
        #endregion GetCtacteBancoId

        #region GetWhereTiposSegunPermiso
        /// <summary>
        /// Gets the where tipos segun permiso.
        /// </summary>
        /// <param name="esInfoCompleta">if set to <c>true</c> [es info completa].</param>
        /// <returns></returns>
        private static string GetWhereTiposSegunPermiso(bool esInfoCompleta)
        {
            string nombreColumna;
            if (esInfoCompleta)
                nombreColumna = CuentaCorrienteCuentasBancariasService.VistaTipoId_NombreCol;
            else
                nombreColumna = CuentaCorrienteCuentasBancariasService.TipoId_NombreCol;
            string where = "";
            if (!RolesService.Tiene("bancarias ver tipo normal"))
                where += " and " + nombreColumna + " != " + Definiciones.TipoCuentaBancaria.Normal;
            if (!RolesService.Tiene("bancarias ver tipo directivo"))
                where += " and " + nombreColumna + " != " + Definiciones.TipoCuentaBancaria.Directivo;

            return where;
        }
        #endregion GetWhereTiposSegunPermiso

        #region GetCuentaCorrienteBancariasDataTable
        public static DataTable GetCuentaCorrienteBancariasDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = " 1=1 ";
                where += CuentaCorrienteCuentasBancariasService.GetWhereTiposSegunPermiso(false);
                if (soloActivos) where += " and " + CuentaCorrienteBancosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.CTACTE_BANCARIASCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCuentaCorrienteBancariasDataTable

        #region GetCuentaCorrienteBancariasDataTableTodo
        public static DataTable GetCuentaCorrienteBancariasDataTableTodo(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = " 1=1 ";
               // where += CuentaCorrienteCuentasBancariasService.GetWhereTiposSegunPermiso(false);
                if (soloActivos) where += " and " + CuentaCorrienteBancosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.CTACTE_BANCARIASCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCuentaCorrienteBancariasDataTableTodo

        #region GetCuentaCorrienteBancariasInfoCompleta
        public static DataTable GetCuentaCorrienteBancariasInfoCompleta(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                string where = "(" + CuentaCorrienteBancosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " OR " + CuentaCorrienteBancosService.EntidadId_NombreCol + " IS NULL )";
                where += GetWhereTiposSegunPermiso(true);
                if (soloActivos) where += " and " + CuentaCorrienteBancosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0) where += " and " + clausulas;

                sesion.Db.IniciarBusquedaFlexible();
                dt = sesion.Db.CTACTE_BANCARIAS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
                sesion.Db.FinalizarBusquedaFlexible();

                return dt;
            }
        }
        #endregion GetCuentaCorrienteBancariasInfoCompleta

        #region GetCuentaCorrienteBancariaPorUsuarioDataTable
        /// <summary>
        /// Obtener las cuentas bancarias a las que el usuario tiene acceso
        /// </summary>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteBancariaPorUsuarioDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtAux = UsuariosService.GetSucursalesPerteneceUsuario(sesion.Usuario.ID);
                string sucursales = "-1";

                for (int i = 0; i < dtAux.Rows.Count; i++)
                {
                    sucursales += ", " + dtAux.Rows[i]["sucursal_id"];
                }

                string clausulas = CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol + " in (" + sucursales + ") OR " + CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol + " IS NULL ";
                string orden = CuentaCorrienteCuentasBancariasService.Orden_NombreCol + "," + CuentaCorrienteCuentasBancariasService.VistaSucursalNombre_NombreCol + "," + CuentaCorrienteCuentasBancariasService.VistaCtacteBancoAbreviatura_NombreCol + "," + CuentaCorrienteCuentasBancariasService.NumeroCuenta_NombreCol;
                DataTable dt = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasInfoCompleta(clausulas, orden, true);

                return dt;
            }
        }
        #endregion GetCuentaCorrienteBancariaPorUsuarioDataTable

        #region GetSaldoActual
        /// <summary>
        /// Gets the saldo.
        /// </summary>
        /// <param name="ctacte_bancaria_id">The ctacte_bancaria_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public decimal GetSaldoActual(decimal ctacte_bancaria_id, SessionService sesion)
        {
            string clausula = CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + ctacte_bancaria_id;
            return sesion.Db.CTACTE_BANCARIAS_INFO_COMPLETACollection.GetRow(clausula).SALDO_ACTUAL;
        }
        #endregion GetSaldo

        #region GetReporteCheque
        /// <summary>
        /// Gets the reporte cheque.
        /// </summary>
        /// <param name="ctacte_bancaria_id">The ctacte_bancaria_id.</param>
        /// <returns></returns>
        public static decimal GetReporteCheque(decimal ctacte_bancaria_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_BANCARIASCollection.GetByPrimaryKey(ctacte_bancaria_id).REPORTE_ID;
            }
        }
        #endregion GetReporteCheque

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTACTE_BANCARIASRow cuenta = new CTACTE_BANCARIASRow();
                    string valorAnterior = string.Empty;
                    decimal aux;

                    if (insertarNuevo)
                    {
                        cuenta.ID = sesion.Db.GetSiguienteSecuencia("ctacte_bancarias_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        cuenta.IsFECHA_SALDO_EXTRACTONull = true;
                    }
                    else
                    {
                        cuenta = sesion.Db.CTACTE_BANCARIASCollection.GetRow(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + campos[CuentaCorrienteCuentasBancariasService.Id_NombreCol]);
                        valorAnterior = cuenta.ToString();
                    }

                    aux = (decimal)campos[CuentaCorrienteCuentasBancariasService.CtacteBancoId_NombreCol];
                    if (cuenta.CTACTE_BANCO_ID != aux)
                    {
                        if (CuentaCorrienteBancosService.EstaActivo(aux)) cuenta.CTACTE_BANCO_ID = aux;
                        else throw new System.ArgumentException("El banco seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }

                    cuenta.ESTADO = campos[CuentaCorrienteCuentasBancariasService.Estado_NombreCol].ToString();

                    aux = (decimal)campos[CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol];
                    if (cuenta.MONEDA_ID != aux)
                    {
                        if (MonedasService.EstaActivo(aux)) cuenta.MONEDA_ID = aux;
                        else throw new System.ArgumentException("La moneda seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }

                    cuenta.NUMERO_CUENTA = campos[CuentaCorrienteCuentasBancariasService.NumeroCuenta_NombreCol].ToString();
                    cuenta.REPORTE_ID = (decimal)campos[CuentaCorrienteCuentasBancariasService.ReporteId_NombreCol];

                    cuenta.MONTO_LINEA_CREDITO = (decimal)campos[CuentaCorrienteCuentasBancariasService.MontoLineaCredito_NombreCol];
                    cuenta.MONTO_SOBREGIRO = (decimal)campos[CuentaCorrienteCuentasBancariasService.MontoSobregiro_NombreCol];


                    if (campos.Contains(CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol) && !Interprete.EsNullODBNull(campos[CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol]))
                    {
                        if (SucursalesService.EstaActivo((decimal)campos[CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol]))
                            cuenta.SUCURSAL_ID = (decimal)campos[CuentaCorrienteCuentasBancariasService.SucursalId_NombreCol];
                        else throw new System.ArgumentException("La sucursal seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                    else
                    {
                        cuenta.IsSUCURSAL_IDNull = true;
                    }

                    if (campos.Contains(CuentaCorrienteCuentasBancariasService.ReporteParaBancoId_NombreCol))
                        cuenta.REPORTE_PARA_BANCO_ID = (decimal)campos[CuentaCorrienteCuentasBancariasService.ReporteParaBancoId_NombreCol];
                    else
                        cuenta.IsREPORTE_PARA_BANCO_IDNull = true;

                    cuenta.ORDEN = (decimal)campos[CuentaCorrienteCuentasBancariasService.Orden_NombreCol];
                    
                    if (insertarNuevo)
                    {
                        cuenta.SALDO_EXTRACTO = decimal.Parse(campos[CuentaCorrienteCuentasBancariasService.SaldoExtracto_NombreCol].ToString());
                        cuenta.SALDO_INICIAL = decimal.Parse(campos[CuentaCorrienteCuentasBancariasService.SaldoInicial_NombreCol].ToString());
                    }
                    else
                    {
                        aux = decimal.Parse(campos[CuentaCorrienteCuentasBancariasService.SaldoExtracto_NombreCol].ToString());
                        if (cuenta.SALDO_EXTRACTO != aux)
                        {
                            cuenta.FECHA_SALDO_EXTRACTO = DateTime.Now;
                            cuenta.SALDO_EXTRACTO = aux;
                        }

                        aux = decimal.Parse(campos[CuentaCorrienteCuentasBancariasService.SaldoInicial_NombreCol].ToString());
                        if (cuenta.SALDO_INICIAL != aux)
                        {
                            //Por la importancia del campo, se crea un log de columna
                            LogCambiosService.LogDeColumna(CuentaCorrienteCuentasBancariasService.Nombre_Tabla, CuentaCorrienteCuentasBancariasService.SaldoInicial_NombreCol, cuenta.ID, cuenta.SALDO_INICIAL.ToString(), aux.ToString(), sesion);
                            cuenta.SALDO_INICIAL = aux;
                        }
                    }

                    cuenta.TITULAR = campos[CuentaCorrienteCuentasBancariasService.Titular_NombreCol].ToString();

                    //se agrega/modifica el tipo de cuenta bancaria si es que existe
                    if (campos.Contains(CuentaCorrienteCuentasBancariasService.TipoId_NombreCol))
                    {
                        cuenta.TIPO_ID = decimal.Parse(campos[CuentaCorrienteCuentasBancariasService.TipoId_NombreCol].ToString());
                    }
                    else
                    {
                        if (insertarNuevo)
                            cuenta.TIPO_ID = Definiciones.TipoCuentaBancaria.Normal;
                    }
                    
                    if (insertarNuevo) sesion.Db.CTACTE_BANCARIASCollection.Insert(cuenta);
                    else sesion.Db.CTACTE_BANCARIASCollection.Update(cuenta);

                    LogCambiosService.LogDeRegistro(CuentaCorrienteCuentasBancariasService.Nombre_Tabla, cuenta.ID, valorAnterior, cuenta.ToString(), sesion);

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
        public static string Nombre_Tabla
        {
            get { return "CTACTE_BANCARIAS"; }
        }
        public static string Nombre_Vista 
        {
            get { return "ctacte_bancarias_info_completa"; }
        }
        public static string CtacteBancoId_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.ESTADOColumnName; }
        }
        public static string FechaSaldoExtracto_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.FECHA_SALDO_EXTRACTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.MONEDA_IDColumnName; }
        }
        public static string MontoLineaCredito_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.MONTO_LINEA_CREDITOColumnName; }
        }
        public static string MontoSobregiro_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.MONTO_SOBREGIROColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.ORDENColumnName; }
        }
        public static string NumeroCuenta_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.NUMERO_CUENTAColumnName; }
        }
        public static string ReporteId_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.REPORTE_IDColumnName; }
        }
        public static string ReporteParaBancoId_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.REPORTE_PARA_BANCO_IDColumnName; }
        }
        public static string SaldoExtracto_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.SALDO_EXTRACTOColumnName; }
        }
        public static string SaldoInicial_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.SALDO_INICIALColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.SUCURSAL_IDColumnName; }
        }
        public static string Titular_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.TITULARColumnName; }
        }
        public static string TipoId_NombreCol
        {
            get { return CTACTE_BANCARIASCollection.TIPO_IDColumnName; }
        }
        public static string VistaCtacteBancoAbreviatura_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaCtacteBancoNombre_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.BANCO_NOMBREColumnName; }
        }
        public static string VistaCtacteBancoPaisId_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.BANCO_PAIS_IDColumnName; }
        }
        public static string VistaMoneda_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.MONEDAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string ReporteNombre_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.REPORTE_NOMBREColumnName; }
        }
        public static string VistaTitular_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.TITULARColumnName; }
        }
        public static string VistaTipoId_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.TIPO_IDColumnName; }
        }
        public static string VistaTipoDescripcion_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.TIPOS_CTACTE_BANCARIA_DESCRColumnName; }
        }
        public static string VistaSaldoActual_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.SALDO_ACTUALColumnName; }
        }
        public static string VistaSaldoConciliado_NombreCol
        {
            get { return CTACTE_BANCARIAS_INFO_COMPLETACollection.SALDO_CONCILIADOColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrienteCuentasBancariasService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrienteCuentasBancariasService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected CTACTE_BANCARIASRow row;
        protected CTACTE_BANCARIASRow rowSinModificar;
        public class Modelo : CTACTE_BANCARIASCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal CtacteBancoId { get { return row.CTACTE_BANCO_ID; } set { row.CTACTE_BANCO_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime? FechaSaldoExtracto { get { if (row.IsFECHA_SALDO_EXTRACTONull) return null; else  return row.FECHA_SALDO_EXTRACTO; } set { if (value.HasValue) row.FECHA_SALDO_EXTRACTO = value.Value; else row.IsFECHA_SALDO_EXTRACTONull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MontoLineaCredito { get { return row.MONTO_LINEA_CREDITO; } set { row.MONTO_LINEA_CREDITO = value; } }
        public decimal MontoSobregiro { get { return row.MONTO_SOBREGIRO; } set { row.MONTO_SOBREGIRO = value; } }
        public string NumeroCuenta { get { return row.NUMERO_CUENTA; } set { row.NUMERO_CUENTA = value; } }
        public decimal Orden { get { return row.ORDEN; } set { row.ORDEN = value; } }
        public decimal ReporteId { get { return row.REPORTE_ID; } set { row.REPORTE_ID = value; } }
        public decimal? ReporteParaBancoId { get { if (row.IsREPORTE_PARA_BANCO_IDNull) return null; return row.REPORTE_PARA_BANCO_ID; } set { if (value.HasValue) row.REPORTE_PARA_BANCO_ID = value.Value; else row.IsREPORTE_PARA_BANCO_IDNull = true; } }
        public decimal SaldoExtracto { get { if (row.IsSALDO_EXTRACTONull) return 0; return row.SALDO_EXTRACTO; } set { row.SALDO_EXTRACTO = value; } }
        public decimal SaldoInicial { get { return row.SALDO_INICIAL; } set { row.SALDO_INICIAL = value; } }
        public decimal? SucursalId { get { if (row.IsSUCURSAL_IDNull) return null; return row.SUCURSAL_ID; } set { if (value.HasValue) row.SALDO_INICIAL = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        public decimal? TipoId { get { if (row.IsTIPO_IDNull) return null; return row.TIPO_ID; } set { if (value.HasValue) row.TIPO_ID = value.Value; else row.IsTIPO_IDNull = true; } }
        public string Titular { get { return row.TITULAR; } set { row.TITULAR = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CuentaCorrienteBancosService _ctacte_banco;
        public CuentaCorrienteBancosService CtacteBanco
        {
            get
            {
                if (this._ctacte_banco == null)
                {
                    //Descomentar cuando la clase sea orientada a objetos
                    //if(this.sesion != null)
                    //    this._caso = new CuentaCorrienteBancosService(this.CtacteBancoId, this.sesion);
                    //else
                    this._ctacte_banco = new CuentaCorrienteBancosService(this.CtacteBancoId);
                }
                return this._ctacte_banco;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId);
                return this._moneda;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                    this._sucursal = new SucursalesService(this.SucursalId.Value);
                return this._sucursal;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_BANCARIASCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_BANCARIASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CTACTE_BANCARIASRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrienteCuentasBancariasService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteCuentasBancariasService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteCuentasBancariasService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        public CuentaCorrienteCuentasBancariasService(EdiCBA.CuentaBancaria edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = DepositosBancariosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);
            
            #region banco
            if (!string.IsNullOrEmpty(edi.banco_uuid))
                this._ctacte_banco = CuentaCorrienteBancosService.GetPorUUID(edi.banco_uuid, sesion);
            if (this._ctacte_banco == null && edi.banco != null)
                this._ctacte_banco = new CuentaCorrienteBancosService(edi.banco, almacenar_localmente, sesion);
            if (this._ctacte_banco == null)
                throw new Exception("No se encontró el UUID " + edi.banco_uuid + " ni se definieron los datos del objeto.");
            
            if(!this.CtacteBanco.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.CtacteBanco.Id.HasValue)
                this.CtacteBancoId = this.CtacteBanco.Id.Value;
            #endregion banco

            this.Estado = Definiciones.Estado.Activo;

            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda

            this.NumeroCuenta = edi.numero_cuenta;
            
            #region sucursal
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal == null && edi.sucursal != null)
                this._sucursal = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this._sucursal == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");

            if (!this.Sucursal.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Sucursal.Id.HasValue)
                this.SucursalId = this.Sucursal.Id.Value;
            #endregion sucursal

            this.Titular = edi.titular; 
        }
        private CuentaCorrienteCuentasBancariasService(CTACTE_BANCARIASRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.row.ID = sesion.db.GetSiguienteSecuencia("ctacte_bancarias_sqc");
                sesion.db.CTACTE_BANCARIASCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, null, sesion);
            }
            else
            {
                sesion.db.CTACTE_BANCARIASCollection.Update(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, this.rowSinModificar, sesion);
            }

            this.rowSinModificar = this.row.Clonar();

            return this.row.ID;
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._ctacte_banco = null;
            this._moneda = null;
            this._sucursal = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override CuentaCorrienteCuentasBancariasService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.CTACTE_BANCO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.MONEDA_IDColumnName:
                        case Modelo.REPORTE_IDColumnName:
                        case Modelo.REPORTE_PARA_BANCO_IDColumnName:
                        case Modelo.SUCURSAL_IDColumnName:
                        case Modelo.TIPO_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.MONTO_LINEA_CREDITOColumnName:
                        case Modelo.MONTO_SOBREGIROColumnName:
                        case Modelo.SALDO_EXTRACTOColumnName:
                        case Modelo.SALDO_INICIALColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.ESTADOColumnName:
                        case Modelo.NUMERO_CUENTAColumnName:
                        case Modelo.TITULARColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.FECHA_SALDO_EXTRACTOColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            CTACTE_BANCARIASRow[] rows = sesion.db.CTACTE_BANCARIASCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CuentaCorrienteCuentasBancariasService[] cb = new CuentaCorrienteCuentasBancariasService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cb[i] = new CuentaCorrienteCuentasBancariasService(rows[i]);

            return cb;
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.CuentaBancaria()
            {
                banco_uuid = this.CtacteBanco.GetOrCreateUUID(sesion),
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                numero_cuenta = this.NumeroCuenta,
                sucursal_uuid = this.SucursalId.HasValue ? this.Sucursal.GetOrCreateUUID(sesion) : null,
                titular = this.Titular,
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.banco = (EdiCBA.Banco)this.CtacteBanco.ToEDI(nueva_profundidad, sesion);
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
                if(this.SucursalId.HasValue)
                    e.sucursal = (EdiCBA.Sucursal)this.Sucursal.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
