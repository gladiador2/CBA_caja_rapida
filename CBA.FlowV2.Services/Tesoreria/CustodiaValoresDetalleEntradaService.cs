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
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CustodiaValoresDetalleEntradaService
    {
        #region GetCustodiaValoresDetalleEntradaInfoCompleta
        /// <summary>
        /// Gets the custodia valores detalle entrada information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCustodiaValoresDetalleEntradaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CustodiaValoresDetalleEntradaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;
                return sesion.db.CUSTODIA_VALORES_DET_ENT_IN_CCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCustodiaValoresDetalleEntradaInfoCompleta

        #region GetCustodiaValoresDetalleEntradaDataTable
        /// <summary>
        /// Gets the custodia valores detalle entrada data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCustodiaValoresDetalleEntradaDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetCustodiaValoresDetalleEntradaDataTable(clausulas, orden, sesion);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Gets the custodia valores detalle entrada data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCustodiaValoresDetalleEntradaDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = CustodiaValoresDetalleEntradaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.CUSTODIA_VALORES_DET_ENTRADACollection.GetAsDataTable(where, orden);
        }
        #endregion GetCustodiaValoresDetalleEntradaDataTable

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
                string clausulas = CustodiaValoresDetalleEntradaService.CustodiaValorId_NombreCol + " = " + custodia_valores_id + " and " +
                                   CustodiaValoresDetalleEntradaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                DataTable dtDetalles = GetCustodiaValoresDetalleEntradaDataTable(clausulas, string.Empty);
                DataTable dtCabecera = CustodiaValoresService.GetCustodiaValoresDataTable(CustodiaValoresService.Id_NombreCol + " = " + custodia_valores_id, string.Empty);
                decimal total = 0;
                decimal monedaCabeceraId = (decimal)dtCabecera.Rows[0][CustodiaValoresService.MonedaId_NombreCol];
                decimal cotizacionMoneda = (decimal)dtCabecera.Rows[0][CustodiaValoresService.CotizacionMoneda_NombreCol];

                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    if (monedaCabeceraId == (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleEntradaService.MonedaId_NombreCol])
                    {
                        total += (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleEntradaService.Monto_NombreCol];
                    }
                    else
                    {
                        total += (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleEntradaService.Monto_NombreCol]
                                 / (decimal)dtDetalles.Rows[i][CustodiaValoresDetalleEntradaService.CotizacionMoneda_NombreCol]
                                 * cotizacionMoneda;
                    }
                }

                return total;
            }
        }
        #endregion GetTotal

        #region ConfirmarCanje
        /// <summary>
        /// Confirmars the canje.
        /// </summary>
        /// <param name="custodia_valor_id">The custodia_valor_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ConfirmarCanje(decimal custodia_valor_id, SessionService sesion)
        {
            try
            {
                CUSTODIA_VALORES_DET_ENTRADARow[] rows = sesion.db.CUSTODIA_VALORES_DET_ENTRADACollection.GetByCUSTODIA_VALOR_ID(custodia_valor_id);

                //Activar los datalles que entran e inactivar los datos del canje
                for (int i = 0; i < rows.Length; i++)
                {
                    CustodiaValoresDetalleService.SetEstado(rows[i].CUSTODIA_VALOR_DET_ID, Definiciones.Estado.Activo, sesion);
                    rows[i].ESTADO = Definiciones.Estado.Inactivo;
                    sesion.db.CUSTODIA_VALORES_DET_ENTRADACollection.Update(rows[i]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion ConfirmarCanje

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    CuentaCorrienteChequesRecibidosService ctacteCheque = new CuentaCorrienteChequesRecibidosService();
                    CuentaCorrientePagaresDetalleService ctactePagareDetalle = new CuentaCorrientePagaresDetalleService();
                    DataTable dtCustodiaValor, dtChequeRecibido, dtPagareDet;
                    int ctacteValorId;

                    CUSTODIA_VALORES_DET_ENTRADARow row = new CUSTODIA_VALORES_DET_ENTRADARow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("custodia_valores_det_ent_sqc");
                    row.FECHA = DateTime.Now;
                    row.CUSTODIA_VALOR_ID = (decimal)campos[CustodiaValoresDetalleEntradaService.CustodiaValorId_NombreCol];
                    row.ESTADO = Definiciones.Estado.Activo;

                    dtCustodiaValor = CustodiaValoresService.GetCustodiaValoresDataTable(CustodiaValoresService.Id_NombreCol + " = " + row.CUSTODIA_VALOR_ID, string.Empty);

                    ctacteValorId = Convert.ToInt32(campos[CustodiaValoresDetalleEntradaService.CtacteValorId_NombreCol]);
                    row.CTACTE_VALOR_ID = ctacteValorId;
                    row.OBSERVACION_INICIAL = (string)campos[CustodiaValoresDetalleEntradaService.Observacion_NombreCol];
                    row.MONEDA_ID = (decimal)campos[CustodiaValoresDetalleEntradaService.MonedaId_NombreCol];
                    row.DEPOSITO_AUTOMATICO = (string)campos[CustodiaValoresDetalleEntradaService.DepositoAutomatico_NombreCol];
                    row.COSTO = (decimal)campos[CustodiaValoresDetalleEntradaService.Costo_NombreCol];

                    //Se actualiza la cotizacion de la moneda
                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtCustodiaValor.Rows[0][CustodiaValoresService.SucursalId_NombreCol]), row.MONEDA_ID, row.FECHA, sesion);
                    if (row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda destino.");

                    #region Se obtienen los campos segun el tipo de valor
                    switch (ctacteValorId)
                    {
                        case Definiciones.CuentaCorrienteValores.Efectivo:
                            row.MONTO = (decimal)campos[CustodiaValoresDetalleService.Monto_NombreCol];
                            break;
                        case Definiciones.CuentaCorrienteValores.Cheque:
                            row.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)campos[CustodiaValoresDetalleEntradaService.CtacteChequeRecibidoId_NombreCol];

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
                            row.CTACTE_PAGARE_DET_ID = (decimal)campos[CustodiaValoresDetalleEntradaService.CtactePagareDetId_NombreCol];

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

                    sesion.Db.CUSTODIA_VALORES_DET_ENTRADACollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Agregar detalle a custodia pero inactivarlo hasta que se confirme
                    //Crear el detalle en la custodia pero inactivo, 
                    //para luego activarlo al confirmar el canje
                    Hashtable camposDetalle = new Hashtable();
                    decimal detalleCreadoId;
                    camposDetalle.Add(CustodiaValoresDetalleService.CustodiaValorId_NombreCol, row.CUSTODIA_VALOR_ID);
                    camposDetalle.Add(CustodiaValoresDetalleService.CtacteValorId_NombreCol, row.CTACTE_VALOR_ID);
                    camposDetalle.Add(CustodiaValoresDetalleService.Monto_NombreCol, row.MONTO);
                    camposDetalle.Add(CustodiaValoresDetalleService.ObservacionInicial_NombreCol, row.OBSERVACION_INICIAL);
                    camposDetalle.Add(CustodiaValoresDetalleService.MonedaId_NombreCol, row.MONEDA_ID);
                    camposDetalle.Add(CustodiaValoresDetalleService.Costo_NombreCol, row.COSTO);
                    camposDetalle.Add(CustodiaValoresDetalleService.DepositoAutomatico_NombreCol, row.DEPOSITO_AUTOMATICO);
                    if (!row.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
                        camposDetalle.Add(CustodiaValoresDetalleService.CtacteChequeRecibidoId_NombreCol, row.CTACTE_CHEQUE_RECIBIDO_ID);
                    if (!row.IsCTACTE_PAGARE_DET_IDNull)
                        camposDetalle.Add(CustodiaValoresDetalleService.CtactePagareDetId_NombreCol, row.CTACTE_PAGARE_DET_ID);

                    row.CUSTODIA_VALOR_DET_ID = CustodiaValoresDetalleService.Guardar(camposDetalle);
                    sesion.db.CUSTODIA_VALORES_DET_ENTRADACollection.Update(row);

                    CustodiaValoresDetalleService.SetEstado(row.CUSTODIA_VALOR_DET_ID, Definiciones.Estado.Inactivo, sesion);

                    CustodiaValoresService.ActualizarTotales(row.CUSTODIA_VALOR_ID, sesion);
                    #endregion Agregar detalle a custodia pero inactivarlo hasta que se confirme
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified custodia_valores_detalle_entrada_id.
        /// </summary>
        /// <param name="custodia_valores_detalle_entrada_id">The custodia_valores_detalle_entrada_id.</param>
        public static void Borrar(decimal custodia_valores_detalle_entrada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CUSTODIA_VALORES_DET_ENTRADARow row = sesion.Db.CUSTODIA_VALORES_DET_ENTRADACollection.GetByPrimaryKey(custodia_valores_detalle_entrada_id);
                    //Se borra el detalle de entrada
                    sesion.Db.CUSTODIA_VALORES_DET_ENTRADACollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    //Al guardar se creo un detalle de custodia en estado inactivo
                    //Ahora debe borrarse ese detalle afectando asi la caja de tesoreria
                    CustodiaValoresDetalleService.Borrar(row.CUSTODIA_VALOR_DET_ID, sesion);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion Borrar

        #region Inactivar
        /// <summary>
        /// Inactivars the specified custodia_valores_detalle_entrada_id.
        /// </summary>
        /// <param name="custodia_valores_detalle_entrada_id">The custodia_valores_detalle_entrada_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Inactivar(decimal custodia_valores_detalle_entrada_id, SessionService sesion)
        {
            CUSTODIA_VALORES_DET_ENTRADARow row = sesion.Db.CUSTODIA_VALORES_DET_ENTRADACollection.GetByPrimaryKey(custodia_valores_detalle_entrada_id);
            row.ESTADO = Definiciones.Estado.Inactivo;
            sesion.Db.CUSTODIA_VALORES_DET_ENTRADACollection.Update(row);
        }
        #endregion Inactivar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CUSTODIA_VALORES_DET_ENTRADA"; }
        }
        public static string Nombre_Vista
        {
            get { return "CUSTODIA_VALORES_DET_ENT_IN_C"; }
        }
        public static string Costo_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.COSTOColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtactePagareDetId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.CTACTE_PAGARE_DET_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string CustodiaValorDetId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.CUSTODIA_VALOR_DET_IDColumnName; }
        }
        public static string CustodiaValorId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.CUSTODIA_VALOR_IDColumnName; }
        }
        public static string DepositoAutomatico_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.DEPOSITO_AUTOMATICOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.MONTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENTRADACollection.OBSERVACION_INICIALColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENT_IN_CCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENT_IN_CCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaObservacionValor_NombreCol
        {
            get { return CUSTODIA_VALORES_DET_ENT_IN_CCollection.OBSERVACION_VALORColumnName; }
        }
        #endregion Accessors
    }
}
