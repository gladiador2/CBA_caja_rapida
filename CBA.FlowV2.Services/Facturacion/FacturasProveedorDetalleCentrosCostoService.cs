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
    public class FacturasProveedorDetalleCentrosCostoService
    {
        #region GetFacturasProveedorDetalleCentrosCostoDataTable
        /// <summary>
        /// Gets the facturas proveedor detalle centros costo data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFacturasProveedorDetalleCentrosCostoDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetFacturasProveedorDetalleCentrosCostoDataTable

        #region GetFacturasProveedorDetalleCentrosCostoInfoCompleta
        /// <summary>
        /// Gets the facturas proveedor detalle centros costo information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFacturasProveedorDetalleCentrosCostoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FACTURAS_PROV_DET_CC_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetFacturasProveedorDetalleCentrosCostoInfoCompleta

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
                    FACTURAS_PROVEEDOR_DET_CENT_CRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(FacturasProveedorDetalleCentrosCostoService.Id_NombreCol))
                    {
                        row = sesion.db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.GetByPrimaryKey((decimal)campos[FacturasProveedorDetalleCentrosCostoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        #region Validar que no fue agregado anteriormente
                        string clausulas = FacturasProveedorDetalleCentrosCostoService.FacturaProveedorDetalleId_NombreCol + " = " + campos[FacturasProveedorDetalleCentrosCostoService.FacturaProveedorDetalleId_NombreCol] + " and " +
                                           FacturasProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol + " = " + campos[FacturasProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol];
                        DataTable dt = GetFacturasProveedorDetalleCentrosCostoInfoCompleta(clausulas, string.Empty);

                        if (dt.Rows.Count > 0)
                            throw new Exception("El centro de costo " + dt.Rows[0][FacturasProveedorDetalleCentrosCostoService.VistaCentroCostoNombre_NombreCol] + " ya estaba incluido.");
                        #endregion Validar que no es parte del grupo

                        row = new FACTURAS_PROVEEDOR_DET_CENT_CRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("facturas_proveedor_det_cc_sqc");
                        row.FACTURA_PROVEEDOR_DETALLE_ID = (decimal)campos[FacturasProveedorDetalleCentrosCostoService.FacturaProveedorDetalleId_NombreCol];
                    }

                    row.CENTRO_COSTO_ID = (decimal)campos[FacturasProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];

                    if (campos.Contains(FacturasProveedorDetalleCentrosCostoService.Id_NombreCol))
                        sesion.db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.Update(row);
                    else
                        sesion.db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.Insert(row);

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
        /// <summary>
        /// Borrars the specified factura_proveedor_detalle_cuenta_id.
        /// </summary>
        /// <param name="factura_proveedor_detalle_centro_costo_id">The factura_proveedor_detalle_centro_costo_id.</param>
        public static void Borrar(decimal factura_proveedor_detalle_centro_costo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FacturasProveedorDetalleCentrosCostoService.Borrar(factura_proveedor_detalle_centro_costo_id, sesion);
            }
        }

        public static void Borrar(decimal factura_proveedor_detalle_centro_costo_id, decimal factura_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FacturasProveedorDetalleCentrosCostoService.Borrar(factura_proveedor_detalle_centro_costo_id, factura_proveedor_detalle_id, sesion);
            }
        }

        /// <summary>
        /// Borrars the specified factura_proveedor_detalle_cuenta_id.
        /// </summary>
        /// <param name="factura_proveedor_detalle_centro_costo_id">The factura_proveedor_detalle_centro_costo_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal factura_proveedor_detalle_centro_costo_id, SessionService sesion)
        {
            FACTURAS_PROVEEDOR_DET_CENT_CRow row = sesion.db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.GetByPrimaryKey(factura_proveedor_detalle_centro_costo_id);
            sesion.db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }

        public static void Borrar(decimal factura_proveedor_detalle_centro_costo_id, decimal factura_proveedor_detalle_id, SessionService sesion)
        {
            FACTURAS_PROVEEDOR_DET_CENT_CRow row = sesion.db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.GetRow(FacturasProveedorDetalleCentrosCostoService.FacturaProveedorDetalleId_NombreCol + " = " + factura_proveedor_detalle_id + " and " + FacturasProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol + " = " + factura_proveedor_detalle_centro_costo_id);
            sesion.db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente
        /// <summary>
        /// Distribuirs the porcentajes equitativamente.
        /// </summary>
        /// <param name="factura_proveedor_detalle_id">The factura_proveedor_detalle_id.</param>
        public static void DistribuirPorcentajesEquitativamente(decimal factura_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FACTURAS_PROVEEDOR_DET_CENT_CRow[] rows = sesion.db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.GetByFACTURA_PROVEEDOR_DETALLE_ID(factura_proveedor_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.FACTURAS_PROVEEDOR_DET_CENT_CCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "FACTURAS_PROVEEDOR_DET_CENT_C"; }
        }
        public static string Nombre_Vista
        {
            get { return "FACTURAS_PROV_DET_CC_INFO_C"; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_CENT_CCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string FacturaProveedorDetalleId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_CENT_CCollection.FACTURA_PROVEEDOR_DETALLE_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_CENT_CCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_CENT_CCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCentroCostoAbreviatura_NombreCol
        {
            get { return FACTURAS_PROV_DET_CC_INFO_CCollection.CENTRO_COSTO_ABREVIATURAColumnName; }
        }
        public static string VistaCentroCostoNombre_NombreCol
        {
            get { return FACTURAS_PROV_DET_CC_INFO_CCollection.CENTRO_COSTO_NOMBREColumnName; }
        }
        public static string VistaCentroCostoOrden_NombreCol
        {
            get { return FACTURAS_PROV_DET_CC_INFO_CCollection.CENTRO_COSTO_ORDENColumnName; }
        }
        #endregion Accessors
    }
}
