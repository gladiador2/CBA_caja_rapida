using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrientePersonasCalidadPagoService
    {
        #region GetCuentaCorrientePersonasCalidadPagoInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente personas calidad pago info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentaCorrientePersonasCalidadPagoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_PERSONAS_CALIDAD_PAGOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrientePersonasCalidadPagoInfoCompleta

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PERSONAS_CALIDAD_PAGOS"; }
        }
        public static string ASolaFirma_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.A_SOLA_FIRMAColumnName; }
        }
        public static string CantidadVencimientos_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.CANTIDAD_VENCIMIENTOSColumnName; }
        }
        public static string CasoEstadoId_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.CASO_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.COTIZACION_MONEDAColumnName; }
        }
        public static string Credito_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.CREDITOColumnName; }
        }
        public static string CtactePagareDetId_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.CTACTE_PAGARE_DET_IDColumnName; }
        }
        public static string Debito_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.DEBITOColumnName; }
        }
        public static string DiasAtraso_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.DIAS_ATRASOColumnName; }
        }
        public static string FechaOtorgamiento_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.FECHA_OTORGAMIENTOColumnName; }
        }
        public static string FechaPago_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.FECHA_PAGOColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.FLUJO_IDColumnName; }
        }
        public static string FlujoNombre_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.FLUJO_NOMBREColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.MONEDA_IDColumnName; }
        }
        public static string MonedaNombre_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.MONEDA_NOMBREColumnName; }
        }
        public static string PagosFinalizados_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.PAGOS_FINALIZADOSColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.PERSONA_IDColumnName; }
        }
        public static string Saldo_NombreCol
        {
            get { return CTACTE_PERSONAS_CALIDAD_PAGOSCollection.SALDOColumnName; }
        }
        #endregion Accessors
    }
}
