#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Db;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosRemisionesService : AsientosAutomaticosService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacion<RemisionesService>
        {
            #region Constructor
            public CentrosCostoAplicacion(object caso_cabecera, object caso_detalle, SessionService sesion)
                : base(new RemisionesService())
            {
                var cabecera = (RemisionesService)caso_cabecera;
                var detalles = (RemisionesDetallesService[])caso_detalle;

                Dictionary<decimal, decimal> dCosto = new Dictionary<decimal, decimal>();
                decimal costoTotal = 0;

                if (cabecera.ExisteEnDB)
                {
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        var sm = cabecera.GetPrimero<StockMovimientoService>(new ClaseCBABase.Filtro[] 
                    {
                        new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = cabecera.CasoId.Value },
                        new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.REGISTRO_IDColumnName, Valor = detalles[i].Id.Value },
                        new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.IDColumnName, OrderBy = true, Valor = "desc" },
                    });

                        if (sm != null)
                        {
                            dCosto.Add(detalles[i].Id.Value, sm.Costo);
                            costoTotal += sm.Costo;
                        }
                        else
                        {
                            dCosto.Add(detalles[i].Id.Value, 0);
                        }
                    }
                }

                if (costoTotal > 0)
                {
                    for (int i = 0; i < detalles.Length; i++)
                        this.porcentajeDetalleSobreTotal.Add(detalles[i].Id.Value, dCosto[detalles[i].Id ?? (decimal)i] / costoTotal);
                }
                else
                {
                    for (int i = 0; i < detalles.Length; i++)
                        this.porcentajeDetalleSobreTotal.Add(detalles[i].Id ?? (decimal)i, 100m);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region Constructor
        public AsientosRemisionesService(int asiento_automatico_id)
            : base(asiento_automatico_id){}
        #endregion Constructor

        #region CalcularObservacion
        protected override string CalcularObservacionCabecera(CasosService caso, object cabecera, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(this.EstructuraObservacion);
            var casoCabecera = (RemisionesService)cabecera;

            foreach (string campo in eo.Campos)
            {
                switch (campo)
                {
                    case EstructuraObservacionHelper.Campo.CasoId:
                        eo.Set(campo, casoCabecera.CasoId);
                        break;
                    case EstructuraObservacionHelper.Campo.CasoNroComprobante:
                        eo.Set(campo, caso.NroComprobante);
                        break;
                    case EstructuraObservacionHelper.Campo.Sucursal:
                        eo.Set(campo, caso.Sucursal.Nombre);
                        break;
                    case EstructuraObservacionHelper.Campo.Deposito:
                        eo.Set(campo, casoCabecera.DepositoId);
                        break;
                    case EstructuraObservacionHelper.Campo.Persona:
                        eo.Set(campo, caso.Persona.NombreCompleto);
                        break;
                    case EstructuraObservacionHelper.Campo.Proveedor:
                        eo.Set(campo, caso.Proveedor.RazonSocial);
                        break;
                    case EstructuraObservacionHelper.Campo.FuncionarioCabecera:
                        eo.Set(campo, caso.Funcionario.Persona.NombreCompleto);
                        break;
                    case EstructuraObservacionHelper.Campo.ObservacionCabecera:
                        eo.Set(campo, casoCabecera.Observacion);
                        break;
                    default:
                        throw new Exception("Campo no implementado");
                }
            }

            return eo.observacion.Length > 0 ? eo.observacion : this.Nombre;
        }
        #endregion CalcularObservacion

        #region AsentarPendienteAAprobado
        /// <summary>
        /// Asentars the pendiente A aprobado.
        /// - Debe en (Egreso) Costo de venta (por costo)
        /// - Haber en (Activo) Mercaderias (por costo)
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarPendienteAAprobado(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Detalles
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (RemisionesService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (RemisionesDetallesService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaCompra(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.Fecha, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if(casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.CasoId);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, CalcularObservacionCabecera(casoCabecera.Caso, casoCabecera, sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                AsientosAutomaticosDetalleService asientoAutomaticoDetalle = new AsientosAutomaticosDetalleService((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], sesion);

                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.Remisiones_Pendiente_a_Aprobado.Egreso_AumentarCostoDeVenta:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            if (casoCabecera.FuncionarioId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            else if (casoCabecera.FuncionarioChoferId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioChoferId);
                            else if (casoCabecera.FuncionarioAcompanhante1Id.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioAcompanhante1Id);
                            else if (casoCabecera.FuncionarioAcompanhante2Id.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioAcompanhante2Id);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorEntregaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            StockService.Costo costoPPP = new StockService.Costo();
                            string where = StockMovimientoService.Modelo.CASO_IDColumnName + "=" + casoCabecera.CasoId;
                            where += " and " + StockMovimientoService.Modelo.REGISTRO_IDColumnName + "=" + casoDetalles[j].Id.Value;
                            STOCK_MOVIMIENTOSRow[] movimientos = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(where, StockMovimientoService.Modelo.IDColumnName + " DESC");

                            if (movimientos.Length > 0)
                            {
                                StockMovimientoService sm = new StockMovimientoService(movimientos[0].ID, sesion);
                                costoPPP = sm.GetCostoPPP(sesion);

                            }

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].Articulo.CodigoEmpresa + " - ";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            detalles.Agregar(cuentaAux, costoPPP.costo, 0, monedaPais, cotizacionMonedaPais, costoPPP.moneda_id, costoPPP.cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.Remisiones_Pendiente_a_Aprobado.Activo_DisminuirMercaderias:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            if (casoCabecera.FuncionarioId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            else if (casoCabecera.FuncionarioChoferId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioChoferId);
                            else if (casoCabecera.FuncionarioAcompanhante1Id.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioAcompanhante1Id);
                            else if (casoCabecera.FuncionarioAcompanhante2Id.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioAcompanhante2Id);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorEntregaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            StockService.Costo costoPPP = new StockService.Costo();
                            string where = StockMovimientoService.Modelo.CASO_IDColumnName + "=" + casoCabecera.CasoId;
                            where += " and " + StockMovimientoService.Modelo.REGISTRO_IDColumnName + "=" + casoDetalles[j].Id.Value;
                            STOCK_MOVIMIENTOSRow[] movimientos = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(where, StockMovimientoService.Modelo.IDColumnName + " DESC");

                            if (movimientos.Length > 0)
                            {
                                StockMovimientoService sm = new StockMovimientoService(movimientos[0].ID, sesion);
                                costoPPP = sm.GetCostoPPP(sesion);

                            }

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].Articulo.CodigoEmpresa + " - ";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            detalles.Agregar(cuentaAux, 0, costoPPP.costo, monedaPais, cotizacionMonedaPais, costoPPP.moneda_id, costoPPP.cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                }
            }

            casoCabecera.FinalizarUsingSesion();

            if (this.UnificarDetallesMismaCuenta == Definiciones.SiNo.Si)
                EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarPendienteAAprobado

        #region AsentarAprobadoAAnulado
        /// <summary>
        /// Asentars the aprobado A anulado.
        /// - Debe en (Egreso) Costo de venta (por costo)
        /// - Haber en (Activo) Mercaderias (por costo)
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarAprobadoAAnulado(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Detalles
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (RemisionesService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (RemisionesDetallesService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaCompra(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.Fecha, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if (casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.CasoId);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, CalcularObservacionCabecera(casoCabecera.Caso, casoCabecera, sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                AsientosAutomaticosDetalleService asientoAutomaticoDetalle = new AsientosAutomaticosDetalleService((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], sesion);

                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.Remisiones_Aprobado_a_Anulado.Egreso_DisminuirCostoDeVenta:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            if (casoCabecera.FuncionarioId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            else if (casoCabecera.FuncionarioChoferId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioChoferId);
                            else if (casoCabecera.FuncionarioAcompanhante1Id.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioAcompanhante1Id);
                            else if (casoCabecera.FuncionarioAcompanhante2Id.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioAcompanhante2Id);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorEntregaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            StockService.Costo costoPPP = new StockService.Costo();
                            string where = StockMovimientoService.Modelo.CASO_IDColumnName + "=" + casoCabecera.CasoId;
                            where += " and " + StockMovimientoService.Modelo.REGISTRO_IDColumnName + "=" + casoDetalles[j].Id.Value;
                            STOCK_MOVIMIENTOSRow[] movimientos = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(where, StockMovimientoService.Modelo.IDColumnName + " DESC");

                            if (movimientos.Length > 0)
                            {
                                StockMovimientoService sm = new StockMovimientoService(movimientos[0].ID, sesion);
                                costoPPP = sm.GetCostoPPP(sesion);

                            }

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].Articulo.CodigoEmpresa + " - ";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            detalles.Agregar(cuentaAux, 0, costoPPP.costo, monedaPais, cotizacionMonedaPais, costoPPP.moneda_id, costoPPP.cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.Remisiones_Aprobado_a_Anulado.Activo_AumentarMercaderias:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            if (casoCabecera.FuncionarioId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            else if (casoCabecera.FuncionarioChoferId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioChoferId);
                            else if (casoCabecera.FuncionarioAcompanhante1Id.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioAcompanhante1Id);
                            else if (casoCabecera.FuncionarioAcompanhante2Id.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioAcompanhante2Id);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorEntregaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            StockService.Costo costoPPP = new StockService.Costo();
                            string where = StockMovimientoService.Modelo.CASO_IDColumnName + "=" + casoCabecera.CasoId;
                            where += " and " + StockMovimientoService.Modelo.REGISTRO_IDColumnName + "=" + casoDetalles[j].Id.Value;
                            STOCK_MOVIMIENTOSRow[] movimientos = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(where, StockMovimientoService.Modelo.IDColumnName + " DESC");

                            if (movimientos.Length > 0)
                            {
                                StockMovimientoService sm = new StockMovimientoService(movimientos[0].ID, sesion);
                                costoPPP = sm.GetCostoPPP(sesion);

                            }

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].Articulo.CodigoEmpresa + " - ";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            detalles.Agregar(cuentaAux, costoPPP.costo, 0, monedaPais, cotizacionMonedaPais, costoPPP.moneda_id, costoPPP.cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                }
            }

            casoCabecera.FinalizarUsingSesion();

            if (this.UnificarDetallesMismaCuenta == Definiciones.SiNo.Si)
                EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarAprobadoAAnulado
    }
}
