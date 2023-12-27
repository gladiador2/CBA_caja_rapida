using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Facturacion;

namespace CBA.FlowV2.Services.Stock
{
    public class StockMovimientoService : ClaseCBA<StockMovimientoService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string SucursalRegionId = "REGION_ID";
            public const string TipoMovimientoAfectaCostoOrdenamiento = "TIPO_MOVIMIENTO_AFECTA_COSTO";
        }
        #endregion FiltrosExtension

        #region Propiedades privadas
        public static string[] tiposMovimientoAfectanCosto = new string[] 
        {
            Definiciones.Stock.TipoMovimiento.Compra,
            Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor,
            Definiciones.Stock.TipoMovimiento.NotaCreditoCliente,
            Definiciones.Stock.TipoMovimiento.Industrializacion
        };
        #endregion Propiedades privadas

        #region Propiedades
        protected STOCK_MOVIMIENTOSRow row;
        protected STOCK_MOVIMIENTOSRow rowSinModificar;
        public class Modelo : STOCK_MOVIMIENTOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal ArticuloId { get { return row.ARTICULO_ID; } set { row.ARTICULO_ID = value; } }
        public decimal Cantidad { get { return row.CANTIDAD; } set { row.CANTIDAD = value; } }
        public decimal? CasoId { get { if (row.IsCASO_IDNull) return null; else return row.CASO_ID; } set { if (value.HasValue) row.CASO_ID = value.Value; else row.IsCASO_IDNull = true; } }
        public decimal Costo { get { return row.COSTO; } set { row.COSTO = value; } }
        public decimal CostoCotizacionMoneda { get { return row.COSTO_COTIZACION_MONEDA; } set { row.COSTO_COTIZACION_MONEDA = value; } }
        public decimal CostoCotizacionMonedaOrigen { get { return row.COSTO_COTIZACION_MONEDA_ORIGEN; } set { row.COSTO_COTIZACION_MONEDA_ORIGEN = value; } }
        public decimal CostoMonedaId { get { return row.COSTO_MONEDA_ID; } set { row.COSTO_MONEDA_ID = value; } }
        public decimal CostoMonedaOrigenId { get { return row.COSTO_MONEDA_ORIGEN_ID; } set { row.COSTO_MONEDA_ORIGEN_ID = value; } }
        public decimal CostoOrigen { get { return row.COSTO_ORIGEN; } set { row.COSTO_ORIGEN = value; } }
        public decimal DepositoId { get { return row.DEPOSITO_ID; } set { row.DEPOSITO_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime FechaFormulario { get { return row.FECHA_FORMULARIO; } set { row.FECHA_FORMULARIO = value; } }
        public DateTime FechaMovimiento { get { return row.FECHA_MOVIMIENTO; } set { row.FECHA_MOVIMIENTO= value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal ImpuestoId { get { return row.IMPUESTO_ID; } set { row.IMPUESTO_ID = value; } }
        public decimal LoteId { get { return row.LOTE_ID; } set { row.LOTE_ID = value; } }
        public decimal RegistroId { get { return row.REGISTRO_ID; } set { row.REGISTRO_ID = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public string TipoMovimiento { get { return row.TIPO_MOVIMIENTO; } set { row.TIPO_MOVIMIENTO = value; } }
        public decimal UsuarioId { get { return row.USUARIO_ID; } set { row.USUARIO_ID = value; } }
        #endregion Propiedades
        
        #region Propiedades Extendidas
        /// <summary>
        /// Debe retornar el ppp del ultimo cierre menor a la fecha formulario. 
        /// Si no existe ningun, movimiento retornar el ultimo movimiento de articulos_costos
        /// </summary>
        /// <value>
        /// The costo PPP.
        /// </value>
        public CBA.FlowV2.Services.Stock.StockService.Costo CostoPPP
        {
            get 
            {
                var lFiltros = new List<Filtro>();

                //La primera vez usar la igualdad al buscar para disminuir procesamiento
                var fFecha = new Filtro() { Columna = ArticulosCostosCierresDetallesService.FiltroExtension.ArticulosCostosCierreFecha, Valor = this.FechaFormulario };

                lFiltros.Add(new Filtro() { Columna = ArticulosCostosCierresDetallesService.Modelo.ARTICULO_IDColumnName, Valor = this.ArticuloId });
                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticulosCostosIndependiente) == Definiciones.SiNo.Si)
                    lFiltros.Add(new Filtro() { Columna = ArticulosCostosCierresDetallesService.FiltroExtension.ArticulosCostosCierreRegionId, Valor = this.Sucursal.RegionId.Value });
                lFiltros.Add(fFecha);
                lFiltros.Add(new Filtro() { Columna = ArticulosCostosCierresDetallesService.Modelo.IDColumnName, OrderBy = true, Valor = "desc" });
                
                var accd = this.GetFiltrado<ArticulosCostosCierresDetallesService>(lFiltros);
                if (accd.Length > 0)
                {
                    return new CBA.FlowV2.Services.Stock.StockService.Costo()
                    {
                        costo = accd[0].CostoActual,
                        moneda_id = accd[0].ArticuloCostoCierre.MonedaId,
                        cotizacion = accd[0].ArticuloCostoCierre.Cotizacion
                    };
                }
                
                //Si no se encontro un cierre cambiar la igualdad por menor o igual
                fFecha.Comparacion = "<=";
                accd = this.GetFiltrado<ArticulosCostosCierresDetallesService>(lFiltros);
                if (accd.Length > 0)
                {
                    return new CBA.FlowV2.Services.Stock.StockService.Costo()
                    {
                        costo = accd[0].CostoActual,
                        moneda_id = accd[0].ArticuloCostoCierre.MonedaId,
                        cotizacion = accd[0].ArticuloCostoCierre.Cotizacion
                    };
                }

                //Si no se encontro un cierre buscar el ultimo movimiento de ingreso del articulo
                //para obtener el costo origen y convertirlo a la moneda del país
                var sm = StockMovimientoService.UltimoIngreso(this.ArticuloId, this.SucursalId, this.FechaFormulario, this.sesion);
                if (sm != null)
                {
                    return new CBA.FlowV2.Services.Stock.StockService.Costo()
                    {
                        costo = sm.Costo,
                        moneda_id = sm.CostoMonedaId,
                        cotizacion = sm.CostoCotizacionMoneda
                    };
                }

                decimal monedaPaisId = PaisesService.GetMoneda(this.Sucursal.PaisId, sesion);

                //Si no se encontró un cierre ni movimiento de ingreso
                //intentar utilizar el costo inicial de la ficha de artículo
                if (this.Articulo.CostoBaseMonto.HasValue && this.Articulo.CostoBaseMonedaId.HasValue)
                {
                    if (this.Articulo.CostoBaseMonedaId.Value == monedaPaisId)
                    {
                        return new CBA.FlowV2.Services.Stock.StockService.Costo()
                        {
                            costo = this.Articulo.CostoBaseMonto.Value,
                            moneda_id = this.Articulo.CostoBaseMonedaId.Value,
                            cotizacion = this.Articulo.CostoBaseCotizacion.Value
                        };
                    }
                    else
                    {
                        var costo = new CBA.FlowV2.Services.Stock.StockService.Costo();
                        costo.moneda_id = monedaPaisId;
                        if (this.MovimientoPositivo)
                            costo.cotizacion = CotizacionesService.GetCotizacionMonedaVenta(this.Sucursal.PaisId, monedaPaisId, this.FechaFormulario, sesion);
                        else
                            costo.cotizacion = CotizacionesService.GetCotizacionMonedaCompra(this.Sucursal.PaisId, monedaPaisId, this.FechaFormulario, sesion);
                        costo.costo = this.Articulo.CostoBaseMonto.Value / this.Articulo.CostoBaseCotizacion.Value * costo.cotizacion;
                        return costo;
                    }
                }

                //Si no se encontró un costo ni la ficha tenía uno definido, retornar el costo origen 
                //convirtiendo la moneda de ser necesario
                if (this.CostoMonedaOrigenId == monedaPaisId)
                {
                    return new CBA.FlowV2.Services.Stock.StockService.Costo()
                    {
                        costo = this.CostoOrigen,
                        moneda_id = this.CostoMonedaOrigenId,
                        cotizacion = this.CostoCotizacionMonedaOrigen
                    };
                }
                else
                {
                    var costo = new CBA.FlowV2.Services.Stock.StockService.Costo();
                    costo.moneda_id = monedaPaisId; 
                    if(this.MovimientoPositivo)
                        costo.cotizacion = CotizacionesService.GetCotizacionMonedaVenta(this.Sucursal.PaisId, monedaPaisId, this.FechaFormulario, sesion);
                    else
                        costo.cotizacion = CotizacionesService.GetCotizacionMonedaCompra(this.Sucursal.PaisId, monedaPaisId, this.FechaFormulario, sesion);
                    costo.costo = this.CostoOrigen / this.CostoCotizacionMonedaOrigen * costo.cotizacion;
                    return costo;
                }
            }
        }

        public bool MovimientoPositivo
        {
            get
            {
                //Si el tipo de movimiento no es combo y aumenta la existencia
                if(this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.AjustePositivo |
                   this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.Compra |
                   this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.Industrializacion |
                   this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.NotaCreditoCliente |
                   this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.NotaDebitoProveedor |
                   this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.TransferenciaEntrada)
                {
                    return true;
                }
                //Si es un combo que se esta creando
                else if (this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.CombosCreados && this.Articulo.esCombo == Definiciones.SiNo.Si)
                {
                    return true;
                }
                //Si es un item del combo que se esta eliminando
                else if (this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.CombosEliminado && this.Articulo.esCombo == Definiciones.SiNo.No)
                {
                    return true;
                }
                
                return false;
            }
        }

        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                {
                    if (this.sesion != null)
                        this._articulo = new ArticulosService(this.ArticuloId, this.sesion);
                    else
                        this._articulo = new ArticulosService(this.ArticuloId);
                }
                return this._articulo;
            }
        }

        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    if (this.sesion != null)
                        this._caso = new CasosService(this.CasoId.Value, this.sesion);
                    else
                        this._caso = new CasosService(this.CasoId.Value);
                }
                return this._caso;
            }
        }

        private MonedasService _costo_moneda;
        public MonedasService CostoMoneda
        {
            get
            {
                if (this._costo_moneda == null)
                    this._costo_moneda = this.Get<MonedasService>(this.CostoMonedaId);
                return this._costo_moneda;
            }
        }

        private MonedasService _costo_moneda_origen;
        public MonedasService CostoMonedaOrigen
        {
            get
            {
                if (this._costo_moneda_origen == null)
                    this._costo_moneda_origen = this.Get<MonedasService>(this.CostoMonedaOrigenId);
                return this._costo_moneda_origen;
            }
        }

        private StockDepositosService _deposito;
        public StockDepositosService Deposito
        {
            get
            {
                if (this._deposito == null)
                {
                    if (this.sesion != null)
                        this._deposito = new StockDepositosService(this.DepositoId, this.sesion);
                    else
                        this._deposito = new StockDepositosService(this.DepositoId);
                }
                return this._deposito;
            }
        }

        private ImpuestosService _impuesto;
        public ImpuestosService Impuesto
        {
            get
            {
                if (this._impuesto == null)
                    this._impuesto = this.Get<ImpuestosService>(this.ImpuestoId);
                return this._impuesto;
            }
        }

        private ArticulosLotesService _lote;
        public ArticulosLotesService Lote
        {
            get
            {
                if (this._lote == null)
                {
                    if (this.sesion != null)
                        this._lote = new ArticulosLotesService(this.LoteId, this.sesion);
                    else
                        this._lote = new ArticulosLotesService(this.LoteId);
                }
                return this._lote;
            }
        }

        private UsuariosService _usuario;
        public UsuariosService Usuario
        {
            get
            {
                if (this._usuario == null)
                {
                    if (this.sesion != null)
                        this._usuario = new UsuariosService(this.UsuarioId, this.sesion);
                    else
                        this._usuario = new UsuariosService(this.UsuarioId);
                }
                return this._usuario;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                {
                    if (this.sesion != null)
                        this._sucursal = new SucursalesService(this.SucursalId, this.sesion);
                    else
                        this._sucursal = new SucursalesService(this.SucursalId);
                }
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
                this.row = sesion.db.STOCK_MOVIMIENTOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_MOVIMIENTOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(STOCK_MOVIMIENTOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public StockMovimientoService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockMovimientoService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockMovimientoService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private StockMovimientoService(STOCK_MOVIMIENTOSRow row)
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
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                this.UsuarioId = sesion.Usuario.ID;
                this.FechaMovimiento = DateTime.Now;

                if (this.DepositoId != this.rowSinModificar.DEPOSITO_ID)
                    this.SucursalId = this.Deposito.SucursalId;

                if (this.Caso.FechaFormulario.HasValue)
                    this.FechaFormulario = this.Caso.FechaFormulario.Value;
                else
                    this.FechaFormulario = this.FechaMovimiento;

                //Si es un ingreso de stock proviniente de una factura de proveedor, usar la fecha de la factura
                if (this.Caso.FlujoId == Definiciones.FlujosIDs.INGRESO_DE_STOCK)
                {
                    var dtIngreso = IngresoStockService.GetIngresoStockDataTable(IngresoStockService.CasoId_NombreCol + " = " + this.CasoId, string.Empty, sesion);
                    if (!Interprete.EsNullODBNull(dtIngreso.Rows[0][IngresoStockService.CasoFcProveedorId_NombreCol]))
                    {
                        var dtFacturaProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + dtIngreso.Rows[0][IngresoStockService.CasoFcProveedorId_NombreCol], string.Empty, sesion);
                        if (dtFacturaProveedor.Rows.Count > 0)
                        {
                            this.FechaFormulario = (DateTime)dtFacturaProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol];
                            this.CostoCotizacionMoneda = (decimal)dtFacturaProveedor.Rows[0][FacturasProveedorService.MonedaPaisCotizacion_NombreCol];
                        }
                    }
                }

                if (this.ImpuestoId <= 0)
                {
                    if(this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.Compra || this.TipoMovimiento == Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor)
                        this.ImpuestoId = this.Articulo.ImpuestoCompraId.HasValue ? this.Articulo.ImpuestoCompraId.Value : this.Articulo.ImpuestoId;
                    else
                        this.ImpuestoId = this.Articulo.ImpuestoId;
                }

                //Si no se especificó el costo en la moneda del país
                //obtener el costo más apropiado para inicializar aunque
                //estos datos son sobre-escrito al hacer los cierres de costo de artículo
                if (this.CostoMonedaId <= 0)
                {
                    var costoPPP = this.CostoPPP;
                    this.Costo = costoPPP.costo;
                    this.CostoMonedaId = costoPPP.moneda_id;
                    this.CostoCotizacionMoneda = costoPPP.cotizacion;
                }

                //Si no se especificó el costo origen, utilizar el
                //expresado en la moneda del país que contiene el PPP
                if (this.CostoMonedaOrigenId <= 0)
                {
                    this.CostoOrigen = this.Costo;
                    this.CostoMonedaOrigenId = this.CostoMonedaId;
                    this.CostoCotizacionMonedaOrigen = this.CostoCotizacionMoneda;
                }

                sesion.db.STOCK_MOVIMIENTOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.STOCK_MOVIMIENTOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
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
            this._articulo = null;
            this._caso = null;
            this._costo_moneda = null;
            this._costo_moneda_origen = null;
            this._deposito = null;
            this._impuesto = null;
            this._lote = null;
            this._sucursal = null;
            this._usuario = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override StockMovimientoService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();

            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    switch (f.Columna)
                    {
                        case Modelo.FECHA_FORMULARIOColumnName:
                        case Modelo.FECHA_MOVIMIENTOColumnName:
                            orden.Add("trunc(" + f.Columna + ") " + f.Valor);
                            break;
                        case FiltroExtension.TipoMovimientoAfectaCostoOrdenamiento:
                            string ordenTipoMovimiento = "decode(" + Modelo.TIPO_MOVIMIENTOColumnName + ", ";
                            for (int i = 0; i < tiposMovimientoAfectanCosto.Length; i++)
                                 ordenTipoMovimiento += "'" + tiposMovimientoAfectanCosto[i] + "', 1, ";
                            ordenTipoMovimiento += "2) " + f.Valor;
                            orden.Add(ordenTipoMovimiento);
                            break;
                        default:
                            orden.Add(f.Columna + " " + f.Valor);
                            break;
                    }
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.ARTICULO_IDColumnName:
                        case Modelo.CANTIDADColumnName:
                        case Modelo.CASO_IDColumnName:
                        case Modelo.COSTO_MONEDA_IDColumnName:
                        case Modelo.COSTO_MONEDA_ORIGEN_IDColumnName:
                        case Modelo.COSTO_ORIGENColumnName:
                        case Modelo.COSTOColumnName:
                        case Modelo.DEPOSITO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.LOTE_IDColumnName:
                        case Modelo.REGISTRO_IDColumnName:
                        case Modelo.SUCURSAL_IDColumnName:
                        case Modelo.USUARIO_IDColumnName:
                            if(f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + f.Valor + ")");
                            break;
                        case Modelo.TIPO_MOVIMIENTOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") in ('" + (string.Join("','", (string[])f.Valor)).ToUpper() + "')");
                            break;
                        case Modelo.FECHA_FORMULARIOColumnName:
                        case Modelo.FECHA_MOVIMIENTOColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        case FiltroExtension.SucursalRegionId:
                            sb.Append(" exists(select * from " + SucursalesService.Nombre_Tabla + " s " +
                                         "         where s." + SucursalesService.Modelo.IDColumnName + " = " + Nombre_Tabla + "." + Modelo.SUCURSAL_IDColumnName +
                                         "           and s." + f.Columna + " = " + f.Valor + ") ");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.FECHA_FORMULARIOColumnName);
            STOCK_MOVIMIENTOSRow[] rows = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            StockMovimientoService[] afr = new StockMovimientoService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                afr[i] = new StockMovimientoService(rows[i]);
            return afr;
        }

        public static StockMovimientoService[] Buscar(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return Buscar(clausulas, orden, sesion);
            }
        }
        public static StockMovimientoService[] Buscar(string clausulas, string orden, SessionService sesion)
        {
            string where = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
            if (clausulas.Length > 0)
                where += " and (" + clausulas + ")"; 
            STOCK_MOVIMIENTOSRow[] rows = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(where, orden);
            StockMovimientoService[] sm = new StockMovimientoService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                sm[i] = new StockMovimientoService(rows[i]);
            return sm;
        }
        #endregion Buscar

        #region Borrar
        public void Borrar()
        {
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("Falta implementar.");
        }
        #endregion ToEDI

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "STOCK_MOVIMIENTOS"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "STOCK_MOVIMIENTOS_SQC"; }
        }
        #endregion Accessors

        #region ExisteMovimientoPosterior
        public static bool ExisteMovimientoPosterior(decimal caso_id, decimal lote_id, decimal deposito_id, SessionService sesion)
        {
            string sql = "select count(" + StockMovimientoService.Id_NombreCol + ") cantidad " +
                         "  from " + StockMovimientoService.Nombre_Tabla +
                         " where " + StockMovimientoService.LoteId_NombreCol + " = " + lote_id +
                         "   and " + StockMovimientoService.Deposito_Id_NombreCol + " = " + deposito_id +
                         "   and " + StockMovimientoService.Id_NombreCol + " > (select max(" +  StockMovimientoService.Id_NombreCol + ")" + 
                         "                                                        from " + StockMovimientoService.Nombre_Tabla +
                         "                                                       where " + StockMovimientoService.Caso_Id_NombreCol + " = " + caso_id +
                         "                                                      )";
            DataTable dt = sesion.db.EjecutarQuery(sql);
            return (decimal)dt.Rows[0][0] > 0;
        }
        #endregion ExisteMovimientoPosterior

        #region ArticulosConMovimiento
        public static List<decimal> ArticulosConMovimiento(DateTime? fecha_desde, DateTime? fecha_hasta, decimal? region_id, SessionService sesion)
        {
            var lArticulosId = new List<decimal>();
            string sql = "select distinct " + Modelo.ARTICULO_IDColumnName +
                         "  from " + Nombre_Tabla +
                         " where " + Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
            if (fecha_desde.HasValue)
                sql += " and trunc(" + Modelo.FECHA_FORMULARIOColumnName + ") >= to_date('" + fecha_desde.Value.ToShortDateString() + "', 'dd/mm/yyyy')";
            if (fecha_hasta.HasValue)
                sql += " and trunc(" + Modelo.FECHA_FORMULARIOColumnName + ") <= to_date('" + fecha_hasta.Value.ToShortDateString() + "', 'dd/mm/yyyy')";
            if(region_id.HasValue)
            {
                sql += " and " + Modelo.SUCURSAL_IDColumnName + 
                       " in (select " + SucursalesService.Modelo.IDColumnName +
                       "       from " + SucursalesService.Nombre_Tabla + " s " +
                       "      where s." + SucursalesService.Modelo.REGION_IDColumnName + " = " + region_id + ")";
            }

            var dt = sesion.db.EjecutarQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
                lArticulosId.Add((decimal)dt.Rows[i][Modelo.ARTICULO_IDColumnName]);

            return lArticulosId;
        }
        #endregion ArticulosConMovimiento

        #region UltimoIngreso
        public static StockMovimientoService UltimoIngreso(decimal articulo_id, decimal sucursal_id, DateTime? fecha, SessionService sesion)
        {
            var lFiltros = new List<Filtro>();

            lFiltros.Add(new Filtro() { Columna = Modelo.ARTICULO_IDColumnName, Valor = articulo_id });
            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticulosCostosIndependiente) == Definiciones.SiNo.Si)
            {
                var sucursal = new SucursalesService(sucursal_id, sesion);
                lFiltros.Add(new Filtro() { Columna = FiltroExtension.SucursalRegionId, Valor = sucursal.RegionId.Value });
            }

            //Buscar movimientos de compra y si no existen buscar ajustes positivos
            var fTipoMovimiento = new Filtro() { Columna = Modelo.TIPO_MOVIMIENTOColumnName, Valor = Definiciones.Stock.TipoMovimiento.Compra };
            lFiltros.Add(fTipoMovimiento);

            if (fecha.HasValue)
                lFiltros.Add(new Filtro() { Columna = Modelo.FECHA_FORMULARIOColumnName, Valor = fecha, Comparacion = "<=" });

            lFiltros.Add(new Filtro() { Columna = Modelo.IDColumnName, OrderBy = true, Valor = "desc" });

            var sm = StockMovimientoService.Instancia;
            sm.IniciarUsingSesion(sesion);
            var ultimoIngreso = sm.GetPrimero<StockMovimientoService>(lFiltros);

            if (ultimoIngreso == null)
            {
                //Buscar ajustes positivos
                fTipoMovimiento.Valor = Definiciones.Stock.TipoMovimiento.AjustePositivo;
                ultimoIngreso = sm.GetPrimero<StockMovimientoService>(lFiltros);
            }
            sm.FinalizarUsingSesion();

            return ultimoIngreso;
        }
        #endregion UltimoIngreso

        #region MovimientoAfectaCosto
        public static bool MovimientoAfectaCosto(string tipo_movimiento)
        {
            //El ajuste positivo tendria que moficiar (retornar true) pero:
            //- Actualmente no están los UserControl para ingresar el costo en la UI
            //- En StockAjusteDetalleService.Guardar se está tomando el último PPP por lo que retornar true interfiere con el cálculo de un nuevo PPP
            //Para retornar true hay que permitir que el usuario ingrese el dato desde la interfaz, pero no todos los clientes
            //quieren que los usuairos puedan hacerlo.
            return tiposMovimientoAfectanCosto.Contains(tipo_movimiento);
        }
        #endregion MovimientoAfectaCosto

        #region MovimientoAfectaCantidad
        public static bool MovimientoAfectaCantidad(string tipo_movimiento, bool costo_independiente_por_region)
        {
            if ((tipo_movimiento == Definiciones.Stock.TipoMovimiento.TransferenciaEntrada && !costo_independiente_por_region) |
                (tipo_movimiento == Definiciones.Stock.TipoMovimiento.TransferenciaSalida && !costo_independiente_por_region))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion MovimientoAfectaCantidad

        public CBA.FlowV2.Services.Stock.StockService.Costo GetCostoPPP(SessionService session)
        {
           
                var lFiltros = new List<Filtro>();

                //La primera vez usar la igualdad al buscar para disminuir procesamiento
                var fFecha = new Filtro() { Columna = ArticulosCostosCierresDetallesService.FiltroExtension.ArticulosCostosCierreFecha, Valor = this.FechaFormulario };

                lFiltros.Add(new Filtro() { Columna = ArticulosCostosCierresDetallesService.Modelo.ARTICULO_IDColumnName, Valor = this.ArticuloId });
                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticulosCostosIndependiente) == Definiciones.SiNo.Si)
                    lFiltros.Add(new Filtro() { Columna = ArticulosCostosCierresDetallesService.FiltroExtension.ArticulosCostosCierreRegionId, Valor = this.Sucursal.RegionId.Value });
                lFiltros.Add(fFecha);
                lFiltros.Add(new Filtro() { Columna = ArticulosCostosCierresDetallesService.Modelo.IDColumnName, OrderBy = true, Valor = "desc" });

                var accd = this.GetFiltrado<ArticulosCostosCierresDetallesService>(lFiltros);
                if (accd.Length > 0)
                {
                    return new CBA.FlowV2.Services.Stock.StockService.Costo()
                    {
                        costo = accd[0].CostoActual,
                        moneda_id = accd[0].ArticuloCostoCierre.MonedaId,
                        cotizacion = accd[0].ArticuloCostoCierre.Cotizacion
                    };
                }

                //Si no se encontro un cierre cambiar la igualdad por menor o igual
                fFecha.Comparacion = "<=";
                accd = this.GetFiltrado<ArticulosCostosCierresDetallesService>(lFiltros);
                if (accd.Length > 0)
                {
                    return new CBA.FlowV2.Services.Stock.StockService.Costo()
                    {
                        costo = accd[0].CostoActual,
                        moneda_id = accd[0].ArticuloCostoCierre.MonedaId,
                        cotizacion = accd[0].ArticuloCostoCierre.Cotizacion
                    };
                }

                //Si no se encontro un cierre buscar el ultimo movimiento de ingreso del articulo
                //para obtener el costo origen y convertirlo a la moneda del país
                var sm = StockMovimientoService.UltimoIngreso(this.ArticuloId, this.SucursalId, this.FechaFormulario,session);
                if (sm != null)
                {
                    return new CBA.FlowV2.Services.Stock.StockService.Costo()
                    {
                        costo = sm.Costo,
                        moneda_id = sm.CostoMonedaId,
                        cotizacion = sm.CostoCotizacionMoneda
                    };
                }

                decimal monedaPaisId = PaisesService.GetMoneda(this.Sucursal.PaisId, sesion);

                //Si no se encontró un cierre ni movimiento de ingreso
                //intentar utilizar el costo inicial de la ficha de artículo
                if (this.Articulo.CostoBaseMonto.HasValue && this.Articulo.CostoBaseMonedaId.HasValue)
                {
                    if (this.Articulo.CostoBaseMonedaId.Value == monedaPaisId)
                    {
                        return new CBA.FlowV2.Services.Stock.StockService.Costo()
                        {
                            costo = this.Articulo.CostoBaseMonto.Value,
                            moneda_id = this.Articulo.CostoBaseMonedaId.Value,
                            cotizacion = this.Articulo.CostoBaseCotizacion.Value
                        };
                    }
                    else
                    {
                        var costo = new CBA.FlowV2.Services.Stock.StockService.Costo();
                        costo.moneda_id = monedaPaisId;
                        if (this.MovimientoPositivo)
                            costo.cotizacion = CotizacionesService.GetCotizacionMonedaVenta(this.Sucursal.PaisId, monedaPaisId, this.FechaFormulario, sesion);
                        else
                            costo.cotizacion = CotizacionesService.GetCotizacionMonedaCompra(this.Sucursal.PaisId, monedaPaisId, this.FechaFormulario, sesion);
                        costo.costo = this.Articulo.CostoBaseMonto.Value / this.Articulo.CostoBaseCotizacion.Value * costo.cotizacion;
                        return costo;
                    }
                }

                //Si no se encontró un costo ni la ficha tenía uno definido, retornar el costo origen 
                //convirtiendo la moneda de ser necesario
                if (this.CostoMonedaOrigenId == monedaPaisId)
                {
                    return new CBA.FlowV2.Services.Stock.StockService.Costo()
                    {
                        costo = this.CostoOrigen,
                        moneda_id = this.CostoMonedaOrigenId,
                        cotizacion = this.CostoCotizacionMonedaOrigen
                    };
                }
                else
                {
                    var costo = new CBA.FlowV2.Services.Stock.StockService.Costo();
                    costo.moneda_id = monedaPaisId;
                    if (this.MovimientoPositivo)
                        costo.cotizacion = CotizacionesService.GetCotizacionMonedaVenta(this.Sucursal.PaisId, monedaPaisId, this.FechaFormulario, sesion);
                    else
                        costo.cotizacion = CotizacionesService.GetCotizacionMonedaCompra(this.Sucursal.PaisId, monedaPaisId, this.FechaFormulario, sesion);
                    costo.costo = this.CostoOrigen / this.CostoCotizacionMonedaOrigen * costo.cotizacion;
                    return costo;
                }
            
        }

        #region CODIGO VIEJO PRE ORIENTACION A OBJETOS


        #region Actualizar Costo de Movimiento
        public static void ActualizarCostoMovimiento(decimal caso_id, decimal articulo_id, DataRow costos, SessionService sesion)
        {
            string clausula = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' and " +
                              StockMovimientoService.Articulo_Id_NombreCol + "=" + articulo_id + " and " + StockMovimientoService.Caso_Id_NombreCol + "=" + caso_id;
            STOCK_MOVIMIENTOSRow[] movimientos = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausula, string.Empty);
            
            for (int i = 0; i < movimientos.Length; i++)
            {
                movimientos[i].COSTO = decimal.Parse(costos[CostosService.Costo_NombreCol].ToString());
                movimientos[i].COSTO_MONEDA_ID = decimal.Parse(costos[CostosService.MonedaId_NombreCol].ToString());
                movimientos[i].COSTO_COTIZACION_MONEDA = decimal.Parse(costos[CostosService.Cotizacion_NombreCol].ToString());
                sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientos[i]);
            }
        }
        #endregion Actualizar Costo de Movimiento

        #region Diferencias segun movimiento
        #region GetDiferenciaStockFechaMovimiento
        public static decimal GetDiferenciaStockFechaMovimiento(decimal articulo_id, string lote_id, decimal sucursal_id, decimal deposito_id,  DateTime fechaInicio,bool usarfechaInicio, DateTime fechaFin)
        {
            using (SessionService sesion = new SessionService())
            {
                string select = " select  tipo_movimiento, cantidad from stock_movimientos where "; 
                string clausulas = string.Empty;
                clausulas = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' and " +
                            StockMovimientoService.Articulo_Id_NombreCol + "=" + articulo_id;
                
                if(usarfechaInicio)
                    clausulas += " and " + "trunc(" + StockMovimientoService.Fecha_Movimiento_NombreCol + ") > to_date('" + fechaInicio.ToShortDateString() + "','dd/mm/yyyy') ";
                clausulas += " and " + "trunc(" + StockMovimientoService.Fecha_Movimiento_NombreCol + ") < to_date('" + fechaFin.ToShortDateString() + "','dd/mm/yyyy') ";
                
                //Datos no obligatorios
                if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.VistaSucursalId_NombreCol + "=" + sucursal_id;
                if (deposito_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.Deposito_Id_NombreCol + "=" + deposito_id;
                if (!lote_id.Equals(string.Empty))
                    clausulas += " and " + StockMovimientoService.LoteId_NombreCol + " in (" + lote_id + ")";

                decimal diferencia = 0;
                var movimientos = sesion.Db.EjecutarQuery(select + clausulas);
                // la consulta a esta vista hace lento al módulo de seguimiento de articulos
              //  STOCK_MOVIMIENTOSRow[] movimientos = sesion.Db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulas, StockMovimientoService.Fecha_Movimiento_NombreCol + "," + StockMovimientoService.Id_NombreCol);
                for (int i = 0; i < movimientos.Rows.Count; i++)
                {
                    switch (movimientos.Rows[i][StockMovimientoService.Tipo_Movimiento_NombreCol].ToString())
                    {
                        case Definiciones.Stock.TipoMovimiento.AjusteNegativo:
                            
                              diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                              //mov = Definiciones.Costos.TipoActualizacion.Disminuye;
                            break;
                        case Definiciones.Stock.TipoMovimiento.AjustePositivo:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                                //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Compra:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                                //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Industrializacion:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoCliente:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                           // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoCliente:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //Se agrega esto para poner un valor por defecto
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                           // mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoProveedor:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                           // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.PuntoMinimo:
                            throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        case Definiciones.Stock.TipoMovimiento.TransferenciaEntrada:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.TransferenciaSalida:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Transito:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //Se agrega esto para poner un valor por defecto
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Venta:
                        case Definiciones.Stock.TipoMovimiento.Remision:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.UsoDeInsumo:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosCreados:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());

                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;

                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosEliminado:

                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        default: throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                    }
                   
                }
                return diferencia;
            }
        }
        #endregion GetDiferenciaStockFechaMovimiento

        #region GetDiferenciaStockFechaHoraMovimiento
        public static decimal GetDiferenciaStockFechaHoraMovimiento(decimal articulo_id, decimal lote_id, decimal sucursal_id, decimal deposito_id, DateTime fechaInicio, bool usarfechaInicio, DateTime fechaFin)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = string.Empty;
                clausulas = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' and " +
                            StockMovimientoService.Articulo_Id_NombreCol + "=" + articulo_id;

                if (usarfechaInicio)
                    clausulas += " and " + StockMovimientoService.Fecha_Movimiento_NombreCol + " > to_date('" + fechaInicio.ToString() + "','dd/MM/yyyy HH24:MI:SS') ";
                
                clausulas += " and " + StockMovimientoService.Fecha_Movimiento_NombreCol + " < to_date('" + fechaFin.ToString() + "', 'dd/MM/yyyy HH24:MI:SS') ";

                //Datos no obligatorios
                if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.VistaSucursalId_NombreCol + "=" + sucursal_id;
                if (deposito_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.Deposito_Id_NombreCol + "=" + deposito_id;
                if (lote_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.LoteId_NombreCol + "=" + lote_id;

                decimal diferencia = 0;

                STOCK_MOVIMIENTO_INFO_COMPLRow[] movimientos = sesion.Db.STOCK_MOVIMIENTO_INFO_COMPLCollection.GetAsArray(clausulas, StockMovimientoService.Fecha_Movimiento_NombreCol + "," + StockMovimientoService.Id_NombreCol);
                for (int i = 0; i < movimientos.Length; i++)
                {
                    switch (movimientos[i].TIPO_MOVIMIENTO)
                    {
                        case Definiciones.Stock.TipoMovimiento.AjusteNegativo:

                            diferencia -= movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuye;
                            break;
                        case Definiciones.Stock.TipoMovimiento.AjustePositivo:
                            diferencia += movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Compra:
                            diferencia += movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Industrializacion:
                            throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoCliente:
                            diferencia += movimientos[i].CANTIDAD;
                            // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoCliente:
                            diferencia -= movimientos[i].CANTIDAD;
                            //Se agrega esto para poner un valor por defecto
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor:
                            diferencia -= movimientos[i].CANTIDAD;
                            // mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoProveedor:
                            diferencia += movimientos[i].CANTIDAD;
                            // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.PuntoMinimo:
                            throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        case Definiciones.Stock.TipoMovimiento.TransferenciaEntrada:
                              diferencia += movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.TransferenciaSalida:
                              diferencia -= movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Transito:
                            diferencia -= movimientos[i].CANTIDAD;
                            //Se agrega esto para poner un valor por defecto
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Venta:
                        case Definiciones.Stock.TipoMovimiento.Remision:
                            diferencia -= movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.UsoDeInsumo:
                            diferencia -= movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosCreados:
                            diferencia -= movimientos[i].CANTIDAD;

                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;

                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosEliminado:

                            diferencia += movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        default: throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                    }

                }
                return diferencia;
            }
        }
        public static decimal GetDiferenciaStockFechaHoraMovimientoConComparacionDeMovimientoActual(decimal articulo_id, decimal lote_id, decimal sucursal_id, decimal deposito_id, DateTime fechaInicio, bool usarfechaInicio, DateTime fechaFin, decimal caso_id,bool considerarTransferencia)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = string.Empty;
                clausulas = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' and " +
                            StockMovimientoService.Articulo_Id_NombreCol + "=" + articulo_id;
                

                if (usarfechaInicio)
                    clausulas += " and " + StockMovimientoService.Fecha_Movimiento_NombreCol + " > to_date('" + fechaInicio.ToString() + "','dd/MM/yyyy HH24:MI:SS') ";

                clausulas += " and " + StockMovimientoService.Fecha_Movimiento_NombreCol + " < to_date('" + fechaFin.ToString() + "', 'dd/MM/yyyy HH24:MI:SS') ";

                //Datos no obligatorios
                if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.VistaSucursalId_NombreCol + "=" + sucursal_id;
                if (deposito_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.Deposito_Id_NombreCol + "=" + deposito_id;


                decimal diferencia = StockService.GetStockInicial(StockService.ArticuloId_NombreCol + "=" + articulo_id);

                STOCK_MOVIMIENTO_INFO_COMPLRow[] movimientos = sesion.Db.STOCK_MOVIMIENTO_INFO_COMPLCollection.GetAsArray(clausulas, StockMovimientoService.Fecha_Movimiento_NombreCol + "," + StockMovimientoService.Id_NombreCol);
                
                for (int i = 0; i < movimientos.Length; i++)
                {
                    if (movimientos[i].CASO_ID == caso_id && movimientos[i].ARTICULO_ID == articulo_id && movimientos[i].LOTE_ID == lote_id)
                    {

                    }
                    else
                    {
                        switch (movimientos[i].TIPO_MOVIMIENTO)
                        {
                            case Definiciones.Stock.TipoMovimiento.AjusteNegativo:

                                diferencia -= movimientos[i].CANTIDAD;
                                //mov = Definiciones.Costos.TipoActualizacion.Disminuye;
                                break;
                            case Definiciones.Stock.TipoMovimiento.AjustePositivo:
                                diferencia += movimientos[i].CANTIDAD;
                                //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                                break;
                            case Definiciones.Stock.TipoMovimiento.Compra:
                                diferencia += movimientos[i].CANTIDAD;
                                //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                                break;
                            case Definiciones.Stock.TipoMovimiento.Industrializacion:
                                throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                            case Definiciones.Stock.TipoMovimiento.NotaCreditoCliente:
                                diferencia += movimientos[i].CANTIDAD;
                                // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                                break;
                            case Definiciones.Stock.TipoMovimiento.NotaDebitoCliente:
                                diferencia -= movimientos[i].CANTIDAD;
                                //Se agrega esto para poner un valor por defecto
                                //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                                break;
                            case Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor:
                                diferencia -= movimientos[i].CANTIDAD;
                                // mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                                break;
                            case Definiciones.Stock.TipoMovimiento.NotaDebitoProveedor:
                                diferencia += movimientos[i].CANTIDAD;
                                // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                                break;
                            case Definiciones.Stock.TipoMovimiento.PuntoMinimo:
                                throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                            case Definiciones.Stock.TipoMovimiento.TransferenciaEntrada:
                                //if (considerarTransferencia)
                                    diferencia += movimientos[i].CANTIDAD;
                                //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                                break;
                            case Definiciones.Stock.TipoMovimiento.TransferenciaSalida:
                                //if (considerarTransferencia)
                                    diferencia -= movimientos[i].CANTIDAD;
                                //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                                break;
                            case Definiciones.Stock.TipoMovimiento.Transito:
                                diferencia -= movimientos[i].CANTIDAD;
                                //Se agrega esto para poner un valor por defecto
                                //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                                break;
                            case Definiciones.Stock.TipoMovimiento.Venta:
                            case Definiciones.Stock.TipoMovimiento.Remision:
                                diferencia -= movimientos[i].CANTIDAD;
                                //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                                break;
                            case Definiciones.Stock.TipoMovimiento.UsoDeInsumo:
                                diferencia -= movimientos[i].CANTIDAD;
                                //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                                break;
                            case Definiciones.Stock.TipoMovimiento.CombosCreados:
                                diferencia -= movimientos[i].CANTIDAD;

                                //mov = Definiciones.Costos.TipoActualizacion.Disminuir;

                                break;
                            case Definiciones.Stock.TipoMovimiento.CombosEliminado:

                                diferencia += movimientos[i].CANTIDAD;
                                //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                                break;
                            default: throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        }
                    }

                }
                return diferencia;
            }
        }
        #endregion GetDiferenciaStockFechaHoraMovimiento
        #endregion Diferencias segun movimiento

        #region  Diferencias segun formulario
        #region GetDiferenciaStockFechaFormulario
        public static decimal GetDiferenciaStockFechaFormulario(decimal articulo_id, string lote_id, decimal sucursal_id, decimal deposito_id, DateTime fechaInicio, bool usarfechaInicio, DateTime fechaFin)
        {
            using (SessionService sesion = new SessionService())
            {
                string select = " select  tipo_movimiento, cantidad from stock_movimientos where "; 
                string clausulas = string.Empty;
                clausulas = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' and " +
                            StockMovimientoService.Articulo_Id_NombreCol + "=" + articulo_id;

                if (usarfechaInicio)
                    clausulas += " and " + "trunc(" + StockMovimientoService.Fecha_Formulario_NombreCol + ") > to_date('" + fechaInicio.ToShortDateString() + "','dd/mm/yyyy') ";
                clausulas += " and " + "trunc(" + StockMovimientoService.Fecha_Formulario_NombreCol + ") < to_date('" + fechaFin.ToShortDateString() + "','dd/mm/yyyy') ";

                //Datos no obligatorios
                if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.VistaSucursalId_NombreCol + "=" + sucursal_id;
                if (deposito_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.Deposito_Id_NombreCol + "=" + deposito_id;
                if (!lote_id.Equals(string.Empty))
                    clausulas += " and " + StockMovimientoService.LoteId_NombreCol + " in (" + lote_id + ")";

                decimal diferencia = 0;

                var movimientos = sesion.Db.EjecutarQuery(select + clausulas);
                // la consulta a esta vista hace lento al módulo de seguimiento de articulos
              //  STOCK_MOVIMIENTO_INFO_COMPLRow[] movimientos = sesion.Db.STOCK_MOVIMIENTO_INFO_COMPLCollection.GetAsArray(clausulas, StockMovimientoService.Fecha_Formulario_NombreCol + "," + StockMovimientoService.Id_NombreCol);
                for (int i = 0; i < movimientos.Rows.Count; i++)
                {
                    switch (movimientos.Rows[i][StockMovimientoService.Tipo_Movimiento_NombreCol].ToString())
                    {
                        case Definiciones.Stock.TipoMovimiento.AjusteNegativo:

                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuye;
                            break;
                        case Definiciones.Stock.TipoMovimiento.AjustePositivo:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Compra:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Industrializacion:
                            //throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoCliente:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoCliente:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //Se agrega esto para poner un valor por defecto
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            // mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoProveedor:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.PuntoMinimo:
                            throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        case Definiciones.Stock.TipoMovimiento.TransferenciaEntrada:
                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.TransferenciaSalida:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Transito:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //Se agrega esto para poner un valor por defecto
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Venta:
                        case Definiciones.Stock.TipoMovimiento.Remision:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.UsoDeInsumo:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosCreados:
                            diferencia -= Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());

                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;

                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosEliminado:

                            diferencia += Decimal.Parse(movimientos.Rows[i][StockMovimientoService.Cantidad_NombreCol].ToString());
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        default: throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                    }

                }
                return diferencia;
            }
        }
        #endregion GetDiferenciaStockFechaFormulario

        #region GetDiferenciaStockFechaHoraMovimiento
        public static decimal GetDiferenciaStockFechaHoraFormulario(decimal articulo_id, decimal lote_id, decimal sucursal_id, decimal deposito_id, DateTime fechaInicio, bool usarfechaInicio, DateTime fechaFin)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = string.Empty;
                clausulas = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' and " +
                            StockMovimientoService.Articulo_Id_NombreCol + "=" + articulo_id;

                if (usarfechaInicio)
                    clausulas += " and " + StockMovimientoService.Fecha_Formulario_NombreCol + " > to_date('" + fechaInicio.ToString() + "','dd/MM/yyyy HH24:MI:SS') ";

                clausulas += " and " + StockMovimientoService.Fecha_Formulario_NombreCol + " < to_date('" + fechaFin.ToString() + "', 'dd/MM/yyyy HH24:MI:SS') ";

                //Datos no obligatorios
                if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.VistaSucursalId_NombreCol + "=" + sucursal_id;
                if (deposito_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.Deposito_Id_NombreCol + "=" + deposito_id;
                if (lote_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausulas += " and " + StockMovimientoService.LoteId_NombreCol + "=" + lote_id;

                decimal diferencia = 0;

                STOCK_MOVIMIENTO_INFO_COMPLRow[] movimientos = sesion.Db.STOCK_MOVIMIENTO_INFO_COMPLCollection.GetAsArray(clausulas, StockMovimientoService.Fecha_Formulario_NombreCol + "," + StockMovimientoService.Id_NombreCol);
                for (int i = 0; i < movimientos.Length; i++)
                {
                    switch (movimientos[i].TIPO_MOVIMIENTO)
                    {
                        case Definiciones.Stock.TipoMovimiento.AjusteNegativo:

                            diferencia -= movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuye;
                            break;
                        case Definiciones.Stock.TipoMovimiento.AjustePositivo:
                            diferencia += movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Compra:
                            diferencia += movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Industrializacion:
                            throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoCliente:
                            diferencia += movimientos[i].CANTIDAD;
                            // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoCliente:
                            diferencia -= movimientos[i].CANTIDAD;
                            //Se agrega esto para poner un valor por defecto
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor:
                            diferencia -= movimientos[i].CANTIDAD;
                            // mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoProveedor:
                            diferencia += movimientos[i].CANTIDAD;
                            // mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.PuntoMinimo:
                            throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        case Definiciones.Stock.TipoMovimiento.TransferenciaEntrada:
                            diferencia += movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        case Definiciones.Stock.TipoMovimiento.TransferenciaSalida:
                            diferencia -= movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Transito:
                            diferencia -= movimientos[i].CANTIDAD;
                            //Se agrega esto para poner un valor por defecto
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Venta:
                        case Definiciones.Stock.TipoMovimiento.Remision:
                            diferencia -= movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.UsoDeInsumo:
                            diferencia -= movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;
                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosCreados:
                            diferencia -= movimientos[i].CANTIDAD;

                            //mov = Definiciones.Costos.TipoActualizacion.Disminuir;

                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosEliminado:

                            diferencia += movimientos[i].CANTIDAD;
                            //mov = Definiciones.Costos.TipoActualizacion.Aumentar;
                            break;
                        default: throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                    }

                }
                return diferencia;
            }
        }
        #endregion GetDiferenciaStockFechaHoraMovimiento
        #endregion Diferencias segun formulario

        #region Accessors
        #region Tablas
        public static string Id_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.IDColumnName; }
        }
        public static string Articulo_Id_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName; }
        }
        public static string Deposito_Id_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.DEPOSITO_IDColumnName; }
        }
        public static string Caso_Id_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.CASO_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.CANTIDADColumnName; }
        }
        public static string Fecha_Movimiento_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.FECHA_MOVIMIENTOColumnName; }
        }
        public static string Fecha_Formulario_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.FECHA_FORMULARIOColumnName; }
        }
        public static string Existencia_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.EXISTENCIAColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.LOTE_IDColumnName; }
        }
        public static string Tipo_Movimiento_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.TIPO_MOVIMIENTOColumnName; }
        }
        public static string Usuario_Id_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.USUARIO_IDColumnName; }
        }
        public static string CostoMonedaId_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.COSTO_MONEDA_IDColumnName; }
        }
        public static string Costo_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.COSTOColumnName; }
        }
        public static string CostoCotizacionMoneda_NombreCol
        {
            get { return STOCK_MOVIMIENTOSCollection.COSTO_COTIZACION_MONEDAColumnName; }
        }
        #endregion Tablas

        #region Vistas
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloFamiliaDescripcion_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ARTICULO_FAMILIA_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloGrupoDescripcion_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ARTICULO_GRUPO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ARTICULO_GRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoDescripcion_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ARTICULO_SUBGRUPO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ARTICULO_SUBGRUPO_IDColumnName; }
        }
        public static string VistaDepositoAbreviatura_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.DEPOSITO_ABREVIATURAColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaEstadoAnteriorId_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ESTADO_ANTERIOR_IDColumnName; }
        }
        public static string VistaEstadoId_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ESTADO_IDColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.FLUJO_IDColumnName; }
        }
        public static string VistaLote_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.LOTEColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalId_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.USUARIO_NOMBREColumnName; }
        }
        public static string VistaUsuario_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.USUARIOColumnName; }
        }
        public static string VistaCostoMonedaNombre_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.COSTO_MONEDA_NOMBREColumnName; }
        }
        public static string VistaCostoMonedaSimbolo_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.MONEDA_COSTO_SOMBOLOColumnName; }
        }
        public static string VistaCostoMonedaCadenaDecimales_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.MON_COSTO_CADE_DECIMALESColumnName; }
        }
        public static string VistaCostoMonedaCantidadDecimales_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.MON_COSTO_CANT_DECIMALESColumnName; }
        }
        public static string VistaTransferenciaDestino_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.DESTINOColumnName; }
        }
        public static string VistaCostoPPP_NombreCol
        {
            get { return STOCK_MOVIMIENTO_INFO_COMPLCollection.COSTO_PPPColumnName; }
        }      
        #endregion Vistas

        #region Calculados
        public static string MovimientoPositivo_NombreCol
        { get { return "movimiento_positivo"; } }
        public static string MovimientoNegativo_NombreCol
        { get { return "movimiento_negativo"; } }
       
        #endregion Calculados

        #endregion Accessors
        #endregion CODIGO VIEJO PRE ORIENTACION A OBJETOS
    }
}
