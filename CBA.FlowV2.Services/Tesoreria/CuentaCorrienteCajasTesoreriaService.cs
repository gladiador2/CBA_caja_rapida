#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCajasTesoreriaService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="ctacte_caja_tesoreria_id">The ctacte_caja_tesoreria_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal ctacte_caja_tesoreria_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CAJAS_TESORERIARow row = sesion.Db.CTACTE_CAJAS_TESORERIACollection.GetByPrimaryKey(ctacte_caja_tesoreria_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region SaldoEfectivoPorCaja
        public static decimal SaldoEfectivoPorCaja(decimal caja_tesoreria_id, decimal moneda_id)
        {
            using(SessionService sesion = new SessionService())
            {
                return SaldoEfectivoPorCaja(caja_tesoreria_id, moneda_id, sesion);
            }
        }
        public static decimal SaldoEfectivoPorCaja(decimal caja_tesoreria_id, decimal moneda_id, SessionService sesion) 
        {
            string sql = "select nvl(sum(nvl(" + CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso_NombreCol + ", 0)) - sum(nvl(" + CuentaCorrienteCajasTesoreriaMovimientosService.Egreso_NombreCol + ", 0)),0) " +
                         "  from " + CuentaCorrienteCajasTesoreriaMovimientosService.Nombre_Tabla +
                         " where " + CuentaCorrienteCajasTesoreriaMovimientosService.CtacteCajaTesoreriaId_NombreCol + " = " + caja_tesoreria_id + 
                         "   and " + CuentaCorrienteCajasTesoreriaMovimientosService.MonedaId_NombreCol + " = " + moneda_id +
                         "   and " + CuentaCorrienteCajasTesoreriaMovimientosService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.Efectivo;

            DataTable dt = sesion.db.EjecutarQuery(sql);
            if (dt.Rows.Count > 0)
                return (decimal)dt.Rows[0][0];
            else
                return 0;
        }
        #endregion SaldoEfectivoPorCaja

        #region GetSucursal
        /// <summary>
        /// Gets the sucursal.
        /// </summary>
        /// <param name="ctacte_caja_tesoreria_id">The ctacte_caja_tesoreria_id.</param>
        /// <returns></returns>
        public static decimal GetSucursal(decimal ctacte_caja_tesoreria_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CAJAS_TESORERIARow row = sesion.Db.CTACTE_CAJAS_TESORERIACollection.GetByPrimaryKey(ctacte_caja_tesoreria_id);
                return row.SUCURSAL_ID;
            }
        }
        #endregion GetSucursal
        
        #region GetMaxOrden
        /// <summary>
        /// Gets the sucursal.
        /// </summary>
        /// <param name="ctacte_caja_tesoreria_id">The ctacte_caja_tesoreria_id.</param>
        /// <returns></returns>
        public static decimal GetMaxOrden()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtCajas = sesion.Db.CTACTE_CAJAS_TESORERIACollection.GetAsDataTable(string.Empty, CuentaCorrienteCajasTesoreriaService.Orden_NombreCol + " desc");
                if (dtCajas.Rows.Count <= 0)
                    return 0;
                else 
                    return (decimal)dtCajas.Rows[0][CuentaCorrienteCajasTesoreriaService.Orden_NombreCol];
            }
        }
        #endregion GetMaxOrden

        #region VerificarOrden
        public static bool VerificarOrdenLibre(decimal orden, decimal caja_tesoreria_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CuentaCorrienteCajasTesoreriaService.Orden_NombreCol + " = " + orden
                    + " and " + CuentaCorrienteCajasTesoreriaService.Id_NombreCol + " != "+ caja_tesoreria_id ;
                DataTable dtCajas = sesion.Db.CTACTE_CAJAS_TESORERIACollection.GetAsDataTable(clausulas, string.Empty);
                if (dtCajas.Rows.Count > 0)
                    return false;
                else
                    return true;
            }
        }
        #endregion VerificarOrden

        #region GetCuentaCorrienteCajasTesoreriaDataTable
        public static DataTable GetCuentaCorrienteCajasTesoreriaDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteCajasTesoreriaDataTable(clausulas, orden, soloActivos, sesion);
            }
        }

        public static DataTable GetCuentaCorrienteCajasTesoreriaDataTable(string clausulas, string orden, bool soloActivos, SessionService sesion)
        {
            try
            {
                string where = " 1=1 ";
                if (soloActivos) where += " and " + CuentaCorrienteCajasTesoreriaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.CTACTE_CAJAS_TESORERIACollection.GetAsDataTable(where, orden);
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetCuentaCorrienteCajasTesoreriaDataTable(string clausulas, string orden)
        {
            return GetCuentaCorrienteCajasTesoreriaDataTable(clausulas, orden, false);
        }
        #endregion GetCuentaCorrienteCajasTesoreriaDataTable

        #region GetCuentaCorrienteCajasTesoreriaInfoCompleta
        public static DataTable GetCuentaCorrienteCajasTesoreriaInfoCompleta(string clausulas, string orden, bool soloActivos)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = " 1=1 ";
                    if (soloActivos) where += " and " + CuentaCorrienteCajasTesoreriaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                    if (clausulas.Length > 0) where += " and " + clausulas;

                    return sesion.Db.CTACTE_CAJAS_TESO_INFO_COMPCollection.GetAsDataTable(where, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        
        public static DataTable GetCuentaCorrienteCajasTesoreriaInfoCompleta(string clausulas, string orden)
        {
            return GetCuentaCorrienteCajasTesoreriaInfoCompleta(clausulas, orden, false);
        }
        #endregion GetCuentaCorrienteCajasTesoreriaInfoCompleta

        #region GetCajasPorUsuarioDataTable
        /// <summary>
        /// Obtener las cajas de tesoreria a las que el usuario tiene acceso
        /// </summary>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetCajasPorUsuarioDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtAux = UsuariosService.GetSucursalesPerteneceUsuario(sesion.Usuario.ID);
                string sucursales = "-1";

                for (int i = 0; i < dtAux.Rows.Count; i++)
                {
                    sucursales += ", " + dtAux.Rows[i]["sucursal_id"];
                }

                string clausulas = CuentaCorrienteCajasTesoreriaService.SucursalId_NombreCol + " in (" + sucursales + ")";
                DataTable dt = CuentaCorrienteCajasTesoreriaService.GetCuentaCorrienteCajasTesoreriaInfoCompleta(clausulas, CuentaCorrienteCajasTesoreriaService.Nombre_NombreCol, true);

                return dt;
            }
        }
        public DataTable GetCajasPorUsuarioDataTable(decimal sucursalId)
        {
            using (SessionService sesion = new SessionService())
            {
               /* DataTable dtAux = UsuariosService.GetSucursalesPerteneceUsuario(sesion.Usuario.ID);
                string sucursales = "-1";

                for (int i = 0; i < dtAux.Rows.Count; i++)
                {
                    sucursales += ", " + dtAux.Rows[i]["sucursal_id"];
                }*/

                string clausulas = CuentaCorrienteCajasTesoreriaService.SucursalId_NombreCol + " in (" + sucursalId + ")" + " and " + CuentaCorrienteCajasTesoreriaService.UsuarioCreacionId_NombreCol + " = " + sesion.Usuario.ID;
                DataTable dt = CuentaCorrienteCajasTesoreriaService.GetCuentaCorrienteCajasTesoreriaInfoCompleta(clausulas, CuentaCorrienteCajasTesoreriaService.Nombre_NombreCol, true);

                return dt;
            }
        }
        public static DataTable GetCajasPorUsuarioDataTable2()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dtAux = UsuariosService.GetSucursalesPerteneceUsuario(sesion.Usuario.ID);
                string sucursales = "-1";

                for (int i = 0; i < dtAux.Rows.Count; i++)
                {
                    sucursales += ", " + dtAux.Rows[i]["sucursal_id"];
                }

                string clausulas = CuentaCorrienteCajasTesoreriaService.SucursalId_NombreCol + " in (" + sucursales + ")";
                DataTable dt = GetCuentaCorrienteCajasTesoreriaInfoCompleta(clausulas, CuentaCorrienteCajasTesoreriaService.Nombre_NombreCol, true);

                return dt;
            }
        }
        #endregion GetCajasPorUsuarioDataTable

        #region GetChequesRecibidosEnCaja
        /// <summary>
        /// Gets the cheques recibidos en caja.
        /// </summary>
        /// <param name="ctacte_caja_tesoreria_id">The ctacte_caja_tesoreria_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns></returns>
        public static DataTable GetChequesRecibidosEnCaja(decimal ctacte_caja_tesoreria_id, decimal moneda_id)
        {
            CuentaCorrienteCajasTesoreriaMovimientosService ctacteCajaMov = new CuentaCorrienteCajasTesoreriaMovimientosService();

            //Solo los cheques que no estan rechazados, depositados, utilizados ni efectivizados y que
            //ademas ya vencieron (pueden ser efectivizados o depositados)
            string clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CtacteCajaTesoreriaId_NombreCol + " = " + ctacte_caja_tesoreria_id + " and " +
                               CuentaCorrienteCajasTesoreriaMovimientosService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.Cheque + " and " +
                               CuentaCorrienteCajasTesoreriaMovimientosService.MonedaId_NombreCol + " = " + moneda_id + " and " +
                               CuentaCorrienteCajasTesoreriaMovimientosService.FechaEgreso_NombreCol + " is null and " +
                               CuentaCorrienteCajasTesoreriaMovimientosService.VistaCtacteChequeRecibidoEstadoId_NombreCol + " in(" + Definiciones.CuentaCorrienteChequesEstados.AlDia + "," + Definiciones.CuentaCorrienteChequesEstados.Adelantado + ")"; 
                               

            DataTable dt = ctacteCajaMov.GetCuentaCorrienteCajasTesoreriaMovimientosInfoCompleta(clausulas, CuentaCorrienteCajaService.VistaCtacteChequeRecibidoEmisor_NombreCol);
            return dt;
        }

        /// <summary>
        /// Gets the cheques recibidos en caja venc.
        /// </summary>
        /// <param name="ctacte_caja_tesoreria_id">The ctacte_caja_tesoreria_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="desde">The desde.</param>
        /// <param name="hasta">The hasta.</param>
        /// <param name="parte_texto">The parte_texto.</param>
        /// <returns></returns>
        public static DataTable GetChequesRecibidosEnCajaVenc(decimal ctacte_caja_tesoreria_id, decimal moneda_id, DateTime desde, DateTime hasta, string parte_texto)
        {
            //Solo los cheques que no estan rechazados, depositados, utilizados ni efectivizados y que
            //ademas ya vencieron (pueden ser efectivizados o depositados)
            string clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CtacteCajaTesoreriaId_NombreCol + " = " + ctacte_caja_tesoreria_id + " and " +
                               CuentaCorrienteCajasTesoreriaMovimientosService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.Cheque + " and " +
                               CuentaCorrienteCajasTesoreriaMovimientosService.MonedaId_NombreCol + " = " + moneda_id + " and " +
                               CuentaCorrienteCajasTesoreriaMovimientosService.Egreso_NombreCol + " is null and " +
                               CuentaCorrienteCajasTesoreriaMovimientosService.VistaCtacteChequeRecibidoEstadoId_NombreCol + " = " + Definiciones.CuentaCorrienteChequesEstados.AlDia + " and " + 
                               " (" + CuentaCorrienteCajasTesoreriaMovimientosService.VistaCtacteChequeRecibidoVen_NombreCol+ " between trunc(to_date('" + desde + "','dd/mm/yyyy hh24:mi:ss'),'DD') and trunc(to_date('" + hasta + "','dd/mm/yyyy hh24:mi:ss'),'DD') ) ";

            if(parte_texto.Length > 0)
            {
                decimal monto;

                clausulas += " and ( " +
                            "   upper(" + CuentaCorrienteCajasTesoreriaMovimientosService.VistaCtacteChequeRecibidoEmisor_NombreCol + ") like '%" + parte_texto.ToUpper() + "%' or " +
                            "   upper(" + CuentaCorrienteCajasTesoreriaMovimientosService.VistaCtacteChequeRecibidoNumero_NombreCol + ") like '%" + parte_texto.ToUpper() + "%' ";

                if (decimal.TryParse(parte_texto, out monto))
                    clausulas += " or " + CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso_NombreCol + " = " + monto + " ";

                clausulas += ") ";
            }

            DataTable dt = CuentaCorrienteCajasTesoreriaMovimientosService.GetCuentaCorrienteCajasTesoreriaMovimientosInfoCompleta2(clausulas, CuentaCorrienteCajaService.VistaCtacteChequeRecibidoEmisor_NombreCol);
            return dt;
        }
        
        /// <summary>
        /// Gets the cheques recibidos en caja.
        /// </summary>
        /// <param name="ctacte_caja_tesoreria_id">The ctacte_caja_tesoreria_id.</param>
        /// <returns></returns>
        public static DataTable GetChequesRecibidosEnCaja(decimal ctacte_caja_tesoreria_id)
        {
            CuentaCorrienteCajasTesoreriaMovimientosService ctacteCajaMov = new CuentaCorrienteCajasTesoreriaMovimientosService();

            //Solo los cheques que no estan rechazados, depositados, utilizados ni efectivizados y que
            //ademas ya vencieron (pueden ser efectivizados o depositados)
            string clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CtacteCajaTesoreriaId_NombreCol + " = " + ctacte_caja_tesoreria_id + " and " +
                               CuentaCorrienteCajasTesoreriaMovimientosService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.Cheque + " and " +                              
                               CuentaCorrienteCajasTesoreriaMovimientosService.VistaCtacteChequeRecibidoEstadoId_NombreCol + " in(" + Definiciones.CuentaCorrienteChequesEstados.AlDia + "," + Definiciones.CuentaCorrienteChequesEstados.AlDia + ")"; 

            DataTable dt = ctacteCajaMov.GetCuentaCorrienteCajasTesoreriaMovimientosInfoCompleta(clausulas, CuentaCorrienteCajaService.VistaCtacteChequeRecibidoEmisor_NombreCol);
            return dt;
        }
        #endregion GetChequesRecibidosEnCaja

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    CTACTE_CAJAS_TESORERIARow row = new CTACTE_CAJAS_TESORERIARow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_sucursal_sqc");
                        row.FECHA_CREACION = DateTime.Now;
                        row.USUARIO_CREACION_ID = sesion.Usuario.ID;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.CTACTE_CAJAS_TESORERIACollection.GetRow(CuentaCorrienteCajasTesoreriaService.Id_NombreCol + " = " + campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.ABREVIATURA = (string)campos[CuentaCorrienteCajasTesoreriaService.Abreviatura_NombreCol];
                    row.ESTADO = (string)campos[CuentaCorrienteCajasTesoreriaService.Estado_NombreCol];
                    row.NOMBRE = (string)campos[CuentaCorrienteCajasTesoreriaService.Nombre_NombreCol];

                    if (VerificarOrdenLibre((decimal)campos[CuentaCorrienteCajasTesoreriaService.Orden_NombreCol], (decimal) row.ID))
                        row.ORDEN = (decimal)campos[CuentaCorrienteCajasTesoreriaService.Orden_NombreCol];
                    else
                        throw new Exception("El orden de la caja no está disponible.");

                    //Si se modifico
                    if (row.SUCURSAL_ID != (decimal)campos[CuentaCorrienteCajasTesoreriaService.SucursalId_NombreCol])
                    {
                        //Se verifica que este activo
                        if (SucursalesService.EstaActivo((decimal)campos[CuentaCorrienteCajasTesoreriaService.SucursalId_NombreCol]))
                            row.SUCURSAL_ID = (decimal)campos[CuentaCorrienteCajasTesoreriaService.SucursalId_NombreCol];
                        else
                            throw new Exception("La sucursal no se encuentra activa.");
                    }
                    if (campos.Contains(CuentaCorrienteCajasTesoreriaService.POSId_NombreCol))
                        row.POS_ID = (decimal)campos[CuentaCorrienteCajasTesoreriaService.POSId_NombreCol];
                    else
                        row.IsPOS_IDNull = true;

                    if (insertarNuevo) sesion.Db.CTACTE_CAJAS_TESORERIACollection.Insert(row);
                    else sesion.Db.CTACTE_CAJAS_TESORERIACollection.Update(row);

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
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CAJAS_TESORERIA"; }
        }
        public static string Nombre_Vista 
        {
            get { return "ctacte_cajas_teso_info_comp"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIACollection.ABREVIATURAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIACollection.ESTADOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIACollection.FECHA_CREACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIACollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIACollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIACollection.ORDENColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIACollection.SUCURSAL_IDColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIACollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string POSId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIACollection.POS_IDColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_INFO_COMPCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaPOSNombre_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_INFO_COMPCollection.POS_NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrienteCajasTesoreriaService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrienteCajasTesoreriaService(e.RegistroId, sesion);
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
        protected CTACTE_CAJAS_TESORERIARow row;
        protected CTACTE_CAJAS_TESORERIARow rowSinModificar;
        public class Modelo : CTACTE_CAJAS_TESORERIACollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Abreviatura { get { return ClaseCBABase.GetStringHelper(row.ABREVIATURA); } set { row.ABREVIATURA = value; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public decimal Orden { get { return row.ORDEN; } private set { row.ORDEN = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } private set { row.SUCURSAL_ID = value; } }
        public decimal UsuarioCreacionId { get { return row.USUARIO_CREACION_ID; } private set { row.USUARIO_CREACION_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                    this._sucursal = new SucursalesService(this.SucursalId);
                return this._sucursal;
            }
        }
        
        private UsuariosService _usuario_creacion;
        public UsuariosService UsuarioCreacion
        {
            get
            {
                if (this._usuario_creacion == null)
                    this._usuario_creacion = new UsuariosService(this.UsuarioCreacionId);
                return this._usuario_creacion;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_CAJAS_TESORERIACollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_CAJAS_TESORERIARow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_CAJAS_TESORERIARow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrienteCajasTesoreriaService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteCajasTesoreriaService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteCajasTesoreriaService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CuentaCorrienteCajasTesoreriaService(EdiCBA.CajaTesoreria edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = DepositosBancariosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);
            
            this.Abreviatura = edi.abreviatura;
            this.Nombre = edi.nombre;
            
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
            
            this.UsuarioCreacionId = Definiciones.Usuarios.Soporte;
            this.Estado = Definiciones.Estado.Activo;
            this.FechaCreacion = DateTime.Now;
            this.Orden = 0;
        }
        private CuentaCorrienteCajasTesoreriaService(CTACTE_CAJAS_TESORERIARow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._sucursal = null;
            this._usuario_creacion = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.CajaTesoreria()
            {
                abreviatura = this.Abreviatura,
                nombre = this.Nombre,
                sucursal_uuid = this.Sucursal.GetOrCreateUUID(sesion),
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
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
