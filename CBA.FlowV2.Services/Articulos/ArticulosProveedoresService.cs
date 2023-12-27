#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;
#endregion Using

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosProveedoresService
    {
        #region GetArticulosProveedoresDataTable
        /// <summary>
        /// Gets the articulos proveedores data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosProveedoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_PROVEEDORESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosProveedoresDataTable
        
        #region GetArticulosProveedoresInfoCompleta
        /// <summary>
        /// Gets the articulos proveedores info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public  DataTable GetArticulosProveedoresInfoCompleta(string clausulas, string orden)
         {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ART_PROV_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
         }
        #endregion GetArticulosProveedoresInfoCompleta

        #region GetArticulosProveedoresPorArticulo
        /// <summary>
        /// Gets the articulos proveedores por articulo.
        /// </summary>
        /// <returns></returns>
        public DataTable GetArticulosProveedoresPorArticulo(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = ArticulosProveedoresService.ArticuloId_NombreCol + " = " + articulo_id;
                return sesion.Db.ART_PROV_INFO_COMPLETACollection.GetAsDataTable(where, ArticulosProveedoresService.VistaProveedorCodigo_NombreCol);
            }
        }
        #endregion GetArticulosProveedoresPorArticulo

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_PROVEEDORESRow row = new ARTICULOS_PROVEEDORESRow();
                sesion.Db.BeginTransaction();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("articulos_proveedores_sqc");
                    row.ARTICULO_ID = (decimal)campos[ArticulosProveedoresService.ArticuloId_NombreCol];
                }
                else
                {
                    row = sesion.Db.ARTICULOS_PROVEEDORESCollection.GetByPrimaryKey((decimal)campos[ArticulosProveedoresService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                row.PROVEEDOR_ID = (decimal)campos[ArticulosProveedoresService.ProveedorId_NombreCol];
                row.CODIGO = (string)campos[ArticulosProveedoresService.Codigo_NombreCol];
                row.DESCRIPCION = (string)campos[ArticulosProveedoresService.Descripcion_NombreCol]; 
                    
                if (campos.Contains(ArticulosProveedoresService.CodigoBarras_NombreCol))
                    row.CODIGO_BARRA = (string)campos[ArticulosProveedoresService.CodigoBarras_NombreCol];
                if (campos.Contains(ArticulosProveedoresService.Catalogo_NombreCol))
                    row.CATALOGO = (string)campos[ArticulosProveedoresService.Catalogo_NombreCol];

                if (insertarNuevo) sesion.Db.ARTICULOS_PROVEEDORESCollection.Insert(row);
                else sesion.Db.ARTICULOS_PROVEEDORESCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                
                sesion.Db.CommitTransaction();
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified articulo proveedor id.
        /// </summary>
        /// <param name="articuloProveedorId">The articulo proveedor id.</param>
        public void Borrar(decimal articuloProveedorId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ARTICULOS_PROVEEDORESRow row = sesion.Db.ARTICULOS_PROVEEDORESCollection.GetRow(ArticulosProveedoresService.Id_NombreCol + " = " + articuloProveedorId.ToString());
                    String valorAnterior = row.ToString();

                    sesion.Db.ROLESCollection.DeleteByPrimaryKey(articuloProveedorId);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);

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

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_PROVEEDORES"; }
        }
        public static string Nombre_Vista
        {
            get { return "ART_PROV_INFO_COMPLETA"; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return ARTICULOS_PROVEEDORESCollection.ARTICULO_IDColumnName; }
        }
        public static string Catalogo_NombreCol
        {
            get { return ARTICULOS_PROVEEDORESCollection.CATALOGOColumnName; }
        }
        public static string CodigoBarras_NombreCol
        {
            get { return ARTICULOS_PROVEEDORESCollection.CODIGO_BARRAColumnName; }
        }
        public static string Codigo_NombreCol
        {
            get { return ARTICULOS_PROVEEDORESCollection.CODIGOColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ARTICULOS_PROVEEDORESCollection.DESCRIPCIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ARTICULOS_PROVEEDORESCollection.IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return ARTICULOS_PROVEEDORESCollection.PROVEEDOR_IDColumnName; }
        }
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return ART_PROV_INFO_COMPLETACollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloNombre_NombreCol
        {
            get { return ART_PROV_INFO_COMPLETACollection.ARTICULO_NOMBREColumnName; }
        }
        public static string VistaProveedorCodigo_NombreCol
        {
            get { return ART_PROV_INFO_COMPLETACollection.PROVEEDOR_CODIGOColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return ART_PROV_INFO_COMPLETACollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }
        //no reponer
        public static string VistaNoReponer_NombreCol
        {
            get { return ART_PROV_INFO_COMPLETACollection.NO_REPONERColumnName; }
        }


        #endregion Accessors
    }
}
