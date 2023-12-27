#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class MovimientoFondoFijoDetalleCentrosCostoService
    {
        #region GetDataTable
        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = MovimientoFondoFijoDetalleCentrosCostoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.MOV_FONDO_FIJO_DET_CENT_CCollection.GetAsDataTable(where, orden);
        }
        public static DataTable GetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDataTable(clausulas, orden, sesion);
            }
        }
        #endregion GetDataTable

        #region GetInfoCompleta
        public static DataTable GetInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
           
                string where = MovimientoFondoFijoDetalleCentrosCostoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;
                return sesion.Db.MOV_FONDO_FIJO_DET_CC_INFO_CCollection.GetAsDataTable(where, orden);
            
        }
        public static DataTable GetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetInfoCompleta(clausulas, orden, sesion);
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
                    MOV_FONDO_FIJO_DET_CENT_CRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(MovimientoFondoFijoDetalleCentrosCostoService.Id_NombreCol))
                    {
                        row = sesion.db.MOV_FONDO_FIJO_DET_CENT_CCollection.GetByPrimaryKey((decimal)campos[MovimientoFondoFijoDetalleCentrosCostoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        #region Validar que no fue agregado anteriormente
                        string clausulas = MovimientoFondoFijoDetalleCentrosCostoService.MovimientoFondoFijoDetalleId_NombreCol + " = " + campos[MovimientoFondoFijoDetalleCentrosCostoService.MovimientoFondoFijoDetalleId_NombreCol] + " and " +
                                           MovimientoFondoFijoDetalleCentrosCostoService.CentroCostoId_NombreCol + " = " + campos[MovimientoFondoFijoDetalleCentrosCostoService.CentroCostoId_NombreCol];
                        DataTable dt = GetInfoCompleta(clausulas, string.Empty);

                        if (dt.Rows.Count > 0)
                            throw new Exception("El centro de costo " + dt.Rows[0][MovimientoFondoFijoDetalleCentrosCostoService.VistaCentroCostoNombre_NombreCol] + " ya estaba incluido.");
                        #endregion Validar que no es parte del grupo

                        row = new MOV_FONDO_FIJO_DET_CENT_CRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("MOV_FONDO_FIJO_DET_CC_SQC");
                        row.MOVIMIENTO_FONDO_FIJO_DET_ID = (decimal)campos[MovimientoFondoFijoDetalleCentrosCostoService.MovimientoFondoFijoDetalleId_NombreCol];
                        row.ESTADO = Definiciones.Estado.Activo;
                    }

                    row.CENTRO_COSTO_ID = (decimal)campos[MovimientoFondoFijoDetalleCentrosCostoService.CentroCostoId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[MovimientoFondoFijoDetalleCentrosCostoService.Porcentaje_NombreCol];

                    if (campos.Contains(MovimientoFondoFijoDetalleCentrosCostoService.Id_NombreCol))
                        sesion.db.MOV_FONDO_FIJO_DET_CENT_CCollection.Update(row);
                    else
                        sesion.db.MOV_FONDO_FIJO_DET_CENT_CCollection.Insert(row);

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
                MovimientoFondoFijoDetalleCentrosCostoService.Borrar(factura_cliente_detalle_centro_costo_id, sesion);
            }
        }

        public static void Borrar(decimal movimiento_fondo_fijo_detalle_centro_costo_id, SessionService sesion)
        {
            MOV_FONDO_FIJO_DET_CENT_CRow row = sesion.db.MOV_FONDO_FIJO_DET_CENT_CCollection.GetByPrimaryKey(movimiento_fondo_fijo_detalle_centro_costo_id);
            
            //Para realizar el borrado logico se aguarda a que
            //el detalle de FC Cliente tambien tenga borrado logico
            //row.ESTADO = Definiciones.Estado.Inactivo;
            //sesion.db.FACTURAS_CLIENTE_DET_CENT_CCollection.Update(row);
            sesion.db.MOV_FONDO_FIJO_DET_CENT_CCollection.Delete(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente
        /// <summary>
        /// Distribuirs the porcentajes equitativamente.
        /// </summary>
        /// <param name="factura_proveedor_detalle_id">The factura_proveedor_detalle_id.</param>
        public static void DistribuirPorcentajesEquitativamente(decimal movimiento_fondo_fijo_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                MOV_FONDO_FIJO_DET_CENT_CRow[] rows = sesion.db.MOV_FONDO_FIJO_DET_CENT_CCollection.GetByMOVIMIENTO_FONDO_FIJO_DET_ID(movimiento_fondo_fijo_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.MOV_FONDO_FIJO_DET_CENT_CCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "MOV_FONDO_FIJO_DET_CENT_C"; }
        }
        public static string Nombre_Vista
        {
            get { return "MOV_FONDO_FIJO_DET_CC_INFO_C"; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CENT_CCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CENT_CCollection.ESTADOColumnName; }
        }
        public static string MovimientoFondoFijoDetalleId_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CENT_CCollection.MOVIMIENTO_FONDO_FIJO_DET_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CENT_CCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CENT_CCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCentroCostoAbreviatura_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CC_INFO_CCollection.CENTRO_COSTO_ABREVIATURAColumnName; }
        }
        public static string VistaCentroCostoNombre_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CC_INFO_CCollection.CENTRO_COSTO_NOMBREColumnName; }
        }
        public static string VistaCentroCostoOrden_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CC_INFO_CCollection.CENTRO_COSTO_ORDENColumnName; }
        }
        #endregion Accessors
    }
}
