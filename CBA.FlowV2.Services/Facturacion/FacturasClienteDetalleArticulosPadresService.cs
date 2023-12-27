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
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class FacturasClienteDetalleArticulosPadresService
    {
        #region GetFacturaClienteDetalleArticulosPadresDataTable
        /// <summary>
        /// Gets the factura cliente detalle articulos padres data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetFacturaClienteDetalleArticulosPadresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                dt = sesion.Db.FACTURAS_CLIENTE_DET_ART_PADRECollection.GetAsDataTable(clausulas, string.Empty);
                return dt;
            }
        }
        #endregion GetFacturaClienteDetalleArticulosPadresDataTable

        #region Accesors

        public static string ArticuloDescripcion_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.ARTICULO_DESCRIPCIONColumnName; }
        }

        public static string FacturasClienteId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.FACTURAS_CLIENTE_IDColumnName; }
        }
        
        public static string TotalBruto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.TOTAL_BRUTOColumnName; }
        }

        public static string CantidadUnitariaTotalDest_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.CANTIDAD_UNITARIA_TOTAL_DESTColumnName; }
        }

        public static string CostoMonto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.COSTO_MONTOColumnName; }
        }

        public static string CostoMonedaCabecera_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.COSTO_MONEDA_CABECERAColumnName; }
        }

        public static string Rentabilidad_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.RENTABILIDADColumnName; }
        }

        public static string TotalMontoDto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.TOTAL_MONTO_DTOColumnName; }
        }

        public static string TotalMontoImpuesto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.TOTAL_MONTO_IMPUESTOColumnName; }
        }

        public static string TotalNeto_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.TOTAL_NETOColumnName; }
        }

        public static string TotalRecargoFinanciero_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_ART_PADRECollection.TOTAL_RECARGO_FINANCIEROColumnName; }
        }
        #endregion Accesors
    }
}
