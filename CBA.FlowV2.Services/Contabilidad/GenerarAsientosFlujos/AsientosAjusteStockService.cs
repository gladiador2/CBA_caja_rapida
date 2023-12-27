#region Using
using System.Collections;
using CBA.FlowV2.Services.Base;
using System;
using System.Data;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosAjusteStockService : AsientosAutomaticosService
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
                    decimal detalleId = (decimal)dtDetalles.Rows[i][StockAjusteDetalleService.Id_NombreCol];
                    decimal porcentaje = 1;

                    if ((decimal)dtCabecera.Rows[0][StockAjusteService.CostoTotal_NombreCol] != 0)
                    {
                        porcentaje = ((decimal)dtDetalles.Rows[i][StockAjusteDetalleService.CostoTotal_NombreCol] / (decimal)dtDetalles.Rows[i][StockAjusteDetalleService.Cotizacion_NombreCol]) /
                                     ((decimal)dtCabecera.Rows[0][StockAjusteService.CostoTotal_NombreCol] / (decimal)dtCabecera.Rows[0][StockAjusteService.Cotizacion_NombreCol]);
                    }
                    this.porcentajeDetalleSobreTotal.Add(detalleId, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region CalcularObservacion
        //Se cambio a metodo static para no cambiar el metodo AsentarPendienteAAprobado que tambien es static
        private static string CalcularObservacionDetalles(AsientosAutomaticosDetalleService asiento_automatico_detalle, CasosService caso, StockAjusteService casoCabecera, StockAjusteDetalleService casoDetalle, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(asiento_automatico_detalle.EstructuraObservacion);
            
            foreach (string campo in eo.Campos)
            {
                switch (campo)
                {
                    case EstructuraObservacionHelper.Campo.CasoId:
                        eo.Set(campo, casoCabecera.CasoId);
                        break;
                    case EstructuraObservacionHelper.Campo.Sucursal:
                        eo.Set(campo, caso.Sucursal.Nombre);
                        break;
                    case EstructuraObservacionHelper.Campo.Deposito:
                        eo.Set(campo, casoCabecera.Deposito.Nombre);
                        break;
                   case EstructuraObservacionHelper.Campo.FuncionarioCabecera:
                        eo.Set(campo, caso.FuncionarioId.HasValue ? caso.Funcionario.Persona.NombreCompleto : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.ArticuloCodigo:
                        eo.Set(campo, casoDetalle.Articulo.CodigoEmpresa);
                        break;
                    case EstructuraObservacionHelper.Campo.ArticuloDescripcion:
                        eo.Set(campo, casoDetalle.Articulo.DescripcionInterna);
                        break;
                    case EstructuraObservacionHelper.Campo.ObservacionCabecera:
                        eo.Set(campo, casoCabecera.Observacion);
                        break;
                    case EstructuraObservacionHelper.Campo.ObservacionDetalle:
                        eo.Set(campo, casoDetalle.Observacion);
                        break;
                    case EstructuraObservacionHelper.Campo.Cantidad:
                        eo.Set(campo, casoDetalle.CantidadDestino);
                        break;
                    default:
                        throw new Exception("Campo no implementado");
                }
            }

            return eo.observacion.Length > 0 ? eo.observacion : asiento_automatico_detalle.Descripcion;
        }
        #endregion CalcularObservacion

        #region AsientosAjusteStockService
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
            DataTable dtCabecera = StockAjusteService.GetStockAjusteInfoCompleta(StockAjusteService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
            DataTable dtDetalles = StockAjusteDetalleService.GetStockAjusteDetalleInfoCompleta(StockAjusteDetalleService.StockAjusteId_NombreCol + " = " + dtCabecera.Rows[0][StockAjusteService.Id_NombreCol], StockAjusteDetalleService.Id_NombreCol, sesion);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux, montoImpuesto;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(dtCabecera, dtDetalles, new StockAjusteService(), sesion);
            
            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][StockAjusteService.Fecha_Creacion_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.AjusteStock_Pendiente_a_Aprobado,
                                                                                             caso,
                                                                                             Interprete.ObtenerString(dtCabecera.Rows[0][StockAjusteService.Observacion_NombreCol]),
                                                                                             sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            StockAjusteService casoCabecera = new StockAjusteService(decimal.Parse(dtCabecera.Rows[0][StockAjusteService.Id_NombreCol].ToString()));
            casoCabecera.IniciarUsingSesion(sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                AsientosAutomaticosDetalleService asientoAutomaticoDetalle = new AsientosAutomaticosDetalleService((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], sesion);
                
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AjusteStock_Pendiente_a_Aprobado.Egreso_AumentarEgresoPorAjusteNegativo:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            StockAjusteDetalleService casoDetalles = new StockAjusteDetalleService(decimal.Parse(dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol].ToString()));

                            //Solo se incluyen detalles de ajuste negativo
                            if ((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.CantidadDestino_NombreCol] >= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloFamiliaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloGrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][StockAjusteService.DepositoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][StockAjusteService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.CostoTotal_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido && !Interprete.EsNullODBNull(dtDetalles.Rows[j][StockAjusteDetalleService.Observacion_NombreCol]))
                                observacion = (string)dtDetalles.Rows[j][StockAjusteDetalleService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalles(asientoAutomaticoDetalle, caso, casoCabecera, casoDetalles, sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AjusteStock_Pendiente_a_Aprobado.Activo_DisminuirMercaderiasPorAjusteNegativo:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            StockAjusteDetalleService casoDetalles = new StockAjusteDetalleService(decimal.Parse(dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol].ToString()));

                            //Solo se incluyen detalles de ajuste negativo
                            if ((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.CantidadDestino_NombreCol] >= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloFamiliaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloGrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][StockAjusteService.DepositoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][StockAjusteService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.CostoTotal_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido && !Interprete.EsNullODBNull(dtDetalles.Rows[j][StockAjusteDetalleService.Observacion_NombreCol]))
                                observacion = (string)dtDetalles.Rows[j][StockAjusteDetalleService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalles(asientoAutomaticoDetalle, caso, casoCabecera, casoDetalles, sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AjusteStock_Pendiente_a_Aprobado.Activo_AumentarMercaderiasPorAjustePositivo:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            StockAjusteDetalleService casoDetalles = new StockAjusteDetalleService(decimal.Parse(dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol].ToString()));

                            //Solo se incluyen detalles de ajuste positivo
                            if ((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.CantidadDestino_NombreCol] <= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloFamiliaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloGrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol])); 
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][StockAjusteService.DepositoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][StockAjusteService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.CostoTotal_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido && !Interprete.EsNullODBNull(dtDetalles.Rows[j][StockAjusteDetalleService.Observacion_NombreCol]))
                                observacion = (string)dtDetalles.Rows[j][StockAjusteDetalleService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalles(asientoAutomaticoDetalle, caso, casoCabecera, casoDetalles, sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.AjusteStock_Pendiente_a_Aprobado.Ingreso_AumentarEgresoPorAjustePositivo:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            StockAjusteDetalleService casoDetalles = new StockAjusteDetalleService(decimal.Parse(dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol].ToString()));

                            //Solo se incluyen detalles de ajuste positivo
                            if ((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.CantidadDestino_NombreCol] <= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloFamiliaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloGrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.ArticuloId_NombreCol])); 
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][StockAjusteDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][StockAjusteService.DepositoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][StockAjusteService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.CostoTotal_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido && !Interprete.EsNullODBNull(dtDetalles.Rows[j][StockAjusteDetalleService.Observacion_NombreCol]))
                                observacion = (string)dtDetalles.Rows[j][StockAjusteDetalleService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalles(asientoAutomaticoDetalle, caso, casoCabecera, casoDetalles, sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Cotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][StockAjusteDetalleService.Id_NombreCol],
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

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.AjusteStock_Pendiente_a_Aprobado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsientosAjusteStockService
    }
}
