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
using CBA.FlowV2.Services.Common;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class TransferenciaCajasSucursalService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de Metodos Heredados
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var drCabecera = (DataRow)caso_cabecera;
            var drDetalle = (DataRow)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            if (!Interprete.EsNullODBNull(drCabecera[TransferenciaCajasSucursalService.SucursalDestinoId_NombreCol]))
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.SucursalRelacionada, drCabecera[TransferenciaCajasSucursalService.SucursalDestinoId_NombreCol]);
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

        public static DataTable GetTransferenciaCajasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTransferenciaCajasDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetTransferenciaCajasDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.TRANSFERENCIA_CAJAS_SUCURSALCollection.GetAsDataTable(clausulas, orden);
        }

        public static DataTable GetTransferenciaCajasInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTransferenciaCajasInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetTransferenciaCajasInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.TRANSFERENCIA_CAJAS_SUC_INF_CCollection.GetAsDataTable(clausulas, orden);
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

                TRANSFERENCIA_CAJAS_SUCURSALRow cabeceraRow = sesion.Db.TRANSFERENCIA_CAJAS_SUCURSALCollection.GetByCASO_ID(caso_id)[0];
                TRANSFERENCIA_CAJAS_SUC_DETRow[] detalleRows = sesion.Db.TRANSFERENCIA_CAJAS_SUC_DETCollection.GetByTRANS_CAJAS_SUC_ID(cabeceraRow.ID);

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

                // de pendiente a en-proceso
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.EnProceso))
                { 
                    exito = true;
                    revisarRequisitos = true;
                    decimal montoTotalTrnsferencia = 0;

                    if (!cabeceraRow.IsFONDO_FIJO_DES_IDNull && !cabeceraRow.IsFONDO_FIJO_ORIGEN_IDNull)
                    {
                        decimal fondoFijoMonedaOrigen = CuentaCorrienteFondosFijosService.GetMonedaFondoFijo(cabeceraRow.FONDO_FIJO_ORIGEN_ID);
                        decimal fondoFijoMonedaDestino = CuentaCorrienteFondosFijosService.GetMonedaFondoFijo(cabeceraRow.FONDO_FIJO_DES_ID);

                        if (fondoFijoMonedaOrigen != fondoFijoMonedaDestino)
                            throw new Exception("La transferencia entre fondos fijos solo se puede dar cuando las monedas son las mismas");
                    }

                    if (!cabeceraRow.IsFONDO_FIJO_ORIGEN_IDNull)
                    {
                        foreach (TRANSFERENCIA_CAJAS_SUC_DETRow row in detalleRows)
                            montoTotalTrnsferencia += row.MONTO;

                        string observación = "Egreso por Transferencia de Cajas de Sucursal " + cabeceraRow.CASO_ID + " pasado al estado En-Proceso. ";

                        //Realizamos el egreso del Fondo Fijo
                        CuentaCorrienteFondosFijosMovimientosService.Movimiento(cabeceraRow.FONDO_FIJO_ORIGEN_ID, Definiciones.Error.Valor.EnteroPositivo, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, cabeceraRow.ID, 0, montoTotalTrnsferencia, detalleRows[0].COTIZACION_MONEDA, observación, cabeceraRow.FECHA, sesion);
                    }
                    else if (!cabeceraRow.IsCAJA_SUC_ORIGEN_IDNull)
                    {
                        if (!CuentaCorrienteCajasSucursalService.EstaAbierta(cabeceraRow.CAJA_SUC_ORIGEN_ID))
                            throw new Exception("La Caja de Sucursal origen seleccionada no está abierta.");

                        decimal monedaFondoFijoDestino = Definiciones.Error.Valor.EnteroPositivo;

                        if (!cabeceraRow.IsFONDO_FIJO_DES_IDNull)
                            monedaFondoFijoDestino = CuentaCorrienteFondosFijosService.GetMonedaFondoFijo(cabeceraRow.FONDO_FIJO_DES_ID);

                        foreach (TRANSFERENCIA_CAJAS_SUC_DETRow row in detalleRows)
                        {
                            if (row.CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                            {
                                if (!monedaFondoFijoDestino.Equals(Definiciones.Error.Valor.EnteroPositivo) && row.MONEDA_ID != monedaFondoFijoDestino)
                                    throw new Exception("Los detalles contienen montos con monedas distinas a las del Fondo Fijo Destino.");

                                CuentaCorrienteCajaService.Egreso(cabeceraRow.CAJA_SUC_ORIGEN_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, cabeceraRow.ID, Definiciones.Error.Valor.EnteroPositivo,
                                                           row.CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, row.MONEDA_ID, row.COTIZACION_MONEDA, row.MONTO, cabeceraRow.FECHA, sesion);
                            }
                            else if (row.CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Cheque)
                            {
                                CuentaCorrienteCajaService.Egreso(cabeceraRow.CAJA_SUC_ORIGEN_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, cabeceraRow.ID, Definiciones.Error.Valor.EnteroPositivo,
                                                           row.CTACTE_VALOR_ID, row.CTACTE_CHEQUE_RECIBIDO_ID, row.MONEDA_ID, row.COTIZACION_MONEDA, row.MONTO, cabeceraRow.FECHA, sesion);
                            }
                        }
                    }
                    else if (!cabeceraRow.IsCAJA_TESO_ORIGEN_IDNull)
                    {
                        foreach (TRANSFERENCIA_CAJAS_SUC_DETRow row in detalleRows)
                        {
                            if (row.CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                            {
                                decimal saldo = CuentaCorrienteCajasTesoreriaService.SaldoEfectivoPorCaja(cabeceraRow.CAJA_TESO_ORIGEN_ID, row.MONEDA_ID, sesion);
                                if (row.MONTO <= saldo)
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(cabeceraRow.CAJA_TESO_ORIGEN_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, string.Empty, row.TRANS_CAJAS_SUC_ID, row.ID, row.CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, row.MONEDA_ID, row.COTIZACION_MONEDA, row.MONTO, cabeceraRow.FECHA, sesion);
                                else 
                                    throw new NotImplementedException("Saldo Insuficiente en la caja de tesorería origen.");
                            }
                            else
                            {
                                DataTable dt = CuentaCorrienteChequesRecibidosService.GetDataTable(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + row.CTACTE_CHEQUE_RECIBIDO_ID, string.Empty, sesion);
                                decimal estado = (decimal)dt.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol];
                                if (!(estado == Definiciones.CuentaCorrienteChequesEstados.Efectivizado || estado == Definiciones.CuentaCorrienteChequesEstados.Depositado))
                                    CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(cabeceraRow.CAJA_TESO_ORIGEN_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, string.Empty, row.TRANS_CAJAS_SUC_ID, row.ID, row.CTACTE_VALOR_ID, row.CTACTE_CHEQUE_RECIBIDO_ID, row.MONEDA_ID, row.COTIZACION_MONEDA, row.MONTO, cabeceraRow.FECHA, sesion);
                                else
                                    throw new NotImplementedException("El cheque ya no está disponible para esta transacción.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("TransferenciaCajasSucursalService.ProcesarCambioEstado. No se pudo realizar el egreso.");
                    }
                }

                // de en-proceso a cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                { 
                    exito = true;
                    revisarRequisitos = true;
                    decimal montoTotalTrnsferencia = 0;
                    
                    //Damos salida a los valores de la caja de sucursal o fondo fijo
                    if (!cabeceraRow.IsFONDO_FIJO_DES_IDNull)
                    {

                        decimal monedaFondoFijoDestino = CuentaCorrienteFondosFijosService.GetMonedaFondoFijo(cabeceraRow.FONDO_FIJO_DES_ID);
                        foreach (TRANSFERENCIA_CAJAS_SUC_DETRow row in detalleRows)
                        {
                            if (row.MONEDA_ID != monedaFondoFijoDestino)
                                throw new Exception("Los detalles contienen montos con monedas distinas a las del Fondo Fijo Destino");

                            montoTotalTrnsferencia += row.MONTO;
                        }

                        string observación = "Ingreso por Transferencia de Cajas de Sucursal " + cabeceraRow.CASO_ID.ToString() + " pasado al estado Cerrado. ";

                        //Realizamos el Ingreso del Fondo Fijo
                        CuentaCorrienteFondosFijosMovimientosService.Movimiento(cabeceraRow.FONDO_FIJO_DES_ID, Definiciones.Error.Valor.EnteroPositivo, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, cabeceraRow.ID, montoTotalTrnsferencia, 0, detalleRows[0].COTIZACION_MONEDA, observación, cabeceraRow.FECHA, sesion);
                    }
                    else if(!cabeceraRow.IsCAJA_SUC_DES_IDNull)
                    {
                        if (!CuentaCorrienteCajasSucursalService.EstaAbierta(cabeceraRow.CAJA_SUC_DES_ID))
                            throw new Exception("La Caja de Sucursal destino seleccionada no está abierta.");
                            
                        foreach (TRANSFERENCIA_CAJAS_SUC_DETRow row in detalleRows)
                        {
                            System.Collections.Hashtable campos = new System.Collections.Hashtable();
                            campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, cabeceraRow.FECHA);
                            campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, row.MONEDA_ID);
                            campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, row.COTIZACION_MONEDA);
                            campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, row.MONTO);
                            if (row.CTACTE_VALOR_ID == (decimal)Definiciones.CuentaCorrienteValores.Efectivo)
                            {
                                campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                            }
                            else if (row.CTACTE_VALOR_ID == (decimal)Definiciones.CuentaCorrienteValores.Cheque)
                            {
                                campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Cheque);
                                campos.Add(CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol, row.CTACTE_CHEQUE_RECIBIDO_ID);
                            }
                            if (row.CTACTE_VALOR_ID == (decimal)Definiciones.CuentaCorrienteValores.POS)
                            {
                                campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.POS);
                            }
                            campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                            campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_DESTINO_ID);
                            campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, CuentaCorrienteCajasSucursalService.GetFuncionarioCobradorId(cabeceraRow.CAJA_SUC_DES_ID));
                            campos.Add(CuentaCorrienteCajaService.TransferenciaCajaSucId_NombreCol, row.TRANS_CAJAS_SUC_ID);
                            campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.DebitoTransferenciaDeCtaCte);
                            campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, cabeceraRow.CAJA_SUC_DES_ID);

                            CuentaCorrienteCajaService.Guardar(campos, sesion);
                        }
                    }
                    else if (!cabeceraRow.IsCAJA_TESO_DESTINO_IDNull)
                    {
                        foreach (TRANSFERENCIA_CAJAS_SUC_DETRow row in detalleRows)
                        {
                            if (row.CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                                CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CAJA_TESO_DESTINO_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, string.Empty, row.TRANS_CAJAS_SUC_ID, row.ID, row.CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, row.MONEDA_ID, row.COTIZACION_MONEDA, row.MONTO, cabeceraRow.FECHA, sesion);
                            else
                                CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CAJA_TESO_DESTINO_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, string.Empty, row.TRANS_CAJAS_SUC_ID, row.ID, row.CTACTE_VALOR_ID, row.CTACTE_CHEQUE_RECIBIDO_ID, row.MONEDA_ID, row.COTIZACION_MONEDA, row.MONTO, cabeceraRow.FECHA, sesion);
                        }
                    }
                    else
                    {
                        throw new Exception("TransferenciaCajasSucursalService.ProcesarCambioEstado. No se pudo realizar el ingreso.");
                    }
                }
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    exito = true;
                    revisarRequisitos = true;
                    decimal montoTotalTrnsferencia = 0;

                    //Damos salida a los valores de la caja de sucursal o fondo fijo
                    if (!cabeceraRow.IsFONDO_FIJO_ORIGEN_IDNull)
                    {
                        decimal monedaFondoFijoOrigen = CuentaCorrienteFondosFijosService.GetMonedaFondoFijo(cabeceraRow.FONDO_FIJO_ORIGEN_ID);
                        foreach (TRANSFERENCIA_CAJAS_SUC_DETRow row in detalleRows)
                        {
                            if (row.MONEDA_ID != monedaFondoFijoOrigen)
                                throw new Exception("Los detalles continenen montos con monedas distinas a las del Fondo Fijo Destino");

                            montoTotalTrnsferencia += row.MONTO;
                        }

                        string observación = "Ingreso por Transferencia de Cajas de Sucursal " + cabeceraRow.CASO_ID.ToString() + " pasado al estado Pendiente. ";

                        //Realizamos el Ingreso del Fondo Fijo
                        CuentaCorrienteFondosFijosMovimientosService.Movimiento(cabeceraRow.FONDO_FIJO_ORIGEN_ID, Definiciones.Error.Valor.EnteroPositivo, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, cabeceraRow.ID, montoTotalTrnsferencia, 0, detalleRows[0].COTIZACION_MONEDA, observación, cabeceraRow.FECHA, sesion);
                    }
                    else if(!cabeceraRow.IsCAJA_SUC_ORIGEN_IDNull)
                    {
                        if (!CuentaCorrienteCajasSucursalService.EstaAbierta(cabeceraRow.CAJA_SUC_ORIGEN_ID))
                            throw new Exception("La Caja de Sucursal origen seleccionada no está abierta.");
                        
                        foreach (TRANSFERENCIA_CAJAS_SUC_DETRow row in detalleRows)
                        {
                            System.Collections.Hashtable campos = new System.Collections.Hashtable();
                            campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, cabeceraRow.FECHA);
                            campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, row.MONEDA_ID);
                            campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, row.COTIZACION_MONEDA);
                            campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, row.MONTO);
                            campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                            campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                            campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ORIGEN_ID);
                            campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, CuentaCorrienteCajasSucursalService.GetFuncionarioCobradorId(cabeceraRow.CAJA_SUC_ORIGEN_ID));
                            campos.Add(CuentaCorrienteCajaService.TransferenciaCajaSucId_NombreCol, row.TRANS_CAJAS_SUC_ID);
                            campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.DebitoTransferenciaDeCtaCte);
                            campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, cabeceraRow.CAJA_SUC_ORIGEN_ID);

                            CuentaCorrienteCajaService.Guardar(campos, sesion);// aqui se ingresa efectivo por transferencia de caja a caja (en proceso a pendiente)
                        }
                    }
                    else if (!cabeceraRow.IsCAJA_TESO_ORIGEN_IDNull)
                    {
                        foreach (TRANSFERENCIA_CAJAS_SUC_DETRow row in detalleRows)
                        {
                            if (row.CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo)
                                CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CAJA_TESO_ORIGEN_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, string.Empty, row.TRANS_CAJAS_SUC_ID, row.ID, row.CTACTE_VALOR_ID, Definiciones.Error.Valor.EnteroPositivo, row.MONEDA_ID, row.COTIZACION_MONEDA, row.MONTO, cabeceraRow.FECHA, sesion);
                            else
                                CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(cabeceraRow.CAJA_TESO_ORIGEN_ID, Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL, string.Empty, row.TRANS_CAJAS_SUC_ID, row.ID, row.CTACTE_VALOR_ID, row.CTACTE_CHEQUE_RECIBIDO_ID, row.MONEDA_ID, row.COTIZACION_MONEDA, row.MONTO, cabeceraRow.FECHA, sesion);
                        }
                    }
                    else
                    {
                        throw new Exception("TransferenciaCajasSucursalService.ProcesarCambioEstado. No se pudo realizar el reingreso.");
                    }
                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.TRANSFERENCIA_CAJAS_SUCURSALCollection.Update(cabeceraRow);
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

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            throw new NotImplementedException();
        }

        #endregion Implementacion de Metodos Heredados

        #region Tiene Detalles
        public static bool TransferenciaTieneDetalles(decimal transferenciaId)
        {
            using (SessionService session = new SessionService())
            {
                string clausulas = TransferenciaCajasSucursalDetalleService.TransfCajaSucId_NombreCol + " = " + transferenciaId.ToString();

                if (TransferenciaCajasSucursalDetalleService.GetTransCajasSucDetalleInfoCompleta(clausulas, string.Empty).Rows.Count > 0)
                    return true;
                return false;

            }
        }
        #endregion Tiene Detalles

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {

            bool exito =  Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
            return exito;
            }
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
                TRANSFERENCIA_CAJAS_SUCURSALRow row = new TRANSFERENCIA_CAJAS_SUCURSALRow();
                try
                {
                    string valorAnterior = string.Empty;
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("TRANSFERENCIA_CAJAS_SUC_SQC");
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[SucursalOrigenId_NombreCol].ToString()),
                                                             int.Parse(Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL.ToString()),
                                                             int.Parse(sesion.Usuario_Id.ToString()),
                                                             SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                        row.FECHA = DateTime.Parse(campos[Fecha_NombreCol].ToString());
                    }
                    else
                    {
                        row = sesion.Db.TRANSFERENCIA_CAJAS_SUCURSALCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    // a partir de este punto se asignan los valores
                    if (campos.Contains(SucursalOrigenId_NombreCol))
                        row.SUCURSAL_ORIGEN_ID = decimal.Parse(campos[SucursalOrigenId_NombreCol].ToString());

                    if (campos.Contains(SucursalDestinoId_NombreCol))
                        row.SUCURSAL_DESTINO_ID = decimal.Parse(campos[SucursalDestinoId_NombreCol].ToString());

                    if (campos.Contains(UsuarioId_NombreCol))
                        row.USUARIO_ID = decimal.Parse(campos[UsuarioId_NombreCol].ToString());

                    if (campos.Contains(CajaSucursalOrigenId_NombreCol))
                        row.CAJA_SUC_ORIGEN_ID = decimal.Parse(campos[CajaSucursalOrigenId_NombreCol].ToString());
                    else
                        row.IsCAJA_SUC_ORIGEN_IDNull = true;

                    if (campos.Contains(CajaSucursalDestinoId_NombreCol))
                        row.CAJA_SUC_DES_ID = decimal.Parse(campos[CajaSucursalDestinoId_NombreCol].ToString());
                    else
                        row.IsCAJA_SUC_DES_IDNull = true;

                    if (campos.Contains(CajaTesoOrigenId_NombreCol))
                        row.CAJA_TESO_ORIGEN_ID = decimal.Parse(campos[CajaTesoOrigenId_NombreCol].ToString());
                    else
                        row.IsCAJA_TESO_ORIGEN_IDNull = true;

                    if (campos.Contains(CajaTesoDestinoId_NombreCol))
                        row.CAJA_TESO_DESTINO_ID = decimal.Parse(campos[CajaTesoDestinoId_NombreCol].ToString());
                    else
                        row.IsCAJA_TESO_DESTINO_IDNull = true;

                    if (campos.Contains(FondoFijoOrigenId_NombreCol))
                        row.FONDO_FIJO_ORIGEN_ID = decimal.Parse(campos[FondoFijoOrigenId_NombreCol].ToString());
                    else
                        row.IsFONDO_FIJO_ORIGEN_IDNull = true;

                    if (campos.Contains(FondoFijoDestinoId_NombreCol))
                        row.FONDO_FIJO_DES_ID = decimal.Parse(campos[FondoFijoDestinoId_NombreCol].ToString());
                    else
                        row.IsFONDO_FIJO_DES_IDNull = true;

                    if (campos.Contains(TextoPredefinidoId_NombreCol))
                        row.TEXTO_PREDEFINIDO_ID = (decimal)campos[TextoPredefinidoId_NombreCol];
                    else
                        row.IsTEXTO_PREDEFINIDO_IDNull = true;

                    if (campos.Contains(Observacion_NombreCol))
                        row.OBSERVACION = campos[Observacion_NombreCol].ToString();                    

                    row.FECHA = DateTime.Parse(campos[Fecha_NombreCol].ToString());

                    if (insertarNuevo)
                        sesion.Db.TRANSFERENCIA_CAJAS_SUCURSALCollection.Insert(row);
                    else
                        sesion.Db.TRANSFERENCIA_CAJAS_SUCURSALCollection.Update(row);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
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
                    TRANSFERENCIA_CAJAS_SUCURSALRow cabecera = sesion.Db.TRANSFERENCIA_CAJAS_SUCURSALCollection.GetByCASO_ID(caso_id)[0];
                    TRANSFERENCIA_CAJAS_SUC_DETRow[] detalles = sesion.Db.TRANSFERENCIA_CAJAS_SUC_DETCollection.GetByTRANS_CAJAS_SUC_ID(cabecera.ID);

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

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.TRANSFERENCIA_CAJAS_SUCURSALCollection.DeleteByCASO_ID(caso_id);
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
        #endregion Borrar

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "TRANSFERENCIA_CAJAS_SUCURSAL"; }
        }
        public static string Id_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.FECHAColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.CASO_IDColumnName; }
        }

        public static string SucursalOrigenId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.SUCURSAL_ORIGEN_IDColumnName; }
        }

        public static string SucursalDestinoId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.SUCURSAL_DESTINO_IDColumnName; }
        }
        public static string CajaSucursalOrigenId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.CAJA_SUC_ORIGEN_IDColumnName; }
        }
        public static string CajaSucursalDestinoId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.CAJA_SUC_DES_IDColumnName; }
        }
        public static string CajaTesoDestinoId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.CAJA_TESO_DESTINO_IDColumnName; }
        }
        public static string CajaTesoOrigenId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.CAJA_TESO_ORIGEN_IDColumnName; }
        }
        public static string FondoFijoOrigenId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.FONDO_FIJO_ORIGEN_IDColumnName; }
        }
        public static string FondoFijoDestinoId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.FONDO_FIJO_DES_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.USUARIO_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUCURSALCollection.OBSERVACIONColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string TransferenciaId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_INF_CCollection.TRANSFERENCIA_IDColumnName; }
        }
        public static string VistaCajaSucOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_INF_CCollection.CAJA_SUC_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaCajaSucDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_INF_CCollection.CAJA_SUC_DES_NOMBREColumnName; }
        }
        public static string VistaCajaTesoDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_INF_CCollection.CAJA_TESO_DESTINO_NOMBREColumnName; }
        }
        public static string VistaCajaTesoOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_INF_CCollection.CAJA_TESO_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaFondoFijoOrigenNombre_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_INF_CCollection.FONDO_FIJO_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaFondoFijoDestinoNombre_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_INF_CCollection.FONDO_FIJO_DESTINO_NOMBREColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return TRANSFERENCIA_CAJAS_SUC_INF_CCollection.CASO_ESTADO_IDColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}




