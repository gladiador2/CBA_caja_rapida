#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoProveedor;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class OrdenesPagoValoresService
    {
        #region GetOrdenesPagoValoresDataTable
        public static DataTable GetOrdenesPagoValoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetOrdenesPagoValoresDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetOrdenesPagoValoresDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ORDENES_PAGO_VALORESCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetOrdenesPagoValoresDataTable

        #region GetOrdenesPagoValoresInfoCompleta
        public static DataTable GetOrdenesPagoValoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetOrdenesPagoValoresInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetOrdenesPagoValoresInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ORDENES_PAGO_VALORES_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetOrdenesPagoValoresInfoCompleta

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                OrdenesPagoValoresService.Guardar(campos, sesion);
            }
        }
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// 
        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                int ctacteValorId;

                DataTable dtCabecera;
                ORDENES_PAGO_VALORESRow row = new ORDENES_PAGO_VALORESRow();
                string valorAnterior = Definiciones.Log.RegistroNuevo;

                row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_pago_valores_sqc");
                row.ORDEN_PAGO_ID = (decimal)campos[OrdenesPagoValoresService.OrdenPagoId_NombreCol];

                dtCabecera = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.Id_NombreCol + " = " + row.ORDEN_PAGO_ID, string.Empty, sesion);

                //Se inicializa a No sin importar el tipo de valor
                row.CG_USAR_AUTONUM = Definiciones.SiNo.No;

                ctacteValorId = int.Parse(campos[OrdenesPagoValoresService.CtacteValorId_NombreCol].ToString());
                switch (ctacteValorId)
                {
                    case Definiciones.CuentaCorrienteValores.Efectivo:
                        break;
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        if (campos.Contains(OrdenesPagoValoresService.CRCtacteChequeRecibidoId_NombreCol))
                        {
                            //Cheque recibido
                            row.CR_CTACTE_CHEQUE_RECIBIDO_ID = (decimal)campos[OrdenesPagoValoresService.CRCtacteChequeRecibidoId_NombreCol];
                        }
                        else
                        {
                            decimal decimalAuxOPCaso;

                            //Cheque girado
                            row.CG_CTACTE_BANCARIA_ID = (decimal)campos[OrdenesPagoValoresService.CGCtacteBancariaId_NombreCol];
                            row.CG_ES_DIFERIDO = (string)campos[OrdenesPagoValoresService.CGEsDiferido_NombreCol];
                            row.CG_FECHA_EMISION = (DateTime)campos[OrdenesPagoValoresService.CGFechaEmision_NombreCol];
                            row.CG_FECHA_VENCIMIENTO = (DateTime)campos[OrdenesPagoValoresService.CGFechaVencimiento_NombreCol];
                            row.CG_NOMBRE_BENEFICIARIO = (string)campos[OrdenesPagoValoresService.CGNombreBeneficiario_NombreCol];
                            row.CG_NUMERO_CTA_BENEFICIARIO = (string)campos[OrdenesPagoValoresService.CGNumeroCtaBeneficiario_NombreCol];
                            row.CG_NOMBRE_EMISOR = (string)campos[OrdenesPagoValoresService.CGNombreEmisor_NombreCol];
                            row.CG_NUMERO_CHEQUE = (string)campos[OrdenesPagoValoresService.CGNumeroCheque_NombreCol];
                            row.CG_USAR_AUTONUM = (string)campos[OrdenesPagoValoresService.CGUsarAutonum_NombreCol];

                            if (row.CG_USAR_AUTONUM == Definiciones.SiNo.Si)
                                row.CG_AUTONUMERACION_ID = (decimal)campos[OrdenesPagoValoresService.CGAutonumeracionId_NombreCol];

                            //Comprobar que no exista un cheque activo emitido con el mismo numero perteneciente a la misma cuenta
                            if (CuentaCorrienteChequesGiradosService.ExisteNumero(row.CG_CTACTE_BANCARIA_ID, row.CG_NUMERO_CHEQUE))
                            {
                                throw new Exception("Ya existe un cheque emitido con número " + row.CG_NUMERO_CHEQUE + " de la cuenta seleccionada.");
                            }
                            //Advertir si existe otra OP con valores aun no generados y que posteriormente emitirian 
                            //un cheque de la misma cuenta con mismo numero
                            else if (CuentaCorrienteChequesGiradosService.ExisteChequeGiradoParaCuentaYNumero(row.CG_CTACTE_BANCARIA_ID, row.CG_NUMERO_CHEQUE, out decimalAuxOPCaso))
                            {
                                throw new Exception("Existe un cheque con misma cuenta y número en la OP caso " + decimalAuxOPCaso + ".");
                            }

                        }
                        break;
                    case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                        row.TC_CTACTE_TARJETA_CREDITO_ID = (decimal)campos[OrdenesPagoValoresService.TCCtacteTarjetaCreditoId_NombreCol];
                        row.TC_CUPON = (string)campos[OrdenesPagoValoresService.TCCupon_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.Anticipo:
                        row.ANTICIPO_PROVEEDOR_ID = (decimal)campos[OrdenesPagoValoresService.AnticipoProveedorId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.AjusteBancario:
                        row.AJUSTE_BANCARIO_ID = (decimal)campos[OrdenesPagoValoresService.AjusteBancarioId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.NotaDeCredito:
                        row.NOTA_CREDITO_PROVEEDOR_ID = (decimal)campos[OrdenesPagoValoresService.NotaCreditoProveedorId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                        row.TRANSFERENCIA_BANCARIA_ID = (decimal)campos[OrdenesPagoValoresService.TransferenciaBancariaId_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.RetencionRenta:
                    case Definiciones.CuentaCorrienteValores.RetencionIVA:
                        //Creada en el cambio de estado de la OP
                        if (campos.Contains(OrdenesPagoValoresService.RetencionEmitidaId_NombreCol))
                            row.RETENCION_EMITIDA_ID = (decimal)campos[OrdenesPagoValoresService.RetencionEmitidaId_NombreCol];
                        row.RETENCION_FECHA = (DateTime)campos[OrdenesPagoValoresService.RetencionFecha_NombreCol];
                        row.RETENCION_TIPO_ID = (decimal)campos[OrdenesPagoValoresService.RetencionTipoId_NombreCol];
                        row.RETENCION_AUX_CASOS = (string)campos[OrdenesPagoValoresService.RetencionAuxCasos_NombreCol];
                        row.RETENCION_AUX_MONTOS = (string)campos[OrdenesPagoValoresService.RetencionAuxMontos_NombreCol];
                        break;
                    case Definiciones.CuentaCorrienteValores.Ajuste:
                        break;
                    case Definiciones.CuentaCorrienteValores.DebitoAutomatico:
                        row.DEBITO_AUTOM_CTACTE_BANC_ID = (decimal)campos[OrdenesPagoValoresService.DebitoAutomCtacteBancId_NombreCol];
                        break;
                    default: throw new Exception("Tipo de valor no implementado.");
                }
                row.CTACTE_VALOR_ID = Convert.ToDecimal(ctacteValorId);

                if (campos.Contains(OrdenesPagoValoresService.CotizacionMonedaDestino_NombreCol))
                    row.COTIZACION_MONEDA_DESTINO = (decimal)campos[OrdenesPagoValoresService.CotizacionMonedaDestino_NombreCol];
                else
                    row.COTIZACION_MONEDA_DESTINO = (decimal)dtCabecera.Rows[0][OrdenesPagoService.CotizacionMoneda_NombreCol];

                if (row.COTIZACION_MONEDA_DESTINO.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizarse la cotización de la moneda destino.");

                row.MONEDA_ORIGEN_ID = (decimal)campos[OrdenesPagoValoresService.MonedaOrigenId_NombreCol];
                if (row.MONEDA_ORIGEN_ID == (decimal)dtCabecera.Rows[0][OrdenesPagoService.MonedaId_NombreCol])
                {
                    row.COTIZACION_MONEDA_ORIGEN = row.COTIZACION_MONEDA_DESTINO;
                }
                else
                {
                    if (campos.Contains(OrdenesPagoValoresService.CotizacionMonedaOrigen_NombreCol))
                        row.COTIZACION_MONEDA_ORIGEN = (decimal)campos[OrdenesPagoValoresService.CotizacionMonedaOrigen_NombreCol];
                    else
                        row.COTIZACION_MONEDA_ORIGEN = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCabecera.Rows[0][OrdenesPagoService.SucursalOrigenId_NombreCol]), row.MONEDA_ORIGEN_ID, (DateTime)dtCabecera.Rows[0][OrdenesPagoService.Fecha_NombreCol], sesion);
                }

                if (row.COTIZACION_MONEDA_ORIGEN.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizarse la cotización de la moneda origen.");

                row.MONTO_ORIGEN = (decimal)campos[OrdenesPagoValoresService.MontoOrigen_NombreCol];
                row.MONTO_DESTINO = row.MONTO_ORIGEN / row.COTIZACION_MONEDA_ORIGEN * row.COTIZACION_MONEDA_DESTINO;
                
                row.OBSERVACION = (string)campos[OrdenesPagoValoresService.Observacion_NombreCol];

                if (campos.Contains(OrdenesPagoValoresService.NroComprobanteRetencion_NombreCol))
                    row.NRO_COMPROBANTE = (string)campos[OrdenesPagoValoresService.NroComprobanteRetencion_NombreCol];

                sesion.Db.ORDENES_PAGO_VALORESCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                //Se recalculan los totales de la cabecera
                OrdenesPagoService.CalcularTotales(row.ORDEN_PAGO_ID, sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal orden_pago_valor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Borrar(orden_pago_valor_id, sesion);
            }
        }

        /// <summary>
        /// Borrars the specified orden_pago_valor_id.
        /// </summary>
        /// <param name="orden_pago_valor_id">The orden_pago_valor_id.</param>
        public static void Borrar(decimal orden_pago_valor_id, SessionService sesion)
        {
            try
            { 
                ORDENES_PAGO_VALORESRow row = sesion.Db.ORDENES_PAGO_VALORESCollection.GetByPrimaryKey(orden_pago_valor_id);

                if (row != null)
                {
                    sesion.Db.ORDENES_PAGO_VALORESCollection.DeleteByPrimaryKey(orden_pago_valor_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    //Se recalculan los totales de la cabecera
                    OrdenesPagoService.CalcularTotales(row.ORDEN_PAGO_ID, sesion);    
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion borrar

        #region ActualizarDatosRetencion
        public static void ActualizarDatosRetencion(decimal retencionIdAnterior, decimal retencionIdNuevo, SessionService sesion)
        {
            try
            {
                ORDENES_PAGO_VALORESRow[] rowAnterior = sesion.Db.ORDENES_PAGO_VALORESCollection.GetAsArray(RetencionEmitidaId_NombreCol + " = " + retencionIdAnterior, string.Empty);

                //Actualizar Valor
                for (int i = 0; i < rowAnterior.Length; i++)
                {
                    rowAnterior[i].RETENCION_EMITIDA_ID = retencionIdNuevo;
                    sesion.Db.ORDENES_PAGO_VALORESCollection.Update(rowAnterior[i]);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }
        #endregion ActualizarDatosRetencion

        #region Actualizar Nro. Retencion
        public static void ActualizarRetenciones(decimal valorId, string nroRetencion)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DataTable dtValor;
                    ORDENES_PAGO_VALORESRow valorRow;
                    string valorAnterior;

                    string clausula = OrdenesPagoValoresService.Id_NombreCol + " = " + valorId.ToString();
                    dtValor = OrdenesPagoValoresService.GetOrdenesPagoValoresDataTable(clausula, string.Empty);
                    valorRow = sesion.Db.ORDENES_PAGO_VALORESCollection.GetByPrimaryKey(decimal.Parse(dtValor.Rows[0][OrdenesPagoValoresService.Id_NombreCol].ToString()));
                    valorAnterior = dtValor.ToString();
                    valorRow.NRO_COMPROBANTE = nroRetencion;

                    sesion.Db.ORDENES_PAGO_VALORESCollection.Update(valorRow);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, valorRow.ID, valorAnterior, valorRow.ToString(), sesion);
               
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Actualizar Nro. Retencion

        #region ReemplazarCheque
        public static void ReemplazarCheque(System.Collections.Hashtable campos, bool anularCheque)
        { 
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    decimal valorId = (decimal)campos[OrdenesPagoValoresService.Id_NombreCol];
                    ORDENES_PAGO_VALORESRow valorReemplazadoRow = sesion.db.ORDENES_PAGO_VALORESCollection.GetByPrimaryKey(valorId);
                    DataTable dtOrdenesPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.Id_NombreCol + " = " + valorReemplazadoRow.ORDEN_PAGO_ID, string.Empty, sesion);
                    CASOSRow casoRow = sesion.db.CASOSCollection.GetByPrimaryKey((decimal)dtOrdenesPago.Rows[0][OrdenesPagoService.CasoId_NombreCol]);

                    #region Se anula el cheque girado asociado al valor de la OP y se borra ese valor
                    // O se anula el cheque
                    if (anularCheque)
                    {
                        //Se anula el cheque
                        CuentaCorrienteChequesGiradosService.Anular(valorReemplazadoRow.CG_CTACTE_CHEQUE_GIRADO_ID,
                                                  "Reemplazo de cheque en Orden de Pago " + Traducciones.Caso + " " + dtOrdenesPago.Rows[0][OrdenesPagoService.CasoId_NombreCol].ToString() + " en estado " + casoRow.ESTADO_ID + ".",
                                                  sesion);
                    }
                    // O se borra el cheque y sus movimientos asociados
                    else
                    {
                        // Se borra el cheque girado
                        CuentaCorrienteChequesGiradosService.Borrar(valorReemplazadoRow.CG_CTACTE_CHEQUE_GIRADO_ID, sesion);
                    }

                    //Se afecta la cuenta bancaria si el cheque ya la habia afectado
                    if (CuentaCorrienteChequesGiradosService.SaldoAfectado(valorReemplazadoRow.CG_CTACTE_CHEQUE_GIRADO_ID, sesion))
                    {
                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                              valorReemplazadoRow.CG_CTACTE_BANCARIA_ID,
                              Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                              casoRow.ID,
                              Definiciones.Error.Valor.EnteroPositivo,
                              (decimal)dtOrdenesPago.Rows[0][OrdenesPagoService.Id_NombreCol],
                              valorReemplazadoRow.MONEDA_ORIGEN_ID,
                              valorReemplazadoRow.MONTO_ORIGEN,
                              valorReemplazadoRow.COTIZACION_MONEDA_ORIGEN,
                              valorReemplazadoRow.CG_FECHA_VENCIMIENTO,
                              "Reemplazo de cheque en Caso " + dtOrdenesPago.Rows[0][OrdenesPagoService.CasoId_NombreCol] + " de " + Definiciones.FlujosIDs.GetNombre(Definiciones.FlujosIDs.ORDEN_DE_PAGO) + " " + dtOrdenesPago.Rows[0][OrdenesPagoService.NroComprobante_NombreCol] + " en estado " + casoRow.ESTADO_ID + ". Anulación del cheque " + valorReemplazadoRow.CG_NUMERO_CHEQUE + " fecha " + valorReemplazadoRow.CG_FECHA_EMISION.Date + ".",
                              valorReemplazadoRow.CG_CTACTE_CHEQUE_GIRADO_ID,
                              null,
                              true,
                              sesion);
                    }

                    // Se borra el valor asociado
                    OrdenesPagoValoresService.Borrar(valorId, sesion);
                    #endregion Se anula el cheque girado asociado al valor de la OP y se borra ese valor

                    #region Se crea el nuevo valor, el cheque girado asociado y se realizan las acciones correspondientes a la transicion a GENERACION de la OP
                    // Se crea un nuevo valor para la OP con los datos del cheque nuevo
                    decimal valorNuevoId = OrdenesPagoValoresService.Guardar(campos, sesion);

                    ORDENES_PAGO_VALORESRow valorNuevoRow = sesion.db.ORDENES_PAGO_VALORESCollection.GetByPrimaryKey(valorNuevoId);
                    System.Collections.Hashtable camposCG = new System.Collections.Hashtable();
                    decimal autonumeracion_id = Definiciones.Error.Valor.EnteroPositivo;
                    string nroCheque;

                    camposCG.Add(CuentaCorrienteChequesGiradosService.CasoCreadorId_NombreCol, (decimal)dtOrdenesPago.Rows[0][OrdenesPagoService.CasoId_NombreCol]);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.CotizacionMoneda_NombreCol, valorNuevoRow.COTIZACION_MONEDA_ORIGEN);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.CtaCteBancariaId_NombreCol, valorNuevoRow.CG_CTACTE_BANCARIA_ID);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol, valorNuevoRow.CG_ES_DIFERIDO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.FechaPosdatado_NombreCol, valorNuevoRow.CG_FECHA_EMISION);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol, valorNuevoRow.CG_FECHA_VENCIMIENTO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.MonedaId_NombreCol, valorNuevoRow.MONEDA_ORIGEN_ID);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.Monto_NombreCol, valorNuevoRow.MONTO_ORIGEN);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol, valorNuevoRow.CG_NOMBRE_BENEFICIARIO);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.NumeroCtaBeneficiario_NombreCol, Interprete.ObtenerString(valorNuevoRow.CG_NUMERO_CTA_BENEFICIARIO));
                    camposCG.Add(CuentaCorrienteChequesGiradosService.NombreEmisor_NombreCol, valorNuevoRow.CG_NOMBRE_EMISOR);
                    camposCG.Add(CuentaCorrienteChequesGiradosService.Observacion_NombreCol, valorNuevoRow.OBSERVACION);

                    if (!valorNuevoRow.IsCG_AUTONUMERACION_IDNull)
                    {
                        autonumeracion_id = valorNuevoRow.CG_AUTONUMERACION_ID;
                        camposCG.Add(CuentaCorrienteChequesGiradosService.AutonumeracionId_NombreCol, valorNuevoRow.CG_AUTONUMERACION_ID);
                    }

                    if (valorNuevoRow.CG_NUMERO_CHEQUE != null && valorNuevoRow.CG_NUMERO_CHEQUE.Length > 0)
                        camposCG.Add(CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol, valorNuevoRow.CG_NUMERO_CHEQUE);

                    //Se crea el cheque girado
                    valorNuevoRow.CG_CTACTE_CHEQUE_GIRADO_ID = CuentaCorrienteChequesGiradosService.Emitir(camposCG, autonumeracion_id, out nroCheque, sesion);
                    valorNuevoRow.CG_NUMERO_CHEQUE = nroCheque;

                    //Se actualiza en la base de datos el id del cheque girado
                    sesion.Db.ORDENES_PAGO_VALORESCollection.Update(valorNuevoRow);

                    //Se afecta la cuenta bancaria si el cheque no es adelantado
                    if (valorNuevoRow.CG_FECHA_VENCIMIENTO.Date <= DateTime.Now.Date && valorNuevoRow.CG_ES_DIFERIDO == Definiciones.SiNo.No)
                    {
                        CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                              valorNuevoRow.CG_CTACTE_BANCARIA_ID,
                              Definiciones.FlujosIDs.ORDEN_DE_PAGO,
                              (decimal)dtOrdenesPago.Rows[0][OrdenesPagoService.CasoId_NombreCol],
                              Definiciones.Error.Valor.EnteroPositivo,
                              (decimal)dtOrdenesPago.Rows[0][OrdenesPagoService.Id_NombreCol],
                              valorNuevoRow.MONEDA_ORIGEN_ID,
                              valorNuevoRow.MONTO_ORIGEN * (-1),
                              valorNuevoRow.COTIZACION_MONEDA_ORIGEN,
                              (DateTime)dtOrdenesPago.Rows[0][OrdenesPagoService.Fecha_NombreCol],
                              "Reemplazo de cheque en Caso " + dtOrdenesPago.Rows[0][OrdenesPagoService.CasoId_NombreCol] + " de " + FlujosService.GetDescripcionImpresion(Definiciones.FlujosIDs.ORDEN_DE_PAGO) + " " + dtOrdenesPago.Rows[0][OrdenesPagoService.NroComprobante_NombreCol] + " (" + valorNuevoRow.CG_NOMBRE_BENEFICIARIO + "). Cheque " + valorNuevoRow.CG_NUMERO_CHEQUE + " fecha " + valorNuevoRow.CG_FECHA_EMISION.Date + ".",
                              valorNuevoRow.CG_CTACTE_CHEQUE_GIRADO_ID,
                              null,
                              false,
                              sesion);
                    }
                    #endregion Se crea el nuevo valor, el cheque girado asociado y se realizan las acciones correspondientes a la transicion a GENERACION de la OP

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion ReemplazarCheque

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ORDENES_PAGO_VALORES"; }
        }
        public static string Nombre_Vista
        {
            get { return "ordenes_pago_valores_info_comp"; }
        }
        public static string AjusteBancarioId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.AJUSTE_BANCARIO_IDColumnName; }
        }
        public static string AnticipoProveedorId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.ANTICIPO_PROVEEDOR_IDColumnName; }
        }
        public static string CGAutonumeracionId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_AUTONUMERACION_IDColumnName; }
        }
        public static string CGCtacteBancariaId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_CTACTE_BANCARIA_IDColumnName; }
        }
        public static string CGCtacteChequeGiradoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_CTACTE_CHEQUE_GIRADO_IDColumnName; }
        }
        public static string CGEsDiferido_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_ES_DIFERIDOColumnName; }
        }
        public static string CGFechaEmision_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_FECHA_EMISIONColumnName; }
        }
        public static string CGFechaVencimiento_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_FECHA_VENCIMIENTOColumnName; }
        }
        public static string CGNombreBeneficiario_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_NOMBRE_BENEFICIARIOColumnName; }
        }
        public static string CGNombreEmisor_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_NOMBRE_EMISORColumnName; }
        }
        public static string CGNumeroCheque_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_NUMERO_CHEQUEColumnName; }
        }
        public static string CGNumeroCtaBeneficiario_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_NUMERO_CTA_BENEFICIARIOColumnName; }
        }
        public static string CGUsarAutonum_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CG_USAR_AUTONUMColumnName; }
        }
        public static string CotizacionMonedaDestino_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.COTIZACION_MONEDA_DESTINOColumnName; }
        }
        public static string CotizacionMonedaOrigen_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.COTIZACION_MONEDA_ORIGENColumnName; }
        }
        public static string CRCtacteChequeRecibidoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CR_CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string DebitoAutomCtacteBancId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.DEBITO_AUTOM_CTACTE_BANC_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoDestino_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.MONTO_DESTINOColumnName; }
        }
        public static string MontoOrigen_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.MONTO_ORIGENColumnName; }
        }
        public static string NroComprobanteRetencion_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NotaCreditoProveedorId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.NOTA_CREDITO_PROVEEDOR_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.OBSERVACIONColumnName; }
        }
        public static string OrdenPagoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.ORDEN_PAGO_IDColumnName; }
        }
        public static string TCCtacteTarjetaCreditoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.TC_CTACTE_TARJETA_CREDITO_IDColumnName; }
        }
        public static string TCCupon_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.TC_CUPONColumnName; }
        }
        public static string TransferenciaBancariaId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.TRANSFERENCIA_BANCARIA_IDColumnName; }
        }
        public static string RetencionAuxCasos_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.RETENCION_AUX_CASOSColumnName; }
        }
        public static string RetencionAuxMontos_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.RETENCION_AUX_MONTOSColumnName; }
        }
        public static string RetencionEmitidaId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.RETENCION_EMITIDA_IDColumnName; }
        }
        public static string RetencionTipoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.RETENCION_TIPO_IDColumnName; }
        }
        public static string RetencionFecha_NombreCol
        {
            get { return ORDENES_PAGO_VALORESCollection.RETENCION_FECHAColumnName; }
        }
        public static string VistaAjusteBancarioBancoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.AJUSTE_BANC_BANCO_IDColumnName; }
        }
        public static string VistaAjusteBancarioBancoNombre_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.AJUSTE_BANC_BANCO_NOMBREColumnName; }
        }
        public static string VistaAjusteBancarioCuentaBancariaId_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.AJUSTE_BANC_CTA_BANCARIA_IDColumnName; }
        }
        public static string VistaAjusteBancarioCuentaNumero_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.AJUSTE_BANC_CUENTA_NROColumnName; }
        }
        public static string VistaAjusteBancarioCasoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.AJUSTE_BANCARIO_CASO_IDColumnName; }
        }
        public static string VistaCasoRelacionadoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.CASO_RELACIONADO_IDColumnName; }
        }
        public static string VistaCGCtacteBancariaNumero_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.CG_CTACTE_BANCARIA_NUMEROColumnName; }
        }
        public static string VistaCGCtacteBancoAbreviatura_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.CG_CTACTE_BANCO_ABREVIATURAColumnName; }
        }
        public static string VistaCGCtacteBancoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.CG_CTACTE_BANCO_IDColumnName; }
        }
        public static string VistaCGCtacteBancariaId_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.CG_CTACTE_BANCARIA_IDColumnName; }
        }
        public static string VistaCGCtacteBancoNombre_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.CG_CTACTE_BANCO_NOMBREColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaMonedaOrigenNombre_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.MONEDA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaMonedaOrigenSimbolo_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.MONEDA_ORIGEN_SIMBOLOColumnName; }
        }
        public static string VistaOrdenPagoCasoEstadoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.ORDEN_PAGO_CASO_ESTADO_IDColumnName; }
        }
        public static string VistaOrdenPagoCasoId_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.ORDEN_PAGO_CASO_IDColumnName; }
        }
        public static string VistaResumen_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.RESUMENColumnName; }
        }
        public static string VistaRetencionEmitidaEstado_NombreCol
        {
            get { return ORDENES_PAGO_VALORES_INFO_COMPCollection.RETENCION_EMITIDA_ESTADOColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static OrdenesPagoValoresService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });
            
            if (e == null)
                return null;
            else
                return new OrdenesPagoValoresService(e.RegistroId, sesion);
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
        protected ORDENES_PAGO_VALORESRow row;
        protected ORDENES_PAGO_VALORESRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AjusteBancarioId { get { if (row.IsAJUSTE_BANCARIO_IDNull) return null; else return row.AJUSTE_BANCARIO_ID; } set { if (value.HasValue) row.AJUSTE_BANCARIO_ID = value.Value; else row.IsAJUSTE_BANCARIO_IDNull = true; } }
        public decimal? AnticipoProveedorId { get { if (row.IsANTICIPO_PROVEEDOR_IDNull) return null; else return row.ANTICIPO_PROVEEDOR_ID; } set { if (value.HasValue) row.ANTICIPO_PROVEEDOR_ID = value.Value; else row.IsANTICIPO_PROVEEDOR_IDNull = true; } }
        public decimal? CGAutonumeracionId { get { if (row.IsCG_AUTONUMERACION_IDNull) return null; else return row.CG_AUTONUMERACION_ID; } set { if (value.HasValue) row.CG_AUTONUMERACION_ID = value.Value; else row.IsCG_AUTONUMERACION_IDNull = true; } }
        public decimal? CGCtacteBancariaId { get { if (row.IsCG_CTACTE_BANCARIA_IDNull) return null; else return row.CG_CTACTE_BANCARIA_ID; } set { if (value.HasValue) row.CG_CTACTE_BANCARIA_ID = value.Value; else row.IsCG_CTACTE_BANCARIA_IDNull = true; } }
        public decimal? CGCtacteChequeGiradoId { get { if (row.IsCG_CTACTE_CHEQUE_GIRADO_IDNull) return null; else return row.CG_CTACTE_CHEQUE_GIRADO_ID; } set { if (value.HasValue) row.CG_CTACTE_CHEQUE_GIRADO_ID = value.Value; else row.IsCG_CTACTE_CHEQUE_GIRADO_IDNull = true; } }
        public string CGEsDiferido { get { return ClaseCBABase.GetStringHelper(row.CG_ES_DIFERIDO); } set { row.CG_ES_DIFERIDO = value; } }
        public DateTime? CGFechaEmision { get { if (row.IsCG_FECHA_EMISIONNull) return null; else return row.CG_FECHA_EMISION; } set { if (value.HasValue) row.CG_FECHA_EMISION = value.Value; else row.IsCG_FECHA_EMISIONNull = true; } }
        public DateTime? CGFechaVencimiento { get { if (row.IsCG_FECHA_VENCIMIENTONull) return null; else return row.CG_FECHA_VENCIMIENTO; } set { if (value.HasValue) row.CG_FECHA_VENCIMIENTO = value.Value; else row.IsCG_FECHA_VENCIMIENTONull = true; } }
        public string CGNombreBeneficiario { get { return ClaseCBABase.GetStringHelper(row.CG_NOMBRE_BENEFICIARIO); } set { row.CG_NOMBRE_BENEFICIARIO = value; } }
        public string CGNombreEmisor { get { return ClaseCBABase.GetStringHelper(row.CG_NOMBRE_EMISOR); } set { row.CG_NOMBRE_EMISOR = value; } }
        public string CGNumeroCheque { get { return ClaseCBABase.GetStringHelper(row.CG_NUMERO_CHEQUE); } set { row.CG_NUMERO_CHEQUE = value; } }
        public string CGNumeroCtaBeneficiario { get { return ClaseCBABase.GetStringHelper(row.CG_NUMERO_CTA_BENEFICIARIO); } set { row.CG_NUMERO_CTA_BENEFICIARIO = value; } }
        public string CGUsarAutonum { get { return ClaseCBABase.GetStringHelper(row.CG_USAR_AUTONUM); } set { row.CG_USAR_AUTONUM = value; } }
        public decimal CotizacionMonedaDestino { get { return row.COTIZACION_MONEDA_DESTINO; } set { row.COTIZACION_MONEDA_DESTINO = value; } }
        public decimal CotizacionMonedaOrigen { get { return row.COTIZACION_MONEDA_ORIGEN; } set { row.COTIZACION_MONEDA_ORIGEN = value; } }
        public decimal? CRCtacteChequeRecibidoId { get { if (row.IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull) return null; else return row.CR_CTACTE_CHEQUE_RECIBIDO_ID; } set { if (value.HasValue) row.CR_CTACTE_CHEQUE_RECIBIDO_ID = value.Value; else row.IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull = true; } }
        public decimal CtacteValorId { get { return row.CTACTE_VALOR_ID; } set { row.CTACTE_VALOR_ID = value; } }
        public decimal? DebitoAutomCtacteBancId { get { if (row.IsDEBITO_AUTOM_CTACTE_BANC_IDNull) return null; else return row.DEBITO_AUTOM_CTACTE_BANC_ID; } set { if (value.HasValue) row.DEBITO_AUTOM_CTACTE_BANC_ID = value.Value; else row.IsDEBITO_AUTOM_CTACTE_BANC_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaOrigenId { get { return row.MONEDA_ORIGEN_ID; } set { row.MONEDA_ORIGEN_ID = value; } }
        public decimal MontoDestino { get { return row.MONTO_DESTINO; } set { row.MONTO_DESTINO = value; } }
        public decimal MontoOrigen { get { return row.MONTO_ORIGEN; } set { row.MONTO_ORIGEN = value; } }
        public decimal? NotaCreditoProveedorId { get { if (row.IsNOTA_CREDITO_PROVEEDOR_IDNull) return null; else return row.NOTA_CREDITO_PROVEEDOR_ID; } set { if (value.HasValue) row.NOTA_CREDITO_PROVEEDOR_ID = value.Value; else row.IsNOTA_CREDITO_PROVEEDOR_IDNull = true; } }
        public string NroComprobante { get { return ClaseCBABase.GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal OrdenPagoId { get { return row.ORDEN_PAGO_ID; } set { row.ORDEN_PAGO_ID = value; } }
        public string RetencionAuxCasos { get { return ClaseCBABase.GetStringHelper(row.RETENCION_AUX_CASOS); } set { row.RETENCION_AUX_CASOS = value; } }
        public string RetencionAuxMontos { get { return ClaseCBABase.GetStringHelper(row.RETENCION_AUX_MONTOS); } set { row.RETENCION_AUX_MONTOS = value; } }
        public decimal? RetencionEmitidaId { get { if (row.IsRETENCION_EMITIDA_IDNull) return null; else return row.RETENCION_EMITIDA_ID; } set { if (value.HasValue) row.RETENCION_EMITIDA_ID = value.Value; else row.IsRETENCION_EMITIDA_IDNull = true; } }
        public DateTime? RetencionFecha { get { if (row.IsRETENCION_FECHANull) return null; else return row.RETENCION_FECHA; } set { if (value.HasValue) row.RETENCION_FECHA = value.Value; else row.IsRETENCION_FECHANull = true; } }
        public decimal? RetencionTipoId { get { if (row.IsRETENCION_TIPO_IDNull) return null; else return row.RETENCION_TIPO_ID; } set { if (value.HasValue) row.RETENCION_TIPO_ID = value.Value; else row.IsRETENCION_TIPO_IDNull = true; } }
        public string TCCupon { get { return ClaseCBABase.GetStringHelper(row.TC_CUPON); } set { row.TC_CUPON = value; } }
        public decimal? TCCtacteTarjetaCreditoId { get { if (row.IsTC_CTACTE_TARJETA_CREDITO_IDNull) return null; else return row.TC_CTACTE_TARJETA_CREDITO_ID; } set { if (value.HasValue) row.TC_CTACTE_TARJETA_CREDITO_ID = value.Value; else row.IsTC_CTACTE_TARJETA_CREDITO_IDNull = true; } }
        public decimal? TransferenciaBancariaId { get { if (row.IsTRANSFERENCIA_BANCARIA_IDNull) return null; else return row.TRANSFERENCIA_BANCARIA_ID; } set { if (value.HasValue) row.TRANSFERENCIA_BANCARIA_ID = value.Value; else row.IsTRANSFERENCIA_BANCARIA_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CuentaCorrienteCuentasBancariasService _debito_autom_ctacte_banc;
        public CuentaCorrienteCuentasBancariasService DebitoAutomCtacteBanc
        {
            get
            {
                if (this._debito_autom_ctacte_banc == null)
                    this._debito_autom_ctacte_banc = new CuentaCorrienteCuentasBancariasService(this.DebitoAutomCtacteBancId.Value);
                return this._debito_autom_ctacte_banc;
            }
        }

        private MonedasService _moneda_origen;
        public MonedasService MonedaOrigen
        {
            get
            {
                if (this._moneda_origen == null)
                    this._moneda_origen = new MonedasService(this.MonedaOrigenId);
                return this._moneda_origen;
            }
        }

        private OrdenesPagoService _orden_pago;
        public OrdenesPagoService OrdenPago
        {
            get
            {
                if (this._orden_pago == null)
                    this._orden_pago = new OrdenesPagoService(this.OrdenPagoId);
                return this._orden_pago;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ORDENES_PAGO_VALORESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ORDENES_PAGO_VALORESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(ORDENES_PAGO_VALORESRow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public OrdenesPagoValoresService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public OrdenesPagoValoresService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public OrdenesPagoValoresService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
       
        private OrdenesPagoValoresService(ORDENES_PAGO_VALORESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCabecera
        public static OrdenesPagoValoresService[] GetPorCabecera(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCabecera(cabecera_id, sesion);
            }
        }

        public static OrdenesPagoValoresService[] GetPorCabecera(decimal cabecera_id, SessionService sesion)
        {
            var rows = sesion.db.ORDENES_PAGO_VALORESCollection.GetAsArray(OrdenesPagoValoresService.OrdenPagoId_NombreCol + " = "  + cabecera_id, OrdenesPagoValoresService.Id_NombreCol);
            OrdenesPagoValoresService[] opv = new OrdenesPagoValoresService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                opv[i] = new OrdenesPagoValoresService(rows[i]);
            return opv;
        }
        #endregion GetPorCabecera

       
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
