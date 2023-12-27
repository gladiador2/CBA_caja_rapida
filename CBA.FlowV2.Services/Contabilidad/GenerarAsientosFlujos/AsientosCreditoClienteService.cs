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
using CBA.FlowV2.Services.Facturacion;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosCreditoClienteService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacion<CreditosService>
        {
            #region Constructor
            public CentrosCostoAplicacion(CreditosService creditosService, SessionService sesion)
                : base(new CreditosService())
            {
                decimal detalleId = (decimal)creditosService.Id;
                decimal porcentaje = 100;
                this.porcentajeDetalleSobreTotal.Add(detalleId, porcentaje);
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region AsentarAprobadoAVigente
        /// <summary>
        /// Asentars the pendiente a aprobado.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">No se encontró un período contable activo.</exception>
        public static decimal AsentarAprobadoAVigente(CasosService caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            CreditosService casoCabecera = CreditosService.GetPorCaso(caso.Id.Value, sesion);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, casoCabecera.FechaRetiro.Value, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.AjusteBancario_Aprobado_a_Cerrado,
                                                                                             caso,
                                                                                             Interprete.ObtenerString(casoCabecera.Observacion),
                                                                                             sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.CreditoCliente_Aprobado_a_Vigente.Activo_AumentarCapitalADesembolsar:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        if (!Interprete.EsNullODBNull(casoCabecera.CanalVentaId))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        if (casoCabecera.PersonaGarante1Id != null)
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, casoCabecera.PersonaGarante1Id);

                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = casoCabecera.MontoCapitalSolicitado;

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                            observacion = Traducciones.Caso + " " + casoCabecera.CasoId + ". ";

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)casoCabecera.Id, 100,
                                         centrosCostoAp.Seleccionar((decimal)casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, casoCabecera, null, sesion), (decimal)casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.CreditoCliente_Aprobado_a_Vigente.Activo_AumentarInteresDevengado:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        if (!Interprete.EsNullODBNull(casoCabecera.CanalVentaId))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        if (casoCabecera.PersonaGarante1Id != null)
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, casoCabecera.PersonaGarante1Id);

                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)casoCabecera.MontoInteres;

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                            observacion = Traducciones.Caso + " " + casoCabecera.CasoId + ". ";

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)casoCabecera.Id, 100,
                                         centrosCostoAp.Seleccionar((decimal)casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, casoCabecera, null, sesion), (decimal)casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.CreditoCliente_Aprobado_a_Vigente.Activo_AumentarInteresDevengadoNoVencido:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        if (!Interprete.EsNullODBNull(casoCabecera.CanalVentaId))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        if (casoCabecera.PersonaGarante1Id != null)
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, casoCabecera.PersonaGarante1Id);

                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)casoCabecera.MontoInteres;

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                            observacion = Traducciones.Caso + " " + casoCabecera.CasoId + ". ";

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)casoCabecera.Id, 100,
                                         centrosCostoAp.Seleccionar((decimal)casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, casoCabecera, null, sesion), (decimal)casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.CreditoCliente_Aprobado_a_Vigente.Activo_AumentarPrestamosAClientes:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        if (!Interprete.EsNullODBNull(casoCabecera.CanalVentaId))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        if (casoCabecera.PersonaGarante1Id != null)
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, casoCabecera.PersonaGarante1Id);

                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)casoCabecera.MontoCapitalSolicitado;

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                            observacion = Traducciones.Caso + " " + casoCabecera.CasoId + ". ";

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)casoCabecera.Id, 100,
                                         centrosCostoAp.Seleccionar((decimal)casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, casoCabecera, null, sesion), (decimal)casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.CreditoCliente_Aprobado_a_Vigente.Activo_AumentarRecaudacionesEnProceso:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        if (!Interprete.EsNullODBNull(casoCabecera.CanalVentaId))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        if (casoCabecera.PersonaGarante1Id != null)
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, casoCabecera.PersonaGarante1Id);

                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)casoCabecera.MontoCapitalAprobado - (decimal)casoCabecera.MontoCapitalSolicitado;

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                            observacion = Traducciones.Caso + " " + casoCabecera.CasoId + ". ";

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)casoCabecera.Id, 100,
                                         centrosCostoAp.Seleccionar((decimal)casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, casoCabecera, null, sesion), (decimal)casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;
                }
            }

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.CreditoCliente_Aprobado_a_Vigente, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarAprobadoAVigente

        #region AsentarEnRevisionAVigente
        public static decimal AsentarEnRevisionAVigente(CasosService caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            CreditosService casoCabecera = CreditosService.GetPorCaso(caso.Id.Value, sesion);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, fecha_asiento, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.AjusteBancario_Aprobado_a_Cerrado,
                                                                                             caso,
                                                                                             Interprete.ObtenerString(casoCabecera.Observacion),
                                                                                             sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.CreditoCliente_EnRevision_a_Vigente.AumentarDescuentoInteresesADevengar:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        if (!Interprete.EsNullODBNull(casoCabecera.CanalVentaId))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        if (casoCabecera.PersonaGarante1Id != null)
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, casoCabecera.PersonaGarante1Id);

                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = casoCabecera.DescuentoCancAntAplicado;
                        
                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                            observacion = Traducciones.Caso + " " + casoCabecera.CasoId + ". ";

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)casoCabecera.Id, 100,
                                         centrosCostoAp.Seleccionar((decimal)casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, casoCabecera, null, sesion), (decimal)casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.CreditoCliente_EnRevision_a_Vigente.DisminuirADevengarVigente:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        if (!Interprete.EsNullODBNull(casoCabecera.CanalVentaId))
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        if (casoCabecera.PersonaGarante1Id != null)
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, casoCabecera.PersonaGarante1Id);

                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = casoCabecera.DescuentoCancAntAplicado;
                        
                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                            observacion = Traducciones.Caso + " " + casoCabecera.CasoId + ". ";

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)casoCabecera.Id, 100,
                                         centrosCostoAp.Seleccionar((decimal)casoCabecera.Id,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, casoCabecera, null, sesion), (decimal)casoCabecera.PersonaId, Definiciones.Tablas.Personas);

                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;
                }
            }

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.CreditoCliente_EnRevision_a_Vigente, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarEnRevisionAVigente
    }
}
