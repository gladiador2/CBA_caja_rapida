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

namespace CBA.FlowV2.Services.Anticipo
{
    public class AnticiposPersonaService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.ANTICIPO_PERSONA;
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
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, drCabecera[AnticiposPersonaService.TextoPredefinidoId_NombreCol]);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }
        
        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
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
                bool exito = false;
                bool revisarRequisitos = false;
                mensaje = string.Empty;
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    ANTICIPOS_PERSONARow cabeceraRow = sesion.Db.ANTICIPOS_PERSONACollection.GetByCASO_ID(caso_id)[0];

                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Si fue emitido un recibo, el mismo es anulado.
                        exito = true;
                        revisarRequisitos = true;

                        #region anular el recibo si existe
                        if (!cabeceraRow.IsCTACTE_RECIBO_IDNull)
                        {
                            CuentaCorrienteRecibosService.Anular(cabeceraRow.CTACTE_RECIBO_ID, sesion);
                        }
                        #endregion anular el recibo si existe
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //Si no existe un recibo, generarlo.
                        //Si ya existe y cambio el monto total, actualizar el recibo
                        exito = true;
                        revisarRequisitos = true;

                        if (cabeceraRow.MONTO_TOTAL <= 0)
                            throw new Exception("El monto del anticipo debe ser mayor a cero.");

                        #region generar el recibo si se debe
                        //Se confirma que haya una autonumeracion guardada
                        if (cabeceraRow.IsAUTONUMERACION_RECIBO_IDNull)
                            throw new Exception("Debe seleccionar un talonario de recibos");
                        
                        //Si no existe un recibo se crea. Si existe actualizar el monto
                        if (cabeceraRow.IsCTACTE_RECIBO_IDNull)
                        {
                            if (!AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_RECIBO_ID))
                            {
                                System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                decimal numeroSecuencia;
                                string nroRecibo = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_RECIBO_ID, out numeroSecuencia, sesion);
                                
                                campos.Add(CuentaCorrienteRecibosService.AutonumeracionId_NombreCol, cabeceraRow.AUTONUMERACION_RECIBO_ID);
                                campos.Add(CuentaCorrienteRecibosService.Estado_NombreCol, Definiciones.Estado.Activo);
                                campos.Add(CuentaCorrienteRecibosService.Fecha_NombreCol, DateTime.Now);
                                campos.Add(CuentaCorrienteRecibosService.MonedaId_NombreCol, cabeceraRow.MONEDA_ID);
                                campos.Add(CuentaCorrienteRecibosService.Monto_NombreCol, cabeceraRow.MONTO_TOTAL);
                                campos.Add(CuentaCorrienteRecibosService.NroComprobante_NombreCol, nroRecibo);
                                campos.Add(CuentaCorrienteRecibosService.NroComprobanteSecuencia_NombreCol, numeroSecuencia);
                                campos.Add(CuentaCorrienteRecibosService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);

                                cabeceraRow.CTACTE_RECIBO_ID = CuentaCorrienteRecibosService.Guardar(campos, true, true, Definiciones.Error.Valor.EnteroPositivo, sesion);
                            }
                             else
                             {
                                 throw new Exception("Debe Indicar el Nro del Comprobante");
                             }
                        }
                        else
                        {
                            DataTable dtRecibo = CuentaCorrienteRecibosService.GetCtacteReciboDataTable2(cabeceraRow.CTACTE_RECIBO_ID);

                            System.Collections.Hashtable campos = new System.Collections.Hashtable();
                            campos.Add(CuentaCorrienteRecibosService.Id_NombreCol, dtRecibo.Rows[0][CuentaCorrienteRecibosService.Id_NombreCol]);
                            campos.Add(CuentaCorrienteRecibosService.AutonumeracionId_NombreCol, dtRecibo.Rows[0][CuentaCorrienteRecibosService.AutonumeracionId_NombreCol]);
                            campos.Add(CuentaCorrienteRecibosService.Estado_NombreCol, dtRecibo.Rows[0][CuentaCorrienteRecibosService.Estado_NombreCol]);
                            campos.Add(CuentaCorrienteRecibosService.Fecha_NombreCol, dtRecibo.Rows[0][CuentaCorrienteRecibosService.Fecha_NombreCol]);
                            campos.Add(CuentaCorrienteRecibosService.MonedaId_NombreCol, dtRecibo.Rows[0][CuentaCorrienteRecibosService.MonedaId_NombreCol]);
                            campos.Add(CuentaCorrienteRecibosService.Monto_NombreCol, cabeceraRow.MONTO_TOTAL);
                            campos.Add(CuentaCorrienteRecibosService.NroComprobante_NombreCol, dtRecibo.Rows[0][CuentaCorrienteRecibosService.NroComprobante_NombreCol]);
                            campos.Add(CuentaCorrienteRecibosService.PersonaId_NombreCol, dtRecibo.Rows[0][CuentaCorrienteRecibosService.PersonaId_NombreCol]);

                            CuentaCorrienteRecibosService.Guardar(campos, false, true, Definiciones.Error.Valor.EnteroPositivo, sesion);
                        }
                    }
                    #endregion generar el recibo si se debe
                    
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //Se anula el recibo.
                        exito = true;

                        #region anular el recibo
                        if (!cabeceraRow.IsCTACTE_RECIBO_IDNull)
                        {
                            CuentaCorrienteRecibosService.Anular(cabeceraRow.CTACTE_RECIBO_ID, sesion);
                        }
                        #endregion anular el recibo
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //Afectar la cuenta corriente de la persona
                        exito = true;
                        revisarRequisitos = true;

                        if (cabeceraRow.MONTO_TOTAL <= 0)
                            throw new Exception("El monto del anticipo debe ser mayor a cero.");

                        CuentaCorrienteChequesRecibidosService ctacteChequeRecibido = new CuentaCorrienteChequesRecibidosService();
                        CuentaCorrienteCajaService ctacteCaja = new CuentaCorrienteCajaService();
                        ANTICIPOS_PERSONA_DETRow[] detallesRow = sesion.Db.ANTICIPOS_PERSONA_DETCollection.GetByANTICIPO_PERSONA_ID(cabeceraRow.ID);

                        #region afectar ctacte
                        //Ingresar el debito
                        CuentaCorrientePersonasService.AgregarDebito( (decimal)cabeceraRow.PERSONA_ID,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                                                        Definiciones.CuentaCorrienteValores.Anticipo,
                                                        cabeceraRow.CASO_ID,
                                                        cabeceraRow.MONEDA_ID,
                                                        cabeceraRow.COTIZACION_MONEDA,
                                                        new decimal[] { Definiciones.Impuestos.Exenta },
                                                        new decimal[] { cabeceraRow.MONTO_TOTAL },
                                                        string.Empty,
                                                        DateTime.Now.AddYears(1),
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        Definiciones.Error.Valor.EnteroPositivo,
                                                        sesion);
                        #endregion afectar ctacte

                        //Realizar acciones por cada documento
                        for (int i = 0; i < detallesRow.Length; i++)
                        {
                            #region Crear Cheque y depositos e insertar a Caja
                            switch ((int)(detallesRow[i].CTACTE_VALOR_ID))
                            {
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    System.Collections.Hashtable campos2 = new System.Collections.Hashtable();
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol, detallesRow[i].COTIZACION_MONEDA);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol, detallesRow[i].CHEQUE_CTACTE_BANCO_ID);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol, string.Empty);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.EsDiferido_NombreCol, detallesRow[i].CHEQUE_ES_DIFERIDO);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.FechaPosdatado_NombreCol, detallesRow[i].CHEQUE_FECHA_POSDATADO);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol, detallesRow[i].CHEQUE_FECHA_VENCIMIENTO);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol, detallesRow[i].MONEDA_ID);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.Monto_NombreCol, detallesRow[i].MONTO);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.NombreBeneficiario_NombreCol, detallesRow[i].CHEQUE_NOMBRE_BENEFICIARIO);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol, detallesRow[i].CHEQUE_NOMBRE_EMISOR);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol, detallesRow[i].CHEQUE_NRO_CHEQUE);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol, detallesRow[i].CHEQUE_NRO_CUENTA);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.ChequeDeTerceros_NombreCol, detallesRow[i].CHEQUE_DE_TERCEROS);
                                    campos2.Add(CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol, cabeceraRow.CASO_ID);

                                    detallesRow[i].CTACTE_CHEQUE_RECIBIDO_ID = ctacteChequeRecibido.Guardar(campos2, true, sesion);
                                    break;
                                case Definiciones.CuentaCorrienteValores.DepositoBancario:

                                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                                        detallesRow[i].DEPOSITO_CTACTE_BANCARIAS_ID,
                                        Definiciones.FlujosIDs.ANTICIPO_PERSONA,
                                        cabeceraRow.CASO_ID,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        detallesRow[i].ID,
                                        detallesRow[i].MONEDA_ID,
                                        detallesRow[i].MONTO,
                                        detallesRow[i].COTIZACION_MONEDA,
                                        cabeceraRow.FECHA,
                                        "Caso " + cabeceraRow.CASO_ID + " de Anticipo de Persona",
                                        null,
                                        null,
                                        false,
                                        sesion);

                                    break;
                                default:
                                    break;
                             }

                            #region ingresar valores a la caja
                            if (detallesRow[i].CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Efectivo || detallesRow[i].CTACTE_VALOR_ID == Definiciones.CuentaCorrienteValores.Cheque)
                            {
                                
                                decimal ctacteCajaSucursalId = Definiciones.Error.Valor.EnteroPositivo;

                                //Si el Anticipo esta siendo creado desde un proceso de Refinanciacion de Credito
                                //entonces intentar utilizar los valores de la pasarela
                                if (ctacteCajaSucursalId == Definiciones.Error.Valor.EnteroPositivo)
                                {
                                    var notaCreditoCtacteCajaSucursal = this.GetPasarelaCambioEstadoCampo(CBA.FlowV2.Services.Facturacion.CreditosService.ValoresConstantes.CancelacionAnticipadaNotaCreditoCajaSucursal);
                                    if (notaCreditoCtacteCajaSucursal != null)
                                        ctacteCajaSucursalId = (decimal)notaCreditoCtacteCajaSucursal.valor;
                                }                                

                                //Si no se encontro probar con sucursal y funcionario cobrador
                                if (ctacteCajaSucursalId == Definiciones.Error.Valor.EnteroPositivo)
                                    ctacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(cabeceraRow.SUCURSAL_ID, cabeceraRow.FUNCIONARIO_COBRADOR_ID);

                                //Si no se encontro probar con el funcionario asociado al usuario
                                if (ctacteCajaSucursalId.Equals(Definiciones.Error.Valor.EnteroPositivo) && !sesion.Usuario.IsFUNCIONARIO_IDNull)
                                    ctacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(cabeceraRow.SUCURSAL_ID, sesion.Usuario.FUNCIONARIO_ID);

                                //Si no se encontro una abierta, se lanza la excepcion
                                if (ctacteCajaSucursalId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    throw new Exception("No existe una caja abierta.");

                                System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, DateTime.Now);
                                campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, detallesRow[i].MONEDA_ID);
                                campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, detallesRow[i].COTIZACION_MONEDA);
                                campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, detallesRow[i].MONTO);
                                campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, detallesRow[i].CTACTE_VALOR_ID);
                                campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                                campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                                campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, cabeceraRow.FUNCIONARIO_COBRADOR_ID);
                                campos.Add(CuentaCorrienteCajaService.AnticipoPersonaId_NombreCol, detallesRow[i].ANTICIPO_PERSONA_ID);
                                campos.Add(CuentaCorrienteCajaService.AnticipoPersonaDetId_NombreCol, detallesRow[i].ID);
                                campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.DebitoPorPago);
                                campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, ctacteCajaSucursalId);
                                if (detallesRow[i].CTACTE_VALOR_ID.Equals(Definiciones.CuentaCorrienteValores.Cheque))
                                    campos.Add(CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol, detallesRow[i].CTACTE_CHEQUE_RECIBIDO_ID);

                                CuentaCorrienteCajaService.Guardar(campos, sesion);
                            }
                            #endregion ingresar valores a la caja

                            // Se guardan los datos
                            sesion.db.ANTICIPOS_PERSONA_DETCollection.Update(detallesRow[i]);
                            #endregion Crear Cheque y Depositos e insertar a Caja
                        }
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Devolucion))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Devolucion) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        if (cambio_pedido_por_usuario)
                        {
                            mensaje = "Solo el sistema puede utilizar la transición 'Devolución' -> 'Cerrado'.";
                            exito = false;
                        }
                    }
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Cerrado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;

                        if (cambio_pedido_por_usuario)
                            throw new Exception("AnticiposPersonaService.ProcesarCambioEstado(). La transición Cerrado a Aprobado no puede ser realizada por un usuario.");
                    }
                    
                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.ANTICIPOS_PERSONACollection.Update(cabeceraRow);

                        #region Actualizar datos en tabla casos
                        Hashtable camposCaso = new Hashtable();
                        camposCaso.Add(CasosService.FechaFormulario_NombreCol, cabeceraRow.FECHA);
                        camposCaso.Add(CasosService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                        camposCaso.Add(CasosService.FuncionarioId_NombreCol, cabeceraRow.FUNCIONARIO_COBRADOR_ID);
                        camposCaso.Add(CasosService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                        CasosService.ActualizarCampos(cabeceraRow.CASO_ID, camposCaso, sesion);
                        #endregion Actualizar datos en tabla casos
                    }

                }
                catch (Exception exp)
                {
                    exito = false;
                    throw exp;
                }
                return exito;
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }

        #endregion Implementacion de metodos abstract

        #region GetAnticipoPersonaDataTable
        public static DataTable GetAnticipoPersonaDataTable2(decimal anticipo_persona_id)
        {
            return GetAnticipoPersonaDataTable(AnticiposPersonaService.Id_NombreCol + " = " + anticipo_persona_id, string.Empty);
        }

        public static DataTable GetAnticipoPersonaPorCasoDataTable2(decimal caso_anticipo_persona_id, SessionService sesion)
        {
            return GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + caso_anticipo_persona_id, string.Empty);
        }

        public static DataTable GetAnticipoPersonaPorCasoDataTable2(decimal caso_anticipo_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + caso_anticipo_persona_id, string.Empty, sesion);
            }
        }

        public static DataTable GetAnticipoPersonaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAnticipoPersonaDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAnticipoPersonaDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ANTICIPOS_PERSONACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAnticipoPersonaDataTable

        #region GetAnticipoPersonaInfoCompleta
        public static DataTable GetAnticipoPersonaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAnticipoPersonaInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAnticipoPersonaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ANTICIPOS_PERSONA_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAnticipoPersonaInfoCompleta

        #region GetAnticipoPersonaPorCaso
        /// <summary>
        /// Gets the sugerencia por caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetAnticipoPersonaPorCaso(Decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ANTICIPOS_PERSONACollection.GetAsDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetSugerenciaPorCaso

        #region GetAnticipoPersonaPorPersonaId
        public static decimal GetAnticipoPersonaTotalPorPersonaId(decimal personaId)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAnticipoPersonaTotalPorPersonaId(personaId, sesion);
            }
        }

        public static decimal GetAnticipoPersonaTotalPorPersonaId(decimal personaId, SessionService sesion)
        {
            string query = "";
            query += "select sum(ap." + AnticiposPersonaService.SaldoPorAplicar_NombreCol + ") " + AnticiposPersonaService.SaldoPorAplicar_NombreCol + " \n";
            query += "  from " + AnticiposPersonaService.Nombre_Tabla + " ap, " + CasosService.Nombre_Tabla + " c " + "\n";
            query += " where ap." + AnticiposPersonaService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol + " \n";
            query += "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " + "\n";
            query += "   and c." + CasosService.EstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Aprobado + "' \n";
            query += "   and ap." + AnticiposPersonaService.PersonaId_NombreCol + " = " + personaId;

            DataTable dt = sesion.db.EjecutarQuery(query);

            if (dt.Rows[0][AnticiposPersonaService.SaldoPorAplicar_NombreCol] != DBNull.Value)
                return decimal.Parse(dt.Rows[0][AnticiposPersonaService.SaldoPorAplicar_NombreCol].ToString());
            else
                return 0;
        }

        #endregion GetAnticipoPersonaPorPersonaId

        #region DisminuirSaldoDisponible
        /// <summary>
        /// Disminuirs the saldo disponible.
        /// </summary>
        /// <param name="anticipo_persona_id">The anticipo_persona_id.</param>
        /// <param name="total_afectado">The total_afectado.</param>
        /// <param name="sesion">The sesion.</param>
        public static void DisminuirSaldoDisponible(decimal anticipo_persona_id, decimal total_afectado, bool llamada_desde_cambio_estado_otro_flujo, SessionService sesion)
        {
            ANTICIPOS_PERSONARow row = sesion.Db.ANTICIPOS_PERSONACollection.GetByPrimaryKey(anticipo_persona_id);
            string valorAnterior = row.SALDO_POR_APLICAR.ToString();
            bool exito = false;
            string mensaje;

            if (row.SALDO_POR_APLICAR < total_afectado)
                throw new Exception("El anticipo no cuenta con suficiente saldo para ser aplicado.");
            
            row.SALDO_POR_APLICAR -= total_afectado;

            sesion.Db.ANTICIPOS_PERSONACollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, AnticiposPersonaService.SaldoPorAplicar_NombreCol, row.ID, valorAnterior, row.SALDO_POR_APLICAR.ToString(), sesion);

            //Las llamladas desde el cambio de estado de un flujo no deben afecatar al estado del anticipo
            //Las acciones posteriores al cambio de estado realizaran las acciones que se encuentran en este bloque IF
            if (!llamada_desde_cambio_estado_otro_flujo)
            {
                //Si el saldo por aplicar llega a cero, el caso debe
                //ser pasado a cerrado
                if (row.SALDO_POR_APLICAR <= 0)
                {
                    exito = new AnticiposPersonaService().ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, "El saldo del anticipo llegó a cero.", sesion);
                    if (exito)
                        new AnticiposPersonaService().EjecutarAccionesLuegoDeCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                    if (!exito)
                        throw new Exception("Error en AnticiposPersonasService.DisminuirSaldoDisponible. El saldo fue agotado pero el caso no pudo ser pasado a cerrado. " + mensaje + ".");
                }
            }
        }
        #endregion DisminuirSaldoDisponible

        #region AumentarSaldoDisponible
        public static void AumentarSaldoDisponible(decimal anticipo_persona_id, decimal total_afectado, SessionService sesion)
        {
            ANTICIPOS_PERSONARow row = sesion.Db.ANTICIPOS_PERSONACollection.GetByPrimaryKey(anticipo_persona_id);
            decimal saldoAnterior = row.SALDO_POR_APLICAR;
            string valorAnterior = row.SALDO_POR_APLICAR.ToString();
            bool exito = false;
            string mensaje;

            if (row.MONTO_TOTAL < row.SALDO_POR_APLICAR + total_afectado)
                throw new Exception("El saldo no puede ser mayor al monto inicial del anticipo.");

            row.SALDO_POR_APLICAR += total_afectado;

            sesion.Db.ANTICIPOS_PERSONACollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, AnticiposPersonaService.SaldoPorAplicar_NombreCol, row.ID, valorAnterior, row.SALDO_POR_APLICAR.ToString(), sesion);

            //Si el caso estaba cerrado y ahora tiene saldo, debe regresar a aprobado
            if (saldoAnterior == 0 && row.SALDO_POR_APLICAR > 0)
            {
                exito = new AnticiposPersonaService().ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                if (exito)
                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aprobado, "El anticipo tiene saldo por aplicar.", sesion);
                if (exito)
                    new AnticiposPersonaService().EjecutarAccionesLuegoDeCambioEstado(row.CASO_ID, Definiciones.EstadosFlujos.Aprobado, sesion);
                if (!exito)
                    throw new Exception("Error en AnticiposPersonasService.AumentarSaldoDisponible. El saldo fue aumentado pero el caso no pudo ser pasado a aprobado. " + mensaje + ".");
            }
        }
        #endregion AumentarSaldoDisponible

        #region RecalcularTotal
        /// <summary>
        /// Recalculars the total.
        /// </summary>
        /// <param name="anticipo_persona_id">The anticipo_persona_id.</param>
        public void RecalcularTotal(decimal anticipo_persona_id, SessionService sesion)
        {
            ANTICIPOS_PERSONARow row = sesion.Db.ANTICIPOS_PERSONACollection.GetByPrimaryKey(anticipo_persona_id);
            ANTICIPOS_PERSONA_DETRow[] detalleRows = sesion.Db.ANTICIPOS_PERSONA_DETCollection.GetByANTICIPO_PERSONA_ID(anticipo_persona_id);
            decimal total = 0;
            string valorAnterior;

            valorAnterior = row.MONTO_TOTAL.ToString();

            for (int i = 0; i < detalleRows.Length; i++)
            {
                //Debe convertirse si la moneda del valor es distinta a la moneda principal del pago
                if (!row.MONEDA_ID.Equals(detalleRows[i].MONEDA_ID))
                    total += detalleRows[i].MONTO / detalleRows[i].COTIZACION_MONEDA * row.COTIZACION_MONEDA;
                else
                    total += detalleRows[i].MONTO;
            }

            row.MONTO_TOTAL = total;
            row.SALDO_POR_APLICAR = total;

            sesion.Db.ANTICIPOS_PERSONACollection.Update(row);
            LogCambiosService.LogDeColumna(Nombre_Tabla, AnticiposPersonaService.MontoTotal_NombreCol, row.ID, valorAnterior, row.MONTO_TOTAL.ToString(), sesion);
        }
        #endregion RecalcularTotal

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, ref decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, ref id, sesion);
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, ref decimal id, SessionService sesion)
        {
            bool exito = false;
            ANTICIPOS_PERSONARow row = new ANTICIPOS_PERSONARow();

            try
            {
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[AnticiposPersonaService.SucursalId_NombreCol].ToString()),
                                                          int.Parse(Definiciones.FlujosIDs.ANTICIPO_PERSONA.ToString()),
                                                          int.Parse(sesion.Usuario_Id.ToString()),
                                                          SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    row.ID = sesion.Db.GetSiguienteSecuencia("anticipos_persona_sqc");
                    row.MONTO_TOTAL = 0;
                    row.SALDO_POR_APLICAR = 0;
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                    id = row.ID;
                }
                else
                {
                    row = sesion.Db.ANTICIPOS_PERSONACollection.GetByPrimaryKey((decimal)campos[AnticiposPersonaService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                row.FECHA = (DateTime)campos[AnticiposPersonaService.Fecha_NombreCol];

                if (row.SUCURSAL_ID != (decimal)campos[AnticiposPersonaService.SucursalId_NombreCol])
                {
                    if (SucursalesService.EstaActivo((decimal)campos[AnticiposPersonaService.SucursalId_NombreCol]))
                        row.SUCURSAL_ID = (decimal)campos[AnticiposPersonaService.SucursalId_NombreCol];
                    else
                        throw new System.Exception("La sede se encuentra inactiva.");
                }

                if (row.PERSONA_ID != (decimal)campos[AnticiposPersonaService.PersonaId_NombreCol])
                {
                    if (PersonasService.EstaActivo((decimal)campos[AnticiposPersonaService.PersonaId_NombreCol]))
                        row.PERSONA_ID = (decimal)campos[AnticiposPersonaService.PersonaId_NombreCol];
                    else
                        throw new System.Exception("La persona se encuentra inactiva.");
                }

               
                if (!MonedasService.EstaActivo((decimal)campos[AnticiposPersonaService.MonedaId_NombreCol]))
                {
                    throw new System.Exception("La moneda se encuentra inactiva.");
                }
                else
                {
                    row.MONEDA_ID = (decimal)campos[AnticiposPersonaService.MonedaId_NombreCol];

                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);

                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda.");
                }
                //Si cambia, se verifica que este activo
                if (campos.Contains(AnticiposPersonaService.AutonmeracionReciboId_NombreCol))
                {
                    if (row.IsAUTONUMERACION_RECIBO_IDNull || !row.AUTONUMERACION_RECIBO_ID.Equals((decimal)campos[AnticiposPersonaService.AutonmeracionReciboId_NombreCol]))
                    {
                        if (!AutonumeracionesService.EstaActivo((decimal)campos[AnticiposPersonaService.AutonmeracionReciboId_NombreCol]))
                            throw new Exception("El talonario se encuentra inactivo");
                        row.AUTONUMERACION_RECIBO_ID = (decimal)campos[AnticiposPersonaService.AutonmeracionReciboId_NombreCol];

                        
                    }
                    if (AutonumeracionesService.EsGeneracionManual(row.AUTONUMERACION_RECIBO_ID))
                    {
                        string men = string.Empty;
                        if (row.IsCTACTE_RECIBO_IDNull)
                        {
                            if (campos.Contains(AnticiposPersonaService.VistaNroComprobante_NombreCol))
                            {
                                row.CTACTE_RECIBO_ID = CuentaCorrienteRecibosService.CrearRecibo(row.AUTONUMERACION_RECIBO_ID, campos[AnticiposPersonaService.VistaNroComprobante_NombreCol].ToString(),
                                                                      row.PERSONA_ID, row.MONEDA_ID, row.MONTO_TOTAL, row.FECHA, Definiciones.Estado.Activo, out men);
                            }
                        }
                    }
                }
                else
                {
                    row.IsAUTONUMERACION_RECIBO_IDNull = true;
                }
                
                if (!FuncionariosService.EstaActivo((decimal)campos[AnticiposPersonaService.FuncionarioCobradorId_NombreCol]))
                    throw new System.Exception("El funcionario se encuentra inactivo.");
                else
                    row.FUNCIONARIO_COBRADOR_ID = (decimal)campos[AnticiposPersonaService.FuncionarioCobradorId_NombreCol];

                if (campos.Contains(AnticiposPersonaService.TextoPredefinidoId_NombreCol))
                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[AnticiposPersonaService.TextoPredefinidoId_NombreCol];
                else
                    row.IsTEXTO_PREDEFINIDO_IDNull = true;

                row.OBSERVACION = (string)campos[AnticiposPersonaService.Observacion_NombreCol];

                if (insertarNuevo) sesion.Db.ANTICIPOS_PERSONACollection.Insert(row);
                else sesion.Db.ANTICIPOS_PERSONACollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_COBRADOR_ID);
                camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
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
                    id = Definiciones.Error.Valor.EnteroPositivo;
                }

                throw;
            }
            return exito;
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
                    String mensaje = "Error.";

                    //Se obtiene el caso a ser borrado
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    ANTICIPOS_PERSONARow cabecera = sesion.Db.ANTICIPOS_PERSONACollection.GetByCASO_ID(caso_id)[0];
                    AnticiposPersonaDetalleService anticipoPersonaDetalle = new AnticiposPersonaDetalleService();
                    DataTable dtDetalles;

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        //Borrar los detalles del caso
                        dtDetalles = anticipoPersonaDetalle.GetAnticipoPersonaDetalleDataTable(AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol + " = " + cabecera.ID, string.Empty);
                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            anticipoPersonaDetalle.Borrar((decimal)dtDetalles.Rows[i][AnticiposPersonaDetalleService.Id_NombreCol]);
                        }

                        sesion.Db.ANTICIPOS_PERSONACollection.DeleteByCASO_ID(caso_id);
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

        #region AnularYEmitirNuevoRecibo
        /// <summary>
        /// Anulars the Y emitir nuevo recibo.
        /// </summary>
        /// <param name="anticipo_persona_id">The anticipo_persona_id.</param>
        /// <param name="autonumeracion_recibo_id">The autonumeracion_recibo_id.</param>
        /// <returns>Numero de recibo</returns>
        public static string AnularYEmitirNuevoRecibo(decimal anticipo_persona_id, decimal autonumeracion_recibo_id, bool esManual, bool Emitir)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    AutonumeracionesService autonumeracion = new AutonumeracionesService();
                    ANTICIPOS_PERSONARow row = sesion.Db.ANTICIPOS_PERSONACollection.GetByPrimaryKey(anticipo_persona_id);
                    string valorAnterior = row.ToString();
                    System.Collections.Hashtable campos;
                    decimal numeroSecuencia;
                    string nroRecibo;
                    DataTable dtRecibo;

                   
                    //Anular recibo anterior
                    if(!row.IsCTACTE_RECIBO_IDNull)
                        CuentaCorrienteRecibosService.Anular(row.CTACTE_RECIBO_ID, sesion);

                    if (!esManual)
                    {
                        if (Emitir)
                        {
                            #region Creacion del recibo nuevo
                            campos = new System.Collections.Hashtable();
                            nroRecibo = AutonumeracionesService.GetSiguienteNumero2(autonumeracion_recibo_id, out numeroSecuencia, sesion);

                            campos.Add(CuentaCorrienteRecibosService.AutonumeracionId_NombreCol, autonumeracion_recibo_id);
                            campos.Add(CuentaCorrienteRecibosService.Estado_NombreCol, Definiciones.Estado.Activo);
                            campos.Add(CuentaCorrienteRecibosService.Fecha_NombreCol, DateTime.Now);
                            campos.Add(CuentaCorrienteRecibosService.MonedaId_NombreCol, row.MONEDA_ID);
                            campos.Add(CuentaCorrienteRecibosService.Monto_NombreCol, row.MONTO_TOTAL);
                            campos.Add(CuentaCorrienteRecibosService.NroComprobante_NombreCol, nroRecibo);
                            campos.Add(CuentaCorrienteRecibosService.NroComprobanteSecuencia_NombreCol, numeroSecuencia);
                            campos.Add(CuentaCorrienteRecibosService.PersonaId_NombreCol, row.PERSONA_ID);

                            row.CTACTE_RECIBO_ID = CuentaCorrienteRecibosService.Guardar(campos, true, true, Definiciones.Error.Valor.EnteroPositivo, sesion);
                            #endregion Creacion del recibo nuevo
                        }
                        else
                        {
                            row.IsCTACTE_RECIBO_IDNull = true;
                            nroRecibo = string.Empty;
                        }
                    
                    }
                    else
                    {
                        row.IsCTACTE_RECIBO_IDNull = true;
                        nroRecibo = string.Empty;
                    }
                    

                    sesion.Db.ANTICIPOS_PERSONACollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return nroRecibo;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion AnularYEmitirNuevoRecibo

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ANTICIPOS_PERSONA"; }
        }
        public static string Nombre_Vista
        {
            get { return "anticipos_persona_info_comp"; }
        }
        public static string AutonmeracionReciboId_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.AUTONUMERACION_RECIBO_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.CASO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteReciboId_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.CTACTE_RECIBO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.FECHAColumnName; }
        }
        public static string FuncionarioCobradorId_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.FUNCIONARIO_COBRADOR_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.MONTO_TOTALColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.PERSONA_IDColumnName; }
        }
        public static string SaldoPorAplicar_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.SALDO_POR_APLICARColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.SUCURSAL_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return ANTICIPOS_PERSONACollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return ANTICIPOS_PERSONA_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return ANTICIPOS_PERSONA_INFO_COMPCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return ANTICIPOS_PERSONA_INFO_COMPCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return ANTICIPOS_PERSONA_INFO_COMPCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return ANTICIPOS_PERSONA_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return ANTICIPOS_PERSONA_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return ANTICIPOS_PERSONA_INFO_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        #endregion Accessors
    }
}
