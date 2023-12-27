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
using CBA.FlowV2.Services.Casos;
using System.Collections;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.TextosPredefinidos;

#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class StockTransferenciasService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de Metodos Abstractos
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.SucursalRelacionada, drCabecera[StockTransferenciasService.SucursalDestinoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[StockTransferenciasService.DepositoOrigen_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[StockTransferenciaDetalleService.ArticuloId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[StockTransferenciasService.TextoPredefinidoId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            STOCK_TRANSFERENCIARow[] rows;
            rows = sesion.Db.STOCK_TRANSFERENCIACollection.GetByCASO_ID(caso_id);
            if (rows.Length == 1)
                return rows[0].COMPROBANTE.ToString();
            else
                return string.Empty;
        }

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
                mensaje = string.Empty;
                bool exito = false;
                bool borrarCasoAsociado = false;
                decimal casoEspejo = Definiciones.Error.Valor.EnteroPositivo;

                mensaje = "";
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    STOCK_TRANSFERENCIARow transferenciaRow = sesion.Db.STOCK_TRANSFERENCIACollection.GetByCASO_ID(caso_id)[0];
                    STOCK_TRANSFERENCIA_DETALLERow[] detalleRows = sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.GetByTRANSFERENCIA_STOCK_ID(transferenciaRow.ID);
                    // de borrador a anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        exito = true;
                    }
                    // de borrador a pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        #region generar autonumeracion

                        //Si no existe un comprobante se crea
                        if (transferenciaRow.COMPROBANTE == null || transferenciaRow.COMPROBANTE.Length <= 0)
                        {
                            if (transferenciaRow.IsAUTONUMERACION_IDNull)
                                throw new Exception("Debe indicarse el talonario o un número de comprobante de forma manual.");

                            transferenciaRow.COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(transferenciaRow.AUTONUMERACION_ID, sesion);
                            
                        }
                        #endregion generar autonumeracion

                        if (detalleRows.Length <= 0)
                        {
                            mensaje = "La transferencia no tiene detalles.";
                            exito = false;
                        }
                        else
                        {
                            exito = true;
                        }

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    //de pendiente a borrador
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                           estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    //de pendiente a anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        exito = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    // de pendiente a aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        exito = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    // de aprobado a pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        exito = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    // de aprobado a viajando
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Viajando))
                    {
                        try
                        {
                            string tipoMovimiento = string.Empty;
                            exito = true;

                            #region Verificar Puede Avanzar Estado
                            if (exito)
                            {
                                exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                            }
                            #endregion Verificar Puede Avanzar Estado

                            //Asignar la numeracion de remisión, si corresponde y no existía
                            //validando que sea única (considerando el flujo Remisiones)
                            if(ClaseCBABase.GetStringHelper(transferenciaRow.REMISION_EXTERNA) == string.Empty && !transferenciaRow.IsREMISION_AUTONUMERACION_IDNull)
                            {
                                if (AutonumeracionesService.EsGeneracionManual(transferenciaRow.REMISION_AUTONUMERACION_ID, sesion))
                                    throw new Exception("Debe indicar el número de comprobante de remisión, que es de numeración manual.");
                                
                                //Se debe traer el siguiente numero para completar las validaciones. Aun no se debe actualizar el talonario
                                string nroComprobanteAux = AutonumeracionesService.ConsultarSiguienteNumero(transferenciaRow.REMISION_AUTONUMERACION_ID, sesion);
                                if (nroComprobanteAux.Equals(""))
                                    throw new Exception("No se pudo asignar un número de comprobante de remisión válido.");

                                decimal casoCoincideId;
                                if (RemisionesService.GetExisteNroComprobanteRemision(Definiciones.Error.Valor.EnteroPositivo, transferenciaRow.CASO_ID, transferenciaRow.REMISION_AUTONUMERACION_ID, nroComprobanteAux, out casoCoincideId, sesion))
                                    throw new Exception("El número de remisión " + nroComprobanteAux + " ya está siendo utilizado en el " + Traducciones.Caso + " " + casoCoincideId + ".");

                                //Si se pasaron todas las validaciones. Generar comprobante.
                                decimal nroComprobanteNumerico = Definiciones.Error.Valor.EnteroPositivo;
                                transferenciaRow.REMISION_EXTERNA = AutonumeracionesService.GetSiguienteNumero2(transferenciaRow.REMISION_AUTONUMERACION_ID, out nroComprobanteNumerico, sesion);
                            }
                            
                                foreach (STOCK_TRANSFERENCIA_DETALLERow detalle in detalleRows)
                                {
                                    tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaSalida;
                                    StockService.modificarStock(transferenciaRow.DEPOSITO_ORIGEN_ID,
                                                         detalle.ARTICULO_ID,
                                                         Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                                         tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                                         sesion, null, null, detalle.ID);
                                }
                            
                            #region Crear caso espejo de transferencia
                                if (!RolesService.Tiene("TRANSFERENCIAS STOCK NO GENERAR CASO ESPEJO"))
                                {
                                    // Se crea la cabecera del caso espejo
                                    STOCK_TRANSFERENCIARow transferenciaEspejo = sesion.db.STOCK_TRANSFERENCIACollection.GetByPrimaryKey(transferenciaRow.ID);
                                    // Se modifican los campos distintos al caso original
                                    transferenciaEspejo.ID = sesion.Db.GetSiguienteSecuencia("stock_transferencia_sqc");
                                    //transferenciaEspejo.FECHA = transferenciaEspejo;
                                    transferenciaEspejo.ES_CASO_ORIGINAL = Definiciones.SiNo.No;
                                    transferenciaEspejo.CASO_ASOCIADO_ID = transferenciaRow.CASO_ID;
                                    transferenciaEspejo.IMPRESO = transferenciaRow.IMPRESO;
                                    CrearCasos CrearCaso = new CrearCasos((int)transferenciaEspejo.SUCURSAL_DESTINO_ID,
                                                                 int.Parse(Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS.ToString()),
                                                                 int.Parse(sesion.Usuario_Id.ToString()),
                                                                 SessionService.GetClienteIP());
                                    transferenciaEspejo.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                                    sesion.Db.STOCK_TRANSFERENCIACollection.Insert(transferenciaEspejo);
                                    LogCambiosService.LogDeRegistro(StockTransferenciasService.Nombre_Tabla, transferenciaEspejo.ID, Definiciones.Log.RegistroNuevo, transferenciaEspejo.ToString(), sesion);

                                    // Se copian los detalles del caso original al espejo
                                    foreach (STOCK_TRANSFERENCIA_DETALLERow detalle in detalleRows)
                                    {
                                        STOCK_TRANSFERENCIA_DETALLERow detalleEspejo = sesion.db.STOCK_TRANSFERENCIA_DETALLECollection.GetByPrimaryKey(detalle.ID);
                                        detalleEspejo = detalle;
                                        detalleEspejo.ID = sesion.Db.GetSiguienteSecuencia("STOCK_TRANSFERENCIA_DET_SQC");
                                        detalleEspejo.TRANSFERENCIA_STOCK_ID = transferenciaEspejo.ID;
                                        sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.Insert(detalleEspejo);
                                        LogCambiosService.LogDeRegistro(StockTransferenciaDetalleService.Nombre_Tabla, detalleEspejo.ID, Definiciones.Log.RegistroNuevo, detalleEspejo.ToString(), sesion);
                                    }

                                    // Se pasa el caso espejo al estado correspondiente
                                    CambioEstadoCasoService cambioEstado = new CambioEstadoCasoService();
                                    bool estadoActualizado = cambioEstado.CambiarEstado(decimal.Parse(transferenciaEspejo.CASO_ID.ToString()),
                                                               Definiciones.EstadosFlujos.EnProceso,
                                                               sesion.Usuario.ID,
                                                               sesion.Usuario.SESION,
                                                               "Transición automática.",
                                                               SessionService.GetClienteIP(),
                                                               sesion);




                                    // Se actualiza el caso asociado del caso origen con el caso espejo
                                    transferenciaRow.CASO_ASOCIADO_ID = decimal.Parse(transferenciaEspejo.CASO_ID.ToString());

                                    #region Actualizar datos en tabla casos
                                    Hashtable camposCaso = new Hashtable();
                                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, transferenciaRow.FECHA);
                                    camposCaso.Add(CasosService.NroComprobante_NombreCol, transferenciaRow.COMPROBANTE);
                                    if (!Interprete.EsNullODBNull(transferenciaRow.REMISION_EXTERNA))
                                        camposCaso.Add(CasosService.NroComprobante2_NombreCol, transferenciaRow.REMISION_EXTERNA);
                                    if (!transferenciaRow.IsFUNCIONARIO_CHOFER_IDNull)
                                        camposCaso.Add(CasosService.FuncionarioId_NombreCol, transferenciaRow.FUNCIONARIO_CHOFER_ID);
                                    CasosService.ActualizarCampos(transferenciaRow.CASO_ASOCIADO_ID, camposCaso, sesion);
                                    #endregion Actualizar datos en tabla casos
                                }
                            #endregion Crear caso espejo de transferencia
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }                       
                    }
                    // de viajando a aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Viajando) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        try
                        {
                            exito = true;

                            #region Verificar Puede Avanzar Estado
                            if (exito)
                            {
                                exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                            }
                            #endregion Verificar Puede Avanzar Estado

                            if (exito && !transferenciaRow.IsCASO_ASOCIADO_IDNull)
                            {
                                casoEspejo = sesion.db.STOCK_TRANSFERENCIACollection.GetAsArray(StockTransferenciasService.CasoId_NombreCol + " = " + transferenciaRow.CASO_ASOCIADO_ID, string.Empty)[0].CASO_ID;
                                borrarCasoAsociado = true;
                                transferenciaRow.IsCASO_ASOCIADO_IDNull = true;
                                string tipoMovimiento = string.Empty;
                                foreach (STOCK_TRANSFERENCIA_DETALLERow detalle in detalleRows)
                                {
                                    tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaEntrada;
                                    StockService.modificarStock(transferenciaRow.DEPOSITO_ORIGEN_ID,
                                                         detalle.ARTICULO_ID,
                                                         Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                                         tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                                         sesion, null, null, detalle.ID);
                                }
                            }

                            //Borrar el asiento de Aprobado a Viajando
                            decimal transicionId = TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Viajando, sesion);
                            Contabilidad.AsientosService.BorrarPorCasoYTransicion(caso_id, transicionId, sesion);
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }                        
                    }
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Viajando) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                     
                        exito = true;
                        if (exito && transferenciaRow.IsCASO_ASOCIADO_IDNull && cambio_pedido_por_usuario)
                        {
                            
                            foreach (STOCK_TRANSFERENCIA_DETALLERow detalle in detalleRows)
                            {
                              string  tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaEntrada;
                                decimal depositoDestinoId;
                                // VIGOMEL - 22/10/2020
                                // Si el detalle tiene proveedor_id, buscamos si el mismo tiene deposito asociado.
                                // Si tiene, actualiza stock en deposito asociado.
                                // Caso contrario actualiza para el deposito de la cabecera.
                                if (!detalle.IsPROVEEDOR_IDNull)
                                {
                                    DataTable dt = StockDepositosService.GetStockDepositosDataTable(transferenciaRow.SUCURSAL_DESTINO_ID, detalle.PROVEEDOR_ID, false, true);
                                    if (dt.Rows.Count > 0)
                                        depositoDestinoId = decimal.Parse(dt.Rows[0][StockDepositosService.Id_NombreCol].ToString());
                                    else
                                        depositoDestinoId = transferenciaRow.DEPOSITO_DESTINO_ID;
                                }
                                else
                                    depositoDestinoId = transferenciaRow.DEPOSITO_DESTINO_ID;

                                // Actualizamos el Stock.
                                StockService.modificarStock(depositoDestinoId,
                                                     detalle.ARTICULO_ID,
                                                     Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                                     tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                                     sesion, null, null, detalle.ID);

                                /*StockService.modificarStock(transferenciaRow.DEPOSITO_DESTINO_ID,
                                                     detalle.ARTICULO_ID,
                                                     Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                                     tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                                     sesion, null, null, detalle.ID);*/
                            }
 
                        }

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.EnRevision))
                    {
                        exito = true;

                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnRevision) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        try
                        {
                            exito = true;

                            #region Verificar Puede Avanzar Estado
                            if (exito)
                            {
                                exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                            }
                            #endregion Verificar Puede Avanzar Estado

                            if (exito)
                            {
                                string tipoMovimiento = string.Empty;
                                STOCK_TRANSFERENCIARow[] transferenciaOrigen = sesion.Db.STOCK_TRANSFERENCIACollection.GetByCASO_ASOCIADO_ID(transferenciaRow.CASO_ID, false);
                                if (transferenciaOrigen.Length < 1)
                                {
                                    throw new Exception("Error al Cerrar la Transferencia");
                                }

                                decimal idTransferenciaOrigen = transferenciaOrigen[0].ID;
                                foreach (STOCK_TRANSFERENCIA_DETALLERow detalle in detalleRows)
                                {
                                    tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaEntrada;
                                    decimal depositoDestinoId;
                                    // VIGOMEL - 22/10/2020
                                    // Si el detalle tiene proveedor_id, buscamos si el mismo tiene deposito asociado.
                                    // Si tiene, actualiza stock en deposito asociado.
                                    // Caso contrario actualiza para el deposito de la cabecera.
                                    if (!detalle.IsPROVEEDOR_IDNull)
                                    {
                                        DataTable dt = StockDepositosService.GetStockDepositosDataTable(transferenciaRow.SUCURSAL_DESTINO_ID, detalle.PROVEEDOR_ID, false, true);
                                        if (dt.Rows.Count > 0)
                                            depositoDestinoId = decimal.Parse(dt.Rows[0][StockDepositosService.Id_NombreCol].ToString());
                                        else
                                            depositoDestinoId = transferenciaRow.DEPOSITO_DESTINO_ID;
                                    }
                                    else
                                        depositoDestinoId = transferenciaRow.DEPOSITO_DESTINO_ID;

                                    // Actualizamos el Stock.
                                    StockService.modificarStock(depositoDestinoId,
                                                         detalle.ARTICULO_ID,
                                                         Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                                         tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                                         sesion, null, null, detalle.ID);

                                    /*StockService.modificarStock(transferenciaRow.DEPOSITO_DESTINO_ID,
                                                         detalle.ARTICULO_ID,
                                                         Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                                         tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                                         sesion, null, null, detalle.ID);*/
                                }
                                CambioEstadoCasoService caso = new CambioEstadoCasoService();
                                caso.CambiarEstado(transferenciaRow.CASO_ASOCIADO_ID, Definiciones.EstadosFlujos.Cerrado, sesion.Usuario.ID, sesion.Usuario.SESION, "", SessionService.GetClienteIP(), sesion);
                            }
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.STOCK_TRANSFERENCIACollection.Update(transferenciaRow);

                        if (borrarCasoAsociado && !casoEspejo.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            Borrar(casoEspejo, sesion);
                    }
                    return exito;
                }
                catch (Exception exp)
                {
                    exito = false;
                    throw exp;
                }
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }
        #endregion Implementacion de Metodos Abstractos

        #region GetStockTranferencia
        public static DataTable GetStockTransferenciaDataTable2(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStockTransferenciaDataTable2(clausula, orden, sesion);
            }
        }

        public static DataTable GetStockTransferenciaDataTable2(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.STOCK_TRANSFERENCIACollection.GetAsDataTable(clausula, orden);
        }

        /// <summary>
        /// Gets the stock A tranferencia data table por sucursal.
        /// </summary>
        /// <param name="id_sucursal">The id_sucursal.</param>
        /// <returns></returns>
        public DataTable GetStockATranferenciaDataTablePorSucursal(decimal id_sucursal)
        {
            return GetStockTransferenciaDataTable2(SucursalDestinoId_NombreCol + " = " + id_sucursal + " or " + SucursalOrigenId_NombreCol+ " = " + id_sucursal, string.Empty);
        }
        #endregion GetStockTransferenciaDataTable

        #region GetStockTranferenciaInfoCompleta
        public static DataTable GetStockTranferenciaInfoCompleta(string clausulas, string orden)
        { 
            using (SessionService sesion = new SessionService())
            {
                return GetStockTranferenciaInfoCompleta(clausulas, orden, sesion);
            }
        }
        
        /// <summary>
        /// Gets the stock tranferencia info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetStockTranferenciaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.STOCK_TRANSF_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetStockTranferenciaInfoCompleta

        #region GetStockTransferenciaPorCaso

        /// <summary>
        /// Gets the stock transferencia por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetStockTransferenciaPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_TRANSFERENCIACollection.GetAsDataTable(StockTransferenciasService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetStockTransferenciaPorCaso

        #region GetStockTransferenciaSucursalDestinoNombrePorCaso
        public static string GetStockTransferenciaSucursalDestinoNombrePorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = StockTransferenciasService.CasoId_NombreCol + " = " + caso_id;
                STOCK_TRANSF_INFO_COMPLRow[] row = sesion.db.STOCK_TRANSF_INFO_COMPLCollection.GetAsArray(StockTransferenciasService.CasoId_NombreCol + " = " + caso_id,string.Empty);
                if (row.Length == 1)
                    return row[0].SUCURSAL_DESTINO;
                else
                    return string.Empty;
                   
            }
        }
        #endregion GetStockTransferenciaSucursalDestinoNombrePorCaso

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            bool exito = false;
            using (SessionService sesion = new SessionService())
            { 
                exito = Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
            }
            return exito;
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, SessionService sesion)
        {
            STOCK_TRANSFERENCIARow row = new STOCK_TRANSFERENCIARow();
            try
            {
                string valorAnterior = string.Empty;
                
                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("stock_transferencia_sqc");
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalOrigenId_NombreCol].ToString()),
                                                         int.Parse(Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS.ToString()),
                                                         int.Parse(sesion.Usuario_Id.ToString()),
                                                         SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.IMPRESO = Definiciones.SiNo.No;
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                    if (campos.Contains(StockTransferenciasService.EsCasoOriginal_NombreCol))
                        row.ES_CASO_ORIGINAL = (string)campos[StockTransferenciasService.EsCasoOriginal_NombreCol];
                    else
                        row.ES_CASO_ORIGINAL = Definiciones.SiNo.Si;
                }
                else
                {
                    row = sesion.Db.STOCK_TRANSFERENCIACollection.GetByPrimaryKey(decimal.Parse(campos[StockTransferenciasService.Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }
                
                if (campos.Contains(StockTransferenciasService.Acompanante1_NombreCol))
                    row.ACOMPANANTE1_ID = decimal.Parse(campos[StockTransferenciasService.Acompanante1_NombreCol].ToString());
                else 
                    row.IsACOMPANANTE1_IDNull = true;

                if (campos.Contains(RemisionExterna_NombreCol))
                    row.REMISION_EXTERNA = campos[RemisionExterna_NombreCol].ToString();

                if (campos.Contains(RemisionAutonumeracionId_NombreCol))
                {
                    row.REMISION_AUTONUMERACION_ID = (decimal)campos[RemisionAutonumeracionId_NombreCol];

                    if (GetStringHelper(row.REMISION_EXTERNA).Length > 0)
                    {
                        //Validar que el numero de remision sea único (considerando el flujo Remisiones)
                        decimal casoCoincideId;
                        if (RemisionesService.GetExisteNroComprobanteRemision(Definiciones.Error.Valor.EnteroPositivo, row.CASO_ID, row.REMISION_AUTONUMERACION_ID, row.REMISION_EXTERNA, out casoCoincideId, sesion))
                            throw new Exception("El número de remisión " + row.REMISION_EXTERNA + " ya está siendo utilizado en el " + Traducciones.Caso + " " + casoCoincideId + ".");
                    }
                }
                else
                {
                    row.IsREMISION_AUTONUMERACION_IDNull = true;
                }

                if (campos.Contains(StockTransferenciasService.Acompanante2_NombreCol))
                    row.ACOMPANANTE2_ID = decimal.Parse(campos[StockTransferenciasService.Acompanante2_NombreCol].ToString());
                else
                    row.IsACOMPANANTE2_IDNull = true;

                if (campos.Contains(StockTransferenciasService.Acompanante3_NombreCol))
                    row.ACOMPANANTE3_ID = decimal.Parse(campos[StockTransferenciasService.Acompanante3_NombreCol].ToString());
                else
                    row.IsACOMPANANTE3_IDNull = true;

                if (campos.Contains(StockTransferenciasService.Autonumeraciones_NombreCol))
                {
                    row.AUTONUMERACION_ID = decimal.Parse(campos[StockTransferenciasService.Autonumeraciones_NombreCol].ToString());
                }

                if (campos.Contains(StockTransferenciasService.CasoAsociadoId_NombreCol))
                    row.CASO_ASOCIADO_ID = decimal.Parse(campos[StockTransferenciasService.CasoAsociadoId_NombreCol].ToString());

                if (campos.Contains(StockTransferenciasService.ChoferId_NombreCol))
                        row.FUNCIONARIO_CHOFER_ID = decimal.Parse(campos[StockTransferenciasService.ChoferId_NombreCol].ToString());
                else
                    row.IsFUNCIONARIO_CHOFER_IDNull = true;

                if (campos.Contains(StockTransferenciasService.ProveedorId_NombreCol))
                        row.PROVEEDOR_ID = decimal.Parse(campos[StockTransferenciasService.ProveedorId_NombreCol].ToString());
                else
                    row.IsPROVEEDOR_IDNull = true;

                if (campos.Contains(StockTransferenciasService.ChoferNombre_NombreCol))
                    row.CHOFER_NOMBRE = campos[StockTransferenciasService.ChoferNombre_NombreCol].ToString();

                if (campos.Contains(StockTransferenciasService.Comprobante_NombreCol))
                    row.COMPROBANTE = campos[StockTransferenciasService.Comprobante_NombreCol].ToString();
                if (campos.Contains(StockTransferenciasService.CostoAsociado_NombreCol))
                    row.COSTO_ASOCIADO = decimal.Parse(campos[StockTransferenciasService.CostoAsociado_NombreCol].ToString());
                if (campos.Contains(StockTransferenciasService.CostoTransferencia_NombreCol))
                    row.COSTO_TRANSFERENCIA = decimal.Parse(campos[StockTransferenciasService.CostoTransferencia_NombreCol].ToString());
                if (campos.Contains(StockTransferenciasService.Cotizacion_NombreCol))
                    row.COTIZACION = decimal.Parse(campos[StockTransferenciasService.Cotizacion_NombreCol].ToString());
                
                if (campos.Contains(StockTransferenciasService.DepositoDestino_NombreCol))
                {
                    if (row.DEPOSITO_DESTINO_ID != decimal.Parse(campos[StockTransferenciasService.DepositoDestino_NombreCol].ToString()))
                    {
                        var depositoDestino = new StockDepositosService(decimal.Parse(campos[StockTransferenciasService.DepositoDestino_NombreCol].ToString()), sesion);
                        if(depositoDestino.Estado == Definiciones.Estado.Inactivo)
                            throw new Exception("El depósito destino está inactivo.");

                        row.DEPOSITO_DESTINO_ID = depositoDestino.Id.Value;
                        row.SUCURSAL_DESTINO_ID = depositoDestino.SucursalId;
                    }
                }

                if (campos.Contains(StockTransferenciasService.DepositoOrigen_NombreCol))
                {
                    if (row.DEPOSITO_DESTINO_ID != decimal.Parse(campos[StockTransferenciasService.DepositoOrigen_NombreCol].ToString()))
                    {
                        var depositoOrigen = new StockDepositosService(decimal.Parse(campos[StockTransferenciasService.DepositoOrigen_NombreCol].ToString()), sesion);
                        if(depositoOrigen.Estado == Definiciones.Estado.Inactivo)
                            throw new Exception("El depósito origen está inactivo.");

                        row.DEPOSITO_ORIGEN_ID = depositoOrigen.Id.Value;
                        row.SUCURSAL_ORIGEN_ID = depositoOrigen.SucursalId;
                    }
                }

                if (row.DEPOSITO_DESTINO_ID == row.DEPOSITO_ORIGEN_ID)
                    throw new Exception("Depósito origen y destino no pueden ser el mismo.");

                row.FECHA = (DateTime)campos[StockTransferenciasService.Fecha_NombreCol];
                row.OBSERVACION = (string)campos[StockTransferenciasService.Observacion_NombreCol];

                if (campos.Contains(StockTransferenciasService.MonedaId_NombreCol))
                    row.MONEDA_ID = decimal.Parse(campos[StockTransferenciasService.MonedaId_NombreCol].ToString());
                if (campos.Contains(StockTransferenciasService.TotalCosto_NombreCol))
                    row.TOTAL_COSTO = decimal.Parse(campos[StockTransferenciasService.TotalCosto_NombreCol].ToString());
                
                if (campos.Contains(StockTransferenciasService.VehiculoId_NombreCol))
                    row.VEHICULO_ID = decimal.Parse(campos[StockTransferenciasService.VehiculoId_NombreCol].ToString());
                else
                    row.IsVEHICULO_IDNull= true;
                
                if (campos.Contains(StockTransferenciasService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = decimal.Parse(campos[StockTransferenciasService.TextoPredefinidoId_NombreCol].ToString());
                else
                    row.IsTEXTO_PREDEFINIDO_IDNull = true;
                
                if (campos.Contains(StockTransferenciasService.VehiculoMarca_NombreCol))
                    row.VEHICULO_MARCA = campos[StockTransferenciasService.VehiculoMarca_NombreCol].ToString();
                if (campos.Contains(StockTransferenciasService.VehiculoMatricula_NombreCol))
                    row.VEHICULO_MATRICULA = campos[StockTransferenciasService.VehiculoMatricula_NombreCol].ToString();

                if (insertarNuevo) sesion.Db.STOCK_TRANSFERENCIACollection.Insert(row);
                else sesion.Db.STOCK_TRANSFERENCIACollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.COMPROBANTE);
                if (row.ES_CASO_ORIGINAL == Definiciones.SiNo.Si)
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ORIGEN_ID);
                else
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_DESTINO_ID);
                if (!Interprete.EsNullODBNull(row.REMISION_EXTERNA))
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, row.REMISION_EXTERNA);
                if (!row.IsFUNCIONARIO_CHOFER_IDNull)
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_CHOFER_ID);
                else if (!row.IsPROVEEDOR_IDNull)
                    camposCaso.Add(CasosService.ProveedorId_NombreCol, row.PROVEEDOR_ID);
                CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos

                return true;
            }
            catch (Exception)
            {
                if (insertarNuevo && row.CASO_ID > 0)
                {
                    (new CasosService()).Eliminar(row.CASO_ID, sesion);
                    caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    estado_id = string.Empty;
                }
                
                throw;
            }
        }
        #endregion Guardar

        #region GetCostoTransferencia
        /// <summary>
        /// Gets the costo transferencia.
        /// </summary>
        /// <param name="transferencia_id">The transferencia_id.</param>
        /// <returns></returns>
        public static decimal GetCostoTransferencia(decimal transferencia_id) 
        {
            using (SessionService sesion = new SessionService()) 
            {
                
                STOCK_TRANSFERENCIARow row = sesion.Db.STOCK_TRANSFERENCIACollection.GetByPrimaryKey(transferencia_id);

                if (row == null)
                    return Definiciones.Error.Valor.EnteroPositivo;

                if (row.IsCOSTO_TRANSFERENCIANull) 
                    return Definiciones.Error.Valor.EnteroPositivo;
                else
                    return row.COSTO_TRANSFERENCIA;
                
            }
        }
        #endregion GetCostoTransferencia

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        /// 
        public static bool Borrar(decimal caso_id, SessionService sesion)
        {
            
                try
                {
                   
                    bool exito = true;
                    string mensaje = string.Empty;

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    STOCK_TRANSFERENCIARow cabecera = sesion.Db.STOCK_TRANSFERENCIACollection.GetByCASO_ID(caso_id)[0];
                    STOCK_TRANSFERENCIA_DETALLERow[] detalles = sesion.Db.STOCK_TRANSFERENCIA_DETALLECollection.GetByTRANSFERENCIA_STOCK_ID(cabecera.ID);

                    if (cabecera.ES_CASO_ORIGINAL.Equals(Definiciones.SiNo.Si))
                    {

                        if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                        {
                            exito = false;
                            mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                        }
                        if (exito && detalles.Length > 0)
                        {
                            exito = false;
                            mensaje = "El caso no puede borrarse ya que posee detalles.";
                        }
                    }
                    else
                    {
                        if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso))
                        {
                            exito = false;
                            mensaje = "El caso no puede borrarse ya que debe estar en el estado En Proceso.";
                        }
                        if (exito)
                        {
                            for (int i = 0; i < detalles.Length; i++)
                            {
                                StockTransferenciaDetalleService.Borrar(detalles[i].ID, sesion);
                            }
                        }

                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.STOCK_TRANSFERENCIACollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        //Se borra el caso
                        (new CasosService()).Eliminar(caso_id, sesion);
                    }
                    else
                    {
                        throw new System.ArgumentException(mensaje);
                    }

                    
                    return exito;
                }
                catch (Exception exp)
                {
                   
                    throw exp;
                }
            
        }
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(caso_id, sesion);
                    sesion.CommitTransaction();
                    return true;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region CrearTransferencia

        public static bool CrearTransferencia(decimal sucursal_destino_id, decimal sucursal_origen_id, decimal deposito_origen_id, decimal deposito_destino_id, DateTime fecha, decimal moneda_id, decimal costo_asociado, decimal cotizacion, decimal autonumeracion_id, ref decimal caso_transferencia, ref string estado_transferencia, SessionService sesion)
        {
            System.Collections.Hashtable camposTransferencia = new System.Collections.Hashtable();
            camposTransferencia.Add(StockTransferenciasService.SucursalOrigenId_NombreCol, sucursal_origen_id);
            camposTransferencia.Add(StockTransferenciasService.DepositoOrigen_NombreCol, deposito_origen_id);
            camposTransferencia.Add(StockTransferenciasService.DepositoDestino_NombreCol, deposito_destino_id);
            camposTransferencia.Add(StockTransferenciasService.SucursalDestinoId_NombreCol, sucursal_destino_id);
            camposTransferencia.Add(StockTransferenciasService.Fecha_NombreCol, fecha);
            camposTransferencia.Add(StockTransferenciasService.MonedaId_NombreCol, moneda_id);
            camposTransferencia.Add(StockTransferenciasService.CostoAsociado_NombreCol, costo_asociado);
            camposTransferencia.Add(StockTransferenciasService.Cotizacion_NombreCol, cotizacion);
            camposTransferencia.Add(StockTransferenciasService.Autonumeraciones_NombreCol, autonumeracion_id);

            return StockTransferenciasService.Guardar(camposTransferencia, true, ref caso_transferencia, ref estado_transferencia, sesion);
        }

        #endregion CrearTransferencia

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "TRANSFERENCIAS STOCK NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.TransferenciaStockMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region ActualizarImpreso
        public static void ActualizarImpreso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarImpreso(caso_id, sesion);
            }
        }

        public static void ActualizarImpreso(decimal caso_id, SessionService sesion)
        {
            ActualizarFecha(caso_id, sesion);

            STOCK_TRANSFERENCIARow row = sesion.Db.STOCK_TRANSFERENCIACollection.GetRow(CasoId_NombreCol + " = " + caso_id);
            string valorAnterior = row.ToString();

            row.IMPRESO = Definiciones.SiNo.Si;
            sesion.db.STOCK_TRANSFERENCIACollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }

        public static void ActualizarFecha(decimal caso_id, SessionService sesion)
        {
            STOCK_TRANSFERENCIARow row = new STOCK_TRANSFERENCIARow();
            string valorAnterior = String.Empty;
            try
            {
                row = sesion.Db.STOCK_TRANSFERENCIACollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                valorAnterior = row.ToString();

                if (EsActualizable && row.IMPRESO == Definiciones.SiNo.No)
                    row.FECHA = DateTime.Today.Date;

                sesion.db.STOCK_TRANSFERENCIACollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                Hashtable campos = new Hashtable();
                campos.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                campos.Add(CasosService.NroComprobante_NombreCol, row.COMPROBANTE);
                if (!Interprete.EsNullODBNull(row.REMISION_EXTERNA))
                    campos.Add(CasosService.NroComprobante2_NombreCol, row.REMISION_EXTERNA);
                if (!row.IsPROVEEDOR_IDNull)
                    campos.Add(CasosService.PersonaId_NombreCol, row.PROVEEDOR_ID);
                if (!row.IsFUNCIONARIO_CHOFER_IDNull)
                    campos.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_CHOFER_ID);
                CasosService.ActualizarCampos(row.CASO_ID, campos, sesion);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool EsActualizable
        {
            get { return VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ReportesActualizarImpresoStockTransferencia).Equals(Definiciones.SiNo.Si); }

        }
        #endregion ActualizarImpreso

        #region DesmarcarImpreso
        public static void DesmarcarImpreso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                STOCK_TRANSFERENCIARow row = new STOCK_TRANSFERENCIARow();
                string valorAnterior = String.Empty;
                try
                {
                    row = sesion.Db.STOCK_TRANSFERENCIACollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                    valorAnterior = row.ToString();

                    row.IMPRESO = Definiciones.SiNo.No;
                    sesion.db.STOCK_TRANSFERENCIACollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion DesmarcarImpreso

        #region FueImpreso
        public static bool FueImpreso(decimal casoId)
        {
            if (casoId == Definiciones.Error.Valor.EnteroPositivo) return false;
            using (SessionService sesion = new SessionService())
            {
                STOCK_TRANSFERENCIARow row = sesion.Db.STOCK_TRANSFERENCIACollection.GetRow(CasoId_NombreCol + " = " + casoId);
                return row.IMPRESO.Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion FueImpreso

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "STOCK_TRANSFERENCIA"; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.CASO_IDColumnName; }
        }
        public static string Acompanante1_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.ACOMPANANTE1_IDColumnName; }
        }
        public static string Acompanante2_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.ACOMPANANTE2_IDColumnName; }
        }
        public static string Acompanante3_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.ACOMPANANTE3_IDColumnName; }
        }
        public static string Autonumeraciones_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.CASO_ASOCIADO_IDColumnName; }
        }
        public static string ChoferId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.FUNCIONARIO_CHOFER_IDColumnName; }
        }
        public static string ChoferNombre_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.CHOFER_NOMBREColumnName; }
        }
        public static string Comprobante_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.COMPROBANTEColumnName; }
        }
        public static string CostoAsociado_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.COSTO_ASOCIADOColumnName; }
        }
        public static string CostoTransferencia_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.COSTO_TRANSFERENCIAColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.COTIZACIONColumnName; }
        }
        public static string DepositoDestino_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.DEPOSITO_DESTINO_IDColumnName; }
        }
        public static string DepositoOrigen_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.DEPOSITO_ORIGEN_IDColumnName; }
        }
        public static string EsCasoOriginal_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.ES_CASO_ORIGINALColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.FECHAColumnName; }
        }
        public static string Impreso_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.IMPRESOColumnName; }
        }
        public static string VehiculoMarca_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.VEHICULO_MARCAColumnName; }
        }
        public static string VehiculoMatricula_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.VEHICULO_MATRICULAColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.MONEDA_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.OBSERVACIONColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.PROVEEDOR_IDColumnName; }
        }
        public static string SucursalDestinoId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.SUCURSAL_DESTINO_IDColumnName; }
        }
        public static string SucursalOrigenId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.SUCURSAL_ORIGEN_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string TotalCosto_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.TOTAL_COSTOColumnName; }
        }
        public static string VehiculoId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.VEHICULO_IDColumnName; }
        }
        public static string RemisionAutonumeracionId_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.REMISION_AUTONUMERACION_IDColumnName; }
        }
        public static string RemisionExterna_NombreCol
        {
            get { return STOCK_TRANSFERENCIACollection.REMISION_EXTERNAColumnName; }
        }
        #endregion Tablas

        #region Vistas
        public static string Nombre_Vista
        {
            get { return "STOCK_TRANSF_INFO_COMPL"; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoUsuarioCreacion_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.CASO_USUARIO_CREACIONColumnName; }
        }
        public static string VistaCodigoProveedor_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.CODIGOColumnName; }
        }
        public static string VistaCalle1_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.CALLE1ColumnName; }
        }
        public static string VistaDepositoDestino_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.DEPOSITO_DESTINOColumnName; }
        }
        public static string VistaDepositoDestinoAbreviatura_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.DEPOSITO_DESTINO_ABRColumnName; }
        }
        public static string VistaDepositoOrigen_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.DEPOSITO_ORIGENColumnName; }
        }
        public static string VistaDepositoOrigenAbreviatura_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.DEPOSITO_ORIGEN_ABRColumnName; }
        }
        public static string VistaMoneda_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.MONEDAColumnName; }
        }
        public static string VistaRazonSocial_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.RAZON_SOCIALColumnName; }
        }
        public static string VistaVehiculo_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.VEHICULOColumnName; }
        }
        public static string VistaSucursalDestino_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.SUCURSAL_DESTINOColumnName; }
        }
        public static string VistaSucursalDestinoAbreviatura_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.SUCURSAL_DESTINO_ABRColumnName; }
        }
        public static string VistaSucursalOrigen_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.SUCURSAL_ORIGENColumnName; }
        }
        public static string VistaSucursalOrigenAbreviatura_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.SUCURSAL_ORIGEN_ABRColumnName; }
        }
        public static string VistaTextoPredefinidoTexto_NombreCol
        {
            get { return STOCK_TRANSF_INFO_COMPLCollection.TEXTOColumnName; }
        }
        #endregion Vistas
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static StockTransferenciasService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new StockTransferenciasService(e.RegistroId, sesion);
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
        protected STOCK_TRANSFERENCIARow row;
        protected STOCK_TRANSFERENCIARow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? Acompanhante1Id { get { if (row.IsACOMPANANTE1_IDNull) return null; else return row.ACOMPANANTE1_ID; } set { if (value.HasValue) row.ACOMPANANTE1_ID = value.Value; else row.IsACOMPANANTE1_IDNull = true; } }
        public decimal? Acompanhante2Id { get { if (row.IsACOMPANANTE2_IDNull) return null; else return row.ACOMPANANTE2_ID; } set { if (value.HasValue) row.ACOMPANANTE2_ID = value.Value; else row.IsACOMPANANTE2_IDNull = true; } }
        public decimal? Acompanhante3Id { get { if (row.IsACOMPANANTE3_IDNull) return null; else return row.ACOMPANANTE3_ID; } set { if (value.HasValue) row.ACOMPANANTE3_ID = value.Value; else row.IsACOMPANANTE3_IDNull = true; } }
        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public decimal? CasoAsociadoId { get { if (row.IsCASO_ASOCIADO_IDNull) return null; else return row.CASO_ASOCIADO_ID; } set { if (value.HasValue) row.CASO_ASOCIADO_ID = value.Value; else row.IsCASO_ASOCIADO_IDNull = true; } }
        public decimal? CasoId { get { if (row.IsCASO_IDNull) return null; else return row.CASO_ID; } set { if (value.HasValue) row.CASO_ID = value.Value; else row.IsCASO_IDNull = true; } }
        public string ChoferNombre { get { return GetStringHelper(row.CHOFER_NOMBRE); } set { row.CHOFER_NOMBRE = value; } }
        public string Comprobante { get { return GetStringHelper(row.COMPROBANTE); } set { row.COMPROBANTE = value; } }
        public decimal? CostoAsociado { get { if (row.IsCOSTO_ASOCIADONull) return null; else return row.COSTO_ASOCIADO; } set { if (value.HasValue) row.COSTO_ASOCIADO = value.Value; else row.IsCOSTO_ASOCIADONull = true; } }
        public decimal? CostoTransferencia { get { if (row.IsCOSTO_TRANSFERENCIANull) return null; else return row.COSTO_TRANSFERENCIA; } set { if (value.HasValue) row.COSTO_TRANSFERENCIA = value.Value; else row.IsCOSTO_TRANSFERENCIANull = true; } }
        public decimal? Cotizacion { get { if (row.IsCOTIZACIONNull) return null; else return row.COTIZACION; } set { if (value.HasValue) row.COTIZACION = value.Value; else row.IsCOTIZACIONNull = true; } }
        public string EsCasoOriginal { get { return GetStringHelper(row.ES_CASO_ORIGINAL); } set { row.ES_CASO_ORIGINAL = value; } }
        public decimal DepositoDestinoId { get { return row.DEPOSITO_DESTINO_ID; } set { row.DEPOSITO_DESTINO_ID = value; } }
        public decimal DepositoOrigenId { get { return row.DEPOSITO_ORIGEN_ID; } set { row.DEPOSITO_ORIGEN_ID = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal? FuncionarioChoferId { get { if (row.IsFUNCIONARIO_CHOFER_IDNull) return null; else return row.FUNCIONARIO_CHOFER_ID; } set { if (value.HasValue) row.FUNCIONARIO_CHOFER_ID = value.Value; else row.IsFUNCIONARIO_CHOFER_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? MonedaId { get { if (row.IsMONEDA_IDNull) return null; else return row.MONEDA_ID; } set { if (value.HasValue) row.MONEDA_ID = value.Value; else row.IsMONEDA_IDNull = true; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }
        public decimal? RemisionAutonumeracionId { get { if (row.IsREMISION_AUTONUMERACION_IDNull) return null; else return row.REMISION_AUTONUMERACION_ID; } set { if (value.HasValue) row.REMISION_AUTONUMERACION_ID = value.Value; else row.IsREMISION_AUTONUMERACION_IDNull = true; } }
        public string RemisionExterna { get { return GetStringHelper(row.REMISION_EXTERNA); } set { row.REMISION_EXTERNA = value; } }
        public decimal SucursalDestinoId { get { return row.SUCURSAL_DESTINO_ID; } set { row.SUCURSAL_DESTINO_ID = value; } }
        public decimal SucursalOrigenId { get { return row.SUCURSAL_ORIGEN_ID; } set { row.SUCURSAL_ORIGEN_ID = value; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        public decimal? TotalCosto { get { if (row.IsTOTAL_COSTONull) return null; else return row.TOTAL_COSTO; } set { if (value.HasValue) row.TOTAL_COSTO = value.Value; else row.IsTOTAL_COSTONull = true; } }
        public decimal? VehiculoId { get { if (row.IsVEHICULO_IDNull) return null; else return row.VEHICULO_ID; } set { if (value.HasValue) row.VEHICULO_ID = value.Value; else row.IsVEHICULO_IDNull = true; } }
        public string VehiculoMarca { get { return GetStringHelper(row.VEHICULO_MARCA); } set { row.VEHICULO_MARCA = value; } }
        public string VehiculoMatricula { get { return GetStringHelper(row.VEHICULO_MATRICULA); } set { row.VEHICULO_MATRICULA = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private FuncionariosService _acompanhante1;
        public FuncionariosService Acompanhante1
        {
            get
            {
                if (this._acompanhante1 == null)
                {
                    if (this.sesion != null)
                        this._acompanhante1 = new FuncionariosService(this.Acompanhante1Id.Value, this.sesion);
                    else
                        this._acompanhante1 = new FuncionariosService(this.Acompanhante1Id.Value);
                }
                return this._acompanhante1;
            }
        }

        private FuncionariosService _acompanhante2;
        public FuncionariosService Acompanhante2
        {
            get
            {
                if (this._acompanhante2 == null)
                {
                    if (this.sesion != null)
                        this._acompanhante2 = new FuncionariosService(this.Acompanhante2Id.Value, this.sesion);
                    else
                        this._acompanhante2 = new FuncionariosService(this.Acompanhante2Id.Value);
                }
                return this._acompanhante2;
            }
        }

        private FuncionariosService _acompanhante3;
        public FuncionariosService Acompanhante3
        {
            get
            {
                if (this._acompanhante3 == null)
                {
                    if (this.sesion != null)
                        this._acompanhante3 = new FuncionariosService(this.Acompanhante3Id.Value, this.sesion);
                    else
                        this._acompanhante3 = new FuncionariosService(this.Acompanhante3Id.Value);
                }
                return this._acompanhante3;
            }
        }

        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    if (this.sesion != null)
                        this._caso = new CasosService(this.CasoId.Value, this.sesion);
                    else
                        this._caso = new CasosService(this.CasoId.Value);
                }
                return this._caso;
            }
        }

        private CasosService _caso_asociado;
        public CasosService CasoAsociado
        {
            get
            {
                if (this._caso_asociado == null)
                {
                    if (this.sesion != null)
                        this._caso_asociado = new CasosService(this.CasoAsociadoId.Value, this.sesion);
                    else
                        this._caso_asociado = new CasosService(this.CasoAsociadoId.Value);
                }
                return this._caso_asociado;
            }
        }

        private StockDepositosService _deposito_origen;
        public StockDepositosService DepositoOrigen
        {
            get
            {
                if (this._deposito_origen == null)
                {
                    if (this.sesion != null)
                        this._deposito_origen = new StockDepositosService(this.DepositoOrigenId, this.sesion);
                    else
                        this._deposito_origen = new StockDepositosService(this.DepositoOrigenId);
                }
                return this._deposito_origen;
            }
        }

        private StockDepositosService _deposito_destino;
        public StockDepositosService DepositoDestino
        {
            get
            {
                if (this._deposito_destino == null)
                {
                    if (this.sesion != null)
                        this._deposito_destino = new StockDepositosService(this.DepositoDestinoId, this.sesion);
                    else
                        this._deposito_destino = new StockDepositosService(this.DepositoDestinoId);
                }
                return this._deposito_destino;
            }
        }

        private FuncionariosService _funcionario_chofer;
        public FuncionariosService FuncionarioChofer
        {
            get
            {
                if (this._funcionario_chofer == null)
                {
                    if (this.sesion != null)
                        this._funcionario_chofer = new FuncionariosService(this.FuncionarioChoferId.Value, this.sesion);
                    else
                        this._funcionario_chofer = new FuncionariosService(this.FuncionarioChoferId.Value);
                }
                return this._funcionario_chofer;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                {
                    if (this.sesion != null)
                        this._moneda = new MonedasService(this.MonedaId.Value, this.sesion);
                    else
                        this._moneda = new MonedasService(this.MonedaId.Value);
                }
                return this._moneda;
            }
        }

        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                {
                    if (this.sesion != null)
                        this._proveedor = new ProveedoresService(this.ProveedorId.Value, this.sesion);
                    else
                        this._proveedor = new ProveedoresService(this.ProveedorId.Value);
                }
                return this._proveedor;
            }
        }

        private SucursalesService _sucursal_destino;
        public SucursalesService SucursalDestion
        {
            get
            {
                if (this._sucursal_destino == null)
                {
                    if (this.sesion != null)
                        this._sucursal_destino = new SucursalesService(this.SucursalDestinoId, this.sesion);
                    else
                        this._sucursal_destino = new SucursalesService(this.SucursalDestinoId);
                }
                return this._sucursal_destino;
            }
        }

        private SucursalesService _sucursal_origen;
        public SucursalesService SucursalOrigen
        {
            get
            {
                if (this._sucursal_origen == null)
                {
                    if (this.sesion != null)
                        this._sucursal_origen = new SucursalesService(this.SucursalOrigenId, this.sesion);
                    else
                        this._sucursal_origen = new SucursalesService(this.SucursalOrigenId);
                }
                return this._sucursal_origen;
            }
        }

        private TextosPredefinidosService _texto_predefinido;
        public TextosPredefinidosService TextoPredefinido
        {
            get
            {
                if (this._texto_predefinido == null)
                {
                    if (this.sesion != null)
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value, this.sesion);
                    else
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value);
                }
                return this._texto_predefinido;
            }
        }

        private VehiculosService _vehiculo;
        public VehiculosService Vehiculo
        {
            get
            {
                if (this._vehiculo == null)
                {
                    if (this.sesion != null)
                        this._vehiculo = new VehiculosService(this.VehiculoId.Value, this.sesion);
                    else
                        this._vehiculo = new VehiculosService(this.VehiculoId.Value);
                }
                return this._vehiculo;
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private StockTransferenciaDetalleService[] stock_transferencia_detalles;
        public StockTransferenciaDetalleService[] StockTransferenciaDetalles
        {
            get
            {
                if (this.stock_transferencia_detalles == null)
                    this.stock_transferencia_detalles = StockTransferenciaDetalleService.GetPorCabecera(this.Id.Value);
                return this.stock_transferencia_detalles;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.STOCK_TRANSFERENCIACollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_TRANSFERENCIARow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(STOCK_TRANSFERENCIARow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public StockTransferenciasService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockTransferenciasService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockTransferenciasService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        private StockTransferenciasService(STOCK_TRANSFERENCIARow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._acompanhante1 = null;
            this._acompanhante2 = null;
            this._acompanhante3 = null;
            this._caso = null;
            this._caso_asociado = null;
            this._deposito_destino = null;
            this._deposito_origen = null;
            this._funcionario_chofer = null;
            this._moneda = null;
            this._proveedor = null;
            this._sucursal_destino = null;
            this._sucursal_origen = null;
            this._texto_predefinido = null;
            this._vehiculo = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region GetPorCaso
        public static StockTransferenciasService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static StockTransferenciasService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.STOCK_TRANSFERENCIACollection.GetByCASO_ID(caso_id)[0];
            return new StockTransferenciasService(row);
        }
        #endregion GetPorCaso
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}