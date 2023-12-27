using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.ToolbarFlujo;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CustodiaValoresDetalleService
    {
        #region GetCustodiaValoresDetalleDataTable
        /// <summary>
        /// Gets the custodia valores detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCustodiaValoresDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CustodiaValoresDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.CUSTODIA_VALORES_DETCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCustodiaValoresDetalleDataTable

        #region GetCustodiaValoresDetalleInfoCompleta
        /// <summary>
        /// Gets the custodia valores detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCustodiaValoresDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CustodiaValoresDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.CUSTODIA_VALORES_DET_INF_COMPCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCustodiaValoresDetalleInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                CUSTODIA_VALORES_DETRow row = new CUSTODIA_VALORES_DETRow();

                try
                {
                    CuentaCorrienteChequesRecibidosService ctacteCheque = new CuentaCorrienteChequesRecibidosService();
                    CuentaCorrientePagaresDetalleService ctactePagareDetalle = new CuentaCorrientePagaresDetalleService();
                    DataTable dtCustodiaValor, dtChequeRecibido, dtPagareDet;
                    int ctacteValorId;

                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("custodia_valores_det_sqc");
                    row.CUSTODIA_VALOR_ID = (decimal)campos[CustodiaValoresDetalleService.CustodiaValorId_NombreCol];
                    row.ESTADO = Definiciones.Estado.Activo;

                    dtCustodiaValor = CustodiaValoresService.GetCustodiaValoresDataTable(CustodiaValoresService.Id_NombreCol + " = " + row.CUSTODIA_VALOR_ID, string.Empty);

                    ctacteValorId = Convert.ToInt32(campos[CustodiaValoresDetalleService.CtacteValorId_NombreCol]);
                    row.CTACTE_VALOR_ID = ctacteValorId;

                    row.VALOR_RETIRADO = Definiciones.SiNo.No;
                    row.OBSERVACION_INICIAL = (string)campos[CustodiaValoresDetalleService.ObservacionInicial_NombreCol];
                    
                    row.MONEDA_ID = (decimal)campos[CustodiaValoresDetalleService.MonedaId_NombreCol];

                    row.DEPOSITO_AUTOMATICO = (string)campos[CustodiaValoresDetalleService.DepositoAutomatico_NombreCol];

                    row.COSTO = (decimal)campos[CustodiaValoresDetalleService.Costo_NombreCol];

                    //Se actualiza la cotizacion de la moneda
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCustodiaValor.Rows[0][CustodiaValoresService.SucursalId_NombreCol]), row.MONEDA_ID, DateTime.Now, sesion);
                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda destino.");

                    #region Se obtienen los campos segun el tipo de valor
                    switch (ctacteValorId)
                    {
                        case Definiciones.CuentaCorrienteValores.Efectivo:
                            row.MONTO = (decimal)campos[CustodiaValoresDetalleService.Monto_NombreCol];
                            break;
                        case Definiciones.CuentaCorrienteValores.Cheque:
                            row.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)campos[CustodiaValoresDetalleService.CtacteChequeRecibidoId_NombreCol];
                            
                            //Se obtiene el cheque
                            dtChequeRecibido = ctacteCheque.GetCuentaCorrienteChequesRecibidosInfoCompleta(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + row.CTACTE_CHEQUE_RECIBIDO_ID, string.Empty);

                            //Se controla que el cheque pueda ser custodiado
                            if (!(dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].Equals(Definiciones.CuentaCorrienteChequesEstados.AlDia) ||
                                  dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.EstadoChequeId_NombreCol].Equals(Definiciones.CuentaCorrienteChequesEstados.Adelantado)))
                            {
                                //En caso que no se haya encontrado el motivo
                                throw new Exception("El cheque no puede ser custodiado debido a su estado (" + dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaEstadoNombre_NombreCol] + ").");
                            }

                            row.MONTO = (decimal)dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.Monto_NombreCol];
                            break;
                        case Definiciones.CuentaCorrienteValores.Pagare:
                            row.CTACTE_PAGARE_DET_ID = (decimal)campos[CustodiaValoresDetalleService.CtactePagareDetId_NombreCol];

                            //Se obtiene el pagare
                            dtPagareDet = CuentaCorrientePagaresDetalleService.GetCuentaCorrientePagaresDetalleInfoCompleta(CuentaCorrientePagaresDetalleService.Id_NombreCol + " = " + row.CTACTE_PAGARE_DET_ID, string.Empty);

                            //Se controla que el pagare no este pagado parcial ni totalmente
                            if ((decimal)dtPagareDet.Rows[0][CuentaCorrientePagaresDetalleService.VistaMontoSaldo_NombreCol] < (decimal)dtPagareDet.Rows[0][CuentaCorrientePagaresDetalleService.MontoTotal_NombreCol])
                                throw new Exception("El pagaré se encuentra pagado en forma parcial o total.");

                            row.MONTO = (decimal)dtPagareDet.Rows[0][CuentaCorrientePagaresDetalleService.MontoTotal_NombreCol];

                            break;
                        default: throw new Exception("Tipo de valor no implementado.");
                    }
                    #endregion Se obtienen los campos segun el tipo de valor

                    sesion.Db.CUSTODIA_VALORES_DETCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    
                    #region Acciones luego de insertar el nuevo registro
                    switch (ctacteValorId)
                    {
                        case Definiciones.CuentaCorrienteValores.Efectivo:
                            //Se afecta el saldo de la caja de tesoreria
                            CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(
                                  (decimal)dtCustodiaValor.Rows[0][CustodiaValoresService.CtacteCajaTesoreriaId_NombreCol],
                                  Definiciones.FlujosIDs.CUSTODIA_DE_VALORES,
                                  string.Empty,
                                  row.CUSTODIA_VALOR_ID,
                                  row.ID,
                                  Definiciones.CuentaCorrienteValores.Efectivo,
                                  Definiciones.Error.Valor.EnteroPositivo,
                                  row.MONEDA_ID,
                                  row.COTIZACION_MONEDA,
                                  row.MONTO,
                                  (DateTime)dtCustodiaValor.Rows[0][CustodiaValoresService.Fecha_NombreCol],
                                  sesion
                               );

                            break;
                        case Definiciones.CuentaCorrienteValores.Cheque:
                            //Se afecta el saldo de la caja
                            CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(
                                  (decimal)dtCustodiaValor.Rows[0][CustodiaValoresService.CtacteCajaTesoreriaId_NombreCol],
                                  Definiciones.FlujosIDs.CUSTODIA_DE_VALORES,
                                  string.Empty,
                                  row.CUSTODIA_VALOR_ID,
                                  row.ID,
                                  Definiciones.CuentaCorrienteValores.Cheque,
                                  row.CTACTE_CHEQUE_RECIBIDO_ID,
                                  row.MONEDA_ID,
                                  row.COTIZACION_MONEDA,
                                  row.MONTO,
                                  (DateTime)dtCustodiaValor.Rows[0][CustodiaValoresService.Fecha_NombreCol],
                                  sesion
                               );

                            break;
                        case Definiciones.CuentaCorrienteValores.Pagare:
                            break;
                        default: throw new Exception("Tipo de valor no implementado.");
                    }
                    #endregion Acciones luego de insertar el nuevo registro

                    CustodiaValoresService.ActualizarTotales(row.CUSTODIA_VALOR_ID, sesion);
                }
                catch (Exception)
                {
                    throw;
                }

                return row.ID;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified custodia_valor_det_id.
        /// </summary>
        /// <param name="custodia_valor_det_id">The custodia_valor_det_id.</param>
        public static void Borrar(decimal custodia_valor_det_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Borrar(custodia_valor_det_id, sesion);
            }
        }

        /// <summary>
        /// Borrars the specified deposito_bancario_detalle_id.
        /// </summary>
        /// <param name="custodia_valor_det_id">The custodia_valor_det_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <exception cref="System.Exception">Tipo de valor no implementado.</exception>
        public static void Borrar(decimal custodia_valor_det_id, SessionService sesion)
        {
            try
            {
                CUSTODIA_VALORES_DETRow row = sesion.Db.CUSTODIA_VALORES_DETCollection.GetByPrimaryKey(custodia_valor_det_id);
                int ctacteValorId = Convert.ToInt32(row.CTACTE_VALOR_ID);
                DataTable dtCustodia = CustodiaValoresService.GetCustodiaValoresDataTable(CustodiaValoresService.Id_NombreCol + "=" + row.CUSTODIA_VALOR_ID, CustodiaValoresService.Id_NombreCol);
                decimal casoId = (decimal)dtCustodia.Rows[0][CustodiaValoresService.CasoId_NombreCol];
                
                #region Acciones luego de insertar el nuevo registro
                switch (ctacteValorId)
                {
                    case Definiciones.CuentaCorrienteValores.Efectivo:
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        //Se afecta la caja de tesoreria
                        CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.CUSTODIA_DE_VALORES, string.Empty, row.ID, casoId, sesion);
               
                        break;
                    case Definiciones.CuentaCorrienteValores.Pagare:
                        break;
                    default: throw new Exception("Tipo de valor no implementado.");
                }
                #endregion Acciones luego de insertar el nuevo registro

                //Se borra el detalle
                sesion.Db.CUSTODIA_VALORES_DETCollection.Delete(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                CustodiaValoresService.ActualizarTotales(row.CUSTODIA_VALOR_ID, sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion borrar

        #region SetEstado
        /// <summary>
        /// Sets the estado.
        /// </summary>
        /// <param name="custodia_valor_det_id">The custodia_valor_det_id.</param>
        /// <param name="estado">if set to <c>true</c> [estado].</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetEstado(decimal custodia_valor_det_id, string estado, SessionService sesion)
        {
            CUSTODIA_VALORES_DETRow row = sesion.Db.CUSTODIA_VALORES_DETCollection.GetByPrimaryKey(custodia_valor_det_id);
            row.ESTADO = estado;
            sesion.db.CUSTODIA_VALORES_DETCollection.Update(row);
        }
        #endregion SetEstado

        #region RetirarValor
        /// <summary>
        /// Retirars the valor.
        /// </summary>
        /// <param name="custodia_valor_det_id">The custodia_valor_det_id.</param>
        /// <param name="fecha_retiro">The fecha_retiro.</param>
        /// <param name="observacion_retiro">The observacion_retiro.</param>
        public static void RetirarValor(decimal custodia_valor_det_id, DateTime fecha_retiro, string observacion_retiro)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    int ctacte_valor_id;
                    bool existe;
                    decimal cotizacion;
                    DataTable dtDetalles;
                    CuentaCorrienteChequesRecibidosService ctacteChequeRecibido = new CuentaCorrienteChequesRecibidosService();
                    CUSTODIA_VALORES_DETRow row = sesion.Db.CUSTODIA_VALORES_DETCollection.GetByPrimaryKey(custodia_valor_det_id);
                    string valorAnterior = row.ToString();
                    DataTable dtCabecera = CustodiaValoresService.GetCustodiaValoresDataTable(CustodiaValoresService.Id_NombreCol + " = " + row.CUSTODIA_VALOR_ID, string.Empty);
                    bool exito = false;
                    string mensaje;

                    row.VALOR_RETIRADO = Definiciones.SiNo.Si;
                    row.USUARIO_RETIRO_ID = sesion.Usuario.ID;
                    row.FECHA_RETIRO = fecha_retiro;
                    row.OBSERVACION_RETIRO = observacion_retiro;

                    //Obtener la cotizacion
                    cotizacion = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(((decimal)dtCabecera.Rows[0][CustodiaValoresService.SucursalId_NombreCol])), row.MONEDA_ID, (DateTime)dtCabecera.Rows[0][CustodiaValoresService.Fecha_NombreCol], sesion);
                    if (cotizacion.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda.");

                    //Dar ingreso al valor a la caja de tesoreria de donde provino al salir
                    ctacte_valor_id = Convert.ToInt32(row.CTACTE_VALOR_ID);
                    switch(ctacte_valor_id)
                    {
                        case Definiciones.CuentaCorrienteValores.Efectivo:
                            //Se da ingreso al efectivo
                            CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(
                                  (decimal)dtCabecera.Rows[0][CustodiaValoresService.CtacteCajaTesoreriaId_NombreCol],
                                  Definiciones.FlujosIDs.CUSTODIA_DE_VALORES,
                                  string.Empty,
                                  row.CUSTODIA_VALOR_ID,
                                  row.ID,
                                  ctacte_valor_id,
                                  Definiciones.Error.Valor.EnteroPositivo,
                                  row.MONEDA_ID,
                                  cotizacion,
                                  row.MONTO,
                                  DateTime.Now,
                                  sesion
                               );

                            break;
                        case Definiciones.CuentaCorrienteValores.Cheque:
                            //Se da ingreso al cheque
                            CuentaCorrienteCajasTesoreriaMovimientosService.Ingreso2(
                                  (decimal)dtCabecera.Rows[0][CustodiaValoresService.CtacteCajaTesoreriaId_NombreCol],
                                  Definiciones.FlujosIDs.CUSTODIA_DE_VALORES,
                                  string.Empty,
                                  row.CUSTODIA_VALOR_ID,
                                  row.ID,
                                  ctacte_valor_id,
                                  row.CTACTE_CHEQUE_RECIBIDO_ID,
                                  row.MONEDA_ID,
                                  cotizacion,
                                  row.MONTO,
                                  DateTime.Now,
                                  sesion
                               );

                            //Desmarcar del cheque el estado custodia
                            ctacteChequeRecibido.RetiradoDeCustodiaPorCustodiaDeValores(row.CTACTE_CHEQUE_RECIBIDO_ID, row.CUSTODIA_VALOR_ID, sesion);

                            break;
                        case Definiciones.CuentaCorrienteValores.Pagare:
                            break;
                        default: throw new Exception("Tipo de valor no implementado.");
                    }

                    sesion.Db.CUSTODIA_VALORES_DETCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.CommitTransaction();
                    sesion.BeginTransaction();

                    //Si todos los valores fueron retirados el caso debe
                    //ser pasado a cerrado
                    dtDetalles = CustodiaValoresDetalleService.GetCustodiaValoresDetalleDataTable(CustodiaValoresDetalleService.CustodiaValorId_NombreCol + " = " + row.CUSTODIA_VALOR_ID, string.Empty);
                    existe = false;
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    {
                        if ((string)dtDetalles.Rows[i][CustodiaValoresDetalleService.ValorRetirado_NombreCol] == Definiciones.SiNo.No)
                            existe = true;

                        if (existe) break;
                    }
                    if (!existe)
                    {
                        exito = (new CustodiaValoresService()).ProcesarCambioEstado((decimal)dtCabecera.Rows[0][CustodiaValoresService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                        if (exito)
                            exito = (new ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCabecera.Rows[0][CustodiaValoresService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Todos los valores fueron retirados.", sesion);
                        if (exito)
                            (new CustodiaValoresService()).EjecutarAccionesLuegoDeCambioEstado((decimal)dtCabecera.Rows[0][CustodiaValoresService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);
                        if (!exito)
                            throw new Exception("Error en CustodiaValoresDetalle.RetirarValor. " + mensaje + ".");
                    }
                    
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion RetirarValor

        #region GetTotal
        /// <summary>
        /// Gets the total.
        /// </summary>
        /// <param name="custodia_valores_id">The custodia_valores_id.</param>
        /// <returns></returns>
        public static decimal GetTotal(decimal custodia_valores_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CustodiaValoresDetalleService.CustodiaValorId_NombreCol + " = " + custodia_valores_id + " and " +
                                   CustodiaValoresDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                DataTable dtDetalles = GetCustodiaValoresDetalleDataTable(clausulas, string.Empty);
                DataTable dtCabecera = CustodiaValoresService.GetCustodiaValoresDataTable(CustodiaValoresService.Id_NombreCol + " = " + custodia_valores_id, string.Empty);
                decimal total = 0;
                decimal monedaCabeceraId = (decimal)dtCabecera.Rows[0][CustodiaValoresService.MonedaId_NombreCol];
                decimal cotizacionPago = (decimal)dtCabecera.Rows[0][CustodiaValoresService.CotizacionMoneda_NombreCol];

                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    if (monedaCabeceraId == (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleService.MonedaId_NombreCol])
                    {
                        total += (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleService.Monto_NombreCol];
                    }
                    else
                    {
                        total += (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleService.Monto_NombreCol]
                                 / (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleService.CotizacionMoneda_NombreCol]
                                 * cotizacionPago;
                    }
                }

                return total;
            }
        }
        #endregion GetTotal

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CUSTODIA_VALORES_DET"; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtactePagareDetId_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.CTACTE_PAGARE_DET_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string CustodiaValorId_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.CUSTODIA_VALOR_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.ESTADOColumnName; }
        }
        public static string FechaRetiro_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.FECHA_RETIROColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.MONTOColumnName; }
        }
        public static string ObservacionInicial_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.OBSERVACION_INICIALColumnName; }
        }
        public static string ObservacionRetiro_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.OBSERVACION_RETIROColumnName; }
        }
        public static string UsuarioRetiroId_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.USUARIO_RETIRO_IDColumnName; }
        }
        public static string ValorRetirado_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.VALOR_RETIRADOColumnName; }
        }
        public static string DepositoAutomatico_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.DEPOSITO_AUTOMATICOColumnName; }
        }
        public static string Costo_NombreCol
        {
            get { return CUSTODIA_VALORES_DETCollection.COSTOColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_INF_COMPCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_INF_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_INF_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonedaCabeceraId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_INF_COMPCollection.MONEDA_CABECERA_IDColumnName; }
        }
        public static string VistaCotizacionMonedaCabecera_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_INF_COMPCollection.COTIZACION_MONEDA_CABECERAColumnName; }
        }
        public static string VistaObservacionValor_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_INF_COMPCollection.OBSERVACION_VALORColumnName; }
        }
        #endregion Accessors
    }
}
