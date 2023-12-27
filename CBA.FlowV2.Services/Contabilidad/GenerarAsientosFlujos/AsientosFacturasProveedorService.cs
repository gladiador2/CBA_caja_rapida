#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
using CBA.FlowV2.Services.Tesoreria;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosFacturasProveedorService : AsientosAutomaticosService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacion : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacion(object caso_cabecera, object caso_detalle, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                var cabecera = (FacturasProveedorService)caso_cabecera;
                var detalles = (FacturasProveedorDetalleService[])caso_detalle;

                for (int i = 0; i < detalles.Length; i++)
                {
                    //Si no está guardado en el sistema, no se puede recuperar el desglose por centro de costo
                    DataTable dtCentrosCosto = null;
                    if (detalles[i].ExisteEnDB)
                        dtCentrosCosto = FacturasProveedorDetalleCentrosCostoService.GetFacturasProveedorDetalleCentrosCostoDataTable(FacturasProveedorDetalleCentrosCostoService.FacturaProveedorDetalleId_NombreCol + " = " + detalles[i].Id.Value, string.Empty, sesion);
                    else
                        dtCentrosCosto = new DataTable();

                    if (dtCentrosCosto.Rows.Count > 0)
                    {
                        Dictionary<decimal, decimal> dCentrosCostos = new Dictionary<decimal, decimal>();
                        decimal suma = 0;

                        for (int j = 0; j < dtCentrosCosto.Rows.Count; j++)
                        {
                            dCentrosCostos.Add((decimal)dtCentrosCosto.Rows[j][FacturasProveedorDetalleCentrosCostoService.CentroCostoId_NombreCol], (decimal)dtCentrosCosto.Rows[j][FacturasProveedorDetalleCentrosCostoService.Porcentaje_NombreCol]);
                            suma += (decimal)dtCentrosCosto.Rows[j][FacturasProveedorDetalleCentrosCostoService.Porcentaje_NombreCol];
                        }

                        //Se agrega un centro de costo ficticio para llegar a 100%
                        //y que la normalizacion posterior no afecte que la asignacion de
                        //centros haya sido menor a 100%
                        if (suma < 100)
                            dCentrosCostos.Add(Definiciones.Error.Valor.EnteroPositivo, 100 - suma);

                        this.detalles.Add(detalles[i].Id.Value, dCentrosCostos);
                    }

                    decimal porcentaje = 1;
                    if (cabecera.TotalBruto.Value != 0)
                        porcentaje = detalles[i].TotalBruto / cabecera.TotalBruto.Value;
                    this.porcentajeDetalleSobreTotal.Add(detalles[i].Id ?? (decimal)i, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region Constructor
        public AsientosFacturasProveedorService(int asiento_automatico_id)
            : base(asiento_automatico_id)
        {
        }
        #endregion Constructor

        #region CalcularObservacion
        protected override string CalcularObservacionCabecera(CasosService caso, object cabecera, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(this.EstructuraObservacion);
            var casoCabecera = (FacturasProveedorService)cabecera;

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
                        eo.Set(campo, casoCabecera.StockDeposito.Nombre);
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
                    case EstructuraObservacionHelper.Campo.FondoFijo:
                        eo.Set(campo, casoCabecera.CtacteFondoFijoId.HasValue ? casoCabecera.CtacteFondoFijo.Nombre : string.Empty);
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
            var casoCabecera = (FacturasProveedorService)cabecera;
            var casoDetalle = (FacturasProveedorDetalleService)detalle;

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
                        eo.Set(campo, casoCabecera.StockDeposito.Nombre);
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
                        eo.Set(campo, casoDetalle.ArticuloId.HasValue ? casoDetalle.Articulo.CodigoEmpresa : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.ArticuloDescripcion:
                        eo.Set(campo, casoDetalle.ArticuloId.HasValue ? casoDetalle.Articulo.DescripcionInterna : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.FondoFijo:
                        eo.Set(campo, casoCabecera.CtacteFondoFijoId.HasValue ? casoCabecera.CtacteFondoFijo.Nombre : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.TextoPredefinidoDetalle:
                        eo.Set(campo, casoDetalle.TextoPredefinidoId.HasValue ? casoDetalle.TextoPredefinido.Texto : string.Empty);
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
                    case EstructuraObservacionHelper.Campo.CasoAsociado:
                        eo.Set(campo, casoCabecera.CasoAsociadoId);
                        break;
                    default:
                        throw new Exception("Campo no implementado");
                }
            }

            return eo.observacion.Length > 0 ? eo.observacion : asiento_automatico_detalle.Descripcion;
        }
        #endregion Calcular

        #region AsentarEnRevisionAAprobado
        /// <summary>
        /// Asentars the en revision A aprobado.
        /// Si la factura es por mercaderias
        /// - Debe en mercaderias en proceso por monto neto sin descuento
        /// Si la factura es por gastos
        /// - Debe en (Egreso) gastos en proceso por monto neto sin descuento
        /// Para todos los casos
        /// - Debe en (Activo) credito fiscal 5% (por monto gravado 5 con descuento)
        /// - Debe en (Activo) credito fiscal 10% (por monto gravado 10 con descuento)
        /// Si el proveedor es local (definido en ficha de proveedores)
        /// - Haber en (Pasivo) Proveedores locales por monto bruto con descuento
        /// Si el proveedor no es local (definido en ficha de proveedores)
        /// - Haber en (Pasivo) Proveedores del Exterior por monto bruto con descuento
        /// Para todos los casos
        /// - Haber en (Ingreso) Descuentos Obtenidos por el descuento neto
        /// Si es por pago de cuentas de terceros y se translada la deuda a la ctacte de la persona
        /// - Debe en (Activo) Clientes
        /// - Haber en (Activo) Prestamos y Anticipos a Terceros a Cobrar
        /// Si es por pago de cuentas de terceros para ganar el credito fiscal
        /// - Debe en (Activo) Caja
        /// - Haber en (Pasivo) Proveedores
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarEnRevisionAAprobado(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
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

            var casoCabecera = (FacturasProveedorService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (FacturasProveedorDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];

            DataTable dtDetallesCuentas;
            DataTable dtPagoTercPersonas;
            if (casoCabecera.ExisteEnDB)
                dtPagoTercPersonas = FCProveedorPagosTercPersonasService.GetFCProveedorPagosTercPersonas(FCProveedorPagosTercPersonasService.FCProveedorId_NombreCol + " = " + casoCabecera.Id.Value, string.Empty, sesion);
            else
                dtPagoTercPersonas = new DataTable();
            
            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux = Definiciones.Error.Valor.EnteroPositivo;
            decimal montoAux, montoNetoDescontado, montoDescuentoNeto;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, new FacturasProveedorService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            //En caso el usuario haya establecido las cuentas afectadas por detalle (desde la FC Proveedor)
            decimal[] cuentasAux, porcentajesAux;

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.FechaFactura.Value, sesion);

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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Activo_AumentarMercaderiaEnProceso:

                        //Solo se asienta si la factura es por compra de mercaderias
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.CompraArticulos)
                            continue;

                        //Asentar solo si la politica de afectar stock es a traves del flujo Ingreso de Stock
                        if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion) != Definiciones.AfectarStock.PorIngresoStock)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            cuentasAux = null;
                            porcentajesAux = null;

                            #region seleccionar cuentas contables
                            //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                            //y no las indicadas por la relacion entre cuentas y asientos automaticos
                            if (casoCabecera.ExisteEnDB)
                                dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                            else
                                dtDetallesCuentas = new DataTable();
                            if (dtDetallesCuentas.Rows.Count > 0)
                            {
                                cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                {
                                    cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                    porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }
                            }
                            else
                            {
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                            }
                            #endregion seleccionar cuentas contables
                            
                            //Obtener el monto neto incluyendo el descuento
                            montoNetoDescontado = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;
                            
                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );
                            }
                            
                            montoAux = montoNetoDescontado + montoDescuentoNeto;
                            
                            //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                            //usuario o lo indicado en la relacion de cuenta por asiento automatico
                            if (cuentasAux == null)
                            {
                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentasAux[k], montoAux * porcentajesAux[k] / 100, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Egreso_AumentarGastosEnProceso:

                        //Solo se asienta si la factura es por gastos
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.Gastos &&
                            casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.GastosDeDespacho &&
                            casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.Autofactura)
                        {
                            continue;
                        }

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            cuentasAux = null;
                            porcentajesAux = null;

                            #region seleccionar cuentas contables
                            //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                            //y no las indicadas por la relacion entre cuentas y asientos automaticos
                            if (casoCabecera.ExisteEnDB)
                                dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                            else
                                dtDetallesCuentas = new DataTable();
                            if (dtDetallesCuentas.Rows.Count > 0)
                            {
                                cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                {
                                    cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                    porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }
                            }
                            else
                            {
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                            }
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto incluyendo el descuento
                            montoNetoDescontado = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );
                            }

                            montoAux = montoNetoDescontado + montoDescuentoNeto;

                            //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                            //usuario o lo indicado en la relacion de cuenta por asiento automatico
                            if (cuentasAux == null)
                            {
                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentasAux[k], montoAux * porcentajesAux[k] / 100, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Activo_AumentarCreditoFiscal5:

                        //Solo se asienta si afecta credito fiscal de la empresa
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
                            continue;
                        
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Se evitan los calculos si el detalle no es gravado 5
                            if (casoDetalles[j].PorcentajeImpuesto != 5)
                            {
                                //Se verifica si no es un impuesto conmpuesto que tenga IVA 5
                                if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId, Definiciones.Impuestos.IVA_5, sesion))
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalImpuestoDescontado;
                            
                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Activo_AumentarCreditoFiscal10:

                        //Solo se asienta si afecta credito fiscal de la empresa
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Se evitan los calculos si el detalle no es gravado 10
                            if (casoDetalles[j].PorcentajeImpuesto != 10)
                            {
                                //Se verifica si no es un impuesto conmpuesto que tenga IVA 10
                                if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId, Definiciones.Impuestos.IVA_10, sesion))
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalImpuestoDescontado;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Pasivo_AumentarProveedoresLocales:
                        
                        //Solo se asienta si afecta ctacte del proveedor
                        if (casoCabecera.AfectaCtacteProveedor != Definiciones.SiNo.Si)
                            continue;

                        //Seguir solo si el proveedor es nacional
                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.No)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalPago;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Pasivo_AumentarCuandoNoAfectaCtacte:

                        //Solo se asienta si afecta ctacte del proveedor
                        if (casoCabecera.AfectaCtacteProveedor != Definiciones.SiNo.No)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalPago;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Pasivo_AumentarProveedoresExterior:

                        //Solo se asienta si afecta ctacte del proveedor
                        if (casoCabecera.AfectaCtacteProveedor != Definiciones.SiNo.Si)
                            continue;

                        //Seguir solo si el proveedor no es nacional
                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.Si)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalPago;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Ingreso_AumentarDescuentosObtenidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;

                                //Se suma al descuento del detalle el descuento de la cabecera
                                montoDescuentoNeto += casoDetalles[j].TotalPago *
                                                      casoCabecera.PorcentajeDescSobreTotal / 100;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );

                                //Se suma al descuento del detalle el descuento de la cabecera
                                //quitando el impuesto
                                decimal auxDescuentoConImpuesto = (casoDetalles[j].TotalPago *
                                                                  casoCabecera.PorcentajeDescSobreTotal / 100);

                                montoDescuentoNeto += auxDescuentoConImpuesto -
                                                      auxDescuentoConImpuesto /
                                                      (1 + (100 / casoDetalles[j].PorcentajeImpuesto));
                            }

                            montoAux = montoDescuentoNeto;

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Activo_AumentarMercaderia:

                        //Solo se asienta si la factura es por compra de mercaderias
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.CompraArticulos)
                            continue;

                        //Asentar solo si la politica de afectar stock es a traves de la factura de proveedor
                        if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion) != Definiciones.AfectarStock.PorFacturaProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            cuentasAux = null;
                            porcentajesAux = null;

                            #region seleccionar cuentas contables
                            //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                            //y no las indicadas por la relacion entre cuentas y asientos automaticos
                            if (casoCabecera.ExisteEnDB)
                                dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                            else
                                dtDetallesCuentas = new DataTable();
                            if (dtDetallesCuentas.Rows.Count > 0)
                            {
                                cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                {
                                    cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                    porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }
                            }
                            else
                            {
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                            }
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto incluyendo el descuento
                            montoNetoDescontado = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );
                            }

                            montoAux = montoNetoDescontado + montoDescuentoNeto;

                            //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                            //usuario o lo indicado en la relacion de cuenta por asiento automatico
                            if (cuentasAux == null)
                            {
                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentasAux[k], montoAux * porcentajesAux[k] / 100, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Activo_AumentarClientes:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;
                        
                        //Solo se asienta si afecta ctacte de la persona
                        if (casoCabecera.AfectaCtactePersona != Definiciones.SiNo.Si)
                            continue;
                        
                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            for (int k = 0; k < dtPagoTercPersonas.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Caso.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                //Calcular tomando el porcentaje del detalle que se translada a la persona y el porcentaje de la cuota
                                //respecto al totla del transpaso
                                montoAux = casoDetalles[j].TotalPago *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignado_NombreCol] / 100 *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignadoCuota_NombreCol] / 100;

                                //Disminuir por el descuento de la cabecera
                                montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                                //Sumar al monto la comision por gestion
                                montoAux *= (1 + (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeComision_NombreCol] / 100);

                                //Obtener el monto en la moneda del pais
                                if (casoCabecera.MonedaId != monedaPais)
                                    montoAux = montoAux / casoCabecera.MonedaCotizacion * cotizacionMonedaPais;

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Activo_AumentarPagosARecuperar:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta ctacte de la persona
                        if (casoCabecera.AfectaCtactePersona != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            for (int k = 0; k < dtPagoTercPersonas.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                DataTable dtPersona = PersonasService.GetPersonasInfoCompletaPorID(dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol].ToString());
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, dtPersona.Rows[0][PersonasService.TipoClienteId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                //Calcular tomando el porcentaje del detalle que se translada a la persona y el porcentaje de la cuota
                                //respecto al totla del transpaso
                                montoAux = casoDetalles[j].TotalPago *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignado_NombreCol] / 100 *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignadoCuota_NombreCol] / 100;

                                //Disminuir por el descuento de la cabecera
                                montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                                //Sumar al monto la comision por gestion
                                montoAux *= (1 + (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeComision_NombreCol] / 100);

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Activo_AumentarCajaPorPagosTercerosPorCreditoFiscal:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta credito fiscal
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto incluyendo el descuento
                            montoAux = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_EnRevision_a_Aprobado.Pasivo_AumentarProveeodoresPorPagosTercerosPorCreditoFiscal:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta credito fiscal
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalPago;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), invertirDebeHaber, invertirSiEsNegativo,
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
        #endregion AsentarEnRevisionAAprobado

        #region AsentarPendienteAAprobado
        /// <summary>
        /// Asentars the pendiente A aprobado.
        /// Si la factura es por mercaderias
        /// - Debe en mercaderias en proceso por monto neto sin descuento
        /// Si la factura es por gastos
        /// - Debe en (Egreso) gastos en proceso por monto neto sin descuento
        /// Para todos los casos
        /// - Debe en (Activo) credito fiscal 5% (por monto gravado 5 con descuento)
        /// - Debe en (Activo) credito fiscal 10% (por monto gravado 10 con descuento)
        /// Si el proveedor es local (definido en ficha de proveedores)
        /// - Haber en (Pasivo) Proveedores locales por monto bruto con descuento
        /// Si el proveedor no es local (definido en ficha de proveedores)
        /// - Haber en (Pasivo) Proveedores del Exterior por monto bruto con descuento
        /// Para todos los casos
        /// - Haber en (Ingreso) Descuentos Obtenidos por el descuento neto
        /// Si es por pago de cuentas de terceros y se translada la deuda a la ctacte de la persona
        /// - Debe en (Activo) Clientes
        /// - Haber en (Activo) Prestamos y Anticipos a Terceros a Cobrar
        /// Si es por pago de cuentas de terceros para ganar el credito fiscal
        /// - Debe en (Activo) Caja
        /// - Haber en (Pasivo) Proveedores
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

            var casoCabecera = (FacturasProveedorService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (FacturasProveedorDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];

            DataTable dtDetallesCuentas;
            DataTable dtPagoTercPersonas;
            if (casoCabecera.ExisteEnDB)
                dtPagoTercPersonas = FCProveedorPagosTercPersonasService.GetFCProveedorPagosTercPersonas(FCProveedorPagosTercPersonasService.FCProveedorId_NombreCol + " = " + casoCabecera.Id.Value, string.Empty, sesion);
            else
                dtPagoTercPersonas = new DataTable();
            
            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux = Definiciones.Error.Valor.EnteroPositivo;
            decimal montoAux, montoNetoDescontado, montoDescuentoNeto;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, new FacturasProveedorService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            //En caso el usuario haya establecido las cuentas afectadas por detalle (desde la FC Proveedor)
            decimal[] cuentasAux, porcentajesAux;

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            //cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.FechaFactura.Value, sesion);
            // Se toma la cotizacion guardado en la cabecera del flujo
            cotizacionMonedaPais = casoCabecera.MonedaPaisCotizacion;

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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Activo_AumentarMercaderiaEnProceso:

                        //Solo se asienta si la factura es por compra de mercaderias
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.CompraArticulos)
                            continue;

                        //Asentar solo si la politica de afectar stock es a traves del flujo Ingreso de Stock
                        if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion) != Definiciones.AfectarStock.PorIngresoStock)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            cuentasAux = null;
                            porcentajesAux = null;

                            #region seleccionar cuentas contables
                            //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                            //y no las indicadas por la relacion entre cuentas y asientos automaticos
                            if (casoCabecera.ExisteEnDB)
                                dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                            else
                                dtDetallesCuentas = new DataTable();
                            if (dtDetallesCuentas.Rows.Count > 0)
                            {
                                cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                {
                                    cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                    porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }
                            }
                            else
                            {
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                            }
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto incluyendo el descuento
                            montoNetoDescontado = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );
                            }

                            montoAux = montoNetoDescontado + montoDescuentoNeto;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                            //usuario o lo indicado en la relacion de cuenta por asiento automatico
                            if (cuentasAux == null)
                            {
                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);

                            }
                            else
                            {
                                for (int k = 0; k < cuentasAux.Length; k++)
                                {
                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentasAux[k], montoAux * porcentajesAux[k] / 100, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
                                                     centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                }
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Egreso_AumentarGastosEnProceso:

                        //Solo se asienta si la factura es por gastos
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.Gastos &&
                            casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.GastosDeDespacho &&
                            casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.Autofactura)
                        {
                            continue;
                        }

                        if (casoCabecera.PagoContratistaDetalleId.HasValue)
                        {
                            #region seleccionar cuentas contables
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[0].TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                            decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.CertificadoMonto_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, monto, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion));

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        }
                        else
                        {
                            #region sumar separando en cuentas
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                            for (int j = 0; j < casoDetalles.Length; j++)
                            {

                                if (!ImpuestosService.EsImpuestoInmobiliario(casoDetalles[j].ImpuestoId))
                                {
                                    #region Impuesto
                                    cuentasAux = null;
                                    porcentajesAux = null;

                                    #region seleccionar cuentas contables
                                    //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                                    //y no las indicadas por la relacion entre cuentas y asientos automaticos
                                    if (casoCabecera.ExisteEnDB)
                                        dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                                    else
                                        dtDetallesCuentas = new DataTable();
                                    if (dtDetallesCuentas.Rows.Count > 0)
                                    {
                                        cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                        porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                        for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                        {
                                            cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                            porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                        }
                                    }
                                    else
                                    {
                                        parametrosElegirCuenta = new Hashtable();
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                        if (casoDetalles[j].ArticuloId.HasValue)
                                        {
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                        }
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                            continue;
                                    }
                                    #endregion seleccionar cuentas contables

                                    //Obtener el monto neto incluyendo el descuento
                                    montoNetoDescontado = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                                    //Obtener el monto del descuento sin impuesto
                                    if (casoDetalles[j].PorcentajeImpuesto == 0)
                                    {
                                        montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                                    }
                                    else
                                    {
                                        montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                             (casoDetalles[j].TotalBruto *
                                                                casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                             );
                                    }

                                    montoAux = montoNetoDescontado + montoDescuentoNeto;
                                    if (casoCabecera.PagoContratistaDetalleId.HasValue)
                                    {
                                        DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                                        montoAux += (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoReparo_NombreCol];
                                    }

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                    {
                                        observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                        if (casoDetalles[j].ArticuloId.HasValue)
                                            observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                        else
                                            observacion += ". " + casoDetalles[j].Observacion;
                                    }

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                        observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                    //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                                    //usuario o lo indicado en la relacion de cuenta por asiento automatico
                                    if (cuentasAux == null)
                                    {
                                        //Se suma el monto por cada cuenta
                                        detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                         centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                         centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                    casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                    }
                                    else
                                    {
                                        for (int k = 0; k < cuentasAux.Length; k++)
                                        {
                                            //Se suma el monto por cada cuenta
                                            detalles.Agregar(cuentasAux[k], montoAux * porcentajesAux[k] / 100, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                             centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
                                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                        }
                                    }
                                    #endregion Impuesto
                                }
                                else
                                {
                                    #region Impuesto Inmobiliario
                                    DataTable dtImpuestoCompuesto = ImpuestosCompuestosService.GetImpuestosCompuestosInfoCompleta(ImpuestosCompuestosService.ImpuestoPadreId_NombreCol + " = " + casoDetalles[j].ImpuestoId, string.Empty);
                                    foreach (DataRow dr in dtImpuestoCompuesto.Rows)
                                    {
                                        decimal totalPago = casoDetalles[j].TotalPago;
                                        //total = (totalPago * (decimal)dr[ImpuestosCompuestosService.Porcentaje_NombreCol] / 100);
                                        cuentasAux = null;
                                        porcentajesAux = null;

                                        #region seleccionar cuentas contables
                                        //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                                        //y no las indicadas por la relacion entre cuentas y asientos automaticos
                                        if (casoCabecera.ExisteEnDB)
                                            dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                                        else
                                            dtDetallesCuentas = new DataTable();
                                        if (dtDetallesCuentas.Rows.Count > 0)
                                        {
                                            cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                            porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                            for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                            {
                                                cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                                porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                            }
                                        }
                                        else
                                        {
                                            parametrosElegirCuenta = new Hashtable();
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                            if (casoDetalles[j].ArticuloId.HasValue)
                                            {
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                            }
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, (decimal)dr[ImpuestosCompuestosService.ImpuestoHijoId_NombreCol]);
                                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                continue;
                                        }
                                        #endregion seleccionar cuentas contables

                                        montoNetoDescontado = casoDetalles[j].TotalPago;

                                        //Obtener el monto del descuento sin impuesto
                                        if ((decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol] == 0)
                                        {
                                            montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                                        }
                                        else
                                        {
                                            montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                                 (casoDetalles[j].TotalBruto *
                                                                    casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / (decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol]))
                                                                 );
                                        }

                                        if ((decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol] == 0)
                                            montoAux = ((montoNetoDescontado + montoDescuentoNeto) * (decimal)dr[ImpuestosCompuestosService.Porcentaje_NombreCol] / 100);
                                        else
                                            montoAux = ((montoNetoDescontado + montoDescuentoNeto) * 
                                                        (decimal)dr[ImpuestosCompuestosService.Porcentaje_NombreCol] / 100) -
                                                        (((montoNetoDescontado + montoDescuentoNeto) * (decimal)dr[ImpuestosCompuestosService.Porcentaje_NombreCol] / 100) / 
                                                        (1 + (100 / (decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol])));
                                        

                                        if (casoCabecera.PagoContratistaDetalleId.HasValue)
                                        {
                                            DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                                            montoAux += (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoReparo_NombreCol];
                                        }

                                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                        if (!detalles.Resumido)
                                        {
                                            observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                            if (casoDetalles[j].ArticuloId.HasValue)
                                                observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                            else
                                                observacion += ". " + casoDetalles[j].Observacion;
                                        }

                                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                            observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                        //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                                        //usuario o lo indicado en la relacion de cuenta por asiento automatico
                                        if (cuentasAux == null)
                                        {
                                            //Se suma el monto por cada cuenta
                                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                        }
                                        else
                                        {
                                            for (int k = 0; k < cuentasAux.Length; k++)
                                            {
                                                //Se suma el monto por cada cuenta
                                                detalles.Agregar(cuentasAux[k], montoAux * porcentajesAux[k] / 100, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                                 centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
                                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                            }
                                        }

                                    }
                                    #endregion Impuesto Inmobiliario
                                }
                            }
                            #endregion sumar separando en cuentas

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        }

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Activo_AumentarCreditoFiscal5:

                        //Solo se asienta si afecta credito fiscal de la empresa
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Se evitan los calculos si el detalle no es gravado 5
                            if (casoDetalles[j].PorcentajeImpuesto != 5)
                            {
                                //Se verifica si no es un impuesto conmpuesto que tenga IVA 5
                                if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId, Definiciones.Impuestos.IVA_5, sesion))
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalImpuestoDescontado;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Activo_AumentarCreditoFiscal10:

                        //Solo se asienta si afecta credito fiscal de la empresa
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
                            continue;

                        if (casoCabecera.PagoContratistaDetalleId.HasValue)
                        {
                            #region seleccionar cuentas contables
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                            decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.TotalIva_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, monto, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion));

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        }
                        else
                        {
                            #region sumar separando en cuentas
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                            for (int j = 0; j < casoDetalles.Length; j++)
                            {
                                //Se evitan los calculos si el detalle no es gravado 10
                                if (casoDetalles[j].PorcentajeImpuesto != 10)
                                {
                                    //Se verifica si no es un impuesto conmpuesto que tenga IVA 10
                                    if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId, Definiciones.Impuestos.IVA_10, sesion))
                                        continue;
                                }

                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = casoDetalles[j].TotalImpuestoDescontado;

                                //Disminuir por el descuento de la cabecera
                                montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                    if (casoDetalles[j].ArticuloId.HasValue)
                                        observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                    else
                                        observacion += ". " + casoDetalles[j].Observacion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                    observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                        }

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.AumentarPagosEnProceso:

                        if (casoCabecera.CtacteCondicionPago.TipoCondicionPago != Definiciones.CondicionPagoTipo.CONTADO) 
                            continue;

                        //Solo se asienta si afecta ctacte del proveedor
                        if (casoCabecera.AfectaCtacteProveedor != Definiciones.SiNo.Si)
                            continue;

                        if (casoCabecera.PagoContratistaDetalleId.HasValue)
                        {
                            #region seleccionar cuentas contables
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                            decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.CertificadoMonto_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.TotalIva_NombreCol] - ((decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoFijoPagado_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoReparo_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.FacturasProveedorPagado_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.AdelantosPagados_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.AdelantoInicial_NombreCol]);

                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, monto, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion));

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        }
                        else
                        {
                            #region sumar separando en cuentas
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                            for (int j = 0; j < casoDetalles.Length; j++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = casoDetalles[j].TotalPago;

                                //Disminuir por el descuento de la cabecera
                                montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                    if (casoDetalles[j].ArticuloId.HasValue)
                                        observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                    else
                                        observacion += ". " + casoDetalles[j].Observacion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                    observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.ProveedorId, Definiciones.Tablas.Proveedores);
                            }
                            #endregion sumar separando en cuentas

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        }

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Pasivo_AumentarProveedoresLocales:

                        if (casoCabecera.CtacteCondicionPago.TipoCondicionPago != Definiciones.CondicionPagoTipo.CREDITO) 
                            continue;

                        //Solo se asienta si afecta ctacte del proveedor
                        if (casoCabecera.AfectaCtacteProveedor != Definiciones.SiNo.Si)
                            continue;

                        //Seguir solo si el proveedor es nacional
                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.No)
                            continue;


                        if (casoCabecera.PagoContratistaDetalleId.HasValue)
                        {
                            #region seleccionar cuentas contables
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                            decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.CertificadoMonto_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.TotalIva_NombreCol] - ((decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoFijoPagado_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoReparo_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.FacturasProveedorPagado_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.AdelantosPagados_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.AdelantoInicial_NombreCol]);

                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, monto, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion));

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        }
                        else
                        {
                            #region sumar separando en cuentas
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                            for (int j = 0; j < casoDetalles.Length; j++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = casoDetalles[j].TotalPago;

                                //Disminuir por el descuento de la cabecera
                                montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                    if (casoDetalles[j].ArticuloId.HasValue)
                                        observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                    else
                                        observacion += ". " + casoDetalles[j].Observacion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                    observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.ProveedorId, Definiciones.Tablas.Proveedores);
                            }
                            #endregion sumar separando en cuentas

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        }

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Pasivo_AumentarProveedoresExterior:

                        if (casoCabecera.CtacteCondicionPago.TipoCondicionPago != Definiciones.CondicionPagoTipo.CREDITO)
                            continue;

                        //Solo se asienta si afecta ctacte del proveedor
                        if (casoCabecera.AfectaCtacteProveedor != Definiciones.SiNo.Si)
                            continue;

                        //Seguir solo si el proveedor no es nacional
                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.Si)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalPago;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoCabecera.ProveedorId, Definiciones.Tablas.Proveedores);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Ingreso_AumentarDescuentosObtenidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;

                                //Se suma al descuento del detalle el descuento de la cabecera
                                montoDescuentoNeto += casoDetalles[j].TotalPago *
                                                      casoCabecera.PorcentajeDescSobreTotal / 100;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );

                                //Se suma al descuento del detalle el descuento de la cabecera
                                //quitando el impuesto
                                decimal auxDescuentoConImpuesto = (casoDetalles[j].TotalPago *
                                                                  casoCabecera.PorcentajeDescSobreTotal / 100);

                                montoDescuentoNeto += auxDescuentoConImpuesto -
                                                      auxDescuentoConImpuesto /
                                                      (1 + (100 / casoDetalles[j].PorcentajeImpuesto));

                            }

                            montoAux = montoDescuentoNeto;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Activo_AumentarMercaderia:

                        //Solo se asienta si la factura es por compra de mercaderias
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.CompraArticulos)
                            continue;

                        //Asentar solo si la politica de afectar stock es a traves de la factura de proveedor
                        if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion) != Definiciones.AfectarStock.PorFacturaProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            cuentasAux = null;
                            porcentajesAux = null;

                            #region seleccionar cuentas contables
                            //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                            //y no las indicadas por la relacion entre cuentas y asientos automaticos
                            if (casoCabecera.ExisteEnDB)
                                dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                            else
                                dtDetallesCuentas = new DataTable();
                            if (dtDetallesCuentas.Rows.Count > 0)
                            {
                                cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                {
                                    cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                    porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }
                            }
                            else
                            {
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                            }
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto incluyendo el descuento
                            montoNetoDescontado = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );
                            }

                            montoAux = montoNetoDescontado + montoDescuentoNeto;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                            //usuario o lo indicado en la relacion de cuenta por asiento automatico
                            if (cuentasAux == null)
                            {
                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                            }
                            else
                            {
                                for (int k = 0; k < cuentasAux.Length; k++)
                                {
                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentasAux[k], montoAux * porcentajesAux[k] / 100, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
                                                     centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                }
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Activo_AumentarClientes:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta ctacte de la persona
                        if (casoCabecera.AfectaCtactePersona != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            for (int k = 0; k < dtPagoTercPersonas.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Caso.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                //Calcular tomando el porcentaje del detalle que se translada a la persona y el porcentaje de la cuota
                                //respecto al totla del transpaso
                                montoAux = casoDetalles[j].TotalPago *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignado_NombreCol] / 100 *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignadoCuota_NombreCol] / 100;

                                //Disminuir por el descuento de la cabecera
                                montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                                //Sumar al monto la comision por gestion
                                montoAux *= (1 + (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeComision_NombreCol] / 100);

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                    if (casoDetalles[j].ArticuloId.HasValue)
                                        observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                    else
                                        observacion += ". " + casoDetalles[j].Observacion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                    observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol], Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Activo_AumentarPagosARecuperar:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta ctacte de la persona
                        if (casoCabecera.AfectaCtactePersona != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            for (int k = 0; k < dtPagoTercPersonas.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                DataTable dtPersona = PersonasService.GetPersonasInfoCompletaPorID(dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol].ToString());
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, dtPersona.Rows[0][PersonasService.TipoClienteId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                //Calcular tomando el porcentaje del detalle que se translada a la persona y el porcentaje de la cuota
                                //respecto al totla del transpaso
                                montoAux = casoDetalles[j].TotalPago *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignado_NombreCol] / 100 *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignadoCuota_NombreCol] / 100;

                                //Disminuir por el descuento de la cabecera
                                montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                                //Sumar al monto la comision por gestion
                                montoAux *= (1 + (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeComision_NombreCol] / 100);

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                    if (casoDetalles[j].ArticuloId.HasValue)
                                        observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                    else
                                        observacion += ". " + casoDetalles[j].Observacion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                    observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol], Definiciones.Tablas.Personas);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Activo_AumentarCajaPorPagosTercerosPorCreditoFiscal:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta credito fiscal
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto incluyendo el descuento
                            montoAux = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.Pasivo_AumentarProveeodoresPorPagosTercerosPorCreditoFiscal:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta credito fiscal
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalPago;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.PagoContratista:

                        if (casoCabecera.PagoContratistaDetalleId.HasValue)
                        {
                            #region seleccionar cuentas contables
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                            decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoFijoPagado_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.FacturasProveedorPagado_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.AdelantosPagados_NombreCol] + (decimal)dt.Rows[0][PagoContratistasDetallesServices.AdelantoInicial_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, monto, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion));

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        }
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Pendiente_a_Aprobado.PagoContratistaFondoReparo:

                        if (casoCabecera.PagoContratistaDetalleId.HasValue)
                        {
                            #region seleccionar cuentas contables
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                            decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoReparo_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, monto, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion));

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        }
                        break;
                }
            }

            casoCabecera.FinalizarUsingSesion();

            if (this.UnificarDetallesMismaCuenta == Definiciones.SiNo.Si)
                EjecutarUnificarDetallesMismaCuenta(asientoCabeceraId, sesion);

            if (crearAsiento) return asientoCabeceraId; else { AsientosService.Borrar(asientoCabeceraId, sesion); return Definiciones.Error.Valor.EnteroPositivo; }
        }
        #endregion AsentarPendienteAAprobado

        #region AsentarAprobadoAPendiente
        public decimal AsentarAprobadoAPendiente(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
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

            var casoCabecera = (FacturasProveedorService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDetalles = (FacturasProveedorDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Detalles];

            DataTable dtPagoTercPersonas = FCProveedorPagosTercPersonasService.GetFCProveedorPagosTercPersonas(FCProveedorPagosTercPersonasService.FCProveedorId_NombreCol + " = " + casoCabecera.Id.Value, string.Empty, sesion);
            DataTable dtDetallesCuentas;

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux = Definiciones.Error.Valor.EnteroPositivo;
            decimal montoAux, montoNetoDescontado, montoDescuentoNeto;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacion centrosCostoAp = new CentrosCostoAplicacion(casoCabecera, casoDetalles, new FacturasProveedorService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            //En caso el usuario haya establecido las cuentas afectadas por detalle (desde la FC Proveedor)
            decimal[] cuentasAux, porcentajesAux;

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.Sucursal.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.Sucursal.PaisId, monedaPais, casoCabecera.FechaFactura.Value, sesion);

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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Activo_DisminuirMercaderiaEnProceso:

                        //Solo se asienta si la factura es por compra de mercaderias
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.CompraArticulos)
                            continue;

                        //Asentar solo si la politica de afectar stock es a traves del flujo Ingreso de Stock
                        if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion) != Definiciones.AfectarStock.PorIngresoStock)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            cuentasAux = null;
                            porcentajesAux = null;

                            #region seleccionar cuentas contables
                            //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                            //y no las indicadas por la relacion entre cuentas y asientos automaticos
                            if (casoCabecera.ExisteEnDB)
                                dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                            else
                                dtDetallesCuentas = new DataTable();
                            if (dtDetallesCuentas.Rows.Count > 0)
                            {
                                cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                {
                                    cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                    porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }
                            }
                            else
                            {
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                            }
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto incluyendo el descuento
                            montoNetoDescontado = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );
                            }

                            montoAux = montoNetoDescontado + montoDescuentoNeto;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                            //usuario o lo indicado en la relacion de cuenta por asiento automatico
                            if (cuentasAux == null)
                            {
                                //Se suma el monto por cada cuenta #1
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                                    //Se suma el monto por cada cuenta #1
                                    detalles.Agregar(cuentasAux[k], 0, montoAux * porcentajesAux[k] / 100, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Egreso_DisminuirGastosEnProceso:

                        if (casoCabecera.PagoContratistaDetalleId.HasValue)
                        {
                            #region seleccionar cuentas contables
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[0].TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                            decimal monto = (decimal)dt.Rows[0][PagoContratistasDetallesServices.CertificadoMonto_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, monto, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion), invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, (decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol], 100,
                                             centrosCostoAp.Seleccionar((decimal)dt.Rows[0][FacturasProveedorDetalleService.Id_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[0], sesion));

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        }
                        else
                        {
                            #region sumar separando en cuentas
                            detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                            for (int j = 0; j < casoDetalles.Length; j++)
                            {

                                if (!ImpuestosService.EsImpuestoInmobiliario(casoDetalles[j].ImpuestoId))
                                {
                                    #region Impuesto
                                    cuentasAux = null;
                                    porcentajesAux = null;

                                    #region seleccionar cuentas contables
                                    //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                                    //y no las indicadas por la relacion entre cuentas y asientos automaticos
                                    if (casoCabecera.ExisteEnDB)
                                        dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                                    else
                                        dtDetallesCuentas = new DataTable();
                                    if (dtDetallesCuentas.Rows.Count > 0)
                                    {
                                        cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                        porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                        for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                        {
                                            cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                            porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                        }
                                    }
                                    else
                                    {
                                        parametrosElegirCuenta = new Hashtable();
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                        if (casoDetalles[j].ArticuloId.HasValue)
                                        {
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                        }
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                            continue;
                                    }
                                    #endregion seleccionar cuentas contables

                                    //Obtener el monto neto incluyendo el descuento
                                    montoNetoDescontado = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                                    //Obtener el monto del descuento sin impuesto
                                    if (casoDetalles[j].PorcentajeImpuesto == 0)
                                    {
                                        montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                                    }
                                    else
                                    {
                                        montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                             (casoDetalles[j].TotalBruto *
                                                                casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                             );
                                    }

                                    montoAux = montoNetoDescontado + montoDescuentoNeto;

                                    if (casoCabecera.PagoContratistaDetalleId.HasValue)
                                    {
                                        DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                                        montoAux += (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoReparo_NombreCol];
                                    }

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                    {
                                        observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                        if (casoDetalles[j].ArticuloId.HasValue)
                                            observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                        else
                                            observacion += ". " + casoDetalles[j].Observacion;
                                    }

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                        observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                    //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                                    //usuario o lo indicado en la relacion de cuenta por asiento automatico
                                    if (cuentasAux == null)
                                    {
                                        //Se suma el monto por cada cuenta
                                        detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                         centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                         centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                    casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                    }
                                    else
                                    {
                                        for (int k = 0; k < cuentasAux.Length; k++)
                                        {
                                            //Se suma el monto por cada cuenta
                                            detalles.Agregar(cuentasAux[k], 0, montoAux * porcentajesAux[k] / 100, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                             centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
                                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                        }
                                    }
                                    #endregion Impuesto
                                }
                                else
                                {
                                    #region Impuesto Inmobiliario
                                    DataTable dtImpuestoCompuesto = ImpuestosCompuestosService.GetImpuestosCompuestosInfoCompleta(ImpuestosCompuestosService.ImpuestoPadreId_NombreCol + " = " + casoDetalles[j].ImpuestoId, string.Empty);
                                    foreach (DataRow dr in dtImpuestoCompuesto.Rows)
                                    {
                                        decimal totalPago = casoDetalles[j].TotalPago;
                                        //total = (totalPago * (decimal)dr[ImpuestosCompuestosService.Porcentaje_NombreCol] / 100);
                                        cuentasAux = null;
                                        porcentajesAux = null;

                                        #region seleccionar cuentas contables
                                        //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                                        //y no las indicadas por la relacion entre cuentas y asientos automaticos
                                        if (casoCabecera.ExisteEnDB)
                                            dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                                        else
                                            dtDetallesCuentas = new DataTable();
                                        if (dtDetallesCuentas.Rows.Count > 0)
                                        {
                                            cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                            porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                            for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                            {
                                                cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                                porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                            }
                                        }
                                        else
                                        {
                                            parametrosElegirCuenta = new Hashtable();
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                            if (casoDetalles[j].ArticuloId.HasValue)
                                            {
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                            }
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, (decimal)dr[ImpuestosCompuestosService.ImpuestoHijoId_NombreCol]);
                                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                continue;
                                        }
                                        #endregion seleccionar cuentas contables

                                        montoNetoDescontado = casoDetalles[j].TotalPago;

                                        //Obtener el monto del descuento sin impuesto
                                        if ((decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol] == 0)
                                        {
                                            montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                                        }
                                        else
                                        {
                                            montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                                 (casoDetalles[j].TotalBruto *
                                                                    casoDetalles[j].PorcentajeDescuento / 100 /
                                                                    (1 + (100 / (decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol]))
                                                                 );
                                        }

                                        if ((decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol] == 0)
                                            montoAux = ((montoNetoDescontado + montoDescuentoNeto) * (decimal)dr[ImpuestosCompuestosService.Porcentaje_NombreCol] / 100);
                                        else
                                            montoAux = ((montoNetoDescontado + montoDescuentoNeto) * 
                                                        (decimal)dr[ImpuestosCompuestosService.Porcentaje_NombreCol] / 100) -
                                                        (((montoNetoDescontado + montoDescuentoNeto) * (decimal)dr[ImpuestosCompuestosService.Porcentaje_NombreCol] / 100) / 
                                                        (1 + (100 / (decimal)dr[ImpuestosCompuestosService.VistaImpuestoHijoPorcentaje_NombreCol])));
                                        

                                        if (casoCabecera.PagoContratistaDetalleId.HasValue)
                                        {
                                            DataTable dt = PagoContratistasDetallesServices.GetPagoContratistasDetallesDatatable(PagoContratistasDetallesServices.Id_NombreCol + " = " + casoCabecera.PagoContratistaDetalleId.Value, PagoContratistasDetallesServices.Id_NombreCol);
                                            montoAux += (decimal)dt.Rows[0][PagoContratistasDetallesServices.FondoReparo_NombreCol];
                                        }

                                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                        if (!detalles.Resumido)
                                        {
                                            observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                            if (casoDetalles[j].ArticuloId.HasValue)
                                                observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                            else
                                                observacion += ". " + casoDetalles[j].Observacion;
                                        }

                                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                            observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                        //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                                        //usuario o lo indicado en la relacion de cuenta por asiento automatico
                                        if (cuentasAux == null)
                                        {
                                            //Se suma el monto por cada cuenta
                                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                             centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                             centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                        casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                        }
                                        else
                                        {
                                            for (int k = 0; k < cuentasAux.Length; k++)
                                            {
                                                //Se suma el monto por cada cuenta
                                                detalles.Agregar(cuentasAux[k], 0, montoAux * porcentajesAux[k] / 100, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                                 centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
                                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion), casoDetalles[j].ArticuloId, Definiciones.Tablas.Articulos);
                                            }
                                        }

                                    }
                                    #endregion Impuesto Inmobiliario
                                }
                            }
                            #endregion sumar separando en cuentas

                            foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                                AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        }

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Activo_DisminuirCreditoFiscal5:

                        //Solo se asienta si afecta credito fiscal de la empresa
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Se evitan los calculos si el detalle no es gravado 5
                            if (casoDetalles[j].PorcentajeImpuesto != 5)
                            {
                                //Se verifica si no es un impuesto conmpuesto que tenga IVA 5
                                if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId, Definiciones.Impuestos.IVA_5, sesion))
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalImpuestoDescontado;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta #3
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Activo_DisminuirCreditoFiscal10:

                        //Solo se asienta si afecta credito fiscal de la empresa
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            //Se evitan los calculos si el detalle no es gravado 10
                            if (casoDetalles[j].PorcentajeImpuesto != 10)
                            {
                                //Se verifica si no es un impuesto conmpuesto que tenga IVA 10
                                if (!ImpuestosCompuestosService.GetContieneGravado(casoDetalles[j].ImpuestoId, Definiciones.Impuestos.IVA_10, sesion))
                                    continue;
                            }

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalImpuestoDescontado;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta #4
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Pasivo_DisminuirProveedoresLocales:

                        //Solo se asienta si afecta ctacte del proveedor
                        if (casoCabecera.AfectaCtacteProveedor != Definiciones.SiNo.Si)
                            continue;

                        //Seguir solo si el proveedor es nacional
                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.No)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalPago;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta #5
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Pasivo_DisminuirProveedoresExterior:

                        //Solo se asienta si afecta ctacte del proveedor
                        if (casoCabecera.AfectaCtacteProveedor != Definiciones.SiNo.Si)
                            continue;

                        //Seguir solo si el proveedor no es nacional
                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.Si)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalPago;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta #6
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Ingreso_DisminuirDescuentosObtenidos:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                            if (casoDetalles[j].ArticuloId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;

                                //Se suma al descuento del detalle el descuento de la cabecera
                                montoDescuentoNeto += casoDetalles[j].TotalPago *
                                                      casoCabecera.PorcentajeDescSobreTotal / 100;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 / (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );

                                //Se suma al descuento del detalle el descuento de la cabecera
                                //quitando el impuesto
                                decimal auxDescuentoConImpuesto = (casoDetalles[j].TotalPago *
                                                                  casoCabecera.PorcentajeDescSobreTotal / 100);

                                montoDescuentoNeto += auxDescuentoConImpuesto -
                                                      auxDescuentoConImpuesto /
                                                      (1 + (100 / casoDetalles[j].PorcentajeImpuesto));

                            }

                            montoAux = montoDescuentoNeto;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta #7
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Activo_DisminuirMercaderia:

                        //Solo se asienta si la factura es por compra de mercaderias
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.CompraArticulos)
                            continue;

                        //Asentar solo si la politica de afectar stock es a traves de la factura de proveedor
                        if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AfectarStock, sesion) != Definiciones.AfectarStock.PorFacturaProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            cuentasAux = null;
                            porcentajesAux = null;

                            #region seleccionar cuentas contables
                            //Si se asociaron cuentas contables al detalle de la factura deben usarse esas 
                            //y no las indicadas por la relacion entre cuentas y asientos automaticos
                            if (casoCabecera.ExisteEnDB)
                                dtDetallesCuentas = FacturasProveedorDetalleCuentaContableService.GetFacturasProveedorDetalleCuentaContableDataTable(FacturasProveedorDetalleCuentaContableService.FacturaProveedorDetalleId_NombreCol + " = " + casoDetalles[j].Id.Value, string.Empty, sesion);
                            else
                                dtDetallesCuentas = new DataTable();
                            if (dtDetallesCuentas.Rows.Count > 0)
                            {
                                cuentasAux = new decimal[dtDetallesCuentas.Rows.Count];
                                porcentajesAux = new decimal[dtDetallesCuentas.Rows.Count];

                                for (int k = 0; k < dtDetallesCuentas.Rows.Count; k++)
                                {
                                    cuentasAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.CtbCuentaId_NombreCol];
                                    porcentajesAux[k] = (decimal)dtDetallesCuentas.Rows[k][FacturasProveedorDetalleCuentaContableService.Porcentaje_NombreCol];
                                }
                            }
                            else
                            {
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                            }
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto incluyendo el descuento
                            montoNetoDescontado = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                            //Obtener el monto del descuento sin impuesto
                            if (casoDetalles[j].PorcentajeImpuesto == 0)
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento;
                            }
                            else
                            {
                                montoDescuentoNeto = casoDetalles[j].TotalDescuento -
                                                     (casoDetalles[j].TotalBruto *
                                                        casoDetalles[j].PorcentajeDescuento / 100 /
                                                        (1 + (100 / casoDetalles[j].PorcentajeImpuesto))
                                                     );
                            }

                            montoAux = montoNetoDescontado + montoDescuentoNeto;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta segun se tome lo especificado por el 
                            //usuario o lo indicado en la relacion de cuenta por asiento automatico
                            if (cuentasAux == null)
                            {
                                //Se suma el monto por cada cuenta #8
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
                                    //Se suma el monto por cada cuenta #8
                                    detalles.Agregar(cuentasAux[k], 0, montoAux * porcentajesAux[k] / 100, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDetalles[j].Id ?? j, porcentajesAux[k],
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
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Activo_DisminuirClientes:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta ctacte de la persona
                        if (casoCabecera.AfectaCtactePersona != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            for (int k = 0; k < dtPagoTercPersonas.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Caso.Persona.TipoClienteId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                //Calcular tomando el porcentaje del detalle que se translada a la persona y el porcentaje de la cuota
                                //respecto al totla del transpaso
                                montoAux = casoDetalles[j].TotalPago *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignado_NombreCol] / 100 *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignadoCuota_NombreCol] / 100;

                                //Disminuir por el descuento de la cabecera
                                montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                                //Sumar al monto la comision por gestion
                                montoAux *= (1 + (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeComision_NombreCol] / 100);

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                    if (casoDetalles[j].ArticuloId.HasValue)
                                        observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                    else
                                        observacion += ". " + casoDetalles[j].Observacion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                    observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                //Se suma el monto por cada cuenta #9
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Activo_DisminuirPagosARecuperar:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta ctacte de la persona
                        if (casoCabecera.AfectaCtactePersona != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDetalles.Length; j++)
                        {
                            for (int k = 0; k < dtPagoTercPersonas.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, PeriodosService.GetPlanCuenta(periodo_id, sesion));
                                if (casoDetalles[j].ArticuloId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                                }
                                DataTable dtPersona = PersonasService.GetPersonasInfoCompletaPorID(dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol].ToString());
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PersonaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, dtPersona.Rows[0][PersonasService.TipoClienteId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                //Calcular tomando el porcentaje del detalle que se translada a la persona y el porcentaje de la cuota
                                //respecto al totla del transpaso
                                montoAux = casoDetalles[j].TotalPago *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignado_NombreCol] / 100 *
                                           (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeAsignadoCuota_NombreCol] / 100;

                                //Disminuir por el descuento de la cabecera
                                montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                                //Sumar al monto la comision por gestion
                                montoAux *= (1 + (decimal)dtPagoTercPersonas.Rows[k][FCProveedorPagosTercPersonasService.PorcentajeComision_NombreCol] / 100);

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                    if (casoDetalles[j].ArticuloId.HasValue)
                                        observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                    else
                                        observacion += ". " + casoDetalles[j].Observacion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                    observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                                //Se suma el monto por cada cuenta #10
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDetalles[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDetalles[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion));
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Activo_DisminuirCajaPorPagosTercerosPorCreditoFiscal:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta credito fiscal
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            //Obtener el monto neto incluyendo el descuento
                            montoAux = casoDetalles[j].TotalPago - casoDetalles[j].TotalImpuestoDescontado;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta #11
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.FCProveedores_Aprobado_a_Pendiente.Pasivo_DisminuirProveeodoresPorPagosTercerosPorCreditoFiscal:

                        //Solo se asienta si la factura es por pago de deudas de terceros
                        if (casoCabecera.TipoFacturaProveedorId != Definiciones.TipoFacturaProveedor.PagoTerceros)
                            continue;

                        //Solo se asienta si afecta credito fiscal
                        if (casoCabecera.AfectaCredFiscalEmpresa != Definiciones.SiNo.Si)
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
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, casoDetalles[j].Articulo.FamiliaId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, casoDetalles[j].Articulo.GrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, casoDetalles[j].Articulo.SubGrupoId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, casoDetalles[j].ArticuloId.Value);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, casoDetalles[j].Articulo.EsDanhado);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, casoDetalles[j].Articulo.EsUsado);
                            }
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoCabecera.CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.FuncionarioId_NombreCol, casoCabecera.FuncionarioId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol, casoCabecera.ProveedorGastoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RubroId_NombreCol, casoDetalles[j].RubroId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.StockDepositoId_NombreCol, casoCabecera.StockDepositoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.Sucursal.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoDetalles[j].TextoPredefinidoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, casoDetalles[j].ImpuestoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDetalles[j].TotalPago;

                            //Disminuir por el descuento de la cabecera
                            montoAux *= (1 - casoCabecera.PorcentajeDescSobreTotal / 100);

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoCabecera.Proveedor.RazonSocial + ", ";
                                if (casoDetalles[j].ArticuloId.HasValue)
                                    observacion += (casoDetalles[j].Articulo.DescripcionProveedor.Length > 0 ? casoDetalles[j].Articulo.DescripcionProveedor : casoDetalles[j].Articulo.DescripcionInterna) + " " + casoDetalles[j].Lote.Lote + ". " + casoDetalles[j].Observacion;
                                else
                                    observacion += ". " + casoDetalles[j].Observacion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.No))
                                observacion = CalcularObservacionDetalle(asientoAutomaticoDetalle, casoCabecera.Caso, casoCabecera, casoDetalles[j], sesion);

                            //Se suma el monto por cada cuenta #12
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.MonedaCotizacion, observacion, invertirDebeHaber, invertirSiEsNegativo,
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
        #endregion AsentarAprobadoAPendiente
    }
}
