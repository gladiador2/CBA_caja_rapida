#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Presupuestos
{
    public class PresupuestosDetalleService
    {
        #region GetPresupuestosDetalleDataTable
        /// <summary>
        /// Gets the presupuestos detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPresupuestosDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRESUPUESTOS_DETALLECollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPresupuestosDetalleDataTable

        #region GetPresupuestosDetalleInfoCompleta
        /// <summary>
        /// Gets the presupuestos detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPresupuestosDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PRESUPUESTOS_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetPresupuestosDetalleInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PRESUPUESTOS_DETALLERow row = new PRESUPUESTOS_DETALLERow();
                    string valorAnterior = Definiciones.Log.RegistroNuevo;

                    if (!campos.Contains(PresupuestosDetalleService.Id_NombreCol))
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("PRESUPUESTOS_DETALLE_SQC");
                        row.PRESUPUESTO_ETAPA_ID = (decimal)campos[PresupuestosDetalleService.PresupuestoEtapaId_NombreCol];
                        row.CANTIDAD_UNITARIA_FACTURADA = 0;
                    }
                    else
                    {
                        row = sesion.Db.PRESUPUESTOS_DETALLECollection.GetByPrimaryKey((decimal)campos[PresupuestosDetalleService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.OBSERVACION = (string)campos[PresupuestosDetalleService.Observacion_NombreCol];
                    row.UNIDAD_MEDIDA = (string)campos[PresupuestosDetalleService.UnidadMedida_NombreCol];
                    row.CANTIDAD_POR_CAJA = (decimal)campos[PresupuestosDetalleService.CantidadPorCaja_NombreCol];
                    row.CANTIDAD_CAJAS = (decimal)campos[PresupuestosDetalleService.CantidadCajas_NombreCol];
                    row.CANTIDAD_UNIDADES = (decimal)campos[PresupuestosDetalleService.CantidadUnidades_NombreCol];
                    row.CANTIDAD_UNITARIA_TOTAL = row.CANTIDAD_UNIDADES + row.CANTIDAD_POR_CAJA * row.CANTIDAD_CAJAS;
                    row.MONTO_BRUTO_UNITARIO = (decimal)campos[PresupuestosDetalleService.MontoBrutoUnitario_NombreCol];
                    row.IMPUESTO_ID = (decimal)campos[PresupuestosDetalleService.ImpuestoId_NombreCol];
                    row.PORCENTAJE_IMPUESTO = ImpuestosService.GetPorcentajePorId(row.IMPUESTO_ID);
                    row.PORCENTAJE_DESC = (decimal)campos[PresupuestosDetalleService.PorcentajeDesc_NombreCol];
                    row.MONTO_DESCUENTO = row.MONTO_BRUTO_UNITARIO * row.PORCENTAJE_DESC / 100;

                    //Verificar que el porcentaje de impuesto no sea 0
                    if (row.PORCENTAJE_IMPUESTO == 0)
                    {
                        row.MONTO_IMPUESTO = row.MONTO_BRUTO_UNITARIO - row.MONTO_DESCUENTO;
                    }
                    else
                    {
                        row.MONTO_IMPUESTO = (row.MONTO_BRUTO_UNITARIO - row.MONTO_DESCUENTO) / ((100 / row.PORCENTAJE_IMPUESTO) + 1);
                    }

                    row.MONTO_NETO_UNITARIO = row.MONTO_BRUTO_UNITARIO - row.MONTO_DESCUENTO - row.MONTO_IMPUESTO;

                    if (campos.Contains(PresupuestosDetalleService.ArticuloId_NombreCol))
                    {
                        if (row.IsARTICULO_IDNull || row.ARTICULO_ID != (decimal)campos[PresupuestosDetalleService.ArticuloId_NombreCol])
                        {
                            row.ARTICULO_ID = (decimal)campos[PresupuestosDetalleService.ArticuloId_NombreCol];
                            if (!ArticulosService.EstaActivo((decimal)campos[PresupuestosDetalleService.ArticuloId_NombreCol]))
                                throw new Exception("El artículo no está activo.");
                        }
                    }
                    else
                    {
                        row.IsARTICULO_IDNull = true;
                    }

                    if (campos.Contains(PresupuestosDetalleService.ActivoId_NombreCol))
                        row.ACTIVO_ID = (decimal)campos[PresupuestosDetalleService.ActivoId_NombreCol];
                    else
                        row.IsACTIVO_IDNull = true;

                    if (!campos.Contains(PresupuestosDetalleService.Id_NombreCol)) 
                        sesion.Db.PRESUPUESTOS_DETALLECollection.Insert(row);
                    else 
                        sesion.Db.PRESUPUESTOS_DETALLECollection.Update(row);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();

                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region ActualizarMontoArticulo
        static public void ActualizarMontoArticulo(decimal presupuesto_etapa_id, decimal articulo_id, decimal monto)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    string clausula = PresupuestosDetalleService.PresupuestoEtapaId_NombreCol + " = " + presupuesto_etapa_id + " and " +
                                      PresupuestosDetalleService.ArticuloId_NombreCol + " = " + articulo_id;
                    
                    PRESUPUESTOS_DETALLERow[] rows = sesion.Db.PRESUPUESTOS_DETALLECollection.GetAsArray(clausula, string.Empty);

                    foreach (var r in rows)
                    {
                        string valorAnterior = r.ToString();

                        r.MONTO_BRUTO_UNITARIO = monto;
                        r.MONTO_DESCUENTO = r.MONTO_BRUTO_UNITARIO * r.PORCENTAJE_DESC / 100;
                        //Verificar que el porcentaje de impuesto no sea 0
                        if (r.PORCENTAJE_IMPUESTO == 0)
                        {
                            r.MONTO_IMPUESTO = r.MONTO_BRUTO_UNITARIO - r.MONTO_DESCUENTO;
                        }
                        else
                        {
                            r.MONTO_IMPUESTO = (r.MONTO_BRUTO_UNITARIO - r.MONTO_DESCUENTO) / ((100 / r.PORCENTAJE_IMPUESTO) + 1);
                        }

                        r.MONTO_NETO_UNITARIO = r.MONTO_BRUTO_UNITARIO - r.MONTO_DESCUENTO - r.MONTO_IMPUESTO;
                        sesion.Db.PRESUPUESTOS_DETALLECollection.Update(r);

                        LogCambiosService.LogDeRegistro(Nombre_Tabla, r.ID, valorAnterior, r.ToString(), sesion);
                    }

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion

        #region Borrar
        /// <summary>
        /// Borrars the specified presupuesto_detalle_id.
        /// </summary>
        /// <param name="presupuesto_detalle_id">The presupuesto_detalle_id.</param>
        public static void Borrar(decimal presupuesto_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    PRESUPUESTOS_DETALLERow row = sesion.Db.PRESUPUESTOS_DETALLECollection.GetByPrimaryKey(presupuesto_detalle_id);

                    DataTable dt = PresupuestosDetalleCasosService.GetPresupuestosDetalleCasosDataTable(PresupuestosDetalleCasosService.PresupuestoDetalleId_NombreCol + " = " + row.ID, string.Empty);

                    //Se borran todos los casos asociados
                    for (int i = 0; i < dt.Rows.Count; i++)
                        PresupuestosDetalleCasosService.Borrar((decimal)dt.Rows[i][PresupuestosDetalleCasosService.Id_NombreCol]);

                    sesion.Db.PRESUPUESTOS_DETALLECollection.DeleteByPrimaryKey(presupuesto_detalle_id);
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
            get { return "PRESUPUESTOS_DETALLE"; }
        }
        public static string ActivoId_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.ACTIVO_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.ARTICULO_IDColumnName; }
        }
        public static string CantidadCajas_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.CANTIDAD_CAJASColumnName; }
        }
        public static string CantidadPorCaja_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.CANTIDAD_POR_CAJAColumnName; }
        }
        public static string CantidadUnidades_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.CANTIDAD_UNIDADESColumnName; }
        }
        public static string CantidadUnitariaFacturada_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.CANTIDAD_UNITARIA_FACTURADAColumnName; }
        }
        public static string CantidadUnitariaTotal_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.CANTIDAD_UNITARIA_TOTALColumnName; }
        }
        public static string CostoId_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.COSTO_IDColumnName; }
        }
        public static string CostoMonedaCotizacion_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.COSTO_MONEDA_COTIZACIONColumnName; }
        }
        public static string CostoMonedaId_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.COSTO_MONEDA_IDColumnName; }
        }
        public static string CostoMonto_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.COSTO_MONTOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.IMPUESTO_IDColumnName; }
        }
        public static string MontoBrutoUnitario_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.MONTO_BRUTO_UNITARIOColumnName; }
        }
        public static string MontoDescuento_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.MONTO_DESCUENTOColumnName; }
        }
        public static string MontoImpuesto_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.MONTO_IMPUESTOColumnName; }
        }
        public static string MontoNetoUnitario_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.MONTO_NETO_UNITARIOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.OBSERVACIONColumnName; }
        }
        public static string PorcentajeDesc_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.PORCENTAJE_DESCColumnName; }
        }
        public static string PorcentajeImpuesto_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.PORCENTAJE_IMPUESTOColumnName; }
        }
        public static string PresupuestoEtapaId_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.PRESUPUESTO_ETAPA_IDColumnName; }
        }
        public static string UnidadMedida_NombreCol
        {
            get { return PRESUPUESTOS_DETALLECollection.UNIDAD_MEDIDAColumnName; }
        }
        public static string VistaActivoCodigo_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ACTIVO_CODIGOColumnName; }
        }
        public static string VistaArticuloCodigoEmpresa_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_COD_EMPRESAColumnName; }
        }
        public static string VistaArticuloDescInterna_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_DESC_INTERNAColumnName; }
        }
        public static string VistaArticuloFamiliaDesc_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_FAMILIA_DESCColumnName; }
        }
        public static string VistaArticuloFamiliaId_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string VistaArticuloGrupoDesc_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_GRUPO_DESCColumnName; }
        }
        public static string VistaArticuloGrupoId_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_GRUPO_IDColumnName; }
        }
        public static string VistaArticuloSubgrupoDesc_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_SUBGRUPO_DESCColumnName; }
        }
        public static string VistaArticuloCantidadPorCaja_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_CANTIDAD_POR_CAJAColumnName; }
        }
        public static string VistaArticuloUnidadMedidaId_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_UNIDAD_MED_IDColumnName; }
        }
        public static string VistaArticuloUnidadMedidaDesc_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_UNIDAD_MED_DESCColumnName; }
        }
        public static string VistaArticuloSubgrupoId_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.ARTICULO_SUBGRUPO_IDColumnName; }
        }
        public static string VistaImpuestoNombre_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.IMPUESTO_NOMBREColumnName; }
        }
        public static string VistaImpuestoPorcentaje_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.IMPUESTO_PORCENTAJEColumnName; }
        }
        public static string VistaMontoBrutoDescontadoTotal_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.MONTO_BRUTO_DESCONTADO_TOTALColumnName; }
        }
        public static string VistaPresupuestoEtapaNombre_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.PRESUPUESTO_ETAPA_NOMBREColumnName; }
        }
        public static string VistaPresupuestoId_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.PRESUPUESTO_IDColumnName; }
        }
        public static string VistaPresupuestoObjeto_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.PRESUPUESTO_OBJETOColumnName; }
        }
        public static string VistaUnidadMedidaDescripcion_NombreCol
        {
            get { return PRESUPUESTOS_DET_INFO_COMPLETACollection.UNIDAD_MEDIDA_DESCRIPCIONColumnName; }
        }
        #endregion Accessors
    }
}
