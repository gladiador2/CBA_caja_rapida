#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoPersona;
using System.Collections;
//using CBA.FlowV2.Services.Common;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using CBA.FlowV2.Services.ToolbarFlujo;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePagosPersonaDocumentoService
    {
        #region Clase GetMora Webservice
        public static class GetMora
        {
           
        }
        #endregion Clase GetMora Webservice
        
        #region Clase PagarMora Webservice
        public static class PagarMora
        {
          
        }
        #endregion Clase PagarMora Webservice

        #region Clase DesPagarMora Webservice
        public static class DesPagarMora
        {
            
        }
        #endregion Clase DesPagarMora Webservice

        #region GetCuentaCorrientePagosPersonaDocumentoDataTable
        /// <summary>
        /// Gets the cuenta corriente pagos persona documento data table.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDocumentoDataTable(decimal ctacte_pago_persona_id)
        {
            return GetCuentaCorrientePagosPersonaDocumentoDataTable(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id, CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol);
        }

        /// <summary>
        /// Gets the cuenta corriente pagos persona documento data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDocumentoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrientePagosPersonaDocumentoDataTable(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the cuenta corriente pagos persona documento data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDocumentoDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0) where += " and " + clausulas;
                    
            return sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetAsDataTable(where, orden);
        }
        #endregion GetCuentaCorrientePagosPersonaDocumentoDataTable

        #region GetCuentaCorrientePagosPersonaDocumentoInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente pagos persona documento info completa.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(decimal ctacte_pago_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id, CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol, sesion);
            }
        }

        /// <summary>
        /// Gets the cuenta corriente pagos persona documento info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0) where += " and " + clausulas;
            return sesion.Db.CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.GetAsDataTable(where, orden);
        }
        #endregion GetCuentaCorrientePagosPersonaDocumentoInfoCompleta

        #region GetMontoTotal
        public static void GetMontoTotal(decimal ctacte_pago_persona_id, out decimal total_contado, out decimal total_credito, out decimal total_financiero, out decimal total_recargo)
        {
            using (SessionService sesion = new SessionService())
            {
                GetMontoTotal(ctacte_pago_persona_id, out total_contado, out total_credito, out total_financiero, out total_recargo, sesion);
            }
        }

        /// <summary>
        /// Gets the monto total.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="total_contado">The total_contado.</param>
        /// <param name="total_credito">The total_credito.</param>
        /// <param name="total_financiero">The total_financiero.</param>
        /// <param name="total_recargo">The total_recargo.</param>
        public static void GetMontoTotal(decimal ctacte_pago_persona_id, out decimal total_contado, out decimal total_credito, out decimal total_financiero, out decimal total_recargo, SessionService sesion)
        {
            string clausulas = CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id + " and " +
                               CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            CTACTE_PAGOS_PERS_DOC_INF_COMPRow[] rows = sesion.Db.CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.GetAsArray(clausulas, string.Empty);
            DataTable dtCtactePago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pago_persona_id, string.Empty, sesion);
            DataTable dtCtactePersona;
            decimal monto;

            total_contado = 0;
            total_credito = 0;
            total_financiero = 0;
            total_recargo = 0;
            
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].ESTADO.Equals(Definiciones.Estado.Inactivo))
                    continue;

                //Debe convertirse si la moneda del valor es distinta a la moneda principal del pago
                if (rows[i].MONEDA_ID.Equals((decimal)dtCtactePago.Rows[0][PagosDePersonaService.MonedaId_NombreCol]))
                {
                    monto = rows[i].MONTO;
                }
                else
                {
                    monto = rows[i].MONTO / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePago.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                }

                //Se discrimina entre recargo, movimiento contado, credito y credito por cargos financieros
                if (!rows[i].IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
                {
                    total_recargo += monto;
                }
                else if (!rows[i].IsFLUJO_IDNull && rows[i].FLUJO_ID == Definiciones.FlujosIDs.CREDITOS) 
                {
                    //Discriminar entre monto credito por capital y monto financiero por intereses del credito
                    dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.Id_NombreCol + " = " + rows[i].CTACTE_PERSONA_ID, string.Empty, sesion);

                    //Si es entrega inicial no se encuentra en el calendario de pagos
                    if (Interprete.EsNullODBNull(dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol]))
                    {
                        total_contado += monto;
                    }
                    else
                    {
                        var credito = CreditosService.GetPorCaso(rows[i].CASO_ID, sesion);
                        credito.IniciarUsingSesion(sesion);
                        decimal porcentajeCapital = (credito.Calendario[0].MontoCapital + credito.Calendario[0].MontoImpuesto) / (credito.Calendario[0].MontoCapital + credito.Calendario[0].MontoInteresADevengar);

                        if (credito.FacturarIntereses == Definiciones.CreditosPoliticaFacturacion.Pago)
                            total_financiero += monto * (1 - porcentajeCapital);
                        else
                            total_credito += monto * (1 - porcentajeCapital);

                        decimal montoCredito = monto * porcentajeCapital;
                        if (credito.FacturarCapital == Definiciones.CreditosPoliticaFacturacion.Pago)
                            total_contado += montoCredito;
                        else
                            total_credito += montoCredito;

                        credito.FinalizarUsingSesion();
                    }
                }
                else if (rows[i].FACTURA_CLIENTE_TIPO != null && !rows[i].FACTURA_CLIENTE_TIPO.Equals(DBNull.Value) && rows[i].FACTURA_CLIENTE_TIPO == Definiciones.TipoFactura.Contado)
                {
                    total_contado += monto;
                }
                else
                {
                    total_credito += monto;
                }
            }
        }
        #endregion GetMontoTotal

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos,SessionService sesion)
        {
            return Guardar(campos, true, sesion);
        }
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            return Guardar(campos, true, new SessionService());
        }

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="verificar_cuenta_bloqueada">if set to <c>true</c> [verificar_cuenta_bloqueada].</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, bool verificar_cuenta_bloqueada, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONA_DOCUMENTORow row = new CTACTE_PAGOS_PERSONA_DOCUMENTORow();
            DataTable cabecera;
            DataTable dtCtactePagoPersona;
            string valorAnterior = string.Empty;
            decimal saldo;
            valorAnterior = Definiciones.Log.RegistroNuevo;
            CuentaCorrientePersonasService ctactePersona = null ;

            try
            {
                cabecera = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + campos[CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol], string.Empty, sesion);

                string estado = CasosService.GetEstadoCaso((decimal)cabecera.Rows[0][PagosDePersonaService.CasoId_NombreCol]);

                if (estado == Definiciones.EstadosFlujos.Anulado || estado == Definiciones.EstadosFlujos.Aprobado)
                    throw new System.Exception("El caso ya fue " + estado + " no se pueden agregar mas documentos, favor refrescar el caso.");

                if (campos.Contains(CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol))
                {
                    ctactePersona = new CuentaCorrientePersonasService((decimal)campos[CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol], sesion);
                    if (!ctactePersona.ExisteEnDB)
                        throw new System.Exception("El documento no fue encontrado.");

                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si && ctactePersona.CasoId.HasValue)
                    {
                        var sucursal = new SucursalesService((decimal)cabecera.Rows[0][PagosDePersonaService.SucursalId_NombreCol], sesion);
                        CasosService casoDocumento = new CasosService(ctactePersona.CasoId.Value, sesion);
                        if (casoDocumento.Sucursal.RegionId != sucursal.RegionId)
                            throw new Exception("El documento proviene de una región distinta al caso.");
                    }

                    VerificarCuotasPreviasConSaldoAlGuardar((decimal)campos[CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol], (decimal)cabecera.Rows[0][PagosDePersonaService.PersonaId_NombreCol], (decimal)campos[CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol], sesion);
                    VerificarCuotasMenorVencimientoAlGuardar((decimal)campos[CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol], (decimal)cabecera.Rows[0][PagosDePersonaService.PersonaId_NombreCol], (decimal)campos[CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol], sesion);
                }

                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_pagos_persona_doc_sqc");
                row.ESTADO = Definiciones.Estado.Activo;
                row.CTACTE_PAGOS_PERSONA_ID = (decimal)campos[CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol];

                if (campos.Contains(CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol))
                {
                    row.CTACTE_PERSONA_ID = ctactePersona.Id.Value;
                    
                    if (verificar_cuenta_bloqueada && ctactePersona.Bloqueado == Definiciones.SiNo.Si)
                        throw new Exception("El documento se encuentra bloqueado.");

                    saldo = ctactePersona.Credito - ctactePersona.Debito;

                    //Se toma el minimo entre el saldo de la cuota y lo que se desea pagar
                    row.MONTO = Math.Min((decimal)campos[CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol], saldo);

                    //Verificar que si es una factura contado no se realiza un pago parcial sino total, o por el saldo completo
                    if (ctactePersona.CasoId.HasValue)
                    {
                        if (CasosService.GetFlujo((decimal)ctactePersona.CasoId, sesion) == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                        {
                            if (FacturasClienteService.GetTipoFactura(ctactePersona.CasoId.Value, sesion) == Definiciones.TipoFactura.Contado)
                            {
                                if (Math.Round(row.MONTO, ctactePersona.Moneda.CantidadDecimales) != Math.Round(saldo, ctactePersona.Moneda.CantidadDecimales))
                                    throw new System.Exception("Las facturas contado deben ser pagadas en su totalidad. La deuda del documento es " + saldo.ToString(ctactePersona.Moneda.CadenaDecimales) + ".");
                            }
                        }
                    }

                    if (ctactePersona.Moneda.Estado == Definiciones.Estado.Inactivo)
                        throw new System.Exception("La moneda se encuentra inactiva.");
                    row.MONEDA_ID = ctactePersona.MonedaId;

                    if(campos.Contains(CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol))
                        row.COTIZACION_MONEDA = (decimal)campos[CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol];
                    else
                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(sesion.SucursalActiva.PAIS_ID, row.MONEDA_ID, (DateTime)cabecera.Rows[0][PagosDePersonaService.Fecha_NombreCol], sesion);
                    
                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda.");

                    CuentaCorrientePersonasService.SetBloqueado(row.CTACTE_PERSONA_ID, true, sesion);
                }
                else
                {
                    row.IsCTACTE_PERSONA_IDNull = true;

                    row.CTACTE_PAGO_PERSONA_RECARGO_ID = (decimal)campos[CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol];
                    row.MONTO = (decimal)campos[CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];
                    row.MONEDA_ID = (decimal)campos[CuentaCorrientePersonasService.MonedaId_NombreCol];
                    row.COTIZACION_MONEDA = (decimal)campos[CuentaCorrientePersonasService.CotizacionMoneda_NombreCol];
                }

                if (!campos[CuentaCorrientePagosPersonaDocumentoService.Observacion_NombreCol].Equals(System.DBNull.Value))
                    row.OBSERVACION = (string)campos[CuentaCorrientePagosPersonaDocumentoService.Observacion_NombreCol];
                else
                    row.OBSERVACION = string.Empty;

                sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
               {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        if (exp.Message.IndexOf("UK_CTACTE_PAGOS_PERS_DOC_DOC") >= 0)
                        {
                            throw new System.ArgumentException("El documento ya forma parte de los detalles de pago.");
                        }
                        else
                        {
                            throw new System.ArgumentException("Error de unicidad.");
                        }        
                    default:
                        throw exp;
                }
            }
            catch (Exception)
            {
                throw;
            }

            //Se obtiene el datatable que no existia antes si es que el caso fue creado en esta llamada
            dtCtactePagoPersona = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + campos[CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol], string.Empty, sesion);

            //Agregar recargos si corresponde a los documentos que provienen de ctacte personas
            if (!row.IsCTACTE_PERSONA_IDNull)
            {
                #region agregar recargo
                decimal diasDeGraciaMora = Definiciones.Error.Valor.IntPositivo;
                decimal diasDeGraciaInteresPunitorio = Definiciones.Error.Valor.IntPositivo;

                DateTime fechaPago = (DateTime)dtCtactePagoPersona.Rows[0][PagosDePersonaService.Fecha_NombreCol];
                TimeSpan span = fechaPago.Date - ctactePersona.FechaVencimiento.Date;
                
                decimal porcentajeMora = Definiciones.Error.Valor.EnteroPositivo;
                decimal montoMoraDiario = Definiciones.Error.Valor.EnteroPositivo;
                decimal? montoMoraManual = null;
                decimal porcentajeInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasPorcentajeInteresPunitorioSobreMora);
                decimal montoGastoCobranza = 0, montoMora = 0, montoInteresPunitorio;
                System.Collections.Hashtable camposRecargo;

                int flujoId = ctactePersona.CasoId.HasValue ? (int)CasosService.GetFlujo((decimal)ctactePersona.CasoId, sesion) : Definiciones.Error.Valor.IntPositivo;

                switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.PagoDePersonasPoliticaRecargo))
                {
                    case Definiciones.PoliticasRecargo.CBAFlow:
                        #region Definiciones.PoliticasRecargo.CBAFlow
                        if (span.Days > 0)
                        {
                            #region dias de gracia segun flujo
                            switch (flujoId)
                            {
                                case Definiciones.Error.Valor.IntPositivo: //Pagares, se utilizan los valores para Creditos
                                    diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraCreditoDesdeDias);
                                    diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioCreditoDesdeDias);
                                    break;
                                case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                    porcentajeMora = FacturasClienteService.GetPorcentajeMora(ctactePersona.CasoId.Value);
                                    diasDeGraciaMora = FacturasClienteService.GetDiasGracia(ctactePersona.CasoId.Value);
                                    diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioFCDesdeDias);
                                    break;
                                case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                                    diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraFCDesdeDias);
                                    diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioFCDesdeDias);
                                    break;
                                case Definiciones.FlujosIDs.CREDITOS:
                                    diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraCreditoDesdeDias);
                                    diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioCreditoDesdeDias);
                                    var credito = CreditosService.GetPorCaso(ctactePersona.CasoId.Value, sesion);
                                    credito.IniciarUsingSesion(sesion);

                                    if (ctactePersona.CalendarioPagosCRCliId.HasValue && ctactePersona.CalendarioPagosCRCli.MontoMoraManual.HasValue)
                                    {
                                        montoMoraManual = ctactePersona.CalendarioPagosCRCli.MontoMoraManual.Value;
                                    }
                                    else
                                    {
                                        if (credito.PorcentajeDiarioMora.HasValue)
                                            porcentajeMora = credito.PorcentajeDiarioMora.Value;
                                        else
                                            montoMoraDiario = credito.MontoDiarioMora.Value;
                                    }
                                    credito.FinalizarUsingSesion();
                                    break;
                                case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                                    diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraDescuentoDocDesdeDias);
                                    diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioDescuentoDocDesdeDias);
                                    break;
                                case Definiciones.FlujosIDs.TRANSFERENCIA_CTACTE_PERSONA:
                                    diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraFCDesdeDias);
                                    diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioFCDesdeDias);
                                    break;
                                case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                    diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraFCDesdeDias);
                                    diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioFCDesdeDias);
                                    break;
                                case Definiciones.FlujosIDs.CAJA_RAPIDA:
                                    diasDeGraciaMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraDescuentoDocDesdeDias);
                                    diasDeGraciaInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarInteresPunitorioDescuentoDocDesdeDias);
                                    break;

                                default: throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.Guardar(). Flujo no manejado");
                            }
                            #endregion dias de gracia segun flujo

                            //Monto mora es el monto pagado por el porcentaje diario de mora por la cantidad de dias de atraso
                            if (montoMoraManual.HasValue)
                            {
                                montoMora = montoMoraManual.Value;
                            }
                            else
                            {
                                if (porcentajeMora > 0)
                                    montoMora = row.MONTO * porcentajeMora / 100 * span.Days;
                                else
                                    montoMora = montoMoraDiario * span.Days;
                            }

                            //Monto interes punitorio es un porcentaje de la mora
                            montoInteresPunitorio = montoMora * porcentajeInteresPunitorio / 100;

                            #region Calcular fecha de vencimiento + dias de gracia
                            DateTime vencimientoDiasGracia = ctactePersona.FechaVencimiento.AddDays((double)diasDeGraciaMora).Date;
                            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PagoPersonasVerificarCalendarioParaAtraso).Equals(Definiciones.SiNo.Si))
                            {
                                bool diaValido = EsDiaVencimientoValido(vencimientoDiasGracia);

                                while (!diaValido) //Si el dia no es un domingo o feriado, debe correrse al siguiente dia
                                {
                                    vencimientoDiasGracia = vencimientoDiasGracia.AddDays(1);
                                    diaValido = EsDiaVencimientoValido(vencimientoDiasGracia);
                                }
                            }
                            #endregion Calcular fecha de vencimiento + dias de gracia

                            if (montoMora > 0 && (fechaPago > vencimientoDiasGracia))
                            {
                                #region Agregar detalle por mora
                                camposRecargo = new System.Collections.Hashtable();
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Cotizacion_NombreCol, row.COTIZACION_MONEDA);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.Recargo);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaDocId_NombreCol, row.ID);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.MonedaId_NombreCol, row.MONEDA_ID);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Monto_NombreCol, montoMora);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.ImpuestoId_NombreCol, Definiciones.Impuestos.IVA_5);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Observacion_NombreCol, "Mora.");
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol, Definiciones.TipoRecargo.Mora);

                                CuentaCorrientePagosPersonaRecargosService.Guardar(camposRecargo, row.CTACTE_PAGOS_PERSONA_ID, sesion);
                                #endregion Agregar detalle por mora
                            }

                            if (montoInteresPunitorio > 0 && span.Days > diasDeGraciaInteresPunitorio)
                            {
                                #region Agregar detalle por interes punitorio
                                camposRecargo = new System.Collections.Hashtable();
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Cotizacion_NombreCol, row.COTIZACION_MONEDA);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.Recargo);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaDocId_NombreCol, row.ID);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.MonedaId_NombreCol, row.MONEDA_ID);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Monto_NombreCol, montoInteresPunitorio);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.ImpuestoId_NombreCol, Definiciones.Impuestos.IVA_5);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Observacion_NombreCol, "Interés punitorio.");
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol, Definiciones.TipoRecargo.InteresPunitorio);

                                CuentaCorrientePagosPersonaRecargosService.Guardar(camposRecargo, row.CTACTE_PAGOS_PERSONA_ID, sesion);
                                #endregion Agregar detalle por interes punitorio
                            }

                            //Calculado sobre el monto pagado
                            montoGastoCobranza = GastosCobranzasService.GetMontoGastoCobranza((decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.SucursalId_NombreCol],
                                                                                              ctactePersona.FechaVencimiento,
                                                                                              (DateTime)dtCtactePagoPersona.Rows[0][PagosDePersonaService.Fecha_NombreCol],
                                                                                              row.MONEDA_ID,
                                                                                              row.COTIZACION_MONEDA,
                                                                                              row.MONTO);

                            if (montoGastoCobranza > 0)
                            {
                                #region Agregar detalle por gasto de cobranza
                                camposRecargo = new System.Collections.Hashtable();
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Cotizacion_NombreCol, row.COTIZACION_MONEDA);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.Recargo);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaDocId_NombreCol, row.ID);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.MonedaId_NombreCol, row.MONEDA_ID);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Monto_NombreCol, montoGastoCobranza);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.ImpuestoId_NombreCol, Definiciones.Impuestos.IVA_10);
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Observacion_NombreCol, "Gasto de Cobranza.");
                                camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol, Definiciones.TipoRecargo.GastoCobranza);

                                CuentaCorrientePagosPersonaRecargosService.Guardar(camposRecargo, row.CTACTE_PAGOS_PERSONA_ID, sesion);
                                #endregion Agregar detalle por gasto de cobranza
                            }
                        }
                        #endregion Definiciones.PoliticasRecargo.CBAFlow
                        break;

                    case Definiciones.PoliticasRecargo.Webservice:
                        switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
                        {
                            case Definiciones.Clientes.Electroban:
                                #region Agregar detalle por mora
                                

                                if (montoMora > 0)
                                {
                                    camposRecargo = new System.Collections.Hashtable();
                                    camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Cotizacion_NombreCol, row.COTIZACION_MONEDA);
                                    camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.Recargo);
                                    camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaDocId_NombreCol, row.ID);
                                    camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.MonedaId_NombreCol, row.MONEDA_ID);
                                    camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Monto_NombreCol, montoMora);
                                    camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.ImpuestoId_NombreCol, Definiciones.Impuestos.IVA_5);
                                    camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.Observacion_NombreCol, "Mora.");
                                    camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol, Definiciones.TipoRecargo.Mora);

                                    CuentaCorrientePagosPersonaRecargosService.Guardar(camposRecargo, row.CTACTE_PAGOS_PERSONA_ID, sesion);
                                }
                                #endregion Agregar detalle por mora
                                break;
                            default:
                                throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.Guardar(), el cliente no tiene implementación para política de recargo por webservice.");
                        }

                        break;

                    default:
                        throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.Guardar(), política de recargo no implementada.");
                }
                #endregion agregar recargo
            }

            //Actualizar el monto del vuelto
            PagosDePersonaService.ActualizarVuelto(row.CTACTE_PAGOS_PERSONA_ID, sesion);

            //Actualizar el total del recibo si se calcula por documentos
            if (dtCtactePagoPersona.Rows[0][PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol].Equals(Definiciones.SiNo.Si))
                CuentaCorrienteRecibosService.ActualizarTotal(dtCtactePagoPersona, sesion);

            return row.ID;
        }
        #endregion Guardar

        #region GuardarMejorEsfuerzo
        public static void GuardarMejorEsfuerzo(decimal ctacte_pago_persona_id, decimal monto)
        { 
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    GuardarMejorEsfuerzo(ctacte_pago_persona_id, monto, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        public static void GuardarMejorEsfuerzo(decimal ctacte_pago_persona_id, decimal monto, SessionService sesion)
        {
            try
            {
                DataTable dtCtactePago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pago_persona_id, string.Empty, sesion);

                string estado = CasosService.GetEstadoCaso((decimal)dtCtactePago.Rows[0][PagosDePersonaService.CasoId_NombreCol]);

                if (estado == Definiciones.EstadosFlujos.Anulado || estado == Definiciones.EstadosFlujos.Aprobado)
                    throw new System.Exception("El caso ya fue " + estado + " no se pueden agregar mas documentos, favor refrescar el caso.");

                DataTable dtCtactePersonas = CuentaCorrientePersonasService.GetOrdenadoPorVencimientoDataTable((decimal)dtCtactePago.Rows[0][PagosDePersonaService.PersonaId_NombreCol], string.Empty, sesion);

                decimal saldo;
                decimal saldoMonedaDoc, montoAPagar;
                decimal monedaId = (decimal)dtCtactePago.Rows[0][PagosDePersonaService.MonedaId_NombreCol];
                decimal cotizacion = (decimal)dtCtactePago.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                saldo = monto;
                for (int i = 0; saldo > 0 && i < dtCtactePersonas.Rows.Count; i++)
                {
                    Hashtable campos = new Hashtable();
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol, ctacte_pago_persona_id);
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol, dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol]);
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol, dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.Id_NombreCol]);
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.Observacion_NombreCol, dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.VistaObservacion_NombreCol]);

                    if (monedaId == (decimal)dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.MonedaId_NombreCol])
                        saldoMonedaDoc = saldo;
                    else
                        saldoMonedaDoc = saldo / cotizacion * (decimal)dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol];

                    montoAPagar = Math.Min(saldoMonedaDoc, (-1) * (decimal)dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.VistaSaldoDebito_NombreCol]);
                    campos.Add(CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol, montoAPagar);

                    //Guardar los datos
                    CuentaCorrientePagosPersonaDocumentoService.Guardar(campos, sesion);

                    //Disminuir el saldo en la moneda de la cabecera
                    if (monedaId == (decimal)dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.MonedaId_NombreCol])
                        saldo -= montoAPagar;
                    else
                        saldo -= montoAPagar / (decimal)dtCtactePersonas.Rows[i][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol] * cotizacion;

                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion GuardarMejorEsfuerzo

        #region BorrarByCtaCtePersonaId
        public static void BorrarByCtaCtePersonaId(decimal ctacte_persona_id, decimal caso_id, SessionService sesion)
        {
            try
            {
                string estado = CasosService.GetEstadoCaso(caso_id);

                if (estado == Definiciones.EstadosFlujos.Anulado || estado == Definiciones.EstadosFlujos.Aprobado)
                    throw new System.Exception("El caso ya fue " + estado + " no se pueden borrar mas documentos, favor refrescar el caso.");

                string clausulas = CtactePersonaId_NombreCol + " = " + ctacte_persona_id;
                DataTable dt = GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(clausulas, string.Empty, sesion);

                foreach (DataRow r in dt.Rows)
                {
                    Borrar((decimal)r[Id_NombreCol], sesion);
                }
            }
            catch (Exception e) 
            {
                throw e;
            }
        }        
        #endregion BorrarByCtaCtePersonaId

        #region BorrarTodos
        /// <summary>
        /// Borrars the todos.
        /// </summary>
        /// <param name="pago_persona_id">The pago_persona_id.</param>
        public static void BorrarTodos(decimal pago_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = GetCuentaCorrientePagosPersonaDocumentoDataTable(pago_persona_id);

                string estado = CasosService.GetEstadoCaso((decimal)dt.Rows[0][PagosDePersonaService.CasoId_NombreCol]);

                if (estado == Definiciones.EstadosFlujos.Anulado || estado == Definiciones.EstadosFlujos.Aprobado)
                    throw new System.Exception("El caso ya fue " + estado);

                for (int i = 0; i < dt.Rows.Count; i++)
                    Borrar((decimal)dt.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol]);
            }
        }
        #endregion BorrarTodos

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_pago_persona_documento_id.
        /// </summary>
        /// <param name="ctacte_pago_persona_documento_id">The ctacte_pago_persona_documento_id.</param>
        /// 
        public static void Borrar(decimal ctacte_pago_persona_documento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Borrar(ctacte_pago_persona_documento_id, sesion);
            }
        }

        public static void Borrar(decimal ctacte_pago_persona_documento_id, SessionService sesion)
        {
            try
            {
                CTACTE_PAGOS_PERSONA_DOCUMENTORow row = sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetByPrimaryKey(ctacte_pago_persona_documento_id);
                CTACTE_PAGOS_PERSONA_DOCUMENTORow[] rowAux;
                DataTable dtPago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + row.CTACTE_PAGOS_PERSONA_ID, string.Empty);

                string estado = CasosService.GetEstadoCaso((decimal)dtPago.Rows[0][PagosDePersonaService.CasoId_NombreCol]);

                if (estado == Definiciones.EstadosFlujos.Anulado || estado == Definiciones.EstadosFlujos.Aprobado)
                    throw new System.Exception("El caso ya fue " + estado + " no se pueden borrar mas documentos, favor refrescar el caso.");

                VerificarCuotasPreviasConSaldoAlBorrar(row.CTACTE_PAGOS_PERSONA_ID, row.ID, sesion);
                VerificarCuotasMenorVencimientoAlBorrar(row.CTACTE_PAGOS_PERSONA_ID, row.ID, sesion);

                //Si el documento proviene de ctacte_personas deben borrarse los recargos existentes sobre el mimsmo
                //Si el documento es un recargo debe borrarse de la tabla recargos
                if (row.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
                {
                    DataTable dt = CuentaCorrientePagosPersonaRecargosService.GetCuentaCorrientePagosPersonaRecargosDataTable(CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaDocId_NombreCol + " = " + ctacte_pago_persona_documento_id, string.Empty);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Borrado logico
                        rowAux = sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetByCTACTE_PAGO_PERSONA_RECARGO_ID((decimal)dt.Rows[i][CuentaCorrientePagosPersonaRecargosService.Id_NombreCol]);
                        for (int j = 0; j < rowAux.Length; j++)
                        {
                            rowAux[j].ESTADO = Definiciones.Estado.Inactivo;
                            sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Update(rowAux[j]);
                        }

                        CuentaCorrientePagosPersonaRecargosService.Borrar((decimal)dt.Rows[i][CuentaCorrientePagosPersonaRecargosService.Id_NombreCol], sesion);
                    }

                    CuentaCorrientePersonasService.SetBloqueado(row.CTACTE_PERSONA_ID, false, sesion);

                    //Borrado logico
                    row.ESTADO = Definiciones.Estado.Inactivo;
                    sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Update(row);
                }
                else
                {
                    //Borrado logico
                    row.ESTADO = Definiciones.Estado.Inactivo;
                    sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Update(row);
                    CuentaCorrientePagosPersonaRecargosService.Borrar(row.CTACTE_PAGO_PERSONA_RECARGO_ID, sesion);
                }

                //Actualizar el monto del vuelto
                PagosDePersonaService.ActualizarVuelto(row.CTACTE_PAGOS_PERSONA_ID, sesion);

                //Actualizar el total del recibo si se calcula por documentos
                if (dtPago.Rows[0][PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol].Equals(Definiciones.SiNo.Si))
                    CuentaCorrienteRecibosService.ActualizarTotal(dtPago, sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Borrar

        #region Inactivar 
        /// <summary>
        /// Inactivars the specified ctacte_pago_persona_documento_id.
        /// </summary>
        /// <param name="ctacte_pago_persona_documento_id">The ctacte_pago_persona_documento_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Inactivar(decimal ctacte_pago_persona_documento_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONA_DOCUMENTORow row = sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetByPrimaryKey(ctacte_pago_persona_documento_id);
            row.ESTADO = Definiciones.Estado.Inactivo;
            sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Update(row);
        }


        public static void Activar(decimal ctacte_pago_persona_documento_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONA_DOCUMENTORow row = sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetByPrimaryKey(ctacte_pago_persona_documento_id);
            row.ESTADO = Definiciones.Estado.Activo;
            sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Update(row);
        }
        #endregion Inactivar

        #region ConfirmarDocumentos
        /// <summary>
        /// Confirmars the documentos.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="emitir_factura1">if set to <c>true</c> [emitir_factura1].</param>
        /// <param name="emitir_factura2">if set to <c>true</c> [emitir_factura2].</param>
        /// <param name="detalles_recibo">The detalles_recibo.</param>
        /// <param name="detalles_factura1">The detalles_factura1.</param>
        /// <param name="detalles_factura2">The detalles_factura2.</param>
        /// <param name="total_documentos">The total_documentos.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ConfirmarDocumentos(decimal ctacte_pago_persona_id, decimal ctacte_caja_sucursal_id, bool emitir_factura1, bool emitir_factura2, out Hashtable[] detalles_recibo, out Hashtable[] detalles_factura1, out Hashtable[] detalles_factura2, out decimal total_documentos, SessionService sesion)
        {
            DataTable dtCtactePersonaTotal, dtCtactePagoPersona;
            decimal saldo;
            string mensaje;

            DataTable dtCtactePersonaDet;
            Hashtable montoPorImpuesto;
            Hashtable camposRecargo;
            decimal[] impuestoId, monto;
            decimal articuloGastoCobranza, articuloInteresPunitorio, articuloMora;
            int indiceAux, contadorDetallesRecibo = 0, contadorDetallesFactura1 = 0, contadorDetallesFactura2 = 0;
            decimal montoVerificacion, ctacteRecargoId;
            string clausulas;

            total_documentos = 0;

            dtCtactePagoPersona = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pago_persona_id, string.Empty, sesion);

            //Documentos del pago
            clausulas = CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id + " and " +
                        CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            CTACTE_PAGOS_PERSONA_DOCUMENTORow[] rows = sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetAsArray(clausulas, CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol);

            //Se inicializan los arreglos usando el tamanho maximo que puedan tener (asumiendo que cada detalle puede dividirse en capital, interes corriente y gasto administrativo)
            //Luego se utiliza un hashtable auxiliar para reducir el tamanho de los arreglos a solo lo necesario
            detalles_recibo = new Hashtable[rows.Length * 3];
            detalles_factura1 = new Hashtable[rows.Length * 3];
            detalles_factura2 = new Hashtable[rows.Length * 3];

            articuloGastoCobranza = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoGastoCobranza);
            articuloMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoMoraArticulo);
            articuloInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoInteresPunitorio);

            //Realizar acciones por cada documento
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].ESTADO.Equals(Definiciones.Estado.Inactivo))
                    continue;

                //Si es un recargo entonces debe ser creado en la cuenta corriente
                //para luego ser pagado
                if (rows[i].IsCTACTE_PERSONA_IDNull)
                {
                    rows[i].CTACTE_PERSONA_ID = CuentaCorrientePagosPersonaRecargosService.CrearCredito(rows[i].CTACTE_PAGO_PERSONA_RECARGO_ID, ctacte_pago_persona_id, sesion);
                    sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Update(rows[i]);
                }

                //Se obtiene el registro de la cuenta corriente de la persona
                var ctactePersona = new CuentaCorrientePersonasService(rows[i].CTACTE_PERSONA_ID, sesion);
                int flujo_id = (int)CasosService.GetFlujo((decimal)ctactePersona.CasoId, sesion);

                //Se obtienen todos los registros relacionados con saldo mayor a 0.01 salvo el que se esta pagando
                if(ctactePersona.CasoId.HasValue)
                {
                    clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + ctactePersona.CasoId.Value + " and " + 
                                "(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                }
                else
                {
                    if (ctactePersona.CtactePagareDetId.HasValue)
                    {
                        DataTable dtPagareDetalle = CuentaCorrientePagaresDetalleService.GetCuentaCorrientePagaresDetalleDataTable(CuentaCorrientePagaresDetalleService.Id_NombreCol + " = " + ctactePersona.CtactePagareDetId.Value, string.Empty, sesion);
                        clausulas = CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol + " = " + dtPagareDetalle.Rows[0][CuentaCorrientePagaresDetalleService.CtactePagareId_NombreCol] + " and " +
                                   "(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                    }
                    else
                    {
                        clausulas = "(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                    }
                }

                dtCtactePersonaTotal = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(clausulas, string.Empty, sesion);

                #region Calcular monto por tipo de impuesto
                montoPorImpuesto = new System.Collections.Hashtable();
                dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable(ctactePersona.Id.Value, sesion);

                for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                {
                    if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                        montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol];
                    else
                        montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol]);
                }
            
                impuestoId = new decimal[montoPorImpuesto.Count];
                monto = new decimal[montoPorImpuesto.Count];

                indiceAux = 0;
                montoVerificacion = 0;
                foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                {
                    impuestoId[indiceAux] = (decimal)par.Key;
                    monto[indiceAux] = (decimal)par.Value / Math.Max(ctactePersona.Credito, ctactePersona.Debito) * rows[i].MONTO;

                    montoVerificacion += monto[indiceAux];

                    indiceAux++;
                }

                //Se aumenta la suma parcial de documentos pagados que se devuelve como parametro saliente
                if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol]) 
                    total_documentos += rows[i].MONTO;
                else
                    total_documentos += (rows[i].MONTO / rows[i].COTIZACION_MONEDA) * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                
                if (Math.Round(rows[i].MONTO, 4) != Math.Round(montoVerificacion, 4))
                    throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + rows[i].MONTO + ".");
                #endregion Calcular monto por tipo de impuesto

                #region AgregarDebito
                //Ingresar el debito
                ctactePersona.Debito += rows[i].MONTO; //quitar esta linea cuando AgregarDebito utilice orientacion a objeto
                CuentaCorrientePersonasService.AgregarDebito(ctactePersona.PersonaId,
                                            ctactePersona.Id.Value,
                                            Definiciones.CuentaCorrienteConceptos.DebitoPorPago,
                                            Definiciones.CuentaCorrienteValores.Efectivo, //Se agrega efectivo por completar el dato simplemente
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            rows[i].MONEDA_ID,
                                            rows[i].COTIZACION_MONEDA,
                                            impuestoId,
                                            monto,
                                            string.Empty,
                                            (DateTime)dtCtactePagoPersona.Rows[0][PagosDePersonaService.Fecha_NombreCol],
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            rows[i].ID,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            sesion);

                #endregion AgregarDebito

                #region Control de Saldo
                //Saldo antes del pago actual
                saldo = ctactePersona.Credito - ctactePersona.Debito;

                //Desbloquear la ctacte
                CuentaCorrientePersonasService.SetBloqueado(rows[i].CTACTE_PERSONA_ID, false, sesion);

                //Si el saldo es cero y no existe otros movimientos con saldo debe cerrarse el caso pagado
                //No se toman en cuenta los recargos, salvo para el flujo Creditos que al pasar de En-Revisión a Vigente puede incluir recargos como cuotas.
                if (ctactePersona.CasoId.HasValue && 
                    Math.Round(saldo, ctactePersona.Moneda.CantidadDecimales) == 0 &&
                    dtCtactePersonaTotal.Rows.Count <= 1 && 
                    (ctactePersona.CtacteConceptoId != Definiciones.CuentaCorrienteConceptos.Recargo || ctactePersona.Caso.FlujoId == Definiciones.FlujosIDs.CREDITOS))
                {
                    bool exitoCasoAsociado = false;
                    switch (flujo_id)
                    {
                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                            FacturasClienteService facturaCliente = new FacturasClienteService();
                            exitoCasoAsociado = facturaCliente.ProcesarCambioEstado(ctactePersona.CasoId.Value, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                            if (exitoCasoAsociado)
                                exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(ctactePersona.CasoId.Value, Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                            if (exitoCasoAsociado)
                                facturaCliente.EjecutarAccionesLuegoDeCambioEstado(ctactePersona.CasoId.Value, Definiciones.EstadosFlujos.Cerrado, sesion);

                            if (!exitoCasoAsociado)
                                throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos, Facturacion Cliente. " + mensaje + ".");
                            break;
                        case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                            NotasDebitoPersonaService notaDebitoPersona = new NotasDebitoPersonaService();
                            exitoCasoAsociado = notaDebitoPersona.ProcesarCambioEstado(ctactePersona.CasoId.Value, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                            if (exitoCasoAsociado)
                                exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(ctactePersona.CasoId.Value, Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                            if (exitoCasoAsociado)
                                notaDebitoPersona.EjecutarAccionesLuegoDeCambioEstado(ctactePersona.CasoId.Value, Definiciones.EstadosFlujos.Cerrado, sesion);

                            if (!exitoCasoAsociado)
                                throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos, Nota de débito persona. " + mensaje + ".");
                            break;
                        case Definiciones.FlujosIDs.CREDITOS:
                            var credito = CreditosService.GetPorCaso(ctactePersona.CasoId.Value, sesion);
                            credito.IniciarUsingSesion(sesion);
                            credito.ProcesarCambioEstado(Definiciones.EstadosFlujos.Cerrado, false, new ToolbarFlujoService.ComentarioTransicion { texto = "Transición automática por deuda finiquitada." }, sesion);
                            credito.FinalizarUsingSesion();
                            break;
                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                            DescuentoDocumentosClienteService descuento = new DescuentoDocumentosClienteService();
                            exitoCasoAsociado = descuento.ProcesarCambioEstado(ctactePersona.CasoId.Value, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                            if (exitoCasoAsociado)
                                exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(ctactePersona.CasoId.Value, Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                            if (exitoCasoAsociado)
                                descuento.EjecutarAccionesLuegoDeCambioEstado(ctactePersona.CasoId.Value, Definiciones.EstadosFlujos.Cerrado, sesion);
                            if (!exitoCasoAsociado)
                                throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos, Descuento de Documentos Cliente. " + mensaje + ".");
                            break;
                            
                    }
                }
                #endregion Control de Saldo

                #region Discriminar detalles de comprobantes de pago
                #region Recargo
                if (!rows[i].IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
                {
                    DataTable dtCtactePagoPersonaRecargo = CuentaCorrientePagosPersonaRecargosService.GetCuentaCorrientePagosPersonaRecargosDataTable(CuentaCorrientePagosPersonaRecargosService.Id_NombreCol + " = " + rows[i].CTACTE_PAGO_PERSONA_RECARGO_ID, string.Empty);

                    #region Registrar el recargo en ctacte_recargos
                    camposRecargo = new Hashtable();
                    camposRecargo.Add(CuentaCorrienteRecargosService.CasoOrigenId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol]);
                    camposRecargo.Add(CuentaCorrienteRecargosService.Cotizacion_NombreCol, rows[i].COTIZACION_MONEDA);
                    camposRecargo.Add(CuentaCorrienteRecargosService.CtactePagoPersonaDocId_NombreCol, rows[i].ID);
                    camposRecargo.Add(CuentaCorrienteRecargosService.CtactePagoPersonaRecargoId_NombreCol, rows[i].CTACTE_PAGO_PERSONA_RECARGO_ID);
                    camposRecargo.Add(CuentaCorrienteRecargosService.Fecha_NombreCol, DateTime.Now);
                    camposRecargo.Add(CuentaCorrienteRecargosService.FuncionarioId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.FuncionarioCobradorId_NombreCol]);
                    camposRecargo.Add(CuentaCorrienteRecargosService.MonedaId_NombreCol, rows[i].MONEDA_ID);
                    camposRecargo.Add(CuentaCorrienteRecargosService.Monto_NombreCol, rows[i].MONTO);
                    camposRecargo.Add(CuentaCorrienteRecargosService.PersonaId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol]);
                    camposRecargo.Add(CuentaCorrienteRecargosService.SucursalId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.SucursalId_NombreCol]);
                    camposRecargo.Add(CuentaCorrienteRecargosService.TipoRecargo_NombreCol, dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol]);

                    //Si no se emite la factura entonces todavia no se define la caja de sucursal
                    if(emitir_factura1 || emitir_factura2)
                        camposRecargo.Add(CuentaCorrienteRecargosService.CtacteCajaSucursalId_NombreCol, ctacte_caja_sucursal_id);

                    if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.GastoCobranza)
                        camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, Articulos.ArticulosService.GetImpuestoId(articuloGastoCobranza));
                    else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.InteresPunitorio)
                        camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, Articulos.ArticulosService.GetImpuestoId(articuloInteresPunitorio));
                    else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.Mora)
                        camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, Articulos.ArticulosService.GetImpuestoId(articuloMora));

                    ctacteRecargoId = CuentaCorrienteRecargosService.Guardar(camposRecargo, sesion);
                    #endregion Registrar el recargo en ctacte_recargos

                    if (emitir_factura2)
                    {
                        detalles_factura2[contadorDetallesFactura2] = new Hashtable();

                        detalles_factura2[contadorDetallesFactura2][FacturasClienteDetalleService.CtacteRecargoId_NombreCol] = ctacteRecargoId;

                        if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.GastoCobranza)
                        {
                            detalles_factura2[contadorDetallesFactura2][FacturasClienteDetalleService.ArticuloId_NombreCol] = articuloGastoCobranza;
                            detalles_factura2[contadorDetallesFactura2][FacturasClienteDetalleService.Observacion_NombreCol] = "Gasto de Cobranza " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        }
                        else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.InteresPunitorio)
                        {
                            detalles_factura2[contadorDetallesFactura2][FacturasClienteDetalleService.ArticuloId_NombreCol] = articuloInteresPunitorio;
                            detalles_factura2[contadorDetallesFactura2][FacturasClienteDetalleService.Observacion_NombreCol] = "Interés Punitorio " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        }
                        else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.Mora)
                        {
                            detalles_factura2[contadorDetallesFactura2][FacturasClienteDetalleService.ArticuloId_NombreCol] = articuloMora;
                            detalles_factura2[contadorDetallesFactura2][FacturasClienteDetalleService.Observacion_NombreCol] = "Mora " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        }

                        if(rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            detalles_factura2[contadorDetallesFactura2][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO;
                        else
                            detalles_factura2[contadorDetallesFactura2][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                        contadorDetallesFactura2++;
                    }
                    else if (emitir_factura1)
                    {
                        detalles_factura1[contadorDetallesFactura1] = new Hashtable();

                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.CtacteRecargoId_NombreCol] = ctacteRecargoId;

                        if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.GastoCobranza)
                        {
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoGastoCobranza);
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = "Gasto de Cobranza " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        }
                        else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.InteresPunitorio)
                        {
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoInteresPunitorio);
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = "Interés Punitorio " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        }
                        else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.Mora)
                        {
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoMoraArticulo);
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = "Mora " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        } 
                        
                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO;
                        else
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                        contadorDetallesFactura1++;
                    }
                    else
                    {
                        detalles_recibo[contadorDetallesRecibo] = new Hashtable();

                        if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.GastoCobranza)
                        {
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoGastoCobranza);
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.Observacion_NombreCol] = "Gasto de Cobranza " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        }
                        else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.InteresPunitorio)
                        {
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoInteresPunitorio);
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.Observacion_NombreCol] = "Interés Punitorio " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        }
                        else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.Mora)
                        {
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoMoraArticulo);
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.Observacion_NombreCol] = "Mora " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        } 
                        
                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO;
                        else
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                        contadorDetallesRecibo++;
                    }
                }
                #endregion Recargo

                #region Credito de Personas
                else if (rows[i].IsCTACTE_PAGO_PERSONA_RECARGO_IDNull && ctactePersona.CasoId.HasValue && flujo_id == Definiciones.FlujosIDs.CREDITOS)
                {
                    ArticulosService articulo;
                    decimal montoConcepto = 0;

                    var credito = CreditosService.GetPorCaso(ctactePersona.CasoId.Value, sesion);
                    credito.IniciarUsingSesion(sesion);

                    CreditosService.CalendarioService[] cuotas;

                    //Se paga una cuota normal o se paga una cancelacion anticipada
                    if (ctactePersona.CalendarioPagosCRCliId.HasValue)
                    {
                        //Si es una cuota normal
                        cuotas = new CreditosService.CalendarioService[1] { ctactePersona.CalendarioPagosCRCli };
                    }
                    else
                    {
                        //Si es una cancelacion anticipada
                        cuotas = credito.GetFiltrado<CreditosService.CalendarioService>(new ClaseCBABase.Filtro[] 
                        {
                            new ClaseCBABase.Filtro { Columna = CreditosService.CalendarioService.Modelo.CREDITO_IDColumnName, Valor = credito.Id.Value },
                            new ClaseCBABase.Filtro { Columna = CreditosService.CalendarioService.Modelo.CANCELACION_ANTICIPADAColumnName, Valor = Definiciones.SiNo.Si }
                        });
                    }

                    int plazo = credito.CantidadDias;
                    int diasAnho = credito.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;
                    
                    //Obtener los saldos de interes y capital, priorizando lo ya pagado como interes
                    decimal saldoInteres = 0;
                    decimal saldoCapital = 0;
                    foreach (var c in cuotas)
                    {
                        saldoInteres = c.MontoInteresADevengar + c.MontoInteresDevengado + c.MontoInteresEnSuspenso;
                        saldoCapital = c.MontoCapital + c.MontoImpuesto;
                    }
                    saldoInteres -= ctactePersona.Debito;

                    if (saldoInteres < 0)
                    {
                        saldoCapital = -saldoInteres;
                        saldoInteres = 0;
                    }

                    decimal pagoInteres = Math.Min(rows[i].MONTO, saldoInteres);
                    decimal pagoCapital = rows[i].MONTO - pagoInteres;
                    decimal porcentajePago = rows[i].MONTO / ctactePersona.Credito;

                    //Verificar si se debe agregar un detalle por el capital
                    if (credito.FacturarCapital == Definiciones.CreditosPoliticaFacturacion.Pago)
                    {
                        //Agregar el detalle de Capital
                        detalles_factura1[contadorDetallesFactura1] = new Hashtable();
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoCapitalArticulo);
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = "Capital " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];

                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoCapital;
                        else
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoCapital / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                        contadorDetallesFactura1++;
                    }
                    else 
                    {
                        //Agregar el detalle de capital al recibo
                        detalles_recibo[contadorDetallesRecibo] = new Hashtable();
                        detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoCapitalArticulo);
                        detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.Observacion_NombreCol] = "Capital " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoCapital;
                        else
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoCapital / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                        contadorDetallesRecibo++;
                    }

                    articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente).Articulo;
                    if (articulo.ArticulosLotes.Length <= 0)
                        throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                    //Verificar si se debe agregar detalles por el interes
                    if(credito.FacturarIntereses == Definiciones.CreditosPoliticaFacturacion.Pago)
                    {
                        //Agregar el detalle de interes corriente
                        detalles_factura1[contadorDetallesFactura1] = new Hashtable();
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoInteres;
                        else
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoInteres / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                        contadorDetallesFactura1++;
                    }
                    else
                    {
                        //Agregar el detalle de capital al recibo
                        detalles_recibo[contadorDetallesRecibo] = new Hashtable();
                        detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                        detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";
                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoInteres;
                        else
                            detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoInteres / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                        contadorDetallesRecibo++;
                    }

                    //Verificar si se debe agregar detalles por conceptos
                    if (credito.FacturarConceptosEnPagos == Definiciones.SiNo.Si)
                    {
                        #region FC Detalle por gasto administrativo
                        articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        detalles_factura1[contadorDetallesFactura1] = new Hashtable();
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                        if (credito.MontoGastoAdministrativo.HasValue)
                            montoConcepto = credito.MontoGastoAdministrativo.Value;
                        else
                            montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeGastoAdminist.Value / diasAnho / 100 * plazo;

                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            montoConcepto = montoConcepto * porcentajePago;
                        else
                            montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                        if (montoConcepto > 0)
                        {
                            contadorDetallesFactura1++;
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                        }
                        #endregion FC Detalle por gasto administrativo

                        #region FC Detalle por seguro
                        articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Seguro).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        detalles_factura1[contadorDetallesFactura1] = new Hashtable();
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                        if (credito.MontoSeguro.HasValue)
                            montoConcepto = credito.MontoSeguro.Value;
                        else
                            montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeSeguro.Value / diasAnho / 100 * plazo;

                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            montoConcepto = montoConcepto * porcentajePago;
                        else
                            montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                        
                        if (montoConcepto > 0)
                        {
                            contadorDetallesFactura1++;
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                        }
                        #endregion FC Detalle por seguro

                        #region FC Detalle por corretaje
                        articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Corretaje).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        detalles_factura1[contadorDetallesFactura1] = new Hashtable();
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                        if (credito.MontoCorretaje.HasValue)
                            montoConcepto = credito.MontoCorretaje.Value;
                        else
                            montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeCorretaje.Value / diasAnho / 100 * plazo;

                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            montoConcepto = montoConcepto * porcentajePago;
                        else
                            montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                        if (montoConcepto > 0)
                        {
                            contadorDetallesFactura1++;
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                        }
                        #endregion FC Detalle por corretaje

                        #region FC Detalle por comision administrativa
                        articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.ComisionAdministrativa).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        detalles_factura1[contadorDetallesFactura1] = new Hashtable();
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                        if (credito.MontoComisionAdmin.HasValue)
                            montoConcepto = credito.MontoComisionAdmin.Value;
                        else
                            montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeComisionAdmin.Value / diasAnho / 100 * plazo;

                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            montoConcepto = montoConcepto * porcentajePago;
                        else
                            montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                       
                        if (montoConcepto > 0)
                        {
                            contadorDetallesFactura1++;
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                        }
                        #endregion FC Detalle por comision administrativa

                        #region FC Detalle por otros
                        articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Otros).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        detalles_factura1[contadorDetallesFactura1] = new Hashtable();
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                        if (credito.MontoOtros.HasValue)
                            montoConcepto = credito.MontoOtros.Value;
                        else
                            montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeOtros.Value / diasAnho / 100 * plazo;

                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            montoConcepto = montoConcepto * porcentajePago;
                        else
                            montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                        if (montoConcepto > 0)
                        {
                            contadorDetallesFactura1++;
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                        }
                        #endregion FC Detalle por otros

                        #region FC Detalle por bonificacion
                        articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.BonificacionOrdenCompra).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        detalles_factura1[contadorDetallesFactura1] = new Hashtable();
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                        detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                        if (credito.MontoBonificacion.HasValue)
                            montoConcepto = credito.MontoBonificacion.Value;
                        else
                            montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeBonificacion.Value / diasAnho / 100 * plazo;

                        if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                            montoConcepto = montoConcepto * porcentajePago;
                        else
                            montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                        if (montoConcepto > 0)
                        {
                            contadorDetallesFactura1++;
                            detalles_factura1[contadorDetallesFactura1][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                        }
                        #endregion FC Detalle por bonificacion
                    }

                    credito.FinalizarUsingSesion();
                }
                #endregion Credito de Personas

                #region Incluir en recibo si es credito y no se ingreso en las opciones anteriores
                else if (flujo_id == Definiciones.FlujosIDs.CREDITOS ||
                         flujo_id == Definiciones.FlujosIDs.REFINANCIACION_DEUDAS ||
                        (flujo_id == Definiciones.FlujosIDs.FACTURACION_CLIENTE && FacturasClienteService.GetTipoFactura(ctactePersona.CasoId.Value, sesion) != Definiciones.TipoFactura.Contado))
                {
                    detalles_recibo[contadorDetallesRecibo] = new Hashtable();
                    detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClientePorGananciaOtroFlujoArticulo);
                    detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.Observacion_NombreCol] = "Pago sobre " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                    if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                        detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO;
                    else
                        detalles_recibo[contadorDetallesRecibo][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                    contadorDetallesRecibo++;
                }
                #endregion Incluir en recibo si es credito y no se ingreso en las opciones anteriores
                #endregion Discriminar detalles de comprobantes de pago
            }

            #region disminuir el tamanho de los arreglos de hashtable
            Array.Resize(ref detalles_factura1, contadorDetallesFactura1);
            Array.Resize(ref detalles_factura2, contadorDetallesFactura2);
            Array.Resize(ref detalles_recibo, contadorDetallesRecibo);
            #endregion ajustar hashtables devueltas por el metodo al tamanho minimo posible
        }
        #endregion ConfirmarDocumentos

        #region ConfirmarDocumentosCompensacion
        public static void ConfirmarDocumentosCompensacion(decimal ctacte_pago_persona_id, decimal[] ctacte_pago_persona_documento_id, bool emitir_factura, out Hashtable[] detalles_factura, out decimal total_documentos, SessionService sesion)
        {
            DataTable dtCtactePersona, dtCtactePersonaTotal, dtCtactePagoPersona;
            decimal saldo;
            string mensaje;

            DataTable dtCtactePersonaDet;
            Hashtable montoPorImpuesto;
            Hashtable camposRecargo;
            decimal[] impuestoId, monto;
            int indiceAux, contadorDetallesFactura = 0;
            decimal articuloGastoCobranza, articuloInteresPunitorio, articuloMora;
            decimal montoVerificacion, ctacteRecargoId;
            string clausulas;

            total_documentos = 0;
            detalles_factura = new Hashtable[0];

            if(ctacte_pago_persona_documento_id.Length > 0)
            {
                dtCtactePagoPersona = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pago_persona_id, string.Empty);

                //Documentos del pago
                clausulas = CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol + " in (" + string.Join(",", Array.ConvertAll<decimal, string>(ctacte_pago_persona_documento_id, delegate(decimal i) { return i.ToString(); })) + ") ";
                CTACTE_PAGOS_PERSONA_DOCUMENTORow[] rows = sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetAsArray(clausulas, string.Empty);

                //Se inicializa el arreglo usando el tamanho maximo que puedan tener (asumiendo que cada detalle puede dividirse en capital, interes corriente y gasto administrativo)
                //Luego se utiliza un hashtable auxiliar para reducir el tamanho de los arreglos a solo lo necesario
                detalles_factura = new Hashtable[rows.Length * 3];

                articuloGastoCobranza = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoGastoCobranza);
                articuloMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoMoraArticulo);
                articuloInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoInteresPunitorio);

                //Realizar acciones por cada documento
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i].ESTADO.Equals(Definiciones.Estado.Inactivo))
                        continue;

                    //Si es un recargo entonces debe ser creado en la cuenta corriente
                    //para luego ser pagado
                    if (rows[i].IsCTACTE_PERSONA_IDNull)
                    {
                        rows[i].CTACTE_PERSONA_ID = CuentaCorrientePagosPersonaRecargosService.CrearCredito(rows[i].CTACTE_PAGO_PERSONA_RECARGO_ID, ctacte_pago_persona_id, sesion);
                        sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Update(rows[i]);
                    }

                    //Se obtiene el registro de la cuenta corriente de la persona
                    dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + rows[i].CTACTE_PERSONA_ID, string.Empty, sesion);

                    //Se obtienen todos los registros relacionados con saldo mayor a 0.01 salvo el que se esta pagando
                    if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol].Equals(DBNull.Value))
                    {
                        clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol] + " and " +
                                    "(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                    }
                    else
                    {
                        if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol].Equals(DBNull.Value))
                        {
                            clausulas = CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol + " = " + dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol] + " and " +
                                       "(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                        }
                        else
                        {
                            clausulas = "(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                        }
                    }

                    dtCtactePersonaTotal = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(clausulas, string.Empty, sesion);

                    #region Calcular monto por tipo de impuesto
                    montoPorImpuesto = new System.Collections.Hashtable();
                    dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], sesion);

                    for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                    {
                        if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                            montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol];
                        else
                            montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol]);
                    }

                    impuestoId = new decimal[montoPorImpuesto.Count];
                    monto = new decimal[montoPorImpuesto.Count];

                    indiceAux = 0;
                    montoVerificacion = 0;
                    foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                    {
                        impuestoId[indiceAux] = (decimal)par.Key;
                        monto[indiceAux] = (decimal)par.Value / Math.Max((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol], (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol]) * rows[i].MONTO;

                        montoVerificacion += monto[indiceAux];

                        indiceAux++;
                    }

                    //Se aumenta la suma parcial de documentos pagados que se devuelve como parametro saliente
                    if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                        total_documentos += rows[i].MONTO;
                    else
                        total_documentos += (rows[i].MONTO / rows[i].COTIZACION_MONEDA) * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                    if (Math.Round(rows[i].MONTO, 4) != Math.Round(montoVerificacion, 4))
                        throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentosCompensacion(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + rows[i].MONTO + ".");
                    #endregion Calcular monto por tipo de impuesto

                    #region AgregarDebito
                    //Ingresar el debito
                    CuentaCorrientePersonasService.AgregarDebito((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.PersonaId_NombreCol],
                                                (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                                Definiciones.CuentaCorrienteConceptos.DebitoPorPago,
                                                Definiciones.CuentaCorrienteValores.Efectivo, //Se agrega efectivo por completar el dato simplemente
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                rows[i].MONEDA_ID,
                                                rows[i].COTIZACION_MONEDA,
                                                impuestoId,
                                                monto,
                                                string.Empty,
                                                (DateTime)dtCtactePagoPersona.Rows[0][PagosDePersonaService.Fecha_NombreCol],
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                rows[i].ID,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                sesion);

                    #endregion AgregarDebito

                    #region Control de Saldo
                    //Saldo antes del pago actual
                    saldo = (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] -
                            (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol];

                    //Saldo luego del pago actual
                    saldo -= rows[i].MONTO;

                    //Desbloquear la ctacte
                    CuentaCorrientePersonasService.SetBloqueado(rows[i].CTACTE_PERSONA_ID, false, sesion);

                    //Si es FC, ND o credito de clientes, el saldo es cero y no existe otros movimientos con saldo debe cerrarse el caso pagado
                    if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol].Equals(DBNull.Value) &&
                        !dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CtaCteConceptoId_NombreCol].Equals(Definiciones.CuentaCorrienteConceptos.Recargo) &&
                         Math.Round(saldo, 4) == 0 && dtCtactePersonaTotal.Rows.Count <= 1)
                    {
                        int flujoId = Convert.ToInt32(dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol]);
                        bool exitoCasoAsociado = false;

                        switch (flujoId)
                        {
                            case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                FacturasClienteService facturaCliente = new FacturasClienteService();
                                exitoCasoAsociado = facturaCliente.ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                if (exitoCasoAsociado)
                                    exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                if (exitoCasoAsociado)
                                    facturaCliente.EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                                if (!exitoCasoAsociado)
                                    throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentosCompensacion, Facturacion Cliente. " + mensaje + ".");
                                break;
                            case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                                NotasDebitoPersonaService notaDebitoPersona = new NotasDebitoPersonaService();
                                exitoCasoAsociado = notaDebitoPersona.ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                if (exitoCasoAsociado)
                                    exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                if (exitoCasoAsociado)
                                    notaDebitoPersona.EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                                if (!exitoCasoAsociado)
                                    throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentosCompensacion, Nota de débito persona. " + mensaje + ".");
                                break;
                            case Definiciones.FlujosIDs.CREDITOS:
                                var credito = CreditosService.GetPorCaso((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], sesion);
                                credito.IniciarUsingSesion(sesion);
                                credito.ProcesarCambioEstado(Definiciones.EstadosFlujos.Cerrado, false, new ToolbarFlujoService.ComentarioTransicion { texto = "Transición automática por deuda finiquitada." }, sesion);
                                credito.FinalizarUsingSesion();
                                break;
                        }
                    }
                    #endregion Control de Saldo

                    #region Discriminar detalles de comprobantes de pago
                    #region Recargo
                    if (!rows[i].IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
                    {
                        DataTable dtCtactePagoPersonaRecargo = CuentaCorrientePagosPersonaRecargosService.GetCuentaCorrientePagosPersonaRecargosDataTable(CuentaCorrientePagosPersonaRecargosService.Id_NombreCol + " = " + rows[i].CTACTE_PAGO_PERSONA_RECARGO_ID, string.Empty);

                        #region Registrar el recargo en ctacte_recargos
                        camposRecargo = new Hashtable();
                        camposRecargo.Add(CuentaCorrienteRecargosService.CasoOrigenId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol]);
                        camposRecargo.Add(CuentaCorrienteRecargosService.Cotizacion_NombreCol, rows[i].COTIZACION_MONEDA);
                        camposRecargo.Add(CuentaCorrienteRecargosService.CtactePagoPersonaDocId_NombreCol, rows[i].ID);
                        camposRecargo.Add(CuentaCorrienteRecargosService.CtactePagoPersonaRecargoId_NombreCol, rows[i].CTACTE_PAGO_PERSONA_RECARGO_ID);
                        camposRecargo.Add(CuentaCorrienteRecargosService.Fecha_NombreCol, DateTime.Now);
                        camposRecargo.Add(CuentaCorrienteRecargosService.FuncionarioId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.FuncionarioCobradorId_NombreCol]);
                        camposRecargo.Add(CuentaCorrienteRecargosService.MonedaId_NombreCol, rows[i].MONEDA_ID);
                        camposRecargo.Add(CuentaCorrienteRecargosService.Monto_NombreCol, rows[i].MONTO);
                        camposRecargo.Add(CuentaCorrienteRecargosService.PersonaId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol]);
                        camposRecargo.Add(CuentaCorrienteRecargosService.SucursalId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.SucursalId_NombreCol]);
                        camposRecargo.Add(CuentaCorrienteRecargosService.TipoRecargo_NombreCol, dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol]);

                        if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.GastoCobranza)
                        {
                            camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, Articulos.ArticulosService.GetImpuestoId(articuloGastoCobranza));
                        }
                        else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.InteresPunitorio)
                        {
                            camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, Articulos.ArticulosService.GetImpuestoId(articuloInteresPunitorio));
                        }
                        else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.Mora)
                        {
                            camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, Articulos.ArticulosService.GetImpuestoId(articuloMora));
                        }

                        ctacteRecargoId = CuentaCorrienteRecargosService.Guardar(camposRecargo, sesion);
                        #endregion Registrar el recargo en ctacte_recargos

                        if (emitir_factura)
                        {
                            detalles_factura[contadorDetallesFactura] = new Hashtable();

                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.CtacteRecargoId_NombreCol] = ctacteRecargoId;

                            if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.GastoCobranza)
                            {
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoGastoCobranza);
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = "Gasto de Cobranza " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                            }
                            else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.InteresPunitorio)
                            {
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoInteresPunitorio);
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = "Interés Punitorio " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                            }
                            else if ((decimal)dtCtactePagoPersonaRecargo.Rows[0][CuentaCorrientePagosPersonaRecargosService.TipoRecargo_NombreCol] == Definiciones.TipoRecargo.Mora)
                            {
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoMoraArticulo);
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = "Mora " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];
                            }

                            if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO;
                            else
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = rows[i].MONTO / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                            contadorDetallesFactura++;
                        }
                    }
                    #endregion Recargo

                    #region Credito de Personas
                    else if (rows[i].IsCTACTE_PAGO_PERSONA_RECARGO_IDNull && 
                             !dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol].Equals(DBNull.Value) &&
                             (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol] == Definiciones.FlujosIDs.CREDITOS)
                    {
                        ArticulosService articulo;
                        decimal montoConcepto = 0;
                        
                        var credito = CreditosService.GetPorCaso((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], sesion);
                        credito.IniciarUsingSesion(sesion);

                        CreditosService.CalendarioService[] cuotas;

                        //Se paga una cuota normal o se paga una cancelacion anticipada
                        if (!Interprete.EsNullODBNull(dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol]))
                        {
                            //Si es una cuota normal
                            cuotas = new CreditosService.CalendarioService[1] { credito.Get<CreditosService.CalendarioService>((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol]) };
                        }
                        else
                        {
                            //Si es una cancelacion anticipada
                            cuotas = credito.GetFiltrado<CreditosService.CalendarioService>(new ClaseCBABase.Filtro[] 
                            {
                                new ClaseCBABase.Filtro { Columna = CreditosService.CalendarioService.Modelo.CREDITO_IDColumnName, Valor = dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol] },
                                new ClaseCBABase.Filtro { Columna = CreditosService.CalendarioService.Modelo.CANCELACION_ANTICIPADAColumnName, Valor = Definiciones.SiNo.Si }
                            });
                        }

                        int plazo = credito.CantidadDias;
                        int diasAnho = credito.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;

                        //Obtener los saldos de interes y capital, priorizando lo ya pagado como interes
                        decimal saldoInteres = 0;
                        decimal saldoCapital = 0;
                        foreach (var c in cuotas)
                        {
                            saldoInteres = c.MontoInteresADevengar + c.MontoInteresDevengado + c.MontoInteresEnSuspenso;
                            saldoCapital = c.MontoCapital + c.MontoImpuesto;
                        }
                        saldoInteres -= (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol];

                        if (saldoInteres < 0)
                        {
                            saldoCapital = -saldoInteres;
                            saldoInteres = 0;
                        }

                        decimal pagoInteres = Math.Min(rows[i].MONTO, saldoInteres);
                        decimal pagoCapital = rows[i].MONTO - pagoInteres;
                        decimal porcentajePago = rows[i].MONTO / (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol];

                        //Verificar si se debe agregar un detalle por el capital
                        if (credito.FacturarIntereses == Definiciones.CreditosPoliticaFacturacion.Pago)
                        {
                            //Agregar el detalle de Capital
                            detalles_factura[contadorDetallesFactura] = new Hashtable();
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoCapitalArticulo);
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = "Capital " + Traducciones.Caso + " Nº" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol];

                            if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoCapital;
                            else
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoCapital / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                            contadorDetallesFactura++;
                        }

                        articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        //Verificar si se debe agregar detalles por el interes
                        if(credito.FacturarIntereses == Definiciones.CreditosPoliticaFacturacion.Pago)
                        {
                            //Agregar el detalle de interes corriente
                            detalles_factura[contadorDetallesFactura] = new Hashtable();
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                            if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoInteres;
                            else
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = pagoInteres / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                            contadorDetallesFactura++;
                        }

                        //Verificar si se debe agregar detalles por conceptos
                        if (credito.FacturarConceptosEnPagos == Definiciones.SiNo.Si)
                        {
                            #region FC Detalle por gasto administrativo
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            detalles_factura[contadorDetallesFactura] = new Hashtable();
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                            if (credito.MontoGastoAdministrativo.HasValue)
                                montoConcepto = credito.MontoGastoAdministrativo.Value;
                            else
                                montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeGastoAdminist.Value / diasAnho / 100 * plazo;

                            if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                                montoConcepto = montoConcepto * porcentajePago;
                            else
                                montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                            if (montoConcepto > 0)
                            {
                                contadorDetallesFactura++;
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                            }
                            #endregion FC Detalle por gasto administrativo

                            #region FC Detalle por seguro
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Seguro).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            detalles_factura[contadorDetallesFactura] = new Hashtable();
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                            if (credito.MontoSeguro.HasValue)
                                montoConcepto = credito.MontoSeguro.Value;
                            else
                                montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeSeguro.Value / diasAnho / 100 * plazo;

                            if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                                montoConcepto = montoConcepto * porcentajePago;
                            else
                                montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                            
                            if (montoConcepto > 0)
                            {
                                contadorDetallesFactura++;
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                            }
                            #endregion FC Detalle por seguro

                            #region FC Detalle por corretaje
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Corretaje).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            detalles_factura[contadorDetallesFactura] = new Hashtable();
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                            if (credito.MontoCorretaje.HasValue)
                                montoConcepto = credito.MontoCorretaje.Value;
                            else
                                montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeCorretaje.Value / diasAnho / 100 * plazo;

                            if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                                montoConcepto = montoConcepto * porcentajePago;
                            else
                                montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                            if (montoConcepto > 0)
                            {
                                contadorDetallesFactura++;
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                            }
                            #endregion FC Detalle por corretaje

                            #region FC Detalle por comision administrativa
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.ComisionAdministrativa).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            detalles_factura[contadorDetallesFactura] = new Hashtable();
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                            if (credito.MontoComisionAdmin.HasValue)
                                montoConcepto = credito.MontoComisionAdmin.Value;
                            else
                                montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeComisionAdmin.Value / diasAnho / 100 * plazo;

                            if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                                montoConcepto = montoConcepto * porcentajePago;
                            else
                                montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                           
                            if (montoConcepto > 0)
                            {
                                contadorDetallesFactura++;
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                            }
                            #endregion FC Detalle por comision administrativa

                            #region FC Detalle por otros
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Otros).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            detalles_factura[contadorDetallesFactura] = new Hashtable();
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                            if (credito.MontoOtros.HasValue)
                                montoConcepto = credito.MontoOtros.Value;
                            else
                                montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeOtros.Value / diasAnho / 100 * plazo;

                            if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                                montoConcepto = montoConcepto * porcentajePago;
                            else
                                montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                            if (montoConcepto > 0)
                            {
                                contadorDetallesFactura++;
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                            }
                            #endregion FC Detalle por otros

                            #region FC Detalle por bonificacion
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.BonificacionOrdenCompra).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            detalles_factura[contadorDetallesFactura] = new Hashtable();
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.ArticuloId_NombreCol] = articulo.Id.Value;
                            detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.Observacion_NombreCol] = articulo.DescripcionImpresion + " (" + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + ")";

                            if (credito.MontoBonificacion.HasValue)
                                montoConcepto = credito.MontoBonificacion.Value;
                            else
                                montoConcepto = credito.MontoCapitalSolicitado * credito.PorcentajeBonificacion.Value / diasAnho / 100 * plazo;

                            if (rows[i].MONEDA_ID == (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol])
                                montoConcepto = montoConcepto * porcentajePago;
                            else
                                montoConcepto = montoConcepto * porcentajePago / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                            if (montoConcepto > 0)
                            {
                                contadorDetallesFactura++;
                                detalles_factura[contadorDetallesFactura][FacturasClienteDetalleService.TotalNeto_NombreCol] = montoConcepto;
                            }
                            #endregion FC Detalle por bonificacion
                        }

                        credito.FinalizarUsingSesion();
                    }
                    #endregion Credito de Personas
                    
                    #endregion Discriminar detalles de comprobantes de pago
                }
            }

            #region disminuir el tamanho de los arreglos de hashtable
            Array.Resize(ref detalles_factura, contadorDetallesFactura);
            #endregion ajustar hashtables devueltas por el metodo al tamanho minimo posible
        }
        #endregion ConfirmarDocumentosCompensacion

        #region AccionesPosterioresAConfirmarDocumentos
        /// <summary>
        /// Accioneses the posteriores a confirmar documentos.
        /// </summary>
        /// <param name="ctacte_pago_personas_id">The ctacte_pago_personas_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <exception cref="System.Exception">
        /// Error en CuentaCorrientePagosPersonaDocumentoService.AccionesPosterioresAConfirmarDocumentos(), el cliente no tiene implementación para política de recargo por webservice.
        /// or
        /// Error en CuentaCorrientePagosPersonaDocumentoService.AccionesPosterioresAConfirmarDocumentos(), política de recargo no implementada.
        /// </exception>
        public static void AccionesPosterioresAConfirmarDocumentos(decimal ctacte_pago_personas_id, SessionService sesion)
        {
            switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.PagoDePersonasPoliticaRecargo))
            {
                case Definiciones.PoliticasRecargo.CBAFlow:
                    break;
                case Definiciones.PoliticasRecargo.Webservice:
                    switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
                    {
                        case Definiciones.Clientes.Electroban:
                           
                            break;
                        default:
                            throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.AccionesPosterioresAConfirmarDocumentos(), el cliente no tiene implementación para política de recargo por webservice.");
                    }

                    break;

                default:
                    throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.AccionesPosterioresAConfirmarDocumentos(), política de recargo no implementada.");
            }
        }
        #endregion AccionesPosterioresAConfirmarDocumentos

        #region AccionesPosterioresADesconfirmarDocumentos
        public static void AccionesPosterioresADesconfirmarDocumentos(decimal ctacte_pago_personas_id, decimal[] ctacte_pago_persona_recargo_id, SessionService sesion)
        {
            switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.PagoDePersonasPoliticaRecargo))
            {
                case Definiciones.PoliticasRecargo.CBAFlow:
                    break;
                case Definiciones.PoliticasRecargo.Webservice:
                    switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
                    {
                        
                        default:
                            throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.AccionesPosterioresAConfirmarDocumentos(), el cliente no tiene implementación para política de recargo por webservice.");
                    }

                    break;

                default:
                    throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.AccionesPosterioresAConfirmarDocumentos(), política de recargo no implementada.");
            }
        }
        #endregion AccionesPosterioresADesconfirmarDocumentos

        #region VerificarDeudaDocumentos
        /// <summary>
        /// Verificars the deuda documentos.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="mensaje">The mensaje.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool VerificarDeudaDocumentos(decimal ctacte_pago_persona_id, out string mensaje, SessionService sesion)
        {
            DataTable dtCtactePersonas;
            decimal saldo;
            string clausulas;

            //Documentos del pago
            clausulas = CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id + " and " +
                        CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            CTACTE_PAGOS_PERSONA_DOCUMENTORow[] rows = sesion.Db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetAsArray(clausulas, CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol);

            mensaje = string.Empty;

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].ESTADO.Equals(Definiciones.Estado.Inactivo))
                    continue;

                //Los recargos no son registros de ctacte_personas hasta que el pago es confirmado
                if (rows[i].IsCTACTE_PERSONA_IDNull) continue;

                dtCtactePersonas = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.Id_NombreCol + " = " + rows[i].CTACTE_PERSONA_ID, string.Empty, sesion);

                #region Controlar si esta en judicial
                if ((string)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.Judicial_NombreCol] == Definiciones.SiNo.Si)
                {
                    if (!RolesService.Tiene("pagos de persona pagar en judicial"))
                        throw new Exception(string.Format("No se puede realizar el pago porque el caso {0} se encuentra en judicial.", dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol]));
                }
                #endregion Controlar si esta en judicial
                

                saldo = (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] - (decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol];

                if (saldo < rows[i].MONTO)
                {
                    string strSaldo = saldo == 0 ? "0" : saldo.ToString(MonedasService.CadenaDecimales2((decimal)dtCtactePersonas.Rows[0][CuentaCorrientePersonasService.MonedaId_NombreCol]));
                    mensaje = "El documento sobre el que desea pagar " + rows[i].MONTO.ToString(MonedasService.CadenaDecimales2(rows[i].MONEDA_ID)) + " cuenta con un saldo de " + strSaldo + ".";
                    return false;
                }
            }

            return true;
        }
        #endregion VerificarDeudaDocumentos

        #region VerificarCuotasPreviasConSaldo
        public static bool VerificarCuotasPreviasConSaldoAlGuardar(decimal ctacte_pago_persona_id, decimal persona_id, decimal ctacte_persona_id, SessionService sesion)
        {
            try
            {
                if (RolesService.Tiene("PAGOS DE PERSONA NO CONTROLAR CUOTAS PREVIAS CON SALDO"))
                    return true;

                bool verificar = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PagoDePersonasControlarCuotasPreviasConSaldo).Equals(Definiciones.SiNo.Si);

                if (verificar)
                {
                    string sql = 
                            "select cp2." + CuentaCorrientePersonasService.CuotaNumero_NombreCol + ", cp2." + CuentaCorrientePersonasService.CasoId_NombreCol +
                            "  from " + CuentaCorrientePersonasService.Nombre_Tabla + " cp1, " +
                            "       " + CuentaCorrientePersonasService.Nombre_Tabla + " cp2 " +
                            " where cp1." + CuentaCorrientePersonasService.CasoId_NombreCol + " = cp2." + CuentaCorrientePersonasService.CasoId_NombreCol +
                            "   and cp1." + CuentaCorrientePersonasService.CuotaNumero_NombreCol + " > cp2." + CuentaCorrientePersonasService.CuotaNumero_NombreCol +
                            "   and round(cp2." + CuentaCorrientePersonasService.Credito_NombreCol + ", 2) > round(cp2." + CuentaCorrientePersonasService.Debito_NombreCol + ", 2) " +
                            "   and cp1." + CuentaCorrientePersonasService.Id_NombreCol + " = " + ctacte_persona_id +
                            "   and cp1." + CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + persona_id +
                            "   and cp2." + CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + persona_id +
                            "   and cp1." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                            "   and cp2." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                            " minus " +
                            "select cp." + CuentaCorrientePersonasService.CuotaNumero_NombreCol + ", cp." + CuentaCorrientePersonasService.CasoId_NombreCol +
                            "  from " + CuentaCorrientePersonasService.Nombre_Tabla + " cp, " +
                            "       " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Tabla + " cppd " +
                            " where cppd." + CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + " = cp." + CuentaCorrientePersonasService.Id_NombreCol +
                            "   and cppd." + CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id + 
                            "   and cppd." + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                    DataTable dt = sesion.db.EjecutarQuery(sql);
                    
                    if (dt.Rows.Count > 0)
                        throw new Exception("No puede pagar la cuota seleccionada del caso " + dt.Rows[0][1] + " mientras la cuota " + dt.Rows[0][0] + " tenga saldo.");
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool VerificarCuotasPreviasConSaldoAlBorrar(decimal ctacte_pago_persona_id, decimal ctacte_pago_persona_documento_id, SessionService sesion)
        {
            try
            {
                if (RolesService.Tiene("PAGOS DE PERSONA NO CONTROLAR CUOTAS PREVIAS CON SALDO"))
                    return true;

                bool verificar = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PagoDePersonasControlarCuotasPreviasConSaldo).Equals(Definiciones.SiNo.Si);

                if (verificar)
                {
                    string sql =
                            "select cp2." + CuentaCorrientePersonasService.CuotaNumero_NombreCol + ", cp2." + CuentaCorrientePersonasService.CasoId_NombreCol +
                            "  from " + CuentaCorrientePersonasService.Nombre_Tabla + " cp1, " +
                            "       " + CuentaCorrientePersonasService.Nombre_Tabla + " cp2, " +
                            "       " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Tabla + " cppd1, " +
                            "       " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Tabla + " cppd2 " +
                            " where cppd2." + CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id +
                            "   and cppd2." + CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol + " <> " + ctacte_pago_persona_documento_id +
                            "   and cp1." + CuentaCorrientePersonasService.CasoId_NombreCol + " = cp2." + CuentaCorrientePersonasService.CasoId_NombreCol +
                            "   and cppd1." + CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol + " = " + ctacte_pago_persona_documento_id +
                            "   and cppd1." + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                            "   and cppd2." + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                            "   and cppd1." + CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + " = cp1." + CuentaCorrientePersonasService.Id_NombreCol +
                            "   and cppd2." + CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + " = cp2." + CuentaCorrientePersonasService.Id_NombreCol +
                            "   and cp2." + CuentaCorrientePersonasService.CuotaNumero_NombreCol + " > cp1." + CuentaCorrientePersonasService.CuotaNumero_NombreCol;

                    DataTable dt = sesion.db.EjecutarQuery(sql);

                    if (dt.Rows.Count > 0)
                        throw new Exception("No puede borrar el documento porque debe ser pagado antes que la cuota " + dt.Rows[0][0] + " del caso " + dt.Rows[0][1] + ".");
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion VerificarCuotasPreviasConSaldo

        #region VerificarCuotasMenorVencimiento
        public static bool VerificarCuotasMenorVencimientoAlGuardar(decimal ctacte_pago_persona_id, decimal persona_id, decimal ctacte_persona_id, SessionService sesion)
        {
            try
            {
                if (RolesService.Tiene("PAGOS DE PERSONA NO CONTROLAR CUOTAS MENOR VENCIMIENTO"))
                    return true;

                bool verificar = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PagoDePersonasControlarCuotasMenorVto).Equals(Definiciones.SiNo.Si);

                if (verificar)
                {
                    //Solo verificar cuotas que no son FC Contado
                    string sql =
                            "select cp2." + CuentaCorrientePersonasService.Id_NombreCol +
                            "  from " + CuentaCorrientePersonasService.Nombre_Vista + " cp1, " +
                            "       " + CuentaCorrientePersonasService.Nombre_Tabla + " cp2 " +
                            " where cp1." + CuentaCorrientePersonasService.PersonaId_NombreCol + " = cp2." + CuentaCorrientePersonasService.PersonaId_NombreCol +
                            "   and trunc(cp1." + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ") > trunc(cp2." + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ")" +
                            "   and round(cp2." + CuentaCorrientePersonasService.Credito_NombreCol + ", 2) > round(cp2." + CuentaCorrientePersonasService.Debito_NombreCol + ", 2) " +
                            "   and cp2." + CuentaCorrientePersonasService.CtactePersonaRelacionada_NombreCol + " is null " +
                            "   and cp2." + CuentaCorrientePersonasService.CtaCteConceptoId_NombreCol + " in (" + Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo + "," + Definiciones.CuentaCorrienteConceptos.Financiacion +  ") " +
                            "   and cp1." + CuentaCorrientePersonasService.Id_NombreCol + " = " + ctacte_persona_id +
                            "   and cp1." + CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + persona_id +
                            "   and cp2." + CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + persona_id +
                            "   and cp1." + CuentaCorrientePersonasService.CtaCteConceptoId_NombreCol + " <> " + Definiciones.CuentaCorrienteConceptos.EntregaInicial +
                            "   and (cp1." + CuentaCorrientePersonasService.VistaFacturaClienteTipo_NombreCol + " is null or " + CuentaCorrientePersonasService.VistaFacturaClienteTipo_NombreCol + " = '" + Definiciones.TipoFactura.Credito + "') " +
                            "   and cp1." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                            "   and cp2." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                            " minus " +
                            "select cp." + CuentaCorrientePersonasService.Id_NombreCol +
                            "  from " + CuentaCorrientePersonasService.Nombre_Tabla + " cp, " +
                            "       " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Tabla + " cppd " +
                            " where cppd." + CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + " = cp." + CuentaCorrientePersonasService.Id_NombreCol +
                            "   and cppd." + CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id +
                            "   and cppd." + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                    DataTable dt = sesion.db.EjecutarQuery(sql);

                    if (dt.Rows.Count > 0)
                        throw new Exception("No puede pagar la cuota seleccionada mientras exista una deuda con menor vencimiento.");
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool VerificarCuotasMenorVencimientoAlBorrar(decimal ctacte_pago_persona_id, decimal ctacte_pago_persona_documento_id, SessionService sesion)
        {
            try
            {
                if (RolesService.Tiene("PAGOS DE PERSONA NO CONTROLAR CUOTAS MENOR VENCIMIENTO"))
                    return true;

                bool verificar = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PagoDePersonasControlarCuotasMenorVto).Equals(Definiciones.SiNo.Si);

                if (verificar)
                {
                    string sql =
                            "select cp2." + CuentaCorrientePersonasService.CuotaNumero_NombreCol + ", cp2." + CuentaCorrientePersonasService.CasoId_NombreCol +
                            "  from " + CuentaCorrientePersonasService.Nombre_Tabla + " cp1, " +
                            "       " + CuentaCorrientePersonasService.Nombre_Tabla + " cp2, " +
                            "       " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Tabla + " cppd1, " +
                            "       " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Tabla + " cppd2 " +
                            " where cppd2." + CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id +
                            "   and cppd2." + CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol + " <> " + ctacte_pago_persona_documento_id +
                            "   and cp1." + CuentaCorrientePersonasService.PersonaId_NombreCol + " = cp2." + CuentaCorrientePersonasService.PersonaId_NombreCol +
                            "   and cppd1." + CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol + " = " + ctacte_pago_persona_documento_id +
                            "   and cppd1." + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                            "   and cppd2." + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                            "   and cppd1." + CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + " = cp1." + CuentaCorrientePersonasService.Id_NombreCol +
                            "   and cppd2." + CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + " = cp2." + CuentaCorrientePersonasService.Id_NombreCol +
                            "   and trunc(cp2." + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ") > trunc(cp1." + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ")";

                    DataTable dt = sesion.db.EjecutarQuery(sql);

                    if (dt.Rows.Count > 0)
                        throw new Exception("No puede pagar la cuota seleccionada mientras exista una deuda con menor vencimiento.");
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion VerificarCuotasMenorVencimiento

        #region EsDiaVencimientoValido
        private static bool EsDiaVencimientoValido(DateTime fecha_vencimiento) 
        {
            bool valido = true;

            if (fecha_vencimiento.DayOfWeek.Equals(DayOfWeek.Sunday))
                valido = false;
            else if (CalendariosService.EsFeriado(fecha_vencimiento))
                valido = false;

            return valido;
        }
        #endregion EsDiaVencimientoValido

        #region AjsutarDocumentos
        /// <summary>
        /// Ajsutars the documentos.
        /// </summary>
        /// <param name="dt_pago_persona">The dt_pago_persona.</param>
        /// <param name="modificaciones">The modificaciones.</param>
        /// <param name="sesion">The sesion.</param>
        public static void AjsutarDocumentos(DataTable dt_pago_persona, decimal[][] modificaciones, SessionService sesion)
        {
            try
            {
                for (int i = 0; i < modificaciones.Length; i++)
                {
                    if (modificaciones[i][0] == Definiciones.Error.Valor.EnteroPositivo)
                        continue;

                    CTACTE_PAGOS_PERSONA_DOCUMENTORow row = sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetByPrimaryKey(modificaciones[i][0]);
                    
                    if (row.ESTADO.Equals(Definiciones.Estado.Inactivo))
                        continue;

                    row.MONTO = modificaciones[i][1];
                    sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Update(row);

                    if (!row.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
                    {
                        CTACTE_PAGOS_PERSONA_RECARGORow rowRecargo = sesion.db.CTACTE_PAGOS_PERSONA_RECARGOCollection.GetByPrimaryKey(row.CTACTE_PAGO_PERSONA_RECARGO_ID);
                        rowRecargo.MONTO = modificaciones[i][1];
                        sesion.db.CTACTE_PAGOS_PERSONA_RECARGOCollection.Update(rowRecargo);
                    }
                }

                //Actualizar el monto del vuelto
                PagosDePersonaService.ActualizarVuelto((decimal)dt_pago_persona.Rows[0][PagosDePersonaService.Id_NombreCol], sesion);

                //Actualizar el total del recibo si se calcula por documentos
                if (dt_pago_persona.Rows[0][PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol].Equals(Definiciones.SiNo.Si))
                    CuentaCorrienteRecibosService.ActualizarTotal(dt_pago_persona, sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion AjsutarDocumentos

        #region DesvincularCtactePersonaParaBorrarRecargo
        public static void DesvincularCtactePersonaParaBorrarRecargo(decimal ctacte_pago_persona_documento_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONA_DOCUMENTORow row = sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetByPrimaryKey(ctacte_pago_persona_documento_id);
            row.IsCTACTE_PERSONA_IDNull = true;
            sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.Update(row);
        }
        #endregion DesvincularCtactePersonaParaBorrarRecargo

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PAGOS_PERSONA_DOCUMENTO"; }
        }
        public static string Nombre_Vista 
        {
            get { return "CTACTE_PAGOS_PERS_DOC_INF_COMP"; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtactePagosPersonaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.CTACTE_PAGOS_PERSONA_IDColumnName; }
        }
        public static string CtactePagoPersonaRecargoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.CTACTE_PAGO_PERSONA_RECARGO_IDColumnName; }
        }
        public static string CtactePersonaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.CTACTE_PERSONA_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.MONTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.OBSERVACIONColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.CASO_IDColumnName; }
        }
        public static string VistaCuota_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.CUOTAColumnName; }
        }
        public static string VistaCuotaNumero_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.CUOTA_NUMEROColumnName; }
        }
        public static string VistaCredito_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.CREDITOColumnName; }
        }
        public static string VistaDebito_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.DEBITOColumnName; }
        }
        public static string VistaFacturaClienteTipo_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.FACTURA_CLIENTE_TIPOColumnName; }
        }
        public static string VistaFechaVencimiento_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string VistaFechaVencimientoTexto_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.FECHA_VENCIMIENTO_TEXTOColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.FLUJO_IDColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPagoConfirmado_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.PAGO_CONFIRMADOColumnName; }
        }
        public static string VistaDiaDeGracia_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.DIA_DE_GRACIAColumnName; }
        }
        public static string VistaCtacteValorId_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DOC_INF_COMPCollection.CTACTE_VALOR_IDColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrientePagosPersonaDocumentoService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrientePagosPersonaDocumentoService(e.RegistroId, sesion);
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
        protected CTACTE_PAGOS_PERSONA_DOCUMENTORow row;
        protected CTACTE_PAGOS_PERSONA_DOCUMENTORow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? CotizacionMoneda { get { if (row.IsCOTIZACION_MONEDANull) return null; else return row.COTIZACION_MONEDA; } set { if (value.HasValue) row.COTIZACION_MONEDA = value.Value; else row.IsCOTIZACION_MONEDANull = true; } }
        public decimal? CtactePagoPersonaRecargoId { get { if (row.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull) return null; else return row.CTACTE_PAGO_PERSONA_RECARGO_ID; } set { if (value.HasValue) row.CTACTE_PAGO_PERSONA_RECARGO_ID = value.Value; else row.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull = true; } }
        public decimal CtactePagosPersonaId { get { return row.CTACTE_PAGOS_PERSONA_ID; } set { row.CTACTE_PAGOS_PERSONA_ID = value; } }
        public decimal? CtactePersonaId { get { if (row.IsCTACTE_PERSONA_IDNull) return null; else return row.CTACTE_PERSONA_ID; } set { if (value.HasValue) row.CTACTE_PERSONA_ID = value.Value; else row.IsCTACTE_PERSONA_IDNull = true; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal? Monto { get { if (row.IsMONTONull) return null; else return row.MONTO; } set { if (value.HasValue) row.MONTO = value.Value; else row.IsMONTONull = true; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CuentaCorrientePersonasService _ctacte_persona;
        public CuentaCorrientePersonasService CtactePersona
        {
            get
            {
                if (this._ctacte_persona == null)
                    this._ctacte_persona = new CuentaCorrientePersonasService(this.CtactePersonaId.Value);
                return this._ctacte_persona;
            }
        }
        
        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId);
                return this._moneda;
            }
        }

        private PagosDePersonaService _ctacte_pagos_persona;
        public PagosDePersonaService CtactePagosPersona
        {
            get
            {
                if (this._ctacte_pagos_persona == null)
                    this._ctacte_pagos_persona = new PagosDePersonaService(this.CtactePagosPersonaId);
                return this._ctacte_pagos_persona;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_PAGOS_PERSONA_DOCUMENTORow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_PAGOS_PERSONA_DOCUMENTORow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CuentaCorrientePagosPersonaDocumentoService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrientePagosPersonaDocumentoService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrientePagosPersonaDocumentoService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CuentaCorrientePagosPersonaDocumentoService(EdiCBA.CobranzaDocumento edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = CuentaCorrientePagosPersonaDocumentoService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.venta;

            this.Estado = Definiciones.Estado.Activo;

            #region pago de persona
            if (!string.IsNullOrEmpty(edi.cobranza_uuid))
                this._ctacte_pagos_persona = PagosDePersonaService.GetPorUUID(edi.cobranza_uuid, sesion);
            if (this._ctacte_pagos_persona == null && edi.cobranza != null)
                this._ctacte_pagos_persona = new PagosDePersonaService(edi.cobranza, almacenar_localmente, sesion);
            if (this._ctacte_pagos_persona != null)
            {
                if (!this.CtactePagosPersona.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.CtactePagosPersona.Id.HasValue)
                    this.CtactePagosPersonaId = this.CtactePagosPersona.Id.Value;
            }
            #endregion pago de persona

            #region ctacte persona
            if (!string.IsNullOrEmpty(edi.ctacte_persona_uuid))
                this._ctacte_persona = CuentaCorrientePersonasService.GetPorUUID(edi.ctacte_persona_uuid, sesion);
            if (this._ctacte_persona == null && edi.ctacte_persona != null)
                this._ctacte_persona = new CuentaCorrientePersonasService(edi.ctacte_persona, almacenar_localmente, sesion);
            if (this._ctacte_persona == null)
                throw new Exception("No se encontró el UUID " + edi.ctacte_persona_uuid + " ni se definieron los datos del objeto.");

            if (!this.CtactePersona.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.CtactePersona.Id.HasValue)
                this.CtactePersonaId = this.CtactePersona.Id.Value;
            #endregion ctacte persona

            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                this.Moneda.IniciarUsingSesion(sesion);
                this.Moneda.Guardar();
                this.Moneda.FinalizarUsingSesion();
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda

            this.Monto = edi.monto;
            this.Observacion = edi.observacion;
        }
        private CuentaCorrientePagosPersonaDocumentoService(CTACTE_PAGOS_PERSONA_DOCUMENTORow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static CuentaCorrientePagosPersonaDocumentoService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static CuentaCorrientePagosPersonaDocumentoService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.CTACTE_PAGOS_PERSONA_DOCUMENTOCollection.GetAsArray(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = "  + cabecera_id + " and " + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol);
            CuentaCorrientePagosPersonaDocumentoService[] cppd = new CuentaCorrientePagosPersonaDocumentoService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cppd[i] = new CuentaCorrientePagosPersonaDocumentoService(rows[i]);
            return cppd;
        }
        #endregion GetPorCabecera

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.CobranzaDocumento()
            {
                cobranza_uuid = this.CtactePagosPersona.GetOrCreateUUID(sesion),
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol, this.Id.Value, sesion),
                ctacte_persona_uuid = this.CtactePersonaId.HasValue ? this.CtactePersona.GetOrCreateUUID(sesion) : null,
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                monto = this.Monto.Value,
                observacion = this.Observacion,
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.CtactePagosPersona.Fecha,
                    moneda_uuid = this.Moneda.ToEDI().uuid,
                    compra = this.CotizacionMoneda.Value
                };
                e.ctacte_persona = this.CtactePersonaId.HasValue ? (EdiCBA.CtactePersona)this.CtactePersona.ToEDI(nueva_profundidad, sesion) : null;
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
