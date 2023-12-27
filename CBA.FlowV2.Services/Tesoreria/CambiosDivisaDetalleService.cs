using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CambiosDivisaDetalleService
    {
        #region GetCambiosDivisaDetalleDataTable
        /// <summary>
        /// Gets the cambios divisa detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCambiosDivisaDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCambiosDivisaDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public DataTable GetCambiosDivisaDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CAMBIOS_DIVISA_DETALLECollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCambiosDivisaDetalleDataTable

        #region GetCambiosDivisaDetalleInfoCompleta
        /// <summary>
        /// Gets the cambios divisa detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCambiosDivisaDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCambiosDivisaDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }
        public DataTable GetCambiosDivisaDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CAMBIOS_DIVISA_DET_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCambiosDivisaDetalleInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    CambiosDivisaService cambioDivisa = new CambiosDivisaService();
                    CuentaCorrienteCajasTesoreriaService cajaTesoreria = new CuentaCorrienteCajasTesoreriaService();
                    CuentaCorrienteCajasTesoreriaMovimientosService ctacteCajaTesoreriaMov = new CuentaCorrienteCajasTesoreriaMovimientosService();
                    DataTable dtCambioDivisa = cambioDivisa.GetCambiosDivisaDataTable(CambiosDivisaService.Id_NombreCol + " = " + campos[CambiosDivisaDetalleService.CambioDivisaId_NombreCol], string.Empty);

                    CAMBIOS_DIVISA_DETALLERow row = new CAMBIOS_DIVISA_DETALLERow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("cambios_divisa_det_sqc");
                    row.CAMBIO_DIVISA_ID = (decimal)campos[CambiosDivisaDetalleService.CambioDivisaId_NombreCol];
                    
                    row.MONTO_DESTINO = (decimal)campos[CambiosDivisaDetalleService.MontoDestino_NombreCol];
                    row.MONTO_ORIGEN = (decimal)campos[CambiosDivisaDetalleService.MontoOrigen_NombreCol];
                    
                    row.MONEDA_DESTINO_ID = (decimal)campos[CambiosDivisaDetalleService.MonedaDestinoId_NombreCol];
                    if (!MonedasService.EstaActivo(row.MONEDA_DESTINO_ID))
                        throw new System.Exception("La moneda destino encuentra inactiva.");

                    row.COTIZACION_MONEDA_DESTINO = (decimal)campos[CambiosDivisaDetalleService.CotizacionMonedaDestino_NombreCol];
                    if (row.COTIZACION_MONEDA_DESTINO.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe indicar la cotización de la moneda destino.");

                    row.MONEDA_ORIGEN_ID = (decimal)campos[CambiosDivisaDetalleService.MonedaOrigenId_NombreCol];
                    if (!MonedasService.EstaActivo(row.MONEDA_ORIGEN_ID))
                        throw new System.Exception("La moneda origen encuentra inactiva.");

                    row.COTIZACION_MONEDA_ORIGEN = (decimal)campos[CambiosDivisaDetalleService.CotizacionMonedaOrigen_NombreCol];
                    if (row.COTIZACION_MONEDA_ORIGEN.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe indicar la cotización de la moneda origen.");
                    
                    //Se agrega el registro
                    sesion.Db.CAMBIOS_DIVISA_DETALLECollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    //Se afecta el saldo de la caja de tesoreria
                    CuentaCorrienteCajasTesoreriaMovimientosService.Egreso(
                          (decimal)dtCambioDivisa.Rows[0][CambiosDivisaService.CtacteCajaTesoreriaId_NombreCol],
                          Definiciones.FlujosIDs.CAMBIO_DIVISA,
                          string.Empty,
                          row.CAMBIO_DIVISA_ID,
                          row.ID,
                          Definiciones.CuentaCorrienteValores.Efectivo,
                          Definiciones.Error.Valor.EnteroPositivo,
                          row.MONEDA_ORIGEN_ID,
                          row.COTIZACION_MONEDA_ORIGEN,
                          row.MONTO_ORIGEN,
                          (DateTime)dtCambioDivisa.Rows[0][CambiosDivisaService.Fecha_NombreCol],
                          sesion
                       );

                    //Se recalculan los totales de la cabecera
                    (new CambiosDivisaService()).CalcularTotales(row.CAMBIO_DIVISA_ID, sesion);
                    
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
        /// Borrars the specified deposito_bancario_detalle_id.
        /// </summary>
        /// <param name="cambio_divisa_detalle_id">The cambio_divisa_detalle_id.</param>
        public void Borrar(decimal cambio_divisa_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    CAMBIOS_DIVISA_DETALLERow row = sesion.Db.CAMBIOS_DIVISA_DETALLECollection.GetByPrimaryKey(cambio_divisa_detalle_id);
                    DataTable dtCambios = (new CambiosDivisaService()).GetCambiosDivisaDataTable(CambiosDivisaService.Id_NombreCol + "=" + row.CAMBIO_DIVISA_ID, CambiosDivisaService.Id_NombreCol);
                    decimal casoId =(decimal) dtCambios.Rows[0][CambiosDivisaService.CasoId_NombreCol];

                    //Se devuelve el valor a la caja de tesoreria
                    CuentaCorrienteCajasTesoreriaMovimientosService.DeshacerEgreso(Definiciones.FlujosIDs.CAMBIO_DIVISA, string.Empty, row.ID, casoId, sesion);
                    
                    //Se borra el detalle
                    sesion.Db.CAMBIOS_DIVISA_DETALLECollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    sesion.CommitTransaction();
                    sesion.BeginTransaction();

                    //Se recalculan los totales de la cabecera
                    (new CambiosDivisaService()).CalcularTotales(row.CAMBIO_DIVISA_ID, sesion);
                    
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CAMBIOS_DIVISA_DETALLE"; }
        }
        public static string CambioDivisaId_NombreCol
        {
            get { return CAMBIOS_DIVISA_DETALLECollection.CAMBIO_DIVISA_IDColumnName; }
        }
        public static string CotizacionMonedaDestino_NombreCol
        {
            get { return CAMBIOS_DIVISA_DETALLECollection.COTIZACION_MONEDA_DESTINOColumnName; }
        }
        public static string CotizacionMonedaOrigen_NombreCol
        {
            get { return CAMBIOS_DIVISA_DETALLECollection.COTIZACION_MONEDA_ORIGENColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CAMBIOS_DIVISA_DETALLECollection.IDColumnName; }
        }
        public static string MonedaDestinoId_NombreCol
        {
            get { return CAMBIOS_DIVISA_DETALLECollection.MONEDA_DESTINO_IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return CAMBIOS_DIVISA_DETALLECollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoDestino_NombreCol
        {
            get { return CAMBIOS_DIVISA_DETALLECollection.MONTO_DESTINOColumnName; }
        }
        public static string MontoOrigen_NombreCol
        {
            get { return CAMBIOS_DIVISA_DETALLECollection.MONTO_ORIGENColumnName; }
        }
        public static string VistaMonedaDestinoNombre_NombreCol
        {
            get { return CAMBIOS_DIVISA_DET_INFO_COMPCollection.MONEDA_DESTINO_NOMBREColumnName; }
        }
        public static string VistaMonedaDestinoSimbolo_NombreCol
        {
            get { return CAMBIOS_DIVISA_DET_INFO_COMPCollection.MONEDA_DESTINO_SIMBOLOColumnName; }
        }
        public static string VistaMonedaOrigenNombre_NombreCol
        {
            get { return CAMBIOS_DIVISA_DET_INFO_COMPCollection.MONEDA_ORIGEN_NOMBREColumnName; }
        }
        public static string VistaMonedaOrigenSimbolo_NombreCol
        {
            get { return CAMBIOS_DIVISA_DET_INFO_COMPCollection.MONEDA_ORIGEN_SIMBOLOColumnName; }
        }
        #endregion Accessors
    }
}
