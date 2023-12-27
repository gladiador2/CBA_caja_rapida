#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion using

namespace CBA.FlowV2.Services.Herramientas
{
    public class PagosContratistasDetalleCuentaContableService
    {
        #region CuentaContableDataTable
        public static DataTable GetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaContableDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaContableDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.PAGO_CONTRATISTAS_DET_CTBCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion 

        #region CuentaContableInfoCompleta
  
        public static DataTable GetCuentaContableInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PAGO_CONTRATISTAS_DET_CTBCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion 

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    PAGO_CONTRATISTAS_DET_CTBRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(PagosContratistasDetalleCuentaContableService.Id_NombreCol))
                    {
                        row = sesion.db.PAGO_CONTRATISTAS_DET_CTBCollection.GetByPrimaryKey((decimal)campos[PagosContratistasDetalleCuentaContableService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        row = new PAGO_CONTRATISTAS_DET_CTBRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("pago_contrat_det_ctb_sqc");
                        row.PAGO_CONTRATISTAS_DET_ID = (decimal)campos[PagosContratistasDetalleCuentaContableService.PagoContratistasDetalleId_NombreCol];
                    }

                    row.CTB_CUENTA_ID = (decimal)campos[PagosContratistasDetalleCuentaContableService.CtbCuentaId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[PagosContratistasDetalleCuentaContableService.Porcentaje_NombreCol];

                    if (campos.Contains(PagosContratistasDetalleCuentaContableService.Id_NombreCol))
                        sesion.db.PAGO_CONTRATISTAS_DET_CTBCollection.Update(row);
                    else
                        sesion.db.PAGO_CONTRATISTAS_DET_CTBCollection.Insert(row);

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
        public static void Borrar(decimal pago_contratistas_detalle_cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PagosContratistasDetalleCuentaContableService.Borrar(pago_contratistas_detalle_cuenta_id, sesion);
            }
        }

        public static void Borrar(decimal pago_contratistas_detalle_cuenta_id, decimal pago_contratistas_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PagosContratistasDetalleCuentaContableService.Borrar(pago_contratistas_detalle_cuenta_id, pago_contratistas_detalle_id, sesion);
            }
        }

        public static void Borrar(decimal pago_contratistas_detalle_cuenta_id, SessionService sesion)
        {
            PAGO_CONTRATISTAS_DET_CTBRow row = sesion.db.PAGO_CONTRATISTAS_DET_CTBCollection.GetByPrimaryKey(pago_contratistas_detalle_cuenta_id);
            sesion.db.PAGO_CONTRATISTAS_DET_CTBCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }

        public static void Borrar(decimal pago_contratistas_detalle_cuenta_id, decimal pago_contratistas_detalle_id, SessionService sesion)
        {
            PAGO_CONTRATISTAS_DET_CTBRow row = sesion.db.PAGO_CONTRATISTAS_DET_CTBCollection.GetRow(PagosContratistasDetalleCuentaContableService.PagoContratistasDetalleId_NombreCol + " = " + pago_contratistas_detalle_id + " and " + PagosContratistasDetalleCuentaContableService.CtbCuentaId_NombreCol + " = " + pago_contratistas_detalle_cuenta_id);
            sesion.db.PAGO_CONTRATISTAS_DET_CTBCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente
        public static void DistribuirPorcentajesEquitativamente(decimal pago_contratistas_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PAGO_CONTRATISTAS_DET_CTBRow[] rows = sesion.db.PAGO_CONTRATISTAS_DET_CTBCollection.GetByPAGO_CONTRATISTAS_DET_ID(pago_contratistas_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.PAGO_CONTRATISTAS_DET_CTBCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PAGO_CONTRATISTAS_DET_CTB"; }
        }
        public static string CtbCuentaId_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DET_CTBCollection.CTB_CUENTA_IDColumnName; }
        }
        public static string PagoContratistasDetalleId_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DET_CTBCollection.PAGO_CONTRATISTAS_DET_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DET_CTBCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DET_CTBCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCtbCuentaCodigoCompleto_NombreCol
        {
            get { return PAGO_CONTRAT_DET_CTB_INFO_CCollection.CTB_CUENTA_CODIGO_COMPLETOColumnName; }
        }
        public static string VistaCtbCuentaNombre_NombreCol
        {
            get { return PAGO_CONTRAT_DET_CTB_INFO_CCollection.CTB_CUENTA_NOMBREColumnName; }
        }
        public static string VistaCtbPlanCuentaId_NombreCol
        {
            get { return PAGO_CONTRAT_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_IDColumnName; }
        }
        public static string VistaCtbPlanCuentaNombre_NombreCol
        {
            get { return PAGO_CONTRAT_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
