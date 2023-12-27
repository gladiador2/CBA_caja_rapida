using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Facturacion
{
    public class OrdenesServicioDetalleInsumoService
    {
        #region GetOrdenesServicioDetalleInsumoDataTable
        /// <summary>
        /// Gets dataTable by the ordenServicioDetalleId 
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioDetalleInsumoDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERVICIO_DET_INSUMOSCollection.GetAsDataTable(clausula, orden);                
            }
        }
        #endregion GetOrdenesServicioDetalleInsumoDataTable

        #region Guardar
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

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            ORDENES_SERVICIO_DET_INSUMOSRow row = new ORDENES_SERVICIO_DET_INSUMOSRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("ORDENES_SERV_DET_INSUMOS_SQC");
                row.ORDEN_SERVICIO_DETALLE_ID = (decimal)campos[OrdenesServicioDetalleInsumoService.OrdenServicioDetalleId_NombreCol];
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.ORDENES_SERVICIO_DET_INSUMOSCollection.GetRow(OrdenesServicioDetalleInsumoService.Id_NombreCol + " = " + campos[OrdenesServicioDetalleInsumoService.Id_NombreCol]);               
                valorAnterior = row.ToString();
            }

            row.ARTICULO_ID = (decimal)campos[OrdenesServicioDetalleInsumoService.ArticuloId_NombreCol];
            row.CANTIDAD = (decimal)campos[OrdenesServicioDetalleInsumoService.Cantidad_NombreCol];
            row.UNIDAD_ID = campos[OrdenesServicioDetalleInsumoService.UnidadId_NombreCol].ToString();
            row.COSTO_UNITARIO = decimal.Parse(campos[OrdenesServicioDetalleInsumoService.CostoUnitario_NombreCol].ToString());
            row.COSTO_TOTAL = decimal.Parse(campos[OrdenesServicioDetalleInsumoService.CostoTotal_NombreCol].ToString());

            if (insertarNuevo) 
                sesion.Db.ORDENES_SERVICIO_DET_INSUMOSCollection.Insert(row);
            else 
                sesion.Db.ORDENES_SERVICIO_DET_INSUMOSCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }

        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified detalles_id.
        /// </summary>
        /// <param name="detalles_id">The detalles_id.</param>
        public static void Borrar(decimal insumos_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    ORDENES_SERVICIO_DET_INSUMOSRow row = new ORDENES_SERVICIO_DET_INSUMOSRow();
                    row = sesion.Db.ORDENES_SERVICIO_DET_INSUMOSCollection.GetByPrimaryKey(insumos_id);                    
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;

                    sesion.Db.ORDENES_SERVICIO_DET_INSUMOSCollection.DeleteByPrimaryKey(insumos_id);
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
            get { return "ORDENES_SERVICIO_DET_INSUMOS" ; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_INSUMOSCollection.IDColumnName ; }
        }
        public static string OrdenServicioDetalleId_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_INSUMOSCollection.ORDEN_SERVICIO_DETALLE_IDColumnName ; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_INSUMOSCollection.ARTICULO_IDColumnName ; }
        }
        public static string Cantidad_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_INSUMOSCollection.CANTIDADColumnName ; }
        }
        public static string CostoUnitario_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_INSUMOSCollection.COSTO_UNITARIOColumnName ; }
        }
        public static string CostoTotal_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_INSUMOSCollection.COSTO_TOTALColumnName ; }
        }
        public static string UnidadId_NombreCol
        {
            get { return ORDENES_SERVICIO_DET_INSUMOSCollection.UNIDAD_IDColumnName ; }
        }
        #endregion Accessors
    }
}
