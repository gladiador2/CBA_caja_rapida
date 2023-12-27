#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosAnticiposPersonasService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacion(DataTable dtCabecera, DataTable dtDetalles, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    decimal detalleId = (decimal)dtDetalles.Rows[i][AnticiposPersonaDetalleService.Id_NombreCol];
                    decimal porcentaje = ((decimal)dtDetalles.Rows[i][AnticiposPersonaDetalleService.Monto_NombreCol] / (decimal)dtDetalles.Rows[i][AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol]) /
                                         ((decimal)dtCabecera.Rows[0][AnticiposPersonaService.MontoTotal_NombreCol] / (decimal)dtCabecera.Rows[0][AnticiposPersonaService.CotizacionMoneda_NombreCol]);
                                         
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
            DataTable dtCabecera = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
            DataTable dtDetalles = AnticiposPersonaDetalleService.GetAnticipoPersonaDetalleInfoCompleta(AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol + " = " + dtCabecera.Rows[0][AnticiposPersonaService.Id_NombreCol], string.Empty, sesion);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(dtCabecera, dtDetalles, new AnticiposPersonaService(), sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][AnticiposPersonaService.Fecha_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.AnticipoPersona_Pendiente_a_Aprobado,
                                                                                             caso,
                                                                                             Interprete.ObtenerString(dtCabecera.Rows[0][AnticiposPersonaService.Observacion_NombreCol]),
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AnticipoPersona_Pendiente_a_Aprobado.Activo_AumentarCaja:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][AnticiposPersonaService.FuncionarioCobradorId_NombreCol]);
                            if (!Interprete.EsNullODBNull(dtDetalles.Rows[j][AnticiposPersonaDetalleService.CtacteChequeRecibidoId_NombreCol]))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesRecibidosService.GetEstado((decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.CtacteChequeRecibidoId_NombreCol], sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol, dtDetalles.Rows[j][AnticiposPersonaDetalleService.CtacteProcesadoraTarjetaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, dtDetalles.Rows[j][AnticiposPersonaDetalleService.CtacteValorId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][AnticiposPersonaDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCabecera.Rows[0][AnticiposPersonaService.PersonaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, caso.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][AnticiposPersonaService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][AnticiposPersonaService.TextoPredefinidoId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.Monto_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido && !Interprete.EsNullODBNull(dtDetalles.Rows[j][AnticiposPersonaDetalleService.VistaObservacion_NombreCol]))
                                observacion = (string)dtDetalles.Rows[j][AnticiposPersonaDetalleService.VistaObservacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AnticipoPersona_Pendiente_a_Aprobado.Pasivo_AumentarAnticiposRecibidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, dtDetalles.Rows[j][AnticiposPersonaDetalleService.CtacteValorId_NombreCol]);
                            if (!Interprete.EsNullODBNull(dtDetalles.Rows[j][AnticiposPersonaDetalleService.CtacteChequeRecibidoId_NombreCol]))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesRecibidosService.GetEstado((decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.CtacteChequeRecibidoId_NombreCol], sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol, dtDetalles.Rows[j][AnticiposPersonaDetalleService.CtacteProcesadoraTarjetaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][AnticiposPersonaService.FuncionarioCobradorId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][AnticiposPersonaDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCabecera.Rows[0][AnticiposPersonaService.PersonaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, caso.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][AnticiposPersonaService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][AnticiposPersonaService.TextoPredefinidoId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.Monto_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido && !Interprete.EsNullODBNull(dtDetalles.Rows[j][AnticiposPersonaDetalleService.VistaObservacion_NombreCol]))
                                observacion = (string)dtDetalles.Rows[j][AnticiposPersonaDetalleService.VistaObservacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][AnticiposPersonaDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                }
            }

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.AnticipoPersona_Pendiente_a_Aprobado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarPendienteAAprobado
    }
}
