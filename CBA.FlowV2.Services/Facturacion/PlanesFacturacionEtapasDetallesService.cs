#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class PlanesFacturacionEtapasDetallesService
    {
        #region GetPlanesFacturacionEtapasDetallesDataTable
        /// <summary>
        /// Gets the planes facturacion etapas detalles data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPlanesFacturacionEtapasDetallesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANES_FACTURACION_ETAPAS_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPlanesFacturacionEtapasDetallesDataTable

        #region GetPlanesFacturacionEtapasDetallesInfoCompleta
        /// <summary>
        /// Gets the planes facturacion etapas detalles info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPlanesFacturacionEtapasDetallesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PLANES_FACT_ETAPAS_DET_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPlanesFacturacionEtapasDetallesInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PLANES_FACTURACION_ETAPAS_DETRow row = new PLANES_FACTURACION_ETAPAS_DETRow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    if (!campos.Contains(PlanesFacturacionEtapasDetallesService.Id_NombreCol))
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("planes_facturacion_et_det_sqc");
                        row.PLAN_FACTURACION_ETAPA_ID = (decimal)campos[PlanesFacturacionEtapasDetallesService.PlanFacturacionEtapaId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.PLANES_FACTURACION_ETAPAS_DETCollection.GetByPrimaryKey((decimal)campos[PlanesFacturacionEtapasDetallesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (row.ARTICULO_ID.Equals(DBNull.Value) || row.ARTICULO_ID != (decimal)campos[PlanesFacturacionEtapasDetallesService.ArticuloId_NombreCol])
                    {
                        row.ARTICULO_ID = (decimal)campos[PlanesFacturacionEtapasDetallesService.ArticuloId_NombreCol];
                        if (!ArticulosService.EstaActivo(row.ARTICULO_ID))
                            throw new Exception("El artículo no está activo.");
                    }

                    row.CALCULAR_MONTO = (string)campos[PlanesFacturacionEtapasDetallesService.CalcularMonto_NombreCol];
                    row.CANTIDAD_EMBALADA = (decimal)campos[PlanesFacturacionEtapasDetallesService.CantidadEmbalada_NombreCol];
                    row.CANTIDAD_UNITARIA = (decimal)campos[PlanesFacturacionEtapasDetallesService.CantidadUnitaria_NombreCol];
                    row.MONTO_BRUTO = (decimal)campos[PlanesFacturacionEtapasDetallesService.MontoBruto_NombreCol];
                    row.OBSERVACION = campos[PlanesFacturacionEtapasDetallesService.Observacion_NombreCol].Equals(DBNull.Value) ? string.Empty : (string)campos[PlanesFacturacionEtapasDetallesService.Observacion_NombreCol];
                    row.UNIDAD_MEDIDA_ID = (string)campos[PlanesFacturacionEtapasDetallesService.UnidadMedidaId_NombreCol];

                    //Se agrega un activo
                    if (campos.Contains(PlanesFacturacionEtapasDetallesService.ActivoId_NombreCol))
                        row.ACTIVO_ID = (decimal)campos[PlanesFacturacionEtapasDetallesService.ActivoId_NombreCol];
                    else 
                        row.IsACTIVO_IDNull = true;

                    if (!campos.Contains(PlanesFacturacionEtapasDetallesService.Id_NombreCol)) 
                        sesion.Db.PLANES_FACTURACION_ETAPAS_DETCollection.Insert(row);
                    else 
                        sesion.Db.PLANES_FACTURACION_ETAPAS_DETCollection.Update(row);
                   
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified plan_facturacion_etapa_detalle_id.
        /// </summary>
        /// <param name="plan_facturacion_etapa_detalle_id">The plan_facturacion_etapa_detalle_id.</param>
        public static void Borrar(decimal plan_facturacion_etapa_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    PLANES_FACTURACION_ETAPAS_DETRow row = sesion.Db.PLANES_FACTURACION_ETAPAS_DETCollection.GetByPrimaryKey(plan_facturacion_etapa_detalle_id);

                    sesion.Db.PLANES_FACTURACION_ETAPAS_DETCollection.DeleteByPrimaryKey(plan_facturacion_etapa_detalle_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PLANES_FACTURACION_ETAPAS_DET"; }
        }
        public static string ActivoId_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.ACTIVO_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.ARTICULO_IDColumnName; }
        }
        public static string CalcularMonto_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.CALCULAR_MONTOColumnName; }
        }
        public static string CantidadEmbalada_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.CANTIDAD_EMBALADAColumnName; }
        }
        public static string CantidadUnitaria_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.CANTIDAD_UNITARIAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.IDColumnName; }
        }
        public static string MontoBruto_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.MONTO_BRUTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.OBSERVACIONColumnName; }
        }
        public static string PlanFacturacionEtapaId_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.PLAN_FACTURACION_ETAPA_IDColumnName; }
        }
        public static string UnidadMedidaId_NombreCol
        {
            get { return PLANES_FACTURACION_ETAPAS_DETCollection.UNIDAD_MEDIDA_IDColumnName; }
        }
        public static string VistaActivoCodigo_NombreCol
        {
            get { return PLANES_FACT_ETAPAS_DET_INFO_CCollection.ACTIVO_CODIGOColumnName; }
        }
        public static string VistaArticuloCodigoEmpresa_NombreCol
        {
            get { return PLANES_FACT_ETAPAS_DET_INFO_CCollection.ARTICULO_CODIGO_EMPRESAColumnName; }
        }
        public static string VistaArticuloParaVenta_NombreCol
        {
            get { return PLANES_FACT_ETAPAS_DET_INFO_CCollection.ARTICULO_PARA_VENTAColumnName; }
        }
        public static string VistaArticuloUnidadMedidaId_NombreCol
        {
            get { return PLANES_FACT_ETAPAS_DET_INFO_CCollection.ARTICULO_UNIDAD_MEDIDA_IDColumnName; }
        }
        public static string VistaCantidadPorCaja_NombreCol
        {
            get { return PLANES_FACT_ETAPAS_DET_INFO_CCollection.CANTIDAD_POR_CAJAColumnName; }
        }
        public static string VistaImpuestoId_NombreCol
        {
            get { return PLANES_FACT_ETAPAS_DET_INFO_CCollection.IMPUESTO_IDColumnName; }
        }
        public static string VistaImpuestoNombre_NombreCol
        {
            get { return PLANES_FACT_ETAPAS_DET_INFO_CCollection.IMPUESTO_NOMBREColumnName; }
        }
        public static string VistaImpuestoPorcentaje_NombreCol
        {
            get { return PLANES_FACT_ETAPAS_DET_INFO_CCollection.IMPUESTO_PORCENTAJEColumnName; }
        }
        #endregion Accessors
    }
}
