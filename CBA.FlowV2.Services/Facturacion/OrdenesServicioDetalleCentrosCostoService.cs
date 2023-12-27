#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion using

namespace CBA.FlowV2.Services.Facturacion
{
    public class OrdenesServicioDetalleCentrosCostoService
    {
        #region GetOrdenesServicioDetalleCentrosCosto

        /// <summary>
        /// Gets the ordenes servicio detalle centros costo.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioDetalleCentrosCosto(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ORDENES_SERVICIO_DET_CENT_COSCollection.GetAsDataTable(clausulas, orden);
        }
        /// <summary>
        /// Gets the ordenes servicio detalle centros costo.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioDetalleCentrosCosto(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetOrdenesServicioDetalleCentrosCosto(clausulas, orden, sesion);
            }
        }
        #endregion GetFacturasProveedorDetalleCentrosCostoDataTable

        #region GetOrdenesServicioDetalleCentrosCostoInfoCompleta
        /// <summary>
        /// Gets the ordenes servicio detalle centros costo information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioDetalleCentrosCostoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERV_DET_CC_INF_CCollection.GetAsDataTable(clausulas, orden);
            }
        }

        #endregion GetOrdenesServicioDetalleCentrosCostoInfoCompleta

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
                    ORDENES_SERVICIO_DET_CENT_COSRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(OrdenesServicioDetalleCentrosCostoService.Id_NombreCol))
                    {
                        row = sesion.db.ORDENES_SERVICIO_DET_CENT_COSCollection.GetByPrimaryKey((decimal)campos[OrdenesServicioDetalleCentrosCostoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        #region Validar que no fue agregado anteriormente
                        string clausulas = OrdenesServicioDetalleCentrosCostoService.OrdenServicioDetalleId_NombreCol + " = " + campos[OrdenesServicioDetalleCentrosCostoService.OrdenServicioDetalleId_NombreCol] + " and " +
                                           OrdenesServicioDetalleCentrosCostoService.CentroCostoId_NombreCol + " = " + campos[OrdenesServicioDetalleCentrosCostoService.CentroCostoId_NombreCol];
                        DataTable dt = GetOrdenesServicioDetalleCentrosCosto(clausulas, string.Empty);

                        if (dt.Rows.Count > 0)
                            throw new Exception("El centro de costo ya estaba incluido.");
                        #endregion Validar que no es parte del grupo

                        row = new ORDENES_SERVICIO_DET_CENT_COSRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("ORDENES_SERVICIO_DET_CC_SQC");
                        row.ORDEN_SERVICIO_DET_ID = (decimal)campos[OrdenesServicioDetalleCentrosCostoService.OrdenServicioDetalleId_NombreCol];
                    }

                    row.CENTRO_COSTO_ID = (decimal)campos[OrdenesServicioDetalleCentrosCostoService.CentroCostoId_NombreCol];
                    row.CANTIDAD = (decimal)campos[OrdenesServicioDetalleCentrosCostoService.Cantidad_NombreCol];

                    if (campos.Contains(OrdenesServicioDetalleCentrosCostoService.Id_NombreCol))
                        sesion.db.ORDENES_SERVICIO_DET_CENT_COSCollection.Update(row);
                    else
                        sesion.db.ORDENES_SERVICIO_DET_CENT_COSCollection.Insert(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        
        public static void Borrar(decimal orden_servcio_detalle_centro_costo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                OrdenesServicioDetalleCentrosCostoService.Borrar(orden_servcio_detalle_centro_costo_id, sesion);
            }
        }

        public static void Borrar(decimal orden_servcio_detalle_centro_costo_id, SessionService sesion)
        {
            ORDENES_SERVICIO_DET_CENT_COSRow row = sesion.db.ORDENES_SERVICIO_DET_CENT_COSCollection.GetByPrimaryKey(orden_servcio_detalle_centro_costo_id);
            sesion.db.ORDENES_SERVICIO_DET_CENT_COSCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        public static void BorrarPorOrdenDetalle(decimal orden_servcio_detalle_id, SessionService sesion)
        {
            ORDENES_SERVICIO_DET_CENT_COSRow[] row = sesion.db.ORDENES_SERVICIO_DET_CENT_COSCollection.GetByORDEN_SERVICIO_DET_ID(orden_servcio_detalle_id);
            for (int i = 0; i < row.Length; i++)
            {
                sesion.db.ORDENES_SERVICIO_DET_CENT_COSCollection.Delete(row[i]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
                
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ORDEN_SERVICIO_DET_CENT_COS"; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_CENT_COSCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string OrdenServicioDetalleId_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_CENT_COSCollection.ORDEN_SERVICIO_DET_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_CENT_COSCollection.IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_CENT_COSCollection.CANTIDADColumnName; }
        }
        public static string Nombre_Vista
        {
            get { return "ordenes_serv_det_cc_inf_c"; }
        }
        public static string VistaCentroCostoNombre_NombreCol
        {
            get { return ORDENES_SERV_DET_CC_INF_CCollection.CENTRO_COSTO_NOMBREColumnName; }
        }
        public static string VistaCentroCostoAbreviatura_NombreCol
        {
            get { return ORDENES_SERV_DET_CC_INF_CCollection.CENTRO_COSTO_ABREVIATURAColumnName; }
        }
        public static string VistaCentroCostoOrden_NombreCol
        {
            get { return ORDENES_SERV_DET_CC_INF_CCollection.CENTRO_COSTO_ORDENColumnName; }
        }
        #endregion Accessors
    }
}
