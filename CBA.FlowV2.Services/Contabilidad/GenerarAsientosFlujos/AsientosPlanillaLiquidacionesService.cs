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
using CBA.FlowV2.Services.RecursosHumanos;
using System.Collections.Generic;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosPlanillaLiquidacionesService : AsientosAutomaticosService
    {
        #region Constructor
        public AsientosPlanillaLiquidacionesService(int asiento_automatico_id)
            : base(asiento_automatico_id) { }
        #endregion Constructor

        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacion(object caso_cabecera, object caso_detalles, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                var cabecera = (PlanillaLiquidacionesService)caso_cabecera;
                var detalles = (PlanillaLiquidacionesDetallesService[])caso_detalles;
                for (int i = 0; i < detalles.Length; i++) 
                {
                    decimal detalleId = (decimal)detalles[i].Id;
                    decimal porcentaje = (decimal)detalles[i].TotalACobrar / (decimal)cabecera.Total;
                    this.porcentajeDetalleSobreTotal.Add(detalleId, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region AsentarPendienteAAprobado
        /// <summary>
        /// Asentars the pendiente A aprobado.
        /// - Aumentar pasivo - pago a funcionarios
        /// - Aumentar egreso - pago a funcionarios
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarPendienteAAprobado(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Detalles,
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (PlanillaLiquidacionesService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (PlanillaLiquidacionesDetallesService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];
            DateTime fechaDeAsiento;
            DataTable dtDetallesCuentas;
            int funcionarioDescuentoIPSId = VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.RrhhDescuentoIPS);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux = Definiciones.Error.Valor.EnteroPositivo;
            decimal montoAux;
            decimal correspondeciaMeses;
            if ((int)casoCabecera.Tipo == Definiciones.TipoLiquidacion.Aguinaldo)
                correspondeciaMeses = 12;
            else
                correspondeciaMeses = 1;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, new PlanillaLiquidacionesService(), sesion);

            //En caso el usuario haya establecido las cuentas afectadas por detalle
            decimal[] cuentasAux, porcentajesAux;

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.FechaHasta, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if (casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.PlanillaLiquidaciones_Pendiente_a_Aprobado,
                                                                                             casoCabecera.Caso,
                                                                                             Interprete.ObtenerString(casoCabecera.Observacion),
                                                                                             sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PlanillaLiquidaciones_Pendiente_a_Aprobado.Pasivo_AumentarPagoFuncionarios:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region asentar por salario base
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol,casoDetalles[j].MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId.Value);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoDetalles[j].FuncionarioId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalSalario;
                            montoAux /= correspondeciaMeses;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = Traducciones.Caso + " " + casoCabecera.CasoId + " " + casoCabecera.Sucursal.Nombre + ". " + casoDetalles[j].Funcionario.Nombre + ".";

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDetalles[j].MonedaId, casoDetalles[j].Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                            #endregion asentar por salario base

                            DataTable dtFuncionariosLiquidacionesDet = FuncionariosLiquidacionesDetallesService.GetLiquidacionesDetallesDataTable(FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol + " = " + casoDetalles[j].LiquidacionId, sesion);
                            for (int k = 0; k < dtFuncionariosLiquidacionesDet.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDetalles[j].MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoDetalles[j].FuncionarioId);

                                if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol] == Definiciones.TipoItemLiquidacion.Bonificacion)
                                {
                                    DataTable dtFuncionarioBonificacion = FuncionariosBonificacionesService.GetFuncionariosBonificacionesDataTable(FuncionariosBonificacionesService.Id_NombreCol + " = " + dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol], string.Empty);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.BonificacionId_NombreCol, dtFuncionarioBonificacion.Rows[0][FuncionariosBonificacionesService.BonificacionId_NombreCol]);
                                }
                                else if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol] == Definiciones.TipoItemLiquidacion.Descuento)
                                {
                                    DataTable dtFuncionarioDescuento = new FuncionariosDescuentosService().GetFuncionariosDescuentosDataTable(FuncionariosDescuentosService.Id_NombreCol + " = " + dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol], string.Empty);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.DescuentoId_NombreCol, dtFuncionarioDescuento.Rows[0][FuncionariosDescuentosService.Id_NombreCol]);
                                }

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.Monto_NombreCol];
                                montoAux /= correspondeciaMeses;

                                //Invertir el monto si es un descuento o cancela parte de la ctacte_personas
                                if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol] == Definiciones.TipoItemLiquidacion.Descuento ||
                                   (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol] == Definiciones.TipoItemLiquidacion.CtaCte)
                                {
                                    montoAux *= -1;
                                }

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = Traducciones.Caso + " " + casoCabecera.CasoId + " " + casoCabecera.Sucursal.Nombre + ". " + casoDetalles[j].Funcionario.Nombre  + ".";

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Si el detalle tiene la misma moneda que la cabecera, utilizar la cotizacion de la cabecera
                                decimal cotizacionOrigen = (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.Cotizacion_NombreCol];
                                if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol] == casoDetalles[j].MonedaId)
                                    cotizacionOrigen = casoDetalles[j].Cotizacion;

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol], cotizacionOrigen, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].FuncionarioId, Definiciones.Tablas.Funcionarios);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PlanillaLiquidaciones_Pendiente_a_Aprobado.Pasivo_AumentarAportesEmpresa:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDetalles[j].MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoDetalles[j].FuncionarioId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalAporteEmpresa;
                            montoAux /= correspondeciaMeses;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = Traducciones.Caso + " " + casoCabecera.CasoId + " " + casoCabecera.Sucursal.Nombre + ". " + casoDetalles[j].Funcionario.Nombre + ".";

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoDetalles[j].MonedaId, casoDetalles[j].Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].FuncionarioId, Definiciones.Tablas.Funcionarios);

                            string clausulas = FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol + " = " + casoDetalles[j].LiquidacionId + " and " +
                                               FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol + " = " + Definiciones.TipoItemLiquidacion.Descuento + " and " +
                                               " exists (select fd." + FuncionariosDescuentosService.Id_NombreCol + " from " + FuncionariosDescuentosService.Nombre_Tabla + " fd where fd." + FuncionariosDescuentosService.Id_NombreCol + " = " + FuncionariosLiquidacionesDetallesService.Nombre_Tabla + "." + FuncionariosLiquidacionesDetallesService.ItemId_NombreCol + " and " +
                                               "     " + FuncionariosDescuentosService.DescuentoId_NombreCol + " = " + funcionarioDescuentoIPSId + " and " +
                                               "     " + FuncionariosDescuentosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "')";
                            DataTable dtFuncionariosLiquidacionesDet = FuncionariosLiquidacionesDetallesService.GetLiquidacionesDetallesDataTable(clausulas, sesion);
                            for (int k = 0; k < dtFuncionariosLiquidacionesDet.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDetalles[j].MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoDetalles[j].FuncionarioId);

                                if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol] == Definiciones.TipoItemLiquidacion.Bonificacion)
                                {
                                    DataTable dtFuncionarioBonificacion = FuncionariosBonificacionesService.GetFuncionariosBonificacionesDataTable(FuncionariosBonificacionesService.Id_NombreCol + " = " + dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol], string.Empty);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.BonificacionId_NombreCol, dtFuncionarioBonificacion.Rows[0][FuncionariosBonificacionesService.BonificacionId_NombreCol]);
                                }
                                else if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol] == Definiciones.TipoItemLiquidacion.Descuento)
                                {
                                    DataTable dtFuncionarioDescuento = new FuncionariosDescuentosService().GetFuncionariosDescuentosDataTable(FuncionariosDescuentosService.Id_NombreCol + " = " + dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol], string.Empty);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.DescuentoId_NombreCol, dtFuncionarioDescuento.Rows[0][FuncionariosDescuentosService.Id_NombreCol]);
                                }

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.Monto_NombreCol];
                                montoAux /= correspondeciaMeses;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = Traducciones.Caso + " " + casoCabecera.CasoId + " " + casoCabecera.Sucursal.Nombre + ". " + casoDetalles[j].Funcionario.Nombre + ".";

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Si el detalle tiene la misma moneda que la cabecera, utilizar la cotizacion de la cabecera
                                decimal cotizacionOrigen = (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.Cotizacion_NombreCol];
                                if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol] == casoDetalles[j].MonedaId)
                                    cotizacionOrigen = casoDetalles[j].Cotizacion;

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol], cotizacionOrigen, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].FuncionarioId, Definiciones.Tablas.Funcionarios);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PlanillaLiquidaciones_Pendiente_a_Aprobado.Egreso_AumentarPagoFuncionarios:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region asentar por salario base
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDetalles[j].MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoDetalles[j].FuncionarioId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalSalario;
                            montoAux /= correspondeciaMeses;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = Traducciones.Caso + " " + casoCabecera.CasoId + " " + casoCabecera.Sucursal.Nombre + ". " + casoDetalles[j].Funcionario.Nombre + ".";

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoDetalles[j].MonedaId, casoDetalles[j].Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                            #endregion asentar por salario base

                            string clausulas = FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol + " = " + casoDetalles[j].LiquidacionId + " and " +
                                               FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol + " = " + Definiciones.TipoItemLiquidacion.Bonificacion;
                            DataTable dtFuncionariosLiquidacionesDet = FuncionariosLiquidacionesDetallesService.GetLiquidacionesDetallesDataTable(clausulas, sesion);
                            for (int k = 0; k < dtFuncionariosLiquidacionesDet.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDetalles[j].MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoDetalles[j].FuncionarioId);

                                if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol] == Definiciones.TipoItemLiquidacion.Bonificacion)
                                {
                                    DataTable dtFuncionarioBonificacion = FuncionariosBonificacionesService.GetFuncionariosBonificacionesDataTable(FuncionariosBonificacionesService.Id_NombreCol + " = " + dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol], string.Empty);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.BonificacionId_NombreCol, dtFuncionarioBonificacion.Rows[0][FuncionariosBonificacionesService.BonificacionId_NombreCol]);
                                }
                                else if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol] == Definiciones.TipoItemLiquidacion.Descuento)
                                {
                                    DataTable dtFuncionarioDescuento = new FuncionariosDescuentosService().GetFuncionariosDescuentosDataTable(FuncionariosDescuentosService.Id_NombreCol + " = " + dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol], string.Empty);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.DescuentoId_NombreCol, dtFuncionarioDescuento.Rows[0][FuncionariosDescuentosService.Id_NombreCol]);
                                }

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.Monto_NombreCol];
                                montoAux /= correspondeciaMeses;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = Traducciones.Caso + " " + casoCabecera.CasoId + " " + casoCabecera.Sucursal.Nombre + ". " + casoDetalles[j].Funcionario.Nombre + ".";

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Si el detalle tiene la misma moneda que la cabecera, utilizar la cotizacion de la cabecera
                                decimal cotizacionOrigen = (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.Cotizacion_NombreCol];
                                if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol] == casoDetalles[j].MonedaId)
                                    cotizacionOrigen = casoDetalles[j].Cotizacion;

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol], cotizacionOrigen, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].FuncionarioId, Definiciones.Tablas.Funcionarios);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PlanillaLiquidaciones_Pendiente_a_Aprobado.Egreso_AumentarAportesEmpresa:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDetalles[j].MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoDetalles[j].FuncionarioId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalAporteEmpresa;
                            montoAux /= correspondeciaMeses; 

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = Traducciones.Caso + " " + casoCabecera.CasoId + " " + casoCabecera.Sucursal.Nombre + ". " + casoDetalles[j].Funcionario.Nombre + ".";

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoDetalles[j].MonedaId, casoDetalles[j].Cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].FuncionarioId, Definiciones.Tablas.Funcionarios);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.PlanillaLiquidaciones_Pendiente_a_Aprobado.Ingreso_AumentarPorDescuentos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            string clausulas = FuncionariosLiquidacionesDetallesService.FuncionariosLiquidacionesId_NombreCol + " = " + casoDetalles[j].LiquidacionId + " and " +
                                               FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol + " = " + Definiciones.TipoItemLiquidacion.Descuento + " and " +
                                               " not exists (select fd." + FuncionariosDescuentosService.Id_NombreCol + " from " + FuncionariosDescuentosService.Nombre_Tabla + " fd " +
                                               "              where fd." + FuncionariosDescuentosService.Id_NombreCol + " = " + FuncionariosLiquidacionesDetallesService.Nombre_Tabla + "." + FuncionariosLiquidacionesDetallesService.ItemId_NombreCol +
                                               "                and " + FuncionariosLiquidacionesDetallesService.Nombre_Tabla + "." + FuncionariosLiquidacionesDetallesService.TipoItem_NombreCol + " = " + Definiciones.TipoItemLiquidacion.Descuento +
                                               "                and " + FuncionariosDescuentosService.DescuentoId_NombreCol + " = " + funcionarioDescuentoIPSId +
                                               "                and " + FuncionariosDescuentosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "')";
                            DataTable dtFuncionariosLiquidacionesDet = FuncionariosLiquidacionesDetallesService.GetLiquidacionesDetallesDataTable(clausulas, sesion);
                            for (int k = 0; k < dtFuncionariosLiquidacionesDet.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDetalles[j].MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoDetalles[j].FuncionarioId);

                                DataTable dtFuncionarioDescuento = new FuncionariosDescuentosService().GetFuncionariosDescuentosDataTable(FuncionariosDescuentosService.Id_NombreCol + " = " + dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.ItemId_NombreCol], string.Empty);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.DescuentoId_NombreCol, dtFuncionarioDescuento.Rows[0][FuncionariosDescuentosService.DescuentoId_NombreCol]);

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.Monto_NombreCol];
                                montoAux /= correspondeciaMeses; 

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = Traducciones.Caso + " " + casoCabecera.CasoId + " " + casoCabecera.Sucursal.Nombre + ". " + casoDetalles[j].Funcionario.Nombre + ".";

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Si el detalle tiene la misma moneda que la cabecera, utilizar la cotizacion de la cabecera
                                decimal cotizacionOrigen = (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.Cotizacion_NombreCol];
                                if ((decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol] == casoDetalles[j].MonedaId)
                                    cotizacionOrigen = casoDetalles[j].Cotizacion;

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtFuncionariosLiquidacionesDet.Rows[k][FuncionariosLiquidacionesDetallesService.MonedaId_NombreCol], cotizacionOrigen, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].FuncionarioId, Definiciones.Tablas.Funcionarios);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                }
            }

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.PlanillaLiquidaciones_Pendiente_a_Aprobado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else {AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarPendienteAAprobado
    }
}
