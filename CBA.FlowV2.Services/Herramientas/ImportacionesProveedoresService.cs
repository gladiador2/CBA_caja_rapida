using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class ImportacionesProveedoresService
    {
        #region GetImportacionesProveedoresDataTable
        public DataTable GetImportacionesProveedoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACIONES_PROVEEDORESCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetImportacionesProveedoresDataTable

        #region GetImportacionesProveedoresInfoCompleta
        public DataTable GetImportacionesProveedoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACIONES_PROVE_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetImportacionesProveedoresInfoCompleta

        #region GetImportacionesProveedor
        public DataTable GetImportacionesProveedor(decimal proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ProveedorId_NombreCol + " = " + proveedor_id.ToString() +
                    " and " + VistaSePuedeModificar_NombreCol + " = '" + Definiciones.SiNo.Si + "'" +
                    " and " + VistaFinalizado_NombreCol + " = '" + Definiciones.SiNo.No + "'";
                DataTable table = sesion.Db.IMPORTACIONES_PROVE_INFO_COMPCollection.GetAsDataTable(clausulas, string.Empty);
                return table;
            }
        }
        #endregion GetImportacionesProveedor

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                IMPORTACIONES_PROVEEDORESRow row = new IMPORTACIONES_PROVEEDORESRow();
                try
                {
                    sesion.Db.BeginTransaction();

                    row.IMPORTACION_ID = (decimal)campos[ImportacionId_NombreCol];
                    row.PROVEEDOR_ID = (decimal)campos[ProveedorId_NombreCol];

                    sesion.Db.IMPORTACIONES_PROVEEDORESCollection.Insert(row);

                    sesion.Db.CommitTransaction();
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
        public void Borrar(decimal importacion_id, decimal proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    FacturasProveedorService facturasProveedor = new FacturasProveedorService();
                    string clausulas = FacturasProveedorService.ImportacionId_NombreCol + " = " + importacion_id.ToString() +
                        " and " + FacturasProveedorService.ProveedorId_NombreCol + " = " + proveedor_id.ToString();
                    DataTable dt = facturasProveedor.GetFacturaProveedorDataTable(clausulas,string.Empty);
                    if (dt.Rows.Count > 0)
                    {
                        throw new Exception("La importacion esta relacionada con facturas con el proveedor seleccionado");
                    }
                    

                    IMPORTACIONES_PROVEEDORESRow row;

                    row = sesion.Db.IMPORTACIONES_PROVEEDORESCollection.GetByPrimaryKey(importacion_id,proveedor_id);

                    sesion.Db.IMPORTACIONES_PROVEEDORESCollection.DeleteByPrimaryKey(importacion_id, proveedor_id);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "IMPORTACIONES_PROVEEDORES"; }
        }
        public static string ImportacionId_NombreCol
        {
            get { return IMPORTACIONES_PROVEEDORESCollection.IMPORTACION_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return IMPORTACIONES_PROVEEDORESCollection.PROVEEDOR_IDColumnName; }
        }
        public static string VistaProveedor_NombreCol
        {
            get { return IMPORTACIONES_PROVE_INFO_COMPCollection.PROVEEDORColumnName; }
        }
        public static string VistaFinalizado_NombreCol
        {
            get { return IMPORTACIONES_PROVE_INFO_COMPCollection.FINALIZADOColumnName; }
        }
        public static string VistaImportacionDescripcion_NombreCol
        {
            get { return IMPORTACIONES_PROVE_INFO_COMPCollection.IMPORTACION_DESCRIPCIONColumnName; }
        }
        public static string VistaSePuedeModificar_NombreCol
        {
            get { return IMPORTACIONES_PROVE_INFO_COMPCollection.SE_PUEDE_MODIFICARColumnName; }
        }
        #endregion Accessors
    }
}
