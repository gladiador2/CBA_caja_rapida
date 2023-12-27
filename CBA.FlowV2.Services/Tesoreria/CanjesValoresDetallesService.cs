using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CanjesValoresDetallesService
    {
        #region GetCanjesValoresDetalleInfoCompleta
        /// <summary>
        /// Gets the canjes valores detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCanjesValoresDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CANJES_VALORES_DET_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCanjesValoresDetalleInfoCompleta

        #region GetCanjesValoresDetalleDataTable
        /// <summary>
        /// Gets the canjes valores detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCanjesValoresDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CANJES_VALORES_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCanjesValoresDetalleDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DataTable dtCanjeValor;
                    int tipoValor;
                    CANJES_VALORES_DETRow row = new CANJES_VALORES_DETRow();
                    
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("canjes_valores_det_sqc");
                    row.CANJE_VALOR_ID = (decimal)campos[CanjesValoresDetallesService.CanjeValorId_NombreCol];

                    dtCanjeValor = CanjesValoresService.GetCanjesValoresDataTable(CanjesValoresService.Id_NombreCol + " = " + row.CANJE_VALOR_ID, string.Empty);

                    row.MONEDA_ID = (decimal)campos[CanjesValoresDetallesService.MonedaId_NombreCol];
                    if (!MonedasService.EstaActivo(row.MONEDA_ID))
                        throw new Exception("La moneda no está activa.");

                    row.COTIZACION_MONEDA = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtCanjeValor.Rows[0][CanjesValoresService.SucursalId_NombreCol]), row.MONEDA_ID, (DateTime)dtCanjeValor.Rows[0][CanjesValoresService.Fecha_NombreCol], sesion);
                    if(row.COTIZACION_MONEDA.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizar la cotización de la moneda.");

                    row.MONTO = (decimal)campos[CanjesValoresDetallesService.Monto_NombreCol];
                    row.OBSERVACION = (string)campos[CanjesValoresDetallesService.Observacion_NombreCol];

                    row.CTACTE_VALOR_ID = (int)campos[CanjesValoresDetallesService.CtacteValorId_NombreCol];
                    tipoValor = (int)campos[CanjesValoresDetallesService.CtacteValorId_NombreCol];

                    switch (tipoValor)
                    { 
                        case Definiciones.CuentaCorrienteValores.Cheque:
                            row.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)campos[CanjesValoresDetallesService.CtacteChequeRecibidoId_NombreCol];
                            //conseguir caso id del canje padre
                            decimal caso_ID = CanjesValoresService.GetCasoID(row.CANJE_VALOR_ID);
                            CuentaCorrienteChequesRecibidosService.CambiarEstado(row.CTACTE_CHEQUE_RECIBIDO_ID, caso_ID, Definiciones.CuentaCorrienteChequesEstados.ParaCanje, sesion, false, Definiciones.Error.Valor.EnteroPositivo);

                            break;
                        case Definiciones.CuentaCorrienteValores.Efectivo:
                            break;
                        default: throw new Exception("Error en CanjesValoresDetalleService.Guardar(). Tipo de valor no implementado");
                    }
                    
                    sesion.Db.CANJES_VALORES_DETCollection.Insert(row);
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
        /// Borrars the specified canje_valores_detalle_id.
        /// </summary>
        /// <param name="canje_valores_detalle_id">The canje_valores_detalle_id.</param>
        public static void Borrar(decimal canje_valores_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    CANJES_VALORES_DETRow row = sesion.Db.CANJES_VALORES_DETCollection.GetByPrimaryKey(canje_valores_detalle_id);

                    if (!row.IsCTACTE_CHEQUE_RECIBIDO_IDNull) { // si el detalle es un cheque
                        //se obtiene el estado anterior
                        decimal reestablecerEstado = CuentaCorrienteChequesMovimientosService.GetEstadoAnterior(row.CTACTE_CHEQUE_RECIBIDO_ID);
                        decimal caso_ID = CanjesValoresService.GetCasoID(row.CANJE_VALOR_ID);
                        CuentaCorrienteChequesRecibidosService.CambiarEstado(row.CTACTE_CHEQUE_RECIBIDO_ID, caso_ID, reestablecerEstado, sesion, false, Definiciones.Error.Valor.EnteroPositivo);
                    }

                    sesion.Db.CANJES_VALORES_DETCollection.Delete(row);
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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CANJES_VALORES_DET"; }
        }

        public static string CanjeValorId_NombreCol
        {
            get { return CANJES_VALORES_DETCollection.CANJE_VALOR_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CANJES_VALORES_DETCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CtacteChequeRecibidoId_NombreCol
        {
            get { return CANJES_VALORES_DETCollection.CTACTE_CHEQUE_RECIBIDO_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CANJES_VALORES_DETCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CANJES_VALORES_DETCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CANJES_VALORES_DETCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CANJES_VALORES_DETCollection.MONTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CANJES_VALORES_DETCollection.OBSERVACIONColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return CANJES_VALORES_DET_INFO_COMPCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CANJES_VALORES_DET_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CANJES_VALORES_DET_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaValorObservacion_NombreCol
        {
            get { return CANJES_VALORES_DET_INFO_COMPCollection.VALOR_OBSERVACIONColumnName; }
        }
        #endregion Accessors
    }
}
