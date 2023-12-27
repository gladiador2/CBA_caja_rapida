using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class CajaSucursalRepartoService
    {
        #region GetDataTable
        public static DataTable GetAllAsDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CAJA_SUCURSAL_REPARTOCollection.GetAllAsDataTable();
            }
        }

        public static DataTable GetAsDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CAJA_SUCURSAL_REPARTOCollection.GetAsDataTable(clausula, CajaSucursalRepartoService.NroCaja_NombreCol);
            }
        }
        #endregion GetDataTable

        #region Accessors
        public static string Nombre_Vista
        {
            get { return "CAJA_SUCURSAL_REPARTO"; }
        }
        public static string NroCaja_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.CAJA_IDColumnName; }
        }
        public static string NroReparto_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.REPARTO_IDColumnName; }
        }
        public static string Chofer_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.CHOFERColumnName; }
        }
        public static string Vehiculo_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.VEHICULOColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string PersonaNombre_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string PersonaCodigo_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.PERSONA_CODIGOColumnName; }
        }
        public static string MonedaSimbolo_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.COTIZACION_DESTINOColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.TOTAL_MONTO_BRUTOColumnName; }
        }
        public static string CasoReparto_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.REPARTO_CASOColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.FECHA_INICIOColumnName; }
        }
        public static string MonedaCadenaDecimal_NombreCol
        {
            get { return CAJA_SUCURSAL_REPARTOCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
       
        #endregion Accessors
    }
}
