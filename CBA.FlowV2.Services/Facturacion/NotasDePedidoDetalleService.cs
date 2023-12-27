#region Using

using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Common;

#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class NotasDePedidoDetalleService
    {
        #region Get Pedido de Cliente Detalle Row
        /// <summary>
        /// Gets the pedido de cliente detalle row.
        /// </summary>
        /// <param name="pedido_de_cliente_detalle_id">The pedido_de_cliente_detalle_id.</param>
        /// <returns></returns>
        public DataRow GetPedidoDeClienteDetalleRow(Decimal pedido_de_cliente_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetAsDataTable(Id_NombreCol + "= " + pedido_de_cliente_detalle_id, string.Empty);
                return table.Rows[0];
            }
        }
        #endregion Get Pedido de Cliente Detalle Row

        #region Get Pedido de Cliente Detalle
        /// <summary>
        /// Gets the pedido de cliente detalle.
        /// </summary>
        /// <param name="pedido_de_cliente_id">The pedido_de_cliente_id.</param>
        /// <returns></returns>
        public static DataTable GetPedidoDeClienteDetalleDataTable(string where)
        {
            DataTable detalles;
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    detalles = sesion.Db.PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.GetAsDataTable(where, Id_NombreCol);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return detalles;
        }

        public static DataTable GetPedidoDeClienteDetalleInfoCompletaDataTable(string where)
        {
            DataTable detalles;
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    detalles = sesion.Db.PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.GetAsDataTable(where, NotasDePedidoDetalleService.OrdenDePresentacion_NombreCol);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return detalles;
        }
        #endregion Get Pedido de Cliente Detalle

        #region Get Pedido de Cliente Detalle Por Grupo
        public static DataTable GetPedidoDeClienteDetallePorGrupoDataTable(string where)
        {
            DataTable detalles;
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    detalles = sesion.Db.PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.GetAsDataTable(where, Id_NombreCol);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return detalles;
        }
        #endregion Get Pedido de Cliente Detalle Por Grupo

        #region Getters
        public DataTable GetPedidoDeClienteDetalle(Decimal pedido_de_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.GetAsDataTable(PedidosClienteId_NombreCol + " = " + pedido_de_cliente_id, Id_NombreCol);
            }
        }
        public static DataTable GetPedidoDeClienteDetalleOrdenadoAsDataTable(Decimal pedido_de_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.GetAsDataTable(PedidosClienteId_NombreCol + " = " + pedido_de_cliente_id, OrdenDePresentacion_NombreCol + " asc");
            }
        }
        private static PEDIDOS_CLIENTE_DETALLERow[] GetPedidoDeClienteDetalleOrdenado(Decimal pedido_de_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetAsArray(PedidosClienteId_NombreCol + " = " + pedido_de_cliente_id, OrdenDePresentacion_NombreCol + " asc");
            }
        }
        public static PEDIDOS_CLIENTE_DETALLERow getArticuloPedido(string where)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetRow(where);
            }
        }
        public static decimal GetCantidadPorItem(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PEDIDOS_CLIENTE_DETALLERow row = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(detalle_id);
                if (row != null)
                {
                    return row.CANTIDAD_UNITARIA_PEDIDA;
                }
                return 0;

            }
        }
        public static decimal GetCantidadTotalPorItem(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PEDIDOS_CLIENTE_DETALLERow row = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(detalle_id);
                if (row != null)
                {
                    return row.CANTIDAD_TOTAL_PEDIDA;
                }
                return 0;
            }
        }
        public static decimal GetLoteIdPorDetalleId(decimal detalle_id)
        {
            decimal loteId;
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    loteId = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(detalle_id).LOTE_ID;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return loteId;
        }
        public static decimal GetArticuloIdPorDetalleId(decimal detalle_id)
        {
            decimal articuloId;
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    articuloId = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(detalle_id).ARTICULO_ID;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return articuloId;
        }
        public static decimal GetPrecioListaDestinoIdPorDetalleId(decimal detalle_id)
        {
            decimal precio;
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    precio = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(detalle_id).PRECIO_LISTA_DESTINO;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return precio;
        }
        public static decimal GetCantidadTotalPedidaPorDetalleId(decimal detalle_id)
        {
            decimal precio;
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    precio = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(detalle_id).CANTIDAD_TOTAL_PEDIDA;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return precio;
        }
        public static decimal GetCantidadTotalPorDetalleId(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCantidadTotalPorDetalleId(detalle_id, sesion);
            }
        }
        public static decimal GetCantidadTotalPorDetalleId(decimal detalle_id, SessionService sesion)
        {
            return sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(detalle_id).CANTIDAD_TOTAL_ENTREGADA;
        }

        public static decimal GetNotaDePedidoIdPorId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    decimal notaDePedidoID = GetNotaDePedidoIdPorId(id, sesion);
                    sesion.db.CommitTransaction();
                    return notaDePedidoID;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static decimal GetNotaDePedidoIdPorId(decimal id, SessionService sesion) 
        {
            PEDIDOS_CLIENTE_DETALLERow row = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(id);            
            return row.PEDIDOS_CLIENTE_ID;            
        }
        #endregion Getters

        #region ReordenarDetalles
        public static void ReordenarDetalles(Decimal pedido_de_cliente_id, Decimal detalle_id,decimal operacion)
        {
            int paso = (Definiciones.OrdenOperacion.Bajar == operacion) ? 1 : -1;
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    PEDIDOS_CLIENTE_DETALLERow[] detalles = NotasDePedidoDetalleService.GetPedidoDeClienteDetalleOrdenado(pedido_de_cliente_id);
                    for (int i = 0; i < detalles.Length; i++)
                        if (detalles[i].ID == detalle_id)
                        {
                            if (!(i + paso < 0 || i + paso > detalles.Length))
                            {
                                detalles[i].ORDEN_DE_PRESENTACION = i + paso+1;
                                detalles[i+paso].ORDEN_DE_PRESENTACION = i+1;
                                sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.Update(detalles[i]);
                                sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.Update(detalles[i+paso]);
                            }
                            break;
                        }
                    sesion.Db.CommitTransaction();
                }
                catch (Exception)
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion ReordenarDetalles

        #region Actualizar Cantidad Pedido
        public static void ActualizarCantidadPedidos(System.Collections.Hashtable campos, decimal vCaso)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (campos.Contains(ArticuloId_NombreCol) && campos.Contains(PedidosClienteId_NombreCol))
                    {
                        PEDIDOS_CLIENTE_DETALLERow pedidoDetalleRow = new PEDIDOS_CLIENTE_DETALLERow();

                        string where = ArticuloId_NombreCol + " = " + decimal.Parse(campos[ArticuloId_NombreCol].ToString()) + " AND " + PedidosClienteId_NombreCol + " = " + decimal.Parse(campos[PedidosClienteId_NombreCol].ToString());
                        //obtener detalle por id de artículo y pedido al que corresponde
                        pedidoDetalleRow = getArticuloPedido(where);

                        if (campos.Contains(CantidadTotalEntregada_NombreCol))
                        {
                            pedidoDetalleRow.CANTIDAD_TOTAL_ENTREGADA = decimal.Parse(campos[CantidadTotalEntregada_NombreCol].ToString());
                        }

                        if (campos.Contains(CantidadCajasEntregada_NombreCol))
                        {
                            pedidoDetalleRow.CANTIDAD_CAJAS_ENTREGADA = decimal.Parse(campos[CantidadCajasEntregada_NombreCol].ToString());
                        }

                        if (campos.Contains(CantidadUnitariaEntregada_NombreCol))
                        {
                            pedidoDetalleRow.CANTIDAD_UNITARIA_ENTREGADA = decimal.Parse(campos[CantidadUnitariaEntregada_NombreCol].ToString());
                        }

                        //crear otro hashtable y poblar la misma con los campos requeridos para llamar al método Guardar
                        System.Collections.Hashtable hashTable = new System.Collections.Hashtable();

                        hashTable.Add(NotasDePedidoDetalleService.Id_NombreCol, pedidoDetalleRow.ID);
                        hashTable.Add(NotasDePedidoDetalleService.ArticuloId_NombreCol, pedidoDetalleRow.ARTICULO_ID);
                        hashTable.Add(NotasDePedidoDetalleService.LoteId_NombreCol, pedidoDetalleRow.LOTE_ID);
                        hashTable.Add(NotasDePedidoDetalleService.UnidadIdDestino_NombreCol, pedidoDetalleRow.UNIDAD_DESTINO_ID);
                        hashTable.Add(NotasDePedidoDetalleService.CantidadCajasEntregada_NombreCol, pedidoDetalleRow.CANTIDAD_CAJAS_ENTREGADA);
                        hashTable.Add(NotasDePedidoDetalleService.CantidadUnitariaEntregada_NombreCol, pedidoDetalleRow.CANTIDAD_UNITARIA_ENTREGADA);
                        hashTable.Add(NotasDePedidoDetalleService.ImpuestoId_NombreCol, pedidoDetalleRow.IMPUESTO_ID);
                        hashTable.Add(NotasDePedidoDetalleService.Monto_Descuento_NombreCol, pedidoDetalleRow.MONTO_DESCUENTO);
                        hashTable.Add(NotasDePedidoDetalleService.PorcentajeDto_NombreCol, pedidoDetalleRow.PORCENTAJE_DTO);
                        hashTable.Add(NotasDePedidoDetalleService.PrecioListaDestino_NombreCol, pedidoDetalleRow.PRECIO_LISTA_DESTINO);
                        hashTable.Add(NotasDePedidoDetalleService.VendedorComisionistaId_NombreCol, pedidoDetalleRow.VENDEDOR_COMISIONISTA_ID);
                        hashTable.Add(NotasDePedidoDetalleService.CantidadSubItemsFinal_NombreCol, pedidoDetalleRow.CANTIDAD_SUBITEMS_FINAL);

                        NotasDePedidoDetalleService.Guardar(decimal.Parse(campos[PedidosClienteId_NombreCol].ToString()), hashTable, false, vCaso);

                        if (campos.Contains(CantidadTotalEntregada_NombreCol) && campos.Contains(CantidadTotalPedida_NombreCol))
                        {
                            string mensaje = string.Empty;

                            //obtener el Pedido
                            PEDIDOS_CLIENTERow pedidoRow = new PEDIDOS_CLIENTERow();
                            pedidoRow = NotasDePedidosService.GetPedidoDeCliente2(decimal.Parse(campos[PedidosClienteId_NombreCol].ToString()));
                            string valorAnteriorPedido = pedidoRow.ToString();
                            sesion.BeginTransaction();

                            //si los cambios son mayores precios debería aprobar nuevamente, y el caso pasa a estado pendiente
                            if (decimal.Parse(campos[CantidadTotalEntregada_NombreCol].ToString()) > decimal.Parse(campos[CantidadTotalPedida_NombreCol].ToString()))
                            {
                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(vCaso, Definiciones.EstadosFlujos.Pendiente, string.Empty, sesion);

                                pedidoRow.APROBACION_DPTO_CREDITO = Definiciones.SiNo.No;
                            }
                            //si los cambios son menores crédito debería aprobar nuevamente, y el caso pasa a estado pendiente
                            else if (decimal.Parse(campos[CantidadTotalEntregada_NombreCol].ToString()) < decimal.Parse(campos[CantidadTotalPedida_NombreCol].ToString()))
                            {
                                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(vCaso, Definiciones.EstadosFlujos.Pendiente, string.Empty, sesion);

                                pedidoRow.APROBACION_DPTO_PRECIOS = Definiciones.SiNo.No;
                            }

                            sesion.db.PEDIDOS_CLIENTECollection.Update(pedidoRow);
                            LogCambiosService.LogDeRegistro(NotasDePedidosService.Nombre_Tabla, pedidoRow.ID, valorAnteriorPedido, pedidoRow.ToString(), sesion);
                            sesion.CommitTransaction();
                        }
                    }
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Actualizar Cantidad Pedido

        #region ActualizarArticuloRecargoFinanciero
        /// <summary>
        /// Actualizars the articulo recargo financiero.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="total_recargo_financiero">The total_recargo_financiero.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarArticuloRecargoFinanciero(decimal pedido_cliente_id, decimal caso_id, decimal total_recargo_financiero, SessionService sesion)
        {
            DataTable dtPedidoCliente = NotasDePedidosService.GetPedidoDeClienteDataTable(NotasDePedidosService.ID_NombreCol + " = " + pedido_cliente_id, string.Empty, sesion);
            decimal articuloRecargoId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteArticuloPorRecargoFinanciero);
            string clausulas = ArticulosService.Id_NombreCol + " = " + articuloRecargoId;
            DataTable dtArticuloRecargo = ArticulosService.GetArticulos(clausulas, string.Empty, true, (decimal)dtPedidoCliente.Rows[0][NotasDePedidosService.SUCURSAL_ID_NombreCol]);
            DataTable dtArticuloRecargoLote = ArticulosLotesService.GetArticulosLotes(articuloRecargoId, ArticulosLotesService.Id_NombreCol + " desc ");
            PEDIDOS_CLIENTE_DETALLERow[] detallesRow = sesion.db.PEDIDOS_CLIENTE_DETALLECollection.GetByARTICULO_ID(articuloRecargoId);

            if (dtArticuloRecargoLote.Rows.Count <= 0)
                throw new Exception("No existe un lote para el artículo de recargo financiero.");

            //Si ya existia alguno creado, se borra
            for (int i = 0; i < detallesRow.Length; i++)
                NotasDePedidoDetalleService.Borrar(detallesRow[i].ID, caso_id, false, sesion);

            if (total_recargo_financiero > 0)
            {
                Hashtable campos = new Hashtable();
                campos.Add(NotasDePedidoDetalleService.PedidosClienteId_NombreCol, pedido_cliente_id);
                campos.Add(NotasDePedidoDetalleService.ArticuloId_NombreCol, articuloRecargoId);
                campos.Add(NotasDePedidoDetalleService.LoteId_NombreCol, dtArticuloRecargoLote.Rows[0][ArticulosLotesService.Id_NombreCol]);
                campos.Add(NotasDePedidoDetalleService.CantidadUnitariaEntregada_NombreCol, (decimal)1);
                campos.Add(NotasDePedidoDetalleService.PrecioListaDestino_NombreCol, total_recargo_financiero);
                campos.Add(NotasDePedidoDetalleService.OrdenDePresentacion_NombreCol, NotasDePedidoDetalleService.Orden(pedido_cliente_id, sesion) + 1);

                NotasDePedidoDetalleService.Guardar(pedido_cliente_id, campos, true, caso_id, false, sesion);
            }
        }
        #endregion ActualizarArticuloRecargoFinanciero

        #region Guardar
        public static void Guardar(decimal pedido_cliente_id, System.Collections.Hashtable campos, bool insertarNuevo, decimal caso_id)
        { 
            using (SessionService sesion = new SessionService())
            {
                Guardar(pedido_cliente_id, campos, insertarNuevo, caso_id, true, sesion);
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="pedido_cliente_id">The pedido_cliente_id.</param>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        private static void Guardar(decimal pedido_cliente_id, System.Collections.Hashtable campos, bool insertarNuevo, decimal caso_id, bool recalcular_totales_cabecera, SessionService sesion)
        {
            try
            {
                PEDIDOS_CLIENTE_DETALLERow row = new PEDIDOS_CLIENTE_DETALLERow();
                PEDIDOS_CLIENTERow pedidoRow;
                RegimenComisionesService regimenComisiones = new RegimenComisionesService();
                decimal monto_original_descuento = 0, monto_original_recargo = 0;
                decimal cantidad_original = 0;
                VendedorClienteFamiliaService vendedorClienteFamilia = new VendedorClienteFamiliaService();
                decimal articuloRecargoFinanciero = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteArticuloPorRecargoFinanciero);
                DateTime fechaPrimerVencimiento, fechaSegundoVencimiento;
                bool usarFechaPrimerVencimiento, usarFechaSegundoVencimiento;

                string valorAnterior = string.Empty;
                bool esServicio;

                //El articulo debe tener ingreso aprobado
                if (!ArticulosService.IngresoAprobado(decimal.Parse(campos[ArticuloId_NombreCol].ToString())))
                {
                    throw new System.ArgumentException("El ingreso del artículo aún no está aprobado.");
                }
                
                esServicio = ArticulosService.EsServicio(decimal.Parse(campos[ArticuloId_NombreCol].ToString()));

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("pedidos_cliente_detalle_sqc");
                    row.PEDIDOS_CLIENTE_ID = decimal.Parse(campos[PedidosClienteId_NombreCol].ToString());

                    if (campos.Contains(ActivoId_NombreCol))
                    {
                        row.ACTIVO_ID = decimal.Parse(campos[ActivoId_NombreCol].ToString());
                    }
                }
                else
                {
                    row = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    monto_original_descuento = row.TOTAL_MONTO_DTO;
                    monto_original_recargo = row.TOTAL_RECARGO_FINANCIERO;
                    valorAnterior = row.ToString();
                    cantidad_original = row.CANTIDAD_UNITARIA_TOTAL_ORIG;
                    if (campos.Contains(ActivoId_NombreCol))
                    {
                        row.ACTIVO_ID = decimal.Parse(campos[ActivoId_NombreCol].ToString());
                    }
                }

                //Se obtiene la nota de pedido
                pedidoRow = NotasDePedidosService.GetPedidoDeCliente2(row.PEDIDOS_CLIENTE_ID, sesion);
                #region verificar cantidad de detalles segun autonumeracion
                if (!campos.Contains(NotasDePedidoDetalleService.Id_NombreCol) && !pedidoRow.IsAUTONUMERACION_IDNull)
                {
                    var dt = AutonumeracionesService.GetAutonumeracionesDataTable(AutonumeracionesService.Id_NombreCol + " = " + pedidoRow.AUTONUMERACION_ID, string.Empty, sesion);
                    if (!Interprete.EsNullODBNull(dt.Rows[0][AutonumeracionesService.DetallesCantidadMaxima_NombreCol]))
                    {
                        var dtDetalles = NotasDePedidoDetalleService.GetPedidoDeClienteDetalleDataTable(NotasDePedidoDetalleService.PedidosClienteId_NombreCol + " = " + pedido_cliente_id);
                        if (dtDetalles.Rows.Count >= (decimal)dt.Rows[0][AutonumeracionesService.DetallesCantidadMaxima_NombreCol])
                            throw new Exception("Cantidad máxima de artículos superada.");
                    }
                }
                #endregion verificar cantidad de detalles segun autonumeracion

                string valorAnteriorPedido = pedidoRow.ToString();
                row.ARTICULO_ID = (decimal)campos[ArticuloId_NombreCol];
                row.LOTE_ID = decimal.Parse(campos[LoteId_NombreCol].ToString());

                //se obtiene datos adicionales del articulo
                DataTable dtArticulos = ArticulosService.GetArticuloInfoCompletaPorID(row.ARTICULO_ID, pedidoRow.SUCURSAL_ID, sesion);
                //La cantidad por caja se toma de la seccion del articulo
                row.CANTIDAD_POR_CAJA_ORIGEN = decimal.Parse(dtArticulos.Rows[0][ArticulosService.CantidadPorCaja_NombreCol].ToString());
                row.UNIDAD_ORIGEN_ID = dtArticulos.Rows[0][ArticulosService.UnidadMedidaId_NombreCol].ToString();

                if (insertarNuevo)
                {
                    DataTable tabla = ArticulosConversionesService.GetUnidadesDeMedidaPorArticulo(row.ARTICULO_ID, pedidoRow.SUCURSAL_ID);
                    row.UNIDAD_DESTINO_ID = tabla.Rows[0][UnidadesService.Id_NombreCol].ToString();
                    if (row.UNIDAD_DESTINO_ID != null)
                    {
                        //se obtiene el factor de conversion
                        row.FACTOR_CONVERSION = (new ArticulosConversionesService()).GetFactorConversion(row.ARTICULO_ID, row.UNIDAD_DESTINO_ID, pedidoRow.SUCURSAL_ID);
                        row.CANTIDAD_POR_CAJA_DESTINO = row.CANTIDAD_POR_CAJA_ORIGEN * row.FACTOR_CONVERSION;

                        row.CANTIDAD_UNIDAD_ORIGEN = row.CANTIDAD_UNITARIA_ENTREGADA / row.FACTOR_CONVERSION;
                    }

                    row.CANTIDAD_CAJAS_ENTREGADA = 0;
                    row.CANTIDAD_UNITARIA_ENTREGADA = (decimal)campos[NotasDePedidoDetalleService.CantidadUnitariaEntregada_NombreCol];
                    row.IMPUESTO_ID = ArticulosService.GetImpuestoId((decimal)campos[NotasDePedidoDetalleService.ArticuloId_NombreCol]);
                    row.CANTIDAD_TOTAL_ENTREGADA = (decimal)campos[NotasDePedidoDetalleService.CantidadUnitariaEntregada_NombreCol]; ;
                    row.CANTIDAD_UNITARIA_TOTAL_ORIG = (decimal)campos[NotasDePedidoDetalleService.CantidadUnitariaEntregada_NombreCol];
                    row.MONTO_DESCUENTO = 0;
                    row.PORCENTAJE_DTO = 0;
                    row.CANTIDAD_SUBITEMS_FINAL = 0;

                    //Si es un servicio no se controla la existencia
                    if (!ArticulosService.EsServicio(row.ARTICULO_ID, sesion))
                    {
                        if (VerificarRepeticion(row.PEDIDOS_CLIENTE_ID, row.LOTE_ID, sesion) && insertarNuevo)
                            throw new Exception("El Lote de este Artículo ya fue ingresado");

                        decimal cantidadDisponible = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, pedidoRow.DEPOSITO_ID);
                        string verificarExistencia = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.VerificarExistenciaStockPedidoCliente);
                        if (verificarExistencia.Equals(Definiciones.SiNo.Si))
                        {
                            if (cantidadDisponible < row.CANTIDAD_UNITARIA_TOTAL_ORIG)
                                throw  new Exception("Cantidad insuficiente");
                            row.CON_STOCK = Definiciones.SiNo.Si;
                        }
                        else
                        {
                            if (cantidadDisponible < row.CANTIDAD_UNITARIA_TOTAL_ORIG)
                                row.CON_STOCK = Definiciones.SiNo.No;
                            else
                                row.CON_STOCK = Definiciones.SiNo.Si;

                        }
                    }
                }
                else
                {
                    decimal cantidadActual = row.CANTIDAD_UNITARIA_TOTAL_ORIG;

                    if (campos.Contains(UnidadIdDestino_NombreCol))
                        row.UNIDAD_DESTINO_ID = campos[UnidadIdDestino_NombreCol].ToString();
                    row.CANTIDAD_CAJAS_ENTREGADA = decimal.Parse(campos[CantidadCajasEntregada_NombreCol].ToString());
                    row.CANTIDAD_UNITARIA_ENTREGADA = decimal.Parse(campos[CantidadUnitariaEntregada_NombreCol].ToString());
                    row.PRECIO_LISTA_DESTINO = decimal.Parse(campos[PrecioListaDestino_NombreCol].ToString());
                    if (campos.Contains(ImpuestoId_NombreCol))
                        row.IMPUESTO_ID = (decimal)campos[NotasDePedidoDetalleService.ImpuestoId_NombreCol];
                    else
                        row.IMPUESTO_ID = ArticulosService.GetImpuestoId((decimal)campos[NotasDePedidoDetalleService.ArticuloId_NombreCol]);
                    if (row.UNIDAD_DESTINO_ID != null)
                    {
                        //se obtiene el factor de conversion
                        row.FACTOR_CONVERSION = (new ArticulosConversionesService()).GetFactorConversion(row.ARTICULO_ID, row.UNIDAD_DESTINO_ID, pedidoRow.SUCURSAL_ID);
                        row.CANTIDAD_POR_CAJA_DESTINO = row.CANTIDAD_POR_CAJA_ORIGEN * row.FACTOR_CONVERSION;

                        row.CANTIDAD_UNIDAD_ORIGEN = row.CANTIDAD_UNITARIA_ENTREGADA / row.FACTOR_CONVERSION;
                    }

                    //La cantidad en unidades es la cantidad de cajas, por unidades que trae una caja
                    //mas la cantidad que se pidio suelta
                   
                    row.CANTIDAD_TOTAL_ENTREGADA = (row.CANTIDAD_CAJAS_ENTREGADA * row.CANTIDAD_POR_CAJA_DESTINO) + row.CANTIDAD_UNITARIA_ENTREGADA;
                    row.CANTIDAD_UNITARIA_TOTAL_ORIG = row.CANTIDAD_TOTAL_ENTREGADA / row.FACTOR_CONVERSION;

                    if (!(ArticulosService.EsServicio(row.ARTICULO_ID)))
                    {

                        decimal cantidadDisponible = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, pedidoRow.DEPOSITO_ID);
                        string verificarExistencia = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.VerificarExistenciaStockPedidoCliente);
                        if (verificarExistencia.Equals(Definiciones.SiNo.Si))
                        {
                            if (cantidadDisponible + cantidadActual < row.CANTIDAD_UNITARIA_TOTAL_ORIG)
                                throw new Exception("Cantidad insuficiente");
                            row.CON_STOCK = Definiciones.SiNo.Si;
                        }
                        else
                        {
                            if (cantidadDisponible + cantidadActual < row.CANTIDAD_UNITARIA_TOTAL_ORIG)
                                row.CON_STOCK = Definiciones.SiNo.No;
                            else
                                row.CON_STOCK = Definiciones.SiNo.Si;

                        }
                    }

                    //Para evitar diferencias entre el porcentaje y valor de descuento
                    //se calcula uno a partir del otro, privilegiando el valor
                    if (campos.Contains(Monto_Descuento_NombreCol))
                        row.MONTO_DESCUENTO = decimal.Parse(campos[Monto_Descuento_NombreCol].ToString());
                    
                    if (row.MONTO_DESCUENTO > 0)
                        row.PORCENTAJE_DTO = row.MONTO_DESCUENTO / row.PRECIO_LISTA_DESTINO * 100;
                    else row.PORCENTAJE_DTO = 0;

                    row.CANTIDAD_SUBITEMS_FINAL = decimal.Parse(campos[CantidadSubItemsFinal_NombreCol].ToString());
                }
                if( row.ORDEN_DE_PRESENTACION ==0)
                    row.ORDEN_DE_PRESENTACION = (decimal)campos[NotasDePedidoDetalleService.OrdenDePresentacion_NombreCol];

                decimal precio, moneda_precio, cotizacion_precio, porcentajeDescuento = 0;
                if (row.ARTICULO_ID != articuloRecargoFinanciero)
                {
                    

                    if (dtArticulos.Rows[0][ArticulosService.ControlarPrecio_NombreCol].Equals(Definiciones.SiNo.Si))
                    {
                        precio = PreciosService.GetPrecioPorArticulo(pedidoRow.PERSONA_ID,
                                                             row.ARTICULO_ID,
                                                             pedidoRow.MONEDA_DESTINO_ID,
                                                             pedidoRow.SUCURSAL_ID,
                                                             pedidoRow.CASO_ID,
                                                             pedidoRow.COTIZACION_DESTINO,
                                                             pedidoRow.LISTA_PRECIO_ID,
                                                             pedidoRow.CONDICION_PAGO_ID,
                                                             ref porcentajeDescuento,
                                                             out moneda_precio,
                                                             out cotizacion_precio,
                                                             out fechaPrimerVencimiento,
                                                             out usarFechaPrimerVencimiento,
                                                             out fechaSegundoVencimiento,
                                                             out usarFechaSegundoVencimiento,
                                                             false, Definiciones.Error.Valor.EnteroPositivo);
                    }
                    else
                    {
                        moneda_precio = pedidoRow.MONEDA_DESTINO_ID;
                        cotizacion_precio = pedidoRow.COTIZACION_DESTINO;
                        precio = row.PRECIO_LISTA_DESTINO;
                    }

                    if (row.PORCENTAJE_DTO != 0)
                        porcentajeDescuento = row.PORCENTAJE_DTO;

                    row.PORCENTAJE_DTO = porcentajeDescuento;
                    row.MONTO_DESCUENTO = row.PRECIO_LISTA_DESTINO * row.PORCENTAJE_DTO / 100;
                }
                else 
                {
                    moneda_precio = pedidoRow.MONEDA_DESTINO_ID;
                    cotizacion_precio = pedidoRow.COTIZACION_DESTINO;
                    precio = row.PRECIO_LISTA_DESTINO;
                }

                //Se toma la moneda origen de la que se convirtio al tipo de moneda de la factura
                row.MONEDA_ORIGEN_ID = moneda_precio;
                row.COTIZACION_ORIGEN = cotizacion_precio;
                row.PRECIO_LISTA_ORIGEN = precio;

                if (insertarNuevo)
                {
                    decimal precioConvertido = 0;
                    decimal precioConvertidoPorUnidad = precio / row.FACTOR_CONVERSION;

                    if (pedidoRow.MONEDA_DESTINO_ID == moneda_precio)
                    {
                        precioConvertido = precioConvertidoPorUnidad;
                    }
                    else
                    {
                        precioConvertido = precioConvertidoPorUnidad / cotizacion_precio * pedidoRow.COTIZACION_DESTINO;
                    }
                    if (campos.Contains(NotasDePedidoDetalleService.PrecioListaDestino_NombreCol))
                    {
                        row.PRECIO_LISTA_DESTINO = (decimal)campos[NotasDePedidoDetalleService.PrecioListaDestino_NombreCol];
                    }
                    else
                    {
                        row.PRECIO_LISTA_DESTINO = precioConvertido;
                    }
                }
                else
                {
                    if (campos.Contains(PrecioListaDestino_NombreCol))
                        row.PRECIO_LISTA_DESTINO = decimal.Parse(campos[PrecioListaDestino_NombreCol].ToString());
                    else
                        row.PRECIO_LISTA_DESTINO = row.PRECIO_LISTA_ORIGEN;
                }

                if (campos.Contains(VendedorComisionistaId_NombreCol))
                {
                    row.VENDEDOR_COMISIONISTA_ID = decimal.Parse(campos[VendedorComisionistaId_NombreCol].ToString());
                }
                else
                {
                    DataRow articuloRow = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + (decimal)campos[ArticuloId_NombreCol], string.Empty, false, pedidoRow.SUCURSAL_ID).Rows[0];
                    decimal familia_id = decimal.Parse(articuloRow[ArticulosService.FamiliaId_NombreCol].ToString());
                    decimal cliente_id = pedidoRow.PERSONA_ID;
                    decimal vendedor_id = vendedorClienteFamilia.GetVendedor(cliente_id, familia_id);
                    if (vendedor_id == Definiciones.Error.Valor.EnteroPositivo)
                    {
						if (!pedidoRow.IsVENDEDOR_IDNull)
							row.VENDEDOR_COMISIONISTA_ID = pedidoRow.VENDEDOR_ID;
                    }
                    else
                    {
                        row.VENDEDOR_COMISIONISTA_ID = vendedor_id;
                    }
                }
                //El monto bruto total es el precio bruto unitario por la cantidad de unidades
                row.TOTAL_MONTO_BRUTO = row.PRECIO_LISTA_DESTINO * row.CANTIDAD_TOTAL_ENTREGADA;

                //Es el total del monto descontado
                row.TOTAL_MONTO_DTO = row.MONTO_DESCUENTO * row.CANTIDAD_TOTAL_ENTREGADA;

                row.TOTAL_RECARGO_FINANCIERO = 0;
                //Si la operacion no es contado
                if (pedidoRow.TIPO_FACTURA_ID == Definiciones.TipoFactura.Credito)
                {
                    //Si el articulo tiene recargo financiero guardar el monto
                    if ((string)dtArticulos.Rows[0][ArticulosService.RecargoFinanciero_NombreCol] == Definiciones.SiNo.Si)
                    {
                        //Monto neto por recargo mensual por cantidad de pagos
                        // neto - neto / (1 + recargo * meses)
                        row.TOTAL_RECARGO_FINANCIERO = row.TOTAL_MONTO_BRUTO - row.TOTAL_MONTO_BRUTO /
                                                       (1 + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClientePorcentajeRecargoFinanciero) / 100 * CondicionesPagoService.GetCantidadPagos(pedidoRow.CONDICION_PAGO_ID));
                    }
                }

                row.TOTAL_NETO = (row.PRECIO_LISTA_DESTINO - row.MONTO_DESCUENTO) * row.CANTIDAD_TOTAL_ENTREGADA - row.TOTAL_RECARGO_FINANCIERO;

                //El total en concepto de impuesto es la diferencia entre el monto total con descuento
                //y el monto total neto
                decimal porcentajeImpuesto = ImpuestosService.GetPorcentajePorId(row.IMPUESTO_ID);
                row.PORCENTAJE_IMPUESTO = porcentajeImpuesto;
                if (porcentajeImpuesto > 0)
                {
                    row.TOTAL_MONTO_IMPUESTO = row.TOTAL_NETO / ((100 / porcentajeImpuesto) + 1);
                }
                else
                {
                    row.TOTAL_MONTO_IMPUESTO = 0;
                }

                if (CasosService.GetEstadoCaso(pedidoRow.CASO_ID, sesion) == Definiciones.EstadosFlujos.Borrador)
                {
                    row.CANTIDAD_CAJAS_PEDIDA = row.CANTIDAD_CAJAS_ENTREGADA;
                    row.CANTIDAD_UNITARIA_PEDIDA = row.CANTIDAD_UNITARIA_ENTREGADA;
                    row.CANTIDAD_TOTAL_PEDIDA = row.CANTIDAD_TOTAL_ENTREGADA;
                }

                if (!pedidoRow.IsVENDEDOR_IDNull)
                    row.PORCENTAJE_COMISION_VEN = regimenComisiones.ObtenerPorcentaje(row.ARTICULO_ID, DateTime.Now, row.VENDEDOR_COMISIONISTA_ID, pedidoRow.PERSONA_ID, pedidoRow.LISTA_PRECIO_ID, row.CANTIDAD_TOTAL_ENTREGADA, row.PORCENTAJE_DTO, false);
                else
                    row.PORCENTAJE_COMISION_VEN = Definiciones.Error.Valor.EnteroPositivo;

                if (row.PORCENTAJE_COMISION_VEN == Definiciones.Error.Valor.EnteroPositivo)
                {
                    row.PORCENTAJE_COMISION_VEN = 0;
                    row.MONTO_COMISION_VEN = 0;
                }
                else
                {
                    row.MONTO_COMISION_VEN = (row.PORCENTAJE_COMISION_VEN * (row.TOTAL_NETO - row.TOTAL_MONTO_IMPUESTO)) / 100;
                }
                
                // se calculan los costos de cada item o se pone a cero si no tiene costo

                //TODO Uri: columnas pendientes de ser borradas
                var costoPPP = CostosService.GetCosto(row.ARTICULO_ID, pedidoRow.DEPOSITO_ID, pedidoRow.FECHA, sesion);
                row.IsCOSTO_IDNull = true;
                row.COSTO_MONTO = costoPPP.costo;
                row.COSTO_MONEDA_ID = costoPPP.moneda_id;
                row.COSTO_MONEDA_COTIZACION = costoPPP.cotizacion;

                #region linea de credito
                //Si el caso no esta en   borrador, entonces debe afectarse la linea de credito
                if (CasosService.GetEstadoCaso(pedidoRow.CASO_ID, sesion) != Definiciones.EstadosFlujos.Borrador)
                {
                    //Si el caso afecta a la linea de credito
                    if (pedidoRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si)
                    {
                        decimal factor;
                        decimal variacion_afecta_linea;
                        PERSONASRow personaRow = sesion.Db.PERSONASCollection.GetByPrimaryKey(pedidoRow.PERSONA_ID);
                        decimal cotizacionLineaCredito = CotizacionesService.GetCotizacionMonedaVenta(personaRow.MONEDA_LIMITE_CREDITO_ID);

                        if (personaRow.MONEDA_LIMITE_CREDITO_ID == pedidoRow.MONEDA_DESTINO_ID)
                        {
                            factor = 1;
                        }
                        else
                        {
                            // El factor es la division entre la cotizacion venta de la moneda en que se encuentra la
                            //linea de credito, y la cotizacion utilizada en la NP
                            factor = cotizacionLineaCredito / pedidoRow.COTIZACION_DESTINO;
                        }

                        //Si es un detalle nuevo, se almacena la cotizacion de la moneda de la linea de credito
                        if (row.IsCOTIZACION_MONEDA_LINEA_CREDNull) row.COTIZACION_MONEDA_LINEA_CRED = cotizacionLineaCredito;

                        variacion_afecta_linea = (row.TOTAL_MONTO_DTO + row.TOTAL_RECARGO_FINANCIERO - monto_original_descuento - monto_original_recargo) * factor;

                        //Se actualiza en la cabecera el monto que afecta a la linea de credito
                        //en la moneda de la linea de credito
                        pedidoRow.MONTO_AFECTA_LINEA_CREDITO += variacion_afecta_linea;

                        //Se actualiza la linea de credito
                        personaRow.CONTADOR_CREDITO_ACTUAL += variacion_afecta_linea;

                        //Se redondea a 10 decimales
                        pedidoRow.MONTO_AFECTA_LINEA_CREDITO = Interprete.Redondear(pedidoRow.MONTO_AFECTA_LINEA_CREDITO, 10);
                        personaRow.CONTADOR_CREDITO_ACTUAL = Interprete.Redondear(personaRow.CONTADOR_CREDITO_ACTUAL, 10);

                        //Se actualiza la cotizacino de la moneda de la linea de credito, en el detalle
                        row.COTIZACION_MONEDA_LINEA_CRED = cotizacionLineaCredito;

                        //obtener la linea de credito
                        PersonasLineaCreditoService personasLineaCredito = new PersonasLineaCreditoService();
                        DataRow lineaCredito = personasLineaCredito.GetPersonasLineaCredito(personaRow.ID, sesion);
                        decimal lineaCreditoMonto = (decimal)lineaCredito[PersonasLineaCreditoService.MontoLineaCredito_NombreCol];

                        if (lineaCreditoMonto - CuentaCorrientePersonasService.GetSaldoPersonaEnDolares(personaRow.ID, sesion) * cotizacionLineaCredito < pedidoRow.TOTAL_MONTO_BRUTO_FINAL * factor)
                            throw new System.ArgumentException("La persona no cuenta con suficiente saldo en su línea de crédito.");

                        //Se guardan las modificaciones a personas y pedidos_cliente
                        sesion.Db.PERSONASCollection.Update(personaRow);
                        sesion.db.PEDIDOS_CLIENTECollection.Update(pedidoRow);
                        LogCambiosService.LogDeRegistro(NotasDePedidosService.Nombre_Tabla, pedidoRow.ID, valorAnteriorPedido, pedidoRow.ToString(), sesion);
                    }
                }
                #endregion linea de credito

                if (campos.Contains(NotasDePedidoDetalleService.Observacion_NombreCol))
                {
                    row.OBSERVACION = (string)campos[NotasDePedidoDetalleService.Observacion_NombreCol];
                }
               
                if (insertarNuevo) sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.Insert(row);
                else sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                if(recalcular_totales_cabecera)
                    NotasDePedidosService.RecalcularTotales(pedido_cliente_id, sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region Orden
        public static decimal Orden(decimal pedido_id)
        { 
            using (SessionService sesion = new SessionService())
            {
                return NotasDePedidoDetalleService.Orden(pedido_id, sesion);
            }
        }
        public static decimal Orden(decimal pedido_id, SessionService sesion)
        {
            PEDIDOS_CLIENTE_DETALLERow[] row = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPEDIDOS_CLIENTE_ID(pedido_id);
            decimal mayor = 0;
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i].ORDEN_DE_PRESENTACION > mayor)
                {
                    mayor = row[i].ORDEN_DE_PRESENTACION;
                }
            }

            return mayor;
        }
        #endregion Orden

        #region Borrar
        public static void Borrar(decimal pedido_cliente_detalle_id, decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                NotasDePedidoDetalleService.Borrar(pedido_cliente_detalle_id, caso_id, true, sesion);
            }
        }

        /// <summary>
        /// Borrars the specified pedido_cliente_detalle_id.
        /// </summary>
        /// <param name="pedido_cliente_detalle_id">The pedido_cliente_detalle_id.</param>
        private static void Borrar(decimal pedido_cliente_detalle_id, decimal caso_id, bool recalcular_totales_cabecera, SessionService sesion)
        {
            try
            {
                PEDIDOS_CLIENTE_DETALLERow row = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPrimaryKey(pedido_cliente_detalle_id);
                PEDIDOS_CLIENTERow pedidoRow = sesion.Db.PEDIDOS_CLIENTECollection.GetByPrimaryKey(row.PEDIDOS_CLIENTE_ID);
                PERSONASRow personaRow = sesion.Db.PERSONASCollection.GetByPrimaryKey(pedidoRow.PERSONA_ID);
                string valorAnteriorPedido = pedidoRow.ToString();
                //Si el caso no esta en estado borrador
                if (CasosService.GetEstadoCaso(pedidoRow.CASO_ID, sesion) != Definiciones.EstadosFlujos.Borrador)
                {
                    //Si el caso afecta a la linea de credito
                    if (pedidoRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si)
                    {
                        //Se modifica el saldo de la linea de credito en la moneda de la linea
                        personaRow.CONTADOR_CREDITO_ACTUAL -= row.TOTAL_MONTO_DTO / pedidoRow.COTIZACION_DESTINO * row.COTIZACION_MONEDA_LINEA_CRED;
                        pedidoRow.MONTO_AFECTA_LINEA_CREDITO -= row.TOTAL_MONTO_DTO / pedidoRow.COTIZACION_DESTINO * row.COTIZACION_MONEDA_LINEA_CRED;

                        //Se redondea a 10 decimales
                        personaRow.CONTADOR_CREDITO_ACTUAL = Interprete.Redondear(personaRow.CONTADOR_CREDITO_ACTUAL, MonedasService.CantidadDecimalesStatic(personaRow.MONEDA_LIMITE_CREDITO_ID));
                        pedidoRow.MONTO_AFECTA_LINEA_CREDITO = Interprete.Redondear(pedidoRow.MONTO_AFECTA_LINEA_CREDITO, MonedasService.CantidadDecimalesStatic(personaRow.MONEDA_LIMITE_CREDITO_ID));

                        //Se guardan las modificaciones a personas y pedidos_cliente
                        sesion.Db.PERSONASCollection.Update(personaRow);
                        sesion.db.PEDIDOS_CLIENTECollection.Update(pedidoRow);
                        LogCambiosService.LogDeRegistro(NotasDePedidosService.Nombre_Tabla, pedidoRow.ID, valorAnteriorPedido, pedidoRow.ToString(), sesion);
                    }
                }
              
                ActualizarOrden(row, sesion);

                (new NotasDePedidoDetalleItemsService()).BorrarPorItem(row.ID);

                sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.Delete(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                if(recalcular_totales_cabecera)
                    NotasDePedidosService.RecalcularTotales(row.PEDIDOS_CLIENTE_ID, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Borrar

        #region ActualizarOrden
        private static void ActualizarOrden(PEDIDOS_CLIENTE_DETALLERow detalle, SessionService sesion)
        {
            PEDIDOS_CLIENTE_DETALLERow[] detalles = NotasDePedidoDetalleService.GetPedidoDeClienteDetalleOrdenado(detalle.PEDIDOS_CLIENTE_ID);
            for (int i = (int)detalle.ORDEN_DE_PRESENTACION - 1; i < detalles.Length; i++)
            {
                detalles[i].ORDEN_DE_PRESENTACION--;
                sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.Update(detalles[i]);
            }
        }
        #endregion ActualizarOrden

        #region Verificar Repeticion

        /// <summary>
        /// Verificars the repetición.
        /// </summary>
        /// <param name="pedido_de_cliente_id">The pedido_de_cliente_id.</param>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="lote_id">The lote_id.</param>
        /// <returns></returns>
        public static bool VerificarRepeticion(decimal pedido_de_cliente_id, decimal lote_id, SessionService sesion)
        {
            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ControlarRepeticionEnDetallesDeVentas, sesion).Equals(Definiciones.SiNo.No))
                return false;

            PEDIDOS_CLIENTE_DETALLERow[] detalle = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPEDIDOS_CLIENTE_ID(pedido_de_cliente_id);
            for (int i = 0; i < detalle.Length; i++)
            {
                if (detalle[i].LOTE_ID == lote_id)
                    return true;
            }

            return false;
        }

        public static bool VerificarRepeticion(decimal pedido_de_cliente_id, decimal lote_id)
        {
            return VerificarRepeticion(pedido_de_cliente_id, lote_id, new SessionService());
        }
        #endregion Verificar Repeticion

        #region Get Suma Impuestos
        /// <summary>
        /// Obtener, por cada tipo de impuesto, la suma de los detalles del caso.
        /// </summary>
        /// <param name="pedido_de_cliente_id">The pedido_de_cliente_id.</param>
        /// <returns>
        /// DataTable de impuestos con una columna total indicando la suma para cada tipo de impuesto
        /// </returns>
        public DataTable GetSumaImpuestos(decimal pedido_de_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    PEDIDOS_CLIENTE_DETALLERow[] detalles; //Detalles del caso
                    DataTable impuestos; //Variable a ser devuelta por la funcion
                    DataRow dr; //Variable auxiliar

                    //Se obtienen los detalles del caso
                    detalles = sesion.Db.PEDIDOS_CLIENTE_DETALLECollection.GetByPEDIDOS_CLIENTE_ID(pedido_de_cliente_id);

                    //Se cargan los impuestos existentes en el sistema
                    impuestos = ImpuestosService.GetImpuestosDataTable();
                    impuestos.PrimaryKey = new DataColumn[] { impuestos.Columns[ImpuestosService.Id_NombreCol] };

                    //Se agrega la columna Total, que contendra la suma del monto en concepto
                    //de impuesto, por cada tipo de impuesto
                    impuestos.Columns.Add("TOTAL", typeof(Decimal));

                    //Se inicializa 
                    foreach (DataRow impuesto in impuestos.Rows) impuesto["TOTAL"] = 0;


                    foreach (PEDIDOS_CLIENTE_DETALLERow detalle in detalles)
                    {
                        //Se obtiene la fila correspondiente al tipo de impuesto
                        dr = impuestos.Rows.Find(detalle.IMPUESTO_ID);

                        //Se suma el impuesto correspondiente al detalle del caso
                        dr["TOTAL"] = (decimal)dr["TOTAL"] + detalle.TOTAL_MONTO_IMPUESTO;
                    }

                    return impuestos;
                }
                catch (Exception exp)
                {
                    throw exp;
                }

            }
        }
        #endregion Get Suma Impuestos       

        #region AprobacionPrecios
        public static void AprobacionPrecios(decimal nota_pedido_id, SessionService sesion, bool aprobar)
        {
            try
            {

                PEDIDOS_CLIENTE_DETALLERow[] pedidosDetallesRow = sesion.db.PEDIDOS_CLIENTE_DETALLECollection.GetByPEDIDOS_CLIENTE_ID(nota_pedido_id);
                for (int i = 0; i < pedidosDetallesRow.Length; i++)
                {
                    if (aprobar)
                    {
                        if (pedidosDetallesRow[i].IsPRECIO_UNITARIO_APROBADONull)
                        {
                            pedidosDetallesRow[i].PRECIO_UNITARIO_APROBADO = pedidosDetallesRow[i].PRECIO_LISTA_DESTINO;
                        }
                        else {
                            if (pedidosDetallesRow[i].PRECIO_LISTA_DESTINO < pedidosDetallesRow[i].PRECIO_UNITARIO_APROBADO)
                            {
                                pedidosDetallesRow[i].PRECIO_UNITARIO_APROBADO = pedidosDetallesRow[i].PRECIO_LISTA_DESTINO;
                            }
                        
                        }
                    }
                    else {
                        pedidosDetallesRow[i].IsPRECIO_UNITARIO_APROBADONull = true; 
                    }
                    sesion.db.PEDIDOS_CLIENTE_DETALLECollection.Update(pedidosDetallesRow[i]);
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion AprobacionPrecios

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PEDIDOS_CLIENTE_DETALLE"; }
        }
        public static string Nombre_Vista
        {
            get { return "PEDIDOS_CLIENTE_DET_INFO_COMPL"; }
        }
        public static string Id_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.IDColumnName; }
        }
        public static string ActivoId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.ACTIVO_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.ARTICULO_IDColumnName; }
        }
        public static string CantidadCajasEntregada_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.CANTIDAD_CAJAS_ENTREGADAColumnName; }
        }
        public static string CantidadPorCajaDestino_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.CANTIDAD_POR_CAJA_DESTINOColumnName; }
        }
        public static string CantidadUnitariaEntregada_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.CANTIDAD_UNITARIA_ENTREGADAColumnName; }
        }
        public static string CantidadTotalEntregada_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.CANTIDAD_TOTAL_ENTREGADAColumnName; }
        }
        public static string CotizacionMonedaLineaCred_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.COTIZACION_MONEDA_LINEA_CREDColumnName; }
        }
        public static string CotizacionOrigen_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.COTIZACION_ORIGENColumnName; }
        }
        public static string CostoMonedaCotizacion_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.COSTO_MONEDA_COTIZACIONColumnName; }
        }
        public static string ImpuestoPorcentaje_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.PORCENTAJE_IMPUESTOColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.IMPUESTO_IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoComisionVen_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.MONTO_COMISION_VENColumnName; }
        }
        public static string OrdenDePresentacion_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.ORDEN_DE_PRESENTACIONColumnName; }
        }
        public static string PedidosClienteId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.PEDIDOS_CLIENTE_IDColumnName; }
        }
        public static string PorcentajeComisionVen_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.PORCENTAJE_COMISION_VENColumnName; }
        }
        public static string PorcentajeDto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.PORCENTAJE_DTOColumnName; }
        }
        public static string Monto_Descuento_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.MONTO_DESCUENTOColumnName; }
        }
        public static string PrecioListaDestino_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.PRECIO_LISTA_DESTINOColumnName; }
        }
        public static string PrecioListaOrigen_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.PRECIO_LISTA_ORIGENColumnName; }
        }
        public static string TotalMontoBruto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.TOTAL_MONTO_BRUTOColumnName; }
        }
        public static string TotalMontoDto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.TOTAL_MONTO_DTOColumnName; }
        }
        public static string TotalMontoImpuesto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.TOTAL_MONTO_IMPUESTOColumnName; }
        }
        public static string TotalNeto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.TOTAL_NETOColumnName; }
        }
        public static string UnidadIdDestino_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.UNIDAD_DESTINO_IDColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.LOTE_IDColumnName; }
        }
        public static string VendedorComisionistaId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.VENDEDOR_COMISIONISTA_IDColumnName; }
        }
        public static string CantidadTotalPedida_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.CANTIDAD_TOTAL_PEDIDAColumnName; }
        }
        public static string CantidadUnitariaPedida_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.CANTIDAD_UNITARIA_PEDIDAColumnName; }
        }
        public static string CantidadCajasPedida_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.CANTIDAD_CAJAS_PEDIDAColumnName; }
        }
        public static string CantidadSubItemsFinal_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.CANTIDAD_SUBITEMS_FINALColumnName; }
        }
        public static string CostoMonto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.COSTO_MONTOColumnName; }
        }
        public static string CostoMonedaId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.COSTO_MONEDA_IDColumnName; }
        }
        public static string TotalRecargoFinanciero_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.TOTAL_RECARGO_FINANCIEROColumnName; }
        }
        public static string PrecioUnitarioAprobado_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.PRECIO_UNITARIO_APROBADOColumnName; }
        }
        public static string ConStock_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLECollection.CON_STOCKColumnName; }
        }
        public static string VistaCostoMonedaNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.COSTO_MONEDA_NOMBREColumnName; }
        }
        public static string VistaArticulo_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.ARTICULOColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloFamiliaNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.ARTICULO_FAMILIA_NOMBREColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.ARTICULO_GRUPO_IDColumnName; }
        }
        public static string VistaArticuloGrupoNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.ARTICULO_GRUPO_NOMBREColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.ARTICULO_SUBGRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.ARTICULO_SUBGRUPO_NOMBREColumnName; }
        }
        public static string VistaArticuloMarcaNombre_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.ARTICULO_MARCA_NOMBREColumnName; }
        }
        public static string VistaActivoCodigo_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.ACTIVO_CODIGOColumnName; }
        }
        public static string VistaMonedaOrigen_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.MONEDA_ORIGENColumnName; }
        }
        public static string VistaMonedaCantidadesDecimales_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.CADENA_DECIMALESColumnName; }
        }
        public static string VistaMonedaCantidadesDecimalesCosto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.CANTIDADES_DECIMALES_COSTOColumnName; }
        }
        public static string VistaMonedaCadenaDecimalesCosto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.CADENA_DECIMALES_COSTOColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.SIMBOLOColumnName; }
        }
        public static string VistaUnidad_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.UNIDAD_DESTINOColumnName; }
        }
        public static string VistaImpuesto_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.IMPUESTOColumnName; }
        }
        public static string VistaLote_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.LOTEColumnName; }
        }
        public static string VistaVendedorComisionista_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.VENDEDOR_COMISIONISTAColumnName; }
        }
        public static string VistaCodigoEmpresa_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.CODIGO_EMPRESAColumnName; }
        }
        public static string VistaCodigoBarrasEmpresa_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.CODIGO_BARRAS_EMPRESAColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DET_INFO_COMPLCollection.OBSERVACIONColumnName; }
        }
        #endregion Accessors
    }
}
