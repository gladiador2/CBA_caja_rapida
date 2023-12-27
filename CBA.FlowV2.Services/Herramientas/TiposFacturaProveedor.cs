using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TiposFacturaProveedorService
    {
        #region GetTiposFacturaProveedor
        /// <summary>
        /// Obtener los tipos de factura de proveedor que puede ver el usuario
        /// </summary>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetTiposFacturaProveedor(bool soloActivos)
        {
            DataTable dt = new DataTable();
            TIPOS_FACTURA_PROVEEDORRow row;
            dt.Columns.Add(TiposFacturaProveedorService.Id_NombreCol, typeof(decimal));
            dt.Columns.Add(TiposFacturaProveedorService.Nombre_NombreCol, typeof(string));
            dt.Columns.Add(TiposFacturaProveedorService.Estado_NombreCol, typeof(string));
            dt.Columns.Add("seleccionable", typeof(bool));
            
            if (RolesService.Tiene("tipo factura proveedor gastos ver")) {
                DataRow dr = dt.NewRow();
                row = GetTipoFacturaProveedor(Definiciones.TipoFacturaProveedor.Gastos);
                dr[TiposFacturaProveedorService.Id_NombreCol] = Definiciones.TipoFacturaProveedor.Gastos;
                dr[TiposFacturaProveedorService.Estado_NombreCol] = row.ESTADO;
                dr[TiposFacturaProveedorService.Nombre_NombreCol] = row.NOMBRE;
                dr["seleccionable"] = RolesService.Tiene("tipo factura proveedor gastos editar");
                if(soloActivos && row.ESTADO.Equals(Definiciones.Estado.Activo))
                    dt.Rows.Add(dr);
            }

            if (RolesService.Tiene("tipo factura proveedor compra articulos ver")) {
                DataRow dr = dt.NewRow();
                row = GetTipoFacturaProveedor(Definiciones.TipoFacturaProveedor.CompraArticulos);
                dr[TiposFacturaProveedorService.Id_NombreCol] = Definiciones.TipoFacturaProveedor.CompraArticulos;
                dr[TiposFacturaProveedorService.Estado_NombreCol] = row.ESTADO;
                dr[TiposFacturaProveedorService.Nombre_NombreCol] = row.NOMBRE;
                dr["seleccionable"] = RolesService.Tiene("tipo factura proveedor compra articulos editar");
                if(soloActivos && row.ESTADO.Equals(Definiciones.Estado.Activo))
                    dt.Rows.Add(dr);
            }
            if (RolesService.Tiene("TIPO FACTURA PROVEEDOR PAGO A TERCEROS VER"))
            {
                DataRow dr = dt.NewRow();
                row = GetTipoFacturaProveedor(Definiciones.TipoFacturaProveedor.PagoTerceros);
                dr[TiposFacturaProveedorService.Id_NombreCol] = Definiciones.TipoFacturaProveedor.PagoTerceros;
                dr[TiposFacturaProveedorService.Estado_NombreCol] = row.ESTADO;
                dr[TiposFacturaProveedorService.Nombre_NombreCol] = row.NOMBRE;
                dr["seleccionable"] = RolesService.Tiene("TIPO FACTURA PROVEEDOR PAGO A TERCEROS EDITAR");
                if (soloActivos && row.ESTADO.Equals(Definiciones.Estado.Activo))
                    dt.Rows.Add(dr);
            }
            if (RolesService.Tiene("TIPO FACTURA PROVEEDOR GASTOS DE DESPACHO VER"))
            {
                DataRow dr = dt.NewRow();
                row = GetTipoFacturaProveedor(Definiciones.TipoFacturaProveedor.GastosDeDespacho);
                dr[TiposFacturaProveedorService.Id_NombreCol] = Definiciones.TipoFacturaProveedor.GastosDeDespacho;
                dr[TiposFacturaProveedorService.Estado_NombreCol] = row.ESTADO;
                dr[TiposFacturaProveedorService.Nombre_NombreCol] = row.NOMBRE;
                dr["seleccionable"] = RolesService.Tiene("TIPO FACTURA PROVEEDOR GASTOS DE DESPACHO EDITAR");
                if (soloActivos && row.ESTADO.Equals(Definiciones.Estado.Activo))
                    dt.Rows.Add(dr);
            }
            if (RolesService.Tiene("TIPO FACTURA PROVEEDOR AUTOFACTURA VER"))
            {
                DataRow dr = dt.NewRow();
                row = GetTipoFacturaProveedor(Definiciones.TipoFacturaProveedor.Autofactura);
                dr[TiposFacturaProveedorService.Id_NombreCol] = Definiciones.TipoFacturaProveedor.Autofactura;
                dr[TiposFacturaProveedorService.Estado_NombreCol] = row.ESTADO;
                dr[TiposFacturaProveedorService.Nombre_NombreCol] = row.NOMBRE;
                dr["seleccionable"] = RolesService.Tiene("TIPO FACTURA PROVEEDOR AUTOFACTURA EDITAR");
                if (soloActivos && row.ESTADO.Equals(Definiciones.Estado.Activo))
                    dt.Rows.Add(dr);
            } 

            return dt;
        }
        #endregion GetTiposFacturaProveedor

        #region GetTipoFacturaProveedor
        public static TIPOS_FACTURA_PROVEEDORRow GetTipoFacturaProveedor(decimal tipoFacturaProveedorId)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TIPOS_FACTURA_PROVEEDORCollection.GetByPrimaryKey(tipoFacturaProveedorId);
            }
        }
        #endregion GetTipoFacturaProveedor

        #region EstaActivo
        public static bool EstaActivo(decimal tipo_factura_proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_FACTURA_PROVEEDORRow row = new TIPOS_FACTURA_PROVEEDORRow();
                row = sesion.Db.TIPOS_FACTURA_PROVEEDORCollection.GetByPrimaryKey(tipo_factura_proveedor_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }

        }
        #endregion EstaActivo

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TIPOS_FACTURA_PROVEEDOR"; }
        }
        public static string Id_NombreCol
        {
            get { return TIPOS_FACTURA_PROVEEDORCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TIPOS_FACTURA_PROVEEDORCollection.NOMBREColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TIPOS_FACTURA_PROVEEDORCollection.ESTADOColumnName; }
        }
        #endregion Accessors

    }
}
