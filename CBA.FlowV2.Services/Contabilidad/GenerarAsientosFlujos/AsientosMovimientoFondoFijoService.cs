#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
using System.Collections.Generic;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosMovimientoFondoFijoService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacion(DataTable dtCabecera, DataTable dtDetalles, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                decimal total = 0;

                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    total += (decimal)dtDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoEgresoOrigen_NombreCol] + (decimal)dtDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoIngresoOrigen_NombreCol];

                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    decimal detalleId = (decimal)dtDetalles.Rows[i][MovimientoFondoFijoDetalleService.Id_NombreCol];
                    decimal porcentaje = ((decimal)dtDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoEgresoOrigen_NombreCol] + (decimal)dtDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoIngresoOrigen_NombreCol]) / total;
                    this.porcentajeDetalleSobreTotal.Add(detalleId, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region AsentarPendienteAAprobado
        /// <summary>
        /// Asentars the pendiente A aprobado.
        /// - Aumentar mercaderias (monto neto)
        /// - Disminuir mercaderias en proceso (monto neto)
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public static decimal AsentarPendienteAAprobado(CasosService caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            DateTime fechaDeAsiento;
            DataTable dtCabecera = MovimientoFondoFijoService.GetMovimientoFondoFijoInfoCompleta(MovimientoFondoFijoService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
            decimal asientoCabeceraId = Definiciones.Error.Valor.EnteroPositivo;

            List<decimal> detallesSucursales = MovimientoFondoFijoDetalleService.GetSucursalesDistintas((decimal)dtCabecera.Rows[0][MovimientoFondoFijoService.Id_NombreCol], sesion);
            if (!detallesSucursales.Contains((decimal)dtCabecera.Rows[0][MovimientoFondoFijoService.SucursalId_NombreCol]))
                detallesSucursales.Add((decimal)dtCabecera.Rows[0][MovimientoFondoFijoService.SucursalId_NombreCol]);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal cuentaAux = Definiciones.Error.Valor.EnteroPositivo;
            decimal montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;

            foreach (decimal sucursalId in detallesSucursales)
            {
                string clausulas = MovimientoFondoFijoDetalleService.MovimientoFondoFijoId_NombreCol + " = " + dtCabecera.Rows[0][MovimientoFondoFijoService.Id_NombreCol] + " and ";
                if (sucursalId == (decimal)dtCabecera.Rows[0][MovimientoFondoFijoService.SucursalId_NombreCol])
                    clausulas += "(" + MovimientoFondoFijoDetalleService.SucursalMoviminetoId_NombreCol + " is null or " + MovimientoFondoFijoDetalleService.SucursalMoviminetoId_NombreCol + " = " + sucursalId + ")";
                else
                    clausulas += MovimientoFondoFijoDetalleService.SucursalMoviminetoId_NombreCol + " = " + sucursalId;

                DataTable dtDetalles = MovimientoFondoFijoDetalleService.GetMovimientoFondoFijoDetallesInfoCompleta(clausulas, MovimientoFondoFijoDetalleService.Id_NombreCol, sesion);
                if (dtDetalles.Rows.Count <= 0)
                    continue;

                DataTable dtDetallesCuentas;
                DataTable dtSucursal = SucursalesService.GetSucursalesInfoCompleta2(SucursalesService.Id_NombreCol + " = " + sucursalId, string.Empty, false);

                CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(dtCabecera, dtDetalles, new MovimientoFondoFijoService(), sesion);

                //En caso el usuario haya establecido las cuentas afectadas por detalle
                decimal[] cuentasAux, porcentajesAux;

                monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
                cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][MovimientoFondoFijoService.Fecha_NombreCol], sesion);

                //Crear la cabecera del asiento
                campos = new Hashtable();
                campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
                campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
                campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
                campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
                campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.MovimientoFondoFijo_Pendiente_a_Aprobado,
                                                                                                 caso,
                                                                                                 Interprete.ObtenerString(dtCabecera.Rows[0][MovimientoFondoFijoService.Observacion_NombreCol]),
                                                                                                 sesion));
                campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
                campos.Add(AsientosService.SucursalId_NombreCol, sucursalId);
                campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
                asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

                //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
                for (int i = 0; i < asientos_detalle.Rows.Count; i++)
                {
                    switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                    {
                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.MovimientoFondoFijo_Pendiente_a_Aprobado.Activo_AumentarFondoFijoPorIngreso:

                            #region sumar separando en cuentas
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                            for (int j = 0; j < dtDetalles.Rows.Count; j++)
                            {
                                //Solo se incluyen detalles de ajuste positivo
                                if ((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MontoIngresoDestino_NombreCol] <= 0)
                                    continue;

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, sucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, dtSucursal.Rows[0][SucursalesService.RegionId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.TextoPredefinidoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][MovimientoFondoFijoService.FondoFijoId_NombreCol]);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MontoIngresoDestino_NombreCol] * (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = Traducciones.Caso + " " + dtCabecera.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol] + " " + dtSucursal.Rows[0][SucursalesService.Nombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.VistaTextoPredefinidoNombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Comentario_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol], (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.CotizacionDestino_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol], 100,
                                                 centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                            }
                            #endregion sumar separando en cuentas

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                            break;
                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.MovimientoFondoFijo_Pendiente_a_Aprobado.Egreso_DisminuirGastosEnProcesoPorEgreso:
                            if (!dtCabecera.Rows[0][MovimientoFondoFijoService.PagoContratistaDetalleId_NombreCol].Equals(DBNull.Value))
                            {
                                detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[0][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, sucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, dtSucursal.Rows[0][SucursalesService.RegionId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtDetalles.Rows[0][MovimientoFondoFijoDetalleService.TextoPredefinidoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][MovimientoFondoFijoService.FondoFijoId_NombreCol]);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;

                                #endregion seleccionar cuentas contables

                                DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + (decimal)dtCabecera.Rows[0][MovimientoFondoFijoService.PagoContratistaDetalleId_NombreCol], PagoContratistasDetallesServices.Id_NombreCol);
                                decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.CertificadoMonto_NombreCol];

                                montoAux = monto;

                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[0][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol], (decimal)dtDetalles.Rows[0][MovimientoFondoFijoDetalleService.CotizacionDestino_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                          centrosCostoAp, (decimal)dtDetalles.Rows[0][MovimientoFondoFijoDetalleService.Id_NombreCol], 100,
                                                          centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[0][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                                                     asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                     asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                     asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                     caso, dtCabecera.Rows[0], dtDetalles.Rows[0], sesion));

                                foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                    AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                            }
                            else
                            {
                                #region sumar separando en cuentas
                                detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                                for (int j = 0; j < dtDetalles.Rows.Count; j++)
                                {
                                    cuentasAux = null;
                                    porcentajesAux = null;

                                    //Solo se incluyen detalles de ajuste negativo
                                    if ((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol] <= 0)
                                        continue;

                                    #region seleccionar cuentas contables
                                    //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                                    //y no las indicadas por la relacion entre cuentas y asientos automaticos
                                    dtDetallesCuentas = MovimientoFondoFijoDetalleCuentaContableService.GetMovimientoFondoFijoDetalleCuentaContableDataTable(MovimientoFondoFijoDetalleCuentaContableService.MovimientoFondoFijoDetalleId_NombreCol + " = " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol], string.Empty, sesion);
                                    if (dtDetallesCuentas.Rows.Count > 0)
                                    {
                                        cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                        porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                        for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                        {
                                            cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][MovimientoFondoFijoDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                            porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][MovimientoFondoFijoDetalleCuentaContableService.Porcentaje_NombreCol];
                                        }
                                    }
                                    else
                                    {
                                        parametrosElegirCuenta = new Hashtable();
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, sucursalId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, dtSucursal.Rows[0][SucursalesService.RegionId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.TextoPredefinidoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][MovimientoFondoFijoService.FondoFijoId_NombreCol]);
                                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                            continue;
                                    }

                                    #endregion seleccionar cuentas contables

                                    montoAux = (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol] * (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = Traducciones.Caso + " " + dtCabecera.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol] + " " + dtSucursal.Rows[0][SucursalesService.Nombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.VistaTextoPredefinidoNombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Comentario_NombreCol];

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];
                                    //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                                    //usuario o lo indicado en la relacion de cuenta por asiento automatico
                                    if (cuentasAux == null)
                                    {
                                        //Se suma el monto por cada cuenta
                                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol], (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.CotizacionDestino_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                         centrosCostoAp, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol], 100,
                                                         centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                    caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                                    }
                                    else
                                    {
                                        for (int k = 0; k < cuentasAux.Length; k++)
                                        {
                                            //Se suma el monto por cada cuenta
                                            detalles.Agregar(cuentasAux[k], montoAux * porcentajesAux[k] / 100, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol], cotizacionMonedaPais, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                            centrosCostoAp, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol], 100,
                                                         centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                    caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                                        }
                                    }
                                }
                                #endregion sumar separando en cuentas

                                foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                    AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                            }

                            break;

                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.MovimientoFondoFijo_Pendiente_a_Aprobado.Activo_DisminuirRecaudacionesADepositarPorIngreso:

                            #region sumar separando en cuentas
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                            for (int j = 0; j < dtDetalles.Rows.Count; j++)
                            {
                                //Solo se incluyen detalles de ajuste positivo
                                if ((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MontoIngresoDestino_NombreCol] <= 0)
                                    continue;

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, sucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, dtSucursal.Rows[0][SucursalesService.RegionId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.TextoPredefinidoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][MovimientoFondoFijoService.FondoFijoId_NombreCol]);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MontoIngresoDestino_NombreCol] * (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = Traducciones.Caso + " " + dtCabecera.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol] + " " + dtSucursal.Rows[0][SucursalesService.Nombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.VistaTextoPredefinidoNombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Comentario_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol], cotizacionMonedaPais, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol], 100,
                                                 centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                            }
                            #endregion sumar separando en cuentas

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                            break;

                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.MovimientoFondoFijo_Pendiente_a_Aprobado.Activo_DisminuirFondoFijoPorEgreso:

                            #region sumar separando en cuentas
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                            for (int j = 0; j < dtDetalles.Rows.Count; j++)
                            {
                                //Solo se incluyen detalles de ajuste negativo
                                if ((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol] <= 0)
                                    continue;

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, sucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, dtSucursal.Rows[0][SucursalesService.RegionId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.TextoPredefinidoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][MovimientoFondoFijoService.FondoFijoId_NombreCol]);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol] * (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Cantidad_NombreCol];

                                if (montoAux < 0)
                                    montoAux *= -1;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = Traducciones.Caso + " " + dtCabecera.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol] + " " + dtSucursal.Rows[0][SucursalesService.Nombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.VistaTextoPredefinidoNombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Comentario_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol], cotizacionMonedaPais, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol], 100,
                                                 centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                            }
                            #endregion sumar separando en cuentas

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                            break;

                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.MovimientoFondoFijo_Pendiente_a_Aprobado.PagoContratista:

                            if (!dtCabecera.Rows[0][MovimientoFondoFijoService.PagoContratistaDetalleId_NombreCol].Equals(DBNull.Value))
                            {

                                #region sumar separando en cuentas
                                detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                                for (int j = 0; j < dtDetalles.Rows.Count; j++)
                                {

                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, sucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, dtSucursal.Rows[0][SucursalesService.RegionId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.TextoPredefinidoId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][MovimientoFondoFijoService.FondoFijoId_NombreCol]);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + (decimal)dtCabecera.Rows[0][MovimientoFondoFijoService.PagoContratistaDetalleId_NombreCol], PagoContratistasDetallesServices.Id_NombreCol);
                                    decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoFijoPagado_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.FacturasProveedorPagado_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.AdelantosPagados_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.AdelantoInicial_NombreCol];

                                    montoAux = monto;

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = Traducciones.Caso + " " + dtCabecera.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol] + " " + dtSucursal.Rows[0][SucursalesService.Nombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.VistaTextoPredefinidoNombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Comentario_NombreCol];

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol], (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.CotizacionDestino_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol], 100,
                                                 centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                                }
                                #endregion sumar separando en cuentas

                                foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                    AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                            }
                            break;
                        case Definiciones.Contabilidad.AsientosAutomaticosDetalle.MovimientoFondoFijo_Pendiente_a_Aprobado.PagoContratistaFondoReparo:

                            if (!dtCabecera.Rows[0][MovimientoFondoFijoService.PagoContratistaDetalleId_NombreCol].Equals(DBNull.Value))
                            {

                                #region sumar separando en cuentas
                                detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                                for (int j = 0; j < dtDetalles.Rows.Count; j++)
                                {

                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, sucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, dtSucursal.Rows[0][SucursalesService.RegionId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.TextoPredefinidoId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][MovimientoFondoFijoService.FondoFijoId_NombreCol]);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + (decimal)dtCabecera.Rows[0][MovimientoFondoFijoService.PagoContratistaDetalleId_NombreCol], PagoContratistasDetallesServices.Id_NombreCol);
                                    decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoReparo_NombreCol];

                                    montoAux = monto;

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                        observacion = Traducciones.Caso + " " + dtCabecera.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol] + " " + dtSucursal.Rows[0][SucursalesService.Nombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.VistaTextoPredefinidoNombre_NombreCol] + ". " + dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Comentario_NombreCol];

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol], (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.CotizacionDestino_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, (decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol], 100,
                                                 centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][MovimientoFondoFijoDetalleService.Id_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                                }
                                #endregion sumar separando en cuentas

                                foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                    AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                            }
                            break;
                    }
                }

                //pongo el control acá porque este metodo crea dos asientos y el método retorna un sólo asientoCabeceraId
                if (asientoCabeceraId != Definiciones.Error.Valor.EnteroPositivo)
                {
                    DataTable detalle = AsientosDetalleService.GetAsientosDetalleDataTable(AsientosDetalleService.CtbAsientoId_NombreCol + " = " + asientoCabeceraId, string.Empty, sesion);
                    if (detalle.Rows.Count <= 0)
                    {
                        AsientosService.Borrar(asientoCabeceraId, sesion);
                    }
                }
            }

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.MovimientoFondoFijo_Pendiente_a_Aprobado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarPendienteAAprobado
    }
}
