#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class ImportacionIngresoCostosService
    {
        #region GetImportacionIngresoCostosDataTable
        /// <summary>
        /// Gets the ingreso stock detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetImportacionIngresoCostosDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.IMPORTACION_INGRESO_COSTOSCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetImportacionIngresoCostosDetallle

        #region GetImportacionIngresoCostosInfoCompleta
        
        public static DataTable GetImportacionIngresoCostosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.IMPORTACION_INGRESO_COSTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetImportacionIngresoCostosInfoCompleta


        public static decimal getTotalGastosAplicados(string clausulas, decimal monedaDestinoId, decimal cotizacionCabecera)
        {
            decimal totalGastos = 0;
            using (SessionService sesion = new SessionService())
            {
                
                IMPORTACION_INGRESO_COSTOSRow[] rows = sesion.db.IMPORTACION_INGRESO_COSTOSCollection.GetAsArray(clausulas, string.Empty);
                foreach (IMPORTACION_INGRESO_COSTOSRow row in rows)
                {
                    if (row.MONEDA_ID == monedaDestinoId)
                    {
                        totalGastos = totalGastos + row.MONTO;
                    }
                    else
                    {
                        totalGastos += row.MONTO / row.COTIZACION * cotizacionCabecera;
                    }

                    
                }
            }
            return totalGastos;
        }

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    IMPORTACION_INGRESO_COSTOSRow row = new IMPORTACION_INGRESO_COSTOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("importacion_ingreso_costos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.IMPORTACION_GASTOS_ID = decimal.Parse(campos[ImportacionIngresoCostosService.ImportacionGastosId_NombreCol].ToString());
                        row.IMPORTACION_ID = decimal.Parse(campos[ImportacionIngresoCostosService.ImportacionId_NombreCol].ToString());
                        row.INGRESO_STOCK_DETALLE_ID = decimal.Parse(campos[ImportacionIngresoCostosService.IngresoStockDetalleId_NombreCol].ToString());
                        row.INGRESO_STOCK_ID = decimal.Parse(campos[ImportacionIngresoCostosService.IngresoStockId_NombreCol].ToString());
                        
                    }
                    else
                    {
                        row = sesion.Db.IMPORTACION_INGRESO_COSTOSCollection.GetByPrimaryKey(decimal.Parse(campos[ImportacionIngresoCostosService.Id_NombreCol].ToString()));
                      
                    }

                    row.MONEDA_ID = decimal.Parse(campos[ImportacionIngresoCostosService.MonedaId_NombreCol].ToString());
                    row.COTIZACION = decimal.Parse(campos[ImportacionIngresoCostosService.Cotizacion_NombreCol].ToString());
                    if (campos.Contains(ImportacionIngresoCostosService.Monto_NombreCol))
                    {
                        row.MONTO = decimal.Parse(campos[ImportacionIngresoCostosService.Monto_NombreCol].ToString());

                    }
                    else
                    {
                        row.PORCENTAJE = decimal.Parse(campos[ImportacionIngresoCostosService.Porcentaje_NombreCol].ToString());
                    }


                    if (insertarNuevo) sesion.Db.IMPORTACION_INGRESO_COSTOSCollection.Insert(row);
                    else sesion.Db.IMPORTACION_INGRESO_COSTOSCollection.Update(row);

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
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    IMPORTACION_INGRESO_COSTOSRow row = new IMPORTACION_INGRESO_COSTOSRow();
                    row = sesion.Db.IMPORTACION_INGRESO_COSTOSCollection.GetByPrimaryKey(detalles_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.IMPORTACION_INGRESO_COSTOSCollection.DeleteByPrimaryKey(detalles_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();

                    
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Borrar
       
        #region Accessors

        #region Tablas
        public static string Nombre_Tabla
        {
            get { return "IMPORTACION_INGRESO_COSTOS"; }
        }
        public static string Id_NombreCol
        {
            get { return IMPORTACION_INGRESO_COSTOSCollection.IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return IMPORTACION_INGRESO_COSTOSCollection.COTIZACIONColumnName; }
        }
        public static string ImportacionGastosId_NombreCol
        {
            get { return IMPORTACION_INGRESO_COSTOSCollection.IMPORTACION_GASTOS_IDColumnName; }
        }
        public static string ImportacionId_NombreCol
        {
            get { return IMPORTACION_INGRESO_COSTOSCollection.IMPORTACION_IDColumnName; }
        }

        public static string IngresoStockDetalleId_NombreCol
        {
            get { return IMPORTACION_INGRESO_COSTOSCollection.INGRESO_STOCK_DETALLE_IDColumnName; }
        }
        public static string IngresoStockId_NombreCol
        {
            get { return IMPORTACION_INGRESO_COSTOSCollection.INGRESO_STOCK_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return IMPORTACION_INGRESO_COSTOSCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return IMPORTACION_INGRESO_COSTOSCollection.MONTOColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return IMPORTACION_INGRESO_COSTOSCollection.PORCENTAJEColumnName; }
        }
       


        #endregion Tablas

        #region Vista
        public static string Nombre_Vista
        {
            get { return "import_ingre_costos_info_compl"; }
        }
        public static string VistaImportacionGastosCotizacion_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.IMPORT_GASTOS_COTIZACIONColumnName; }
        }
        public static string VistaImportacionGastosMonedaId_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.IMPORT_GASTOS_MONEDA_IDColumnName; }
        }
        public static string VistaImportacionGastosMonedaNombre_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.IMPORT_GASTOS_MONEDA_NOMBREColumnName; }
        }
        public static string VistaImportacionFacturas_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.IMPORTACION_FACTURASColumnName; }
        }
        public static string VistaImportacionGastosMontos_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.IMPORTACION_GASTOS_MONTOColumnName; }
        }
        public static string VistaImportacionNombre_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.IMPORTACION_NOMBREColumnName; }
        }
        public static string VistaIgresoCasoFCProveedor_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_CASO_FC_PROVEEDOR_IDColumnName; }
        }
        public static string VistaIngresoCaso_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_CASO_IDColumnName; }
        }
        public static string VistaIngresoDepositoAbreviatura_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DEPOSITO_ABREVIATURAColumnName; }
        }
        public static string VistaIngresoDepositoId_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DEPOSITO_IDColumnName; }
        }
        public static string VistaIngresoDepositoNombre_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaIngresoDetalleArticuloCodigo_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DET_ARTICULO_CODIGOColumnName; }
        }
        public static string VistaIngresoDetalleArticuloId_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DET_ARTICULO_IDColumnName; }
        }
        public static string VistaIngresoDetalleCotizacion_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DET_COTIZACIONColumnName; }
        }
        public static string VistaIngresoDetalleLoteId_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DET_LOTE_IDColumnName; }
        }
        public static string VistaIngresoDetalleLote_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DET_LOTEColumnName; }
        }
        public static string VistaIngresoDetalleMonedaId_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DET_MONEDA_IDColumnName; }
        }
        public static string VistaIngresoDetalleMonedaSimbolo_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_DET_MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaIngresoSucursalAbreviatura_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaIngresoSucursalId_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_SUCURSAL_IDColumnName; }
        }
        public static string VistaIngresoSucursalNombre_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.INGRESO_SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return IMPORT_INGRE_COSTOS_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        #endregion Vista
        
        #endregion Accessors
    }
}




