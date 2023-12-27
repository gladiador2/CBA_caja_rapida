#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Facturacion;
#endregion Using

namespace CBA.FlowV2.Services.NotaCreditosProveedores
{
    public class NotasCreditoProveedorDetalleService
    {
        #region GetNotaCreditoProveedorDetalleDataTable
        public static DataTable GetNotaCreditoProveedoresDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoProveedoresDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoProveedoresDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTAS_CREDITO_PROVEEDORES_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaCreditoProveedorDetalleDataTable

        #region GetNotaCreditoProveedorDetalleInfoCompleta
        public static DataTable GetNotaCreditoProveedoresDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoProveedoresDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoProveedoresDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTAS_CRED_PRO_DET_INF_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaCreditoProveedorDetalleInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    NOTAS_CREDITO_PROVEEDORES_DETRow row = new NOTAS_CREDITO_PROVEEDORES_DETRow();
                    FACTURAS_PROVEEDOR_DETALLERow rowFacturaDetalle = new FACTURAS_PROVEEDOR_DETALLERow();
                    FACTURAS_PROVEEDORRow rowFactura = new FACTURAS_PROVEEDORRow();
                    NotasCreditoProveedorService notaCreditoProveedor = new NotasCreditoProveedorService();
                    SucursalesService sucursal = new SucursalesService();
                    
                    string valorAnterior;
                    
                    valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("notas_credito_prov_det_sqc");
                    row.NOTA_CREDITO_PROVEEDOR_ID = decimal.Parse(campos[NotasCreditoProveedorDetalleService.NotaCreditoId_NombreCol].ToString());
                    
                    //Si es una devolución
                    if (campos.Contains(NotasCreditoProveedorDetalleService.FacturaProveedorDetalleId_NombreCol))
                    {
                        row.FACTURA_PROVEEDOR_ID = decimal.Parse(campos[NotasCreditoProveedorDetalleService.FacturaProveedorId_NombreCol].ToString());
                        row.FACTURA_PROVEEDOR_DETALLE_ID = decimal.Parse(campos[NotasCreditoProveedorDetalleService.FacturaProveedorDetalleId_NombreCol].ToString());

                        //se cargan la sucursal y el deposito de la factura

                        
                        rowFactura = sesion.Db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(row.FACTURA_PROVEEDOR_ID);
                        row.SUCURSAL_ID = rowFactura.SUCURSAL_ID;
                        row.DEPOSITO_ID = rowFactura.STOCK_DEPOSITO_ID;

                        
                        rowFacturaDetalle = sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.GetByPrimaryKey(row.FACTURA_PROVEEDOR_DETALLE_ID);
                        row.ARTICULO_ID = rowFacturaDetalle.ARTICULO_ID;
                        row.LOTE_ID = rowFacturaDetalle.LOTE_ID;

                        if (!rowFacturaDetalle.IsACTIVO_IDNull)
                            row.ACTIVO_ID = rowFacturaDetalle.ACTIVO_ID;

                        row.COSTO_UNITARIO = rowFacturaDetalle.TOTAL_PAGO / rowFacturaDetalle.CANTIDAD_UNITARIA_TOTAL_DEST;
                        row.IMPUESTO_PORCENTAJE = rowFacturaDetalle.PORCENTAJE_IMPUESTO;
                        row.IMPUESTO_ID = rowFacturaDetalle.IMPUESTO_ID;


                        row.CANTIDAD = (decimal)campos[NotasCreditoProveedorDetalleService.Cantidad_NombreCol];
                        row.TOTAL = row.COSTO_UNITARIO * row.CANTIDAD;
                        if (row.IMPUESTO_PORCENTAJE != 0) row.IMPUESTO_MONTO = row.TOTAL / ((100 / row.IMPUESTO_PORCENTAJE) + 1);
                        else row.IMPUESTO_MONTO = 0;
                        
                    }

                    else
                    {
                        row.FACTURA_PROVEEDOR_ID = (decimal)campos[NotasCreditoProveedorDetalleService.FacturaProveedorId_NombreCol]; //Se relaciona a una factura. (DC)

                        row.TEXTO_PREDEFINIDO_ID = (decimal)campos[NotasCreditoProveedorDetalleService.TextoPredefinidoId_NombreCol];
                        row.MONTO_CONCEPTO = (decimal)campos[NotasCreditoProveedorDetalleService.MontoConcepto_NombreCol];
                        row.IMPUESTO_ID = (decimal)campos[NotasCreditoProveedorDetalleService.ImpuestoId_NombreCol];

                        if (campos.Contains(NotasCreditoProveedorDetalleService.ImpuestoPorcentje_NombreCol))
                            row.IMPUESTO_PORCENTAJE = (decimal)campos[NotasCreditoProveedorDetalleService.ImpuestoPorcentje_NombreCol];
                        
                        decimal porcentajeImpuesto = ImpuestosService.GetPorcentajePorId(row.IMPUESTO_ID);
                        if (porcentajeImpuesto > 0) row.IMPUESTO_MONTO = row.MONTO_CONCEPTO / ((100 / porcentajeImpuesto) + 1);
                        else row.IMPUESTO_MONTO = 0;
                        row.CANTIDAD = 1;
                        row.COSTO_UNITARIO = row.MONTO_CONCEPTO;
                        row.TOTAL = row.MONTO_CONCEPTO;

                        if (campos.Contains(NotasCreditoProveedorDetalleService.ActivoId_NombreCol))
                        {
                            row.ACTIVO_ID = decimal.Parse(campos[NotasCreditoProveedorDetalleService.ActivoId_NombreCol].ToString());
                        }
                        else
                        {
                            row.IsACTIVO_IDNull = true;
                        }
                    }


                    row.OBSERVACION = campos[NotasCreditoProveedorDetalleService.NotaCreditoId_NombreCol].ToString();
                    sesion.Db.NOTAS_CREDITO_PROVEEDORES_DETCollection.Insert(row);
                    

                    if (campos.Contains(NotasCreditoProveedorDetalleService.FacturaProveedorDetalleId_NombreCol))
                    {
                        rowFacturaDetalle = sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.GetByPrimaryKey(row.FACTURA_PROVEEDOR_DETALLE_ID);
                        rowFacturaDetalle.CANTIDAD_DEVUELTA_NOTA_CREDITO += row.CANTIDAD;
                        sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.Update(rowFacturaDetalle);
                        
                    }

                    notaCreditoProveedor.RecalcularTotal(row.NOTA_CREDITO_PROVEEDOR_ID, sesion);
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

        #region Borrar
        /// <summary>
        /// Borrars the specified nota_credito_proveedor_detalle_id.
        /// </summary>
        /// <param name="nota_credito_proveedor_detalle_id">The nota_credito_proveedor_detalle_id.</param>
        public static void Borrar(decimal nota_credito_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    NOTAS_CREDITO_PROVEEDORES_DETRow row;
                    NotasCreditoProveedorService notaCreditoProveedor = new NotasCreditoProveedorService();
                    FACTURAS_PROVEEDOR_DETALLERow rowFacturaDetalle = new FACTURAS_PROVEEDOR_DETALLERow();
                    //se obtiene l el detalle de la nota de credito
                    row = sesion.Db.NOTAS_CREDITO_PROVEEDORES_DETCollection.GetByPrimaryKey(nota_credito_proveedor_detalle_id);
                   
                    //se obtiene el item de factura asociada a al detalles
                    if (row.IsTEXTO_PREDEFINIDO_IDNull)
                    {
                        rowFacturaDetalle = sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.GetByPrimaryKey(row.FACTURA_PROVEEDOR_DETALLE_ID);
                        // se repono el la cantida a la factura
                        rowFacturaDetalle.CANTIDAD_DEVUELTA_NOTA_CREDITO -= row.CANTIDAD;
                    }


                    sesion.Db.NOTAS_CREDITO_PROVEEDORES_DETCollection.DeleteByPrimaryKey(nota_credito_proveedor_detalle_id);
                    sesion.Db.FACTURAS_PROVEEDOR_DETALLECollection.Update(rowFacturaDetalle);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    notaCreditoProveedor.RecalcularTotal(row.NOTA_CREDITO_PROVEEDOR_ID, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "NOTAS_CREDITO_PROVEEDORES_DET"; }
        }
        public static string Nombre_Vista
        {
            get { return "NOTAS_CRED_PRO_DET_INF_COMP"; }
        }
        public static string Id_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.IDColumnName; }
        } 
        public static string NotaCreditoId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.NOTA_CREDITO_PROVEEDOR_IDColumnName; }
        }
        public static string ActivoId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.ACTIVO_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.ARTICULO_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.CANTIDADColumnName; }
        }
        public static string CostoUnitario_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.COSTO_UNITARIOColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get {  return NOTAS_CREDITO_PROVEEDORES_DETCollection.DEPOSITO_IDColumnName; }
        }
        public static string FacturaProveedorDetalleId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.FACTURA_PROVEEDOR_DETALLE_IDColumnName; }
        }
        public static string FacturaProveedorId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.FACTURA_PROVEEDOR_IDColumnName; }
        }
        public static string ImpuestoMonto_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.IMPUESTO_MONTOColumnName; }
        }
        public static string ImpuestoPorcentje_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.IMPUESTO_PORCENTAJEColumnName; }
        }
        public static string ArticuloLoteId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.LOTE_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.SUCURSAL_IDColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.TOTALColumnName; }
        }
        public static string MontoConcepto_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.MONTO_CONCEPTOColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return NOTAS_CREDITO_PROVEEDORES_DETCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string TextoPredefinidoNombre_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.TEXTOColumnName; }
        }

        public static string ImpuestoId_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.IMPUESTO_IDColumnName; }
        }

        public static string ImpuestoNombre_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.NOMBRE_IMPUESTOColumnName; }
        }


        #region Vistas
        public static string VistaActivoCodigo_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.ACTIVO_CODIGOColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaLote_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.LOTEColumnName; }
        }
        public static string VistaSucursal_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaDeposito_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaFacturaCasoId_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.FACTURA_CASO_IDColumnName; }
        }
        public static string VistaFacturaFecha_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.FACTURA_FECHAColumnName; }
        }
        public static string VistaFacturaNroComprobante_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.FACTURA_NRO_COMPROBANTEColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.ARTICULO_GRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.ARTICULO_SUBGRUPO_IDColumnName; }
        }
        public static string VistaMonedaCotizacion_NombreCol
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.MONEDA_COTIZACIONColumnName; }
        }
        public static string VistaNotaCreditoProveedorComprobante
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.NOTA_CRED_PROV_COMPROBANTEColumnName; }
        }
        public static string VistaNotaCreditoProveedorFecha
        {
            get { return NOTAS_CRED_PRO_DET_INF_COMPCollection.NOTA_CREDITO_PROVEEDOR_FECHAColumnName; }
        }

        #endregion Vistas
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static NotasCreditoProveedorDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new NotasCreditoProveedorDetalleService(e.RegistroId, sesion);
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
        protected NOTAS_CREDITO_PROVEEDORES_DETRow row;
        protected NOTAS_CREDITO_PROVEEDORES_DETRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? ActivoId { get { if (row.IsACTIVO_IDNull) return null; else return row.ACTIVO_ID; } set { if (value.HasValue) row.ACTIVO_ID = value.Value; else row.IsACTIVO_IDNull = true; } }
        public decimal? ArticuloId { get { if (row.IsARTICULO_IDNull) return null; else return row.ARTICULO_ID; } set { if (value.HasValue) row.ARTICULO_ID = value.Value; else row.IsARTICULO_IDNull = true; } }
        public decimal? Cantidad { get { if (row.IsCANTIDADNull) return null; else return row.CANTIDAD; } set { if (value.HasValue) row.CANTIDAD = value.Value; else row.IsCANTIDADNull = true; } }
        public decimal? CostoUnitario { get { if (row.IsCOSTO_UNITARIONull) return null; else return row.COSTO_UNITARIO; } set { if (value.HasValue) row.COSTO_UNITARIO = value.Value; else row.IsCOSTO_UNITARIONull = true; } }
        public decimal? DepositoId { get { if (row.IsDEPOSITO_IDNull) return null; else return row.DEPOSITO_ID; } set { if (value.HasValue) row.DEPOSITO_ID = value.Value; else row.IsDEPOSITO_IDNull = true; } }
        public decimal? FacturaProveedorDetalleId { get { if (row.IsFACTURA_PROVEEDOR_DETALLE_IDNull) return null; else return row.FACTURA_PROVEEDOR_DETALLE_ID; } set { if (value.HasValue) row.FACTURA_PROVEEDOR_DETALLE_ID = value.Value; else row.IsFACTURA_PROVEEDOR_DETALLE_IDNull = true; } }
        public decimal FacturaProveedorId { get { return row.FACTURA_PROVEEDOR_ID; } set { row.FACTURA_PROVEEDOR_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? ImpuestoId { get { if (row.IsIMPUESTO_IDNull) return null; else return row.IMPUESTO_ID; } set { if (value.HasValue) row.IMPUESTO_ID = value.Value; else row.IsIMPUESTO_IDNull = true; } }
        public decimal? ImpuestoMonto { get { if (row.IsIMPUESTO_MONTONull) return null; else return row.IMPUESTO_MONTO; } set { if (value.HasValue) row.IMPUESTO_MONTO = value.Value; else row.IsIMPUESTO_MONTONull = true; } }
        public decimal? ImpuestoPorcentaje { get { if (row.IsIMPUESTO_PORCENTAJENull) return null; else return row.IMPUESTO_PORCENTAJE; } set { if (value.HasValue) row.IMPUESTO_PORCENTAJE = value.Value; else row.IsIMPUESTO_PORCENTAJENull = true; } }
        public decimal? LoteId { get { if (row.IsLOTE_IDNull) return null; else return row.LOTE_ID; } set { if (value.HasValue) row.LOTE_ID = value.Value; else row.IsLOTE_IDNull = true; } }
        public decimal? MontoConcepto { get { if (row.IsMONTO_CONCEPTONull) return null; else return row.MONTO_CONCEPTO; } set { if (value.HasValue) row.MONTO_CONCEPTO = value.Value; else row.IsMONTO_CONCEPTONull = true; } }
        public decimal NotaCreditoProveedorId { get { return row.NOTA_CREDITO_PROVEEDOR_ID; } set { row.NOTA_CREDITO_PROVEEDOR_ID = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? SucursalId { get { if (row.IsSUCURSAL_IDNull) return null; else return row.SUCURSAL_ID; } set { if (value.HasValue) row.SUCURSAL_ID = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        public decimal? Total { get { if (row.IsTOTALNull) return null; else return row.TOTAL; } set { if (value.HasValue) row.TOTAL = value.Value; else row.IsTOTALNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null && this.ArticuloId.HasValue)
                    this._articulo = new ArticulosService(this.ArticuloId.Value);
                return this._articulo;
            }
        }

        private ArticulosLotesService _lote;
        public ArticulosLotesService Lote
        {
            get
            {
                if (this._lote == null && this.LoteId.HasValue)
                    this._lote = new ArticulosLotesService(this.LoteId.Value);
                return this._lote;
            }
        }

        private ImpuestosService _impuesto;
        public ImpuestosService Impuesto
        {
            get
            {
                if (this._impuesto == null && this.ImpuestoId.HasValue)
                    this._impuesto = new ImpuestosService(this.ImpuestoId.Value);
                return this._impuesto;
            }
        }

        private FacturasProveedorService _factura_proveedor;
        public FacturasProveedorService FacturaProveedor
        {
            get
            {
                if (this._factura_proveedor == null)
                    this._factura_proveedor = new FacturasProveedorService(this.FacturaProveedorId);
                return this._factura_proveedor;
            }
        }

        private FacturasProveedorDetalleService _factura_proveedor_detalle;
        public FacturasProveedorDetalleService FacturaProveedorDetalle
        {
            get
            {
                if (this._factura_proveedor_detalle == null && this.FacturaProveedorDetalleId.HasValue)
                    this._factura_proveedor_detalle = new FacturasProveedorDetalleService(this.FacturaProveedorDetalleId.Value);
                return this._factura_proveedor_detalle;
            }
        }
        
        private NotasCreditoProveedorService _nota_credito_proveedor;
        public NotasCreditoProveedorService NotaCreditoProveedor
        {
            get
            {
                if (this._nota_credito_proveedor == null)
                    this._nota_credito_proveedor = new NotasCreditoProveedorService(this.NotaCreditoProveedorId);
                return this._nota_credito_proveedor;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.NOTAS_CREDITO_PROVEEDORES_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new NOTAS_CREDITO_PROVEEDORES_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(NOTAS_CREDITO_PROVEEDORES_DETRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public NotasCreditoProveedorDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public NotasCreditoProveedorDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public NotasCreditoProveedorDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public NotasCreditoProveedorDetalleService(EdiCBA.NotaCreditoProveedorDetalle edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = NotasCreditoProveedorDetalleService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            #region articulo
            if (!string.IsNullOrEmpty(edi.articulo_uuid))
                this._articulo = ArticulosService.GetPorUUID(edi.articulo_uuid, sesion);
          
            if (this._articulo == null)
                throw new Exception("No se encontró el UUID " + edi.articulo_uuid + " ni se definieron los datos del objeto.");

            if (!this.Articulo.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Articulo.Id.HasValue)
                this.ArticuloId = this.Articulo.Id.Value;
            #endregion articulo

            this.Cantidad = edi.cantidad_unitaria_total_destino;
            this.CostoUnitario = edi.costo_unitario_monto;

            #region nota credito
            if (!string.IsNullOrEmpty(edi.nota_credito_proveedor_uuid))
                this._nota_credito_proveedor = NotasCreditoProveedorService.GetPorUUID(edi.nota_credito_proveedor_uuid, sesion);
            if (this._nota_credito_proveedor == null && edi.nota_credito_proveedor != null)
                this._nota_credito_proveedor = new NotasCreditoProveedorService(edi.nota_credito_proveedor, almacenar_localmente, sesion);
            if (this._nota_credito_proveedor != null)
            {
                if (!this.NotaCreditoProveedor.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.NotaCreditoProveedor.Id.HasValue)
                    this.NotaCreditoProveedorId = this.NotaCreditoProveedor.Id.Value;
            }
            #endregion nota credito

            #region impuesto
            if (!string.IsNullOrEmpty(edi.impuesto_uuid))
                this._impuesto = ImpuestosService.GetPorUUID(edi.impuesto_uuid, sesion);
            if (this._impuesto == null && edi.impuesto != null)
                this._impuesto = new ImpuestosService(edi.impuesto, almacenar_localmente, sesion);
            if (this._impuesto == null)
                throw new Exception("No se encontró el UUID " + edi.impuesto_uuid + " ni se definieron los datos del objeto.");

            if (!this.Impuesto.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Impuesto.Id.HasValue)
                this.ImpuestoId = this.Impuesto.Id.Value;
            this.ImpuestoPorcentaje = this.Impuesto.Porcentaje;
            #endregion impuesto

            if (!this.ArticuloId.HasValue)
                this.MontoConcepto = edi.total_neto;

            this.ImpuestoMonto = edi.total_impuesto;
            this.Total = edi.total_neto;

            #region lote
            if (!string.IsNullOrEmpty(edi.lote_uuid))
                this._lote = ArticulosLotesService.GetPorUUID(edi.lote_uuid, sesion);
            
            if (this._lote == null)
                throw new Exception("No se encontró el UUID " + edi.lote_uuid + " ni se definieron los datos del objeto.");

            if (!this.Lote.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Lote.Id.HasValue)
                this.LoteId = this.Lote.Id.Value;
            #endregion lote

            this.Observacion = edi.observacion;

            #region factura proveedor
            if (!string.IsNullOrEmpty(edi.factura_proveedor_uuid))
                this._factura_proveedor = FacturasProveedorService.GetPorUUID(edi.factura_proveedor_uuid, sesion);
            if (this._factura_proveedor == null && edi.factura_proveedor != null)
                this._factura_proveedor = new FacturasProveedorService(edi.factura_proveedor, almacenar_localmente, sesion);
            if (this._factura_proveedor != null)
            {
                if (!this.FacturaProveedor.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.FacturaProveedor.Id.HasValue)
                    this.FacturaProveedorId = this.FacturaProveedor.Id.Value;
            }
            #endregion factura proveedor

            #region factura proveedor detalle
            if (!string.IsNullOrEmpty(edi.factura_proveedor_detalle_uuid))
                this._factura_proveedor_detalle = FacturasProveedorDetalleService.GetPorUUID(edi.factura_proveedor_detalle_uuid, sesion);
            if (this._factura_proveedor_detalle == null && edi.factura_proveedor_detalle != null)
                this._factura_proveedor_detalle = new FacturasProveedorDetalleService(edi.factura_proveedor_detalle, almacenar_localmente, sesion);
            if (this._factura_proveedor_detalle != null)
            {
                if (!this.FacturaProveedorDetalle.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.FacturaProveedorDetalle.Id.HasValue)
                    this.FacturaProveedorDetalleId = this.FacturaProveedorDetalle.Id.Value;
            }
            #endregion factura proveedor detalle
        }
        private NotasCreditoProveedorDetalleService(NOTAS_CREDITO_PROVEEDORES_DETRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCaso
        public static NotasCreditoProveedorDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static NotasCreditoProveedorDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.NOTAS_CREDITO_PROVEEDORES_DETCollection.GetAsArray(NotasCreditoProveedorDetalleService.NotaCreditoId_NombreCol + " = " + cabecera_id, NotasCreditoProveedorDetalleService.Id_NombreCol);
            NotasCreditoProveedorDetalleService[] ncpd = new NotasCreditoProveedorDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                ncpd[i] = new NotasCreditoProveedorDetalleService(rows[i]);
            return ncpd;
        }
        #endregion GetPorCaso

      
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
