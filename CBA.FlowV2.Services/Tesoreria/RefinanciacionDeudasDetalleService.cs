#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using System.Collections;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class RefinanciacionDeudasDetalleService
    {

        public static DataTable GetRefinanciacionDeudasDetallesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetRefinanciacionDeudasDetallesDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetRefinanciacionDeudasDetallesDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.REFINANCIACION_DEUDAS_DOCCollection.GetAsDataTable(clausulas, orden);
        }
       
        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar(campos, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            REFINANCIACION_DEUDAS_DOCRow row = new REFINANCIACION_DEUDAS_DOCRow();

            row.ID = sesion.Db.GetSiguienteSecuencia("REFINANCIACION_DEUDAS_DOC_SQC");
            row.REFINANCIACION_DEUDAS_ID = (decimal)campos[RefinanciacionDeudasDetalleService.RefinancionDeudasId_NombreCol];
            row.CANTIDAD_CUOTAS = (decimal)campos[RefinanciacionDeudasDetalleService.CantidadCuotas_NombreCol];
            row.COTIZACION = (decimal)campos[RefinanciacionDeudasDetalleService.Cotizacion_NombreCol];
            row.CUOTA = (decimal)campos[RefinanciacionDeudasDetalleService.Cuota_NombreCol];
            row.IMPORTE = (decimal)campos[RefinanciacionDeudasDetalleService.Importe_NombreCol];
            row.MONEDA_ID = (decimal)campos[RefinanciacionDeudasDetalleService.MonedaId_NombreCol];
            row.MONTO_ANTERIOR = (decimal)campos[RefinanciacionDeudasDetalleService.MontoAnterior_NombreCol];
            row.VENCIMIENTO = (DateTime)campos[RefinanciacionDeudasDetalleService.Vencimiento_NombreCol];
            row.ES_INTERES = (string)campos[RefinanciacionDeudasDetalleService.EsInteres_NombreCol];

            sesion.Db.REFINANCIACION_DEUDAS_DOCCollection.Insert(row);
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal refinanciacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.REFINANCIACION_DEUDAS_DOCCollection.DeleteByREFINANCIACION_DEUDAS_ID(refinanciacion_id);
            }
        }
        #endregion borrar

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "REFINANCIACION_DEUDAS_DOC"; }
        }
        public static string CantidadCuotas_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.CANTIDAD_CUOTASColumnName; }
        }
        public static string CalendarioPagosFCClienteId_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.CALENDARIO_PAGOS_FC_CLIENTE_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.COTIZACIONColumnName; }
        }
        public static string Cuota_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.CUOTAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.IDColumnName; }
        }
        public static string Importe_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.IMPORTEColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.MONEDA_IDColumnName; }
        }
        public static string MontoAnterior_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.MONTO_ANTERIORColumnName; }
        }
        public static string RefinancionDeudasId_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.REFINANCIACION_DEUDAS_IDColumnName; }
        }
        public static string Vencimiento_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.VENCIMIENTOColumnName; }
        }
        public static string EsInteres_NombreCol
        {
            get { return REFINANCIACION_DEUDAS_DOCCollection.ES_INTERESColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "REFI_DEUDAS_INFO_COMP"; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return REFI_DEUDAS_DOC_INF_COMPCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return REFI_DEUDAS_DOC_INF_COMPCollection.MONEDA_CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return REFI_DEUDAS_DOC_INF_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}