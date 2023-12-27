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
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.NotasCreditoPersona;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosCostosCierresService : ClaseCBA<ArticulosCostosCierresService>
    {
        #region Permisos
        public Permiso Permisos = new Permiso();
        public class Permiso
        {
            private bool? _articulosCostosCierresEditar;
            public bool ArticulosCostosCierresEditar { get { if (this._articulosCostosCierresEditar == null) _articulosCostosCierresEditar = RolesService.Tiene("ARTICULOS COSTOS CIERRES EDITAR"); return this._articulosCostosCierresEditar.Value; } }
        }
        #endregion Permisos

        #region Propiedades
        protected ARTICULOS_COSTOS_CIERRESRow row;
        protected ARTICULOS_COSTOS_CIERRESRow rowSinModificar;
        public class Modelo : ARTICULOS_COSTOS_CIERRESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? ArticuloCostoCierreAnteriorId { get { if(row.IsART_COSTO_CIERRE_ANTERIOR_IDNull) return null; else return row.ART_COSTO_CIERRE_ANTERIOR_ID; } set { if(value.HasValue) row.ART_COSTO_CIERRE_ANTERIOR_ID = value.Value; else row.IsART_COSTO_CIERRE_ANTERIOR_IDNull = true; } }
        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime FechaCierre { get { return row.FECHA_CIERRE; } set { row.FECHA_CIERRE = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal? RegionId { get { if(row.IsREGION_IDNull) return null; else return row.REGION_ID; } set { if(value.HasValue) row.REGION_ID = value.Value; else row.IsREGION_IDNull = true; } }
        public decimal UsuarioCreacionId { get { return row.USUARIO_CREACION_ID; } set { row.USUARIO_CREACION_ID = value; } }
        #endregion Propiedades
        
        #region Propiedades Extendidas
        private ArticulosCostosCierresService _articulo_costo_cierre_anterior;
        public ArticulosCostosCierresService ArticuloCostoCierreAnterior
        {
            get
            {
                if (this._articulo_costo_cierre_anterior == null)
                    this._articulo_costo_cierre_anterior = this.Get<ArticulosCostosCierresService>(this.ArticuloCostoCierreAnteriorId.Value);
                return this._articulo_costo_cierre_anterior;
            }
        }
        
        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = this.Get<MonedasService>(this.MonedaId);
                return this._moneda;
            }
        }

        private RegionesService _region;
        public RegionesService Region
        {
            get
            {
               if (this._region == null)
                {
                    if (this.sesion != null)
                        this._region = new RegionesService(this.RegionId.Value, this.sesion);
                    else
                        this._region = new RegionesService(this.RegionId.Value);
                }
                return this._region;
            }
        }

        private UsuariosService _usuario_creacion;
        public UsuariosService UsuarioCreacion
        {
            get
            {
                if (this._usuario_creacion == null)
                {
                    if (this.sesion != null)
                        this._usuario_creacion = new UsuariosService(this.UsuarioCreacionId, this.sesion);
                    else
                        this._usuario_creacion = new UsuariosService(this.UsuarioCreacionId);
                }
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
                this.row = sesion.db.ARTICULOS_COSTOS_CIERRESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ARTICULOS_COSTOS_CIERRESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(ARTICULOS_COSTOS_CIERRESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public ArticulosCostosCierresService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ArticulosCostosCierresService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ArticulosCostosCierresService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private ArticulosCostosCierresService(ARTICULOS_COSTOS_CIERRESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            //Si se está creando y no se establecía el cierre anterior, tratar de seleccionarlo
            if (!this.ExisteEnDB && !this.ArticuloCostoCierreAnteriorId.HasValue)
            {
                var lFiltros = new List<ClaseCBABase.Filtro>();
                if (this.RegionId.HasValue)
                    lFiltros.Add(new Filtro() { Columna = ArticulosCostosCierresService.Modelo.REGION_IDColumnName, Valor = this.RegionId.Value });
                else
                    lFiltros.Add(new Filtro() { Columna = ArticulosCostosCierresService.Modelo.REGION_IDColumnName, Comparacion = "is", Valor = "null" });

                lFiltros.Add(new ClaseCBABase.Filtro() { Columna = ArticulosCostosCierresService.Modelo.FECHA_CIERREColumnName, OrderBy = true, Valor = "desc" });

                var acc = this.GetPrimero<ArticulosCostosCierresService>(lFiltros);

                if (acc != null)
                    this.ArticuloCostoCierreAnteriorId = acc.Id.Value;
            }

            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                this.UsuarioCreacionId = sesion.Usuario.ID;
                this.FechaCreacion = DateTime.Now;

                sesion.db.ARTICULOS_COSTOS_CIERRESCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);

                //Crear los detalles del cierre. Las siguientes llamadas al guaradar
                //pueden modificar las propiedades del cierre pero recalcula los detalles
                this.CrearDetalles();
            }
            else
            {
                sesion.db.ARTICULOS_COSTOS_CIERRESCollection.Update(this.row);
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

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticulosCostosIndependiente) == Definiciones.SiNo.Si)
            {
                if (!this.RegionId.HasValue)
                    excepciones.Agregar("Debe indicar la región.");
            }

            if (this.Cotizacion <= 0)
                excepciones.Agregar("La cotización no es válida.");

            if (!this.ExisteEnDB && this.ArticuloCostoCierreAnteriorId.HasValue)
            {
                //El cierre anterior no puede estar como anterior de otro cierre más
                var acc = this.GetPrimero<ArticulosCostosCierresService>(new Filtro() 
                {
                    Columna = Modelo.ART_COSTO_CIERRE_ANTERIOR_IDColumnName, Valor = this.ArticuloCostoCierreAnteriorId.Value
                });

                if (acc != null)
                    excepciones.Agregar("El cierre anterior seleccionado ya es cierre anterior de la fecha " + acc.FechaCierre.ToShortDateString() + ".");
            }

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._articulo_costo_cierre_anterior = null;
            this._moneda = null;
            this._region = null;
            this._usuario_creacion = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override ArticulosCostosCierresService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

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
                        case Modelo.ART_COSTO_CIERRE_ANTERIOR_IDColumnName:
                        case Modelo.COTIZACIONColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.MONEDA_IDColumnName:
                        case Modelo.REGION_IDColumnName:
                        case Modelo.USUARIO_CREACION_IDColumnName:
                            if(f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + f.Valor + ")");
                            break;
                        case Modelo.FECHA_CIERREColumnName:
                        case Modelo.FECHA_CREACIONColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.FECHA_CIERREColumnName);
            var rows = sesion.db.ARTICULOS_COSTOS_CIERRESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            ArticulosCostosCierresService[] acc = new ArticulosCostosCierresService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                acc[i] = new ArticulosCostosCierresService(rows[i]);
            return acc;
        }
        #endregion Buscar

        #region BuscarDetalle
        public ArticulosCostosCierresDetallesService BuscarDetalle(decimal articulo_id)
        {
            if (!this.ArticuloCostoCierreAnteriorId.HasValue)
                return null;

            var accd = this.GetPrimero<ArticulosCostosCierresDetallesService>(new Filtro[]
            {
                new Filtro() { Columna = ArticulosCostosCierresDetallesService.Modelo.ARTICULO_COSTO_CIERRE_IDColumnName, Valor = this.ArticuloCostoCierreAnteriorId.Value },
                new Filtro() { Columna = ArticulosCostosCierresDetallesService.Modelo.ARTICULO_IDColumnName, Valor = articulo_id }
            });
            return accd;
        }
        #endregion BuscarDetalle

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

        #region Borrar
        public void Borrar()
        {
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    this.IniciarUsingSesion(sesion);
                    this.Borrar(sesion);
                    this.FinalizarUsingSesion();
                }
            }
            else
            {
                this.Borrar(this.sesion);
            }
        }
        public void Borrar(SessionService sesion)
        {
            var cierrePosterior = this.GetPrimero<ArticulosCostosCierresService>(new Filtro() { Columna = Modelo.ART_COSTO_CIERRE_ANTERIOR_IDColumnName, Valor = this.Id.Value });
            if (cierrePosterior != null)
            {
                cierrePosterior.IniciarUsingSesion(this.sesion);
                cierrePosterior.Borrar();
                cierrePosterior.FinalizarUsingSesion();
            }

            foreach (var accd in this.GetFiltrado<ArticulosCostosCierresDetallesService>(new Filtro() { Columna = ArticulosCostosCierresDetallesService.Modelo.ARTICULO_COSTO_CIERRE_IDColumnName, Valor = this.Id.Value }))
            {
                accd.IniciarUsingSesion(sesion);
                accd.Borrar();
                accd.FinalizarUsingSesion();
            }

            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

        #region CrearDetalles
        private void CrearDetalles()
        {
            bool costoIndependientePorRegion = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticulosCostosIndependiente) == Definiciones.SiNo.Si;

            //Orden en que se evaluan los movimientos
            var lTiposMovimiento = new List<string[]>()
            {
                new string[] { Definiciones.Stock.TipoMovimiento.Compra, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.Compra, "<" },
                new string[] { Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.NotaCreditoCliente, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.AjustePositivo, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.AjusteNegativo, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.UsoDeInsumo, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.UsoDeInsumo, "<" },
                new string[] { Definiciones.Stock.TipoMovimiento.Venta, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.Remision, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.Venta, "<" },
                new string[] { Definiciones.Stock.TipoMovimiento.Remision, "<" },
                new string[] { Definiciones.Stock.TipoMovimiento.CombosCreados, ">" }, //artículo resultante
                new string[] { Definiciones.Stock.TipoMovimiento.CombosEliminado, ">" }, //artículo resultante
                new string[] { Definiciones.Stock.TipoMovimiento.TransferenciaEntrada, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.TransferenciaSalida, ">" },
                new string[] { Definiciones.Stock.TipoMovimiento.CombosCreados, "<" }, //artículo insumo
                new string[] { Definiciones.Stock.TipoMovimiento.CombosEliminado, "<" }, //artículo insumo
            };

            //Obtener los artículo que estuvieron en los depósitos
            var dtStockSucDepositoArticulo = StockService.GetArticulosDistintos(this.sesion);
            
            List<Filtro>lFiltros = new List<Filtro>();
            //El valor se establece en cada iteración
            Filtro fArticulo = new Filtro() { Columna = StockMovimientoService.Modelo.ARTICULO_IDColumnName };
            lFiltros.Add(fArticulo);
            Filtro fTipoMovimiento = new Filtro() { Columna = StockMovimientoService.Modelo.TIPO_MOVIMIENTOColumnName };
            lFiltros.Add(fTipoMovimiento);

            //La comparación se establece en cada iteración
            Filtro fCantidad = new Filtro() { Columna = StockMovimientoService.Modelo.CANTIDADColumnName, Valor = 0m };
            lFiltros.Add(fCantidad);

            if(this.ArticuloCostoCierreAnteriorId.HasValue)
                lFiltros.Add(new Filtro() { Columna = StockMovimientoService.Modelo.FECHA_FORMULARIOColumnName, Valor = this.ArticuloCostoCierreAnterior.FechaCierre.Date, Comparacion = ">" });
            lFiltros.Add(new Filtro() { Columna = StockMovimientoService.Modelo.FECHA_FORMULARIOColumnName, Valor = this.FechaCierre.Date, Comparacion = "<=" });
            if (this.RegionId.HasValue)
                lFiltros.Add(new Filtro() { Columna = StockMovimientoService.FiltroExtension.SucursalRegionId, Valor = this.RegionId.Value });
            lFiltros.Add(new Filtro() { Columna = StockMovimientoService.Modelo.FECHA_FORMULARIOColumnName, OrderBy = true });
            lFiltros.Add(new Filtro() { Columna = StockMovimientoService.Modelo.CANTIDADColumnName, OrderBy = true, Valor = "desc" });

            var filtros = lFiltros.ToArray();

            DateTime? movimientosFechaDesde = null;
            if(this.ArticuloCostoCierreAnteriorId.HasValue)
                movimientosFechaDesde = this.ArticuloCostoCierreAnterior.FechaCierre.Date.AddDays(1);
            var articulosConMovimiento = StockMovimientoService.ArticulosConMovimiento(movimientosFechaDesde, this.FechaCierre, this.RegionId, this.sesion);

            for (int i = 0; i < dtStockSucDepositoArticulo.Rows.Count; i++)
            {
                var accd = new ArticulosCostosCierresDetallesService()
                {
                    ArticuloCostoCierreId = this.Id.Value,
                    ArticuloId = (decimal)dtStockSucDepositoArticulo.Rows[i][StockService.ArticuloId_NombreCol],
                    CantidadAnterior = 0,
                    CantidadVariacionNegativa = 0,
                    CantidadVariacionPositiva = 0,
                    CostoAnterior = 0
                };

                //Buscar el detalle de cierre para el mismo lote en el cierre anterior
                var accdAnterior = this.BuscarDetalle(accd.ArticuloId);

                if (accdAnterior != null)
                {
                    accd.CantidadAnterior = accdAnterior.CantidadAnterior + accdAnterior.CantidadVariacionPositiva - accdAnterior.CantidadVariacionNegativa;
                    accd.CostoAnterior = accdAnterior.CostoActual;
                    
                    //Se parte del antrior para ir promediando con los movimientos posteriores
                    accd.CostoActual = accd.CostoAnterior;
                }

                //Buscar el conjunto de movimientos entre la fecha del cierre y el cierre anterior
                //ordenando por movimientos de ingreso, egreso y luego transferencias
                fArticulo.Valor = (decimal)dtStockSucDepositoArticulo.Rows[i][StockService.ArticuloId_NombreCol];

                if (articulosConMovimiento.Contains((decimal)fArticulo.Valor))
                {
                    foreach (var tm in lTiposMovimiento)
                    {
                        fTipoMovimiento.Valor = tm[0];
                        fCantidad.Comparacion = tm[1];

                        CrearDetallesCalcular(filtros, ref accd, tm[0], StockMovimientoService.MovimientoAfectaCantidad(tm[0], costoIndependientePorRegion));
                    }
                }

                try
                {
                    accd.IniciarUsingSesion(sesion);
                    accd.Guardar();
                    accd.FinalizarUsingSesion();
                }
                catch
                {
                    accd.FinalizarUsingSesion();
                    throw;
                }
            }
        }
        #endregion CrearDetalles

        #region CrearDetallesCalcular
        private void CrearDetallesCalcular(Filtro[] filtros, ref ArticulosCostosCierresDetallesService accd, string tipo_movimiento, bool movimiento_afecta_cantidad)
        {
            bool movimiento_afecta_costo = StockMovimientoService.MovimientoAfectaCosto(tipo_movimiento);

            foreach (var sm in this.GetFiltrado<StockMovimientoService>(filtros))
            {
                decimal signo = sm.MovimientoPositivo ? 1 : -1;
                if (movimiento_afecta_costo)
                {
                    //Si el movimiento es por nota de credito cliente, entonces
                    //hay que actualizar el costo al de la factura en que se basa por si cambió
                    //antes de calcular el nuevo costo promedio ponderado
                    if (tipo_movimiento == Definiciones.Stock.TipoMovimiento.NotaCreditoCliente)
                    {
                        var notaCreditoPersonaDet = new NotasCreditoPersonaDetalleService(sm.RegistroId, this.sesion);
                        if (TipoNotaCreditoService.AfectaStockSimple((int)notaCreditoPersonaDet.NotaCreditoPersona.TipoNotaCreditoId.Value))
                        {
                            sm.IniciarUsingSesion(this.sesion);
                            var smFacturaDet = sm.GetPrimero<StockMovimientoService>(new Filtro[]
                                {
                                    new Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = notaCreditoPersonaDet.FacturaCliente.CasoId },
                                    new Filtro() { Columna = StockMovimientoService.Modelo.REGISTRO_IDColumnName, Valor = notaCreditoPersonaDet.FacturaClienteDetalle.Id.Value },
                                    new Filtro() { Columna = StockMovimientoService.Modelo.IDColumnName, Valor = "desc", OrderBy = true },
                                }
                            );

                            if(smFacturaDet == null)
                                throw new Exception("Movimiento de factura " + notaCreditoPersonaDet.FacturaCliente.CasoId + " no encontrado.");

                            sm.Costo = smFacturaDet.Costo;
                            sm.Guardar();
                            sm.FinalizarUsingSesion();
                        }
                    }

                    if (accd.CantidadAnterior + accd.CantidadVariacionPositiva - accd.CantidadVariacionNegativa + sm.Cantidad * signo > 0)
                        accd.CostoActual = (accd.CostoActual * (accd.CantidadAnterior + accd.CantidadVariacionPositiva - accd.CantidadVariacionNegativa) + sm.Cantidad * signo * sm.Costo) / (accd.CantidadAnterior + accd.CantidadVariacionPositiva - accd.CantidadVariacionNegativa + sm.Cantidad * signo);
                    else
                        accd.CostoActual = 0;
                }
                else
                {
                    //Se actualiza el costo al del PPP
                    sm.IniciarUsingSesion(this.sesion);
                    sm.Costo = accd.CostoActual;
                    sm.Guardar();
                    sm.FinalizarUsingSesion();
                }

                if (movimiento_afecta_cantidad)
                {
                    if (signo > 0)
                        accd.CantidadVariacionPositiva += sm.Cantidad;
                    else
                        accd.CantidadVariacionNegativa += sm.Cantidad;
                }
            }
        }
        #endregion CrearDetallesCalcular

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_COSTOS_CIERRES"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "ARTICULOS_COSTOS_CIERRES_SQC"; }
        }
        #endregion Accessors
    }
}
