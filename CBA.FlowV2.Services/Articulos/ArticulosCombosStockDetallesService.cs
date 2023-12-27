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
    public class ArticulosCombosStockDetallesService
    {
        public ArticulosCombosStockDetallesService()
        {
        }


        #region Guardar

        public static void GuardarDetalle(System.Collections.Hashtable campos, SessionService sesion, decimal caso_id, string estado)
        {
            try
            {
                ARTICULOS_COMBOS_STOCK_DETRow row = new ARTICULOS_COMBOS_STOCK_DETRow();
                string valorAnterior = string.Empty;
               
                row.ID = sesion.Db.GetSiguienteSecuencia("articulos_combos_stock_det_sqc");
                row.ART_COMBO_STOCK_ID = decimal.Parse(campos[ArticulosCombosStockDetallesService.ArticuloComboStockId_NombreCol].ToString());
                row.ARTICULOS_DETALLE_LOTE_ID = decimal.Parse(campos[ArticulosCombosStockDetallesService.ArticuloDetalleLoteId_NombreCol].ToString());
                row.CANTIDAD = decimal.Parse(campos[ArticulosCombosStockDetallesService.Cantidad_NombreCol].ToString());
                row.UNIDAD = campos[ArticulosCombosStockDetallesService.ArticuloComboStockId_NombreCol].ToString();
                sesion.Db.ARTICULOS_COMBOS_STOCK_DETCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
               


               
                decimal articulo_id = ArticulosLotesService.GetArticuloId2(row.ARTICULOS_DETALLE_LOTE_ID);
                decimal deposito_id = decimal.Parse(campos[ArticulosCombosStockService.DepositoId_NombreCol].ToString());
                string operacion = campos["tipo"].ToString();

                if (operacion.Equals(Definiciones.ComboTipoOperacion.Generar))
                {
                    StockService.modificarStockCombo(deposito_id, articulo_id, row.CANTIDAD, Definiciones.Stock.TipoMovimiento.CombosCreados, caso_id, row.ARTICULOS_DETALLE_LOTE_ID, false, sesion,estado, null, row.ID);
                }
                else
                {
                    StockService.modificarStockCombo(deposito_id, articulo_id, row.CANTIDAD, Definiciones.Stock.TipoMovimiento.CombosEliminado, caso_id, row.ARTICULOS_DETALLE_LOTE_ID, false, sesion, estado, null, row.ID);
                }
            }
            catch (Exception exp)
            {
                
                throw exp;
            }
        }

        #endregion Guardar

       
        public static DataTable GetDetallesLotes(decimal lote_id)
        {
            using (SessionService sesion = new SessionService())
            {

                return GetDetallesLotes(lote_id, sesion);
            }
        }
        public static DataTable GetDetallesLotes(decimal lote_id, SessionService sesion)
        {
           
                string where = ArticulosCombosStockDetallesService.VistaArticuloComboLoteID_NombreCol + "=" + lote_id;
                return sesion.Db.ART_COMBOS_STOCK_DET_INF_COMPLCollection.GetAsDataTable(where, ArticulosCombosStockDetallesService.ArticuloDetalleLoteId_NombreCol);
        }      

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_COMBOS_STOCK_DET"; }
        }
        
        public static string Id_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCK_DETCollection.IDColumnName; }
        }
        public static string ArticuloDetalleLoteId_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCK_DETCollection.ARTICULOS_DETALLE_LOTE_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCK_DETCollection.CANTIDADColumnName; }
        }
        public static string UnidadId_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCK_DETCollection.UNIDADColumnName; }
        }
        public static string ArticuloComboStockId_NombreCol
        {
            get { return ARTICULOS_COMBOS_STOCK_DETCollection.ART_COMBO_STOCK_IDColumnName; }
        }
        public static string VistaLote_NombreCol
        {
            get { return ART_COMBOS_STOCK_DET_INF_COMPLCollection.LOTEColumnName; }
        }
        public static string VistaArticuloComboLoteID_NombreCol
        {
            get { return ART_COMBOS_STOCK_DET_INF_COMPLCollection.ARTICULO_COMBO_LOTE_IDColumnName; }
        }
        #endregion Accessors
    }
}
