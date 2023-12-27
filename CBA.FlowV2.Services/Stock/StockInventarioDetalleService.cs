#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class StockInventarioDetalleService
    {
        #region GetStockInventarioDetalleDataTable

        /// <summary>
        /// Gets the stock inventario detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public DataTable GetStockInventarioDetalleDataTable(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.INGRESO_STOCK_DETALLESCollection.GetAsDataTable(clausula,string.Empty);
            }
        }

        /// <summary>
        /// Gets the stock inventario detalle data table.
        /// </summary>
        /// <param name="stock_inventario_id">The stock_inventario_id.</param>
        /// <returns></returns>
        public DataTable GetStockInventarioDetalleDataTable(decimal stock_inventario_id)
        {
            string clausula = StockInventarioDetalleService.StockInventarioId_NombreCol + " = " + stock_inventario_id;
            return GetStockInventarioDetalleDataTable(clausula);
        }
        #endregion GetStockAjusteDetalleDataTable

        #region GetStockInventarioDetalleInfoCompleta

        /// <summary>
        /// Gets the stock inventario detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetStockInventarioDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_INVENT_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }

        /// <summary>
        /// Gets the stock inventario detalle info completa.
        /// </summary>
        /// <param name="stock_inventario_id">The stock_inventario_id.</param>
        /// <returns></returns>
        public DataTable GetStockInventarioDetalleInfoCompleta(decimal stock_inventario_id)
        {
            string clausula = StockInventarioDetalleService.StockInventarioId_NombreCol + " = " + stock_inventario_id;
            return GetStockInventarioDetalleInfoCompleta(clausula, StockInventarioDetalleService.VistaArticuloDescripcion_NombreCol);
        }
        #endregion GetStockInventarioDetalleInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, bool conStock)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    decimal loteId = decimal.Parse(campos[StockInventarioDetalleService.LoteId_NombreCol].ToString());
                   
                    STOCK_INVENTARIO_DETALLERow row = new STOCK_INVENTARIO_DETALLERow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("stock_inventario_detalle_sqc");
                        valorAnterior = CBA.FlowV2.Services.Base.Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.STOCK_INVENTARIO_DETALLECollection.GetRow(StockInventarioDetalleService.Id_NombreCol + " = " + campos[StockInventarioDetalleService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    row.ARTICULO_ID = decimal.Parse(campos[StockInventarioDetalleService.ArticuloId_NombreCol].ToString());
                    row.LOTE_ID = decimal.Parse(campos[StockInventarioDetalleService.LoteId_NombreCol].ToString());                   
                    row.STOCK_INVENTANRIO_ID = decimal.Parse(campos[StockInventarioDetalleService.StockInventarioId_NombreCol].ToString());
                    row.CANTIDAD_MANUAL = decimal.Parse(campos[StockInventarioDetalleService.CantidadManual_NombreCol].ToString());
                    row.CANTIDAD_SISTEMA = decimal.Parse(campos[StockInventarioDetalleService.CantidadSistema_NombreCol].ToString());

                    if (campos.Contains(StockInventarioDetalleService.Pasillo_NombreCol))
                        row.PASILLO = campos[StockInventarioDetalleService.Pasillo_NombreCol].ToString();
                    if (campos.Contains(StockInventarioDetalleService.Estante_NombreCol))
                        row.ESTANTE = campos[StockInventarioDetalleService.Estante_NombreCol].ToString();
                    if (campos.Contains(StockInventarioDetalleService.Nivel_NombreCol))
                        row.NIVEL = campos[StockInventarioDetalleService.Nivel_NombreCol].ToString();
                    if (campos.Contains(StockInventarioDetalleService.Columna_NombreCol))
                        row.COLUMNA = campos[StockInventarioDetalleService.Columna_NombreCol].ToString();

                    if (insertarNuevo )
                    {
                        if (conStock)
                        {
                            if (row.CANTIDAD_SISTEMA == 0)
                            {
                                return;
                            }
                        }

                        row.CANTIDAD_MANUAL = row.CANTIDAD_SISTEMA;
                    }
                    row.UNIDAD_ID = campos[StockInventarioDetalleService.UnidadId_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.STOCK_INVENTARIO_DETALLECollection.Insert(row);
                    else sesion.Db.STOCK_INVENTARIO_DETALLECollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();                    
                }
                catch (Excepciones.LoteSinCostoActivo exp) 
                {
                    throw exp; //Si no se encuentra el costo se debe volver a donde se llamo la funcion y continuar con otro lote
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region CambiarCantidadManual
        public void CambiarCantidadManual(decimal inventario_detalle_id, decimal cantidad_manual)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    STOCK_INVENTARIO_DETALLERow row = new STOCK_INVENTARIO_DETALLERow();
                    string valorAnterior = string.Empty;

                    row = sesion.Db.STOCK_INVENTARIO_DETALLECollection.GetByPrimaryKey(inventario_detalle_id);
                     valorAnterior = row.ToString();


                     row.CANTIDAD_MANUAL = cantidad_manual;
                    
                    sesion.Db.STOCK_INVENTARIO_DETALLECollection.Update(row);

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
        #endregion CambiarCantidadManual
       
        #region Borrar
        public void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    STOCK_INVENTARIO_DETALLERow row = new STOCK_INVENTARIO_DETALLERow();
                    row = sesion.Db.STOCK_INVENTARIO_DETALLECollection.GetByPrimaryKey(detalles_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = CBA.FlowV2.Services.Base.Definiciones.Log.RegistroBorrado;
                    sesion.Db.STOCK_INVENTARIO_DETALLECollection.DeleteByPrimaryKey(detalles_id);
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
            get { return "STOCK_INVENTARIO_DETALLE"; }
        }
        public static string StockAjusteCasoId_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.AJUSTE_STOCK_CASO_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.ARTICULO_IDColumnName; }
        }
        public static string CantidadManual_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.CANTIDAD_MANUALColumnName; }
        }
        public static string CantidadSistema_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.CANTIDAD_SISTEMAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.IDColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.LOTE_IDColumnName; }
        }
        public static string StockInventarioId_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.STOCK_INVENTANRIO_IDColumnName; }
        }
        public static string UnidadId_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.UNIDAD_IDColumnName; }
        }
        public static string Pasillo_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.PASILLOColumnName; }
        }
        public static string Estante_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.ESTANTEColumnName; }
        }
        public static string Nivel_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.NIVELColumnName; }
        }
        public static string Columna_NombreCol
        {
            get { return STOCK_INVENTARIO_DETALLECollection.COLUMNAColumnName; }
        }

        #endregion Tablas

        #region Vista
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloCodigoCatalogo_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.ARTICULO_CODIGO_CATALOGOColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloFamilia_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.ARTICULO_FAMILIAColumnName; }
        }
        public static string VistaArticuloGrupo_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.ARTICULO_GRUPOColumnName; }
        }
        public static string VistaArticuloSubGrupo_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.ARTICULO_SUBGRUPOColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.GRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.SUBGRUPO_IDColumnName; }
        }
        public static string VistaCosto_NombreCol 
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.COSTOColumnName; }
        }
        public static string VistaCostoCotizacion_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.COSTO_COTIZACIONColumnName; }
        }
        public static string VistaCostoMoneda_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.COSTO_MONEDAColumnName; }
        }
        public static string VistaUnidadMedida_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.UNIDAD_MEDIDAColumnName; }
        }
        public static string VistaArticuloLote_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.LOTEColumnName; }
        }
        public static string VistaStockInventarioId_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.STOCK_INVENTANRIO_IDColumnName; }
        }
        public static string VistaStockInventarioCasoId_NombreCol
        {
            get { return STOCK_INVENT_DET_INFO_COMPLCollection.STOCK_INVENT_CASO_IDColumnName; }
        }
        #endregion Vista
        
        #endregion Accessors
    }
}




