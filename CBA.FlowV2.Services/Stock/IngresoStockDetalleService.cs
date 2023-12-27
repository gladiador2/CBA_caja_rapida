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
using CBA.FlowV2.Services.Activos;
#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class IngresoStockDetalleService
    {
        #region GetIngresoStockDetalleDataTable
        /// <summary>
        /// Gets the ingreso stock detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetIngresoStockDetalleDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetIngresoStockDetalleDataTable(clausula, orden, sesion);
            }
        }

        public static DataTable GetIngresoStockDetalleDataTable(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.INGRESO_STOCK_DETALLESCollection.GetAsDataTable(clausula, orden);
        }
        #endregion GetIngresoStockDetalleDataTable

        #region GetIngresoStockDetalleInfoCompleta
        /// <summary>
        /// Gets the ingreso stock detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetIngresoStockDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetIngresoStockDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetIngresoStockDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.INGRESO_STOCK_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetIngresoStockDetalleInfoCompleta

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

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                DataTable dtIngreso = IngresoStockService.GetIngresoStockDataTable(IngresoStockService.Id_NombreCol + " = " + campos[IngresoStockDetalleService.IngresoStockId_NombreCol], string.Empty, sesion); 
                INGRESO_STOCK_DETALLESRow row = new INGRESO_STOCK_DETALLESRow();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ingreso_stock_detalles_sqc");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.CANTIDAD_ORIGINAL = decimal.Parse(campos[IngresoStockDetalleService.CantidadTotalOrigen_NombreCol].ToString());
                    row.MONEDA_ORIGINAL_ID = decimal.Parse(campos[IngresoStockDetalleService.MonedaId_NombreCol].ToString());

                    decimal impuesto = 0;
                    if (campos.Contains(IngresoStockDetalleService.CostoImpuestoPorc_NombreCol))
                    {
                        impuesto = (decimal)decimal.Parse(campos[IngresoStockDetalleService.CostoImpuestoPorc_NombreCol].ToString());
                    }

                    //Si se indico el impuesto del costo se calcula el costo neto sin dto original discriminando el impuesto
                    if (impuesto > 0)
                    {
                        row.COSTO_NETO_SIN_DTO_ORIGINAL = decimal.Parse(campos[IngresoStockDetalleService.Costo_NombreCol].ToString()) -
                                                        decimal.Parse(campos[IngresoStockDetalleService.Costo_NombreCol].ToString()) /
                                                        (1 + (100 / impuesto));
                    }
                    else
                    {
                        row.COSTO_NETO_SIN_DTO_ORIGINAL = decimal.Parse(campos[IngresoStockDetalleService.Costo_NombreCol].ToString());
                    }
                }
                else
                {
                    row = sesion.Db.INGRESO_STOCK_DETALLESCollection.GetRow(IngresoStockDetalleService.Id_NombreCol + " = " + campos[IngresoStockDetalleService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                row.LOTE_ID = decimal.Parse(campos[IngresoStockDetalleService.LoteId_NombreCol].ToString()); decimal articuloId = ArticulosLotesService.GetArticuloId2(row.LOTE_ID, sesion);
                row.CANTIDAD_TOTAL_ORIGEN = decimal.Parse(campos[IngresoStockDetalleService.CantidadTotalOrigen_NombreCol].ToString());
                row.UNIDAD_ID = campos[IngresoStockDetalleService.UnidadId_NombreCol].ToString();
                row.FACTOR_CONVERSION = ArticulosConversionesService.GetFactorConversion(articuloId, row.UNIDAD_ID, (decimal)dtIngreso.Rows[0][IngresoStockService.SucursalId_NombreCol], sesion);
                row.CANTIDAD_TOTAL_DESTINO = row.CANTIDAD_TOTAL_ORIGEN / row.FACTOR_CONVERSION;
                row.COSTO = decimal.Parse(campos[IngresoStockDetalleService.Costo_NombreCol].ToString());
                row.COSTO_IMPUESTO_PORC = decimal.Parse(campos[IngresoStockDetalleService.CostoImpuestoPorc_NombreCol].ToString());
                row.MONEDA_ID = decimal.Parse(campos[IngresoStockDetalleService.MonedaId_NombreCol].ToString());
                row.COTIZACION = decimal.Parse(campos[IngresoStockDetalleService.Cotizacion_NombreCol].ToString());

                if (campos.Contains(IngresoStockDetalleService.MonedaPaisCotizacion_NombreCol))
                {
                    row.MONEDA_PAIS_COTIZACION = (decimal)campos[IngresoStockDetalleService.MonedaPaisCotizacion_NombreCol];
                }
                else
                {
                    var sucursal = new SucursalesService((decimal)dtIngreso.Rows[0][IngresoStockService.SucursalId_NombreCol], sesion);
                    if (row.MONEDA_ID == sucursal.Pais.MonedaId)
                        row.MONEDA_PAIS_COTIZACION = row.COTIZACION;
                    else
                        row.MONEDA_PAIS_COTIZACION = CotizacionesService.GetCotizacionMonedaVenta(sucursal.PaisId, sucursal.Pais.MonedaId, (DateTime)dtIngreso.Rows[0][IngresoStockService.Fecha_NombreCol]);
                }

                row.INGRESO_STOCK_ID = decimal.Parse(campos[IngresoStockDetalleService.IngresoStockId_NombreCol].ToString());

                if (campos.Contains(IngresoStockDetalleService.ActivoId_NombreCol))
                {
                    row.ACTIVO_ID = decimal.Parse(campos[IngresoStockDetalleService.ActivoId_NombreCol].ToString());
                }
                else
                {
                    row.IsACTIVO_IDNull = true;
                }

                if (campos.Contains(IngresoStockDetalleService.PorcentajeProrrateoDetalle_NombreCol))
                {
                    row.PORCENTAJE_PRORRATEO_DETALLE = decimal.Parse(campos[IngresoStockDetalleService.PorcentajeProrrateoDetalle_NombreCol].ToString()); ;
                    row.MONTO_PRORRATEO_DETALLE = decimal.Parse(campos[IngresoStockDetalleService.MontoProrrateoDetalle_NombreCol].ToString()); ;
                    row.MONTO_PRORRATEADO = decimal.Parse(campos[IngresoStockDetalleService.MontoProrrateado_NombreCol].ToString()); ;
                }
                else
                {
                    row.PORCENTAJE_PRORRATEO_DETALLE = 0;
                    row.MONTO_PRORRATEO_DETALLE = 0;
                    row.MONTO_PRORRATEADO = row.COSTO;
                }

                if (insertarNuevo) sesion.Db.INGRESO_STOCK_DETALLESCollection.Insert(row);
                else sesion.Db.INGRESO_STOCK_DETALLESCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Modificar Detalle
        /// <summary>
        /// Modificar los detalles
        /// </summary>
        /// <param name="campos">Campos a ser modificados</param>
        public static void ModificarDetalle(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    decimal detalleId = (decimal)campos[IngresoStockDetalleService.Id_NombreCol];
                    var row = sesion.Db.INGRESO_STOCK_DETALLESCollection.GetByPrimaryKey(detalleId);
                    
                    var dtCabecera = IngresoStockService.GetIngresoStockInfoCompleta(IngresoStockService.Id_NombreCol + " = " + row.INGRESO_STOCK_ID, string.Empty, sesion);
                    var casoEstadoId = (string)dtCabecera.Rows[0][IngresoStockService.VistaCasoEstado_NombreCol];
                    if (casoEstadoId != Definiciones.EstadosFlujos.Borrador && casoEstadoId != Definiciones.EstadosFlujos.Pendiente)
                        throw new Exception("El detalle no puede modificarse estando el caso en " + casoEstadoId);
                    
                    string valorAnterior = row.ToString();
                    if (campos.Contains(IngresoStockDetalleService.CantidadTotalOrigen_NombreCol))
                    {
                        row.CANTIDAD_TOTAL_ORIGEN = (decimal)campos[IngresoStockDetalleService.CantidadTotalOrigen_NombreCol];
                        row.CANTIDAD_TOTAL_DESTINO = row.CANTIDAD_TOTAL_ORIGEN / row.FACTOR_CONVERSION;
                    }

                    if (campos.Contains(IngresoStockDetalleService.Costo_NombreCol))
                    {
                        row.COSTO = (decimal)campos[IngresoStockDetalleService.Costo_NombreCol];
                    }

                    if (campos.Contains(IngresoStockDetalleService.CostoImpuestoPorc_NombreCol))
                    {
                        row.COSTO_IMPUESTO_PORC = (decimal)campos[IngresoStockDetalleService.CostoImpuestoPorc_NombreCol];
                    }

                    if (campos.Contains(IngresoStockDetalleService.MonedaId_NombreCol))
                    {
                        row.MONEDA_ID = (decimal)campos[IngresoStockDetalleService.MonedaId_NombreCol];
                    }

                    if (campos.Contains(IngresoStockDetalleService.LoteId_NombreCol))
                    {
                        row.LOTE_ID = (decimal)campos[IngresoStockDetalleService.LoteId_NombreCol];
                    }

                    sesion.Db.INGRESO_STOCK_DETALLESCollection.Update(row);
                    string valorNuevo = row.ToString();
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }

        #endregion Modificar Detalle

        #region Actualizar Gastos
        public static void ActualizarGastos(decimal detalleId, decimal montoGastoTotal, decimal cantidad)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    INGRESO_STOCK_DETALLESRow row = new INGRESO_STOCK_DETALLESRow();
                    row = sesion.Db.INGRESO_STOCK_DETALLESCollection.GetByPrimaryKey(detalleId);
                    string valorAnterior = row.ToString();

                    row.GASTO_TOTAL_APLICADO = montoGastoTotal;

                    if (cantidad > 0)
                        row.GASTO_UNITARIO_APLICADO = montoGastoTotal / cantidad;

                    row.COSTO_PRORRATEADO = row.COSTO + row.GASTO_UNITARIO_APLICADO;
                    row.MONTO_TOTAL_PRORRATEADO = row.COSTO_PRORRATEADO * cantidad;

                    sesion.Db.INGRESO_STOCK_DETALLESCollection.Update(row);
                    string valorNuevo = row.ToString();
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Actualizar Gastos

        #region ActualizarDetalleDesde FC Aprobada
        public static decimal ActualizarDetalle(System.Collections.Hashtable campos, decimal caso_id, decimal lote_anterior, SessionService sesion)
        {
            try
            {
                DataTable dtIngreso = IngresoStockService.GetIngresoStockPorCasoStatic(caso_id);
                decimal ingresoId = decimal.Parse(dtIngreso.Rows[0][IngresoStockService.Id_NombreCol].ToString());

                INGRESO_STOCK_DETALLESRow row = new INGRESO_STOCK_DETALLESRow();

                string clausula = IngresoStockDetalleService.IngresoStockId_NombreCol + "=" + ingresoId + " and " + IngresoStockDetalleService.LoteId_NombreCol + "=" + lote_anterior;
                string valorAnterior = string.Empty;
                row = sesion.Db.INGRESO_STOCK_DETALLESCollection.GetRow(clausula);
                valorAnterior = row.ToString();

                row.CANTIDAD_ORIGINAL = decimal.Parse(campos[IngresoStockDetalleService.CantidadTotalOrigen_NombreCol].ToString());
                row.MONEDA_ORIGINAL_ID = decimal.Parse(campos[IngresoStockDetalleService.MonedaId_NombreCol].ToString());

                decimal impuesto = 0;
                if (campos.Contains(IngresoStockDetalleService.CostoImpuestoPorc_NombreCol))
                    impuesto = (decimal)decimal.Parse(campos[IngresoStockDetalleService.CostoImpuestoPorc_NombreCol].ToString());

                //Si se indico el impuesto del costo se calcula el costo neto sin dto original discriminando el impuesto
                if (impuesto > 0)
                {
                    row.COSTO_NETO_SIN_DTO_ORIGINAL = decimal.Parse(campos[IngresoStockDetalleService.Costo_NombreCol].ToString()) -
                                                    decimal.Parse(campos[IngresoStockDetalleService.Costo_NombreCol].ToString()) /
                                                    (1 + (100 / impuesto));
                }
                else
                {
                    row.COSTO_NETO_SIN_DTO_ORIGINAL = decimal.Parse(campos[IngresoStockDetalleService.Costo_NombreCol].ToString());
                }

                row.LOTE_ID = decimal.Parse(campos[IngresoStockDetalleService.LoteId_NombreCol].ToString()); decimal articuloId = (new ArticulosLotesService()).GetArticuloId(row.LOTE_ID);
                row.CANTIDAD_TOTAL_ORIGEN = decimal.Parse(campos[IngresoStockDetalleService.CantidadTotalOrigen_NombreCol].ToString());
                row.UNIDAD_ID = campos[IngresoStockDetalleService.UnidadId_NombreCol].ToString();
                row.FACTOR_CONVERSION = (new ArticulosConversionesService()).GetFactorConversion(articuloId, row.UNIDAD_ID, (decimal)dtIngreso.Rows[0][IngresoStockService.SucursalId_NombreCol]);
                row.CANTIDAD_TOTAL_DESTINO = row.CANTIDAD_TOTAL_ORIGEN / row.FACTOR_CONVERSION;
                row.COSTO = decimal.Parse(campos[IngresoStockDetalleService.Costo_NombreCol].ToString());
                row.COSTO_IMPUESTO_PORC = decimal.Parse(campos[IngresoStockDetalleService.CostoImpuestoPorc_NombreCol].ToString());
                row.MONEDA_ID = decimal.Parse(campos[IngresoStockDetalleService.MonedaId_NombreCol].ToString());
                row.COTIZACION = decimal.Parse(campos[IngresoStockDetalleService.Cotizacion_NombreCol].ToString());

                if (campos.Contains(IngresoStockDetalleService.MonedaPaisCotizacion_NombreCol))
                {
                    row.MONEDA_PAIS_COTIZACION = (decimal)campos[IngresoStockDetalleService.MonedaPaisCotizacion_NombreCol];
                }
                else
                {
                    var sucursal = new SucursalesService((decimal)dtIngreso.Rows[0][IngresoStockService.SucursalId_NombreCol], sesion);
                    if (row.MONEDA_ID == sucursal.Pais.MonedaId)
                        row.MONEDA_PAIS_COTIZACION = row.COTIZACION;
                    else
                        row.MONEDA_PAIS_COTIZACION = CotizacionesService.GetCotizacionMonedaVenta(sucursal.PaisId, sucursal.Pais.MonedaId, (DateTime)dtIngreso.Rows[0][IngresoStockService.Fecha_NombreCol]);
                }

                if (campos.Contains(IngresoStockDetalleService.ActivoId_NombreCol))
                    row.ACTIVO_ID = decimal.Parse(campos[IngresoStockDetalleService.ActivoId_NombreCol].ToString());
                else
                    row.IsACTIVO_IDNull = true;

                if (campos.Contains(IngresoStockDetalleService.PorcentajeProrrateoDetalle_NombreCol))
                {
                    row.PORCENTAJE_PRORRATEO_DETALLE = decimal.Parse(campos[IngresoStockDetalleService.PorcentajeProrrateoDetalle_NombreCol].ToString());
                    row.MONTO_PRORRATEO_DETALLE = decimal.Parse(campos[IngresoStockDetalleService.MontoProrrateoDetalle_NombreCol].ToString());
                    row.MONTO_PRORRATEADO = decimal.Parse(campos[IngresoStockDetalleService.MontoProrrateado_NombreCol].ToString());
                }
                else
                {
                    row.PORCENTAJE_PRORRATEO_DETALLE = 0;
                    row.MONTO_PRORRATEO_DETALLE = 0;
                    row.MONTO_PRORRATEADO = row.COSTO;
                }

                sesion.Db.INGRESO_STOCK_DETALLESCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion ActualizarDetalleDesde FC Aprobada

        #region BorrarTodos
        public static void BorrarTodos(decimal ingreso_stock_id, SessionService sesion)
        {
            DataTable dt = GetIngresoStockDetalleDataTable(IngresoStockDetalleService.IngresoStockId_NombreCol + " = " + ingreso_stock_id, string.Empty, sesion);
            for (int i = 0; i < dt.Rows.Count; i++)
                Borrar((decimal)dt.Rows[i][IngresoStockDetalleService.Id_NombreCol], sesion);
        }
        #endregion BorrarTodos

        #region Borrar
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Borrar(detalles_id, sesion);
                    sesion.Db.CommitTransaction();
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
            INGRESO_STOCK_DETALLESRow row = sesion.Db.INGRESO_STOCK_DETALLESCollection.GetByPrimaryKey(detalles_id);
            string valorAnterior = row.ToString();
            string valorNuevo = Definiciones.Log.RegistroBorrado;
            sesion.Db.INGRESO_STOCK_DETALLESCollection.DeleteByPrimaryKey(detalles_id);
            borrarLote(row.LOTE_ID, sesion);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
        }

        /*
         * Para borrar el lote del articulo, cuando
         * el articulo es trazable y
         * el lote no existe en ninguna factura proveedor
         */
        private static void borrarLote(decimal lote_id, SessionService sesion)
        {
            //preguntar si articulo es trazable
            if (ArticulosService.EsTrazable(ArticulosLotesService.GetArticuloId2(lote_id)))
            {
                //si es trazable, verificar que no sea detalle de FP
                if (!ArticulosLotesService.ExisteLoteEnDetalleFP(lote_id))
                {
                    //si el lote no existe en detalle de FP, entonces borrar lote
                    sesion.Db.ARTICULOS_LOTESCollection.DeleteByPrimaryKey(lote_id);
                }
            }
        }
        #endregion Borrar

        #region Accessors

        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "INGRESO_STOCK_DETALLES"; }
        }
        public static string ActivoId_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.ACTIVO_IDColumnName; }
        }
        public static string MontoTotalProrrateado_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.MONTO_TOTAL_PRORRATEADOColumnName; }
        }
        public static string CantidadTotalOrigen_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.CANTIDAD_TOTAL_ORIGENColumnName; }
        }
        public static string CantidadTotalDestino_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.CANTIDAD_TOTAL_DESTINOColumnName; }
        }
        public static string UnidadId_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.UNIDAD_IDColumnName; }
        }
        public static string FactorConversion_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.FACTOR_CONVERSIONColumnName; }
        }
        public static string Costo_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.COSTOColumnName; }
        }
        public static string CostoImpuestoPorc_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.COSTO_IMPUESTO_PORCColumnName; }
        }
        public static string CostoNetoSinDtoOriginal_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.COSTO_NETO_SIN_DTO_ORIGINALColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.COTIZACIONColumnName; }
        }
        public static string MonedaPaisCotizacion_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.MONEDA_PAIS_COTIZACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.IDColumnName; }
        }
        public static string IngresoStockId_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.INGRESO_STOCK_IDColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.LOTE_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.MONEDA_IDColumnName; }
        }
        public static string PorcentajeProrrateoDetalle_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.PORCENTAJE_PRORRATEO_DETALLEColumnName; }
        }
        public static string MontoProrrateoDetalle_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.MONTO_PRORRATEO_DETALLEColumnName; }
        }
        public static string MontoProrrateado_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.MONTO_PRORRATEADOColumnName; }
        }
        public static string MonedaOriginalId_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.MONEDA_ORIGINAL_IDColumnName; }
        }
        public static string CantidadOriginal_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.CANTIDAD_ORIGINALColumnName; }
        }
        public static string GastoUnitarioAplicado_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.GASTO_UNITARIO_APLICADOColumnName; }
        }
        public static string GastoTotalAplicadoAplicado_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.GASTO_TOTAL_APLICADOColumnName; }
        }
        public static string CostoProrrateado_NombreCol
        {
            get { return INGRESO_STOCK_DETALLESCollection.COSTO_PRORRATEADOColumnName; }
        }
        //public static string EsTrazable_NombreCol
        //{
        //    get { return INGRESO_STOCK_DETALLESCollection.ES_TRAZABLEColumnName; }
        //}
        #endregion Tablas

        #region Vista
        public static string Nombre_Vista
        {
            get { return "INGRESO_STOCK_DET_INFO_COMPL"; }
        }
        public static string VistaActivoCodigo_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.ACTIVO_CODIGOColumnName; }
        }
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.ARTICULO_CODIGOColumnName; }
        }

        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloId_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.ARTICULO_IDColumnName; }
        }
        public static string VistaLoteId_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.LOTE_IDColumnName; }
        }
        public static string VistaLote_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.LOTEColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.ARTICULO_GRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.ARTICULO_SUBGRUPO_IDColumnName; }
        }
        public static string VistaCostoTotal_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.COSTO_TOTALColumnName; }
        }
        public static string VistaCostoTotalProrrateado_NombreCol
        {
            get { return INGRESO_STOCK_DET_INFO_COMPLCollection.COSTO_TOTAL_PRORRATEADOColumnName; }
        }
        #endregion Vista

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static IngresoStockDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new IngresoStockDetalleService(e.RegistroId, sesion);
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
        protected INGRESO_STOCK_DETALLESRow row;
        protected INGRESO_STOCK_DETALLESRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? ActivoId { get { if (row.IsACTIVO_IDNull) return null; else return row.ACTIVO_ID; } set { if (value.HasValue) row.ACTIVO_ID = value.Value; else row.IsACTIVO_IDNull = true; } }
        public decimal? CantidadOriginal { get { if (row.IsCANTIDAD_ORIGINALNull) return null; else return row.CANTIDAD_ORIGINAL; } set { if (value.HasValue) row.CANTIDAD_ORIGINAL = value.Value; else row.IsCANTIDAD_ORIGINALNull = true; } }
        public decimal? CantidadTotalDestino { get { if (row.IsCANTIDAD_TOTAL_DESTINONull) return null; else return row.CANTIDAD_TOTAL_DESTINO; } set { if (value.HasValue) row.CANTIDAD_TOTAL_DESTINO = value.Value; else row.IsCANTIDAD_TOTAL_DESTINONull = true; } }
        public decimal CantidadTotalOrigen { get { return row.CANTIDAD_TOTAL_ORIGEN; } set { row.CANTIDAD_TOTAL_ORIGEN = value; } }
        public decimal Costo { get { return row.COSTO; } set { row.COSTO = value; } }
        public decimal CostoImpuestoPorc { get { return row.COSTO_IMPUESTO_PORC; } set { row.COSTO_IMPUESTO_PORC = value; } }
        public decimal? CostoSinDtoOriginal { get { if (row.IsCOSTO_NETO_SIN_DTO_ORIGINALNull) return null; else return row.COSTO_NETO_SIN_DTO_ORIGINAL; } set { if (value.HasValue) row.COSTO_NETO_SIN_DTO_ORIGINAL = value.Value; else row.IsCOSTO_NETO_SIN_DTO_ORIGINALNull = true; } }
        public decimal? CostoProrrateado { get { if (row.IsCOSTO_PRORRATEADONull) return null; else return row.COSTO_PRORRATEADO; } set { if (value.HasValue) row.COSTO_PRORRATEADO = value.Value; else row.IsCOSTO_PRORRATEADONull = true; } }
        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public decimal? FactorConversion { get { if (row.IsFACTOR_CONVERSIONNull) return null; else return row.FACTOR_CONVERSION; } set { if (value.HasValue) row.FACTOR_CONVERSION = value.Value; else row.IsFACTOR_CONVERSIONNull = true; } }
        public decimal? GastoTotalAplicacion { get { if (row.IsGASTO_TOTAL_APLICADONull) return null; else return row.GASTO_TOTAL_APLICADO; } set { if (value.HasValue) row.GASTO_TOTAL_APLICADO = value.Value; else row.IsGASTO_TOTAL_APLICADONull = true; } }
        public decimal? GastoUnitarioAplicado { get { if (row.IsGASTO_UNITARIO_APLICADONull) return null; else return row.GASTO_UNITARIO_APLICADO; } set { if (value.HasValue) row.GASTO_UNITARIO_APLICADO = value.Value; else row.IsGASTO_UNITARIO_APLICADONull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal IngresoStockId { get { return row.INGRESO_STOCK_ID; } set { row.INGRESO_STOCK_ID = value; } }
        public decimal? LoteId { get { if (row.IsLOTE_IDNull) return null; else return row.LOTE_ID; } set { if (value.HasValue) row.LOTE_ID = value.Value; else row.IsLOTE_IDNull = true; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal? MonedaOriginalId { get { if (row.IsMONEDA_ORIGINAL_IDNull) return null; else return row.MONEDA_ORIGINAL_ID; } set { if (value.HasValue) row.MONEDA_ORIGINAL_ID = value.Value; else row.IsMONEDA_ORIGINAL_IDNull = true; } }
        public decimal MonedaPaisCotizacion { get { return row.MONEDA_PAIS_COTIZACION; } set { row.MONEDA_PAIS_COTIZACION = value; } }
        public decimal? MontoProrrateado { get { if (row.IsMONTO_PRORRATEADONull) return null; else return row.MONTO_PRORRATEADO; } set { if (value.HasValue) row.MONTO_PRORRATEADO = value.Value; else row.IsMONTO_PRORRATEADONull = true; } }
        public decimal? MontoProrrateoDetalle { get { if (row.IsMONTO_PRORRATEO_DETALLENull) return null; else return row.MONTO_PRORRATEO_DETALLE; } set { if (value.HasValue) row.MONTO_PRORRATEO_DETALLE = value.Value; else row.IsMONTO_PRORRATEO_DETALLENull = true; } }
        public decimal? MontoTotalProrrateo { get { if (row.IsMONTO_TOTAL_PRORRATEADONull) return null; else return row.MONTO_TOTAL_PRORRATEADO; } set { if (value.HasValue) row.MONTO_TOTAL_PRORRATEADO = value.Value; else row.IsMONTO_TOTAL_PRORRATEADONull = true; } }
        public decimal? PorcentajeProrrateoDetalle { get { if (row.IsPORCENTAJE_PRORRATEO_DETALLENull) return null; else return row.PORCENTAJE_PRORRATEO_DETALLE; } set { if (value.HasValue) row.PORCENTAJE_PRORRATEO_DETALLE = value.Value; else row.IsPORCENTAJE_PRORRATEO_DETALLENull = true; } }
        public string UnidadId { get { return ClaseCBABase.GetStringHelper(row.UNIDAD_ID); } set { row.UNIDAD_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ActivosService _activo;
        public ActivosService Activo
        {
            get
            {
                if (this._activo == null)
                    this._activo = new ActivosService(this.ActivoId.Value);
                return this._activo;
            }
        }

        private IngresoStockService _ingreso_stock;
        public IngresoStockService IngresoStock
        {
            get
            {
                if (this._ingreso_stock == null)
                    this._ingreso_stock = new IngresoStockService(this.IngresoStockId);
                return this._ingreso_stock;
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
                    this._moneda = new MonedasService(this.MonedaId);
                return this._moneda;
            }
        }
        
        private UnidadesService _unidad;
        public UnidadesService Unidad
        {
            get
            {
                if (this._unidad == null)
                    this._unidad = new UnidadesService(this.UnidadId);
                return this._unidad;
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
                this.row = sesion.db.INGRESO_STOCK_DETALLESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new INGRESO_STOCK_DETALLESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(INGRESO_STOCK_DETALLESRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public IngresoStockDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public IngresoStockDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public IngresoStockDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private IngresoStockDetalleService(INGRESO_STOCK_DETALLESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static IngresoStockDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static IngresoStockDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.INGRESO_STOCK_DETALLESCollection.GetAsArray(IngresoStockDetalleService.IngresoStockId_NombreCol + " = " + cabecera_id, IngresoStockDetalleService.Id_NombreCol);
            IngresoStockDetalleService[] sad = new IngresoStockDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                sad[i] = new IngresoStockDetalleService(rows[i]);
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
            return GetStockMovimiento(this.IngresoStock.CasoId, sesion);
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
            this._activo = null;
            this._costo_ppp = null;
            this._ingreso_stock = null;
            this._lote = null;
            this._moneda = null;
            this._unidad = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
