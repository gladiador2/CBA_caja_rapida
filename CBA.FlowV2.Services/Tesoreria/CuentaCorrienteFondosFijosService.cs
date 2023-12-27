using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteFondosFijosService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal ctacte_fondo_fijo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EstaActivo(ctacte_fondo_fijo_id, sesion);
            }
        }

        public static bool EstaActivo(decimal ctacte_fondo_fijo_id, SessionService sesion)
        {
            CTACTE_FONDOS_FIJOSRow row = sesion.Db.CTACTE_FONDOS_FIJOSCollection.GetByPrimaryKey(ctacte_fondo_fijo_id);
            return row.ESTADO == Definiciones.Estado.Activo;
        }
        #endregion EstaActivo

        #region GetCuentaCorrienteFondosFijosDataTable
        /// <summary>
        /// Gets the cuenta corriente fondos fijos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteFondosFijosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteFondosFijosDataTable(clausulas, orden, sesion);
            }
        }
        public static DataTable GetCuentaCorrienteFondosFijosDataTable(string clausulas, string orden, SessionService sesion)
        {
            try
            {
                return sesion.Db.CTACTE_FONDOS_FIJOSCollection.GetAsDataTable(clausulas, orden);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrienteFondosFijosDataTable

        #region GetCuentaCorrienteFondosFijosInfoCompleta
        public static DataTable GetCuentaCorrienteFondosFijosInfoCompleta(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.CTACTE_FONDOS_FIJOS_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetCuentaCorrienteFondosFijosInfoCompleta()
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCuentaCorrienteFondosFijosInfoCompleta(string.Empty, string.Empty);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrienteFondosFijosInfoCompleta

        #region GetSucursalId
        public static decimal GetSucursalId(decimal ctacte_fondo_fijo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_FONDOS_FIJOSRow row = sesion.Db.CTACTE_FONDOS_FIJOSCollection.GetByPrimaryKey(ctacte_fondo_fijo_id);
                return row.IsSUCURSAL_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.SUCURSAL_ID;
            }
        }
        #endregion GetSucursalId

        #region GetFuncionarioId
        public static decimal GetFuncionarioId(decimal ctacte_fondo_fijo_id, SessionService sesion)
        {
            CTACTE_FONDOS_FIJOSRow ctacteFondoFijo = sesion.Db.CTACTE_FONDOS_FIJOSCollection.GetByPrimaryKey(ctacte_fondo_fijo_id);
            return ctacteFondoFijo.FUNCIONARIO_ID;
        }
        #endregion GetFuncionarioId

        #region GetFondosFijosSegunPermisos
        /// <summary>
        /// Gets the fondos fijos segun permisos.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFondosFijosSegunPermisos(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = "( " + CuentaCorrienteFondosFijosService.SucursalId_NombreCol + " is null or " +
                               " exists(select * from " + UsuariosSucursalesService.Nombre_Tabla + " us " +
                               "         where us." + UsuariosSucursalesService.SucursalId_NombreCol + " = " + CuentaCorrienteFondosFijosService.Nombre_Vista + "." + CuentaCorrienteFondosFijosService.SucursalId_NombreCol + " and " +
                               "               us." + UsuariosSucursalesService.UsuarioId_NombreCol + " = " + sesion.Usuario.ID + ")" +
                               ")";

                if (clausulas.Length > 0)
                    where += " and " + clausulas;

                return GetCuentaCorrienteFondosFijosInfoCompleta(where, orden);
            }
        }
        #endregion GetFondosFijosSegunPermisos

        #region Recalcular monto disponible
        /// <summary>
        /// Recalculars the monto disponible.
        /// </summary>
        /// <param name="ctacte_fondo_fijo_id">The ctacte_fondo_fijo_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static decimal RecalcularMontoDisponible(decimal ctacte_fondo_fijo_id, SessionService sesion)
        {
            try
            {
                CTACTE_FONDOS_FIJOSRow ctacteFondoFijo = sesion.Db.CTACTE_FONDOS_FIJOSCollection.GetByPrimaryKey(ctacte_fondo_fijo_id);
                CTACTE_FONDOS_FIJOS_MOVRow[] ctacteFondofijoMovimientos = sesion.Db.CTACTE_FONDOS_FIJOS_MOVCollection.GetByCTACTE_FONDO_FIJO_ID(ctacteFondoFijo.ID);
                string valorAnterior = ctacteFondoFijo.ToString();
                decimal ingreso, egreso;

                //Se inicializa la propiedad
                ctacteFondoFijo.MONTO_ACTUAL = 0;

                //Por cada detalle de movimiento se suma (ingreso - egreso)
                for (int i = 0; i < ctacteFondofijoMovimientos.Length; i++)
                {
                    ingreso = ctacteFondofijoMovimientos[i].IsINGRESONull ? 0 : ctacteFondofijoMovimientos[i].INGRESO;
                    egreso = ctacteFondofijoMovimientos[i].IsEGRESONull ? 0 : ctacteFondofijoMovimientos[i].EGRESO;

                    ctacteFondoFijo.MONTO_ACTUAL += ingreso - egreso;
                }

                //Se actualiza el registro
                sesion.Db.CTACTE_FONDOS_FIJOSCollection.Update(ctacteFondoFijo);

                //Se guarda el log
                LogCambiosService.LogDeColumna(CuentaCorrienteFondosFijosService.Nombre_Tabla,
                                               CuentaCorrienteFondosFijosService.MontoActual_NombreCol,
                                               ctacteFondoFijo.ID,
                                               valorAnterior,
                                               ctacteFondoFijo.ToString(),
                                               sesion);

                NotificacionesService.EvaluarPorEntidad(Nombre_Tabla, ctacteFondoFijo.ID, false,string.Empty, sesion);

                return ctacteFondoFijo.MONTO_ACTUAL;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Recalcular monto disponible

        #region Get monto disponible
        public static decimal GetMontoDisponible(decimal ctacte_fondo_fijo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CTACTE_FONDOS_FIJOSRow ctacteFondoFijo = sesion.Db.CTACTE_FONDOS_FIJOSCollection.GetByPrimaryKey(ctacte_fondo_fijo_id);
                    CTACTE_FONDOS_FIJOS_MOVRow[] ctacteFondofijoMovimientos = sesion.Db.CTACTE_FONDOS_FIJOS_MOVCollection.GetByCTACTE_FONDO_FIJO_ID(ctacteFondoFijo.ID);
                    string valorAnterior = ctacteFondoFijo.ToString();
                    decimal ingreso, egreso;

                    //Se inicializa la propiedad
                    ctacteFondoFijo.MONTO_ACTUAL = 0;

                    //Por cada detalle de movimiento se suma (ingreso - egreso)
                    for (int i = 0; i < ctacteFondofijoMovimientos.Length; i++)
                    {
                        ingreso = ctacteFondofijoMovimientos[i].IsINGRESONull ? 0 : ctacteFondofijoMovimientos[i].INGRESO;
                        egreso = ctacteFondofijoMovimientos[i].IsEGRESONull ? 0 : ctacteFondofijoMovimientos[i].EGRESO;

                        ctacteFondoFijo.MONTO_ACTUAL += ingreso - egreso;
                    }

                    return ctacteFondoFijo.MONTO_ACTUAL;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Get Monto Disponible

        #region Get Moneda Fondo Fijo
        public static decimal GetMonedaFondoFijo(decimal ctacte_fondo_fijo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CTACTE_FONDOS_FIJOSRow ctacteFondoFijo = sesion.Db.CTACTE_FONDOS_FIJOSCollection.GetByPrimaryKey(ctacte_fondo_fijo_id);
                    return ctacteFondoFijo.MONEDA_ID;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Get Moneda Fondo Fijo

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

                    CTACTE_FONDOS_FIJOSRow row = new CTACTE_FONDOS_FIJOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_fondos_fijos_sqc");
                        row.FECHA_CREACION = DateTime.Now;
                        row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.CTACTE_FONDOS_FIJOSCollection.GetRow(CuentaCorrienteFondosFijosService.Id_NombreCol + " = " + campos[CuentaCorrienteFondosFijosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.ABREVIATURA = (string)campos[CuentaCorrienteFondosFijosService.Abreviatura_NombreCol];
                    row.NOMBRE = (string)campos[CuentaCorrienteFondosFijosService.Nombre_NombreCol];
                    row.ESTADO = (string)campos[CuentaCorrienteFondosFijosService.Estado_NombreCol];

                    row.LIMITE_INFERIOR = (decimal)campos[CuentaCorrienteFondosFijosService.LimiteInferior_NombreCol];
                    row.LIMITE_SUPERIOR = (decimal)campos[CuentaCorrienteFondosFijosService.LimiteSuperior_NombreCol];
                    row.MONTO_SOBREGIRO = (decimal)campos[CuentaCorrienteFondosFijosService.MontoSobregiro_NombreCol];

                    //Si cambia, se controla que la nueva se encuentre activa
                    if (!row.MONEDA_ID.Equals((decimal)campos[CuentaCorrienteFondosFijosService.MonedaId_NombreCol]))
                    {
                        if (!MonedasService.EstaActivo((decimal)campos[CuentaCorrienteFondosFijosService.MonedaId_NombreCol]))
                        {
                            throw new System.Exception("La moneda se encuentra inactiva.");
                        }
                        else
                        {
                            row.MONEDA_ID = (decimal)campos[CuentaCorrienteFondosFijosService.MonedaId_NombreCol];
                        }
                    }

                    if(campos.Contains(CuentaCorrienteFondosFijosService.SucursalId_NombreCol))
                        row.SUCURSAL_ID = (decimal)campos[CuentaCorrienteFondosFijosService.SucursalId_NombreCol];
                    else
                        row.IsSUCURSAL_IDNull = true;

                    //Si cambia, se controla que la nueva se encuentre activa
                    if (!row.FUNCIONARIO_ID.Equals((decimal)campos[CuentaCorrienteFondosFijosService.FuncionarioId_NombreCol]))
                    {
                        if (!FuncionariosService.EstaActivo((decimal)campos[CuentaCorrienteFondosFijosService.FuncionarioId_NombreCol]))
                        {
                            throw new System.Exception("El funcionario se encuentra inactivo.");
                        }
                        else
                        {
                            row.FUNCIONARIO_ID = (decimal)campos[CuentaCorrienteFondosFijosService.FuncionarioId_NombreCol];
                        }
                    }

                    if (insertarNuevo) sesion.Db.CTACTE_FONDOS_FIJOSCollection.Insert(row);
                    else sesion.Db.CTACTE_FONDOS_FIJOSCollection.Update(row);

                    //Se actualiza el monto disponible actual
                    CuentaCorrienteFondosFijosService.RecalcularMontoDisponible(row.ID, sesion);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
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
        public const string Nombre_Tabla = "CTACTE_FONDOS_FIJOS";
        public const string Nombre_Vista = "CTACTE_FONDOS_FIJOS_INFO_COMP";
        
        public static string Abreviatura_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.ABREVIATURAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.ESTADOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.IDColumnName; }
        }
        public static string LimiteInferior_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.LIMITE_INFERIORColumnName; }
        }
        public static string LimiteSuperior_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.LIMITE_SUPERIORColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.MONEDA_IDColumnName; }
        }
        public static string MontoActual_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.MONTO_ACTUALColumnName; }
        }
        public static string MontoSobregiro_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.MONTO_SOBREGIROColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.NOMBREColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOSCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_INFO_COMPCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_FONDOS_FIJOS_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected CTACTE_FONDOS_FIJOSRow row;
        protected CTACTE_FONDOS_FIJOSRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Abreviatura { get { return ClaseCBABase.GetStringHelper(row.ABREVIATURA); } set { row.ABREVIATURA = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public decimal FuncionarioId { get { return row.FUNCIONARIO_ID; } set { row.FUNCIONARIO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? LimiteInferior { get { if (row.IsLIMITE_INFERIORNull) return null; else return row.LIMITE_INFERIOR; } set { if (value.HasValue) row.LIMITE_INFERIOR = value.Value; else row.IsLIMITE_INFERIORNull = true; } }
        public decimal? LimiteSuperior { get { if (row.IsLIMITE_SUPERIORNull) return null; else return row.LIMITE_SUPERIOR; } set { if (value.HasValue) row.LIMITE_SUPERIOR = value.Value; else row.IsLIMITE_SUPERIORNull = true; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MontoActual { get { return row.MONTO_ACTUAL; } set { row.MONTO_ACTUAL = value; } }
        public decimal MontoSobregiro { get { return row.MONTO_SOBREGIRO; } set { row.MONTO_SOBREGIRO = value; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public decimal? SucursalId { get { if (row.IsSUCURSAL_IDNull) return null; else return row.SUCURSAL_ID; } set { if (value.HasValue) row.SUCURSAL_ID = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        public decimal UsuarioCreacionId { get { return row.USUARIO_CREACION_ID; } set { row.USUARIO_CREACION_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private FuncionariosService _funcionario;
        public FuncionariosService Funcionario
        {
            get
            {
                if (this._funcionario == null)
                    this._funcionario = new FuncionariosService(this.FuncionarioId);
                return this._funcionario;
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
                this.row = sesion.db.CTACTE_FONDOS_FIJOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_FONDOS_FIJOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrienteFondosFijosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteFondosFijosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteFondosFijosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
