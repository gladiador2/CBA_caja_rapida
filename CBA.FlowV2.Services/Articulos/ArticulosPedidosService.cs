#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;

using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.General;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosPedidosService
    {

        #region ArticulosPedidosDataTable
        public static DataTable ArticulosPedidosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService()) {
                DataTable table = sesion.Db.ARTICULOS_PEDIDOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion ArticulosPedidosDataTable

        #region ObtenerArticulosDePedido
        public static decimal[] ObtenerArticulosDePedido(decimal pedido_id)
        {
            List<decimal> articulos = new List<decimal>();
            string clausula = ArticulosPedidosService.PedidoClienteID_NombreCol + " = " + pedido_id.ToString();
            DataTable dtArticulos =  ArticulosPedidosDataTable(clausula, string.Empty);
            dtArticulos = dtArticulos.DefaultView.ToTable(true, ArticulosPedidosService.ArticuloID_NombreCol);
            foreach (DataRow dr in dtArticulos.Rows)
                articulos.Add(decimal.Parse(dr[ArticulosPedidosService.ArticuloID_NombreCol].ToString()));
            return articulos.ToArray();
        }
        #endregion ObtenerArticulosDePedido

        #region Accesors
        public static string Nombre_Vista
        {
            get { return "ARTICULOS_PEDIDOS"; } 
        }

        public static string ArticuloID_NombreCol
        { 
            get { return ARTICULOS_PEDIDOSCollection.ARTICULO_IDColumnName; } 
        }
        public static string DescripcionInterna_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.DESCRIPCION_INTERNAColumnName; }
        }
        public static string FamiliaDescripcion_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.FAMILIA_DESCRIPCIONColumnName; }
        }
        public static string FamiliaID_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.FAMILIA_IDColumnName; }
        }
        public static string GrupoDescripcion_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.GRUPO_DESCRIPCIONColumnName; }
        }
        public static string GrupoID_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.GRUPO_IDColumnName; }
        }
        public static string PedidoClienteID_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.PEDIDO_CLIENTE_IDColumnName; }
        }
        public static string PersonaID_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.PERSONA_IDColumnName; }
        }
        public static string PersonaNombre_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.PERSONA_NOMBREColumnName; }
        }
        public static string PreventaFechaEntrega_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.PREVENTA_FECHA_ENTREGAColumnName; }
        }
        public static string PreventaOrden_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.PREVENTA_ORDENColumnName; }
        }
        public static string SubgrupoDescripcion_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.SUBGRUPO_DESCRIPCIONColumnName; }
        }
        public static string SubgrupoID_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.SUBGRUPO_IDColumnName; }
        }

        public static string Existencia_NombreCol
        {
            get { return ARTICULOS_PEDIDOSCollection.EXISTENCIAColumnName; }
        }












        #endregion Accesors
    }
}
