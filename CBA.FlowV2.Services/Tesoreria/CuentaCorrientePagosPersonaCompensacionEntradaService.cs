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
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Casos;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePagosPersonaCompensacionEntradaService
    {
        #region GetCuentaCorrientePagosPersonaCompensacionEntradaInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente pagos persona compensacion entrada information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaCompensacionEntradaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CuentaCorrientePagosPersonaCompensacionEntradaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;
                return sesion.db.CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCuentaCorrientePagosPersonaCompensacionEntradaInfoCompleta

        #region GetCuentaCorrientePagosPersonaCompensacionEntradaDataTable
        /// <summary>
        /// Gets the cuenta corriente pagos persona compensacion entrada data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaCompensacionEntradaDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCuentaCorrientePagosPersonaCompensacionEntradaDataTable(clausulas, orden, sesion);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Gets the cuenta corriente pagos persona compensacion entrada data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaCompensacionEntradaDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = CuentaCorrientePagosPersonaCompensacionEntradaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.GetAsDataTable(where, orden);
        }
        #endregion GetCuentaCorrientePagosPersonaCompensacionEntradaDataTable

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

        #region GetTotal
        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <returns></returns>
        public static decimal GetTotal(decimal ctacte_pago_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagosPersonaId_NombreCol + " = " + ctacte_pago_persona_id + " and " +
                                   CuentaCorrientePagosPersonaCompensacionEntradaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                DataTable dtDetallesCompensacion = GetCuentaCorrientePagosPersonaCompensacionEntradaDataTable(clausulas, string.Empty);
                DataTable dtPago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pago_persona_id, string.Empty);
                decimal total = 0;
                decimal monedaPagoId = (decimal)dtPago.Rows[0][PagosDePersonaService.MonedaId_NombreCol];
                decimal cotizacionPago = (decimal)dtPago.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];

                for (int i = 0; i < dtDetallesCompensacion.Rows.Count; i++)
                {
                    if (monedaPagoId == (decimal)dtDetallesCompensacion.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.MonedaId_NombreCol])
                    {
                        total += (decimal)dtDetallesCompensacion.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.Monto_NombreCol];
                    }
                    else
                    {
                        total += (decimal)dtDetallesCompensacion.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.Monto_NombreCol]
                                 / (decimal)dtDetallesCompensacion.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.CotizacionMoneda_NombreCol]
                                 * cotizacionPago;
                    }
                }

                return total;
            }
        }
        #endregion GetTotal

        #region SetCtactePagoPersonaDocumento
        /// <summary>
        /// Sets the ctacte pago persona documento.
        /// </summary>
        /// <param name="ctacte_pago_persona_compensacion_entrante_id">The ctacte_pago_persona_compensacion_entrante_id.</param>
        /// <param name="ctacte_pago_persona_documento_id">The ctacte_pago_persona_documento_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetCtactePagoPersonaDocumento(decimal ctacte_pago_persona_compensacion_entrante_id, decimal ctacte_pago_persona_documento_id, SessionService sesion)
        {
            CTACTE_PAGOS_PER_COMPEN_ENTRADRow row = sesion.db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.GetByPrimaryKey(ctacte_pago_persona_compensacion_entrante_id);
            row.CTACTE_PAGOS_PERSONA_DOC_ID = ctacte_pago_persona_documento_id;
            sesion.db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.Update(row);
        }
        #endregion SetCtactePagoPersonaDocumento

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            CTACTE_PAGOS_PER_COMPEN_ENTRADRow row;
            DataTable cabecera;

            using (SessionService sesion = new SessionService())
            {
                row = new CTACTE_PAGOS_PER_COMPEN_ENTRADRow();
                string valorAnterior = Definiciones.Log.RegistroNuevo;
                CuentaCorrientePersonasService ctactePersona = null;
                DataTable dtCtactePagoPersona;
                decimal saldo;

                try
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_pagos_per_comp_ent_sqc");
                    row.ESTADO = Definiciones.Estado.Activo;
                    row.FECHA_CREACION = DateTime.Now;
                    row.CTACTE_PAGOS_PERSONA_ID = (decimal)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagosPersonaId_NombreCol];

                    cabecera = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + row.CTACTE_PAGOS_PERSONA_ID, string.Empty);

                    if (campos.Contains(CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePersonaId_NombreCol))
                    {
                        ctactePersona = new CuentaCorrientePersonasService((decimal)campos[CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol], sesion);
                        if (!ctactePersona.ExisteEnDB)
                            throw new System.Exception("El documento no fue encontrado.");

                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si && ctactePersona.CasoId.HasValue)
                        {
                            var sucursal = new SucursalesService((decimal)cabecera.Rows[0][PagosDePersonaService.SucursalId_NombreCol], sesion);
                            if (ctactePersona.Caso.Sucursal.RegionId != sucursal.RegionId)
                                throw new Exception("El documento proviene de una región distinta al caso.");
                        }

                        row.CTACTE_PERSONA_ID = (decimal)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePersonaId_NombreCol];

                        if (ctactePersona.Bloqueado == Definiciones.SiNo.Si)
                            throw new Exception("El documento se encuentra bloqueado.");

                        saldo = ctactePersona.Credito - ctactePersona.Debito;

                        if (saldo < (decimal)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.Monto_NombreCol])
                            throw new System.Exception("La deuda del documento es " + saldo + ".");

                        row.MONTO = (decimal)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.Monto_NombreCol];

                        //Verificar que si es una factura contado no se realiza un pago parcial sino total, o por el saldo completo
                        if (ctactePersona.CasoId.HasValue && ctactePersona.Caso.FlujoId == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                        {
                            if (FacturasClienteService.GetTipoFactura(ctactePersona.CasoId.Value, sesion) == Definiciones.TipoFactura.Contado)
                            {
                                if (Math.Round(row.MONTO, ctactePersona.Moneda.CantidadDecimales) != Math.Round(saldo, ctactePersona.Moneda.CantidadDecimales))
                                    throw new System.Exception("Las facturas contado deben ser pagadas en su totalidad. La deuda del documento es " + saldo.ToString(ctactePersona.Moneda.CadenaDecimales) + ".");
                            }
                        }

                        if (ctactePersona.Moneda.Estado == Definiciones.Estado.Inactivo)
                            throw new System.Exception("La moneda se encuentra inactiva.");
                        row.MONEDA_ID = ctactePersona.MonedaId;

                        if (campos.Contains(CuentaCorrientePagosPersonaCompensacionEntradaService.CotizacionMoneda_NombreCol))
                            row.COTIZACION_MONEDA = (decimal)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.CotizacionMoneda_NombreCol];
                        else
                        {
                            row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(sesion.SucursalActiva.PAIS_ID, row.MONEDA_ID, (DateTime)cabecera.Rows[0][PagosDePersonaService.Fecha_NombreCol], sesion);
                        }

                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");

                        CuentaCorrientePersonasService.SetBloqueado(row.CTACTE_PERSONA_ID, true, sesion);
                    }
                    else
                    {
                        row.IsCTACTE_PERSONA_IDNull = true;

                        row.CTACTE_PAGO_PERSONA_RECARGO_ID = (decimal)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagoPersonaRecargoId_NombreCol];
                        row.MONTO = (decimal)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.Monto_NombreCol];
                        row.MONEDA_ID = (decimal)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.MonedaId_NombreCol];
                        row.COTIZACION_MONEDA = (decimal)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.CotizacionMoneda_NombreCol];
                    }

                    if (!Interprete.EsNullODBNull(campos[CuentaCorrientePagosPersonaCompensacionEntradaService.Observacion_NombreCol]))
                        row.OBSERVACION = (string)campos[CuentaCorrientePagosPersonaCompensacionEntradaService.Observacion_NombreCol];
                    else
                        row.OBSERVACION = string.Empty;

                    sesion.Db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.Insert(row);
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

                dtCtactePagoPersona = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + campos[CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagosPersonaId_NombreCol], string.Empty);

                //Agregar recargos si corresponde a los documentos que provienen de ctacte personas
                if (campos.Contains(CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePersonaId_NombreCol))
                {
                    #region agregar recargo
                    decimal diasDeGraciaMora = Definiciones.Error.Valor.IntPositivo;
                    decimal diasDeGraciaInteresPunitorio = Definiciones.Error.Valor.IntPositivo;

                    DateTime fechaPago = (DateTime)dtCtactePagoPersona.Rows[0][PagosDePersonaService.Fecha_NombreCol];
                    TimeSpan span = fechaPago - ctactePersona.FechaVencimiento;

                    decimal porcentajeMora = Definiciones.Error.Valor.EnteroPositivo;
                    decimal montoMoraDiario = Definiciones.Error.Valor.EnteroPositivo;
                    decimal porcentajeInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasPorcentajeInteresPunitorioSobreMora);
                    decimal? montoMoraManual = null;
                    decimal montoGastoCobranza = 0, montoMora = 0, montoInteresPunitorio;
                    System.Collections.Hashtable camposRecargo;

                    int flujoId = ctactePersona.CasoId.HasValue ? (int)ctactePersona.Caso.FlujoId : Definiciones.Error.Valor.IntPositivo;

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

                                        if (ctactePersona.CasoId.HasValue)
                                        {
                                            var creditoPagare = CreditosService.GetPorCaso(ctactePersona.CasoId.Value, sesion);
                                            creditoPagare.IniciarUsingSesion(sesion);
                                            if (creditoPagare.PorcentajeDiarioMora.HasValue)
                                                porcentajeMora = creditoPagare.PorcentajeDiarioMora.Value;
                                            else
                                                montoMoraDiario = creditoPagare.MontoDiarioMora.Value;
                                            creditoPagare.FinalizarUsingSesion();
                                        }
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
                                    default: throw new Exception("Error en CuentaCorrientePagosPersonaCompensacionEntradaService.Guardar(). Flujo no manejado");
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
                                DateTime vencimientoDiasGracia = ctactePersona.FechaVencimiento.AddDays((double)diasDeGraciaMora);
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
                                    camposRecargo.Add(CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaCompEnId_NombreCol, row.ID);
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
                                default:
                            throw new Exception("Error en CuentaCorrientePagosPersonaCompensacionEntradaService.Guardar(), el cliente no tiene implementación para política de recargo por webservice.");
                            break;
                             }
                                 

                        default:
                            throw new Exception("Error en CuentaCorrientePagosPersonaCompensacionEntradaService.Guardar(), política de recargo no implementada.");
                    }

                   

                }
                #endregion agregar recargo
            }
        

        PagosDePersonaService.ActualizarCompensacionAnticipoPorVuelto(row.CTACTE_PAGOS_PERSONA_ID);
        }

        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_pago_persona_compensacion_entrada_id.
        /// </summary>
        /// <param name="ctacte_pago_persona_compensacion_entrada_id">The ctacte_pago_persona_compensacion_entrada_id.</param>
        public static void Borrar(decimal ctacte_pago_persona_compensacion_entrada_id)
        {
            try
            {
                CTACTE_PAGOS_PER_COMPEN_ENTRADRow row;

                using (SessionService sesion = new SessionService())
                {
                    row = sesion.Db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.GetByPrimaryKey(ctacte_pago_persona_compensacion_entrada_id);
                    DataTable dtPago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + row.CTACTE_PAGOS_PERSONA_ID, string.Empty);

                    //Si el documento proviene de ctacte_personas deben borrarse los recargos existentes sobre el mimsmo
                    //Si el documento es un recargo debe borrarse de la tabla recargos
                    if (row.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
                    {
                        DataTable dt = CuentaCorrientePagosPersonaRecargosService.GetCuentaCorrientePagosPersonaRecargosDataTable(CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaCompEnId_NombreCol + " = " + ctacte_pago_persona_compensacion_entrada_id, string.Empty);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            sesion.Db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.DeleteByCTACTE_PAGO_PERSONA_RECARGO_ID((decimal)dt.Rows[i][CuentaCorrientePagosPersonaRecargosService.Id_NombreCol]);
                            CuentaCorrientePagosPersonaRecargosService.Borrar((decimal)dt.Rows[i][CuentaCorrientePagosPersonaRecargosService.Id_NombreCol], sesion);
                        }

                        sesion.Db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.Delete(row);
                        CuentaCorrientePersonasService.SetBloqueado(row.CTACTE_PERSONA_ID, false, sesion);
                    }
                    else
                    {
                        sesion.Db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.Delete(row);
                        CuentaCorrientePagosPersonaRecargosService.Borrar(row.CTACTE_PAGO_PERSONA_RECARGO_ID, sesion);
                    }

                    PagosDePersonaService.ActualizarCompensacionAnticipoPorVuelto(row.CTACTE_PAGOS_PERSONA_ID);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Borrar

        #region Inactivar
        /// <summary>
        /// Inactivars the specified ctacte_pago_persona_compensacion_salida_id.
        /// </summary>
        /// <param name="ctacte_pago_persona_compensacion_entrada_id">The ctacte_pago_persona_compensacion_entrada_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Inactivar(decimal ctacte_pago_persona_compensacion_entrada_id, SessionService sesion)
        {
            CTACTE_PAGOS_PER_COMPEN_ENTRADRow row = sesion.Db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.GetByPrimaryKey(ctacte_pago_persona_compensacion_entrada_id);
            row.ESTADO = Definiciones.Estado.Inactivo;
            sesion.Db.CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.Update(row);
        }
        #endregion Inactivar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PAGOS_PER_COMPEN_ENTRAD"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTACTE_PAGOS_PER_COMP_ENT_IN_C"; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtactePagosPersonaId_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.CTACTE_PAGOS_PERSONA_IDColumnName; }
        }
        public static string CtactePagoPersonaRecargoId_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.CTACTE_PAGO_PERSONA_RECARGO_IDColumnName; }
        }
        public static string CtactePagoPersonaDocId_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.CTACTE_PAGOS_PERSONA_DOC_IDColumnName; }
        }
        public static string CtactePersonaId_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.CTACTE_PERSONA_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.ESTADOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.FECHA_CREACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.MONTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMPEN_ENTRADCollection.OBSERVACIONColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.CASO_IDColumnName; }
        }
        public static string VistaCredito_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.CREDITOColumnName; }
        }
        public static string VistaCuota_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.CUOTAColumnName; }
        }
        public static string VistaDebito_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.DEBITOColumnName; }
        }
        public static string VistaFacturaClienteTipo_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.FACTURA_CLIENTE_TIPOColumnName; }
        }
        public static string VistaFechaVencimientoTexto_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.FECHA_VENCIMIENTO_TEXTOColumnName; }
        }
        public static string VistaFechaVencimiento_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.FECHA_VENCIMIENTOColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPagoConfirmado_NombreCol
        {
            get { return CTACTE_PAGOS_PER_COMP_ENT_IN_CCollection_Base.PAGO_CONFIRMADOColumnName; }
        }
        #endregion Accessors
    }
}

