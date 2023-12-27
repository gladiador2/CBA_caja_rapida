#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Facturacion;
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class CostosService
    {
        #region Crear DataRow Costo
        public static DataRow CrearDataRowCosto()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(CostosService.Costo_NombreCol, typeof(decimal));
            dt.Columns.Add(CostosService.MonedaId_NombreCol, typeof(decimal));
            dt.Columns.Add(CostosService.Cotizacion_NombreCol, typeof(decimal));

            return dt.NewRow();
        }
        #endregion Crear DataRow Costo

        #region AjustarCosto
        public decimal AjustarCosto(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {

                try
                {
                    ARTICULOS_COSTOSRow row = new ARTICULOS_COSTOSRow();
                    ARTICULOS_LOTESRow loteRow = new ARTICULOS_LOTESRow();

                    sesion.Db.BeginTransaction();
                    row.ID = sesion.Db.GetSiguienteSecuencia("articulos_costos_sqc");
                    row.LOTE_ID = decimal.Parse(campos[CostosService.LoteId_NombreCol].ToString());
                    if (campos.Contains(CostosService.CasoId_NombreCol)
                        && campos[CostosService.CasoId_NombreCol] != null)
                    {
                        row.CASO_ID = decimal.Parse(campos[CostosService.CasoId_NombreCol].ToString());
                    }
                    else
                    {
                        row.IsCASO_IDNull = true;
                    }
                    row.CANTIDAD_INICIAL = decimal.Parse(campos[CostosService.CantidadInicial_NombreCol].ToString());
                    row.CANTIDAD_RESTANTE = decimal.Parse(campos[CostosService.CantidadRestante_NombreCol].ToString());
                    row.MONEDA_ID = decimal.Parse(campos[CostosService.MonedaId_NombreCol].ToString());
                    row.COTIZACION = decimal.Parse(campos[CostosService.Cotizacion_NombreCol].ToString());
                    if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda.");

                    row.IsFECHA_FINNull = true;
                    loteRow = sesion.Db.ARTICULOS_LOTESCollection.GetByPrimaryKey(row.LOTE_ID);
                    row.ARTICULO_ID = loteRow.ARTICULO_ID;

                    row.COSTO = decimal.Parse(campos[CostosService.Costo_NombreCol].ToString());

                    row.COSTO_PONDERADO = row.COSTO;
                    row.AJUSTE_MANUAL = Definiciones.SiNo.Si;
                    row.FECHA_INSERCION = DateTime.Now;

                    sesion.Db.ARTICULOS_COSTOSCollection.Insert(row);
                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion AjustarCosto

        #region GetCostosDataTable
        public static DataTable GetCostosDataTable(string clausulas, string order)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCostosDataTable(clausulas, order, sesion);
            }
        }

        public static DataTable GetCostosDataTable(string clausulas, string order, SessionService sesion)
        {
            string where = CostosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            if (clausulas.Length >= 0)
                where += " and " + clausulas;
            return sesion.Db.ARTICULOS_COSTOSCollection.GetAsDataTable(where, order);
        }
        #endregion GetCostosDataTable

        #region GetCostosInfoCompleta
        /// <summary>
        /// Gets the costos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public DataTable GetCostosInfoCompleta(string clausulas, string order)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CostosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length >= 0)
                    where += " and " + clausulas;
                return sesion.Db.ARTICULOS_COSTO_INFO_COMPLETACollection.GetAsDataTable(where, order);
            }
        }

        public DataTable GetCostosInfoCompletaPorArticulo(decimal articulo_id)
        {
            string clausulas = CostosService.ArticuloId_NombreCol + "=" + articulo_id;
            return GetCostosInfoCompleta(clausulas, CostosService.FechaInsercion_NombreCol + "," + CostosService.Id_NombreCol);
        }

        #endregion GetCostosInfoCompleta

        # region ObtenerColumnaTipoCosteo
        public static string ObtenerColumnaTipoCosteo()
        {
            using (SessionService sesion = new SessionService())
            {
                if (sesion.tipoCosto == Definiciones.TipoCosto.Fifo)
                {
                    return CostosService.Costo_NombreCol;
                }
                else
                {
                    return CostosService.CostoPoderado_NombreCol;
                }
            }
        }

        #endregion ObtenerTipoCosteo

        #region GetCosto
        public static StockService.Costo GetCosto(decimal articulo_id, decimal deposito_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCosto(articulo_id, deposito_id, fecha, sesion);
            }
        }
        public static StockService.Costo GetCosto(decimal articulo_id, decimal deposito_id, DateTime fecha, SessionService sesion)
        {
            var deposito = new StockDepositosService(deposito_id, sesion);

            var sm = new StockMovimientoService()
            {
                ArticuloId = articulo_id,
                SucursalId = deposito.SucursalId,
                DepositoId = deposito.Id.Value,
                FechaFormulario = fecha,
                CostoMonedaOrigenId = deposito.Sucursal.Region.SucursalCasaMatriz.MonedaId,
                CostoOrigen = 0,
            };

            sm.IniciarUsingSesion(sesion);
            var costoPPP = sm.CostoPPP;
            sm.FinalizarUsingSesion();
            
            return costoPPP;
        }
        #endregion GetCosto

        #region GetUltimoCosto

        public static StockMovimientoService GetUltimoCosto(decimal articulo_id, decimal region_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUltimoCosto(articulo_id, region_id, fecha, sesion);
            }
        }

        public static StockMovimientoService GetUltimoCosto(decimal articulo_id, decimal region_id, DateTime fecha, SessionService sesion)
        {
            string query = @"
                select " + StockMovimientoService.Modelo.IDColumnName + @"
                  from (
                        select rownum, sm." + StockMovimientoService.Modelo.IDColumnName + @"
                          from " + StockMovimientoService.Nombre_Tabla + @" sm, " + SucursalesService.Nombre_Tabla + @" s 
                          where sm." + StockMovimientoService.Modelo.TIPO_MOVIMIENTOColumnName + @" = '" + Definiciones.Stock.TipoMovimiento.Compra + @"' 
                            and trunc(sm." + StockMovimientoService.Modelo.FECHA_FORMULARIOColumnName + @") <= to_date('" + fecha.ToShortDateString() + @"', 'dd/mm/yyyy') 
                            and sm." + StockMovimientoService.Modelo.ARTICULO_IDColumnName + @" = " + articulo_id + @"
                            and sm." + StockMovimientoService.Modelo.SUCURSAL_IDColumnName + @" = s." + SucursalesService.Id_NombreCol + @" 
                            and sm." + StockMovimientoService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + @"'";

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticulosCostosIndependiente) == Definiciones.SiNo.Si)
                query += " and s." + SucursalesService.RegionId_NombreCol + " = " + region_id;
            query += @" 
                      order by trunc(sm." + StockMovimientoService.Modelo.FECHA_FORMULARIOColumnName + @") desc, sm."+ StockMovimientoService.Modelo.COSTOColumnName + @" desc 
                    )
              where rownum = 1";

            DataTable dt = sesion.db.EjecutarQuery(query);

            if (dt.Rows.Count <= 0)
                return null;
            else
                return new StockMovimientoService((decimal)dt.Rows[0][StockMovimientoService.Modelo.IDColumnName], sesion);
        }
        #endregion GetUltimoCosto

        #region GetIVAUltimoCosto
        public static decimal? GetIVAUltimoCosto(decimal articulo_id, decimal region_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetIVAUltimoCosto(articulo_id, region_id, fecha, sesion);
            }
        }

        public static decimal? GetIVAUltimoCosto(decimal articulo_id, decimal region_id, DateTime fecha, SessionService sesion)
        {
            string query = @"
                select " + StockMovimientoService.Costo_NombreCol + @"
                  from (
                        select rownum, (sm." + StockMovimientoService.Modelo.COSTOColumnName + @" * i." + ImpuestosService.Porcentaje_NombreCol + @") / 100 " +StockMovimientoService.Costo_NombreCol + @"  
                          from " + StockMovimientoService.Nombre_Tabla + @" sm, " + SucursalesService.Nombre_Tabla + @" s, " + ImpuestosService.Nombre_Tabla + @" i  
                          where sm." + StockMovimientoService.Modelo.TIPO_MOVIMIENTOColumnName + @" = '" + Definiciones.Stock.TipoMovimiento.Compra + @"' 
                            and trunc(sm." + StockMovimientoService.Modelo.FECHA_FORMULARIOColumnName + @") <= to_date('" + fecha.ToShortDateString() + @"', 'dd/mm/yyyy') 
                            and sm." + StockMovimientoService.Modelo.ARTICULO_IDColumnName + @" = " + articulo_id + @"
                            and sm." + StockMovimientoService.Modelo.SUCURSAL_IDColumnName + @" = s." + SucursalesService.Id_NombreCol + @" 
                            and sm." + StockMovimientoService.Modelo.IMPUESTO_IDColumnName + @" = i." + ImpuestosService.Id_NombreCol + @" 
                            and sm." + StockMovimientoService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + @"'";

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionArticulosCostosIndependiente) == Definiciones.SiNo.Si)
                query += " and s." + SucursalesService.RegionId_NombreCol + " = " + region_id;
            query += @" 
                      order by trunc(sm." + StockMovimientoService.Modelo.FECHA_FORMULARIOColumnName + @") desc, sm."+ StockMovimientoService.Modelo.COSTOColumnName + @" desc 
                    )
              where rownum = 1";

            DataTable dt = sesion.db.EjecutarQuery(query);

            if (dt.Rows.Count <= 0)
                return null;
            else
                return (decimal)dt.Rows[0]["costo"];        
        }

        #endregion GetIVAUltimoCosto

        #region CorreccionCostos
        public static void RecalcularCostos(decimal articulo_id, DateTime fechaInsercion, SessionService sesion, bool usarFechaRstanteActual)
        {

            ARTICULOS_COSTOSRow[] costosRow;
            ARTICULOS_COSTOSRow costoActual;
            ARTICULOS_COSTOSRow costoAnterior;
            ARTICULOS_COSTOSRow costoSiguiente = new ARTICULOS_COSTOSRow();

            ARTICULOS_COSTOSRow[] costoNC;
            NOTAS_CREDITO_PERSONASRow ncRow;
            NOTAS_CREDITO_PERSONAS_DETRow[] ncDetalleRow;


            FACTURAS_CLIENTE_DETALLERow facturaDetalleRow = new FACTURAS_CLIENTE_DETALLERow();
            STOCK_TRANSFERENCIA_DETALLERow transferenciaDetalleRow = new STOCK_TRANSFERENCIA_DETALLERow();
            STOCK_AJUSTE_DETALLERow ajusteDetallesRow = new STOCK_AJUSTE_DETALLERow();
            USO_DE_INSUMOS_DETALLERow insumoDetallesRow = new USO_DE_INSUMOS_DETALLERow();

            string queryStockFecha = string.Empty;
            string queryNCCosto = string.Empty;
            decimal cantidadArticuloFecha;

            try
            {
                costosRow = sesion.db.ARTICULOS_COSTOSCollection.GetAsArray(CostosService.ArticuloId_NombreCol + "=" + articulo_id + " and " + CostosService.Estado_NombreCol + " = 'A' ", CostosService.FechaInsercion_NombreCol);

                

                for (int indiceCostos = 0; indiceCostos < costosRow.Length; indiceCostos++)
                {
                    if (indiceCostos < (costosRow.Length - 1))
                    {
                        costoSiguiente = sesion.db.ARTICULOS_COSTOSCollection.GetByPrimaryKey(costosRow[indiceCostos + 1].ID);
                    }

                    if (fechaInsercion < costosRow[indiceCostos].FECHA_INSERCION || fechaInsercion == costosRow[indiceCostos].FECHA_INSERCION)
                    {
                        
                        #region Calculo del nuevo Costo Ponderado
                        if (indiceCostos == 0)
                        {

                            costoActual = sesion.db.ARTICULOS_COSTOSCollection.GetByPrimaryKey(costosRow[indiceCostos].ID);
                            costoActual.COSTO_PONDERADO = costoActual.COSTO;
                            costoAnterior = costoActual;
                        }
                        else
                        {
                            costoActual = sesion.db.ARTICULOS_COSTOSCollection.GetByPrimaryKey(costosRow[indiceCostos].ID);
                            costoAnterior = sesion.db.ARTICULOS_COSTOSCollection.GetByPrimaryKey(costosRow[indiceCostos - 1].ID);
                            if (usarFechaRstanteActual)
                            {
                                cantidadArticuloFecha = costoActual.CANTIDAD_REST_FECHA_INSERCION;
                            }
                            else
                            {
                                cantidadArticuloFecha = 0;
                                if (costoActual.IsCASO_IDNull)
                                {
                                    cantidadArticuloFecha += StockMovimientoService.GetDiferenciaStockFechaHoraMovimiento(articulo_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, DateTime.Now, false, costoActual.FECHA_INSERCION);
                                }
                                else
                                {
                                    cantidadArticuloFecha += StockMovimientoService.GetDiferenciaStockFechaHoraMovimientoConComparacionDeMovimientoActual(articulo_id, costoActual.LOTE_ID, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, DateTime.Now, false, costoActual.FECHA_INSERCION, costoActual.CASO_ID,false);
                                }
                                
                            }
                            if (cantidadArticuloFecha == 0)
                            {
                                costoActual.COSTO_PONDERADO = costoActual.COSTO;
                                costoActual.CANTIDAD_REST_FECHA_INSERCION = 0;
                            }
                            else
                            {
                                if (cantidadArticuloFecha < 0)
                                    cantidadArticuloFecha = 0;

                                if (costoActual.MONEDA_ID != costoAnterior.MONEDA_ID)
                                {
                                    costoActual.COSTO_PONDERADO = ((costoActual.COSTO * costoActual.CANTIDAD_INICIAL) + ((costoAnterior.COSTO_PONDERADO / costoAnterior.COTIZACION * costoActual.COTIZACION) * cantidadArticuloFecha)) / (costoActual.CANTIDAD_INICIAL + cantidadArticuloFecha);

                                }
                                else
                                {
                                    if (costosRow[indiceCostos].COSTO == costoAnterior.COSTO_PONDERADO)
                                    {
                                        costoActual.COSTO_PONDERADO = costosRow[indiceCostos].COSTO;
                                    }
                                    else
                                    {
                                        costoActual.COSTO_PONDERADO = ((costosRow[indiceCostos].COSTO * costoActual.CANTIDAD_INICIAL) + (costoAnterior.COSTO_PONDERADO * cantidadArticuloFecha)) / (costoActual.CANTIDAD_INICIAL + cantidadArticuloFecha);
                                    }
                                }
                                //costoActual.COSTO_PONDERADO = Decimal.Ceiling(costoActual.COSTO_PONDERADO);
                                costoActual.CANTIDAD_REST_FECHA_INSERCION = cantidadArticuloFecha;
                            }

                        }
                        #endregion Calculo del nuevo Costo Ponderado

                        string filtroFecha = string.Empty;
                        if (indiceCostos < (costosRow.Length - 1))
                        {
                            costoSiguiente = sesion.db.ARTICULOS_COSTOSCollection.GetByPrimaryKey(costosRow[indiceCostos + 1].ID);
                            filtroFecha += " and fecha_movimiento< to_date('" + costoSiguiente.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        }

                        filtroFecha += " and fecha_movimiento>= to_date('" + costoActual.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";

                        #region Facturas Anuladas
                        
                        string queryAnuladas = string.Empty;

                        queryAnuladas = " select  fc.caso_id as caso, fc.id,fcd.id as detalle  ";
                        queryAnuladas += " from facturas_cliente fc, facturas_cliente_detalle fcd,stock_movimientos sm ";
                        queryAnuladas += " where fc.id = fcd.facturas_cliente_id ";
                        queryAnuladas += " and fc.caso_id = sm.caso_id ";
                        queryAnuladas += " and fcd.articulo_id = sm. articulo_id ";
                        queryAnuladas += " and sm.cantidad<0 ";
                        if (indiceCostos < (costosRow.Length - 1))
                        {
                            costoSiguiente = sesion.db.ARTICULOS_COSTOSCollection.GetByPrimaryKey(costosRow[indiceCostos + 1].ID);
                            queryAnuladas += " and sm.fecha_movimiento< to_date('" + costoSiguiente.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        }

                        queryAnuladas += " and sm.fecha_movimiento>= to_date('" + costoActual.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        queryAnuladas += " and  fcd.articulo_id =" + costoActual.ARTICULO_ID + " order by  sm.fecha_movimiento asc";

                        //Facturas de Clientes.
                        DataTable facturasAnuladas = sesion.db.EjecutarQuery(queryAnuladas);
                        if (facturasAnuladas.Rows.Count > 0)
                        {
                            for (int indiceFacturasAnuladas = 0; indiceFacturasAnuladas < facturasAnuladas.Rows.Count; indiceFacturasAnuladas++)
                            {
                                decimal facturaAnuladaId = decimal.Parse(facturasAnuladas.Rows[indiceFacturasAnuladas]["detalle"].ToString());
                                decimal casoAnuladoId = decimal.Parse(facturasAnuladas.Rows[indiceFacturasAnuladas]["caso"].ToString());
                            
                                facturaDetalleRow = new FACTURAS_CLIENTE_DETALLERow();
                                facturaDetalleRow = sesion.db.FACTURAS_CLIENTE_DETALLECollection.GetByPrimaryKey(decimal.Parse(facturasAnuladas.Rows[indiceFacturasAnuladas]["detalle"].ToString()));
                                string clausulaHistoricaAnuladas = STOCK_MOVIMIENTOSCollection.CASO_IDColumnName + "=" + casoAnuladoId + " and " + STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName + "=" + facturaDetalleRow.ARTICULO_ID;
                                STOCK_MOVIMIENTOSRow[] movimientoFactura = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulaHistoricaAnuladas + filtroFecha, string.Empty);
                                for (int movimientoFacturaIndice = 0; movimientoFacturaIndice < movimientoFactura.Length; movimientoFacturaIndice++)
                                {
                                    movimientoFactura[movimientoFacturaIndice].COSTO = costoActual.COSTO_PONDERADO;
                                    movimientoFactura[movimientoFacturaIndice].COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                    movimientoFactura[movimientoFacturaIndice].COSTO_COTIZACION_MONEDA = costoActual.COTIZACION;

                                    sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientoFactura[movimientoFacturaIndice]);
                                }
                            }
                        }

                        #endregion Facturas Anuladas

                        #region Facturas de Clientes y NC Vinculadas
                        string query = string.Empty;

                        query = " select  fc.caso_id as caso, fc.id,fcd.id as detalle  ";
                        query += " from facturas_cliente fc, facturas_cliente_detalle fcd,stock_movimientos sm ";
                        query += " where fc.id = fcd.facturas_cliente_id ";
                        query += " and fc.caso_id = sm.caso_id ";
                        query += " and fcd.articulo_id = sm. articulo_id ";
                        query += " and sm.cantidad>0 ";
                        if (indiceCostos < (costosRow.Length - 1))
                        {
                            costoSiguiente = sesion.db.ARTICULOS_COSTOSCollection.GetByPrimaryKey(costosRow[indiceCostos + 1].ID);
                            query += " and sm.fecha_movimiento< to_date('" + costoSiguiente.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        }

                        query += " and sm.fecha_movimiento>= to_date('" + costoActual.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        query += " and  fcd.articulo_id =" + costoActual.ARTICULO_ID + " order by  sm.fecha_movimiento asc";

                        //Facturas de Clientes.
                        DataTable facturas = sesion.db.EjecutarQuery(query);
                        if (facturas.Rows.Count > 0)
                        {

                            for (int indiceFacturas = 0; indiceFacturas < facturas.Rows.Count; indiceFacturas++)
                            {
                                decimal facturId = decimal.Parse(facturas.Rows[indiceFacturas]["detalle"].ToString());
                                decimal casoId = decimal.Parse(facturas.Rows[indiceFacturas]["caso"].ToString());
                                if (casoId == 1905530)
                                {
                                    string problema = "aqui esta el pr0blema";
                                }

                                facturaDetalleRow = new FACTURAS_CLIENTE_DETALLERow();
                                facturaDetalleRow = sesion.db.FACTURAS_CLIENTE_DETALLECollection.GetByPrimaryKey(decimal.Parse(facturas.Rows[indiceFacturas]["detalle"].ToString()));
                                facturaDetalleRow.COSTO_MONTO = costoActual.COSTO_PONDERADO;
                                facturaDetalleRow.COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                facturaDetalleRow.COSTO_MONEDA_COTIZACION = costoActual.COTIZACION;
                                sesion.db.FACTURAS_CLIENTE_DETALLECollection.Update(facturaDetalleRow);

                                string clausulaHistorica = STOCK_MOVIMIENTOSCollection.CASO_IDColumnName + "=" + casoId + " and " + STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName + "=" + facturaDetalleRow.ARTICULO_ID;
                                STOCK_MOVIMIENTOSRow[] movimientoFactura = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulaHistorica + filtroFecha, string.Empty);
                                for (int movimientoFacturaIndice = 0; movimientoFacturaIndice < movimientoFactura.Length; movimientoFacturaIndice++)
                                {
                                    movimientoFactura[movimientoFacturaIndice].COSTO = costoActual.COSTO_PONDERADO;
                                    movimientoFactura[movimientoFacturaIndice].COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                    movimientoFactura[movimientoFacturaIndice].COSTO_COTIZACION_MONEDA = costoActual.COTIZACION;

                                    sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientoFactura[movimientoFacturaIndice]);
                                }



                                //Notas de Creditos Asociadas
                                ncDetalleRow = sesion.db.NOTAS_CREDITO_PERSONAS_DETCollection.GetByFACTURA_CLIENTE_DETALLE_ID(facturaDetalleRow.ID);
                                for (int indiceNCDetalle = 0; indiceNCDetalle < ncDetalleRow.Length; indiceNCDetalle++)
                                {

                                    ncRow = sesion.db.NOTAS_CREDITO_PERSONASCollection.GetByPrimaryKey(ncDetalleRow[indiceNCDetalle].NOTA_CREDITO_PERSONA_ID);
                                    queryNCCosto = CostosService.CasoId_NombreCol + "=" + ncRow.CASO_ID + " and " + CostosService.LoteId_NombreCol + "=" + ncDetalleRow[indiceNCDetalle].LOTE_ID;
                                    costoNC = sesion.db.ARTICULOS_COSTOSCollection.GetAsArray(queryNCCosto, CostosService.FechaInsercion_NombreCol);
                                    for (int indiceCostoNC = 0; indiceCostoNC < costoNC.Length; indiceCostoNC++)
                                    {

                                        costoNC[indiceCostoNC].COSTO = costoActual.COSTO_PONDERADO;
                                        costoNC[indiceCostoNC].MONEDA_ID = costoActual.MONEDA_ID;
                                        costoNC[indiceCostoNC].COTIZACION = costoActual.COTIZACION;
                                        sesion.db.ARTICULOS_COSTOSCollection.Update(costoNC[indiceCostoNC]);

                                        string clausulaHistoricaNC = STOCK_MOVIMIENTOSCollection.CASO_IDColumnName + "=" + ncRow.CASO_ID + " and " + STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName + "=" + ncDetalleRow[indiceNCDetalle].ARTICULO_ID;
                                        STOCK_MOVIMIENTOSRow[] movimientoNC = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulaHistoricaNC + filtroFecha, string.Empty);
                                        for (int movimientoNCIndice = 0; movimientoNCIndice < movimientoNC.Length; movimientoNCIndice++)
                                        {
                                            movimientoNC[movimientoNCIndice].COSTO = costoActual.COSTO_PONDERADO;
                                            movimientoNC[movimientoNCIndice].COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                            movimientoNC[movimientoNCIndice].COSTO_COTIZACION_MONEDA = costoActual.COTIZACION;

                                            sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientoNC[movimientoNCIndice]);
                                        }

                                    }
                                    if (costoNC.Length < 1)
                                    {
                                        string clausulaHistoricaNC2 = STOCK_MOVIMIENTOSCollection.CASO_IDColumnName + "=" + ncRow.CASO_ID + " and " + STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName + "=" + ncDetalleRow[indiceNCDetalle].ARTICULO_ID;
                                        STOCK_MOVIMIENTOSRow[] movimientoNC2 = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulaHistoricaNC2 + filtroFecha, string.Empty);
                                        for (int movimientoNCIndice2 = 0; movimientoNCIndice2 < movimientoNC2.Length; movimientoNCIndice2++)
                                        {
                                            movimientoNC2[movimientoNCIndice2].COSTO = costoActual.COSTO_PONDERADO;
                                            movimientoNC2[movimientoNCIndice2].COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                            movimientoNC2[movimientoNCIndice2].COSTO_COTIZACION_MONEDA = costoActual.COTIZACION;

                                            sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientoNC2[movimientoNCIndice2]);
                                        }
                                    }
                                }
                            }
                        }
                        #endregion Facturas de Clientes y NC Vinculadas

                        #region Actulizacion  de Costos de Movimientos para los casos de Factura de Proceedor e Ingreso de stock
                        if (!costosRow[indiceCostos].IsCASO_IDNull)
                        {
                            int flujoId = (int)CasosService.GetFlujo(costosRow[indiceCostos].CASO_ID, sesion);
                            if (flujoId.Equals(Definiciones.FlujosIDs.INGRESO_DE_STOCK) || flujoId.Equals(Definiciones.FlujosIDs.FACTURACION_PROVEEDOR))
                            {
                                string clausulaHistoricaCompra = STOCK_MOVIMIENTOSCollection.CASO_IDColumnName + "=" + costosRow[indiceCostos].CASO_ID + " and " + STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName + "=" + costoActual.ARTICULO_ID;

                                STOCK_MOVIMIENTOSRow[] movimientoCompra = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulaHistoricaCompra, string.Empty);

                                for (int movimientoCompraIndice = 0; movimientoCompraIndice < movimientoCompra.Length; movimientoCompraIndice++)
                                {
                                    movimientoCompra[movimientoCompraIndice].COSTO = costoActual.COSTO;
                                    movimientoCompra[movimientoCompraIndice].COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                    movimientoCompra[movimientoCompraIndice].COSTO_COTIZACION_MONEDA = costoActual.COTIZACION;

                                    sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientoCompra[movimientoCompraIndice]);
                                }
                            }
                        }
                        #endregion Actulizacion  de Costos de Movimientos para los casos de Factura de Proceedor e Ingreso de stock

                        #region Actualización de Uso de Insumos
                        string queryInsumos = string.Empty;

                        queryInsumos = "select us.caso_id as caso, us.id, usd.id as detalle, al.articulo_id as articulo_id  ";
                        queryInsumos += " from uso_de_insumos us, uso_de_insumos_detalle usd,stock_movimientos sm,articulos_lotes  al ";
                        queryInsumos += " where us.id = usd.uso_de_insumo_id";
                        queryInsumos += " and us.caso_id = sm.caso_id";
                        queryInsumos += " and al.id = usd.articulo_lote_id  ";
                        queryInsumos += " and al.articulo_id = sm.articulo_id ";

              
                        if (indiceCostos < (costosRow.Length - 1))
                        {
                            queryInsumos += " and sm.fecha_movimiento< to_date('" + costoSiguiente.FECHA_INSERCION+ "','dd/MM/YYYY hh24:mi:ss')";
                        }

                        queryInsumos += " and sm.fecha_movimiento>= to_date('" + costoActual.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        queryInsumos += " and al.articulo_id =" + costoActual.ARTICULO_ID + " order by  sm.fecha_movimiento asc";
                        DataTable dtInsumos = sesion.db.EjecutarQuery(queryInsumos);

                        if (dtInsumos.Rows.Count > 0)
                        {
                            for (int indiceInsumos = 0; indiceInsumos < dtInsumos.Rows.Count; indiceInsumos++)
                            {
                                decimal insumoDetalleId = decimal.Parse(dtInsumos.Rows[indiceInsumos]["detalle"].ToString());
                                decimal insumoCasoId = decimal.Parse(dtInsumos.Rows[indiceInsumos]["caso"].ToString());
                                decimal insumoArticuloId = decimal.Parse(dtInsumos.Rows[indiceInsumos]["articulo_id"].ToString());
                                insumoDetallesRow = new USO_DE_INSUMOS_DETALLERow();
                                insumoDetallesRow = sesion.db.USO_DE_INSUMOS_DETALLECollection.GetByPrimaryKey(insumoDetalleId);
                                insumoDetallesRow.COSTO_TOTAL = costoActual.COSTO_PONDERADO * insumoDetallesRow.CANTIDAD_UNITARIA_TOTAL_DEST;
                                insumoDetallesRow.COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                insumoDetallesRow.COSTO_MONEDA_COTIZACION = costoActual.COTIZACION;
                                sesion.db.USO_DE_INSUMOS_DETALLECollection.Update(insumoDetallesRow);

                                string clausulaHistoricaUI = STOCK_MOVIMIENTOSCollection.CASO_IDColumnName + "=" + insumoCasoId + " and " + STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName + "=" + insumoArticuloId;
                                STOCK_MOVIMIENTOSRow[] movimientoUI = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulaHistoricaUI + filtroFecha, string.Empty);
                                for (int movimientoUIIndice = 0; movimientoUIIndice < movimientoUI.Length; movimientoUIIndice++)
                                {
                                    movimientoUI[movimientoUIIndice].COSTO = costoActual.COSTO_PONDERADO;
                                    movimientoUI[movimientoUIIndice].COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                    movimientoUI[movimientoUIIndice].COSTO_COTIZACION_MONEDA = costoActual.COTIZACION;

                                    sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientoUI[movimientoUIIndice]);
                                }
                            }
                        }

                        #endregion Actualización de Uso de Insumos

                        #region Actulización de Costos de Transferencia de Articulos
                        string queryTransferencias = string.Empty;

                        queryTransferencias = " select st.caso_id as caso, st.id, std.id as detalle  ";
                        queryTransferencias += " from stock_transferencia st, stock_transferencia_detalle std,stock_movimientos sm ";
                        queryTransferencias += " where st.id = std.transferencia_stock_id ";
                        queryTransferencias += " and st.caso_id = sm.caso_id";
                        queryTransferencias += " and std.articulo_id = sm. articulo_id ";
                        if (indiceCostos < (costosRow.Length - 1))
                        {

                            queryTransferencias += " and sm.fecha_movimiento< to_date('" + costoSiguiente.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        }

                        queryTransferencias += " and sm.fecha_movimiento>= to_date('" + costoActual.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        
                        queryTransferencias += " and  std.articulo_id =" + costoActual.ARTICULO_ID + " order by  sm.fecha_movimiento asc";
                        DataTable dttransferencias = sesion.db.EjecutarQuery(queryTransferencias);

                        if (dttransferencias.Rows.Count > 0)
                        {
                            for (int indiceTransfrencias = 0; indiceTransfrencias < dttransferencias.Rows.Count; indiceTransfrencias++)
                            {
                                decimal stDetalleId = decimal.Parse(dttransferencias.Rows[indiceTransfrencias]["detalle"].ToString());
                                decimal stCasoId = decimal.Parse(dttransferencias.Rows[indiceTransfrencias]["caso"].ToString());

                                transferenciaDetalleRow = new STOCK_TRANSFERENCIA_DETALLERow();
                                transferenciaDetalleRow = sesion.db.STOCK_TRANSFERENCIA_DETALLECollection.GetByPrimaryKey(stDetalleId);
                                transferenciaDetalleRow.MONTO_COSTO = costoActual.COSTO_PONDERADO;
                                transferenciaDetalleRow.COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                transferenciaDetalleRow.COTIZACION_MONEDA = costoActual.COTIZACION;
                                sesion.db.STOCK_TRANSFERENCIA_DETALLECollection.Update(transferenciaDetalleRow);

                                string clausulaHistoricaST = STOCK_MOVIMIENTOSCollection.CASO_IDColumnName + "=" + stCasoId + " and " + STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName + "=" + transferenciaDetalleRow.ARTICULO_ID;
                                STOCK_MOVIMIENTOSRow[] movimientoST = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulaHistoricaST + filtroFecha, string.Empty);
                                for (int movimientoSTIndice = 0; movimientoSTIndice < movimientoST.Length; movimientoSTIndice++)
                                {
                                    movimientoST[movimientoSTIndice].COSTO = costoActual.COSTO_PONDERADO;
                                    movimientoST[movimientoSTIndice].COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                    movimientoST[movimientoSTIndice].COSTO_COTIZACION_MONEDA = costoActual.COTIZACION;

                                    sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientoST[movimientoSTIndice]);
                                }
                            }
                        }

                        #endregion Actulización de Costos de Transferencia de Articulos

                        #region Actulización de Costos de Ajuste Stock
                        string queryAjustes = string.Empty;

                        queryAjustes = "select sa.caso_id as caso, sa.id, sad.id as detalle  ";
                        queryAjustes += " from stock_ajuste sa, stock_ajuste_detalle sad, stock_movimientos sm";
                        queryAjustes += " where sa.id = sad.stock_ajuste_id";
                        queryAjustes += " and sa.caso_id = sm.caso_id";
                        queryAjustes += " and sad.articulo_id = sm. articulo_id ";

                        if (indiceCostos < (costosRow.Length - 1))
                        {
                            queryAjustes += " and sm.fecha_movimiento< to_date('" + costoSiguiente.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        }

                        queryAjustes += " and sm.fecha_movimiento>= to_date('" + costoActual.FECHA_INSERCION + "','dd/MM/YYYY hh24:mi:ss')";
                        queryAjustes += " and  sad.articulo_id =" + costoActual.ARTICULO_ID + " order by  sm.fecha_movimiento asc";
                        DataTable dtAjustes = sesion.db.EjecutarQuery(queryAjustes);

                        if (dtAjustes.Rows.Count > 0)
                        {
                            for (int indiceAjustes = 0; indiceAjustes < dtAjustes.Rows.Count; indiceAjustes++)
                            {
                                decimal ajusteDetalleId = decimal.Parse(dtAjustes.Rows[indiceAjustes]["detalle"].ToString());
                                decimal ajusteCasoId = decimal.Parse(dtAjustes.Rows[indiceAjustes]["caso"].ToString());

                                ajusteDetallesRow = new STOCK_AJUSTE_DETALLERow();
                                ajusteDetallesRow = sesion.db.STOCK_AJUSTE_DETALLECollection.GetByPrimaryKey(ajusteDetalleId);
                                ajusteDetallesRow.COSTO_UNITARIO = costoActual.COSTO_PONDERADO;
                                ajusteDetallesRow.MONEDA_ID = costoActual.MONEDA_ID;
                                ajusteDetallesRow.COTIZACION = costoActual.COTIZACION;
                                sesion.db.STOCK_AJUSTE_DETALLECollection.Update(ajusteDetallesRow);

                                string clausulaHistoricaAS = STOCK_MOVIMIENTOSCollection.CASO_IDColumnName + "=" + ajusteCasoId + " and " + STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName + "=" + ajusteDetallesRow.ARTICULO_ID;
                                STOCK_MOVIMIENTOSRow[] movimientoAS = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulaHistoricaAS + filtroFecha, string.Empty);
                                for (int movimientoASIndice = 0; movimientoASIndice < movimientoAS.Length; movimientoASIndice++)
                                {
                                    movimientoAS[movimientoASIndice].COSTO = costoActual.COSTO_PONDERADO;
                                    movimientoAS[movimientoASIndice].COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                    movimientoAS[movimientoASIndice].COSTO_COTIZACION_MONEDA = costoActual.COTIZACION;

                                    sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientoAS[movimientoASIndice]);
                                }
                            }
                        }

                        #endregion Actulización de Costos de Ajuste Stock

                        #region Movimiento Propio
                        if (!costoActual.IsCASO_IDNull)
                        {
                            string clausulaHistoricaPropio = STOCK_MOVIMIENTOSCollection.CASO_IDColumnName + "=" + costoActual.CASO_ID + " and " + STOCK_MOVIMIENTOSCollection.ARTICULO_IDColumnName + "=" + costoActual.ARTICULO_ID;
                            STOCK_MOVIMIENTOSRow[] movimientoPropio = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(clausulaHistoricaPropio, string.Empty);
                            for (int movimientoPropioIndice = 0; movimientoPropioIndice < movimientoPropio.Length; movimientoPropioIndice++)
                            {
                                movimientoPropio[movimientoPropioIndice].COSTO = costoActual.COSTO;
                                movimientoPropio[movimientoPropioIndice].COSTO_MONEDA_ID = costoActual.MONEDA_ID;
                                movimientoPropio[movimientoPropioIndice].COSTO_COTIZACION_MONEDA = costoActual.COTIZACION;

                                sesion.db.STOCK_MOVIMIENTOSCollection.Update(movimientoPropio[movimientoPropioIndice]);
                            }
                        }
                        #endregion Movimiento Propio

                        #region Actualizacion Costo de Stock Historio a Fecha
                        //Stock Historico
                        string whereCostoHistorico = StockService.ArticuloId_NombreCol + " =" + costoActual.ARTICULO_ID;
                        whereCostoHistorico += " and FECHA_FORMATO_NUMERO >= (" + costoActual.FECHA_INSERCION.ToString(Definiciones.FechaFormatoISO) + ")";
                        if (indiceCostos < (costosRow.Length - 1))
                        {
                            whereCostoHistorico += " and FECHA_FORMATO_NUMERO < (" + costoSiguiente.FECHA_INSERCION.ToString(Definiciones.FechaFormatoISO) + ")";
                        }
                        STOCK_SUC_DEPOSITO_ART_FECHARow[] stockHistorico = sesion.db.STOCK_SUC_DEPOSITO_ART_FECHACollection.GetAsArray(whereCostoHistorico, string.Empty);

                        if (stockHistorico.Length > 0)
                        {
                            for (int n = 0; n < stockHistorico.Length; n++)
                            {
                                stockHistorico[n].COSTO_PONDERADO = costoActual.COSTO_PONDERADO;
                                stockHistorico[n].MONEDA_PONDERADA_ID = costoActual.MONEDA_ID;
                                stockHistorico[n].MONEDA_PONDERADA_COTIZACION = costoActual.COTIZACION;
                                sesion.db.STOCK_SUC_DEPOSITO_ART_FECHACollection.Update(stockHistorico[n]);

                            }
                        }
                        #endregion Actualizacion Costo de Stock Historio a Fecha



                        sesion.db.ARTICULOS_COSTOSCollection.Update(costoActual);
                    }
                }
            }
            catch (Exception exp)
            {

                throw exp;

            }

        }
        #endregion CorreccionCostos

        #region CorregirCostosGeneral
        public static void CorregirCostos(decimal articulo_id,bool corregir_todos)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOSRow articulo;
                ARTICULOSRow[] articulos;
                ARTICULOS_COSTOSRow[] costos;
                if (corregir_todos)
                {
                    articulos = sesion.db.ARTICULOSCollection.GetAsArray(string.Empty, ArticulosService.Id_NombreCol);

                    for (int i = 0; i < articulos.Length; i++)
                    {
                        costos = sesion.db.ARTICULOS_COSTOSCollection.GetAsArray(CostosService.ArticuloId_NombreCol + "=" + articulos[i].ID, CostosService.FechaInsercion_NombreCol);
                        if (costos.Length > 0)
                        {
                            RecalcularCostos(articulos[i].ID, costos[0].FECHA_INSERCION, sesion, true);
                        }

                    }
                }
                else
                {
                    articulo = sesion.db.ARTICULOSCollection.GetByPrimaryKey(articulo_id);
                    costos = sesion.db.ARTICULOS_COSTOSCollection.GetAsArray(CostosService.ArticuloId_NombreCol + "=" + articulo.ID, CostosService.FechaInsercion_NombreCol);
                    if (costos.Length > 0)
                    {
                        RecalcularCostos(articulo.ID, costos[0].FECHA_INSERCION, sesion, true);
                    }
                    
                }

                
            }
        }
        #endregion CorregirCostosGeneral

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_COSTOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "articulos_costo_info_completa"; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.IDColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return ARTICULOS_COSTO_ACTIVOCollection.LOTE_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return ARTICULOS_COSTO_ACTIVOCollection.ARTICULO_IDColumnName; ; }
        }
        public static string CantidadInicial_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.CANTIDAD_INICIALColumnName; }
        }
        public static string CantidadRestante_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.CANTIDAD_RESTANTEColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.CASO_IDColumnName; }
        }
        public static string Costo_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.COSTOColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return ARTICULOS_COSTO_ACTIVOCollection.COTIZACIONColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.FECHA_FINColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.MONEDA_IDColumnName; }
        }
        public static string AjusteManual_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.AJUSTE_MANUALColumnName; }
        }
        public static string FechaInsercion_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.FECHA_INSERCIONColumnName; }
        }
        public static string CantidadRestanteEnFechaInsercion_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.CANTIDAD_REST_FECHA_INSERCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ARTICULOS_COSTOSCollection.ESTADOColumnName; }
        }
        public static string MonedaNombre_NombreCol
        {
            get { return ARTICULOS_COSTO_ACTIVOCollection.MONEDAColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return ARTICULOS_COSTO_INFO_COMPLETACollection.FLUJO_IDColumnName; }
        }
        public static string FechaCaso_NombreCol
        {
            get { return ARTICULOS_COSTO_INFO_COMPLETACollection.FECHA_CREACIONColumnName; }
        }
        public static string Lote_NombreCol
        {
            get { return ARTICULOS_COSTO_INFO_COMPLETACollection.LOTEColumnName; }
        }
        public static string FlujoNombre_NombreCol
        {
            get { return ARTICULOS_COSTO_INFO_COMPLETACollection.FLUJOColumnName; }
        }
        public static string CostoPoderado_NombreCol
        {
            get { return ARTICULOS_COSTO_INFO_COMPLETACollection.COSTO_PONDERADOColumnName; }
        }
        public static string MonedaCadenaDecimales_NombreCol
        {
            get { return ARTICULOS_COSTO_INFO_COMPLETACollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string MonedaCantidadDecimales_NombreCol
        {
            get { return ARTICULOS_COSTO_INFO_COMPLETACollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }

        public static string MonedaSimbolo_NombreCol
        {
            get { return ARTICULOS_COSTO_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }

        #endregion Accessors

        #region GetCostoPorLoteEnFecha
        public static DataRow GetCostoPorArticuloEnFecha(decimal articulo_id, SessionService sesion, DateTime fecha)
        {
            string query = CostosService.ArticuloId_NombreCol + "=" + articulo_id;
            query += " and " + CostosService.FechaInsercion_NombreCol + " >= to_date('" + fecha.ToString() + "','dd/MM/yyyy HH24:MI:SS') ";
            //query += " and " + CostosService.FechaInsercion_NombreCol + " < to_date('" + fecha.ToString() + "','dd/MM/yyyy HH24:MI:SS') ";
            DataTable costos = sesion.db.ARTICULOS_COSTOSCollection.GetAsDataTable(query, CostosService.FechaInsercion_NombreCol);

            if (costos.Rows.Count > 0)
            {

                return costos.Rows[0];

            }
            else
                return null;

        }
        #endregion GetCostoPorLoteEnFecha
    }
}
