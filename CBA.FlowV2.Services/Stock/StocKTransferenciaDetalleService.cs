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
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class StockTransferenciaDetalleService
    {
        #region GetStockTransferenciaDetalleDataTable
        /// <summary>
        /// Gets the stock transferencia detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public DataTable GetStockTransferenciaDetalleDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_TRANSF_DET_INFO_COMPLCollection.GetAsDataTable(clausula,string.Empty);
            }
        }
        /// <summary>
        /// Gets the stock transferencia detalle data table.
        /// </summary>
        /// <param name="stock_transferencia_id">The stock_transferencia_id.</param>
        /// <returns></returns>
        public DataTable GetStockTransferenciaDetalleDataTable(decimal stock_transferencia_id)
        {
            string clausula = StockTransferenciaDetalleService.TransferenciaStockId_NombreCol + " = " + stock_transferencia_id;
            return GetStockTransferenciaDetalleDataTable(clausula);
        }
        #endregion GetStockTransferenciaDetalleDataTable

        #region GetStockTransferecniaDetalleInfoCompleta
        public static DataTable GetStocTransferenciaDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStocTransferenciaDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetStocTransferenciaDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.STOCK_TRANSF_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetStockTransferecniaDetalleInfoCompleta

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                Guardar(campos, insertarNuevo, sesion);
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                STOCK_TRANSFERENCIA_DETALLERow row = new STOCK_TRANSFERENCIA_DETALLERow();
                STOCK_TRANSFERENCIARow cabecerarow = new STOCK_TRANSFERENCIARow();
                string valorAnterior = string.Empty;
                
                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("STOCK_TRANSFERENCIA_DET_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    row = sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.GetRow(StockTransferenciaDetalleService.Id_NombreCol + " = " + campos[StockTransferenciaDetalleService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                row.TRANSFERENCIA_STOCK_ID = (decimal)campos[StockTransferenciaDetalleService.TransferenciaStockId_NombreCol];

                //se obtienen datos de la cabecera a fin de verificar la disponibilidad de los articulos
                cabecerarow = sesion.Db.STOCK_TRANSFERENCIACollection.GetByPrimaryKey(row.TRANSFERENCIA_STOCK_ID);

                row.ARTICULO_ID = (decimal)campos[StockTransferenciaDetalleService.ArticuloId_NombreCol];
                row.UNIDAD_MEDIDA_DESTINO_ID = (string)campos[StockTransferenciaDetalleService.UnidadMedidaDestino_NombreCol];
                if (campos.Contains(StockTransferenciaDetalleService.Observacion_NombreCol)) 
                    row.OBSERVACION = (string)campos[StockTransferenciaDetalleService.Observacion_NombreCol];
                row.CANTIDAD_DEST_CAJA = decimal.Parse(campos[StockTransferenciaDetalleService.CantidadDestinoCaja_NombreCol].ToString());
                row.CANTIDAD_DEST_EMBALADA = decimal.Parse(campos[StockTransferenciaDetalleService.CantidadDestinoEmbalada_NombreCol].ToString());
                row.CANTIDAD_DEST_UNITARIA = decimal.Parse(campos[StockTransferenciaDetalleService.CantidadDestinoUnitaria_NombreCol].ToString());
                row.CANTIDAD_UNITARIA_DEST_TOTAL = row.CANTIDAD_DEST_CAJA * row.CANTIDAD_DEST_EMBALADA + row.CANTIDAD_DEST_UNITARIA;
                row.LOTE_ID = decimal.Parse(campos[StockTransferenciaDetalleService.LoteId_NombreCol].ToString());
                
                //debemos conocer el factor de conversion
                row.FACTOR_CONVERSION = (new ArticulosConversionesService()).GetFactorConversion(row.ARTICULO_ID, row.UNIDAD_MEDIDA_DESTINO_ID, cabecerarow.SUCURSAL_ORIGEN_ID);

                DataTable dtArticulos = ArticulosService.GetArticuloInfoCompletaPorID(row.ARTICULO_ID, cabecerarow.SUCURSAL_ORIGEN_ID);

                row.UNIDAD_MEDIDA_ORIGEN_ID = dtArticulos.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();

                row.CANTIDAD_ORIG_CAJA = row.CANTIDAD_DEST_CAJA * row.FACTOR_CONVERSION;
                row.CANTIDAD_ORIG_EMBALADA = row.CANTIDAD_DEST_EMBALADA;
                row.CANTIDAD_ORIG_UNITARIA = row.CANTIDAD_DEST_UNITARIA / row.FACTOR_CONVERSION;
                row.CANTIDAD_UNITARIA_ORIG_TOTAL = row.CANTIDAD_UNITARIA_DEST_TOTAL / row.FACTOR_CONVERSION;
                /*Control de disponibilidad del articulo*/

                decimal disponibles = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, cabecerarow.DEPOSITO_ORIGEN_ID);

                if (disponibles < row.CANTIDAD_UNITARIA_ORIG_TOTAL)
                    throw new Exception("Cantidad disponible insuficiente.");
                
                if (campos.Contains(StockTransferenciaDetalleService.ProveedorId_NombreCol))
                    row.PROVEEDOR_ID = (decimal)campos[StockTransferenciaDetalleService.ProveedorId_NombreCol];

                //TODO Uri: columnas pendientes de ser borradas
                var costoPPP = CostosService.GetCosto(row.ARTICULO_ID, cabecerarow.DEPOSITO_ORIGEN_ID, cabecerarow.FECHA, sesion);
                row.MONTO_COSTO = costoPPP.costo * row.CANTIDAD_UNITARIA_ORIG_TOTAL;
                row.COSTO_MONEDA_ID = costoPPP.moneda_id;
                row.COTIZACION_MONEDA = costoPPP.cotizacion;
                row.IsCOSTOS_IDNull = true;
                
                if (insertarNuevo) sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.Insert(row);
                else sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                AfectarStock(row.TRANSFERENCIA_STOCK_ID, row, sesion, false);
                ActualizarTotalesStatic(row.TRANSFERENCIA_STOCK_ID, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Modificar Detalle
        /// <summary>
        /// Modificar cantidad en el detalle
        /// </summary>
        /// <param name="campos">Campos</param>
        public static void ModificarDetalle(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (!campos.Contains(StockTransferenciaDetalleService.CantidadDestinoUnitaria_NombreCol))
                        throw new Exception("Falta indicar la cantidad unitaria");
                    if (!campos.Contains(StockTransferenciaDetalleService.CantidadDestinoEmbalada_NombreCol))
                        throw new Exception("Falta indicar la cantidad de cajas");
                    if (!campos.Contains(StockTransferenciaDetalleService.Id_NombreCol))
                        throw new Exception("Falta indicar el detalle a modificar");


                    sesion.Db.BeginTransaction();
                    STOCK_TRANSFERENCIA_DETALLERow row = new STOCK_TRANSFERENCIA_DETALLERow();
                    STOCK_TRANSFERENCIARow cabecerarow = new STOCK_TRANSFERENCIARow();

                    decimal detalleId = (decimal)campos[StockTransferenciaDetalleService.Id_NombreCol];
                    row = sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.GetByPrimaryKey(detalleId);
                    string valorAnterior = row.ToString();
                    decimal cantidadDestinoAnterior = row.CANTIDAD_UNITARIA_ORIG_TOTAL;

                    /* se obtienen datos de la cabecera a fin de verificar la disponibilidad de los articulos,
                     */
                    cabecerarow = sesion.Db.STOCK_TRANSFERENCIACollection.GetByPrimaryKey(row.TRANSFERENCIA_STOCK_ID);
                    row.CANTIDAD_DEST_UNITARIA = decimal.Parse(campos[StockTransferenciaDetalleService.CantidadDestinoUnitaria_NombreCol].ToString());
                    row.CANTIDAD_DEST_EMBALADA = decimal.Parse(campos[StockTransferenciaDetalleService.CantidadDestinoEmbalada_NombreCol].ToString());
                    row.CANTIDAD_UNITARIA_DEST_TOTAL = (row.CANTIDAD_DEST_CAJA * row.CANTIDAD_DEST_EMBALADA) + row.CANTIDAD_DEST_UNITARIA;
                    //Se calculan las cantidades 
                    row.CANTIDAD_ORIG_UNITARIA = row.CANTIDAD_DEST_UNITARIA/row.FACTOR_CONVERSION;
                    row.CANTIDAD_ORIG_EMBALADA = row.CANTIDAD_DEST_EMBALADA / row.FACTOR_CONVERSION;
                    row.CANTIDAD_UNITARIA_ORIG_TOTAL = row.CANTIDAD_UNITARIA_DEST_TOTAL / row.FACTOR_CONVERSION;
                    row.IsMONTO_COSTONull = true;
                   
                    /*Control de disponibilidad del articulo*/
                    decimal disponibles = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, cabecerarow.DEPOSITO_ORIGEN_ID);

                    if (disponibles + cantidadDestinoAnterior < row.CANTIDAD_UNITARIA_ORIG_TOTAL)
                        throw new Exception("Cantidad disponible insuficiente.");

                    sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.Update(row);
                    string valorNuevo = row.ToString();
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);

                    //si la politica de movimiento de Stock es temprana
                    //Se hace un doble movimiento, primero se devuelve el stock y luego se quita de nuevo
                    AfectarStock(row.TRANSFERENCIA_STOCK_ID, row, sesion, true);
                    AfectarStock(row.TRANSFERENCIA_STOCK_ID, row, sesion, false);

                    sesion.Db.CommitTransaction();

                    ActualizarTotalesStatic(row.TRANSFERENCIA_STOCK_ID);
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }

        #endregion Modificar Detalle
      
        #region Borrar
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Borrar(detalles_id, sesion);
                    sesion.db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        public static void Borrar(decimal detalles_id, SessionService sesion)
        {
            try
            {
                
                STOCK_TRANSFERENCIA_DETALLERow row = new STOCK_TRANSFERENCIA_DETALLERow();
                row = sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.GetByPrimaryKey(detalles_id);
                string valorAnterior = row.ToString();
                string valorNuevo = Definiciones.Log.RegistroBorrado;
                sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.DeleteByPrimaryKey(detalles_id);
                AfectarStock(row.TRANSFERENCIA_STOCK_ID, row, sesion, true);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);

                ActualizarTotalesStatic(row.TRANSFERENCIA_STOCK_ID, sesion);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        #endregion Borrar

        #region CrearTransferenciaDetalle
        public static void CrearTransferenciaDetalle(decimal caso_id, decimal articulo_id, decimal lote_id, string unidad_destino_id, decimal cantidad_unidad_destino, decimal cantidad_embalada, decimal cantidad_por_caja_destino, decimal moneda_id, decimal cotizacion_origen, decimal cantidad_unitaria_total_destino, decimal costo_id, SessionService sesion)
        {
            DataTable dtCabecera = StockTransferenciasService.GetStockTransferenciaDataTable2(StockTransferenciasService.CasoId_NombreCol + " = " + caso_id, string.Empty,sesion);

            if (dtCabecera.Rows.Count > 0)
            {
                System.Collections.Hashtable camposDetalle = new System.Collections.Hashtable();
                //recorro el o los detalles de la factrura para asignar a transferencia detalles
                camposDetalle.Add(StockTransferenciaDetalleService.TransferenciaStockId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.Id_NombreCol]);
                camposDetalle.Add(StockTransferenciaDetalleService.ArticuloId_NombreCol, articulo_id);
                camposDetalle.Add(StockTransferenciaDetalleService.LoteId_NombreCol, lote_id);
                camposDetalle.Add(StockTransferenciaDetalleService.UnidadMedidaDestino_NombreCol, unidad_destino_id);
                camposDetalle.Add(StockTransferenciaDetalleService.CantidadDestinoUnitaria_NombreCol, cantidad_unidad_destino);
                camposDetalle.Add(StockTransferenciaDetalleService.CantidadDestinoEmbalada_NombreCol, cantidad_embalada);
                camposDetalle.Add(StockTransferenciaDetalleService.CantidadDestinoCaja_NombreCol, cantidad_por_caja_destino);
                camposDetalle.Add(StockTransferenciaDetalleService.CostoMonedaId_NombreCol, moneda_id);
                camposDetalle.Add(StockTransferenciaDetalleService.CotizacionMoneda_NombreCol, cotizacion_origen);
                camposDetalle.Add(StockTransferenciaDetalleService.CostosId_NombreCol, costo_id);

                StockTransferenciaDetalleService.Guardar(camposDetalle, true, sesion);
            }            
        }
        #endregion CrearTransferenciaDetalle

        #region AfectarStock
        private static void AfectarStock(decimal stock_transferencia_id, STOCK_TRANSFERENCIA_DETALLERow row, SessionService sesion, bool borrar)
        {
            DataTable dtTransferencia = StockTransferenciasService.GetStockTransferenciaDataTable2(StockTransferenciasService.Id_NombreCol + " = " + row.TRANSFERENCIA_STOCK_ID, string.Empty, sesion);
            
            string tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaSalida;
            if (borrar)
                tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaEntrada;

            bool afectarCostos = StockService.modificarStock((decimal)dtTransferencia.Rows[0][StockTransferenciasService.DepositoOrigen_NombreCol],
                                 row.ARTICULO_ID,
                                 Interprete.Redondear(row.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                 tipoMovimiento, (decimal)dtTransferencia.Rows[0][StockTransferenciasService.CasoId_NombreCol], row.LOTE_ID, string.Empty,
                                 sesion, null, null, row.ID);
        }
        #endregion AfectarStock

        #region ActualizarTotales
        private void ActualizarTotales(decimal transferencia_id, SessionService sesion)
        {
            
            try
            {
                decimal costoTranferencia = 0;
                STOCK_TRANSFERENCIARow cabecera = sesion.Db.STOCK_TRANSFERENCIACollection.GetByPrimaryKey(transferencia_id);
                STOCK_TRANSFERENCIA_DETALLERow[] detalles = sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.GetByTRANSFERENCIA_STOCK_ID(transferencia_id);

                for (int i = 0; i < detalles.Length; i++)
                {
                    if (cabecera.MONEDA_ID != detalles[i].COSTO_MONEDA_ID)
                    {
                        costoTranferencia += detalles[i].MONTO_COSTO /detalles[i].COTIZACION_MONEDA * cabecera.COTIZACION;
                    }
                    else
                    {
                        costoTranferencia += detalles[i].MONTO_COSTO;
                    }
                }
                
                cabecera.COSTO_TRANSFERENCIA = costoTranferencia;

                cabecera.TOTAL_COSTO = cabecera.COSTO_ASOCIADO + costoTranferencia;

                sesion.Db.STOCK_TRANSFERENCIACollection.Update(cabecera);
               

            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
            
        }
        #endregion ActualizarTotales

        #region ActualizarTotales Static
        private static void ActualizarTotalesStatic(decimal transferencia_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ActualizarTotalesStatic(transferencia_id, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        
        private static void ActualizarTotalesStatic(decimal transferencia_id, SessionService sesion)
        {
            decimal costoTranferencia = 0;
            STOCK_TRANSFERENCIARow cabecera = sesion.Db.STOCK_TRANSFERENCIACollection.GetByPrimaryKey(transferencia_id);
            STOCK_TRANSFERENCIA_DETALLERow[] detalles = sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.GetByTRANSFERENCIA_STOCK_ID(transferencia_id);

            for (int i = 0; i < detalles.Length; i++)
            {
                if (cabecera.MONEDA_ID != detalles[i].COSTO_MONEDA_ID)
                    costoTranferencia += detalles[i].MONTO_COSTO / detalles[i].COTIZACION_MONEDA * cabecera.COTIZACION;
                else
                    costoTranferencia += detalles[i].MONTO_COSTO;
            }

            cabecera.COSTO_TRANSFERENCIA = costoTranferencia;
            cabecera.TOTAL_COSTO = cabecera.COSTO_ASOCIADO + costoTranferencia;
            sesion.Db.STOCK_TRANSFERENCIACollection.Update(cabecera);
        }
        #endregion ActualizarTotales

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "STOCK_TRANSFERENCIA_DETALLE"; }
        }
        public static string Nombre_Vista
        {
            get { return "STOCK_TRANSF_DET_INFO_COMPL"; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.IDColumnName; }
        }
        public static string TransferenciaStockId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.TRANSFERENCIA_STOCK_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.ARTICULO_IDColumnName; }
        }
        public static string CantidadDestinoCaja_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.CANTIDAD_DEST_CAJAColumnName; }
        }
        public static string CantidadDestinoEmbalada_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.CANTIDAD_DEST_EMBALADAColumnName; }
        }
        public static string CantidadDestinoUnitariaTotal_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.CANTIDAD_UNITARIA_DEST_TOTALColumnName; }
        }
        public static string CantidadDestinoUnitaria_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.CANTIDAD_DEST_UNITARIAColumnName; }
        }
        public static string CantidadOrigenCaja_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.CANTIDAD_ORIG_CAJAColumnName; }
        }
        public static string CantidadOrigenEmbalada_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.CANTIDAD_ORIG_EMBALADAColumnName; }
        }
        public static string CantidadOrigenUnitaria_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.CANTIDAD_ORIG_UNITARIAColumnName; }
        }
        public static string CantidadOrigenUnitariaTotal_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.CANTIDAD_UNITARIA_ORIG_TOTALColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CostoMonedaId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.COSTO_MONEDA_IDColumnName; }
        }
        public static string CostosId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.COSTOS_IDColumnName; }
        }
        public static string FactorConversion_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.FACTOR_CONVERSIONColumnName; }
        }
        public static string MontoCosto_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.MONTO_COSTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.OBSERVACIONColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.PROVEEDOR_IDColumnName; }
        }
        public static string UnidadMedidaDestino_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.UNIDAD_MEDIDA_DESTINO_IDColumnName; }
        }
        public static string UnidadMedidaOrigen_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.UNIDAD_MEDIDA_ORIGEN_IDColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_DETALLECollection.LOTE_IDColumnName; }
        }
         public static string VistaNombreArticulo_NombreCol
        {
            get { return STOCK_TRANSF_DET_INFO_COMPLCollection.DESCRIPCION_INTERNAColumnName; }
        }
         public static string VistaLote_NombreCol
         {
             get { return STOCK_TRANSF_DET_INFO_COMPLCollection.LOTEColumnName; }
         }
         public static string VistaArticuloFamiliaId_NombreCol
         {
             get { return STOCK_TRANSF_DET_INFO_COMPLCollection.ARTICULO_FAMILIA_IDColumnName; }
         }
         public static string VistaArticuloGrupoId_NombreCol
         {
             get { return STOCK_TRANSF_DET_INFO_COMPLCollection.ARTICULO_GRUPO_IDColumnName; }
         }
         public static string VistaArticuloSubgrupoId_NombreCol
         {
             get { return STOCK_TRANSF_DET_INFO_COMPLCollection.ARTICULO_SUBGRUPO_IDColumnName; }
         }
         public static string VistaArticuloCodigo_NombreCol
         {
             get { return STOCK_TRANSF_DET_INFO_COMPLCollection.ARTICULO_CODIGOColumnName;}
         }
         public static string VistaProveedorRazonSocial
         {
             get { return STOCK_TRANSF_DET_INFO_COMPLCollection.RAZON_SOCIALColumnName; }
         }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static StockTransferenciaDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new StockTransferenciaDetalleService(e.RegistroId, sesion);
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
        protected STOCK_TRANSFERENCIA_DETALLERow row;
        protected STOCK_TRANSFERENCIA_DETALLERow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? ArticuloId { get { if (row.IsARTICULO_IDNull) return null; else return row.ARTICULO_ID; } set { if (value.HasValue) row.ARTICULO_ID = value.Value; else row.IsARTICULO_IDNull = true; } }
        public decimal? CantidadDestCaja { get { if (row.IsCANTIDAD_DEST_CAJANull) return null; else return row.CANTIDAD_DEST_CAJA; } set { if (value.HasValue) row.CANTIDAD_DEST_CAJA = value.Value; else row.IsCANTIDAD_DEST_CAJANull = true; } }
        public decimal? CantidadDestEmbalada { get { if (row.IsCANTIDAD_DEST_EMBALADANull) return null; else return row.CANTIDAD_DEST_EMBALADA; } set { if (value.HasValue) row.CANTIDAD_DEST_EMBALADA = value.Value; else row.IsCANTIDAD_DEST_EMBALADANull = true; } }
        public decimal? CantidadDestUnitaria { get { if (row.IsCANTIDAD_DEST_UNITARIANull) return null; else return row.CANTIDAD_DEST_UNITARIA; } set { if (value.HasValue) row.CANTIDAD_DEST_UNITARIA = value.Value; else row.IsCANTIDAD_DEST_UNITARIANull = true; } }
        public decimal? CantidadOrigCaja { get { if (row.IsCANTIDAD_ORIG_CAJANull) return null; else return row.CANTIDAD_ORIG_CAJA; } set { if (value.HasValue) row.CANTIDAD_ORIG_CAJA = value.Value; else row.IsCANTIDAD_ORIG_CAJANull = true; } }
        public decimal? CantidadOrigEmbalada { get { if (row.IsCANTIDAD_ORIG_EMBALADANull) return null; else return row.CANTIDAD_ORIG_EMBALADA; } set { if (value.HasValue) row.CANTIDAD_ORIG_EMBALADA = value.Value; else row.IsCANTIDAD_ORIG_EMBALADANull = true; } }
        public decimal? CantidadOrigUnitaria { get { if (row.IsCANTIDAD_ORIG_UNITARIANull) return null; else return row.CANTIDAD_ORIG_UNITARIA; } set { if (value.HasValue) row.CANTIDAD_ORIG_UNITARIA = value.Value; else row.IsCANTIDAD_ORIG_UNITARIANull = true; } }
        public decimal? CantidadUnitariaDestTotal { get { if (row.IsCANTIDAD_UNITARIA_DEST_TOTALNull) return null; else return row.CANTIDAD_UNITARIA_DEST_TOTAL; } set { if (value.HasValue) row.CANTIDAD_UNITARIA_DEST_TOTAL = value.Value; else row.IsCANTIDAD_UNITARIA_DEST_TOTALNull = true; } }
        public decimal? CantidadUnitariaOrigTotal { get { if (row.IsCANTIDAD_UNITARIA_ORIG_TOTALNull) return null; else return row.CANTIDAD_UNITARIA_ORIG_TOTAL; } set { if (value.HasValue) row.CANTIDAD_UNITARIA_ORIG_TOTAL = value.Value; else row.IsCANTIDAD_UNITARIA_ORIG_TOTALNull = true; } }
        public decimal? CostoMonedaId { get { if (row.IsCOSTO_MONEDA_IDNull) return null; else return row.COSTO_MONEDA_ID; } set { if (value.HasValue) row.COSTO_MONEDA_ID = value.Value; else row.IsCOSTO_MONEDA_IDNull = true; } }
        public decimal? CostosId { get { if (row.IsCOSTOS_IDNull) return null; else return row.COSTOS_ID; } set { if (value.HasValue) row.COSTOS_ID = value.Value; else row.IsCOSTOS_IDNull = true; } }
        public decimal? CotizacionMoneda { get { if (row.IsCOTIZACION_MONEDANull) return null; else return row.COTIZACION_MONEDA; } set { if (value.HasValue) row.COTIZACION_MONEDA = value.Value; else row.IsCOTIZACION_MONEDANull = true; } }
        public decimal? FactorConversion { get { if (row.IsFACTOR_CONVERSIONNull) return null; else return row.FACTOR_CONVERSION; } set { if (value.HasValue) row.FACTOR_CONVERSION = value.Value; else row.IsFACTOR_CONVERSIONNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? LoteId { get { if (row.IsLOTE_IDNull) return null; else return row.LOTE_ID; } set { if (value.HasValue) row.LOTE_ID = value.Value; else row.IsLOTE_IDNull = true; } }
        public decimal? MontoCosto { get { if (row.IsMONTO_COSTONull) return null; else return row.MONTO_COSTO; } set { if (value.HasValue) row.MONTO_COSTO = value.Value; else row.IsMONTO_COSTONull = true; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? TransferenciaStockId { get { if (row.IsTRANSFERENCIA_STOCK_IDNull) return null; else return row.TRANSFERENCIA_STOCK_ID; } set { if (value.HasValue) row.TRANSFERENCIA_STOCK_ID = value.Value; else row.IsTRANSFERENCIA_STOCK_IDNull = true; } }
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

        private StockTransferenciasService _transferencia_stock;
        public StockTransferenciasService TransferenciaStock
        {
            get
            {
                if (this._transferencia_stock == null)
                    this._transferencia_stock = new StockTransferenciasService(this.TransferenciaStockId.Value);
                return this._transferencia_stock;
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
                this.row = sesion.db.STOCK_TRANSFERENCIA_DETALLECollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_TRANSFERENCIA_DETALLERow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(STOCK_TRANSFERENCIA_DETALLERow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public StockTransferenciaDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockTransferenciaDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockTransferenciaDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private StockTransferenciaDetalleService(STOCK_TRANSFERENCIA_DETALLERow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static StockTransferenciaDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static StockTransferenciaDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.STOCK_TRANSFERENCIA_DETALLECollection.GetAsArray(StockTransferenciaDetalleService.TransferenciaStockId_NombreCol + " = " + cabecera_id, StockTransferenciaDetalleService.Id_NombreCol);
            StockTransferenciaDetalleService[] td = new StockTransferenciaDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                td[i] = new StockTransferenciaDetalleService(rows[i]);
            return td;
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
            return GetStockMovimiento(this.TransferenciaStock.CasoId.Value, sesion);
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
            this._transferencia_stock = null;
            this._unidad_medida_destino = null;
            this._unidad_medida_origen = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
