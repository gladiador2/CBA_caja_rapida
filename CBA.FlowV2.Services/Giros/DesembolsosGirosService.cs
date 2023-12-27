#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using System.Collections;
using System.Collections.Generic;

#endregion Using

namespace CBA.FlowV2.Services.Giros
{
    public class DesembolsosGirosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.DESEMBOLSOS_GIROS;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

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

                mensaje = string.Empty;
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    DESEMBOLSOS_GIROSRow cabeceraRow = sesion.Db.DESEMBOLSOS_GIROSCollection.GetByCASO_ID(caso_id)[0];

                    #region Borrador a Pendiente
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                           estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones:
                        //Ninguna
                        exito = true;
                        revisarRequisitos = true;
                    }
                    #endregion Borrador a Pendiente

                    #region Borrador a Anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                                estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones:
                        //Ninguna
                        exito = true;
                        revisarRequisitos = true;
                    }
                    #endregion Borrador a Anulado
                    
                    #region Pendiente a Borrador 
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                                estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones:
                        //Ninguna
                        exito = true;
                        revisarRequisitos = true;
                    }
                    #endregion Pendiente a Borrador

                    #region Pendiente a Anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                                estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones:
                        //Ninguna
                        exito = true;
                        revisarRequisitos = true;
                    }
                    #endregion Pendiente a Anulado

                    #region Pendiente a EN-PROCESO
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                                estado_destino.Equals(Definiciones.EstadosFlujos.EnProceso))
                    {
                        //Acciones:
                        //Se valida si el monto de los detalles coinciden con el total acumulado y el monto del valor 
                        //Se genera el número de comprobante basado en la autonumeracion.
                        try
                        {
                            exito = true;
                            revisarRequisitos = true;
                        
                            #region Controlar Montos
                            if (exito) 
                            {                                
                                decimal montoDetalles = 0;

                                string clausulas = DesembolsosGirosDetService.DesembolsoGiroId_NombreCol + " = " + cabeceraRow.ID;
                                DataTable detalles = DesembolsosGirosDetService.GetDesembolsoGirosDetDataTable(clausulas, string.Empty, sesion);

                                foreach (DataRow r in detalles.Rows)
                                    montoDetalles += (decimal)r[DesembolsosGirosDetService.MontoOrigen_NombreCol];

                                if (!(montoDetalles == cabeceraRow.MONTO_TOTAL && cabeceraRow.MONTO_TOTAL == (cabeceraRow.MONTO_VALOR + cabeceraRow.MONTO_COMISION)))
                                {
                                    exito = false;
                                    mensaje = "Los montos del valor y los detalles no coinciden";
                                }
                            }
                            #endregion Controlar Montos

                            #region Generar comprobante
                            if (cabeceraRow.NRO_COMPROBANTE == null)
                            {
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

                                //Controlar que se logro asignar una numeracion
                                if (cabeceraRow.NRO_COMPROBANTE.Equals(""))
                                {
                                    exito = false;
                                    mensaje = "No se pudo asignar una numeración válida";
                                }
                            }
                            #endregion Generar comprobante
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }
                    #endregion Pendiente a EN-PROCESO

                    #region En-Proceso a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                                estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones:
                        //Ninguna
                        exito = true;
                        revisarRequisitos = true;
                    }
                    #endregion En-Proceso a Pendiente

                    #region En-Proceso a Anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                                estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones:
                        //Ninguna
                        exito = true;
                        revisarRequisitos = true;
                    }
                    #endregion En-Proceso a Anulado
                    
                    #region En-Proceso a Cerrado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                                estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {

                        #region Afectar Tesoreria
                        //Si fue un caso asociado no debe hacerse nada ya que dicho caso afecto los valores
                        switch(int.Parse(cabeceraRow.CTACTE_VALOR_ID.ToString()))
                        {
                            case Definiciones.CuentaCorrienteValores.Efectivo:
                                CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.DESEMBOLSOS_GIROS, string.Empty, cabeceraRow.ID, Definiciones.Error.Valor.EnteroPositivo, cabeceraRow.CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, cabeceraRow.MONEDA_ID, cabeceraRow.COTIZACION_MONEDA, cabeceraRow.MONTO_VALOR, DateTime.Now, sesion);
                                break;
                            case Definiciones.CuentaCorrienteValores.Cheque:
                                System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                campos.Add(CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol, cabeceraRow.COTIZACION_MONEDA);
                                campos.Add(CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol, cabeceraRow.CHEQUE_CTACTE_BANCO_ID);
                                campos.Add(CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol, string.Empty);
                                campos.Add(CuentaCorrienteChequesRecibidosService.FechaCreacion_NombreCol, cabeceraRow.FECHA);
                                campos.Add(CuentaCorrienteChequesRecibidosService.EsDiferido_NombreCol, cabeceraRow.CHEQUE_ES_DIFERIDO);
                                campos.Add(CuentaCorrienteChequesRecibidosService.FechaPosdatado_NombreCol, cabeceraRow.CHEQUE_FECHA_POSDATADO);
                                campos.Add(CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol, cabeceraRow.CHEQUE_FECHA_VENCIMIENTO);
                                campos.Add(CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol, cabeceraRow.MONEDA_ID);
                                campos.Add(CuentaCorrienteChequesRecibidosService.Monto_NombreCol, cabeceraRow.MONTO_VALOR);
                                campos.Add(CuentaCorrienteChequesRecibidosService.NombreBeneficiario_NombreCol, cabeceraRow.CHEQUE_NOMBRE_BENEFICIARIO);
                                campos.Add(CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol, cabeceraRow.CHEQUE_NOMBRE_EMISOR);
                                campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol, cabeceraRow.CHEQUE_NRO_CHEQUE);
                                campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol, cabeceraRow.CHEQUE_NRO_CUENTA);
                                campos.Add(CuentaCorrienteChequesRecibidosService.ChequeDeTerceros_NombreCol, Definiciones.SiNo.No);
                                campos.Add(CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol, casoRow.ID);
                                CuentaCorrienteChequesRecibidosService chequeRecibido = new CuentaCorrienteChequesRecibidosService();
                                decimal id_chequeRecibido = chequeRecibido.Guardar(campos, true, sesion);
                                cabeceraRow.CTACTE_CHEQUE_RECIBIDO_ID = id_chequeRecibido;
                                CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.DESEMBOLSOS_GIROS, string.Empty, cabeceraRow.ID, Definiciones.Error.Valor.EnteroPositivo, cabeceraRow.CTACTE_VALOR_ID, id_chequeRecibido, cabeceraRow.MONEDA_ID, cabeceraRow.COTIZACION_MONEDA, cabeceraRow.MONTO_VALOR, DateTime.Now, sesion);                  
                                sesion.Db.DESEMBOLSOS_GIROSCollection.Update(cabeceraRow);
                                break;
                        }
                        #endregion Afectar Tesoreria

                        #region Actualizar Giros Movimientos
                        System.Collections.Hashtable campos2 = new System.Collections.Hashtable();

                        string clausulas = DesembolsosGirosDetService.DesembolsoGiroId_NombreCol + " = " + cabeceraRow.ID;
                        DataTable detalles = DesembolsosGirosDetService.GetDesembolsoGirosDetDataTable(clausulas, string.Empty, sesion);
                        decimal movimiento, moneda,cotizacion,monto, detalle_id;
                        
                        foreach (DataRow r in detalles.Rows)
                        {
                            movimiento = (decimal)r[DesembolsosGirosDetService.CtacteGirosMovimientoId_NombreCol];
                            moneda = (decimal)r[DesembolsosGirosDetService.MonedaOrigenId_NombreCol];
                            cotizacion = (decimal)r[DesembolsosGirosDetService.CotizacionMonedaOrigen_NombreCol];
                            monto = (decimal)r[DesembolsosGirosDetService.MontoOrigen_NombreCol];
                            detalle_id = (decimal)r[DesembolsosGirosDetService.Id_NombreCol];
                            CuentaCorrienteGirosMovimientosService.InsertarMovientoRelacionado(movimiento, moneda, monto, cotizacion, caso_id, detalle_id, sesion);
                        }
                        #endregion Actualizar Giros Movimientos

                        exito = true;
                        revisarRequisitos = true;                    
                    }
                    #endregion En-Proceso a Cerrado

                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }
                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.DESEMBOLSOS_GIROSCollection.Update(cabeceraRow);
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

        #region EjecutarAccionesLuegoDeCambioEstado
        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }
        #endregion EjecutarAccionesLuegoDeCambioEstado

        #region GetNumeroComprobante
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion) 
        {
            DESEMBOLSOS_GIROSRow row = sesion.Db.DESEMBOLSOS_GIROSCollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }
        #endregion GetNumeroComprobante

        #region GetMontoTotal
        public static decimal GetMontoTotal(Decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DESEMBOLSOS_GIROSRow row = sesion.Db.DESEMBOLSOS_GIROSCollection.GetByCASO_ID(caso_id)[0];
                return row.MONTO_TOTAL;
            }
        }
        #endregion GetNumeroComprobante

        #endregion Implementacion de metodos abstract

        #region GetDesembolsosGirosDataTable
        /// <summary>
        /// Gets the ordenes pago data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        /// 
        public static DataTable GetDesembolsosGirosPorCaso(decimal caso_id, string orden) 
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = DesembolsosGirosService.CasoId_NombreCol + " = " + caso_id;
                return sesion.Db.DESEMBOLSOS_GIROSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        
        public static DataTable GetDesembolsosGirosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESEMBOLSOS_GIROSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDesembolsosGirosDataTable

        #region GetDesembolsosGirosInfoCompleta
        /// <summary>
        /// Gets the ordenes pago info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>

        public static DataTable GetDesembolsosGirosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESEMBOLSOS_GIROS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetOrdenesPagoInfoCompleta

        #region CalcularTotales
        /// <summary>
        /// Calculars the totales.
        /// </summary>
        /// <param name="orden_pago_id">The orden_pago_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void CalcularTotales(decimal desembolso_id, SessionService sesion)
        {
            DataTable dt = sesion.Db.DESEMBOLSOS_GIROS_DETCollection.GetByDESEMBOLSO_GIRO_IDAsDataTable(desembolso_id);
            DESEMBOLSOS_GIROSRow row = sesion.Db.DESEMBOLSOS_GIROSCollection.GetByPrimaryKey(desembolso_id);
            string valorAnterior = row.ToString();

            row.MONTO_TOTAL = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
                row.MONTO_TOTAL += (decimal)dt.Rows[i][DesembolsosGirosDetService.MontoDestino_NombreCol];                

            sesion.Db.DESEMBOLSOS_GIROSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion CalcularTotales

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                DESEMBOLSOS_GIROSRow row = new DESEMBOLSOS_GIROSRow();

                try
                {
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[DesembolsosGirosService.SucursalOrigenId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.DESEMBOLSOS_GIROS.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        row.ID = sesion.Db.GetSiguienteSecuencia("desembolsos_giros_sqc");
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.MONTO_TOTAL = 0;
                    }
                    else
                    {
                        row = sesion.Db.DESEMBOLSOS_GIROSCollection.GetRow(DesembolsosGirosService.Id_NombreCol + " = " + campos[DesembolsosGirosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.MONTO_COMISION = (decimal)campos[DesembolsosGirosService.MontoComision_NombreCol];
                    row.MONTO_VALOR = (decimal)campos[DesembolsosGirosService.MontoValor_NombreCol];
                    row.OBSERVACION = campos[DesembolsosGirosService.Observacion_NombreCol].ToString();

                    if (campos.Contains(DesembolsosGirosService.AutonumeracionId_NombreCol))
                        row.AUTONUMERACION_ID = (decimal)campos[DesembolsosGirosService.AutonumeracionId_NombreCol];
                    else
                        row.IsAUTONUMERACION_IDNull = true;

                    if (campos.Contains(DesembolsosGirosService.NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = (string)campos[DesembolsosGirosService.NroComprobante_NombreCol];

                    row.FECHA = (DateTime)campos[DesembolsosGirosService.Fecha_NombreCol];

                    //Si cambia
                    if (!row.SUCURSAL_ORIGEN_ID.Equals(campos[DesembolsosGirosService.SucursalOrigenId_NombreCol]))
                    {
                        if (!SucursalesService.EstaActivo((decimal)campos[DesembolsosGirosService.SucursalOrigenId_NombreCol]))
                            throw new Exception("La sucursal origen no está activa.");

                        row.SUCURSAL_ORIGEN_ID = (decimal)campos[DesembolsosGirosService.SucursalOrigenId_NombreCol];
                    }

                    //Si cambia
                    if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[DesembolsosGirosService.MonedaId_NombreCol])
                    {
                        if (!MonedasService.EstaActivo((decimal)campos[DesembolsosGirosService.MonedaId_NombreCol]))
                            throw new Exception("La moneda origen no está activa");

                        row.MONEDA_ID = (decimal)campos[DesembolsosGirosService.MonedaId_NombreCol];

                        //Se actualiza la cotizacion de la moneda
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ORIGEN_ID), row.MONEDA_ID, row.FECHA, sesion);
                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda origen.");
                    }                   

                    row.CTACTE_VALOR_ID = Decimal.Parse(campos[DesembolsosGirosService.CtacteValorId_NombreCol].ToString());

                    //Si se desembolsa con una transferencia
                    if (row.CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.TransferenciaBancaria) 
                    {
                        row.TRANSFERENCIA_BANCARIA_ID = (decimal)campos[DesembolsosGirosService.TransferenciaBancariaId_NombreCol];
                    }

                    //Si se desembolsa con un dep bancario
                    if (row.CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.DepositoBancario) 
                    {
                        row.DEPOSITO_BANCARIO_ID = (decimal)campos[DesembolsosGirosService.DepositoBancarioId_NombreCol];
                    }

                    //Si de desembolsa con Cheque
                    if (row.CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Cheque)
                    {
                        row.CHEQUE_CTACTE_BANCO_ID = (decimal)campos[DesembolsosGirosService.ChequeCtacteBancoId_NombreCol];
                        row.CHEQUE_DOCUMENTO_EMISOR = campos[DesembolsosGirosService.ChequeDocumentoEmisor_NombreCol].ToString();
                        row.CHEQUE_ES_DIFERIDO = campos[DesembolsosGirosService.ChequeEsDiferido_NombreCol].ToString();
                        row.CHEQUE_FECHA_POSDATADO = DateTime.Parse(campos[DesembolsosGirosService.ChequeFechaPosdatado_NombreCol].ToString());
                        row.CHEQUE_FECHA_VENCIMIENTO = DateTime.Parse(campos[DesembolsosGirosService.ChequeFechaVencimiento_NombreCol].ToString());
                        row.CHEQUE_NOMBRE_BENEFICIARIO = campos[DesembolsosGirosService.ChequeNombreBeneficiario_NombreCol].ToString();
                        row.CHEQUE_NOMBRE_EMISOR = campos[DesembolsosGirosService.ChequeNombreEmisor_NombreCol].ToString();
                        row.CHEQUE_NRO_CHEQUE = campos[DesembolsosGirosService.ChequeNroCheque_NombreCol].ToString();
                        row.CHEQUE_NRO_CUENTA = campos[DesembolsosGirosService.ChequeNroCuenta_NombreCol].ToString();
                    }
                    //Si es un giro por tarjeta de credito
                    if (campos.Contains(DesembolsosGirosService.CtacteProcesadoraTarjetaId_NombreCol))
                    {
                        row.CTACTE_PROCESADORA_TARJETA_ID = (decimal)campos[DesembolsosGirosService.CtacteProcesadoraTarjetaId_NombreCol];
                        row.IsCTACTE_RED_PAGO_IDNull = true;
                    }

                    //Si es un giro por red de pago
                    if (campos.Contains(DesembolsosGirosService.CtacteRedPagoId_NombreCol))
                    {
                        row.CTACTE_RED_PAGO_ID = (decimal)campos[DesembolsosGirosService.CtacteRedPagoId_NombreCol];
                        row.IsCTACTE_PROCESADORA_TARJETA_IDNull= true;
                    }

                    if (campos.Contains(DesembolsosGirosService.CtacteCajaTesoreriaId_NombreCol))
                    {
                        row.CTACTE_CAJA_TESORERIA_ID = (decimal)campos[DesembolsosGirosService.CtacteCajaTesoreriaId_NombreCol];
                    }

                    if (insertarNuevo) sesion.Db.DESEMBOLSOS_GIROSCollection.Insert(row);
                    else sesion.Db.DESEMBOLSOS_GIROSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos
                    
                    exito = true;
                }
                catch (Exception)
                {
                    //Si el caso fue creado el mismo debe borrarse
                    if (insertarNuevo && row.CASO_ID > 0)
                    {
                        (new CasosService()).Eliminar(row.CASO_ID, sesion);
                        caso_id = Definiciones.Error.Valor.EnteroPositivo;
                        estado_id = string.Empty;
                    }

                    throw;
                }
                return exito;
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
                    string mensaje = string.Empty;

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    DESEMBOLSOS_GIROSRow cabecera = sesion.Db.DESEMBOLSOS_GIROSCollection.GetByCASO_ID(caso_id)[0];

                    if (! caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        throw new Exception ("El caso sólo puede borrarse en el estado borrador.");
                    }

                        //Se obtienen los detalles del caso a ser borrados.
                        DataTable detalles = DesembolsosGirosDetService.GetDesembolsoGirosDetDataTable(DesembolsosGirosDetService.DesembolsoGiroId_NombreCol + " = " + cabecera.ID,string.Empty);

                        foreach (DataRow r in detalles.Rows) 
                            DesembolsosGirosDetService.Borrar((decimal)r[DesembolsosGirosDetService.Id_NombreCol], sesion);
 
                        sesion.Db.DESEMBOLSOS_GIROSCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        //Se borra el caso
                        (new CasosService()).Eliminar(caso_id, sesion); 

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

        #region ActualizarMontoTotal
        public static void ActualizarMontoTotal(decimal desembolso_id, SessionService sesion) 
        {
            try
            {
                decimal total = 0;
                string valorAnterior;
                DESEMBOLSOS_GIROSRow row;
                string clausulas = DesembolsosGirosDetService.DesembolsoGiroId_NombreCol + " = " + desembolso_id;
                DataTable detalles = DesembolsosGirosDetService.GetDesembolsoGirosDetDataTable(clausulas, string.Empty, sesion);

                foreach (DataRow r in detalles.Rows)
                    total += (decimal)r[DesembolsosGirosDetService.MontoOrigen_NombreCol];

                row = sesion.Db.DESEMBOLSOS_GIROSCollection.GetRow(DesembolsosGirosService.Id_NombreCol + " = " + desembolso_id);
                valorAnterior = row.ToString();

                row.MONTO_TOTAL = total;
                
                sesion.Db.DESEMBOLSOS_GIROSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            }
            catch (Exception exp)
            {
                throw exp;
            }
       }

        #endregion ActualizarMontoTotal

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "DESEMBOLSOS_GIROS"; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CASO_IDColumnName; }
        }
        public static string ChequeCtacteBancoId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CHEQUE_CTACTE_BANCO_IDColumnName; }
        }
        public static string ChequeDocumentoEmisor_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CHEQUE_DOCUMENTO_EMISORColumnName; }
        }
        public static string ChequeEsDiferido_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CHEQUE_ES_DIFERIDOColumnName; }
        }
        public static string ChequeFechaPosdatado_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CHEQUE_FECHA_POSDATADOColumnName; }
        }
        public static string ChequeFechaVencimiento_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CHEQUE_FECHA_VENCIMIENTOColumnName; }
        }
        public static string ChequeNombreBeneficiario_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CHEQUE_NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string ChequeNombreEmisor_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CHEQUE_NOMBRE_EMISORColumnName; }
        }
        public static string ChequeNroCheque_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CHEQUE_NRO_CHEQUEColumnName; }
        }
        public static string ChequeNroCuenta_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CHEQUE_NRO_CUENTAColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteCajaTesoreriaId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteProcesadoraTarjetaId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CTACTE_PROCESADORA_TARJETA_IDColumnName; }
        }
        public static string CtacteRedPagoId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CTACTE_RED_PAGO_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string DepositoBancarioId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.DEPOSITO_BANCARIO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.MONEDA_IDColumnName; }
        }
        public static string MontoComision_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.MONTO_COMISIONColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.MONTO_TOTALColumnName; }
        }
        public static string MontoValor_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.MONTO_VALORColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalOrigenId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.SUCURSAL_ORIGEN_IDColumnName; }
        }
        public static string TransferenciaBancariaId_NombreCol
        {
            get { return DESEMBOLSOS_GIROSCollection.TRANSFERENCIA_BANCARIA_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "DESEMBOLSOS_GIROS_INFO_COMPL"; }
        }
        public static string VistaAutonumeracionTimbrado_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_INFO_COMPLCollection.AUTONUMERACION_TIMBRADOColumnName; }
        }
        public static string VistaBancoNombre_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_INFO_COMPLCollection.BANCO_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaProcesadoraTarjNombre_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_INFO_COMPLCollection.PROC_TARJ_NOMBREColumnName; }
        }
        public static string VistaRedPagoNombre_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_INFO_COMPLCollection.RED_PAGO_NOMBREColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaValorNombre_NombreCol
        {
            get { return DESEMBOLSOS_GIROS_INFO_COMPLCollection.VALOR_NOMBREColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}
