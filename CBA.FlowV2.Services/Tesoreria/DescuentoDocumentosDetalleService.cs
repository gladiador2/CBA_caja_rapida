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
    public class DescuentoDocumentosDetalleService
    {
        #region GetDescuentoDocumentosDetalleDataTable
        /// <summary>
        /// Gets the descuento documentos detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetDescuentoDocumentosDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESCUENTO_DOCUMENTOS_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetDescuentoDocumentosDetalleDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESCUENTO_DOCUMENTOS_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentoDocumentosDetalleDataTable

        #region GetDescuentoDocumentosDetalleInfoCompleta

        /// <summary>
        /// Gets the descuento documentos detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetDescuentoDocumentosDetalleInfoCompleta(string clausulas,  string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.DESC_DOCS_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDescuentoDocumentosDetalleInfoCompleta

        #region Guardar

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public void Guardar(bool insertarNuevo, System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DescuentoDocumentosService descuentoDocumentos = new DescuentoDocumentosService();
                    DataTable dtDescuentoDocumentos, dtChequeRecibido, dtPagareDet;
                    int ctacteValorId;

                    sesion.Db.BeginTransaction();

                    DESCUENTO_DOCUMENTOS_DETRow row = new DESCUENTO_DOCUMENTOS_DETRow();

                    string valorAnterior;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("DESCUENTO_DOCUMENTOS_DET_SQC");
                    }
                    else
                    {
                        row = sesion.Db.DESCUENTO_DOCUMENTOS_DETCollection.GetByPrimaryKey((decimal)campos[DescuentoDocumentosDetalleService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.DESCUENTO_DOCUMENTO_ID = (decimal)campos[DescuentoDocumentosDetalleService.DescuentoDocumentosId_NombreCol];

                    dtDescuentoDocumentos = descuentoDocumentos.GetDescuentoDocumentosDataTable(DescuentoDocumentosService.Id_NombreCol + " = " + row.DESCUENTO_DOCUMENTO_ID, string.Empty);

                    ctacteValorId = Convert.ToInt32(campos[DescuentoDocumentosDetalleService.CtacteValorId_NombreCol]);
                    row.CTACTE_VALOR_ID = (decimal)campos[DescuentoDocumentosDetalleService.CtacteValorId_NombreCol];
                    
                    switch (ctacteValorId)
                    {
                        case Definiciones.CuentaCorrienteValores.Cheque:
                            row.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)campos[DescuentoDocumentosDetalleService.CtacteChequeRecibidoId_NombreCol];

                            //Se obtiene el cheque
                            dtChequeRecibido = CuentaCorrienteChequesRecibidosService.GetCuentaCorrienteChequesRecibidosInfoCompleta2(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + row.CTACTE_CHEQUE_RECIBIDO_ID, string.Empty, sesion);

                            //Se controla que el cheque pueda ser descontado
                            if (insertarNuevo && !(dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].Equals(Definiciones.CuentaCorrienteChequesEstados.AlDia) ||
                                  dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].Equals(Definiciones.CuentaCorrienteChequesEstados.Adelantado)))
                            {
                                //En caso que no se haya encontrado el motivo
                                throw new Exception("El cheque no puede ser custodiado debido a su estado (" + dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol] + ").");
                            }

                            row.MONTO = (decimal)dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];
                            row.FECHA_VENCIMIENTO = (DateTime)dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.FechaVencimiento_NombreCol];

                            row.MONEDA_ID = (decimal)dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.MonedaId_NombreCol];
                            //Se actualiza la cotizacion de la moneda
                            row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtDescuentoDocumentos.Rows[0][DescuentoDocumentosService.SucursalId_NombreCol]), row.MONEDA_ID, (DateTime)dtDescuentoDocumentos.Rows[0][DescuentoDocumentosService.Fecha_NombreCol], sesion);
                            if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                throw new Exception("Debe actualizarse la cotización de la moneda destino.");

                            break;
                        case Definiciones.CuentaCorrienteValores.Pagare:
                            row.CTACTE_PAGARE_DET_ID = (decimal)campos[DescuentoDocumentosDetalleService.CtactePagareDetId_NombreCol];

                            //Se obtiene el pagare
                            dtPagareDet = CuentaCorrientePagaresDetalleService.GetCuentaCorrientePagaresDetalleInfoCompleta(CuentaCorrientePagaresDetalleService.Id_NombreCol + " = " + row.CTACTE_PAGARE_DET_ID, string.Empty);

                            //Se controla que el pagare no este pagado parcial ni totalmente
                            if ((decimal)dtPagareDet.Rows[0][CuentaCorrientePagaresDetalleService.VistaMontoSaldo_NombreCol] < (decimal)dtPagareDet.Rows[0][CuentaCorrientePagaresDetalleService.MontoTotal_NombreCol])
                                throw new Exception("El pagaré se encuentra pagado en forma parcial o total.");

                            row.MONTO = (decimal)dtPagareDet.Rows[0][CuentaCorrientePagaresDetalleService.MontoTotal_NombreCol];
                            row.FECHA_VENCIMIENTO = (DateTime)dtPagareDet.Rows[0][CuentaCorrientePagaresDetalleService.FechaVencimiento_NombreCol];
                            
                            row.MONEDA_ID = (decimal)dtPagareDet.Rows[0][CuentaCorrientePagaresDetalleService.VistaMonedaId_NombreCol];
                            //Se actualiza la cotizacion de la moneda
                            row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtDescuentoDocumentos.Rows[0][DescuentoDocumentosService.SucursalId_NombreCol]), row.MONEDA_ID, (DateTime)dtDescuentoDocumentos.Rows[0][DescuentoDocumentosService.Fecha_NombreCol], sesion);
                            if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                throw new Exception("Debe actualizarse la cotización de la moneda destino.");

                            break;
                        default: throw new Exception("Tipo de valor no implementado.");
                    }

                    row.PORCENTAJE_COMISION = (decimal)campos[DescuentoDocumentosDetalleService.PorcentajeComision_NombreCol];
                    row.MONTO_COMISION = row.MONTO * row.PORCENTAJE_COMISION / 100;
                    row.MONTO_IMPUESTO = (decimal)campos[DescuentoDocumentosDetalleService.MontoImpuesto_NombreCol];
                    row.OBSERVACION = (string)campos[DescuentoDocumentosDetalleService.Observacion_NombreCol];

                    if (insertarNuevo)
                        sesion.Db.DESCUENTO_DOCUMENTOS_DETCollection.Insert(row);
                    else
                        sesion.Db.DESCUENTO_DOCUMENTOS_DETCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Acciones luego de insertar el nuevo registro
                    if (insertarNuevo)
                    {
                        switch (ctacteValorId)
                        {
                            case Definiciones.CuentaCorrienteValores.Cheque:
                                //Se obtiene el cheque
                                dtChequeRecibido = CuentaCorrienteChequesRecibidosService.GetDataTable(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + row.CTACTE_CHEQUE_RECIBIDO_ID, string.Empty, sesion);

                                //Se afecta el saldo de la caja
                                CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(
                                      (decimal)dtDescuentoDocumentos.Rows[0][DescuentoDocumentosService.CtacteCajaTesoreriaId_NombreCol],
                                      Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS,
                                      string.Empty,
                                      row.DESCUENTO_DOCUMENTO_ID,
                                      row.ID,
                                      Definiciones.CuentaCorrienteValores.Cheque,
                                      row.CTACTE_CHEQUE_RECIBIDO_ID,
                                      row.MONEDA_ID,
                                      row.COTIZACION_MONEDA,
                                      row.MONTO,
                                      (DateTime)dtDescuentoDocumentos.Rows[0][DescuentoDocumentosService.Fecha_NombreCol],
                                      sesion
                                   );

                                break;
                            case Definiciones.CuentaCorrienteValores.Pagare:
                                break;
                            default: throw new Exception("Tipo de valor no implementado.");
                        }
                    }
                    
                    #endregion Acciones luego de insertar el nuevo registro
                    
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
        /// Borrars the specified descuento documento detalle id.
        /// </summary>
        /// <param name="descuento_documento_detalle_id">The descuento_documento_detalle_id.</param>
        public void Borrar(decimal descuento_documento_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    DESCUENTO_DOCUMENTOS_DETRow row;
                    DescuentoDocumentosService descuentoDocumentos = new DescuentoDocumentosService();
                    
                    row = sesion.Db.DESCUENTO_DOCUMENTOS_DETCollection.GetByPrimaryKey(descuento_documento_detalle_id);

                    int ctacteValorId = Convert.ToInt32(row.CTACTE_VALOR_ID);

                    #region Acciones luego de insertar el nuevo registro
                    switch (ctacteValorId)
                    {
                        case Definiciones.CuentaCorrienteValores.Cheque:

                            DataTable dtDescuento = (new DescuentoDocumentosService()).GetDescuentoDocumentosDataTable(DescuentoDocumentosService.Id_NombreCol + "=" + row.DESCUENTO_DOCUMENTO_ID, DescuentoDocumentosService.Id_NombreCol);
                            decimal casoId = (decimal)dtDescuento.Rows[0][CambiosDivisaService.CasoId_NombreCol];

                            //Se afecta la caja de tesoreria
                            CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS, string.Empty, row.ID, casoId, sesion);

                            break;
                        case Definiciones.CuentaCorrienteValores.Pagare:
                            break;
                        default: throw new Exception("Tipo de valor no implementado.");
                    }
                    #endregion Acciones luego de insertar el nuevo registro
                    
                    sesion.Db.DESCUENTO_DOCUMENTOS_DETCollection.DeleteByPrimaryKey(descuento_documento_detalle_id);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region RechazarCheque
        /// <summary>
        /// Rechazars the cheque.
        /// </summary>
        /// <param name="descuento_documentos_detalle_id">The descuento_documentos_detalle_id.</param>
        public static void RechazarCheque(decimal descuento_documentos_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DESCUENTO_DOCUMENTOS_DETRow row = sesion.db.DESCUENTO_DOCUMENTOS_DETCollection.GetByPrimaryKey(descuento_documentos_detalle_id);
                DataTable dtCabecera = new DescuentoDocumentosService().GetDescuentoDocumentosInfoCompleta(DescuentoDocumentosService.Id_NombreCol + " = " + row.DESCUENTO_DOCUMENTO_ID, string.Empty);

                //El caso debe estar en aprobado o cerrado
                if (!((string)dtCabecera.Rows[0][DescuentoDocumentosService.VistaCasoEstadoId_NombreCol] == Definiciones.EstadosFlujos.Aprobado ||
                      (string)dtCabecera.Rows[0][DescuentoDocumentosService.VistaCasoEstadoId_NombreCol] == Definiciones.EstadosFlujos.Cerrado))
                {
                    throw new Exception("Para rechazar cheques el caso debe estar en estado Aprobado o Cerrdo.");
                }

                //Cambiar el estado del cheque a rechazado
                CuentaCorrienteChequesRecibidosService.CambiarEstado(row.CTACTE_CHEQUE_RECIBIDO_ID, (decimal)dtCabecera.Rows[0][DescuentoDocumentosService.CasoId_NombreCol], Definiciones.CuentaCorrienteChequesEstados.Rechazado, sesion, false, Definiciones.Error.Valor.EnteroPositivo);

                //Si hay una cuenta bancaria asociada al caso se disminuye el saldo
                if (!dtCabecera.Rows[0][DescuentoDocumentosService.CtacteBancariaId_NombreCol].Equals(DBNull.Value))
                {
                    CuentaCorrienteCuentasBancariasMovimientosService.Guardar(
                        (decimal)dtCabecera.Rows[0][DescuentoDocumentosService.CtacteBancariaId_NombreCol],
                        Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS,
                        (decimal)dtCabecera.Rows[0][DescuentoDocumentosService.CasoId_NombreCol],
                        Definiciones.Error.Valor.EnteroPositivo,
                        row.DESCUENTO_DOCUMENTO_ID,
                        row.MONEDA_ID,
                        row.MONTO,
                        row.COTIZACION_MONEDA,
                        DateTime.Now,
                        "Rechazado en Descuento de Documentos caso " + dtCabecera.Rows[0][DescuentoDocumentosService.CasoId_NombreCol],
                        null,
                        row.CTACTE_CHEQUE_RECIBIDO_ID,
                        true,
                        sesion);
                }
            }
        }
        #endregion RechazarCheque

        #region Modificar Comision e Impuesto en TodosDetalles
        public static void ModificarComisionImpuestoTodosDetalles(decimal descuentoDocumentoId, decimal porcentajeComision, decimal montoImpuesto)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    // Se obtienen todos los detalles del caso
                    DESCUENTO_DOCUMENTOS_DETRow[] detalles = sesion.Db.DESCUENTO_DOCUMENTOS_DETCollection.GetByDESCUENTO_DOCUMENTO_ID(descuentoDocumentoId);

                    // Se declara una variable local
                    string valorAnterior = string.Empty;
                    
                    // Se edita cada detalle
                    foreach (DESCUENTO_DOCUMENTOS_DETRow fila in detalles)
                    {
                        valorAnterior = fila.ToString();

                        fila.PORCENTAJE_COMISION = porcentajeComision;
                        fila.MONTO_COMISION = fila.MONTO * fila.PORCENTAJE_COMISION / 100;
                        fila.MONTO_IMPUESTO = montoImpuesto;

                        sesion.Db.DESCUENTO_DOCUMENTOS_DETCollection.Update(fila);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, fila.ID, valorAnterior, fila.ToString(), sesion);
                    }
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Modificar Comision e Impuesto en TodosDetalles

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DESCUENTO_DOCUMENTOS_DET"; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtactePagareDetId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.CTACTE_PAGARE_DET_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string DescuentoDocumentosId_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.DESCUENTO_DOCUMENTO_IDColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.IDColumnName; }
        }
        public static string MontoComision_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.MONTO_COMISIONColumnName; }
        }
        public static string MontoImpuesto_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.MONTO_IMPUESTOColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.MONTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.OBSERVACIONColumnName; }
        }
        public static string PorcentajeComision_NombreCol
        {
            get { return DESCUENTO_DOCUMENTOS_DETCollection.PORCENTAJE_COMISIONColumnName; }
        }
        public static string VistaChequeEstadoId_NombreCol
        {
            get { return DESC_DOCS_DET_INFO_COMPLCollection.CHEQUE_ESTADO_IDColumnName; }
        }
        public static string VistaChequeEstado_NombreCol
        {
            get { return DESC_DOCS_DET_INFO_COMPLCollection.CHEQUE_ESTADOColumnName; }
        }
        public static string VistaCuentaValorNombre_NombreCol
        {
            get { return DESC_DOCS_DET_INFO_COMPLCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return DESC_DOCS_DET_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return DESC_DOCS_DET_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaObservacionValor_NombreCol
        {
            get { return DESC_DOCS_DET_INFO_COMPLCollection.OBSERVACION_VALORColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return DESC_DOCS_DET_INFO_COMPLCollection.MONEDA_IDColumnName; }
        }
        #endregion Accessors
    }
}
