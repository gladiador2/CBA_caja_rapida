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
    public class ImportacionesArticulosService
    {
        #region ImportacionArticulosDataTable
        public static DataTable ImportacionArticulosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService()) {
                DataTable table = sesion.Db.IMPORTACION_ARTICULOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion ImportacionArticulosDataTable

        #region ObtenerArticulosDeImportacion
        public static decimal[] ObtenerArticulosDeImportacion(decimal importacion_id)
        {
            List<decimal> articulos = new List<decimal>();
            string clausula = ImportacionesArticulosService.ImportacionID_NombreCol + " = " + importacion_id.ToString();
            DataTable dtArticulos = ImportacionArticulosDataTable(clausula, string.Empty);
            dtArticulos = dtArticulos.DefaultView.ToTable(true, ImportacionesArticulosService.ArticuloID_NombreCol);
            foreach (DataRow dr in dtArticulos.Rows)
                articulos.Add(decimal.Parse(dr[ImportacionesArticulosService.ArticuloID_NombreCol].ToString()));
            return articulos.ToArray();
        }
        #endregion ObtenerArticulosDeImportacion


        #region Accessors
        public static string Nombre_Vista
        {
            get { return "IMPORTACION_ARTICULOS"; }
        }

        public static string ArticuloID_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.ARTICULO_IDColumnName; }
        }
        public static string CantidadImportacion_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.CANTIDAD_IMPORTACIONColumnName; }
        }
        public static string DescripcionInterna_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.DESCRIPCION_INTERNAColumnName; }
        }
        public static string embarcador_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.EMBARCADORColumnName; }
        }
        public static string Existencia_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.EXISTENCIAColumnName; }
        }
        public static string FacturaProveedorID_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.FACTURA_PROVEEDOR_IDColumnName; }
        }
        public static string FamiliaDescripcion_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.FAMILIA_DESCRIPCIONColumnName; }
        }
        public static string FamiliaID_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.FAMILIA_IDColumnName; }
        }
        public static string FechaSalida_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.FECHA_SALIDAColumnName; }
        }
        public static string GrupoDescripcion_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.GRUPO_DESCRIPCIONColumnName; }
        }
        public static string GrupoID_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.GRUPO_IDColumnName; }
        }
        public static string ImportacionID_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.IMPORTACION_IDColumnName; }
        }
        public static string NombreInterno_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.NOMBRE_INTERNOColumnName; }
        }
        public static string LoteID_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.LOTE_IDColumnName; }
        }
        public static string NumeroBL_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.NUMERO_BLColumnName; }
        }
        public static string ProveedorID_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.PROVEEDOR_IDColumnName; }
        }
        public static string ProveedorNombre_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.PROVEEDOR_NOMBREColumnName; }
        }
        public static string StockDepositoNombre_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.STOCK_DEPOSITO_NOMBREColumnName; }
        }
        public static string SubgrupoDescripcion_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.SUBGRUPO_DESCRIPCIONColumnName; }
        }
        public static string SubgrupoID_NombreCol
        {
            get { return IMPORTACION_ARTICULOSCollection.SUBGRUPO_IDColumnName; }
        }

        #endregion Accessors
    }
}
