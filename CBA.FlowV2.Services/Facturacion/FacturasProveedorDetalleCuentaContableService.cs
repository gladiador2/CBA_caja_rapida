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
    public class FacturasProveedorDetalleCuentaContableService
    {
        #region FacturasProveedorDetalleCuentaContableDataTable
        /// <summary>
        /// Gets the facturas proveedor detalle cuenta contable data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFacturasProveedorDetalleCuentaContableDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturasProveedorDetalleCuentaContableDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetFacturasProveedorDetalleCuentaContableDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FACTURAS_PROVEEDOR_DET_CTBCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion FacturasProveedorDetalleCuentaContableDataTable

        #region FacturasProveedorDetalleCuentaContableInfoCompleta
        /// <summary>
        /// Gets the facturas proveedor detalle cuenta contable info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFacturasProveedorDetalleCuentaContableInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FACTURAS_PROV_DET_CTB_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion FacturasProveedorDetalleCuentaContableInfoCompleta

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
                    FACTURAS_PROVEEDOR_DET_CTBRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(FacturasProveedorDetalleCuentaContableService.Id_NombreCol))
                    {
                        row = sesion.db.FACTURAS_PROVEEDOR_DET_CTBCollection.GetByPrimaryKey((decimal)campos[FacturasProveedorDetalleCuentaContableService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        row = new FACTURAS_PROVEEDOR_DET_CTBRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("facturas_proveedor_det_ctb_sqc");
                        row.FACTURA_PROVEEDOR_DETALLE_ID = (decimal)campos[FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol];
                    }

                    row.CTB_CUENTA_ID = (decimal)campos[FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];

                    if (campos.Contains(FacturasProveedorDetalleCuentaContableService.Id_NombreCol))
                        sesion.db.FACTURAS_PROVEEDOR_DET_CTBCollection.Update(row);
                    else
                        sesion.db.FACTURAS_PROVEEDOR_DET_CTBCollection.Insert(row);

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
        /// <param name="factura_proveedor_detalle_cuenta_id">The factura_proveedor_detalle_cuenta_id.</param>
        public static void Borrar(decimal factura_proveedor_detalle_cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FacturasProveedorDetalleCuentaContableService.Borrar(factura_proveedor_detalle_cuenta_id, sesion);
            }
        }

        public static void Borrar(decimal factura_proveedor_detalle_cuenta_id, decimal factura_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FacturasProveedorDetalleCuentaContableService.Borrar(factura_proveedor_detalle_cuenta_id, factura_proveedor_detalle_id, sesion);
            }
        }

        /// <summary>
        /// Borrars the specified factura_proveedor_detalle_cuenta_id.
        /// </summary>
        /// <param name="factura_proveedor_detalle_cuenta_id">The factura_proveedor_detalle_cuenta_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal factura_proveedor_detalle_cuenta_id, SessionService sesion)
        {
            FACTURAS_PROVEEDOR_DET_CTBRow row = sesion.db.FACTURAS_PROVEEDOR_DET_CTBCollection.GetByPrimaryKey(factura_proveedor_detalle_cuenta_id);
            sesion.db.FACTURAS_PROVEEDOR_DET_CTBCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }

        public static void Borrar(decimal factura_proveedor_detalle_cuenta_id, decimal factura_proveedor_detalle_id, SessionService sesion)
        {
            FACTURAS_PROVEEDOR_DET_CTBRow row = sesion.db.FACTURAS_PROVEEDOR_DET_CTBCollection.GetRow(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + factura_proveedor_detalle_id + " and " + FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol + " = " + factura_proveedor_detalle_cuenta_id);
            sesion.db.FACTURAS_PROVEEDOR_DET_CTBCollection.Delete(row);
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
                FACTURAS_PROVEEDOR_DET_CTBRow[] rows = sesion.db.FACTURAS_PROVEEDOR_DET_CTBCollection.GetByFACTURA_PROVEEDOR_DETALLE_ID(factura_proveedor_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.FACTURAS_PROVEEDOR_DET_CTBCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "FACTURAS_PROVEEDOR_DET_CTB"; }
        }
        public static string CtbCuentaId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_CTBCollection.CTB_CUENTA_IDColumnName; }
        }
        public static string FacturaProveedorDetalleId_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_CTBCollection.FACTURA_PROVEEDOR_DETALLE_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_CTBCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return FACTURAS_PROVEEDOR_DET_CTBCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCtbCuentaCodigoCompleto_NombreCol
        {
            get { return FACTURAS_PROV_DET_CTB_INFO_CCollection.CTB_CUENTA_CODIGO_COMPLETOColumnName; }
        }
        public static string VistaCtbCuentaNombre_NombreCol
        {
            get { return FACTURAS_PROV_DET_CTB_INFO_CCollection.CTB_CUENTA_NOMBREColumnName; }
        }
        public static string VistaCtbPlanCuentaId_NombreCol
        {
            get { return FACTURAS_PROV_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_IDColumnName; }
        }
        public static string VistaCtbPlanCuentaNombre_NombreCol
        {
            get { return FACTURAS_PROV_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
