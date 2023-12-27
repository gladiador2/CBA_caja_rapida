#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.EgresosVariosCaja;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Db;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosEgresoVarioCajaService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacionDetalles : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacionDetalles(DataTable dtCabecera, DataTable dtDetalles, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    decimal detalleId = (decimal)dtDetalles.Rows[i][EgresosVariosCajaDetalleService.Id_NombreCol];
                    decimal porcentaje = (decimal)dtDetalles.Rows[i][EgresosVariosCajaDetalleService.MontoDestino_NombreCol] /
                                         (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.MontoTotal_NombreCol];
                    this.porcentajeDetalleSobreTotal.Add(detalleId, porcentaje);
                }
            }
            #endregion Constructor
        }

        private class CentrosCostoAplicacionValores : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacionValores(DataTable dtCabecera, DataTable dtValores, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                for (int i = 0; i < dtValores.Rows.Count; i++)
                {
                    decimal detalleId = (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.Id_NombreCol];
                    decimal porcentaje = (decimal)dtValores.Rows[i][EgresosVariosCajaValoresService.MontoDestino_NombreCol] /
                                         (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.MontoTotal_NombreCol];
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
            DataTable dtCabecera = EgresosVariosCajaService.GetEgresosVariosCajaDataTable(EgresosVariosCajaService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
            DataTable dtDetalles = EgresosVariosCajaDetalleService.GetEgresosVariosCajaDetallesInfoCompleta(EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol + " = " + dtCabecera.Rows[0][EgresosVariosCajaService.Id_NombreCol], string.Empty, sesion);
            DataTable dtValores = EgresosVariosCajaValoresService.GetInfoCompleta(EgresosVariosCajaValoresService.EgresoVarioCajaId_NombreCol + " = " + dtCabecera.Rows[0][EgresosVariosCajaService.Id_NombreCol], string.Empty, sesion);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacionDetalles centrosCostoApDetalles = new CentrosCostoAplicacionDetalles(dtCabecera, dtDetalles, new EgresosVariosCajaService(), sesion);
            CentrosCostoAplicacionValores centrosCostoApValores = new CentrosCostoAplicacionValores(dtCabecera, dtValores, new EgresosVariosCajaService(), sesion);
            
            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][EgresosVariosCajaService.Fecha_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.EgresoVarioCaja_Pendiente_a_Aprobado,
                                                                                             caso,
                                                                                             Interprete.ObtenerString(dtCabecera.Rows[0][EgresosVariosCajaService.Observacion_NombreCol]),
                                                                                             sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion); 
            
            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                dtDetalles = EgresosVariosCajaDetalleService.GetEgresosVariosCajaDetallesInfoCompleta(EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol + " = " + dtCabecera.Rows[0][EgresosVariosCajaService.Id_NombreCol], string.Empty, sesion);
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.EgresoVarioCaja_Pendiente_a_Aprobado.Pasivo_DisminuirProveedoresNacionales:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            if (Interprete.EsNullODBNull(dtDetalles.Rows[j][EgresosVariosCajaDetalleService.ProveedorId_NombreCol]))
                                continue;

                            //Solo se incluyen detalles de proveedores nacionales
                            if (!ProveedoresService.EsNacional((decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.ProveedorId_NombreCol], sesion))
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.CtacteFondoFijoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtDetalles.Rows[j][EgresosVariosCajaDetalleService.ProveedorId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            decimal casoReferido = (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol];
                            CASOSRow casoRow = CasosService.GetCasoPorId(casoReferido);

                            DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoReferido, string.Empty);
                            decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(factProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol].ToString()));

                            montoAux = (decimal)dtDetalles.Rows[j][EgresosVariosCajaValoresService.MontoDestino_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = ClaseCBABase.GetStringHelper(dtDetalles.Rows[j][EgresosVariosCajaValoresService.Observacion_NombreCol]);
                                if (!Interprete.EsNullODBNull(dtDetalles.Rows[j][EgresosVariosCajaValoresService.Observacion_NombreCol]))
                                    observacion += ". " + dtDetalles.Rows[j][EgresosVariosCajaValoresService.Observacion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionVenta, (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol], (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApDetalles, (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Id_NombreCol], 100,
                                             centrosCostoApDetalles.Seleccionar((decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion), (decimal)factProveedor.Rows[0][FacturasProveedorService.ProveedorId_NombreCol], Definiciones.Tablas.Proveedores);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDetalles, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.EgresoVarioCaja_Pendiente_a_Aprobado.Pasivo_DisminuirProveedoresExtranjeros:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            if (Interprete.EsNullODBNull(dtDetalles.Rows[j][EgresosVariosCajaDetalleService.ProveedorId_NombreCol]))
                                continue;

                            //Solo se incluyen detalles de proveedores nacionales
                            if (ProveedoresService.EsNacional((decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.ProveedorId_NombreCol], sesion))
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.CtacteFondoFijoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtDetalles.Rows[j][EgresosVariosCajaDetalleService.ProveedorId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            decimal casoReferido = (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol];
                            CASOSRow casoRow = CasosService.GetCasoPorId(casoReferido);

                            DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoReferido, string.Empty);
                            decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(factProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol].ToString()));

                            montoAux = (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.MontoDestino_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = (string)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.VistaCtacteObservacion_NombreCol];
                                if (!Interprete.EsNullODBNull(dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Observacion_NombreCol]))
                                    observacion += ". " + dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Observacion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionVenta, (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol], (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApDetalles, (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Id_NombreCol], 100,
                                             centrosCostoApDetalles.Seleccionar((decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion), (decimal)factProveedor.Rows[0][FacturasProveedorService.ProveedorId_NombreCol], Definiciones.Tablas.Proveedores);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDetalles, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.EgresoVarioCaja_Pendiente_a_Aprobado.Activo_AumentarClientesPorPagoAPersona:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        DataRow[] detallesSinCreditos = dtDetalles.Select(EgresosVariosCajaDetalleService.VistaFlujoId_NombreCol + " <> " + Definiciones.FlujosIDs.CREDITOS);
                        if (detallesSinCreditos.Length > 0)
                            dtDetalles = detallesSinCreditos.CopyToDataTable();
                        else
                            continue;

                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            if (Interprete.EsNullODBNull(dtDetalles.Rows[j][EgresosVariosCajaDetalleService.PersonaId_NombreCol]))
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.CtacteFondoFijoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtDetalles.Rows[j][EgresosVariosCajaDetalleService.PersonaId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.MontoDestino_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = (string)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.VistaCtacteObservacion_NombreCol];
                                if (!Interprete.EsNullODBNull(dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Observacion_NombreCol]))
                                    observacion += ". " + dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Observacion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol], (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApDetalles, (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Id_NombreCol], 100,
                                             centrosCostoApDetalles.Seleccionar((decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion), (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.PersonaId_NombreCol], Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDetalles, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.EgresoVarioCaja_Pendiente_a_Aprobado.Activo_AumentarCreditoPorPagoAPersona:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        DataRow[] detallesConCreditos = dtDetalles.Select(EgresosVariosCajaDetalleService.VistaFlujoId_NombreCol + " = " + Definiciones.FlujosIDs.CREDITOS);
                        if (detallesConCreditos.Length > 0)
                            dtDetalles = detallesConCreditos.CopyToDataTable();
                        else
                            continue;

                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            if (Interprete.EsNullODBNull(dtDetalles.Rows[j][EgresosVariosCajaDetalleService.PersonaId_NombreCol]))
                                continue;

                            var credito = CreditosService.Instancia.GetPrimero<CreditosService>(new ClaseCBABase.Filtro
                            {
                                Columna = CreditosService.Modelo.CASO_IDColumnName,
                                Valor = (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol]
                            });
                            credito.IniciarUsingSesion(sesion);

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.CtacteFondoFijoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtDetalles.Rows[j][EgresosVariosCajaDetalleService.PersonaId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.MontoDestino_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = (string)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.VistaCtacteObservacion_NombreCol];
                                if (!Interprete.EsNullODBNull(dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Observacion_NombreCol]))
                                    observacion += ". " + dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Observacion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol], (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApDetalles, (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Id_NombreCol], 100,
                                             centrosCostoApDetalles.Seleccionar((decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion), (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.PersonaId_NombreCol], Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApDetalles, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.EgresoVarioCaja_Pendiente_a_Aprobado.Activo_DisminuirFondoFijo:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtValores.Rows.Count; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.CtacteFondoFijoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, dtValores.Rows[j][EgresosVariosCajaValoresService.CtacteValorId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtValores.Rows[j][EgresosVariosCajaValoresService.MontoDestino_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol], (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoApValores, (decimal)dtValores.Rows[j][EgresosVariosCajaValoresService.Id_NombreCol], 100,
                                             centrosCostoApValores.Seleccionar((decimal)dtValores.Rows[j][EgresosVariosCajaDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtValores.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApValores, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.EgresoVarioCaja_Pendiente_a_Aprobado.DiferenciaDeCambio:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][EgresosVariosCajaService.SucursalId_NombreCol]);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = 0;

                        for (int j = 0; j < dtValores.Rows.Count; j++)
                        {
                            if ((decimal)dtValores.Rows[j][EgresosVariosCajaValoresService.MonedaOrigenId_NombreCol] == monedaPais)
                            {
                                montoAux += (decimal)dtValores.Rows[j][EgresosVariosCajaValoresService.MontoDestino_NombreCol];
                            }
                            else
                            {
                                montoAux += (decimal)dtValores.Rows[j][EgresosVariosCajaValoresService.MontoDestino_NombreCol] * cotizacionMonedaPais;
                            }

                        }

                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            if ((decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.MonedaOrigenId_NombreCol] == monedaPais)
                            {
                                montoAux -= (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.MontoDestino_NombreCol];
                            }
                            else
                            {
                                decimal casoReferido = (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol];
                                CASOSRow casoRow = CasosService.GetCasoPorId(casoReferido);

                                if (casoRow.FLUJO_ID == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                                {
                                    DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoReferido, string.Empty);
                                    decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(factProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol].ToString()));

                                    montoAux -= (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.MontoDestino_NombreCol] * cotizacionVenta;
                                }
                                else
                                {
                                    montoAux -= (decimal)dtDetalles.Rows[j][EgresosVariosCajaDetalleService.MontoDestino_NombreCol];
                                }
                            }

                        }

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        decimal debe = montoAux < 0 ? 0 : Math.Abs(montoAux);
                        decimal haber = montoAux < 0 ? Math.Abs(montoAux) : 0;

                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, debe, haber, monedaPais, cotizacionMonedaPais, monedaPais, cotizacionMonedaPais, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoApDetalles, (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.Id_NombreCol], 100,
                                         centrosCostoApDetalles.Seleccionar((decimal)dtCabecera.Rows[0][EgresosVariosCajaService.Id_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    caso, dtCabecera.Rows[0], null, sesion));
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoApValores, sesion);

                        break;
                }
            }

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.EgresoVarioCaja_Pendiente_a_Aprobado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarPendienteAAprobado
    }
}
