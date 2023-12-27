using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Stock
{
    public class UsoDeInsumosDetalleCentroCostoService
    {
        #region Getters
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
                if (where != string.Empty)
                    where += " and ";
                where += UsoDeInsumosDetalleCentroCostoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                return sesion.db.USO_DE_INSUMOS_DET_CENT_CCollection.GetAsDataTable(where,orderBy);
            }
        }

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
                if (where != string.Empty)
                    where += " and ";
                where += UsoDeInsumosDetalleCentroCostoService.VistaEstado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                return sesion.db.USO_DE_INSUMOS_DET_CC_INFO_CCollection.GetAsDataTable(where, orderBy);
            }
        }
        #endregion

        #region DistribuirPorcentajesEquitativamente
        /// <summary>
        /// Distribuirs the porcentajes equitativamente.
        /// </summary>
        /// <param name="factura_proveedor_detalle_id">The factura_proveedor_detalle_id.</param>
        public static void DistribuirPorcentajesEquitativamente(decimal usoDeInsumosDetalleId)
        {
            using (SessionService sesion = new SessionService())
            {
                USO_DE_INSUMOS_DET_CENT_CRow[] rows = sesion.db.USO_DE_INSUMOS_DET_CENT_CCollection.GetByUSO_DE_INSUMOS_DET_ID(usoDeInsumosDetalleId);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.USO_DE_INSUMOS_DET_CENT_CCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente

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
                    USO_DE_INSUMOS_DET_CENT_CRow row;
                    string valorAnterior = string.Empty;

                    if (campos.Contains(UsoDeInsumosDetalleCentroCostoService.Id_NombreCol))
                    {
                        row = sesion.db.USO_DE_INSUMOS_DET_CENT_CCollection.GetByPrimaryKey((decimal)campos[UsoDeInsumosDetalleCentroCostoService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        #region Validar que no fue agregado anteriormente
                        string where = UsoDeInsumosDetallesId_NombreCol + "=" + campos[UsoDeInsumosDetallesId_NombreCol].ToString() + " and " +
                                       CentroDeCostoId_NombreCol + " = " + campos[CentroDeCostoId_NombreCol].ToString();

                        DataTable dt = GetDataTableInfoCompleta(where,string.Empty);

                        if (dt.Rows.Count > 0)
                            throw new Exception("El centro de costo " + dt.Rows[0][VistaCentroDeCostoNombre_NombreCol] + " ya estaba incluido.");
                        #endregion Validar que no es parte del grupo

                        row = new USO_DE_INSUMOS_DET_CENT_CRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.db.GetSiguienteSecuencia("uso_de_insumos_det_cc_sqc");
                        row.USO_DE_INSUMOS_DET_ID = (decimal)campos[UsoDeInsumosDetallesId_NombreCol];
                        row.ESTADO = Definiciones.Estado.Activo;
                    }

                    row.CENTRO_COSTO_ID = (decimal)campos[CentroDeCostoId_NombreCol];
                    row.PORCENTAJE = (decimal)campos[Porcentaje_NombreCol];

                    if (campos.Contains(Id_NombreCol))
                        sesion.db.USO_DE_INSUMOS_DET_CENT_CCollection.Update(row);
                    else
                        sesion.db.USO_DE_INSUMOS_DET_CENT_CCollection.Insert(row);

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
                UsoDeInsumosDetalleCentroCostoService.Borrar(usoDeInsumoDetalleId, sesion);
            }
        }

        public static void Borrar(decimal usoDeInsumoDetalleId, SessionService sesion)
        {
            USO_DE_INSUMOS_DET_CENT_CRow row = sesion.db.USO_DE_INSUMOS_DET_CENT_CCollection.GetByPrimaryKey(usoDeInsumoDetalleId);

            sesion.db.USO_DE_INSUMOS_DET_CENT_CCollection.Delete(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region Accesors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "USO_DE_INSUMOS_DET_CENT_C"; }
        }
        public static string Id_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CENT_CCollection.IDColumnName; }
        }
        public static string UsoDeInsumosDetallesId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CENT_CCollection.USO_DE_INSUMOS_DET_IDColumnName; }
        }
        public static string CentroDeCostoId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CENT_CCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CENT_CCollection.ESTADOColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CENT_CCollection.PORCENTAJEColumnName; }
        }
        #endregion

        #region Vista
        public static string Nombre_Vista
        {
            get { return "uso_de_insumos_det_cc_info_c"; }
        }
        public static string VistaId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CC_INFO_CCollection.IDColumnName; }
        }
        public static string VistaUsoDeInsumoDetalleId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CC_INFO_CCollection.USO_DE_INSUMOS_DET_IDColumnName; }
        }
        public static string VistaCentroDeCosto_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CC_INFO_CCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string VistaCentroDeCostoNombre_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CC_INFO_CCollection.CENTRO_COSTO_NOMBREColumnName; }
        }
        public static string VistaCentroDeCostoAbreviatura_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CC_INFO_CCollection.CENTRO_COSTO_ABREVIATURAColumnName; }
        }
        public static string VistaCentroCostoOrden_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CC_INFO_CCollection.CENTRO_COSTO_ORDENColumnName; }
        }
        public static string VistaPorcentaje_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CC_INFO_CCollection.PORCENTAJEColumnName; }
        }
        public static string VistaEstado_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_CC_INFO_CCollection.ESTADOColumnName; }
        }
        #endregion

        #endregion
    }
}
