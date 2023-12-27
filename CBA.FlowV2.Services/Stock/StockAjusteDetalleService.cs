#region Using
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
#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class StockAjusteDetalleService
    {

        #region GetStockAjusteDetalleDataTable

        /// <summary>
        /// Gets the stock ajuste detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public DataTable GetStockAjusteDetalleDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_AJUSTE_DETALLECollection.GetAsDataTable(clausula,string.Empty);
            }
        }
        /// <summary>
        /// Gets the stock ajuste detalle data table.
        /// </summary>
        /// <param name="stock_ajuste_id">The stock_ajuste_id.</param>
        /// <returns></returns>
        public DataTable GetStockAjusteDetalleDataTable(decimal stock_ajuste_id)
        {
            string clausula = StockAjusteDetalleService.StockAjusteId_NombreCol + " = " + stock_ajuste_id;
            return GetStockAjusteDetalleDataTable(clausula);
        }
        #endregion GetStockAjusteDetalleDataTable

        #region GetStockAjusteDetalleInfoCompleta
        /// <summary>
        /// Gets the stock ajuste detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetStockAjusteDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStockAjusteDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetStockAjusteDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.db.STOCK_AJUSTE_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetStockAjusteDetalleInfoCompleta

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            STOCK_AJUSTE_DETALLERow row = new STOCK_AJUSTE_DETALLERow();
            string valorAnterior = string.Empty;

            var dtAjuste = StockAjusteService.GetStockAjusteDataTable(StockAjusteService.Id_NombreCol + " = " + campos[StockAjusteDetalleService.StockAjusteId_NombreCol], string.Empty, sesion);

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("stock_ajuste_detalle_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.STOCK_AJUSTE_DETALLECollection.GetRow(StockAjusteDetalleService.Id_NombreCol + " = " + campos[StockAjusteDetalleService.Id_NombreCol]);
                valorAnterior = row.ToString();
            }
            row.STOCK_AJUSTE_ID = (decimal)campos[StockAjusteDetalleService.StockAjusteId_NombreCol];
            row.ARTICULO_ID = (decimal)campos[StockAjusteDetalleService.ArticuloId_NombreCol];
            row.LOTE_ID = (decimal)campos[StockAjusteDetalleService.LoteId_NombreCol];
            row.UNIDAD_MEDIDA_DESTINO_ID = (string)campos[StockAjusteDetalleService.UnidadMedidaDestino_NombreCol];
            
            row.CANTIDAD_DESTINO = (decimal)campos[StockAjusteDetalleService.CantidadDestino_NombreCol];
            
            row.OBSERVACION = (string)campos[StockAjusteDetalleService.Observacion_NombreCol];
            
            //se obtiene la unidad principal del articulo
            DataTable dtArticulo = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + row.ARTICULO_ID, string.Empty, false, (decimal)dtAjuste.Rows[0][StockAjusteService.SucursalId_NombreCol]);

            
            row.UNIDAD_MEDIDA_ORIGEN_ID = dtArticulo.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();

            //se obtiene el factor de conversion de entre la unidad principal(origen) y la unidad de medida destino
            row.FACTOR_CONVERSION = (new ArticulosConversionesService()).GetFactorConversion(row.ARTICULO_ID, row.UNIDAD_MEDIDA_DESTINO_ID, (decimal)dtAjuste.Rows[0][StockAjusteService.SucursalId_NombreCol]);
            row.CANTIDAD_ORIGEN = row.CANTIDAD_DESTINO / row.FACTOR_CONVERSION;

            #region Obtener el costoPPP
            var smTmp = new StockMovimientoService()
            {
                TipoMovimiento = row.CANTIDAD_ORIGEN > 0 ? Definiciones.Stock.TipoMovimiento.AjustePositivo : Definiciones.Stock.TipoMovimiento.AjusteNegativo,
                ArticuloId = row.ARTICULO_ID,
                LoteId = row.LOTE_ID,
                SucursalId = (decimal)dtAjuste.Rows[0][StockAjusteService.SucursalId_NombreCol],
                CostoOrigen = 0,
                CostoMonedaOrigenId = (decimal)dtAjuste.Rows[0][StockAjusteService.MonedaId_NombreCol],
                CostoCotizacionMonedaOrigen = (decimal)dtAjuste.Rows[0][StockAjusteService.Cotizacion_NombreCol],
                FechaFormulario = (DateTime)dtAjuste.Rows[0][StockAjusteService.Fecha_Creacion_NombreCol],
            };
            smTmp.IniciarUsingSesion(sesion);
            var costoPPP = smTmp.CostoPPP;
            smTmp.FinalizarUsingSesion();
            #endregion Obtener el costoPPP

            row.MONEDA_ID = costoPPP.moneda_id;
            row.COTIZACION = costoPPP.cotizacion;
            row.COSTO_UNITARIO = costoPPP.costo;
            
            if (row.CANTIDAD_DESTINO < 0)
                row.COSTO_TOTAL = row.COSTO_UNITARIO * row.FACTOR_CONVERSION * (row.CANTIDAD_DESTINO * -1);
            else
                row.COSTO_TOTAL = row.COSTO_UNITARIO * row.FACTOR_CONVERSION * row.CANTIDAD_DESTINO;

            row.COSTO_UNITARIO = row.COSTO_UNITARIO * row.FACTOR_CONVERSION;

            //cantidades que vienen desde el inventario
            if (campos.Contains(InventarioCantidadEncontrada_NombreCol))
                row.INVENTARIO_CANT_ENCONTRADA = (decimal)campos[InventarioCantidadEncontrada_NombreCol];
            else
                row.INVENTARIO_CANT_ENCONTRADA = 0;

            if (campos.Contains(InventarioCantidadSistema_NombreCol))
                row.INVENTARIO_CANT_SISTEMA = (decimal)campos[InventarioCantidadSistema_NombreCol];
            else
                row.INVENTARIO_CANT_SISTEMA = 0;

            if (insertarNuevo) sesion.Db.STOCK_AJUSTE_DETALLECollection.Insert(row);
            else sesion.Db.STOCK_AJUSTE_DETALLECollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            StockAjusteService.ActualizarTotal(row.STOCK_AJUSTE_ID, sesion);
            ActualizarCabecera(row.STOCK_AJUSTE_ID, sesion);
        }
        #endregion Guardar

        #region Editar Cantidad
        /// <summary>
        /// Actualizar cantidad origen y destino
        /// </summary>
        /// <param name="stock_detalle_id">ID del detalle</param>
        /// <param name="cantidad">Cantidad nueva</param>
        public static void EditarCantidad(decimal stock_detalle_id, decimal cantidad)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    STOCK_AJUSTE_DETALLERow row = sesion.Db.STOCK_AJUSTE_DETALLECollection.GetByPrimaryKey(stock_detalle_id);
                    DataTable dtCabecera = StockAjusteService.GetStockAjusteDataTable(StockAjusteService.Id_NombreCol + " = " + row.STOCK_AJUSTE_ID, string.Empty, sesion);
                    
                    string valorAnterior = row.ToString();
                    row.CANTIDAD_DESTINO = cantidad;
                    row.CANTIDAD_ORIGEN = row.CANTIDAD_DESTINO / row.FACTOR_CONVERSION;

                    var costoPPP = CostosService.GetCosto(row.ARTICULO_ID, (decimal)dtCabecera.Rows[0][StockAjusteService.DepositoId_NombreCol], (DateTime)dtCabecera.Rows[0][StockAjusteService.Fecha_Creacion_NombreCol], sesion);

                    row.COSTO_UNITARIO = costoPPP.costo * row.FACTOR_CONVERSION;
                    row.COSTO_TOTAL = row.COSTO_UNITARIO * row.CANTIDAD_DESTINO;

                    if (row.CANTIDAD_DESTINO < 0)
                        row.COSTO_TOTAL *= -1;

                    sesion.Db.STOCK_AJUSTE_DETALLECollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    StockAjusteService.ActualizarTotal(row.STOCK_AJUSTE_ID, sesion);
                    ActualizarCabecera(row.STOCK_AJUSTE_ID, sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }

        #endregion Editar Cantidad

        #region Borrar
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    STOCK_AJUSTE_DETALLERow row = new STOCK_AJUSTE_DETALLERow();
                    row = sesion.Db.STOCK_AJUSTE_DETALLECollection.GetByPrimaryKey(detalles_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.STOCK_AJUSTE_DETALLECollection.DeleteByPrimaryKey(detalles_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();

                    StockAjusteService.ActualizarTotal(row.STOCK_AJUSTE_ID, sesion);
                    ActualizarCabecera(row.STOCK_AJUSTE_ID, sesion);
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Borrar

        #region ActualizarCabecera 
        private static void ActualizarCabecera(decimal ajuste_id, SessionService sesion)
        {
            decimal costo = 0;
            STOCK_AJUSTERow cabecera = sesion.Db.STOCK_AJUSTECollection.GetByPrimaryKey(ajuste_id);
            STOCK_AJUSTE_DETALLERow[] detalles = sesion.Db.STOCK_AJUSTE_DETALLECollection.GetBySTOCK_AJUSTE_ID(ajuste_id);

            for (int i = 0; i < detalles.Length; i++)
            {
                if (cabecera.MONEDA_ID != detalles[i].MONEDA_ID)
                    costo += detalles[i].COSTO_TOTAL / detalles[i].COTIZACION * cabecera.COTIZACION;
                else
                    costo += detalles[i].COSTO_TOTAL;
            }

            cabecera.COSTO_TOTAL = costo;
            sesion.Db.STOCK_AJUSTECollection.Update(cabecera);
        }
        #endregion ActualizarCabecera 

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "STOCK_AJUSTE_DETALLE"; }
        }
        public static string Nombre_Vista
        {
            get { return "STOCK_AJUSTE_DET_INFO_COMPLETA"; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.MONEDA_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.COTIZACIONColumnName; }
        }
        public static string CostoUnitario_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.COSTO_UNITARIOColumnName; }
        }
        public static string StockAjusteId_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.STOCK_AJUSTE_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.ARTICULO_IDColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.LOTE_IDColumnName; }
        }
        public static string UnidadMedidaDestino_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.UNIDAD_MEDIDA_DESTINO_IDColumnName; }
        }
        public static string CantidadDestino_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.CANTIDAD_DESTINOColumnName; }
        }
        public static string UnidadMedidaOrigen_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.UNIDAD_MEDIDA_ORIGEN_IDColumnName; }
        }
        public static string CantidadOrigen_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.CANTIDAD_ORIGENColumnName; }
        }
        public static string FactorConversion_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.FACTOR_CONVERSIONColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.OBSERVACIONColumnName; }
        }
        public static string CostoTotal_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.COSTO_TOTALColumnName; }
        }
        public static string InventarioCantidadEncontrada_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.INVENTARIO_CANT_ENCONTRADAColumnName; }
        }
        public static string InventarioCantidadSistema_NombreCol
        {
            get { return STOCK_AJUSTE_DETALLECollection.INVENTARIO_CANT_SISTEMAColumnName; }
        }
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.DESCRIPCION_INTERNAColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.CASO_IDColumnName; }
        }
        public static string VistaLote_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.LOTEColumnName; }
        }
        public static string VistaUnidadMedidaDestinoNombre_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.UNIDAD_MEDIDA_DESTINO_NOMBREColumnName; }
        }
        public static string VistaUnidadMedidaOrigenNombre_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.UNIDAD_MEDIDA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.ARTICULO_GRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.ARTICULO_SUBGRUPO_IDColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCotizacion_NombreCol
        {
            get { return STOCK_AJUSTE_DET_INFO_COMPLETACollection.COTIZACIONColumnName; }
        }

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static StockAjusteDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new StockAjusteDetalleService(e.RegistroId, sesion);
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
        protected STOCK_AJUSTE_DETALLERow row;
        protected STOCK_AJUSTE_DETALLERow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Ajustado { get { return ClaseCBABase.GetStringHelper(row.AJUSTADO); } set { row.AJUSTADO = value; } }
        public decimal? ArticuloId { get { if (row.IsARTICULO_IDNull) return null; else return row.ARTICULO_ID; } set { if (value.HasValue) row.ARTICULO_ID = value.Value; else row.IsARTICULO_IDNull = true; } }
        public decimal? CantidadDestino { get { if (row.IsCANTIDAD_DESTINONull) return null; else return row.CANTIDAD_DESTINO; } set { if (value.HasValue) row.CANTIDAD_DESTINO = value.Value; else row.IsCANTIDAD_DESTINONull = true; } }
        public decimal? CantidadOrigen { get { if (row.IsCANTIDAD_ORIGENNull) return null; else return row.CANTIDAD_ORIGEN; } set { if (value.HasValue) row.CANTIDAD_ORIGEN = value.Value; else row.IsCANTIDAD_ORIGENNull = true; } }
        public decimal? CostoTotal { get { if (row.IsCOSTO_TOTALNull) return null; else return row.COSTO_TOTAL; } set { if (value.HasValue) row.COSTO_TOTAL = value.Value; else row.IsCOSTO_TOTALNull = true; } }
        public decimal? CostoUnitario { get { if (row.IsCOSTO_UNITARIONull) return null; else return row.COSTO_UNITARIO; } set { if (value.HasValue) row.COSTO_UNITARIO = value.Value; else row.IsCOSTO_UNITARIONull = true; } }
        public decimal? Cotizacion { get { if (row.IsCOTIZACIONNull) return null; else return row.COTIZACION; } set { if (value.HasValue) row.COTIZACION = value.Value; else row.IsCOTIZACIONNull = true; } }
        public decimal? FactorConversion { get { if (row.IsFACTOR_CONVERSIONNull) return null; else return row.FACTOR_CONVERSION; } set { if (value.HasValue) row.FACTOR_CONVERSION = value.Value; else row.IsFACTOR_CONVERSIONNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? InventarioCantEncontrada { get { if (row.IsINVENTARIO_CANT_ENCONTRADANull) return null; else return row.INVENTARIO_CANT_ENCONTRADA; } set { if (value.HasValue) row.INVENTARIO_CANT_ENCONTRADA = value.Value; else row.IsINVENTARIO_CANT_ENCONTRADANull = true; } }
        public decimal? InventarioCantSistema { get { if (row.IsINVENTARIO_CANT_SISTEMANull) return null; else return row.INVENTARIO_CANT_SISTEMA; } set { if (value.HasValue) row.INVENTARIO_CANT_SISTEMA = value.Value; else row.IsINVENTARIO_CANT_SISTEMANull = true; } }
        public decimal? LoteId { get { if (row.IsLOTE_IDNull) return null; else return row.LOTE_ID; } set { if (value.HasValue) row.LOTE_ID = value.Value; else row.IsLOTE_IDNull = true; } }
        public decimal? MonedaId { get { if (row.IsMONEDA_IDNull) return null; else return row.MONEDA_ID; } set { if (value.HasValue) row.MONEDA_ID = value.Value; else row.IsMONEDA_IDNull = true; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? StockAjusteId { get { if (row.IsSTOCK_AJUSTE_IDNull) return null; else return row.STOCK_AJUSTE_ID; } set { if (value.HasValue) row.STOCK_AJUSTE_ID = value.Value; else row.IsSTOCK_AJUSTE_IDNull = true; } }
        public string UnidadMedidaDestinoId { get { return ClaseCBABase.GetStringHelper(row.UNIDAD_MEDIDA_DESTINO_ID); } set { row.UNIDAD_MEDIDA_DESTINO_ID = value; } }
        public string UnidadMedidaOrigenId { get { return ClaseCBABase.GetStringHelper(row.UNIDAD_MEDIDA_ORIGEN_ID); } set { row.UNIDAD_MEDIDA_ORIGEN_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                    this._articulo = new ArticulosService(this.ArticuloId.Value);
                return this._articulo;
            }
        }

        private ArticulosLotesService _lote;
        public ArticulosLotesService Lote
        {
            get
            {
                if (this._lote == null)
                    this._lote = new ArticulosLotesService(this.LoteId.Value);
                return this._lote;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId.Value);
                return this._moneda;
            }
        }

        private StockAjusteService _stock_ajuste;
        public StockAjusteService StockAjuste
        {
            get
            {
                if (this._stock_ajuste == null)
                    this._stock_ajuste = new StockAjusteService(this.StockAjusteId.Value);
                return this._stock_ajuste;
            }
        }

        private UnidadesService _unidad_medida_destino;
        public UnidadesService UnidadMedidaDestino
        {
            get
            {
                if (this._unidad_medida_destino == null)
                    this._unidad_medida_destino = new UnidadesService(this.UnidadMedidaDestinoId);
                return this._unidad_medida_destino;
            }
        }

        private UnidadesService _unidad_medida_origen;
        public UnidadesService UnidadMedidaOrigen
        {
            get
            {
                if (this._unidad_medida_origen == null)
                    this._unidad_medida_origen = new UnidadesService(this.UnidadMedidaOrigenId);
                return this._unidad_medida_origen;
            }
        }

        private StockService.Costo _costo_ppp;
        public StockService.Costo CostoPPP
        {
            get
            {
                if (this._costo_ppp == null)
                {
                    var sm = this.GetStockMovimiento();
                    if (sm != null)
                    {
                        this._costo_ppp = new StockService.Costo()
                        {
                            costo = sm.Costo,
                            cotizacion = sm.CostoCotizacionMoneda,
                            moneda_id = sm.CostoMonedaId
                        };
                    }
                }
                return this._costo_ppp;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.STOCK_AJUSTE_DETALLECollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_AJUSTE_DETALLERow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(STOCK_AJUSTE_DETALLERow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public StockAjusteDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockAjusteDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockAjusteDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private StockAjusteDetalleService(STOCK_AJUSTE_DETALLERow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static StockAjusteDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static StockAjusteDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.STOCK_AJUSTE_DETALLECollection.GetAsArray(StockAjusteDetalleService.StockAjusteId_NombreCol + " = " + cabecera_id, StockAjusteDetalleService.Id_NombreCol);
            StockAjusteDetalleService[] sad = new StockAjusteDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                sad[i] = new StockAjusteDetalleService(rows[i]);
            return sad;
        }
        #endregion GetPorCabecera

        #region GetStockMovimiento
        public StockMovimientoService GetStockMovimiento()
        {
            using(SessionService sesion = new SessionService())
            {
                return GetStockMovimiento(sesion);
            }
        }

        public StockMovimientoService GetStockMovimiento(SessionService sesion)
        {
            return GetStockMovimiento(this.StockAjuste.CasoId, sesion);
        }
        
        public StockMovimientoService GetStockMovimiento(decimal caso_id, SessionService sesion)
        {
            var sm = new StockMovimientoService();
            sm.IniciarUsingSesion(sesion);
            
            var movimiento = sm.GetPrimero<StockMovimientoService>(new ClaseCBABase.Filtro[] {
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = caso_id },
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.REGISTRO_IDColumnName, Valor = this.Id.Value },
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.IDColumnName, OrderBy = true, Valor = "desc" }
            });
            sm.FinalizarUsingSesion();

            return movimiento;
        }
        #endregion GetStockMovimiento

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._articulo = null;
            this._costo_ppp = null;
            this._lote = null;
            this._moneda = null;
            this._stock_ajuste = null;
            this._unidad_medida_destino = null;
            this._unidad_medida_origen = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}




