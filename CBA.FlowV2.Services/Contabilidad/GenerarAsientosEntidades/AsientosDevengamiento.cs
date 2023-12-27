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
    public class AsientosDevengamiento
    {
        #region AsentarDevengamiento
        public static void AsentarDevengamiento(DevengamientosService devengamiento)
        {
            using (SessionService sesion = new SessionService())
            {
                AsentarDevengamiento(devengamiento, sesion);
            }
        }

        public static void AsentarDevengamiento(DevengamientosService devengamiento, SessionService sesion)
        {
            try
            {
                decimal sucursalId = Definiciones.Error.Valor.EnteroPositivo;
                string clausulas = string.Empty;
                if (devengamiento.RegionId.HasValue)
                    clausulas = SucursalesService.RegionId_NombreCol + " = " + devengamiento.RegionId.Value;

                DataTable dtSucursales = SucursalesService.GetSucursalesDataTable2(clausulas, SucursalesService.EsCasaMatriz_NombreCol + " desc, " + SucursalesService.Id_NombreCol, true);
                if (dtSucursales.Rows.Count > 0)
                    sucursalId = (decimal)dtSucursales.Rows[0][SucursalesService.Id_NombreCol];

                DataTable dtPeriodos = PeriodosService.GetPeriodoActivoAAsentar(devengamiento.Fecha, sucursalId, sesion);
                if (dtPeriodos.Rows.Count <= 0)
                    throw new Exception("No se encontró un período contable activo.");

                foreach (DataRow drPeriodo in dtPeriodos.Rows)
                {
                    try
                    {
                        DataTable dtAsientoAutomatico = AsientosAutomaticosService.GetAsientosAutomaticosDataTable(AsientosAutomaticosService.Id_NombreCol + " = " + Definiciones.Contabilidad.AsientosAutomaticos.DevengamientoCreado, string.Empty, true);
                        DataTable dtAsientosDetalle = AsientosAutomaticosDetalleService.GetAsientosAutomaticosDetalleInfoCompleta(AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol + " = " + Definiciones.Contabilidad.AsientosAutomaticos.DevengamientoCreado + " and " + AsientosAutomaticosDetalleService.VistaCantidadCuentasRelacionadas_NombreCol + " > " + 0, AsientosAutomaticosDetalleService.Orden_NombreCol, sesion);

                        Hashtable campos = new Hashtable();
                        Hashtable sumaPorCuenta;
                        Hashtable parametrosElegirCuenta;
                        decimal asientoCabeceraId;
                        decimal cuentaAux, montoAux = 0;
                        decimal monedaPais, cotizacionMonedaPais;
                        bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
                        decimal periodoId = (decimal)drPeriodo[PeriodosService.Id_NombreCol];

                        monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(SucursalesService.GetPais(sucursalId), sesion);
                        cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(sesion.SucursalActiva_pais_id, monedaPais, devengamiento.Fecha, sesion);

                        //Crear la cabecera del asiento
                        campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodoId);
                        campos.Add(AsientosService.TablaRelacionadaId_NombreCol, DevengamientosService.Nombre_Tabla);
                        campos.Add(AsientosService.RegistroRelacionadoId_NombreCol, devengamiento.Id.Value);
                        campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
                        campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
                        campos.Add(AsientosService.FechaAsiento_NombreCol, devengamiento.Fecha);
                        campos.Add(AsientosService.Observacion_NombreCol, "Devengamiento a fecha " + devengamiento.Fecha.ToShortDateString() + ".");
                        campos.Add(AsientosService.RevisionPosterior_NombreCol, (string)dtAsientoAutomatico.Rows[0][AsientosAutomaticosService.RevisionPosterior_NombreCol]);
                        campos.Add(AsientosService.SucursalId_NombreCol, sucursalId);
                        asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

                        //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
                        for (int i = 0; i < dtAsientosDetalle.Rows.Count; i++)
                        {
                            switch (int.Parse(dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                            {
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.AumentarADevengarVigente:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.ADevengarVigenteAum;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.DisminuirADevengarVigente:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.ADevengarVigenteDis;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.AumentarADevengarVencido:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.ADevengarVencidoAum;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.DisminuirADevengarVencido:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.ADevengarVencidoDis;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.AumentarDevengado:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.DevengadoAum;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.DisminuirDevengado:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.DevengadoDis;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.AumentarEnSuspenso:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.EnSuspensoAum;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.DisminuirEnSuspenso:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.EnSuspensoDis;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.AumentarCapitalACobrarVigente:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.CapitalACobrarVigenteAum;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.DisminuirCapitalACobrarVigente:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.CapitalACobrarVigenteDis;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.AumentarCapitalACobrarVencido:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.CapitalACobrarVencidoAum;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.DisminuirCapitalACobrarVencido:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.CapitalACobrarVencidoDis - devengamiento.CapitalVencidoCobrado;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.AumentarInteresACobrarVigente:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.InteresACobrarVigenteAum;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.DisminuirInteresACobrarVigente:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.InteresACobrarVigenteDis;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.AumentarInteresACobrarVencido:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.InteresACobrarVencidoAum;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
                                    AsientosDetalleService.Guardar(campos, true, sesion);
                                    #endregion crear detalles del asiento

                                    break;
                                case Definiciones.Contabilidad.AsientosAutomaticosDetalle.DevengamientoCreado.DisminuirInteresACobrarVencido:

                                    #region calcular
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodoId, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, devengamiento.MonedaId);
                                    if (devengamiento.RegionId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, devengamiento.RegionId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    montoAux = devengamiento.InteresACobrarVencidoDis - devengamiento.InteresVencidoCobrado;

                                    //Obtener el monto en la moneda del pais
                                    if (devengamiento.MonedaId != monedaPais)
                                        montoAux = montoAux / devengamiento.Cotizacion * cotizacionMonedaPais;

                                    #endregion calcular

                                    #region crear detalles del asiento
                                    campos = new Hashtable();
                                    campos.Add(AsientosDetalleService.CtbAsientoId_NombreCol, asientoCabeceraId);
                                    campos.Add(AsientosDetalleService.CtbCuentaId_NombreCol, cuentaAux);
                                    campos.Add(AsientosDetalleService.Debe_NombreCol, invertirDebeHaber ? montoAux : (decimal)0);
                                    campos.Add(AsientosDetalleService.Haber_NombreCol, invertirDebeHaber ? (decimal)0 : montoAux);
                                    campos.Add(AsientosDetalleService.MonedaId_NombreCol, monedaPais);
                                    campos.Add(AsientosDetalleService.CotizacionMoneda_NombreCol, cotizacionMonedaPais);
                                    campos.Add(AsientosDetalleService.MonedaOrigenId_NombreCol, devengamiento.MonedaId);
                                    campos.Add(AsientosDetalleService.CotizacionMonedaOrigen_NombreCol, devengamiento.Cotizacion);
                                    campos.Add(AsientosDetalleService.Observacion_NombreCol, dtAsientosDetalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol] + " " + devengamiento.Fecha.ToShortDateString());
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
            catch
            {
                //Se continua aunque no haya un periodo activo
            }
        }
        #endregion AsentarCambioEstado
    }
}
