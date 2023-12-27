using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Contabilidad
{
    public class TiposComprobanteSET
    {
        #region GetTiposComprobante
        /// <summary>
        /// Obtener los tipos de factura de proveedor que puede ver el usuario
        /// </summary>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetTiposComprobante(bool soloActivos)
        {
            DataTable dt = new DataTable();
            CTB_TIPO_COMPROBANTE_SETRow row;
            
            dt.Columns.Add(TiposComprobanteSET.Id_NombreCol, typeof(decimal));
            dt.Columns.Add(TiposComprobanteSET.Nombre_NombreCol, typeof(string));
            dt.Columns.Add(TiposComprobanteSET.Estado_NombreCol, typeof(string));
            return dt;
        }
        #endregion GetTiposComprobante

        #region GetTipoComprobanteDataTable
        public static DataTable GetTiposComprobanteDataTable(string tipo)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_TIPO_COMPROBANTE_SETCollection.GetAsDataTable(TiposComprobanteSET.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" + " and tipo like '" + tipo + "'", TiposComprobanteSET.Nombre_NombreCol);
            }
        }
        #endregion GetTipoComprobanteDataTable

        #region GetTipoFacturaProveedor
        public static CTB_TIPO_COMPROBANTE_SETRow GetTipoComprobante(decimal tipoComprobanteId)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_TIPO_COMPROBANTE_SETCollection.GetByPrimaryKey(tipoComprobanteId);
            }
        }
        #endregion GetTipoFacturaProveedor

        #region EstaActivo
        public static bool EstaActivo(decimal tipoComprobanteId)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_TIPO_COMPROBANTE_SETRow row = new CTB_TIPO_COMPROBANTE_SETRow();
                row = sesion.Db.CTB_TIPO_COMPROBANTE_SETCollection.GetByPrimaryKey(tipoComprobanteId);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTB_TIPO_COMPROBANTE_SET"; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_TIPO_COMPROBANTE_SETCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTB_TIPO_COMPROBANTE_SETCollection.NOMBREColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTB_TIPO_COMPROBANTE_SETCollection.ESTADOColumnName; }
        }
        #endregion Accessors
    }
}
