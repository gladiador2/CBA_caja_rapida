#region Using
using System;
using System.Data;
using System.Linq;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.Giros;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Tesoreria;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePagosPersonaDetalleService
    {
        #region GetCuentaCorrientePagosPersonaDetalleDataTable
        /// <summary>
        /// Gets the cuenta corriente pagos persona detalle data table.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDetalleDataTable(decimal ctacte_pago_persona_id)
        {
            return GetCuentaCorrientePagosPersonaDetalleDataTable(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + ctacte_pago_persona_id, CuentaCorrientePagosPersonaDetalleService.Id_NombreCol);
        }

        /// <summary>
        /// Gets the cuenta corriente pagos persona detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrientePagosPersonaDetalleDataTable(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the cuenta corriente pagos persona detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.GetAsDataTable(where, orden);
        }
        #endregion GetCuentaCorrientePagosPersonaDetalleDataTable

        #region GetCuentaCorrientePagosPersonaDetalleInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente pagos persona detalle info completa.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDetalleInfoCompleta(decimal ctacte_pago_persona_id)
        {
            return GetCuentaCorrientePagosPersonaDetalleInfoCompleta(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + ctacte_pago_persona_id, CuentaCorrientePagosPersonaDetalleService.Id_NombreCol);
        }

        /// <summary>
        /// Gets the cuenta corriente pagos persona detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePagosPersonaDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrientePagosPersonaDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrientePagosPersonaDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CTACTE_PAGOS_PERS_DET_INF_COMPCollection.GetAsDataTable(where, orden);
        }
        #endregion GetCuentaCorrientePagosPersonaDetalleInfoCompleta

        #region GetMontoTotal
        /// <summary>
        /// Gets the monto total.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <returns></returns>
        public static decimal GetMontoTotal(decimal ctacte_pago_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMontoTotal(ctacte_pago_persona_id, sesion);
            }
        }

        public static decimal GetMontoTotal(decimal ctacte_pago_persona_id, SessionService sesion)
        {
            decimal total = 0;
            string clausulas = CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and + " +
                               CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + ctacte_pago_persona_id;

            CTACTE_PAGOS_PERSONA_DETRow[] rows = sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.GetAsArray(clausulas, CuentaCorrientePagosPersonaDetalleService.Id_NombreCol);
            DataTable dtCtactePago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pago_persona_id, string.Empty, sesion);

            for (int i = 0; i < rows.Length; i++)
            {
                //Debe convertirse si la moneda del valor es distinta a la moneda principal del pago
                if (rows[i].MONEDA_ID.Equals((decimal)dtCtactePago.Rows[0][PagosDePersonaService.MonedaId_NombreCol]))
                    total += rows[i].MONTO;
                else
                    total += rows[i].MONTO / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePago.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
            }

            return total;
        }
        #endregion GetMontoTotal

        #region GetRetencion
        /// <summary>
        /// Gets the retencion.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="nro_comprobante">The nro_comprobante.</param>
        /// <returns></returns>
        public static decimal GetRetencion(decimal ctacte_pago_persona_id, string nro_comprobante, SessionService sesion)
        {
            string clausulas = CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + ctacte_pago_persona_id + " and " +
                               CuentaCorrientePagosPersonaDetalleService.RetencionNroComprobante_NombreCol + " = '" + nro_comprobante + "' " + " and " +
                               CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " + " and " +
                               CuentaCorrientePagosPersonaDetalleService.RetencionId_NombreCol + " is not null ";

            CTACTE_PAGOS_PERSONA_DETRow[] rows = sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.GetAsArray(clausulas, string.Empty);

            if (rows.Length > 0) return rows[0].RETENCION_ID;
            else return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetRetencion

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                Guardar(campos, sesion);
            }
        }
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                CTACTE_PAGOS_PERSONA_DETRow row = new CTACTE_PAGOS_PERSONA_DETRow();
                DataTable cabecera;
                SucursalesService sucursal = new SucursalesService();
                DataTable dtCtactePago;
                string valorAnterior = Definiciones.Log.RegistroNuevo;

                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_pagos_persona_det_sqc");
                row.CTACTE_PAGO_PERSONA_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol];
                cabecera = cabecera = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + row.CTACTE_PAGO_PERSONA_ID, string.Empty, sesion);
                dtCtactePago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + row.CTACTE_PAGO_PERSONA_ID, string.Empty, sesion);

                string estado = CasosService.GetEstadoCaso((decimal)cabecera.Rows[0][PagosDePersonaService.CasoId_NombreCol]);

                if (estado == Definiciones.EstadosFlujos.Anulado || estado == Definiciones.EstadosFlujos.Aprobado)
                    throw new System.Exception("El caso ya fue " + estado + " no se pueden agregar mas pagos, favor refrescar el caso.");

                //Segun el tipo de valor, debera crearse un cheque, un anticipo, etc.
                switch ((int)campos[CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol])
                {
                    case Definiciones.CuentaCorrienteValores.Anticipo:
                        //Debe aplicarse como pago parte del saldo del anticipo
                        row.ANTICIPO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.AnticipoId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        row.CHEQUE_ES_DIFERIDO = (string)campos[CuentaCorrientePagosPersonaDetalleService.ChequeEsDiferido_NombreCol];
                        row.CHEQUE_FECHA_POSDATADO = (DateTime)campos[CuentaCorrientePagosPersonaDetalleService.ChequeFechaPosdatada_NombreCol];
                        row.CHEQUE_FECHA_VENCIMIENTO = (DateTime)campos[CuentaCorrientePagosPersonaDetalleService.ChequeFechaVencimiento_NombreCol];
                        row.CHEQUE_NOMBRE_BENEFICIARIO = (string)campos[CuentaCorrientePagosPersonaDetalleService.ChequeNombreBeneficiario_NombreCol];
                        row.CHEQUE_NOMBRE_EMISOR = (string)campos[CuentaCorrientePagosPersonaDetalleService.ChequeNombreEmisor_NombreCol];
                        row.CHEQUE_NRO_CHEQUE = (string)campos[CuentaCorrientePagosPersonaDetalleService.ChequeNroCheque_NombreCol];
                        row.CHEQUE_NRO_CUENTA = (string)campos[CuentaCorrientePagosPersonaDetalleService.ChequeNroCuenta_NombreCol];
                        row.CHEQUE_DE_TERCEROS = (string)campos[CuentaCorrientePagosPersonaDetalleService.ChequeDeTerceros_NombreCol];
                        row.CHEQUE_DOCUMENTO_EMISOR = (string)campos[CuentaCorrientePagosPersonaDetalleService.ChequeDocumentoEmisor_NombreCol];

                        if (!CuentaCorrienteBancosService.EstaActivo((decimal)campos[CuentaCorrientePagosPersonaDetalleService.ChequeCtacteBancoId_NombreCol]))
                            throw new Exception("El banco no está activo.");
                        else
                            row.CHEQUE_CTACTE_BANCO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.ChequeCtacteBancoId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.DepositoBancario:
                        //Se verifica que este activa
                        if (!CuentaCorrienteCuentasBancariasService.EstaActivo((decimal)campos[CuentaCorrientePagosPersonaDetalleService.DepositoCtaCteBancariasId_NombreCol]))
                            throw new System.Exception("La cuenta bancaria está inactiva.");
                        else
                            row.DEPOSITO_CTACTE_BANCARIAS_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.DepositoCtaCteBancariasId_NombreCol];

                        row.DEPOSITO_NRO_BOLETA = (string)campos[CuentaCorrientePagosPersonaDetalleService.DepositoNroBoleta_NombreCol];
                        row.DEPOSITO_FECHA = (DateTime)campos[CuentaCorrientePagosPersonaDetalleService.DepositoFecha_NombreCol];

                        //Por el momento no se utiliza el campo ya que no es necesario 
                        //crear un caso de deposito
                        //row.DEPOSITO_BANCARIO_ID
                        break;

                    case Definiciones.CuentaCorrienteValores.Efectivo:
                        break;
                    case Definiciones.CuentaCorrienteValores.NotaDeCredito:
                        row.NOTA_CREDITO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.NotaCreditoId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.Pagare:
                        throw new Exception("No puede pagarse utilizando un pagaré.");
                    case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:

                        row.CTACTE_PROCESADORA_TARJETA_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.CtacteProcesadoraTarjetaId_NombreCol];
                        row.TARJETA_NRO = (string)campos[CuentaCorrientePagosPersonaDetalleService.TarjetaNro_NombreCol];
                        row.TARJETA_TITULAR = (string)campos[CuentaCorrientePagosPersonaDetalleService.TarjetaTitular_NombreCol];
                        row.TARJETA_VENCIMIENTO = (DateTime)campos[CuentaCorrientePagosPersonaDetalleService.TarjetaVencimiento_NombreCol];
                        row.CTACTE_PLAN_DESEMBOLSO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.CtaCtePlanDesembolsoId_NombreCol];
                        break;

                    case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                        row.TRANSFERENCIA_BANCARIA_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.TransferenciaBancariaId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.RetencionIVA:
                        row.RETENCION_CASO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.RetencionCasoId_NombreCol];
                        row.RETENCION_NRO_COMPROBANTE = campos[CuentaCorrientePagosPersonaDetalleService.RetencionNroComprobante_NombreCol].ToString();
                        row.RETENCION_OBSERVACION = (string)campos[CuentaCorrientePagosPersonaDetalleService.RetencionObservacion_NombreCol];
                        row.RETENCION_FECHA = (DateTime)campos[CuentaCorrientePagosPersonaDetalleService.RetencionFecha_NombreCol];
                        row.RETENCION_TIPO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.RetencionTipoId_NombreCol];
                        row.RETENCION_PORCENTAJE = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.RetencionPorcentaje_NombreCol];
                        if (campos.Contains(CuentaCorrientePagosPersonaDetalleService.RetencionTimbrado_NombreCol))
                            row.RETENCION_TIMBRADO = (string)campos[CuentaCorrientePagosPersonaDetalleService.RetencionTimbrado_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.RetencionRenta:
                        row.RETENCION_CASO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.RetencionCasoId_NombreCol];
                        row.RETENCION_NRO_COMPROBANTE = campos[CuentaCorrientePagosPersonaDetalleService.RetencionNroComprobante_NombreCol].ToString();
                        row.RETENCION_OBSERVACION = (string)campos[CuentaCorrientePagosPersonaDetalleService.RetencionObservacion_NombreCol];
                        row.RETENCION_FECHA = (DateTime)campos[CuentaCorrientePagosPersonaDetalleService.RetencionFecha_NombreCol];
                        row.RETENCION_TIPO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.RetencionTipoId_NombreCol];
                        row.RETENCION_PORCENTAJE = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.RetencionPorcentaje_NombreCol];
                        if (campos.Contains(CuentaCorrientePagosPersonaDetalleService.RetencionTimbrado_NombreCol))
                            row.RETENCION_TIMBRADO = (string)campos[CuentaCorrientePagosPersonaDetalleService.RetencionTimbrado_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.RetencionSECP:
                        row.RETENCION_CASO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.RetencionCasoId_NombreCol];
                        row.RETENCION_NRO_COMPROBANTE = campos[CuentaCorrientePagosPersonaDetalleService.RetencionNroComprobante_NombreCol].ToString();
                        row.RETENCION_OBSERVACION = (string)campos[CuentaCorrientePagosPersonaDetalleService.RetencionObservacion_NombreCol];
                        row.RETENCION_FECHA = (DateTime)campos[CuentaCorrientePagosPersonaDetalleService.RetencionFecha_NombreCol];
                        row.RETENCION_TIPO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.RetencionTipoId_NombreCol];
                        row.RETENCION_PORCENTAJE = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.RetencionPorcentaje_NombreCol];
                        if (campos.Contains(CuentaCorrientePagosPersonaDetalleService.RetencionTimbrado_NombreCol))
                            row.RETENCION_TIMBRADO = (string)campos[CuentaCorrientePagosPersonaDetalleService.RetencionTimbrado_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.TransferenciaCtacte:
                        //Debe aplicarse como pago parte del saldo de la transferencia de ctacte
                        row.TRANSFERENCIA_CTACTE_PERS_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.TransferenciaCtactePersId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.Giro:

                        row.CTACTE_RED_PAGO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.CtaCteRedPagoId_NombreCol];
                        row.CTACTE_PLAN_DESEMBOLSO_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.CtaCtePlanDesembolsoId_NombreCol];
                        row.GIRO_COMPROBANTE = (string)campos[CuentaCorrientePagosPersonaDetalleService.GiroComprobante_NombreCol];
                        row.OBSERVACIONES = (string)campos[CuentaCorrientePagosPersonaDetalleService.Observaciones_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.POS:

                        row.POS_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.PosId_NombreCol];
                        row.CTACTE_PROCESADORA_TARJETA_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.CtacteProcesadoraTarjetaId_NombreCol];
                        row.MONTO_NETO = calculcarMontoNeto_POS(row.POS_ID, row.CTACTE_PROCESADORA_TARJETA_ID, (decimal)campos[CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol]);
                        row.FECHA_ACREDITACION = calcularFechaAcreditacion(row.POS_ID, row.CTACTE_PROCESADORA_TARJETA_ID);
                        row.TARJETA_NRO = (string)campos[CuentaCorrientePagosPersonaDetalleService.TarjetaNro_NombreCol];
                        row.OBSERVACIONES = (string)campos[CuentaCorrientePagosPersonaDetalleService.TarjetaNro_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.Ajuste:
                        break;
                    default: throw new Exception("Error. El tipo de valor indefinido.");
                }

                row.ESTADO = Definiciones.Estado.Activo;
                row.CTACTE_VALOR_ID = (int)campos[CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol];

                if (!MonedasService.EstaActivo((decimal)campos[CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol]))
                    throw new System.Exception("La moneda se encuentra inactiva.");
                else
                    row.MONEDA_ID = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol];

                if (campos.Contains(CuentaCorrientePagosPersonaDetalleService.CotizacionMoneda_NombreCol))
                    row.COTIZACION_MONEDA = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.CotizacionMoneda_NombreCol];
                else
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtCtactePago.Rows[0][PagosDePersonaService.SucursalId_NombreCol]), row.MONEDA_ID, (DateTime)cabecera.Rows[0][PagosDePersonaService.Fecha_NombreCol], sesion);

                if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizarse la cotización de la moneda.");

                row.MONTO = (decimal)campos[CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol];

                sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                //Actualizar el monto del vuelto
                PagosDePersonaService.ActualizarVuelto(row.CTACTE_PAGO_PERSONA_ID, sesion);

                //Actualizar el total del recibo si se calcula por valores
                if (dtCtactePago.Rows[0][PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol].Equals(Definiciones.SiNo.No))
                    CuentaCorrienteRecibosService.ActualizarTotal(dtCtactePago, sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_pago_persona_detalle_id.
        /// </summary>
        /// <param name="ctacte_pago_persona_detalle_id">The ctacte_pago_persona_detalle_id.</param>
        public static void Borrar(decimal ctacte_pago_persona_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CTACTE_PAGOS_PERSONA_DETRow row = sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.GetByPrimaryKey(ctacte_pago_persona_detalle_id);
                    DataTable dtPago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + row.CTACTE_PAGO_PERSONA_ID, string.Empty);

                    string estado = CasosService.GetEstadoCaso((decimal)dtPago.Rows[0][PagosDePersonaService.CasoId_NombreCol]);

                    if (estado == Definiciones.EstadosFlujos.Anulado || estado == Definiciones.EstadosFlujos.Aprobado)
                        throw new System.Exception("El caso ya fue " + estado + " no se pueden borrar mas pagos, favor refrescar el caso.");

                    row.ESTADO = Definiciones.Estado.Inactivo;
                    sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    //Actualizar el monto del vuelto
                    PagosDePersonaService.ActualizarVuelto(row.CTACTE_PAGO_PERSONA_ID, sesion);

                    //Actualizar el total del recibo si se calcula por valores
                    if (dtPago.Rows[0][PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol].Equals(Definiciones.SiNo.No))
                        CuentaCorrienteRecibosService.ActualizarTotal(dtPago, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region CalcularValores
        public static decimal CalcularValores(bool excluirValores, decimal pago_persona_id, decimal moneda_id, decimal moneda_cotizacion, SessionService sesion)
        {
            DataTable dtPagoPersonaValores = CuentaCorrientePagosPersonaDetalleService.GetCuentaCorrientePagosPersonaDetalleDataTable(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + pago_persona_id, string.Empty, sesion);
            decimal montoVuelto = PagosDePersonaService.GetMontoVuelto(pago_persona_id, sesion);
            decimal decimalAux = 0;
            decimal total = 0;

            for (int i = 0; i < dtPagoPersonaValores.Rows.Count; i++)
            {
                if (excluirValores)
                {
                    //No se suman las notas de credito, los anticipos ni las transferencias de ctacte
                    if ((decimal)dtPagoPersonaValores.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.NotaDeCredito ||
                        (decimal)dtPagoPersonaValores.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.Anticipo ||
                        (decimal)dtPagoPersonaValores.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol] == Definiciones.CuentaCorrienteValores.TransferenciaCtacte)
                    {
                        continue;
                    }
                }

                decimalAux = (decimal)dtPagoPersonaValores.Rows[i][CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol];

                if (moneda_id != (decimal)dtPagoPersonaValores.Rows[i][CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol])
                {
                    //Se convierte a la moneda de la cabecera
                    decimalAux = decimalAux / (decimal)dtPagoPersonaValores.Rows[i][CuentaCorrientePagosPersonaDetalleService.CotizacionMoneda_NombreCol] * moneda_cotizacion;
                }

                total += decimalAux;
            }

            return total -= montoVuelto;
        }
        #endregion CalcularValores

        #region DeschacerConfirmacion
        public static void DeschacerConfirmacion(decimal ctacte_pago_persona_det_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONA_DETRow row = sesion.db.CTACTE_PAGOS_PERSONA_DETCollection.GetByPrimaryKey(ctacte_pago_persona_det_id);
            row.IsCTACTE_CHEQUE_RECIBIDO_IDNull = true;
            row.IsRETENCION_IDNull = true;
            row.IsRETENCION_DETALLE_IDNull = true;
            row.IsCTACTE_GIRO_IDNull = true;
            sesion.db.CTACTE_PAGOS_PERSONA_DETCollection.Update(row);
        }
        #endregion DeschacerConfirmacion

        #region ConfirmarDetalles
        /// <summary>
        /// Confirmars the detalles.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal ConfirmarDetalles(decimal ctacte_pago_persona_id, SessionService sesion)
        {
            CuentaCorrienteChequesRecibidosService ctacteChequeRecibido = new CuentaCorrienteChequesRecibidosService();
            DataTable dtCtactePagoPersona = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pago_persona_id, string.Empty, sesion);
            CuentaCorrienteProcesadorasTarjetaService procesadoraTarjeta = new CuentaCorrienteProcesadorasTarjetaService();
            System.Collections.Hashtable campos;
            DataTable dtCtactePersonaPrincipal, dtValidaciones;
            string clausulas;
            decimal ctacteCajaSucursalId, montoTotal = 0;
            decimal vCasoId_DepositoPOS = Definiciones.Error.Valor.EnteroPositivo;
           
            bool exitoCasos_POS = false;

            //Validar que no existan dos retenciones del mismo tipo sobre el mismo caso
            clausulas = "select " + RetencionCasoId_NombreCol +
                        "  from " + Nombre_Tabla +
                        " where " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and + " +
                        "       " + CtactePagoPersonaId_NombreCol + " = " + ctacte_pago_persona_id + " and " +
                        "       " + CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.RetencionIVA +
                        " group by " + RetencionCasoId_NombreCol + ", " + RetencionTipoId_NombreCol +
                        " having count(" + RetencionCasoId_NombreCol + ") > 1";
            dtValidaciones = sesion.db.EjecutarQuery(clausulas);
            if (dtValidaciones.Rows.Count > 0)
            {
                string msgError = dtValidaciones.Rows.Count > 1 ? "Los casos " : "El caso ";
                for (int i = 0; i < dtValidaciones.Rows.Count; i++)
                    msgError += dtValidaciones.Rows[0][CuentaCorrientePagosPersonaDetalleService.RetencionCasoId_NombreCol] + " ";
                msgError += (dtValidaciones.Rows.Count > 1 ? "tienen " : "tiene ");
                msgError += " más de una retención del mismo tipo.";
                throw new Exception(msgError);
            }

            //Se obtiene el id de la caja de sucursal abierta
            ctacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(
                                                        (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.SucursalId_NombreCol],
                                                        (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.FuncionarioCobradorId_NombreCol]);

            //Si no se encontro una abierta, se lanza la excepcion
            if (ctacteCajaSucursalId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                throw new Exception("No existe una caja abierta.");

            //Valores del pago
            clausulas = CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and + " +
                        CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + ctacte_pago_persona_id;

            CTACTE_PAGOS_PERSONA_DETRow[] rows = sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.GetAsArray(clausulas, CuentaCorrientePagosPersonaDetalleService.Id_NombreCol);

            //Realizar acciones por cada tipo de valor
            for (int i = 0; i < rows.Length; i++)
            {
                int ctacteValorId = decimal.ToInt32(rows[i].CTACTE_VALOR_ID);
                switch (ctacteValorId)
                {
                    case Definiciones.CuentaCorrienteValores.Anticipo:
                        //Debe afectarse el saldo del anticipo
                        //e incluirse a la cuenta corriente
                        //Debe incluirse la aplicacion del anticipo a la caja
                        DataTable dtAnticipoPersona;

                        //Se obtiene la cabecera del anticipo
                        dtAnticipoPersona = AnticiposPersonaService.GetAnticipoPersonaDataTable2(rows[i].ANTICIPO_ID);

                        //Se obtiene el movimiento principal de la cuenta corriente
                        clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + dtAnticipoPersona.Rows[0][AnticiposPersonaService.CasoId_NombreCol];
                        dtCtactePersonaPrincipal = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);

                        //Se agrega el credito para disminuir el debito del anticipo
                        CuentaCorrientePersonasService.AgregarCredito((decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol],
                                                     (decimal)dtCtactePersonaPrincipal.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                                     Definiciones.CuentaCorrienteConceptos.CreditoPorPago,
                                                     (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol],
                                                     rows[i].MONEDA_ID,
                                                     rows[i].COTIZACION_MONEDA,
                                                     new decimal[] { Definiciones.Impuestos.Exenta },
                                                     new decimal[] { rows[i].MONTO },
                                                     string.Empty,
                                                     DateTime.Now,
                                                     rows[i].ID,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     1,
                                                     1,
                                                     sesion);

                        //Se afecta el saldo en la cabecera del anticipo
                        AnticiposPersonaService.DisminuirSaldoDisponible(rows[i].ANTICIPO_ID, rows[i].MONTO, false, sesion);

                        break;
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        //Debe crearse el cheque y luego incluirse el pago
                        campos = new System.Collections.Hashtable();
                        campos.Add(CuentaCorrienteChequesRecibidosService.CotizacionMoneda_NombreCol, rows[i].COTIZACION_MONEDA);
                        campos.Add(CuentaCorrienteChequesRecibidosService.CtacteBancoId_NombreCol, rows[i].CHEQUE_CTACTE_BANCO_ID);
                        campos.Add(CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol, string.Empty);
                        campos.Add(CuentaCorrienteChequesRecibidosService.EsDiferido_NombreCol, rows[i].CHEQUE_ES_DIFERIDO);
                        campos.Add(CuentaCorrienteChequesRecibidosService.FechaPosdatado_NombreCol, rows[i].CHEQUE_FECHA_POSDATADO);
                        campos.Add(CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol, rows[i].CHEQUE_FECHA_VENCIMIENTO);
                        campos.Add(CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol, rows[i].MONEDA_ID);
                        campos.Add(CuentaCorrienteChequesRecibidosService.Monto_NombreCol, rows[i].MONTO);
                        campos.Add(CuentaCorrienteChequesRecibidosService.NombreBeneficiario_NombreCol, rows[i].CHEQUE_NOMBRE_BENEFICIARIO);
                        campos.Add(CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol, rows[i].CHEQUE_NOMBRE_EMISOR);
                        campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol, rows[i].CHEQUE_NRO_CHEQUE);
                        campos.Add(CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol, rows[i].CHEQUE_NRO_CUENTA);
                        campos.Add(CuentaCorrienteChequesRecibidosService.ChequeDeTerceros_NombreCol, rows[i].CHEQUE_DE_TERCEROS);
                        campos.Add(CuentaCorrienteChequesRecibidosService.NumeroDocumentoEmisor_NombreCol, rows[i].CHEQUE_DOCUMENTO_EMISOR);
                        campos.Add(CuentaCorrienteChequesRecibidosService.CasoCreadorId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol]);
                        rows[i].CTACTE_CHEQUE_RECIBIDO_ID = ctacteChequeRecibido.Guardar(campos, true, sesion);
                        break;
                    case Definiciones.CuentaCorrienteValores.DepositoBancario:
                        DataTable dtCajaSucursal = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalInfoCompleta2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + ctacteCajaSucursalId, string.Empty);

                        //Se agrega el movimiento bancario
                        //Se da ingreso a la cuenta bancaria
                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                            rows[i].DEPOSITO_CTACTE_BANCARIAS_ID,
                            Definiciones.FlujosIDs.PAGO_DE_PERSONAS,
                            (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol],
                            ctacteCajaSucursalId,
                            rows[i].ID,
                            rows[i].MONEDA_ID,
                            rows[i].MONTO,
                            rows[i].COTIZACION_MONEDA,
                            (DateTime)dtCtactePagoPersona.Rows[0][PagosDePersonaService.Fecha_NombreCol],
                            "Caso " + dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol] + " de Pago de persona ( " + dtCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.VistaFuncionarioNombre_NombreCol] + " en " + dtCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.VistaSucursalNombre_NombreCol] + ".",
                            null,
                            null,
                            false,
                            sesion);
                        break;

                    case Definiciones.CuentaCorrienteValores.Efectivo:
                        //Ninguna accion
                        break;
                    case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:

                        campos = new System.Collections.Hashtable();
                        campos.Add(CuentaCorrienteGirosService.Comprobante_NombreCol, "TC " + rows[i].TARJETA_NRO);
                        campos.Add(CuentaCorrienteGirosService.Cotizacion_NombreCol, rows[i].COTIZACION_MONEDA);
                        campos.Add(CuentaCorrienteGirosService.CtaCtePlanesDesembolsoId_NombreCol, rows[i].CTACTE_PLAN_DESEMBOLSO_ID);
                        campos.Add(CuentaCorrienteGirosService.MonedaId_NombreCol, rows[i].MONEDA_ID);
                        campos.Add(CuentaCorrienteGirosService.MontoPago_NombreCol, rows[i].MONTO);
                        campos.Add(CuentaCorrienteGirosService.PersonaId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol]);
                        // Se agrega el caso del pago asociaro para la creacion del movimiento de giro correspondiente
                        campos.Add(CuentaCorrienteGirosMovimientosService.CasoId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol]);

                        rows[i].CTACTE_GIRO_ID = CuentaCorrienteGirosService.Guardar(campos, (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol], sesion);

                        break;
                    case Definiciones.CuentaCorrienteValores.NotaDeCredito:
                        //Debe afectarse el saldo de la NC
                        //e incluirse a la cuenta corriente
                        DataTable dtNotaCreditoPersona;

                        //Se obtiene la cabecera del anticipo
                        dtNotaCreditoPersona = NotasCreditoPersonaService.GetNotaCreditoPersonaDataTable2(rows[i].NOTA_CREDITO_ID);

                        //Se obtiene el movimiento principal de la cuenta corriente
                        clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.CasoId_NombreCol];
                        dtCtactePersonaPrincipal = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);

                        DataTable dtCtactePersonaDet;
                        System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                        decimal[] impuestoId, monto;
                        int indiceAux;
                        decimal montoVerificacion, montoAux;

                        #region Calcular monto por tipo de impuesto
                        dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dtCtactePersonaPrincipal.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], sesion);

                        for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                        {
                            // (monto pagado) / (Debito cuenta pagada) * monto correspondiente al tipo de impuetso en la cuenta principal
                            montoAux = rows[i].MONTO / (decimal)dtCtactePersonaPrincipal.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol] * (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol];

                            if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + montoAux;
                            else
                                montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], montoAux);
                        }

                        impuestoId = new decimal[montoPorImpuesto.Count];
                        monto = new decimal[montoPorImpuesto.Count];

                        indiceAux = 0;
                        montoVerificacion = 0;
                        foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                        {
                            impuestoId[indiceAux] = (decimal)par.Key;
                            monto[indiceAux] = (decimal)par.Value;

                            montoVerificacion += (decimal)par.Value;

                            indiceAux++;
                        }

                        if (Math.Round(rows[i].MONTO, 4) != Math.Round(montoVerificacion, 4))
                            throw new Exception("Error en CuentaCorrientePagosPersonaDetalleService.ConfirmarDetalles(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + rows[i].MONTO + ".");
                        #endregion Calcular monto por tipo de impuesto

                        //Se agrega el credito para disminuir el debito de la NC
                        CuentaCorrientePersonasService.AgregarCredito((decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol],
                                                     (decimal)dtCtactePersonaPrincipal.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                                     Definiciones.CuentaCorrienteConceptos.CreditoPorPago,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     rows[i].MONEDA_ID,
                                                     rows[i].COTIZACION_MONEDA,
                                                     impuestoId,
                                                     monto,
                                                     string.Empty,
                                                     DateTime.Now,
                                                     rows[i].ID,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     1,
                                                     1,
                                                     sesion);

                        //Se afecta el saldo en la cabecera de la NC
                        NotasCreditoPersonaService.DisminuirSaldoDisponible(rows[i].NOTA_CREDITO_ID, rows[i].MONTO, false, sesion);

                        break;
                    case Definiciones.CuentaCorrienteValores.RetencionIVA:
                        //Debe crearse la retencion en las tablas correspondientes
                        decimal retencion_cabecera_id;

                        //Verificar si ya existe una cabecera de retencion creada
                        retencion_cabecera_id = CuentaCorrientePagosPersonaDetalleService.GetRetencion(ctacte_pago_persona_id, rows[i].RETENCION_NRO_COMPROBANTE, sesion);

                        decimal retencion;
                        string query;
                        DataTable dtFacturaMonto, dtRetencionPagada;

                        //se busca el impuesto para calcular la retencion
                        query = "select round(case m.id \n" +
                                " when " + rows[i].MONEDA_ID + " then \n" +
                                " fc." + FacturasClienteService.TotalMontoImpuesto_NombreCol + " * \n" +
                                " (1 - fc." + FacturasClienteService.PorcentajeDescSobreTotal_NombreCol + " / 100) \n" +
                                " else \n" +
                                " fc." + FacturasClienteService.TotalMontoImpuesto_NombreCol + " * \n" +
                                " (1 - fc." + FacturasClienteService.PorcentajeDescSobreTotal_NombreCol + " / 100) / \n" +
                                " fc." + FacturasClienteService.CotizacionDestino_NombreCol + " * \n" +
                                " herramientas.Obtener_Cotizacion_Venta(fc." + FacturasClienteService.SucursalId_NombreCol + " , \n" +
                                rows[i].MONEDA_ID + " , \n" +
                                " fc." + FacturasClienteService.Fecha_NombreCol + ") end, m." + MonedasService.Modelo.CANTIDADES_DECIMALESColumnName + ") " + FacturasClienteService.TotalMontoImpuesto_NombreCol + " \n" +
                                " from " + FacturasClienteService.Nombre_Tabla + " fc," + MonedasService.Nombre_Tabla + " m \n" +
                                " where fc." + FacturasClienteService.MonedaDestinoId_NombreCol + " = m." + MonedasService.Modelo.IDColumnName + "\n" +
                                " and fc." + FacturasClienteService.CasoId_NombreCol + " = " + rows[i].RETENCION_CASO_ID;

                        dtFacturaMonto = sesion.db.EjecutarQuery(query);

                        //si encontro el monto del impuesto, empieza el calculo de la retencion
                        if (dtFacturaMonto.Rows.Count > 0)
                        {
                            //se calcula la retencion
                            retencion = ((decimal)dtFacturaMonto.Rows[0][FacturasClienteService.TotalMontoImpuesto_NombreCol] * rows[i].RETENCION_PORCENTAJE) / 100;

                            if (rows[0].MONEDA_ID == Definiciones.Monedas.Guaranies)
                                retencion = Math.Round(retencion, 0, MidpointRounding.AwayFromZero);
                            else
                                retencion = Math.Round(retencion, 2, MidpointRounding.AwayFromZero);

                            //se busca el total de la retencion pagada si hay insertada
                            query = "select round(case cr." + CuentaCorrienteRetencionesRecibidasService.MonedaId_NombreCol + " \n " +
                                    " when " + rows[i].MONEDA_ID + " then \n" +
                                    " cr." + CuentaCorrienteRetencionesRecibidasService.Total_NombreCol + " \n" +
                                    " else \n " +
                                    " cr." + CuentaCorrienteRetencionesRecibidasService.Total_NombreCol + " / \n" +
                                    " fc." + FacturasClienteService.CotizacionDestino_NombreCol + " * \n" +
                                    " herramientas.Obtener_Cotizacion_Venta(fc." + FacturasClienteService.SucursalId_NombreCol + " , \n" +
                                    rows[i].MONEDA_ID + " , \n" +
                                    " fc." + FacturasClienteService.Fecha_NombreCol + ") end, 2) " + CuentaCorrienteRetencionesRecibidasService.Total_NombreCol + " \n" +
                                    " from " + CuentaCorrienteRetencionesRecibidasService.Nombre_Tabla + " cr, " + CuentaCorrientePagosPersonaDetalleService.Nombre_Tabla + " ccpd, " + FacturasClienteService.Nombre_Tabla + " fc \n " +
                                    " where ccpd." + CuentaCorrientePagosPersonaDetalleService.RetencionCasoId_NombreCol + " = " + rows[i].RETENCION_CASO_ID +
                                    " and ccpd. " + CuentaCorrientePagosPersonaDetalleService.RetencionCasoId_NombreCol + " = fc." + FacturasClienteService.CasoId_NombreCol + " \n" +
                                    " and cr." + CuentaCorrienteRetencionesRecibidasService.Id_NombreCol + " = ccpd." + CuentaCorrientePagosPersonaDetalleService.RetencionId_NombreCol +
                                    " and ccpd." + CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                            dtRetencionPagada = sesion.db.EjecutarQuery(query);

                            //si hay retencion insertada, se resta a la retencion calculada
                            if (dtRetencionPagada.Rows.Count > 0)
                            {
                                retencion = retencion - dtRetencionPagada.AsEnumerable().Sum(r => r.Field<decimal>(CuentaCorrienteRetencionesRecibidasService.Total_NombreCol));
                                if (rows[0].MONEDA_ID == Definiciones.Monedas.Guaranies)
                                    retencion = Math.Round(retencion, 0);
                                else
                                    retencion = Math.Round(retencion, 2);
                            }

                            if (rows[i].MONTO > retencion)
                                throw new Exception("El monto de la retención caso " + rows[i].RETENCION_CASO_ID + " supera el monto a retener del documento, que es " + retencion + ".");
                        }

                        //Si no existe entonces crear la cabecera
                        if (retencion_cabecera_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        {
                            campos = new System.Collections.Hashtable();
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.MonedaId_NombreCol, rows[i].MONEDA_ID);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.PersonaId_NombreCol, (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol]);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.NroComprobante_NombreCol, rows[i].RETENCION_NRO_COMPROBANTE);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.Fecha_NombreCol, rows[i].RETENCION_FECHA);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.Observacion_NombreCol, rows[i].RETENCION_OBSERVACION);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.Timbrado_NombreCol, rows[i].RETENCION_TIMBRADO);

                            retencion_cabecera_id = CuentaCorrienteRetencionesRecibidasService.Guardar(ctacte_pago_persona_id, campos, sesion);
                        }
                        rows[i].RETENCION_ID = retencion_cabecera_id;

                        if (retencion_cabecera_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("No se pudo encontrar o crear la cabecera de retención al intentar generar el detalle de retención.");

                        //Detalle de retencion a agregar
                        campos = new System.Collections.Hashtable();
                        campos.Add(CuentaCorrienteRetencionesRecDetService.CtacteRetencionRecibidaId_NombreCol, retencion_cabecera_id);
                        campos.Add(CuentaCorrienteRetencionesRecDetService.CasoId_NombreCol, rows[i].RETENCION_CASO_ID);
                        campos.Add(CuentaCorrienteRetencionesRecDetService.TipoId_NombreCol, rows[i].RETENCION_TIPO_ID);
                        campos.Add(CuentaCorrienteRetencionesRecDetService.Monto_NombreCol, rows[i].MONTO);
                        rows[i].RETENCION_DETALLE_ID = CuentaCorrienteRetencionesRecDetService.Guardar(campos, sesion);

                        break;
                    case Definiciones.CuentaCorrienteValores.RetencionRenta:
                        //Debe crearse la retencion en las tablas correspondientes
                        decimal retencion_renta_cabecera_id;

                        //Verificar si ya existe una cabecera de retencion creada
                        retencion_renta_cabecera_id = CuentaCorrientePagosPersonaDetalleService.GetRetencion(ctacte_pago_persona_id, rows[i].RETENCION_NRO_COMPROBANTE, sesion);

                        //Si no existe entonces crear la cabecera
                        if (retencion_renta_cabecera_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        {
                            campos = new System.Collections.Hashtable();
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.MonedaId_NombreCol, rows[i].MONEDA_ID);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.PersonaId_NombreCol, (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol]);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.NroComprobante_NombreCol, rows[i].RETENCION_NRO_COMPROBANTE);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.Fecha_NombreCol, rows[i].RETENCION_FECHA);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.Observacion_NombreCol, rows[i].RETENCION_OBSERVACION);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.Timbrado_NombreCol, rows[i].RETENCION_TIMBRADO);

                            retencion_renta_cabecera_id = CuentaCorrienteRetencionesRecibidasService.Guardar(ctacte_pago_persona_id, campos, sesion);
                        }
                        rows[i].RETENCION_ID = retencion_renta_cabecera_id;

                        if (retencion_renta_cabecera_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("No se pudo encontrar o crear la cabecera de retención al intentar generar el detalle de retención.");

                        //Detalle de retencion a agregar
                        campos = new System.Collections.Hashtable();
                        campos.Add(CuentaCorrienteRetencionesRecDetService.CtacteRetencionRecibidaId_NombreCol, retencion_renta_cabecera_id);
                        campos.Add(CuentaCorrienteRetencionesRecDetService.CasoId_NombreCol, rows[i].RETENCION_CASO_ID);
                        campos.Add(CuentaCorrienteRetencionesRecDetService.TipoId_NombreCol, rows[i].RETENCION_TIPO_ID);
                        campos.Add(CuentaCorrienteRetencionesRecDetService.Monto_NombreCol, rows[i].MONTO);
                        rows[i].RETENCION_DETALLE_ID = CuentaCorrienteRetencionesRecDetService.Guardar(campos, sesion);

                        break;
                    case Definiciones.CuentaCorrienteValores.RetencionSECP:
                        //Debe crearse la retencion en las tablas correspondientes
                        decimal retencion_secp_cabecera_id;

                        //Verificar si ya existe una cabecera de retencion creada
                        retencion_secp_cabecera_id = CuentaCorrientePagosPersonaDetalleService.GetRetencion(ctacte_pago_persona_id, rows[i].RETENCION_NRO_COMPROBANTE, sesion);

                        //Si no existe entonces crear la cabecera
                        if (retencion_secp_cabecera_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        {
                            campos = new System.Collections.Hashtable();
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.MonedaId_NombreCol, rows[i].MONEDA_ID);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.PersonaId_NombreCol, (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol]);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.NroComprobante_NombreCol, rows[i].RETENCION_NRO_COMPROBANTE);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.Fecha_NombreCol, rows[i].RETENCION_FECHA);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.Observacion_NombreCol, rows[i].RETENCION_OBSERVACION);
                            campos.Add(CuentaCorrienteRetencionesRecibidasService.Timbrado_NombreCol, rows[i].RETENCION_TIMBRADO);

                            retencion_secp_cabecera_id = CuentaCorrienteRetencionesRecibidasService.Guardar(ctacte_pago_persona_id, campos, sesion);
                        }
                        rows[i].RETENCION_ID = retencion_secp_cabecera_id;

                        if (retencion_secp_cabecera_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("No se pudo encontrar o crear la cabecera de retención al intentar generar el detalle de retención.");

                        //Detalle de retencion a agregar
                        campos = new System.Collections.Hashtable();
                        campos.Add(CuentaCorrienteRetencionesRecDetService.CtacteRetencionRecibidaId_NombreCol, retencion_secp_cabecera_id);
                        campos.Add(CuentaCorrienteRetencionesRecDetService.CasoId_NombreCol, rows[i].RETENCION_CASO_ID);
                        campos.Add(CuentaCorrienteRetencionesRecDetService.TipoId_NombreCol, rows[i].RETENCION_TIPO_ID);
                        campos.Add(CuentaCorrienteRetencionesRecDetService.Monto_NombreCol, rows[i].MONTO);
                        rows[i].RETENCION_DETALLE_ID = CuentaCorrienteRetencionesRecDetService.Guardar(campos, sesion);

                        break;
                    case Definiciones.CuentaCorrienteValores.TransferenciaCtacte:
                        //Debe afectarse el saldo de la transferencia
                        //e incluirse a la cuenta corriente
                        //Debe incluirse la aplicacion de la transferencia a la caja
                        DataTable dtTransferenciaCtactePersonas;

                        //Se obtiene la cabecera
                        dtTransferenciaCtactePersonas = TransferenciasCtaCtePersonasService.GetTransferenciaDataTable(TransferenciasCtaCtePersonasService.Id_NombreCol + " = " + rows[i].TRANSFERENCIA_CTACTE_PERS_ID, string.Empty);

                        //Se obtiene el movimiento principal de la cuenta corriente
                        clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + dtTransferenciaCtactePersonas.Rows[0][AnticiposPersonaService.CasoId_NombreCol] + " and " +
                                    CuentaCorrientePersonasService.Debito_NombreCol + " > 0 ";
                        dtCtactePersonaPrincipal = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);

                        //Se agrega el credito para disminuir el debito del anticipo
                        CuentaCorrientePersonasService.AgregarCredito((decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol],
                                                     (decimal)dtCtactePersonaPrincipal.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                                     Definiciones.CuentaCorrienteConceptos.CreditoPorPago,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     rows[i].MONEDA_ID,
                                                     rows[i].COTIZACION_MONEDA,
                                                     new decimal[] { Definiciones.Impuestos.Exenta },
                                                     new decimal[] { rows[i].MONTO },
                                                     string.Empty,
                                                     DateTime.Now,
                                                     rows[i].ID,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     Definiciones.Error.Valor.EnteroPositivo,
                                                     1,
                                                     1,
                                                     sesion);

                        break;
                    case Definiciones.CuentaCorrienteValores.Pagare:
                        throw new Exception("No puede pagarse utilizando un pagaré.");

                    case Definiciones.CuentaCorrienteValores.Giro:

                        campos = new System.Collections.Hashtable();
                        campos.Add(CuentaCorrienteGirosService.Comprobante_NombreCol, rows[i].GIRO_COMPROBANTE == null ? string.Empty : rows[i].GIRO_COMPROBANTE);
                        campos.Add(CuentaCorrienteGirosService.Cotizacion_NombreCol, rows[i].COTIZACION_MONEDA);
                        campos.Add(CuentaCorrienteGirosService.CtaCtePlanesDesembolsoId_NombreCol, rows[i].CTACTE_PLAN_DESEMBOLSO_ID);
                        campos.Add(CuentaCorrienteGirosService.MonedaId_NombreCol, rows[i].MONEDA_ID);
                        campos.Add(CuentaCorrienteGirosService.MontoPago_NombreCol, rows[i].MONTO);
                        campos.Add(CuentaCorrienteGirosService.PersonaId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.PersonaId_NombreCol]);
                        campos.Add(CuentaCorrienteGirosService.Observaciones_NombreCol, rows[i].OBSERVACIONES);
                        // Se agrega el caso del pago asociado para la creacion del movimiento de giro correspondiente
                        campos.Add(CuentaCorrienteGirosMovimientosService.CasoId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol]);

                        rows[i].CTACTE_GIRO_ID = CuentaCorrienteGirosService.Guardar(campos, (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CasoId_NombreCol], sesion);
                        break;

                    case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                        //Ninguna accion
                        break;
                    case Definiciones.CuentaCorrienteValores.Ajuste:
                        //Ninguna accion
                        break;
                    case Definiciones.CuentaCorrienteValores.POS:
                        //la transferencia de caja se realiza de una vez al cierre de caja
                        // si es online, crea caso de deposito bancario
                        // si el deposito se realiza de forma "offline", entonces solamente se agregan detalles del pago para que luego se procese con un webservice
                        try
                        {
                            
                            //  crear deposito bancario, a estado borrador
                            exitoCasos_POS = DepositoBancario_POS(dtCtactePagoPersona.Rows[0], rows[i], sesion, ref vCasoId_DepositoPOS);

                        }
                        catch (Exception e)
                        {
                            sesion.RollbackTransaction();
                            throw;
                        }
                        break;
                    default: throw new Exception("Error. El tipo de valor indefinido.");
                }

                //Se actualiza el detalle por si se completo un dato
                sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.Update(rows[i]);

                //Se agrega a la caja de la sucursal
                campos = new System.Collections.Hashtable();
                campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.Fecha_NombreCol]);
                campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, rows[i].MONEDA_ID);
                campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, rows[i].COTIZACION_MONEDA);
                campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, rows[i].MONTO);
                campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, rows[i].CTACTE_VALOR_ID);
                campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.SucursalId_NombreCol]);
                campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, dtCtactePagoPersona.Rows[0][PagosDePersonaService.FuncionarioCobradorId_NombreCol]);
                campos.Add(CuentaCorrienteCajaService.CtactePagoPersonaId_NombreCol, rows[i].CTACTE_PAGO_PERSONA_ID);
                campos.Add(CuentaCorrienteCajaService.CtactePagoPersonaDetId_NombreCol, rows[i].ID);
                campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.DebitoPorPago);
                campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, ctacteCajaSucursalId);

                if (rows[i].CTACTE_VALOR_ID.Equals(Definiciones.CuentaCorrienteValores.Cheque))
                    campos.Add(CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol, rows[i].CTACTE_CHEQUE_RECIBIDO_ID);

                CuentaCorrienteCajaService.Guardar(campos, sesion); // aqui se ingresa a caja el valor cobrado //3

                //Debe convertirse si la moneda del valor es distinta a la moneda principal del pago
                if (rows[i].MONEDA_ID.Equals((decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.MonedaId_NombreCol]))
                {
                    montoTotal += rows[i].MONTO;
                }
                else
                {
                    montoTotal += rows[i].MONTO / rows[i].COTIZACION_MONEDA * (decimal)dtCtactePagoPersona.Rows[0][PagosDePersonaService.CotizacionMoneda_NombreCol];
                }

                if (exitoCasos_POS)
                {
                   // 
                   // exitoCasos_POS = avanzarEstadosTransferenciaCaja(vCasoId_TransferenciaPOS, sesion);

                    exitoCasos_POS = avanzarEstadosDepositoBancario(vCasoId_DepositoPOS, sesion);

                    #region actualizar detalles de los pagos procesados, indicando el id de deposito bancario relacionado
                    if (exitoCasos_POS)
                    {
                        // se actualiza el detalle de pago, por si se ha creado con exito el deposito bancario xxxx
                        #region obtener caso creado
                        DataTable caso = DepositosBancariosService.GetDepositosBancariosDataTable(DepositosBancariosService.CasoId_NombreCol + " = " + vCasoId_DepositoPOS, string.Empty, sesion);
                        decimal vCasoDepositoId = (decimal)caso.Rows[0][DepositosBancariosService.Id_NombreCol];
                        #endregion obtener caso creado
                        rows[i].DEPOSITO_BANCARIO_ID = vCasoDepositoId;
                        sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.Update(rows[i]);
                        exitoCasos_POS = false; // esto evita que en la sgte iteración vuelva a pasar por aqui si no es un deposito bancario
                    }
                    #endregion actualizar detalles de los pagos procesados, indicando el id de deposito bancario relacionado
                }
            }

            return montoTotal;
        }
        #endregion ConfirmarDetalles

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PAGOS_PERSONA_DET"; }
        }
        public static string AnticipoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.ANTICIPO_IDColumnName; }
        }

        public static string ChequeCtacteBancoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_CTACTE_BANCO_IDColumnName; }
        }
        public static string ChequeEsDiferido_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_ES_DIFERIDOColumnName; }
        }
        public static string ChequeFechaPosdatada_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_FECHA_POSDATADOColumnName; }
        }
        public static string ChequeFechaVencimiento_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_FECHA_VENCIMIENTOColumnName; }
        }
        public static string ChequeDeTerceros_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_DE_TERCEROSColumnName; }
        }
        public static string ChequeNombreBeneficiario_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string ChequeNombreEmisor_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_NOMBRE_EMISORColumnName; }
        }
        public static string ChequeNroCheque_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_NRO_CHEQUEColumnName; }
        }
        public static string ChequeNroCuenta_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_NRO_CUENTAColumnName; }
        }
        public static string ChequeDocumentoEmisor_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CHEQUE_DOCUMENTO_EMISORColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteGiroId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CTACTE_GIRO_IDColumnName; }
        }
        public static string CtactePagoPersonaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CTACTE_PAGO_PERSONA_IDColumnName; }
        }
        public static string CtacteProcesadoraTarjetaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CTACTE_PROCESADORA_TARJETA_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string CtaCtePlanDesembolsoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CTACTE_PLAN_DESEMBOLSO_IDColumnName; }
        }
        public static string CtaCteRedPagoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.CTACTE_RED_PAGO_IDColumnName; }
        }
        public static string DepositoBancarioId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.DEPOSITO_BANCARIO_IDColumnName; }
        }
        public static string DepositoCtaCteBancariasId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.DEPOSITO_CTACTE_BANCARIAS_IDColumnName; }
        }
        public static string DepositoFecha_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.DEPOSITO_FECHAColumnName; }
        }
        public static string DepositoNroBoleta_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.DEPOSITO_NRO_BOLETAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.ESTADOColumnName; }
        }
        public static string GiroComprobante_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.GIRO_COMPROBANTEColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.MONTOColumnName; }
        }
        public static string NotaCreditoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.NOTA_CREDITO_IDColumnName; }
        }
        public static string Observaciones_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.OBSERVACIONESColumnName; }
        }
        public static string RetencionCasoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.RETENCION_CASO_IDColumnName; }
        }
        public static string RetencionFecha_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.RETENCION_FECHAColumnName; }
        }
        public static string RetencionPorcentaje_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.RETENCION_PORCENTAJEColumnName; }
        }
        public static string RetencionTimbrado_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.RETENCION_TIMBRADOColumnName; }
        }
        public static string RetencionTipoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.RETENCION_TIPO_IDColumnName; }
        }
        public static string RetencionDetalleId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.RETENCION_DETALLE_IDColumnName; }
        }
        public static string RetencionId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.RETENCION_IDColumnName; }
        }
        public static string RetencionNroComprobante_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.RETENCION_NRO_COMPROBANTEColumnName; }
        }
        public static string RetencionObservacion_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.RETENCION_OBSERVACIONColumnName; }
        }
        public static string TarjetaNro_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.TARJETA_NROColumnName; }
        }
        public static string TarjetaTitular_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.TARJETA_TITULARColumnName; }
        }
        public static string TarjetaVencimiento_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.TARJETA_VENCIMIENTOColumnName; }
        }
        public static string TransferenciaBancariaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.TRANSFERENCIA_BANCARIA_IDColumnName; }
        }
        public static string TransferenciaCtactePersId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.TRANSFERENCIA_CTACTE_PERS_IDColumnName; }
        }
        public static string PosId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.POS_IDColumnName; }
        }
        public static string MontoNeto_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.MONTO_NETOColumnName; }
        }
        public static string FechaAcreditacion_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.FECHA_ACREDITACIONColumnName; }
        }
        public static string TransferenciaCajaSucursalId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_DETCollection.TRANSFERENCIA_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DET_INF_COMPCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DET_INF_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DET_INF_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaObservacion_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DET_INF_COMPCollection.OBSERVACIONColumnName; }
        }
        public static string VistaRetencionTimbrado_NombreCol
        {
            get { return CTACTE_PAGOS_PERS_DET_INF_COMPCollection.RETENCION_TIMBRADOColumnName; }
        }

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrientePagosPersonaDetalleService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrientePagosPersonaDetalleService(e.RegistroId, sesion);
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
        protected CTACTE_PAGOS_PERSONA_DETRow row;
        protected CTACTE_PAGOS_PERSONA_DETRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AnticipoId { get { if (row.IsANTICIPO_IDNull) return null; else return row.ANTICIPO_ID; } set { if (value.HasValue) row.ANTICIPO_ID = value.Value; else row.IsANTICIPO_IDNull = true; } }
        public decimal? ChequeCtacteBancoId { get { if (row.IsCHEQUE_CTACTE_BANCO_IDNull) return null; else return row.CHEQUE_CTACTE_BANCO_ID; } set { if (value.HasValue) row.CHEQUE_CTACTE_BANCO_ID = value.Value; else row.IsCHEQUE_CTACTE_BANCO_IDNull = true; } }
        public string ChequeDeTerceros { get { return ClaseCBABase.GetStringHelper(row.CHEQUE_DE_TERCEROS); } set { row.CHEQUE_DE_TERCEROS = value; } }
        public string ChequeDocumentoEmisor { get { return ClaseCBABase.GetStringHelper(row.CHEQUE_DOCUMENTO_EMISOR); } set { row.CHEQUE_DOCUMENTO_EMISOR = value; } }
        public string ChequeEsDiferido { get { return ClaseCBABase.GetStringHelper(row.CHEQUE_ES_DIFERIDO); } set { row.CHEQUE_ES_DIFERIDO = value; } }
        public DateTime? ChequeFechaPosdatado { get { if (row.IsCHEQUE_FECHA_POSDATADONull) return null; else return row.CHEQUE_FECHA_POSDATADO; } set { if (value.HasValue) row.CHEQUE_FECHA_POSDATADO = value.Value; else row.IsCHEQUE_FECHA_POSDATADONull = true; } }
        public DateTime? ChequeFechaVencimiento { get { if (row.IsCHEQUE_FECHA_VENCIMIENTONull) return null; else return row.CHEQUE_FECHA_VENCIMIENTO; } set { if (value.HasValue) row.CHEQUE_FECHA_VENCIMIENTO = value.Value; else row.IsCHEQUE_FECHA_VENCIMIENTONull = true; } }
        public string ChequeNombreBeneficiario { get { return ClaseCBABase.GetStringHelper(row.CHEQUE_NOMBRE_BENEFICIARIO); } set { row.CHEQUE_NOMBRE_BENEFICIARIO = value; } }
        public string ChequeNombreEmisor { get { return ClaseCBABase.GetStringHelper(row.CHEQUE_NOMBRE_EMISOR); } set { row.CHEQUE_NOMBRE_EMISOR = value; } }
        public string ChequeNroCheque { get { return ClaseCBABase.GetStringHelper(row.CHEQUE_NRO_CHEQUE); } set { row.CHEQUE_NRO_CHEQUE = value; } }
        public string ChequeNroCuenta { get { return ClaseCBABase.GetStringHelper(row.CHEQUE_NRO_CUENTA); } set { row.CHEQUE_NRO_CUENTA = value; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal? CtacteGiroId { get { if (row.IsCTACTE_GIRO_IDNull) return null; else return row.CTACTE_GIRO_ID; } set { if (value.HasValue) row.CTACTE_GIRO_ID = value.Value; else row.IsCTACTE_GIRO_IDNull = true; } }
        public decimal? CtacteChequeRecibidoId { get { if (row.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return null; else return row.CTACTE_CHEQUE_RECIBIDO_ID; } set { if (value.HasValue) row.CTACTE_CHEQUE_RECIBIDO_ID = value.Value; else row.IsCTACTE_CHEQUE_RECIBIDO_IDNull = true; } }
        public decimal CtactePagoPersonaId { get { return row.CTACTE_PAGO_PERSONA_ID; } set { row.CTACTE_PAGO_PERSONA_ID = value; } }
        public decimal? CtactePlanDesembolsoId { get { if (row.IsCTACTE_PLAN_DESEMBOLSO_IDNull) return null; else return row.CTACTE_PLAN_DESEMBOLSO_ID; } set { if (value.HasValue) row.CTACTE_PLAN_DESEMBOLSO_ID = value.Value; else row.IsCTACTE_PLAN_DESEMBOLSO_IDNull = true; } }
        public decimal? CtacteProcesadoraTarjetaId { get { if (row.IsCTACTE_PROCESADORA_TARJETA_IDNull) return null; else return row.CTACTE_PROCESADORA_TARJETA_ID; } set { if (value.HasValue) row.CTACTE_PROCESADORA_TARJETA_ID = value.Value; else row.IsCTACTE_PROCESADORA_TARJETA_IDNull = true; } }
        public decimal? CtacteRedPagoId { get { if (row.IsCTACTE_RED_PAGO_IDNull) return null; else return row.CTACTE_RED_PAGO_ID; } set { if (value.HasValue) row.CTACTE_RED_PAGO_ID = value.Value; else row.IsCTACTE_RED_PAGO_IDNull = true; } }
        public decimal CtacteValorId { get { return row.CTACTE_VALOR_ID; } set { row.CTACTE_VALOR_ID = value; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? DepositoBancarioId { get { if (row.IsDEPOSITO_BANCARIO_IDNull) return null; else return row.DEPOSITO_BANCARIO_ID; } set { if (value.HasValue) row.DEPOSITO_BANCARIO_ID = value.Value; else row.IsDEPOSITO_BANCARIO_IDNull = true; } }
        public decimal? DepositoCtacteBancariasId { get { if (row.IsDEPOSITO_CTACTE_BANCARIAS_IDNull) return null; else return row.DEPOSITO_CTACTE_BANCARIAS_ID; } set { if (value.HasValue) row.DEPOSITO_CTACTE_BANCARIAS_ID = value.Value; else row.IsDEPOSITO_CTACTE_BANCARIAS_IDNull = true; } }
        public DateTime? DepositoFecha { get { if (row.IsDEPOSITO_FECHANull) return null; else return row.DEPOSITO_FECHA; } set { if (value.HasValue) row.DEPOSITO_FECHA = value.Value; else row.IsDEPOSITO_FECHANull = true; } }
        public string DepositoNroBoleta { get { return ClaseCBABase.GetStringHelper(row.DEPOSITO_NRO_BOLETA); } set { row.DEPOSITO_NRO_BOLETA = value; } }
        public string GiroComprobante { get { return ClaseCBABase.GetStringHelper(row.GIRO_COMPROBANTE); } set { row.GIRO_COMPROBANTE = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal? Monto { get { if (row.IsMONTONull) return null; else return row.MONTO; } set { if (value.HasValue) row.MONTO = value.Value; else row.IsMONTONull = true; } }
        public decimal? NotaCreditoId { get { if (row.IsNOTA_CREDITO_IDNull) return null; else return row.NOTA_CREDITO_ID; } set { if (value.HasValue) row.NOTA_CREDITO_ID = value.Value; else row.IsNOTA_CREDITO_IDNull = true; } }
        public string Observaciones { get { return ClaseCBABase.GetStringHelper(row.OBSERVACIONES); } set { row.OBSERVACIONES = value; } }
        public decimal? RetencionCasoId { get { if (row.IsRETENCION_CASO_IDNull) return null; else return row.RETENCION_CASO_ID; } set { if (value.HasValue) row.RETENCION_CASO_ID = value.Value; else row.IsRETENCION_CASO_IDNull = true; } }
        public decimal? RetencionDetalleId { get { if (row.IsRETENCION_DETALLE_IDNull) return null; else return row.RETENCION_DETALLE_ID; } set { if (value.HasValue) row.RETENCION_DETALLE_ID = value.Value; else row.IsRETENCION_DETALLE_IDNull = true; } }
        public DateTime? RetencionFecha { get { if (row.IsRETENCION_FECHANull) return null; else return row.RETENCION_FECHA; } set { if (value.HasValue) row.RETENCION_FECHA = value.Value; else row.IsRETENCION_FECHANull = true; } }
        public decimal? RetencionId { get { if (row.IsRETENCION_IDNull) return null; else return row.RETENCION_ID; } set { if (value.HasValue) row.RETENCION_ID = value.Value; else row.IsRETENCION_IDNull = true; } }
        public string RetencionNroComprobante { get { return ClaseCBABase.GetStringHelper(row.RETENCION_NRO_COMPROBANTE); } set { row.RETENCION_NRO_COMPROBANTE = value; } }
        public string RetencionObservacion { get { return ClaseCBABase.GetStringHelper(row.RETENCION_OBSERVACION); } set { row.RETENCION_OBSERVACION = value; } }
        public string RetencionTimbrado { get { return ClaseCBABase.GetStringHelper(row.RETENCION_TIMBRADO); } set { row.RETENCION_TIMBRADO = value; } }
        public decimal? RetencionTipoId { get { if (row.IsRETENCION_TIPO_IDNull) return null; else return row.RETENCION_TIPO_ID; } set { if (value.HasValue) row.RETENCION_TIPO_ID = value.Value; else row.IsRETENCION_TIPO_IDNull = true; } }
        public string TarjetaNro { get { return ClaseCBABase.GetStringHelper(row.TARJETA_NRO); } set { row.TARJETA_NRO = value; } }
        public string TarjetaTitular { get { return ClaseCBABase.GetStringHelper(row.TARJETA_TITULAR); } set { row.TARJETA_TITULAR = value; } }
        public DateTime? TarjetaVencimiento { get { if (row.IsTARJETA_VENCIMIENTONull) return null; else return row.TARJETA_VENCIMIENTO; } set { if (value.HasValue) row.TARJETA_VENCIMIENTO = value.Value; else row.IsTARJETA_VENCIMIENTONull = true; } }
        public decimal? TransferenciaBancariaId { get { if (row.IsTRANSFERENCIA_BANCARIA_IDNull) return null; else return row.TRANSFERENCIA_BANCARIA_ID; } set { if (value.HasValue) row.TRANSFERENCIA_BANCARIA_ID = value.Value; else row.IsTRANSFERENCIA_BANCARIA_IDNull = true; } }
        public decimal? TransferenciaCtactePersId { get { if (row.IsTRANSFERENCIA_CTACTE_PERS_IDNull) return null; else return row.TRANSFERENCIA_CTACTE_PERS_ID; } set { if (value.HasValue) row.TRANSFERENCIA_CTACTE_PERS_ID = value.Value; else row.IsTRANSFERENCIA_CTACTE_PERS_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private PagosDePersonaService _ctacte_pago_persona;
        public PagosDePersonaService CtactePagoPersona
        {
            get
            {
                if (this._ctacte_pago_persona == null)
                    this._ctacte_pago_persona = new PagosDePersonaService(this.CtactePagoPersonaId);
                return this._ctacte_pago_persona;
            }
        }

        private CuentaCorrienteProcesadorasTarjetaService _ctacte_procesadora_tarjeta;
        public CuentaCorrienteProcesadorasTarjetaService CtacteProcesadoraTarjeta
        {
            get
            {
                if (this._ctacte_procesadora_tarjeta == null)
                    this._ctacte_procesadora_tarjeta = new CuentaCorrienteProcesadorasTarjetaService(this.CtacteProcesadoraTarjetaId.Value);
                return this._ctacte_procesadora_tarjeta;
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
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_PAGOS_PERSONA_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_PAGOS_PERSONA_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_PAGOS_PERSONA_DETRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CuentaCorrientePagosPersonaDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrientePagosPersonaDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrientePagosPersonaDetalleService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CuentaCorrientePagosPersonaDetalleService(EdiCBA.CobranzaValor edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = CuentaCorrientePagosPersonaDetalleService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.venta;

            this.Estado = Definiciones.Estado.Activo;

            #region pago de persona
            if (!string.IsNullOrEmpty(edi.cobranza_uuid))
                this._ctacte_pago_persona = PagosDePersonaService.GetPorUUID(edi.cobranza_uuid, sesion);
            if (this._ctacte_pago_persona == null && edi.cobranza != null)
                this._ctacte_pago_persona = new PagosDePersonaService(edi.cobranza, almacenar_localmente, sesion);
            if (this._ctacte_pago_persona != null)
            {
                if (!this.CtactePagoPersona.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.CtactePagoPersona.Id.HasValue)
                    this.CtactePagoPersonaId = this.CtactePagoPersona.Id.Value;
            }
            #endregion pago de persona

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
            this.Observaciones = edi.observacion;

            this.CtacteValorId = edi.tipo_valor;

            //Todavia no se cargan los valores especificos de cada valor
            switch ((int)this.CtacteValorId)
            {
                case Definiciones.CuentaCorrienteValores.Cheque:
                    this.ChequeNroCheque = edi.nro_comprobante;
                    this.ChequeFechaPosdatado = edi.fecha_emision;
                    this.ChequeFechaVencimiento = edi.fecha_vencimiento;
                    break;
                case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                    this.TarjetaNro = edi.nro_comprobante;
                    this.TarjetaVencimiento = edi.fecha_vencimiento;

                    #region procesadora tarjeta
                    if (!string.IsNullOrEmpty(edi.procesadora_tarjeta_uuid))
                        this._ctacte_procesadora_tarjeta = CuentaCorrienteProcesadorasTarjetaService.GetPorUUID(edi.procesadora_tarjeta_uuid, sesion);
                    if (this._ctacte_procesadora_tarjeta == null && edi.procesadora_tarjeta != null)
                        this._ctacte_procesadora_tarjeta = new CuentaCorrienteProcesadorasTarjetaService(edi.procesadora_tarjeta, almacenar_localmente, sesion);

                    if (this._ctacte_procesadora_tarjeta != null)
                    {
                        if (!this._ctacte_procesadora_tarjeta.ExisteEnDB && almacenar_localmente)
                        {
                            //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                            throw new NotImplementedException("Debe guardarse localmente la entidad.");
                        }
                        if (this._ctacte_procesadora_tarjeta.Id.HasValue)
                            this.CtacteProcesadoraTarjetaId = this._ctacte_procesadora_tarjeta.Id.Value;
                    }
                    #endregion procesadora tarjeta

                    break;
                case Definiciones.CuentaCorrienteValores.RetencionIVA:
                case Definiciones.CuentaCorrienteValores.RetencionRenta:
                case Definiciones.CuentaCorrienteValores.RetencionSECP:
                    this.RetencionNroComprobante = edi.nro_comprobante;
                    this.RetencionFecha = edi.fecha_emision;
                    break;
            }
        }
        private CuentaCorrientePagosPersonaDetalleService(CTACTE_PAGOS_PERSONA_DETRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static CuentaCorrientePagosPersonaDetalleService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static CuentaCorrientePagosPersonaDetalleService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.CTACTE_PAGOS_PERSONA_DETCollection.GetAsArray(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + cabecera_id + " and " + CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", CuentaCorrientePagosPersonaDetalleService.Id_NombreCol);
            CuentaCorrientePagosPersonaDetalleService[] cppd = new CuentaCorrientePagosPersonaDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cppd[i] = new CuentaCorrientePagosPersonaDetalleService(rows[i]);
            return cppd;
        }
        #endregion GetPorCabecera

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._ctacte_pago_persona = null;
            this._ctacte_procesadora_tarjeta = null;
            this._moneda = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.CobranzaValor()
            {
                cobranza_uuid = this.CtactePagoPersona.GetOrCreateUUID(sesion),
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, CuentaCorrientePagosPersonaDetalleService.CotizacionMoneda_NombreCol, this.Id.Value, sesion),
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                monto = this.Monto.Value,
                observacion = this.Observaciones,
                tipo_valor = (int)this.CtacteValorId
            };

            switch ((int)this.CtacteValorId)
            {
                case Definiciones.CuentaCorrienteValores.Cheque:
                    e.nro_comprobante = this.ChequeNroCheque;
                    e.fecha_emision = this.ChequeFechaPosdatado;
                    e.fecha_vencimiento = this.ChequeFechaVencimiento;
                    break;
                case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                    e.nro_comprobante = this.TarjetaNro;
                    e.fecha_vencimiento = this.TarjetaVencimiento;
                    if (this.CtacteProcesadoraTarjetaId.HasValue)
                        e.procesadora_tarjeta_uuid = this.CtacteProcesadoraTarjeta.GetOrCreateUUID(sesion);
                    break;
                case Definiciones.CuentaCorrienteValores.RetencionIVA:
                case Definiciones.CuentaCorrienteValores.RetencionRenta:
                case Definiciones.CuentaCorrienteValores.RetencionSECP:
                    e.nro_comprobante = this.TarjetaNro;
                    e.fecha_emision = this.RetencionFecha;
                    break;
            }

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.CtactePagoPersona.Fecha,
                    moneda_uuid = this.Moneda.ToEDI().uuid,
                    compra = this.CotizacionMoneda
                };
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
                if (this.CtacteProcesadoraTarjetaId.HasValue)
                    e.procesadora_tarjeta = (EdiCBA.ProcesadoraTarjeta)this.CtacteProcesadoraTarjeta.ToEDI(nueva_profundidad, sesion);
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

        #region calcular monto neto
        private static decimal calculcarMontoNeto_POS(decimal pos_id, decimal tarjeta_id, decimal montoBruto)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal montoNeto = montoBruto;
                CTACTE_PROCESADORAS_TARJETARow tarjetasRow = sesion.Db.CTACTE_PROCESADORAS_TARJETACollection.GetRow(CuentaCorrienteProcesadorasTarjetaService.Id_NombreCol + " = " + tarjeta_id);
                decimal procesadoraId = tarjetasRow.PROCESADORA_ID;
                decimal procesadoraId_aux = tarjetasRow.PROCESADORA_ID;

                CTACTE_PROCESADORAS_TARJETA_ENTIDADRow procesadorasRow = sesion.Db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetRow(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.IDColumnName + " = " + procesadoraId);
                CTACTE_PROCESADORAS_TARJETA_ENTIDADRow procesadorasRow_aux = procesadorasRow;             
                CTACTE_POSRow posRow = sesion.Db.CTACTE_POSCollection.GetRow(CuentaCorrientePosService.Id_NombreCol + " = " + pos_id);
                CTACTE_TARJETAS_CONFIG_PROCESOSRow configuracionRow = sesion.Db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.GetRow(CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_IDColumnName + " = " + procesadoraId
                                                    + " and " + CuentaCorrienteTarjetasConfiguracionService.Modelo.POS_IDColumnName + " = " + pos_id);
                #region para cambio de datos
                // cambio datos
                // tipotarjeta credito debito
                // procesadoraId 1 - bancard
                // procesadoraId 2 - dinelco
                //--- SI ES DE PROCESADORA BANCARD(1) LA TARJETA PERO PASA POR RED DINELCO
                //--- SI ES DE PROCESADORA DINELCO(2) LA TARJETA PERO PASA POR RED INFONET

                if (configuracionRow == null)
                    throw new Exception("No se puede procesar la operación. La tarjeta y POS seleccionados no están configurados para ser procesados.");
                if (!configuracionRow.IsPROCESADORA_ID_RED_DINELCONull)
                {
                    procesadoraId_aux = configuracionRow.PROCESADORA_ID_RED_DINELCO;
                    procesadorasRow_aux = sesion.Db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetRow(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.IDColumnName + " = " + procesadoraId_aux);
                }
                // if (posRow.RED.ToString().Equals(CuentaCorrientePosService.red_infonet.ToString()) && procesadoraId == 2)//      SI ES PROCESADORA DINELCO Y LA TARJETA PASA POR RED INFONET, TOMA FRECUENCIA DE INFONET               {

                if (!configuracionRow.IsPROCESADORA_ID_RED_INFONETNull)
                {
                    procesadoraId_aux = configuracionRow.PROCESADORA_ID_RED_INFONET;

                    procesadorasRow_aux = sesion.Db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetRow(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.IDColumnName + " = " + procesadoraId_aux);
                }
                // cambio datos
                #endregion para cambio de datos

                bool esTarjetaCredito = tarjetasRow.ES_TARJETA_CREDITO.ToString().Equals(Definiciones.SiNo.Si);
                bool esMontoBruto = false;
                if (esTarjetaCredito)
                    esMontoBruto = procesadorasRow_aux.CRED_COMISION_SOB_IMP_BRUTO.Equals(Definiciones.SiNo.Si);
                else
                    esMontoBruto = procesadorasRow_aux.DEB_COMISION_SOB_IMP_BRUTO.Equals(Definiciones.SiNo.Si);

                if (!esMontoBruto)
                {
                    decimal comisionPorcentaje = configuracionRow.COMISION_PORC / 100;
                    decimal ivaPorcentaje = configuracionRow.IVA_SOBRE_COMISION_PORC / 100;
                    decimal rentaPorcentaje = configuracionRow.RENTA_SOBRE_IVA_PORC / 100;

                    decimal comision = montoBruto * comisionPorcentaje;
                    decimal iva = comision * ivaPorcentaje;
                    decimal renta = iva * rentaPorcentaje;

                    montoNeto = Math.Floor(montoBruto - comision - iva - renta);// redondeo hacia arriba
                }
                return montoNeto;
            }
        }
        #endregion calcular monto neto

        #region calcular fecha acreditacion DEPOSITO BANCARIO
        private static DateTime calcularFechaAcreditacion(decimal pos_id, decimal tarjeta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DateTime fecha_acreditacion = DateTime.Today;
                CTACTE_PROCESADORAS_TARJETARow tarjetasRow = sesion.Db.CTACTE_PROCESADORAS_TARJETACollection.GetRow(CuentaCorrienteProcesadorasTarjetaService.Id_NombreCol + " = " + tarjeta_id);
                decimal procesadoraId = tarjetasRow.PROCESADORA_ID;
                decimal procesadoraId_aux = tarjetasRow.PROCESADORA_ID;

                CTACTE_PROCESADORAS_TARJETA_ENTIDADRow procesadorasRow = sesion.Db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetRow(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.IDColumnName + " = " + procesadoraId);
                CTACTE_PROCESADORAS_TARJETA_ENTIDADRow procesadorasRow_aux = procesadorasRow;

                CTACTE_POSRow posRow = sesion.Db.CTACTE_POSCollection.GetRow(CuentaCorrientePosService.Id_NombreCol + " = " + pos_id);

                CTACTE_TARJETAS_CONFIG_PROCESOSRow configuracionRow = sesion.Db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.GetRow(CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_IDColumnName + " = " + procesadoraId
                                                    + " and " + CuentaCorrienteTarjetasConfiguracionService.Modelo.POS_IDColumnName + " = " + pos_id);
                bool esTarjetaCredito = tarjetasRow.ES_TARJETA_CREDITO.ToString().Equals(Definiciones.SiNo.Si);
                bool controlaDiaHabil = procesadorasRow.CONTROLA_DIA_HABIL.ToString().Equals(Definiciones.SiNo.Si);
                bool controlaFeriadoBancario = procesadorasRow.CONTROLA_FERIADO_BANCARIO.ToString().Equals(Definiciones.SiNo.Si);

                bool esPosDia = true;
                bool sobreBruto = true;

                decimal frecuencia = Definiciones.Error.Valor.EnteroPositivo;
                DateTime fecha = DateTime.Today;
                // if (posRow.RED.ToString().Equals(CuentaCorrientePosService.red_dinelco.ToString()) && procesadoraId == 1)//      SI ES PROCESADORA INFONET Y LA TARJETA PASA POR RED DINELCO, TOMA FRECUENCIA DE DINELCO               {
                if (!configuracionRow.IsPROCESADORA_ID_RED_DINELCONull)
                {
                    procesadoraId_aux = configuracionRow.PROCESADORA_ID_RED_DINELCO;
                    procesadorasRow_aux = sesion.Db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetRow(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.IDColumnName + " = " + procesadoraId_aux);
                }
                // if (posRow.RED.ToString().Equals(CuentaCorrientePosService.red_infonet.ToString()) && procesadoraId == 2)//      SI ES PROCESADORA DINELCO Y LA TARJETA PASA POR RED INFONET, TOMA FRECUENCIA DE INFONET               {

                if (!configuracionRow.IsPROCESADORA_ID_RED_INFONETNull)
                {
                    procesadoraId_aux = configuracionRow.PROCESADORA_ID_RED_INFONET;

                    procesadorasRow_aux = sesion.Db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetRow(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.IDColumnName + " = " + procesadoraId_aux);
                }

                if (esTarjetaCredito)
                {
                    esPosDia = procesadorasRow.CRED_COMISION_POS_DIA.ToString().Equals(Definiciones.SiNo.Si);
                    sobreBruto = procesadorasRow.CRED_COMISION_POS_DIA.ToString().Equals(Definiciones.SiNo.Si);

                    if (fecha.DayOfWeek == DayOfWeek.Monday)// LUNES
                        frecuencia = procesadorasRow_aux.CRED_LUNES_HORAS;
                    if (fecha.DayOfWeek == DayOfWeek.Tuesday)// MARTES
                        frecuencia = procesadorasRow_aux.CRED_MARTES_HORAS;

                    if (fecha.DayOfWeek == DayOfWeek.Wednesday)// MIERCOLES
                        frecuencia = procesadorasRow_aux.CRED_MIERCOLES_HORAS;

                    if (fecha.DayOfWeek == DayOfWeek.Thursday)// JUEVES
                        frecuencia = procesadorasRow_aux.CRED_JUEVES_HORAS;

                    if (fecha.DayOfWeek == DayOfWeek.Friday)// VIERNES
                        frecuencia = procesadorasRow_aux.CRED_VIERNES_HORAS;

                    if (fecha.DayOfWeek == DayOfWeek.Saturday)//SABADO
                        frecuencia = procesadorasRow_aux.CRED_SABADO_HORAS;

                    else if (fecha.DayOfWeek == DayOfWeek.Sunday)//DOMINGO
                        frecuencia = procesadorasRow_aux.CRED_DOMINGO_HORAS;
                }
                else
                {
                    esPosDia = procesadorasRow.DEB_COMISION_POS_DIA.ToString().Equals(Definiciones.SiNo.Si);
                    sobreBruto = procesadorasRow.DEB_COMISION_POS_DIA.ToString().Equals(Definiciones.SiNo.Si);

                    if (fecha.DayOfWeek == DayOfWeek.Monday)// LUNES
                        frecuencia = procesadorasRow_aux.DEB_LUNES_HORAS;
                    if (fecha.DayOfWeek == DayOfWeek.Tuesday)// MARTES
                        frecuencia = procesadorasRow_aux.DEB_MARTES_HORAS;

                    if (fecha.DayOfWeek == DayOfWeek.Wednesday)// MIERCOLES
                        frecuencia = procesadorasRow_aux.DEB_MIERCOLES_HORAS;

                    if (fecha.DayOfWeek == DayOfWeek.Thursday)// JUEVES
                        frecuencia = procesadorasRow_aux.DEB_JUEVES_HORAS;

                    if (fecha.DayOfWeek == DayOfWeek.Friday)// VIERNES
                        frecuencia = procesadorasRow_aux.DEB_VIERNES_HORAS;

                    if (fecha.DayOfWeek == DayOfWeek.Saturday)//SABADO
                        frecuencia = procesadorasRow_aux.DEB_SABADO_HORAS;

                    else if (fecha.DayOfWeek == DayOfWeek.Sunday)//DOMINGO
                        frecuencia = procesadorasRow_aux.DEB_DOMINGO_HORAS;
                }

                // CALCULAR FECHA
                if (!esPosDia) // es on line
                {
                    fecha_acreditacion = DateTime.Today;
                }
                else // es pos dia
                {
                    // procesadoraId 1 - bancard - infonet
                    // procesadoraId 2 - bepsa - dinelco
                    // 1 red dinelco
                    // 2 red infonet

                    fecha_acreditacion = fecha.AddHours((double)frecuencia);
                }

                #region controla dia habil y feriado bancario
                if (controlaFeriadoBancario) // es feriado bancario
                    fecha_acreditacion = fecha_acreditacion.AddDays(1);

                if (controlaDiaHabil)
                {
                    while (!EsDiaHabil(fecha_acreditacion))// mientras no sea dia habil, agrega un dia
                    {
                        fecha_acreditacion = fecha_acreditacion.AddDays(1);
                    }
                }

                #endregion controla dia habil y feriado bancario

                return fecha_acreditacion;

            }
        }
        #endregion calcular fecha acreditacion DEPOSITO BANCARIO

        #region esDiaHabil
        public static bool EsDiaHabil(DateTime p_fecha)
        {
            // Verificar si el día de la semana es sábado o domingo
            if (p_fecha.DayOfWeek == DayOfWeek.Saturday || p_fecha.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            else
            {
                return true;// si no es sabado o no es domingo
            }
        }
        #endregion esDiaHabil

        #region transferencia de Caja
        public static bool TransferenciaDeCaja_POS(DataRow cabeceraPago, CTACTE_PAGOS_PERSONA_DETRow rowDetalle, SessionService sesion, ref decimal vCasoTransferenciaId)
        {
            bool exito = false;

            vCasoTransferenciaId = Definiciones.Error.Valor.EnteroPositivo;
            decimal vCabeceraID = Definiciones.Error.Valor.EnteroPositivo;
            string vCasoEstado = string.Empty;

            CTACTE_PROCESADORAS_TARJETARow tarjetasRow = sesion.Db.CTACTE_PROCESADORAS_TARJETACollection.GetRow(CuentaCorrienteProcesadorasTarjetaService.Id_NombreCol + " = " + rowDetalle.CTACTE_PROCESADORA_TARJETA_ID);

            CTACTE_TARJETAS_CONFIG_PROCESOSRow configuracionRow = sesion.Db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.GetRow(CuentaCorrienteTarjetasConfiguracionService.Modelo.POS_IDColumnName + " = " + tarjetasRow.PROCESADORA_ID
                                                + " and " + CuentaCorrienteTarjetasConfiguracionService.Modelo.POS_IDColumnName + " = " + rowDetalle.POS_ID);
            DataTable dtCajaSucursal = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + configuracionRow.CTACTE_CAJA_ID, string.Empty);
            System.Collections.Hashtable campos = new System.Collections.Hashtable();

            #region cabecera de Transferencia
            decimal sucursalOrigen = decimal.Parse(cabeceraPago[PagosDePersonaService.SucursalId_NombreCol].ToString());
            decimal sucursalDestino = decimal.Parse(dtCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol].ToString()); //configuracionRow.;
            decimal usuarioId = sesion.Usuario.ID;
            decimal textoPredefinidoId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.IdConceptoProceTarjTransfCaja);

            string observacion = "Transferencia de caja automática. Relacionada al caso " + decimal.Parse(cabeceraPago[PagosDePersonaService.CasoId_NombreCol].ToString());

            decimal cajaSucursalOrigen = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(decimal.Parse(cabeceraPago[PagosDePersonaService.SucursalId_NombreCol].ToString()), decimal.Parse(cabeceraPago[PagosDePersonaService.FuncionarioCobradorId_NombreCol].ToString()));
            decimal cajaSucursalDestino = configuracionRow.CTACTE_CAJA_ID;

            decimal fondoFijoOrigen = Definiciones.Error.Valor.EnteroPositivo;
            decimal fondoFijoDestino = Definiciones.Error.Valor.EnteroPositivo;

            decimal cajaTesoreriaOrigen = Definiciones.Error.Valor.EnteroPositivo;
            decimal cajaTesoreriaDestino = Definiciones.Error.Valor.EnteroPositivo;

            campos.Add(TransferenciaCajasSucursalService.SucursalOrigenId_NombreCol, sucursalOrigen);
            campos.Add(TransferenciaCajasSucursalService.SucursalDestinoId_NombreCol, sucursalDestino);
            campos.Add(TransferenciaCajasSucursalService.UsuarioId_NombreCol, usuarioId);
            campos.Add(TransferenciaCajasSucursalService.Fecha_NombreCol, DateTime.Now);
            campos.Add(TransferenciaCajasSucursalService.Observacion_NombreCol, observacion);

            campos.Add(TransferenciaCajasSucursalService.CajaSucursalOrigenId_NombreCol, cajaSucursalOrigen);

            if (fondoFijoOrigen != Definiciones.Error.Valor.EnteroPositivo)
                campos.Add(TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol, fondoFijoOrigen);

            if (cajaTesoreriaOrigen != Definiciones.Error.Valor.EnteroPositivo)
                campos.Add(TransferenciaCajasSucursalService.CajaTesoOrigenId_NombreCol, cajaTesoreriaOrigen);

            campos.Add(TransferenciaCajasSucursalService.CajaSucursalDestinoId_NombreCol, cajaSucursalDestino);

            if (fondoFijoDestino != Definiciones.Error.Valor.EnteroPositivo)
                campos.Add(TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol, fondoFijoDestino);

            if (cajaTesoreriaDestino != Definiciones.Error.Valor.EnteroPositivo)
                campos.Add(TransferenciaCajasSucursalService.CajaTesoDestinoId_NombreCol, cajaTesoreriaDestino);

            if (textoPredefinidoId != Definiciones.Error.Valor.EnteroPositivo)
                campos.Add(TransferenciaCajasSucursalService.TextoPredefinidoId_NombreCol, textoPredefinidoId);

            //Guardar los datos
            exito = TransferenciaCajasSucursalService.Guardar(campos, true, ref vCasoTransferenciaId, ref vCasoEstado, sesion);

            #endregion cabecera de Transferencia

            #region obtener caso creado
            DataTable caso = TransferenciaCajasSucursalService.GetTransferenciaCajasDataTable(TransferenciaCajasSucursalService.CasoId_NombreCol + " = " + vCasoTransferenciaId, string.Empty, sesion);
            vCabeceraID = (decimal)caso.Rows[0][TransferenciaCajasSucursalService.Id_NombreCol];
            #endregion obtener caso creado

            #region detalle de Transferencia
            if (exito)// si se creo el caso de transferencia, insertar detalles
            {
                System.Collections.Hashtable camposDet = new System.Collections.Hashtable();
                decimal monedaId = rowDetalle.MONEDA_ID;
                decimal cotizacion = CotizacionesService.GetCotizacionMonedaVenta(monedaId);
                decimal monto = rowDetalle.MONTO;
                camposDet.Add(TransferenciaCajasSucursalDetalleService.TransfCajaSucId_NombreCol, vCabeceraID);
                camposDet.Add(TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol, monedaId);
                camposDet.Add(TransferenciaCajasSucursalDetalleService.Monto_NombreCol, monto);
                camposDet.Add(TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol, cotizacion);
                camposDet.Add(TransferenciaCajasSucursalDetalleService.CtaCteValorId_NombreCol, (decimal)Definiciones.CuentaCorrienteValores.POS);

                TransferenciaCajasSucursalDetalleService.Guardar(camposDet, sesion);
            }
            #endregion detalle de Transferencia

            return exito;
        }
        #endregion transferencia de Caja

        #region transferencia de Caja agrupado
        // se llama al cerrar una caja sucursal
        public static bool TransferenciaDeCaja_POS_agrupado(decimal sucursalId, decimal funcionarioCobradorId, SessionService sesion)
        {
            bool exito = false;
            decimal sucursalOrigen = sucursalId;
            decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
            decimal vCabeceraID = Definiciones.Error.Valor.EnteroPositivo;
            decimal vMonedaId = Definiciones.Error.Valor.EnteroPositivo;

            string vCasoEstado = string.Empty;

            CTACTE_TARJETAS_CONFIG_PROCESOSRow[] configuraciones = sesion.Db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.GetAsArray(string.Empty, string.Empty);

            foreach (CTACTE_TARJETAS_CONFIG_PROCESOSRow rowConfiguracion in configuraciones)// obtenemos todas las configuraciones de tarjeta
            {
                decimal totalNeto = 0;
                // recorremos cada configuracion y consultamos los cobros realizados para cada una 
                #region calcular monto a transferir
                string clausula = TransferenciaCajaSucursalId_NombreCol + " is null ";
                // obtenemos los detalles de pago que faltan ser procesados para la transferencia entre cajas
                DataTable detalles = getPagoPersonaDetalle_valorPOS(sucursalId, funcionarioCobradorId, rowConfiguracion.POS_ID, rowConfiguracion.PROCESADORA_ID, clausula, sesion);
                foreach (DataRow rowDetail in detalles.Rows)
                {
                    totalNeto += decimal.Parse(rowDetail[CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol].ToString());
                    vMonedaId = decimal.Parse(rowDetail[CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol].ToString());
                }
                #endregion calcular monto a transferir

                #region crear cabecera de Transferencia
                if (totalNeto > 0)
                {
                    DataTable dtCajaSucursal = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + rowConfiguracion.CTACTE_CAJA_ID, string.Empty);
                    System.Collections.Hashtable campos = new System.Collections.Hashtable();

                    decimal sucursalDestino = decimal.Parse(dtCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol].ToString());
                    decimal usuarioId = sesion.Usuario.ID;
                    decimal textoPredefinidoId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.IdConceptoProceTarjTransfCaja);

                    string observacion = "Transferencia de caja automática Caja Cobrador a Caja Procesadora, de fecha " + DateTime.Now;

                    decimal cajaSucursalOrigen = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(sucursalId, funcionarioCobradorId);
                    decimal cajaSucursalDestino = rowConfiguracion.CTACTE_CAJA_ID;

                    decimal fondoFijoOrigen = Definiciones.Error.Valor.EnteroPositivo;
                    decimal fondoFijoDestino = Definiciones.Error.Valor.EnteroPositivo;

                    decimal cajaTesoreriaOrigen = Definiciones.Error.Valor.EnteroPositivo;
                    decimal cajaTesoreriaDestino = Definiciones.Error.Valor.EnteroPositivo;

                    campos.Add(TransferenciaCajasSucursalService.SucursalOrigenId_NombreCol, sucursalOrigen);
                    campos.Add(TransferenciaCajasSucursalService.SucursalDestinoId_NombreCol, sucursalDestino);
                    campos.Add(TransferenciaCajasSucursalService.UsuarioId_NombreCol, usuarioId);
                    campos.Add(TransferenciaCajasSucursalService.Fecha_NombreCol, DateTime.Now);
                    campos.Add(TransferenciaCajasSucursalService.Observacion_NombreCol, observacion);

                    campos.Add(TransferenciaCajasSucursalService.CajaSucursalOrigenId_NombreCol, cajaSucursalOrigen);

                    if (fondoFijoOrigen != Definiciones.Error.Valor.EnteroPositivo)
                        campos.Add(TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol, fondoFijoOrigen);

                    if (cajaTesoreriaOrigen != Definiciones.Error.Valor.EnteroPositivo)
                        campos.Add(TransferenciaCajasSucursalService.CajaTesoOrigenId_NombreCol, cajaTesoreriaOrigen);

                    campos.Add(TransferenciaCajasSucursalService.CajaSucursalDestinoId_NombreCol, cajaSucursalDestino);

                    if (fondoFijoDestino != Definiciones.Error.Valor.EnteroPositivo)
                        campos.Add(TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol, fondoFijoDestino);

                    if (cajaTesoreriaDestino != Definiciones.Error.Valor.EnteroPositivo)
                        campos.Add(TransferenciaCajasSucursalService.CajaTesoDestinoId_NombreCol, cajaTesoreriaDestino);

                    if (textoPredefinidoId != Definiciones.Error.Valor.EnteroPositivo)
                        campos.Add(TransferenciaCajasSucursalService.TextoPredefinidoId_NombreCol, textoPredefinidoId);

                    //Guardar los datos
                    exito = TransferenciaCajasSucursalService.Guardar(campos, true, ref vCasoId, ref vCasoEstado, sesion);

                #endregion crear cabecera de Transferencia agrupado

                    #region obtener caso creado
                    DataTable caso = TransferenciaCajasSucursalService.GetTransferenciaCajasDataTable(TransferenciaCajasSucursalService.CasoId_NombreCol + " = " + vCasoId, string.Empty, sesion);
                    vCabeceraID = (decimal)caso.Rows[0][TransferenciaCajasSucursalService.Id_NombreCol];
                    #endregion obtener caso creado

                    #region insertar detalle de Transferencia
                    if (exito)// si se creo el caso de transferencia, insertar detalles
                    {
                        System.Collections.Hashtable camposDet = new System.Collections.Hashtable();
                        decimal monedaId = vMonedaId;
                        decimal cotizacion = CotizacionesService.GetCotizacionMonedaVenta(monedaId);
                        decimal monto = totalNeto;
                        camposDet.Add(TransferenciaCajasSucursalDetalleService.TransfCajaSucId_NombreCol, vCabeceraID);
                        camposDet.Add(TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol, monedaId);
                        camposDet.Add(TransferenciaCajasSucursalDetalleService.Monto_NombreCol, monto);
                        camposDet.Add(TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol, cotizacion);
                        camposDet.Add(TransferenciaCajasSucursalDetalleService.CtaCteValorId_NombreCol, (decimal)Definiciones.CuentaCorrienteValores.POS);

                        TransferenciaCajasSucursalDetalleService.Guardar(camposDet, sesion);
                    }
                    #endregion insertar detalle de Transferencia

                    #region avanzar transferencia de Caja a estado CERRADO
                    avanzarEstadosTransferenciaCaja(vCasoId, sesion);
                    #endregion avanzar transferencia de Caja a estado CERRADO

                    #region actualizar detalles de los pagos procesados, indicando el id de la transferencia de caja relacionada
                    foreach (DataRow rowDetail in detalles.Rows)
                    {
                        CTACTE_PAGOS_PERSONA_DETRow detallePago = sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.GetByPrimaryKey(decimal.Parse(rowDetail[CuentaCorrientePagosPersonaDetalleService.Id_NombreCol].ToString()));
                        detallePago.TRANSFERENCIA_CAJA_SUCURSAL_ID = vCabeceraID;
                        sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.Update(detallePago);
                    }
                    #endregion actualizar detalles de los pagos procesados, indicando el id de la transferencia de caja relacionada

                }
            }

            return exito;
        }
        #endregion transferencia de Caja agrupado

        #region DepositoBancario_POS
        public static bool DepositoBancario_POS(DataRow cabeceraPago, CTACTE_PAGOS_PERSONA_DETRow rowDetalle, SessionService sesion, ref decimal vCasoId)
        {
            bool exito = false;
            decimal vCabeceraId = Definiciones.Error.Valor.EnteroPositivo;
            vCasoId = Definiciones.Error.Valor.EnteroPositivo;
            string vCasoEstado = string.Empty;

            CTACTE_PROCESADORAS_TARJETARow tarjetasRow = sesion.Db.CTACTE_PROCESADORAS_TARJETACollection.GetRow(CuentaCorrienteProcesadorasTarjetaService.Id_NombreCol + " = " + rowDetalle.CTACTE_PROCESADORA_TARJETA_ID);

            CTACTE_TARJETAS_CONFIG_PROCESOSRow configuracionRow = sesion.Db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.GetRow(CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_IDColumnName + " = " + tarjetasRow.PROCESADORA_ID
                                                + " and " + CuentaCorrienteTarjetasConfiguracionService.Modelo.POS_IDColumnName + " = " + rowDetalle.POS_ID);
            DataTable dtCajaSucursal = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + configuracionRow.CTACTE_CAJA_ID, string.Empty);
            System.Collections.Hashtable campos = new System.Collections.Hashtable();

            if (!CuentaCorrienteProcesadorasTarjetaEntidadService.EsProcesoPosDia(tarjetasRow.PROCESADORA_ID, tarjetasRow.ES_TARJETA_CREDITO.Equals(Definiciones.SiNo.Si)))
            {// si es procesamiento online, hace el deposito bancario.
                decimal sucursalDestino = decimal.Parse(dtCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol].ToString());
                decimal funcionarioId = decimal.Parse(cabeceraPago[PagosDePersonaService.FuncionarioCobradorId_NombreCol].ToString());

                string observacion = "Depósito bancario por pago procesado mediante POS. Relacionada al caso " + decimal.Parse(cabeceraPago[PagosDePersonaService.CasoId_NombreCol].ToString());

                #region get datos origen
                //  decimal cajaSucursalOrigen = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(decimal.Parse(cabeceraPago[PagosDePersonaService.SucursalId_NombreCol].ToString()), decimal.Parse(cabeceraPago[PagosDePersonaService.FuncionarioCobradorId_NombreCol].ToString()));
                decimal cajaSucursalOrigen = configuracionRow.CTACTE_CAJA_ID;
                #endregion get datos origen

                #region get datos de cuenta destino
                DataTable dtCuentaDestino = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTableTodo(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + configuracionRow.CTACTE_BANCARIA_ID_DEST, string.Empty, true);
                decimal cuentaDestinoId = decimal.Parse(dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.IDColumnName].ToString());
                decimal bancoDestinoId = decimal.Parse(dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.CTACTE_BANCO_IDColumnName].ToString());
                string cuentaNumeroDestino = dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.NUMERO_CUENTAColumnName].ToString();
                decimal cuentaDestinoMonedaId = decimal.Parse(dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.MONEDA_IDColumnName].ToString());
                decimal sucursalDestinoId = decimal.Parse(dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.SUCURSAL_IDColumnName].ToString());
                #endregion get datos de cuenta destino


                try
                {
                    #region guardar cabecera de deposito
                    campos.Add(DepositosBancariosService.SucursalId_NombreCol, sucursalDestinoId);
                    campos.Add(DepositosBancariosService.CtacteBancariaId_NombreCol, cuentaDestinoId);
                    campos.Add(DepositosBancariosService.DepositoDesdeSuc_NombreCol, Definiciones.SiNo.Si);
                    campos.Add(DepositosBancariosService.CrearAnticipoPersona_NombreCol, Definiciones.SiNo.No);
                    campos.Add(DepositosBancariosService.CtacteCajaSucursalId_NombreCol, cajaSucursalOrigen);
                    campos.Add(DepositosBancariosService.Fecha_NombreCol, DateTime.Now);
                    campos.Add(DepositosBancariosService.FuncionarioId_NombreCol, funcionarioId);
                    campos.Add(DepositosBancariosService.NroComprobante_NombreCol, string.Empty);
                    campos.Add(DepositosBancariosService.Observacion_NombreCol, observacion);
                    campos.Add(DepositosBancariosService.TextoPredefinidoId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.IdConceptoProcTarjDepoBanc));
                    //      campos.Add(DepositosBancariosService.PersonaId_NombreCol, );
                    //Guardar los datos
                    exito = DepositosBancariosService.Guardar(campos, true, ref vCasoId, ref vCasoEstado, sesion); //2

                    #endregion guardar cabecera de deposito

                    #region obtener caso creado
                    DataTable caso = DepositosBancariosService.GetDepositosBancariosDataTable(DepositosBancariosService.CasoId_NombreCol + " = " + vCasoId, string.Empty, sesion);
                    vCabeceraId = (decimal)caso.Rows[0][DepositosBancariosService.Id_NombreCol];
                    #endregion obtener caso creado

                    #region guardar detalle de deposito
                    System.Collections.Hashtable camposDet = new System.Collections.Hashtable();

                    camposDet.Add(DepositosBancariosDetalleService.DepositoBancarioId_NombreCol, vCabeceraId);
                    camposDet.Add(DepositosBancariosDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.POS);

                    if (rowDetalle.MONTO_NETO <= 0)
                        throw new Exception("El monto debe ser positivo.");

                    camposDet.Add(DepositosBancariosDetalleService.Importe_NombreCol, rowDetalle.MONTO_NETO);

                    DepositosBancariosDetalleService.Guardar(camposDet, sesion);
                    #endregion guardar detalle de deposito
                }
                catch (Exception e)
                {
                    throw;
                }
            }// si el procesamiento no es ONLINE, se realiza en un proceso externo
            return exito;
        }

        #endregion DepositoBancario_POS

        #region deposito bancario POS agrupado
        // se llama con un webservice
        // crea un caso de deposito bancario, por cada configuracion existente con la sumatoria de importes en detalle de pago de personas segun: valor pos, sucursal y funcionario
        public static bool DepositoBancario_POS_agrupado(decimal sucursalId, decimal funcionarioCobradorId, out string  casosCreados, out decimal casosFallidos)
        {
            bool exito = false;
            bool exitoCaso = false;

            decimal sucursalOrigen = sucursalId;
            decimal vCabeceraID = Definiciones.Error.Valor.EnteroPositivo;
            decimal vMonedaId = Definiciones.Error.Valor.EnteroPositivo;
            decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;


            string vCasoEstado = string.Empty;
            // obtenemos todas las configuraciones de tarjeta
            CTACTE_TARJETAS_CONFIG_PROCESOSRow[] configuraciones = (new SessionService()).Db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.GetAsArray(string.Empty, string.Empty);
             casosCreados = string.Empty;
             casosFallidos = 0;

             //Inicializar sesion para soporte
             LogueoService logueo = new LogueoService(string.Empty, string.Empty, string.Empty);
             logueo.AsignarVariablesDeSesion();
            foreach (CTACTE_TARJETAS_CONFIG_PROCESOSRow rowConfiguracion in configuraciones)
            {
                using (SessionService sesion = new SessionService())
                {
                    // controlamos la sesion por cada posible caso a crear de deposito bancario
                    try
                    {
                        sesion.BeginTransaction();

                        decimal totalNeto = 0;
                        string observacion = "Depósito bancario por pagos procesados mediante POS";

                        #region get datos origen
                        decimal cajaSucursalOrigen = rowConfiguracion.CTACTE_CAJA_ID;
                        #endregion get datos origen

                        #region get datos de cuenta destino
                        DataTable dtCuentaDestino = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTableTodo(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + rowConfiguracion.CTACTE_BANCARIA_ID_DEST, string.Empty, true);
                        decimal cuentaDestinoId = decimal.Parse(dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.IDColumnName].ToString());
                        decimal bancoDestinoId = decimal.Parse(dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.CTACTE_BANCO_IDColumnName].ToString());
                        string cuentaNumeroDestino = dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.NUMERO_CUENTAColumnName].ToString();
                        decimal cuentaDestinoMonedaId = decimal.Parse(dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.MONEDA_IDColumnName].ToString());
                        decimal sucursalDestinoId = decimal.Parse(dtCuentaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Modelo.SUCURSAL_IDColumnName].ToString());
                        #endregion get datos de cuenta destino

                        // recorremos cada configuracion y consultamos los cobros realizados para cada una
                        #region calcular monto a transferir
                        string clausula = "to_date("+FechaAcreditacion_NombreCol + ", 'dd/MM/yyyy') <= '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and " + DepositoBancarioId_NombreCol + " is null ";
                        DataTable detalles = getPagoPersonaDetalle_valorPOS(sucursalId, funcionarioCobradorId, rowConfiguracion.POS_ID, rowConfiguracion.PROCESADORA_ID, clausula, sesion);
                        foreach (DataRow rowDetail in detalles.Rows)
                        {
                            totalNeto += decimal.Parse(rowDetail[CuentaCorrientePagosPersonaDetalleService.MontoNeto_NombreCol].ToString());
                            vMonedaId = decimal.Parse(rowDetail[CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol].ToString());
                        }
                        #endregion calcular monto a transferir

                        #region guardar cabecera de deposito
                        if (totalNeto > 0)
                        {
                            System.Collections.Hashtable campos = new System.Collections.Hashtable();
                            campos.Add(DepositosBancariosService.SucursalId_NombreCol, sucursalDestinoId);
                            campos.Add(DepositosBancariosService.CtacteBancariaId_NombreCol, cuentaDestinoId);
                            campos.Add(DepositosBancariosService.DepositoDesdeSuc_NombreCol, Definiciones.SiNo.Si);
                            campos.Add(DepositosBancariosService.CrearAnticipoPersona_NombreCol, Definiciones.SiNo.No);
                            campos.Add(DepositosBancariosService.CtacteCajaSucursalId_NombreCol, cajaSucursalOrigen);
                            campos.Add(DepositosBancariosService.Fecha_NombreCol, DateTime.Now);
                            campos.Add(DepositosBancariosService.FuncionarioId_NombreCol, funcionarioCobradorId);
                            campos.Add(DepositosBancariosService.NroComprobante_NombreCol, string.Empty);
                            campos.Add(DepositosBancariosService.Observacion_NombreCol, observacion);
                            campos.Add(DepositosBancariosService.TextoPredefinidoId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.IdConceptoProcTarjDepoBanc));

                            //Guardar los datos
                            exitoCaso = DepositosBancariosService.Guardar(campos, true, ref vCasoId, ref vCasoEstado, sesion);

                        #endregion guardar cabecera de deposito

                            #region obtener caso creado
                            DataTable caso = DepositosBancariosService.GetDepositosBancariosDataTable(DepositosBancariosService.CasoId_NombreCol + " = " + vCasoId, string.Empty, sesion);
                            vCabeceraID = (decimal)caso.Rows[0][DepositosBancariosService.Id_NombreCol];
                            #endregion obtener caso creado

                            #region guardar detalle de deposito
                            System.Collections.Hashtable camposDet = new System.Collections.Hashtable();

                            camposDet.Add(DepositosBancariosDetalleService.DepositoBancarioId_NombreCol, vCabeceraID);
                            camposDet.Add(DepositosBancariosDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.POS);

                            if (totalNeto <= 0)
                                throw new Exception("El monto debe ser positivo.");

                            camposDet.Add(DepositosBancariosDetalleService.Importe_NombreCol, totalNeto);

                            DepositosBancariosDetalleService.Guardar(camposDet, sesion);
                            #endregion guardar detalle de deposito

                            #region pasar a APROBADO el deposito bancario
                            exitoCaso = avanzarEstadosDepositoBancario(vCasoId, sesion);
                            #endregion pasar a APROBADO el deposito bancario

                            #region actualizar detalles de los pagos procesados, indicando el id de deposito bancario relacionado
                            foreach (DataRow rowDetail in detalles.Rows)
                            {
                                CTACTE_PAGOS_PERSONA_DETRow detallePago = sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.GetByPrimaryKey(decimal.Parse(rowDetail[CuentaCorrientePagosPersonaDetalleService.Id_NombreCol].ToString()));
                                detallePago.DEPOSITO_BANCARIO_ID = vCabeceraID;
                                sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.Update(detallePago);
                            }
                            #endregion actualizar detalles de los pagos procesados, indicando el id de deposito bancario relacionado

                            casosCreados += casosCreados.Equals(string.Empty) ? vCabeceraID.ToString() : ", " + vCabeceraID;
                            sesion.CommitTransaction();
                            exito = exito || exitoCaso;
                        }
                    }
                    catch (Exception e)
                    {
                        casosFallidos++;
                        sesion.RollbackTransaction();
                    }
                }
            }

            return exito;
        }

        #endregion deposito bancario POS agrupado

        #region avanza estados transferenciaPOS
        private static bool avanzarEstadosTransferenciaCaja(decimal vCasoId, SessionService sesion)
        {
            #region avanzar cambio de estados
            string mensaje = "Transición automática";
            bool exito = false;
            TransferenciaCajasSucursalService transferencia = new TransferenciaCajasSucursalService();
            CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();

            exito = transferencia.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
            if (exito)
            {
                // borrador a pendiente
                mensaje = "Transición automática";
                exito = ToolbarFlujo.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, mensaje, sesion);
            }
            // pendiente a En-Proceso
            exito = transferencia.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.EnProceso, false, out mensaje, sesion);

            if (exito)
            {
                // pendiente a EnProceso
                mensaje = "Transición automática";
                exito = ToolbarFlujo.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.EnProceso, mensaje, sesion);
            }
            exito = transferencia.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);

            if (exito)
            {
                // enProceso a cerrado
                mensaje = "Transición automática";
                exito = ToolbarFlujo.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Cerrado, mensaje, sesion);
            }
            if (exito)
                transferencia.EjecutarAccionesLuegoDeCambioEstado(vCasoId, Definiciones.EstadosFlujos.Cerrado, sesion);

            #endregion avanzar cambio de estados
            return exito;
        }
        #endregion avanza estados transferenciaPOS

        #region avanza estados DepositoBancarioPOS
        private static bool avanzarEstadosDepositoBancario(decimal vCasoId, SessionService sesion)
        {
            bool exito = false;

            string mensaje = "Transición automática";
            DepositosBancariosService depo = new DepositosBancariosService();
            CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();
            // borrador a pendiente
            exito = depo.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);

            if (exito)
            {
                mensaje = "Transición automática";
                exito = ToolbarFlujo.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, mensaje, sesion);
            }
            // pendiente a PreAprobado
            exito = depo.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.PreAprobado, false, out mensaje, sesion);
            if (exito)
            {
                mensaje = "Transición automática";
                exito = ToolbarFlujo.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.PreAprobado, mensaje, sesion);
            }
            // PreAprobado a Aprobado
            exito = depo.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
            if (exito)
            {
                mensaje = "Transición automática";
                exito = ToolbarFlujo.ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, mensaje, sesion);
            }

            return exito;
        }
        #endregion avanza estados DepositoBancarioPOS

        #region getDetalles_POS
        public static DataTable getPagoPersonaDetalle_valorPOS(decimal sucursalId, decimal funcionarioCobradorId, decimal posId, decimal procesadoraId, string clausulas, SessionService sesion)
        {
            DataTable dt = null;
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("select ppd.* \n");
            query.Append("from " + PagosDePersonaService.Nombre_Tabla + " pp, \n");
            query.Append("     " + CuentaCorrientePagosPersonaDetalleService.Nombre_Tabla + " ppd \n");
            query.Append("where pp." + PagosDePersonaService.Id_NombreCol + " = ppd." + CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " \n");
            query.Append("      and ppd." + CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.POS + " \n");
            query.Append("      and ppd." + CuentaCorrientePagosPersonaDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' \n");
            query.Append("      and pp." + PagosDePersonaService.SucursalId_NombreCol + " = " + sucursalId + "\n");
            query.Append("      and pp." + PagosDePersonaService.FuncionarioCobradorId_NombreCol + " = " + funcionarioCobradorId + " \n");
            query.Append("      and ppd." + CuentaCorrientePagosPersonaDetalleService.PosId_NombreCol + " = " + posId + " \n");
            //query.Append("      and ppd." + CuentaCorrientePagosPersonaDetalleService.DepositoBancarioId_NombreCol + " is null \n");        
            query.Append("      and ppd." + CuentaCorrientePagosPersonaDetalleService.CtacteProcesadoraTarjetaId_NombreCol + " = " + procesadoraId + " \n");
            if (!clausulas.Equals(string.Empty))
                query.Append(" and " + clausulas);

            dt = sesion.Db.EjecutarQuery(query.ToString());
            return dt;
        }
        #endregion getDetalles_POS

    }
}