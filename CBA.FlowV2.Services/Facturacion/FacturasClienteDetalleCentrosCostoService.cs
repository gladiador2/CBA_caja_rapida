#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion using

namespace CBA.FlowV2.Services.Facturacion
{
    public class FacturasClienteDetalleCentrosCostoService
    {
        #region GetDataTable
        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = FacturasClienteDetalleCentrosCostoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.FACTURAS_CLIENTE_DET_CENT_CCollection.GetAsDataTable(where, orden);
        }
        #endregion GetDataTable

        #region GetInfoCompleta
        public static DataTable GetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = FacturasClienteDetalleCentrosCostoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;
                return sesion.Db.FACTURAS_CLIENTE_DET_CC_INFO_CCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    FACTURAS_CLIENTE_DET_CENT_CRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(FacturasClienteDetalleCentrosCostoService.Id_NombreCol))
                    {
                        row = sesion.db.FACTURAS_CLIENTE_DET_CENT_CCollection.GetByPrimaryKey((decimal)campos[FacturasClienteDetalleCentrosCostoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        #region Validar que no fue agregado anteriormente
                        string clausulas = FacturasClienteDetalleCentrosCostoService.FacturaClienteDetalleId_NombreCol + " = " + campos[FacturasClienteDetalleCentrosCostoService.FacturaClienteDetalleId_NombreCol] + " and " +
                                           FacturasClienteDetalleCentrosCostoService.CentroCostoId_NombreCol + " = " + campos[FacturasClienteDetalleCentrosCostoService.CentroCostoId_NombreCol];
                        DataTable dt = GetInfoCompleta(clausulas, string.Empty);

                        if (dt.Rows.Count > 0)
                            throw new Exception("El centro de costo " + dt.Rows[0][FacturasClienteDetalleCentrosCostoService.VistaCentroCostoNombre_NombreCol] + " ya estaba incluido.");
                        #endregion Validar que no es parte del grupo

                        row = new FACTURAS_CLIENTE_DET_CENT_CRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("facturas_cliente_det_cc_sqc");
                        row.FACTURA_CLIENTE_DETALLE_ID = (decimal)campos[FacturasClienteDetalleCentrosCostoService.FacturaClienteDetalleId_NombreCol];
                        row.ESTADO = Definiciones.Estado.Activo;
                    }

                    row.CENTRO_COSTO_ID = (decimal)campos[FacturasClienteDetalleCentrosCostoService.CentroCostoId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[FacturasClienteDetalleCentrosCostoService.Porcentaje_NombreCol];

                    if (campos.Contains(FacturasClienteDetalleCentrosCostoService.Id_NombreCol))
                        sesion.db.FACTURAS_CLIENTE_DET_CENT_CCollection.Update(row);
                    else
                        sesion.db.FACTURAS_CLIENTE_DET_CENT_CCollection.Insert(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal factura_cliente_detalle_centro_costo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FacturasClienteDetalleCentrosCostoService.Borrar(factura_cliente_detalle_centro_costo_id, sesion);
            }
        }

        public static void Borrar(decimal factura_cliente_detalle_centro_costo_id, SessionService sesion)
        {
            FACTURAS_CLIENTE_DET_CENT_CRow row = sesion.db.FACTURAS_CLIENTE_DET_CENT_CCollection.GetByPrimaryKey(factura_cliente_detalle_centro_costo_id);
            
            //Para realizar el borrado logico se aguarda a que
            //el detalle de FC Cliente tambien tenga borrado logico
            //row.ESTADO = Definiciones.Estado.Inactivo;
            //sesion.db.FACTURAS_CLIENTE_DET_CENT_CCollection.Update(row);
            sesion.db.FACTURAS_CLIENTE_DET_CENT_CCollection.Delete(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente
        /// <summary>
        /// Distribuirs the porcentajes equitativamente.
        /// </summary>
        /// <param name="factura_proveedor_detalle_id">The factura_proveedor_detalle_id.</param>
        public static void DistribuirPorcentajesEquitativamente(decimal factura_cliente_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FACTURAS_CLIENTE_DET_CENT_CRow[] rows = sesion.db.FACTURAS_CLIENTE_DET_CENT_CCollection.GetByFACTURA_CLIENTE_DETALLE_ID(factura_cliente_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.FACTURAS_CLIENTE_DET_CENT_CCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "FACTURAS_CLIENTE_DET_CENT_C"; }
        }
        public static string Nombre_Vista
        {
            get { return "FACTURAS_CLIENTE_DET_CC_INFO_C"; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_CENT_CCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_CENT_CCollection.ESTADOColumnName; }
        }
        public static string FacturaClienteDetalleId_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_CENT_CCollection.FACTURA_CLIENTE_DETALLE_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_CENT_CCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_CENT_CCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCentroCostoAbreviatura_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_CC_INFO_CCollection.CENTRO_COSTO_ABREVIATURAColumnName; }
        }
        public static string VistaCentroCostoNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_CC_INFO_CCollection.CENTRO_COSTO_NOMBREColumnName; }
        }
        public static string VistaCentroCostoOrden_NombreCol
        {
            get { return FACTURAS_CLIENTE_DET_CC_INFO_CCollection.CENTRO_COSTO_ORDENColumnName; }
        }
        #endregion Accessors
    }
}
