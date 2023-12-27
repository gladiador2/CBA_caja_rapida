#region using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Facturacion;
using System.Collections;

#endregion using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class AsientosDetalleCentrosCostoService
    {
        #region GetAsientosDetalleCentrosCostoDataTable
        public static DataTable GetAsientosDetalleCentrosCostoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAsientosDetalleCentrosCostoDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetAsientosDetalleCentrosCostoDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTB_ASIENTOS_DETALLE_CENT_COSTCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAsientosDetalleCentrosCostoDataTable

        #region GetAsientosDetalleCentrosCostoInfoCompleta
        /// <summary>
        /// Gets the asientos detalle centros costo information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosDetalleCentrosCostoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_ASIENTOS_DET_CENT_C_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetAsientosDetalleCentrosCostoInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                Guardar(campos, sesion);
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                CTB_ASIENTOS_DETALLE_CENT_COSTRow row;
                string valorAnterior = string.Empty;

                #region recursividad para convertir grupos de centros de costo a su desglose
                if (CentrosCostoService.EsGrupo((decimal)campos[AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol], sesion))
                {
                    DataTable dtCentroCosto = CentrosCostoService.GetCentrosCostoDataTable(CentrosCostoService.Id_NombreCol + " = " + campos[AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol], string.Empty, sesion);
                    DataTable dtGrupoDet = CentrosCostoGruposDetalleService.GetCentrosCostoGruposDetalleDataTable(CentrosCostoGruposDetalleService.CentroCostoGrupoId_NombreCol + " = " + dtCentroCosto.Rows[0][CentrosCostoService.CentroCostoGrupoId_NombreCol], CentrosCostoGruposDetalleService.Id_NombreCol, sesion);
                    for (int i = 0; i < dtGrupoDet.Rows.Count; i++)
                    {
                        Hashtable ht = (Hashtable)campos.Clone();
                        ht[AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol] = dtGrupoDet.Rows[i][CentrosCostoGruposDetalleService.CentroCostoId_NombreCol];
                        ht[AsientosDetalleCentrosCostoService.Porcentaje_NombreCol] = (decimal)campos[AsientosDetalleCentrosCostoService.Porcentaje_NombreCol] * (decimal)dtGrupoDet.Rows[i][CentrosCostoGruposDetalleService.Porcentaje_NombreCol] / 100;
                        Guardar(ht, sesion);
                    }
                    return;
                }
                #endregion recursividad para convertir grupos de centros de costo a su desglose

                if (campos.Contains(AsientosDetalleCentrosCostoService.Id_NombreCol))
                {
                    row = sesion.db.CTB_ASIENTOS_DETALLE_CENT_COSTCollection.GetByPrimaryKey((decimal)campos[AsientosDetalleCentrosCostoService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }
                else
                {
                    row = new CTB_ASIENTOS_DETALLE_CENT_COSTRow();
                    valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.db.GetSiguienteSecuencia("ctb_asientos_detalle_cen_c_sqc");
                    row.CTB_ASIENTO_DETALLE_ID = (decimal)campos[AsientosDetalleCentrosCostoService.CtbAsientoDetalleId_NombreCol];

                    if (campos.Contains(AsientosDetalleCentrosCostoService.FacturaProvDetCentCId_NombreCol))
                        row.FACTURA_PROV_DET_CENT_C_ID = (decimal)campos[AsientosDetalleCentrosCostoService.FacturaProvDetCentCId_NombreCol];
                }

                row.CENTRO_COSTO_ID = (decimal)campos[AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol];
                row.PORCENTAJE = decimal.Parse(campos[AsientosDetalleCentrosCostoService.Porcentaje_NombreCol].ToString());

                if (campos.Contains(FacturasProveedorDetalleCentrosCostoService.Id_NombreCol))
                    sesion.db.CTB_ASIENTOS_DETALLE_CENT_COSTCollection.Update(row);
                else
                    sesion.db.CTB_ASIENTOS_DETALLE_CENT_COSTCollection.Insert(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified factura_proveedor_detalle_cuenta_id.
        /// </summary>
        /// <param name="ctb_asiento_detalle_centro_costo_id">The ctb_asiento_detalle_centro_costo_id.</param>
        public static void Borrar(decimal ctb_asiento_detalle_centro_costo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                AsientosDetalleCentrosCostoService.Borrar(ctb_asiento_detalle_centro_costo_id, sesion);
            }
        }

        /// <summary>
        /// Borrars the specified factura_proveedor_detalle_cuenta_id.
        /// </summary>
        /// <param name="ctb_asiento_detalle_centro_costo_id">The ctb_asiento_detalle_centro_costo_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal ctb_asiento_detalle_centro_costo_id, SessionService sesion)
        {
            CTB_ASIENTOS_DETALLE_CENT_COSTRow row = sesion.db.CTB_ASIENTOS_DETALLE_CENT_COSTCollection.GetByPrimaryKey(ctb_asiento_detalle_centro_costo_id);
            sesion.db.CTB_ASIENTOS_DETALLE_CENT_COSTCollection.Delete(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
        }
        #endregion Borrar

        #region DistribuirPorcentajesEquitativamente
        /// <summary>
        /// Distribuirs the porcentajes equitativamente.
        /// </summary>
        /// <param name="ctb_asiento_detalle_id">The ctb_asiento_detalle_id.</param>
        public static void DistribuirPorcentajesEquitativamente(decimal ctb_asiento_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_ASIENTOS_DETALLE_CENT_COSTRow[] rows = sesion.db.CTB_ASIENTOS_DETALLE_CENT_COSTCollection.GetByCTB_ASIENTO_DETALLE_ID(ctb_asiento_detalle_id);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].PORCENTAJE = (decimal)100 / rows.Length;
                    sesion.db.CTB_ASIENTOS_DETALLE_CENT_COSTCollection.Update(rows[i]);
                }
            }
        }
        #endregion DistribuirPorcentajesEquitativamente
        
        #region Crear
        public static void Crear(decimal ctb_asiento_detalle_id, Hashtable centros_costo, SessionService sesion)
        {
            if (centros_costo != null && centros_costo.Count > 0)
            {
                System.Collections.Hashtable campos;
                foreach (DictionaryEntry pair in centros_costo)
                {
                    campos = new System.Collections.Hashtable();
                    campos.Add(AsientosDetalleCentrosCostoService.CentroCostoId_NombreCol, pair.Key);
                    campos.Add(AsientosDetalleCentrosCostoService.CtbAsientoDetalleId_NombreCol, ctb_asiento_detalle_id);
                    campos.Add(AsientosDetalleCentrosCostoService.Porcentaje_NombreCol, pair.Value);
                    AsientosDetalleCentrosCostoService.Guardar(campos, sesion);
                }
            }
        }
        #endregion Crear

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTB_ASIENTOS_DETALLE_CENT_COST"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTB_ASIENTOS_DET_CENT_C_INFO_C"; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_CENT_COSTCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string CtbAsientoDetalleId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_CENT_COSTCollection.CTB_ASIENTO_DETALLE_IDColumnName; }
        }
        public static string FacturaProvDetCentCId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_CENT_COSTCollection.FACTURA_PROV_DET_CENT_C_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_CENT_COSTCollection.IDColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_CENT_COSTCollection.PORCENTAJEColumnName; }
        }
        public static string VistaCentroCostoAbreviatura_NombreCol
        {
            get { return CTB_ASIENTOS_DET_CENT_C_INFO_CCollection_Base.CENTRO_COSTO_ABREVIATURAColumnName; }
        }
        public static string VistaCentroCostoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_DET_CENT_C_INFO_CCollection_Base.CENTRO_COSTO_NOMBREColumnName; }
        }
        public static string VistaCtbAsientoDetalleObserv_NombreCol
        {
            get { return CTB_ASIENTOS_DET_CENT_C_INFO_CCollection_Base.CTB_ASIENTO_DETALLE_OBSERVColumnName; }
        }
        public static string VistaCentroCostoOrden_NombreCol
        {
            get { return CTB_ASIENTOS_DET_CENT_C_INFO_CCollection_Base.CENTRO_COSTO_ORDENColumnName; }
        }
        #endregion Accessors
    }
}
