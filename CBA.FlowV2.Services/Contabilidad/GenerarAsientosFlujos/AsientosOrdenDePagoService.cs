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
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Anticipo;
using System.Diagnostics;
using CBA.FlowV2.Services.RecursosHumanos;
using System.Collections.Generic;
using CBA.FlowV2.Services.NotaCreditosProveedores;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad.GenerarAsientosFlujos
{
    public class AsientosOrdenDePagoService : AsientosAutomaticosService
    {
        #region subclase CentrosCostoAplicacion
        private class CentrosCostoAplicacionDocumentos : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacionDocumentos(object caso_cabecera, object caso_detalles, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                var cabecera = (OrdenesPagoService)caso_cabecera;
                var detalles = (OrdenesPagoDetalleService[])caso_detalles;

                for (int i = 0; i < detalles.Length; i++)
                {
                    decimal porcentaje = detalles[i].MontoDestino.Value / cabecera.MontoTotal;
                    this.porcentajeDetalleSobreTotal.Add(detalles[i].Id ?? (decimal)i, porcentaje);
                }
            }
            #endregion Constructor
        }

        private class CentrosCostoAplicacionValores : CentrosCostoService.CentrosCostoAplicacionWorkaround
        {
            #region Constructor
            public CentrosCostoAplicacionValores(object caso_cabecera, object caso_detalle, FlujosServiceBaseWorkaround flujoService, SessionService sesion)
                : base(flujoService)
            {
                var cabecera = (OrdenesPagoService)caso_cabecera;
                var detalles = (OrdenesPagoValoresService[])caso_detalle;

                for (int i = 0; i < detalles.Length; i++)
                {
                    decimal porcentaje = detalles[i].MontoDestino / cabecera.MontoTotal;
                    this.porcentajeDetalleSobreTotal.Add(detalles[i].Id ?? (decimal)i, porcentaje);
                }
            }
            #endregion Constructor
        }
        #endregion subclase CentrosCostoAplicacion

        #region Constructor
        public AsientosOrdenDePagoService(int asiento_automatico_id)
            : base(asiento_automatico_id){}
        #endregion Constructor

        #region CalcularObservacion
        protected override string CalcularObservacionCabecera(CasosService caso, object cabecera, SessionService sesion)
        {
            EstructuraObservacionHelper eo = new EstructuraObservacionHelper(this.EstructuraObservacion);
            var casoCabecera = (OrdenesPagoService)cabecera;

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
                    case EstructuraObservacionHelper.Campo.Persona:
                        eo.Set(campo, caso.PersonaId.HasValue ? caso.Persona.NombreCompleto : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.Proveedor:
                        eo.Set(campo, caso.ProveedorId.HasValue ? caso.Proveedor.RazonSocial : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.FuncionarioCabecera:
                        eo.Set(campo, caso.FuncionarioId.HasValue ? caso.Funcionario.Persona.NombreCompleto : string.Empty);
                        break;
                    case EstructuraObservacionHelper.Campo.ObservacionCabecera:
                        eo.Set(campo, casoCabecera.Observacion);
                        break;
                    case EstructuraObservacionHelper.Campo.TextoPredefinidoCabecera:
                        eo.Set(campo, casoCabecera.TextoPredefinido.Texto);
                        break;
                    default:
                        throw new Exception("Campo no implementado");
                }
            }

            if (eo.observacion.Length > 0)
                return eo.observacion;
            else
                return AsientosService.GetObservacion((int)this.Id.Value, caso, casoCabecera.Observacion, sesion);
        }

        private string CalcularObservacionValor(OrdenesPagoValoresService valor, SessionService sesion)
        {
            string observacion = string.Empty;

            switch ((int)valor.CtacteValorId)
            {
                case Definiciones.CuentaCorrienteValores.Cheque:
                    if (valor.CRCtacteChequeRecibidoId.HasValue)
                    {
                        var dtChequeRecibido = CuentaCorrienteChequesRecibidosService.GetCuentaCorrienteChequesRecibidosInfoCompleta2(CuentaCorrienteChequesRecibidosService.Id_NombreCol + " = " + valor.CRCtacteChequeRecibidoId.Value, string.Empty, sesion);
                        observacion = dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.VistaBancoAbreviatura_NombreCol] + " Cta. " + dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.NumeroCuenta_NombreCol] + 
                                      " Cheque " + dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.NumeroCheque_NombreCol] + " " + dtChequeRecibido.Rows[0][CuentaCorrienteChequesRecibidosService.NombreEmisor_NombreCol];
                    }
                    else if (valor.CGCtacteChequeGiradoId.HasValue)
                    {
                        var dtChequeGirado = CuentaCorrienteChequesGiradosService.GetCuentaCorrienteChequesGiradosInfoCompleta2(CuentaCorrienteChequesGiradosService.Id_NombreCol + " = " + valor.CGCtacteChequeGiradoId.Value, string.Empty, sesion);
                        observacion = dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.VistaCtaCteBancoAbreviatura_NombreCol] + " Cta. " + dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.VistaCuentaBancaria_NombreCol] +
                                      " Cheque " + dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.NumeroCheque_NombreCol] + " Vto. " + ((DateTime)dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.FechaVencimiento_NombreCol]).ToShortDateString() +
                                      " Es diferido: " + dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.EsDiferido_NombreCol] + " Beneficiario: " + dtChequeGirado.Rows[0][CuentaCorrienteChequesGiradosService.NombreBeneficiario_NombreCol];
                    }
                    break;
                case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                    observacion = "Cupón " + valor.TCCupon;
                    break;
                case Definiciones.CuentaCorrienteValores.Anticipo:
                    if (valor.AnticipoProveedorId.HasValue)
                    {
                        var dtAnticipo = AnticiposProveedorService.GetAnticipoProveedorInfoCompleta(AnticiposProveedorService.Id_NombreCol + " = " + valor.AnticipoProveedorId, string.Empty, sesion);
                        if (dtAnticipo.Rows.Count > 0)
                        {
                            observacion = "Caso Nº" + dtAnticipo.Rows[0][AnticiposProveedorService.CasoId_NombreCol] +
                                          " saldo: " + dtAnticipo.Rows[0][AnticiposProveedorService.VistaMonedaSimbolo_NombreCol] + "." + ((decimal)dtAnticipo.Rows[0][AnticiposProveedorService.SaldoPorAplicar_NombreCol]).ToString(valor.MonedaOrigen.CadenaDecimales);
                        }
                    }
                    break;
                case Definiciones.CuentaCorrienteValores.NotaDeCredito:
                    if (valor.NotaCreditoProveedorId.HasValue)
                    {
                        var dtNotaCredito = NotasCreditoProveedorService.GetNotaCreditoProveedorInfoCompleta(NotasCreditoProveedorService.Id_NombreCol + " = " + valor.NotaCreditoProveedorId, string.Empty, sesion);
                        if (dtNotaCredito.Rows.Count > 0)
                        {
                            observacion = "Caso " + dtNotaCredito.Rows[0][NotasCreditoProveedorService.CasoId_NombreCol] + " Nº Comp: " + dtNotaCredito.Rows[0][NotasCreditoProveedorService.NroComprobante_NombreCol] +
                                          " saldo: " + dtNotaCredito.Rows[0][NotasCreditoProveedorService.VistaMonedaSimbolo_NombreCol] + "." + ((decimal)dtNotaCredito.Rows[0][NotasCreditoProveedorService.SaldoPorAplicar_NombreCol]).ToString(valor.MonedaOrigen.CadenaDecimales);
                        }
                    }
                    break;
                case Definiciones.CuentaCorrienteValores.TransferenciaBancaria:
                    if (valor.TransferenciaBancariaId.HasValue)
                    {
                        var dtTransferenciaBancaria = TransferenciasBancariasService.GetTransferenciasBancariasInfoCompleta(TransferenciasBancariasService.Id_NombreCol + " = " + valor.TransferenciaBancariaId.Value, string.Empty, sesion);
                        if (dtTransferenciaBancaria.Rows.Count > 0)
                        {
                            observacion = "Caso " + dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.CasoId_NombreCol] + " Nro. " + dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.NumeroTransaccion_NombreCol] +
                                          " de " + Interprete.ObtenerString(dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.VistaCtacteBancoOrigenAbrev_NombreCol]) + " " + Interprete.ObtenerString(dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol]) +
                                          " a " + Interprete.ObtenerString(dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.VistaCtacteBancoDestinoAbrev_NombreCol]) + " " + Interprete.ObtenerString(dtTransferenciaBancaria.Rows[0][TransferenciasBancariasService.NumeroCuentaDestino_NombreCol]);
                        }
                    }
                    break;
                case Definiciones.CuentaCorrienteValores.RetencionIVA:
                    var dtRetencion = CuentaCorrienteRetencionesEmitidasService.GetCuentaCorrienteRetencionesEmitidasInfoCompletaStatic(CuentaCorrienteRetencionesEmitidasService.Id_NombreCol + " = " + valor.RetencionEmitidaId, string.Empty, sesion);
                    observacion = "Retención " + dtRetencion.Rows[0][CuentaCorrienteRetencionesEmitidasService.NroComprobante_NombreCol] + " del " + valor.RetencionFecha.Value.ToShortDateString();
                    break;
                case Definiciones.CuentaCorrienteValores.DebitoAutomatico:
                    if (valor.DebitoAutomCtacteBancId.HasValue)
                    {
                        observacion = valor.DebitoAutomCtacteBanc.CtacteBanco.Abreviatura + " Cta. " + valor.DebitoAutomCtacteBanc.NumeroCuenta;
                    }
                    break;
            }

            if (observacion.Length > 0)
                observacion += " ";
            observacion += valor.Observacion;

            return observacion;
        }
        #endregion CalcularObservacion

        #region AsentarAprobadoAGeneracion
        /// <summary>
        /// Asentars the aprobado A generacion.
        /// - Aumentar pagos en proceso (monto bruto)
        /// - Disminuir caja (monto bruto)
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarAprobadoAGeneracion(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Documentos,
                Definiciones.Contabilidad.ClavesDatos.Valores,
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (OrdenesPagoService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDocumentos = (OrdenesPagoDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Documentos];
            var casoValores = (OrdenesPagoValoresService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Valores];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux = 0;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacionValores centrosCostoAp = new CentrosCostoAplicacionValores(casoCabecera, casoValores, new OrdenesPagoService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.SucursalOrigen.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.SucursalOrigen.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if (casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.CasoId);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, CalcularObservacionCabecera(casoCabecera.Caso, casoCabecera, sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion.Egreso_AumentarPagosEnProceso:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);
                            if(casoValores[j].CGCtacteChequeGiradoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesGiradosService.GetEstado(casoValores[j].CGCtacteChequeGiradoId.Value, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoValores[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);

                            for (int k = 0; k < casoDocumentos.Length; k++)
                            {
                                if (casoDocumentos[k].CtacteFondoFijoId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[k].CtacteFondoFijoId);
                                    break;
                                }
                            }

                            if (casoValores[j].CGCtacteBancariaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].CGCtacteBancariaId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoCabecera.CtacteCajaTesoOrigenId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].MontoDestino;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = CalcularObservacionValor(casoValores[j], sesion); 
                                if (observacion == string.Empty)
                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];
                            
                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoValores[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoValores[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoValores[j], sesion));

                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion.Activo_DisminuirCaja:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);
                            if(casoValores[j].CGCtacteChequeGiradoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesGiradosService.GetEstado(casoValores[j].CGCtacteChequeGiradoId.Value, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoValores[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoValores[j].CGCtacteBancariaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].CGCtacteBancariaId);
                            if (casoValores[j].TransferenciaBancariaId.HasValue)
                            {
                                DataTable dtTransferencia = TransferenciasBancariasService.GetTransferenciasBancariasInfoCompleta(TransferenciasBancariasService.Id_NombreCol + " = " + casoValores[j].TransferenciaBancariaId, string.Empty, sesion);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol]);
                            }
                            if (casoValores[j].DebitoAutomCtacteBancId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].DebitoAutomCtacteBancId);
                            }
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoCabecera.CtacteCajaTesoOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].MontoDestino;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = CalcularObservacionValor(casoValores[j], sesion); 
                                if (observacion == string.Empty)
                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoValores[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoValores[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoValores[j], sesion));
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
        #endregion AsentarAprobadoAGeneracion

        #region AsentarGeneracionAAnulado
        /// <summary>
        /// Asentars the generacion A anulado.
        /// - Aumentar caja (monto bruto)
        /// - Disminuir pagos en proceso (monto bruto)
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarGeneracionAAnulado(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Documentos,
                Definiciones.Contabilidad.ClavesDatos.Valores,
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (OrdenesPagoService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDocumentos = (OrdenesPagoDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Documentos];
            var casoValores = (OrdenesPagoValoresService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Valores];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacionValores centrosCostoAp = new CentrosCostoAplicacionValores(casoCabecera, casoValores, new OrdenesPagoService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.SucursalOrigen.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.SucursalOrigen.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if (casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.CasoId);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, CalcularObservacionCabecera(casoCabecera.Caso, casoCabecera, sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado.Activo_AumentarCaja:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);
                            if (casoValores[j].CGCtacteChequeGiradoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesGiradosService.GetEstado(casoValores[j].CGCtacteChequeGiradoId.Value, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoValores[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoValores[j].CGCtacteBancariaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].CGCtacteBancariaId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoCabecera.CtacteCajaTesoOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].MontoDestino;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = CalcularObservacionValor(casoValores[j], sesion);
                                if (observacion == string.Empty)
                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado.Egreso_DisminuirPagosEnProceso:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);
                            if (casoValores[j].CGCtacteChequeGiradoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesGiradosService.GetEstado(casoValores[j].CGCtacteChequeGiradoId.Value, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoValores[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoValores[j].CGCtacteBancariaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].CGCtacteBancariaId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoCabecera.CtacteCajaTesoOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].MontoDestino;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = CalcularObservacionValor(casoValores[j], sesion);
                                if (observacion == string.Empty)
                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];
                            
                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoValores[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoValores[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
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
        #endregion AsentarGeneracionAAnulado

        #region AsentarGeneracionACerrado
        /// <summary>
        /// Asentars the generacion A cerrado.
        /// - Disminuir pagos en proceso (monto bruto)
        /// - Aumentar por monto bruto segun tipo de OP
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="pais_id">The pais_id.</param>
        public decimal AsentarGeneracionACerrado(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Documentos,
                Definiciones.Contabilidad.ClavesDatos.Valores,
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (OrdenesPagoService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDocumentos = (OrdenesPagoDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Documentos];
            var casoValores = (OrdenesPagoValoresService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Valores];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal periodoId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacionDocumentos centrosCostoAp = new CentrosCostoAplicacionDocumentos(casoCabecera, casoDocumentos, new OrdenesPagoService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            string clausulas = OperacionesService.CasoId_NombreCol + " = " + casoCabecera.CasoId.ToString("#") + " and " +
                               OperacionesService.EstadoOriginalId_NombreCol + " = '" + Definiciones.EstadosFlujos.Generacion + "' and " +
                               OperacionesService.EstadoResultanteId_NombreCol + " = '" + Definiciones.EstadosFlujos.Cerrado + "' ";
            DataTable dtOperaciones = OperacionesService.GetOperacionesDataTable(clausulas, OperacionesService.Id_NombreCol + " desc", sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.SucursalOrigen.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.SucursalOrigen.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if (casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.CasoId);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, CalcularObservacionCabecera(casoCabecera.Caso, casoCabecera, sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Egreso_DisminuirPagosEnProceso:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;                                 
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];
                            
                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Pasivo_DisminuirProvedoresPorPagoProveedorExtranjero:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Pasivo_DisminuirProvedoresPorPagoProveedorLocal:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.No)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarFondoFijoPorReposicion:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.ReposicionFondoFijo)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarPagoFuncionarios:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoFuncionarios)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarAnticipoFuncionarios:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.AdelantoFuncionario)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarAnticipoProveedores:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarPorCambioDivisa:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoCambioDivisa)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarPorCustodiaValores:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoCustodiaValores)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarPorDescuentoDocumentos:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoDescuentoDocumentos)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarPorTransferenciaBancaria:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoTransferenciaBancaria)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarPorTransferenciaTesoreria:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoTransferenciaTesoreria)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarPorAjusteBancario:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoAjusteBancario)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarClientesPorPagoPersonas:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAPersona)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Cerrado.Activo_AumentarCreditoPorPagoPersonas:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAPersona)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (!casoDocumentos[j].CasoReferidoId.HasValue || casoDocumentos[j].CasoReferido.FlujoId != Definiciones.FlujosIDs.CREDITOS)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
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
        #endregion AsentarGeneracionACerrado

        #region AsentarAprobadoAGeneracionUNIFICADO
        public decimal AsentarAprobadoAGeneracionUNIFICADO(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Documentos,
                Definiciones.Contabilidad.ClavesDatos.Valores,
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (OrdenesPagoService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDocumentos = (OrdenesPagoDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Documentos];
            var casoValores = (OrdenesPagoValoresService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Valores];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal periodoId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacionDocumentos centrosCostoAp = new CentrosCostoAplicacionDocumentos(casoCabecera, casoDocumentos, new OrdenesPagoService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            string clausulas = OperacionesService.CasoId_NombreCol + " = " + casoCabecera.CasoId.ToString("#") + " and " +
                               OperacionesService.EstadoOriginalId_NombreCol + " = '" + Definiciones.EstadosFlujos.Aprobado + "' and " +
                               OperacionesService.EstadoResultanteId_NombreCol + " = '" + Definiciones.EstadosFlujos.Generacion + "' ";
            DataTable dtOperaciones = OperacionesService.GetOperacionesDataTable(clausulas, OperacionesService.Id_NombreCol + " desc", sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.SucursalOrigen.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.SucursalOrigen.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if (casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.CasoId);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, CalcularObservacionCabecera(casoCabecera.Caso, casoCabecera, sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                decimal condicionPagoId = Definiciones.Error.Valor.EnteroPositivo;

                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_DisminuirCaja:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);
                            if(casoValores[j].CGCtacteChequeGiradoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesGiradosService.GetEstado(casoValores[j].CGCtacteChequeGiradoId.Value, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoValores[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoValores[j].CGCtacteBancariaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].CGCtacteBancariaId);
                            if (casoValores[j].TransferenciaBancariaId.HasValue)
                            {
                                DataTable dtTransferencia = TransferenciasBancariasService.GetTransferenciasBancariasInfoCompleta(TransferenciasBancariasService.Id_NombreCol + " = " + casoValores[j].TransferenciaBancariaId, string.Empty, sesion);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol]);
                            }
                            if (casoValores[j].DebitoAutomCtacteBancId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].DebitoAutomCtacteBancId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoCabecera.CtacteCajaTesoOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].MontoDestino;
                            
                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = CalcularObservacionValor(casoValores[j], sesion); 
                                if (observacion == string.Empty)
                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoValores[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoValores[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoValores[j], sesion));

                            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.SucursalOrigen.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;

                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.DisminuirPagosEnProceso:
                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (!casoDocumentos[j].CasoReferidoId.HasValue || casoDocumentos[j].CasoReferido.FlujoId != Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                                continue;

                            DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId.Value, string.Empty);
                            string facturaId = factProveedor.Rows[0][FacturasProveedorService.Id_NombreCol].ToString();
                            DataTable factProveedorDet = FacturasProveedorDetalleService.GetFacturaProveedorDetalleInfoCompleta(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + facturaId, string.Empty);

                            condicionPagoId = (decimal)factProveedor.Rows[0][FacturasProveedorService.CtacteCondicionPagoId_NombreCol];
                            if (!CondicionesPagoService.GetTipoCondicionPago(condicionPagoId).ToUpper().Equals(Definiciones.CondicionPagoTipo.CONTADO))
                                continue;

                            for (int k = 0; k < factProveedorDet.Rows.Count; k++)
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol]);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                if (casoCabecera.PersonaId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                }
                                if (casoCabecera.ProveedorId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);

                                if (!Interprete.EsNullODBNull(factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]))
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloFamiliaId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloGrupoId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ImpuestoId_NombreCol]);
                                }
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol]);

                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                decimal participacion = (decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.TotalPago_NombreCol] * (100 - (decimal)factProveedor.Rows[0][FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol]) / 100 / (decimal)factProveedor.Rows[0][FacturasProveedorService.TotalPago_NombreCol];
                                montoAux =  participacion * casoDocumentos[j].MontoOrigen.Value;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                    if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                        observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                    else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                        observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(factProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol].ToString()));

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionVenta, (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol], (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaCotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)factProveedor.Rows[0][FacturasProveedorService.ProveedorId_NombreCol], Definiciones.Tablas.Proveedores);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Pasivo_DisminuirProvedoresPorPagoProveedorExtranjero:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                            {
                                DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId, string.Empty);
                                string facturaId = factProveedor.Rows[0][FacturasProveedorService.Id_NombreCol].ToString();
                                DataTable factProveedorDet = FacturasProveedorDetalleService.GetFacturaProveedorDetalleInfoCompleta(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + facturaId, string.Empty);

                                condicionPagoId = (decimal)factProveedor.Rows[0][FacturasProveedorService.CtacteCondicionPagoId_NombreCol];
                                if (!CondicionesPagoService.GetTipoCondicionPago(condicionPagoId).ToUpper().Equals(Definiciones.CondicionPagoTipo.CREDITO))
                                    continue;

                                for (int k = 0; k < factProveedorDet.Rows.Count; k++)
                                {
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                    if (casoCabecera.PersonaId.HasValue)
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    }
                                    if (casoCabecera.ProveedorId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                    if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                    if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);

                                    if (!Interprete.EsNullODBNull(factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]))
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloFamiliaId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloGrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ImpuestoId_NombreCol]);
                                    }
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol]);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    decimal participacion = (decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.TotalPago_NombreCol] * (100 - (decimal)factProveedor.Rows[0][FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol]) / 100 / (decimal)factProveedor.Rows[0][FacturasProveedorService.TotalPago_NombreCol];
                                    montoAux = participacion * casoDocumentos[j].MontoOrigen.Value;

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                    {
                                        observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                        if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                            observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                        else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                            observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                    }

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(factProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol].ToString()));

                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionVenta, (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol], (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaCotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                     centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)factProveedor.Rows[0][FacturasProveedorService.ProveedorId_NombreCol], Definiciones.Tablas.Proveedores);
                                }
                            }
                            else
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                if (casoCabecera.PersonaId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                }
                                if (casoCabecera.ProveedorId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = casoDocumentos[j].MontoDestino.Value;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                    if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                        observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                    else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                        observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.ProveedorId.Value, Definiciones.Tablas.Proveedores);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Pasivo_DisminuirProvedoresPorPagoProveedorLocal:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.No)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                            {
                                DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId, string.Empty);
                                string facturaId = factProveedor.Rows[0][FacturasProveedorService.Id_NombreCol].ToString();
                                DataTable factProveedorDet = FacturasProveedorDetalleService.GetFacturaProveedorDetalleInfoCompleta(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + facturaId, string.Empty);

                                condicionPagoId = (decimal)factProveedor.Rows[0][FacturasProveedorService.CtacteCondicionPagoId_NombreCol];
                                if (!CondicionesPagoService.GetTipoCondicionPago(condicionPagoId).ToUpper().Equals(Definiciones.CondicionPagoTipo.CREDITO))
                                    continue;

                                for (int k = 0; k < factProveedorDet.Rows.Count; k++)
                                {
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                    if (casoCabecera.PersonaId.HasValue)
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    }
                                    if (casoCabecera.ProveedorId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                    if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                    if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);

                                    if (!Interprete.EsNullODBNull(factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]))
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloFamiliaId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloGrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ImpuestoId_NombreCol]);
                                    }
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol]);

                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    decimal participacion = (decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.TotalPago_NombreCol] * (100 - (decimal)factProveedor.Rows[0][FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol]) / 100 / (decimal)factProveedor.Rows[0][FacturasProveedorService.TotalPago_NombreCol];
                                    montoAux = participacion * casoDocumentos[j].MontoOrigen.Value;

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                    {
                                        observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                        if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                            observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                        else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                            observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                    }

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(factProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol].ToString()));

                                    Debug.WriteLine("Envía: " + montoAux * cotizacionVenta);

                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionVenta, (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol], (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaCotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                     centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)factProveedor.Rows[0][FacturasProveedorService.ProveedorId_NombreCol], Definiciones.Tablas.Proveedores);
                                }

                            }
                            else
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                if (casoCabecera.PersonaId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                }
                                if (casoCabecera.ProveedorId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = casoDocumentos[j].MontoDestino.Value;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                    if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                        observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                    else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                        observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.ProveedorId.Value, Definiciones.Tablas.Proveedores);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarFondoFijoPorReposicion:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.ReposicionFondoFijo)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarPagoFuncionarios:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoFuncionarios)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            DataTable dtFuncionariosLiquidacion = FuncionariosLiquidacionesService.GetLiquidacionesInfoCompletaDataTable2(FuncionariosLiquidacionesService.Id_NombreCol + " = " + casoDocumentos[j].LiquidacionId.Value, string.Empty);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)dtFuncionariosLiquidacion.Rows[0][FuncionariosLiquidacionesService.FuncionarioId_NombreCol], Definiciones.Tablas.Funcionarios);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarAnticipoFuncionarios:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.AdelantoFuncionario)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            DataTable dtFuncionariosAdelantos = FuncionarioAdelantoService.GetFuncionarioAdelantoDataTableStatic(FuncionarioAdelantoService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId, string.Empty);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)dtFuncionariosAdelantos.Rows[0][FuncionarioAdelantoService.FuncionarioId_NombreCol], Definiciones.Tablas.Funcionarios);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarAnticipoProveedores:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.ProveedorId, Definiciones.Tablas.Proveedores);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarPorCambioDivisa:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoCambioDivisa)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }
                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarPorCustodiaValores:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoCustodiaValores)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarPorDescuentoDocumentos:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoDescuentoDocumentos)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarPorTransferenciaBancaria:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoTransferenciaBancaria)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarPorTransferenciaTesoreria:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoTransferenciaTesoreria)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarPorAjusteBancario:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoAjusteBancario)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarClientesPorPagoPersonas:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAPersona)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.Activo_AumentarCreditoPorPagoPersonas:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAPersona)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (!casoDocumentos[j].CasoReferidoId.HasValue || casoDocumentos[j].CasoReferido.FlujoId != Definiciones.FlujosIDs.CREDITOS)
                                continue;

                            var credito = CreditosService.Instancia.GetPrimero<CreditosService>(new ClaseCBABase.Filtro
                            {
                                Columna = CreditosService.Modelo.CASO_IDColumnName,
                                Valor = casoDocumentos[j].CasoReferidoId
                            });
                            credito.IniciarUsingSesion(sesion);

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Aprobado_a_Generacion_UNIFICADO.DiferenciaDeTotales:
                        
                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                        if (casoCabecera.PersonaId.HasValue)
                        {
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                        }
                        if (casoCabecera.ProveedorId.HasValue)
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoCabecera.CtacteCajaTesoOrigenId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = 0;
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            if (casoValores[j].MonedaOrigenId == monedaPais )
                                montoAux += casoValores[j].MontoDestino;
                            else
                                montoAux += casoValores[j].MontoOrigen * cotizacionMonedaPais; 
                        }

                        decimal totalValores = montoAux;
                        decimal totalDetalles = 0;

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].MonedaOrigenId.Value == monedaPais)
                            {
                                totalDetalles += casoDocumentos[j].MontoDestino.Value;
                                montoAux -= casoDocumentos[j].MontoDestino.Value;
                            }
                            else
                            {
                                if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                                {
                                    DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId.Value, string.Empty);
                                    decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(factProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol].ToString()));

                                    totalDetalles += casoDocumentos[j].MontoOrigen.Value * cotizacionVenta;
                                    montoAux -= casoDocumentos[j].MontoOrigen.Value * cotizacionVenta;
                                }
                                else if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR)
                                {
                                    DataTable anticipo = AnticiposProveedorService.GetAnticipoProveedorDataTable(AnticiposProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId.Value, string.Empty);
                                    decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(anticipo.Rows[0][AnticiposProveedorService.Fecha_NombreCol].ToString()));

                                    totalDetalles += casoDocumentos[j].MontoOrigen.Value * cotizacionVenta;
                                    montoAux -= casoDocumentos[j].MontoOrigen.Value * cotizacionVenta;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        decimal debe = montoAux < 0 ? 0 : Math.Abs(montoAux);
                        decimal haber = montoAux < 0 ? Math.Abs(montoAux) : 0;
                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, debe, haber, monedaPais, cotizacionMonedaPais, monedaPais, cotizacionMonedaPais, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, casoCabecera.Id.Value, 100,
                                         centrosCostoAp.Seleccionar(casoCabecera.Id.Value,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    casoCabecera.Caso, casoCabecera, null, sesion));
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
        #endregion AsentarAprobadoAGeneracionUNIFICADO

        #region AsentarGeneracionAAnuladoUNIFICADO
        public decimal AsentarGeneracionAAnuladoUNIFICADO(Hashtable datos_caso, DateTime fecha_asiento, decimal periodo_id, DataTable asientos_detalle, SessionService sesion)
        {
            List<string> lCamposRequeridos = new List<string>()
            {
                Definiciones.Contabilidad.ClavesDatos.Cabecera,
                Definiciones.Contabilidad.ClavesDatos.Documentos,
                Definiciones.Contabilidad.ClavesDatos.Valores,
            };

            foreach (string clave in lCamposRequeridos)
            {
                if (!datos_caso.ContainsKey(clave))
                    throw new Exception("El diccionario debe contener la clave " + clave + ".");
            }

            var casoCabecera = (OrdenesPagoService)datos_caso[Definiciones.Contabilidad.ClavesDatos.Cabecera];
            casoCabecera.IniciarUsingSesion(sesion);

            var casoDocumentos = (OrdenesPagoDetalleService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Documentos];
            var casoValores = (OrdenesPagoValoresService[])datos_caso[Definiciones.Contabilidad.ClavesDatos.Valores];

            Hashtable campos = new Hashtable();
            AsientosDetalleService.Detalles detalles;
            Hashtable parametrosElegirCuenta;
            decimal asientoCabeceraId;
            decimal periodoId;
            decimal cuentaAux, montoAux;
            decimal monedaPais, cotizacionMonedaPais;
            bool invertirDebeHaber = false, invertirSiEsNegativo = false, crearAsiento = true;
            string observacion;
            CentrosCostoAplicacionDocumentos centrosCostoAp = new CentrosCostoAplicacionDocumentos(casoCabecera, casoDocumentos, new OrdenesPagoService(), sesion);
            decimal planCuentaId = PeriodosService.GetPlanCuenta(periodo_id, sesion);

            string clausulas = OperacionesService.CasoId_NombreCol + " = " + casoCabecera.CasoId.ToString("#") + " and " +
                               OperacionesService.EstadoOriginalId_NombreCol + " = '" + Definiciones.EstadosFlujos.Generacion + "' and " +
                               OperacionesService.EstadoResultanteId_NombreCol + " = '" + Definiciones.EstadosFlujos.Anulado + "' ";
            DataTable dtOperaciones = OperacionesService.GetOperacionesDataTable(clausulas, OperacionesService.Id_NombreCol + " desc", sesion);

            monedaPais = CBA.FlowV2.Services.Herramientas.PaisesService.GetMoneda(casoCabecera.SucursalOrigen.PaisId, sesion);
            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.SucursalOrigen.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);

            //Crear la cabecera del asiento
            campos.Add(AsientosService.CtbPeriodoId_NombreCol, periodo_id);
            if (casoCabecera.Caso.AlmacenarLocalmente)
                campos.Add(AsientosService.CasoRelacionadoId_NombreCol, casoCabecera.CasoId);
            campos.Add(AsientosService.Aprobado_NombreCol, Definiciones.SiNo.No);
            campos.Add(AsientosService.Automatico_NombreCol, Definiciones.SiNo.Si);
            campos.Add(AsientosService.FechaAsiento_NombreCol, fecha_asiento);
            campos.Add(AsientosService.Observacion_NombreCol, CalcularObservacionCabecera(casoCabecera.Caso, casoCabecera, sesion));
            campos.Add(AsientosService.RevisionPosterior_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaRevisionPosterior_NombreCol]);
            campos.Add(AsientosService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
            campos.Add(AsientosService.TransicionId_NombreCol, asientos_detalle.Rows[0][AsientosAutomaticosDetalleService.VistaTransicionId_NombreCol]);
            asientoCabeceraId = AsientosService.Guardar(campos, true, sesion);

            //Por cada detalle de asiento automatico seleccionar las cuentas y agregar el detalle
            for (int i = 0; i < asientos_detalle.Rows.Count; i++)
            {
                decimal condicionPagoId = Definiciones.Error.Valor.EnteroPositivo;

                switch (int.Parse(asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol].ToString()))
                {
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_AumentarCaja:

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteValorId_NombreCol, casoValores[j].CtacteValorId);
                            if(casoValores[j].CGCtacteChequeGiradoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol, CBA.FlowV2.Services.Tesoreria.CuentaCorrienteChequesGiradosService.GetEstado(casoValores[j].CGCtacteChequeGiradoId.Value, sesion));
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoValores[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoValores[j].CGCtacteBancariaId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].CGCtacteBancariaId);
                            if (casoValores[j].TransferenciaBancariaId.HasValue)
                            {
                                DataTable dtTransferencia = TransferenciasBancariasService.GetTransferenciasBancariasInfoCompleta(TransferenciasBancariasService.Id_NombreCol + " = " + casoValores[j].TransferenciaBancariaId, string.Empty, sesion);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol]);
                            }
                            if (casoValores[j].DebitoAutomCtacteBancId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol, casoValores[j].DebitoAutomCtacteBancId);
                            }
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoCabecera.CtacteCajaTesoOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoValores[j].MontoDestino;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = CalcularObservacionValor(casoValores[j], sesion); 
                                if (observacion == string.Empty)
                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoValores[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoValores[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoValores[j], sesion));

                            cotizacionMonedaPais = CBA.FlowV2.Services.Herramientas.CotizacionesService.GetCotizacionMonedaVenta(casoCabecera.SucursalOrigen.PaisId, monedaPais, casoCabecera.Fecha.Value, sesion);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.AumentarPagosEnProceso:
                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                            {
                                DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId, string.Empty);
                                string facturaId = factProveedor.Rows[0][FacturasProveedorService.Id_NombreCol].ToString();
                                DataTable factProveedorDet = FacturasProveedorDetalleService.GetFacturaProveedorDetalleInfoCompleta(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + facturaId, string.Empty);

                                condicionPagoId = (decimal)factProveedor.Rows[0][FacturasProveedorService.CtacteCondicionPagoId_NombreCol];
                                if (!CondicionesPagoService.GetTipoCondicionPago(condicionPagoId).ToUpper().Equals(Definiciones.CondicionPagoTipo.CONTADO))
                                    continue;

                                for (int k = 0; k < factProveedorDet.Rows.Count; k++)
                                {
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, factProveedor.Rows[0][FacturasProveedorService.Id_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                    if (casoCabecera.PersonaId.HasValue)
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    }
                                    if (casoCabecera.ProveedorId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                    if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                    if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);

                                    if (!Interprete.EsNullODBNull(factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]))
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloFamiliaId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloGrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ImpuestoId_NombreCol]);
                                    }
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol]);
                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    decimal participacion = (decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.TotalPago_NombreCol] * (100 - (decimal)factProveedor.Rows[0][FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol]) / 100 / (decimal)factProveedor.Rows[0][FacturasProveedorService.TotalPago_NombreCol];
                                    montoAux = participacion * casoDocumentos[j].MontoOrigen.Value;
                                    
                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                    {
                                        observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                        if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                            observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                        else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                            observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                    }

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(factProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol].ToString()));

                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionVenta, (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol], (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaCotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                     centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)factProveedor.Rows[0][FacturasProveedorService.ProveedorId_NombreCol], Definiciones.Tablas.Proveedores);
                                }
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);
                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Pasivo_AumentarProvedoresPorPagoProveedorExtranjero:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        if (casoCabecera.Proveedor.esNacional == Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                            {
                                DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId, string.Empty);
                                string facturaId = factProveedor.Rows[0][FacturasProveedorService.Id_NombreCol].ToString();
                                DataTable factProveedorDet = FacturasProveedorDetalleService.GetFacturaProveedorDetalleInfoCompleta(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + facturaId, string.Empty);

                                condicionPagoId = (decimal)factProveedor.Rows[0][FacturasProveedorService.CtacteCondicionPagoId_NombreCol];
                                if (!CondicionesPagoService.GetTipoCondicionPago(condicionPagoId).ToUpper().Equals(Definiciones.CondicionPagoTipo.CREDITO))
                                    continue;

                                for (int k = 0; k < factProveedorDet.Rows.Count; k++)
                                {
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, factProveedor.Rows[0][FacturasProveedorService.Id_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                    if (casoCabecera.PersonaId.HasValue)
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    }
                                    if (casoCabecera.ProveedorId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                    if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                    if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);

                                    if (!Interprete.EsNullODBNull(factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]))
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloFamiliaId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloGrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ImpuestoId_NombreCol]);
                                    }
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol]);

                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    decimal participacion = (decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.TotalPago_NombreCol] * (100 - (decimal)factProveedor.Rows[0][FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol]) / 100 / (decimal)factProveedor.Rows[0][FacturasProveedorService.TotalPago_NombreCol];
                                    montoAux = participacion * casoDocumentos[j].MontoOrigen.Value;

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                    {
                                        observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                        if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                            observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                        else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                            observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                    }

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol], (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaCotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                     centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)factProveedor.Rows[0][FacturasProveedorService.ProveedorId_NombreCol], Definiciones.Tablas.Proveedores);
                                }
                            }
                            else
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                if (casoCabecera.PersonaId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                }
                                if (casoCabecera.ProveedorId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = casoDocumentos[j].MontoDestino.Value;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                    if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                        observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                    else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                        observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, montoAux, 0, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.ProveedorId.Value, Definiciones.Tablas.Proveedores);
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Pasivo_AumentarProvedoresPorPagoProveedorLocal:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        if (casoCabecera.Proveedor.esNacional != Definiciones.SiNo.Si)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                            {
                                DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId, string.Empty);
                                string facturaId = factProveedor.Rows[0][FacturasProveedorService.Id_NombreCol].ToString();
                                DataTable factProveedorDet = FacturasProveedorDetalleService.GetFacturaProveedorDetalleInfoCompleta(FacturasProveedorDetalleService.FacturaProveedorId_NombreCol + " = " + facturaId, string.Empty);

                                condicionPagoId = (decimal)factProveedor.Rows[0][FacturasProveedorService.CtacteCondicionPagoId_NombreCol];
                                if (!CondicionesPagoService.GetTipoCondicionPago(condicionPagoId).ToUpper().Equals(Definiciones.CondicionPagoTipo.CREDITO))
                                    continue;

                                for (int k = 0; k < factProveedorDet.Rows.Count; k++)
                                {
                                    #region seleccionar cuentas contables
                                    parametrosElegirCuenta = new Hashtable();
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol]);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                    if (casoCabecera.PersonaId.HasValue)
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                    }
                                    if (casoCabecera.ProveedorId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                    if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                    if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);

                                    if (!Interprete.EsNullODBNull(factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]))
                                    {
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloFamiliaId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloGrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.VistaArticuloSubgrupoId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]);
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol, ArticulosService.GetEsDanhado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ArticuloUsado_NombreCol, ArticulosService.GetEsUsado((decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.ArticuloId_NombreCol]));
                                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ImpuestoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.ImpuestoId_NombreCol]);
                                    }
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, factProveedorDet.Rows[k][FacturasProveedorDetalleService.TextoPredefinidoId_NombreCol]);

                                    cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                    if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                        continue;
                                    #endregion seleccionar cuentas contables

                                    decimal participacion = (decimal)factProveedorDet.Rows[k][FacturasProveedorDetalleService.TotalPago_NombreCol] * (100 - (decimal)factProveedor.Rows[0][FacturasProveedorService.PorcentajeDescSobreTotal_NombreCol]) / 100 / (decimal)factProveedor.Rows[0][FacturasProveedorService.TotalPago_NombreCol];
                                    montoAux = participacion * casoDocumentos[j].MontoOrigen.Value;

                                    observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                    if (!detalles.Resumido)
                                    {
                                        observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                        if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                            observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                        else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                            observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                    }

                                    if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                        observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                    //Se suma el monto por cada cuenta
                                    detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaId_NombreCol], (decimal)factProveedor.Rows[0][FacturasProveedorService.MonedaCotizacion_NombreCol], observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                     centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                     centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                                asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                                casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)factProveedor.Rows[0][FacturasProveedorService.ProveedorId_NombreCol], Definiciones.Tablas.Proveedores);
                                }
                            }
                            else
                            {
                                #region seleccionar cuentas contables
                                parametrosElegirCuenta = new Hashtable();
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                                if (casoCabecera.PersonaId.HasValue)
                                {
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                                }
                                if (casoCabecera.ProveedorId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                                if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                                if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                    parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                                cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                                if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                    continue;
                                #endregion seleccionar cuentas contables

                                montoAux = casoDocumentos[j].MontoDestino.Value;

                                observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                                if (!detalles.Resumido)
                                {
                                    observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                    if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                        observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                    else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                        observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                                }

                                if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                    observacion = (string)campos[AsientosService.Observacion_NombreCol];

                                //Se suma el monto por cada cuenta
                                detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                                 centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                                 centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                            asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                            casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.ProveedorId.Value, Definiciones.Tablas.Proveedores);
                            
                            }
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirFondoFijoPorReposicion:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.ReposicionFondoFijo)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirPagoFuncionarios:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoFuncionarios)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            DataTable dtFuncionariosLiquidacion = FuncionariosLiquidacionesService.GetLiquidacionesInfoCompletaDataTable2(FuncionariosLiquidacionesService.Id_NombreCol + " = " + casoDocumentos[j].LiquidacionId.Value, string.Empty);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)dtFuncionariosLiquidacion.Rows[0][FuncionariosLiquidacionesService.FuncionarioId_NombreCol], Definiciones.Tablas.Funcionarios);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirAnticipoFuncionarios:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.AdelantoFuncionario)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            DataTable dtFuncionariosAdelantos = FuncionarioAdelantoService.GetFuncionarioAdelantoDataTableStatic(FuncionarioAdelantoService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId, string.Empty);

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), (decimal)dtFuncionariosAdelantos.Rows[0][FuncionarioAdelantoService.FuncionarioId_NombreCol], Definiciones.Tablas.Funcionarios);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirAnticipoProveedores:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.ProveedorId, Definiciones.Tablas.Proveedores);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirPorCambioDivisa:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoCambioDivisa)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirPorCustodiaValores:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoCustodiaValores)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirPorDescuentoDocumentos:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoDescuentoDocumentos)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirPorTransferenciaBancaria:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoTransferenciaBancaria)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirPorTransferenciaTesoreria:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoTransferenciaTesoreria)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirPorAjusteBancario:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.RespaldoAjusteBancario)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));
                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion));
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirClientesPorPagoPersonas:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAPersona)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.CREDITOS)
                                continue;

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.Activo_DisminuirCreditoPorPagoPersonas:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAPersona)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (!casoDocumentos[j].CasoReferidoId.HasValue || casoDocumentos[j].CasoReferido.FlujoId != Definiciones.FlujosIDs.CREDITOS)
                                continue;

                            var credito = CreditosService.Instancia.GetPrimero<CreditosService>(new ClaseCBABase.Filtro
                            {
                                Columna = CreditosService.Modelo.CASO_IDColumnName,
                                Valor = casoDocumentos[j].CasoReferidoId.Value
                            });
                            credito.IniciarUsingSesion(sesion);

                            #region seleccionar cuentas contables
                            parametrosElegirCuenta = new Hashtable();
                            if (!Interprete.EsNullODBNull(credito.CanalVentaId))
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol, credito.CanalVentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoDocumentos[j].MonedaOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                            if (casoCabecera.PersonaId.HasValue)
                            {
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                            }
                            if (casoCabecera.ProveedorId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                            if (casoDocumentos[j].CtacteCajaTesoDestinoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoDocumentos[j].CtacteCajaTesoDestinoId);
                            if (casoDocumentos[j].CtacteFondoFijoId.HasValue)
                                parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol, casoDocumentos[j].CtacteFondoFijoId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                            cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                            if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                continue;
                            #endregion seleccionar cuentas contables

                            montoAux = casoDocumentos[j].MontoDestino.Value;

                            observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                            if (!detalles.Resumido)
                            {
                                observacion = casoDocumentos[j].CasoReferido.Flujo.DescripcionImpresion + ". ";
                                if (casoDocumentos[j].CtacteProveedorId.HasValue)
                                    observacion += casoDocumentos[j].CtacteProveedor.CtacteConcepto.Descripcion;
                                else if (casoDocumentos[j].CtactePersonaId.HasValue)
                                    observacion += casoDocumentos[j].CtactePersona.CtacteConcepto.Descripcion;
                            }

                            if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                                observacion = (string)campos[AsientosService.Observacion_NombreCol];

                            //Se suma el monto por cada cuenta
                            detalles.Agregar(cuentaAux, 0, montoAux, monedaPais, cotizacionMonedaPais, casoCabecera.MonedaId, casoCabecera.CotizacionMoneda, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                             centrosCostoAp, casoDocumentos[j].Id ?? j, 100,
                                             centrosCostoAp.Seleccionar(casoDocumentos[j].Id ?? j,
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                        asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                        casoCabecera.Caso, casoCabecera, casoDocumentos[j], sesion), casoCabecera.PersonaId, Definiciones.Tablas.Personas);
                        }
                        #endregion sumar separando en cuentas

                        foreach (AsientosDetalleService.Detalle d in detalles.Resultado())
                            AsientosDetalleService.Guardar(detalles.AsientoId, d, centrosCostoAp, sesion);

                        break;
                    case Definiciones.Contabilidad.AsientosAutomaticosDetalle.OrdenDePago_Generacion_a_Anulado_UNIFICADO.DiferenciaDeTotales:

                        if (casoCabecera.OrdenPagoTipoId != Definiciones.TiposOrdenesPago.PagoAProveedor)
                            continue;

                        #region sumar separando en cuentas
                        detalles = new AsientosDetalleService.Detalles(asientoCabeceraId, asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol].Equals(Definiciones.SiNo.Si));

                        #region seleccionar cuentas contables
                        parametrosElegirCuenta = new Hashtable();
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol, planCuentaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.MonedaId_NombreCol, casoCabecera.MonedaId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.SucursalId_NombreCol, casoCabecera.SucursalOrigenId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.RegionId_NombreCol, casoCabecera.SucursalOrigen.RegionId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol, casoCabecera.OrdenPagoTipoId);
                        if (casoCabecera.PersonaId.HasValue)
                        {
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.PersonaId_NombreCol, casoCabecera.PersonaId);
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TipoClienteId_NombreCol, casoCabecera.Persona.TipoClienteId);
                        }
                        if (casoCabecera.ProveedorId.HasValue)
                            parametrosElegirCuenta.Add(AsientosAutoRelacionesService.ProveedorId_NombreCol, casoCabecera.ProveedorId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol, casoCabecera.CtacteCajaTesoOrigenId);
                        parametrosElegirCuenta.Add(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol, casoCabecera.TextoPredefinidoId);
                        cuentaAux = AsientosAutomaticosDetalleService.GetCuentaAAsentar((decimal)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Id_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol], asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol], parametrosElegirCuenta, out invertirDebeHaber, out invertirSiEsNegativo, ref crearAsiento, sesion);
                        if (cuentaAux.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            continue;
                        #endregion seleccionar cuentas contables

                        montoAux = 0;
                        for (int j = 0; j < casoValores.Length; j++)
                        {
                            if (casoValores[j].MonedaOrigenId == monedaPais)
                            {
                                montoAux += casoValores[j].MontoDestino;
                            }
                            else
                            {
                                montoAux += casoValores[j].MontoOrigen * cotizacionMonedaPais;
                            }

                        }

                        decimal totalValores = montoAux;
                        decimal totalDetalles = 0;

                        for (int j = 0; j < casoDocumentos.Length; j++)
                        {
                            if (casoDocumentos[j].MonedaOrigenId.Value == monedaPais)
                            {
                                totalDetalles += casoDocumentos[j].MontoDestino.Value;
                                montoAux -= casoDocumentos[j].MontoDestino.Value;
                            }
                            else
                            {
                                if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.FACTURACION_PROVEEDOR)
                                {
                                    DataTable factProveedor = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId.Value, string.Empty);
                                    decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(factProveedor.Rows[0][FacturasProveedorService.FechaFactura_NombreCol].ToString()));

                                    totalDetalles += casoDocumentos[j].MontoOrigen.Value * cotizacionVenta;
                                    montoAux -= casoDocumentos[j].MontoOrigen.Value * cotizacionVenta;
                                }
                                else if (casoDocumentos[j].CasoReferidoId.HasValue && casoDocumentos[j].CasoReferido.FlujoId == Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR)
                                {
                                    DataTable anticipo = AnticiposProveedorService.GetAnticipoProveedorDataTable(AnticiposProveedorService.CasoId_NombreCol + " = " + casoDocumentos[j].CasoReferidoId.Value, string.Empty);
                                    decimal cotizacionVenta = CotizacionesService.GetCotizacionMonedaVenta(monedaPais, DateTime.Parse(anticipo.Rows[0][AnticiposProveedorService.Fecha_NombreCol].ToString()));

                                    totalDetalles += casoDocumentos[j].MontoOrigen.Value * cotizacionVenta;
                                    montoAux -= casoDocumentos[j].MontoOrigen.Value * cotizacionVenta;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        observacion = (string)asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                        if (asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                            observacion = (string)campos[AsientosService.Observacion_NombreCol];

                        decimal haber = montoAux < 0 ? 0 : Math.Abs(montoAux);
                        decimal debe = montoAux < 0 ? Math.Abs(montoAux) : 0;
                        //Se suma el monto por cada cuenta
                        detalles.Agregar(cuentaAux, debe, haber, monedaPais, cotizacionMonedaPais, monedaPais, cotizacionMonedaPais, observacion, invertirDebeHaber, invertirSiEsNegativo,
                                         centrosCostoAp, casoCabecera.Id.Value, 100,
                                         centrosCostoAp.Seleccionar(casoCabecera.Id.Value,
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol],
                                                                    asientos_detalle.Rows[i][AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol],
                                                                    casoCabecera.Caso, casoCabecera, null, sesion));
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
        #endregion AsentarGeneracionAAnuladoUNIFICADO
    }
}
