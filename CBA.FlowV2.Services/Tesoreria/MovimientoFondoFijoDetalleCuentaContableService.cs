#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class MovimientoFondoFijoDetalleCuentaContableService
    {
        #region GetMovimientoFondoFijoDetalleCuentaContableDataTable

        public static DataTable GetMovimientoFondoFijoDetalleCuentaContableDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMovimientoFondoFijoDetalleCuentaContableDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetMovimientoFondoFijoDetalleCuentaContableDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.MOV_FONDO_FIJO_DET_CTBCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetMovimientoFondoFijoDetalleCuentaContableDataTable

        #region GetMovimientoFondoFijoDetalleCuentaContableInfoCompleta

        public static DataTable GetMovimientoFondoFijoDetalleCuentaContableInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMovimientoFondoFijoDetalleCuentaContableInfoCompleta(clausulas,orden,sesion);
            }
        }
        public static DataTable GetMovimientoFondoFijoDetalleCuentaContableInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            
                return sesion.Db.MOV_FONDO_FIJO_DET_CTB_INFO_CCollection.GetAsDataTable(clausulas, orden);
            
        }
        #endregion MovimientoFondoFijoDetalleCuentaContableInfoCompleta

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
                    MOV_FONDO_FIJO_DET_CTBRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(MovimientoFondoFijoDetalleCuentaContableService.Id_NombreCol))
                    {
                        row = sesion.db.MOV_FONDO_FIJO_DET_CTBCollection.GetByPrimaryKey((decimal)campos[MovimientoFondoFijoDetalleCuentaContableService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        row = new MOV_FONDO_FIJO_DET_CTBRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("MOV_FONDO_FIJO_DET_CTB_SQC");
                        row.MOVIMIENTO_FONDO_FIJO_DET_ID = (decimal)campos[MovimientoFondoFijoDetalleCuentaContableService.MovimientoFondoFijoDetalleId_NombreCol];
                    }

                    row.CTB_CUENTA_ID = (decimal)campos[MovimientoFondoFijoDetalleCuentaContableService.CtbCuentaId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[MovimientoFondoFijoDetalleCuentaContableService.Porcentaje_NombreCol];

                    if (campos.Contains(MovimientoFondoFijoDetalleCuentaContableService.Id_NombreCol))
                        sesion.db.MOV_FONDO_FIJO_DET_CTBCollection.Update(row);
                    else
                        sesion.db.MOV_FONDO_FIJO_DET_CTBCollection.Insert(row);

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
        /// <summary>
        /// Borrars the specified factura_proveedor_detalle_cuenta_id.
        /// </summary>
        /// <param name="factura_proveedor_detalle_cuenta_id">The factura_proveedor_detalle_cuenta_id.</param>
        public static void Borrar(decimal factura_proveedor_detalle_cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                MovimientoFondoFijoDetalleCuentaContableService.Borrar(factura_proveedor_detalle_cuenta_id, sesion);
            }
        }

       
        public static void Borrar(decimal movimiento_fondo_fijo_detalle_cuenta_id, SessionService sesion)
        {
            MOV_FONDO_FIJO_DET_CTBRow row = sesion.db.MOV_FONDO_FIJO_DET_CTBCollection.GetByPrimaryKey(movimiento_fondo_fijo_detalle_cuenta_id);
            sesion.db.MOV_FONDO_FIJO_DET_CTBCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente
        
        public static void DistribuirPorcentajesEquitativamente(decimal movimiento_fondo_fijo_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                MOV_FONDO_FIJO_DET_CTBRow[] rows = sesion.db.MOV_FONDO_FIJO_DET_CTBCollection.GetByMOVIMIENTO_FONDO_FIJO_DET_ID(movimiento_fondo_fijo_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.MOV_FONDO_FIJO_DET_CTBCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "MOV_FONDO_FIJO_DET_CTB"; }
        }
        public static string CtbCuentaId_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CTBCollection.CTB_CUENTA_IDColumnName; }
        }
        public static string MovimientoFondoFijoDetalleId_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CTBCollection.MOVIMIENTO_FONDO_FIJO_DET_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CTBCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CTBCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCtbCuentaCodigoCompleto_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CTB_INFO_CCollection.CTB_CUENTA_CODIGO_COMPLETOColumnName; }
        }
        public static string VistaCtbCuentaNombre_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CTB_INFO_CCollection.CTB_CUENTA_NOMBREColumnName; }
        }
        public static string VistaCtbPlanCuentaId_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_IDColumnName; }
        }
        public static string VistaCtbPlanCuentaNombre_NombreCol
        {
            get { return MOV_FONDO_FIJO_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
