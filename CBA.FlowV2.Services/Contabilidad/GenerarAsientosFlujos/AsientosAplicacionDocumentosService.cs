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
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.Facturacion;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosAplicacionDocumentosService
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
                    decimal detalleId = (decimal)dtDetalles.Rows[i][NotasCreditoPersonaAplicacionesService.Id_NombreCol];
                    decimal porcentaje = 1;

                    if ((decimal)dtDetalles.Rows[i][NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol] != 0)
                        porcentaje = (decimal)dtDetalles.Rows[i][NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol] / (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol];

                    this.porcentajeDetalleSobreTotal.Add(detalleId, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region AsentarPendienteAAprobado
        public static decimal AsentarPendienteAAprobado(CasosService caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            DateTime fechaDeAsiento;
            DataTable dtCabecera = NotasCreditoPersonaAplicacionesService.GetNotaCreditoPersonaPorCasoInfoCompleta(caso.Id.Value, sesion);
            DataTable dtDetalles = NotasCreditoPersonaAplicacionDocumentosService.GetNotaCreditoAplicacionDocumentosDataTable(NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol + " = " + dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol], string.Empty, sesion);
            DataTable dtProveedores = ProveedoresService.GetProveedoresDataTable2(ProveedoresService.PersonaId_NombreCol + " = " + dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaValoresId_NombreCol], string.Empty, false);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(dtCabecera, dtDetalles, new NotasCreditoPersonaAplicacionesService(), sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Fecha_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.AplicacionDocumentos_Pendiente_a_Aprobado,
                                                                                             caso,
                                                                                             Interprete.ObtenerString(dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.VistaCasoId_NombreCol]),
                                                                                             sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                decimal montoTotalDetalle = (decimal)dtDetalles.Compute("Sum(MONTO_DESTINO)", "");
                DataTable dtCtaCtePersona = new DataTable();
                DataTable dtCasos = new DataTable();

                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AplicacionDocumentos_Pendiente_a_Aprobado.Activo_DisminuirClientes:

                        if (dtProveedores.Rows.Count == 0)
                            continue;

                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol];

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                        {
                            observacion = (string)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.CasoId_NombreCol];
                        }

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol], (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol], 100,
                                         centrosCostoAp.Seleccionar((decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, dtCabecera.Rows[0], null, sesion));

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AplicacionDocumentos_Pendiente_a_Aprobado.Pasivo_DisminuirProveedores:

                        if (dtProveedores.Rows.Count == 0)
                            continue;

                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol];

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                        {
                            observacion = (string)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.CasoId_NombreCol];
                        }

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol], (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol], 100,
                                         centrosCostoAp.Seleccionar((decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, dtCabecera.Rows[0], null, sesion));

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AplicacionDocumentos_Pendiente_a_Aprobado.Pasivo_DisminuirAnticipo:

                        if (dtProveedores.Rows.Count > 0)
                            continue;

                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol];

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                        {
                            observacion = (string)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.CasoId_NombreCol];
                        }

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol], (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol], 100,
                                         centrosCostoAp.Seleccionar((decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, dtCabecera.Rows[0], null, sesion));

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AplicacionDocumentos_Pendiente_a_Aprobado.PrestamosAClientesNoVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            dtCtaCtePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol], string.Empty, sesion);
                            dtCasos = CasosService.GetCasoInfoCompletaDataTable((decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], sesion);
                            if ((decimal)dtCasos.Rows[0][CasosService.FlujoId_NombreCol] == Definiciones.FlujosIDs.CREDITOS)
                            {

                                var credito = CreditosService.Instancia.GetPrimero<CreditosService>(new ClaseCBABase.Filtro
                                {
                                    Columna = CreditosService.Modelo.CASO_IDColumnName,
                                    Valor = (decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol]
                                });

                                credito.IniciarUsingSesion(sesion);

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, caso.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);

                                if (credito.PersonaGarante1Id != null)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida((decimal)dtCasos.Rows[0][CasosService.Id_NombreCol]);
                                DateTime fechaCobranza = DateTime.Parse(dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Fecha_NombreCol].ToString());

                                double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays > limiteDias)
                                    continue;

                                var cuota = CreditosService.Instancia.Get<CreditosService.CalendarioService>((decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol]);

                                decimal MontoCapital = cuota.MontoCapital;
                                decimal MontoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                decimal montoCuotaRestante = (decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol] - (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol];

                                if (montoCuotaRestante >= 1)
                                {
                                    if (montoCuotaRestante <= MontoInteres)
                                        MontoInteres -= montoCuotaRestante;
                                    else
                                        MontoCapital = MontoCapital - MontoInteres - montoCuotaRestante;
                                }

                                montoTotalDetalle -= MontoInteres;

                                if (montoTotalDetalle > 0)
                                {
                                    montoTotalDetalle -= MontoCapital;

                                    if (montoTotalDetalle > 0)
                                        montoAux = MontoCapital;
                                    else
                                        montoAux = MontoCapital - (montoTotalDetalle * -1);
                                }
                                else
                                    montoAux = 0;

                                credito.FinalizarUsingSesion();


                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = (string)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionesService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol], 100,
                                                 centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion), (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol], Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AplicacionDocumentos_Pendiente_a_Aprobado.InteresesACobrarNoVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {

                            dtCtaCtePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol], string.Empty, sesion);
                            dtCasos = CasosService.GetCasoInfoCompletaDataTable((decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], sesion);
                            if ((decimal)dtCasos.Rows[0][CasosService.FlujoId_NombreCol] == Definiciones.FlujosIDs.CREDITOS)
                            {

                                var credito = CreditosService.Instancia.GetPrimero<CreditosService>(new ClaseCBABase.Filtro
                                {
                                    Columna = CreditosService.Modelo.CASO_IDColumnName,
                                    Valor = (decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol]
                                });

                                credito.IniciarUsingSesion(sesion);

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, caso.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);

                                if (credito.PersonaGarante1Id != null)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida((decimal)dtCasos.Rows[0][CasosService.Id_NombreCol]);
                                DateTime fechaCobranza = DateTime.Parse(dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Fecha_NombreCol].ToString());

                                double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays > limiteDias)
                                    continue;

                                var cuota = CreditosService.Instancia.Get<CreditosService.CalendarioService>((decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol]);

                                decimal MontoCapital = cuota.MontoCapital;
                                decimal MontoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                decimal montoCuotaRestante = (decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol] - (decimal)dtDetalles.Rows[j][CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];

                                if (montoCuotaRestante >= 1)
                                {
                                    if (montoCuotaRestante <= MontoInteres)
                                        MontoInteres -= montoCuotaRestante;
                                    else
                                        MontoCapital = MontoCapital - MontoInteres - montoCuotaRestante;
                                }

                                montoTotalDetalle -= MontoInteres;

                                if (montoTotalDetalle > 0)
                                {
                                    montoTotalDetalle -= MontoCapital;
                                    montoAux = MontoInteres;
                                }
                                else
                                    montoAux = MontoInteres - (montoTotalDetalle * -1);

                                credito.FinalizarUsingSesion();


                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = (string)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionesService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol], 100,
                                                 centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion), (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol], Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AplicacionDocumentos_Pendiente_a_Aprobado.PrestamosAClientesVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {

                            dtCtaCtePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol], string.Empty, sesion);
                            dtCasos = CasosService.GetCasoInfoCompletaDataTable((decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], sesion);
                            if ((decimal)dtCasos.Rows[0][CasosService.FlujoId_NombreCol] == Definiciones.FlujosIDs.CREDITOS)
                            {

                                var credito = CreditosService.Instancia.GetPrimero<CreditosService>(new ClaseCBABase.Filtro
                                {
                                    Columna = CreditosService.Modelo.CASO_IDColumnName,
                                    Valor = (decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol]
                                });

                                credito.IniciarUsingSesion(sesion);

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, caso.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);

                                if (credito.PersonaGarante1Id != null)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida((decimal)dtCasos.Rows[0][CasosService.Id_NombreCol]);
                                DateTime fechaCobranza = DateTime.Parse(dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Fecha_NombreCol].ToString());

                                double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays <= limiteDias)
                                    continue;

                                var cuota = CreditosService.Instancia.Get<CreditosService.CalendarioService>((decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol]);

                                decimal MontoCapital = cuota.MontoCapital;
                                decimal MontoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                decimal montoCuotaRestante = (decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol] - (decimal)dtDetalles.Rows[j][CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];

                                if (montoCuotaRestante >= 1)
                                {
                                    if (montoCuotaRestante <= MontoInteres)
                                        MontoInteres -= montoCuotaRestante;
                                    else
                                        MontoCapital = MontoCapital - MontoInteres - montoCuotaRestante;
                                }

                                montoTotalDetalle -= MontoInteres;

                                if (montoTotalDetalle > 0)
                                {
                                    montoTotalDetalle -= MontoCapital;

                                    if (montoTotalDetalle > 0)
                                        montoAux = MontoCapital;
                                    else
                                        montoAux = MontoCapital - (montoTotalDetalle * -1);
                                }
                                else
                                    montoAux = 0;

                                credito.FinalizarUsingSesion();

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = (string)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionesService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol], 100,
                                                 centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion), (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol], Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;


                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AplicacionDocumentos_Pendiente_a_Aprobado.InteresesACobrarVencidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            dtCtaCtePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol], string.Empty, sesion);
                            dtCasos = CasosService.GetCasoInfoCompletaDataTable((decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], sesion);
                            if ((decimal)dtCasos.Rows[0][CasosService.FlujoId_NombreCol] == Definiciones.FlujosIDs.CREDITOS)
                            {

                                var credito = CreditosService.Instancia.GetPrimero<CreditosService>(new ClaseCBABase.Filtro
                                {
                                    Columna = CreditosService.Modelo.CASO_IDColumnName,
                                    Valor = (decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol]
                                });

                                credito.IniciarUsingSesion(sesion);

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, caso.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);

                                if (credito.PersonaGarante1Id != null)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, credito.PersonaGarante1Id);

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                DateTime? fechaCuotaMasVencida = credito.FechaCuotaMasVencida((decimal)dtCasos.Rows[0][CasosService.Id_NombreCol]);
                                DateTime fechaCobranza = DateTime.Parse(dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.Fecha_NombreCol].ToString());

                                double limiteDias = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);

                                if (!fechaCuotaMasVencida.HasValue || (fechaCobranza - fechaCuotaMasVencida.Value).TotalDays <= limiteDias)
                                    continue;

                                var cuota = CreditosService.Instancia.Get<CreditosService.CalendarioService>((decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol]);

                                decimal MontoCapital = cuota.MontoCapital;
                                decimal MontoInteres = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;

                                decimal montoCuotaRestante = (decimal)dtCtaCtePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol] - (decimal)dtDetalles.Rows[j][CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];

                                if (montoCuotaRestante >= 1)
                                {
                                    if (montoCuotaRestante <= MontoInteres)
                                        MontoInteres -= montoCuotaRestante;
                                    else
                                        MontoCapital = MontoCapital - MontoInteres - montoCuotaRestante;
                                }

                                montoTotalDetalle -= MontoInteres;

                                if (montoTotalDetalle > 0)
                                {
                                    montoTotalDetalle -= MontoCapital;
                                    montoAux = MontoInteres;
                                }
                                else
                                    montoAux = MontoInteres - (montoTotalDetalle * -1);

                                credito.FinalizarUsingSesion();

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = (string)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionesService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, (decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol], 100,
                                                 centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion), (decimal)dtCabecera.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol], Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;
                }
            }

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.AplicacionDocumentos_Pendiente_a_Aprobado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarPendienteAAprobado
    }
}
