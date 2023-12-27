﻿#region Using
using System.Collections;
using CBA.FlowV2.Services.Base;
using System;
using System.Data;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosStockTransferenciasService : AsientosAutomaticosService
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
                    decimal detalleId = (decimal)dtDetalles.Rows[i][StockTransferenciaDetalleService.Id_NombreCol];
                    decimal porcentaje = ((decimal)dtDetalles.Rows[i][StockTransferenciaDetalleService.MontoCosto_NombreCol] / (decimal)dtDetalles.Rows[i][StockTransferenciaDetalleService.CotizacionMoneda_NombreCol] ) /
                                         ((decimal)dtCabecera.Rows[0][StockTransferenciasService.TotalCosto_NombreCol] / (decimal)dtCabecera.Rows[0][StockTransferenciasService.Cotizacion_NombreCol]);
                    this.porcentajeDetalleSobreTotal.Add(detalleId, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region CalcularObservacion
        //Se cambio a metodo static para no cambiar el metodo AsentarPendienteAAprobado que tambien es static
        private static string CalcularObservacionDetalles(AsientosAutomaticosDetalleService asiento_automatico_detalle, CasosService caso, StockTransferenciasService casoCabecera, StockTransferenciaDetalleService casoDetalle, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(asiento_automatico_detalle.EstructuraObservacion);

            foreach (string campo in eo.Campos)
            {
                switch (campo)
                {
                    case EstructuraObservacionHelper.Campo.CasoId:
                        eo.Set(campo, casoCabecera.CasoId);
                        break;
                    case EstructuraObservacionHelper.Campo.CasoNroComprobante:
                        eo.Set(campo, casoCabecera.Comprobante);
                        break;
                    case EstructuraObservacionHelper.Campo.Sucursal:
                        eo.Set(campo, caso.Sucursal.Nombre);
                        break;
                    case EstructuraObservacionHelper.Campo.DepositoOrigen:
                        eo.Set(campo, casoCabecera.DepositoOrigen.Nombre);
                        break;
                    case EstructuraObservacionHelper.Campo.DepositoDestino:
                        eo.Set(campo, casoCabecera.DepositoDestino.Nombre);
                        break;
                    case EstructuraObservacionHelper.Campo.FuncionarioCabecera:
                        eo.Set(campo, caso.FuncionarioId.HasValue ? caso.Funcionario.Persona.NombreCompleto : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.ArticuloCodigo:
                        eo.Set(campo, casoDetalle.Lote.Articulo.CodigoEmpresa);
                        break;
                    case EstructuraObservacionHelper.Campo.ArticuloDescripcion:
                        eo.Set(campo, casoDetalle.Lote.Articulo.DescripcionInterna);
                        break;
                    case EstructuraObservacionHelper.Campo.Lote:
                        eo.Set(campo, casoDetalle.Lote.Lote);
                        break;
                    case EstructuraObservacionHelper.Campo.ObservacionCabecera:
                        eo.Set(campo, casoCabecera.Observacion);
                        break;
                    case EstructuraObservacionHelper.Campo.Cantidad:
                        eo.Set(campo, casoDetalle.CantidadDestUnitaria);
                        break;
                    default:
                        throw new Exception("Campo no implementado");
                }
            }

            return eo.observacion.Length > 0 ? eo.observacion : asiento_automatico_detalle.Descripcion;
        }
        #endregion CalcularObservacion

        #region AsentarAprobadoAViajando
        /// <summary>
        /// Asentars the aprobado A viajando.
        /// Transicion APROBADO a VIAJANDO
        /// - Debe en mercaderias en transito
        /// - Haber en mercaderias
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public static decimal AsentarAprobadoAViajando(CasosService caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            DateTime fechaDeAsiento;
            DataTable dtCabecera = StockTransferenciasService.GetStockTranferenciaInfoCompleta(StockTransferenciasService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
            DataTable dtDetalles = StockTransferenciaDetalleService.GetStocTransferenciaDetalleInfoCompleta(StockTransferenciaDetalleService.TransferenciaStockId_NombreCol + " = " + dtCabecera.Rows[0][StockTransferenciasService.Id_NombreCol], string.Empty, sesion);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(dtCabecera, dtDetalles, new StockTransferenciasService(), sesion);
            
            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][StockTransferenciasService.Fecha_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.StockTransferencia_Aprobado_a_Viajando,
                                                                                             caso,
                                                                                             string.Empty, 
                                                                                             sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            StockTransferenciasService casoCabecera = new StockTransferenciasService(decimal.Parse(dtCabecera.Rows[0][StockTransferenciasService.Id_NombreCol].ToString()));
            casoCabecera.IniciarUsingSesion(sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                AsientosAutomaticosDetalleService asientoAutomaticoDetalle = new AsientosAutomaticosDetalleService((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], sesion);

                switch(int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.StockTransferencia_Aprobado_a_Viajando.Activo_AumentarMercaderiaEnTransito:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            StockTransferenciaDetalleService casoDetalles = new StockTransferenciaDetalleService(decimal.Parse(dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol].ToString()));

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloFamiliaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloGrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]));
                            if (!dtCabecera.Rows[0][StockTransferenciasService.ChoferId_NombreCol].Equals(DBNull.Value))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.ChoferId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.DepositoOrigen_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.SucursalOrigenId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.ProveedorId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.TextoPredefinidoId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.MontoCosto_NombreCol] * (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CantidadDestinoUnitariaTotal_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloCodigo_NombreCol] + " " + dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaNombreArticulo_NombreCol] + " (" + dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaLote_NombreCol] + ")" + ". " + dtDetalles.Rows[j][StockTransferenciaDetalleService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalles(asientoAutomaticoDetalle, caso, casoCabecera, casoDetalles, sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CostoMonedaId_NombreCol], (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                     case Definiciones.Contabilidad.AsientosAutomaticosDetalle.StockTransferencia_Aprobado_a_Viajando.Activo_DisminuirMercaderiaSaliente:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            StockTransferenciaDetalleService casoDetalles = new StockTransferenciaDetalleService(decimal.Parse(dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol].ToString()));

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloFamiliaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloGrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]));
                            if (!dtCabecera.Rows[0][StockTransferenciasService.ChoferId_NombreCol].Equals(DBNull.Value))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.ChoferId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.DepositoOrigen_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.SucursalOrigenId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.ProveedorId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.TextoPredefinidoId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.MontoCosto_NombreCol] * (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CantidadDestinoUnitariaTotal_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloCodigo_NombreCol] + " " + dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaNombreArticulo_NombreCol] + " (" + dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaLote_NombreCol] + ")" + ". " + dtDetalles.Rows[j][StockTransferenciaDetalleService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalles(asientoAutomaticoDetalle, caso, casoCabecera, casoDetalles, sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CostoMonedaId_NombreCol], (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol],
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

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.StockTransferencia_Aprobado_a_Viajando, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else {AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarAprobadoAViajando

        #region AsentarEnRevisionACerrado
        /// <summary>
        /// Asentars the en revision A cerrado.
        /// Transicion EN-REVISION a CERRADO
        /// - Debe en mercaderias
        /// - Haber en mercaderias en transito
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public static decimal AsentarEnRevisionACerrado(CasosService caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            DateTime fechaDeAsiento;
            DataTable dtCabecera = StockTransferenciasService.GetStockTranferenciaInfoCompleta(StockTransferenciasService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
            DataTable dtDetalles = StockTransferenciaDetalleService.GetStocTransferenciaDetalleInfoCompleta(StockTransferenciaDetalleService.TransferenciaStockId_NombreCol + " = " + dtCabecera.Rows[0][StockTransferenciasService.Id_NombreCol], string.Empty, sesion);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(dtCabecera, dtDetalles, new StockTransferenciasService(), sesion);
            
            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][StockTransferenciasService.Fecha_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.StockTransferencia_EnRevision_a_Cerrado,
                                                                                             caso,
                                                                                             string.Empty,
                                                                                             sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, caso.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            StockTransferenciasService casoCabecera = new StockTransferenciasService(decimal.Parse(dtCabecera.Rows[0][StockTransferenciasService.Id_NombreCol].ToString()));
            casoCabecera.IniciarUsingSesion(sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                AsientosAutomaticosDetalleService asientoAutomaticoDetalle = new AsientosAutomaticosDetalleService((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], sesion);

                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.StockTransferencia_EnRevision_a_Cerrado.Activo_AumentarMercaderiaEntrante:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            StockTransferenciaDetalleService casoDetalles = new StockTransferenciaDetalleService(decimal.Parse(dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol].ToString()));

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloFamiliaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloGrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]));
                            if (!dtCabecera.Rows[0][StockTransferenciasService.ChoferId_NombreCol].Equals(DBNull.Value))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.ChoferId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.ProveedorId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.DepositoOrigen_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.SucursalOrigenId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.TextoPredefinidoId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.MontoCosto_NombreCol] * (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CantidadDestinoUnitariaTotal_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloCodigo_NombreCol] + " " + dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaNombreArticulo_NombreCol] + " (" + dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaLote_NombreCol] + ")" + ". " + dtDetalles.Rows[j][StockTransferenciaDetalleService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalles(asientoAutomaticoDetalle, caso, casoCabecera, casoDetalles, sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CostoMonedaId_NombreCol], (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.StockTransferencia_EnRevision_a_Cerrado.Activo_DisminuirMercaderiaEnTransito:
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            StockTransferenciaDetalleService casoDetalles = new StockTransferenciaDetalleService(decimal.Parse(dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol].ToString()));

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloFamiliaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloGrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.ArticuloId_NombreCol]));
                            if (!dtCabecera.Rows[0][StockTransferenciasService.ChoferId_NombreCol].Equals(DBNull.Value))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.ChoferId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.ProveedorId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.DepositoOrigen_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.SucursalOrigenId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][StockTransferenciasService.TextoPredefinidoId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.MontoCosto_NombreCol] * (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CantidadDestinoUnitariaTotal_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaArticuloCodigo_NombreCol] + " " + dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaNombreArticulo_NombreCol] + " (" + dtDetalles.Rows[j][StockTransferenciaDetalleService.VistaLote_NombreCol] + ")" + ". " + dtDetalles.Rows[j][StockTransferenciaDetalleService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalles(asientoAutomaticoDetalle, caso, casoCabecera, casoDetalles, sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CostoMonedaId_NombreCol], (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][StockTransferenciaDetalleService.Id_NombreCol],
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

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.StockTransferencia_EnRevision_a_Cerrado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else {AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarEnRevisionACerrado
    }
}
