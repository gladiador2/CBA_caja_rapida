using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Activos
{
    public class ActivosService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal activo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ACTIVOSRow activo = sesion.Db.ACTIVOSCollection.GetRow(Id_NombreCol + " = " + activo_id);
                return activo.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region ActualizarSucursal
        public static void ActualizarSucursal(decimal id, decimal? sucursal_id, SessionService sesion)
        {
            ACTIVOSRow row = sesion.db.ACTIVOSCollection.GetByPrimaryKey(id);
            if (sucursal_id.HasValue)
                row.SUCURSAL_ID = sucursal_id.Value;
            else
                row.IsSUCURSAL_IDNull = true;
            sesion.db.ACTIVOSCollection.Update(row);
        }
        #endregion ActualizarSucursal

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            if (Validar(campos[Id_NombreCol].ToString(), campos[Codigo_NombreCol].ToString(), sesion))
            {
                try
                {
                    ACTIVOSRow row = new ACTIVOSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("activos_sqc");
                        row.ENTIDAD_ID = sesion.Entidad.ID;
                    }
                    else
                    {
                        row = sesion.Db.ACTIVOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.INGRESO_APROBADO = campos[IngresoAprobado_NombreCol].ToString();
                    row.CODIGO = campos[Codigo_NombreCol].ToString();
                    row.MONTO_COMPRA = Decimal.Parse(campos[MontoCompra_NombreCol].ToString());

                    if (campos.Contains(CentroCostoId_NombreCol))
                        row.CENTRO_COSTO_ID = Decimal.Parse(campos[CentroCostoId_NombreCol].ToString());
                    else
                        row.IsCENTRO_COSTO_IDNull = true;

                    if (campos.Contains(MonedaCompraId_NombreCol))
                        row.MONEDA_COMPRA_ID = Decimal.Parse(campos[MonedaCompraId_NombreCol].ToString());

                    if (campos.Contains(CotizacionMoneda_NombreCol))
                        row.COTIZACION_MONEDA = Decimal.Parse(campos[CotizacionMoneda_NombreCol].ToString());

                    if (campos.Contains(InmuebleID_NombreCol))
                        row.INMUEBLE_ID = Decimal.Parse(campos[InmuebleID_NombreCol].ToString());
                    else 
                        row.IsINMUEBLE_IDNull = true;
                    
                    if (campos.Contains(VehiculoId_NombreCol))
                        row.VEHICULO_ID = Decimal.Parse(campos[VehiculoId_NombreCol].ToString());
                    else 
                        row.IsVEHICULO_IDNull = true;

                    if (campos.Contains(Fecha_Compra_NombreCol))
                        row.FECHA_COMPRA = (DateTime)campos[Fecha_Compra_NombreCol];
                    else
                        row.IsFECHA_COMPRANull = true;

                    if (campos.Contains(SucursalId_NombreCol))
                        row.SUCURSAL_ID = Decimal.Parse(campos[SucursalId_NombreCol].ToString());

                    if (campos.Contains(ActivoRubroId_NombreCol))
                        row.ACTIVO_RUBRO_ID = (decimal)campos[ActivoRubroId_NombreCol];

                    if (campos.Contains(TipoActivoId_NombreCol))
                        row.TIPO_ACTIVO_ID = (decimal)campos[TipoActivoId_NombreCol];

                    if (campos.Contains(CasoRelacionadoId_NombreCol))
                        row.CASO_RELACIONADO_ID = Decimal.Parse(campos[CasoRelacionadoId_NombreCol].ToString());

                    if (campos.Contains(Articulo_ID_NombreCol))
                        row.ARTICULO_ID = Decimal.Parse(campos[Articulo_ID_NombreCol].ToString());
                    else
                        row.IsARTICULO_IDNull = true;

                    if (insertarNuevo) sesion.Db.ACTIVOSCollection.Insert(row);
                    else sesion.Db.ACTIVOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
                catch (OracleException exp)
                {
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("La entidad que está asociando al Activo ya existe");
                        default:
                            throw exp;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Get Activos Info Completa
        /// <summary>
        /// Gets the activos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        /// 
        public static DataTable GetActivosInfoCompleta(string orden, bool soloActivos)
        {
            string where = string.Empty;

            if (soloActivos)
            {
                where = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " + IngresoAprobado_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
            }

            return GetActivosInfoCompleta(where, orden);
        }
        public static DataTable GetActivosInfoCompleta(string orden, bool soloActivos,decimal sucursal_id)
        {
                string where = string.Empty;
                where = "(" + SucursalId_NombreCol + " is null or " + SucursalId_NombreCol + " = " + sucursal_id + ")";
                
                if (soloActivos) 
                {
                    where =  " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " + IngresoAprobado_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
                }
                
                return GetActivosInfoCompleta(where, orden);
        }
        public static DataTable GetActivosInfoCompleta(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ACTIVOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }
        public static DataTable GetActivosInfoCompleta(string clausulas, string orden, bool busquedaFlexible)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                //Desactivar. Distinguir o no mayusculas, minusculas y tildes.
                if (busquedaFlexible) sesion.Db.IniciarBusquedaFlexible();

                dt = sesion.Db.ACTIVOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);

                //Reactivar. Distinguir o no mayusculas, minusculas y tildes.
                if (busquedaFlexible) sesion.Db.FinalizarBusquedaFlexible();

                return dt;
            }
        }

        #endregion Get Activos Info Completa

        #region Get Activos Info Completa Filtrado
        public static DataTable GetActivosInfoCompletaFiltrado(string texto_buscado, bool busqueda_flexible, bool solo_activos)
        {
            return GetActivosInfoCompletaFiltrado(texto_buscado, string.Empty, busqueda_flexible, solo_activos);
        }

        public static DataTable GetActivosInfoCompletaFiltrado(string texto_buscado, string clausulas_extra, bool busqueda_flexible, bool solo_activos) 
        {
            decimal cantidadMinimaCaracteres = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.BusquedaCantidadMinimaCaracteres);
            if (texto_buscado.Trim().Length < cantidadMinimaCaracteres)
                throw new Exception("La cantidad mínima de carácteres de filtrado es " + cantidadMinimaCaracteres + ".");

            string txt = texto_buscado.Replace(' ', '%').ToUpper();

            string clausulas = "(" +
                               "     upper(" + ActivosService.Nombre_NombreCol + ") like '%" + txt + "%' or " +
                               "     upper(" + ActivosService.Codigo_NombreCol + ") like '%" + txt + "%'" +
                               ")";
            if (clausulas_extra.Length > 0)
                clausulas += " and (" + clausulas_extra + ")";

            return GetActivosInfoCompleta(clausulas, ActivosService.Nombre_NombreCol, busqueda_flexible);
        }
        #endregion Get Activos Info Completa Filtrado

        #region GetCentroCosto
        public static decimal GetCentroCosto(decimal activo_id, SessionService sesion)
        {
            ACTIVOSRow row = sesion.Db.ACTIVOSCollection.GetByPrimaryKey(activo_id);
            return row.IsCENTRO_COSTO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CENTRO_COSTO_ID;
        }
        #endregion GetCentroCosto

        #region Validar
        private static bool Validar(string activo_id, string codigo, SessionService sesion) 
        {
            bool valido;
            try
            {
                string clausulas = Id_NombreCol + " <> " + activo_id + " and " + Codigo_NombreCol + " = '" + codigo + "'";
                
                ACTIVOSRow activo = sesion.Db.ACTIVOSCollection.GetRow(clausulas);

                if (activo == null)
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                    throw new Exception("El código ya existe.");
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return valido;
        }
        #endregion Validar

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "ACTIVOS"; }
        }
        public static string CasoRelacionadoId_NombreCol
        {
            get { return ACTIVOSCollection.CASO_RELACIONADO_IDColumnName; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return ACTIVOSCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string Codigo_NombreCol
        {
            get { return ACTIVOSCollection.CODIGOColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return ACTIVOSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ACTIVOSCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ACTIVOSCollection.IDColumnName; }
        }
        public static string IngresoAprobado_NombreCol
        {
            get { return ACTIVOSCollection.INGRESO_APROBADOColumnName; }
        }
        public static string InmuebleID_NombreCol
        {
            get { return ACTIVOSCollection.INMUEBLE_IDColumnName; }
        }
        public static string MonedaCompraId_NombreCol
        {
            get { return ACTIVOSCollection.MONEDA_COMPRA_IDColumnName; }
        }
        public static string MontoCompra_NombreCol
        {
            get { return ACTIVOSCollection.MONTO_COMPRAColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ACTIVOSCollection.NOMBREColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return ACTIVOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string TipoActivoId_NombreCol
        {
            get { return ACTIVOSCollection.TIPO_ACTIVO_IDColumnName; }
        }
        public static string ActivoRubroId_NombreCol
        {
            get { return ACTIVOSCollection.ACTIVO_RUBRO_IDColumnName; }
        }
        public static string VehiculoId_NombreCol
        {
            get { return ACTIVOSCollection.VEHICULO_IDColumnName; }
        }
        public static string Fecha_Compra_NombreCol
        {
            get { return ACTIVOSCollection.FECHA_COMPRAColumnName; }
        }
        public static string Articulo_ID_NombreCol
        {
            get { return ACTIVOSCollection.ARTICULO_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "activos_info_completa"; }
        }
        public static string VistaActivoRubroDescripcion_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.ACTIVO_RUBRO_DESCRIPCIONColumnName; }
        }
        public static string VistaId_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.IDColumnName; }
        }
        public static string VistaCodigoDescripcion_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.CODIGO_DESCRIPCIONColumnName; }
        }
        public static string VistaCodigo_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.CODIGOColumnName; }
        }
        public static string VistaEntidad_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaInmuebleNombre_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.INMUEBLE_NOMBREColumnName; }
        }
        public static string VistaTipoActivoNombre_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.ACTIVO_RUBRO_DESCRIPCIONColumnName; }
        }
        public static string VistaVehiculoNombre_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.VEHICULO_NOMBREColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaVidaUtil_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.ACTIVO_RUBRO_VIDA_UTIL_ANHOSColumnName; }
        }
        public static string VistaCodigoArticulo_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloId_NombreCol
        {
            get { return ACTIVOS_INFO_COMPLETACollection.ARTICULO_IDColumnName; }
        }
        #endregion Vista
        
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected ACTIVOSRow row;
        protected ACTIVOSRow rowSinModificar;
        public class Modelo : ACTIVOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? CentroCostoId { get { if (row.IsCENTRO_COSTO_IDNull) return null; else return row.CENTRO_COSTO_ID; } set { if (value.HasValue) row.CENTRO_COSTO_ID = value.Value; else row.IsCENTRO_COSTO_IDNull = true; } }
        public string Codigo { get { return ClaseCBABase.GetStringHelper(row.CODIGO); } set { row.CODIGO = value; } }
        public decimal? CotizacionMonenda { get { if (row.IsCOTIZACION_MONEDANull) return null; else return row.COTIZACION_MONEDA; } set { if (value.HasValue) row.COTIZACION_MONEDA = value.Value; else row.IsCOTIZACION_MONEDANull = true; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public DateTime? FechaCompra { get { if (row.IsFECHA_COMPRANull) return null; else return row.FECHA_COMPRA; } set { if (value.HasValue) row.FECHA_COMPRA = value.Value; else row.IsFECHA_COMPRANull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string IngresoAprobado { get { return ClaseCBABase.GetStringHelper(row.INGRESO_APROBADO); } set { row.INGRESO_APROBADO = value; } }
        public decimal? InmuebleId { get { if (row.IsINMUEBLE_IDNull) return null; else return row.INMUEBLE_ID; } set { if (value.HasValue) row.INMUEBLE_ID = value.Value; else row.IsINMUEBLE_IDNull = true; } }
        public decimal? MonedaCompraId { get { if (row.IsMONEDA_COMPRA_IDNull) return null; else return row.MONEDA_COMPRA_ID; } set { if (value.HasValue) row.MONEDA_COMPRA_ID = value.Value; else row.IsMONEDA_COMPRA_IDNull = true; } }
        public decimal? MontoCompraId { get { if (row.IsMONTO_COMPRANull) return null; else return row.MONTO_COMPRA; } set { if (value.HasValue) row.MONTO_COMPRA = value.Value; else row.IsMONTO_COMPRANull = true; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public decimal? SucursalId { get { if (row.IsSUCURSAL_IDNull) return null; else return row.SUCURSAL_ID; } set { this._sucursal = null; if (value.HasValue) row.SUCURSAL_ID = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        public decimal? VehiculoId { get { if (row.IsVEHICULO_IDNull) return null; else return row.VEHICULO_ID; } set { if (value.HasValue) row.VEHICULO_ID = value.Value; else row.IsVEHICULO_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
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
                this.row = sesion.db.ACTIVOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ACTIVOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public ActivosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ActivosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ActivosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
           this._sucursal = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}

