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
    public class AsientosFacturasClientesService : AsientosAutomaticosService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacion(object caso_cabecera, object caso_detalle, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                var cabecera = (FacturasClienteService)caso_cabecera;
                var detalles = (FacturasClienteDetalleService[])caso_detalle;

                for (int i = 0; i < detalles.Length; i++)
                {
                    //Si no está guardado en el sistema, no se puede recuperar el desglose por centro de costo
                    DataTable dtCentrosCosto = null;
                    if (detalles[i].ExisteEnDB)
                        dtCentrosCosto = FacturasClienteDetalleCentrosCostoService.GetDataTable(FacturasClienteDetalleCentrosCostoService.FacturaClienteDetalleId_NombreCol + " = " + detalles[i].Id.Value, string.Empty, sesion);
                    else
                        dtCentrosCosto = new DataTable();

                    if (dtCentrosCosto.Rows.Count > 0)
                    {
                        Dictionary<decimal, decimal> dCentrosCostos = new Dictionary<decimal, decimal>();
                        decimal suma = 0;

                        for (int j = 0; j < dtCentrosCosto.Rows.Count; j++)
                        {
                            dCentrosCostos.Add((decimal)dtCentrosCosto.Rows[j][FacturasClienteDetalleCentrosCostoService.CentroCostoId_NombreCol], (decimal)dtCentrosCosto.Rows[j][FacturasClienteDetalleCentrosCostoService.Porcentaje_NombreCol]);
                            suma += (decimal)dtCentrosCosto.Rows[j][FacturasClienteDetalleCentrosCostoService.Porcentaje_NombreCol];
                        }

                        //Se agrega un centro de costo ficticio para llegar a 100%
                        //y que la normalizacion posterior no afecte que la asignacion de
                        //centros haya sido menor a 100%
                        if (suma < 100)
                            dCentrosCostos.Add(Definiciones.Error.Valor.EnteroPositivo, (100m - suma) / 100);

                        this.detalles.Add(detalles[i].Id.Value, dCentrosCostos);
                    }

                    decimal porcentaje = 1;
                    if (cabecera.TotalNeto.Value != 0)
                        porcentaje = detalles[i].TotalNeto / cabecera.TotalNeto.Value;
                    this.porcentajeDetalleSobreTotal.Add(detalles[i].Id ?? (decimal)i, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region Constructor
        public AsientosFacturasClientesService(int asiento_automatico_id)
            : base(asiento_automatico_id){}
        #endregion Constructor

        #region CalcularObservacion
        protected override string CalcularObservacionCabecera(CasosService caso, object cabecera, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(this.EstructuraObservacion);
            var casoCabecera = (FacturasClienteService)cabecera;
            
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
                        eo.Set(campo, casoCabecera.DepositoDestionId.Value);
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

        protected override string CalcularObservacionDetalle(AsientosAutomaticosDetalleService asiento_automatico_detalle, CasosService caso, object cabecera, object detalle, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(asiento_automatico_detalle.EstructuraObservacion);
            var casoCabecera = (FacturasClienteService)cabecera;
            var casoDetalle = (FacturasClienteDetalleService)detalle;

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
                        eo.Set(campo, casoDetalle.CantidadUnidadDestino);
                        break;
                    default:
                        throw new Exception("Campo no implementado");
                }
            }

            return eo.observacion.Length > 0 ? eo.observacion : asiento_automatico_detalle.Descripcion;
        }
        #endregion CalcularObservacion

        #region AsentarPendienteACaja
        /// <summary>
        /// Asentars the pendiente A caja.
        /// Si es credito
        /// - Debe en (Activo) clientes por monto bruto con descuento
        /// Si es contado
        /// - Debe en (Activo) recaudaciones en proceso por monto bruto con descuento
        /// En todos los casos
        /// - Debe en (Egreso) Descuentos Realizados por el descuento neto
        /// - Haber en (Ingreso) Ventas por monto neto sin descuento
        /// - Haber en (Pasivo) Debito Fiscal 5% (por monto gravado 5 con descuento)
        /// - Haber en (Pasivo) Debito Fiscal 10% (por monto gravado 10 con descuento)
        ///
        /// - Debe en (Egreso) Costo de venta (por costo)
        /// - Haber en (Activo) Mercaderias (por costo)
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarPendienteACaja(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
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

            var casoCabecera = (FacturasClienteService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (FacturasClienteDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];
          
            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, new FacturasClienteService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            bool provieneDeCreditos = false;
            decimal? personaRelacionadaId = null;
            if (casoCabecera.CasoOrigenId.HasValue)
            {
                provieneDeCreditos = casoCabecera.CasoOrigen.FlujoId == Definiciones.FlujosIDs.CREDITOS;
                if (provieneDeCreditos)
                {
                    CreditosService creditosService = CreditosService.GetPorCaso(casoCabecera.CasoOrigenId.Value, sesion);
                    if (creditosService.PersonaGarante1Id != null)
                        personaRelacionadaId = creditosService.PersonaGarante1Id.Value;
                }
            }

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaCompra(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);

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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.Activo_AumentarClientes:

                        if (provieneDeCreditos)
                            continue;

                        //Seguir solo si la factura es credito
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Credito)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalNeto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);
                            
                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.Activo_AumentarRecaudacionesEnProceso:

                        if (provieneDeCreditos)
                            continue;

                        //Seguir solo si la factura es contado
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Contado)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalNeto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.Egreso_AumentarDescuentosRealizados:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Los detalles con total negativo son descuentos
                            if (casoDetalles[j].TotalNeto < 0)
                            {
                                //Obtener el monto del descuento sin impuesto
                                if (casoDetalles[j].Impuesto.Porcentaje == 0)
                                    montoAux = casoDetalles[j].TotalNeto;
                                else
                                    montoAux = casoDetalles[j].TotalNeto - casoDetalles[j].TotalNeto / (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));

                                //Se aplica el descuento de la cabecera (con logica inversa a un detalle normal)
                                montoAux -= montoAux * (100 - casoCabecera.PorcentajeDescSobreTotal.Value) / 100;

                                //Pasar el monto a positivo
                                montoAux *= (-1);
                            }
                            else
                            {
                                //Obtener el monto del descuento sin impuesto
                                if (casoDetalles[j].Impuesto.Porcentaje == 0)
                                {
                                    montoAux = casoDetalles[j].TotalMontoDto;

                                    montoAux += casoDetalles[j].TotalNeto * casoCabecera.PorcentajeDescSobreTotal.Value / 100;
                                }
                                else
                                {
                                    montoAux = (casoDetalles[j].TotalMontoBruto * casoDetalles[j].PorcentajeDto / 100) -
                                               (casoDetalles[j].TotalMontoBruto * casoDetalles[j].PorcentajeDto / 100) /
                                                (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));

                                    //Se agrega el descuento de la cabecera (neto)
                                    montoAux += (casoDetalles[j].TotalNeto * casoCabecera.PorcentajeDescSobreTotal.Value / 100) -
                                                (casoDetalles[j].TotalNeto * casoCabecera.PorcentajeDescSobreTotal.Value / 100) /
                                                 (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));
                                }
                            }

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.Ingreso_AumentarIngresoPorVentaContado:

                        //Seguir solo si la factura es contado
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Contado)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto sin descuento
                            if (casoDetalles[j].Impuesto.Porcentaje == 0)
                            {
                                montoAux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                            }
                            else
                            {
                                decimal aux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                                montoAux = aux - aux / (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));
                            }

                            //Si el monto es negativo es porque debe utilizarse en conjunto con invertirDebeHaber
                            if (!invertirSiEsNegativo)
                                if (montoAux < 0) montoAux *= (-1);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.Pasivo_AumentarDebitoFiscal5:

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
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalMontoImpuesto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.Pasivo_AumentarDebitoFiscal10:

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
                            if (casoCabecera.CanalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalMontoImpuesto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.Egreso_AumentarCostoPorVenta:
                        
                        if (casoCabecera.AfectaStock == Definiciones.SiNo.No)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].Articulo.ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            StockService.Costo costoPPP = new StockService.Costo();
                             string where = StockMovimientoService.Modelo.CASO_IDColumnName +"="+ casoCabecera.CasoId;
                                    where += " and " +StockMovimientoService.Modelo.REGISTRO_IDColumnName +"="+ casoDetalles[j].Id.Value;
                            STOCK_MOVIMIENTOSRow[] movimientos = sesion.db.STOCK_MOVIMIENTOSCollection.GetAsArray(where, StockMovimientoService.Modelo.IDColumnName + " DESC");
                            
                            if (movimientos.Length>0)
                            {
                                StockMovimientoService sm = new StockMovimientoService(movimientos[0].ID, sesion);
                                costoPPP = sm.GetCostoPPP(sesion);
                                
                            }
                            costoPPP.costo *= casoDetalles[j].CantidadUnitariaTotalDest;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.Activo_DisminuirMercaderias:

                        if (casoCabecera.AfectaStock == Definiciones.SiNo.No)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].Articulo.ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
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
                            costoPPP.costo *= casoDetalles[j].CantidadUnitariaTotalDest;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.PrestamosAClientes:

                        if (!provieneDeCreditos)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            if (casoCabecera.VendedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            var tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);

                            if (casoDetalles[j].ArticuloId == tafr.Articulo.Id)
                                montoAux = casoDetalles[j].TotalMontoImpuesto;
                            else
                                montoAux = casoDetalles[j].TotalNeto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.InteresesACobrar:

                        if (!provieneDeCreditos)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            var tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);

                            if (casoDetalles[j].ArticuloId != tafr.Articulo.Id)
                                continue;

                            montoAux = casoDetalles[j].TotalNeto / (decimal)1.1;

                            //Tomar enc el uenta posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Pendiente_a_Caja.Ingreso_AumentarIngresoPorVentaCredito:

                        //Seguir solo si la factura es credito
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Credito)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto sin descuento
                            if (casoDetalles[j].Impuesto.Porcentaje == 0)
                            {
                                montoAux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                            }
                            else
                            {
                                decimal aux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                                montoAux = aux - aux / (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));
                            }

                            //Si el monto es negativo es porque debe utilizarse en conjunto con invertirDebeHaber
                            if (!invertirSiEsNegativo)
                                if (montoAux < 0) montoAux *= (-1);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

        #region AsentarEnRepartoACaja
        /// <summary>
        /// Asentars the en reparto A caja.
        /// Si es credito
        /// - Debe en (Activo) clientes por monto bruto con descuento
        /// Si es contado
        /// - Debe en (Activo) recaudaciones en proceso por monto bruto con descuento
        /// En todos los casos
        /// - Debe en (Egreso) Descuentos Realizados por el descuento neto
        /// - Haber en (Ingreso) Ventas por monto neto sin descuento
        /// - Haber en (Pasivo) Debito Fiscal 5% (por monto gravado 5 con descuento)
        /// - Haber en (Pasivo) Debito Fiscal 10% (por monto gravado 10 con descuento)
        ///
        /// - Debe en (Egreso) Costo de venta (por costo)
        /// - Haber en (Activo) Mercaderias (por costo)
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarEnRepartoACaja(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
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

            var casoCabecera = (FacturasClienteService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (FacturasClienteDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false;
            bool invertirSiEsNegativo = false;
            bool crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, new FacturasClienteService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            bool provieneDeCreditos = false;
            decimal? personaRelacionadaId = null;
            if (casoCabecera.CasoOrigenId.HasValue)
            {
                provieneDeCreditos = casoCabecera.CasoOrigen.FlujoId == Definiciones.FlujosIDs.CREDITOS;
                if (provieneDeCreditos)
                {
                    CreditosService creditosService = CreditosService.GetPorCaso(casoCabecera.CasoOrigenId.Value, sesion);
                    if (creditosService.PersonaGarante1Id != null)
                        personaRelacionadaId = creditosService.PersonaGarante1Id.Value;
                }
            }

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaCompra(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);

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
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.Activo_AumentarClientes:

                        if (provieneDeCreditos)
                            continue;

                        //Seguir solo si la factura es credito
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Credito)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalNeto;
                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];
                            
                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.Activo_AumentarRecaudacionesEnProceso:

                        if (provieneDeCreditos)
                            continue;

                        //Seguir solo si la factura es contado
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Contado)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalNeto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.Egreso_AumentarDescuentosRealizados:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Los detalles con total negativo son descuentos
                            if (casoDetalles[j].TotalNeto < 0)
                            {
                                //Obtener el monto del descuento sin impuesto
                                if (casoDetalles[j].Impuesto.Porcentaje == 0)
                                    montoAux = casoDetalles[j].TotalNeto;
                                else
                                    montoAux = casoDetalles[j].TotalNeto - casoDetalles[j].TotalNeto / (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));

                                //Se aplica el descuento de la cabecera (con logica inversa a un detalle normal)
                                montoAux -= montoAux * (100 - casoCabecera.PorcentajeDescSobreTotal.Value) / 100;

                                //Pasar el monto a positivo
                                montoAux *= (-1);
                            }
                            else
                            {
                                //Obtener el monto del descuento sin impuesto
                                if (casoDetalles[j].Impuesto.Porcentaje == 0)
                                {
                                    montoAux = casoDetalles[j].TotalMontoDto;

                                    montoAux += casoDetalles[j].TotalNeto * casoCabecera.PorcentajeDescSobreTotal.Value / 100;
                                }
                                else
                                {
                                    montoAux = (casoDetalles[j].TotalMontoBruto * casoDetalles[j].PorcentajeDto / 100) -
                                               (casoDetalles[j].TotalMontoBruto * casoDetalles[j].PorcentajeDto / 100) /
                                                (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));

                                    //Se agrega el descuento de la cabecera (neto)
                                    montoAux += (casoDetalles[j].TotalNeto * casoCabecera.PorcentajeDescSobreTotal.Value / 100) -
                                                (casoDetalles[j].TotalNeto * casoCabecera.PorcentajeDescSobreTotal.Value / 100) /
                                                 (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));
                                }
                            }

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.Ingreso_AumentarIngresoPorVentaContado:

                        //Seguir solo si la factura es contado
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Contado)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto sin descuento
                            if (casoDetalles[j].Impuesto.Porcentaje == 0)
                            {
                                montoAux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                            }
                            else
                            {
                                decimal aux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                                montoAux = aux - aux / (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));
                            }

                            //Si el monto es negativo es porque debe utilizarse en conjunto con invertirDebeHaber
                            if (!invertirSiEsNegativo)
                                if (montoAux < 0) montoAux *= (-1);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.Pasivo_AumentarDebitoFiscal5:

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
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalMontoImpuesto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.Pasivo_AumentarDebitoFiscal10:

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
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            if (casoCabecera.VendedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalMontoImpuesto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.Egreso_AumentarCostoPorVenta:
                        
                        if (casoCabecera.AfectaStock == Definiciones.SiNo.No)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
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
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.Activo_DisminuirMercaderias:

                        if (casoCabecera.AfectaStock == Definiciones.SiNo.No)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
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
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.PrestamosAClientes:

                        if (!provieneDeCreditos)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            var tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);

                            if (casoDetalles[j].ArticuloId == tafr.Articulo.Id)
                                montoAux = casoDetalles[j].TotalMontoImpuesto;
                            else
                                montoAux = casoDetalles[j].TotalNeto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.InteresesACobrar:

                        if (!provieneDeCreditos)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            var tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);

                            if (casoDetalles[j].ArticuloId != tafr.Articulo.Id)
                                continue;

                            montoAux = casoDetalles[j].TotalNeto / (decimal)1.1;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_EnReparto_a_Caja.Ingreso_AumentarIngresoPorVentaCredito:

                        //Seguir solo si la factura es credito
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Credito)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto sin descuento
                            if (casoDetalles[j].Impuesto.Porcentaje == 0)
                            {
                                montoAux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                            }
                            else
                            {
                                decimal aux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                                montoAux = aux - aux / (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));
                            }

                            //Si el monto es negativo es porque debe utilizarse en conjunto con invertirDebeHaber
                            if (!invertirSiEsNegativo)
                                if (montoAux < 0) montoAux *= (-1);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
        #endregion AsentarEnRepartoACaja

        #region AsentarCajaAAnulado
        /// <summary>
        /// Asentars the en caja A anulado.
        /// Si es credito
        /// - Haber en (Activo) clientes por monto bruto con descuento
        /// Si es contado
        /// - Haber en (Activo) recaudaciones en proceso por monto bruto con descuento
        /// En todos los casos
        /// - Debe en (Egreso) Descuentos Realizados por el descuento neto
        /// - Debe en (Ingreso) Ventas por monto neto sin descuento
        /// - Debe en (Pasivo) Debito Fiscal 5% (por monto gravado 5 con descuento)
        /// - Debe en (Pasivo) Debito Fiscal 10% (por monto gravado 10 con descuento)
        ///
        /// - Haber en (Egreso) Costo de venta (por costo)
        /// - Debe en (Activo) Mercaderias (por costo)
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarCajaAAnulado(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
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

            var casoCabecera = (FacturasClienteService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (FacturasClienteDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false;
            bool invertirSiEsNegativo = false;
            bool crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, new FacturasClienteService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            bool provieneDeCreditos = false;
            decimal? personaRelacionadaId = null;
            if (casoCabecera.CasoOrigenId.HasValue)
            {
                provieneDeCreditos = casoCabecera.CasoOrigen.FlujoId == Definiciones.FlujosIDs.CREDITOS;
                if (provieneDeCreditos)
                {
                    CreditosService creditosService = CreditosService.GetPorCaso(casoCabecera.CasoOrigenId.Value, sesion);
                    if (creditosService.PersonaGarante1Id != null)
                        personaRelacionadaId = creditosService.PersonaGarante1Id.Value;
                }
            }

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaCompra(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);

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
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.Activo_DisminuirClientes:

                        if (provieneDeCreditos)
                            continue;

                        //Seguir si la factura es credito
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Credito)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalNeto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.Activo_DisminuirRecaudacionesEnProceso:

                        if (provieneDeCreditos)
                            continue;

                        //Seguir solo si la factura es contado
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Contado)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalNeto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.Egreso_DisminuirDescuentosRealizados:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Los detalles con total negativo son descuentos
                            if (casoDetalles[j].TotalNeto < 0)
                            {
                                //Obtener el monto del descuento sin impuesto
                                if (casoDetalles[j].Impuesto.Porcentaje == 0)
                                    montoAux = casoDetalles[j].TotalNeto;
                                else
                                    montoAux = casoDetalles[j].TotalNeto - casoDetalles[j].TotalNeto / (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));

                                //Se aplica el descuento de la cabecera (con logica inversa a un detalle normal)
                                montoAux -= montoAux * (100 - casoCabecera.PorcentajeDescSobreTotal.Value) / 100;

                                //Pasar el monto a positivo
                                montoAux *= (-1);
                            }
                            else
                            {
                                //Obtener el monto del descuento sin impuesto
                                if (casoDetalles[j].Impuesto.Porcentaje == 0)
                                {
                                    montoAux = casoDetalles[j].TotalMontoDto;

                                    montoAux += casoDetalles[j].TotalNeto * casoCabecera.PorcentajeDescSobreTotal.Value / 100;
                                }
                                else
                                {
                                    montoAux = (casoDetalles[j].TotalMontoBruto * casoDetalles[j].PorcentajeDto / 100) -
                                               (casoDetalles[j].TotalMontoBruto * casoDetalles[j].PorcentajeDto / 100) /
                                                (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));

                                    //Se agrega el descuento de la cabecera (neto)
                                    montoAux += (casoDetalles[j].TotalNeto * casoCabecera.PorcentajeDescSobreTotal.Value / 100) -
                                                (casoDetalles[j].TotalNeto * casoCabecera.PorcentajeDescSobreTotal.Value / 100) /
                                                 (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));
                                }
                            }

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.Ingreso_DisminuirIngresoPorVentaContado:

                        //Seguir solo si la factura es contado
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Contado)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto sin descuento
                            if (casoDetalles[j].Impuesto.Porcentaje == 0)
                            {
                                montoAux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                            }
                            else
                            {
                                decimal aux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                                montoAux = aux - aux / (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));
                            }

                            //Si el monto es negativo es porque debe utilizarse en conjunto con invertirDebeHaber
                            if (!invertirSiEsNegativo)
                                if (montoAux < 0) montoAux *= (-1);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.Pasivo_DisminuirDebitoFiscal5:

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
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalMontoImpuesto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.Pasivo_DisminuirDebitoFiscal10:

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
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalMontoImpuesto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.Egreso_DisminuirCostoPorVenta:

                        if (casoCabecera.AfectaStock == Definiciones.SiNo.No)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
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
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.Activo_AumentarMercaderias:

                        if (casoCabecera.AfectaStock == Definiciones.SiNo.No)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
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
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.PrestamosAClientes:

                        if (!provieneDeCreditos)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            var tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);

                            if (casoDetalles[j].ArticuloId == tafr.Articulo.Id)
                                montoAux = casoDetalles[j].TotalMontoImpuesto;
                            else
                                montoAux = casoDetalles[j].TotalNeto;

                            //Tomar en cuenta el posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.InteresesACobrar:

                        if (!provieneDeCreditos)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            var tafr = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);

                            if (casoDetalles[j].ArticuloId != tafr.Articulo.Id)
                                continue;

                            montoAux = casoDetalles[j].TotalNeto / (decimal)1.1;

                            //Tomar enc el uenta posible descuento indicado en la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal.Value / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCClientes_Caja_a_Anulado.Ingreso_DisminuirIngresoPorVentaCredito:

                        //Seguir solo si la factura es credito
                        if (casoCabecera.TipoFacturaId != Definiciones.TipoFactura.Credito)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, casoCabecera.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.VendedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaDestinoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.DepositoId);
                            if (casoCabecera.SucursalVentaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalVentaId);
                            else
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            if (personaRelacionadaId != null)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol, personaRelacionadaId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto sin descuento
                            if (casoDetalles[j].Impuesto.Porcentaje == 0)
                            {
                                montoAux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                            }
                            else
                            {
                                decimal aux = casoDetalles[j].TotalMontoBruto - casoDetalles[j].TotalRecargoFinanciero;
                                montoAux = aux - aux / (1 + (100 / casoDetalles[j].Impuesto.Porcentaje));
                            }

                            //Si el monto es negativo es porque debe utilizarse en conjunto con invertirDebeHaber
                            if (!invertirSiEsNegativo)
                                if (montoAux < 0) montoAux *= (-1);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDetalles[j].ArticuloCodigo.Length > 0 ? casoDetalles[j].ArticuloCodigo : casoDetalles[j].Articulo.CodigoEmpresa;
                                observacion += "-";
                                observacion += casoDetalles[j].ArticuloDescripcion.Length > 0 ? casoDetalles[j].ArticuloDescripcion : (casoDetalles[j].Articulo.DescripcionImpresion.Length > 0 ? casoDetalles[j].Articulo.DescripcionImpresion : casoDetalles[j].Articulo.DescripcionInterna);
                                observacion += " (" + casoDetalles[j].Lote.Lote + ") ";
                                observacion += casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaDestinoId.Value, casoCabecera.CotizacionDestino.Value, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

            if (crearAsiento) if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; } else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }

        }
        #endregion AsentarCajaAAnulado
    }
}
