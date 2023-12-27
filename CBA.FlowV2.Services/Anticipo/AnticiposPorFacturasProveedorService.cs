using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Anticipo
{
    public class AnticiposPorFacturasProveedorService
    {
        #region GetAnticiposPorFacturasProveedorDataTable
        public static DataTable GetAnticiposPorFacturasProveedorDataTable(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.ANTICIPOS_FACTURAS_PROVEEDORCollection.GetAsDataTable(clausulas, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetAnticiposPorFacturasProveedorDataTable

        #region GetAnticiposPorFacturasProveedorInfoComp
        public DataTable GetAnticiposPorFacturasProveedorInfoComp(string clausulas, string orden)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.ANTICIPOS_FACT_PROV_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetAnticiposPorFacturasProveedorInfoComp

        #region ContieneFactura
        public static decimal ContieneFacturaAsociada(decimal AnticipoId)
        {
            string clausulas = AnticiposPorFacturasProveedorService.AnticipoProveedorId_NombreCol + " = " + AnticipoId;
            DataTable dtAnticipoFacturas = AnticiposPorFacturasProveedorService.GetAnticiposPorFacturasProveedorDataTable(clausulas, string.Empty);
            if (dtAnticipoFacturas.Rows.Count > 0)
            {
                if (dtAnticipoFacturas.Rows[0][AnticiposPorFacturasProveedorService.FacturaProveedorId_NombreCol].ToString() != string.Empty)
                    return decimal.Parse(dtAnticipoFacturas.Rows[0][AnticiposPorFacturasProveedorService.FacturaProveedorId_NombreCol].ToString());
                else
                    return Definiciones.Error.Valor.EnteroPositivo;
            }
            else
            {
                return Definiciones.Error.Valor.EnteroPositivo;
            }
        }

        public bool ContieneFactura(decimal anticipoProveedorId, List<decimal> facturasProveedor)
        {
            string clausulas = AnticiposPorFacturasProveedorService.AnticipoProveedorId_NombreCol + " = " + anticipoProveedorId.ToString();
            DataTable dtAnticipoFacturas = AnticiposPorFacturasProveedorService.GetAnticiposPorFacturasProveedorDataTable(clausulas, string.Empty);
            if (dtAnticipoFacturas.Rows.Count > 0)
            {
                foreach (DataRow row in dtAnticipoFacturas.Rows)
                {
                    decimal facturaProveedorId = (decimal)row[AnticiposPorFacturasProveedorService.FacturaProveedorId_NombreCol];
                    if (facturasProveedor.Contains(facturaProveedorId))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion ContieneFactura

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                ANTICIPOS_FACTURAS_PROVEEDORRow row = new ANTICIPOS_FACTURAS_PROVEEDORRow();
                
                try
                {
                    sesion.Db.BeginTransaction();

                    row.ANTICIPO_PROVEEDOR_ID = (decimal)campos[AnticipoProveedorId_NombreCol];
                    row.FACTURA_PROVEEDOR_ID = (decimal)campos[FacturaProveedorId_NombreCol];
                    row.FECHA = (DateTime)campos[Fecha_NombreCol];

                    sesion.Db.ANTICIPOS_FACTURAS_PROVEEDORCollection.Insert(row);
                    
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
        public void Borrar(decimal AnticipoProveedorId,decimal FacturaProveedorId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    ANTICIPOS_FACTURAS_PROVEEDORRow row = sesion.Db.ANTICIPOS_FACTURAS_PROVEEDORCollection.GetByPrimaryKey(AnticipoProveedorId, FacturaProveedorId);
                    sesion.Db.ANTICIPOS_FACTURAS_PROVEEDORCollection.Delete(row);
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
        public static string Nombre_tabla
        {
            get { return "ANTICIPOS_FACTURAS_PROVEEDOR"; }
        }
        public static string AnticipoProveedorId_NombreCol
        {
            get { return ANTICIPOS_FACTURAS_PROVEEDORCollection.ANTICIPO_PROVEEDOR_IDColumnName; }
        }
        public static string FacturaProveedorId_NombreCol
        {
            get { return ANTICIPOS_FACTURAS_PROVEEDORCollection.FACTURA_PROVEEDOR_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return ANTICIPOS_FACTURAS_PROVEEDORCollection.FECHAColumnName; }
        }

        public static string VistaFacturaCaso_NombreCol
        {
            get { return ANTICIPOS_FACT_PROV_INFO_COMPCollection.FACTURA_CASOColumnName; }
        }
        public static string VistaComprobante_NombreCol
        {
            get { return ANTICIPOS_FACT_PROV_INFO_COMPCollection.FACTURA_COMPROBANTEColumnName; }
        }
        public static string VistaProveedorNombre_NombreCol
        {
            get { return ANTICIPOS_FACT_PROV_INFO_COMPCollection.PROVEEDOR_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
