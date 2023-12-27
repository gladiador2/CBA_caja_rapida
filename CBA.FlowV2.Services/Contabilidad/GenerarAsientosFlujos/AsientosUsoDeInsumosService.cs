#region Using
using System.Collections;
using CBA.FlowV2.Services.Base;
using System;
using System.Data;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosUsoDeInsumosService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacion(DataTable dtCabecera, DataTable dtDetalles, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                decimal suma = 0;
                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    suma += (decimal)dtDetalles.Rows[i][UsoDeInsumosDetalleService.Modelo.COSTO_TOTALColumnName];

                for (int i = 0; i < dtDetalles.Rows.Count; i++)
                {
                    decimal detalleId = (decimal)dtDetalles.Rows[i][UsoDeInsumosDetalleService.Modelo.IDColumnName];
                    decimal porcentaje = (decimal)dtDetalles.Rows[i][UsoDeInsumosDetalleService.Modelo.COSTO_TOTALColumnName] / suma;
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
            DataTable dtCabecera = UsoDeInsumosService.GetUsoDeInsumosInfoCompleta(UsoDeInsumosService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
            DataTable dtDetalles = UsoDeInsumosDetalleService.GetUsoDeInsumosDetalleInfoCompleta(UsoDeInsumosDetalleService.Modelo.USO_DE_INSUMO_IDColumnName + " = " + dtCabecera.Rows[0][UsoDeInsumosService.Id_NombreCol], string.Empty, sesion);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(dtCabecera, dtDetalles, new UsoDeInsumosService(), sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][UsoDeInsumosService.Fecha_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.UsoDeInsumos_Pendiente_a_Aprobado,
                                                                                             caso,
                                                                                             string.Empty,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.UsoDeInsumos_Pendiente_a_Aprobado.Egreso_AumentarEgresoPorUsoDeInsumos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_FAMILIA_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_GRUPO_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_SUBGRUPO_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_IDColumnName]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_IDColumnName]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.COSTO_MONEDA_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][UsoDeInsumosService.DepositoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][UsoDeInsumosService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][UsoDeInsumosService.FuncionarioId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.COSTO_TOTALColumnName];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_DESCRIPCIONColumnName] + " " + dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.OBSERVACIONColumnName];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.COSTO_MONEDA_IDColumnName], (decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.COSTO_MONEDA_COTIZACIONColumnName], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.IDColumnName], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.IDColumnName],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.UsoDeInsumos_Pendiente_a_Aprobado.Activo_DisminuirMercaderiasPorUsoDeInsumos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_FAMILIA_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_GRUPO_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_SUBGRUPO_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_IDColumnName]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_IDColumnName]));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.COSTO_MONEDA_IDColumnName]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, dtCabecera.Rows[0][UsoDeInsumosService.DepositoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][UsoDeInsumosService.SucursalId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, dtCabecera.Rows[0][UsoDeInsumosService.FuncionarioId_NombreCol]);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.COSTO_TOTALColumnName];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)dtDetalles.Rows[j][UsoDeInsumosDetalleService.ModeloVista.ARTICULO_DESCRIPCIONColumnName] + " " + dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.OBSERVACIONColumnName];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.COSTO_MONEDA_IDColumnName], (decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.COSTO_MONEDA_COTIZACIONColumnName], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.IDColumnName], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][UsoDeInsumosDetalleService.Modelo.IDColumnName],
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

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.UsoDeInsumos_Pendiente_a_Aprobado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarPendienteAAprobado
    }
}
