using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Giros;
using System.Collections;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCajasTesoreriaMovimientosService
    {
        #region GetCuentaCorrienteCajasTesoreriaMovimientosDataTable
        /// <summary>
        /// Gets the cuenta corriente cajas tesoreria movimientos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCuentaCorrienteCajasTesoreriaMovimientosDataTable(string clausulas, string orden)
        {
            return CuentaCorrienteCajasTesoreriaMovimientosService.GetCuentaCorrienteCajasTesoreriaMovimientosDataTable2(clausulas, orden);
        }

        public static DataTable GetCuentaCorrienteCajasTesoreriaMovimientosDataTable2(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsDataTable(clausulas, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrienteCajasTesoreriaMovimientosDataTable

        #region GetCuentaCorrienteCajasTesoreriaMovimientosInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente cajas tesoreria movimientos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetCuentaCorrienteCajasTesoreriaMovimientosInfoCompleta(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = CuentaCorrienteCajasTesoreriaMovimientosService.VistaCtacteChequeRecibidoActivo_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                    if (clausulas.Length > 0)
                        where += " and (" + clausulas + ")";
                    return sesion.Db.CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.GetAsDataTable(where, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        public static DataTable GetCuentaCorrienteCajasTesoreriaMovimientosInfoCompleta2(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    string where = CuentaCorrienteCajasTesoreriaMovimientosService.VistaCtacteChequeRecibidoActivo_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                    if (clausulas.Length > 0)
                        where += " and (" + clausulas + ")";
                    return sesion.Db.CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.GetAsDataTable(where, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetCuentaCorrienteCajasTesoreriaMovimientosInfoCompleta

        #region Egreso
        /// <summary>
        /// Egresoes the specified ctacte_caja_tesoreria_id.
        /// </summary>
        /// <param name="ctacte_caja_tesoreria_id">The ctacte_caja_tesoreria_id.</param>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="registro_cabecera_id">The registro_cabecera_id.</param>
        /// <param name="registro_detalle_id">The registro_detalle_id.</param>
        /// <param name="ctacte_valor_id">The ctacte_valor_id.</param>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="cotizacion_moneda">The cotizacion_moneda.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="fecha">The fecha.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal Egreso(decimal ctacte_caja_tesoreria_id, int flujo_id, string tabla_id, decimal registro_cabecera_id, decimal registro_detalle_id, decimal ctacte_valor_id, decimal ctacte_cheque_recibido_id, decimal moneda_id, decimal cotizacion_moneda, decimal monto, DateTime fecha, SessionService sesion)
        {
            try
            {
                CuentaCorrienteChequesRecibidosService ctacteCheque = new CuentaCorrienteChequesRecibidosService();
                CTACTE_CAJAS_TESORERIA_MOVRow row = new CTACTE_CAJAS_TESORERIA_MOVRow();
                string clausulas;
                string valorAnterior = string.Empty;
                bool insertarNuevo = true;
                int tipo_valor;

                tipo_valor = Convert.ToInt32(ctacte_valor_id);

                #region Control de Saldo en Efectivo
                if (!RolesService.Tiene("CTACTE CAJAS TESORERIA NO CONTROLAR SALDO EFECTIVO"))
                {
                    DataTable dtSaldo;
                    bool tieneSaldo = true;
                    decimal saldo = 0;
                    if (tipo_valor == Definiciones.CuentaCorrienteValores.Efectivo)
                    {
                        string query = "select nvl(sum(nvl(ct.ingreso,0))-sum(nvl(ct.egreso,0)),0) as saldo from Ctacte_Cajas_Tesoreria_Mov ct ";
                        query += " where ct.moneda_id =" + moneda_id + " and ";
                        query += " ct.ctacte_valor_id =" + tipo_valor + " and ";
                        query += " ct.ctacte_caja_tesoreria_id = " + ctacte_caja_tesoreria_id;
                        dtSaldo = sesion.db.EjecutarQuery(query);
                        if (dtSaldo.Rows.Count > 0)
                        {
                            saldo = Math.Round(decimal.Parse(dtSaldo.Rows[0]["saldo"].ToString()), 4);
                            if (monto > saldo)
                            {
                                tieneSaldo = false;
                            }
                        }
                        else
                        {
                            tieneSaldo = false;
                        }

                        if (!tieneSaldo)
                            throw new Exception("La caja No tiene saldo Suficiente para realizar la operacion");
                    }
                }
                #endregion Control de Saldo en Efectivo

                if (flujo_id.Equals(Definiciones.Error.Valor.IntPositivo))
                {
                    if (tabla_id.Equals(CuentaCorrienteChequesRecibidosService.Nombre_Tabla))
                    {
                        //Si no se especifica el flujo se trata de una efectivizacion de cheque
                        if (!ctacte_valor_id.Equals(Definiciones.CuentaCorrienteValores.Cheque))
                            throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.Egreso. Únicamente se puede efectivizar cheques sin utilizar un flujo");

                        //Buscar el ingreso del cheque a la caja
                        clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CtacteCajaTesoreriaId_NombreCol + " = " + ctacte_caja_tesoreria_id + " and " +
                                    CuentaCorrienteCajasTesoreriaMovimientosService.CtacteChequeRecibidoId_NombreCol + " = " + ctacte_cheque_recibido_id + " and " +
                                    CuentaCorrienteCajasTesoreriaMovimientosService.FechaEgreso_NombreCol + " is null ";
                        row = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsArray(clausulas, string.Empty)[0];
                        valorAnterior = row.ToString();
                        insertarNuevo = false;

                        row.EGRESO = row.INGRESO;
                        row.FECHA_EGRESO = fecha;

                        if (row.OBSERVACION != null && !row.OBSERVACION.Equals(string.Empty)) row.OBSERVACION += ". ";
                        row.OBSERVACION += "Egreso por efectivización. ";
                    }
                }
                else
                {
                    switch (flujo_id)
                    {
                        case Definiciones.FlujosIDs.DEPOSITO_BANCARIO:
                            #region
                            DataTable dtDepositoBancario = DepositosBancariosService.GetDepositosBancariosInfoCompleta(DepositosBancariosService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty, sesion);
                            
                            switch (tipo_valor)
                            {
                                case Definiciones.CuentaCorrienteValores.Efectivo:
                                case Definiciones.CuentaCorrienteValores.Ajuste:
                                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                                    valorAnterior = Definiciones.Log.RegistroNuevo;
                                    insertarNuevo = true;

                                    row.EGRESO = monto;

                                    row.COTIZACION_MONEDA = cotizacion_moneda;
                                    row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                                    row.CTACTE_VALOR_ID = ctacte_valor_id;
                                    row.MONEDA_ID = moneda_id;

                                    break;
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    //Buscar el ingreso del cheque a la caja
                                    clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CtacteCajaTesoreriaId_NombreCol + " = " + ctacte_caja_tesoreria_id + " and " +
                                                CuentaCorrienteCajasTesoreriaMovimientosService.CtacteChequeRecibidoId_NombreCol + " = " + ctacte_cheque_recibido_id + " and " +
                                                CuentaCorrienteCajasTesoreriaMovimientosService.FechaEgreso_NombreCol + " is null ";
                                    row = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsArray(clausulas, string.Empty)[0];
                                    valorAnterior = row.ToString();
                                    insertarNuevo = false;

                                    row.EGRESO = row.INGRESO;

                                    //Modificar el estado del cheque
                                    ctacteCheque.ParaDepositoPorDepositoBancario(row.CTACTE_CHEQUE_RECIBIDO_ID, registro_cabecera_id, sesion);

                                    break;
                            }

                            row.DEPOSITO_BANCARIO_DET_ID = registro_detalle_id;
                            row.FECHA_EGRESO = fecha;
                            row.OBSERVACION = "Egreso por deposito bancario caso " + dtDepositoBancario.Rows[0][DepositosBancariosService.CasoId_NombreCol] + ".";

                            break;
                            #endregion
                        case Definiciones.FlujosIDs.CAMBIO_DIVISA:
                            #region
                            DataTable dtCambioDivisa = (new CambiosDivisaService()).GetCambiosDivisaDataTable(CambiosDivisaService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);

                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            insertarNuevo = true;
                            row.CAMBIO_DIVISA_DET_ID = registro_detalle_id;
                            row.EGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_EGRESO = fecha;
                            row.OBSERVACION = "Generado por cambio de divisa caso " + dtCambioDivisa.Rows[0][CambiosDivisaService.CasoId_NombreCol] + ".";

                            break;
                            #endregion
                        case Definiciones.FlujosIDs.CUSTODIA_DE_VALORES:
                            #region
                            DataTable dtCustodiaValores = CustodiaValoresService.GetCustodiaValoresDataTable(CustodiaValoresService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);
                            tipo_valor = Convert.ToInt32(ctacte_valor_id);
                            switch (tipo_valor)
                            {
                                case Definiciones.CuentaCorrienteValores.Efectivo:
                                case Definiciones.CuentaCorrienteValores.Ajuste:
                                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                                    valorAnterior = Definiciones.Log.RegistroNuevo;
                                    insertarNuevo = true;

                                    row.EGRESO = monto;

                                    row.COTIZACION_MONEDA = cotizacion_moneda;
                                    row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                                    row.CTACTE_VALOR_ID = ctacte_valor_id;
                                    row.MONEDA_ID = moneda_id;

                                    break;
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    //Buscar el ingreso del cheque a la caja
                                    clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CtacteCajaTesoreriaId_NombreCol + " = " + ctacte_caja_tesoreria_id + " and " +
                                                CuentaCorrienteCajasTesoreriaMovimientosService.CtacteChequeRecibidoId_NombreCol + " = " + ctacte_cheque_recibido_id + " and " +
                                                CuentaCorrienteCajasTesoreriaMovimientosService.FechaEgreso_NombreCol + " is null ";
                                    row = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsArray(clausulas, string.Empty)[0];
                                    valorAnterior = row.ToString();
                                    insertarNuevo = false;

                                    row.EGRESO = row.INGRESO;

                                    //Modificar el estado del cheque
                                    ctacteCheque.CustodiadoPorCustodiaDeValores(row.CTACTE_CHEQUE_RECIBIDO_ID, registro_cabecera_id, sesion);

                                    break;
                                default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.Egreso. Tipo de valor no implementado para flujo Custodia de Valores.");
                            }

                            row.CUSTODIA_VALOR_DET_ID = registro_detalle_id;
                            row.FECHA_EGRESO = fecha;
                            row.OBSERVACION = "Egreso por custodia de valores caso " + dtCustodiaValores.Rows[0][CustodiaValoresService.CasoId_NombreCol] + ".";

                            break;
                            #endregion
                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS:
                            #region
                            DataTable dtDescuentoDocumentos = (new DescuentoDocumentosService()).GetDescuentoDocumentosDataTable(DescuentoDocumentosService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);
                            tipo_valor = Convert.ToInt32(ctacte_valor_id);
                            switch (tipo_valor)
                            {
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    //Buscar el ingreso del cheque a la caja
                                    clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CtacteCajaTesoreriaId_NombreCol + " = " + ctacte_caja_tesoreria_id + " and " +
                                                CuentaCorrienteCajasTesoreriaMovimientosService.CtacteChequeRecibidoId_NombreCol + " = " + ctacte_cheque_recibido_id + " and " +
                                                CuentaCorrienteCajasTesoreriaMovimientosService.FechaEgreso_NombreCol + " is null ";
                                    row = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsArray(clausulas, string.Empty)[0];
                                    valorAnterior = row.ToString();
                                    insertarNuevo = false;

                                    row.EGRESO = row.INGRESO;

                                    //Modificar el estado del cheque
                                    ctacteCheque.NegociadoPorDescuentoDeDocumentos(row.CTACTE_CHEQUE_RECIBIDO_ID, registro_cabecera_id, sesion);

                                    break;
                                default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.Egreso. Tipo de valor no implementado para flujo Custodia de Valores.");
                            }

                            row.DESCUENTO_DOCUMENTO_DET_ID = registro_detalle_id;
                            row.FECHA_EGRESO = fecha;
                            row.OBSERVACION = "Egreso por descuento de documentos caso " + dtDescuentoDocumentos.Rows[0][CustodiaValoresService.CasoId_NombreCol] + ".";

                            break;
                            #endregion
                        case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                            #region
                            DataTable dtMovimiento = MovimientoVarioCajaTesoreriaService.GetMovimientoVarioCajaTesoreriaDataTable(MovimientoVarioCajaTesoreriaService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty, sesion);

                            if (ctacte_valor_id == Definiciones.CuentaCorrienteValores.Cheque)
                            {
                                DataTable dt = GetCuentaCorrienteCajasTesoreriaMovimientosDataTable2(CtacteChequeRecibidoId_NombreCol + "=" + ctacte_cheque_recibido_id + " and " + Egreso_NombreCol + " is null ", string.Empty);
                                if (dt.Rows.Count == 1)
                                {
                                    row = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByPrimaryKey(decimal.Parse(dt.Rows[0][Id_NombreCol].ToString()));
                                }

                                insertarNuevo = false;
                            }
                            else
                            {
                                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                                row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                                row.MONEDA_ID = moneda_id;
                                row.CTACTE_VALOR_ID = ctacte_valor_id;
                            }
                            row.MOVIMIENTO_VARIO_DET_ID = registro_detalle_id;
                            row.EGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.FECHA_EGRESO = fecha;

                            if (row.OBSERVACION != null && !row.OBSERVACION.Equals(string.Empty)) row.OBSERVACION += ". ";
                            row.OBSERVACION += "Egreso generado por movimiento vario caso Nro. " + dtMovimiento.Rows[0][MovimientoVarioCajaTesoreriaService.CasoId_NombreCol] + ".";
                            break;
                            #endregion
                        case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                            #region
                            DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoInfoCompleta(OrdenesPagoService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty, sesion);
                            tipo_valor = Convert.ToInt32(ctacte_valor_id);
                            switch (tipo_valor)
                            {
                                case Definiciones.CuentaCorrienteValores.Efectivo:
                                case Definiciones.CuentaCorrienteValores.Ajuste:
                                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                                    valorAnterior = Definiciones.Log.RegistroNuevo;
                                    insertarNuevo = true;

                                    row.EGRESO = monto;

                                    row.COTIZACION_MONEDA = cotizacion_moneda;
                                    row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                                    row.CTACTE_VALOR_ID = ctacte_valor_id;
                                    row.MONEDA_ID = moneda_id;

                                    break;
                                case Definiciones.CuentaCorrienteValores.Cheque:
                                    //Buscar el ingreso del cheque a la caja
                                    clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CtacteCajaTesoreriaId_NombreCol + " = " + ctacte_caja_tesoreria_id + " and " +
                                                CuentaCorrienteCajasTesoreriaMovimientosService.CtacteChequeRecibidoId_NombreCol + " = " + ctacte_cheque_recibido_id + " and " +
                                                CuentaCorrienteCajasTesoreriaMovimientosService.FechaEgreso_NombreCol + " is null ";
                                    row = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsArray(clausulas, string.Empty)[0];
                                    valorAnterior = row.ToString();
                                    insertarNuevo = false;

                                    row.EGRESO = row.INGRESO;

                                    //Modificar el estado del cheque
                                    ctacteCheque.UtilizadoPorFlujo(row.CTACTE_CHEQUE_RECIBIDO_ID, sesion);

                                    break;

                                case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                                    DataTable OrdenPagoValor = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(OrdenesPagoValoresService.Id_NombreCol + " = " + registro_detalle_id, string.Empty);
                                    decimal procesadoraId = CuentaCorrienteTarjetasCreditoService.GetCtaCteProcesadora((decimal)(OrdenPagoValor.Rows[0][OrdenesPagoValoresService.TCCtacteTarjetaCreditoId_NombreCol]));
                                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                                    valorAnterior = Definiciones.Log.RegistroNuevo;
                                    insertarNuevo = true;

                                    row.EGRESO = monto;

                                    row.COTIZACION_MONEDA = cotizacion_moneda;
                                    row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                                    row.CTACTE_VALOR_ID = ctacte_valor_id;
                                    row.MONEDA_ID = moneda_id;
                                    row.CTACTE_PROCESADORA_TARJETA_ID = procesadoraId;

                                    break;
                            }

                            row.ORDEN_PAGO_VALOR_ID = registro_detalle_id;
                            row.FECHA_EGRESO = fecha;
                            row.OBSERVACION = "Egreso por orden de pago caso " + dtOrdenPago.Rows[0][OrdenesPagoService.CasoId_NombreCol] + ".";

                            break;
                            #endregion
                        case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL:
                            #region 
                            DataTable dtTransferenciaSuc = TransferenciaCajasSucursalService.GetTransferenciaCajasDataTable(TransferenciaCajasSucursalService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty, sesion);

                            if (ctacte_valor_id == Definiciones.CuentaCorrienteValores.Cheque)
                            {
                                DataTable dt = GetCuentaCorrienteCajasTesoreriaMovimientosDataTable2(CtacteChequeRecibidoId_NombreCol + "=" + ctacte_cheque_recibido_id + " and " + Egreso_NombreCol + " is null ", string.Empty);
                                if (dt.Rows.Count == 1)
                                row = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByPrimaryKey(decimal.Parse(dt.Rows[0][Id_NombreCol].ToString()));
                                insertarNuevo = false;
                            }
                            else
                            {
                                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                                row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                                row.MONEDA_ID = moneda_id;
                                row.CTACTE_VALOR_ID = ctacte_valor_id;
                            }

                            row.TRANSFERENCIA_CAJA_SUC_DET_ID = registro_detalle_id;
                            row.EGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.FECHA_EGRESO = fecha;
                            row.OBSERVACION += "Egreso generado por transferencia caja caso Nro. " + dtTransferenciaSuc.Rows[0][TransferenciaCajasSucursalService.CasoId_NombreCol] + ".";
                            break;
                            #endregion
                        case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA:
                            #region
                            DataTable dtTransferenciaCaja = (new TransferenciasCajasTesoreriaService()).GetTransferenciaCajaTesoreriaDataTable(TransferenciasCajasTesoreriaService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);

                            if (ctacte_valor_id == Definiciones.CuentaCorrienteValores.Cheque)
                            {
                                DataTable dt = GetCuentaCorrienteCajasTesoreriaMovimientosDataTable2(CtacteChequeRecibidoId_NombreCol + "=" + ctacte_cheque_recibido_id + " and " + Egreso_NombreCol + " is null ", string.Empty);
                                if (dt.Rows.Count == 1)
                                {
                                    row = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByPrimaryKey(decimal.Parse(dt.Rows[0][Id_NombreCol].ToString()));
                                }
                                insertarNuevo = false;
                            }
                            else
                            {
                                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                                row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                                row.MONEDA_ID = moneda_id;
                                row.CTACTE_VALOR_ID = ctacte_valor_id;
                            }
                            row.TRANSFERENCIA_DET_ID = registro_detalle_id;
                            row.EGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.FECHA_EGRESO = fecha;

                            //if (!row.OBSERVACION.Equals(string.Empty)) row.OBSERVACION += ". ";
                            row.OBSERVACION += "Egreso generado por transferencia caso Nro. " + dtTransferenciaCaja.Rows[0][TransferenciasCajasTesoreriaService.CasoId_NombreCol] + ".";
                            break;
                            #endregion
                        case Definiciones.FlujosIDs.CANJES_VALORES:
                            #region
                            DataTable dtCanjeValores = CanjesValoresService.GetCanjesValoresDataTable(CanjesValoresService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);

                            if (ctacte_valor_id == Definiciones.CuentaCorrienteValores.Cheque)
                            {
                                DataTable dt = GetCuentaCorrienteCajasTesoreriaMovimientosDataTable2(CtacteChequeRecibidoId_NombreCol + "=" + ctacte_cheque_recibido_id + " and " + Egreso_NombreCol + " is null ", string.Empty);
                                if (dt.Rows.Count == 1)
                                {
                                    row = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByPrimaryKey(decimal.Parse(dt.Rows[0][Id_NombreCol].ToString()));
                                }else{
                                    return Definiciones.Error.Valor.EnteroPositivo;
                                }
                                

                                insertarNuevo = false;
                            }
                            else
                            {
                                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                                row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                                row.MONEDA_ID = moneda_id;
                                row.CTACTE_VALOR_ID = ctacte_valor_id;
                            }

                            row.CANJE_VALOR_DET_ID = registro_detalle_id;
                            row.EGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.FECHA_EGRESO = fecha;

                            if (row.OBSERVACION != null && !row.OBSERVACION.Equals(string.Empty)) row.OBSERVACION += ". ";
                            row.OBSERVACION += "Egreso generado por canje de valores caso Nro. " + dtCanjeValores.Rows[0][CanjesValoresService.CasoId_NombreCol] + ".";
                            break;
                            #endregion
                        default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.Egreso. Flujo no implementado");
                    }
                }

                row.FECHA_OPERACION = fecha;
                row.USUARIO_OPERACION_ID = sesion.Usuario.ID;

                //Aun no se utiliza
                //row.CTACTE_PROCESADORA_TARJETA_ID;

                if(insertarNuevo) sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Insert(row);
                else sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Egreso

        #region DeshacerEgreso
        /// <summary>
        /// Deshacers the egreso.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="registro_detalle_id">The registro_detalle_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void DeshacerEgreso(int flujo_id, string tabla_id, decimal registro_detalle_id, decimal caso_id)
        {
            using (SessionService sesion = new SessionService()) {
                DeshacerEgreso(flujo_id, tabla_id, registro_detalle_id, caso_id, sesion);
            }
        }
        public static void DeshacerEgreso(int flujo_id, string tabla_id, decimal registro_detalle_id, decimal caso_id, SessionService sesion)
        {
            try 
            {
                CuentaCorrienteChequesRecibidosService ctacteCheque = new CuentaCorrienteChequesRecibidosService();

                CTACTE_CAJAS_TESORERIA_MOVRow[] rows;
                CTACTE_CAJAS_TESORERIA_MOVRow row;
                string valorAnterior;
                string clausulas;

                int ctacteValorId;

                if (!flujo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    switch (flujo_id)
                    {
                        case Definiciones.FlujosIDs.DEPOSITO_BANCARIO:
                            rows = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByDEPOSITO_BANCARIO_DET_ID(registro_detalle_id);
                            break;
                        case Definiciones.FlujosIDs.CAMBIO_DIVISA:

                            clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CambioDivisaDetId_NombreCol + " = " + registro_detalle_id + " and " +
                                        "(" + CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso_NombreCol + " is null or " + CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso_NombreCol + " = 0 )";
                            rows = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsArray(clausulas, string.Empty);
                            break;
                        case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                            rows = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByORDEN_PAGO_VALOR_ID(registro_detalle_id);
                            break;
                        case Definiciones.FlujosIDs.CUSTODIA_DE_VALORES:
                            clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CustodiaValorDetId_NombreCol + " = " + registro_detalle_id;
                            rows = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsArray(clausulas, string.Empty);
                            break;
                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS:
                            clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.DescuentoDocumentoDetId_NombreCol + " = " + registro_detalle_id;
                            rows = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsArray(clausulas, string.Empty);
                            break;
                        case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                            rows = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByMOVIMIENTO_VARIO_DET_ID(registro_detalle_id);
                            break;
                        default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerEgreso. Flujo no implementado");
                    }
                }
                else
                {
                    /* Ejemplo para cuando tenga que diferenciarse por tabla
                    if(tabla_id.Equals(xxxxx))
                    {
                    }
                    else 
                    {
                        throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerEgreso. Tabla no implementada");
                    }
                    */
                    throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerEgreso. Tabla no implementada");
                }

                //No existe movimiento asociado
                if (rows.Length <= 0)
                    return;

                row = rows[0];

                valorAnterior = row.ToString();

                ctacteValorId = Convert.ToInt32(row.CTACTE_VALOR_ID);
                switch (ctacteValorId) {
                    case Definiciones.CuentaCorrienteValores.Efectivo:
                    case Definiciones.CuentaCorrienteValores.Ajuste:
                        sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Delete(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                        break;
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        switch (flujo_id) {
                            case Definiciones.FlujosIDs.DEPOSITO_BANCARIO:
                                ctacteCheque.DeshacerParaDepositoPorDepositoBancario(row.CTACTE_CHEQUE_RECIBIDO_ID, sesion);
                                row.IsDEPOSITO_BANCARIO_DET_IDNull = true;
                                row.OBSERVACION += " Reingreso por Depósito Bancario anulado.";
                                break;
                            case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                                ctacteCheque.DeshacerUtilizadoPorFlujo(row.CTACTE_CHEQUE_RECIBIDO_ID, caso_id, sesion);
                                row.IsORDEN_PAGO_VALOR_IDNull = true;
                                row.OBSERVACION += " Reingreso por Orden de Pago anulado.";
                                break;
                            case Definiciones.FlujosIDs.CUSTODIA_DE_VALORES:
                                ctacteCheque.DeshacerUtilizadoPorFlujo(row.CTACTE_CHEQUE_RECIBIDO_ID, caso_id, sesion);
                                row.IsCUSTODIA_VALOR_DET_IDNull = true;
                                if (CuentaCorrienteChequesRecibidosService.GetEstado(row.CTACTE_CHEQUE_RECIBIDO_ID, sesion).Equals(Definiciones.CuentaCorrienteChequesEstados.Rechazado))
                                    row.OBSERVACION += " Reingreso por cheque rechazado en custodia de valores.";
                                else
                                    row.OBSERVACION += " Reingreso por detalle de custodia de valores borrado.";

                                break;
                            case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS:
                                ctacteCheque.DeshacerUtilizadoPorFlujo(row.CTACTE_CHEQUE_RECIBIDO_ID, caso_id, sesion);
                                row.IsDESCUENTO_DOCUMENTO_DET_IDNull = true;
                                row.OBSERVACION += " Reingreso por detalle de descuento de documentos.";
                                break;
                            case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                                ctacteCheque.DeshacerUtilizadoPorFlujo(row.CTACTE_CHEQUE_RECIBIDO_ID, caso_id, sesion);
                                row.IsMOVIMIENTO_VARIO_DET_IDNull = true;
                                row.OBSERVACION += " Reingreso por Movimiento Vario de Tesorería anulado.";
                                break;
                            default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerEgreso. Flujo no implementado.");
                        }

                        row.IsEGRESONull = true;
                        row.IsFECHA_EGRESONull = true;

                        sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Update(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                        break;

                    default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerEgreso. Tipo de valor no implementado");
                }
            } catch (Exception exp) {
                throw exp;
            }
        }

        #endregion DeshacerEgreso

        #region DeshacerIngreso
        public static void DeshacerIngreso(int flujo_id, string tabla_id, decimal registro_detalle_id, decimal caso_id, SessionService sesion)
        {
            try 
            {
                CuentaCorrienteChequesRecibidosService ctacteCheque = new CuentaCorrienteChequesRecibidosService();

                CTACTE_CAJAS_TESORERIA_MOVRow[] rows;
                CTACTE_CAJAS_TESORERIA_MOVRow row;
                string valorAnterior;
                string clausulas;

                int ctacteValorId;

                if (!flujo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    switch (flujo_id)
                    {
                        case Definiciones.FlujosIDs.CAMBIO_DIVISA:
                            clausulas = CuentaCorrienteCajasTesoreriaMovimientosService.CambioDivisaDetId_NombreCol + " = " + registro_detalle_id + " and " +
                                        "(" + CuentaCorrienteCajasTesoreriaMovimientosService.Egreso_NombreCol + " is null or " + CuentaCorrienteCajasTesoreriaMovimientosService.Egreso_NombreCol + " = 0 )";
                            rows = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetAsArray(clausulas, string.Empty);
                            break;
                        case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                            rows = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByMOVIMIENTO_VARIO_DET_ID(registro_detalle_id);
                            break;
                        case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                            rows = sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.GetByORDEN_PAGO_VALOR_ID(registro_detalle_id);
                            break;
                        default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerIngreso. Flujo no implementado");
                    }
                }
                else
                {
                    /* Ejemplo para cuando tenga que diferenciarse por tabla
                    if(tabla_id.Equals(xxxxx))
                    {
                    }
                    else 
                    {
                        throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerEgreso. Tabla no implementada");
                    }
                    */
                    throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerIngreso. Tabla no implementada");
                }

                //No existe un row asociado
                if (rows.Length <= 0)
                    return;
                
                row = rows[0];

                valorAnterior = row.ToString();

                ctacteValorId = Convert.ToInt32(row.CTACTE_VALOR_ID);
                switch (ctacteValorId) {
                    case Definiciones.CuentaCorrienteValores.Efectivo:
                    case Definiciones.CuentaCorrienteValores.Ajuste:
                        sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Delete(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                        break;
                    //Cheque no esta testeado
                    //case Definiciones.CuentaCorrienteValores.Cheque:
                    //    switch (flujo_id) {
                    //        case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                    //            CuentaCorrienteChequesRecibidosService.Borrar(row.CTACTE_CHEQUE_RECIBIDO_ID, sesion);
                    //            break;
                    //        default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerIngreso. Flujo no implementado.");
                    //    }

                    //    sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Delete(row);
                    //    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    //    break;

                    default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.DeshacerIngreso. Tipo de valor no implementado");
                }
            } catch (Exception exp) {
                throw exp;
            }
        }
        #endregion DeshacerIngreso

        #region Ingreso
        public decimal Ingreso(decimal ctacte_caja_tesoreria_id, int flujo_id, string tabla_id, decimal registro_cabecera_id, decimal registro_detalle_id, decimal ctacte_valor_id, decimal ctacte_cheque_recibido_id, decimal moneda_id, decimal cotizacion_moneda, decimal monto, DateTime fecha, SessionService sesion)
        {
            return Ingreso2(ctacte_caja_tesoreria_id, flujo_id, tabla_id, registro_cabecera_id, registro_detalle_id, ctacte_valor_id, ctacte_cheque_recibido_id, moneda_id, cotizacion_moneda, monto, fecha, sesion);
        }

        /// <summary>
        /// Ingresoes the specified ctacte_caja_tesoreria_id.
        /// </summary>
        /// <param name="ctacte_caja_tesoreria_id">The ctacte_caja_tesoreria_id.</param>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="registro_cabecera_id">The registro_cabecera_id.</param>
        /// <param name="registro_detalle_id">The registro_detalle_id.</param>
        /// <param name="ctacte_valor_id">The ctacte_valor_id.</param>
        /// <param name="ctacte_cheque_recibido_id">The ctacte_cheque_recibido_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="cotizacion_moneda">The cotizacion_moneda.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="fecha">The fecha.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal Ingreso2(decimal ctacte_caja_tesoreria_id, int flujo_id, string tabla_id, decimal registro_cabecera_id, decimal registro_detalle_id, decimal ctacte_valor_id, decimal ctacte_cheque_recibido_id, decimal moneda_id, decimal cotizacion_moneda, decimal monto, DateTime fecha, SessionService sesion)
        {
            try
            {
                CuentaCorrienteChequesRecibidosService ctacteCheque = new CuentaCorrienteChequesRecibidosService();
                CTACTE_CAJAS_TESORERIA_MOVRow row = new CTACTE_CAJAS_TESORERIA_MOVRow();
                string valorAnterior = string.Empty;
                bool insertarNuevo = true;

                //Si no se especifica el flujo se trata de una efectivizacion de cheque
                if (flujo_id.Equals(Definiciones.Error.Valor.IntPositivo))
                {
                    if (tabla_id != CuentaCorrienteChequesRecibidosService.Nombre_Tabla)
                        throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.Ingreso2. Tabla no implementada");
                 
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                    insertarNuevo = true;
                    row.INGRESO = monto;
                    row.COTIZACION_MONEDA = cotizacion_moneda;
                    row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                    row.CTACTE_VALOR_ID = ctacte_valor_id;
                    row.MONEDA_ID = moneda_id;
                    row.FECHA_INGRESO = fecha;
                    row.OBSERVACION = "Generado por efectivización de cheque. ";
                }
                else
                {
                    switch (flujo_id)
                    {
                        case Definiciones.FlujosIDs.CAMBIO_DIVISA:
                            DataTable dtCambioDivisa = (new CambiosDivisaService()).GetCambiosDivisaDataTable(CambiosDivisaService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);

                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            insertarNuevo = true;
                            row.CAMBIO_DIVISA_DET_ID = registro_detalle_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            row.OBSERVACION = "Generado por cambio de divisa caso " + dtCambioDivisa.Rows[0][CambiosDivisaService.CasoId_NombreCol] + ". ";

                            break;
                        case Definiciones.FlujosIDs.CUSTODIA_DE_VALORES:
                            DataTable dtCustodia = CustodiaValoresService.GetCustodiaValoresDataTable(CustodiaValoresService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);
                            insertarNuevo = true;
                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            row.CUSTODIA_VALOR_DET_ID = registro_detalle_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            if (!ctacte_cheque_recibido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
                            row.OBSERVACION = "Ingreso generado por retiro del valor en la custodia de valores caso Nro. " + dtCustodia.Rows[0][CustodiaValoresService.CasoId_NombreCol] + ". ";
                            break;
                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS:
                            DataTable dtDescuentoDoc = (new DescuentoDocumentosService()).GetDescuentoDocumentosDataTable(DescuentoDocumentosService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);
                            insertarNuevo = true;
                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            row.DESCUENTO_DOCUMENTO_PAGO_ID = registro_detalle_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            if (!ctacte_cheque_recibido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
                            row.OBSERVACION = "Ingreso generado por pago de Descuento de Documentos caso Nro. " + dtDescuentoDoc.Rows[0][DescuentoDocumentosService.CasoId_NombreCol] + ". ";
                            break;
                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS_CLIENTES:
                            DataTable dtDescuentoDocCli = DescuentoDocumentosClienteService.GetDescuentoDocumentosClienteDataTable(DescuentoDocumentosClienteService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);
                            insertarNuevo = true;
                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            row.DESCUENTO_DOCUMENTO_CLI_DET_ID = registro_detalle_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            if (!ctacte_cheque_recibido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
                            row.OBSERVACION = "Ingreso generado por Descuento de Documentos de Cliente caso Nro. " + dtDescuentoDocCli.Rows[0][DescuentoDocumentosClienteService.CasoId_NombreCol] + ". ";
                            break;
                        case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                            DataTable dtMovimiento = MovimientoVarioCajaTesoreriaService.GetMovimientoVarioCajaTesoreriaDataTable(MovimientoVarioCajaTesoreriaService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty, sesion);
                            insertarNuevo = true;
                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            row.MOVIMIENTO_VARIO_DET_ID = registro_detalle_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            if (!ctacte_cheque_recibido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
                            row.OBSERVACION = "Ingreso generado por movimiento vario caso Nro. " + dtMovimiento.Rows[0][MovimientoVarioCajaTesoreriaService.CasoId_NombreCol] + ". ";
                            break;
                        case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                            if (ctacte_valor_id != Definiciones.CuentaCorrienteValores.Ajuste)
                                throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.Ingreso. Las OP solo pueden ingresar valor tipo Ajuste");

                            DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty, sesion);
                            insertarNuevo = true;
                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            row.ORDEN_PAGO_VALOR_ID = registro_detalle_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            row.OBSERVACION = "Ingreso generado por OP caso Nro. " + dtOrdenPago.Rows[0][OrdenesPagoService.CasoId_NombreCol] + ". ";
                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL:
                            DataTable dtTransferenciaSuc = TransferenciaCajasSucursalService.GetTransferenciaCajasDataTable(TransferenciaCajasSucursalService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty, sesion);
                            insertarNuevo = true;
                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            row.TRANSFERENCIA_CAJA_SUC_DET_ID = registro_detalle_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            if (!ctacte_cheque_recibido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
                            row.OBSERVACION = "Ingreso generado por transferencia sucursal caso Nro. " + dtTransferenciaSuc.Rows[0][TransferenciaCajasSucursalService.CasoId_NombreCol] + ". ";
                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA:
                            DataTable dtTransferencia = (new TransferenciasCajasTesoreriaService()).GetTransferenciaCajaTesoreriaDataTable(TransferenciasCajasTesoreriaService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);
                            insertarNuevo = true;
                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            row.TRANSFERENCIA_DET_ID = registro_detalle_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            if (!ctacte_cheque_recibido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
                            row.OBSERVACION = "Ingreso generado por transferencia caso Nro. " + dtTransferencia.Rows[0][TransferenciasCajasTesoreriaService.CasoId_NombreCol] + ". ";
                            break;
                        case Definiciones.FlujosIDs.CANJES_VALORES:
                            DataTable dtCanjeValor = CanjesValoresService.GetCanjesValoresDataTable(CanjesValoresService.Id_NombreCol + " = " + registro_cabecera_id, string.Empty);
                            insertarNuevo = true;
                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            row.CANJE_VALOR_VAL_ID = registro_detalle_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            if (!ctacte_cheque_recibido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
                            row.OBSERVACION = "Ingreso generado por pago de Canje de Valores caso Nro. " + dtCanjeValor.Rows[0][DescuentoDocumentosService.CasoId_NombreCol] + ". ";
                            break;
                        case Definiciones.FlujosIDs.DESEMBOLSOS_GIROS:
                            string clausulas = DesembolsosGirosService.Id_NombreCol + " = " + registro_cabecera_id;
                            DataTable dtDesembolso = DesembolsosGirosService.GetDesembolsosGirosDataTable(clausulas,string.Empty);
                            insertarNuevo = true;
                            row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                            row.DESEMBOLSO_GIRO_ID = registro_cabecera_id;
                            row.INGRESO = monto;
                            row.COTIZACION_MONEDA = cotizacion_moneda;
                            row.CTACTE_CAJA_TESORERIA_ID = ctacte_caja_tesoreria_id;
                            row.CTACTE_VALOR_ID = ctacte_valor_id;
                            row.MONEDA_ID = moneda_id;
                            row.FECHA_INGRESO = fecha;
                            if (!ctacte_cheque_recibido_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
                            row.OBSERVACION = "Ingreso generado por desembolso de giro. " + dtDesembolso.Rows[0][DesembolsosGirosService.CasoId_NombreCol] + ". ";
                            break;
                        default: throw new Exception("CuentaCorrienteCajasTesoreriaMovimientos.Ingreso. Flujo no implementado");
                    }
                }

                row.FECHA_OPERACION = fecha;
                row.USUARIO_OPERACION_ID = sesion.Usuario.ID;

                //Aun no se utiliza
                //row.CTACTE_PROCESADORA_TARJETA_ID;

                if (insertarNuevo) sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Insert(row);
                else sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Ingreso

        #region IngresoValoresCierreCajaSucursal
        public void IngresoValoresCierreCajaSucursal(decimal ctacte_caja_sucursal_id, SessionService sesion)
        {
            try
            {
                string clausula;
                
                DataTable dtCtacteCajaSuc = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalInfoCompleta2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + ctacte_caja_sucursal_id, string.Empty);

                clausula = CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol + " = " + dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.Id_NombreCol] + " and " +
                    CuentaCorrienteCajaService.CtacteConceptoId_NombreCol + " in (" + Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo + ", " +
                    Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo + ", " + Definiciones.CuentaCorrienteConceptos.DebitoPorPago + ", " +
                    Definiciones.CuentaCorrienteConceptos.CreditoPorPago + ", " + Definiciones.CuentaCorrienteConceptos.Vuelto + ", " +
                    Definiciones.CuentaCorrienteConceptos.TransferenciaDeFondoFijo + ", " + Definiciones.CuentaCorrienteConceptos.DebitoTransferenciaDeCtaCte + ", " +
                    Definiciones.CuentaCorrienteConceptos.CreditoTransferenciaDeCtaCte + ", " + Definiciones.CuentaCorrienteConceptos.Recargo + ", " +
                    Definiciones.CuentaCorrienteConceptos.EntregaInicial + ", " + Definiciones.CuentaCorrienteConceptos.SaldoCaja + ", " +
                    Definiciones.CuentaCorrienteConceptos.EgresoPorTransferencia + ", " + Definiciones.CuentaCorrienteConceptos.IngresoPorTransferencia +
                    ") and not exists(select " + CuentaCorrienteCajaService.Id_NombreCol +
                                        " from " + CuentaCorrienteCajaService.Nombre_Tabla + " cc2 " +
                                        " where cc2." + CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol + " = " + CuentaCorrienteCajaService.Nombre_Tabla + "." + CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol +
                                        " and cc2." + CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol + " = " + CuentaCorrienteCajaService.Nombre_Tabla + "." + CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol +
                                        " and cc2." + CuentaCorrienteCajaService.CtacteConceptoId_NombreCol + " = " + Definiciones.CuentaCorrienteConceptos.EgresoPorTransferencia + ")";
               
                DataTable dtValores = CuentaCorrienteCajaService.GetCtacteCajaDataTable2(clausula, CuentaCorrienteCajaService.Id_NombreCol);
                int ctacteValor;
                Hashtable htEfectivoPorMoneda = new Hashtable();
                CTACTE_CAJAS_TESORERIA_MOVRow row;

                //Por trazabilidad se registran tanto los ingresos como egresos
                //que ocurrieron en la caja de sucursal
                for (int i = 0; i < dtValores.Rows.Count; i++)
                {
                    ctacteValor = Convert.ToInt32(dtValores.Rows[i][CuentaCorrienteCajaService.CtacteValorId_NombreCol]);

                    //Solo se registran los movimientos de efectivo o cheques
                    //El efectivo se suma para ingresarlo de una vez. 
                    //Los cheques entran por separado
                    if (ctacteValor == Definiciones.CuentaCorrienteValores.Efectivo)
                    {
                        if (htEfectivoPorMoneda.Contains((decimal)dtValores.Rows[i][CuentaCorrienteCajaService.MonedaId_NombreCol]))
                            htEfectivoPorMoneda[dtValores.Rows[i][CuentaCorrienteCajaService.MonedaId_NombreCol]] = (decimal)htEfectivoPorMoneda[dtValores.Rows[i][CuentaCorrienteCajaService.MonedaId_NombreCol]] + (decimal)dtValores.Rows[i][CuentaCorrienteCajaService.Monto_NombreCol];
                        else
                            htEfectivoPorMoneda.Add(dtValores.Rows[i][CuentaCorrienteCajaService.MonedaId_NombreCol], dtValores.Rows[i][CuentaCorrienteCajaService.Monto_NombreCol]);
                    }
                    else if (ctacteValor == Definiciones.CuentaCorrienteValores.Cheque)
                    {
                        //No agregar el cheque si ya egreso por un deposito bancario
                        if (!Interprete.EsNullODBNull(dtValores.Rows[i][CuentaCorrienteCajaService.DepositoBancarioDetId_NombreCol]))
                            continue;

                        row = new CTACTE_CAJAS_TESORERIA_MOVRow();

                        row.CTACTE_CAJA_SUCURSAL_ID = ctacte_caja_sucursal_id;
                        row.CTACTE_CAJA_TESORERIA_ID = (decimal)dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaTesoreriaId_NombreCol];

                        if (!dtValores.Rows[i][CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol].Equals(DBNull.Value))
                            row.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)dtValores.Rows[i][CuentaCorrienteCajaService.CtacteChequeRecibidoId_NombreCol];

                        row.CTACTE_VALOR_ID = (decimal)dtValores.Rows[i][CuentaCorrienteCajaService.CtacteValorId_NombreCol];
                        row.FECHA_INGRESO = DateTime.Now;
                        row.FECHA_OPERACION = DateTime.Now;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                        row.INGRESO = (decimal)dtValores.Rows[i][CuentaCorrienteCajaService.Monto_NombreCol];
                        row.MONEDA_ID = (decimal)dtValores.Rows[i][CuentaCorrienteCajaService.MonedaId_NombreCol];
                        row.COTIZACION_MONEDA = (decimal)dtValores.Rows[i][CuentaCorrienteCajaService.CotizacionMoneda_NombreCol];
                        row.OBSERVACION = "Ingreso generado por aceptación de planilla de cierre Nº" + dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.NroComprobante_NombreCol] + ", sucursal " + dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.VistaSucursalNombre_NombreCol] + ", funcionario " + dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.VistaFuncionarioNombre_NombreCol] + ".";
                        row.USUARIO_OPERACION_ID = sesion.Usuario.ID;
                        sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Insert(row);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
                    }
                }

                //Se agrega un registro por moneda en efectivo
                foreach (DictionaryEntry pair in htEfectivoPorMoneda)
                {
                    //Si la suma es cero no se inseta
                    if ((decimal)pair.Value == 0)
                        continue;

                    row = new CTACTE_CAJAS_TESORERIA_MOVRow();

                    row.INGRESO = (decimal)pair.Value;
                    row.MONEDA_ID = (decimal)pair.Key;
                    
                    row.CTACTE_CAJA_SUCURSAL_ID = ctacte_caja_sucursal_id;
                    row.CTACTE_CAJA_TESORERIA_ID = (decimal)dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.CtacteCajaTesoreriaId_NombreCol];
                    row.CTACTE_VALOR_ID = Definiciones.CuentaCorrienteValores.Efectivo;
                    row.FECHA_INGRESO = DateTime.Now;
                    row.FECHA_OPERACION = DateTime.Now;
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_cajas_tesoreria_mov_sqc");
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol]), (decimal)pair.Key, DateTime.Now, sesion);
                    row.OBSERVACION = "Ingreso generado por aceptación de planilla de cierre Nº" + dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.NroComprobante_NombreCol] + ", sucursal " + dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.VistaSucursalNombre_NombreCol] + ", funcionario " + dtCtacteCajaSuc.Rows[0][CuentaCorrienteCajasSucursalService.VistaFuncionarioNombre_NombreCol] + ".";
                    row.USUARIO_OPERACION_ID = sesion.Usuario.ID;
                    sesion.Db.CTACTE_CAJAS_TESORERIA_MOVCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion IngresoValoresCierreCajaSucursal

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CAJAS_TESORERIA_MOV"; }
        }
        public static string Nombre_Vista 
        {
            get { return "ctacte_cajas_teso_mov_inf_comp"; }
        }
        public static string CambioDivisaDetId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.CAMBIO_DIVISA_DET_IDColumnName; }
        }
        public static string CanjeValorDetId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.CANJE_VALOR_DET_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteCajaSucursalId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string CtacteCajaTesoreriaId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.CTACTE_CAJA_TESORERIA_IDColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteProcesadoraTarjetaId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.CTACTE_PROCESADORA_TARJETA_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string CustodiaValorDetId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.CUSTODIA_VALOR_DET_IDColumnName; }
        }
        public static string CustodiaValorDetEntradaId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.CUSTODIA_VALOR_DET_ENTRADA_IDColumnName; }
        }
        public static string DepositoBancarioDetId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.DEPOSITO_BANCARIO_DET_IDColumnName; }
        }
        public static string DescuentoDocumentoCliDetId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.DESCUENTO_DOCUMENTO_CLI_DET_IDColumnName; }
        }
        public static string DescuentoDocumentoDetId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.DESCUENTO_DOCUMENTO_DET_IDColumnName; }
        }
        public static string DescuentoDocumentoPagoId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.DESCUENTO_DOCUMENTO_PAGO_IDColumnName; }
        }
        public static string Egreso_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.EGRESOColumnName; }
        }
        public static string FechaEgreso_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.FECHA_EGRESOColumnName; }
        }
        public static string FechaIngreso_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.FECHA_INGRESOColumnName; }
        }
        public static string FechaOperacion_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.FECHA_OPERACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.IDColumnName; }
        }
        public static string Ingreso_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.INGRESOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.MONEDA_IDColumnName; }
        }
        public static string MovimientoVarioDetId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.MOVIMIENTO_VARIO_DET_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.OBSERVACIONColumnName; }
        }
        public static string OrdenPagoValorId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.ORDEN_PAGO_VALOR_IDColumnName; }
        }
        public static string TransferenciaCajaSucDetId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.TRANSFERENCIA_CAJA_SUC_DET_IDColumnName; }
        }
        public static string TransferenciaDetalleId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.TRANSFERENCIA_DET_IDColumnName; }
        }
        public static string UsuarioOperacionId_NombreCol
        {
            get { return CTACTE_CAJAS_TESORERIA_MOVCollection.USUARIO_OPERACION_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCtacteCajaTesoreriaNombre_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CAJA_TESORERIA_NOMBREColumnName; }
        }
        public static string VistaCtacteChequeRecibidoActivo_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHEQUE_RECIBIDO_ACTIVOColumnName; }
        }
        public static string VistaCtacteChequeRecibidoId_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string VistaCtacteChequeRecibidoBanco_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHEQUE_RECIBIDO_BANCOColumnName; }
        }
        public static string VistaCtacteChequeRecibidoTerc_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHEQUE_RECIBIDO_TERCColumnName; }
        }
        public static string VistaCtacteChequeRecibidoEmisor_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHEQUE_RECIBIDO_EMISORColumnName; }
        }
        public static string VistaCtacteChequeRecibidoEstado_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHEQUE_RECIBIDO_ESTADOColumnName; }
        }
        public static string VistaCtacteChequeRecibidoEstadoId_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHQ_RECIBIDO_ESTADO_IDColumnName; }
        }
        public static string VistaCtacteChequeRecibidoNumero_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHEQUE_RECIBIDO_NUMEROColumnName; }
        }
        public static string VistaCtacteChequeRecibidoVen_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHEQUE_RECIBIDO_VENCColumnName; }
        }
        public static string VistaCtacteChequeRecibidoPersonaId_NombreCol
        {
            get { return CTACTE_CAJAS_TESO_MOV_INF_COMPCollection.CTACTE_CHQ_RECIBIDO_PERSONA_IDColumnName; }
        }
        #endregion Accessors
    }
}
