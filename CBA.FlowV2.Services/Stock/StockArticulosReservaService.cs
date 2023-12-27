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

namespace CBA.FlowV2.Services.Stock
{
    public class StockArticulosReservaService
    {
        #region GetArticulosReservaDataTable
        public static DataTable GetArticulosReservaDataTable(string where, string orderBy) { 
            using (SessionService sesion = new SessionService()){
                return sesion.Db.STOCK_ARTICULOS_RESERVACollection.GetAsDataTable(where, orderBy);
            }
        }
        #endregion GetArticulosReservaDataTable

        #region GetReserva
        public static STOCK_ARTICULOS_RESERVARow GetReserva(decimal loteId, decimal depositoId, SessionService sesion)
        {
            string clausula = StockArticulosReservaService.VistaLoteId_NombreCol + " = " + loteId.ToString();
            if (depositoId != Definiciones.Error.Valor.EnteroPositivo)
                clausula += " and " + StockArticulosReservaService.VistaDepositoId_NombreCol + "=" + depositoId.ToString();
            return sesion.Db.STOCK_ARTICULOS_RESERVACollection.GetRow(clausula);
        }
        //si existe reserva del articulo, retornamos la cantidad disponible segun el id del articulo, 
        //el depositoId es opcional
        public static decimal GetReserva_Segun_Articulo_Id(decimal articuloId, decimal depositoId, SessionService sesion)
        {
            string clausula = StockArticulosReservaService.VistaArticuloId_NombreCol + " = " + articuloId.ToString();
            if (depositoId != Definiciones.Error.Valor.EnteroPositivo)
                clausula += " and " + StockArticulosReservaService.VistaDepositoId_NombreCol + "=" + depositoId.ToString();
            STOCK_ARTICULOS_RESERVARow[] rows = sesion.db.STOCK_ARTICULOS_RESERVACollection.GetAsArray(clausula, StockArticulosReservaService.VistaSucursalId_NombreCol);
            decimal suma = 0;

            for (int i = 0; i < rows.Length; i++)
                suma += rows[i].DISPONIBLE;

            if (suma == 0 || rows.Length < 0)
                return Definiciones.Error.Valor.EnteroPositivo;
            else return suma;
        }
        #endregion GetReserva

        #region GetLotesConExistencia
        public static DataTable GetLotesConExistencia(decimal deposito_id, decimal articulo_id, bool solo_con_saldo, SessionService sesion)
        {
            bool esServicio = ArticulosService.EsServicio(articulo_id, sesion);
            string sql;

            if (esServicio)
            {
                sql = "select " + ArticulosLotesService.Id_NombreCol + ", " +
                      "       " + ArticulosLotesService.LOTE_NombreCol + ", " +
                      "       " + ArticulosLotesService.LOTE_NombreCol + " || ' (-1)' " + ArticulosLotesService.LoteYCantidad_NombreCol +
                      "  from " + ArticulosLotesService.Nombre_Tabla +
                      " where " + ArticulosLotesService.Articulo_ID_NombreCol + " = " + articulo_id +
                      " order by " + ArticulosLotesService.LOTE_NombreCol;
            }
            else
            {
                string sqlExistencia = string.Empty;
                decimal politicaStock = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PoliticaMovimientoStock);

                switch ((int)politicaStock)
                {
                    case (int)Definiciones.Stock.Politicas.Tardia:
                        sqlExistencia = StockArticulosReservaService.VistaDisponible_NombreCol;
                        break;
                    case (int)Definiciones.Stock.Politicas.Intermedio:
                    case (int)Definiciones.Stock.Politicas.Temprano:
                        sqlExistencia = StockArticulosReservaService.VistaExistencia_NombreCol;
                        break;
                    default:
                        throw new Exception("ArticulosLotesService.ObtenerCantidadexistentePorLote(). Política de Stock no implementasda.");
                }

                sql = "select " + StockArticulosReservaService.VistaLoteId_NombreCol + " " + ArticulosLotesService.Id_NombreCol + ", " +
                      "       " + StockArticulosReservaService.VistaLote_NombreCol + ", " +
                      "       " + StockArticulosReservaService.VistaLote_NombreCol + " || ' (' || " + sqlExistencia + " || ')' " + ArticulosLotesService.LoteYCantidad_NombreCol +
                      "  from " + StockArticulosReservaService.Nombre_Vista +
                      " where " + StockArticulosReservaService.VistaArticuloId_NombreCol + " = " + articulo_id +
                      "   and " + StockArticulosReservaService.VistaDepositoId_NombreCol + " = " + deposito_id;

                if (solo_con_saldo)
                {
                    sql += " and " + sqlExistencia + " > 0 ";
                }
                else
                {
                    sql += " union " +
                          "select " + ArticulosLotesService.Id_NombreCol + ", " +
                          "       " + ArticulosLotesService.LOTE_NombreCol + ", " +
                          "       " + ArticulosLotesService.LOTE_NombreCol + " || ' (0)' " + ArticulosLotesService.LoteYCantidad_NombreCol +
                          "  from " + ArticulosLotesService.Nombre_Tabla + 
                          " where " + ArticulosLotesService.Articulo_ID_NombreCol + " = " + articulo_id +
                          "   and not exists(select id from " + StockService.Nombre_Tabla + " ssda " + 
                          "                   where ssda." + StockService.ArticuloLoteId_NombreCol + " = " + ArticulosLotesService.Nombre_Tabla + "." + ArticulosLotesService.Id_NombreCol + 
                          "                     and ssda." + StockService.DepositoId_NombreCol + " = " + deposito_id + ") " +
                          " order by " + StockArticulosReservaService.VistaLote_NombreCol;
                }
            }

            return sesion.db.EjecutarQuery(sql);
        }
        #endregion GetLotesConExistencia

        #region GetCantidadDisponibleSegunLote
        /// <summary>
        /// Retorna la cantidad disponible del artículo relacionado a loteId. 
        /// En caso en que no exista reserva de dicho artículo, se retorna -1 y en ese caso la cantidad
        /// disponible es la existencia del artículo.
        /// </summary>
        /// <param name="loteId">The lote id.</param>
        /// <returns></returns>
        public static decimal GetCantidadDisponibleSegunLote(decimal loteId, decimal depositoId, SessionService sesion)
        {
            STOCK_ARTICULOS_RESERVARow row = GetReserva(loteId, depositoId,sesion);
            if (row != null)
                return row.DISPONIBLE;
            return Definiciones.Error.Valor.EnteroPositivo;
        }

        /// <summary>
        /// Retorna la cantidad disponible del artículo relacionado a loteId. 
        /// En caso en que no exista reserva de dicho artículo, se retorna -1 y en ese caso la cantidad
        /// disponible es la existencia del artículo.
        /// </summary>
        /// <param name="loteId">The lote id.</param>
        /// <returns></returns>
        public static decimal GetCantidadDisponibleSegunLote(decimal loteId, decimal depositoId)
        {
            using (SessionService sesion = new SessionService())
            {
                STOCK_ARTICULOS_RESERVARow row = GetReserva(loteId, depositoId, sesion);
                if (row != null)
                    return row.DISPONIBLE;
                //return Definiciones.Error.Valor.EnteroPositivo;
                return 0;
            }
        }
        #endregion GetCantidadDisponibleSegunLote

        #region ObtenerDatosPorCodigoArticulo
        public static DataTable ObtenerDatosPorCodigoArticulo(string codigoArtículo)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {                
                string clausula =  "upper(" + StockArticulosReservaService.VistaArticuloCodigo_NombreCol + ") = upper('" + codigoArtículo + "')";

                dt = sesion.db.STOCK_ARTICULOS_RESERVACollection.GetAsDataTable(clausula, StockArticulosReservaService.VistaSucursal_NombreCol);
            }
            return dt;
        }
        #endregion ObtenerDatosPorCodigoArticulo

        #region ObtenerDatosAgrupadosSurcursalDepositoPorIdArticulo
        public static DataTable ObtenerDatosAgrupadosSucursalDepositoPorIdArticulo(string idArticulo)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string query = "select  \n" +
                " sar." + StockArticulosReservaService.VistaDeposito_NombreCol + ",\n" +
                " sar." + StockArticulosReservaService.VistaSucursal_NombreCol + ",\n" +
                "  '' " + StockArticulosReservaService.VistaLote_NombreCol + ",\n" +
                " sum(sar." + StockArticulosReservaService.VistaExistencia_NombreCol + ") " + StockArticulosReservaService.VistaExistencia_NombreCol + ",\n" +
                " sum(sar." + StockArticulosReservaService.VistaReservaPedido_NombreCol + ") " + StockArticulosReservaService.VistaReservaPedido_NombreCol + ",\n" +
                " sum(sar." + StockArticulosReservaService.VistaReservaFactura_NombreCol + ") " + StockArticulosReservaService.VistaReservaFactura_NombreCol + ", \n" +
                " sum(sar." + StockArticulosReservaService.VistaReservaTransferencia_NombreCol + ") " + StockArticulosReservaService.VistaReservaTransferencia_NombreCol + ", \n" +
                " sum(sar." + StockArticulosReservaService.VistaReservaProduccionBalanceado_NombreCol + ") " + StockArticulosReservaService.VistaReservaProduccionBalanceado_NombreCol + ", \n" +
                " sum(sar." + StockArticulosReservaService.VistaReservaProduccionBalanceadoMaterial_NombreCol + ") " + StockArticulosReservaService.VistaReservaProduccionBalanceadoMaterial_NombreCol + ", \n" +
                " sum(sar." + StockArticulosReservaService.VistaReservaEgresoProducto_NombreCol + ") " + StockArticulosReservaService.VistaReservaEgresoProducto_NombreCol + ", \n" +
                " sum(sar." + StockArticulosReservaService.VistaReservaEgresoProductoMaterial_NombreCol + ") " + StockArticulosReservaService.VistaReservaEgresoProductoMaterial_NombreCol + ", \n" +
                " sum(sar." + StockArticulosReservaService.VistaCantReservada_NombreCol + ") " + StockArticulosReservaService.VistaCantReservada_NombreCol + ",\n" +
                " sum(sar." + StockArticulosReservaService.VistaDisponible_NombreCol + ") " + StockArticulosReservaService.VistaDisponible_NombreCol + ",\n" +
                " sar." + StockArticulosReservaService.VistaSucursalId_NombreCol + ",\n" +
                " sar." + StockArticulosReservaService.VistaDepositoId_NombreCol + "\n" +

                " from " + StockArticulosReservaService .Nombre_Vista+ " sar\n" +
                " where sar." + StockArticulosReservaService.VistaArticuloId_NombreCol + "  = " + idArticulo + "\n" +

                " group by  sar." + StockArticulosReservaService.VistaSucursalId_NombreCol + ",  sar." + StockArticulosReservaService.VistaSucursal_NombreCol + ", sar." + StockArticulosReservaService.VistaDepositoId_NombreCol + ", sar." + StockArticulosReservaService.VistaDeposito_NombreCol + "\n" +
                " order by sar." + StockArticulosReservaService.VistaSucursal_NombreCol + ", sar." + StockArticulosReservaService.VistaDeposito_NombreCol + "";     

                dt = sesion.Db.EjecutarQuery(query);
            }
            return dt;
        }
        #endregion ObtenerDatosAgrupadosSurcursalDepositoPorIdArticulo

        #region ObtenerDatosPorIdArticulo
        public static DataTable ObtenerDatosPorIdArticulo(string idArtículo)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockArticulosReservaService.VistaArticuloId_NombreCol + " = " + idArtículo + "";

                dt = sesion.db.STOCK_ARTICULOS_RESERVACollection.GetAsDataTable(clausula, StockArticulosReservaService.VistaSucursal_NombreCol);
            }
            return dt;
        }
        #endregion ObtenerDatosPorIdArticulo

        #region Consultas
        public static DataTable ObtenerDatosDeFactura(decimal lote, decimal deposito)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockArticulosReservaService.VistaReservaPorFacturaLoteId_NombreCol + "=" + lote + "";
                clausula += " and " + StockArticulosReservaService.VistaReservaPorFacturaDepositoId_NombreCol + "=" + deposito + "";
                dt = sesion.db.STOCK_ART_RESERVA_POR_FACTURACollection.GetAsDataTable(clausula, StockArticulosReservaService.VistaReservaPorFacturaCaso_NombreCol);
            }
            return dt;
        }
        public static DataTable ObtenerDatosDePedido(decimal lote, decimal deposito)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockArticulosReservaService.VistaReservaPorPedidoLoteId_NombreCol + "=" + lote + "";
                clausula += " and " + StockArticulosReservaService.VistaReservaPorPedidoDepositoId_NombreCol + "=" + deposito + "";
                dt = sesion.db.STOCK_ART_RESERVA_POR_PEDIDOCollection.GetAsDataTable(clausula, StockArticulosReservaService.VistaReservaPorTransferenciaCaso_NombreCol);
            }
            return dt;
        }
        public static DataTable ObtenerDatosDeTransferencia(decimal lote, decimal deposito)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockArticulosReservaService.VistaReservaPorTransferenciaLoteId_NombreCol + "=" + lote + "";
                clausula += " and " + StockArticulosReservaService.VistaReservaPorTransferenciaDepositoId_NombreCol + "=" + deposito + "";
                dt = sesion.db.STOCK_ART_RESERVA_POR_TRANSFERCollection.GetAsDataTable(clausula, StockTransferenciasService.SucursalOrigenId_NombreCol);
            }
            return dt;
        }
        public static DataTable ObtenerDatosDeProduccionBalanceado(decimal lote, decimal deposito)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockArticulosReservaService.VistaReservaPorProduccionBalanceadoLoteId_NombreCol + "=" + lote + "";
                clausula += " and " + StockArticulosReservaService.VistaReservaPorProduccionBalanceadoDepositoId_NombreCol + "=" + deposito + "";
                dt = sesion.db.STOCK_ART_RESERVA_POR_PRODBALACollection.GetAsDataTable(clausula, StockArticulosReservaService.VistaReservaPorProduccionBalanceadoCasoId_NombreCol);                
            }
            return dt;
        }
        public static DataTable ObtenerDatosDeProduccionBalanceadoMateriales(decimal lote, decimal deposito)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockArticulosReservaService.VistaReservaPorProduccionBalanceadoMaterialesLoteId_NombreCol + "=" + lote + "";
                clausula += " and " + StockArticulosReservaService.VistaReservaPorProduccionBalanceadoMaterialesDepositoId_NombreCol + "=" + deposito + "";
                dt = sesion.db.STOCK_ART_RESERVA_POR_PROBALMACollection.GetAsDataTable(clausula, StockArticulosReservaService.VistaReservaPorProduccionBalanceadoMaterialesCasoId_NombreCol);
            }
            return dt;
        }
        public static DataTable ObtenerDatosDeEgresoProducto(decimal lote, decimal deposito)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockArticulosReservaService.VistaReservaPorEgresoProductoLoteId_NombreCol + "=" + lote + "";
                clausula += " and " + StockArticulosReservaService.VistaReservaPorEgresoProductoDepositoId_NombreCol + "=" + deposito + "";
                dt = sesion.db.STOCK_ART_RESERVA_POR_EGREPRODCollection.GetAsDataTable(clausula, StockArticulosReservaService.VistaReservaPorEgresoProductoCasoId_NombreCol);
            }
            return dt;
        }
        public static DataTable ObtenerDatosDeEgresoProductoMateriales(decimal lote, decimal deposito)
        {
            DataTable dt = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockArticulosReservaService.VistaReservaPorEgresoProductoMaterialesLoteId_NombreCol + "=" + lote + "";
                clausula += " and " + StockArticulosReservaService.VistaReservaPorEgresoProductoMaterialesDepositoId_NombreCol + "=" + deposito + "";
                dt = sesion.db.STOCK_ART_RESERVA_POR_EGRPROMACollection.GetAsDataTable(clausula, StockArticulosReservaService.VistaReservaPorEgresoProductoMaterialesCasoId_NombreCol);
            }
            return dt;
        }
        #endregion Consultas

        #region Accessors
        public static string Nombre_Vista
        {
            get { return "STOCK_ARTICULOS_RESERVA"; }
        }
        public static string VistaArticuloId_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.ARTICULO_IDColumnName; }
        }
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticulo_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.ARTICULOColumnName; }
        }
        public static string VistaCantReservada_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.CANT_RESERVADAColumnName; }
        }
        public static string VistaDepositoId_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.DEPOSITO_IDColumnName; }
        }
        public static string VistaDeposito_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.DEPOSITOColumnName; }
        }
        public static string VistaDisponible_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.DISPONIBLEColumnName; }
        }
        public static string VistaExistencia_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.EXISTENCIAColumnName; }
        }
        public static string VistaLoteId_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.ARTICULO_LOTE_IDColumnName; }
        }
        public static string VistaLote_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.LOTEColumnName; }
        }
        public static string VistaSucursalId_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaSucursal_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.SUCURSALColumnName; }
        }
        public static string VistaReservaPedido_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.RESERVADO_PEDIDOColumnName; }
        }
        public static string VistaReservaFactura_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.RESERVADO_FACTURADOColumnName; }
        }
        public static string VistaReservaTransferencia_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.RESERVADO_TRANSFERENCIAColumnName; }
        }
        public static string VistaReservaProduccionBalanceado_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.RESERVADO_PROD_BALANColumnName ; }
        }
        public static string VistaReservaProduccionBalanceadoMaterial_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.RESERVADO_PROD_BALAN_MATERIALColumnName; }
        }
        public static string VistaReservaEgresoProducto_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.RESERVADO_EGRESO_PRODUCTOColumnName; }
        }
        public static string VistaReservaEgresoProductoMaterial_NombreCol
        {
            get { return STOCK_ARTICULOS_RESERVACollection.RESERVADO_EGRESO_PROD_MATERIALColumnName; }
        }

        #region Reserva por Factura
        public static string VistaReservaPorFacturaLote_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_FACTURACollection.LOTE_NOMBREColumnName; }
        }
        public static string VistaReservaPorFacturaLoteId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_FACTURACollection.LOTE_IDColumnName; }
        }
        public static string VistaReservaPorFacturaDeposito_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_FACTURACollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaReservaPorFacturaCaso_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_FACTURACollection.CASO_IDColumnName; }
        }
        public static string VistaReservaPorFacturaComprobante_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_FACTURACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaReservaPorFacturaCantidad_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_FACTURACollection.CANTIDAD_UNITARIA_TOTAL_DESTColumnName; }
        }
        public static string VistaReservaPorFacturaCodCliente_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_FACTURACollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaReservaPorFacturaCliente_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_FACTURACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaReservaPorFacturaDepositoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_FACTURACollection.DEPOSITO_IDColumnName; }
        }
        #endregion Reserva por Factura
       
        #region Reserva por Pedido
        public static string VistaReservaPorPedidoLote_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PEDIDOCollection.LOTEColumnName; }
        }
        public static string VistaReservaPorPedidoLoteId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PEDIDOCollection.LOTE_IDColumnName; }
        }
        public static string VistaReservaPorPedidoDeposito_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PEDIDOCollection.DEPOSITOColumnName; }
        }
        public static string VistaReservaPorPedidoCaso_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PEDIDOCollection.CASO_IDColumnName; }
        }
        public static string VistaReservaPorPedidoComprobante_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PEDIDOCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaReservaPorPedidoCantidad_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PEDIDOCollection.CANTIDAD_TOTAL_ENTREGADAColumnName; }
        }
        public static string VistaReservaPorPedidoCodCliente_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PEDIDOCollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaReservaPorPedidoCliente_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PEDIDOCollection.PERSONAColumnName; }
        }
        public static string VistaReservaPorPedidoDepositoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PEDIDOCollection.DEPOSITO_IDColumnName; }
        }

        #endregion Reserva por Pedido

        #region Reserva por Transferencia
        public static string VistaReservaPorTransferenciaLote_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_TRANSFERCollection.LOTEColumnName; }
        }
        public static string VistaReservaPorTransferenciaLoteId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_TRANSFERCollection.LOTE_IDColumnName; }
        }
        public static string VistaReservaPorTransferenciaDeposito_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_TRANSFERCollection.DEPOSITO_ORIGENColumnName; }
        }

        public static string VistaReservaPorTransferenciaDepositoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_TRANSFERCollection.DEPOSITO_ORIGEN_IDColumnName; }
        }
        public static string VistaReservaPorTransferenciaCaso_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_TRANSFERCollection.CASO_IDColumnName; }
        }
        public static string VistaReservaPorTransferenciaComprobante_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_TRANSFERCollection.COMPROBANTEColumnName; }
        }
        public static string VistaReservaPorTransferenciaCantidad_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_TRANSFERCollection.CANTIDAD_UNITARIA_DEST_TOTALColumnName; }
        }
        public static string VistaReservaPorTransferenciaSucursalDestino_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_TRANSFERCollection.SUCURSAL_DESTINOColumnName; }
        }
        public static string VistaReservaPorTransferenciaDepositoDestino_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_TRANSFERCollection.DEPOSITO_DESTINOColumnName; }
        }

        #endregion Reserva por Transferencia

        #region Reserva por Produccion de Balanceados
        public static string VistaReservaPorProduccionBalanceadoCasoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PRODBALACollection.CASO_IDColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoNroComprobante_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PRODBALACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoSucursalNombre_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PRODBALACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoDepositoNombre_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PRODBALACollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoDepositoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PRODBALACollection.DEPOSITO_IDColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoCantidad_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PRODBALACollection.CANTIDADColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoLoteId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PRODBALACollection.LOTE_IDColumnName; }
        }       
        #endregion Reserva por Produccion de Balanceados

        #region Reserva por Produccion de Balanceados Materiales
        public static string VistaReservaPorProduccionBalanceadoMaterialesCasoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PROBALMACollection.CASO_IDColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoMaterialesNroComprobante_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PROBALMACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoMaterialesSucursalNombre_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PROBALMACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoMaterialesDepositoNombre_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PROBALMACollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoMaterialesDepositoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PROBALMACollection.DEPOSITO_IDColumnName; }
        }        
        public static string VistaReservaPorProduccionBalanceadoMaterialesCantidad_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PROBALMACollection.CANTIDADColumnName; }
        }
        public static string VistaReservaPorProduccionBalanceadoMaterialesLoteId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_PROBALMACollection.LOTE_IDColumnName; }
        }
        #endregion Produccion de Balanceados Materiales

        #region Reserva por Egreso Producto
        public static string VistaReservaPorEgresoProductoCasoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGREPRODCollection.CASO_IDColumnName; }
        }
        public static string VistaReservaPorEgresoProductoNroComprobante_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGREPRODCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaReservaPorEgresoProductoSucursalNombre_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGREPRODCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaReservaPorEgresoProductoDepositoNombre_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGREPRODCollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaReservaPorEgresoProductoDepositoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGREPRODCollection.DEPOSITO_IDColumnName; }
        }
        public static string VistaReservaPorEgresoProductoNombreCompleto_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGREPRODCollection.NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaReservaPorEgresoProductoCodigoPersona_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGREPRODCollection.CODIGO_PERSONAColumnName; }
        }
        public static string VistaReservaPorEgresoProductoCantidad_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGREPRODCollection.CANTIDADColumnName; }
        }
        public static string VistaReservaPorEgresoProductoLoteId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGREPRODCollection.LOTE_IDColumnName; }
        }
        #endregion Reserva por Egreso Producto

        #region Reserva por Egreso Producto Materiales
        public static string VistaReservaPorEgresoProductoMaterialesCasoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGRPROMACollection.CASO_IDColumnName; }
        }
        public static string VistaReservaPorEgresoProductoMaterialesNroComprobante_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGRPROMACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaReservaPorEgresoProductoMaterialesSucursalNombre_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGRPROMACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaReservaPorEgresoProductoMaterialesDepositoNombre_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGRPROMACollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaReservaPorEgresoProductoMaterialesDepositoId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGRPROMACollection.DEPOSITO_IDColumnName; }
        }
        public static string VistaReservaPorEgresoProductoMaterialesNombreCompleto_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGRPROMACollection.NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaReservaPorEgresoProductoMaterialesCodigoPersona_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGRPROMACollection.CODIGO_PERSONAColumnName; }
        }
        public static string VistaReservaPorEgresoProductoMaterialesCantidad_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGRPROMACollection.CANTIDADColumnName; }
        }
        public static string VistaReservaPorEgresoProductoMaterialesLoteId_NombreCol
        {
            get { return STOCK_ART_RESERVA_POR_EGRPROMACollection.LOTE_IDColumnName; }
        }
        #endregion Reserva por Egreso Producto Materiales

        #endregion Accessors
    }
}
