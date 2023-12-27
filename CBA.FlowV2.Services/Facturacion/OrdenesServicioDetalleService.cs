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
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.General;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class OrdenesServicioDetalleService
    {
        #region GetOrdenesServicioDetalleDataTable
        /// <summary>
        /// Gets the ordenes servicio detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioDetalleDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERVICIO_DETALLESCollection.GetAsDataTable(clausula, orden);
            }
        }
        
        #endregion GetUsoDeInsumosDetalleDataTable

        #region GetOrdenesServicioDetalleInfoCompleta
        /// <summary>
        /// Gets the ordenes servicio detalle info completa static.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERV_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetOrdenesServicioDetalleInfoCompleta

        #region Guardar

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            ORDENES_SERVICIO_DETALLESRow row = new ORDENES_SERVICIO_DETALLESRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_servicio_det_sqc");
                row.ORDEN_SERVICIO_ID = (decimal)campos[OrdenesServicioDetalleService.OrdenServicioId_NombreCol];
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.ORDENES_SERVICIO_DETALLESCollection.GetRow(OrdenesServicioDetalleService.Id_NombreCol + " = " + campos[OrdenesServicioDetalleService.Id_NombreCol]);

                //Si no habia un caso asociado pero el nuevo dato si lo asocia
                if (row.IsCASO_ASOCIADO_IDNull && campos.Contains(OrdenesServicioDetalleService.CasoAsociadoId_NombreCol))
                {
                    ControlarFacturaEnOrdenServicio(decimal.Parse(campos[OrdenesServicioDetalleService.CasoAsociadoId_NombreCol].ToString()), sesion);
                }
                //Si habia un caso asociado pero el nuevo dato asocia un caso distinto
                else if (!row.IsCASO_ASOCIADO_IDNull && campos.Contains(OrdenesServicioDetalleService.CasoAsociadoId_NombreCol) && row.CASO_ASOCIADO_ID != decimal.Parse(campos[OrdenesServicioDetalleService.CasoAsociadoId_NombreCol].ToString()))
                {
                    ControlarFacturaEnOrdenServicio(decimal.Parse(campos[OrdenesServicioDetalleService.CasoAsociadoId_NombreCol].ToString()), sesion);
                }

                valorAnterior = row.ToString();
            }

            if (campos.Contains(OrdenesServicioDetalleService.CantidadHoras_NombreCol))
            {
                row.CANTIDAD_HORAS = decimal.Parse(campos[OrdenesServicioDetalleService.CantidadHoras_NombreCol].ToString());
            }

            if (campos.Contains(OrdenesServicioDetalleService.CantidadHorasServ_NombreCol))
            {
                row.CANTIDAD_HORAS_SERV = decimal.Parse(campos[OrdenesServicioDetalleService.CantidadHorasServ_NombreCol].ToString());
            }

            if (campos.Contains(OrdenesServicioDetalleService.Descripcion_NombreCol))
            {
                row.DESCRIPCION = (string)campos[OrdenesServicioDetalleService.Descripcion_NombreCol];
            }
            else
            {
                row.DESCRIPCION = "-";
            }

            if (campos.Contains(OrdenesServicioDetalleService.CasoAsociadoId_NombreCol))
            {
                DataTable casos = CasosService.GetCasosInfoCompleta(CasosService.Id_NombreCol + " = " + campos[OrdenesServicioDetalleService.CasoAsociadoId_NombreCol], string.Empty, sesion);
                if (casos.Rows.Count > 0)
                    row.CASO_ASOCIADO_ID = decimal.Parse(campos[OrdenesServicioDetalleService.CasoAsociadoId_NombreCol].ToString());
                else
                    throw new Exception("No existe un caso con ese número.");
            }
            else
            {
                row.IsCASO_ASOCIADO_IDNull = true;
            }

            if (campos.Contains(OrdenesServicioDetalleService.Costo_Unitario_NombreCol))
                row.COSTO_UNITARIO = decimal.Parse(campos[OrdenesServicioDetalleService.Costo_Unitario_NombreCol].ToString());
            else
                row.IsCOSTO_UNITARIONull = true;

            if (campos.Contains(OrdenesServicioDetalleService.Precio_NombreCol))
                row.PRECIO = decimal.Parse(campos[OrdenesServicioDetalleService.Precio_NombreCol].ToString());
            else
                row.IsPRECIONull = true;

            if (campos.Contains(OrdenesServicioDetalleService.FechaInicio_NombreCol))
                row.FECHA_INICIO = (DateTime)campos[OrdenesServicioDetalleService.FechaInicio_NombreCol];
            else
                row.IsFECHA_INICIONull = true;

            if (campos.Contains(OrdenesServicioDetalleService.FechaFin_NombreCol))
                row.FECHA_FIN = (DateTime)campos[OrdenesServicioDetalleService.FechaFin_NombreCol];
            else
                row.IsFECHA_FINNull = true;

            if (campos.Contains(OrdenesServicioDetalleService.UnidadId_NombreCol))
                row.UNIDAD_ID = campos[OrdenesServicioDetalleService.UnidadId_NombreCol].ToString();

            if (row.MONEDA_ID.Equals(System.DBNull.Value) || row.MONEDA_ID != (decimal)campos[OrdenesServicioDetalleService.MonedaId_NombreCol])
            {
                if (MonedasService.EstaActivo((decimal)campos[OrdenesServicioDetalleService.MonedaId_NombreCol]))
                {
                    row.MONEDA_ID = (decimal)campos[OrdenesServicioDetalleService.MonedaId_NombreCol];
                    DataTable dt = OrdenesServicioService.GetOrdenesServicioDataTable(OrdenesServicioService.Id_NombreCol + " = " + row.ORDEN_SERVICIO_ID.ToString(), string.Empty, sesion);

                    if (row.IsFECHA_INICIONull)
                    {
                        row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dt.Rows[0][OrdenesServicioService.SucursalId_NombreCol]), row.MONEDA_ID, DateTime.Today, sesion);
                    }
                    else
                    {
                        row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dt.Rows[0][OrdenesServicioService.SucursalId_NombreCol]), row.MONEDA_ID, row.FECHA_INICIO, sesion);
                    }


                    if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda.");
                }
                else
                {
                    throw new Exception("La moneda deseada no está activa.");
                }
            }

            if (campos.Contains(OrdenesServicioDetalleService.ActivoId_NombreCol))
                row.ACTIVO_ID = (decimal)campos[OrdenesServicioDetalleService.ActivoId_NombreCol];
            else
                row.IsACTIVO_IDNull = true;

            if (campos.Contains(OrdenesServicioDetalleService.ArticuloId_NombreCol))
                row.ARTICULO_ID = (decimal)campos[OrdenesServicioDetalleService.ArticuloId_NombreCol];
            else
                row.IsARTICULO_IDNull = true;

            if (campos.Contains(OrdenesServicioDetalleService.Costo_Unitario_Descontado_NombreCol))
                row.COSTO_UNITARIO_DESCONTADO = decimal.Parse(campos[OrdenesServicioDetalleService.Costo_Unitario_Descontado_NombreCol].ToString());
            else
                row.IsCOSTO_UNITARIO_DESCONTADONull = true;

            if (campos.Contains(OrdenesServicioDetalleService.Porcentaje_Descuento_NombreCol))
                row.PORCENTAJE_DESCUENTO = decimal.Parse(campos[OrdenesServicioDetalleService.Porcentaje_Descuento_NombreCol].ToString());
            else
                row.IsPORCENTAJE_DESCUENTONull = true;

            if (campos.Contains(OrdenesServicioDetalleService.CostoTotal_NombreCol))
                row.COSTO_TOTAL = decimal.Parse(campos[OrdenesServicioDetalleService.CostoTotal_NombreCol].ToString());
            else
                row.IsCOSTO_TOTALNull = true;

            if (campos.Contains(OrdenesServicioDetalleService.ImpuestoId_NombreCol))
                row.IMPUESTO_ID = decimal.Parse(campos[OrdenesServicioDetalleService.ImpuestoId_NombreCol].ToString());
            else
                row.IsIMPUESTO_IDNull = true;

            if (campos.Contains(OrdenesServicioDetalleService.TotalImpuestoMonto_NombreCol))
                row.TOTAL_IMPUESTO_MONTO = decimal.Parse(campos[OrdenesServicioDetalleService.TotalImpuestoMonto_NombreCol].ToString());
            else
                row.IsTOTAL_IMPUESTO_MONTONull = true;

            if (campos.Contains(OrdenesServicioDetalleService.EstadoId_NombreCol))
                row.ESTADO_ID = campos[OrdenesServicioDetalleService.EstadoId_NombreCol].ToString();
            
            if (insertarNuevo) sesion.Db.ORDENES_SERVICIO_DETALLESCollection.Insert(row);
            else sesion.Db.ORDENES_SERVICIO_DETALLESCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;

        }
        
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// 
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    decimal id = Guardar(campos, insertarNuevo, sesion);

                    sesion.CommitTransaction();
                    return id;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        public static DataTable getEstados()
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string[] estado = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.EstadoDetalleOrdenServicio, sesion).Split(',');

                    DataTable dt = new DataTable();
                    dt.Columns.Add(OrdenesServicioDetalleService.EstadoId_NombreCol, typeof(string));

                    for (int i = 0; i < estado.Length; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr[OrdenesServicioDetalleService.EstadoId_NombreCol] = estado[i];
                        dt.Rows.Add(dr);
                    }
                    return dt;
                }
                catch (Exception exp)
                {                    
                    throw exp;
                }
            }
        }

        public static void ControlarFacturaEnOrdenServicio(decimal casoFacturaProveedor, SessionService sesion)
        {

            DataTable ordenesServiciosDetalles = sesion.Db.ORDENES_SERVICIO_DETALLESCollection.GetAsDataTable(OrdenesServicioDetalleService.CasoAsociadoId_NombreCol + " = " + casoFacturaProveedor, FacturasProveedorService.Id_NombreCol);
            if (ordenesServiciosDetalles.Rows.Count > 0)
            {
                ORDENES_SERVICIORow ordenesServicios = sesion.Db.ORDENES_SERVICIOCollection.GetRow(OrdenesServicioService.Id_NombreCol + " = " + (decimal)ordenesServiciosDetalles.Rows[0][OrdenesServicioDetalleService.OrdenServicioId_NombreCol]);
                throw new Exception("La Factura Proveedor ya existe en la Orden de Servicio caso " + ordenesServicios.CASO_ID );
            }
        }

        #region Borrar
        /// <summary>
        /// Borrars the specified detalles_id.
        /// </summary>
        /// <param name="detalles_id">The detalles_id.</param>
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    ORDENES_SERVICIO_DETALLESRow row = new ORDENES_SERVICIO_DETALLESRow();

                    row = sesion.Db.ORDENES_SERVICIO_DETALLESCollection.GetByPrimaryKey(detalles_id);
                    //Se borra las relaciones si existen
                    OrdenesServicioDetalleRelacionesService.BorrarPorOrdenServicio(row.ID, sesion);

                    OrdenesServicioDetalleCentrosCostoService.BorrarPorOrdenDetalle(detalles_id,sesion);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.ORDENES_SERVICIO_DETALLESCollection.DeleteByPrimaryKey(detalles_id);
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
        public static string Nombre_Tabla
        {
            get { return "ORDENES_SERVICIO_DETALLES"; }
        }
        public static string Nombre_Vista
        {
            get { return "ORDENES_SERV_DET_INFO_COMPL"; }
        }
        public static string ActivoId_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.ACTIVO_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.ARTICULO_IDColumnName; }
        }
        public static string CantidadHoras_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.CANTIDAD_HORASColumnName; }
        }
        public static string CantidadHorasServ_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.CANTIDAD_HORAS_SERVColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.CASO_ASOCIADO_IDColumnName; }
        }
        public static string Costo_Unitario_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.COSTO_UNITARIOColumnName; }
        }
        public static string Costo_Unitario_Descontado_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.COSTO_UNITARIO_DESCONTADOColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.COTIZACIONColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.DESCRIPCIONColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.FECHA_FINColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.FECHA_INICIOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.IMPUESTO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.MONEDA_IDColumnName; }
        }
        public static string OrdenServicioId_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.ORDEN_SERVICIO_IDColumnName; }
        }
        public static string Porcentaje_Descuento_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.PORCENTAJE_DESCUENTOColumnName; }
        }
        public static string Precio_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.PRECIOColumnName; }
        }
        public static string CostoTotal_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.COSTO_TOTALColumnName; }
        }
        public static string TotalImpuestoMonto_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.TOTAL_IMPUESTO_MONTOColumnName; }
        }
        public static string UnidadId_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.UNIDAD_IDColumnName; }
        }
        public static string EstadoId_NombreCol
        {
            get { return ORDENES_SERVICIO_DETALLESCollection.ESTADO_IDColumnName; }
        }
        public static string VistaActivoId_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.ACTIVO_IDColumnName; }
        }
        public static string VistaActivoCodigo_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.ACTIVO_CODIGOColumnName; }
        }
        public static string VistaCasoAsociadoFlujoDesc_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.CASO_ASOC_FLUJO_DESCColumnName; }
        }
        public static string VistaCasoAsociadoFlujoId_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.CASO_ASOC_FLUJO_IDColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaOrdenServicioCasoId_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.ORDEN_SERVICIO_CASOColumnName; }
        }
        public static string VistaOrdenServicioTipo_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.ORDEN_SERVICIO_TIPOColumnName; }
        }
        public static string VistaOrdenServicioTitulo_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.ORDEN_SERVICIO_TITULOColumnName; }
        }
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.ARTICULO_CODIGO_EMPRESAColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaUnidadDescripcion_NombreCol
        {
            get { return ORDENES_SERV_DET_INFO_COMPLCollection.UNIDAD_DESCRIPCIONColumnName; }
        }
        #endregion Accessors
    }
}




