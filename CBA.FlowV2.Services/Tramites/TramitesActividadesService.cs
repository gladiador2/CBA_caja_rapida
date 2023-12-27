#region Using
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Tramites;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Service.Tramites
{
    public class TramitesActividadesService
    {
        #region GetDatatable
        public static DataTable GetTramitesActividadesDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_ACTIVIDADESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetDatatable

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    
                    TRAMITES_ACTIVIDADESRow row = new TRAMITES_ACTIVIDADESRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("tramites_actividades_sqc");
                        row.TRAMITE_ID = (decimal)campos[TramitesActividadesService.TramiteId_NombreCol];
                        row.FINALIZADO = Definiciones.SiNo.No;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_ACTIVIDADESCollection.GetByPrimaryKey(decimal.Parse(campos[TramitesActividadesService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.FINALIZADO = (string)campos[TramitesActividadesService.Finalizado_NombreCol];

                    if (campos.Contains(TramitesActividadesService.Descripcion_NombreCol))
                        row.DESCRIPCION = campos[TramitesActividadesService.Descripcion_NombreCol].ToString();

                    if (campos.Contains(TramitesActividadesService.CantidadHoras_NombreCol))
                        row.CANTIDAD_HORAS = (decimal)campos[TramitesActividadesService.CantidadHoras_NombreCol];
                    else
                        row.IsCANTIDAD_HORASNull = true;

                    if (campos.Contains(TramitesActividadesService.CantidadUnidades_NombreCol))
                        row.CANTIDAD_UNIDADES = (decimal)campos[TramitesActividadesService.CantidadUnidades_NombreCol];
                    else
                        row.IsCANTIDAD_UNIDADESNull = true;

                    if (!Interprete.EsNullODBNull(campos[TramitesActividadesService.FuncionarioId_NombreCol]))
                        row.FUNCIONARIO_ID = (decimal)campos[TramitesActividadesService.FuncionarioId_NombreCol];
                    else
                        row.IsFUNCIONARIO_IDNull = true;

                    if (row.IsMONEDA_IDNull || row.MONEDA_ID != (decimal)campos[TramitesActividadesService.MonedaId_NombreCol])
                    {
                        if (MonedasService.EstaActivo((decimal)campos[TramitesActividadesService.MonedaId_NombreCol]))
                        {
                            row.MONEDA_ID = (decimal)campos[TramitesActividadesService.MonedaId_NombreCol];
                            DataTable dt = TramitesService.GetTramitesDataTable(TramitesService.Id_NombreCol + " = " + row.TRAMITE_ID.ToString(), string.Empty);

                            if (row.IsFECHA_INICIONull)
                                row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dt.Rows[0][TramitesService.SucursalId_NombreCol]), row.MONEDA_ID, DateTime.Today, sesion);
                            else
                                row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dt.Rows[0][TramitesService.SucursalId_NombreCol]), row.MONEDA_ID, row.FECHA_INICIO, sesion);

                            if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                throw new Exception("Debe actualizarse la cotización de la moneda.");
                        }
                        else
                        {
                            throw new Exception("La moneda deseada no está activa.");
                        }
                    }


                    if (campos.Contains(TramitesActividadesService.CostoUnitario_NombreCol))
                        row.COSTO_UNITARIO = (decimal)campos[TramitesActividadesService.CostoUnitario_NombreCol];
                    else
                        row.IsCOSTO_UNITARIONull = true;

                    if (campos.Contains(TramitesActividadesService.Precio_NombreCol))
                        row.PRECIO = (decimal)campos[TramitesActividadesService.Precio_NombreCol];
                    else
                        row.IsPRECIONull = true;

                    if (campos.Contains(TramitesActividadesService.FechaInicio_NombreCol))
                        row.FECHA_INICIO = (DateTime)campos[TramitesActividadesService.FechaInicio_NombreCol];
                    else
                        row.IsFECHA_INICIONull = true;

                    if (campos.Contains(TramitesActividadesService.FechaFin_NombreCol))
                        row.FECHA_FIN = (DateTime)campos[TramitesActividadesService.FechaFin_NombreCol];
                    else
                        row.IsFECHA_FINNull = true;

                    if (!Interprete.EsNullODBNull(campos[TramitesActividadesService.ActivoId_NombreCol]))
                        row.ACTIVO_ID = (decimal)campos[TramitesActividadesService.ActivoId_NombreCol];
                    else
                        row.IsACTIVO_IDNull = true;

                    if (!Interprete.EsNullODBNull(campos[TramitesActividadesService.ArticuloId_NombreCol]))
                        row.ARTICULO_ID = (decimal)campos[TramitesActividadesService.ArticuloId_NombreCol];
                    else
                        row.IsARTICULO_IDNull = true;

                    if (campos.Contains(TramitesActividadesService.UnidadId_NombreCol))
                        row.UNIDAD_ID = campos[TramitesActividadesService.UnidadId_NombreCol].ToString();                    

                    if (campos.Contains(TramitesActividadesService.PorcentajeDescuento_NombreCol))
                        row.PORCENTAJE_DESCUENTO = (decimal)campos[TramitesActividadesService.PorcentajeDescuento_NombreCol];
                    else
                        row.IsPORCENTAJE_DESCUENTONull = true;

                    if (campos.Contains(TramitesActividadesService.CostoTotal_NombreCol))
                        row.COSTO_TOTAL = decimal.Parse(campos[TramitesActividadesService.CostoTotal_NombreCol].ToString());
                    else
                        row.IsCOSTO_TOTALNull = true;

                    if (campos.Contains(TramitesActividadesService.CostoUnitarioDescontado_NombreCol))
                        row.COSTO_UNITARIO_DESCONTADO = (decimal)campos[TramitesActividadesService.CostoUnitarioDescontado_NombreCol];
                    else
                        row.IsCOSTO_UNITARIO_DESCONTADONull = true;

                    if (campos.Contains(TramitesActividadesService.ImpuestoId_NombreCol))
                        row.IMPUESTO_ID = decimal.Parse(campos[TramitesActividadesService.ImpuestoId_NombreCol].ToString());
                    else
                        row.IsIMPUESTO_IDNull = true;

                    if (campos.Contains(TramitesActividadesService.TotalImpuesto_NombreCol))
                        row.TOTAL_IMPUESTO_MONT = decimal.Parse(campos[TramitesActividadesService.TotalImpuesto_NombreCol].ToString());
                    else
                        row.IsTOTAL_IMPUESTO_MONTNull = true;

                    if (insertarNuevo)
                        sesion.Db.TRAMITES_ACTIVIDADESCollection.Insert(row);
                    else
                        sesion.Db.TRAMITES_ACTIVIDADESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch(Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal detalleId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRAMITES_ACTIVIDADESRow row = new TRAMITES_ACTIVIDADESRow();

                    row = sesion.Db.TRAMITES_ACTIVIDADESCollection.GetByPrimaryKey(detalleId);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    
                    sesion.Db.TRAMITES_ACTIVIDADESCollection.DeleteByPrimaryKey(detalleId);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch(Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRAMITES_ACTIVIDADES"; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.IDColumnName; }
        }
        public static string TramiteId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.TRAMITE_IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.DESCRIPCIONColumnName; }
        }
        public static string CantidadHoras_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.CANTIDAD_HORASColumnName; }
        }
        public static string CantidadUnidades_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.CANTIDAD_UNIDADESColumnName; }
        }
        public static string Finalizado_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.FINALIZADOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.MONEDA_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.COTIZACIONColumnName; }
        }
        public static string CostoUnitario_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.COSTO_UNITARIOColumnName; }
        }
        public static string Precio_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.PRECIOColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.FECHA_INICIOColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.FECHA_FINColumnName; }
        }
        public static string ActivoId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.ACTIVO_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.ARTICULO_IDColumnName; }
        }
        public static string UnidadId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.UNIDAD_IDColumnName; }
        }
        public static string PorcentajeDescuento_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.PORCENTAJE_DESCUENTOColumnName; }
        }
        public static string CostoTotal_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.COSTO_TOTALColumnName; }
        }
        public static string CostoUnitarioDescontado_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.COSTO_UNITARIO_DESCONTADOColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.IMPUESTO_IDColumnName; }
        }
        public static string TotalImpuesto_NombreCol
        {
            get { return TRAMITES_ACTIVIDADESCollection.TOTAL_IMPUESTO_MONTColumnName; }
        }
        #endregion Accessors
    }
}