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
    public class StockTransferenciasInsumosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de Metodos Abstractos
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.TRANSFERENCIA_DE_INSUMOS;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
          //  campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.SucursalRelacionada, drCabecera[StockTransferenciasInsumosService.SucursalDestinoId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drCabecera[StockTransferenciasInsumosService.DepositoOrigen_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[StockTransferenciaInsumosDetalleService.ArticuloId_NombreCol]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[StockTransferenciasInsumosService.TextoPredefinidoId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            STOCK_TRANSFERENCIA_INSUMOSRow[] rows;
            rows = sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetByCASO_ID(caso_id);
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

                mensaje = "";
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    STOCK_TRANSFERENCIA_INSUMOSRow transferenciaRow = sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetByCASO_ID(caso_id)[0];
                    STOCK_TRANSFERENCIA_INSUMOS_DETRow[] detalleRows = sesion.Db.STOCK_TRANSFERENCIA_INSUMOS_DETCollection.GetByTRANSFERENCIA_INSUMOS_ID(transferenciaRow.ID);
                    // de borrador a anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        exito = true;
                    }
                    #region de borrador a pendiente
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
                    #endregion de borrador a pendiente

                    #region de pendiente a borrador
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
                    #endregion de pendiente a borrador

                    #region de pendiente a aprobado
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
                    #endregion de pendiente a aprobado

                    #region de aprobado a pendiente
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
                    #endregion de aprobado a pendiente

                    #region de aprobado a viajando
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
                            
                               foreach (STOCK_TRANSFERENCIA_INSUMOS_DETRow detalle in detalleRows)
                                {
                                   // salida de stock (por detalle) del deposito de cabecera.
                                    tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaSalida;
                                    StockService.modificarStock(transferenciaRow.DEPOSITO_ORIGEN_ID,
                                                         detalle.ARTICULO_ID,
                                                         Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                                         tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                                         sesion, null, null, detalle.ID);
                                }
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }
                    #endregion de aprobado a viajando

                    #region viajando a aprobado
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

                           /* if (exito && !transferenciaRow.IsCASO_ASOCIADO_IDNull)
                            {
                                string tipoMovimiento = string.Empty;
                                foreach (STOCK_TRANSFERENCIA_INSUMOS_DETRow detalle in detalleRows)
                                {
                                    tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaEntrada;
                                    StockService.modificarStock(transferenciaRow.DEPOSITO_ORIGEN_ID,
                                                         detalle.ARTICULO_ID,
                                                         Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                                         tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                                         sesion, null, null, detalle.ID);
                                }
                            }*/

                            //Borrar el asiento de Aprobado a Viajando
                            decimal transicionId = TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.TRANSFERENCIA_DE_INSUMOS, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Viajando, sesion);
                            Contabilidad.AsientosService.BorrarPorCasoYTransicion(caso_id, transicionId, sesion);
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }
                    #endregion viajando a aprobado

                    #region viajando a EnRevision
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Viajando) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.EnRevision))
                    {
                     
                        exito = true;
                        // solo se pasa de estado
                        #region Verificar Puede Avanzar Estado
                        if (exito)
                        {
                            exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                        }
                        #endregion Verificar Puede Avanzar Estado
                    }
                    #endregion viajando a EnRevision

                    #region en-revision a cerrado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnRevision) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        try
                        {
                            // verificar que todos los detalles esten recibidos para cerrar el caso
                            foreach (STOCK_TRANSFERENCIA_INSUMOS_DETRow detalle in detalleRows)
                            {
                                if (detalle.RECIBIDO.ToString().Equals(Definiciones.SiNo.No))
                                    throw new Exception("No se puede concretar la transición a CERRADO. Hay insumos no recibidos en al menos un depósito.");
                            }
                            exito = true;

                            #region Verificar Puede Avanzar Estado
                            if (exito)
                            {
                                exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                            }
                            #endregion Verificar Puede Avanzar Estado
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }
                    #endregion en-revision a cerrado

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.Update(transferenciaRow);
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
            return sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetAsDataTable(clausula, orden);
        }
        /*
        /// <summary>
        /// Gets the stock A tranferencia data table por sucursal.
        /// </summary>
        /// <param name="id_sucursal">The id_sucursal.</param>
        /// <returns></returns>
        public DataTable GetStockATranferenciaDataTablePorSucursal(decimal id_sucursal)
        {
            return GetStockTransferenciaDataTable2(SucursalDestinoId_NombreCol + " = " + id_sucursal + " or " + SucursalOrigenId_NombreCol+ " = " + id_sucursal, string.Empty);
        }
         */
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
            return sesion.Db.STOCK_TRANSF_INSUMO_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
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
                return sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetAsDataTable(StockTransferenciasInsumosService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetStockTransferenciaPorCaso

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
            STOCK_TRANSFERENCIA_INSUMOSRow row = new STOCK_TRANSFERENCIA_INSUMOSRow();
            try
            {
                string valorAnterior = string.Empty;
                
                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("stock_transferencia_insumo_sqc");
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalOrigenId_NombreCol].ToString()),
                                                         int.Parse(Definiciones.FlujosIDs.TRANSFERENCIA_DE_INSUMOS.ToString()),
                                                         int.Parse(sesion.Usuario_Id.ToString()),
                                                         SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.IMPRESO = Definiciones.SiNo.No;
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                    if (campos.Contains(StockTransferenciasInsumosService.EsCasoOriginal_NombreCol))
                        row.ES_CASO_ORIGINAL = (string)campos[StockTransferenciasInsumosService.EsCasoOriginal_NombreCol];
                    else
                        row.ES_CASO_ORIGINAL = Definiciones.SiNo.Si;
                }
                else
                {
                    row = sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetByPrimaryKey(decimal.Parse(campos[StockTransferenciasInsumosService.Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }
                
                if (campos.Contains(StockTransferenciasInsumosService.Acompanante1_NombreCol))
                    row.ACOMPANANTE1_ID = decimal.Parse(campos[StockTransferenciasInsumosService.Acompanante1_NombreCol].ToString());
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

                if (campos.Contains(StockTransferenciasInsumosService.Acompanante2_NombreCol))
                    row.ACOMPANANTE2_ID = decimal.Parse(campos[StockTransferenciasInsumosService.Acompanante2_NombreCol].ToString());
                else
                    row.IsACOMPANANTE2_IDNull = true;

                if (campos.Contains(StockTransferenciasInsumosService.Acompanante3_NombreCol))
                    row.ACOMPANANTE3_ID = decimal.Parse(campos[StockTransferenciasInsumosService.Acompanante3_NombreCol].ToString());
                else
                    row.IsACOMPANANTE3_IDNull = true;

                if (campos.Contains(StockTransferenciasInsumosService.Autonumeraciones_NombreCol))
                {
                    row.AUTONUMERACION_ID = decimal.Parse(campos[StockTransferenciasInsumosService.Autonumeraciones_NombreCol].ToString());
                }

                if (campos.Contains(StockTransferenciasInsumosService.CasoAsociadoId_NombreCol))
                    row.CASO_ASOCIADO_ID = decimal.Parse(campos[StockTransferenciasInsumosService.CasoAsociadoId_NombreCol].ToString());

                if (campos.Contains(StockTransferenciasInsumosService.ChoferId_NombreCol))
                        row.FUNCIONARIO_CHOFER_ID = decimal.Parse(campos[StockTransferenciasInsumosService.ChoferId_NombreCol].ToString());
                else
                    row.IsFUNCIONARIO_CHOFER_IDNull = true;

                if (campos.Contains(StockTransferenciasInsumosService.ProveedorId_NombreCol))
                        row.PROVEEDOR_ID = decimal.Parse(campos[StockTransferenciasInsumosService.ProveedorId_NombreCol].ToString());
                else
                    row.IsPROVEEDOR_IDNull = true;

                if (campos.Contains(StockTransferenciasInsumosService.ChoferNombre_NombreCol))
                    row.CHOFER_NOMBRE = campos[StockTransferenciasInsumosService.ChoferNombre_NombreCol].ToString();

                if (campos.Contains(StockTransferenciasInsumosService.Comprobante_NombreCol))
                    row.COMPROBANTE = campos[StockTransferenciasInsumosService.Comprobante_NombreCol].ToString();
                if (campos.Contains(StockTransferenciasInsumosService.CostoAsociado_NombreCol))
                    row.COSTO_ASOCIADO = decimal.Parse(campos[StockTransferenciasInsumosService.CostoAsociado_NombreCol].ToString());
                if (campos.Contains(StockTransferenciasInsumosService.CostoTransferencia_NombreCol))
                    row.COSTO_TRANSFERENCIA = decimal.Parse(campos[StockTransferenciasInsumosService.CostoTransferencia_NombreCol].ToString());
                if (campos.Contains(StockTransferenciasInsumosService.Cotizacion_NombreCol))
                    row.COTIZACION = decimal.Parse(campos[StockTransferenciasInsumosService.Cotizacion_NombreCol].ToString());

                if (campos.Contains(StockTransferenciasInsumosService.DepositoOrigen_NombreCol))
                {                    
                        var depositoOrigen = new StockDepositosService(decimal.Parse(campos[StockTransferenciasInsumosService.DepositoOrigen_NombreCol].ToString()), sesion);
                        if (depositoOrigen.Estado == Definiciones.Estado.Inactivo)
                            throw new Exception("El depósito origen está inactivo.");

                        row.DEPOSITO_ORIGEN_ID = depositoOrigen.Id.Value;
                        row.SUCURSAL_ORIGEN_ID = depositoOrigen.SucursalId;               
                }

                row.FECHA = (DateTime)campos[StockTransferenciasInsumosService.Fecha_NombreCol];
                row.OBSERVACION = (string)campos[StockTransferenciasInsumosService.Observacion_NombreCol];

                if (campos.Contains(StockTransferenciasInsumosService.MonedaId_NombreCol))
                    row.MONEDA_ID = decimal.Parse(campos[StockTransferenciasInsumosService.MonedaId_NombreCol].ToString());
                if (campos.Contains(StockTransferenciasInsumosService.TotalCosto_NombreCol))
                    row.TOTAL_COSTO = decimal.Parse(campos[StockTransferenciasInsumosService.TotalCosto_NombreCol].ToString());
                
                if (campos.Contains(StockTransferenciasInsumosService.VehiculoId_NombreCol))
                    row.VEHICULO_ID = decimal.Parse(campos[StockTransferenciasInsumosService.VehiculoId_NombreCol].ToString());
                else
                    row.IsVEHICULO_IDNull= true;
                
                if (campos.Contains(StockTransferenciasInsumosService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = decimal.Parse(campos[StockTransferenciasInsumosService.TextoPredefinidoId_NombreCol].ToString());
                else
                    row.IsTEXTO_PREDEFINIDO_IDNull = true;
                
                if (campos.Contains(StockTransferenciasInsumosService.VehiculoMarca_NombreCol))
                    row.VEHICULO_MARCA = campos[StockTransferenciasInsumosService.VehiculoMarca_NombreCol].ToString();
                if (campos.Contains(StockTransferenciasInsumosService.VehiculoMatricula_NombreCol))
                    row.VEHICULO_MATRICULA = campos[StockTransferenciasInsumosService.VehiculoMatricula_NombreCol].ToString();

                if (insertarNuevo) sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.Insert(row);
                else sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.COMPROBANTE);
                if (row.ES_CASO_ORIGINAL == Definiciones.SiNo.Si)
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ORIGEN_ID);
               
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
                
                STOCK_TRANSFERENCIA_INSUMOSRow row = sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetByPrimaryKey(transferencia_id);

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
                    STOCK_TRANSFERENCIA_INSUMOSRow cabecera = sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetByCASO_ID(caso_id)[0];
                    STOCK_TRANSFERENCIA_INSUMOS_DETRow[] detalles = sesion.Db.STOCK_TRANSFERENCIA_INSUMOS_DETCollection.GetByTRANSFERENCIA_INSUMOS_ID(cabecera.ID);

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
                                StockTransferenciaInsumosDetalleService.Borrar(detalles[i].ID, sesion);
                            }
                        }

                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.DeleteByCASO_ID(caso_id);
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

        public static bool CrearTransferencia_obsoleto(decimal sucursal_destino_id, decimal sucursal_origen_id, decimal deposito_origen_id, decimal deposito_destino_id, DateTime fecha, decimal moneda_id, decimal costo_asociado, decimal cotizacion, decimal autonumeracion_id, ref decimal caso_transferencia, ref string estado_transferencia, SessionService sesion)
        {
            System.Collections.Hashtable camposTransferencia = new System.Collections.Hashtable();
            camposTransferencia.Add(StockTransferenciasInsumosService.SucursalOrigenId_NombreCol, sucursal_origen_id);
            camposTransferencia.Add(StockTransferenciasInsumosService.DepositoOrigen_NombreCol, deposito_origen_id);
           // camposTransferencia.Add(StockTransferenciasInsumosService.DepositoDestino_NombreCol, deposito_destino_id);
            //camposTransferencia.Add(StockTransferenciasInsumosService.SucursalDestinoId_NombreCol, sucursal_destino_id);
            camposTransferencia.Add(StockTransferenciasInsumosService.Fecha_NombreCol, fecha);
            camposTransferencia.Add(StockTransferenciasInsumosService.MonedaId_NombreCol, moneda_id);
            camposTransferencia.Add(StockTransferenciasInsumosService.CostoAsociado_NombreCol, costo_asociado);
            camposTransferencia.Add(StockTransferenciasInsumosService.Cotizacion_NombreCol, cotizacion);
            camposTransferencia.Add(StockTransferenciasInsumosService.Autonumeraciones_NombreCol, autonumeracion_id);

            return StockTransferenciasInsumosService.Guardar(camposTransferencia, true, ref caso_transferencia, ref estado_transferencia, sesion);
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

            STOCK_TRANSFERENCIA_INSUMOSRow row = sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetRow(CasoId_NombreCol + " = " + caso_id);
            string valorAnterior = row.ToString();

            row.IMPRESO = Definiciones.SiNo.Si;
            sesion.db.STOCK_TRANSFERENCIA_INSUMOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }

        public static void ActualizarFecha(decimal caso_id, SessionService sesion)
        {
            STOCK_TRANSFERENCIA_INSUMOSRow row = new STOCK_TRANSFERENCIA_INSUMOSRow();
            string valorAnterior = String.Empty;
            try
            {
                row = sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                valorAnterior = row.ToString();

                if (EsActualizable && row.IMPRESO == Definiciones.SiNo.No)
                    row.FECHA = DateTime.Today.Date;

                sesion.db.STOCK_TRANSFERENCIA_INSUMOSCollection.Update(row);
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
                STOCK_TRANSFERENCIA_INSUMOSRow row = new STOCK_TRANSFERENCIA_INSUMOSRow();
                string valorAnterior = String.Empty;
                try
                {
                    row = sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                    valorAnterior = row.ToString();

                    row.IMPRESO = Definiciones.SiNo.No;
                    sesion.db.STOCK_TRANSFERENCIA_INSUMOSCollection.Update(row);
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
                STOCK_TRANSFERENCIA_INSUMOSRow row = sesion.Db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetRow(CasoId_NombreCol + " = " + casoId);
                return row.IMPRESO.Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion FueImpreso

        #region Accessors
        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "stock_transferencia_insumos"; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.CASO_IDColumnName; }
        }
        public static string Acompanante1_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.ACOMPANANTE1_IDColumnName; }
        }
        public static string Acompanante2_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.ACOMPANANTE2_IDColumnName; }
        }
        public static string Acompanante3_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.ACOMPANANTE3_IDColumnName; }
        }
        public static string Autonumeraciones_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.CASO_ASOCIADO_IDColumnName; }
        }
        public static string ChoferId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.FUNCIONARIO_CHOFER_IDColumnName; }
        }
        public static string ChoferNombre_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.CHOFER_NOMBREColumnName; }
        }
        public static string Comprobante_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.COMPROBANTEColumnName; }
        }
        public static string CostoAsociado_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.COSTO_ASOCIADOColumnName; }
        }
        public static string CostoTransferencia_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.COSTO_TRANSFERENCIAColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.COTIZACIONColumnName; }
        }
        public static string DepositoOrigen_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.DEPOSITO_ORIGEN_IDColumnName; }
        }
        public static string EsCasoOriginal_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.ES_CASO_ORIGINALColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.FECHAColumnName; }
        }
        public static string Impreso_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.IMPRESOColumnName; }
        }
        public static string VehiculoMarca_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.VEHICULO_MARCAColumnName; }
        }
        public static string VehiculoMatricula_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.VEHICULO_MATRICULAColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.MONEDA_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.OBSERVACIONColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.PROVEEDOR_IDColumnName; }
        }

        public static string SucursalOrigenId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.SUCURSAL_ORIGEN_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string TotalCosto_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.TOTAL_COSTOColumnName; }
        }
        public static string VehiculoId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.VEHICULO_IDColumnName; }
        }
        public static string RemisionAutonumeracionId_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.REMISION_AUTONUMERACION_IDColumnName; }
        }
        public static string RemisionExterna_NombreCol
        {
            get { return STOCK_TRANSFERENCIA_INSUMOSCollection.REMISION_EXTERNAColumnName; }
        }
        #endregion Tablas

        #region Vistas
        public static string Nombre_Vista
        {
            get { return "stock_transf_insumo_info_compl"; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoUsuarioCreacion_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.CASO_USUARIO_CREACIONColumnName; }
        }
        public static string VistaCodigoProveedor_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.CODIGOColumnName; }
        }
        public static string VistaCalle1_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.CALLE1ColumnName; }
        }
      
        public static string VistaDepositoOrigen_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.DEPOSITO_ORIGENColumnName; }
        }
        public static string VistaDepositoOrigenAbreviatura_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.DEPOSITO_ORIGEN_ABRColumnName; }
        }
        public static string VistaMoneda_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.MONEDAColumnName; }
        }
        public static string VistaRazonSocial_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.RAZON_SOCIALColumnName; }
        }
        public static string VistaVehiculo_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.VEHICULOColumnName; }
        }
       
        public static string VistaSucursalOrigen_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.SUCURSAL_ORIGENColumnName; }
        }
        public static string VistaSucursalOrigenAbreviatura_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.SUCURSAL_ORIGEN_ABRColumnName; }
        }
        public static string VistaTextoPredefinidoTexto_NombreCol
        {
            get { return STOCK_TRANSF_INSUMO_INFO_COMPLCollection.TEXTOColumnName; }
        }
        #endregion Vistas
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static StockTransferenciasInsumosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new StockTransferenciasInsumosService(e.RegistroId, sesion);
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
        protected STOCK_TRANSFERENCIA_INSUMOSRow row;
        protected STOCK_TRANSFERENCIA_INSUMOSRow rowSinModificar;

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
        public decimal DepositoOrigenId { get { return row.DEPOSITO_ORIGEN_ID; } set { row.DEPOSITO_ORIGEN_ID = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal? FuncionarioChoferId { get { if (row.IsFUNCIONARIO_CHOFER_IDNull) return null; else return row.FUNCIONARIO_CHOFER_ID; } set { if (value.HasValue) row.FUNCIONARIO_CHOFER_ID = value.Value; else row.IsFUNCIONARIO_CHOFER_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? MonedaId { get { if (row.IsMONEDA_IDNull) return null; else return row.MONEDA_ID; } set { if (value.HasValue) row.MONEDA_ID = value.Value; else row.IsMONEDA_IDNull = true; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }
        public decimal? RemisionAutonumeracionId { get { if (row.IsREMISION_AUTONUMERACION_IDNull) return null; else return row.REMISION_AUTONUMERACION_ID; } set { if (value.HasValue) row.REMISION_AUTONUMERACION_ID = value.Value; else row.IsREMISION_AUTONUMERACION_IDNull = true; } }
        public string RemisionExterna { get { return GetStringHelper(row.REMISION_EXTERNA); } set { row.REMISION_EXTERNA = value; } }
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
        private StockTransferenciaInsumosDetalleService[] stock_transferencia_ins_detalles;
        public StockTransferenciaInsumosDetalleService[] StockTransferenciaInsumoDetalles
        {
            get
            {
                if (this.stock_transferencia_ins_detalles == null)
                    this.stock_transferencia_ins_detalles = StockTransferenciaInsumosDetalleService.GetPorCabecera(this.Id.Value);
                return this.stock_transferencia_ins_detalles;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_TRANSFERENCIA_INSUMOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(STOCK_TRANSFERENCIA_INSUMOSRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public StockTransferenciasInsumosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockTransferenciasInsumosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockTransferenciasInsumosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        private StockTransferenciasInsumosService(STOCK_TRANSFERENCIA_INSUMOSRow row)
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
            this._deposito_origen = null;
            this._funcionario_chofer = null;
            this._moneda = null;
            this._proveedor = null;
            this._sucursal_origen = null;
            this._texto_predefinido = null;
            this._vehiculo = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region GetPorCaso
        public static StockTransferenciasInsumosService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static StockTransferenciasInsumosService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.STOCK_TRANSFERENCIA_INSUMOSCollection.GetByCASO_ID(caso_id)[0];
            return new StockTransferenciasInsumosService(row);
        }
        #endregion GetPorCaso
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}