#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class RendicionCobradorRecibosService
    {
      
       
        public static DataTable GetRendicionCobradorDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RENDICION_COBRADOR_RECIBOSCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetAllRendicionCobradorDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RENDICION_COBRADOR_RECIBOSCollection.GetAllAsDataTable();
            }
        }

        #region Accessors

        #region Tabla
      
        #endregion Tabla

        #region Vista
        public static string VistaAutoNumeracionId_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.AUTONUMERACION_IDColumnName; }
        }
        public static string VistaFecha_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.FECHAColumnName; }
        }
        public static string VistaFuncionarioId_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaMonedaId_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.MONEDA_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonto_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.MONTOColumnName; }
        }
        public static string VistaNombreCompleto_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaNroComprobanteSecuencia_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.NRO_COMPROBANTE_SECUENCIAColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaPersonaId_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.PERSONA_IDColumnName; }
        }
        public static string VistaReciboId_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.RECIBO_IDColumnName; }
        }
        public static string VistaSucursalId_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaCantidadDecimales_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.CANTIDADES_DECIMALESColumnName; }
        }
        public static string VistaCadenaDecimales_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.CADENA_DECIMALESColumnName; }
        }
        public static string VistaEstadoRecibo_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.ESTADO_RECIBOColumnName; }
        }
        public static string VistaEstadoReciboId_NombreCol
        {
            get { return RENDICION_COBRADOR_RECIBOSCollection.ESTADO_RECIBO_IDColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}




