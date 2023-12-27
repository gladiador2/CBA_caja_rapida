#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class DescuentoDocumentosPagosService
    {
        #region GetDescuentoDocumentosPagosDataTable
        /// <summary>
        /// Gets the descuentos documentos pagos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetDescuentosDocumentosPagosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESCUENTO_DOCUMENTOS_PAGOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentoDocumentosPagosDataTable

        #region GetDescuentoDocumentosPagosInfoCompleta
        /// <summary>
        /// Gets the descuento documentos pagos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetDescuentoDocumentosPagosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESC_DOCS_PAGOS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentosDocumentosPagosInfoCompleta

        #region VerificarEstaRepetido
        /// <summary>
        /// Verificars the esta repetido.
        /// </summary>
        /// <param name="ctacte_valor_id">The ctacte_valor_id.</param>
        /// <param name="columna">The columna.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <returns></returns>
        public bool VerificarEstaRepetido(int ctacte_valor_id, string columna, decimal registro_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas;
                bool repetido = false;
                DataTable dtDetalles, dtDescuentoDcoumentos;
                DescuentoDocumentosService descuentoDocumentos = new DescuentoDocumentosService();

                clausulas = DescuentoDocumentosPagosService.CtacteValorId_NombreCol + " = " + ctacte_valor_id + " and " + 
                            columna + " = " + registro_id;

                dtDetalles = sesion.Db.DESCUENTO_DOCUMENTOS_PAGOSCollection.GetAsDataTable(clausulas, string.Empty);

                //Si esta asociado a un caso, verificar que el caso no esta en anulado
                if (dtDetalles.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    {
                        dtDescuentoDcoumentos = descuentoDocumentos.GetDescuentoDocumentosInfoCompleta(DescuentoDocumentosService.Id_NombreCol + " = " + dtDetalles.Rows[i][DescuentoDocumentosPagosService.DescuentoDocumentoId_NombreCol], string.Empty);

                        //Si el caso que asocia no esta en estado anulado, entonces esta repetido
                        if ((string)dtDescuentoDcoumentos.Rows[0][DescuentoDocumentosService.VistaCasoEstadoId_NombreCol] != Definiciones.EstadosFlujos.Anulado)
                            repetido = true;

                        if(repetido) break;
                    }
                }

                return repetido;
            }
        }
        #endregion VerificarEstaRepetido

        #region GuardarIdChequeCreado
        /// <summary>
        /// Guardars the id cheque creado.
        /// </summary>
        /// <param name="descuento_documento_pago_id">The descuento_documento_pago_id.</param>
        /// <param name="ctacte_cheque_recibido_d">The ctacte_cheque_recibido_d.</param>
        /// <param name="sesion">The sesion.</param>
        public void GuardarIdChequeCreado(decimal descuento_documento_pago_id, decimal ctacte_cheque_recibido_id, SessionService sesion)
        {
            DESCUENTO_DOCUMENTOS_PAGOSRow row = sesion.Db.DESCUENTO_DOCUMENTOS_PAGOSCollection.GetByPrimaryKey(descuento_documento_pago_id);
            string valorAnterior = row.ToString();
            row.CTACTE_CHEQUE_RECIBIDO_ID = ctacte_cheque_recibido_id;
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion GuardarIdChequeCreado

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DESCUENTO_DOCUMENTOS_PAGOSRow row = new DESCUENTO_DOCUMENTOS_PAGOSRow();
                    DescuentoDocumentosService descuentoDocumento = new DescuentoDocumentosService();
                    DataTable dtDescuentoDocumento;
                    string valorAnterior = string.Empty;
                    int ctacteValorId;

                    row.ID = sesion.Db.GetSiguienteSecuencia("DESCUENTO_DOCUMENTOS_PAGOS_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;

                    ctacteValorId = (int)campos[DescuentoDocumentosPagosService.CtacteValorId_NombreCol];
                    row.CTACTE_VALOR_ID = Convert.ToDecimal(ctacteValorId);

                    row.DESCUENTO_DOCUMENTO_ID = (decimal)campos[DescuentoDocumentosPagosService.DescuentoDocumentoId_NombreCol];
                    dtDescuentoDocumento = descuentoDocumento.GetDescuentoDocumentosDataTable(DescuentoDocumentosService.Id_NombreCol + " = " + row.DESCUENTO_DOCUMENTO_ID, string.Empty);

                    switch (ctacteValorId)
                    { 
                        case Definiciones.CuentaCorrienteValores.Efectivo:
                            break;
                        case Definiciones.CuentaCorrienteValores.Cheque: 
                            row.CHEQUE_CTACTE_BANCO_ID = (decimal)campos[DescuentoDocumentosPagosService.ChequeCtacteBancoId_NombreCol];
                            if (!CuentaCorrienteBancosService.EstaActivo(row.CHEQUE_CTACTE_BANCO_ID))
                                throw new Exception("El banco no se encuentra activo.");

                            row.CHEQUE_ES_DIFERIDO = (string)campos[DescuentoDocumentosPagosService.ChequeEsDiferido_NombreCol];
                            row.CHEQUE_FECHA_POSTDATADO = (DateTime)campos[DescuentoDocumentosPagosService.ChequeFechaPostdatado_NombreCol];
                            row.CHEQUE_FECHA_VENCIMIENTO = (DateTime)campos[DescuentoDocumentosPagosService.ChequeFechaVencimiento_NombreCol];
                            row.CHEQUE_NOMBRE_BENEFICIARIO = (string)campos[DescuentoDocumentosPagosService.ChequeNombreBeneficiario_NombreCol];
                            row.CHEQUE_NOMBRE_EMISOR = (string)campos[DescuentoDocumentosPagosService.ChequeNombreEmisor_NombreCol];
                            row.CHEQUE_NRO_CHEQUE = (string)campos[DescuentoDocumentosPagosService.ChequeNroCheque_NombreCol];
                            row.CHEQUE_NRO_CUENTA = (string)campos[DescuentoDocumentosPagosService.ChequeNroCuenta_NombreCol];
                            row.CHEQUE_DOCUMENTO_EMISOR = (string)campos[DescuentoDocumentosPagosService.ChequeDocumentoEmisor_NombreCol];
                            break;
                        case Definiciones.CuentaCorrienteValores.DepositoBancario:
                            row.DEPOSITO_CTACTE_BANCARIA_ID = (decimal)campos[DescuentoDocumentosPagosService.DepositoCtacteBancariaId_NombreCol];row.DEPOSITO_CTACTE_BANCARIA_ID = (decimal)campos[DescuentoDocumentosPagosService.DepositoCtacteBancariaId_NombreCol];
                            if (!CuentaCorrienteCuentasBancariasService.EstaActivo(row.DEPOSITO_CTACTE_BANCARIA_ID))
                                throw new Exception("La cuenta bancaria no se encuentra activa.");
                            row.DEPOSITO_FECHA = (DateTime)campos[DescuentoDocumentosPagosService.DepositoFecha_NombreCol];
                            row.DEPOSITO_NRO_BOLETA = (string)campos[DescuentoDocumentosPagosService.DepositoNroBoleta_NombreCol];
                            break;
                        case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                            row.TRANSFERENCIA_BANCARIA_ID = (decimal)campos[DescuentoDocumentosPagosService.TransferenciaBancariaId_NombreCol];
                            break;
                        default:
                            throw new Exception("DescuentoDocumentosPagosService.Guardar(). Tipo de valor no implementado.");
                    }

                    if (ctacteValorId.Equals(Definiciones.CuentaCorrienteValores.TransferenciaBancaria))
                    {
                        DataTable dtTransferencia = TransferenciasBancariasService.GetDataTable(TransferenciasBancariasService.Id_NombreCol + " = " + row.TRANSFERENCIA_BANCARIA_ID, string.Empty, sesion);

                        row.MONEDA_ID = (decimal)dtTransferencia.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol];
                        if (!MonedasService.EstaActivo(row.MONEDA_ID))
                            throw new System.Exception("La moneda se encuentra inactiva.");

                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtDescuentoDocumento.Rows[0][DescuentoDocumentosService.SucursalId_NombreCol]), row.MONEDA_ID, (DateTime)dtDescuentoDocumento.Rows[0][DescuentoDocumentosService.Fecha_NombreCol], sesion);
                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");

                        row.MONTO = (decimal)dtTransferencia.Rows[0][TransferenciasBancariasService.MontoDestino_NombreCol];
                    }
                    else
                    {
                        row.MONEDA_ID = (decimal)campos[DescuentoDocumentosPagosService.MonedaId_NombreCol];
                        if (!MonedasService.EstaActivo(row.MONEDA_ID))
                            throw new System.Exception("La moneda se encuentra inactiva.");

                        row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtDescuentoDocumento.Rows[0][DescuentoDocumentosService.SucursalId_NombreCol]), row.MONEDA_ID, (DateTime)dtDescuentoDocumento.Rows[0][DescuentoDocumentosService.Fecha_NombreCol], sesion);
                        if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("Debe actualizarse la cotización de la moneda.");

                        row.MONTO = (decimal)campos[DescuentoDocumentosPagosService.Monto_NombreCol];
                    }

                    sesion.Db.DESCUENTO_DOCUMENTOS_PAGOSCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        #endregion Guardar

        #region Borrar

        /// <summary>
        /// Borrars the specified descuento documento pagos id.
        /// </summary>
        /// <param name="descuento_documento_pago_id">The descuento_documento_pago_id.</param>
        public void Borrar(decimal descuento_documento_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DESCUENTO_DOCUMENTOS_PAGOSRow row;

                    row = sesion.Db.DESCUENTO_DOCUMENTOS_PAGOSCollection.GetByPrimaryKey(descuento_documento_pago_id);

                    sesion.Db.DESCUENTO_DOCUMENTOS_PAGOSCollection.DeleteByPrimaryKey(descuento_documento_pago_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "DESCUENTO_DOCUMENTOS_PAGOS"; }
        }

        public static string ChequeCtacteBancoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CHEQUE_CTACTE_BANCO_IDColumnName; }
        }

        public static string ChequeEsDiferido_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CHEQUE_ES_DIFERIDOColumnName; }
        }

        public static string ChequeFechaPostdatado_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CHEQUE_FECHA_POSTDATADOColumnName; }
        }

        public static string ChequeFechaVencimiento_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CHEQUE_FECHA_VENCIMIENTOColumnName; }
        }

        public static string ChequeNombreBeneficiario_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CHEQUE_NOMBRE_BENEFICIARIOColumnName; }
        }

        public static string ChequeNombreEmisor_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CHEQUE_NOMBRE_EMISORColumnName; }
        }

        public static string ChequeNroCheque_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CHEQUE_NRO_CHEQUEColumnName; }
        }

        public static string ChequeNroCuenta_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CHEQUE_NRO_CUENTAColumnName; }
        }

        public static string ChequeDocumentoEmisor_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CHEQUE_DOCUMENTO_EMISORColumnName; }
        }

        public static string CotizacionMoneda_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.COTIZACION_MONEDAColumnName; }
        }

        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }

        public static string CtacteValorId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string DepositoBancarioId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.DEPOSITO_BANCARIO_IDColumnName; }
        }
        public static string DepositoCtacteBancariaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.DEPOSITO_CTACTE_BANCARIA_IDColumnName; }
        }
        public static string DepositoFecha_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.DEPOSITO_FECHAColumnName; }
        }
        public static string DepositoNroBoleta_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.DEPOSITO_NRO_BOLETAColumnName; }
        }
        public static string DescuentoDocumentoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.DESCUENTO_DOCUMENTO_IDColumnName; }
        }

        public static string Id_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.IDColumnName; }
        }

        public static string MonedaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.MONEDA_IDColumnName; }
        }

        public static string Monto_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.MONTOColumnName; }
        }
        public static string TransferenciaBancariaId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_PAGOSCollection.TRANSFERENCIA_BANCARIA_IDColumnName; }
        }

        public static string VistaCtacteBancoNombre_NombreCol
        {
            get { return DESC_DOCS_PAGOS_INFO_COMPLCollection.CHEQUE_CTACTE_BANCO_NOMBREColumnName; }
        }

        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return DESC_DOCS_PAGOS_INFO_COMPLCollection.CTACTE_VALOR_NOMBREColumnName; }
        }

        public static string VistaMonedaNombre_NombreCol
        {
            get { return DESC_DOCS_PAGOS_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }

        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return DESC_DOCS_PAGOS_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaObservacion_NombreCol
        {
            get { return DESC_DOCS_PAGOS_INFO_COMPLCollection.OBSERVACIONColumnName; }
        }
        #endregion Accessors
    }
}
