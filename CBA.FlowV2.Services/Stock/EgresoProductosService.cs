using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
using System.Data;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using System.Collections;

namespace CBA.FlowV2.Services.Stock
{
    public class EgresoProductosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.EGRESO_PRODUCTOS;
        }
        #endregion Implementacion de metodos abstract

        #region Getters
        public static DataTable GetEgresoProductosDataTable(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.EGRESO_PRODUCTOSCollection.GetAsDataTable(where, orderby);
            }
        }
        #endregion Getters

        #region ProcesarCambioEstado
        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza las acciones necesarias al cambiar de estado un caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="cambio_pedido_por_usuario">El cambio fue pedido por el usuario o por el sistema</param>
        /// <param name="mensaje">The mensaje de salida.</param>
        /// <returns>
        /// True si no los controles se ejecutaron exitosamente, si no false.
        /// </returns>
        public override bool ProcesarCambioEstado(decimal caso_id, string estado_destino, bool cambio_pedido_por_usuario, out string mensaje, SessionService sesion)
        {
            bool exito = false;
            bool revisarRequisitos = false;
            mensaje = "";
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                EGRESO_PRODUCTOSRow cabeceraRow = sesion.Db.EGRESO_PRODUCTOSCollection.GetByCASO_ID(caso_id)[0];
                EGRESO_PRODUCTOS_DETALLESRow[] detallesRows = sesion.Db.EGRESO_PRODUCTOS_DETALLESCollection.GetByEGRESO_PRODUCTO_ID(cabeceraRow.ID);
                INSUMOS_UTILIZADOSRow[] insumosRows = sesion.Db.INSUMOS_UTILIZADOSCollection.GetByEGRESO_PRODUCTO_ID(cabeceraRow.ID);
                EGRESO_PRODUCTOS_SOBRANTESRow[] sobrantesRows = sesion.Db.EGRESO_PRODUCTOS_SOBRANTESCollection.GetByEGRESO_PRODUCTO_ID(cabeceraRow.ID);

                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                //Borrador a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se genera el numero de comprobante

                    exito = true;
                    revisarRequisitos = true;
                    if (detallesRows.Length <= 0)
                    {
                        mensaje = "El egreso de productos no tiene detalles.";
                        exito = false;
                    }

                    #region Se genera el numero de comprobante
                    if (exito && cabeceraRow.NRO_COMPROBANTE == null)
                    {
                        try
                        {
                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID);

                            //Controlar que se logro asignar una numeracion
                            if (cabeceraRow.NRO_COMPROBANTE.Equals(""))
                            {
                                exito = false;
                                mensaje = "No se pudo asignar una numeración válida";
                            }
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }
                    #endregion Se genera el numero de comprobante
                }
                //Pendiente a Borrador 
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                }
                //Pendiente a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                                      

                    #region insumos utilizados
                    
                    #region Calculo de Cantidades segun detalles
                    //InsumosUtilizadosService.BorrarPorEgresoProductoId(cabeceraRow.ID, sesion);
                    decimal detalleCantidadTotal = 0;

                    foreach (EGRESO_PRODUCTOS_DETALLESRow det in detallesRows)
                    {
                        if ((det.CANTIDAD == 0) && (det.USAR_CANTIDAD == Definiciones.SiNo.Si) ||
                            (det.CANTIDAD_BASCULA == 0) && (det.USAR_CANTIDAD_BASCULA == Definiciones.SiNo.Si))
                        throw new Exception("La cantidad a usar no puede ser 0.");

                        if (det.USAR_CANTIDAD == Definiciones.SiNo.Si)
                            detalleCantidadTotal += (decimal)det.CANTIDAD;
                        else
                            detalleCantidadTotal += (decimal)det.CANTIDAD_BASCULA;
                    }
                    
                    #endregion Calculo de Cantidades segun detalles
                    /*
                    #region Recalculo de Insumos Según los datos de los detalles
                    ARTICULOSRow rowArticulo = ArticulosService.GetArticuloRowPorID(cabeceraRow.ARTICULO_ID, sesion);

                    DataTable dtFinal = new DataTable();
                    dtFinal.Clear();
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName);
                    Hashtable final = new Hashtable();

                    if (rowArticulo.ES_COMBO.Equals(Definiciones.SiNo.No))
                    {
                        #region Si no es Combo
                       
                            final.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName, cabeceraRow.ARTICULO_ID);
                            final.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName, cabeceraRow.UNIDAD_MEDIDA_ID);
                            final.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName, cabeceraRow.ID);
                            final.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName, cabeceraRow.CANTIDAD);
                            final.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName, cabeceraRow.LOTE_ID);
                        
                        #endregion Si no es Combo
                    }
                    else
                    {
                        #region Si  es Combo
                        //primero traemos los insumos que se utilizan en ese combo
                        DataTable dtInsumos = ArticulosCombosService.GetArticulosCombosDataTable(ArticulosCombosService.ArticuloComboId_NombreCol + " = " + cabeceraRow.ARTICULO_ID, sesion);
                        foreach (DataRow insumo in dtInsumos.Rows)
                        {
                            decimal cantidadInsumoNecesario = (detalleCantidadTotal * (decimal)insumo[ArticulosCombosService.CantidadDestino_NombreCol]);

                            DataTable dtlotes;
                            dtlotes = ArticulosLotesService.GetArticulosLotes(ArticulosLotesService.Articulo_ID_NombreCol + " = " + insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol].ToString() +
                                " and " + ArticulosLotesService.Persona_Id_NombreCol + " = " + cabeceraRow.PERSONA_ID, ArticulosLotesService.Fecha_NombreCol, sesion);

                           


                            for (int i = 0; i < dtlotes.Rows.Count; i++)
                            {
                                if (cantidadInsumoNecesario == 0)
                                    continue;
                                DataRow drLote = dtFinal.NewRow();
                                decimal cantidadPorLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote((decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol], cabeceraRow.DEPOSITO_ID, sesion);

                                if (cantidadPorLote <= 0)
                                    continue;

                                if (cantidadPorLote < cantidadInsumoNecesario)
                                {
                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = cabeceraRow.ID;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadPorLote;
                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                    dtFinal.Rows.Add(drLote);
                                    cantidadInsumoNecesario -= cantidadPorLote;
                                }
                                else
                                {
                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = cabeceraRow.ID;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadInsumoNecesario;
                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                    dtFinal.Rows.Add(drLote);
                                    cantidadInsumoNecesario = 0;
                                }

                            }

                        }
                        #endregion Si  es Combo
                    }


                    #region insertar insumos utilizados
                    
                    if (rowArticulo.ES_COMBO == Definiciones.SiNo.Si)
                    {
                        foreach (DataRow dr in dtFinal.Rows)
                        {
                            Hashtable producto = new Hashtable();
                            producto.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName].ToString()));
                            producto.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName, dr[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString());
                            producto.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName].ToString()));
                            producto.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.CANTIDADColumnName].ToString()));
                            producto.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.LOTE_IDColumnName].ToString()));
                            InsumosUtilizadosService.Guardar(producto, true, sesion);
                        }
                    }
                    else
                        InsumosUtilizadosService.Guardar(final, true, sesion);

                    #endregion insertar insumos utilizados

                    #endregion Recalculo de Insumos Según los datos
                     */           
                    #endregion insumos utilizados
                    insumosRows = sesion.Db.INSUMOS_UTILIZADOSCollection.GetAsArray(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName+"="+cabeceraRow.ID,InsumosUtilizadosService.Modelo.LOTE_IDColumnName);
                    decimal faltante = 0;
                    decimal anterior = Definiciones.Error.Valor.EnteroPositivo;
                    foreach (INSUMOS_UTILIZADOSRow insumos in insumosRows)
                    {
                        
                        
                        if(anterior.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            anterior=insumos.ARTICULO_ID;

                        if (!insumos.ARTICULO_ID.Equals(anterior))
                        {
                            anterior = insumos.ARTICULO_ID;
                             faltante = 0;
                         }
                       
                        

                        //DataTable dtInsumos = ArticulosCombosService.GetArticulosCombosDataTable(ArticulosCombosService.ArticuloComboId_NombreCol + " = " + cabeceraRow.ARTICULO_ID, sesion);
                        insumos.CANTIDAD = decimal.Round((detalleCantidadTotal * insumos.CANTIDAD_NOMINAL) / cabeceraRow.CANTIDAD,4);
                        var al = new ArticulosLotesService(insumos.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;
                        decimal cantidadExistencia = StockService.getStockArticuloLoteDeposito(insumos.LOTE_ID, cabeceraRow.DEPOSITO_ID, sesion);

                        if (cantidadExistencia < insumos.CANTIDAD + faltante)
                        {
                            faltante += insumos.CANTIDAD - cantidadExistencia;
                            insumos.CANTIDAD = insumos.CANTIDAD_NOMINAL;
                        }
                        else {
                            if (faltante > 0)
                            {
                                insumos.CANTIDAD = insumos.CANTIDAD + faltante;
                            }
                        }
                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    insumos.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Venta, caso_id, insumos.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    insumos.ID);
                        al.FinalizarUsingSesion();
                        sesion.Db.INSUMOS_UTILIZADOSCollection.Update(insumos);
                    }
                     
                    foreach (EGRESO_PRODUCTOS_SOBRANTESRow sobrantes in sobrantesRows)
                    {
                        var al = new ArticulosLotesService(sobrantes.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    sobrantes.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, sobrantes.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    sobrantes.ID);
                        al.FinalizarUsingSesion();
                    }

                    foreach (EGRESO_PRODUCTOS_DETALLESRow detalles in detallesRows)
                    {
                        EGRESO_PROD_DET_MATERIALESRow[] materialesRow = sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.GetByEGRESO_PRODUCTO_DET_ID(detalles.ID);
                        foreach (EGRESO_PROD_DET_MATERIALESRow materiales in materialesRow)
                        {
                            var al = new ArticulosLotesService(materiales.LOTE_ID, sesion);
                            al.IniciarUsingSesion(sesion);
                            StockService.Costo costo = null;

                            StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                        al.ArticuloId,
                                                        materiales.CANTIDAD,
                                                        Definiciones.Stock.TipoMovimiento.Venta, caso_id, materiales.LOTE_ID, estado_destino,
                                                        sesion,
                                                        costo,
                                                        al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                        materiales.ID);
                            al.FinalizarUsingSesion();
                        }
                    }
                    //Acciones
                    //Se egresa el producto del stock
                    exito = true;
                    revisarRequisitos = true; 
                }
                //Aprobado a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se revierte el egreso del producto del stock
                    revisarRequisitos = true;
                    exito = true;                  

                    foreach (INSUMOS_UTILIZADOSRow insumos in insumosRows)
                    {
                        var al = new ArticulosLotesService(insumos.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -insumos.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Venta, caso_id, insumos.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    insumos.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (EGRESO_PRODUCTOS_SOBRANTESRow sobrantes in sobrantesRows)
                    {
                        var al = new ArticulosLotesService(sobrantes.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -sobrantes.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, sobrantes.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    sobrantes.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (EGRESO_PRODUCTOS_DETALLESRow detalles in detallesRows)
                    {
                        EGRESO_PROD_DET_MATERIALESRow[] materialesRow = sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.GetByEGRESO_PRODUCTO_DET_ID(detalles.ID);
                        foreach (EGRESO_PROD_DET_MATERIALESRow materiales in materialesRow)
                        {
                            var al = new ArticulosLotesService(materiales.LOTE_ID, sesion);
                            al.IniciarUsingSesion(sesion);
                            StockService.Costo costo = null;

                            StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                        al.ArticuloId,
                                                        -materiales.CANTIDAD,
                                                        Definiciones.Stock.TipoMovimiento.Venta, caso_id, materiales.LOTE_ID, estado_destino,
                                                        sesion,
                                                        costo,
                                                        al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                        materiales.ID, true);
                            al.FinalizarUsingSesion();
                        }
                    }
                }
                //Aprobado a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Se revierte el egreso del producto del stock
                    revisarRequisitos = true;
                    exito = true;                  

                    foreach (INSUMOS_UTILIZADOSRow insumos in insumosRows)
                    {
                        var al = new ArticulosLotesService(insumos.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -insumos.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Venta, caso_id, insumos.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    insumos.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (EGRESO_PRODUCTOS_SOBRANTESRow sobrantes in sobrantesRows)
                    {
                        var al = new ArticulosLotesService(sobrantes.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -sobrantes.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, sobrantes.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    sobrantes.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (EGRESO_PRODUCTOS_DETALLESRow detalles in detallesRows)
                    {
                        EGRESO_PROD_DET_MATERIALESRow[] materialesRow = sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.GetByEGRESO_PRODUCTO_DET_ID(detalles.ID);
                        foreach (EGRESO_PROD_DET_MATERIALESRow materiales in materialesRow)
                        {
                            var al = new ArticulosLotesService(materiales.LOTE_ID, sesion);
                            al.IniciarUsingSesion(sesion);
                            StockService.Costo costo = null;

                            StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                        al.ArticuloId,
                                                        -materiales.CANTIDAD,
                                                        Definiciones.Stock.TipoMovimiento.Venta, caso_id, materiales.LOTE_ID, estado_destino,
                                                        sesion,
                                                        costo,
                                                        al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                        materiales.ID, true);
                            al.FinalizarUsingSesion();
                        }
                    }
                }
                //Aprobado a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se revierte el egreso del producto del stock
                    revisarRequisitos = true;
                    exito = true;                   

                    foreach (INSUMOS_UTILIZADOSRow insumos in insumosRows)
                    {
                        var al = new ArticulosLotesService(insumos.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -insumos.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Venta, caso_id, insumos.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    insumos.ID,true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (EGRESO_PRODUCTOS_SOBRANTESRow sobrantes in sobrantesRows)
                    {
                        var al = new ArticulosLotesService(sobrantes.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -sobrantes.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, sobrantes.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    sobrantes.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (EGRESO_PRODUCTOS_DETALLESRow detalles in detallesRows)
                    {
                        EGRESO_PROD_DET_MATERIALESRow[] materialesRow = sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.GetByEGRESO_PRODUCTO_DET_ID(detalles.ID);
                        foreach (EGRESO_PROD_DET_MATERIALESRow materiales in materialesRow)
                        {
                            var al = new ArticulosLotesService(materiales.LOTE_ID, sesion);
                            al.IniciarUsingSesion(sesion);
                            StockService.Costo costo = null;

                            StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                        al.ArticuloId,
                                                        -materiales.CANTIDAD,
                                                        Definiciones.Stock.TipoMovimiento.Venta, caso_id, materiales.LOTE_ID, estado_destino,
                                                        sesion,
                                                        costo,
                                                        al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                        materiales.ID, true);
                            al.FinalizarUsingSesion();
                        }
                    }
                }
                //Aprobado a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Se revierte el egreso del producto del stock
                    revisarRequisitos = true;
                    exito = true;                   

                    foreach (INSUMOS_UTILIZADOSRow insumos in insumosRows)
                    {
                        var al = new ArticulosLotesService(insumos.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -insumos.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Venta, caso_id, insumos.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    insumos.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (EGRESO_PRODUCTOS_SOBRANTESRow sobrantes in sobrantesRows)
                    {
                        var al = new ArticulosLotesService(sobrantes.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -sobrantes.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Compra, caso_id, sobrantes.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    sobrantes.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (EGRESO_PRODUCTOS_DETALLESRow detalles in detallesRows)
                    {
                        EGRESO_PROD_DET_MATERIALESRow[] materialesRow = sesion.Db.EGRESO_PROD_DET_MATERIALESCollection.GetByEGRESO_PRODUCTO_DET_ID(detalles.ID);
                        foreach (EGRESO_PROD_DET_MATERIALESRow materiales in materialesRow)
                        {
                            var al = new ArticulosLotesService(materiales.LOTE_ID, sesion);
                            al.IniciarUsingSesion(sesion);
                            StockService.Costo costo = null;

                            StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                        al.ArticuloId,
                                                        -materiales.CANTIDAD,
                                                        Definiciones.Stock.TipoMovimiento.Venta, caso_id, materiales.LOTE_ID, estado_destino,
                                                        sesion,
                                                        costo,
                                                        al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                        materiales.ID, true);
                            al.FinalizarUsingSesion();
                        }
                    }
                }
                //Borrador a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                //Pendiente a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Ninguna
                    exito = true;
                    revisarRequisitos = true;
                }
                if (exito && revisarRequisitos)
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.EGRESO_PRODUCTOSCollection.Update(cabeceraRow);
                } 
            }
            catch (Exception exp)
            {
                exito = false;
                throw exp;
            }
            return exito;
        }
        #endregion ProcesarCambioEstado

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (!campos.Contains(EgresoProductosService.Modelo.SUCURSAL_IDColumnName))
                        throw new Exception("Debe indicar la sucursal.");
                    if (!campos.Contains(EgresoProductosService.Modelo.DEPOSITO_IDColumnName))
                        throw new Exception("Debe indicar la deposito.");
                    if (!campos.Contains(EgresoProductosService.Modelo.PERSONA_IDColumnName))
                        throw new Exception("Debe indicar el cliente.");
                    if (!campos.Contains(EgresoProductosService.Modelo.ARTICULO_IDColumnName))
                        throw new Exception("Debe indicar el articulo.");

                    EGRESO_PRODUCTOSRow row = new EGRESO_PRODUCTOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                        row.ID = sesion.Db.GetSiguienteSecuencia("egreso_productos_sqc");                        
                    else
                    {
                        row = sesion.Db.EGRESO_PRODUCTOSCollection.GetRow(EgresoProductosService.Modelo.IDColumnName + " = " + campos[EgresoProductosService.Modelo.IDColumnName]);
                        valorAnterior = row.ToString();
                    }                       

                    if (!Interprete.EsNullODBNull(EgresoProductosService.Modelo.SUCURSAL_IDColumnName))
                        row.SUCURSAL_ID = (decimal)campos[EgresoProductosService.Modelo.SUCURSAL_IDColumnName];
                    else
                        throw new Exception("Valor no admitido en sucursal");
                    
                    if (!Interprete.EsNullODBNull(EgresoProductosService.Modelo.DEPOSITO_IDColumnName))
                        row.DEPOSITO_ID = (decimal)campos[EgresoProductosService.Modelo.DEPOSITO_IDColumnName];
                    else
                        throw new Exception("Valor no admitido en deposito");                               

                    if (!Interprete.EsNullODBNull(EgresoProductosService.Modelo.PERSONA_IDColumnName))
                        row.PERSONA_ID = (decimal)campos[EgresoProductosService.Modelo.PERSONA_IDColumnName];
                    else
                        throw new Exception("Valor no admitido en cliente");

                    if (!Interprete.EsNullODBNull(EgresoProductosService.Modelo.ARTICULO_IDColumnName))
                        row.ARTICULO_ID = (decimal)campos[EgresoProductosService.Modelo.ARTICULO_IDColumnName];
                    else
                        throw new Exception("Valor no admitido en articulo");
                    if (campos.Contains(EgresoProductosService.Modelo.LOTE_IDColumnName))
                        row.LOTE_ID = (decimal)campos[EgresoProductosService.Modelo.LOTE_IDColumnName];

                    row.UNIDAD_MEDIDA_ID = campos[EgresoProductosService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString();                   
                    row.CANTIDAD = (decimal)campos[EgresoProductosService.Modelo.CANTIDADColumnName];
                    if (campos.Contains(EgresoProductosService.Modelo.FECHA_SOLICITUDColumnName))
                        row.FECHA_SOLICITUD = (DateTime)campos[EgresoProductosService.Modelo.FECHA_SOLICITUDColumnName];

                    if (campos.Contains(EgresoProductosService.Modelo.AUTONUMERACION_IDColumnName))
                    {
                        if (!Interprete.EsNullODBNull(EgresoProductosService.Modelo.AUTONUMERACION_IDColumnName))
                        {
                            if (AutonumeracionesService.EstaActivo((decimal)campos[EgresoProductosService.Modelo.AUTONUMERACION_IDColumnName]))
                                row.AUTONUMERACION_ID = (decimal)campos[EgresoProductosService.Modelo.AUTONUMERACION_IDColumnName];
                            else
                                throw new Exception("El talonario deseado está inactivo.");
                        }
                        else
                        {
                            row.IsAUTONUMERACION_IDNull = true;
                        }
                    }
                    else
                    {
                        row.IsAUTONUMERACION_IDNull = true;
                    }

                    if (campos.Contains(EgresoProductosService.Modelo.NRO_COMPROBANTEColumnName))
                        row.NRO_COMPROBANTE = (string)campos[EgresoProductosService.Modelo.NRO_COMPROBANTEColumnName];
                    if (campos.Contains(EgresoProductosService.Modelo.PRESENTACION_IDColumnName))
                        row.PRESENTACION_ID = (decimal)campos[EgresoProductosService.Modelo.PRESENTACION_IDColumnName];
                    if (campos.Contains(EgresoProductosService.Modelo.CANTIDAD_PRESENTACIONColumnName))
                        row.CANTIDAD_PRESENTACION = (decimal)campos[EgresoProductosService.Modelo.CANTIDAD_PRESENTACIONColumnName];
                    if (campos.Contains(EgresoProductosService.Modelo.MONEDA_IDColumnName))
                        row.MONEDA_ID = (decimal)campos[EgresoProductosService.Modelo.MONEDA_IDColumnName];
                    if (campos.Contains(EgresoProductosService.Modelo.PRECIOColumnName))
                        row.PRECIO = 0;

                    #region insumos utilizados
                    ARTICULOSRow rowArticulo = ArticulosService.GetArticuloRowPorID(row.ARTICULO_ID, sesion);

                    DataTable dtFinal = new DataTable();
                    dtFinal.Clear();
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName);
                    Hashtable final = new Hashtable();

                    #region Nuevo Codigo de Calculo
                    #region Si es una edicion
                    //if (!insertarNuevo)
                    //{
                    //    if (row.ToString() != valorAnterior)
                    //    {
                            InsumosUtilizadosService.BorrarPorEgresoProductoId(row.ID, sesion);
                    //    }
                    //}
                    #endregion Si es una edicion


                    if (rowArticulo.ES_COMBO.Equals(Definiciones.SiNo.No))
                    {
                        #region Si no es Combo
                        //decimal cantLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, row.DEPOSITO_ID, sesion);
                       
                        //if (cantLote < row.CANTIDAD)
                        //{
                        //    throw new Exception("Cantidad insuficiente");
                        //}
                        //else
                        //{
                        //    final.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName, row.ARTICULO_ID);
                        //    final.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName, row.UNIDAD_MEDIDA_ID);
                        //    final.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName, row.ID);
                        //    final.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName, row.CANTIDAD);
                        //    final.Add(InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName, row.CANTIDAD);
                        //    final.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName, row.LOTE_ID);
                        //}
                        #endregion Si no es Combo

                        #region Si  es Combo

                        decimal cantidadInsumoNecesario = row.CANTIDAD;
                           DataTable dtlotes;
                            dtlotes = ArticulosLotesService.GetArticulosLotes(ArticulosLotesService.Articulo_ID_NombreCol + " = " + row.ARTICULO_ID, ArticulosLotesService.Fecha_NombreCol, sesion);

                            if (dtlotes.Rows.Count <= 0)
                                throw new Exception("No existe lote");
                            //obtenemos el total de existencia del articulo
                            decimal totalArticulo = StockArticulosReservaService.GetReserva_Segun_Articulo_Id(row.ARTICULO_ID, row.DEPOSITO_ID, sesion);

                            //comparamos si existe la cantidad necesaria
                            if (totalArticulo < cantidadInsumoNecesario)
                            {
                                string articulo = ArticulosService.GetArticuloCodigoEmpresa(row.ARTICULO_ID);
                                throw new Exception("Cantidad insuficiente del articulo " + articulo);
                            }



                            for (int i = 0; i < dtlotes.Rows.Count; i++)
                            {
                                if (cantidadInsumoNecesario == 0)
                                    continue;
                                DataRow drLote = dtFinal.NewRow();
                                decimal cantidadPorLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote((decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol], row.DEPOSITO_ID, sesion);

                                if (cantidadPorLote <= 0)
                                    continue;

                                if (cantidadPorLote < cantidadInsumoNecesario)
                                {
                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = row.ARTICULO_ID;
                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = row.UNIDAD_MEDIDA_ID;
                                    drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = row.ID;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadPorLote;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadPorLote;
                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                    dtFinal.Rows.Add(drLote);
                                    cantidadInsumoNecesario -= cantidadPorLote;
                                }
                                else
                                {
                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = row.ARTICULO_ID;
                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = row.UNIDAD_MEDIDA_ID;
                                    drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = row.ID;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadInsumoNecesario;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadInsumoNecesario;
                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                    dtFinal.Rows.Add(drLote);
                                    cantidadInsumoNecesario = 0;
                                }

                            }

                        
                        #endregion Si  es Combo
                    }
                    else
                    {
                        #region Si  es Combo
                        //primero traemos los insumos que se utilizan en ese combo
                        DataTable dtInsumos = ArticulosCombosService.GetArticulosCombosDataTable(ArticulosCombosService.ArticuloComboId_NombreCol + " = " + row.ARTICULO_ID, sesion);
                        foreach (DataRow insumo in dtInsumos.Rows)
                        {
                            decimal cantidadInsumoNecesario = (row.CANTIDAD * (decimal)insumo[ArticulosCombosService.CantidadDestino_NombreCol]);

                            DataTable dtlotes;
                            dtlotes = ArticulosLotesService.GetArticulosLotes(ArticulosLotesService.Articulo_ID_NombreCol + " = " + insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol].ToString(), 
                                ArticulosLotesService.Fecha_NombreCol, sesion);

                            if (dtlotes.Rows.Count <= 0)
                                throw new Exception("No existe lote");
                            //obtenemos el total de existencia del articulo
                            decimal totalArticulo = StockArticulosReservaService.GetReserva_Segun_Articulo_Id(decimal.Parse(insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol].ToString()), row.DEPOSITO_ID, sesion);

                            //comparamos si existe la cantidad necesaria
                            if (totalArticulo < cantidadInsumoNecesario)
                            {
                                string articulo = ArticulosService.GetArticuloCodigoEmpresa(decimal.Parse(insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol].ToString()));
                                throw new Exception("Cantidad insuficiente del articulo " + articulo);
                            }


                            
                            for (int i = 0; i < dtlotes.Rows.Count; i++)
                            {
                                if (cantidadInsumoNecesario == 0)
                                    continue;
                                DataRow drLote = dtFinal.NewRow();
                                decimal cantidadPorLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote((decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol], row.DEPOSITO_ID, sesion);

                                if (cantidadPorLote <= 0)
                                    continue;

                                if (cantidadPorLote < cantidadInsumoNecesario)
                                {
                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = row.ID;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadPorLote;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadPorLote;
                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                    dtFinal.Rows.Add(drLote);
                                    cantidadInsumoNecesario -= cantidadPorLote;
                                }
                                else
                                {
                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = row.ID;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadInsumoNecesario;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadInsumoNecesario;
                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                    dtFinal.Rows.Add(drLote);
                                    cantidadInsumoNecesario = 0;
                                }

                            }

                        }
                        #endregion Si  es Combo
                    }
                    //foreach (DataRow dr in dtFinal.Rows)
                    //{
                    //    Hashtable producto = new Hashtable();
                    //    producto.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName].ToString()));
                    //    producto.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName, dr[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString());
                    //    producto.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName].ToString()));
                    //    producto.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.CANTIDADColumnName].ToString()));
                    //    producto.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.LOTE_IDColumnName].ToString()));
                    //    InsumosUtilizadosService.Guardar(producto, true, sesion);
                    //}
                    #endregion Nuevo Codigo de Calculo

                    #region Codigo Viejo
                    //if (!insertarNuevo)
                    //{
                    //    if (row.ToString() != valorAnterior)
                    //    {
                    //        using (SessionService sesionEditar = new SessionService())
                    //        {
                    //            try
                    //            {
                    //                sesionEditar.Db.BeginTransaction();
                    //                InsumosUtilizadosService.BorrarPorEgresoProductoId(row.ID, sesionEditar);

                    //                //si es combo, se buscan los articulos que son los insumos y que lote va a usar
                    //                if (rowArticulo.ES_COMBO == Definiciones.SiNo.Si)
                    //                {
                    //                    DataTable dtInsumos = ArticulosCombosService.GetArticulosCombosDataTable(ArticulosCombosService.ArticuloComboId_NombreCol + " = " + row.ARTICULO_ID, sesionEditar);

                    //                    foreach (DataRow insumo in dtInsumos.Rows)
                    //                    {
                    //                        DataTable lotes;
                    //                        lotes = ArticulosLotesService.GetArticulosLotesOrderById(ArticulosLotesService.Articulo_ID_NombreCol + " = " + insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol].ToString() +
                    //                            " and " + ArticulosLotesService.Persona_Id_NombreCol + " = " + row.PERSONA_ID, sesionEditar);

                    //                        if (lotes.Rows.Count <= 0)
                    //                            throw new Exception("No existe lote para este cliente");

                    //                        DataTable dtLotes = dtFinal.Clone();
                    //                        decimal cantidadLoteTotal = (row.CANTIDAD * (decimal)insumo[ArticulosCombosService.CantidadDestino_NombreCol]);
                                            
                    //                        for (int i = 0; i < lotes.Rows.Count; i++)
                    //                        {
                    //                            if (cantidadLoteTotal == 0)
                    //                                continue;
                    //                            DataRow drLote = dtLotes.NewRow();
                    //                            decimal cantLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote((decimal)lotes.Rows[i][ArticulosLotesService.Id_NombreCol], row.DEPOSITO_ID, sesionEditar);

                    //                            if (cantLote <= 0)
                    //                            {
                    //                                if (i + 1 == lotes.Rows.Count)
                    //                                {
                    //                                    string articulo = ArticulosService.GetArticuloCodigoEmpresa((decimal)lotes.Rows[0][ArticulosLotesService.Articulo_ID_NombreCol]);
                    //                                    throw new Exception("Cantidad insuficiente del articulo " + articulo);
                    //                                }
                    //                            }
                    //                            else
                    //                                if (cantLote < cantidadLoteTotal)
                    //                                {
                    //                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                    //                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                    //                                    drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = row.ID;
                    //                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantLote;
                    //                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)lotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                    //                                    dtLotes.Rows.Add(drLote);
                    //                                    cantidadLoteTotal -= cantLote;
                    //                                }
                    //                                else
                    //                                {
                    //                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                    //                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                    //                                    drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = row.ID;
                    //                                    //if (i != 0)
                    //                                    //{
                    //                                    //    //decimal auxCantLote = row.CANTIDAD * (decimal)insumo[ArticulosCombosService.CantidadDestino_NombreCol];

                    //                                    //    //if (dtLotes.Rows.Count > 0)
                    //                                    //    //{
                    //                                    //    //    if (dtLotes.Rows[dtLotes.Rows.Count - 1][InsumosUtilizadosService.Modelo.CANTIDADColumnName] != System.DBNull.Value)
                    //                                    //    //        cantidadLoteTotal -= decimal.Parse(dtLotes.Rows[dtLotes.Rows.Count - 1][InsumosUtilizadosService.Modelo.CANTIDADColumnName].ToString());
                    //                                    //    //}

                    //                                    //    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadLoteTotal;
                    //                                    //}
                    //                                    //else
                    //                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadLoteTotal;

                    //                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)lotes.Rows[i][ArticulosLotesService.Id_NombreCol];

                    //                                    cantidadLoteTotal = 0;
                    //                                    dtLotes.Rows.Add(drLote);
                    //                                    break;
                    //                                }
                    //                        }

                    //                        decimal cantidadTotal = 0;
                    //                        for (int i = 0; i < dtLotes.Rows.Count; i++)
                    //                        {
                    //                            if (dtLotes.Rows[i][InsumosUtilizadosService.Modelo.CANTIDADColumnName] != System.DBNull.Value)
                    //                                cantidadTotal += decimal.Parse(dtLotes.Rows[i][InsumosUtilizadosService.Modelo.CANTIDADColumnName].ToString());
                    //                        }

                    //                        if (cantidadTotal < (row.CANTIDAD * (decimal)insumo[ArticulosCombosService.CantidadDestino_NombreCol]))                                                
                    //                        {
                    //                            string articulo = ArticulosService.GetArticuloCodigoEmpresa((decimal)lotes.Rows[0][ArticulosLotesService.Articulo_ID_NombreCol]);
                    //                            throw new Exception("Cantidad insuficiente del articulo " + articulo);
                    //                        }
                    //                        else
                    //                            foreach (DataRow dr in dtLotes.Rows)
                    //                            {
                    //                                if (dtLotes.Rows[0][InsumosUtilizadosService.Modelo.CANTIDADColumnName] != System.DBNull.Value)
                    //                                {
                    //                                    dtFinal.ImportRow(dr);
                    //                                }
                    //                            }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    decimal cantLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, row.DEPOSITO_ID, sesionEditar);

                    //                    if (cantLote < row.CANTIDAD)
                    //                    {
                    //                        throw new Exception("Cantidad insuficiente");
                    //                    }
                    //                    else
                    //                    {
                    //                        final.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName, row.ARTICULO_ID);
                    //                        final.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName, row.UNIDAD_MEDIDA_ID);
                    //                        final.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName, row.ID);
                    //                        final.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName, row.CANTIDAD);
                    //                        final.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName, row.LOTE_ID);
                    //                    }
                    //                }                               

                    //                if (rowArticulo.ES_COMBO == Definiciones.SiNo.Si)
                    //                {
                    //                    foreach (DataRow dr in dtFinal.Rows)
                    //                    {
                    //                        Hashtable producto = new Hashtable();
                    //                        producto.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName].ToString()));
                    //                        producto.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName, dr[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString());
                    //                        producto.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName].ToString()));
                    //                        producto.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.CANTIDADColumnName].ToString()));
                    //                        producto.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.LOTE_IDColumnName].ToString()));
                    //                        InsumosUtilizadosService.Guardar(producto, true, sesionEditar);
                    //                    }
                    //                }
                    //                else
                    //                    InsumosUtilizadosService.Guardar(final, true, sesionEditar);

                    //                sesionEditar.Db.CommitTransaction();
                    //            }
                    //            catch (Exception e)
                    //            {
                    //                sesionEditar.Db.RollbackTransaction();
                    //                throw e;
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    //si es combo, se buscan los articulos que son los insumos y que lote va a usar
                    //    if (rowArticulo.ES_COMBO == Definiciones.SiNo.Si)
                    //    {
                    //        DataTable dtInsumos = ArticulosCombosService.GetArticulosCombosDataTable(ArticulosCombosService.ArticuloComboId_NombreCol + " = " + row.ARTICULO_ID, sesion);

                    //        foreach (DataRow insumo in dtInsumos.Rows)
                    //        {
                    //            DataTable lotes;
                    //            lotes = ArticulosLotesService.GetArticulosLotesOrderById(ArticulosLotesService.Articulo_ID_NombreCol + " = " + insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol].ToString() +
                    //                " and " + ArticulosLotesService.Persona_Id_NombreCol + " = " + row.PERSONA_ID, sesion);

                    //            if (lotes.Rows.Count <= 0)
                    //            {
                    //                string articulo = ArticulosService.GetArticuloCodigoEmpresa((decimal)lotes.Rows[0][ArticulosLotesService.Articulo_ID_NombreCol]);
                    //                throw new Exception("No existe lote del articulo " + articulo  + " para este cliente");
                    //            }
                    //            DataTable dtLotes = dtFinal.Clone();
                    //            decimal cantidadLoteTotal = (row.CANTIDAD * (decimal)insumo[ArticulosCombosService.CantidadDestino_NombreCol]);
                    //            for (int i = 0; i < lotes.Rows.Count; i++)
                    //            {
                    //                DataRow drLote = dtLotes.NewRow();
                    //                decimal cantLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote((decimal)lotes.Rows[i][ArticulosLotesService.Id_NombreCol], row.DEPOSITO_ID, sesion);

                    //                if (cantLote <= 0)
                    //                {
                    //                    if (i + 1 == lotes.Rows.Count)
                    //                    {
                    //                        string articulo = ArticulosService.GetArticuloCodigoEmpresa((decimal)lotes.Rows[0][ArticulosLotesService.Articulo_ID_NombreCol]);                                            
                    //                        throw new Exception("Cantidad insuficiente del articulo " + articulo) ;                                            
                    //                    }
                    //                }
                    //                else{
                    //                    if (cantidadLoteTotal <= 0)
                    //                        continue;
                    //                    if (cantLote <= cantidadLoteTotal)
                    //                    {
                    //                        drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                    //                        drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                    //                        drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = row.ID;
                    //                        drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantLote;
                    //                        drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)lotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                    //                        dtLotes.Rows.Add(drLote);
                    //                        cantidadLoteTotal -= cantLote;
                    //                    }
                    //                    else
                    //                    {
                    //                        drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                    //                        drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                    //                        drLote[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName] = row.ID;
                    //                        if (i != 0)
                    //                        {
                    //                           // decimal auxCantLote = row.CANTIDAD * (decimal)insumo[ArticulosCombosService.CantidadDestino_NombreCol];

                    //                            if (dtLotes.Rows.Count > 0)
                    //                            {
                    //                                if (dtLotes.Rows[dtLotes.Rows.Count - 1][InsumosUtilizadosService.Modelo.CANTIDADColumnName] != System.DBNull.Value)
                    //                                    cantidadLoteTotal -= decimal.Parse(dtLotes.Rows[dtLotes.Rows.Count - 1][InsumosUtilizadosService.Modelo.CANTIDADColumnName].ToString());
                    //                            }
                    //                            drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadLoteTotal;
                    //                        }
                    //                        else
                    //                            drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadLoteTotal;


                    //                        drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)lotes.Rows[i][ArticulosLotesService.Id_NombreCol];


                    //                        cantidadLoteTotal = 0;
                    //                        dtLotes.Rows.Add(drLote);
                    //                        break;
                    //                    }
                    //                }
                    //            }

                    //            decimal cantidadTotal = 0;
                    //            for (int i = 0; i < dtLotes.Rows.Count; i++)
                    //            {
                    //                if (dtLotes.Rows[i][InsumosUtilizadosService.Modelo.CANTIDADColumnName] != System.DBNull.Value)
                    //                    cantidadTotal += decimal.Parse(dtLotes.Rows[i][InsumosUtilizadosService.Modelo.CANTIDADColumnName].ToString());
                    //            }

                    //            if (cantidadTotal < (row.CANTIDAD * (decimal)insumo[ArticulosCombosService.CantidadDestino_NombreCol]))
                    //            {                                   
                    //                string articulo = ArticulosService.GetArticuloCodigoEmpresa((decimal)lotes.Rows[0][ArticulosLotesService.Articulo_ID_NombreCol]);                                                                                                        
                    //                throw new Exception("Cantidad insuficiente del articulo " + articulo);
                    //            }
                    //            else
                    //                foreach (DataRow dr in dtLotes.Rows)
                    //                {
                    //                    if (dtLotes.Rows[0][InsumosUtilizadosService.Modelo.CANTIDADColumnName] != System.DBNull.Value)
                    //                    {
                    //                        dtFinal.ImportRow(dr);
                    //                    }
                    //                }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        decimal cantLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote(row.LOTE_ID, row.DEPOSITO_ID);

                    //        if (cantLote < row.CANTIDAD)
                    //        {
                    //            throw new Exception("Cantidad insuficiente");
                    //        }
                    //        else
                    //        {
                    //            final.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName, row.ARTICULO_ID);
                    //            final.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName, row.UNIDAD_MEDIDA_ID);
                    //            final.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName, row.ID);
                    //            final.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName, row.CANTIDAD);
                    //            final.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName, row.LOTE_ID);
                    //        }
                    //    }
                    //}
                    #endregion Codigo Viejo

                    #endregion insumos utilizados

                    //recien aca se crea el caso luego de corroborar si el articulo tiene los lotes con cantidades suficientes
                    if (insertarNuevo)
                    {                        
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[EgresoProductosService.Modelo.SUCURSAL_IDColumnName].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.EGRESO_PRODUCTOS.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }

                    if (insertarNuevo)
                        sesion.Db.EGRESO_PRODUCTOSCollection.Insert(row);
                    else
                        sesion.Db.EGRESO_PRODUCTOSCollection.Update(row);

                    #region insertar insumos utilizados
                    
                        
                            foreach (DataRow dr in dtFinal.Rows)
                            {
                                Hashtable producto = new Hashtable();
                                producto.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName].ToString()));
                                producto.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName, dr[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString());
                                producto.Add(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName].ToString()));
                                producto.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.CANTIDADColumnName].ToString()));
                                producto.Add(InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName].ToString()));
                                producto.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.LOTE_IDColumnName].ToString()));
                                InsumosUtilizadosService.Guardar(producto, true, sesion);
                            }
                        
                    
                    #endregion insertar insumos utilizados

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_SOLICITUD);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos                   

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    String mensaje = "Error.";

                    //Se obtienen el caso y el pedido a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    EGRESO_PRODUCTOSRow egresoProducto = sesion.Db.EGRESO_PRODUCTOSCollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = EgresoProductosDetallesService.GetEgresoProductosDetallesDataTable(EgresoProductosDetallesService.Modelo.EGRESO_PRODUCTO_IDColumnName + " = " + egresoProducto.ID, string.Empty);

                    //Si el caso posee detalles no puede ser borrado
                    if (detalles.Rows.Count > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        //se borran los insumos utilizados
                        DataTable insumosUtilizados = InsumosUtilizadosService.GetInsumosUtilizadosDataTable(InsumosUtilizadosService.Modelo.EGRESO_PRODUCTO_IDColumnName + " = " + egresoProducto.ID, string.Empty);
                        foreach (DataRow row in insumosUtilizados.Rows)
                            InsumosUtilizadosService.Borrar((decimal)row[InsumosUtilizadosService.Modelo.IDColumnName]);                                                
                        //se borran los sobrantes
                        DataTable sobrantes = EgresoProductosSobrantesService.GetEgresoProductosSobrantesDataTable(EgresoProductosSobrantesService.Modelo.EGRESO_PRODUCTO_IDColumnName + " = " + egresoProducto.ID, string.Empty);
                        foreach (DataRow row in sobrantes.Rows)
                            EgresoProductosSobrantesService.Borrar((decimal)row[EgresoProductosSobrantesService.Modelo.IDColumnName]);

                        sesion.Db.EGRESO_PRODUCTOSCollection.DeleteByCASO_ID(caso_id);
                        
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, egresoProducto.ID, egresoProducto.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        //Se borra el caso
                        (new CasosService()).Eliminar(caso_id, sesion);
                    }
                    else
                    {
                        throw new System.ArgumentException(mensaje);
                    }

                    sesion.CommitTransaction();
                    return exito;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region Accesors
        public const string Nombre_Tabla = "EGRESO_PRODUCTOS";
        public class Modelo : EGRESO_PRODUCTOSCollection_Base { public Modelo() : base(null) { } }             
        #endregion Accesors
    }
}
