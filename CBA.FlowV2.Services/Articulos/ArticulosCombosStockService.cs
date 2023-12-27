using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosCombosStockService
    {
        public ArticulosCombosStockService()
        {
        }


        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, DataTable dt, decimal caso_id, string estado)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    Guardar(campos, dt, caso_id, sesion, estado);
                    sesion.db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        
        public static void Guardar(System.Collections.Hashtable campos, DataTable dt,decimal caso_id, SessionService sesion, string estado)
        {
           
            ArticulosCombosStockDetallesService detalles = new ArticulosCombosStockDetallesService();
            System.Collections.Hashtable camposDetalles;
            
            ARTICULOS_COMBOS_STOCKRow row = new ARTICULOS_COMBOS_STOCKRow();
            string valorAnterior = string.Empty;
            
            row.ID = sesion.Db.GetSiguienteSecuencia("articulos_combos_stock_sqc");
            row.ARTICULO_COMBO_LOTE_ID = decimal.Parse(campos[ArticulosCombosStockService.ArticuloComboLoteId_NombreCol].ToString());
            row.DEPOSITO_ID = decimal.Parse(campos[ArticulosCombosStockService.DepositoId_NombreCol].ToString());
            row.FECHA_OPERACION = DateTime.Now;
            row.CANTIDAD = decimal.Parse(campos[ArticulosCombosStockService.Cantidad_NombreCol].ToString());
            row.OPERACION = campos[ArticulosCombosStockService.Operacion_NombreCol].ToString();
            row.SUCURSAL_ID = decimal.Parse(campos[ArticulosCombosStockService.SucursalId_NombreCol].ToString());
            row.USUARIO_OPERACION_ID = sesion.Usuario_Id;
            sesion.Db.ARTICULOS_COMBOS_STOCKCollection.Insert(row);

            decimal articulo_id = ArticulosLotesService.GetArticuloId2(row.ARTICULO_COMBO_LOTE_ID);
            decimal costo_total = 0;
            decimal detalleId = 0;
            decimal costoDolares = 0;
            decimal cantidadArticulo = 0;
            
            foreach (DataRow dr in dt.Rows)
            {
                detalleId = decimal.Parse(dr[ArticulosCombosStockDetallesService.ArticuloDetalleLoteId_NombreCol].ToString());
                articulo_id = ArticulosLotesService.GetArticuloId2(decimal.Parse(dr[ArticulosCombosStockDetallesService.ArticuloDetalleLoteId_NombreCol].ToString()));

                var costoPPP = CostosService.GetCosto(articulo_id, row.DEPOSITO_ID, row.FECHA_OPERACION, sesion);
                
                cantidadArticulo = decimal.Parse(dr[ArticulosCombosStockDetallesService.Cantidad_NombreCol].ToString());
                if (costoPPP.moneda_id == sesion.SucursalActiva.MONEDA_ID)
                    costo_total += costoPPP.costo * cantidadArticulo;
                else
                    costoDolares += costoPPP.costo / costoPPP.cotizacion * cantidadArticulo;
            }

            costo_total += costoDolares * CotizacionesService.GetCotizacionMonedaCompra(sesion.SucursalActiva_pais_id, sesion.SucursalActiva.MONEDA_ID, DateTime.Now, sesion);
            articulo_id = ArticulosLotesService.GetArticuloId2(row.ARTICULO_COMBO_LOTE_ID);

            if (row.OPERACION.Equals(Definiciones.ComboTipoOperacion.Generar))
                StockService.modificarStockCombo(row.DEPOSITO_ID, articulo_id, row.CANTIDAD, Definiciones.Stock.TipoMovimiento.CombosCreados, caso_id, row.ARTICULO_COMBO_LOTE_ID, true, sesion, estado, null, row.ID);
            else
                StockService.modificarStockCombo(row.DEPOSITO_ID, articulo_id, row.CANTIDAD, Definiciones.Stock.TipoMovimiento.CombosEliminado, caso_id, row.ARTICULO_COMBO_LOTE_ID, true, sesion, estado, null, row.ID);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            foreach (DataRow dr in dt.Rows)
            {
                camposDetalles = null;
                camposDetalles = new System.Collections.Hashtable();
                camposDetalles.Add(ArticulosCombosStockDetallesService.ArticuloComboStockId_NombreCol, row.ID);
                camposDetalles.Add(ArticulosCombosStockService.DepositoId_NombreCol, row.DEPOSITO_ID);
                camposDetalles.Add(ArticulosCombosStockDetallesService.ArticuloDetalleLoteId_NombreCol, dr[ArticulosCombosStockDetallesService.ArticuloDetalleLoteId_NombreCol]);
                camposDetalles.Add(ArticulosCombosStockDetallesService.Cantidad_NombreCol, dr[ArticulosCombosStockDetallesService.Cantidad_NombreCol]);
                camposDetalles.Add(ArticulosCombosStockDetallesService.UnidadId_NombreCol, dr[ArticulosCombosStockDetallesService.UnidadId_NombreCol]);
                camposDetalles.Add("tipo", row.OPERACION);
                ArticulosCombosStockDetallesService.GuardarDetalle(camposDetalles, sesion, caso_id,estado);
            }
        }        
        #endregion Guardar       

        public static void DesconsolidarCombo(decimal cantidad, decimal lote_id, decimal deposito_id, decimal caso_id, SessionService sesion, string estado_destino)
        {
            decimal sucursalId = StockDepositosService.GetSucursalId(deposito_id);
            System.Collections.Hashtable campos = new System.Collections.Hashtable();
            campos.Add(ArticulosCombosStockService.ArticuloComboLoteId_NombreCol, lote_id);
            campos.Add(ArticulosCombosStockService.DepositoId_NombreCol, deposito_id);
            campos.Add(ArticulosCombosStockService.SucursalId_NombreCol, sucursalId);
            campos.Add(ArticulosCombosStockService.Operacion_NombreCol, Definiciones.ComboTipoOperacion.Eliminar);
            campos.Add(ArticulosCombosStockService.Cantidad_NombreCol, cantidad);

            DataTable dt = new DataTable();
            dt.Columns.Add(ArticulosCombosStockDetallesService.ArticuloDetalleLoteId_NombreCol);
            dt.Columns.Add(ArticulosCombosStockDetallesService.Cantidad_NombreCol);
            dt.Columns.Add(ArticulosCombosStockDetallesService.UnidadId_NombreCol);

            DataRow dr;

            DataTable dt2 = ArticulosCombosStockService.GetDatosDeStockLote(lote_id);

            foreach (DataRow dr2 in dt2.Rows)
            {
                dr = dt.NewRow();

                dr[ArticulosCombosStockDetallesService.ArticuloDetalleLoteId_NombreCol] = dr2[ArticulosCombosStockDetallesService.ArticuloDetalleLoteId_NombreCol];
                dr[ArticulosCombosStockDetallesService.Cantidad_NombreCol] = dr2[ArticulosCombosStockDetallesService.Cantidad_NombreCol];
                dr[ArticulosCombosStockDetallesService.UnidadId_NombreCol] = dr2[ArticulosCombosStockDetallesService.UnidadId_NombreCol];

                dt.Rows.Add(dr);
            }

            if (estado_destino.Equals(string.Empty)&& !caso_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                estado_destino = CasosService.GetEstadoCaso(caso_id, sesion);
            
            ArticulosCombosStockService.Guardar(campos, dt, caso_id, sesion, estado_destino);
        }
        public static void DesconsolidarCombo(decimal cantidad, decimal lote_id, decimal deposito_id, decimal caso_id, string estado_destino)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    DesconsolidarCombo(cantidad, lote_id, deposito_id, caso_id, sesion, estado_destino);
                    sesion.db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static DataTable GetDatosDeStockLote(decimal lote_id)
        {
            return ArticulosCombosStockDetallesService.GetDetallesLotes(lote_id);
        }

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return"ARTICULOS_COMBOS_STOCK"; }
        }
        
        public static string Id_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCKCollection.IDColumnName; }
        }
        public static string ArticuloComboLoteId_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCKCollection.ARTICULO_COMBO_LOTE_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCKCollection.DEPOSITO_IDColumnName; }
        }
        public static string FechaOperacion_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCKCollection.FECHA_OPERACIONColumnName; }
        }
        public static string Operacion_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCKCollection.OPERACIONColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCKCollection.SUCURSAL_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCKCollection.USUARIO_OPERACION_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCKCollection.CANTIDADColumnName; }
        }
        #endregion Accessors
    }
}
