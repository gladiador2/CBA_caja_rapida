using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Stock
{
    public class UsoDeInsumosDetalleCuentasContableService
    {
        #region Accesors

        #region Tabla
        public static DataTable GetDataTable()
        {
            return GetDataTable(string.Empty);
        }
        public static DataTable GetDataTable(string where)
        {
            return GetDataTable(where, string.Empty);
        }
        public static DataTable GetDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.USO_DE_INSUMOS_DET_CTBCollection.GetAsDataTable(where,orderBy);
            }
        }
        #endregion

        #region Vista
        public static DataTable GetDataTableInfoCompleta()
        {
            return GetDataTableInfoCompleta(string.Empty);
        }
        public static DataTable GetDataTableInfoCompleta(string where)
        {
            return GetDataTableInfoCompleta(where, string.Empty);
        }
        public static DataTable GetDataTableInfoCompleta(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.USO_DE_INSUMOS_DET_CTB_INFO_CCollection.GetAsDataTable(where, orderBy);
            }
        }
        #endregion

        #endregion

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
                    USO_DE_INSUMOS_DET_CTBRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(UsoDeInsumosDetalleCuentasContableService.Id_NombreCol))
                    {
                        row = sesion.db.USO_DE_INSUMOS_DET_CTBCollection.GetByPrimaryKey((decimal)campos[UsoDeInsumosDetalleCuentasContableService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        row = new USO_DE_INSUMOS_DET_CTBRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("uso_de_insumos_det_ctb_sqc");
                        row.USO_DE_INSUMOS_DET_ID = (decimal)campos[UsoDeInsumosDetalleCuentasContableService.UsoDeInsumosDetId_NombreCol];
                    }

                    row.CTB_CUENTA_ID = (decimal)campos[UsoDeInsumosDetalleCuentasContableService.CtbCuentaId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[UsoDeInsumosDetalleCuentasContableService.Porcentaje_NombreCol];

                    if (campos.Contains(UsoDeInsumosDetalleCuentasContableService.Id_NombreCol))
                        sesion.db.USO_DE_INSUMOS_DET_CTBCollection.Update(row);
                    else
                        sesion.db.USO_DE_INSUMOS_DET_CTBCollection.Insert(row);

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
        public static void Borrar(decimal usoDeInsumoDetalleId)
        {
            using (SessionService sesion = new SessionService())
            {
                UsoDeInsumosDetalleCuentasContableService.Borrar(usoDeInsumoDetalleId, sesion);
            }
        }

        public static void Borrar(decimal usoDeInsumoDetalleId, SessionService sesion)
        {
            USO_DE_INSUMOS_DET_CTBRow row = sesion.db.USO_DE_INSUMOS_DET_CTBCollection.GetByPrimaryKey(usoDeInsumoDetalleId);
            sesion.db.USO_DE_INSUMOS_DET_CTBCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente

        public static void DistribuirPorcentajesEquitativamente(decimal usoDeInsumoDetalleId)
        {
            using (SessionService sesion = new SessionService())
            {
                USO_DE_INSUMOS_DET_CTBRow[] rows = sesion.db.USO_DE_INSUMOS_DET_CTBCollection.GetByUSO_DE_INSUMOS_DET_ID(usoDeInsumoDetalleId);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.USO_DE_INSUMOS_DET_CTBCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "uso_de_insumos_det_ctb"; }
        }
        public static string Id_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTBCollection.IDColumnName; }
        }
        public static string UsoDeInsumosDetId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTBCollection.USO_DE_INSUMOS_DET_IDColumnName; }
        }
        public static string CtbCuentaId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTBCollection.CTB_CUENTA_IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTBCollection.PORCENTAJEColumnName; }
        }
        #endregion

        #region Vista
        public static string Nombre_Vista
        {
            get { return "uso_de_insumos_det_ctb_info_c"; }
        }
        public static string VistaId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTB_INFO_CCollection.IDColumnName; }
        }
        public static string VistaCtbCuentaId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTB_INFO_CCollection.CTB_CUENTA_IDColumnName; }
        }
        public static string VistaCtbCuentaNombre_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTB_INFO_CCollection.CTB_CUENTA_NOMBREColumnName; }
        }
        public static string VistaCtbCuentaCodigoCompleto_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTB_INFO_CCollection.CTB_CUENTA_CODIGO_COMPLETOColumnName ; }
        }
        public static string VistaCtbPlanCuentaId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_IDColumnName; }
        }
        public static string VistaPlanCtbCuentaNombre_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTB_INFO_CCollection.CTB_PLAN_CUENTA_NOMBREColumnName; }
        }
        public static string VistaPorcentaje_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CTB_INFO_CCollection.PORCENTAJEColumnName; }
        }
        #endregion

        #endregion Accessors
    }
}
