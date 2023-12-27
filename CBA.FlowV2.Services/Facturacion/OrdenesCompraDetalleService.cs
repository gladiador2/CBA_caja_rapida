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
    public class OrdenesCompraDetalleService
    {
        #region GetOrdenesCompraDetalleDataTable
        public static DataTable GetOrdenesCompraDetalleDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_COMPRA_DETALLESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetOrdenesCompraDetalleDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (!campos.Contains(OrdenesCompraDetalleService.OrdenCompraId_NombreCol))
                        throw new Exception("Debe indicar la cabecera.");
                    if (!campos.Contains(OrdenesCompraDetalleService.ArticuloId_NombreCol))
                        throw new Exception("Debe indicar el artículo.");
                    if (!campos.Contains(OrdenesCompraDetalleService.Cantidad_NombreCol))
                        throw new Exception("Debe indicar la cantidad.");
                    if (!campos.Contains(OrdenesCompraDetalleService.UnidadMedidaId_NombreCol))
                        throw new Exception("Debe indicar la unidad de medida.");
                    if (!campos.Contains(OrdenesCompraDetalleService.CostoUnitario_NombreCol))
                        throw new Exception("Debe indicar el costo unitario.");

                    sesion.BeginTransaction();

                    ORDENES_COMPRA_DETALLESRow row = new ORDENES_COMPRA_DETALLESRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_compra_detalle_sqc");
                        row.ORDEN_COMPRA_ID = (decimal)campos[OrdenesCompraDetalleService.OrdenCompraId_NombreCol];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.ORDENES_COMPRA_DETALLESCollection.GetRow(OrdenesCompraDetalleService.Id_NombreCol + " = " + campos[OrdenesCompraDetalleService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.ARTICULO_ID = decimal.Parse(campos[OrdenesCompraDetalleService.ArticuloId_NombreCol].ToString());
                    row.CANTIDAD = decimal.Parse(campos[OrdenesCompraDetalleService.Cantidad_NombreCol].ToString());
                    row.UNIDAD_MEDIDA_ID = campos[OrdenesCompraDetalleService.UnidadMedidaId_NombreCol].ToString();
                    row.COSTO_UNITARIO = decimal.Parse(campos[OrdenesCompraDetalleService.CostoUnitario_NombreCol].ToString());
                    row.COSTO_TOTAL = row.COSTO_UNITARIO * row.CANTIDAD;
                    row.UNIDAD_MEDIDA_ID = campos[OrdenesCompraDetalleService.UnidadMedidaId_NombreCol].ToString();
                   
                    if (campos.Contains(OrdenesCompraDetalleService.CasoAsociadoId_NombreCol))
                    {
                        DataTable casos = CasosService.GetCasosInfoCompleta(CasosService.Id_NombreCol + " = " + campos[OrdenesServicioDetalleService.CasoAsociadoId_NombreCol], string.Empty, sesion);
                        if (casos.Rows.Count > 0)
                            row.CASO_ASOCIADO_ID = decimal.Parse(campos[OrdenesCompraDetalleService.CasoAsociadoId_NombreCol].ToString());
                        else
                            throw new Exception("No existe un caso con ese número.");
                    }
                    else
                    {
                        row.IsCASO_ASOCIADO_IDNull = true;
                    }
                    if (insertarNuevo) sesion.Db.ORDENES_COMPRA_DETALLESCollection.Insert(row);
                    else sesion.Db.ORDENES_COMPRA_DETALLESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

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
                    ORDENES_COMPRA_DETALLESRow row = new ORDENES_COMPRA_DETALLESRow();

                    row = sesion.Db.ORDENES_COMPRA_DETALLESCollection.GetByPrimaryKey(detalles_id);
                    //Se borra las relaciones si existen

                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.ORDENES_COMPRA_DETALLESCollection.DeleteByPrimaryKey(detalles_id);
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
            get { return "ORDENES_COMPRA_DETALLES"; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return ORDENES_COMPRA_DETALLESCollection.ARTICULO_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return ORDENES_COMPRA_DETALLESCollection.CANTIDADColumnName; }
        }
        public static string CostoUnitario_NombreCol
        {
            get { return ORDENES_COMPRA_DETALLESCollection.COSTO_UNITARIOColumnName; }
        }
        public static string CostoTotal_NombreCol
        {
            get { return ORDENES_COMPRA_DETALLESCollection.COSTO_TOTALColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_COMPRA_DETALLESCollection.IDColumnName; }
        }
        public static string OrdenCompraId_NombreCol
        {
            get { return ORDENES_COMPRA_DETALLESCollection.ORDEN_COMPRA_IDColumnName; }
        }
        public static string UnidadMedidaId_NombreCol
        {
            get { return ORDENES_COMPRA_DETALLESCollection.UNIDAD_MEDIDA_IDColumnName; }
        }
        public static string CasoAsociadoId_NombreCol
        {
            get { return ORDENES_COMPRA_DETALLESCollection.CASO_ASOCIADO_IDColumnName; }
        }
        
        #endregion Accessors
    }
}




