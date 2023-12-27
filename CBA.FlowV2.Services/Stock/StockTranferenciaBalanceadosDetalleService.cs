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
using CBA.FlowV2.Services.Casos;
#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class StockTransferenciaBalanceadosDetalleService
    {
        #region GetStockTransferenciaBalanceadosDetalleDataTable
        /// <summary>
        /// Gets the stock transferencia detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public DataTable GetStockTransferenciaBalanceadosDetalleDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_TRANSF_BALANC_DET_INFO_COMPLCollection.GetAsDataTable(clausula, string.Empty);
            }
        }
        /// <summary>
        /// Gets the stock transferencia detalle data table.
        /// </summary>
        /// <param name="stock_transferencia_id">The stock_transferencia_id.</param>
        /// <returns></returns>
        public DataTable GetStockTransferenciaBalanceadosDetalleDataTable(decimal stock_transferencia_id)
        {
            string clausula = StockTransferenciaBalanceadosDetalleService.Modelo.TRANSFERENCIA_BALANC_IDColumnName + " = " + stock_transferencia_id;
            return GetStockTransferenciaBalanceadosDetalleDataTable(clausula);
        }
        #endregion GetStockTransferenciaBalanceadosDetalleDataTable

        #region GetStockTransferenciaBalanceadosDetalleInfoCompleta
        public static DataTable GetStockTransferenciaBalanceadosDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStockTransferenciaBalanceadosDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetStockTransferenciaBalanceadosDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.STOCK_TRANSF_BALANC_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetStockTransferenciaBalanceadosDetalleInfoCompleta

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
                STOCK_TRANSFERENCIA_BALANC_DETRow row = new STOCK_TRANSFERENCIA_BALANC_DETRow();
                STOCK_TRANSFERENCIA_BALANCEADOSRow cabecerarow = new STOCK_TRANSFERENCIA_BALANCEADOSRow();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("STOCK_TRANSFERENCIA_BALANC_DET_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    row = sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetRow(StockTransferenciaBalanceadosDetalleService.Modelo.IDColumnName + " = " + campos[StockTransferenciaBalanceadosDetalleService.Modelo.IDColumnName]);
                    valorAnterior = row.ToString();
                }

                row.TRANSFERENCIA_BALANC_ID = (decimal)campos[StockTransferenciaBalanceadosDetalleService.Modelo.TRANSFERENCIA_BALANC_IDColumnName];
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.NRO_CELDAColumnName))
                    row.NRO_CELDA = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.NRO_CELDAColumnName].ToString());

                if (row.NRO_CELDA != 0)
                {
                    DataTable dt = StockTransferenciaBalanceadosDetalleService.GetStockTransferenciaBalanceadosDetalleInfoCompleta(
                        StockTransferenciaBalanceadosDetalleService.Modelo.TRANSFERENCIA_BALANC_IDColumnName + " = " + row.TRANSFERENCIA_BALANC_ID + 
                        " and " + StockTransferenciaBalanceadosDetalleService.Modelo.NRO_CELDAColumnName + " = " + row.NRO_CELDA +
                        " and " + StockTransferenciaBalanceadosDetalleService.Modelo.IDColumnName + " != " + row.ID, string.Empty);

                    if (dt.Rows.Count > 0)
                        throw new Exception("Ya existe un detalle con la celda nro. " + row.NRO_CELDA + ".");
                }

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.DEPOSITO_ORIGEN_IDColumnName))
                {
                    var depositoOrigen = new StockDepositosService(decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.DEPOSITO_ORIGEN_IDColumnName].ToString()), sesion);
                    if (depositoOrigen.Estado == Definiciones.Estado.Inactivo)
                        throw new Exception("El depósito destino está inactivo.");

                    row.DEPOSITO_ORIGEN_ID = depositoOrigen.Id.Value;                    
                }

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.DEPOSITO_DESTINO_IDColumnName))
                {
                    var depositoDestino = new StockDepositosService(decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.DEPOSITO_DESTINO_IDColumnName].ToString()), sesion);
                    if (depositoDestino.Estado == Definiciones.Estado.Inactivo)
                        throw new Exception("El depósito destino está inactivo.");

                    row.DEPOSITO_DESTINO_ID = depositoDestino.Id.Value;
                    row.SUCURSAL_DESTINO_ID = depositoDestino.SucursalId;
                }

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.RECIBIDOColumnName))
                    row.RECIBIDO = campos[StockTransferenciaBalanceadosDetalleService.Modelo.RECIBIDOColumnName].ToString();
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.CASO_IDColumnName))
                    row.CASO_ID = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.CASO_IDColumnName].ToString());
               
                if (row.DEPOSITO_DESTINO_ID == row.DEPOSITO_ORIGEN_ID)
                    throw new Exception("Depósito origen y destino no pueden ser el mismo.");

                //se obtienen datos de la cabecera a fin de verificar la disponibilidad de los articulos
                cabecerarow = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByPrimaryKey(row.TRANSFERENCIA_BALANC_ID);

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.ARTICULO_IDColumnName))
                    row.ARTICULO_ID = (decimal)campos[StockTransferenciaBalanceadosDetalleService.Modelo.ARTICULO_IDColumnName];
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.UNIDAD_MEDIDA_DESTINO_IDColumnName))
                    row.UNIDAD_MEDIDA_DESTINO_ID = (string)campos[StockTransferenciaBalanceadosDetalleService.Modelo.UNIDAD_MEDIDA_DESTINO_IDColumnName];
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.OBSERVACIONColumnName))
                    row.OBSERVACION = (string)campos[StockTransferenciaBalanceadosDetalleService.Modelo.OBSERVACIONColumnName];
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.CANTIDAD_DEST_CAJAColumnName))
                    row.CANTIDAD_DEST_CAJA = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.CANTIDAD_DEST_CAJAColumnName].ToString());
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.CANTIDAD_DEST_EMBALADAColumnName))
                    row.CANTIDAD_DEST_EMBALADA = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.CANTIDAD_DEST_EMBALADAColumnName].ToString());
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.CANTIDAD_DEST_UNITARIAColumnName))
                    row.CANTIDAD_DEST_UNITARIA = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.CANTIDAD_DEST_UNITARIAColumnName].ToString());

                row.CANTIDAD_UNITARIA_DEST_TOTAL = row.CANTIDAD_DEST_CAJA * row.CANTIDAD_DEST_EMBALADA + row.CANTIDAD_DEST_UNITARIA;

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.LOTE_IDColumnName))
                    row.LOTE_ID = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.LOTE_IDColumnName].ToString());

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.TAR_BRUTOColumnName))
                    row.TAR_BRUTO = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.TAR_BRUTOColumnName].ToString());
                else
                    if (insertarNuevo)
                        row.TAR_BRUTO = 0;

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.TAR_PESO_NETOColumnName))
                    row.TAR_PESO_NETO = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.TAR_PESO_NETOColumnName].ToString());
                else
                    if (insertarNuevo)
                        row.TAR_PESO_NETO = 0;

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.PESO_BRUTOColumnName))
                    row.PESO_BRUTO = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.PESO_BRUTOColumnName].ToString());
                else
                    if (insertarNuevo)
                        row.PESO_BRUTO = 0;
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.CASO_IDColumnName))
                    row.CASO_ID = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.CASO_IDColumnName].ToString());

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.AUTONUMERACION_IDColumnName))
                    row.AUTONUMERACION_ID = (decimal)campos[StockTransferenciaBalanceadosDetalleService.Modelo.AUTONUMERACION_IDColumnName];
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.NRO_COMPROBANTEColumnName))
                    row.NRO_COMPROBANTE = campos[StockTransferenciaBalanceadosDetalleService.Modelo.NRO_COMPROBANTEColumnName].ToString();
                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.GENERAR_STOCKColumnName))
                    row.GENERAR_STOCK = campos[StockTransferenciaBalanceadosDetalleService.Modelo.GENERAR_STOCKColumnName].ToString();

                //debemos conocer el factor de conversion
                row.FACTOR_CONVERSION = (new ArticulosConversionesService()).GetFactorConversion(row.ARTICULO_ID, row.UNIDAD_MEDIDA_DESTINO_ID, cabecerarow.SUCURSAL_ORIGEN_ID);

                DataTable dtArticulos = ArticulosService.GetArticuloInfoCompletaPorID(row.ARTICULO_ID, cabecerarow.SUCURSAL_ORIGEN_ID);

                row.UNIDAD_MEDIDA_ORIGEN_ID = dtArticulos.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();

                row.CANTIDAD_ORIG_CAJA = row.CANTIDAD_DEST_CAJA * row.FACTOR_CONVERSION;
                row.CANTIDAD_ORIG_EMBALADA = row.CANTIDAD_DEST_EMBALADA;
                row.CANTIDAD_ORIG_UNITARIA = row.CANTIDAD_DEST_UNITARIA / row.FACTOR_CONVERSION;
                row.CANTIDAD_UNITARIA_ORIG_TOTAL = row.CANTIDAD_UNITARIA_DEST_TOTAL / row.FACTOR_CONVERSION;
                /*Control de disponibilidad del articulo*/

                decimal disponibles = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, row.DEPOSITO_ORIGEN_ID);

                if (disponibles < row.CANTIDAD_UNITARIA_ORIG_TOTAL)
                    throw new Exception("Cantidad disponible insuficiente.");

                if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.PROVEEDOR_IDColumnName))
                    row.PROVEEDOR_ID = (decimal)campos[StockTransferenciaBalanceadosDetalleService.Modelo.PROVEEDOR_IDColumnName];

                //TODO Uri: columnas pendientes de ser borradas
                var costoPPP = CostosService.GetCosto(row.ARTICULO_ID, row.DEPOSITO_ORIGEN_ID, cabecerarow.FECHA, sesion);
                row.MONTO_COSTO = costoPPP.costo * row.CANTIDAD_UNITARIA_ORIG_TOTAL;
                row.COSTO_MONEDA_ID = costoPPP.moneda_id;
                row.COTIZACION_MONEDA = costoPPP.cotizacion;
                row.IsCOSTOS_IDNull = true;

                if (insertarNuevo) sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.Insert(row);
                else sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                AfectarStock(row.TRANSFERENCIA_BALANC_ID, row, sesion, false);
                ActualizarTotalesStatic(row.TRANSFERENCIA_BALANC_ID, sesion);
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
                    if (!campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.CANTIDAD_DEST_UNITARIAColumnName))
                        throw new Exception("Falta indicar la cantidad unitaria");                    
                    if (!campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.IDColumnName))
                        throw new Exception("Falta indicar el detalle a modificar");

                    sesion.Db.BeginTransaction();
                    STOCK_TRANSFERENCIA_BALANC_DETRow row = new STOCK_TRANSFERENCIA_BALANC_DETRow();
                    STOCK_TRANSFERENCIA_BALANCEADOSRow cabecerarow = new STOCK_TRANSFERENCIA_BALANCEADOSRow();

                    decimal detalleId = (decimal)campos[StockTransferenciaBalanceadosDetalleService.Modelo.IDColumnName];
                    row = sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetByPrimaryKey(detalleId);
                    string valorAnterior = row.ToString();
                    decimal cantidadDestinoAnterior = row.CANTIDAD_UNITARIA_ORIG_TOTAL;

                    /* se obtienen datos de la cabecera a fin de verificar la disponibilidad de los articulos,
                     */
                    cabecerarow = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByPrimaryKey(row.TRANSFERENCIA_BALANC_ID);

                    row.NRO_CELDA = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.NRO_CELDAColumnName].ToString());

                    if (row.NRO_CELDA != 0)
                    {
                        DataTable dt = StockTransferenciaBalanceadosDetalleService.GetStockTransferenciaBalanceadosDetalleInfoCompleta(
                            StockTransferenciaBalanceadosDetalleService.Modelo.TRANSFERENCIA_BALANC_IDColumnName + " = " + row.TRANSFERENCIA_BALANC_ID +
                            " and " + StockTransferenciaBalanceadosDetalleService.Modelo.NRO_CELDAColumnName + " = " + row.NRO_CELDA + 
                            " and " + StockTransferenciaBalanceadosDetalleService.Modelo.IDColumnName + " != " + row.ID, string.Empty);

                        if (dt.Rows.Count > 0)
                            throw new Exception("Ya existe un detalle con la celda nro. " + row.NRO_CELDA + ".");
                    }

                    row.CANTIDAD_DEST_UNITARIA = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.CANTIDAD_DEST_UNITARIAColumnName].ToString());
                    
                    row.CANTIDAD_UNITARIA_DEST_TOTAL = row.CANTIDAD_DEST_UNITARIA;
                    //Se calculan las cantidades 
                    row.CANTIDAD_ORIG_UNITARIA = row.CANTIDAD_DEST_UNITARIA / row.FACTOR_CONVERSION;                    
                    row.CANTIDAD_UNITARIA_ORIG_TOTAL = row.CANTIDAD_UNITARIA_DEST_TOTAL / row.FACTOR_CONVERSION;
                    row.IsMONTO_COSTONull = true;
                    //actualizar pesos
                    row.TAR_BRUTO = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.TAR_BRUTOColumnName].ToString());
                    row.TAR_PESO_NETO = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.TAR_PESO_NETOColumnName].ToString());
                    row.PESO_BRUTO = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.PESO_BRUTOColumnName].ToString());
                    if (campos.Contains(StockTransferenciaBalanceadosDetalleService.Modelo.CASO_IDColumnName))
                        row.CASO_ID = decimal.Parse(campos[StockTransferenciaBalanceadosDetalleService.Modelo.CASO_IDColumnName].ToString());

                    var costoPPP = CostosService.GetCosto(row.ARTICULO_ID, row.DEPOSITO_ORIGEN_ID, cabecerarow.FECHA, sesion);
                    row.MONTO_COSTO = costoPPP.costo * row.CANTIDAD_UNITARIA_ORIG_TOTAL;
                    row.COSTO_MONEDA_ID = costoPPP.moneda_id;
                    row.COTIZACION_MONEDA = costoPPP.cotizacion;
                    row.IsCOSTOS_IDNull = true;

                    //row.RECIBIDO = Definiciones.SiNo.Si;

                    /*Control de disponibilidad del articulo*/
                    decimal disponibles = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, row.DEPOSITO_ORIGEN_ID);

                    if (disponibles + cantidadDestinoAnterior < row.CANTIDAD_UNITARIA_ORIG_TOTAL)
                        throw new Exception("Cantidad disponible insuficiente.");

                    sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.Update(row);
                    string valorNuevo = row.ToString();
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);

                    //si la politica de movimiento de Stock es temprana
                    //Se hace un doble movimiento, primero se devuelve el stock y luego se quita de nuevo
                    AfectarStock(row.TRANSFERENCIA_BALANC_ID, row, sesion, true);
                    AfectarStock(row.TRANSFERENCIA_BALANC_ID, row, sesion, false);

                    sesion.Db.CommitTransaction();

                    ActualizarTotalesStatic(row.TRANSFERENCIA_BALANC_ID);
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }

        #endregion Modificar Detalle

        #region RecibirBalanceados
        public static void RecibirBalanceados(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    STOCK_TRANSFERENCIA_BALANC_DETRow row = new STOCK_TRANSFERENCIA_BALANC_DETRow();
                    STOCK_TRANSFERENCIA_BALANCEADOSRow cabecerarow = new STOCK_TRANSFERENCIA_BALANCEADOSRow();

                    #region actualizar recibido = 'S'
                    decimal detalleId = (decimal)campos[StockTransferenciaBalanceadosDetalleService.Modelo.IDColumnName];
                    row = sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetByPrimaryKey(detalleId);
                    string valorAnterior = row.ToString();

                    row.RECIBIDO = Definiciones.SiNo.Si;

                    sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.Update(row);
                    string valorNuevo = row.ToString();
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    #endregion actualizar recibido = 'S'

                    cabecerarow = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByPrimaryKey(row.TRANSFERENCIA_BALANC_ID);                                      

                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }

        public static void GenerarStock(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    STOCK_TRANSFERENCIA_BALANC_DETRow row = new STOCK_TRANSFERENCIA_BALANC_DETRow();
                    STOCK_TRANSFERENCIA_BALANCEADOSRow cabecerarow = new STOCK_TRANSFERENCIA_BALANCEADOSRow();

                    #region actualizar Generado = 'S'
                    decimal detalleId = (decimal)campos[StockTransferenciaBalanceadosDetalleService.Modelo.IDColumnName];
                    row = sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetByPrimaryKey(detalleId);
                    string valorAnterior = row.ToString();

                    row.GENERAR_STOCK = Definiciones.SiNo.Si;

                    sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.Update(row);
                    string valorNuevo = row.ToString();
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    #endregion actualizar recibido = 'S'

                    #region actualizaStock
                    cabecerarow = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByPrimaryKey(row.TRANSFERENCIA_BALANC_ID);

                    if (cabecerarow.IsCASO_ASOCIADO_IDNull)
                    {
                        string tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaEntrada;
                        decimal depositoDestinoId;
                        // VIGOMEL - 22/10/2020
                        // Si el detalle tiene proveedor_id, buscamos si el mismo tiene deposito asociado.
                        // Si tiene, actualiza stock en deposito asociado.
                        // Caso contrario actualiza para el deposito de la cabecera.
                        if (!row.IsPROVEEDOR_IDNull)
                        {
                            DataTable dt = StockDepositosService.GetStockDepositosDataTable(row.SUCURSAL_DESTINO_ID, row.PROVEEDOR_ID, false, true);
                            if (dt.Rows.Count > 0)
                                depositoDestinoId = decimal.Parse(dt.Rows[0][StockDepositosService.Id_NombreCol].ToString());
                            else
                                depositoDestinoId = row.DEPOSITO_DESTINO_ID;
                        }
                        else
                            depositoDestinoId = row.DEPOSITO_DESTINO_ID;

                        // entrada de stock (por detalle) al deposito destino                        
                        StockService.modificarStock(depositoDestinoId,
                                             row.ARTICULO_ID,
                                             Interprete.Redondear(row.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                             tipoMovimiento, cabecerarow.CASO_ID, row.LOTE_ID,  CasosService.GetEstadoCaso(cabecerarow.CASO_ID, sesion),
                                             sesion, null, null, row.ID);

                        /*StockService.modificarStock(transferenciaRow.DEPOSITO_DESTINO_ID,
                                             detalle.ARTICULO_ID,
                                             Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                             tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                             sesion, null, null, detalle.ID);*/
                    }

                    #endregion actualizaStock

                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }

        #endregion RecibirBalanceados

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

                STOCK_TRANSFERENCIA_BALANC_DETRow row = new STOCK_TRANSFERENCIA_BALANC_DETRow();
                row = sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetByPrimaryKey(detalles_id);
                string valorAnterior = row.ToString();
                string valorNuevo = Definiciones.Log.RegistroBorrado;
                sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.DeleteByPrimaryKey(detalles_id);
                AfectarStock(row.TRANSFERENCIA_BALANC_ID, row, sesion, true);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);

                ActualizarTotalesStatic(row.TRANSFERENCIA_BALANC_ID, sesion);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        #endregion Borrar        

        #region GetStockTransferenciaSucursalDestinoNombrePorDetalle
        public static string GetStockTransferenciaSucursalDestinoNombrePorDetalle(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = StockTransferenciaBalanceadosDetalleService.Modelo.CASO_IDColumnName + " = " + caso_id;
                STOCK_TRANSF_BALANC_DET_INFO_COMPLRow[] row = sesion.db.STOCK_TRANSF_BALANC_DET_INFO_COMPLCollection.GetAsArray(StockTransferenciaBalanceadosDetalleService.Modelo.CASO_IDColumnName + " = " + caso_id, string.Empty);
                if (row.Length == 1)
                    return row[0].SUCURSAL_DESTINO;
                else
                    return string.Empty;
            }
        }
        #endregion GetStockTransferenciaSucursalDestinoNombrePorCaso

        #region AfectarStock
        private static void AfectarStock(decimal stock_transferencia_id, STOCK_TRANSFERENCIA_BALANC_DETRow row, SessionService sesion, bool borrar)
        {
            DataTable dtTransferencia = StockTransferenciasBalanceadosService.GetStockTransferenciaDataTable2(StockTransferenciasBalanceadosService.Modelo.IDColumnName + " = " + row.TRANSFERENCIA_BALANC_ID, string.Empty, sesion);

            string tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaSalida;
            if (borrar)
                tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaEntrada;

            bool afectarCostos = StockService.modificarStock(row.DEPOSITO_ORIGEN_ID,
                                 row.ARTICULO_ID,
                                 Interprete.Redondear(row.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                 tipoMovimiento, (decimal)dtTransferencia.Rows[0][StockTransferenciasBalanceadosService.Modelo.CASO_IDColumnName], row.LOTE_ID, string.Empty,
                                 sesion, null, null, row.ID);
        }
        #endregion AfectarStock

        #region ActualizarTotales
        private void ActualizarTotales(decimal transferencia_id, SessionService sesion)
        {

            try
            {
                decimal costoTranferencia = 0;
                STOCK_TRANSFERENCIA_BALANCEADOSRow cabecera = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByPrimaryKey(transferencia_id);
                STOCK_TRANSFERENCIA_BALANC_DETRow[] detalles = sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetByTRANSFERENCIA_BALANC_ID(transferencia_id);

                for (int i = 0; i < detalles.Length; i++)
                {
                    if (cabecera.MONEDA_ID != detalles[i].COSTO_MONEDA_ID)
                    {
                        costoTranferencia += detalles[i].MONTO_COSTO / detalles[i].COTIZACION_MONEDA * cabecera.COTIZACION;
                    }
                    else
                    {
                        costoTranferencia += detalles[i].MONTO_COSTO;
                    }
                }

                cabecera.COSTO_TRANSFERENCIA = costoTranferencia;

                cabecera.TOTAL_COSTO = cabecera.COSTO_ASOCIADO + costoTranferencia;

                sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.Update(cabecera);
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
            STOCK_TRANSFERENCIA_BALANCEADOSRow cabecera = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByPrimaryKey(transferencia_id);
            STOCK_TRANSFERENCIA_BALANC_DETRow[] detalles = sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetByTRANSFERENCIA_BALANC_ID(transferencia_id);

            for (int i = 0; i < detalles.Length; i++)
            {
                if (cabecera.MONEDA_ID != detalles[i].COSTO_MONEDA_ID)
                    costoTranferencia += detalles[i].MONTO_COSTO / detalles[i].COTIZACION_MONEDA * cabecera.COTIZACION;
                else
                    costoTranferencia += detalles[i].MONTO_COSTO;
            }

            cabecera.COSTO_TRANSFERENCIA = costoTranferencia;
            cabecera.TOTAL_COSTO = cabecera.COSTO_ASOCIADO + costoTranferencia;
            sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.Update(cabecera);
        }
        #endregion ActualizarTotales

        public static bool GetExisteNroComprobante(decimal transferencia_balanceado_id, decimal autonumeracion_id, string nro_comprobante, SessionService sesion)
        {
            bool existe = false;
            string clausulas = string.Empty;

            if (!autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                clausulas += StockTransferenciaBalanceadosDetalleService.Modelo.AUTONUMERACION_IDColumnName + " = " + autonumeracion_id + " and ";

            clausulas += StockTransferenciaBalanceadosDetalleService.Modelo.NRO_COMPROBANTEColumnName + " = '" + nro_comprobante + "' " +
                         " and " + StockTransferenciaBalanceadosDetalleService.Modelo.TRANSFERENCIA_BALANC_IDColumnName + " <> " + transferencia_balanceado_id;

            DataTable rows = StockTransferenciaBalanceadosDetalleService.GetStockTransferenciaBalanceadosDetalleInfoCompleta(clausulas, string.Empty);

            existe = rows.Rows.Count > 0;

            return existe;
        }

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "STOCK_TRANSFERENCIA_BALANC_DET"; }
        }
        public static string Nombre_Vista
        {
            get { return "stock_transf_balanc_det_info_compl"; } 
        }

        public class Modelo : STOCK_TRANSFERENCIA_BALANC_DETCollection_Base { public Modelo() : base(null) { } }
        public class VistaModelo : STOCK_TRANSF_BALANC_DET_INFO_COMPLCollection_Base { public VistaModelo() : base(null) { } }
        #endregion Accessors 

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static StockTransferenciaBalanceadosDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new StockTransferenciaBalanceadosDetalleService(e.RegistroId, sesion);
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
        protected STOCK_TRANSFERENCIA_BALANC_DETRow row;
        protected STOCK_TRANSFERENCIA_BALANC_DETRow rowSinModificar;

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
        public decimal? TransferenciaStockId { get { if (row.IsTRANSFERENCIA_BALANC_IDNull) return null; else return row.TRANSFERENCIA_BALANC_ID; } set { if (value.HasValue) row.TRANSFERENCIA_BALANC_ID = value.Value; else row.IsTRANSFERENCIA_BALANC_IDNull = true; } }
        public string UnidadMedidaDestinoId { get { return ClaseCBABase.GetStringHelper(row.UNIDAD_MEDIDA_DESTINO_ID); } set { row.UNIDAD_MEDIDA_DESTINO_ID = value; } }
        public string UnidadMedidaOrigenId { get { return ClaseCBABase.GetStringHelper(row.UNIDAD_MEDIDA_ORIGEN_ID); } set { row.UNIDAD_MEDIDA_ORIGEN_ID = value; } }
        public decimal DepositoDestinoId { get { return row.DEPOSITO_DESTINO_ID; } set { row.DEPOSITO_DESTINO_ID = value; } }
        public decimal SucursalDestinoId { get { return row.SUCURSAL_DESTINO_ID; } set { row.SUCURSAL_DESTINO_ID = value; } }
        public decimal? TarBruto { get { if (row.IsTAR_BRUTONull) return null; else return row.TAR_BRUTO; } set { if (value.HasValue) row.TAR_BRUTO = value.Value; else row.IsTAR_BRUTONull = true; } }
        public decimal? TarPesoNeto { get { if (row.IsTAR_PESO_NETONull) return null; else return row.TAR_PESO_NETO; } set { if (value.HasValue) row.TAR_PESO_NETO = value.Value; else row.IsTAR_PESO_NETONull = true; } }
        public decimal? PesoBruto { get { if (row.IsPESO_BRUTONull) return null; else return row.PESO_BRUTO; } set { if (value.HasValue) row.PESO_BRUTO = value.Value; else row.IsPESO_BRUTONull = true; } }
        public decimal DepositoOrigenId { get { return row.DEPOSITO_ORIGEN_ID; } set { row.DEPOSITO_ORIGEN_ID = value; } }
        public decimal NroCelda { get { return row.NRO_CELDA; } set { row.NRO_CELDA = value; } }
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

        private StockTransferenciasBalanceadosService _transferencia_stock;
        public StockTransferenciasBalanceadosService TransferenciaStock
        {
            get
            {
                if (this._transferencia_stock == null)
                    this._transferencia_stock = new StockTransferenciasBalanceadosService(this.TransferenciaStockId.Value);
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
                this.row = sesion.db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_TRANSFERENCIA_BALANC_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(STOCK_TRANSFERENCIA_BALANC_DETRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public StockTransferenciaBalanceadosDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockTransferenciaBalanceadosDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockTransferenciaBalanceadosDetalleService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private StockTransferenciaBalanceadosDetalleService(STOCK_TRANSFERENCIA_BALANC_DETRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static StockTransferenciaBalanceadosDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static StockTransferenciaBalanceadosDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetAsArray(StockTransferenciaBalanceadosDetalleService.Modelo.TRANSFERENCIA_BALANC_IDColumnName + " = " + cabecera_id, StockTransferenciaBalanceadosDetalleService.Modelo.IDColumnName);
            StockTransferenciaBalanceadosDetalleService[] td = new StockTransferenciaBalanceadosDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                td[i] = new StockTransferenciaBalanceadosDetalleService(rows[i]);
            return td;
        }
        #endregion GetPorCabecera

        #region GetStockMovimiento
        public StockMovimientoService GetStockMovimiento()
        {
            using (SessionService sesion = new SessionService())
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
