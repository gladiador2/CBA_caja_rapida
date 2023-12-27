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
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class OrdenesCompraDetalleRelacionesService
    {
        #region Getters
        public static DataTable GetOrdenesCompraDetRelaciones(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetOrdenesCompraDetRelaciones(clausula, orden, sesion);
            }
        }

        public static DataTable GetOrdenesCompraDetRelaciones(string clausula, string orden, SessionService sesion)
        {
            return sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.GetAsDataTable(clausula, orden);
        }

        public static decimal GetCantidadPorDetalleOrdenCompra(decimal detalle_id, SessionService sesion)
        {
            decimal cantidad = 0;
            ORDENES_COMPRA_DET_RELACIONESRow[] detalles = sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.GetByORDEN_COMPRA_DET_ID(detalle_id);
            for (int i = 0; i < detalles.Length; i++)
            {
                cantidad += detalles[i].CANTIDAD;
            }
            return cantidad;
        }
        #endregion Getters

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            ORDENES_COMPRA_DET_RELACIONESRow row = new ORDENES_COMPRA_DET_RELACIONESRow();
            string valorAnterior = string.Empty;

            if (!campos.Contains(OrdenesCompraDetalleRelacionesService.OrdenCompraDetalleId_NombreCol))
                throw new Exception("Falta indicar el detalle de la Orden de compra");
            if (!campos.Contains(OrdenesCompraDetalleRelacionesService.Cantidad_NombreCol))
                throw new Exception("Falta indicar la cantidad.");
            if (!campos.Contains(OrdenesCompraDetalleRelacionesService.FacturaProveedorDetalleId_NombreCol))
                throw new Exception("Falta indicar el detalle de la factura proveedor.");

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_compra_det_rel_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.db.ORDENES_COMPRA_DET_RELACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[OrdenesCompraDetalleRelacionesService.Id_NombreCol].ToString()));
                valorAnterior = row.ToString();
            }

            row.ORDEN_COMPRA_DET_ID = decimal.Parse(campos[OrdenesCompraDetalleRelacionesService.OrdenCompraDetalleId_NombreCol].ToString());
            row.CANTIDAD = decimal.Parse(campos[OrdenesCompraDetalleRelacionesService.Cantidad_NombreCol].ToString());
            row.FC_PROVEEDOR_DET_ID = decimal.Parse(campos[OrdenesCompraDetalleRelacionesService.FacturaProveedorDetalleId_NombreCol].ToString());

            if (insertarNuevo) sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.Insert(row);
            else sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(detalles_id, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Borrar(decimal detalles_id, SessionService sesion)
        {
            ORDENES_COMPRA_DET_RELACIONESRow row = new ORDENES_COMPRA_DET_RELACIONESRow();
            row = sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.GetByPrimaryKey(detalles_id);

            string valorAnterior = row.ToString();
            string valorNuevo = Definiciones.Log.RegistroBorrado;
            sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.DeleteByPrimaryKey(detalles_id);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
        }

        public static void BorrarPorFCProveedorDet(decimal fc_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    BorrarPorFCProveedorDet(fc_proveedor_detalle_id, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void BorrarPorFCProveedorDet(decimal fc_proveedor_detalle_id, SessionService sesion)
        {
            ORDENES_COMPRA_DET_RELACIONESRow[] row = sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.GetByFC_PROVEEDOR_DET_ID(fc_proveedor_detalle_id);

            string valorAnterior = row.ToString();
            string valorNuevo = Definiciones.Log.RegistroBorrado;
            for (int i = 0; i < row.Length; i++)
            {
                sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.DeleteByPrimaryKey(row[i].ID);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, valorAnterior, valorNuevo, sesion);
            }
        }

        public static void BorrarPorOrdenCompraDet(decimal orden_compra_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    BorrarPorOrdenCompraDet(orden_compra_detalle_id, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void BorrarPorOrdenCompraDet(decimal orden_compra_detalle_id, SessionService sesion)
        {
            ORDENES_COMPRA_DET_RELACIONESRow[] row = sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.GetByORDEN_COMPRA_DET_ID(orden_compra_detalle_id);

            string valorAnterior = row.ToString();
            string valorNuevo = Definiciones.Log.RegistroBorrado;
            for (int i = 0; i < row.Length; i++)
            {
                sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.DeleteByPrimaryKey(row[i].ID);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, valorAnterior, valorNuevo, sesion);
            }
        }
        #endregion Borrar

        #region ModificarDetalllePorFCProveedorDet
        public static void ModificarDetalllePorFCProveedorDet(decimal fc_proveedor_detalle_id, decimal cantidad)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ModificarDetalllePorFCProveedorDet(fc_proveedor_detalle_id, cantidad, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void ModificarDetalllePorFCProveedorDet(decimal fc_proveedor_detalle_id, decimal cantidad, SessionService sesion)
        {
            ORDENES_COMPRA_DET_RELACIONESRow[] row = sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.GetByFC_PROVEEDOR_DET_ID(fc_proveedor_detalle_id);

            string valorAnterior = string.Empty;

            for (int i = 0; i < row.Length; i++)
            {
                valorAnterior = row[i].ToString();
                row[i].CANTIDAD = cantidad;
                sesion.Db.ORDENES_COMPRA_DET_RELACIONESCollection.Update(row[i]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, valorAnterior, row[i].ToString(), sesion);
            }
        }
        #endregion ModificarDetalllePorId

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ORDENES_COMPRA_DET_RELACIONES"; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_COMPRA_DET_RELACIONESCollection.IDColumnName; }
        }
        public static string OrdenCompraDetalleId_NombreCol
        {
            get { return ORDENES_COMPRA_DET_RELACIONESCollection.ORDEN_COMPRA_DET_IDColumnName; }
        }
        public static string FacturaProveedorDetalleId_NombreCol
        {
            get { return ORDENES_COMPRA_DET_RELACIONESCollection.FC_PROVEEDOR_DET_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return ORDENES_COMPRA_DET_RELACIONESCollection.CANTIDADColumnName; }
        }
        #endregion Accessors
    }
}