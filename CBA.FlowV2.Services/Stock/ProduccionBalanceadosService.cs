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
    public class ProduccionBalanceadosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.PRODUCCION_BALANCEADOS;
        }
        #endregion Implementacion de metodos abstract

        #region Getters
        public static DataTable GetProduccionBalanceadosDataTable(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRODUCCION_BALANCEADOSCollection.GetAsDataTable(where, orderby);
            }
        }

        public static DataTable GetProduccionBalanceadosDataTableInfComp(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRODUCCION_BALANCEADOS_INF_COMPLCollection.GetAsDataTable(where, orderby);
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
                PRODUCCION_BALANCEADOSRow cabeceraRow = sesion.Db.PRODUCCION_BALANCEADOSCollection.GetByCASO_ID(caso_id)[0];
                PROD_BALAN_DETALLESRow[] detallesRows = sesion.Db.PROD_BALAN_DETALLESCollection.GetByPROD_BALAN_ID(cabeceraRow.ID);
                INSUMOS_UTILIZADOSRow[] insumosRows = sesion.Db.INSUMOS_UTILIZADOSCollection.GetByPROD_BALAN_ID(cabeceraRow.ID);
                PROD_BALAN_SOBRANTESRow[] sobrantesRows = sesion.Db.PROD_BALAN_SOBRANTESCollection.GetByPROD_BALAN_ID(cabeceraRow.ID);

                
                //Borrador a Pendiente
                 if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se genera el numero de comprobante

                    exito = true;
                    revisarRequisitos = true;
                    if (insumosRows.Length <= 0)
                    {
                        mensaje = "La producción no tiene detalles.";
                        exito = false;
                    }
                    for (int i = 0; i < insumosRows.Length; i++)
                    {
                        if (!(insumosRows[i].CANTIDAD > 0))
                        {
                            mensaje = "Uno de los insumos no posee la cantidad necesaria.";
                            exito = false;
                        }
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
                    for (int i = 0; i < insumosRows.Length; i++)
                    {
                        if (!(insumosRows[i].CANTIDAD > 0))
                        {
                            mensaje = "Uno de los insumos no posee la cantidad necesaria.";
                            exito = false;
                        }
                    }
                                      

                    
                    insumosRows = sesion.Db.INSUMOS_UTILIZADOSCollection.GetAsArray(InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName + "=" + cabeceraRow.ID, InsumosUtilizadosService.Modelo.LOTE_IDColumnName);
                   
                    
                    foreach (INSUMOS_UTILIZADOSRow insumos in insumosRows)
                    {
                        
                                                
                        var al = new ArticulosLotesService(insumos.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;
                        
                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    insumos.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.UsoDeInsumo, caso_id, insumos.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    insumos.ID);
                        al.FinalizarUsingSesion();
                        sesion.Db.INSUMOS_UTILIZADOSCollection.Update(insumos);
                    }
                     
                    foreach (PROD_BALAN_SOBRANTESRow sobrantes in sobrantesRows)
                    {
                        var al = new ArticulosLotesService(sobrantes.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    sobrantes.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Industrializacion, caso_id, sobrantes.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    sobrantes.ID);
                        al.FinalizarUsingSesion();
                    }

                   
                    //Acciones
                    //Se Ingresa el producto del stock
                    StockService.Costo costoInfreso = null;
                    StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    cabeceraRow.ARTICULO_ID,
                                                    cabeceraRow.CANTIDAD ,
                                                    Definiciones.Stock.TipoMovimiento.Industrializacion, caso_id, cabeceraRow.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costoInfreso,
                                                    1,
                                                    cabeceraRow.ID);
                   
                    exito = true;
                    revisarRequisitos = true; 
                }
                //Aprobado a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Se revierte la produccion del stock
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
                                                    Definiciones.Stock.TipoMovimiento.UsoDeInsumo, caso_id, insumos.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    insumos.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (PROD_BALAN_SOBRANTESRow sobrantes in sobrantesRows)
                    {
                        var al = new ArticulosLotesService(sobrantes.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -sobrantes.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Industrializacion, caso_id, sobrantes.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    sobrantes.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    //Acciones
                    //Se Ingresa el producto del stock
                    StockService.Costo costoInfreso = null;
                    StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    cabeceraRow.ARTICULO_ID,
                                                    -cabeceraRow.CANTIDAD ,
                                                    Definiciones.Stock.TipoMovimiento.Industrializacion, caso_id, cabeceraRow.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costoInfreso,
                                                    1,
                                                    cabeceraRow.ID);
                }
                //Aprobado a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Se revierte la produccion del stock
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
                                                    Definiciones.Stock.TipoMovimiento.UsoDeInsumo, caso_id, insumos.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    insumos.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    foreach (PROD_BALAN_SOBRANTESRow sobrantes in sobrantesRows)
                    {
                        var al = new ArticulosLotesService(sobrantes.LOTE_ID, sesion);
                        al.IniciarUsingSesion(sesion);
                        StockService.Costo costo = null;

                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    al.ArticuloId,
                                                    -sobrantes.CANTIDAD,
                                                    Definiciones.Stock.TipoMovimiento.Industrializacion, caso_id, sobrantes.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costo,
                                                    al.Articulo.ImpuestoCompraId.HasValue ? al.Articulo.ImpuestoCompraId.Value : al.Articulo.ImpuestoId,
                                                    sobrantes.ID, true);
                        al.FinalizarUsingSesion();
                    }

                    //Acciones
                    //Se Ingresa el producto del stock
                    StockService.Costo costoInfreso = null;
                    StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                                    cabeceraRow.ARTICULO_ID,
                                                    -cabeceraRow.CANTIDAD ,
                                                    Definiciones.Stock.TipoMovimiento.Industrializacion, caso_id, cabeceraRow.LOTE_ID, estado_destino,
                                                    sesion,
                                                    costoInfreso,
                                                    1,
                                                    cabeceraRow.ID);
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
                    sesion.Db.PRODUCCION_BALANCEADOSCollection.Update(cabeceraRow);
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
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id, decimal sucursal_origen_id, decimal deposito_origen_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (!campos.Contains(ProduccionBalanceadosService.Modelo.SUCURSAL_IDColumnName))
                        throw new Exception("Debe indicar la sucursal.");
                    if (!campos.Contains(ProduccionBalanceadosService.Modelo.DEPOSITO_IDColumnName))
                        throw new Exception("Debe indicar la deposito.");                   
                    if (!campos.Contains(ProduccionBalanceadosService.Modelo.ARTICULO_IDColumnName))
                        throw new Exception("Debe indicar el articulo.");

                    PRODUCCION_BALANCEADOSRow row = new PRODUCCION_BALANCEADOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                        row.ID = sesion.Db.GetSiguienteSecuencia("produccion_balanceados_sqc");                        
                    else
                    {
                        row = sesion.Db.PRODUCCION_BALANCEADOSCollection.GetRow(ProduccionBalanceadosService.Modelo.IDColumnName + " = " + campos[ProduccionBalanceadosService.Modelo.IDColumnName]);
                        valorAnterior = row.ToString();
                    }                       

                    if (!Interprete.EsNullODBNull(ProduccionBalanceadosService.Modelo.SUCURSAL_IDColumnName))
                        row.SUCURSAL_ID = (decimal)campos[ProduccionBalanceadosService.Modelo.SUCURSAL_IDColumnName];
                    else
                        throw new Exception("Valor no admitido en sucursal");
                    
                    if (!Interprete.EsNullODBNull(ProduccionBalanceadosService.Modelo.DEPOSITO_IDColumnName))
                        row.DEPOSITO_ID = (decimal)campos[ProduccionBalanceadosService.Modelo.DEPOSITO_IDColumnName];
                    else
                        throw new Exception("Valor no admitido en deposito");                                                  

                    if (!Interprete.EsNullODBNull(ProduccionBalanceadosService.Modelo.ARTICULO_IDColumnName))
                        row.ARTICULO_ID = (decimal)campos[ProduccionBalanceadosService.Modelo.ARTICULO_IDColumnName];
                    else
                        throw new Exception("Valor no admitido en articulo");
                    if (campos.Contains(ProduccionBalanceadosService.Modelo.LOTE_IDColumnName))
                        row.LOTE_ID = (decimal)campos[ProduccionBalanceadosService.Modelo.LOTE_IDColumnName];

                    row.UNIDAD_MEDIDA_ID = campos[ProduccionBalanceadosService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString();                   
                    row.CANTIDAD = (decimal)campos[ProduccionBalanceadosService.Modelo.CANTIDADColumnName];
                    if (campos.Contains(ProduccionBalanceadosService.Modelo.FECHA_SOLICITUDColumnName))
                        row.FECHA_SOLICITUD = (DateTime)campos[ProduccionBalanceadosService.Modelo.FECHA_SOLICITUDColumnName];

                    if (campos.Contains(ProduccionBalanceadosService.Modelo.AUTONUMERACION_IDColumnName))
                    {
                        if (!Interprete.EsNullODBNull(ProduccionBalanceadosService.Modelo.AUTONUMERACION_IDColumnName))
                        {
                            if (AutonumeracionesService.EstaActivo((decimal)campos[ProduccionBalanceadosService.Modelo.AUTONUMERACION_IDColumnName]))
                                row.AUTONUMERACION_ID = (decimal)campos[ProduccionBalanceadosService.Modelo.AUTONUMERACION_IDColumnName];
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

                    if (campos.Contains(ProduccionBalanceadosService.Modelo.NRO_COMPROBANTEColumnName))
                        row.NRO_COMPROBANTE = (string)campos[ProduccionBalanceadosService.Modelo.NRO_COMPROBANTEColumnName];
                    if (campos.Contains(ProduccionBalanceadosService.Modelo.PRESENTACION_IDColumnName))
                        row.PRESENTACION_ID = (decimal)campos[ProduccionBalanceadosService.Modelo.PRESENTACION_IDColumnName];
                    if (campos.Contains(ProduccionBalanceadosService.Modelo.CANTIDAD_PRESENTACIONColumnName))
                        row.CANTIDAD_PRESENTACION = (decimal)campos[ProduccionBalanceadosService.Modelo.CANTIDAD_PRESENTACIONColumnName];
                    if (campos.Contains(ProduccionBalanceadosService.Modelo.MONEDA_IDColumnName))
                        row.MONEDA_ID = (decimal)campos[ProduccionBalanceadosService.Modelo.MONEDA_IDColumnName];
                    if (campos.Contains(ProduccionBalanceadosService.Modelo.PRECIOColumnName))
                        row.PRECIO = 0;

                    #region insumos utilizados
                    ARTICULOSRow rowArticulo = ArticulosService.GetArticuloRowPorID(row.ARTICULO_ID, sesion);

                    DataTable dtFinal = new DataTable();
                    dtFinal.Clear();
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName);
                    dtFinal.Columns.Add(InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName);
                    Hashtable final = new Hashtable();                   

                    #region  Codigo de Calculo
                    #region Si es una edicion
                    //if (!insertarNuevo)
                    //{
                    //    if (row.ToString() != valorAnterior)
                    //    {
                            InsumosUtilizadosService.BorrarPorProduccionBalanceadoId(row.ID, sesion);
                    //    }
                    //}
                    #endregion Si es una edicion

                    if (rowArticulo.ES_FORMULA.Equals(Definiciones.SiNo.No))
                    {                       
                        #region Si es Combo

                        decimal cantidadInsumoNecesario = row.CANTIDAD;
                        DataTable dtlotes;
                        dtlotes = ArticulosLotesService.GetArticulosLotes(ArticulosLotesService.Articulo_ID_NombreCol + " = " + row.ARTICULO_ID, ArticulosLotesService.Fecha_NombreCol, sesion);
                                                
                        DataRow drLote;
                        if (dtlotes.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtlotes.Rows.Count; i++)
                            {
                                drLote = dtFinal.NewRow();
                                decimal cantidadPorLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote((decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol], deposito_origen_id, sesion);
                                
                                if (cantidadPorLote < cantidadInsumoNecesario)
                                {
                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = row.ARTICULO_ID;
                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = row.UNIDAD_MEDIDA_ID;
                                    drLote[InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName] = row.ID;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadPorLote == Definiciones.Error.Valor.EnteroPositivo ? 0 : cantidadPorLote;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadInsumoNecesario;
                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName] = sucursal_origen_id;
                                    drLote[InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName] = deposito_origen_id;

                                    dtFinal.Rows.Add(drLote);
                                    cantidadInsumoNecesario -= cantidadPorLote;
                                }
                                else
                                {
                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = row.ARTICULO_ID;
                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = row.UNIDAD_MEDIDA_ID;
                                    drLote[InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName] = row.ID;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadInsumoNecesario;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadInsumoNecesario;
                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                    drLote[InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName] = sucursal_origen_id;
                                    drLote[InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName] = deposito_origen_id;
                                    dtFinal.Rows.Add(drLote);
                                    cantidadInsumoNecesario = 0;
                                }
                            }
                        }
                        else
                        {
                            drLote = dtFinal.NewRow();
                            drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = row.ARTICULO_ID;
                            drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = row.UNIDAD_MEDIDA_ID;
                            drLote[InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName] = row.ID;
                            drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = 0;
                            drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadInsumoNecesario;
                            drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = string.Empty;
                            drLote[InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName] = sucursal_origen_id;
                            drLote[InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName] = deposito_origen_id;
                            dtFinal.Rows.Add(drLote);
                        }
                        #endregion Si es Combo
                    }
                    else
                    {
                        #region Si es Combo
                        //primero traemos los insumos que se utilizan en ese combo
                        DataTable dtInsumos = ArticulosFormulasService.GetArticulosFormulasDataTable("ARTICULO_FORMULA_ID = " + row.ARTICULO_ID, sesion);

                        if (dtInsumos.Rows.Count > 0)
                        {
                            foreach (DataRow insumo in dtInsumos.Rows)
                            {
                                decimal cantidadInsumoNecesario = (row.CANTIDAD * (decimal)insumo[ArticulosCombosService.CantidadDestino_NombreCol]);

                                DataTable dtlotes;
                                dtlotes = ArticulosLotesService.GetArticulosLotes(ArticulosLotesService.Articulo_ID_NombreCol + " = " + insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol].ToString(), ArticulosLotesService.Fecha_NombreCol, sesion);
                                                                
                                //obtenemos el total de existencia del articulo
                                decimal totalArticulo = StockArticulosReservaService.GetReserva_Segun_Articulo_Id(decimal.Parse(insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol].ToString()), deposito_origen_id, sesion);
                                                                
                                DataRow drLote;
                                if (dtlotes.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtlotes.Rows.Count; i++)
                                    {                                        
                                        drLote = dtFinal.NewRow();
                                        decimal cantidadPorLote = (new ArticulosLotesService()).ObtenerCantidadexistentePorLote((decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol], deposito_origen_id, sesion);
                                        
                                        if (cantidadPorLote < cantidadInsumoNecesario)
                                        {
                                            drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                                            drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                                            drLote[InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName] = row.ID;
                                            drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadPorLote == Definiciones.Error.Valor.EnteroPositivo ? 0 : cantidadPorLote;
                                            drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadInsumoNecesario;
                                            drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                            drLote[InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName] = sucursal_origen_id;
                                            drLote[InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName] = deposito_origen_id;
                                            dtFinal.Rows.Add(drLote);
                                            cantidadInsumoNecesario -= cantidadPorLote;
                                        }
                                        else
                                        {
                                            drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = (decimal)insumo[ArticulosCombosService.ArticuloDetalleId_NombreCol];
                                            drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = (string)insumo[ArticulosCombosService.UnidadDestinoId_NombreCol];
                                            drLote[InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName] = row.ID;
                                            drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = cantidadInsumoNecesario;
                                            drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadInsumoNecesario;
                                            drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = (decimal)dtlotes.Rows[i][ArticulosLotesService.Id_NombreCol];
                                            drLote[InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName] = sucursal_origen_id;
                                            drLote[InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName] = deposito_origen_id;
                                            dtFinal.Rows.Add(drLote);
                                            cantidadInsumoNecesario = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    drLote = dtFinal.NewRow();
                                    drLote[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName] = row.ARTICULO_ID;
                                    drLote[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName] = row.UNIDAD_MEDIDA_ID;
                                    drLote[InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName] = row.ID;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDADColumnName] = 0;
                                    drLote[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName] = cantidadInsumoNecesario;
                                    drLote[InsumosUtilizadosService.Modelo.LOTE_IDColumnName] = string.Empty;
                                    drLote[InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName] = sucursal_origen_id;
                                    drLote[InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName] = deposito_origen_id;
                                    dtFinal.Rows.Add(drLote);
                                }
                            }
                        }                        
                        #endregion Si es Combo
                    }
                   
                    #endregion Codigo de Calculo                                      

                    #endregion insumos utilizados

                    //recien aca se crea el caso luego de corroborar si el articulo tiene los lotes con cantidades suficientes
                    if (insertarNuevo)
                    {                        
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[ProduccionBalanceadosService.Modelo.SUCURSAL_IDColumnName].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.PRODUCCION_BALANCEADOS.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }

                    if (insertarNuevo)
                        sesion.Db.PRODUCCION_BALANCEADOSCollection.Insert(row);
                    else
                        sesion.Db.PRODUCCION_BALANCEADOSCollection.Update(row);

                    #region insertar insumos utilizados
                        
                    foreach (DataRow dr in dtFinal.Rows)
                    {
                        Hashtable producto = new Hashtable();
                        producto.Add(InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.ARTICULO_IDColumnName].ToString()));
                        producto.Add(InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName, dr[InsumosUtilizadosService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString());
                        producto.Add(InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName].ToString()));
                        producto.Add(InsumosUtilizadosService.Modelo.CANTIDADColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.CANTIDADColumnName].ToString()));
                        producto.Add(InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.CANTIDAD_NOMINALColumnName].ToString()));
                        producto.Add(InsumosUtilizadosService.Modelo.LOTE_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.LOTE_IDColumnName].ToString()));
                        producto.Add(InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.SUCURSAL_IDColumnName].ToString()));
                        producto.Add(InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName, decimal.Parse(dr[InsumosUtilizadosService.Modelo.DEPOSITO_IDColumnName].ToString()));
                        InsumosUtilizadosService.Guardar(producto, true, sesion);
                    }                        
                    
                    #endregion insertar insumos utilizados

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_SOLICITUD);                    
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
                    PRODUCCION_BALANCEADOSRow produccionBalanceado = sesion.Db.PRODUCCION_BALANCEADOSCollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = ProduccionBalanceadosDetallesService.GetProduccionBalanceadoDetallesDataTable(ProduccionBalanceadosDetallesService.Modelo.PROD_BALAN_IDColumnName + " = " + produccionBalanceado.ID, string.Empty);

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
                        DataTable insumosUtilizados = InsumosUtilizadosService.GetInsumosUtilizadosDataTable(InsumosUtilizadosService.Modelo.PROD_BALAN_IDColumnName + " = " + produccionBalanceado.ID, string.Empty);
                        foreach (DataRow row in insumosUtilizados.Rows)
                            InsumosUtilizadosService.Borrar((decimal)row[InsumosUtilizadosService.Modelo.IDColumnName]);                                                
                        //se borran los sobrantes
                        DataTable sobrantes = ProduccionBalanceadosSobrantesService.GetProduccionBalanceadosSobrantesDataTable(ProduccionBalanceadosSobrantesService.Modelo.PROD_BALAN_IDColumnName + " = " + produccionBalanceado.ID, string.Empty);
                        foreach (DataRow row in sobrantes.Rows)
                            ProduccionBalanceadosSobrantesService.Borrar((decimal)row[ProduccionBalanceadosSobrantesService.Modelo.IDColumnName]);

                        sesion.Db.PRODUCCION_BALANCEADOSCollection.DeleteByCASO_ID(caso_id);
                        
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, produccionBalanceado.ID, produccionBalanceado.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
        public const string Nombre_Tabla = "PRODUCCION_BALANCEADOS";
        public class Modelo : PRODUCCION_BALANCEADOSCollection_Base { public Modelo() : base(null) { } }
        public class ModeloVista : PRODUCCION_BALANCEADOS_INF_COMPLCollection_Base { public ModeloVista() : base(null) { } }               
          
        #endregion Accesors
    }
}
