#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using System.Collections;
using System.Collections.Generic;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class MovimientoVarioCajaTesoreriaService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de Metodos Heredados
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA;
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
            
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[MovimientoVarioCajaTesoreriaService.TextoPredefinidoId]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            MOVIMIENTOS_VARIOS_TESORow[] rows;
            rows = sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.GetByCASO_ID(caso_id);
            if (rows.Length == 1)
                return rows[0].NRO_COMPROBANTE.ToString();
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
                bool revisarRequisitos = false;
                mensaje = "";
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    MOVIMIENTOS_VARIOS_TESORow MovimientoRow = sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.GetByCASO_ID(caso_id)[0];
                    MOVIMIENTOS_VARIOS_TESO_DETRow[] detalleRows = sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.GetByMOVIMIENTO_VARIO_ID(MovimientoRow.ID);
                    // de borrador a anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {                       
                        exito = true;
                        revisarRequisitos = true;
                    }
                    // de borrador a pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        if (detalleRows.Length <= 0)
                            throw new Exception("El caso no tiene detalles.");

                        if (MovimientoRow.NRO_COMPROBANTE == null || MovimientoRow.NRO_COMPROBANTE.Length <= 0)
                            MovimientoRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(MovimientoRow.AUTONUMERACION_ID);
                        
                        sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.Update(MovimientoRow);

                        exito = true;
                        revisarRequisitos = true;
                    }
                    //de pendiente a borrador
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                           estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //de pendiente a anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {                        
                        exito = true;
                        revisarRequisitos = true;
                    }
                    // de pendiente a aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        exito = true;
                        revisarRequisitos = true;

                        if (detalleRows.Length <= 0)
                            throw new Exception("El caso no tiene detalles.");

                        CuentaCorrienteChequesRecibidosService chequeRecibido = new CuentaCorrienteChequesRecibidosService();
                        decimal id_chequeRecibido = 0;
                        
                        // Ingreso
                        if (MovimientoRow.TIPO_OPERACION.Equals(Definiciones.TiposMovimientosCaja.Ingreso))
                        {
                            for (int i = 0; i < detalleRows.Length; i++)
                            {
                                // Si es efectivo
                                if (detalleRows[i].CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                                {
                                    // Si es de cuenta bancaria
                                    if (!detalleRows[i].IsCTACTE_BANCARIA_IDNull)
                                    {
                                        DateTime fechaMovimiento = MovimientoRow.FECHA;
                                        // Si es cheque propio emitido para extraer de cuenta bancaria
                                        if (!detalleRows[i].IsFECHA_CREACIONNull)
                                        {
                                            Hashtable campos;
                                            campos = new Hashtable();
                                            decimal autonumeracion_id = Definiciones.Error.Valor.EnteroPositivo;
                                            string nroCheque;

                                            fechaMovimiento = detalleRows[i].FECHA_POSDATADO;

                                            campos.Add(CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol, MovimientoRow.CASO_ID);
                                            campos.Add(CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol, detalleRows[i].COTIZACION_MONEDA);
                                            campos.Add(CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol, detalleRows[i].CTACTE_BANCARIA_ID);
                                            campos.Add(CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol, detalleRows[i].ES_DIFERIDO);
                                            campos.Add(CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol, detalleRows[i].FECHA_POSDATADO);
                                            campos.Add(CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol, detalleRows[i].FECHA_VENCIMIENTO);
                                            campos.Add(CuentaCorrienteChequesGiradosService.MonedaId_NombreCol, detalleRows[i].MONEDA_ID);
                                            campos.Add(CuentaCorrienteChequesGiradosService.Monto_NombreCol, detalleRows[i].MONTO);
                                            campos.Add(CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol, detalleRows[i].NOMBRE_BENEFICIARIO);
                                            campos.Add(CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol, string.Empty);
                                            campos.Add(CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol, detalleRows[i].NOMBRE_EMISOR);
                                            campos.Add(CuentaCorrienteChequesGiradosService.Observacion_NombreCol, detalleRows[i].OBSERVACION);

                                            if (!detalleRows[i].IsAUTONUMERACION_IDNull)
                                            {
                                                campos.Add(CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol, detalleRows[i].AUTONUMERACION_ID);
                                                autonumeracion_id = detalleRows[i].AUTONUMERACION_ID;
                                            }
                                            else if (detalleRows[i].IsAUTONUMERACION_IDNull && detalleRows[i].USAR_CHEQUERA == Definiciones.SiNo.Si)
                                            {
                                                throw new NotImplementedException("Debe seleccionar la autonumeración del cheque");
                                            }

                                            if (detalleRows[i].NUMERO_CHEQUE != null && detalleRows[i].NUMERO_CHEQUE.Length > 0)
                                                campos.Add(CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol, detalleRows[i].NUMERO_CHEQUE);

                                            //Se crea el cheque girado
                                            detalleRows[i].CTACTE_CHEQUE_GIRADO_ID = CuentaCorrienteChequesGiradosService.Emitir(campos, autonumeracion_id, out nroCheque, sesion);
                                            detalleRows[i].NUMERO_CHEQUE = nroCheque;

                                            //Se actualiza en la base de datos el id del cheque girado
                                            sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.Update(detalleRows[i]);
                                        }

                                        //Se afecta la cuenta bancaria si el cheque no es adelantado
                                        if (!detalleRows[i].IsFECHA_VENCIMIENTONull && detalleRows[i].FECHA_VENCIMIENTO.Date <= DateTime.Now.Date)
                                        {
                                            CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                                detalleRows[i].CTACTE_BANCARIA_ID,
                                                Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA,
                                                MovimientoRow.CASO_ID,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                MovimientoRow.ID,
                                                detalleRows[i].MONEDA_ID,
                                                detalleRows[i].MONTO * (-1),
                                                detalleRows[i].COTIZACION_MONEDA,
                                                fechaMovimiento,
                                                "Caso " + MovimientoRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA) + " pasado al estado " + estado_destino + ". Cheque " + detalleRows[i].NUMERO_CHEQUE + " fecha " + detalleRows[i].FECHA_CREACION.Date + ".",
                                                detalleRows[i].CTACTE_CHEQUE_GIRADO_ID,
                                                null,
                                                false,
                                                sesion);
                                        }
                                    }

                                    CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, 
                                                                                            detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, 
                                                                                            Definiciones.Error.Valor.EnteroPositivo, detalleRows[i].MONEDA_ID, 
                                                                                            detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                }
                                // Si es cheque
                                else
                                {
                                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                    campos.Add(CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol, detalleRows[i].COTIZACION_MONEDA);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol, detalleRows[i].CTACTE_BANCO_ID);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol, string.Empty);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.FechaCreacion_NombreCol, detalleRows[i].FECHA_CREACION);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.EsDiferido_NombreCol, detalleRows[i].ES_DIFERIDO);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.FechaPosdatado_NombreCol, detalleRows[i].FECHA_POSDATADO);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol, detalleRows[i].FECHA_VENCIMIENTO);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol, detalleRows[i].MONEDA_ID);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.Monto_NombreCol, detalleRows[i].MONTO);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.NombreBeneficiario_NombreCol, detalleRows[i].NOMBRE_BENEFICIARIO);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol, detalleRows[i].NOMBRE_EMISOR);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol, detalleRows[i].NUMERO_CHEQUE);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol, detalleRows[i].NUMERO_CUENTA);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.ChequeDeTerceros_NombreCol, detalleRows[i].CHEQUE_DE_TERCEROS);
                                    campos.Add(CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol, casoRow.ID);
                                    id_chequeRecibido = chequeRecibido.Guardar(campos, true, sesion);
                                    detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID = id_chequeRecibido;
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, id_chequeRecibido, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                    sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.Update(detalleRows[i]);
                                }
                            }
                        }
                        // Egreso
                        else 
                        {
                            for (int i = 0; i < detalleRows.Length; i++) 
                            {
                                if (detalleRows[i].CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                                {
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                }
                                else 
                                {
                                    // Si el cheque es recibido
                                    if (!detalleRows[i].IsCTACTE_CHEQUE_RECIBIDO_IDNull)
                                    {
                                        DataTable dt = CuentaCorrienteChequesRecibidosService.GetDataTable(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, string.Empty, sesion);
                                        decimal ctacteEstadoChequeId = (decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol];

                                        //El cheque solo puede salir si se encuentra en uno de los siguientes estados
                                        if (ctacteEstadoChequeId == Definiciones.CuentaCorrienteChequesEstados.Adelantado ||
                                            ctacteEstadoChequeId == Definiciones.CuentaCorrienteChequesEstados.AlDia ||
                                            ctacteEstadoChequeId == Definiciones.CuentaCorrienteChequesEstados.Anulado ||
                                            ctacteEstadoChequeId == Definiciones.CuentaCorrienteChequesEstados.Incobrable ||
                                            ctacteEstadoChequeId == Definiciones.CuentaCorrienteChequesEstados.Judicial ||
                                            ctacteEstadoChequeId == Definiciones.CuentaCorrienteChequesEstados.Rechazado)
                                        {
                                            chequeRecibido.UtilizadoPorFlujo(detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, sesion);
                                            CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                        }
                                        else
                                        {
                                            throw new NotImplementedException("el cheque ya no esta disponible para esta transaccion.");
                                        }
                                    }
                                    // Si el cheque es emitido
                                    else if (!detalleRows[i].IsCTACTE_BANCARIA_IDNull)
                                    {
                                        Hashtable campos;
                                        campos = new Hashtable();
                                        decimal autonumeracion_id = Definiciones.Error.Valor.EnteroPositivo;
                                        string nroCheque;

                                        campos.Add(CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol, MovimientoRow.CASO_ID);
                                        campos.Add(CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol, detalleRows[i].COTIZACION_MONEDA);
                                        campos.Add(CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol, detalleRows[i].CTACTE_BANCARIA_ID);
                                        campos.Add(CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol, detalleRows[i].ES_DIFERIDO);
                                        campos.Add(CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol, detalleRows[i].FECHA_CREACION);
                                        campos.Add(CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol, detalleRows[i].FECHA_VENCIMIENTO);
                                        campos.Add(CuentaCorrienteChequesGiradosService.MonedaId_NombreCol, detalleRows[i].MONEDA_ID);
                                        campos.Add(CuentaCorrienteChequesGiradosService.Monto_NombreCol, detalleRows[i].MONTO);
                                        campos.Add(CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol, detalleRows[i].NOMBRE_BENEFICIARIO);
                                        campos.Add(CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol, string.Empty);
                                        campos.Add(CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol, detalleRows[i].NOMBRE_EMISOR);
                                        campos.Add(CuentaCorrienteChequesGiradosService.Observacion_NombreCol, detalleRows[i].OBSERVACION);
                                        
                                        if (!detalleRows[i].IsAUTONUMERACION_IDNull)
                                        {
                                            campos.Add(CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol, detalleRows[i].AUTONUMERACION_ID);
                                            autonumeracion_id = detalleRows[i].AUTONUMERACION_ID;
                                        }
                                        else if (detalleRows[i].IsAUTONUMERACION_IDNull && detalleRows[i].USAR_CHEQUERA == Definiciones.SiNo.Si)
                                        {
                                            throw new NotImplementedException("Debe seleccionar la autonumeración del cheque");
                                        }

                                        if (detalleRows[i].NUMERO_CHEQUE != null && detalleRows[i].NUMERO_CHEQUE.Length > 0)
                                            campos.Add(CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol, detalleRows[i].NUMERO_CHEQUE);
                                        
                                        //Se crea el cheque girado
                                        detalleRows[i].CTACTE_CHEQUE_GIRADO_ID = CuentaCorrienteChequesGiradosService.Emitir(campos, autonumeracion_id, out nroCheque, sesion);
                                        detalleRows[i].NUMERO_CHEQUE = nroCheque;

                                        //Se actualiza en la base de datos el id del cheque girado
                                        sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.Update(detalleRows[i]);

                                        //Se afecta la cuenta bancaria si el cheque no es adelantado
                                        if (detalleRows[i].FECHA_VENCIMIENTO.Date <= DateTime.Now.Date)
                                        {
                                            CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                                detalleRows[i].CTACTE_BANCARIA_ID,
                                                Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA,
                                                MovimientoRow.CASO_ID,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                MovimientoRow.ID,
                                                detalleRows[i].MONEDA_ID,
                                                detalleRows[i].MONTO * (-1),
                                                detalleRows[i].COTIZACION_MONEDA,
                                                MovimientoRow.FECHA,
                                                "Caso " + MovimientoRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA) + " pasado al estado " + estado_destino + ". Cheque " + detalleRows[i].NUMERO_CHEQUE + " fecha " + detalleRows[i].FECHA_CREACION.Date + ".",
                                                detalleRows[i].CTACTE_CHEQUE_GIRADO_ID,
                                                null,
                                                false,
                                                sesion);
                                        }
                                    }
                                    // Error de implementacion
                                    else
                                    {
                                        throw new Exception("Error en el ingreso de cheque como detalle de Movimiento Vario de Tesorería.");
                                    }
                                }
                            }
                        }
                    }
                    #region Aprobado a Anulado
                    //de aprobado a anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        exito = true;
                        revisarRequisitos = true;

                        #region Ingreso
                        //ingreso
                        if (MovimientoRow.TIPO_OPERACION.Equals(Definiciones.TiposMovimientosCaja.Ingreso))
                        {
                            for (int i = 0; i < detalleRows.Length; i++)
                            {
                                if (detalleRows[i].CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                                {
                                    // Si se emitio cheque propio, se anula el cheque
                                    if (!detalleRows[i].IsCTACTE_CHEQUE_GIRADO_IDNull)
                                        CuentaCorrienteChequesGiradosService.Anular(detalleRows[i].CTACTE_CHEQUE_GIRADO_ID, "Anulación de caso aprobado de Movimiento Vario de Tesorería.", sesion);
                                    
                                    decimal saldo = CuentaCorrienteCajasTesoreriaService.SaldoEfectivoPorCaja(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, detalleRows[i].MONEDA_ID, sesion);
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                }
                                else
                                {
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                }
                            }
                        }
                        #endregion Ingreso

                        #region Egreso
                        //egreso
                        else
                        {
                            for (int i = 0; i < detalleRows.Length; i++)
                            {
                                if (detalleRows[i].CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                                {
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                }
                                else
                                {
                                    // Si el cheque es recibido
                                    if (!detalleRows[i].IsCTACTE_CHEQUE_RECIBIDO_IDNull)
                                    {
                                        CuentaCorrienteChequesRecibidosService chequeRecibido = new CuentaCorrienteChequesRecibidosService();
                                        chequeRecibido.DeshacerUtilizadoPorFlujo(detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, MovimientoRow.CASO_ID, sesion);
                                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].ID, MovimientoRow.CASO_ID, sesion);
                                    }
                                    // Si el cheque es emitido
                                    else if (!detalleRows[i].IsCTACTE_BANCARIA_IDNull)
                                    {
                                        DataTable dtChequeGirado = CuentaCorrienteChequesGiradosService.GetCuentaCorrienteChequesGiradosInfoCompleta2(CuentaCorrienteChequesGiradosService.Id_NombreCol + " = " + detalleRows[i].CTACTE_CHEQUE_GIRADO_ID, string.Empty);

                                        CuentaCorrienteChequesGiradosService.Anular(detalleRows[i].CTACTE_CHEQUE_GIRADO_ID, "Movimiento Vario de Tesorería caso " + MovimientoRow.CASO_ID + " pasado de Aprobado a Anulado.", sesion);

                                        if ((string)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.SaldoAfectado_NombreCol] == Definiciones.SiNo.Si)
                                        {
                                            CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                                detalleRows[i].CTACTE_BANCARIA_ID,
                                                Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA,
                                                MovimientoRow.CASO_ID,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                MovimientoRow.ID,
                                                detalleRows[i].MONEDA_ID,
                                                detalleRows[i].MONTO,
                                                detalleRows[i].COTIZACION_MONEDA,
                                                MovimientoRow.FECHA,
                                                "Caso " + MovimientoRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA) + " pasado de Aprobado a Anulado. Cheque " + detalleRows[i].NUMERO_CHEQUE + " fecha " + detalleRows[i].FECHA_CREACION.Date + ".",
                                                detalleRows[i].CTACTE_CHEQUE_GIRADO_ID,
                                                null,
                                                true,
                                                sesion);
                                        }
                                    }
                                    // Error de implementacion
                                    else
                                    {
                                        throw new Exception("Error en el ingreso de cheque como detalle de Movimiento Vario de Tesorería.");
                                    }
                                }
                            }
                        }
                        #endregion Egreso
                    }
                    #endregion Aprobado a Anulado

                    #region Aprobado a Pendiente
                    //de aprobado a pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        exito = true;
                        revisarRequisitos = true;
                        decimal chequeGiradoId;

                        #region Ingreso
                        //si fue un ingreso
                        if (MovimientoRow.TIPO_OPERACION.Equals(Definiciones.TiposMovimientosCaja.Ingreso))
                        {
                            for (int i = 0; i < detalleRows.Length; i++)
                            {
                                //si fue un cheque recibido
                                if (!detalleRows[i].IsCTACTE_CHEQUE_RECIBIDO_IDNull) 
                                {
                                    //obtenemos el/los movimientos del cheque
                                    DataTable dtMovimientoCheque = CuentaCorrienteChequesMovimientosService.GetMovimientosPorChequeRecibido(detalleRows[0].CTACTE_CHEQUE_RECIBIDO_ID);
                                    //si el cheque no se encuentra en estado "Caja al Día"  o "Caja Adelantado", no se puede revertir el ingreso de dicho cheque
                                    if (dtMovimientoCheque.Rows.Count <= 1)
                                    {
                                        //se registra el movimiento de egreso en cuenta caja tesoreria movimiento 
                                        CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                    }
                                }
                                //si fue efectivo
                                else if (detalleRows[i].CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                                {
                                    // Si se emitio cheque propio, se anula el cheque
                                    if (!detalleRows[i].IsCTACTE_CHEQUE_GIRADO_IDNull)
                                        CuentaCorrienteChequesGiradosService.Anular(detalleRows[i].CTACTE_CHEQUE_GIRADO_ID, "Revisión de caso aprobado en Movimiento Vario de Tesorería.", sesion);

                                    decimal saldo = CuentaCorrienteCajasTesoreriaService.SaldoEfectivoPorCaja(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, detalleRows[i].MONEDA_ID, sesion);
                                    if (detalleRows[i].MONTO < saldo) CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                    else throw new NotImplementedException("Saldo Insuficiente en la caja");
                                }
                            }
                        }
                        #endregion Ingreso

                        #region Egreso
                        //si fue un egreso
                        else if (MovimientoRow.TIPO_OPERACION.Equals(Definiciones.TiposMovimientosCaja.Egreso))
                        {

                            for (int i = 0; i < detalleRows.Length; i++)
                            {
                                //si fue efectivo
                                if (detalleRows[i].CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                                {
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(MovimientoRow.CTACTE_CAJA_TESORERIA_ID, Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].MOVIMIENTO_VARIO_ID, detalleRows[i].ID, detalleRows[i].CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, detalleRows[i].MONEDA_ID, detalleRows[i].COTIZACION_MONEDA, detalleRows[i].MONTO, MovimientoRow.FECHA, sesion);
                                }
                                else
                                {
                                    //si fue un cheque recibido
                                    if (!detalleRows[i].IsCTACTE_CHEQUE_RECIBIDO_IDNull)
                                    {
                                        CuentaCorrienteChequesRecibidosService chequeRecibido = new CuentaCorrienteChequesRecibidosService();
                                        chequeRecibido.DeshacerUtilizadoPorFlujo(detalleRows[i].CTACTE_CHEQUE_RECIBIDO_ID, MovimientoRow.CASO_ID, sesion);
                                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA, string.Empty, detalleRows[i].ID, MovimientoRow.CASO_ID, sesion);
                                    }
                                    else if (!detalleRows[i].IsCTACTE_BANCARIA_IDNull)
                                    {
                                        chequeGiradoId = detalleRows[i].CTACTE_CHEQUE_GIRADO_ID;
                                        detalleRows[i].IsCTACTE_CHEQUE_GIRADO_IDNull = true;
                                        sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.Update(detalleRows[i]);

                                        DataTable dtChequeGirado = CuentaCorrienteChequesGiradosService.GetCuentaCorrienteChequesGiradosDataTable(CuentaCorrienteChequesGiradosService.Id_NombreCol + " = " + chequeGiradoId, string.Empty);

                                        if ((string)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.SaldoAfectado_NombreCol] == Definiciones.SiNo.Si)
                                        {
                                            CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                                detalleRows[i].CTACTE_BANCARIA_ID,
                                                Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA,
                                                MovimientoRow.CASO_ID,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                MovimientoRow.ID,
                                                detalleRows[i].MONEDA_ID,
                                                detalleRows[i].MONTO,
                                                detalleRows[i].COTIZACION_MONEDA,
                                                MovimientoRow.FECHA,
                                                "Caso " + MovimientoRow.CASO_ID + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA) + " pasado de Aprobado a Pendiente. Cheque " + detalleRows[i].NUMERO_CHEQUE + " eliminado, fecha " + detalleRows[i].FECHA_CREACION.Date + ".",
                                                chequeGiradoId,
                                                null,
                                                true,
                                                sesion);
                                                
                                        }
                                        CuentaCorrienteChequesGiradosService.Borrar(chequeGiradoId, sesion);
                                    }
                                    // Error de implementacion
                                    else
                                    {
                                        throw new Exception("Error en el ingreso de cheque como detalle de Movimiento Vario de Tesorería.");
                                    }
                                }
                            }
                        }
                        #endregion Egreso
                    }
                    #endregion Aprobado a Pendiente

                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.Update(MovimientoRow);
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

        #endregion Implementacion de Metodos Heredados

        #region GetMovimientoVarioCajaTesoreriaDataTable
        /// <summary>
        /// Gets the movimiento vario caja tesoreria data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetMovimientoVarioCajaTesoreriaDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMovimientoVarioCajaTesoreriaDataTable(clausula, orden, sesion);
            }
        }

        public static DataTable GetMovimientoVarioCajaTesoreriaDataTable(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.GetAsDataTable(clausula, orden);
        }
        #endregion GetMovimientoVarioCajaTesoreriaDataTable

        #region GetMovimientoVarioCajaTesoreriaInfoCompleta
        /// <summary>
        /// Gets the movimiento vario caja tesoreria info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetMovimientoVarioCajaTesoreriaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMovimientoVarioCajaTesoreriaInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetMovimientoVarioCajaTesoreriaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.MOV_VARIOS_TESO_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetMovimientoVarioCajaTesoreriaInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                MOVIMIENTOS_VARIOS_TESORow row = new MOVIMIENTOS_VARIOS_TESORow();
                try
                {
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("movimientos_varios_teso_sqc"); 
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.USUARIO_CREACION_ID = sesion.Usuario.ID;
                    }
                    else
                    {
                        row = sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.FECHA = (DateTime)campos[Fecha_NombreCol];
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[MovimientoVarioCajaTesoreriaService.TextoPredefinidoId];

                    // a partir de este punto se asignan los valores
                    if (campos.Contains(SucursalId_NombreCol)) row.SUCURSAL_ID = decimal.Parse(campos[SucursalId_NombreCol].ToString());
                    else throw new System.ArgumentException("La sucursal no puede ser nula");

                    if (campos.Contains(CtaCteCajaTesoreriaId_NombreCol)) row.CTACTE_CAJA_TESORERIA_ID = decimal.Parse(campos[CtaCteCajaTesoreriaId_NombreCol].ToString());
                    else throw new System.ArgumentException("La caja de tesorería no puede ser nula");
                    
                    if (campos.Contains(AutonumeracionId_NombreCol)) row.AUTONUMERACION_ID = decimal.Parse(campos[AutonumeracionId_NombreCol].ToString());
                    else throw new System.ArgumentException("La autonumeracion no puede ser nula");

                    if (campos.Contains(TipoOperacion)) row.TIPO_OPERACION = campos[TipoOperacion].ToString();
                    else throw new System.ArgumentException("El tipo de operacion no puede ser nulo");

                    if (campos.Contains(NroComprobante_NombreCol)) row.NRO_COMPROBANTE = campos[NroComprobante_NombreCol].ToString();

                    if (campos.Contains(Observacion_NombreCol)) row.OBSERVACION = campos[Observacion_NombreCol].ToString();
                    
                    if (insertarNuevo) sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.Insert(row);
                    else sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
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
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
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
                    MOVIMIENTOS_VARIOS_TESORow cabecera = sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.GetByCASO_ID(caso_id)[0];
                    MOVIMIENTOS_VARIOS_TESO_DETRow[] detalles = sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.GetByMOVIMIENTO_VARIO_ID(cabecera.ID);

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    if(exito && detalles.Length > 0)
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que posee detalles.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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

        #region ReemplazarCheque
        public static void ReemplazarCheque(System.Collections.Hashtable campos, bool anularCheque)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    decimal valorId = (decimal)campos[MovimientoVarioCajaTesoreriaDetalleService.Id_NombreCol];
                    MOVIMIENTOS_VARIOS_TESO_DETRow valorReemplazadoRow = sesion.db.MOVIMIENTOS_VARIOS_TESO_DETCollection.GetByPrimaryKey(valorId);

                    DataTable dtMovVarioTesoreria = MovimientoVarioCajaTesoreriaService.GetMovimientoVarioCajaTesoreriaDataTable(MovimientoVarioCajaTesoreriaService.Id_NombreCol + " = " + valorReemplazadoRow.MOVIMIENTO_VARIO_ID, string.Empty, sesion);
                    CASOSRow casoRow = sesion.db.CASOSCollection.GetByPrimaryKey((decimal)dtMovVarioTesoreria.Rows[0][OrdenesPagoService.CasoId_NombreCol]);

                    #region Se anula el cheque girado se borra ese valor
                    // O se anula el cheque
                    if (anularCheque)
                    {
                        //Se anula el cheque
                        CuentaCorrienteChequesGiradosService.Anular(valorReemplazadoRow.CTACTE_CHEQUE_GIRADO_ID,
                                                  "Reemplazo de cheque en Movimiento Vario Tesoreria " + Traducciones.Caso + " " + dtMovVarioTesoreria.Rows[0][OrdenesPagoService.CasoId_NombreCol].ToString() + " en estado " + casoRow.ESTADO_ID + ".",
                                                  sesion);
                    }

                    //Se afecta la cuenta bancaria si el cheque ya la habia afectado
                    if (CuentaCorrienteChequesGiradosService.SaldoAfectado(valorReemplazadoRow.CTACTE_CHEQUE_GIRADO_ID, sesion))
                    {
                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                              valorReemplazadoRow.CTACTE_BANCARIA_ID,
                              Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA,
                              (decimal)dtMovVarioTesoreria.Rows[0][MovimientoVarioCajaTesoreriaService.CasoId_NombreCol],
                              Definiciones.Error.Valor.EnteroPositivo,
                              (decimal)dtMovVarioTesoreria.Rows[0][MovimientoVarioCajaTesoreriaService.Id_NombreCol],
                              valorReemplazadoRow.MONEDA_ID,
                              valorReemplazadoRow.MONTO,
                              valorReemplazadoRow.COTIZACION_MONEDA,
                              valorReemplazadoRow.FECHA_VENCIMIENTO,
                              "Reemplazo de cheque en Caso " + dtMovVarioTesoreria.Rows[0][MovimientoVarioCajaTesoreriaService.CasoId_NombreCol].ToString() + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA) + " en estado " + casoRow.ESTADO_ID + ". Anulación del cheque " + valorReemplazadoRow.NUMERO_CHEQUE + " fecha " + valorReemplazadoRow.FECHA_CREACION.Date+ ".",
                              valorReemplazadoRow.CTACTE_CHEQUE_GIRADO_ID,
                              null,
                              true,
                              sesion);
                    }

                    // Se borra el detalle asociado
                    decimal chequeId = valorReemplazadoRow.CTACTE_CHEQUE_GIRADO_ID;
                    valorReemplazadoRow.IsCTACTE_CHEQUE_GIRADO_IDNull = true;
                    sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.Update(valorReemplazadoRow);

                    //En caso que el tipo de movimento haya sido INGRESO, el detalle del movimiento vario de tesoreria esta asociado a ctacte_caja_tesoreria_mov por lo cual se hace null dicho mov_det_id
                    DataTable dt = CuentaCorrienteCajasTesoreriaMovimientosService.GetCuentaCorrienteCajasTesoreriaMovimientosDataTable2(CuentaCorrienteCajasTesoreriaMovimientosService.MovimientoVarioDetId_NombreCol + " = " + valorReemplazadoRow.ID, string.Empty);

                    if (dtMovVarioTesoreria.Rows.Count > 0 && dtMovVarioTesoreria.Rows[0][MovimientoVarioCajaTesoreriaService.TipoOperacion].ToString().Equals("I"))
                    {
                        CTACTE_CAJAS_TESORERIA_MOVRow cajaMov = sesion.db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByPrimaryKey(decimal.Parse(dt.Rows[0][CuentaCorrienteCajasTesoreriaMovimientosService.Id_NombreCol].ToString()));
                        cajaMov.IsMOVIMIENTO_VARIO_DET_IDNull = true;
                        sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Update(cajaMov);
                    }
                    //se borra el detalle del movimiento
                    MovimientoVarioCajaTesoreriaDetalleService.Borrar(valorId);

                    #endregion Se anula el cheque girado se borra ese valor

                    #region Se crea el nuevo valor del cheque girado

                    // Se crea un nuevo detalle con los datos del cheque nuevo
                    decimal valorNuevoId = MovimientoVarioCajaTesoreriaDetalleService.Guardar(campos);

                    //En caso que el tipo de movimento haya sido INGRESO, se asocia el nuevo id del detalle del movimiento vario de tesoreria
                    if (dtMovVarioTesoreria.Rows.Count > 0 && dtMovVarioTesoreria.Rows[0][MovimientoVarioCajaTesoreriaService.TipoOperacion].ToString().Equals("I"))
                    {
                        CTACTE_CAJAS_TESORERIA_MOVRow cajaMov = sesion.db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByPrimaryKey(decimal.Parse(dt.Rows[0][CuentaCorrienteCajasTesoreriaMovimientosService.Id_NombreCol].ToString()));
                        //se actualiza con el nuevo id de movimiento_vario_teso_detalle
                        cajaMov.MOVIMIENTO_VARIO_DET_ID = valorNuevoId;
                        sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Update(cajaMov);
                    }

                    MOVIMIENTOS_VARIOS_TESO_DETRow valorNuevoRow = sesion.db.MOVIMIENTOS_VARIOS_TESO_DETCollection.GetByPrimaryKey(valorNuevoId);
                    System.Collections.Hashtable camposCG = new System.Collections.Hashtable();
                    decimal autonumeracion_id = Definiciones.Error.Valor.EnteroPositivo;
                    string nroCheque;

                    camposCG.Add(CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol, (decimal)dtMovVarioTesoreria.Rows[0][OrdenesPagoService.CasoId_NombreCol]);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol, valorNuevoRow.COTIZACION_MONEDA);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol, valorNuevoRow.CTACTE_BANCARIA_ID);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol, valorNuevoRow.ES_DIFERIDO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol, valorNuevoRow.FECHA_CREACION);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol, valorNuevoRow.FECHA_VENCIMIENTO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.MonedaId_NombreCol, valorNuevoRow.MONEDA_ID);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.Monto_NombreCol, valorNuevoRow.MONTO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol, valorNuevoRow.NOMBRE_BENEFICIARIO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol, string.Empty);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol, valorNuevoRow.NOMBRE_EMISOR);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.CtacteBancoId_NombreCol, valorNuevoRow.CTACTE_BANCO_ID);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.Observacion_NombreCol, valorNuevoRow.OBSERVACION);

                    if (!valorNuevoRow.IsAUTONUMERACION_IDNull)
                    {
                        autonumeracion_id = valorNuevoRow.AUTONUMERACION_ID;
                        camposCG.Add(CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol, valorNuevoRow.AUTONUMERACION_ID);
                    }

                    if (valorNuevoRow.NUMERO_CHEQUE != null && valorNuevoRow.NUMERO_CHEQUE.Length > 0)
                        camposCG.Add(CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol, valorNuevoRow.NUMERO_CHEQUE);

                    //Se crea el cheque girado
                    valorNuevoRow.CTACTE_CHEQUE_GIRADO_ID = CuentaCorrienteChequesGiradosService.Emitir(camposCG, autonumeracion_id, out nroCheque, sesion);
                    valorNuevoRow.NUMERO_CHEQUE = nroCheque;

                    //Se actualiza en la base de datos el id del cheque girado
                    sesion.db.MOVIMIENTOS_VARIOS_TESO_DETCollection.Update(valorNuevoRow);

                    //Se afecta la cuenta bancaria si el cheque no es adelantado
                    if (valorNuevoRow.FECHA_VENCIMIENTO.Date <= DateTime.Now.Date && valorNuevoRow.ES_DIFERIDO == Definiciones.SiNo.No)
                    {
                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                              valorNuevoRow.CTACTE_BANCARIA_ID,
                              Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA,
                              (decimal)dtMovVarioTesoreria.Rows[0][MovimientoVarioCajaTesoreriaService.CasoId_NombreCol],
                              Definiciones.Error.Valor.EnteroPositivo,
                              (decimal)dtMovVarioTesoreria.Rows[0][MovimientoVarioCajaTesoreriaService.Id_NombreCol],
                              valorNuevoRow.MONEDA_ID,
                              valorNuevoRow.MONTO * (-1),
                              valorNuevoRow.COTIZACION_MONEDA,
                              (DateTime)dtMovVarioTesoreria.Rows[0][MovimientoVarioCajaTesoreriaService.Fecha_NombreCol],
                              "Reemplazo de cheque en Caso " + dtMovVarioTesoreria.Rows[0][MovimientoVarioCajaTesoreriaService.CasoId_NombreCol].ToString() + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA) + " (" + valorNuevoRow.NOMBRE_BENEFICIARIO + "). Cheque " + valorNuevoRow.NUMERO_CHEQUE + " fecha " + valorNuevoRow.FECHA_CREACION.Date + ".",
                              valorNuevoRow.CTACTE_CHEQUE_GIRADO_ID,
                              null,
                              false,
                              sesion);
                    }
                    #endregion Se crea el nuevo valor del cheque girado
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion ReemplazarCheque

        #region RecalcularTotal
        public void RecalcularTotal(decimal movimiento_id, SessionService sesion) 
        {
            //se obtiene la cabecera
            MOVIMIENTOS_VARIOS_TESORow row = sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.GetByPrimaryKey(movimiento_id);
            
            //se obtienen los detalles
            MOVIMIENTOS_VARIOS_TESO_DETRow[] detallesRow = sesion.Db.MOVIMIENTOS_VARIOS_TESO_DETCollection.GetByMOVIMIENTO_VARIO_ID(row.ID);

            // se reinicia el total
            row.TOTAL_DOLARIZADO = 0;

            //si la cantidad de detalles es cero retorna
            if (detallesRow.Length > 0)
            {
                for (int i = 0; i < detallesRow.Length; i++)
                {
                    row.TOTAL_DOLARIZADO += detallesRow[i].MONTO / detallesRow[i].COTIZACION_MONEDA;
                }
            }   
            sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.Update(row);
        }
        #endregion RecalcularTotal

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "MOVIMIENTOS_VARIOS_TESO"; }
        }
        public static string Nombre_Vista
        {
            get { return "MOV_VARIOS_TESO_INFO_COMPL"; }
        }
        public static string Id_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.CASO_IDColumnName; }
        }
        public static string CtaCteCajaTesoreriaId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.FECHAColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.OBSERVACIONColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.SUCURSAL_IDColumnName; }
        }
        public static string TextoPredefinidoId
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string TipoOperacion
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.TIPO_OPERACIONColumnName; }
        }
        public static string TotalDoalrizado_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.TOTAL_DOLARIZADOColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return MOVIMIENTOS_VARIOS_TESOCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string VistaAnticipoProvUtilizaCasoId_NombreCol
        {
            get { return MOV_VARIOS_TESO_INFO_COMPLCollection.ANTICIPO_PROV_UTILIZA_CASO_IDColumnName; }
        }
        public static string VistaCasoEstado_NombreCol
        {
            get { return MOV_VARIOS_TESO_INFO_COMPLCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return MOV_VARIOS_TESO_INFO_COMPLCollection.SUCURSALE_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinido_NombreCol
        {
            get { return MOV_VARIOS_TESO_INFO_COMPLCollection.TEXTO_PREDEFINIDOColumnName; }
        }
        public static string VistaTipoOperacion_NombreCol
        {
            get { return MOV_VARIOS_TESO_INFO_COMPLCollection.TIPO_OPERACIONColumnName; }
        }
        public static string VistaCajaTesoreriaNombre_NombreCol
        {
            get { return MOV_VARIOS_TESO_INFO_COMPLCollection.CTACTE_CAJA_TESORERIA_NOMBREColumnName; }
        }
        public static string VistaCajaTesoreriaAbreviatura_NombreCol
        {
            get { return MOV_VARIOS_TESO_INFO_COMPLCollection.CTACTE_CAJA_TESORERIA_ABREVColumnName; }
        }
        #endregion Accessors
    }
}
