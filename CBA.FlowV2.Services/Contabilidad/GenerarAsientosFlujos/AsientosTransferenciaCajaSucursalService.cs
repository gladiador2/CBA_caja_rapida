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

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosTransferenciaCajaSucursalService
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
                    suma += (decimal)dtDetalles.Rows[i][TransferenciaCajasSucursalDetalleService.Monto_NombreCol] / (decimal)dtDetalles.Rows[i][TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol];

                if (suma > 0)
                {
                    for (int i = 0; i < dtDetalles.Rows.Count; i++)
                    {
                        decimal detalleId = (decimal)dtDetalles.Rows[i][TransferenciaCajasSucursalDetalleService.Id_NombreCol];
                        decimal porcentaje = (decimal)dtDetalles.Rows[i][TransferenciaCajasSucursalDetalleService.Monto_NombreCol] / (decimal)dtDetalles.Rows[i][TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol] / suma;
                        this.porcentajeDetalleSobreTotal.Add(detalleId, porcentaje);
                    }
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region AsentarEnProcesoACerrado
        public static decimal AsentarEnProcesoACerrado(CasosService caso, bool es_origen, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            DateTime fechaDeAsiento;
            DataTable dtCabecera = TransferenciaCajasSucursalService.GetTransferenciaCajasDataTable(TransferenciaCajasSucursalService.CasoId_NombreCol + " = " + caso.Id.Value, string.Empty, sesion);
            DataTable dtDetalles = TransferenciaCajasSucursalDetalleService.GetTransCajasSucDetalleInfoCompleta(TransferenciaCajasSucursalDetalleService.TransfCajaSucId_NombreCol + " = " + dtCabecera.Rows[0][TransferenciaCajasSucursalService.Id_NombreCol], string.Empty, sesion);

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(dtCabecera, dtDetalles, new TransferenciaCajasSucursalService(), sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(caso.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, monedaPais, (DateTime)dtCabecera.Rows[0][TransferenciaCajasSucursalService.Fecha_NombreCol], sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            campos.Add(AsientosService.CasoRelacionadoId_NombreCol, caso.Id.Value);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, AsientosService.GetObservacion(Definiciones.Contabilidad.AsientosAutomaticos.TransferenciaCajasSucursal_EnProceso_a_Cerrado,
                                                                                             caso,
                                                                                             null,
                                                                                             sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            
            if (es_origen)
                campos.Add(AsientosService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.SucursalOrigenId_NombreCol]);
            else
                campos.Add(AsientosService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.SucursalDestinoId_NombreCol]);

            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaCajasSucursal_EnProceso_a_Cerrado.Activo_AumentarPorIngreso:

                        if (!es_origen)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            //Solo se incluyen detalles de ajuste positivo
                            if ((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol] <= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.SucursalDestinoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.TextoPredefinidoId_NombreCol]);
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol]))
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, CuentaCorrienteFondosFijosService.GetFuncionarioId((decimal)dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol], sesion));
                            }
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaCajasSucursal_EnProceso_a_Cerrado.Activo_DisminuirPorEgreso:

                        if (!es_origen)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            //Solo se incluyen detalles de ajuste positivo
                            if ((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol] <= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.SucursalOrigenId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.TextoPredefinidoId_NombreCol]);
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol]))
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, CuentaCorrienteFondosFijosService.GetFuncionarioId((decimal)dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol], sesion));
                            }
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaCajasSucursal_EnProceso_a_Cerrado.Activo_AumentarPorIngresoDestino:

                        if (es_origen)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            //Solo se incluyen detalles de ajuste positivo
                            if ((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol] <= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.SucursalDestinoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.TextoPredefinidoId_NombreCol]);
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol]))
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, CuentaCorrienteFondosFijosService.GetFuncionarioId((decimal)dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol], sesion));
                            }
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaCajasSucursal_EnProceso_a_Cerrado.Activo_DisminuirPorEgresoDestino:

                        if (es_origen)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            //Solo se incluyen detalles de ajuste positivo
                            if ((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol] <= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.SucursalOrigenId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.TextoPredefinidoId_NombreCol]);
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol]))
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, CuentaCorrienteFondosFijosService.GetFuncionarioId((decimal)dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol], sesion));
                            }
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaCajasSucursal_EnProceso_a_Cerrado.Activo_AumentarPrestamo:

                        if (!es_origen)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            //Solo se incluyen detalles de ajuste positivo
                            if ((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol] <= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.SucursalDestinoId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.TextoPredefinidoId_NombreCol]);
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol]))
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, CuentaCorrienteFondosFijosService.GetFuncionarioId((decimal)dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoDestinoId_NombreCol], sesion));
                            }
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        caso, dtCabecera.Rows[0], dtDetalles.Rows[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.TransferenciaCajasSucursal_EnProceso_a_Cerrado.Activo_DisminuirPrestamo:

                        if (es_origen)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < dtDetalles.Rows.Count; j++)
                        {
                            //Solo se incluyen detalles de ajuste positivo
                            if ((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol] <= 0)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.SucursalOrigenId_NombreCol]);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, caso.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.TextoPredefinidoId_NombreCol]);
                            if (!Interprete.EsNullODBNull(dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol]))
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, CuentaCorrienteFondosFijosService.GetFuncionarioId((decimal)dtCabecera.Rows[0][TransferenciaCajasSucursalService.FondoFijoOrigenId_NombreCol], sesion));
                            }
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Monto_NombreCol];

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.MonedaId_NombreCol], (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.CotizacionMoneda_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dtDetalles.Rows[j][TransferenciaCajasSucursalDetalleService.Id_NombreCol],
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

            if (AsientosAutomaticosService.GetUnificarDetallesMismaCuenta(Definiciones.Contabilidad.AsientosAutomaticos.TransferenciaCajasSucursal_EnProceso_a_Cerrado, sesion))
                AsientosAutomaticosService.EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else {AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarEnProcesoACerrado
    }
}
