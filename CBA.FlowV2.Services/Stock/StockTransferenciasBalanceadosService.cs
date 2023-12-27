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
    public class StockTransferenciasBalanceadosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de Metodos Abstractos
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.TRANSFERENCIA_DE_BALANCEADOS;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);            
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, drDetalle[StockTransferenciaBalanceadosDetalleService.Modelo.DEPOSITO_ORIGEN_IDColumnName]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, drDetalle[StockTransferenciaBalanceadosDetalleService.Modelo.ARTICULO_IDColumnName]);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[StockTransferenciasBalanceadosService.Modelo.TEXTO_PREDEFINIDO_IDColumnName]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            STOCK_TRANSFERENCIA_BALANCEADOSRow[] rows;
            rows = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByCASO_ID(caso_id);
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
                STOCK_TRANSFERENCIA_BALANCEADOSRow transferenciaRow = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByCASO_ID(caso_id)[0];
                STOCK_TRANSFERENCIA_BALANC_DETRow[] detalleRows = sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetByTRANSFERENCIA_BALANC_ID(transferenciaRow.ID);
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
                    if (transferenciaRow.IsVEHICULO_IDNull)
                        throw new Exception("Debe indicar los datos del vehículo");

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
                        if (ClaseCBABase.GetStringHelper(transferenciaRow.REMISION_EXTERNA) == string.Empty && !transferenciaRow.IsREMISION_AUTONUMERACION_IDNull)
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

                        foreach (STOCK_TRANSFERENCIA_BALANC_DETRow detalle in detalleRows)
                        {
                            // salida de stock (por detalle) del deposito de cabecera.
                            tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaSalida;
                            StockService.modificarStock(detalle.DEPOSITO_ORIGEN_ID,
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

                        if (exito && !transferenciaRow.IsCASO_ASOCIADO_IDNull)
                        {
                            string tipoMovimiento = string.Empty;
                            foreach (STOCK_TRANSFERENCIA_BALANC_DETRow detalle in detalleRows)
                            {
                                tipoMovimiento = Definiciones.Stock.TipoMovimiento.TransferenciaEntrada;
                                StockService.modificarStock(detalle.DEPOSITO_ORIGEN_ID,
                                                     detalle.ARTICULO_ID,
                                                     Interprete.Redondear(detalle.CANTIDAD_UNITARIA_ORIG_TOTAL, 3),
                                                     tipoMovimiento, caso_id, detalle.LOTE_ID, estado_destino,
                                                     sesion, null, null, detalle.ID);
                            }
                        }

                        //Borrar el asiento de Aprobado a Viajando
                        decimal transicionId = TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.TRANSFERENCIA_DE_BALANCEADOS, Definiciones.EstadosFlujos.Aprobado, Definiciones.EstadosFlujos.Viajando, sesion);
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
                        foreach (STOCK_TRANSFERENCIA_BALANC_DETRow detalle in detalleRows)
                        {
                            if (detalle.RECIBIDO.ToString().Equals(Definiciones.SiNo.No))
                                throw new Exception("No se puede concretar la transición a CERRADO. Hay balanceados no recibidos en al menos un depósito.");
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
                    sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.Update(transferenciaRow);
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
            return sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetAsDataTable(clausula, orden);
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
            return sesion.Db.STOCK_TRANSF_BALANC_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
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
                return sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetAsDataTable(StockTransferenciasBalanceadosService.Modelo.CASO_IDColumnName + " = " + caso_id, string.Empty);
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
            STOCK_TRANSFERENCIA_BALANCEADOSRow row = new STOCK_TRANSFERENCIA_BALANCEADOSRow();
            try
            {
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("STOCK_TRANSFERENCIA_BALANC_SQC");
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[StockTransferenciasBalanceadosService.Modelo.SUCURSAL_ORIGEN_IDColumnName].ToString()),
                                                         int.Parse(Definiciones.FlujosIDs.TRANSFERENCIA_DE_BALANCEADOS.ToString()),
                                                         int.Parse(sesion.Usuario_Id.ToString()),
                                                         SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.IMPRESO = Definiciones.SiNo.No;
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                    if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.ES_CASO_ORIGINALColumnName))
                        row.ES_CASO_ORIGINAL = (string)campos[StockTransferenciasBalanceadosService.Modelo.ES_CASO_ORIGINALColumnName];
                    else
                        row.ES_CASO_ORIGINAL = Definiciones.SiNo.Si;
                }
                else
                {
                    row = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByPrimaryKey(decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.IDColumnName].ToString()));
                    valorAnterior = row.ToString();
                }

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.ACOMPANANTE1_IDColumnName))
                    row.ACOMPANANTE1_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.ACOMPANANTE1_IDColumnName].ToString());
                else
                    row.IsACOMPANANTE1_IDNull = true;

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.REMISION_EXTERNAColumnName))
                    row.REMISION_EXTERNA = campos[StockTransferenciasBalanceadosService.Modelo.REMISION_EXTERNAColumnName].ToString();

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.REMISION_AUTONUMERACION_IDColumnName))
                {
                    row.REMISION_AUTONUMERACION_ID = (decimal)campos[StockTransferenciasBalanceadosService.Modelo.REMISION_AUTONUMERACION_IDColumnName];

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

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.ACOMPANANTE2_IDColumnName))
                    row.ACOMPANANTE2_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.ACOMPANANTE2_IDColumnName].ToString());
                else
                    row.IsACOMPANANTE2_IDNull = true;

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.ACOMPANANTE3_IDColumnName))
                    row.ACOMPANANTE3_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.ACOMPANANTE3_IDColumnName].ToString());
                else
                    row.IsACOMPANANTE3_IDNull = true;

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.AUTONUMERACION_IDColumnName))
                {
                    row.AUTONUMERACION_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.AUTONUMERACION_IDColumnName].ToString());
                }

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.CASO_ASOCIADO_IDColumnName))
                    row.CASO_ASOCIADO_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.CASO_ASOCIADO_IDColumnName].ToString());

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.FUNCIONARIO_CHOFER_IDColumnName))
                    row.FUNCIONARIO_CHOFER_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.FUNCIONARIO_CHOFER_IDColumnName].ToString());
                else
                    row.IsFUNCIONARIO_CHOFER_IDNull = true;

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.PROVEEDOR_IDColumnName))
                    row.PROVEEDOR_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.PROVEEDOR_IDColumnName].ToString());
                else
                    row.IsPROVEEDOR_IDNull = true;

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.CHOFER_NOMBREColumnName))
                    row.CHOFER_NOMBRE = campos[StockTransferenciasBalanceadosService.Modelo.CHOFER_NOMBREColumnName].ToString();

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.COMPROBANTEColumnName))
                    row.COMPROBANTE = campos[StockTransferenciasBalanceadosService.Modelo.COMPROBANTEColumnName].ToString();
                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.COSTO_ASOCIADOColumnName))
                    row.COSTO_ASOCIADO = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.COSTO_ASOCIADOColumnName].ToString());
                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.COSTO_TRANSFERENCIAColumnName))
                    row.COSTO_TRANSFERENCIA = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.COSTO_TRANSFERENCIAColumnName].ToString());
                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.COTIZACIONColumnName))
                    row.COTIZACION = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.COTIZACIONColumnName].ToString());

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.SUCURSAL_ORIGEN_IDColumnName))                    
                    row.SUCURSAL_ORIGEN_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.SUCURSAL_ORIGEN_IDColumnName].ToString());
                
                row.FECHA = (DateTime)campos[StockTransferenciasBalanceadosService.Modelo.FECHAColumnName];
                row.OBSERVACION = (string)campos[StockTransferenciasBalanceadosService.Modelo.OBSERVACIONColumnName];

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.MONEDA_IDColumnName))
                    row.MONEDA_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.MONEDA_IDColumnName].ToString());
                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.TOTAL_COSTOColumnName))
                    row.TOTAL_COSTO = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.TOTAL_COSTOColumnName].ToString());

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.VEHICULO_IDColumnName))
                    row.VEHICULO_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.VEHICULO_IDColumnName].ToString());
                else
                    row.IsVEHICULO_IDNull = true;

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.TEXTO_PREDEFINIDO_IDColumnName))
                    row.TEXTO_PREDEFINIDO_ID = decimal.Parse(campos[StockTransferenciasBalanceadosService.Modelo.TEXTO_PREDEFINIDO_IDColumnName].ToString());
                else
                    row.IsTEXTO_PREDEFINIDO_IDNull = true;

                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.VEHICULO_MARCAColumnName))
                    row.VEHICULO_MARCA = campos[StockTransferenciasBalanceadosService.Modelo.VEHICULO_MARCAColumnName].ToString();
                if (campos.Contains(StockTransferenciasBalanceadosService.Modelo.VEHICULO_MATRICULAColumnName))
                    row.VEHICULO_MATRICULA = campos[StockTransferenciasBalanceadosService.Modelo.VEHICULO_MATRICULAColumnName].ToString();

                if (insertarNuevo) sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.Insert(row);
                else sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.Update(row);
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
                STOCK_TRANSFERENCIA_BALANCEADOSRow row = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByPrimaryKey(transferencia_id);

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
                STOCK_TRANSFERENCIA_BALANCEADOSRow cabecera = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByCASO_ID(caso_id)[0];
                STOCK_TRANSFERENCIA_BALANC_DETRow[] detalles = sesion.Db.STOCK_TRANSFERENCIA_BALANC_DETCollection.GetByTRANSFERENCIA_BALANC_ID(cabecera.ID);

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
                            StockTransferenciaBalanceadosDetalleService.Borrar(detalles[i].ID, sesion);
                        }
                    }

                }

                //Si no se cumple alguna condicion, se lanza la excepcion
                //caso contrario se elimina el caso de la tabla casos y de la cabecera
                if (exito)
                {
                    sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.DeleteByCASO_ID(caso_id);
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

            STOCK_TRANSFERENCIA_BALANCEADOSRow row = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetRow(StockTransferenciasBalanceadosService.Modelo.CASO_IDColumnName + " = " + caso_id);
            string valorAnterior = row.ToString();

            row.IMPRESO = Definiciones.SiNo.Si;
            sesion.db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }

        public static void ActualizarFecha(decimal caso_id, SessionService sesion)
        {
            STOCK_TRANSFERENCIA_BALANCEADOSRow row = new STOCK_TRANSFERENCIA_BALANCEADOSRow();
            string valorAnterior = String.Empty;
            try
            {
                row = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetRow(StockTransferenciasBalanceadosService.Modelo.CASO_IDColumnName + " = " + caso_id);
                valorAnterior = row.ToString();

                if (EsActualizable && row.IMPRESO == Definiciones.SiNo.No)
                    row.FECHA = DateTime.Today.Date;

                sesion.db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.Update(row);
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
                STOCK_TRANSFERENCIA_BALANCEADOSRow row = new STOCK_TRANSFERENCIA_BALANCEADOSRow();
                string valorAnterior = String.Empty;
                try
                {
                    row = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetRow(StockTransferenciasBalanceadosService.Modelo.CASO_IDColumnName + " = " + caso_id);
                    valorAnterior = row.ToString();

                    row.IMPRESO = Definiciones.SiNo.No;
                    sesion.db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.Update(row);
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
                STOCK_TRANSFERENCIA_BALANCEADOSRow row = sesion.Db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetRow(StockTransferenciasBalanceadosService.Modelo.CASO_IDColumnName + " = " + casoId);
                return row.IMPRESO.Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion FueImpreso

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "stock_transferencia_balanceados"; }
        }
        public static string Nombre_Vista
        {
            get { return "stock_transf_balanc_info_compl"; } 
        }

        public class Modelo :STOCK_TRANSFERENCIA_BALANCEADOSCollection_Base { public Modelo() : base(null) { } }
        public class VistaModelo : STOCK_TRANSF_BALANC_INFO_COMPLCollection_Base { public VistaModelo() : base(null) { } }
        #endregion Accessors      

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static StockTransferenciasBalanceadosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new StockTransferenciasBalanceadosService(e.RegistroId, sesion);
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
        protected STOCK_TRANSFERENCIA_BALANCEADOSRow row;
        protected STOCK_TRANSFERENCIA_BALANCEADOSRow rowSinModificar;

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
        private StockTransferenciaBalanceadosDetalleService[] stock_transferencia_ins_detalles;
        public StockTransferenciaBalanceadosDetalleService[] StockTransferenciaBalanceadosDetalles
        {
            get
            {
                if (this.stock_transferencia_ins_detalles == null)
                    this.stock_transferencia_ins_detalles = StockTransferenciaBalanceadosDetalleService.GetPorCabecera(this.Id.Value);
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
                this.row = sesion.db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_TRANSFERENCIA_BALANCEADOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(STOCK_TRANSFERENCIA_BALANCEADOSRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public StockTransferenciasBalanceadosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockTransferenciasBalanceadosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockTransferenciasBalanceadosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        private StockTransferenciasBalanceadosService(STOCK_TRANSFERENCIA_BALANCEADOSRow row)
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
            this._funcionario_chofer = null;
            this._moneda = null;
            this._proveedor = null;
            this._sucursal_origen = null;
            this._texto_predefinido = null;
            this._vehiculo = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region GetPorCaso
        public static StockTransferenciasBalanceadosService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static StockTransferenciasBalanceadosService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.STOCK_TRANSFERENCIA_BALANCEADOSCollection.GetByCASO_ID(caso_id)[0];
            return new StockTransferenciasBalanceadosService(row);
        }
        #endregion GetPorCaso
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}