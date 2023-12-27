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
    public class OrdenesServicioDetalleRelacionesService
    {
        #region Getters
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
                return GetOrdenesServicioDetalleDataTable(clausula, orden,sesion);
            }
        }

        /// <summary>
        /// Gets the ordenes servicio detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioDetalleDataTable(string clausula, string orden, SessionService sesion)
        {
            
                return sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.GetAsDataTable(clausula, orden);
            
        }

        /// <summary>
        /// Gets the cantidad por detalle orden servicio.
        /// </summary>
        /// <param name="detalle_id">The detalle_id.</param>
        /// <returns></returns>
        public static decimal GetCantidadPorDetalleOrdenServicio(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCantidadPorDetalleOrdenServicio(detalle_id, sesion);
            }
        }

        /// <summary>
        /// Gets the cantidad por detalle orden servicio.
        /// </summary>
        /// <param name="detalle_id">The detalle_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetCantidadPorDetalleOrdenServicio(decimal detalle_id, SessionService sesion)
        {
            decimal cantidad = 0;
            ORDENES_SERV_DET_RELACIONESRow[] detalles = sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.GetByORDEN_SERVICIO_DET_ID(detalle_id);
            for (int i = 0; i < detalles.Length; i++)
            {
                cantidad += detalles[i].CANTIDAD;
            }
            return cantidad;
        }


        #endregion Getters



        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// 
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    Guardar(campos, insertarNuevo,sesion);
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

                    ORDENES_SERV_DET_RELACIONESRow row = new ORDENES_SERV_DET_RELACIONESRow();
                    string valorAnterior = string.Empty;

                    if (!campos.Contains(OrdenesServicioDetalleRelacionesService.OrdenServicioDetalleId_NombreCol))
                        throw new Exception("Falta indicar el detalle de la Orden de servicio");
                    if (!campos.Contains(OrdenesServicioDetalleRelacionesService.Cantidad_NombreCol))
                        throw new Exception("Falta indicar la cantidad.");

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_serv_det_rel_sqc");

                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else {
                        if (!campos.Contains(OrdenesServicioDetalleRelacionesService.Id_NombreCol))
                            throw new Exception("Falta indicar el detalle de la Orden de servicio");
                        row = sesion.db.ORDENES_SERV_DET_RELACIONESCollection.GetByPrimaryKey(decimal.Parse(campos[OrdenesServicioDetalleRelacionesService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.ORDEN_SERVICIO_DET_ID = decimal.Parse(campos[OrdenesServicioDetalleRelacionesService.OrdenServicioDetalleId_NombreCol].ToString());
                    row.CANTIDAD = decimal.Parse(campos[OrdenesServicioDetalleRelacionesService.Cantidad_NombreCol].ToString());

                    if (campos.Contains(OrdenesServicioDetalleRelacionesService.FacturaClienteDetalleId_NombreCol))
                        row.FC_CLIENTE_DET_ID = decimal.Parse(campos[OrdenesServicioDetalleRelacionesService.FacturaClienteDetalleId_NombreCol].ToString());
                    else
                        row.IsFC_CLIENTE_DET_IDNull = true;

                    if (campos.Contains(OrdenesServicioDetalleRelacionesService.FacturaProveedorDetalleId_NombreCol))
                        row.FC_PROVEEDOR_DET_ID = decimal.Parse(campos[OrdenesServicioDetalleRelacionesService.FacturaProveedorDetalleId_NombreCol].ToString());
                    else
                        row.IsFC_PROVEEDOR_DET_IDNull = true;
                   
                    

                    if (insertarNuevo) sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.Insert(row);
                    else sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.Update(row);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                                  
            
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified detalles_id.
        /// </summary>
        /// <param name="detalles_id">The detalles_id.</param>
        /// 
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
            
                    
                    ORDENES_SERV_DET_RELACIONESRow row = new ORDENES_SERV_DET_RELACIONESRow();
                    row = sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.GetByPrimaryKey(detalles_id);
                       
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.DeleteByPrimaryKey(detalles_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    
               
        }
        public static void BorrarPorFCProveedor(decimal fc_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    BorrarPorFCProveedor(fc_proveedor_detalle_id, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }

        }
        public static void BorrarPorFCProveedor(decimal fc_proveedor_detalle_id, SessionService sesion)
        {

           
            ORDENES_SERV_DET_RELACIONESRow[] row = sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.GetByFC_PROVEEDOR_DET_ID(fc_proveedor_detalle_id);

            string valorAnterior = row.ToString();
            string valorNuevo = Definiciones.Log.RegistroBorrado;
            for (int i = 0; i < row.Length; i++)
            {
                sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.DeleteByPrimaryKey(row[i].ID);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, valorAnterior, valorNuevo, sesion);
            }
            
            

        }

        public static void BorrarPorOrdenServicio(decimal orden_servicio_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    BorrarPorOrdenServicio(orden_servicio_detalle_id, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }

        }
        public static void BorrarPorOrdenServicio(decimal orden_servicio_detalle_id, SessionService sesion)
        {


            ORDENES_SERV_DET_RELACIONESRow[] row = sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.GetByORDEN_SERVICIO_DET_ID(orden_servicio_detalle_id);

            string valorAnterior = row.ToString();
            string valorNuevo = Definiciones.Log.RegistroBorrado;
            for (int i = 0; i < row.Length; i++)
            {
                sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.DeleteByPrimaryKey(row[i].ID);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, valorAnterior, valorNuevo, sesion);
            }



        }
        
        #endregion Borrar

        #region ModificarDetalllePorIdFactura
        public static void ModificarDetalllePorIdFacturaProveedor(decimal fc_proveedor_detalle_id,decimal cantidad)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ModificarDetalllePorIdFacturaProveedor(fc_proveedor_detalle_id,cantidad, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }

        }
        public static void ModificarDetalllePorIdFacturaProveedor(decimal fc_proveedor_detalle_id,decimal cantidad, SessionService sesion)
        {


            ORDENES_SERV_DET_RELACIONESRow[] row = sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.GetByFC_PROVEEDOR_DET_ID(fc_proveedor_detalle_id);

            string valorAnterior = string.Empty;

            for (int i = 0; i < row.Length; i++)
            {
                valorAnterior = row[i].ToString();
                row[i].CANTIDAD = cantidad;
                sesion.Db.ORDENES_SERV_DET_RELACIONESCollection.Update(row[i]);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row[i].ID, valorAnterior, row[i].ToString(), sesion);
            }



        }
        #endregion ModificarDetalllePorId

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ORDENES_SERV_DET_RELACIONES"; }
        }
        
        public static string Id_NombreCol
        {
            get { return ORDENES_SERV_DET_RELACIONESCollection.IDColumnName; }
        }
        public static string OrdenServicioDetalleId_NombreCol
        {
            get { return ORDENES_SERV_DET_RELACIONESCollection.ORDEN_SERVICIO_DET_IDColumnName; }
        }
        public static string FacturaClienteDetalleId_NombreCol
        {
            get { return ORDENES_SERV_DET_RELACIONESCollection.FC_CLIENTE_DET_IDColumnName; }
        }
        public static string FacturaProveedorDetalleId_NombreCol
        {
            get { return ORDENES_SERV_DET_RELACIONESCollection.FC_PROVEEDOR_DET_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return ORDENES_SERV_DET_RELACIONESCollection.CANTIDADColumnName; }
        }
        
        #endregion Accessors
    }
}




