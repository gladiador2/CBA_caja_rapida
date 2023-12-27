using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Facturacion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class ImportacionArticulosPedidosService
    {

        #region ImportacionArticulosPedidosDataTable
        public static DataTable ImportacionArticulosPedidosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACION_ARTICULOS_PEDIDOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion ImportacionArticulosPedidosDataTable

        #region Accessors
        public static string Nombre_Vista
        {
            get { return "IMPORTACION_ARTICULOS_PEDIDOS"; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.ARTICULO_IDColumnName; } 
        }
        public static string CantidadImportacion_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.CANTIDAD_IMPORTACIONColumnName; }
        }
        public static string CantidadPedidos_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.CANTIDAD_PEDIDOSColumnName; }
        }
        public static string DescripcionInterna_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.DESCRIPCION_INTERNAColumnName; }
        }
        public static string Existencia_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.EXISTENCIAColumnName; }
        }
        public static string FamiliaDescripcion_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.FAMILIA_DESCRIPCIONColumnName; }
        }
        public static string FamiliaId_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.FAMILIA_IDColumnName; }
        }
        public static string GrupoDescripcion_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.GRUPO_DESCRIPCIONColumnName; }
        }
        public static string GrupoId_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.GRUPO_IDColumnName; }
        }
        public static string SubgrupoDescripcion_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.SUBGRUPO_DESCRIPCIONColumnName; }
        }
        public static string SubgrupoId_NombreCol
        {
            get { return IMPORTACION_ARTICULOS_PEDIDOSCollection.SUBGRUPO_IDColumnName; }
        }
        #endregion Accessors

    }
}
