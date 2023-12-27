#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosTransferenciasBancariasService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacion(DataTable dtCabecera, DataTable dtDetalles, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                decimal detalleId = (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol];
                decimal porcentaje = 1;
                this.porcentajeDetalleSobreTotal.Add(detalleId, porcentaje);
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region AsentarAprobadoACerrado
        /// <summary>
        /// Asentars the aprobado A cerrado.
        /// Si cuenta destino es de la empresa
        /// - Debe en bancos
        /// Si cuenta destino no es de la empresa  
        /// - Debe en cuentas a pagar (pasivo corriente/deudas/otras deudas/cuentas a pagar)
        /// Si cuenta origen es de la empresa
        /// - Haber en bancos
        /// - Debe en gastos generales por gasto de transaccion
        /// Si cuenta origen no es de la empresa
        /// - Haber en anticipos a terceros a cobrar (activo corriente/creditos/otros creditos/Prestamos y Anticipos a terceros a Cobrar
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public static decimal AsentarAprobadoACerrado(CasosService caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            DateTime fechaDeAsiento;
            DataTable dtCabecera = TransferenciasBancariasService.GetTransferenciasBancariasInfoCompleta(TransferenciasBancariasService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
            
            Hashtable campos = new Hashtable();
            Hashtable parametrosElegirCuenta;
            AsientosDetalleService.Detalles detalles;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(dtCabecera, null, new TransferenciasBancariasService(), sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][TransferenciasBancariasService.Fecha_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.TransferenciaBancaria_Aprobado_a_Cerrado,
                                                                                             caso,
                                                                                             Interprete.ObtenerString(dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol]),
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaBancaria_Aprobado_a_Cerrado.Activo_AumentarBancoCuentaDestino:

                        //Solo genera si la cuenta destino es administrada
                        if ((string)dtCabecera.Rows[0][TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol] != Definiciones.SiNo.Si)
                            continue;

                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.CtacteBancariaDestinoId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, caso.FuncionarioId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, caso.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, caso.ProveedorId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.SucursalDestinoId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.TextoPredefinidoId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MontoDestino_NombreCol];

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                        {
                            observacion = (string)dtCabecera.Rows[0][TransferenciasBancariasService.VistaCtacteBancoDestinoAbrev_NombreCol] + " " + dtCabecera.Rows[0][TransferenciasBancariasService.NumeroCuentaDestino_NombreCol];
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciasBancariasService.CGNumeroCheque_NombreCol]))
                                observacion += ". Cheque Nro." + dtCabecera.Rows[0][TransferenciasBancariasService.CGNumeroCheque_NombreCol];

                            observacion += ". " + Traducciones.Caso + " " + dtCabecera.Rows[0][TransferenciasBancariasService.CasoId_NombreCol];
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol]))
                                observacion += ". " + dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol];
                        }

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        if ((decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaOrigenId_NombreCol] != (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol])
                        {
                            cotizacionMonedaPais = (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol];
                        }

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol], (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol], 100,
                                         centrosCostoAp.Seleccionar((decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, dtCabecera.Rows[0], null, sesion));

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaBancaria_Aprobado_a_Cerrado.Pasivo_AumentarCuentasAPagar:

                        //Solo genera si la cuenta destino no es administrada
                        if ((string)dtCabecera.Rows[0][TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol] != Definiciones.SiNo.No)
                            continue;

                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, caso.FuncionarioId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, caso.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, caso.ProveedorId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.TextoPredefinidoId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.SucursalDestinoId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MontoDestino_NombreCol];

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                        {
                            observacion = (string)dtCabecera.Rows[0][TransferenciasBancariasService.VistaCtacteBancoDestinoAbrev_NombreCol] + " " + dtCabecera.Rows[0][TransferenciasBancariasService.NumeroCuentaDestino_NombreCol];
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciasBancariasService.CGNumeroCheque_NombreCol]))
                                observacion += ". Cheque Nro." + dtCabecera.Rows[0][TransferenciasBancariasService.CGNumeroCheque_NombreCol];

                            observacion += ". " + Traducciones.Caso + " " + dtCabecera.Rows[0][TransferenciasBancariasService.CasoId_NombreCol];
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol]))
                                observacion += ". " + dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol];
                        }

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol], (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol], 100,
                                         centrosCostoAp.Seleccionar((decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, dtCabecera.Rows[0], null, sesion));

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaBancaria_Aprobado_a_Cerrado.Egreso_AumentarGastosGeneralesPorGastoTransaccion:

                        //Solo genera si la cuenta origen es administrada
                        if ((string)dtCabecera.Rows[0][TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol] != Definiciones.SiNo.Si)
                            continue;

                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, caso.FuncionarioId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.MonedaOrigenId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, caso.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, caso.ProveedorId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.SucursalOrigenId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.TextoPredefinidoId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CostoTransferencia_NombreCol];

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                        {
                            observacion = (string)dtCabecera.Rows[0][TransferenciasBancariasService.VistaCtacteBancoOrigenAbrev_NombreCol] + " " + dtCabecera.Rows[0][TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol];
                            observacion += ". " + Traducciones.Caso + " " + dtCabecera.Rows[0][TransferenciasBancariasService.CasoId_NombreCol];
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol]))
                                observacion += ". " + dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol];
                        }

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaOrigenId_NombreCol], (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol], 100,
                                         centrosCostoAp.Seleccionar((decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, dtCabecera.Rows[0], null, sesion));

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaBancaria_Aprobado_a_Cerrado.Activo_DisminuirBancoCuentaOrigen:

                        //Solo genera si la cuenta origen es administrada
                        if ((string)dtCabecera.Rows[0][TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol] != Definiciones.SiNo.Si)
                            continue;

                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, caso.FuncionarioId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.MonedaOrigenId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, caso.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, caso.ProveedorId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.SucursalOrigenId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.TextoPredefinidoId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MontoOrigen_NombreCol];

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                        {
                            observacion = (string)dtCabecera.Rows[0][TransferenciasBancariasService.VistaCtacteBancoOrigenAbrev_NombreCol] + " " + dtCabecera.Rows[0][TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol];
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciasBancariasService.CGNumeroCheque_NombreCol]))
                                observacion += ". Cheque Nro." + dtCabecera.Rows[0][TransferenciasBancariasService.CGNumeroCheque_NombreCol];

                            observacion += ". " + Traducciones.Caso + " " + dtCabecera.Rows[0][TransferenciasBancariasService.CasoId_NombreCol];
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol]))
                                observacion += ". " + dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol];
                        }

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        if ((decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaOrigenId_NombreCol] != (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol])
                        {
                            cotizacionMonedaPais = (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol];
                        }

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaOrigenId_NombreCol], (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol], 100,
                                         centrosCostoAp.Seleccionar((decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, dtCabecera.Rows[0], null, sesion));

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaBancaria_Aprobado_a_Cerrado.Activo_AumentarAnticiposATercerosACobrar:

                        //Solo genera si la cuenta origen no es administrada
                        if ((string)dtCabecera.Rows[0][TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol] != Definiciones.SiNo.No)
                            continue;

                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.CtacteBancariaDestinoId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, caso.FuncionarioId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.SucursalDestinoId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, caso.PersonaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, caso.ProveedorId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciasBancariasService.TextoPredefinidoId_NombreCol]);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        //Obtener el monto en la moneda del pais
                        montoAux = (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MontoOrigen_NombreCol] - (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CostoTransferencia_NombreCol];
                        if ((decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaDestinoId_NombreCol] == monedaPais)
                            montoAux = montoAux / (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol] * (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol];
                        else if ((decimal)dtCabecera.Rows[0][TransferenciasBancariasService.MonedaOrigenId_NombreCol] != monedaPais)
                            montoAux = montoAux / (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol] * cotizacionMonedaPais;

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (!detalles.Resumido)
                        {
                            observacion = (string)dtCabecera.Rows[0][TransferenciasBancariasService.VistaCtacteBancoOrigenAbrev_NombreCol] + " " + dtCabecera.Rows[0][TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol];
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciasBancariasService.CGNumeroCheque_NombreCol]))
                                observacion += ". Cheque Nro." + dtCabecera.Rows[0][TransferenciasBancariasService.CGNumeroCheque_NombreCol];

                            observacion += ". " + Traducciones.Caso + " " + dtCabecera.Rows[0][TransferenciasBancariasService.CasoId_NombreCol];
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol]))
                                observacion += ". " + dtCabecera.Rows[0][TransferenciasBancariasService.Observacion_NombreCol];
                        }

                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, monedaPais, cotizacionMonedaPais, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, (decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol], 100,
                                         centrosCostoAp.Seleccionar((decimal)dtCabecera.Rows[0][TransferenciasBancariasService.Id_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, dtCabecera.Rows[0], null, sesion));

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                }
            }

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.TransferenciaBancaria_Aprobado_a_Cerrado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else {AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarAprobadoACerrado
    }
}
