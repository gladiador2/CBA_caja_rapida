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
    public class NotasDePedidoDetalleItemsService
    {
        #region GetNotasDePedidoDetalleItemsDataTable
        public DataTable GetNotasDePedidoDetalleItemsDataTable(decimal notaDePedidoDetalleId)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                //Realizar la busqueda sin importar tildes ni mayusculas
                sesion.Db.IniciarBusquedaFlexible();

                dt = sesion.Db.PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.GetAsDataTable(PedidosClienteDetalleId_NombreCol + " = " + notaDePedidoDetalleId,string.Empty);

                //Finalizar el uso de busqueda sin importar tildes ni mayusculas
                sesion.Db.FinalizarBusquedaFlexible();

                return dt;
            }
        }
        public static DataTable GetNotasDePedidoDetalleItemsDataTable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                dt = sesion.Db.PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.GetAsDataTable(clausulas, Id_NombreCol);

                return dt;
            }
        }
        #endregion GetNotasDePedidoDetalleItemsDataTable

        #region Guardar
        public  static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PEDIDOS_CLIENTE_DETALLE_ITEMSRow row = new PEDIDOS_CLIENTE_DETALLE_ITEMSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("PEDIDOS_CLIENTE_DET_ITEMS_SQC");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.GetRow(NotasDePedidoDetalleItemsService.Id_NombreCol + " = " + campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.PEDIDOS_CLIENTE_DETALLE_ID = (decimal)campos[NotasDePedidoDetalleItemsService.PedidosClienteDetalleId_NombreCol];
                    row.CANTIDAD = (decimal)campos[NotasDePedidoDetalleItemsService.Cantidad_NombreCol];
                    row.UNIDADES = (decimal)campos[NotasDePedidoDetalleItemsService.Unidades_NombreCol];
                    row.COMENTARIO = (string)campos[NotasDePedidoDetalleItemsService.Comentario_NombreCol];

                    if (insertarNuevo) sesion.Db.PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.Insert(row);
                    else sesion.Db.PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return row.ID;
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
        public static void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    PEDIDOS_CLIENTE_DETALLE_ITEMSRow row = sesion.Db.PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.GetByPrimaryKey(id);
                    
                    sesion.Db.BeginTransaction();

                    sesion.Db.PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.Delete(row);
                   
                    LogCambiosService.LogDeRegistro("pedidos_cliente_detalle_items", row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Borrar por Item
        public void BorrarPorItem(decimal pedido_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    PEDIDOS_CLIENTE_DETALLE_ITEMSRow[] subItemsRow= sesion.Db.PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.GetByPEDIDOS_CLIENTE_DETALLE_ID(pedido_id);

                    for (int i = 0; i < subItemsRow.Length; i++)
                    {
                        sesion.Db.BeginTransaction();

                        sesion.Db.PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.Delete(subItemsRow[i]);

                        LogCambiosService.LogDeRegistro("pedidos_cliente_detalle_items", subItemsRow[i].ID, subItemsRow[i].ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        sesion.Db.CommitTransaction();
                        
                    }

                    

                   
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar por Item

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PEDIDOS_CLIENTE_DETALLE_ITEMS"; }
        }
        public static string Id_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.IDColumnName; }
        }
        public static string PedidosClienteDetalleId_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.PEDIDOS_CLIENTE_DETALLE_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.CANTIDADColumnName; }
        }
        public static string Unidades_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.UNIDADESColumnName; }
        }
        public static string Comentario_NombreCol
        {
            get { return PEDIDOS_CLIENTE_DETALLE_ITEMSCollection.COMENTARIOColumnName; }
        }
        #endregion Accessors
    }
}
