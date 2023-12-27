#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoPersona;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteRetencionesRecibidasService
    {   
        #region GetCuentaCorrienteRetencionesRecibidasDataTable

        /// <summary>
        /// Gets the cuenta corriente retenciones recibidas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteRetencionesRecibidasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_RETENCIONES_RECIBIDASCollection.GetAsDataTable(clausulas, orden);
            }
        }

        #endregion GetCuentaCorrienteRetencionesRecibidasDataTable

        #region GetCuentaCorrienteRetencionesRecibidasInfoCompleta

        /// <summary>
        /// Gets the cuenta corriente retenciones recibidas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrienteRetencionesRecibidasInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_RETENC_REC_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrienteRetencionesRecibidasInfoCompleta

        #region ActualizarTotal
        /// <summary>
        /// Actualizars the total.
        /// </summary>
        /// <param name="ctacte_retencion_id">The ctacte_retencion_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarTotal(decimal ctacte_retencion_id, SessionService sesion)
        {
            CTACTE_RETENCIONES_RECIBIDASRow row = sesion.Db.CTACTE_RETENCIONES_RECIBIDASCollection.GetByPrimaryKey(ctacte_retencion_id);
            DataTable dt = CuentaCorrienteRetencionesRecDetService.GetCuentaCorrienteRetencionesRecDetDataTable(CuentaCorrienteRetencionesRecDetService.CtacteRetencionRecibidaId_NombreCol + " = " + ctacte_retencion_id, string.Empty, sesion);
            string valorAnterior = row.ToString();

            row.TOTAL = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
                row.TOTAL += (decimal)dt.Rows[i][CuentaCorrienteRetencionesRecDetService.Monto_NombreCol];

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            sesion.Db.CTACTE_RETENCIONES_RECIBIDASCollection.Update(row);
        }
        #endregion ActualizarTotal

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="ctacte_pagos_persona_id">The ctacte_pagos_persona_id.</param>
        /// <param name="campos">The campos.</param>
        /// <returns></returns>
        public static decimal Guardar(decimal ctacte_pagos_persona_id, Hashtable campos, SessionService sesion)
        {
            try
            {
                CTACTE_RETENCIONES_RECIBIDASRow row = new CTACTE_RETENCIONES_RECIBIDASRow();
                string valorAnterior = string.Empty;

                if (campos.Contains(CuentaCorrienteRetencionesRecibidasService.Id_NombreCol))
                {
                    row = sesion.Db.CTACTE_RETENCIONES_RECIBIDASCollection.GetByPrimaryKey((decimal)campos[CuentaCorrienteRetencionesRecibidasService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }
                else
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_retenc_recibidas_sqc");
                    if (campos.Contains(CuentaCorrienteRetencionesRecibidasService.Fecha_NombreCol))
                        row.FECHA = (DateTime)campos[CuentaCorrienteRetencionesRecibidasService.Fecha_NombreCol];
                    else
                        row.FECHA = DateTime.Now;

                    row.TOTAL = 0;
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }

                DataTable pago_asociado = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + ctacte_pagos_persona_id, string.Empty, sesion);

                //Si cambia
                if (row.MONEDA_ID.Equals(DBNull.Value) || row.MONEDA_ID != (decimal)campos[CuentaCorrienteRetencionesRecibidasService.MonedaId_NombreCol])
                {
                    row.MONEDA_ID = (decimal)campos[CuentaCorrienteRetencionesRecibidasService.MonedaId_NombreCol];
                    if (!MonedasService.EstaActivo(row.MONEDA_ID))
                        throw new Exception("La moneda no se encuentra activa.");

                    row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)pago_asociado.Rows[0][PagosDePersonaService.SucursalId_NombreCol]), row.MONEDA_ID, row.FECHA, sesion);
                    if (row.COTIZACION == Definiciones.Error.Valor.EnteroPositivo)
                        throw new Exception("Debe actualizar la cotización de la moneda.");
                }

                //Si cambia
                if (row.PERSONA_ID.Equals(DBNull.Value) || row.PERSONA_ID != (decimal)campos[CuentaCorrienteRetencionesRecibidasService.PersonaId_NombreCol])
                {
                    row.PERSONA_ID = (decimal)campos[CuentaCorrienteRetencionesRecibidasService.PersonaId_NombreCol];
                    if (!PersonasService.EstaActivo(row.PERSONA_ID))
                        throw new Exception("La persona no se encuentra activa.");
                }

                row.NRO_COMPROBANTE = (string)campos[CuentaCorrienteRetencionesRecibidasService.NroComprobante_NombreCol];

                if (campos.Contains(CuentaCorrienteRetencionesRecibidasService.Observacion_NombreCol))
                    row.OBSERVACION = (string)campos[CuentaCorrienteRetencionesRecibidasService.Observacion_NombreCol];

                if (campos.Contains(CuentaCorrienteRetencionesRecibidasService.Timbrado_NombreCol))
                    row.TIMBRADO = (string)campos[CuentaCorrienteRetencionesRecibidasService.Timbrado_NombreCol];

                if(campos.Contains(CuentaCorrienteRetencionesRecibidasService.Id_NombreCol))
                    sesion.Db.CTACTE_RETENCIONES_RECIBIDASCollection.Update(row);
                else 
                    sesion.Db.CTACTE_RETENCIONES_RECIBIDASCollection.Insert(row);


                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                return row.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified ctacte_retencion_recibida_id.
        /// </summary>
        /// <param name="ctacte_retencion_recibida_id">The ctacte_retencion_recibida_id.</param>
        public static void Borrar(decimal ctacte_retencion_recibida_id, decimal ctacte_retencion_recibida_det_id, SessionService sesion)
        {
            try
            {
                CuentaCorrienteRetencionesRecDetService.Borrar(ctacte_retencion_recibida_det_id, sesion);
                DataTable dt = CuentaCorrienteRetencionesRecDetService.GetCuentaCorrienteRetencionesRecDetDataTable(CuentaCorrienteRetencionesRecDetService.CtacteRetencionRecibidaId_NombreCol + " = " + ctacte_retencion_recibida_id, string.Empty, sesion);
                
                if(dt.Rows.Count <= 0)
                    sesion.Db.CTACTE_RETENCIONES_RECIBIDASCollection.DeleteByPrimaryKey(ctacte_retencion_recibida_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_RETENCIONES_RECIBIDAS"; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return CTACTE_RETENCIONES_RECIBIDASCollection.COTIZACIONColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_RETENCIONES_RECIBIDASCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_RETENCIONES_RECIBIDASCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_RETENCIONES_RECIBIDASCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CTACTE_RETENCIONES_RECIBIDASCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return CTACTE_RETENCIONES_RECIBIDASCollection.OBSERVACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_RETENCIONES_RECIBIDASCollection.PERSONA_IDColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return CTACTE_RETENCIONES_RECIBIDASCollection.TOTALColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_RETENC_REC_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_RETENC_REC_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CTACTE_RETENC_REC_INFO_COMPLCollection.PERSONA_NOMBREColumnName; }
        }
        public static string Timbrado_NombreCol
        {
            get { return CTACTE_RETENC_REC_INFO_COMPLCollection.TIMBRADOColumnName; }
        }
        #endregion Accessors
    }
}
