#region Using
using System.Collections;
using CBA.FlowV2.Services.Base;
using System;
using System.Data;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Casos;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosEntidades
{
    public class AsientosRevaluosDepreciacionesService
    {
        #region AsentarRevaluoDepreciaciones
        public static decimal AsentarRevaluoDepreciaciones(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                return AsentarRevaluoDepreciaciones(campos, sesion);
            }
        }

        public static decimal AsentarRevaluoDepreciaciones(System.Collections.Hashtable hashtable, SessionService sesion)
        {
            decimal asientoCabeceraId = Definiciones.Error.Valor.EnteroPositivo;
            try
            {
                decimal sucursalId = Definiciones.Error.Valor.EnteroPositivo;
                string clausulas = string.Empty;

                DataTable dtSucursales = SucursalesService.GetSucursalesDataTable2(clausulas, SucursalesService.EsCasaMatriz_NombreCol + " desc, " + SucursalesService.Id_NombreCol, true);
                if (dtSucursales.Rows.Count > 0)
                    sucursalId = (decimal)dtSucursales.Rows[0][SucursalesService.Id_NombreCol];

                // los revaluos disponibles para asentar
                DataTable dtRevaluo = ActivoFijoService.GetActivoFijoDataTableInfoCompleta(ActivoFijoService.FechaRevaluo_NombreCol + " between '" + hashtable["fecha-desde"].ToString() + "' and '" + hashtable["fecha-hasta"].ToString() + "' and " + ActivoFijoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", string.Empty);

                // distinct de fechas
                DataView vRevaluo = new DataView(dtRevaluo);
                DataTable distinctRevaluo = vRevaluo.ToTable(true, "fecha_revaluo");

                foreach (DataRow dr in distinctRevaluo.Rows)
                {
                    try
                    {
                        DataTable dtPeriodos = PeriodosService.GetPeriodoActivoAAsentar((DateTime)dr["fecha_revaluo"], sucursalId, sesion);
                        if (dtPeriodos.Rows.Count <= 0)
                            throw new Exception("No se encontró un período contable activo.");

                        foreach (DataRow drPeriodo in dtPeriodos.Rows)
                        {
                            try
                            {
                                DataTable dtAsientoAutomatico = AsientosAutomaticosService.GetAsientosAutomaticosDataTable(AsientosAutomaticosService.Id_NombreCol + " = " + Definiciones.Contabilidad.AsientosAutomaticos.RevaluoDepreciacion, string.Empty, true);
                                DataTable dtAsientosDetalle = AsientosAutomaticosDetalleService.GetAsientosAutomaticosDetalleInfoCompleta(AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol + " = " + Definiciones.Contabilidad.AsientosAutomaticos.RevaluoDepreciacion + " and " + AsientosAutomaticosDetalleService.VistaCantidadCuentasRelacionadas_NombreCol + " > " + 0, AsientosAutomaticosDetalleService.Orden_NombreCol, sesion);

                                Hashtable campos = new Hashtable();
                                Hashtable sumaPorCuenta;
                                Hashtable parametrosElegirCuenta;

                                decimal cuentaAux, montoAux = 0;
                                decimal monedaPais, cotizacionMonedaPais;
                                bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
                                decimal periodoId = (decimal)drPeriodo[PeriodosService.Id_NombreCol];

                                monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(SucursalesService.GetPais(sucursalId), sesion);
                                cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(sesion.SucursalActiva_pais_id, monedaPais, (DateTime)dr["fecha_revaluo"], sesion);

                                // rubros por fecha
                                DataRow[] arrRubrosPorFecha = dtRevaluo.Select("fecha_revaluo = '" + dr["fecha_revaluo"] + "'");
                                DataTable dtRubrosPorFecha = arrRubrosPorFecha.CopyToDataTable();
                                // distinct de rubros
                                DataView vRubros = new DataView(dtRubrosPorFecha);
                                DataTable distinctRubros = vRubros.ToTable(true, "activo_rubro_id");

                                //Crear la cabecera del asiento
                                campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodoId);
                                campos.Add(AsientosService.TablaRelacionadaId_NombreCol, ActivoFijoService.Nombre_Tabla);
                                campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
                                campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
                                campos.Add(AsientosService.FechaAsiento_NombreCol, (DateTime)dr["fecha_revaluo"]);
                                campos.Add(AsientosService.Observacion_NombreCol, "Revalúo y Depreciación de bienes al " + ((DateTime)dr["fecha_revaluo"]).ToShortDateString() + ".");
                                campos.Add(AsientosService.RevisionPosterior_NombreCol, (string)dtAsientoAutomatico.Rows[0][AsientosAutomaticosService.RevisionPosterior_NombreCol]);
                                campos.Add(AsientosService.SucursalId_NombreCol, sucursalId);
                                asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

                                //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
                                for (int i = 0; i < dtAsientosDetalle.Rows.Count; i++)
                                {
                                    switch (int.Parse(dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                                    {
                                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.RevaluoDepreciacion.RubrosRevaluo:

                                            foreach (DataRow drDistinctRubros in distinctRubros.Rows)
                                            {
                                                // activos por rubro
                                                DataRow[] arrActivosPorRubro = dtRubrosPorFecha.Select("activo_rubro_id = " + drDistinctRubros["activo_rubro_id"]);
                                                DataTable dtActivosPorRubro = arrActivosPorRubro.CopyToDataTable();

                                                #region calcular

                                                #region seleccionar cuentas contables
                                                parametrosElegirCuenta = new Hashtable();
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ActivoRubroId_NombreCol, (decimal)drDistinctRubros["activo_rubro_id"]);

                                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                    continue;
                                                #endregion seleccionar cuentas contables

                                                montoAux = (decimal)dtActivosPorRubro.Compute("Sum(revaluo)", "");
                                                #endregion calcular

                                                #region crear detalles del asiento
                                                campos = new Hashtable();
                                                campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                                campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                                campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                                campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                                campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                                campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                                campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, (decimal)dtRubrosPorFecha.Rows[0]["moneda_id"]);
                                                campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, (decimal)dtRubrosPorFecha.Rows[0]["cotizacion"]);
                                                campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + ((DateTime)dr["fecha_revaluo"]).ToShortDateString());
                                                AsientosDetalleService.Guardar(campos, true, sesion);
                                                #endregion crear detalles del asiento
                                            }

                                            break;
                                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.RevaluoDepreciacion.ReservaDelRevalúo:
                                            #region calcular

                                            #region seleccionar cuentas contables
                                            parametrosElegirCuenta = new Hashtable();
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                continue;
                                            #endregion seleccionar cuentas contables

                                            montoAux = (decimal)dtRubrosPorFecha.Compute("Sum(revaluo)", "");
                                            #endregion calcular

                                            #region crear detalles del asiento
                                            campos = new Hashtable();
                                            campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                            campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                            campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                            campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                            campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                            campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                            campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, (decimal)dtRubrosPorFecha.Rows[0]["moneda_id"]);
                                            campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, (decimal)dtRubrosPorFecha.Rows[0]["cotizacion"]);
                                            campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + ((DateTime)dr["fecha_revaluo"]).ToShortDateString());
                                            AsientosDetalleService.Guardar(campos, true, sesion);
                                            #endregion crear detalles del asiento
                                            break;
                                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.RevaluoDepreciacion.Depreciacion:
                                            #region calcular

                                            #region seleccionar cuentas contables
                                            parametrosElegirCuenta = new Hashtable();
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                continue;
                                            #endregion seleccionar cuentas contables

                                            montoAux = (decimal)dtRubrosPorFecha.Compute("Sum(cuota_fiscal_depr_anual)", "");
                                            #endregion calcular

                                            #region crear detalles del asiento
                                            campos = new Hashtable();
                                            campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                            campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                            campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                            campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                            campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                            campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                            campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, (decimal)dtRubrosPorFecha.Rows[0]["moneda_id"]);
                                            campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, (decimal)dtRubrosPorFecha.Rows[0]["cotizacion"]);
                                            campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + ((DateTime)dr["fecha_revaluo"]).ToShortDateString());
                                            AsientosDetalleService.Guardar(campos, true, sesion);
                                            #endregion crear detalles del asiento
                                            break;
                                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.RevaluoDepreciacion.DepreciacionAcumulada:
                                            #region calcular

                                            #region seleccionar cuentas contables
                                            parametrosElegirCuenta = new Hashtable();
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                continue;
                                            #endregion seleccionar cuentas contables

                                            montoAux = (decimal)dtRubrosPorFecha.Compute("Sum(cuota_fiscal_depr_anual)", "");
                                            #endregion calcular

                                            #region crear detalles del asiento
                                            campos = new Hashtable();
                                            campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                            campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                            campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                            campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                            campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                            campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                            campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, (decimal)dtRubrosPorFecha.Rows[0]["moneda_id"]);
                                            campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, (decimal)dtRubrosPorFecha.Rows[0]["cotizacion"]);
                                            campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + ((DateTime)dr["fecha_revaluo"]).ToShortDateString());
                                            AsientosDetalleService.Guardar(campos, true, sesion);
                                            #endregion crear detalles del asiento
                                            break;
                                    }
                                }
                            }
                            catch
                            {
                                //Se continua aunque no se haya podido crear el asiento
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Se continua aunque haya una excepción
                    }
                }
            }
            catch (Exception)
            {
                //Se continua aunque haya una excepción
            }

            return asientoCabeceraId;

        }

        #endregion AsentarRevaluoDepreciaciones
    }
}
