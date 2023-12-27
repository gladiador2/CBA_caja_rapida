#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotaCreditosProveedores;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosNotaCreditoProveedoresService : AsientosAutomaticosService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacion(object caso_cabecera, object caso_detalle, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)

            {
                var cabecera = (NotasCreditoProveedorService)caso_cabecera;
                var detalles = (NotasCreditoProveedorDetalleService[])caso_detalle;

                for (int i = 0; i < detalles.Length; i++)
                {
                    DataTable dtCentrosCosto = null;

                    if (detalles[i].ExisteEnDB)
                        dtCentrosCosto = NotasCreditoProveedorDetalleCentrosCostoService.GetNotasCreditoProveedorDetalleCentrosCostoDataTable(NotasCreditoProveedorDetalleCentrosCostoService.NotaCreditoPorveedorDetalleId_NombreCol + " = " + detalles[i].Id, string.Empty, sesion);
                    else
                        dtCentrosCosto = new DataTable();

                    if (dtCentrosCosto.Rows.Count > 0)
                    {
                        Dictionary<decimal, decimal> dCentrosCostos = new Dictionary<decimal, decimal>();
                        decimal suma = 0;

                        for (int j = 0; j < dtCentrosCosto.Rows.Count; j++)
                        {
                            dCentrosCostos.Add((decimal)dtCentrosCosto.Rows[j][NotasCreditoProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol], (decimal)dtCentrosCosto.Rows[j][NotasCreditoProveedorDetalleCentrosCostoService.Porcentaje_NombreCol]);
                            suma += (decimal)dtCentrosCosto.Rows[j][NotasCreditoProveedorDetalleCentrosCostoService.Porcentaje_NombreCol];
                        }

                        //Se agrega un centro de costo ficticio para llegar a 100%
                        //y que la normalizacion posterior no afecte que la asignacion de
                        //centros haya sido menor a 100%
                        if (suma < 100)
                            dCentrosCostos.Add(Definiciones.Error.Valor.EnteroPositivo, (100m - suma) / 100);

                        this.detalles.Add(detalles[i].Id ?? (decimal)i, dCentrosCostos);
                    }

                    decimal porcentaje = detalles[i].Total.Value / cabecera.MontoTotal;
                    this.porcentajeDetalleSobreTotal.Add(detalles[i].Id ?? (decimal)i, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion
        
        #region Constructor
        public AsientosNotaCreditoProveedoresService(int asiento_automatico_id)
            : base(asiento_automatico_id)
        {
        }
        #endregion Constructor

        #region CalcularObservacion
        protected override string CalcularObservacionCabecera(CasosService caso, object cabecera, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(this.EstructuraObservacion);
            var casoCabecera = (NotasCreditoProveedorService)cabecera;

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
                        eo.Set(campo, casoCabecera.DepositoId.Value);
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

        protected override string CalcularObservacionDetalle(AsientosAutomaticosDetalleService asiento_automatico_detalle, CasosService caso, object cabecera, object detalle, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(asiento_automatico_detalle.EstructuraObservacion);
            var casoCabecera = (NotasCreditoProveedorService)cabecera;
            var casoDetalle = (NotasCreditoProveedorDetalleService)detalle;

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
                        eo.Set(campo, casoCabecera.Deposito.Nombre);
                        break;
                    case EstructuraObservacionHelper.Campo.Persona:
                        eo.Set(campo, caso.PersonaId.HasValue ? caso.Persona.NombreCompleto : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.Proveedor:
                        eo.Set(campo, caso.ProveedorId.HasValue ? caso.Proveedor.RazonSocial : string.Empty);
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
                        eo.Set(campo, casoDetalle.Cantidad);
                        break;
                    default:
                        throw new Exception("Campo no implementado");
                }
            }

            return eo.observacion.Length > 0 ? eo.observacion : asiento_automatico_detalle.Descripcion;
        }
        #endregion CalcularObservacion

        #region AsentarPendienteAAprobado
        /// <summary>
        /// Asentars the pendiente A aprobado.
        /// Si el proveedor es local (definido en ficha de proveedores)
        /// - Debe en (Pasivo) Proveedores locales por monto bruto con descuento
        /// Si el proveedor no es local (definido en ficha de proveedores)
        /// - Debe en (Pasivo) Proveedores del Exterior por monto bruto con descuento
        /// Para todos los casos
        /// - Debe en (Ingreso) Descuentos Obtenidos por el descuento neto
        /// Si la factura apuntada por el detalle es por mercaderias
        /// - Haber en mercaderias por monto neto sin descuento
        /// Si la factura apuntada por el detalle es por gastos
        /// - Haber en (Egreso) gastos en proceso por monto neto sin descuento
        /// Para todos los casos
        /// - Haber en (Activo) credito fiscal 5% (por monto gravado 5 con descuento)
        /// - Haber en (Activo) credito fiscal 10% (por monto gravado 10 con descuento)
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

            var casoCabecera = (NotasCreditoProveedorService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (NotasCreditoProveedorDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];

            DataTable dtDetallesCuentas;
            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux = Definiciones.Error.Valor.EnteroPositivo, montoAux, montoNetoDescontado, montoDescuentoNeto;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, new NotasCreditoProveedorService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            //En caso el usuario haya establecido las cuentas afectadas por detalle
            decimal[] cuentasAux, porcentajesAux;

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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoProveedor_Pendiente_a_Aprobado.Pasivo_DisminuirProveedoresLocales:

                        //Seguir solo si el proveedor es nacional
                        if (casoCabecera.Proveedor.esNacional != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));

                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioResponsableId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].Total.Value;
                            
                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = casoCabecera.NroComprobante + (casoDetalles[j].Articulo != null ? " " + casoDetalles[j].Articulo.DescripcionInterna + " " + casoDetalles[j].Lote.Lote : string.Empty) + ". " + casoDetalles[j].Observacion;

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);
                            
                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoProveedor_Pendiente_a_Aprobado.Pasivo_DisminuirProveedoresExterior:

                        //Seguir solo si el proveedor no es nacional
                        if (casoCabecera.Proveedor.esNacional != Definiciones.SiNo.No)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));

                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioResponsableId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].Total.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = casoCabecera.NroComprobante + (casoDetalles[j].Articulo != null ? " " + casoDetalles[j].Articulo.DescripcionInterna + " " + casoDetalles[j].Lote.Lote : string.Empty) + ". " + casoDetalles[j].Observacion;

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoProveedor_Pendiente_a_Aprobado.Ingreso_DisminuirDescuentosObtenidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Si el detalle no es un articulo no puede tener descuento
                            if (!casoDetalles[j].ArticuloId.HasValue && casoDetalles[j].Articulo == null)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));

                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioResponsableId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto del descuento sin impuesto
                            montoDescuentoNeto = 0;
                            if (casoDetalles[j].FacturaProveedorDetalleId.HasValue || casoDetalles[j].FacturaProveedorDetalle != null)
                            {
                                if (casoDetalles[j].FacturaProveedorDetalle.PorcentajeImpuesto == 0)
                                {
                                    montoDescuentoNeto = casoDetalles[j].FacturaProveedorDetalle.TotalDescuento;
                                }
                                else
                                {
                                    montoDescuentoNeto = casoDetalles[j].FacturaProveedorDetalle.TotalDescuento -
                                                         (casoDetalles[j].FacturaProveedorDetalle.TotalBruto *
                                                            casoDetalles[j].FacturaProveedorDetalle.PorcentajeDescuento / 100 /
                                                            (1 + (100 / casoDetalles[j].FacturaProveedorDetalle.PorcentajeImpuesto))
                                                         );
                                }

                                //Ajustar el monto del descuento por porcentaje segun la cantdiad de articulos devueltos
                                montoDescuentoNeto *= casoDetalles[j].Cantidad.Value / casoDetalles[j].FacturaProveedorDetalle.CantidadUnitariaTotalDest;
                            }
                            
                            montoAux = montoDescuentoNeto;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = casoCabecera.NroComprobante + (casoDetalles[j].Articulo != null ? " " + casoDetalles[j].Articulo.DescripcionInterna + " " + casoDetalles[j].Lote.Lote : string.Empty) + ". " + casoDetalles[j].Observacion;

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoProveedor_Pendiente_a_Aprobado.Activo_DisminuirMercaderia:

                        #region sumar separando en cuentas
                        cuentasAux = null;
                        porcentajesAux = null;

                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Si el detalle no es un articulo no afecta mercaderias
                            if (!casoDetalles[j].ArticuloId.HasValue && casoDetalles[j].Articulo == null)
                                continue;

                            #region seleccionar cuentas contables
                            //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                            //y no las indicadas por la relacion entre cuentas y asientos automaticos
                            if (casoCabecera.ExisteEnDB)
                                dtDetallesCuentas = NotasCreditoProveedorDetalleCuentaContableService.GetNCProveedorDetalleCuentaContableDataTable(NotasCreditoProveedorDetalleCuentaContableService.NotaCreditoProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id, string.Empty, sesion);
                            else
                                dtDetallesCuentas = new DataTable();
                            
                            if (dtDetallesCuentas.Rows.Count > 0)
                            {
                                cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                {
                                    cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][NotasCreditoProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                    porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][NotasCreditoProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }
                            }
                            else
                            {
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioResponsableId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                            }
                            #endregion seleccionar cuentas contables

                            if (casoDetalles[j].FacturaProveedorDetalleId.HasValue || casoDetalles[j].FacturaProveedorDetalle != null)
                            {
                                //Obtener el monto neto incluyendo el descuento
                                montoNetoDescontado = casoDetalles[j].FacturaProveedorDetalle.TotalPago - casoDetalles[j].FacturaProveedorDetalle.TotalImpuestoDescontado;

                                //Obtener el monto del descuento sin impuesto
                                if (casoDetalles[j].FacturaProveedorDetalle.PorcentajeImpuesto == 0)
                                {
                                    montoDescuentoNeto = casoDetalles[j].FacturaProveedorDetalle.TotalDescuento;
                                }
                                else
                                {
                                    montoDescuentoNeto = casoDetalles[j].FacturaProveedorDetalle.TotalDescuento -
                                                         (casoDetalles[j].FacturaProveedorDetalle.TotalBruto *
                                                            casoDetalles[j].FacturaProveedorDetalle.PorcentajeDescuento / 100 /
                                                            (1 + (100 / casoDetalles[j].FacturaProveedorDetalle.PorcentajeImpuesto))
                                                         );
                                }

                                montoAux = montoNetoDescontado + montoDescuentoNeto;

                                //Ajustar el monto del descuento por porcentaje segun la cantdiad de articulos devueltos
                                montoAux *= casoDetalles[j].Cantidad.Value / casoDetalles[j].FacturaProveedorDetalle.CantidadUnitariaTotalDest;
                            }
                            else
                            {
                                montoAux = casoDetalles[j].Total.Value - casoDetalles[j].ImpuestoMonto.Value;
                            }
                            
                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = casoCabecera.NroComprobante + (casoDetalles[j].Articulo != null ? " " + casoDetalles[j].Articulo.DescripcionInterna + " " + casoDetalles[j].Lote.Lote : string.Empty) + ". " + casoDetalles[j].Observacion;

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            if (cuentasAux == null)
                            {
                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                            }
                            else
                            {
                                for (int k = 0; k < cuentasAux.Length; k++)
                                {
                                    detalles.Agregar(cuentasAux[k], 0, montoAux * porcentajesAux[k] / 100, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                    centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                    centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                               asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                               asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                               asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                               casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                                }
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoProveedor_Pendiente_a_Aprobado.Egreso_DisminuirGastosEnProceso:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            cuentasAux = null;
                            porcentajesAux = null;

                            if (casoDetalles[j].FacturaProveedorDetalleId.HasValue || casoDetalles[j].FacturaProveedorDetalle != null)
                            {
                                #region Datos Factura Proveedor
                                //Si el detalle no es un articulo no afecta mercaderias
                                if (casoDetalles[j].ArticuloId.HasValue || casoDetalles[j].Articulo != null)
                                    continue;

                                //Solo se asienta si la factura es por gastos
                                if (casoDetalles[j].FacturaProveedor.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.Gastos)
                                    continue;

                                #region seleccionar cuentas contables
                                //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                                //y no las indicadas por la relacion entre cuentas y asientos automaticos
                                if (casoCabecera.ExisteEnDB)
                                    dtDetallesCuentas = NotasCreditoProveedorDetalleCuentaContableService.GetNCProveedorDetalleCuentaContableDataTable(NotasCreditoProveedorDetalleCuentaContableService.NotaCreditoProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id, string.Empty, sesion);
                                else
                                    dtDetallesCuentas = new DataTable();

                                if (dtDetallesCuentas.Rows.Count > 0)
                                {
                                    cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                    porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                    for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                    {
                                        cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][NotasCreditoProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                        porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][NotasCreditoProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                    }
                                }
                                else
                                {
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));

                                    if (casoDetalles[j].ArticuloId.HasValue)
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                    }
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioResponsableId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                }
                                #endregion seleccionar cuentas contables

                                //Obtener el monto neto incluyendo el descuento
                                montoNetoDescontado = casoDetalles[j].FacturaProveedorDetalle.TotalPago - casoDetalles[j].FacturaProveedorDetalle.TotalImpuestoDescontado;

                                //Obtener el monto del descuento sin impuesto
                                if (casoDetalles[j].FacturaProveedorDetalle.PorcentajeImpuesto == 0)
                                {
                                    montoDescuentoNeto = casoDetalles[j].FacturaProveedorDetalle.TotalDescuento;
                                }
                                else
                                {
                                    montoDescuentoNeto = casoDetalles[j].FacturaProveedorDetalle.TotalDescuento -
                                                         (casoDetalles[j].FacturaProveedorDetalle.TotalBruto *
                                                            casoDetalles[j].FacturaProveedorDetalle.PorcentajeDescuento / 100 /
                                                            (1 + (100 / casoDetalles[j].FacturaProveedorDetalle.PorcentajeImpuesto))
                                                         );
                                }

                                montoAux = montoNetoDescontado + montoDescuentoNeto;

                                //Ajustar el monto del descuento por porcentaje segun la cantdiad de articulos devueltos
                                montoAux *= casoDetalles[j].Cantidad.Value / casoDetalles[j].FacturaProveedorDetalle.CantidadUnitariaTotalDest;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoCabecera.NroComprobante + (casoDetalles[j].Articulo != null ? " " + casoDetalles[j].Articulo.DescripcionInterna + " " + casoDetalles[j].Lote.Lote : string.Empty) + ". " + casoDetalles[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                    observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                                //usuario o lo indicado en la relacion de cuenta por asiento automatico
                                if (cuentasAux == null)
                                {
                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                     centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                                }
                                else
                                {
                                    for (int k = 0; k < cuentasAux.Length; k++)
                                    {
                                        detalles.Agregar(cuentasAux[k], 0, montoAux * porcentajesAux[k] / 100, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                        centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                        centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                   asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                   asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                   asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                   casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region Datos Nota de Crédito Proveedor
                                #region seleccionar cuentas contables
                                //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                                //y no las indicadas por la relacion entre cuentas y asientos automaticos
                                if (casoCabecera.ExisteEnDB)
                                    dtDetallesCuentas = NotasCreditoProveedorDetalleCuentaContableService.GetNCProveedorDetalleCuentaContableDataTable(NotasCreditoProveedorDetalleCuentaContableService.NotaCreditoProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id, string.Empty, sesion);
                                else
                                    dtDetallesCuentas = new DataTable();

                                if (dtDetallesCuentas.Rows.Count > 0)
                                {
                                    cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                    porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                    for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                    {
                                        cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][NotasCreditoProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                        porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][NotasCreditoProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                    }
                                }
                                else
                                {

                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));

                                    if (casoDetalles[j].ArticuloId.HasValue)
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                    }
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioResponsableId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                }
                                #endregion seleccionar cuentas contables

                                //Ajustar el monto del descuento por porcentaje segun la cantdiad de articulos devueltos
                                montoAux = casoDetalles[j].Total.Value - casoDetalles[j].ImpuestoMonto.Value;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                    observacion = casoCabecera.NroComprobante + (casoDetalles[j].Articulo != null ? " " + casoDetalles[j].Articulo.DescripcionInterna + " " + casoDetalles[j].Lote.Lote : string.Empty) + ". " + casoDetalles[j].Observacion;

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                    observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                                //usuario o lo indicado en la relacion de cuenta por asiento automatico
                                if (cuentasAux == null)
                                {
                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                     centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                                }
                                else
                                {
                                    for (int k = 0; k < cuentasAux.Length; k++)
                                    {
                                        detalles.Agregar(cuentasAux[k], 0, montoAux * porcentajesAux[k] / 100, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                     centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoProveedor_Pendiente_a_Aprobado.Activo_DisminuirCreditoFiscal5:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Se evitan los calculos si el detalle no es gravado 5
                            if (casoDetalles[j].ImpuestoPorcentaje.Value != 5)
                            {
                                //Se verifica si no es un impuesto conmpuesto que tenga IVA 5
                                if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId.Value, Definiciones.Impuestos.IVA_5, sesion))
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));

                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioResponsableId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].ImpuestoMonto.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = casoCabecera.NroComprobante + (casoDetalles[j].Articulo != null ? " " + casoDetalles[j].Articulo.DescripcionInterna + " " + casoDetalles[j].Lote.Lote : string.Empty) + ". " + casoDetalles[j].Observacion;

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));

                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoProveedor_Pendiente_a_Aprobado.Activo_DisminuirCreditoFiscal10:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Se evitan los calculos si el detalle no es gravado 10
                            if (casoDetalles[j].ImpuestoPorcentaje.Value != 10)
                            {
                                //Se verifica si no es un impuesto conmpuesto que tenga IVA 10
                                if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId.Value, Definiciones.Impuestos.IVA_10, sesion))
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));

                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioResponsableId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].ImpuestoMonto.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                                observacion = casoCabecera.NroComprobante + (casoDetalles[j].Articulo != null ? " " + casoDetalles[j].Articulo.DescripcionInterna + " " + casoDetalles[j].Lote.Lote : string.Empty) + ". " + casoDetalles[j].Observacion;

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoDetalles[j].FacturaProveedor.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
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
    }
}
