#region Using
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
using CBA.FlowV2.Services.Tesoreria;
using System.Collections;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class FacturasClienteDetalleService
    {
        #region GetFacturaClienteDetalleRow

        /// <summary>
        /// Gets the factura cliente detalle row.
        /// </summary>
        /// <param name="factura_cliente_detalle_id">The factura_cliente_detalle_id.</param>
        /// <returns></returns>
        public DataRow GetFacturaClienteDetalleRow(Decimal factura_cliente_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetAsDataTable(FacturasClienteDetalleService.Id_NombreCol + " = " + factura_cliente_detalle_id, string.Empty);
                return table.Rows[0];
            }
        }

        #endregion GetFacturaClienteDetalleRow

        #region GetFacturaClienteDetalleDataTable
        /// <summary>
        /// Gets the factura cliente detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFacturaClienteDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturaClienteDetalleDataTable(clausulas, orden, sesion);
            }

        }
        public static DataTable GetFacturaClienteDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetAsDataTable(clausulas, orden);
        }

        #endregion GetFacturaClienteDetalleDataTable

        #region GetFacturaClienteDetalle
        /// <summary>
        /// Gets the factura cliente detalle info completa.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <returns></returns>
        public static DataTable GetFacturaClienteDetalleInfoCompletaStatic(decimal factura_cliente_id)
        {
            return GetFacturaClienteDetalleInfoCompletaStatic(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + factura_cliente_id, FacturasClienteDetalleService.Id_NombreCol);
        }

        /// <summary>
        /// Gets the factura cliente detalle information completa static.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFacturaClienteDetalleInfoCompletaStatic(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturaClienteDetalleInfoCompletaStatic(clausulas, orden, sesion);
            }
        }

        public static DataTable GetFacturaClienteDetalleInfoCompletaStatic(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FACTURAS_CLIENTE_DET_INF_COCollection.GetAsDataTable(clausulas, orden);
        }

        /// <summary>
        /// Gets the factura cliente detalle especifico.
        /// </summary>
        /// <param name="factura_cliente_detalle_id">The factura_cliente_detalle_id.</param>
        /// <returns></returns>
        public static DataTable GetFacturaClienteDetalleEspecifico2(Decimal factura_cliente_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FACTURAS_CLIENTE_DET_INF_COCollection.GetAsDataTable(FacturasClienteDetalleService.Id_NombreCol + " = " + factura_cliente_detalle_id, FacturasClienteDetalleService.Id_NombreCol);
            }

        }
        [Obsolete("Utilizar metodos estaticos")]
        public DataTable GetFacturaClienteDetalleEspecifico(Decimal factura_cliente_detalle_id)
        {
            return GetFacturaClienteDetalleEspecifico2(factura_cliente_detalle_id);
        }

        #endregion GetFacturaClienteDetalle

        #region ActualizarArticuloRecargoFinanciero
        /// <summary>
        /// Actualizars the articulo recargo financiero.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="total_recargo_financiero">The total_recargo_financiero.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarArticuloRecargoFinanciero(decimal factura_cliente_id, decimal caso_id, decimal total_recargo_financiero, SessionService sesion)
        {
            decimal articuloRecargoId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteArticuloPorRecargoFinanciero);
            string clausulas = ArticulosService.Id_NombreCol + " = " + articuloRecargoId;
            DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(factura_cliente_id, sesion);
            DataTable dtArticuloRecargo = ArticulosService.GetArticulos(clausulas, string.Empty, true, (decimal)dtFactura.Rows[0][FacturasClienteService.SucursalId_NombreCol]);
            DataTable dtArticuloRecargoLote = ArticulosLotesService.GetArticulosLotes(articuloRecargoId, ArticulosLotesService.Id_NombreCol + " desc ");
            DateTime fechaPrimerVencimiento, fechaSegundoVencimiento;
            bool usarFechaPrimerVencimiento, usarFechaSegundoVencimiento;

            //Se debe buscar entre los detalles de la factura los que tengan asociado el articulo por recargo
            clausulas = FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + factura_cliente_id + " and " + FacturasClienteDetalleService.ArticuloId_NombreCol + " = " + articuloRecargoId;
            DataTable dtDetalles = sesion.db.FACTURAS_CLIENTE_DETALLECollection.GetAsDataTable(clausulas, string.Empty);
            // corroboramos si existe un lote del articulo de recargo financiero, solamente si en el detalle existe articulos asociados a recargo financiero
            if (dtArticuloRecargoLote.Rows.Count <= 0 && dtDetalles.Rows.Count > 0)
                throw new Exception("No existe un lote para el artículo de recargo financiero.");

            //Si ya existia alguno creado, se borra
            foreach (DataRow dr in dtDetalles.Rows)
                FacturasClienteDetalleService.Borrar(decimal.Parse(dr[FacturasClienteDetalleService.Id_NombreCol].ToString()), caso_id, false, sesion);

            if (total_recargo_financiero > 0)
            {
                Hashtable campos = new Hashtable();
                campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, factura_cliente_id);
                campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articuloRecargoId);
                campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtArticuloRecargoLote.Rows[0][ArticulosLotesService.Id_NombreCol]);
                campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, dtArticuloRecargo.Rows[0][ArticulosService.UnidadMedidaId_NombreCol]);
                campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, dtArticuloRecargo.Rows[0][ArticulosService.ImpuestoId_NombreCol]);
                campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, total_recargo_financiero);
                campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, string.Empty);

                FacturasClienteDetalleService.Guardar(factura_cliente_id, campos, true, false, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, sesion);
            }
        }
        #endregion ActualizarArticuloRecargoFinanciero

        #region ActualizarCotizacion
        /// <summary>
        /// Actualizars the cotizacion.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="cotizacion">The cotizacion.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarCotizacion(decimal factura_cliente_id, decimal cotizacion, SessionService sesion)
        {
            try
            {
                //Obtener los detalles asociados a la factura
                string clausulas = FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + factura_cliente_id;
                FACTURAS_CLIENTE_DETALLERow[] rows = sesion.db.FACTURAS_CLIENTE_DETALLECollection.GetAsArray(clausulas, string.Empty);

                foreach (FACTURAS_CLIENTE_DETALLERow row in rows)
                {
                    row.COTIZACION_ORIGEN = cotizacion;
                    row.COTIZACION_MONEDA_LINEA_CRED = cotizacion;

                    sesion.Db.FACTURAS_CLIENTE_DETALLECollection.Update(row);
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException(exp.Message);
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException(exp.Message);
                    default: throw exp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ActualizarCotizacion(decimal factura_cliente_id, decimal cotizacion)
        {
            using (Services.Sesion.SessionService sesion = new CBA.FlowV2.Services.Sesion.SessionService())
            {
                ActualizarCotizacion(factura_cliente_id, cotizacion, sesion);
            }
        }
        #endregion ActualizarCotizacion

        #region SumarCantidadDevueltaNC
        /// <summary>
        /// Suma el campo cantidad a la columna CANTIDAD_DEVUELTA_NOTA_CREDITO
        /// y recalcula la columna TOTAL_NETO_LUEGO_DE_NC
        /// Solo debe ser llamada desde la nota de credito de personas
        /// </summary>
        /// <param name="fc_cliente_detalle_id">The fc_cliente_detalle_id.</param>
        /// <param name="cantidad">The cantidad.</param>
        /// <param name="sesion">The sesion.</param>
        public static void SumarCantidadDevueltaNC(decimal fc_cliente_detalle_id, decimal cantidad, SessionService sesion)
        {
            FACTURAS_CLIENTE_DETALLERow row = sesion.db.FACTURAS_CLIENTE_DETALLECollection.GetByPrimaryKey(fc_cliente_detalle_id);
            string valorAnterior = row.ToString();

            // al modificar la cantidad devuelta tambien se debe modificar el TOTAL_NETO_LUEGO_DE_NC

            // se obtienen los valores originales
            decimal cantidad_restante = row.CANTIDAD_UNITARIA_TOTAL_DEST - row.CANTIDAD_DEVUELTA_NOTA_CREDITO;
            decimal monto_restante = row.TOTAL_NETO_LUEGO_DE_NC;
            //calculamos el monto unitario
            if (row.TOTAL_NETO_LUEGO_DE_NC != 0)
            {// aun existe algo que se puede devolver, por lo tanto el monto unitario depende de este valor
                row.TOTAL_NETO_LUEGO_DE_NC -= (row.TOTAL_NETO_LUEGO_DE_NC / cantidad_restante) * cantidad;
            }
            else
            {//si es cero, o estamos eliminando el detalle de la nc o estamos tratanto de agregar un detalle no valido
                row.TOTAL_NETO_LUEGO_DE_NC -= (row.TOTAL_NETO_LUEGO_DE_NC_AUX / row.CANTIDAD_ANTERIOR_AUX) * cantidad;
            }
            // se modifican los valores 
            row.CANTIDAD_ANTERIOR_AUX = cantidad_restante;
            row.TOTAL_NETO_LUEGO_DE_NC_AUX = monto_restante;
            row.CANTIDAD_DEVUELTA_NOTA_CREDITO += cantidad;

            sesion.db.FACTURAS_CLIENTE_DETALLECollection.Update(row);
            LogCambiosService.LogDeRegistro(FacturasClienteDetalleService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion SumarCantidadDevueltaNC

        #region ActualizarTotalNetoLuegoDeNC
        /// <summary>
        /// Actualiza el total neto luego de nc. Solo debe ser llamado desde el service de FC Cliente al aplicar una NC
        /// </summary>
        /// <param name="fc_cliente_detalle_id">The fc_cliente_detalle_id.</param>
        /// <param name="total_neto_luego_de_nc">The total_neto_luego_de_nc.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarTotalNetoLuegoDeNC(decimal fc_cliente_detalle_id, decimal total_neto_luego_de_nc, SessionService sesion)
        {
            try
            {
                FACTURAS_CLIENTE_DETALLERow row = sesion.db.FACTURAS_CLIENTE_DETALLECollection.GetByPrimaryKey(fc_cliente_detalle_id);
                string valorAnterior = row.ToString();
                row.TOTAL_NETO_LUEGO_DE_NC = total_neto_luego_de_nc;
                sesion.db.FACTURAS_CLIENTE_DETALLECollection.Update(row);
                LogCambiosService.LogDeRegistro(FacturasClienteDetalleService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException(exp.Message);
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException(exp.Message);
                    default: throw exp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion ActualizarTotalNetoLuegoDeNC

        #region Guardar
       /* public static void Guardar(decimal factura_cliente_id, System.Collections.Hashtable campos, bool articulo_no_perteneciente_a_lista_de_precios, bool recalcular_totales_cabecera, out DateTime fecha_primer_vencimiento, out bool usar_fecha_primer_vencimiento, out DateTime fecha_segundo_vencimiento, out bool usar_fecha_segundo_vencimiento, bool verificar_disponibilidad)
        {
            using(SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar(factura_cliente_id, campos, articulo_no_perteneciente_a_lista_de_precios, recalcular_totales_cabecera, out fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento, verificar_disponibilidad, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        * */
        public static decimal Guardar(decimal factura_cliente_id, System.Collections.Hashtable campos, bool articulo_no_perteneciente_a_lista_de_precios, bool recalcular_totales_cabecera, out DateTime fecha_primer_vencimiento, out bool usar_fecha_primer_vencimiento, out DateTime fecha_segundo_vencimiento, out bool usar_fecha_segundo_vencimiento, bool verificar_disponibilidad)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                   decimal detalleid = Guardar(factura_cliente_id, campos, articulo_no_perteneciente_a_lista_de_precios, recalcular_totales_cabecera, out fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento, verificar_disponibilidad, sesion);
                    sesion.CommitTransaction();
                    return detalleid;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static decimal Guardar(decimal factura_cliente_id, System.Collections.Hashtable campos, bool articulo_no_perteneciente_a_lista_de_precios, bool recalcular_totales_cabecera, out DateTime fecha_primer_vencimiento, out bool usar_fecha_primer_vencimiento, out DateTime fecha_segundo_vencimiento, out bool usar_fecha_segundo_vencimiento, bool verificar_disponibilidad, SessionService sesion)
        {
            try
            {
                FACTURAS_CLIENTE_DETALLERow row = new FACTURAS_CLIENTE_DETALLERow();
                FACTURAS_CLIENTERow facturaRow;
                bool esNuevo = false;
                decimal precio, moneda_precio, cotizacion_precio;
                decimal listaPrecioUsadaId = Definiciones.Error.Valor.EnteroPositivo;
                RegimenComisionesService regimenComisiones = new RegimenComisionesService();
                VendedorClienteFamiliaService vendedorClienteFamilia = new VendedorClienteFamiliaService();
                decimal monto_original_descuento = 0, monto_original_recargo = 0;
                decimal cantidad_original = 0, porcentajeDescuento;
                decimal articuloRecargoFinanciero = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteArticuloPorRecargoFinanciero);

                string valorAnterior = String.Empty;
                string valorAnteriorFactura = String.Empty;
                bool esServicio;                

                //Se inicializa a una fecha cualquiera
                fecha_primer_vencimiento = DateTime.Now;
                fecha_segundo_vencimiento = DateTime.Now;
                usar_fecha_primer_vencimiento = false;
                usar_fecha_segundo_vencimiento = false;

                //El articulo debe tener ingreso aprobado
                if (!ArticulosService.IngresoAprobado(decimal.Parse(campos[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString())))
                {
                    throw new System.ArgumentException("El ingreso del artículo aún no está aprobado.");
                }

                esServicio = ArticulosService.EsServicio(decimal.Parse(campos[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString()));

                if (!campos.Contains(FacturasClienteDetalleService.Id_NombreCol))
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("facturas_cliente_detalle_sqc");
                    row.FACTURAS_CLIENTE_ID = decimal.Parse(campos[FacturasClienteDetalleService.FacturaClienteId_NombreCol].ToString());
                    row.TOTAL_NETO_LUEGO_DE_NC_AUX = Definiciones.Error.Valor.EnteroPositivo;
                    row.CANTIDAD_ANTERIOR_AUX = Definiciones.Error.Valor.EnteroPositivo;
                    esNuevo = true;
                }
                else
                {
                    row = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByPrimaryKey(decimal.Parse(campos[FacturasClienteDetalleService.Id_NombreCol].ToString()));
                    monto_original_descuento = row.TOTAL_MONTO_DTO;
                    monto_original_recargo = row.TOTAL_RECARGO_FINANCIERO;
                    valorAnterior = row.ToString();
                    cantidad_original = row.CANTIDAD_UNITARIA_TOTAL_ORIG;
                    row.CANTIDAD_ANTERIOR_AUX = row.CANTIDAD_UNITARIA_TOTAL_DEST - row.CANTIDAD_DEVUELTA_NOTA_CREDITO;
                    row.TOTAL_NETO_LUEGO_DE_NC_AUX = row.TOTAL_NETO_LUEGO_DE_NC;                   
                }
                if (campos.Contains(FacturasClienteDetalleService.ListaPreciosId_NombreCol))
                {
                    row.LISTA_PRECIO_ID = decimal.Parse(campos[FacturasClienteDetalleService.ListaPreciosId_NombreCol].ToString());
                }

                //Se obtiene la factura
                facturaRow = FacturasClienteService.GetFacturaCliente(row.FACTURAS_CLIENTE_ID, sesion);
                
                #region verificar cantidad de detalles segun autonumeracion
                if (!campos.Contains(FacturasClienteDetalleService.Id_NombreCol) && !facturaRow.IsAUTONUMERACION_IDNull)
                {
                    var dt = AutonumeracionesService.GetAutonumeracionesDataTable(AutonumeracionesService.Id_NombreCol + " = " + facturaRow.AUTONUMERACION_ID, string.Empty, sesion);
                    if (!Interprete.EsNullODBNull(dt.Rows[0][AutonumeracionesService.DetallesCantidadMaxima_NombreCol]))
                    {                            
                        var dtDetalles = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + factura_cliente_id, string.Empty, sesion);
                        if (dtDetalles.Rows.Count >= (decimal)dt.Rows[0][AutonumeracionesService.DetallesCantidadMaxima_NombreCol])
                            throw new Exception("Cantidad máxima de artículos superada.");
                    }
                }
                #endregion verificar cantidad de detalles segun autonumeracion

                valorAnteriorFactura = facturaRow.ToString();
                row.UNIDAD_DESTINO_ID = campos[FacturasClienteDetalleService.UnidadDestinoId_NombreCol].ToString();
                row.CANTIDAD_EMBALADA = decimal.Parse(campos[FacturasClienteDetalleService.CantidadEmbalada_NombreCol].ToString());
                row.CANTIDAD_UNIDAD_DESTINO = decimal.Parse(campos[FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol].ToString());
                row.OBSERVACION = (string)campos[FacturasClienteDetalleService.Observacion_NombreCol];

                //Se modifica la cantidad de las relaciones con las notas de pedido y remisiones, si las hubiera
                NotasDePedidoDetalleFacturaClienteRelacionesService.ModificarDetallePorIdFacturaCliente(row.ID, row.CANTIDAD_UNIDAD_DESTINO, sesion, false);
                RemisionesDetalleFacturaClienteRelacionesService.ModificarDetallePorIdFacturaCliente(row.ID, row.CANTIDAD_UNIDAD_DESTINO, sesion, false);

                row.ARTICULO_ID = decimal.Parse(campos[FacturasClienteDetalleService.ArticuloId_NombreCol].ToString());
                row.LOTE_ID = decimal.Parse(campos[FacturasClienteDetalleService.LoteId_NombreCol].ToString());
                //Validar que el lote pertenece al articulo
                if (row.ARTICULO_ID != ArticulosLotesService.GetArticuloId2(row.LOTE_ID, sesion))
                    throw new Exception("El lote no pertenece al artículo.");

                if (campos.Contains(FacturasClienteDetalleService.ArticuloDescripcion_NombreCol))
                    row.ARTICULO_DESCRIPCION = campos[FacturasClienteDetalleService.ArticuloDescripcion_NombreCol].ToString();

                if (campos.Contains(FacturasClienteDetalleService.CtacteRecargoId_NombreCol))
                {
                    if (!row.IsCTACTE_RECARGO_IDNull)
                        CuentaCorrienteRecargosService.Desvincular(row.CTACTE_RECARGO_ID, sesion);

                    row.CTACTE_RECARGO_ID = (decimal)campos[FacturasClienteDetalleService.CtacteRecargoId_NombreCol];
                    CuentaCorrienteRecargosService.Vincular(row.CTACTE_RECARGO_ID, facturaRow.CASO_ID, sesion);
                }

                row.FACTOR_CONVERSION = (new ArticulosConversionesService()).GetFactorConversion(row.ARTICULO_ID, row.UNIDAD_DESTINO_ID, facturaRow.SUCURSAL_ID);

                if (campos.Contains(FacturasClienteDetalleService.DepositoId_NombreCol))
                    row.DEPOSITO_ID = decimal.Parse(campos[FacturasClienteDetalleService.DepositoId_NombreCol].ToString());
                //se obtiene datos adicionales del articulo
                DataTable dtArticulos = ArticulosService.GetArticuloInfoCompletaPorID(row.ARTICULO_ID, facturaRow.SUCURSAL_ID, sesion);

                //La cantidad por caja se toma de la seccion del articulo
                row.CANTIDAD_POR_CAJA_ORIGEN = decimal.Parse(dtArticulos.Rows[0][ArticulosService.CantidadPorCaja_NombreCol].ToString());
                row.UNIDAD_ORIGEN_ID = dtArticulos.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();

                row.CANTIDAD_UNIDAD_ORIGEN = row.CANTIDAD_UNIDAD_DESTINO / row.FACTOR_CONVERSION;
                row.CANTIDAD_POR_CAJA_DESTINO = row.CANTIDAD_POR_CAJA_ORIGEN * row.FACTOR_CONVERSION;

                //La cantidad en unidades es la cantidad de cajas, por unidades que trae una caja
                //mas la cantidad que se pidio suelta
                row.CANTIDAD_UNITARIA_TOTAL_DEST = (row.CANTIDAD_EMBALADA * row.CANTIDAD_POR_CAJA_DESTINO) + row.CANTIDAD_UNIDAD_DESTINO;
                row.CANTIDAD_UNITARIA_TOTAL_ORIG = row.CANTIDAD_UNITARIA_TOTAL_DEST / row.FACTOR_CONVERSION;
                /*
                if (!ArticulosService.EsServicio(row.ARTICULO_ID))
                {
                    decimal cantidadDisponible = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, facturaRow.DEPOSITO_ID, sesion);
                    string verificarExistencia = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.VerificarExistenciaStockFacturaCliente);
                    if (verificarExistencia.Equals(Definiciones.SiNo.Si))
                    {
                        if (verificar_disponibilidad)
                        {
                            if (facturaRow.AFECTA_STOCK.Equals(Definiciones.SiNo.Si))
                            {
                                if (cantidadDisponible + cantidad_original < row.CANTIDAD_UNITARIA_TOTAL_ORIG)
                                {

                                    throw new Exception("Cantidad insuficiente");

                                }
                            }
                        }
                    }
                }*/




                if (row.ARTICULO_ID != articuloRecargoFinanciero)
                {
                    porcentajeDescuento = decimal.Parse(campos[FacturasClienteDetalleService.PorcentajeDescuento_NombreCol].ToString());

                    if (dtArticulos.Rows[0][ArticulosService.ControlarPrecio_NombreCol].Equals(Definiciones.SiNo.Si) && !RolesService.Tiene("fc cliente editar precio"))
                    {
                        //Se obtienen los datos del precio
                        /*precio = PreciosService.GetPrecioPorArticulo(facturaRow.PERSONA_ID,
                                                             row.ARTICULO_ID,
                                                             facturaRow.MONEDA_DESTINO_ID,
                                                             facturaRow.SUCURSAL_ID,
                                                             facturaRow.CASO_ID,
                                                             facturaRow.COTIZACION_DESTINO,
                                                             facturaRow.IsLISTA_PRECIO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : facturaRow.LISTA_PRECIO_ID,
                                                             facturaRow.CONDICION_PAGO_ID,
                                                             ref porcentajeDescuento,
                                                             out moneda_precio, 
                                                             out cotizacion_precio,
                                                             out fecha_primer_vencimiento,
                                                             out usar_fecha_primer_vencimiento,
                                                             out fecha_segundo_vencimiento,
                                                             out usar_fecha_segundo_vencimiento,
                                                             articulo_no_perteneciente_a_lista_de_precios,
                                                             true, row.CANTIDAD_UNITARIA_TOTAL_DEST, sesion);*/
                        precio = PreciosService_new.getPrecioArticuloDePersona(row.ARTICULO_ID, factura_cliente_id, facturaRow.SUCURSAL_ID, facturaRow.MONEDA_DESTINO_ID, row.CANTIDAD_UNITARIA_TOTAL_DEST, out porcentajeDescuento,out cotizacion_precio,out moneda_precio,ref listaPrecioUsadaId, DateTime.Now);
                        row.LISTA_PRECIO_ID = listaPrecioUsadaId;
                        
  
                        if (precio != 0)
                            campos[FacturasClienteDetalleService.MontoDescuento_NombreCol] = precio * porcentajeDescuento / 100;
                        else
                            campos[FacturasClienteDetalleService.MontoDescuento_NombreCol] = decimal.Parse(campos[FacturasClienteDetalleService.PrecioListaDestino_NombreCol].ToString()) * porcentajeDescuento / 100;
                    }
                    else
                    {
                        moneda_precio = facturaRow.MONEDA_DESTINO_ID;
                        cotizacion_precio = facturaRow.COTIZACION_DESTINO;
                        precio = row.PRECIO_LISTA_DESTINO;
                    }

                    row.PORCENTAJE_DTO = porcentajeDescuento;
                }
                else
                {
                    moneda_precio = facturaRow.MONEDA_DESTINO_ID;
                    cotizacion_precio = facturaRow.COTIZACION_DESTINO;
                    precio = row.PRECIO_LISTA_DESTINO;
                }

                //Se toma la moneda origen de la que se convirtio al tipo de moneda de la factura
                row.MONEDA_ORIGEN_ID = moneda_precio;
                row.COTIZACION_ORIGEN = cotizacion_precio;

                row.IMPUESTO_ID = decimal.Parse(campos[FacturasClienteDetalleService.ImpuestoId_NombreCol].ToString());
                row.PRECIO_LISTA_ORIGEN = precio;
                row.PRECIO_LISTA_DESTINO = decimal.Parse(campos[FacturasClienteDetalleService.PrecioListaDestino_NombreCol].ToString());

                if (row.PRECIO_LISTA_DESTINO == 0)
                    throw new Exception("El precio no puede ser cero.");

                if (campos.Contains(FacturasClienteDetalleService.VistaActivoId_NombreCol))
                {
                    if (campos[FacturasClienteDetalleService.VistaActivoId_NombreCol] != DBNull.Value)
                        row.ACTIVO_ID = decimal.Parse(campos[FacturasClienteDetalleService.VistaActivoId_NombreCol].ToString());
                    else
                        row.IsACTIVO_IDNull = true;
                }

                //Para evitar diferencias entre el porcentaje y valor de descuento
                //se calcula uno a partir del otro, privilegiando el valor
                row.MONTO_DESCUENTO = decimal.Parse(campos[FacturasClienteDetalleService.MontoDescuento_NombreCol].ToString());

                if (row.PRECIO_LISTA_DESTINO != 0)
                    row.PORCENTAJE_DTO = row.MONTO_DESCUENTO / row.PRECIO_LISTA_DESTINO * 100;
                else
                    row.PORCENTAJE_DTO = 0;

                #region calculos de totales

                //algunos articulos tienen estos campos cargados
                decimal cantMin = ArticulosService.GetCantMinima(row.ARTICULO_ID);
                decimal cantMax = ArticulosService.GetCantMaxima(row.ARTICULO_ID);
                if (cantMax == 0 && cantMax == 0)//si no tienen cargados estos campos procedemos normalmente
                {
                    //El monto bruto total es el precio bruto unitario por la cantidad de unidades
                    row.TOTAL_MONTO_BRUTO = row.PRECIO_LISTA_DESTINO * row.CANTIDAD_UNITARIA_TOTAL_DEST;

                    //El total ya con el descuento es el precio con descuento por la cantidad de unidades
                    row.TOTAL_MONTO_DTO = row.MONTO_DESCUENTO * row.CANTIDAD_UNITARIA_TOTAL_DEST;

                    
                }
                else //si tienen cargado estos campos cantida Min Max
                {
                    //verificamos que no se supere cargar el maximo
                    if (cantMax >= row.CANTIDAD_UNITARIA_TOTAL_DEST)
                    {
                        //El monto bruto total es el precio bruto unitario por la cantidad de unidades
                        //En este caso la cantidad para multiplcar es la cantidad minima
                        row.TOTAL_MONTO_BRUTO = row.PRECIO_LISTA_DESTINO * cantMin;

                        //El total ya con el descuento es el precio con descuento por la cantidad de unidades
                        row.TOTAL_MONTO_DTO = row.MONTO_DESCUENTO * cantMin;
                    }
                    else // si se supera la cantidad maxima
                    {
                        if (campos.Contains(FacturasClienteDetalleService.Id_NombreCol))//si es un detalle existente eliminarlo 
                        {
                            sesion.Db.FACTURAS_CLIENTE_DETALLECollection.Delete(row);
                            LogCambiosService.LogDeRegistro(FacturasClienteDetalleService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                        }
                             throw new Exception("El artículo supero la cantidad máxima");
                        
                    }
                }


                
                //Si la operacion no es contado
                if (facturaRow.TIPO_FACTURA_ID == Definiciones.TipoFactura.Credito)
                {
                    #region Calcular recargo financiero
                    //Si el articulo tiene recargo financiero guardar el monto
                    if ((string)dtArticulos.Rows[0][ArticulosService.RecargoFinanciero_NombreCol] == Definiciones.SiNo.Si)
                    {
                        //Monto neto por recargo mensual por cantidad de pagos
                        // neto - neto / (1 + recargo * meses)
                        row.TOTAL_RECARGO_FINANCIERO = row.TOTAL_MONTO_BRUTO - row.TOTAL_MONTO_BRUTO /
                                                       (1 + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClientePorcentajeRecargoFinanciero) / 100 * CondicionesPagoService.GetCantidadPagos(facturaRow.CONDICION_PAGO_ID));
                    }
                    #endregion Calcular recargo financiero
                }
                row.TOTAL_RECARGO_FINANCIERO = 0;
                //El monto neto es el monto bruto menos el monto de descuento menos el recargo financiero.
                //El monto neto contiene el impuesto
                row.TOTAL_NETO = row.TOTAL_MONTO_BRUTO - row.TOTAL_MONTO_DTO - row.TOTAL_RECARGO_FINANCIERO;
                // inicialmente el total neto luego de la aplicacion de notas de credito es igual al total neto, esto cambia a medida que se 
                // devuelven los artiuculos o se aplican notas de credito a la factura
                row.TOTAL_NETO_LUEGO_DE_NC = row.TOTAL_NETO;

                decimal porcentajeImpuesto = ImpuestosService.GetPorcentajePorId(row.IMPUESTO_ID);
                row.PORCENTAJE_IMPUESTO = porcentajeImpuesto;
                if (porcentajeImpuesto == 0) row.TOTAL_MONTO_IMPUESTO = 0;
                else row.TOTAL_MONTO_IMPUESTO = row.TOTAL_NETO / ((100 / porcentajeImpuesto) + 1);

                #endregion calculos de totales

                if (campos.Contains(FacturasClienteDetalleService.VendedorComisionistaId_NombreCol))
                {
                    row.VENDEDOR_COMISIONISTA_ID = decimal.Parse(campos[FacturasClienteDetalleService.VendedorComisionistaId_NombreCol].ToString());
                }
                else
                {
                    decimal familia_id = (decimal)dtArticulos.Rows[0][ArticulosService.FamiliaId_NombreCol];
                    decimal cliente_id = facturaRow.PERSONA_ID;
                    decimal vendedor_id = vendedorClienteFamilia.GetVendedor(cliente_id, familia_id);
                    if (vendedor_id == Definiciones.Error.Valor.EnteroPositivo)
                    {
                        if (facturaRow.IsVENDEDOR_IDNull)
                            row.IsVENDEDOR_COMISIONISTA_IDNull = true;
                        else
                            row.VENDEDOR_COMISIONISTA_ID = facturaRow.VENDEDOR_ID;
                    }
                    else
                    {
                        row.VENDEDOR_COMISIONISTA_ID = vendedor_id;
                    }
                }

                row.PORCENTAJE_COMISION_VEN = regimenComisiones.ObtenerPorcentaje(row.ARTICULO_ID,
                                                                                  DateTime.Now,
                                                                                  row.IsVENDEDOR_COMISIONISTA_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.VENDEDOR_COMISIONISTA_ID,
                                                                                  facturaRow.PERSONA_ID,
                                                                                  facturaRow.IsLISTA_PRECIO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : facturaRow.LISTA_PRECIO_ID,
                                                                                  row.CANTIDAD_EMBALADA,
                                                                                  row.PORCENTAJE_DTO,
                                                                                  articulo_no_perteneciente_a_lista_de_precios);
                if (row.PORCENTAJE_COMISION_VEN == Definiciones.Error.Valor.EnteroPositivo)
                {
                    row.PORCENTAJE_COMISION_VEN = 0;
                    row.MONTO_COMISION_VEN = 0;
                }
                else
                {
                    row.MONTO_COMISION_VEN = (row.PORCENTAJE_COMISION_VEN * (row.TOTAL_NETO - row.TOTAL_MONTO_IMPUESTO)) / 100;
                }

                //TODO Uri: columnas pendientes de ser borradas
                var costoPPP = CostosService.GetCosto(row.ARTICULO_ID, facturaRow.DEPOSITO_ID, facturaRow.FECHA, sesion);
                row.IsCOSTO_IDNull = true;
                row.COSTO_MONTO = costoPPP.costo;
                row.COSTO_MONEDA_ID = costoPPP.moneda_id;
                row.COSTO_MONEDA_COTIZACION = costoPPP.cotizacion;
                
                if (campos.Contains(FacturasClienteDetalleService.CasoAsociadoId_NombreCol))
                {

                    row.CASO_ASOCIADO_ID = decimal.Parse(campos[FacturasClienteDetalleService.CasoAsociadoId_NombreCol].ToString());

                    if (!CasosService.ExisteCaso(row.CASO_ASOCIADO_ID))
                        throw new Exception("No exite el caso que se desea asociar al Detalle");
                }

                #region linea de credito
                decimal factor;
                decimal variacion_afecta_linea;
                PERSONASRow personaRow = sesion.Db.PERSONASCollection.GetByPrimaryKey(facturaRow.PERSONA_ID);
                decimal cotizacionLineaCredito = CotizacionesService.GetCotizacionMonedaVenta(personaRow.MONEDA_LIMITE_CREDITO_ID, facturaRow.FECHA);

                //Si es un detalle nuevo, se almacena la cotizacion de la moneda de la linea de credito
                if (row.IsCOTIZACION_MONEDA_LINEA_CREDNull) row.COTIZACION_MONEDA_LINEA_CRED = cotizacionLineaCredito;

                //Si el caso no esta en estado borrador, entonces debe afectarse la linea de credito
                if (CasosService.GetEstadoCaso(facturaRow.CASO_ID, sesion) != Definiciones.EstadosFlujos.Borrador)
                {
                    //Si el caso afecta a la linea de credito
                    if (facturaRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si)
                    {
                        if (personaRow.MONEDA_LIMITE_CREDITO_ID == facturaRow.MONEDA_DESTINO_ID)
                        {
                            factor = 1;
                        }
                        else
                        {
                            // El factor es la division entre la cotizacion de la moneda en que se encuentra la
                            //linea de credito, y la cotizacion utilizada en la NP
                            factor = cotizacionLineaCredito / facturaRow.COTIZACION_DESTINO;
                        }

                        variacion_afecta_linea = (row.TOTAL_MONTO_DTO + row.TOTAL_RECARGO_FINANCIERO - monto_original_descuento - monto_original_recargo) * factor;

                        //Se actualiza en la cabecera el monto que afecta a la linea de credito
                        //en la moneda de la linea de credito
                        facturaRow.MONTO_AFECTA_LINEA_CREDITO += variacion_afecta_linea;

                        //Se actualiza la linea de credito
                        personaRow.CONTADOR_CREDITO_ACTUAL += variacion_afecta_linea;

                        //Se redondea a 10 decimales
                        facturaRow.MONTO_AFECTA_LINEA_CREDITO = Interprete.Redondear(facturaRow.MONTO_AFECTA_LINEA_CREDITO, 10);
                        personaRow.CONTADOR_CREDITO_ACTUAL = Interprete.Redondear(personaRow.CONTADOR_CREDITO_ACTUAL, 10);

                        //Se actualiza la cotizacino de la moneda de la linea de credito, en el detalle
                        row.COTIZACION_MONEDA_LINEA_CRED = cotizacionLineaCredito;

                        //obtener la linea de credito
                        PersonasLineaCreditoService personasLineaCredito = new PersonasLineaCreditoService();
                        DataRow lineaCredito = personasLineaCredito.GetPersonasLineaCredito(personaRow.ID, sesion);
                        decimal lineaCreditoMonto = (decimal)lineaCredito[PersonasLineaCreditoService.MontoLineaCredito_NombreCol];

                        if (lineaCreditoMonto - CuentaCorrientePersonasService.GetSaldoPersonaEnDolares(personaRow.ID, sesion) < facturaRow.TOTAL_NETO)
                            throw new System.ArgumentException("La persona no cuenta con suficiente saldo en su línea de crédito.");

                        //Se guardan las modificaciones a personas y facturas_cliente
                        sesion.Db.PERSONASCollection.Update(personaRow);
                        sesion.Db.FACTURAS_CLIENTECollection.Update(facturaRow);
                        // Esto me dijeronq que hay que realizar cada vez que se llama a un servicio --Galileo
                        LogCambiosService.LogDeRegistro(FacturasClienteService.Nombre_Tabla, facturaRow.ID, valorAnteriorFactura, facturaRow.ToString(), sesion);
                    }
                }
                #endregion linea de credito

                #region afectar stock
                //Si es una insercion cantidad_original es cero, si es una modificacion
                //se modifica solo la diferencia entre la cantidad actual y la anterior
                if (row.IsDEPOSITO_IDNull)
                {
                    StockService.modificarStock(facturaRow.DEPOSITO_ID,
                                                 row.ARTICULO_ID,
                                                 Interprete.Redondear(row.CANTIDAD_UNITARIA_TOTAL_ORIG - cantidad_original, 2),
                                                 Definiciones.Stock.TipoMovimiento.Venta, facturaRow.CASO_ID, row.LOTE_ID, string.Empty,
                                                 sesion, null, row.IMPUESTO_ID, row.ID);
                }
                else
                {
                    StockService.modificarStock(row.DEPOSITO_ID,
                                                 row.ARTICULO_ID,
                                                 Interprete.Redondear(row.CANTIDAD_UNITARIA_TOTAL_ORIG - cantidad_original, 2),
                                                 Definiciones.Stock.TipoMovimiento.Venta, facturaRow.CASO_ID, row.LOTE_ID, string.Empty,
                                                 sesion, null, row.IMPUESTO_ID, row.ID);
 
                }
                #endregion afectar stock

                if (!campos.Contains(FacturasClienteDetalleService.Id_NombreCol))
                    sesion.Db.FACTURAS_CLIENTE_DETALLECollection.Insert(row);
                else
                    sesion.Db.FACTURAS_CLIENTE_DETALLECollection.Update(row);
                LogCambiosService.LogDeRegistro(FacturasClienteDetalleService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                if (recalcular_totales_cabecera)
                    FacturasClienteService.RecalcularTotales(factura_cliente_id, fecha_primer_vencimiento, usar_fecha_primer_vencimiento, fecha_segundo_vencimiento, usar_fecha_segundo_vencimiento, sesion);

                return row.ID;
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException(exp.Message);
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException(exp.Message);
                    default: throw exp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal factura_cliente_detalle_id, decimal caso_id, SessionService sesion)
        {
            FacturasClienteDetalleService.Borrar(factura_cliente_detalle_id, caso_id, true, sesion);
        }

        public static void Borrar(decimal factura_cliente_detalle_id, decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(factura_cliente_detalle_id, caso_id, sesion);
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
        /// Borrars the specified factura_cliente_detalle_id.
        /// </summary>
        /// <param name="factura_cliente_detalle_id">The factura_cliente_detalle_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        public static void Borrar(decimal factura_cliente_detalle_id, decimal caso_id, bool recalcular_totales_cabecera, SessionService sesion)
        {
            try
            {
                #region Validar Estados
                string flujoId = string.Empty;
                string estadoId = string.Empty;

                CasosService.GetFlujoYEstado(caso_id, ref flujoId, ref estadoId);

                if (estadoId.Equals(Definiciones.EstadosFlujos.Pendiente) && !RolesService.Tiene("FC CLIENTE EDITAR DETALLES EN PENDIENTE"))
                    throw new Exception("No pueden eliminarse detalles en Pendiente. Favor actualizar el caso.");
                if (estadoId.Equals(Definiciones.EstadosFlujos.Caja))
                    throw new Exception("No pueden eliminarse detalles en Caja. Favor actualizar el caso.");
                #endregion Validar Estados

                FACTURAS_CLIENTE_DETALLERow row = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByPrimaryKey(factura_cliente_detalle_id);
                FACTURAS_CLIENTERow facturaRow = sesion.Db.FACTURAS_CLIENTECollection.GetByPrimaryKey(row.FACTURAS_CLIENTE_ID);
                PERSONASRow personaRow = sesion.Db.PERSONASCollection.GetByPrimaryKey(facturaRow.PERSONA_ID);

                if (!facturaRow.IsCASO_ORIGEN_IDNull)
                {
                    if (CasosService.GetFlujo(facturaRow.CASO_ORIGEN_ID, sesion) == Definiciones.FlujosIDs.PEDIDO_DE_CLIENTE && !RolesService.Tiene("FC CLIENTE PUEDE EDITAR FACTURA CON NOTA DE PEDIDO"))
                        throw new Exception("La factura tiene el caso asociado " + facturaRow.CASO_ORIGEN_ID + ", si desea editar el pedido, debe anular la factura.");
                }
                //Si el caso no esta en estado borrador
                if (CasosService.GetEstadoCaso(facturaRow.CASO_ID, sesion) != Definiciones.EstadosFlujos.Borrador)
                {
                    //Si el caso afecta a la linea de credito
                    if (facturaRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si)
                    {
                        string valorAnteriorFactura = facturaRow.ToString();
                        //Se modifica el saldo de la linea de credito en la moneda de la linea
                        personaRow.CONTADOR_CREDITO_ACTUAL -= row.TOTAL_MONTO_DTO / facturaRow.COTIZACION_DESTINO * row.COTIZACION_MONEDA_LINEA_CRED;
                        facturaRow.MONTO_AFECTA_LINEA_CREDITO -= row.TOTAL_MONTO_DTO / facturaRow.COTIZACION_DESTINO * row.COTIZACION_MONEDA_LINEA_CRED;

                        //Se redondea a 10 decimales
                        personaRow.CONTADOR_CREDITO_ACTUAL = Interprete.Redondear(personaRow.CONTADOR_CREDITO_ACTUAL, 10);
                        facturaRow.MONTO_AFECTA_LINEA_CREDITO = Interprete.Redondear(facturaRow.MONTO_AFECTA_LINEA_CREDITO, 10);

                        //Se guardan las modificaciones a personas y facturas_cliente
                        sesion.Db.PERSONASCollection.Update(personaRow);
                        sesion.db.FACTURAS_CLIENTECollection.Update(facturaRow);
                        LogCambiosService.LogDeRegistro(FacturasClienteService.Nombre_Tabla, facturaRow.ID, valorAnteriorFactura, facturaRow.ToString(), sesion);
                    }
                }

                StockService.modificarStock(facturaRow.DEPOSITO_ID, row.ARTICULO_ID, Interprete.Redondear(-row.CANTIDAD_UNITARIA_TOTAL_ORIG, 0), Definiciones.Stock.TipoMovimiento.Venta, caso_id, row.LOTE_ID, string.Empty, sesion, null, row.IMPUESTO_ID, row.ID);

                //Se hace nuevamente disponible el recargo para ser incluido en otra factura
                if (!row.IsCTACTE_RECARGO_IDNull)
                    CuentaCorrienteRecargosService.Desvincular(row.CTACTE_RECARGO_ID, sesion);

                //Se borra la distribucion de centros de costo por detalle
                DataTable dtCentrosCosto = FacturasClienteDetalleCentrosCostoService.GetDataTable(FacturasClienteDetalleCentrosCostoService.FacturaClienteDetalleId_NombreCol + " = " + row.ID, string.Empty, sesion);
                for (int i = 0; i < dtCentrosCosto.Rows.Count; i++)
                    FacturasClienteDetalleCentrosCostoService.Borrar((decimal)dtCentrosCosto.Rows[i][FacturasClienteDetalleCentrosCostoService.Id_NombreCol], sesion);

                //Se borra las relaciones si existen  
                //antes se pone las notas de pedido a preparado si las hubiera
                decimal auxNotaPedidoDetalle = NotasDePedidoDetalleFacturaClienteRelacionesService.GetPedidosClienteDetalleIdPorFacturaDetalleId(row.ID);
                if (auxNotaPedidoDetalle != Definiciones.Error.Valor.EnteroPositivo)
                {
                    decimal auxNotaPedido = NotasDePedidoDetalleService.GetNotaDePedidoIdPorId(auxNotaPedidoDetalle);
                    NotasDePedidosService NotasDePedido = new NotasDePedidosService();
                    decimal auxCasoId = NotasDePedidosService.GetCasoIdPorId(auxNotaPedido);
                    if (CasosService.GetEstadoCaso(auxCasoId) == Definiciones.EstadosFlujos.Aprobado)
                        NotasDePedido.CambiarAPreparado(auxCasoId);

                    NotasDePedidoDetalleFacturaClienteRelacionesService.BorrarPorFCCliente(row.ID, sesion);
                }              
                RemisionesDetalleFacturaClienteRelacionesService.BorrarPorFCCliente(row.ID, sesion);

                sesion.Db.FACTURAS_CLIENTE_DETALLECollection.Delete(row);
                LogCambiosService.LogDeRegistro(FacturasClienteDetalleService.Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                //Se deben actualizar los totales en la cabecera del caso
                FacturasClienteService facturacionCliente = new FacturasClienteService();                

                if (recalcular_totales_cabecera)
                    FacturasClienteService.RecalcularTotales(facturaRow.ID, DateTime.Now, false, DateTime.MinValue, false, sesion);
             
                //Revertir todo el proceso si el articulo es un combo representativo
                if (ArticulosService.EsComboRepresentativo(row.ARTICULO_ID))
                    ArticulosCombosStockService.DesconsolidarCombo(row.CANTIDAD_UNITARIA_TOTAL_DEST, row.LOTE_ID, facturaRow.DEPOSITO_ID, facturaRow.CASO_ID, sesion, string.Empty);               
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException(exp.Message);
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException(exp.Message);
                    default: throw exp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion Borrar

        public bool ControlesAgregarDetalle(decimal caso_id, SessionService sesion, out string mensaje )
        {
            CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
            FACTURAS_CLIENTERow cabeceraRow = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
            FACTURAS_CLIENTE_DETALLERow[] detalleRows = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByFACTURAS_CLIENTE_ID(cabeceraRow.ID);
            bool exito = true;
            mensaje = string.Empty;
            try
            {
                #region Controla que los articulos tengan codigo de empresa
                if (exito)
                {
                    foreach (FACTURAS_CLIENTE_DETALLERow d in detalleRows)
                    {
                        ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(d.ARTICULO_ID);
                        //no pueden facturarse articulos sin codigo interno (de la Empresa)
                        if (articulo.CODIGO_EMPRESA == null)
                        {
                            exito = false;
                            mensaje = "El artículo con descripción '" + articulo.DESCRIPCION_INTERNA + "' no tiene definido el código interno. \nArtículos sin código interno no pueden ser facturados.";
                            break;
                        }
                    }
                }
                #endregion Controla que los articulos tengan codigo de empresa
         
                #region Control de familia exclusiva
                if (exito)
                {
                    ARTICULOS_FAMILIASRow familiaExclusiva = null;
                    foreach (FACTURAS_CLIENTE_DETALLERow d in detalleRows)
                    {
                        ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(d.ARTICULO_ID);
                        ARTICULOS_FAMILIASRow familia = sesion.Db.ARTICULOS_FAMILIASCollection.GetByPrimaryKey(articulo.FAMILIA_ID);
                        if (familia.EXCLUSIVO == Definiciones.SiNo.Si)
                        {
                            familiaExclusiva = familia;
                            break;
                        }
                    }
                    if (familiaExclusiva != null)
                    {
                        foreach (FACTURAS_CLIENTE_DETALLERow d in detalleRows)
                        {
                            ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(d.ARTICULO_ID);
                            ARTICULOS_FAMILIASRow familia = sesion.Db.ARTICULOS_FAMILIASCollection.GetByPrimaryKey(articulo.FAMILIA_ID);
                            if (familia.ID != familiaExclusiva.ID)
                            {
                                mensaje = string.Format("La familia {0} es exclusiva y se agregaron artículos de la familia {1}",
                                    familiaExclusiva.NOMBRE,
                                    familia.NOMBRE);
                                exito = false;
                                break;
                            }
                        }
                    }
                }
                #endregion Control de familia exclusiva
                
                return exito;
            }
            catch (Exception exp)
            {
                exito = false;
                throw exp;
            }
        }

        #region Accesors

        public static string Nombre_Tabla
        {
            get { return "FACTURAS_CLIENTE_DETALLE"; }
        }
        public static string Nombre_vista
        {
            get { return "FACTURAS_CLIENTE_DET_INF_CO"; }
        }
        public static string ArticuloCodigoBarras_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.ARTICULO_CODIGO_BARRASColumnName; }
        }
        public static string CostoMonedaId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.COSTO_MONEDA_IDColumnName; }
        }
        public static string ActivoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.ACTIVO_IDColumnName; }
        }
        public static string ArticuloCodigo_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.ARTICULO_CODIGOColumnName; }
        }
        public static string ArticuloDescripcion_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.ARTICULO_IDColumnName; }
        }
        public static string CantidadDevueltaNotaCredito_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CANTIDAD_DEVUELTA_NOTA_CREDITOColumnName; }
        }
        public static string CantidadEmbalada_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CANTIDAD_EMBALADAColumnName; }
        }
        public static string CantidadPorCajaDestino_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CANTIDAD_POR_CAJA_DESTINOColumnName; }
        }
        public static string CantidadPorCajaOrigen_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CANTIDAD_POR_CAJA_ORIGENColumnName; }
        }
        public static string CantidadUnidadDestino_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CANTIDAD_UNIDAD_DESTINOColumnName; }
        }
        public static string CantidadUnidadOrigen_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CANTIDAD_UNIDAD_ORIGENColumnName; }
        }
        public static string CantidadUnitariaTotalDest_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CANTIDAD_UNITARIA_TOTAL_DESTColumnName; }
        }
        public static string CantidadUnitariaTotalOrig_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CANTIDAD_UNITARIA_TOTAL_ORIGColumnName; }
        }
        public static string CostoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.COSTO_IDColumnName; }
        }
        public static string CostoMonto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.COSTO_MONTOColumnName; }
        }
        public static string CotizacionMonedaLineaCred_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.COTIZACION_MONEDA_LINEA_CREDColumnName; }
        }
        public static string CotizacionOrigen_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.COTIZACION_ORIGENColumnName; }
        }
        public static string FactorConversion_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.FACTOR_CONVERSIONColumnName; }
        }
        public static string FacturaClienteId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.FACTURAS_CLIENTE_IDColumnName; }
        }
        public static string CtacteRecargoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CTACTE_RECARGO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.IMPUESTO_IDColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.LOTE_IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoComisionVenta_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.MONTO_COMISION_VENColumnName; }
        }
        public static string MontoDescuento_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.MONTO_DESCUENTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.OBSERVACIONColumnName; }
        }
        public static string PorcentajeComisionVenta_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.PORCENTAJE_COMISION_VENColumnName; }
        }
        public static string PorcentajeDescuento_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.PORCENTAJE_DTOColumnName; }
        }
        public static string PorcentajeImpuesto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.PORCENTAJE_IMPUESTOColumnName; }
        }
        public static string PrecioListaDestino_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.PRECIO_LISTA_DESTINOColumnName; }
        }
        public static string PrecioListaOrigen_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.PRECIO_LISTA_ORIGENColumnName; }
        }
        public static string TotalMontoBruto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.TOTAL_MONTO_BRUTOColumnName; }
        }
        public static string TotalMontoDescuento_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.TOTAL_MONTO_DTOColumnName; }
        }
        public static string TotalMontoImpuesto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.TOTAL_MONTO_IMPUESTOColumnName; }
        }
        public static string TotalNeto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.TOTAL_NETOColumnName; }
        }
        public static string TotalNetoLuegoDeNC_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.TOTAL_NETO_LUEGO_DE_NCColumnName; }
        }
        public static string TotalRecargoFinanciero_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.TOTAL_RECARGO_FINANCIEROColumnName; }
        }
        public static string CostoMonedaCotizacion_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.COSTO_MONEDA_COTIZACIONColumnName; }
        }
        public static string UnidadDestinoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.UNIDAD_DESTINO_IDColumnName; }
        }
        public static string UnidadOrigenId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.UNIDAD_ORIGEN_IDColumnName; }
        }
        public static string VendedorComisionistaId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.VENDEDOR_COMISIONISTA_IDColumnName; }
        }
        public static string TotalNetoLuegoDeNCAux_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.TOTAL_NETO_LUEGO_DE_NC_AUXColumnName; }
        }
        public static string CantidadAnteriorAux_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CANTIDAD_ANTERIOR_AUXColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.CASO_ASOCIADO_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.DEPOSITO_IDColumnName; }
        }
        public static string ListaPreciosId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DETALLECollection.LISTA_PRECIO_IDColumnName; }
        }
        public static string VistaCasoAsociadoFlujoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.CASO_ASO_FLUJO_IDColumnName; }
        }
        public static string VistaArticuloEsTrazable_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.ARTICULO_ES_TRAZABLEColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloFamiliaNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.FAMILIA_NOMBREColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.GRUPO_IDColumnName; }
        }
        public static string VistaArticuloGrupoNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.GRUPO_NOMBREColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.SUBGRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.SUBGRUPO_NOMBREColumnName; }
        }
        public static string VistaImpuestoDescripcion_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.IMPUESTO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloLoteNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.LOTE_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaActivoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.ACTIVO_IDColumnName; }
        }
        public static string VistaActivoCodigo_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.ACTIVO_CODIGOColumnName; }
        }
        public static string VistaDepositoAbreviatura_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_INF_COCollection.DEPOSITO_ABREVIATURAColumnName; }
        }
        #endregion Accesors

        #region ValidarFilaParaImportacion
        public static string ValidarFilaParaImportacion(DataRow fila, decimal? sucursal_id)
        {
            DataTable resultado;
            string mensaje = String.Empty;
            string conjuncion = String.Empty;
            foreach (Object item in fila.ItemArray)
            {
                if (string.IsNullOrEmpty(item.ToString().Trim()))
                    mensaje = Definiciones.Mensajes.CamposVacios;
            }
            using (SessionService sesion = new SessionService())
            {
                resultado = ArticulosService.GetArticuloInfoCompletaPorCodigo(((string)fila[FacturasProveedorDetalleService.VistaArticuloCodigo_NombreCol]).Trim(), sucursal_id);
                if (resultado.Rows.Count > 0)
                {
                    decimal idSeleccionado = decimal.Parse(resultado.Rows[0][ArticulosService.Id_NombreCol].ToString());
                    if (ArticulosService.NoReponer(idSeleccionado))
                    {
                        conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : ", ");
                        mensaje += conjuncion + "El artículo esta marcado para no ser repuesto";
                    }
                    if (!ArticulosService.EstaActivo(idSeleccionado))
                    {
                        conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : ", ");
                        mensaje += conjuncion + "Artículo inactivo";
                    }

                    if (!ArticulosService.IngresoAprobado(idSeleccionado))
                    {
                        conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : ", ");
                        mensaje += conjuncion + "El ingreso del artículo aún no está aprobado.";
                    }

                    conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : " y ");
                    mensaje += conjuncion + Definiciones.Mensajes.Existe;
                }
                else
                {
                    conjuncion = ((string.IsNullOrEmpty(mensaje)) ? string.Empty : " y ");
                    mensaje += conjuncion + "el artículo " + Definiciones.Mensajes.NoExiste;
                }
            }
            return mensaje;
        }
        #endregion ValidarFilaParaImportacion

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static FacturasClienteDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new FacturasClienteDetalleService(e.RegistroId, sesion);
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
        protected FACTURAS_CLIENTE_DETALLERow row;
        protected FACTURAS_CLIENTE_DETALLERow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? ActivoId { get { if (row.IsACTIVO_IDNull) return null; else return row.ACTIVO_ID; } set { if (value.HasValue) row.ACTIVO_ID = value.Value; else row.IsACTIVO_IDNull = true; } }
        public string ArticuloCodigo { get { return ClaseCBABase.GetStringHelper(row.ARTICULO_CODIGO); } set { row.ARTICULO_CODIGO = value; } }
        public string ArticuloCodigoBarras { get { return ClaseCBABase.GetStringHelper(row.ARTICULO_CODIGO_BARRAS); } set { row.ARTICULO_CODIGO_BARRAS = value; } }
        public string ArticuloDescripcion { get { return ClaseCBABase.GetStringHelper(row.ARTICULO_DESCRIPCION); } set { row.ARTICULO_DESCRIPCION = value; } }
        public decimal ArticuloId { get { return row.ARTICULO_ID; } set { row.ARTICULO_ID = value; } }
        public decimal CantidadAnteriorAux { get { return row.CANTIDAD_ANTERIOR_AUX; } set { row.CANTIDAD_ANTERIOR_AUX = value; } }
        public decimal CantidadDevueltaNotaCredito { get { return row.CANTIDAD_DEVUELTA_NOTA_CREDITO; } set { row.CANTIDAD_DEVUELTA_NOTA_CREDITO = value; } }
        public decimal CantidadEmbalada { get { return row.CANTIDAD_EMBALADA; } set { row.CANTIDAD_EMBALADA = value; } }
        public decimal CantidadPorCajaDestino { get { return row.CANTIDAD_POR_CAJA_DESTINO; } set { row.CANTIDAD_POR_CAJA_DESTINO = value; } }
        public decimal? CantidadPorCajaOrigen { get { if (row.IsCANTIDAD_POR_CAJA_ORIGENNull) return null; else return row.CANTIDAD_POR_CAJA_ORIGEN; } set { if (value.HasValue) row.CANTIDAD_POR_CAJA_ORIGEN = value.Value; else row.IsCANTIDAD_POR_CAJA_ORIGENNull = true; } }
        public decimal CantidadUnidadDestino { get { return row.CANTIDAD_UNIDAD_DESTINO; } set { row.CANTIDAD_UNIDAD_DESTINO = value; } }
        public decimal? CantidadUnidadOrigen { get { if (row.IsCANTIDAD_UNIDAD_ORIGENNull) return null; else return row.CANTIDAD_UNIDAD_ORIGEN; } set { if (value.HasValue) row.CANTIDAD_UNIDAD_ORIGEN = value.Value; else row.IsCANTIDAD_UNIDAD_ORIGENNull = true; } }
        public decimal CantidadUnitariaTotalDest { get { return row.CANTIDAD_UNITARIA_TOTAL_DEST; } set { row.CANTIDAD_UNITARIA_TOTAL_DEST = value; } }
        public decimal? CantidadUnitariaTotalOrig { get { if (row.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull) return null; else return row.CANTIDAD_UNITARIA_TOTAL_ORIG; } set { if (value.HasValue) row.CANTIDAD_UNITARIA_TOTAL_ORIG = value.Value; else row.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull = true; } }
        public decimal? CasoAsociadoId { get { if (row.IsCASO_ASOCIADO_IDNull) return null; else return row.CASO_ASOCIADO_ID; } set { if (value.HasValue) row.CASO_ASOCIADO_ID = value.Value; else row.IsCASO_ASOCIADO_IDNull = true; } }
        public decimal? CostoId { get { if (row.IsCOSTO_IDNull) return null; else return row.COSTO_ID; } set { if (value.HasValue) row.COSTO_ID = value.Value; else row.IsCOSTO_IDNull = true; } }
        public decimal CostoMonto { get { return row.COSTO_MONTO; } set { row.COSTO_MONTO = value; } }
        public decimal? CostoMonedaCotizacion { get { if (row.IsCOSTO_MONEDA_COTIZACIONNull) return null; else return row.COSTO_MONEDA_COTIZACION; } set { if (value.HasValue) row.COSTO_MONEDA_COTIZACION = value.Value; else row.IsCOSTO_MONEDA_COTIZACIONNull = true; } }
        public decimal? CostoMonedaId { get { if (row.IsCOSTO_MONEDA_IDNull) return null; else return row.COSTO_MONEDA_ID; } set { if (value.HasValue) row.COSTO_MONEDA_ID = value.Value; else row.IsCOSTO_MONEDA_IDNull = true; } }
        public decimal? CtacteRecargo { get { if (row.IsCTACTE_RECARGO_IDNull) return null; else return row.CTACTE_RECARGO_ID; } set { if (value.HasValue) row.CTACTE_RECARGO_ID = value.Value; else row.IsCTACTE_RECARGO_IDNull = true; } }
        public decimal? FactorConversion { get { if (row.IsFACTOR_CONVERSIONNull) return null; else return row.FACTOR_CONVERSION; } set { if (value.HasValue) row.FACTOR_CONVERSION = value.Value; else row.IsFACTOR_CONVERSIONNull = true; } }
        public decimal FacturasClienteId { get { return row.FACTURAS_CLIENTE_ID; } set { row.FACTURAS_CLIENTE_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal ImpuestoId { get { return row.IMPUESTO_ID; } set { row.IMPUESTO_ID = value; } }
        public decimal? LoteId { get { if (row.IsLOTE_IDNull) return null; else return row.LOTE_ID; } set { if (value.HasValue) row.LOTE_ID = value.Value; else row.IsLOTE_IDNull = true; } }
        public decimal? MonedaOrigenId { get { if (row.IsMONEDA_ORIGEN_IDNull) return null; else return row.MONEDA_ORIGEN_ID; } set { if (value.HasValue) row.MONEDA_ORIGEN_ID = value.Value; else row.IsMONEDA_ORIGEN_IDNull = true; } }
        public decimal? MontoComisionVen { get { if (row.IsMONTO_COMISION_VENNull) return null; else return row.MONTO_COMISION_VEN; } set { if (value.HasValue) row.MONTO_COMISION_VEN = value.Value; else row.IsMONTO_COMISION_VENNull = true; } }
        public decimal MontoDescuento { get { return row.MONTO_DESCUENTO; } set { row.MONTO_DESCUENTO = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? PorcentajeComisionVen { get { if (row.IsPORCENTAJE_COMISION_VENNull) return null; else return row.PORCENTAJE_COMISION_VEN; } set { if (value.HasValue) row.PORCENTAJE_COMISION_VEN = value.Value; else row.IsPORCENTAJE_COMISION_VENNull = true; } }
        public decimal PorcentajeDto { get { return row.PORCENTAJE_DTO; } set { row.PORCENTAJE_DTO = value; } }
        public decimal? PorcentajeImpuesto { get { if (row.IsPORCENTAJE_IMPUESTONull) return null; else return row.PORCENTAJE_IMPUESTO; } set { if (value.HasValue) row.PORCENTAJE_IMPUESTO = value.Value; else row.IsPORCENTAJE_IMPUESTONull = true; } }
        public decimal PrecioListaDestino { get { return row.PRECIO_LISTA_DESTINO; } set { row.PRECIO_LISTA_DESTINO = value; } }
        public decimal PrecioListaOrigen { get { return row.PRECIO_LISTA_ORIGEN; } set { row.PRECIO_LISTA_ORIGEN = value; } }
        public decimal TotalMontoBruto { get { return row.TOTAL_MONTO_BRUTO; } set { row.TOTAL_MONTO_BRUTO = value; } }
        public decimal TotalMontoDto { get { return row.TOTAL_MONTO_DTO; } set { row.TOTAL_MONTO_DTO = value; } }
        public decimal TotalMontoImpuesto { get { return row.TOTAL_MONTO_IMPUESTO; } set { row.TOTAL_MONTO_IMPUESTO = value; } }
        public decimal TotalNeto { get { return row.TOTAL_NETO; } set { row.TOTAL_NETO = value; } }
        public decimal TotalNetoLuegoDeNC { get { return row.TOTAL_NETO_LUEGO_DE_NC; } set { row.TOTAL_NETO_LUEGO_DE_NC = value; } }
        public decimal TotalNetoLuegoDeNCAux { get { return row.TOTAL_NETO_LUEGO_DE_NC_AUX; } set { row.TOTAL_NETO_LUEGO_DE_NC_AUX = value; } }
        public decimal TotalRecargoFinanciero { get { return row.TOTAL_RECARGO_FINANCIERO; } set { row.TOTAL_RECARGO_FINANCIERO = value; } }
        public string UnidadDestinoId { get { return ClaseCBABase.GetStringHelper(row.UNIDAD_DESTINO_ID); } set { row.UNIDAD_DESTINO_ID = value; } }
        public string UnidadOrigenId { get { return ClaseCBABase.GetStringHelper(row.UNIDAD_ORIGEN_ID); } set { row.UNIDAD_ORIGEN_ID = value; } }
        public decimal? VendedorComisionistaId { get { if (row.IsVENDEDOR_COMISIONISTA_IDNull) return null; else return row.VENDEDOR_COMISIONISTA_ID; } set { if (value.HasValue) row.VENDEDOR_COMISIONISTA_ID = value.Value; else row.IsVENDEDOR_COMISIONISTA_IDNull = true; } }
        public decimal? DepositoId { get { if (row.IsDEPOSITO_IDNull) return null; else return row.DEPOSITO_ID; } set { if (value.HasValue) row.DEPOSITO_ID = value.Value; else row.IsDEPOSITO_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                    this._articulo = new ArticulosService(this.ArticuloId);
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

        private ImpuestosService _impuesto;
        public ImpuestosService Impuesto
        {
            get
            {
                if (this._impuesto == null)
                    this._impuesto = new ImpuestosService(this.ImpuestoId);
                return this._impuesto;
            }
        }

        private FacturasClienteService _factura_cliente;
        public FacturasClienteService FacturaCliente
        {
            get
            {
                if (this._factura_cliente == null)
                    this._factura_cliente = new FacturasClienteService(this.FacturasClienteId);
                return this._factura_cliente;
            }
        }

        private UnidadesService _unidad_destino;
        public UnidadesService UnidadDestino
        {
            get
            {
                if (this._unidad_destino == null)
                    this._unidad_destino = new UnidadesService(this.UnidadDestinoId);
                return this._unidad_destino;
            }
        }

        private UnidadesService _unidad_origen;
        public UnidadesService UnidadOrigen
        {
            get
            {
                if (this._unidad_origen == null)
                    this._unidad_origen = new UnidadesService(this.UnidadOrigenId);
                return this._unidad_origen;
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
                this.row = sesion.db.FACTURAS_CLIENTE_DETALLECollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new FACTURAS_CLIENTE_DETALLERow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(FACTURAS_CLIENTE_DETALLERow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public FacturasClienteDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public FacturasClienteDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public FacturasClienteDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public FacturasClienteDetalleService(EdiCBA.FacturaClienteDetalle edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = FacturasClienteDetalleService.GetIdPorUUID(edi.uuid, sesion);
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

            this.CantidadEmbalada = edi.cantidad_embalada_origen;
            this.CantidadPorCajaDestino = edi.cantidad_por_caja_destino;
            this.CantidadPorCajaOrigen = edi.cantidad_por_caja_origen;
            this.CantidadUnidadDestino = edi.cantidad_unitaria_destino;
            this.CantidadUnidadOrigen = edi.cantidad_unitaria_origen;
            this.CantidadUnitariaTotalDest = edi.cantidad_unitaria_total_destino;
            this.CantidadUnitariaTotalOrig = edi.cantidad_unitaria_total_origen;

            if (edi.costo_cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'costo_cotizacion'.");
            this.CostoMonedaCotizacion = edi.costo_cotizacion.compra;
            this.CostoMonto = edi.costo_unitario_monto;
            if (edi.costo_cotizacion.moneda != null)
                this.CostoMonedaId = edi.costo_cotizacion.moneda.id;
            else
                this.CostoMonedaId = MonedasService.GetIdPorUUID(edi.costo_cotizacion.moneda_uuid, sesion).Value;
            
            this.FactorConversion = edi.factor_conversion;

            #region factura cliente
            if (!string.IsNullOrEmpty(edi.factura_cliente_uuid))
                this._factura_cliente = FacturasClienteService.GetPorUUID(edi.factura_cliente_uuid, sesion);
            if (this._factura_cliente == null && edi.factura_cliente != null)
                this._factura_cliente = new FacturasClienteService(edi.factura_cliente, almacenar_localmente, sesion);
            if (this._factura_cliente != null)
            {
                if (!this.FacturaCliente.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.FacturaCliente.Id.HasValue)
                    this.FacturasClienteId = this.FacturaCliente.Id.Value;
            }
            #endregion factura cliente

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
            #endregion impuesto

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
            this.PrecioListaDestino = edi.precio_unitario;
            this.PrecioListaOrigen = edi.precio_unitario;
            this.TotalMontoBruto = edi.total_bruto;
            this.TotalMontoDto = edi.total_descuento;
            this.TotalMontoImpuesto = edi.total_impuesto;
            this.TotalNeto = edi.total_neto;

            this.PorcentajeDto = edi.porcentaje_descuento;
            this.MontoDescuento = edi.total_descuento;
            if (this.PorcentajeDto == 0 && this.MontoDescuento != 0)
                this.PorcentajeDto = this.MontoDescuento / this.TotalNeto * 100;
            if (this.PorcentajeDto != 0 && this.MontoDescuento == 0)
                this.MontoDescuento = this.TotalNeto * this.PorcentajeDto / 100;

            if (edi.unidad_destino == null)
                throw new Exception("El EDI debe contener el objeto 'unidad_destino'.");
            this.UnidadDestinoId = edi.unidad_destino.simbolo;
            if (edi.unidad_origen == null)
                throw new Exception("El EDI debe contener el objeto 'unidad_origen'.");
            this.UnidadOrigenId = edi.unidad_origen.simbolo;

            #region inicializar campos no contemplados en el EDI si el dato no existe localmente
            if (!this.ExisteEnDB)
            {
                this._costo_ppp = new StockService.Costo()
                {
                    costo = edi.costo_unitario_monto,
                    cotizacion = edi.costo_cotizacion.compra,
                    moneda_id = (decimal)(edi.costo_cotizacion.moneda != null ? edi.costo_cotizacion.moneda.id : MonedasService.GetIdPorUUID(edi.costo_cotizacion.moneda_uuid, sesion).Value)
                };
            }
            #endregion campos no contemplados en el EDI si el dato no existe localmente
        }
        private FacturasClienteDetalleService(FACTURAS_CLIENTE_DETALLERow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static FacturasClienteDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static FacturasClienteDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.FACTURAS_CLIENTE_DETALLECollection.GetAsArray(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = "  + cabecera_id, FacturasClienteDetalleService.Id_NombreCol);
            FacturasClienteDetalleService[] fcd = new FacturasClienteDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                fcd[i] = new FacturasClienteDetalleService(rows[i].ID);
            return fcd;
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
            return GetStockMovimiento(this.FacturaCliente.CasoId, sesion);
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
            this._factura_cliente = null;
            this._impuesto = null;
            this._lote = null;
            this._unidad_destino = null;
            this._unidad_origen = null;
        }
        #endregion ResetearPropiedadesExtendidas
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
