#region Using
using System.Collections;
using CBA.FlowV2.Services.Base;
using System;
using System.Data;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
using System.Collections.Generic;
using CBA.FlowV2.Db;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosNotaCreditoClientesService : AsientosAutomaticosService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacion(object caso_cabecera, object caso_detalle, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {

                var cabecera = (NotasCreditoPersonaService)caso_cabecera;
                var detalles = (NotasCreditoPersonaDetalleService[])caso_detalle;

                for (int i = 0; i < detalles.Length; i++)
                {
                    decimal montoConcepto = 0, costoUnitario = 0;

                    if(detalles[i].MontoConcepto.HasValue)
                        montoConcepto = detalles[i].MontoConcepto.Value;

                    if (detalles[i].CostoUnitario.HasValue)
                        costoUnitario = detalles[i].CostoUnitario.Value;

                    decimal porcentaje = (montoConcepto + costoUnitario * detalles[i].Cantidad.Value) / cabecera.MontoTotal;
                    this.porcentajeDetalleSobreTotal.Add(detalles[i].Id ?? i, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region Constructor
        public AsientosNotaCreditoClientesService(int asiento_automatico_id)
            : base(asiento_automatico_id){}
        #endregion Constructor

        #region CalcularObservacion
        protected override string CalcularObservacionCabecera(CasosService caso, object cabecera, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(this.EstructuraObservacion);
            var casoCabecera = (NotasCreditoPersonaService)cabecera;

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
                    case EstructuraObservacionHelper.Campo.Persona:
                        eo.Set(campo, casoCabecera.Persona.NombreCompleto);
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
            var casoCabecera = (NotasCreditoPersonaService)cabecera;
            var casoDetalle = (NotasCreditoPersonaDetalleService)detalle;

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

        #region AsentarPreAprobadoAAprobado
        /// <summary>
        /// Asentars the pre aprobado A caja.
        /// - Debe en (Pasivo) Debito Fiscal 5% (por monto gravado 5 con descuento)
        /// - Debe en (Pasivo) Debito Fiscal 10% (por monto gravado 10 con descuento)
        /// - Debe en (Egreso) Devoluciones a Clientes por el monto neto sin descuento
        /// - Haber en (Pasivo) Devoluciones a Clientes por monto bruto con descuento
        /// - Haber en (Egreso) Descuentos Realizados por descuento sin impuesto
        ///
        /// - Debe en (Activo) Mercaderias (por costo)
        /// - Haber en (Egreso) Costo de venta (por costo)
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarPreAprobadoAAprobado(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
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

            var casoCabecera = (NotasCreditoPersonaService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (NotasCreditoPersonaDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            int tipoNC = Definiciones.Error.Valor.IntPositivo;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, new NotasCreditoPersonaService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            if (casoCabecera.TipoNotaCreditoId.HasValue)
                tipoNC = (int)casoCabecera.TipoNotaCreditoId.Value;

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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoPersona_PreAprobado_a_Aprobado.Pasivo_DisminuirDebitoFiscal5:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Se evitan los calculos si el detalle no es gravado 5
                            if (casoDetalles[j].Impuesto.Porcentaje != 5)
                            {
                                //Se verifica si no es un impuesto conmpuesto que tenga IVA 5
                                if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId, Definiciones.Impuestos.IVA_5, sesion))
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol, casoCabecera.TipoNotaCreditoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].ImpuestoMonto;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.NroComprobante;
                                observacion += " " + casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoPersona_PreAprobado_a_Aprobado.Pasivo_DisminuirDebitoFiscal10:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Se evitan los calculos si el detalle no es gravado 10
                            if (casoDetalles[j].Impuesto.Porcentaje != 10)
                            {
                                //Se verifica si no es un impuesto conmpuesto que tenga IVA 10
                                if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId, Definiciones.Impuestos.IVA_10, sesion))
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol, casoCabecera.TipoNotaCreditoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].ImpuestoMonto;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.NroComprobante;
                                observacion += " " + casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoPersona_PreAprobado_a_Aprobado.Egreso_AumentarDevolucionesClientes:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            if (casoDetalles[j].FacturaClienteId.HasValue && casoDetalles[j].FacturaCliente.CanalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoDetalles[j].FacturaCliente.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol, casoCabecera.TipoNotaCreditoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Se obtienen el porcentaje de descuento del detalle y de la cabecera
                            decimal montoNeto, descuento;

                            montoNeto = casoDetalles[j].Total - casoDetalles[j].ImpuestoMonto;

                            descuento = 0;
                            if (casoDetalles[j].FacturaClienteDetalleId.HasValue)
                                descuento = montoNeto / (1 - casoDetalles[j].FacturaClienteDetalle.PorcentajeDto / 100) - montoNeto;
                            if (casoDetalles[j].FacturaClienteId.HasValue)
                                descuento += montoNeto / (1 - casoDetalles[j].FacturaCliente.PorcentajeDescSobreTotal.Value / 100) - montoNeto;

                            montoAux = montoNeto + descuento;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.NroComprobante;
                                observacion += " " + casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoPersona_PreAprobado_a_Aprobado.Pasivo_AumentarDevolucionesClientesPorFCCredito:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            DataTable dtFactura = new DataTable();

                            //Las NC por unificacion no asocian una factura ya que pueden ser varias
                            if (tipoNC != Definiciones.TiposNotasCredito.UnificacionDeuda)
                            {
                                //Si no hay una factura asociada se asume que fue credito
                                if (casoDetalles[j].FacturaClienteId.HasValue && casoDetalles[j].FacturaCliente.TipoFacturaId != Definiciones.TipoFactura.Credito)
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            if (casoDetalles[j].FacturaClienteId.HasValue && casoDetalles[j].FacturaCliente.CanalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoDetalles[j].FacturaCliente.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol, casoCabecera.TipoNotaCreditoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            if (!casoDetalles[j].ArticuloId.HasValue)
                            {
                                montoAux = casoDetalles[j].Total;
                            }
                            else
                            {
                                switch (tipoNC)
                                {
                                    case Definiciones.TiposNotasCredito.RecuperoMercaderia:
                                    case Definiciones.TiposNotasCredito.CambioTitular:
                                    case Definiciones.TiposNotasCredito.UnificacionDeuda:
                                        //Obtener el costo de la nota de credito
                                        montoAux = casoDetalles[j].CostoUnitario.Value * casoDetalles[j].Cantidad.Value;

                                        break;
                                    default:
                                        //Se obtienen el porcentaje de descuento del detalle y de la cabecera
                                        decimal montoNeto, descuento;

                                        montoNeto = casoDetalles[j].Total - casoDetalles[j].ImpuestoMonto;

                                        descuento = 0;
                                        if (casoDetalles[j].FacturaClienteDetalleId.HasValue)
                                            descuento = montoNeto / (1 - casoDetalles[j].FacturaClienteDetalle.PorcentajeDto / 100) - montoNeto;
                                        if (casoDetalles[j].FacturaClienteId.HasValue)
                                            descuento += montoNeto / (1 - casoDetalles[j].FacturaCliente.PorcentajeDescSobreTotal.Value / 100) - montoNeto;

                                        montoAux = casoDetalles[j].Total + descuento;

                                        break;
                                }
                            }

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.NroComprobante;
                                observacion += " " + casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoPersona_PreAprobado_a_Aprobado.Pasivo_AumentarDevolucionesClientesPorFCContado:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Las NC por unificacion usan el detalle Pasivo_AumentarDevolucionesClientesPorFCCredito
                            if (tipoNC == Definiciones.TiposNotasCredito.UnificacionDeuda)
                                continue;

                            //Si no hay una factura asociada se asume que fue credito
                            if (!casoDetalles[j].FacturaClienteId.HasValue  || casoDetalles[j].FacturaCliente.TipoFacturaId != Definiciones.TipoFactura.Contado)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            if (casoDetalles[j].FacturaClienteId.HasValue && casoDetalles[j].FacturaCliente.CanalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoDetalles[j].FacturaCliente.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol, casoCabecera.TipoNotaCreditoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            if (!casoDetalles[j].ArticuloId.HasValue)
                            {
                                montoAux = casoDetalles[j].Total;
                            }
                            else
                            {
                                switch (tipoNC)
                                {
                                    case Definiciones.TiposNotasCredito.RecuperoMercaderia:
                                    case Definiciones.TiposNotasCredito.CambioTitular:
                                    case Definiciones.TiposNotasCredito.UnificacionDeuda:
                                        //Obtener el costo de la nota de credito
                                        montoAux = casoDetalles[j].CostoUnitario.Value * casoDetalles[j].Cantidad.Value;

                                        break;
                                    default:
                                        montoAux = casoDetalles[j].Total;

                                        break;
                                }
                            }

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.NroComprobante;
                                observacion += " " + casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoPersona_PreAprobado_a_Aprobado.Egreso_DisminuirDescuentosRealizados:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //La NC Personas no tiene descuento en el detalle, pero la FC si podria tenerlo tanto en el detalle como en la cabecera
                            if (!casoDetalles[j].ArticuloId.HasValue)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol, casoCabecera.TipoNotaCreditoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            switch (tipoNC)
                            {
                                case Definiciones.TiposNotasCredito.RecuperoMercaderia:
                                case Definiciones.TiposNotasCredito.CambioTitular:
                                case Definiciones.TiposNotasCredito.UnificacionDeuda:
                                    montoAux = 0;
                                    break;
                                default:
                                    //Se obtienen el porcentaje de descuento del detalle y de la cabecera
                                    decimal montoNeto;

                                    montoNeto = casoDetalles[j].Total - casoDetalles[j].ImpuestoMonto;

                                    montoAux = 0;
                                    if (casoDetalles[j].FacturaClienteDetalleId.HasValue) 
                                        montoAux = montoNeto / (1 - casoDetalles[j].FacturaClienteDetalle.PorcentajeDto / 100) - montoNeto;
                                    if (casoDetalles[j].FacturaClienteId.HasValue) 
                                        montoAux += montoNeto / (1 - casoDetalles[j].FacturaCliente.PorcentajeDescSobreTotal.Value / 100) - montoNeto;
                                    break;
                            }

                            //Si el monto es negativo es porque debe utilizarse en conjunto con invertirDebeHaber
                            if (!invertirSiEsNegativo)
                                if (montoAux < 0) montoAux *= (-1);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.NroComprobante;
                                observacion += " " + casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoPersona_PreAprobado_a_Aprobado.Activo_AumentarMercaderias:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //El detalle solo se crea si involucra un articulo
                            if (!casoDetalles[j].ArticuloId.HasValue)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol, casoCabecera.TipoNotaCreditoId);
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
                            costoPPP.costo *= casoDetalles[j].Cantidad.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.NroComprobante;
                                observacion += " " + casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, costoPPP.costo, 0, monedaPais, cotizacionMonedaPais, costoPPP.moneda_id, costoPPP.cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.NotaCreditoPersona_PreAprobado_a_Aprobado.Egreso_DisminuirCostoPorVenta:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //El detalle solo se crea si involucra un articulo
                            if (!casoDetalles[j].ArticuloId.HasValue)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            if (casoDetalles[j].FacturaClienteId.HasValue && casoDetalles[j].FacturaCliente.CanalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoDetalles[j].FacturaCliente.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioCobradorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol, casoCabecera.TipoNotaCreditoId);
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
                            costoPPP.costo *= casoDetalles[j].Cantidad.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.NroComprobante;
                                observacion += " " + casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, costoPPP.costo, monedaPais, cotizacionMonedaPais, costoPPP.moneda_id, costoPPP.cotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
