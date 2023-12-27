#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Common;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Articulos;
using System.Collections.Specialized;
using System.Text;
using CBA.FlowV2.Services.ToolbarFlujo;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.EgresosVariosCaja;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.Activos;
using CBA.FlowV2.Services.Stock;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public partial class CreditosService : FlujosServiceBase<CreditosService>
    {
        #region Implementacion dependiente de cliente
        #region FechaPrimerVencimientoSugerido
        private DateTime FechaPrimerVencimientoSugerido_9()
        {
            DateTime fecha = this.FechaRetiro.HasValue ? this.FechaRetiro.Value : this.FechaSolicitud;
            switch (this.TipoFrecuencia)
            {
                case Definiciones.TiposIntervalo.Anhos:
                    fecha = fecha.AddYears((int)this.Frecuencia);
                    break;
                case Definiciones.TiposIntervalo.Dias:
                    fecha = fecha.AddDays((int)this.Frecuencia);
                    break;
                case Definiciones.TiposIntervalo.Meses:
                    fecha = fecha.AddMonths((int)this.Frecuencia);
                    break;
                case Definiciones.TiposIntervalo.Semanas:
                    fecha = fecha.AddDays((int)this.Frecuencia * 7);
                    break;
                default: throw new Exception("CreditosService.FechaPrimerVencimientoSugerido. Tipo de frecuencia " + this.TipoFrecuencia + "no implementado");
            }

            if (fecha.Day <= 5)
            {
                //no hacer nada
            }
            else if (fecha.Day <= 15)
            {
                fecha = new DateTime(fecha.Year, fecha.Month, 5);
            }
            else
            {
                fecha = new DateTime(fecha.Year, fecha.Month, 5).AddMonths(1);
            }

            return fecha;
        }

        private DateTime FechaPrimerVencimientoSugerido_23()
        {
            DateTime fecha = this.FechaRetiro.HasValue ? this.FechaRetiro.Value : this.FechaSolicitud;

            if (this.ArticuloId.HasValue && this.ArticuloFinanciero.ReglasPrimerVencimiento != null)
            { 
                FechaUtil.VencimientoDinamico.Regla regla = null;
                foreach (var r in this.ArticuloFinanciero.ReglasPrimerVencimiento.reglas)
	            {
            	    switch(r.tipo)
                    {
                        case FechaUtil.VencimientoDinamico.Regla.Tipo.DiaEntre:
                            if(r.limiteInferior <= fecha.Day && fecha.Day <= r.limiteSuperior)
                                regla = r;
                            break;
                    }

                    if (regla != null)
                        break;
	            }

                if(regla != null)
                    return FechaUtil.VencimientoDinamico.GetPrimerVencimiento(regla, fecha);
            }
            
            //Si no se encontró una regla a aplicar, continuar con la lógica
            //Si el canal de venta es Aso o Gremio, el primer vencimiento
            //es a los 60 dias
            if (this.CanalVentaId.HasValue && (this.CanalVentaId.Value == 1 || this.CanalVentaId.Value == 2))
            {
                fecha = fecha.AddDays(60);
            }
            else if (this.CanalVentaId.HasValue && (this.CanalVentaId.Value == 3 || this.CanalVentaId.Value == 4))
            {
                fecha = fecha.AddMonths(1);
            }
            else
            {
                switch (this.TipoFrecuencia)
                {
                    case Definiciones.TiposIntervalo.Anhos:
                        fecha = fecha.AddYears((int)this.Frecuencia);
                        break;
                    case Definiciones.TiposIntervalo.Dias:
                        fecha = fecha.AddDays((int)this.Frecuencia);
                        break;
                    case Definiciones.TiposIntervalo.Meses:
                        fecha = fecha.AddMonths((int)this.Frecuencia);
                        break;
                    case Definiciones.TiposIntervalo.Semanas:
                        fecha = fecha.AddDays((int)this.Frecuencia * 7);
                        break;
                    default: throw new Exception("CreditosService.FechaPrimerVencimientoSugerido. Tipo de frecuencia " + this.TipoFrecuencia + "no implementado");
                }
            }

            return fecha;
        }
        #endregion FechaPrimerVencimientoSugerido

        #region ModificarDatosFactura
        private void ModificarDatosFactura(decimal caso_factura_id, SessionService sesion)
        {
            switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
            {
                case Definiciones.Clientes.Electroban:
                    ModificarDatosFactura_9(caso_factura_id, sesion);
                    break;
            }
        }

        private void ModificarDatosFactura_9(decimal caso_factura_id, SessionService sesion)
        {
            var dt = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoId_NombreCol + " = " + caso_factura_id, string.Empty, sesion);
            FacturasClienteService.SetNroComprobanteExterno((decimal)dt.Rows[0][FacturasClienteService.Id_NombreCol], "0", sesion);
        }
        #endregion ModificarDatosFactura
        #endregion Implementacion dependiente de cliente

        #region Clase Webmethods
        private static class Webmethods
        {
            #region Clase ConsultarNumeroDocumentoExterno
            public static class ConsultarNumeroDocumentoExterno
            {
               
            }
            #endregion ConsultarNumeroDocumentoExterno

            #region Clase ActualizarNumeroDocumentoExterno
            public static class ActualizarNumeroDocumentoExterno
            {
              
            }
            #endregion ActualizarNumeroDocumentoExterno
        }
        #endregion Clase Webmethods

        #region valores constantes
        public static class ValoresConstantes
        {
            public const string CancelacionAnticipadaNotaCreditoAutonumeracion = "CancelacionAnticipadaNotaCreditoAutonumeracion";
            public const string CancelacionAnticipadaNotaCreditoCajaSucursal = "CancelacionAnticipadaNotaCreditoCajaSucursal";
            public const string CreditoFacturaAlDesembolsarCajaSucursal = "CreditoFacturaAlDesembolsarCajaSucursal";
        }
        #endregion valores constantes

        #region Implementacion de metodos abstract
        #region GetFlujoId
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.CREDITOS;
        }
        #endregion GetFlujoId

        #region SeleccionarCentrosCosto
        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var cabecera = (CreditosService)caso_cabecera;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            if(cabecera.ArticuloId.HasValue)
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, cabecera.ArticuloId.Value);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }
        #endregion SeleccionarCentrosCosto

        #region EjecutarAccionesCambioEstado
        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza las acciones necesarias al cambiar de estado un caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="cambio_pedido_por_usuario">El cambio fue pedido por el usuario o por el sistema</param>
        /// <param name="mensaje">The mensaje de salida.</param>
        /// <returns>
        /// True si no los controles se ejecutaron exitosamente, si no false.
        /// </returns>
        protected override CasosService EjecutarAccionesCambioEstado(string estado_destino, bool cambio_pedido_por_usuario, SessionService sesion)
        {
            bool inicializarSesionLocal = this.sesion == null;
            if (inicializarSesionLocal)
                this.IniciarUsingSesion(sesion);

            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            //Verificar si se cumplen los requisitos
            base.VerificarRequisitosDelFlujo(this.CasoId.Value, this.sesion);

            //Borrador a Pendiente
            if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
            {
                //Acciones
                //Se genera la numeracion si no existia un numero de comprobante definido
                //Se crean las cuotas en el calendario si no existian

                #region Verificar Puede Avanzar Estado
                string mensaje = string.Empty;
                if (!VerificarPuedeAvanzarEstado(this.CasoId.Value, out mensaje, this.sesion))
                {
                    throw new Exception(mensaje);
                }
                #endregion Verificar Puede Avanzar Estado

                if (this.NroComprobante.Length <= 0)
                {
                    if (!AutonumeracionesService.FuncionarioPuedeUsar(this.AutonumeracionId, this.FuncionarioId, this.sesion))
                        throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");

                    this.NroComprobante = AutonumeracionesService.GetSiguienteNumero2(this.AutonumeracionId, this.sesion);

                    //Controlar que se logro asignar una numeracion
                    if (this.NroComprobante.Length <= 0)
                        throw new Exception("No se pudo asignar una numeración válida");
                }

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CreditosValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                {
                    if (!this.ConsultarNumeroDocumentoExterno(out mensaje, this.sesion))
                        throw new Exception(mensaje);
                }

                if (this.Calendario.Length <= 0)
                {
                    this.MontoInteres = 0;
                    foreach (var cuota in TiposCreditoService.CalcularCuotasPorTipo(this))
                    {
                        cuota.IniciarUsingSesion(sesion);
                        this.MontoInteres += cuota.MontoInteresADevengar;
                        cuota.Guardar();
                        cuota.FinalizarUsingSesion();
                    }
                }
            }
            //Pendiente a Borrador
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
            {
                //Acciones
                //Borrar las cuotas del calendario.
                //Borrar el pagaré de garantía si fue creado manualmente 
                string clausula = CuentaCorrientePagaresService.CasoGarantiaId_NombreCol + " = " + this.CasoId;
                DataTable dt = CuentaCorrientePagaresService.GetCuentaCorrientePagaresDataTable(clausula, string.Empty);

                this.MontoInteres = 0;
                foreach (var cuota in this.Calendario)
                {
                    cuota.IniciarUsingSesion(sesion);
                    cuota.Borrar();
                    cuota.FinalizarUsingSesion();
                }
                if (dt.Rows.Count > 0)
                    CuentaCorrientePagaresService.Borrar((decimal)dt.Rows[0][CuentaCorrientePagaresService.Id_NombreCol], this.sesion);
            }
            //Pendiente a PreAprobado 
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.PreAprobado))
            {
                //Acciones
                //Controlar que el capital y la cantidad de cuotas aprobados sean mayor a cero.
                //Controlar que el total capital de las cuotas sean igual al capital aprobado.
                //Controlar que la persona y su conyuge (si no existe separacion de bienes) no esten bloqueados, en inforconf o judicial
                //Verificar linea de credito persona y co-deudores
                //Controlar los niveles de aprobacion segun el tipo de articulo financiero, si esta definido
                //Controlar que los descuentos y retenciones no superan al monto a desembolsar
                //Copiar los detalles personalizados al historico para que no sean modificables

                #region Verificar Puede Avanzar Estado
                string mensaje = string.Empty;
                if (!VerificarPuedeAvanzarEstado(this.CasoId.Value, out mensaje, this.sesion))
                {
                    throw new Exception(mensaje);
                }
                #endregion Verificar Puede Avanzar Estado

                string clausulas = string.Empty;
                DataTable dtDetallesPersonalizados;

                if (this.MontoCapitalAprobado <= 0)
                    throw new Exception("El capital aprobado debe ser mayor a cero.");

                if (this.CantidadCuotas <= 0)
                    throw new Exception("La cantidad de cuotas debe ser mayor a cero.");

                //Se controla que el deudor y los garantes cumplan los requerimientos
                this.Validar();

                #region Verificar linea de credito persona y co-deudores
                if (this.AfectaLineaCredito == Definiciones.SiNo.Si && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CreditosPersonaControlLineaCredito) == Definiciones.SiNo.Si)
                {
                    if (!this.Persona.ControlLineaCredito(this.CasoId.Value, this.MonedaId, this.MontoTotal, this.Cotizacion, this.SucursalId, this.FechaSolicitud, this.sesion))
                        throw new Exception("La persona no cuenta con suficiente saldo en su línea de crédito.");

                    if (this.PersonaGarante1Id.HasValue && !PersonaGarante1.ControlLineaCredito(this.CasoId.Value, this.MonedaId, this.MontoTotal, this.Cotizacion, this.SucursalId, this.FechaSolicitud, this.sesion))
                        throw new Exception("El garante 1 no cuenta con suficiente saldo en su línea de crédito.");

                    if (this.PersonaGarante2Id.HasValue && !PersonaGarante2.ControlLineaCredito(this.CasoId.Value, this.MonedaId, this.MontoTotal, this.Cotizacion, this.SucursalId, this.FechaSolicitud, this.sesion))
                        throw new Exception("El garante 2 no cuenta con suficiente saldo en su línea de crédito.");
                }
                #endregion Verificar linea de credito persona y co-deudores

                decimal totalCapitalCuotas = 0;
                for (int i = 0; i < this.Calendario.Length; i++)
                    totalCapitalCuotas += this.Calendario[i].MontoCapital;

                if (Math.Round(totalCapitalCuotas, this.Moneda.CantidadDecimales) != Math.Round(this.MontoCapitalAprobado, this.Moneda.CantidadDecimales))
                    throw new Exception("El capital aprobado es " + this.MontoCapitalAprobado.ToString(this.Moneda.CadenaDecimales) + " y la suma del capital en las cuotas es de " + totalCapitalCuotas.ToString(this.Moneda.CadenaDecimales) + ".");

                #region Controlar los niveles de aprobacion
                if (this.ArticuloId.HasValue)
                {
                    var af = this.GetPrimero<ArticulosFinancierosService>(new Filtro { Columna = ArticulosFinancierosService.Modelo.ARTICULO_IDColumnName, Valor = this.ArticuloId.Value });
                    decimal aprobaciones = 0;
                    if (this.Aprobacion1 == Definiciones.SiNo.Si)
                        aprobaciones++;
                    if (this.Aprobacion2 == Definiciones.SiNo.Si)
                        aprobaciones++;
                    if (this.Aprobacion3 == Definiciones.SiNo.Si)
                        aprobaciones++;
                    if (aprobaciones < af.TipoArticuloFinanciero.CantidadAprobaciones)
                        throw new Exception("El artículo financiero requiere al menos " + af.TipoArticuloFinanciero.CantidadAprobaciones + " usuarios que aprueben el crédito.");
                }
                #endregion Controlar los niveles de aprobacion

                #region Controlar que los descuentos y retenciones no superan al monto a desembolsar
                decimal totalDesembolso = this.MontoCapitalAprobado - this.MontoDescuentos;
                decimal totalDescuentos = 0;

                foreach (var d in this.Descuentos)
                {
                    if (d.MonedaId == this.MonedaId)
                        totalDescuentos += d.Monto;
                    else
                        totalDescuentos += d.Monto / d.Cotizacion * this.Cotizacion;
                }

                if (Math.Round(totalDesembolso - totalDescuentos, this.Moneda.CantidadDecimales) < 0)
                    throw new Exception("El monto a desembolsar (" + totalDesembolso.ToString(this.Moneda.CadenaDecimales) + ") no puede ser menor al monto a descontar (" + totalDescuentos.ToString(this.Moneda.CadenaDecimales) + ").");
                #endregion Controlar que los descuentos y retenciones no superan al monto a desembolsar

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CreditosValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                {
                    if (!this.ConsultarNumeroDocumentoExterno(out mensaje, this.sesion))
                        throw new Exception(mensaje);
                }

                //Copiar los detalles personalizados al historico para que no sean modificables
                #region Detalles personalizados - Referencia creditos de terceros
                clausulas = LegajoService.PersonaId_NombreCol + " = " + this.PersonaId + " and " +
                            LegajoService.VistaTipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros + " and " +
                            LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                dtDetallesPersonalizados = LegajoService.GetLegajoInfoCompleta(clausulas, string.Empty);
                if(dtDetallesPersonalizados.Rows.Count > 0)
                    DetallesPersonalizados.DetallesPersonalizadosHistoricoService.Guardar(Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, dtDetallesPersonalizados.Rows[0][LegajoService.Id_NombreCol].ToString(), true, this.CasoId.Value, this.sesion);
                #endregion Detalles personalizados - Referencia creditos de terceros

                #region Detalles personalizados - Referencias personales
                clausulas = LegajoService.PersonaId_NombreCol + " = " + this.PersonaId + " and " +
                            LegajoService.VistaTipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasPersonales + " and " +
                            LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                dtDetallesPersonalizados = LegajoService.GetLegajoInfoCompleta(clausulas, string.Empty);
                if (dtDetallesPersonalizados.Rows.Count > 0)
                    DetallesPersonalizados.DetallesPersonalizadosHistoricoService.Guardar(Definiciones.TiposDetallesPersonalizado.ReferenciasPersonales, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, dtDetallesPersonalizados.Rows[0][LegajoService.Id_NombreCol].ToString(), true, this.CasoId.Value, this.sesion);
                #endregion Detalles personalizados - Referencias personales

                #region Detalles personalizados - Referencias Laborales
                clausulas = LegajoService.PersonaId_NombreCol + " = " + this.PersonaId + " and " +
                            LegajoService.VistaTipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasLaborales + " and " +
                            LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                dtDetallesPersonalizados = LegajoService.GetLegajoInfoCompleta(clausulas, string.Empty);
                if (dtDetallesPersonalizados.Rows.Count > 0)
                    DetallesPersonalizados.DetallesPersonalizadosHistoricoService.Guardar(Definiciones.TiposDetallesPersonalizado.ReferenciasLaborales, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, dtDetallesPersonalizados.Rows[0][LegajoService.Id_NombreCol].ToString(), true, this.CasoId.Value, this.sesion);
                #endregion Detalles personalizados - Referencias Laborales

                if (!CuentaCorrientePagaresService.ExistePorCaso(this.CasoId.Value))
                    this.CrearPagareGarantia();

                //TODO: copiar los detalles personalizados para ingresos y egresos
            }
            //PreAprobado a Aprobado 
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
            {
                //Acciones
                //Verificar que la fecha de retiro esta definida.
                //Verificar linea de credito persona y co-deudores
                //Verificar que se asigno la autonumeracion con que se creara la FC Clientes
                //Afectar la ctacte de la persona con el debito (monto a ser desembolsado a traves de OP)
                //Crear la OP en borrador.

                #region Verificar Puede Avanzar Estado
                string mensaje = string.Empty;
                if (!VerificarPuedeAvanzarEstado(this.CasoId.Value, out mensaje, this.sesion))
                {
                    throw new Exception(mensaje);
                }
                #endregion Verificar Puede Avanzar Estado

                //Se controla que el deudor y los garantes cumplan los requerimientos
                Validar();

                if (!this.FechaRetiro.HasValue)
                    throw new Exception("Debe indicar la fecha de retiro de los valores");

                #region Verificar linea de credito persona y co-deudores
                if (this.AfectaLineaCredito == Definiciones.SiNo.Si && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CreditosPersonaControlLineaCredito) == Definiciones.SiNo.Si)
                {
                    if (!this.Persona.ControlLineaCredito(this.CasoId.Value, this.MonedaId, this.MontoTotal, this.Cotizacion, this.SucursalId, this.FechaSolicitud, this.sesion))
                        throw new Exception("La persona no cuenta con suficiente saldo en su línea de crédito.");

                    if (this.PersonaGarante1Id.HasValue && !PersonaGarante1.ControlLineaCredito(this.CasoId.Value, this.MonedaId, this.MontoTotal, this.Cotizacion, this.SucursalId, this.FechaSolicitud, this.sesion))
                        throw new Exception("El garante 1 no cuenta con suficiente saldo en su línea de crédito.");

                    if (this.PersonaGarante2Id.HasValue && !PersonaGarante2.ControlLineaCredito(this.CasoId.Value, this.MonedaId, this.MontoTotal, this.Cotizacion, this.SucursalId, this.FechaSolicitud, this.sesion))
                        throw new Exception("El garante 2 no cuenta con suficiente saldo en su línea de crédito.");
                }
                #endregion Verificar linea de credito persona y co-deudores

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CreditosValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                {
                    if (!this.ConsultarNumeroDocumentoExterno(out mensaje, this.sesion))
                        throw new Exception(mensaje);
                }

                if (!this.CtacteFondoFijoId.HasValue && this.Permisos.CreditosFondoFijoObligatorioAlPasarAAprobado)
                    throw new Exception("Debe indicar el fondo fijo.");

                if (!this.CtacteCajaSucursalId.HasValue && this.Permisos.CreditosCajaSucursalObligatoriaAlPasarAAprobado)
                    throw new Exception("Debe indicar una caja de sucursal.");

                #region Afectar ctacte agregando debito

                //Ingresar el debito
                //Solo se agrega el debito si se ha marcado como para ser desembolsado
                if (this.DesembolsarParaCliente == Definiciones.SiNo.Si)
                {
                    decimal totalDescuentos = this.MontoDescuentos;
                    foreach (var d in this.Descuentos)
                    {
                        if (d.MonedaId == this.MonedaId)
                            totalDescuentos += d.Monto;
                        else
                            totalDescuentos += d.Monto / d.Cotizacion * this.Cotizacion;
                    }

                    CuentaCorrientePersonasService.AgregarDebito(this.PersonaId,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                                        Definiciones.CuentaCorrienteValores.Credito,
                                        this.CasoId.Value,
                                        this.MonedaId,
                                        this.Cotizacion,
                                        new decimal[] { Definiciones.Impuestos.Exenta },
                                        new decimal[] { this.MontoCapitalAprobado - totalDescuentos },
                                        "Otorgamiento de crédito.",
                                        this.FechaRetiro.Value,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        sesion);
                }
                #endregion Afectar ctacte agregando debito
            }
            //Aprobado a Vigente
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Vigente))
            {
                //Acciones
                //Trensicion efectuada debido a que el desembolso fue finalizado.
                //Afectar la ctacte de la persona con el credito (cuotas a ser pagadas)
                //Crear los anticipos de persona y aplicacion de documentos por los descuentos
                //Verificar si se debe crear la FC Cliente emitida por el capital (exento, segun check en la cabera) y por interes (segun chk en cabecera)

                if (cambio_pedido_por_usuario)
                    throw new Exception("La transición de Aprobado a Vigente es realizada desde el flujo Orden de Pago o Egreso Vario de Caja.");

                CasosService casoService = new CasosService();
                FacturasClienteService facturaClienteService = new FacturasClienteService();
                System.Collections.Hashtable campos;
                string casoFacturaEstado = string.Empty, mensajeFactura;
                bool exitoFactura;
                DataTable dtLote, dtArticulo, dtFacturaCreada;
                decimal montoTotalFactura = 0, montoConcepto, casoFacturaId = Definiciones.Error.Valor.EnteroPositivo;
                DateTime fechaPrimerVencimiento = DateTime.Now, fechaSegundoVencimiento = DateTime.MinValue;
                bool usarFechaPrimerVencimiento = false, usarFechaSegundoVencimiento = false;

                #region Verificar Puede Avanzar Estado
                string mensaje = string.Empty;
                if (!VerificarPuedeAvanzarEstado(this.CasoId.Value, out mensaje, this.sesion))
                {
                    throw new Exception(mensaje);
                }
                #endregion Verificar Puede Avanzar Estado

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CreditosValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                    this.ActualizarNumeroDocumentoExterno(out mensaje, this.sesion);

                #region Afectar ctacte agregando credito
                //Ingresar el credito

                if (this.Calendario.Length <= 0)
                    throw new Exception("No existen cuotas para el crédito.");

                #region Agregar la entrega inicial
                if (this.EntregaInicial > 0)
                {
                    CuentaCorrientePersonasService.AgregarCredito(this.PersonaId,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.CuentaCorrienteConceptos.EntregaInicial,
                                            this.CasoId.Value,
                                            this.MonedaId,
                                            this.Cotizacion,
                                            new decimal[] { Definiciones.Impuestos.Exenta },
                                            new decimal[] { this.EntregaInicial },
                                            string.Empty,
                                            DateTime.Now,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            0,
                                            this.Calendario.Length,
                                            sesion);
                }
                #endregion Agregar la entrega inicial

                for (int i = 0; i < this.Calendario.Length; i++)
                {
                    TiposArticuloFinancieroRangoService interes = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);
                    CuentaCorrientePersonasService.AgregarCredito((decimal)this.PersonaId,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                            this.CasoId.Value,
                                            this.MonedaId,
                                            this.Cotizacion,
                                            new decimal[] { Definiciones.Impuestos.Exenta, interes.Articulo.ImpuestoId },
                                            new decimal[] { this.Calendario[i].MontoCapital, this.Calendario[i].MontoInteresADevengar + this.Calendario[i].MontoImpuesto },
                                            string.Empty,
                                            this.Calendario[i].FechaVencimiento,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            this.Calendario[i].Id.Value,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            i+1,
                                            this.Calendario.Length,
                                            sesion);
                }
                #endregion Afectar ctacte agregando credito

                #region Crear los anticipos de persona y aplicacion de documentos por los descuentos
                decimal totalAplicacionDocumentos = 0;
                decimal casoAnticipoParaAplicacionDocumentos = Definiciones.Error.Valor.EnteroPositivo;
                #region Anticipos
                foreach (var d in this.Descuentos)
                {
                    if (!d.CtactePersonaId.HasValue)
                    {
                        d.IniciarUsingSesion(sesion);
                        d.CasoCreadoId = this.CrearAnticipoPersona(d);
                        d.Guardar();
                        d.FinalizarUsingSesion();
                    }
                    else
                    {
                        if (d.MonedaId == this.MonedaId)
                            totalAplicacionDocumentos += d.Monto;
                        else
                            totalAplicacionDocumentos += d.Monto / d.Cotizacion * this.Cotizacion;
                    }
                }

                if (totalAplicacionDocumentos > 0)
                {
                    var d = new CreditosDescuentosService() 
                    {
                        PersonaId = this.PersonaId,
                        MonedaId = this.MonedaId,
                        Cotizacion = this.Cotizacion,
                        Monto = totalAplicacionDocumentos
                    };
                    casoAnticipoParaAplicacionDocumentos = this.CrearAnticipoPersona(d);
                }
                #endregion Anticipos

                #region Aplicacion Documentos
                if (totalAplicacionDocumentos > 0 && casoAnticipoParaAplicacionDocumentos != Definiciones.Error.Valor.EnteroPositivo)
                {
                    decimal casoCreadoAplicacionId = Definiciones.Error.Valor.EnteroPositivo;
                    string casoCreadoAplicacionEstadoId = string.Empty, mensajeAplicacion = string.Empty;
                    bool exitoAplicacion;

                    DataTable dtAutonumeracionAplicacion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(CBA.FlowV2.Services.Base.Definiciones.FlujosIDs.APLICACION_DOCUMENTOS, this.SucursalId);
                    if (dtAutonumeracionAplicacion.Rows.Count <= 0)
                        throw new Exception("No se encontró un talonario para Aplicación de Documentos en la sucursal " + this.Sucursal.Nombre + ".");

                    if (!this.CtacteCajaSucursalId.HasValue)
                        this.CtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, this.FuncionarioId);
                    if (this.CtacteCajaSucursalId.Value == Definiciones.Error.Valor.EnteroPositivo && !sesion.Usuario.IsFUNCIONARIO_IDNull)
                        this.CtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, this.sesion.Usuario.FUNCIONARIO_ID);
                    if (this.CtacteCajaSucursalId.Value == Definiciones.Error.Valor.EnteroPositivo)
                        throw new Exception("No se encontró una caja abierta en la sucursal " + this.Sucursal.Nombre + " para el funcionario " + this.Funcionario.Nombre + " " + this.Funcionario.Apellido + ".");

                    #region crear cabecera
                    casoCreadoAplicacionId = Definiciones.Error.Valor.EnteroPositivo;
                    Hashtable camposAplicacion = new Hashtable();
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol, this.SucursalId);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.UsuarioId_NombreCol, this.sesion.Usuario.ID);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol, this.PersonaId);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.PersonaValoresId_NombreCol, this.PersonaId);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol, this.FuncionarioId);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.CtacteCajaSucursalId_NombreCol, this.CtacteCajaSucursalId.Value);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol, this.MonedaId);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.Fecha_NombreCol, DateTime.Now);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.Cotizacion_NombreCol, this.Cotizacion);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.AutonumeracionId_NombreCol, dtAutonumeracionAplicacion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.ConsolidacionDeuda_NombreCol, Definiciones.SiNo.No);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol, totalAplicacionDocumentos);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.TotalValores_NombreCol, totalAplicacionDocumentos);
                    camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.Observacion_NombreCol, string.Empty);
                    NotasCreditoPersonaAplicacionesService.Guardar(camposAplicacion, true, ref casoCreadoAplicacionId, ref casoCreadoAplicacionEstadoId, this.sesion);
                    DataTable dtAplicacionDocumento = NotasCreditoPersonaAplicacionesService.GetNotaCreditoPersonaAplicacionPorCaso(casoCreadoAplicacionId, this.sesion);
                    #endregion crear cabecera

                    #region agregar valores
                    DataTable dtCtactePersonaAnticipo = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + casoAnticipoParaAplicacionDocumentos + " and " + CuentaCorrientePersonasService.Debito_NombreCol + " > " + CuentaCorrientePersonasService.Credito_NombreCol, CuentaCorrientePersonasService.Id_NombreCol, this.sesion);

                    campos = new Hashtable();
                    campos.Add(NotasCreditoPersonaAplicacionValoresService.CtaCtePersonaId_NombreCol, (decimal)dtCtactePersonaAnticipo.Rows[0][CuentaCorrientePersonasService.Id_NombreCol]);
                    campos.Add(NotasCreditoPersonaAplicacionValoresService.Tipo_NombreCol, Definiciones.TipoComprobanteAplicable.Persona);
                    campos.Add(NotasCreditoPersonaAplicacionValoresService.MontoDestino_NombreCol, totalAplicacionDocumentos);
                    campos.Add(NotasCreditoPersonaAplicacionValoresService.MontoOrigen_NombreCol, totalAplicacionDocumentos);
                    campos.Add(NotasCreditoPersonaAplicacionValoresService.Cotizacion_NombreCol, this.Cotizacion);
                    campos.Add(NotasCreditoPersonaAplicacionValoresService.MonedaId_NombreCol, this.MonedaId);
                    campos.Add(NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol, dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol]);
                    NotasCreditoPersonaAplicacionValoresService.Guardar(campos, this.sesion);
                    #endregion agregar cabecera

                    foreach (var d in this.Descuentos)
                    {
                        if (!d.CtactePersonaId.HasValue)
                            continue;

                        d.IniciarUsingSesion(sesion);

                        Hashtable camposDocumentos = new Hashtable();
                        camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol, dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol]);
                        camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol, d.CtactePersonaId.Value);
                        camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol, d.MonedaId);
                        camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol, d.Cotizacion);
                        camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoOrigen_NombreCol, d.Monto);
                        if (d.MonedaId == this.MonedaId)
                            camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol, d.Monto);
                        else
                            camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol, d.Monto / d.Cotizacion * this.Cotizacion);
                        NotasCreditoPersonaAplicacionDocumentosService.Guardar(camposDocumentos, this.sesion);

                        d.CasoCreadoId = casoCreadoAplicacionId;
                        d.Guardar();
                        d.FinalizarUsingSesion();
                    }

                    exitoAplicacion = (new NotasCreditoPersonaAplicacionesService()).ProcesarCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Pendiente, false, out mensajeAplicacion, this.sesion);
                    if (exitoAplicacion)
                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Pendiente, "Transición automática por descuento de Crédito a Persona.", this.sesion);
                    if (exitoAplicacion)
                        (new NotasCreditoPersonaAplicacionesService()).EjecutarAccionesLuegoDeCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Pendiente, this.sesion);

                    exitoAplicacion = (new NotasCreditoPersonaAplicacionesService()).ProcesarCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Aprobado, false, out mensajeAplicacion, this.sesion);
                    if (exitoAplicacion)
                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Aprobado, "Transición automática por descuento de Crédito a Persona.", this.sesion);
                    if (exitoAplicacion)
                        (new NotasCreditoPersonaAplicacionesService()).EjecutarAccionesLuegoDeCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Aprobado, this.sesion);
                }
                #endregion Aplicacion Documentos
                #endregion Crear los anticipos de persona y aplicacion de documentos por los descuentos

                #region Crear la FC Cliente emitida
                //Verificar si la factura a emitir tendra al menos un detalle, si no, no se crea la factura
                if (this.FacturarIntereses == Definiciones.CreditosPoliticaFacturacion.Desembolso || this.FacturarConceptosEnPagos.Equals(Definiciones.SiNo.No) || this.FacturarCapital == Definiciones.CreditosPoliticaFacturacion.Desembolso)
                {
                    int plazo = this.CantidadDias;
                    int diasAnho = this.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;
                    ArticulosService articulo;

                    #region Crear cabecera
                    campos = new System.Collections.Hashtable();
                    campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, this.FacturaClienteAutonId);
                    if (this.CanalVentaId.HasValue)
                        campos.Add(FacturasClienteService.CanalVentaId_NombreCol, this.CanalVentaId.Value);
                    campos.Add(FacturasClienteService.CasoOrigenId_NombreCol, this.CasoId.Value);
                    campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                    campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CondicionPagoCredito));
                    campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, this.Cotizacion);
                    campos.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, this.FechaRetiro);
                    campos.Add(FacturasClienteService.Fecha_NombreCol, this.FechaRetiro);
                    campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, this.MonedaId);
                    campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, (decimal)0);
                    campos.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.Observacion_NombreCol, "Factura creada por crédito " + Traducciones.Caso + " Nº" + this.CasoId.Value);
                    campos.Add(FacturasClienteService.PersonaId_NombreCol, this.PersonaId);
                    campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, (decimal)0);
                    campos.Add(FacturasClienteService.SucursalId_NombreCol, this.SucursalId);
                    campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, Definiciones.TipoFactura.Contado);
                    campos.Add(FacturasClienteService.VendedorId_NombreCol, this.FuncionarioId);
                    
                    if (!this.CtacteCajaSucursalId.HasValue)
                        this.CtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, this.FuncionarioId);
                    if (this.CtacteCajaSucursalId.Value == Definiciones.Error.Valor.EnteroPositivo && !sesion.Usuario.IsFUNCIONARIO_IDNull)
                        this.CtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, this.sesion.Usuario.FUNCIONARIO_ID);
                    if (this.CtacteCajaSucursalId.Value == Definiciones.Error.Valor.EnteroPositivo)
                        throw new Exception("No se encontró una caja abierta en la sucursal " + this.Sucursal.Nombre + " para el funcionario " + this.Funcionario.Nombre + " " + this.Funcionario.Apellido + ".");
                    campos.Add(FacturasClienteService.CtaCteCajaSucursalId_NombreCol, this.CtacteCajaSucursalId);

                    #region Obtener el primer deposito activo de la sucursal
                    DataTable dtStockDepositoAux = Stock.StockDepositosService.GetStockDepositosDataTable(this.SucursalId, true, true);
                    if (dtStockDepositoAux.Rows.Count <= 0)
                        throw new Exception("La sucursal debe tener al menos un depósito en el cual se pueda facturar.");
                    campos.Add(FacturasClienteService.DepositoId_NombreCol, dtStockDepositoAux.Rows[0][Stock.StockDepositosService.Id_NombreCol]);
                    #endregion Obtener el primer deposito activo de la sucursal

                    FacturasClienteService.Guardar(campos, true, ref casoFacturaId, ref casoFacturaEstado, this.sesion);

                    if (casoFacturaId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("No pudo crearse la factura pro intereses en crédito.");

                    this.ModificarDatosFactura(casoFacturaId, this.sesion);

                    dtFacturaCreada = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoId_NombreCol + " = " + casoFacturaId, string.Empty, this.sesion);

                    #endregion Crear cabecera

                    if (this.FacturarCapital == Definiciones.CreditosPoliticaFacturacion.Desembolso)
                    {
                        #region FC Detalle por capital
                        dtArticulo = Articulos.ArticulosService.GetArticulos(Articulos.ArticulosService.Id_NombreCol + " = " + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoCapitalArticulo), string.Empty, false, this.SucursalId);
                        dtLote = Articulos.ArticulosLotesService.GetArticulosLotesInfoCompleta2((decimal)dtArticulo.Rows[0][Articulos.ArticulosService.Id_NombreCol], string.Empty);
                        if (dtLote.Rows.Count <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + dtArticulo.Rows[0][Articulos.ArticulosService.Id_NombreCol] + " definido en la variable de sistema FCClienteComoComprobantePagoCapitalArticulo.");

                        campos = new System.Collections.Hashtable();
                        campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, dtArticulo.Rows[0][Articulos.ArticulosService.Id_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtLote.Rows[0][Articulos.ArticulosLotesService.Id_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, dtArticulo.Rows[0][Articulos.ArticulosService.UnidadMedidaId_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                        campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                        campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, Definiciones.Impuestos.Exenta);
                        campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, this.MontoCapitalAprobado);
                        campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                        campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                        campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, "Correspondiente a capital en crédito " + Traducciones.Caso + " Nº" + this.CasoId.Value);

                        montoTotalFactura += this.MontoCapitalAprobado;

                        FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, this.sesion);
                        #endregion FC Detalle por capital
                    }

                    if (this.FacturarIntereses == Definiciones.CreditosPoliticaFacturacion.Desembolso)
                    {
                        #region FC Detalle por interes
                        articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente).Articulo;
                        if (articulo.ArticulosLotes.Length <= 0)
                            throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                        campos = new System.Collections.Hashtable();
                        campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo.ArticulosLotes[0].ArticuloId);
                        campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, articulo.ArticulosLotes[0].Id.Value);
                        campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, articulo.UnidadMedidaId);
                        campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                        campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                        campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, articulo.ImpuestoId);
                        campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                        campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                        campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, articulo.DescripcionImpresion + " (" + this.CasoId.Value + ")");

                        if (this.MontoInteres.HasValue)
                            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, this.MontoInteres.Value);
                        else
                            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, this.MontoTotal - this.MontoCapitalAprobado);
                        
                        if (this.InteresIncluyeImpuesto == Definiciones.SiNo.No)
                            campos[FacturasClienteDetalleService.PrecioListaDestino_NombreCol] = (decimal)campos[FacturasClienteDetalleService.PrecioListaDestino_NombreCol] * (1 + ImpuestosService.GetPorcentajePorId(articulo.ImpuestoId, this.sesion) / 100);

                        montoTotalFactura += (decimal)campos[FacturasClienteDetalleService.PrecioListaDestino_NombreCol];

                        if((decimal)campos[FacturasClienteDetalleService.PrecioListaDestino_NombreCol] > 0)
                            FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, this.sesion);
                        #endregion FC Detalle por interes
                    }

                    if (this.FacturarConceptosEnPagos == Definiciones.SiNo.No)
                    {
                        #region FC Detalle por gasto administrativo
                        montoConcepto = this.GetMontoGastoAdministrativo(plazo);
                        if (montoConcepto > 0)
                        {
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            campos = new System.Collections.Hashtable();
                            campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                            campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo.ArticulosLotes[0].ArticuloId);
                            campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, articulo.ArticulosLotes[0].Id.Value);
                            campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, articulo.UnidadMedidaId);
                            campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, articulo.ImpuestoId);
                            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, montoConcepto);
                            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, articulo.DescripcionImpresion + " (" + this.CasoId.Value + ")");

                            montoTotalFactura += montoConcepto;
                            FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, this.sesion);
                        }
                        #endregion FC Detalle por gasto administrativo

                        #region FC Detalle por seguro
                        montoConcepto = this.GetMontoSeguro(plazo);
                        if (montoConcepto > 0)
                        {
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Seguro).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            campos = new System.Collections.Hashtable();
                            campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                            campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo.ArticulosLotes[0].ArticuloId);
                            campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, articulo.ArticulosLotes[0].Id.Value);
                            campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, articulo.UnidadMedidaId);
                            campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, articulo.ImpuestoId);
                            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, montoConcepto);
                            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, articulo.DescripcionImpresion + " (" + this.CasoId.Value + ")");

                            montoTotalFactura += montoConcepto;
                            FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, this.sesion);
                        }
                        #endregion FC Detalle por seguro

                        #region FC Detalle por corretaje
                        montoConcepto = this.GetMontoCorretaje(plazo);
                        if (montoConcepto > 0)
                        {
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Corretaje).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            campos = new System.Collections.Hashtable();
                            campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                            campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo.ArticulosLotes[0].ArticuloId);
                            campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, articulo.ArticulosLotes[0].Id.Value);
                            campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, articulo.UnidadMedidaId);
                            campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, articulo.ImpuestoId);
                            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, montoConcepto);
                            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, articulo.DescripcionImpresion + " (" + this.CasoId.Value + ")");

                            montoTotalFactura += montoConcepto;
                            FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, this.sesion);
                        }
                        #endregion FC Detalle por corretaje

                        #region FC Detalle por comision administrativa
                        montoConcepto = this.GetMontoComisionAministrativa(plazo);
                        if (montoConcepto > 0)
                        {
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.ComisionAdministrativa).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            campos = new System.Collections.Hashtable();
                            campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                            campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo.ArticulosLotes[0].ArticuloId);
                            campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, articulo.ArticulosLotes[0].Id.Value);
                            campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, articulo.UnidadMedidaId);
                            campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, articulo.ImpuestoId);
                            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, montoConcepto);
                            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, articulo.DescripcionImpresion + " (" + this.CasoId.Value + ")");

                            montoTotalFactura += montoConcepto;
                            FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, this.sesion);
                        }
                        #endregion FC Detalle por comision administrativa

                        montoConcepto = this.GetMontoOtros(plazo);
                        if (montoConcepto > 0)
                        {
                            #region FC Detalle por otros
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Otros).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            campos = new System.Collections.Hashtable();
                            campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                            campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo.ArticulosLotes[0].ArticuloId);
                            campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, articulo.ArticulosLotes[0].Id.Value);
                            campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, articulo.UnidadMedidaId);
                            campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, articulo.ImpuestoId);
                            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, montoConcepto);
                            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, articulo.DescripcionImpresion + " (" + this.CasoId.Value + ")");

                            montoTotalFactura += montoConcepto;
                            FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, this.sesion);
                        }
                        #endregion FC Detalle por otros
                    }

                    if (this.FacturarBonificacionEnPagos == Definiciones.SiNo.No)
                    {
                        #region FC Detalle por bonificacion
                        montoConcepto = this.GetMontoBonificacion(plazo);
                        if (montoConcepto > 0)
                        {
                            articulo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.BonificacionOrdenCompra).Articulo;
                            if (articulo.ArticulosLotes.Length <= 0)
                                throw new Exception("No existe ningún lote para el artículo " + articulo.DescripcionInterna + ".");

                            campos = new System.Collections.Hashtable();
                            campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                            campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, articulo.ArticulosLotes[0].ArticuloId);
                            campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, articulo.ArticulosLotes[0].Id.Value);
                            campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, articulo.UnidadMedidaId);
                            campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, articulo.ImpuestoId);
                            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, montoConcepto);
                            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                            campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, articulo.DescripcionImpresion + " (" + this.CasoId.Value + ")");

                            montoTotalFactura += montoConcepto;
                            FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, this.sesion);
                        }
                        #endregion FC Detalle por bonificacion
                    }

                    if (montoTotalFactura <= 0)
                    {
                        FacturasClienteService.Borrar(casoFacturaId, this.sesion);
                    }
                    else
                    {
                        //Crear calendario de pagos
                        CalendarioPagosFCClienteService.CrearCuotas((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol],
                                                                     montoTotalFactura,
                                                                     (DateTime)dtFacturaCreada.Rows[0][FacturasClienteService.Fecha_NombreCol],
                                                                     fechaPrimerVencimiento,
                                                                     usarFechaPrimerVencimiento,
                                                                     fechaSegundoVencimiento,
                                                                     usarFechaSegundoVencimiento,
                                                                     sesion);

                        #region Aprobar el caso de FC Cliente
                        //Pasar a Pendiente
                        exitoFactura = facturaClienteService.ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, false, out mensajeFactura, this.sesion);
                        if (exitoFactura)
                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, "Transición automática.", this.sesion);
                        if (exitoFactura)
                            facturaClienteService.EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, this.sesion);
                        if (!exitoFactura)
                            throw new Exception(mensajeFactura);

                        //Pasar a Caja
                        exitoFactura = facturaClienteService.ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, false, out mensajeFactura, this.sesion);
                        if (exitoFactura)
                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, "Transición automática.", this.sesion);
                        if (exitoFactura)
                            facturaClienteService.EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, this.sesion);
                        if (!exitoFactura)
                            throw new Exception(mensajeFactura);

                        //Pasar a Cerrado
                        exitoFactura = facturaClienteService.ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, false, out mensajeFactura, this.sesion);
                        if (exitoFactura)
                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, "Transición automática.", this.sesion);
                        if (exitoFactura)
                            facturaClienteService.EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, this.sesion);
                        if (!exitoFactura)
                            throw new Exception(mensajeFactura);
                        #endregion Aprobar el caso de FC Cliente

                        if (!exitoFactura)
                            throw new Exception("Error al cambiar de estado la Factura creada. " + mensajeFactura);

                        this.FacturaClienteId = (decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol];
                    }
                }
                #endregion Crear la FC Cliente emitida
            }
            //Vigente a Anulado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Vigente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
            {
                #region Verificar Puede Avanzar Estado
                string mensaje = string.Empty;
                if (!VerificarPuedeAvanzarEstado(this.CasoId.Value, out mensaje, this.sesion))
                {
                    throw new Exception(mensaje);
                }
                #endregion Verificar Puede Avanzar Estado

                //Borrar el pagaré de garantía  
                string clausula = CuentaCorrientePagaresService.CasoGarantiaId_NombreCol + " = " + this.CasoId;
                DataTable dt = CuentaCorrientePagaresService.GetCuentaCorrientePagaresDataTable(clausula, string.Empty, this.sesion);

                if (this.DesembolsarParaCliente != Definiciones.SiNo.No)
                    throw new Exception("No se puede Anular el caso por que es una operación con desembolso.");

                if (this.Descuentos.Length > 0)
                    throw new Exception("No se puede Anular el caso por que tiene descuentos y retenciones.");

                CuentaCorrientePagaresService.Borrar((decimal)dt.Rows[0][CuentaCorrientePagaresService.Id_NombreCol], this.sesion);
                CuentaCorrientePersonasService.DeshacerAgregarCreditoPorCaso(this.CasoId.Value, this.sesion);
            }
            //Vigente a En-Revision
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Vigente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.EnRevision))
            {
                //Acciones
                //Verificar que no se realizo una Cancelacion Anticipada previa
                //Marcar todas las cuotas no bloqueadas para que sean incluidas en la cancelación

                foreach (var c in this.Calendario)
                {
                    if (c.CancelacionAnticipada == Definiciones.SiNo.Si)
                        throw new Exception("No puede negociarse una nueva cancelación anticipada del caso " + this.CasoId + ".");
                    if (c.CtactePersona.Bloqueado == Definiciones.SiNo.No)
                        c.CancelacionAnticipada = Definiciones.SiNo.Si;
                }
            }
            //Vigente a Cerrado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Vigente) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
            {
                //Acciones
                //Ninguna, la transicion es realizada por el sistema y no por el usuario
                
                if (cambio_pedido_por_usuario)
                    throw new Exception("La transición de Vigente a Cerrado es realizada por el sistema cuando se salda la deuda");
            }
            //Borrador a Anulado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
            {
                //Acciones
                //Ninguna
            }
            //Pendiente a Anulado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
            {
                //Acciones
                //Borrar el pagaré de garantía si fue creado manualmente 
                string clausula = CuentaCorrientePagaresService.CasoGarantiaId_NombreCol + " = " + this.CasoId;
                DataTable dt = CuentaCorrientePagaresService.GetCuentaCorrientePagaresDataTable(clausula, string.Empty, this.sesion);

                if (dt.Rows.Count > 0)
                    CuentaCorrientePagaresService.Borrar((decimal)dt.Rows[0][CuentaCorrientePagaresService.Id_NombreCol], this.sesion);
            }
            //PreAprobado a Anulado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.PreAprobado) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
            {
                //Acciones
                //Borrar el pagaré de garantía 
                string clausula = CuentaCorrientePagaresService.CasoGarantiaId_NombreCol + " = " + this.CasoId;
                DataTable dt = CuentaCorrientePagaresService.GetCuentaCorrientePagaresDataTable(clausula, string.Empty, this.sesion);

                CuentaCorrientePagaresService.Borrar((decimal)dt.Rows[0][CuentaCorrientePagaresService.Id_NombreCol], this.sesion);
            }
            //Aprobado a Anulado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
            {
                //Acciones
                //Verificar que la OP generada, si existe este en anulado
                //Revertir en la ctacte de la persona el debito asignado en transicion anterior
                //Borrar el pagaré de garantía 
                string clausula = CuentaCorrientePagaresService.CasoGarantiaId_NombreCol + " = " + this.CasoId;
                DataTable dtPagareGarantia = CuentaCorrientePagaresService.GetCuentaCorrientePagaresDataTable(clausula, string.Empty, this.sesion);

                if (this.OrdenesPagoId.HasValue)
                {
                    DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoInfoCompleta(OrdenesPagoService.Id_NombreCol + " = " + this.OrdenesPagoId.Value, string.Empty, this.sesion);
                    if (dtOrdenPago.Rows.Count > 0) 
                    {
                        if (!dtOrdenPago.Rows[0][OrdenesPagoService.VistaCasoEstadoId_NombreCol].Equals(Definiciones.EstadosFlujos.Anulado))
                            throw new Exception("La Orden de Pago Generada por el caso de crédito debe estar en ANULADO");
                    }
                }

                if (this.EgresoVarioCajaId.HasValue)
                {
                    DataTable dtEgresoVarioCaja = EgresosVariosCajaService.GetEgresosVariosCajaInfoCompleta(EgresosVariosCajaService.Id_NombreCol + " = " + this.EgresoVarioCajaId.Value, string.Empty, this.sesion);
                    if (dtEgresoVarioCaja.Rows.Count > 0)
                    {
                        if (!dtEgresoVarioCaja.Rows[0][EgresosVariosCajaService.VistaCasoEstadoId_NombreCol].Equals(Definiciones.EstadosFlujos.Anulado))
                            throw new Exception("El Egreso Vario de Caja generado por el caso de crédito debe estar en ANULADO");
                    }
                }

                CuentaCorrientePagaresService.Borrar((decimal)dtPagareGarantia.Rows[0][CuentaCorrientePagaresService.Id_NombreCol], this.sesion);
                //Revertir debito
                CuentaCorrientePersonasService.DeshacerAgregarDebitoMovimientoPrincipal(this.CasoId.Value, this.sesion);
            }
            //Pendiente a Rechazado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Rechazado))
            {
                //Acciones
                //Borrar el pagaré de garantía si fue creado manualmente
                string clausula = CuentaCorrientePagaresService.CasoGarantiaId_NombreCol + " = " + this.CasoId;
                DataTable dt = CuentaCorrientePagaresService.GetCuentaCorrientePagaresDataTable(clausula, string.Empty);

                CuentaCorrientePagaresService.Borrar((decimal)dt.Rows[0][CuentaCorrientePagaresService.Id_NombreCol], this.sesion);
            }
            //Aprobado a Rechazado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Rechazado))
            {
                //Acciones
                //Revertir en la ctacte de la persona el debito asignado en transicion anterior
                //Borrar el pagaré de garantía
                //Verificar que la OP generada, si existe este en anulado
                string clausula = CuentaCorrientePagaresService.CasoGarantiaId_NombreCol + " = " + this.CasoId;
                DataTable dtPagareGarantia = CuentaCorrientePagaresService.GetCuentaCorrientePagaresDataTable(clausula, string.Empty, this.sesion);

                if (this.OrdenesPagoId.HasValue)
                {
                    DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoInfoCompleta(OrdenesPagoService.Id_NombreCol + " = " + this.OrdenesPagoId.Value, string.Empty);
                    if (dtOrdenPago.Rows.Count > 0) 
                    {
                        if (!dtOrdenPago.Rows[0][OrdenesPagoService.VistaCasoEstadoId_NombreCol].Equals(Definiciones.EstadosFlujos.Anulado))
                            throw new Exception("La Orden de Pago Generada por el caso de crédito debe estar en ANULADO");
                    }
                }

                CuentaCorrientePagaresService.Borrar((decimal)dtPagareGarantia.Rows[0][CuentaCorrientePagaresService.Id_NombreCol], this.sesion);
                //Revertir debito
                CuentaCorrientePersonasService.DeshacerAgregarDebitoMovimientoPrincipal(this.CasoId.Value, this.sesion);
            }
            //En-Revision a Vigente
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.EnRevision) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Vigente))
            {
                //Acciones
                //Validar que existen cuotas marcadas como cancelacion anticipada
                //Insertar pagos por las cuotas negociadas
                //Insertar nueva cuota por el monto de cuotas menos el descuento por cancelacion anticipada sobre lo no devengado
                //Crear Nota de Crédito por descuento (intereses no devengados descontados)

                decimal totalDeudaNueva = 0, totalInteresADevengarCobrado = 0, totalMora = 0, totalCapital = 0;
                decimal[] monto = null, impuestoId = null;
                int cuotasAgregadas = 0;

                DateTime vencimientoAnterior = this.FechaRetiro.HasValue ? this.FechaRetiro.Value.Date : this.FechaSolicitud.Date;
                DateTime fechaActual = this.FechaCancelacionAnticipada.HasValue ? this.FechaCancelacionAnticipada.Value.Date : DateTime.Now.Date;
                DateTime fechaUltimoPago = vencimientoAnterior;
                int diasLimiteEnSuspenso = CBA.FlowV2.Services.Base.VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.DevengamientoLimiteDiasEnSuspenso);
                int diasAtraso = 0;
                int cuotasSinVencer = 0;
                List<decimal> lCtactePersonas = new List<decimal>();
                List<decimal> lMontos = new List<decimal>();
                bool crearNotaCreditoPorDescuento = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CreditosPersonaCancelacionCrearNotaCreditoPorDescuento) == Definiciones.SiNo.Si;
                    
                foreach (var cuota in this.Calendario)
                {
                    if (fechaActual < cuota.FechaVencimiento.Date)
                        cuotasSinVencer++;
                }

                List<Hashtable> lFacturaDet = new List<Hashtable>();
                List<decimal> lCuotasDevengadasAnticipadamente = new List<decimal>();

                decimal ctacteCajaId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaMejorEsfuerzo(sesion.Usuario.SUCURSAL_ACTIVA_ID, this.sesion.Usuario.IsFUNCIONARIO_IDNull ? this.FuncionarioId : sesion.Usuario.FUNCIONARIO_ID, this.sesion);
                
                #region Insertar pagos por las cuotas negociadas
                this.DescuentoCancAntAplicado = 0;
                foreach (var cuota in this.Calendario)
                {
                    if(cuota.CancelacionAnticipada != Definiciones.SiNo.Si)
                    {
                        vencimientoAnterior = cuota.FechaVencimiento.Date;
                        continue;
                    }

                    #region devengamiento parcial
                    if (this.FechaCancelacionAnticipada.HasValue)
                        diasAtraso = Math.Max((this.FechaCancelacionAnticipada.Value.Date - cuota.FechaVencimiento.Date).Days, 0);
                    else
                        diasAtraso = Math.Max((DateTime.Now.Date - cuota.FechaVencimiento.Date).Days, 0);

                    int cantidadDias = (cuota.FechaVencimiento.Date - vencimientoAnterior).Days;
                    decimal totalInteresCuota = cuota.MontoInteresADevengar + cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;
                    decimal interesDiario = totalInteresCuota / Math.Max(cantidadDias, 1);

                    DateTime fechaHasta = fechaActual;
                    if (fechaActual > cuota.FechaVencimiento.Date)
                        fechaHasta = cuota.FechaVencimiento.Date;

                    //Si la fecha a devengar es anterior a la del vencimiento anterior, tomar como 0 dias transcurridos
                    int diasTranscurridos = Math.Max(0, (fechaHasta - vencimientoAnterior).Days);

                    if (diasTranscurridos > 0 && (fechaHasta - fechaUltimoPago).Days > diasLimiteEnSuspenso)
                    {
                        //Cantidad de dias total en suspenso
                        int diasSuspenso = Math.Min(diasTranscurridos, (fechaHasta - fechaUltimoPago).Days - diasLimiteEnSuspenso);
                        int diasDevengados = (int)Math.Max(0, (fechaHasta - vencimientoAnterior).Days - diasSuspenso);

                        cuota.MontoInteresEnSuspenso = diasSuspenso * interesDiario;
                        cuota.MontoInteresDevengado = diasDevengados * interesDiario;
                        cuota.MontoInteresADevengar = totalInteresCuota - cuota.MontoInteresEnSuspenso - cuota.MontoInteresDevengado;
                    }
                    else
                    {
                        cuota.MontoInteresDevengado = diasTranscurridos * interesDiario;
                        cuota.MontoInteresEnSuspenso = 0;
                        cuota.MontoInteresADevengar = totalInteresCuota - cuota.MontoInteresEnSuspenso - cuota.MontoInteresDevengado;
                    }

                    vencimientoAnterior = cuota.FechaVencimiento.Date;

                    cuota.IniciarUsingSesion(sesion);
                    cuota.Guardar();
                    cuota.FinalizarUsingSesion();
                    #endregion devengamiento parcial

                    /* Siendo:
                     *   A = A devengar
                     *   B = Devengado
                     *   C = En Suspenso
                    */
                    decimal totalBC = cuota.MontoInteresDevengado + cuota.MontoInteresEnSuspenso;
                    decimal saldoBC = Math.Max(totalBC - cuota.CtactePersona.Debito, 0);
                    decimal totalA = cuota.MontoInteresADevengar;
                    decimal saldoA = Math.Min(Math.Max(totalA + totalBC - cuota.CtactePersona.Debito, 0), totalA);
                    decimal montoCapital = cuota.MontoCapital + cuota.MontoImpuesto;
                    decimal saldoCapital = Math.Min(Math.Max(montoCapital - (cuota.CtactePersona.Debito - totalA - totalBC), 0), montoCapital);
                    totalCapital += saldoCapital - cuota.MontoImpuesto;

                    //Saldo de todos los componentes, mas saldo de interes a devengar descontado
                    decimal interesADevengarCobrado = saldoA * (1 - this.DescuentoCancelacionAnticip / 100);
                    
                    if (cuotasSinVencer <= this.DescuentoCancAntCantNoVen)
                        interesADevengarCobrado = saldoA;

                    this.DescuentoCancAntAplicado += saldoA - interesADevengarCobrado;
                    totalInteresADevengarCobrado += interesADevengarCobrado;
                    if (interesADevengarCobrado > 0)
                        lCuotasDevengadasAnticipadamente.Add(cuota.Id.Value);

                    totalDeudaNueva += saldoBC + saldoCapital + interesADevengarCobrado;
                    totalMora += cuota.CalcularMontoMora();

                    #region Calcular monto por tipo de impuesto
                    Hashtable montoPorImpuesto = new Hashtable();
                    DataTable dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable(cuota.CtactePersona.Id.Value, this.sesion);

                    for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                    {
                        if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                            montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol];
                        else
                            montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol]);
                    }

                    impuestoId = new decimal[montoPorImpuesto.Count];
                    monto = new decimal[montoPorImpuesto.Count];

                    int indiceAux = 0;
                    decimal montoVerificacion = 0;
                    foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                    {
                        impuestoId[indiceAux] = (decimal)par.Key;
                        monto[indiceAux] = (decimal)par.Value / cuota.CtactePersona.Credito * (cuota.CtactePersona.Credito - cuota.CtactePersona.Debito);

                        montoVerificacion += monto[indiceAux];

                        indiceAux++;
                    }

                    if (Math.Round((cuota.CtactePersona.Credito - cuota.CtactePersona.Debito), cuota.CtactePersona.Moneda.CantidadDecimales) != Math.Round(montoVerificacion, cuota.CtactePersona.Moneda.CantidadDecimales))
                        throw new Exception("Error en CreditosService.EjecutarAccionesCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + Math.Round((cuota.CtactePersona.Credito - cuota.CtactePersona.Debito)) + ".");
                    #endregion Calcular monto por tipo de impuesto

                    if (montoVerificacion > 0)
                    {
                        //Ingresar el debito
                        CuentaCorrientePersonasService.AgregarDebito(this.PersonaId,
                                                    cuota.CtactePersona.Id.Value,
                                                    Definiciones.CuentaCorrienteConceptos.DebitoPorPago,
                                                    Definiciones.CuentaCorrienteValores.Efectivo, //Se agrega efectivo por completar el dato simplemente
                                                    this.CasoId.Value,
                                                    this.MonedaId,
                                                    this.Cotizacion,
                                                    impuestoId,
                                                    monto,
                                                    "Cancelación anticipada",
                                                    DateTime.Now,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    Definiciones.Error.Valor.EnteroPositivo,
                                                    sesion);

                        CuentaCorrientePersonasService.SetBloqueado(cuota.CtactePersona.Id.Value, false, this.sesion);
                    }
                }
                #endregion Insertar pagos por las cuotas negociadas
                
                #region Insertar nueva cuota
                if (totalDeudaNueva > 0)
                {
                    if (crearNotaCreditoPorDescuento)
                        totalDeudaNueva += this.DescuentoCancAntAplicado;

                    //Como el monto por impuesto contiene el total se
                    //normaliza para escalar posteriormente para cubrir
                    //que el credito haya tenido impuesto compuesto
                    decimal total = 0;
                    for (int i = 0; i < monto.Length; i++)
                        total += monto[i];
                    for (int i = 0; i < monto.Length; i++)
                        monto[i] = monto[i] / total * totalDeudaNueva;

                    lMontos.Add(totalDeudaNueva);
                    lCtactePersonas.Add(
                        CuentaCorrientePersonasService.AgregarCredito(this.PersonaId,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.CuentaCorrienteConceptos.Financiacion,
                                    this.CasoId.Value,
                                    this.MonedaId,
                                    this.Cotizacion,
                                    impuestoId,
                                    monto,
                                    "Cancelación anticipada",
                                    DateTime.Now,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    this.Calendario.Length + ++cuotasAgregadas,
                                    this.Calendario.Length,
                                    sesion)
                    );
                }
                #endregion Insertar nueva cuota

                #region Insertar mora e interes punitorio
                if (totalMora > 0)
                {
                    var mora = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Mora);
                    lMontos.Add(totalMora);
                    lCtactePersonas.Add(
                        CuentaCorrientePersonasService.AgregarCredito(this.PersonaId,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.CuentaCorrienteConceptos.Recargo,
                                    this.CasoId.Value,
                                    this.MonedaId,
                                    this.Cotizacion,
                                    new decimal[] { mora.Articulo.ImpuestoId },
                                    new decimal[] { totalMora },
                                    "Mora " + Traducciones.Caso + " Nº" + this.CasoId.Value,
                                    DateTime.Now,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    Definiciones.Error.Valor.EnteroPositivo,
                                    this.Calendario.Length + ++cuotasAgregadas,
                                    this.Calendario.Length,
                                    sesion)
                    );
                    
                    decimal porcentajeInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasPorcentajeInteresPunitorioSobreMora);
                    decimal totalInteresPunitorio = totalMora * porcentajeInteresPunitorio / 100;
                    if (totalInteresPunitorio > 0)
                    {
                        lMontos.Add(totalInteresPunitorio);
                        lCtactePersonas.Add(
                            CuentaCorrientePersonasService.AgregarCredito(this.PersonaId,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.CuentaCorrienteConceptos.Recargo,
                                        this.CasoId.Value,
                                        this.MonedaId,
                                        this.Cotizacion,
                                        new decimal[] { Definiciones.Impuestos.IVA_10 },
                                        new decimal[] { totalInteresPunitorio },
                                        "Interés punitorio " + Traducciones.Caso + " Nº" + this.CasoId.Value,
                                        DateTime.Now,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        this.Calendario.Length + ++cuotasAgregadas,
                                        this.Calendario.Length,
                                        sesion)
                        );
                    }

                    //Se registra en ctacte_recargos y se factura ya que los flujos por donde se cobre
                    //tomaran la mora ya registrada en la cuenta corriente sin usar sus tablas auxiliares de recargo
                    Hashtable camposRecargo, htFacturaDetRecaro;
                    #region mora
                    #region Registrar el recargo en ctacte_recargos
                    camposRecargo = new Hashtable();
                    camposRecargo.Add(CuentaCorrienteRecargosService.CasoOrigenId_NombreCol, this.CasoId.Value);
                    camposRecargo.Add(CuentaCorrienteRecargosService.Cotizacion_NombreCol, this.Cotizacion);
                    camposRecargo.Add(CuentaCorrienteRecargosService.Fecha_NombreCol, DateTime.Now);
                    if (!sesion.Usuario.IsFUNCIONARIO_IDNull)
                        camposRecargo.Add(CuentaCorrienteRecargosService.FuncionarioId_NombreCol, this.sesion.Usuario.FUNCIONARIO_ID);
                    camposRecargo.Add(CuentaCorrienteRecargosService.MonedaId_NombreCol, this.MonedaId);
                    camposRecargo.Add(CuentaCorrienteRecargosService.Monto_NombreCol, totalMora);
                    camposRecargo.Add(CuentaCorrienteRecargosService.PersonaId_NombreCol, this.PersonaId);
                    camposRecargo.Add(CuentaCorrienteRecargosService.SucursalId_NombreCol, this.SucursalId);
                    camposRecargo.Add(CuentaCorrienteRecargosService.TipoRecargo_NombreCol, Definiciones.TipoRecargo.Mora);
                    if (ctacteCajaId == Definiciones.Error.Valor.EnteroPositivo && !sesion.Usuario.IsFUNCIONARIO_IDNull)
                        ctacteCajaId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, this.sesion.Usuario.FUNCIONARIO_ID);
                    if (ctacteCajaId == Definiciones.Error.Valor.EnteroPositivo)
                        throw new Exception("No se encontró una caja abierta para generar la factura por mora.");
                    camposRecargo.Add(CuentaCorrienteRecargosService.CtacteCajaSucursalId_NombreCol, ctacteCajaId);
                    camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, mora.Articulo.ImpuestoId);
                    decimal ctacteRecargoId = CuentaCorrienteRecargosService.Guardar(camposRecargo, this.sesion);
                    #endregion Registrar el recargo en ctacte_recargos

                    #region Detalle de factura por recargos
                    htFacturaDetRecaro = new Hashtable();
                    lFacturaDet.Add(htFacturaDetRecaro);

                    htFacturaDetRecaro[FacturasClienteDetalleService.CtacteRecargoId_NombreCol] = ctacteRecargoId;
                    htFacturaDetRecaro[FacturasClienteDetalleService.ArticuloId_NombreCol] = mora.ArticuloId;
                    htFacturaDetRecaro[FacturasClienteDetalleService.Observacion_NombreCol] = "Mora " + Traducciones.Caso + " Nº" + this.CasoId.Value;
                    htFacturaDetRecaro[FacturasClienteDetalleService.TotalNeto_NombreCol] = totalMora;
                    #endregion Detalle de factura por recargos
                    #endregion mora

                    #region interes punitorio
                    if (totalInteresPunitorio > 0)
                    {
                        var dtArticuloInteresPunitorio = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoInteresPunitorio), string.Empty, false, this.SucursalId);

                        #region Registrar el recargo en ctacte_recargos
                        camposRecargo = new Hashtable();
                        camposRecargo.Add(CuentaCorrienteRecargosService.CasoOrigenId_NombreCol, this.CasoId.Value);
                        camposRecargo.Add(CuentaCorrienteRecargosService.Cotizacion_NombreCol, this.Cotizacion);
                        camposRecargo.Add(CuentaCorrienteRecargosService.Fecha_NombreCol, DateTime.Now);
                        if (!sesion.Usuario.IsFUNCIONARIO_IDNull)
                            camposRecargo.Add(CuentaCorrienteRecargosService.FuncionarioId_NombreCol, this.sesion.Usuario.FUNCIONARIO_ID);
                        camposRecargo.Add(CuentaCorrienteRecargosService.MonedaId_NombreCol, this.MonedaId);
                        camposRecargo.Add(CuentaCorrienteRecargosService.Monto_NombreCol, totalInteresPunitorio);
                        camposRecargo.Add(CuentaCorrienteRecargosService.PersonaId_NombreCol, this.PersonaId);
                        camposRecargo.Add(CuentaCorrienteRecargosService.SucursalId_NombreCol, this.SucursalId);
                        camposRecargo.Add(CuentaCorrienteRecargosService.TipoRecargo_NombreCol, Definiciones.TipoRecargo.InteresPunitorio);
                        if (ctacteCajaId == Definiciones.Error.Valor.EnteroPositivo && !sesion.Usuario.IsFUNCIONARIO_IDNull)
                            ctacteCajaId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, this.sesion.Usuario.FUNCIONARIO_ID);
                        if (ctacteCajaId == Definiciones.Error.Valor.EnteroPositivo)
                            throw new Exception("No se encontró una caja abierta para generar la factura por interés punitorio.");
                        camposRecargo.Add(CuentaCorrienteRecargosService.CtacteCajaSucursalId_NombreCol, ctacteCajaId);
                        camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, dtArticuloInteresPunitorio.Rows[0][ArticulosService.ImpuestoId_NombreCol]);
                        ctacteRecargoId = CuentaCorrienteRecargosService.Guardar(camposRecargo, this.sesion);
                        #endregion Registrar el recargo en ctacte_recargos

                        #region Detalle de factura por recargos
                        htFacturaDetRecaro = new Hashtable();
                        lFacturaDet.Add(htFacturaDetRecaro);

                        htFacturaDetRecaro[FacturasClienteDetalleService.CtacteRecargoId_NombreCol] = ctacteRecargoId;
                        htFacturaDetRecaro[FacturasClienteDetalleService.ArticuloId_NombreCol] = dtArticuloInteresPunitorio.Rows[0][ArticulosService.Id_NombreCol];
                        htFacturaDetRecaro[FacturasClienteDetalleService.Observacion_NombreCol] = "Interés punitorio " + Traducciones.Caso + " Nº" + this.CasoId.Value;
                        htFacturaDetRecaro[FacturasClienteDetalleService.TotalNeto_NombreCol] = totalInteresPunitorio;
                        #endregion Detalle de factura por recargos
                    }
                    #endregion interes punitorio
                }
                #endregion Insertar mora e interes punitorio

                #region Detalle de factura por interes a devengar cobrado
                //Facturar si se factura en el devengamiento
                if (totalInteresADevengarCobrado > 0 && this.FacturarIntereses == Definiciones.CreditosPoliticaFacturacion.Devengamiento)
                {
                    var gastoAdministrativo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo);
                    var htFacturaDetADevengarCobrado = new Hashtable();
                    lFacturaDet.Add(htFacturaDetADevengarCobrado);
                    
                    htFacturaDetADevengarCobrado[FacturasClienteDetalleService.ArticuloId_NombreCol] = gastoAdministrativo.ArticuloId;
                    htFacturaDetADevengarCobrado[FacturasClienteDetalleService.Observacion_NombreCol] = "Gastos Administrativos " + Traducciones.Caso + " Nº" + this.CasoId.Value;
                    htFacturaDetADevengarCobrado[FacturasClienteDetalleService.TotalNeto_NombreCol] = totalInteresADevengarCobrado;
                }
                #endregion Detalle de factura por interes a devengar cobrado

                #region Detalle de factura por capital
                if (totalCapital > 0 && this.FacturarCapital == Definiciones.CreditosPoliticaFacturacion.CancelacionAnticipada)
                {
                    var htFacturaDetADevengarCobrado = new Hashtable();
                    lFacturaDet.Add(htFacturaDetADevengarCobrado);

                    htFacturaDetADevengarCobrado[FacturasClienteDetalleService.ArticuloId_NombreCol] = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoCapitalArticulo, this.sesion);
                    htFacturaDetADevengarCobrado[FacturasClienteDetalleService.Observacion_NombreCol] = "Capital " + Traducciones.Caso + " Nº" + this.CasoId.Value;
                    htFacturaDetADevengarCobrado[FacturasClienteDetalleService.TotalNeto_NombreCol] = totalCapital;
                }
                #endregion Detalle de factura por capital

                if (lFacturaDet.Count > 0)
                {
                    if (ctacteCajaId == Definiciones.Error.Valor.EnteroPositivo)
                        throw new Exception("No se encontró una caja abierta para generar la factura cancelaciòn anticipada.");
                    this.CrearFacturaComoComprobante(ctacteCajaId, lFacturaDet.ToArray(), lCuotasDevengadasAnticipadamente.ToArray());
                }

                if (crearNotaCreditoPorDescuento && this.DescuentoCancAntAplicado > 0)
                {
                    bool exito = false;

                    //Usar como factura base la más antigua que tenga como caso asociado al crédito
                    var dtFacturaCliente = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoOrigenId_NombreCol + " = " + this.CasoId + " and " + FacturasClienteService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Cerrado + "'", FacturasClienteService.Id_NombreCol, this.sesion);
                    if (dtFacturaCliente.Rows.Count <= 0)
                        throw new Exception("No se encontró una factura sobre la cual hacer la nota de crédito por intereses no devengados.");
                    var facturaCliente = new FacturasClienteService((decimal)dtFacturaCliente.Rows[0][FacturasClienteService.Id_NombreCol], this.sesion);

                    //Agregar a this.DescuentoCancAntAplicado el impuesto segun el articulo asociado
                    TiposArticuloFinancieroRangoService interes = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.InteresCorriente);
                    decimal montoNotaCredito = this.DescuentoCancAntAplicado * (1 + interes.Articulo.Impuesto.Porcentaje / 100);

                    var autonumeracionId = this.GetPasarelaCambioEstadoCampo(ValoresConstantes.CancelacionAnticipadaNotaCreditoAutonumeracion);
                    if (autonumeracionId == null)
                        throw new Exception("No se definió el talonario para la Nota de Crédito.");

                    var notaCreditoCtacteCajaSucursal = this.GetPasarelaCambioEstadoCampo(ValoresConstantes.CancelacionAnticipadaNotaCreditoCajaSucursal);
                    
                    var depositos = StockDepositosService.Buscar(StockDepositosService.SucursalId_NombreCol + " = " + autonumeracionId.campoAsociado2.valor + " and " +
                                                                 StockDepositosService.ParaFacturar_NombreCol + " = '" + Definiciones.SiNo.Si + "'", 
                                                                 StockDepositosService.Orden_NombreCol, 
                                                                 sesion);

                    #region Cabecera Nota de Crédito
                    Hashtable campos = new Hashtable()
                        {
                            {NotasCreditoPersonaService.SucursalId_NombreCol, depositos[0].SucursalId}
                            , {NotasCreditoPersonaService.DepositoId_NombreCol, depositos[0].Id.Value}
                            , {NotasCreditoPersonaService.PersonaId_NombreCol, facturaCliente.PersonaId.Value}
                            , {NotasCreditoPersonaService.MonedaId_NombreCol, facturaCliente.MonedaDestinoId}
                            , {NotasCreditoPersonaService.FuncionarioCobradorId_NombreCol, this.sesion.Usuario_Funcionario_id}
                            , {NotasCreditoPersonaService.AutonumeracionId_NombreCol, autonumeracionId.valor }
                            , {NotasCreditoPersonaService.NroComprobante_NombreCol, string.Empty}
                            , {NotasCreditoPersonaService.Fecha_NombreCol, DateTime.Now}
                            , {NotasCreditoPersonaService.TipoNotaCreditoId_NombreCol, (decimal)Definiciones.TiposNotasCredito.Descuento}
                            , {NotasCreditoPersonaService.Observacion_NombreCol, string.Empty}
                            , {NotasCreditoPersonaService.CtaCteCajaSucursalId_NombreCol, notaCreditoCtacteCajaSucursal != null ? notaCreditoCtacteCajaSucursal.valor : ctacteCajaId }
                        };

                    decimal casoNotaCreditoId = Definiciones.Error.Valor.EnteroPositivo;
                    string casoNotaCreditoEstado = string.Empty;
                    exito = NotasCreditoPersonaService.Guardar2(campos, true, ref casoNotaCreditoId, ref casoNotaCreditoEstado, this.sesion);
                    #endregion Cabecera Nota de Crédito

                    #region Detalle Nota de Crédito
                    DataTable dtNotaCreditoPersona = NotasCreditoPersonaService.GetNotaCreditoPersonaPorCasoDataTable2(casoNotaCreditoId, this.sesion);

                    campos = new Hashtable();
                    campos.Add(NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol, dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.Id_NombreCol]);
                    campos.Add(NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol, facturaCliente.Id.Value);
                    campos.Add(NotasCreditoPersonaDetalleService.ImpuestoId_NombreCol, interes.Articulo.ImpuestoId);
                    campos.Add(NotasCreditoPersonaDetalleService.MontoConcepto_NombreCol, montoNotaCredito);
                    campos.Add(NotasCreditoPersonaDetalleService.Observacion_NombreCol, string.Empty);

                    NotasCreditoPersonaDetalleService.Guardar2(campos, this.sesion);
                    #endregion Detalle Nota de Crédito

                    #region Paso de Estado de la NC Cliente - Borrador a Aprobado
                    string msgCasoAsociado;
                    var notaCreditoService = new NotasCreditoPersonaService();

                    exito = notaCreditoService.ProcesarCambioEstado(casoNotaCreditoId, Definiciones.EstadosFlujos.Pendiente, false, out msgCasoAsociado, this.sesion);
                    if (exito)
                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoNotaCreditoId, Definiciones.EstadosFlujos.Pendiente, "Transición Automática por Consolidación de Deudas", this.sesion);
                    if (exito)
                        notaCreditoService.EjecutarAccionesLuegoDeCambioEstado(casoNotaCreditoId, Definiciones.EstadosFlujos.Pendiente, this.sesion);

                    exito = (new NotasCreditoPersonaService()).ProcesarCambioEstado(casoNotaCreditoId, Definiciones.EstadosFlujos.PreAprobado, false, out msgCasoAsociado, this.sesion);
                    if (exito)
                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoNotaCreditoId, Definiciones.EstadosFlujos.PreAprobado, "Transición Automática por Consolidación de Deudas", this.sesion);
                    if (exito)
                        notaCreditoService.EjecutarAccionesLuegoDeCambioEstado(casoNotaCreditoId, Definiciones.EstadosFlujos.PreAprobado, this.sesion);

                    exito = (new NotasCreditoPersonaService()).ProcesarCambioEstado(casoNotaCreditoId, Definiciones.EstadosFlujos.Aprobado, false, out msgCasoAsociado, this.sesion);
                    if (exito)
                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoNotaCreditoId, Definiciones.EstadosFlujos.Aprobado, "Transición Automática por Consolidación de Deudas", this.sesion);
                    if (exito)
                        notaCreditoService.EjecutarAccionesLuegoDeCambioEstado(casoNotaCreditoId, Definiciones.EstadosFlujos.Aprobado, this.sesion);
                    #endregion Paso de Estado de la NC Cliente - Borrador a Aprobado
                }
            }

            bool controlarPermisosGuardadoValorAnterior = this.controlarPermisosGuardado;
            this.controlarPermisosGuardado = !cambio_pedido_por_usuario;
            this.Caso.Guardar(sesion);
            this.Guardar();
            this.controlarPermisosGuardado = controlarPermisosGuardadoValorAnterior;

            if (inicializarSesionLocal)
                this.FinalizarUsingSesion();

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());

            return this.Caso;
        }
        #endregion EjecutarAccionesCambioEstado

        #region EjecutarAccionesLuegoDeCambioEstado
        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        protected override void EjecutarAccionesLuegoDeCambioEstado(string estado_destino_id, SessionService sesion)
        {
            //Se fuerza un refrescado de informacion
            this.ResetearPropiedadesExtendidas();

            //Pre-Aprobado a Aprobado
            if (this.Caso.EstadoId == Definiciones.EstadosFlujos.Aprobado && this.Caso.EstadoAnterior == Definiciones.EstadosFlujos.PreAprobado)
            {
                if (this.DesembolsarParaCliente == Definiciones.SiNo.Si)
                {
                    //Si el monto a desembolsar es cero, pasar a Vigente
                    decimal totalDesembolso = this.MontoCapitalAprobado - this.MontoDescuentos;
                    decimal totalDescuentos = 0;

                    foreach (var d in this.Descuentos)
                    {
                        if (d.MonedaId == this.MonedaId)
                            totalDescuentos += d.Monto;
                        else
                            totalDescuentos += d.Monto / d.Cotizacion * this.Cotizacion;
                    }

                    if (Math.Round(totalDesembolso - totalDescuentos, this.Moneda.CantidadDecimales) > 0)
                    {
                        if (this.Permisos.CreditoClienteAccionCrearDesembolsoOrdenPago && this.CtacteCajaTesoreriaId.HasValue)
                            this.GenerarOrdenDePago();
                        else if (this.Permisos.CreditoClienteAccionCrearDesembolsoEgresoVarioCaja)
                            this.GenerarEgresoVarioCaja();
                    }
                    else
                    {
                        var comentario = new ToolbarFlujoService.ComentarioTransicion();
                        comentario.texto = "Transición automática por no haber capital a desembolsar."; 
                        this.ProcesarCambioEstado(Definiciones.EstadosFlujos.Vigente, false, comentario, sesion);
                    }
                }
            }
        }
        #endregion EjecutarAccionesLuegoDeCambioEstado
        #endregion Implementacion de metodos abstract
        
        #region VerificarPuedeAvanzarEstado
        public bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, this.Permisos.creditosNoControlarMargenDiasPuedeAvanzarNombre, Definiciones.VariablesDeSistema.CreditosMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string CasoEstadoId = "ESTADO_ID";
            public const string PersonaDeudoraOGaranteId = "PERSONA_DEUDORA_O_GARANTE_ID";
            public const string RequisitosFlujosCasoId = "REQUISITO_FLUJO_CASO_ID";
        }
        #endregion FiltrosExtension

        #region Permisos
        public Permiso Permisos = new Permiso();
        public class Permiso
        {
            private bool? _creditosEditarAfectaLineaCredito;
            public bool CreditosEditarAfectaLineaCredito { get { if (this._creditosEditarAfectaLineaCredito == null) this._creditosEditarAfectaLineaCredito = RolesService.Tiene("CREDITOS EDITAR AFECTA LINEA CREDITO"); return this._creditosEditarAfectaLineaCredito.Value; } }
            
            private bool? _creditos_crear;
            public bool CreditosCrear { get { if (this._creditos_crear == null) this._creditos_crear = RolesService.Tiene("CREDITOS CREAR"); return this._creditos_crear.Value; } }

            private bool? _creditosVerArbol;
            public bool CreditosVerArbol { get { if (this._creditosVerArbol == null) this._creditosVerArbol = RolesService.Tiene("CREDITOS VER ARBOL"); return this._creditosVerArbol.Value; } }

            private bool? _creditosVerDesembolsarParaCliente;
            public bool CreditosVerDesembolsarParaCliente { get { if (this._creditosVerDesembolsarParaCliente == null) this._creditosVerDesembolsarParaCliente = RolesService.Tiene("CREDITOS VER DESEMBOLSAR PARA CLIENTE"); return this._creditosVerDesembolsarParaCliente.Value; } }

            private bool? _creditosEditarEnPendiente;
            public bool CreditosEditarEnPendiente { get { if (this._creditosEditarEnPendiente == null) this._creditosEditarEnPendiente = RolesService.Tiene("CREDITOS EDITAR EN PENDIENTE"); return this._creditosEditarEnPendiente.Value; } }

            private bool? _creditosEditarEnPreAprobado;
            public bool CreditosEditarEnPreAprobado { get { if (this._creditosEditarEnPreAprobado == null) this._creditosEditarEnPreAprobado = RolesService.Tiene("CREDITOS EDITAR EN PRE-APROBADO"); return this._creditosEditarEnPreAprobado.Value; } }

            private bool? _creditosEditarCancelacionAnticipada;
            public bool CreditosEditarCancelacionAnticipada { get { if (this._creditosEditarCancelacionAnticipada == null) this._creditosEditarCancelacionAnticipada = RolesService.Tiene("CREDITOS EDITAR CANCELACION ANTICIPADA"); return this._creditosEditarCancelacionAnticipada.Value; } }
            
            private bool? _creditosCajaSucursalObligatoriaAlPasarAAprobado;
            public bool CreditosCajaSucursalObligatoriaAlPasarAAprobado { get { if (this._creditosCajaSucursalObligatoriaAlPasarAAprobado == null) this._creditosCajaSucursalObligatoriaAlPasarAAprobado = RolesService.Tiene("CREDITOS CAJA SUCURSAL OBLIGATORIA AL PASAR A APROBADO"); return this._creditosCajaSucursalObligatoriaAlPasarAAprobado.Value; } }

            private bool? _creditosNoControlarMargenDiasPuedeAvanzar;
            public string creditosNoControlarMargenDiasPuedeAvanzarNombre = "CREDITOS NO CONTROLAR MARGEN DIAS PUEDE AVANZAR";
            public bool CreditosNoControlarMargenDiasPuedeAvanzar { get { if (this._creditosNoControlarMargenDiasPuedeAvanzar == null) this._creditosNoControlarMargenDiasPuedeAvanzar = RolesService.Tiene(this.creditosNoControlarMargenDiasPuedeAvanzarNombre); return this._creditosNoControlarMargenDiasPuedeAvanzar.Value; } }

            private bool? _puedeEditarCodeudor;
            public bool PuedeEditarCodeudor { get { if (this._puedeEditarCodeudor == null) _puedeEditarCodeudor = RolesService.Tiene("CREDITOS PUEDE EDITAR CODEUDOR"); return this._puedeEditarCodeudor.Value; } }

            private bool? _puedeEditarSeparacionBienes;
            public bool PuedeEditarSeparacionBienes { get { if (this._puedeEditarSeparacionBienes == null) _puedeEditarSeparacionBienes = RolesService.Tiene("CREDITOS EDITAR SEPARACION BIENES"); return this._puedeEditarSeparacionBienes.Value; } }

            private bool? _puedeCrearPagareDeGarantia;
            public bool PuedeCrearPagareDeGarantia { get { if (this._puedeCrearPagareDeGarantia == null) _puedeCrearPagareDeGarantia = RolesService.Tiene("CREDITOS PUEDE CREAR PAGARE GARANTIA"); return this._puedeCrearPagareDeGarantia.Value; } }

            private bool? _puedeEditarFacturarInteresesEnPago;
            public bool PuedeEditarFacturarInteresesEnPago { get { if (this._puedeEditarFacturarInteresesEnPago == null) _puedeEditarFacturarInteresesEnPago = RolesService.Tiene("CREDITOS EDITAR FACTURAR INTERESES EN PAGOS"); return this._puedeEditarFacturarInteresesEnPago.Value; } }

            private bool? _puedeEditarFacturarOtrosGastosEnPago;
            public bool PuedeEditarFacturarOtrosGastosEnPago { get { if (this._puedeEditarFacturarOtrosGastosEnPago == null) _puedeEditarFacturarOtrosGastosEnPago = RolesService.Tiene("CREDITOS EDITAR FACTURAR OTROS GASTOS EN PAGOS"); return this._puedeEditarFacturarOtrosGastosEnPago.Value; } }

            private bool? _puedeEditarFacturarCapitalEnPago;
            public bool PuedeEditarFacturarCapitalEnPago { get { if (this._puedeEditarFacturarCapitalEnPago == null) _puedeEditarFacturarCapitalEnPago = RolesService.Tiene("CREDITOS EDITAR FACTURAR CAPITAL EN PAGOS"); return this._puedeEditarFacturarCapitalEnPago.Value; } }

            private bool? _puedeRelacionarActivos;
            public bool PuedeRelacionarActivos { get { if (this._puedeRelacionarActivos == null) _puedeRelacionarActivos = RolesService.Tiene("CREDITOS VER ACTIVO"); return this._puedeRelacionarActivos.Value; } }

            private bool? _creditoCalendarioPagosDesplazarVencimiento;
            public bool CreditoCalendarioPagosDesplazarVencimiento { get { if (this._creditoCalendarioPagosDesplazarVencimiento == null) this._creditoCalendarioPagosDesplazarVencimiento = RolesService.Tiene("CREDITOS CALENDARIO PAGOS DESPLAZAR VENCIMIENTOS"); return this._creditoCalendarioPagosDesplazarVencimiento.Value; } }

            private bool? _creditoCalendarioPagosEditarMontoMoraManual;
            public bool CreditoCalendarioPagosEditarMontoMoraManual { get { if (this._creditoCalendarioPagosEditarMontoMoraManual == null) this._creditoCalendarioPagosEditarMontoMoraManual = RolesService.Tiene("CREDITOS CALENDARIO PAGOS EDITAR MONTO MORA MANUAL"); return this._creditoCalendarioPagosEditarMontoMoraManual.Value; } }

            private bool? _creditoClienteAccionCrearDesembolsoOrdenPago;
            public bool CreditoClienteAccionCrearDesembolsoOrdenPago { get { if (this._creditoClienteAccionCrearDesembolsoOrdenPago == null) this._creditoClienteAccionCrearDesembolsoOrdenPago = RolesService.Tiene("CREDITOS CLIENTES ACCION CREAR DESEMBOLSO ORDEN PAGO"); return this._creditoClienteAccionCrearDesembolsoOrdenPago.Value; } }

            private bool? _creditoClienteAccionCrearDesembolsoEgresoVarioCaja;
            public bool CreditoClienteAccionCrearDesembolsoEgresoVarioCaja { get { if (this._creditoClienteAccionCrearDesembolsoEgresoVarioCaja == null) this._creditoClienteAccionCrearDesembolsoEgresoVarioCaja = RolesService.Tiene("CREDITOS CLIENTES ACCION CREAR DESEMBOLSO EGRESO VARIO CAJA"); return this._creditoClienteAccionCrearDesembolsoEgresoVarioCaja.Value; } }

            private bool? _creditosDescuentoAnticipoPrecargarAGarante1;
            public bool CreditosDescuentoAnticipoPrecargarAGarante1 { get { if (this._creditosDescuentoAnticipoPrecargarAGarante1 == null) this._creditosDescuentoAnticipoPrecargarAGarante1 = RolesService.Tiene("CREDITOS DESCUENTO ANTICIPO PRECARGAR A GARANTE 1"); return this._creditosDescuentoAnticipoPrecargarAGarante1.Value; } }

            private bool? _creditosEditarDatosFinancieros;
            public bool CreditosEditarDatosFinancieros { get { if (this._creditosEditarDatosFinancieros == null) this._creditosEditarDatosFinancieros = RolesService.Tiene("CREDITOS EDITAR DATOS FINANCIEROS"); return this._creditosEditarDatosFinancieros.Value; } }

            private bool? _creditosVerDatosFinancieros;
            public bool CreditosVerDatosFinancieros { get { if (this._creditosVerDatosFinancieros == null) this._creditosVerDatosFinancieros = RolesService.Tiene("CREDITOS VER DATOS FINANCIEROS"); return this._creditosVerDatosFinancieros.Value; } }

            private bool? _creditosEditarAprobacion1;
            public bool CreditosEditarAprobacion1 { get { if (this._creditosEditarAprobacion1 == null) this._creditosEditarAprobacion1 = RolesService.Tiene("CREDITOS EDITAR APROBACION 1"); return this._creditosEditarAprobacion1.Value; } }

            private bool? _creditosEditarAprobacion2;
            public bool CreditosEditarAprobacion2 { get { if (this._creditosEditarAprobacion2 == null) this._creditosEditarAprobacion2 = RolesService.Tiene("CREDITOS EDITAR APROBACION 2"); return this._creditosEditarAprobacion2.Value; } }

            private bool? _creditosEditarAprobacion3;
            public bool CreditosEditarAprobacion3 { get { if (this._creditosEditarAprobacion3 == null) this._creditosEditarAprobacion3 = RolesService.Tiene("CREDITOS EDITAR APROBACION 3"); return this._creditosEditarAprobacion3.Value; } }

            private bool? _creditosFondoFijoObligatorioAlPasarAAprobado;
            public bool CreditosFondoFijoObligatorioAlPasarAAprobado { get { if (this._creditosFondoFijoObligatorioAlPasarAAprobado == null) this._creditosFondoFijoObligatorioAlPasarAAprobado = RolesService.Tiene("CREDITOS FONDO FIJO OBLIGATORIO AL PASAR A APROBADO"); return this._creditosFondoFijoObligatorioAlPasarAAprobado.Value; } }
            
            private bool? _creditosLanzarReportePagare;
            public bool CreditosLanzarReportePagare { get { if (this._creditosLanzarReportePagare == null) this._creditosLanzarReportePagare = RolesService.Tiene("CREDITOS LANZAR REPORTE PAGARE"); return this._creditosLanzarReportePagare.Value; } }

            private bool? _creditosLanzarReporteLiquidacion;
            public bool CreditosLanzarReporteLiquidacion { get { if (this._creditosLanzarReporteLiquidacion == null) this._creditosLanzarReporteLiquidacion = RolesService.Tiene("CREDITOS LANZAR REPORTE LIQUIDACION"); return this._creditosLanzarReporteLiquidacion.Value; } }

            private bool? _creditosLanzarReporteContrato;
            public bool CreditosLanzarReporteContrato { get { if (this._creditosLanzarReporteContrato == null) this._creditosLanzarReporteContrato = RolesService.Tiene("CREDITOS LANZAR REPORTE CONTRATO"); return this._creditosLanzarReporteContrato.Value; } }

            private bool? _creditosLanzarReporteSolicitud;
            public bool CreditosLanzarReporteSolicitud { get { if (this._creditosLanzarReporteSolicitud == null) this._creditosLanzarReporteSolicitud = RolesService.Tiene("CREDITOS LANZAR REPORTE SOLICITUD"); return this._creditosLanzarReporteSolicitud.Value; } }

            private bool? _creditosLanzarReporteChequera;
            public bool CreditosLanzarReporteChequera { get { if (this._creditosLanzarReporteChequera == null) this._creditosLanzarReporteChequera = RolesService.Tiene("CREDITOS LANZAR REPORTE CHEQUERA"); return this._creditosLanzarReporteChequera.Value; } }

            private bool? _creditosLanzarReporteCredito;
            public bool CreditosLanzarReporteCredito { get { if (this._creditosLanzarReporteCredito == null) this._creditosLanzarReporteCredito = RolesService.Tiene("CREDITOS LANZAR REPORTE CREDITO"); return this._creditosLanzarReporteCredito.Value; } }

            private bool? _creditosLanzarReporteCreditoVerDevengamiento;
            public bool CreditosLanzarReporteCreditoVerDevengamiento { get { if (this._creditosLanzarReporteCreditoVerDevengamiento == null) this._creditosLanzarReporteCreditoVerDevengamiento = RolesService.Tiene("CREDITOS LANZAR REPORTE CREDITO VER DEVENGAMIENTO"); return this._creditosLanzarReporteCreditoVerDevengamiento.Value; } }
        }
        #endregion Permisos

        #region Propiedades
        protected CREDITOSRow row;
        protected CREDITOSRow rowSinModificar;
        public class Modelo : CREDITOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? ActivoId { get { if (row.IsACTIVO_IDNull) return null; else return row.ACTIVO_ID; } set { if (value.HasValue) { if (this.ActivoId != value) this._activo = null; row.ACTIVO_ID = value.Value; } else { row.IsACTIVO_IDNull = true; } } }
        public string AfectaLineaCredito { get { return ClaseCBABase.GetStringHelper(row.AFECTA_LINEA_CREDITO); } set { row.AFECTA_LINEA_CREDITO = value; } }
        public string AnhoComercial { get { return row.ANHO_COMERCIAL; } set { row.ANHO_COMERCIAL = value; } }
        public string Aprobacion1 { get { return ClaseCBABase.GetStringHelper(row.APROBACION_1); } set { row.APROBACION_1 = value; } }
        public DateTime? Aprobacion1Fecha { get { if (row.IsAPROBACION_1_FECHANull) return null; else return row.APROBACION_1_FECHA; } set { if (value.HasValue) row.APROBACION_1_FECHA = value.Value; else row.IsAPROBACION_1_FECHANull = true; } }
        public decimal? Aprobacion1UsuarioId { get { if (row.IsAPROBACION_1_USUARIO_IDNull) return null; else return row.APROBACION_1_USUARIO_ID; } set { if (value.HasValue) row.APROBACION_1_USUARIO_ID = value.Value; else row.IsAPROBACION_1_USUARIO_IDNull = true; } }
        public string Aprobacion2 { get { return ClaseCBABase.GetStringHelper(row.APROBACION_2); } set { row.APROBACION_2 = value; } }
        public DateTime? Aprobacion2Fecha { get { if (row.IsAPROBACION_2_FECHANull) return null; else return row.APROBACION_2_FECHA; } set { if (value.HasValue) row.APROBACION_2_FECHA = value.Value; else row.IsAPROBACION_2_FECHANull = true; } }
        public decimal? Aprobacion2UsuarioId { get { if (row.IsAPROBACION_2_USUARIO_IDNull) return null; else return row.APROBACION_2_USUARIO_ID; } set { if (value.HasValue) row.APROBACION_2_USUARIO_ID = value.Value; else row.IsAPROBACION_2_USUARIO_IDNull = true; } }
        public string Aprobacion3 { get { return ClaseCBABase.GetStringHelper(row.APROBACION_3); } set { row.APROBACION_3 = value; } }
        public DateTime? Aprobacion3Fecha { get { if (row.IsAPROBACION_3_FECHANull) return null; else return row.APROBACION_3_FECHA; } set { if (value.HasValue) row.APROBACION_3_FECHA = value.Value; else row.IsAPROBACION_3_FECHANull = true; } }
        public decimal? Aprobacion3UsuarioId { get { if (row.IsAPROBACION_3_USUARIO_IDNull) return null; else return row.APROBACION_3_USUARIO_ID; } set { if (value.HasValue) row.APROBACION_3_USUARIO_ID = value.Value; else row.IsAPROBACION_3_USUARIO_IDNull = true; } }
        public decimal? ArticuloId { get { if (row.IsARTICULO_IDNull) return null; else return row.ARTICULO_ID; } set { if (value.HasValue) { if (this.ArticuloId != value) this._articulo = null; row.ARTICULO_ID = value.Value; } else { row.IsARTICULO_IDNull = true; } } }
        public string AumentarCapitalPorDescuent { get { return row.AUMENTAR_CAPITAL_POR_DESCUENT; } set { row.AUMENTAR_CAPITAL_POR_DESCUENT = value; } }
        public decimal AutonumeracionId { get { return row.AUTONUMERACION_ID; } set { row.AUTONUMERACION_ID = value; } }
        public string BonificacionIncluyeImpuesto { get { return row.BONIFICACION_INCLUYE_IMPUESTO; } set { row.BONIFICACION_INCLUYE_IMPUESTO = value; } }
        public decimal? CanalVentaId { get { if (row.IsCANAL_VENTA_IDNull) return null; else return row.CANAL_VENTA_ID; } set { if (value.HasValue) row.CANAL_VENTA_ID = value.Value; else row.IsCANAL_VENTA_IDNull = true; } }
        public decimal CantidadCuotas { get { return row.CANTIDAD_CUOTAS; } set { row.CANTIDAD_CUOTAS = value; } }
        public decimal? CasoAsociadoId { get { if (row.IsCASO_ASOCIADO_IDNull) return null; else return row.CASO_ASOCIADO_ID; } set { if (value.HasValue) row.CASO_ASOCIADO_ID = value.Value; else row.IsCASO_ASOCIADO_IDNull = true; } }
        public decimal? CasoId { get { if (row.CASO_ID <= 0) return null; else return row.CASO_ID; } set { if (this.CasoId != value) this._caso = null; row.CASO_ID = value.Value; } }
        public string ConceptoIncluyeImpuesto { get { return row.CONCEPTO_INCLUYE_IMPUESTO; } set { row.CONCEPTO_INCLUYE_IMPUESTO = value; } }
        public string ConRecurso { get { return row.CON_RECURSO; } set { row.CON_RECURSO = value; } }
        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public decimal? CtacteCajaSucursalId { get { if (row.IsCTACTE_CAJA_SUCURSAL_IDNull) return null; else return row.CTACTE_CAJA_SUCURSAL_ID; } set { if (value.HasValue) row.CTACTE_CAJA_SUCURSAL_ID = value.Value; else row.IsCTACTE_CAJA_SUCURSAL_IDNull = true; } }
        public decimal? CtacteCajaTesoreriaId { get { if (row.IsCTACTE_CAJA_TESORERIA_IDNull) return null; else return row.CTACTE_CAJA_TESORERIA_ID; } set { if (value.HasValue) row.CTACTE_CAJA_TESORERIA_ID = value.Value; else row.IsCTACTE_CAJA_TESORERIA_IDNull = true; } }
        public decimal? CtacteFondoFijoId { get { if (row.IsCTACTE_FONDO_FIJO_IDNull) return null; else return row.CTACTE_FONDO_FIJO_ID; } set { if (value.HasValue) row.CTACTE_FONDO_FIJO_ID = value.Value; else row.IsCTACTE_FONDO_FIJO_IDNull = true; } }
        public decimal DescuentoCancAntCantNoVen { get { return row.DESCUENTO_CANC_ANT_CANT_NO_VEN; } set { row.DESCUENTO_CANC_ANT_CANT_NO_VEN = value; } }
        public decimal DescuentoCancelacionAnticip { get { return row.DESCUENTO_CANCELACION_ANTICIP; } set { row.DESCUENTO_CANCELACION_ANTICIP = value; } }
        public decimal DescuentoCancAntAplicado { get { return row.DESCUENTO_CANC_ANT_APLICADO; } set { row.DESCUENTO_CANC_ANT_APLICADO = value; } }
        public string DesembolsarParaCliente { get { return row.DESEMBOLSAR_PARA_CLIENTE; } set { row.DESEMBOLSAR_PARA_CLIENTE = value; } }
        public decimal DiasGracia { get { return row.DIAS_GRACIA; } set { row.DIAS_GRACIA = value; } }
        public decimal? EgresoVarioCajaId { get { if (row.IsEGRESO_VARIO_CAJA_IDNull) return null; else return row.EGRESO_VARIO_CAJA_ID; } set { if (value.HasValue) row.EGRESO_VARIO_CAJA_ID = value.Value; else row.IsEGRESO_VARIO_CAJA_IDNull = true; } }
        public decimal EntregaInicial { get { return row.ENTREGA_INICIAL; } set { row.ENTREGA_INICIAL = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? FacturaClienteAutonId { get { if (row.IsFACTURA_CLIENTE_AUTON_IDNull) return null; else return row.FACTURA_CLIENTE_AUTON_ID; } set { if (value.HasValue) row.FACTURA_CLIENTE_AUTON_ID = value.Value; else row.IsFACTURA_CLIENTE_AUTON_IDNull = true; } }
        public decimal? FacturaClienteId { get { if (row.IsFACTURA_CLIENTE_IDNull) return null; else return row.FACTURA_CLIENTE_ID; } set { if (value.HasValue) row.FACTURA_CLIENTE_ID = value.Value; else row.IsFACTURA_CLIENTE_IDNull = true; } }
        public string FacturarBonificacionEnPagos { get { return ClaseCBABase.GetStringHelper(row.FACTURAR_BONIFICACION_EN_PAGOS); } set { row.FACTURAR_BONIFICACION_EN_PAGOS = value; } }
        public decimal FacturarCapital { get { return row.FACTURAR_CAPITAL; } set { row.FACTURAR_CAPITAL = value; } }
        public string FacturarConceptosEnPagos { get { return ClaseCBABase.GetStringHelper(row.FACTURAR_CONCEPTOS_EN_PAGOS); } set { row.FACTURAR_CONCEPTOS_EN_PAGOS = value; } }
        public decimal FacturarIntereses { get { return row.FACTURAR_INTERESES; } set { row.FACTURAR_INTERESES = value; } }
        public DateTime? FechaCancelacionAnticipada { get { if (row.IsFECHA_CANCELACION_ANTICIPADANull) return null; else return row.FECHA_CANCELACION_ANTICIPADA; } set { if (value.HasValue) row.FECHA_CANCELACION_ANTICIPADA = value.Value; else row.IsFECHA_CANCELACION_ANTICIPADANull = true; } }
        public DateTime FechaPrimerVencimiento { get { return row.FECHA_PRIMER_VENCIMIENTO; } set { row.FECHA_PRIMER_VENCIMIENTO = value; } }
        public DateTime FechaSolicitud { get { return row.FECHA_SOLICITUD; } set { row.FECHA_SOLICITUD = value; } }
        public DateTime? FechaRetiro { get { if (row.IsFECHA_RETIRONull) return null; else return row.FECHA_RETIRO; } set { if (value.HasValue) row.FECHA_RETIRO = value.Value; else row.IsFECHA_RETIRONull = true; } }
        public decimal Frecuencia { get { return row.FRECUENCIA; } set { row.FRECUENCIA = value; } }
        public decimal FuncionarioId { get { return row.FUNCIONARIO_ID; } set { if (this.FuncionarioId != value) this._funcionario = null; row.FUNCIONARIO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string InteresCompuesto { get { return ClaseCBABase.GetStringHelper(row.INTERES_COMPUESTO); } set { row.INTERES_COMPUESTO = value; } }
        public string InteresIncluyeImpuesto { get { return row.INTERES_INCLUYE_IMPUESTO; } set { row.INTERES_INCLUYE_IMPUESTO = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { if (this.MonedaId != value) this._moneda = null;row.MONEDA_ID = value; } }
        public decimal? MontoBonificacion { get { if (row.IsMONTO_BONIFICACIONNull) return null; else return row.MONTO_BONIFICACION; } set { if (value.HasValue) row.MONTO_BONIFICACION = value.Value; else row.IsMONTO_BONIFICACIONNull = true; } }
        public decimal MontoCapitalAprobado { get { return row.MONTO_CAPITAL_APROBADO; } set { row.MONTO_CAPITAL_APROBADO = value; } }
        public decimal MontoCapitalOrdenCompra { get { return row.MONTO_CAPITAL_ORDEN_COMPRA; } set { row.MONTO_CAPITAL_ORDEN_COMPRA = value; } }
        public decimal MontoCapitalSolicitado { get { return row.MONTO_CAPITAL_SOLICITADO; } set { row.MONTO_CAPITAL_SOLICITADO = value; } }
        public decimal? MontoComisionAdmin { get { if (row.IsMONTO_COMISION_ADMINNull) return null; else return row.MONTO_COMISION_ADMIN; } set { if (value.HasValue) row.MONTO_COMISION_ADMIN = value.Value; else row.IsMONTO_COMISION_ADMINNull = true; } }
        public decimal? MontoCorretaje { get { if (row.IsMONTO_CORRETAJENull) return null; else return row.MONTO_CORRETAJE; } set { if (value.HasValue) row.MONTO_CORRETAJE = value.Value; else row.IsMONTO_CORRETAJENull = true; } }
        public decimal? MontoDiarioMora { get { if (row.IsMONTO_DIARIO_MORANull) return null; else return row.MONTO_DIARIO_MORA; } set { if (value.HasValue) row.MONTO_DIARIO_MORA = value.Value; else row.IsMONTO_DIARIO_MORANull = true; } }
        public decimal? MontoGastoAdministrativo { get { if (row.IsMONTO_GASTO_ADMINISTRATIVONull) return null; else return row.MONTO_GASTO_ADMINISTRATIVO; } set { if (value.HasValue) row.MONTO_GASTO_ADMINISTRATIVO = value.Value; else row.IsMONTO_GASTO_ADMINISTRATIVONull = true; } }
        public decimal? MontoInteres { get { if (row.IsMONTO_INTERESNull) return null; else return row.MONTO_INTERES; } set { if (value.HasValue) row.MONTO_INTERES = value.Value; else row.IsMONTO_INTERESNull = true; } }
        public decimal? MontoOtros { get { if (row.IsMONTO_OTROSNull) return null; else return row.MONTO_OTROS; } set { if (value.HasValue) row.MONTO_OTROS = value.Value; else row.IsMONTO_OTROSNull = true; } }
        public decimal MontoRedondeo { get { return row.MONTO_REDONDEO; } set { row.MONTO_REDONDEO = value; } }
        public decimal? MontoSeguro { get { if (row.IsMONTO_SEGURONull) return null; else return row.MONTO_SEGURO; } set { if (value.HasValue) row.MONTO_SEGURO = value.Value; else row.IsMONTO_SEGURONull = true; } }
        public decimal MontoTotal { get { return row.MONTO_TOTAL; } set { row.MONTO_TOTAL = value; } }
        public string NroComprobante { get { return GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string NumeroSolicitud { get { return GetStringHelper(row.NUMERO_SOLICITUD); } set { row.NUMERO_SOLICITUD = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? OrdenesPagoId { get { if (row.IsORDENES_PAGO_IDNull) return null; else return row.ORDENES_PAGO_ID; } set { if (value.HasValue) row.ORDENES_PAGO_ID = value.Value; else row.IsORDENES_PAGO_IDNull = true; } }
        public decimal? PersonaGarante1Id { get { if (row.IsPERSONA_GARANTE1_IDNull) return null; else return row.PERSONA_GARANTE1_ID; } set { if (value.HasValue) { if (this.PersonaGarante1Id != value) this._persona_garante1 = null; row.PERSONA_GARANTE1_ID = value.Value; } else { row.IsPERSONA_GARANTE1_IDNull = true; } } }
        public decimal? PersonaGarante2Id { get { if (row.IsPERSONA_GARANTE2_IDNull) return null; else return row.PERSONA_GARANTE2_ID; } set { if (value.HasValue) { if (this.PersonaGarante2Id != value) this._persona_garante2 = null; row.PERSONA_GARANTE2_ID = value.Value; } else { row.IsPERSONA_GARANTE2_IDNull = true; } } }
        public decimal PersonaId { get { return row.PERSONA_ID; } set { if (this.PersonaId != value) this._persona = null; row.PERSONA_ID = value; } }
        public decimal? PorcentajeBonificacion { get { if (row.IsPORCENTAJE_BONIFICACIONNull) return null; else return row.PORCENTAJE_BONIFICACION; } set { if (value.HasValue) row.PORCENTAJE_BONIFICACION = value.Value; else row.IsPORCENTAJE_BONIFICACIONNull = true; } }
        public decimal? PorcentajeComisionAdmin { get { if (row.IsPORCENTAJE_COMISION_ADMINNull) return null; else return row.PORCENTAJE_COMISION_ADMIN; } set { if (value.HasValue) row.PORCENTAJE_COMISION_ADMIN = value.Value; else row.IsPORCENTAJE_COMISION_ADMINNull = true; } }
        public decimal? PorcentajeCorretaje { get { if (row.IsPORCENTAJE_CORRETAJENull) return null; else return row.PORCENTAJE_CORRETAJE; } set { if (value.HasValue) row.PORCENTAJE_CORRETAJE = value.Value; else row.IsPORCENTAJE_CORRETAJENull = true; } }
        public decimal? PorcentajeGastoAdminist { get { if (row.IsPORCENTAJE_GASTO_ADMINISTNull) return null; else return row.PORCENTAJE_GASTO_ADMINIST; } set { if (value.HasValue) row.PORCENTAJE_GASTO_ADMINIST = value.Value; else row.IsPORCENTAJE_GASTO_ADMINISTNull = true; } }
        public decimal? PorcentajeDiarioMora { get { if (row.IsPORCENTAJE_DIARIO_MORANull) return null; else return row.PORCENTAJE_DIARIO_MORA; } set { if (value.HasValue) row.PORCENTAJE_DIARIO_MORA = value.Value; else row.IsPORCENTAJE_DIARIO_MORANull = true; } }
        public decimal? PorcentajeInteres { get { if (row.IsPORCENTAJE_INTERESNull) return null; else return row.PORCENTAJE_INTERES; } set { if (value.HasValue) row.PORCENTAJE_INTERES = value.Value; else row.IsPORCENTAJE_INTERESNull = true; } }
        public decimal? PorcentajeOtros { get { if (row.IsPORCENTAJE_OTROSNull) return null; else return row.PORCENTAJE_OTROS; } set { if (value.HasValue) row.PORCENTAJE_OTROS = value.Value; else row.IsPORCENTAJE_OTROSNull= true; } }
        public decimal? PorcentajeSeguro { get { if (row.IsPORCENTAJE_SEGURONull) return null; else return row.PORCENTAJE_SEGURO; } set { if (value.HasValue) row.PORCENTAJE_SEGURO = value.Value; else row.IsPORCENTAJE_SEGURONull = true; } }
        public string SeparacionBienes { get { return GetStringHelper(row.SEPARACION_BIENES); } set { row.SEPARACION_BIENES = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { if (this.SucursalId != value) this._sucursal = null; row.SUCURSAL_ID = value; } }
        public decimal TipoCreditoId { get { return row.TIPO_CREDITO_ID; } set { row.TIPO_CREDITO_ID = value; } }
        public string TipoFrecuencia { get { return row.TIPO_FRECUENCIA; } set { row.TIPO_FRECUENCIA = value; } }
        public string TipoInteresAnual { get { return row.TIPO_INTERES_ANUAL; } set { row.TIPO_INTERES_ANUAL = value; } }
        public decimal? TotalEgresos { get { if (row.IsTOTAL_EGRESOSNull) return null; else return row.TOTAL_EGRESOS; } set { if (value.HasValue) row.TOTAL_EGRESOS = value.Value; else row.IsTOTAL_EGRESOSNull = true; } }
        public decimal? TotalIngresos { get { if (row.IsTOTAL_INGRESOSNull) return null; else return row.TOTAL_INGRESOS; } set { if (value.HasValue) row.TOTAL_INGRESOS = value.Value; else row.IsTOTAL_INGRESOSNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        public bool TieneCancelacionAnticipada
        {
            get
            {
                if (!this.ExisteEnDB) 
                    return false;

                foreach (var c in this.Calendario)
                {
                    if (c.CancelacionAnticipada == Definiciones.SiNo.Si)
                        return true;
                }
                return false;
            }
        }

        private UsuariosService _aprobacion_1_usuario;
        public UsuariosService Aprobacion1Usuario
        {
            get
            {
                if (this._aprobacion_1_usuario == null)
                {
                    if (this.sesion != null)
                        this._aprobacion_1_usuario = new UsuariosService(this.Aprobacion1UsuarioId.Value, this.sesion);
                    else
                        this._aprobacion_1_usuario = new UsuariosService(this.Aprobacion1UsuarioId.Value);
                }
                return this._aprobacion_1_usuario;
            }
        }

        private UsuariosService _aprobacion_2_usuario;
        public UsuariosService Aprobacion2Usuario
        {
            get
            {
                if (this._aprobacion_2_usuario == null)
                {
                    if (this.sesion != null)
                        this._aprobacion_2_usuario = new UsuariosService(this.Aprobacion2UsuarioId.Value, this.sesion);
                    else
                        this._aprobacion_2_usuario = new UsuariosService(this.Aprobacion2UsuarioId.Value);
                }
                return this._aprobacion_2_usuario;
            }
        }

        private UsuariosService _aprobacion_3_usuario;
        public UsuariosService Aprobacion3Usuario
        {
            get
            {
                if (this._aprobacion_3_usuario == null)
                {
                    if (this.sesion != null)
                        this._aprobacion_3_usuario = new UsuariosService(this.Aprobacion3UsuarioId.Value, this.sesion);
                    else
                        this._aprobacion_3_usuario = new UsuariosService(this.Aprobacion3UsuarioId.Value);
                }
                return this._aprobacion_3_usuario;
            }
        }
        
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                    this._articulo = new ArticulosService(this.ArticuloId.Value);
                return this._articulo;
            }
        }

        private ArticulosFinancierosService _articulo_financiero;
        public ArticulosFinancierosService ArticuloFinanciero
        {
            get
            {
                if (!this.ArticuloId.HasValue)
                    return null;

                if (this._articulo_financiero == null || this._articulo_financiero.ArticuloId != this.ArticuloId.Value)
                    this._articulo_financiero = this.GetPrimero<ArticulosFinancierosService>(new Filtro { Columna = ArticulosFinancierosService.Modelo.ARTICULO_IDColumnName, Valor = this.ArticuloId.Value });
                return this._articulo_financiero;
            }
        }


        private ActivosService _activo;
        public ActivosService Activo
        {
            get
            {
                if (this._activo == null)
                    this._activo = new ActivosService(this.ActivoId.Value);
                return this._activo;
            }
        }

        private CanalesVentaService _canal_venta;
        public CanalesVentaService CanalVenta
        {
            get
            {
                if (this._canal_venta == null)
                {
                    if (this.sesion != null)
                        this._canal_venta = new CanalesVentaService(this.CanalVentaId.Value, this.sesion);
                    else
                        this._canal_venta = new CanalesVentaService(this.CanalVentaId.Value);
                }
                return this._canal_venta;
            }
        }

        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    if(this.sesion != null)
                        this._caso = new CasosService(this.CasoId.Value, this.sesion);
                    else
                        this._caso = new CasosService(this.CasoId.Value);
                }
                return this._caso;
            }
        }

        private FuncionariosService _funcionario;
        public FuncionariosService Funcionario
        {
            get
            {
                if (this._funcionario == null)
                {
                    if (this.sesion != null)
                        this._funcionario = new FuncionariosService(this.FuncionarioId, this.sesion);
                    else
                        this._funcionario = new FuncionariosService(this.FuncionarioId);
                }
                return this._funcionario;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = this.Get<MonedasService>(this.MonedaId);
                return this._moneda;
            }
        }

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                {
                    if (this.sesion != null)
                        this._persona = new PersonasService(this.PersonaId, this.sesion);
                    else
                        this._persona = new PersonasService(this.PersonaId);
                }
                return this._persona;
            }
        }

        private PersonasService _persona_garante1;
        public PersonasService PersonaGarante1
        {
            get
            {
                if (this._persona_garante1 == null)
                {
                    if (this.sesion != null)
                        this._persona_garante1 = new PersonasService(this.PersonaGarante1Id.Value, this.sesion);
                    else
                        this._persona_garante1 = new PersonasService(this.PersonaGarante1Id.Value);
                }
                return this._persona_garante1;
            }
        }

        private PersonasService _persona_garante2;
        public PersonasService PersonaGarante2
        {
            get
            {
                if (this._persona_garante2 == null)
                {
                    if (this.sesion != null)
                        this._persona_garante2 = new PersonasService(this.PersonaGarante2Id.Value, this.sesion);
                    else
                        this._persona_garante2 = new PersonasService(this.PersonaGarante2Id.Value);
                }
                return this._persona_garante2;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                {
                    if (this.sesion != null)
                        this._sucursal = new SucursalesService(this.SucursalId, this.sesion);
                    else
                        this._sucursal = new SucursalesService(this.SucursalId);
                }
                return this._sucursal;
            }
        }

        public int CantidadDias
        {
            get 
            {
                DateTime[] vencimientos = CreditosService.CalcularVencimientos(this.FechaPrimerVencimiento, (int)this.CantidadCuotas, this.TipoFrecuencia, (int)this.Frecuencia);
                return (vencimientos[vencimientos.Length - 1].Date - (this.FechaRetiro.HasValue ? this.FechaRetiro.Value.Date : this.FechaSolicitud.Date)).Days;
            }
        }

        public DateTime FechaPrimerVencimientoSugerido
        {
            get
            {
                DateTime fecha;

                switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
                {
                    case Definiciones.Clientes.Apro:
                        fecha = FechaPrimerVencimientoSugerido_23();
                        break;
                    case Definiciones.Clientes.Electroban:
                        fecha = FechaPrimerVencimientoSugerido_9();
                        break;
                    default:
                        fecha = this.FechaRetiro.HasValue ? this.FechaRetiro.Value : this.FechaSolicitud;
                        switch (this.TipoFrecuencia)
                        {
                            case Definiciones.TiposIntervalo.Anhos:
                                fecha = fecha.AddYears((int)this.Frecuencia);
                                break;
                            case Definiciones.TiposIntervalo.Dias:
                                fecha = fecha.AddDays((int)this.Frecuencia);
                                break;
                            case Definiciones.TiposIntervalo.Meses:
                                fecha = fecha.AddMonths((int)this.Frecuencia);
                                break;
                            case Definiciones.TiposIntervalo.Semanas:
                                fecha = fecha.AddDays((int)this.Frecuencia * 7);
                                break;
                            default: throw new Exception("CreditosService.FechaPrimerVencimientoSugerido. Tipo de frecuencia " + this.TipoFrecuencia + "no implementado");
                        }
                        break;
                }
                return fecha;
            }
        }

        public decimal MontoDescuentos
        {
            get
            {
                decimal monto = 0;
                int plazo = this.CantidadDias;

                monto += this.GetMontoGastoAdministrativo(plazo);
                monto += this.GetMontoSeguro(plazo);
                monto += this.GetMontoCorretaje(plazo);
                monto += this.GetMontoComisionAministrativa(plazo);
                monto += this.GetMontoOtros(plazo);
                monto += this.GetMontoBonificacion(plazo);
                
                return monto;
            }
        }

        public decimal TasaAnualEfectiva
        {
            get
            {
                return (decimal)TiposCreditoService.TirNoPer.Calcular(this);
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private CalendarioService[] _calendario;
        public CalendarioService[] Calendario
        {
            get
            {
                if (this._calendario == null)
                    this._calendario = this.GetFiltrado<CalendarioService>(new Filtro { Columna = CalendarioService.Modelo.CREDITO_IDColumnName, Valor = this.Id.Value });
                return this._calendario;
            }
        }

        private CuentaCorrientePersonasService[] _ctacte_persona_cancelacion;
        public CuentaCorrientePersonasService[] CtactePersonasCancelacion
        {
            get
            {
                if (this._ctacte_persona_cancelacion == null)
                {
                    string clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + this.CasoId.Value + " and " +
                                       CuentaCorrientePersonasService.CtaCteConceptoId_NombreCol + " = " + Definiciones.CuentaCorrienteConceptos.Financiacion + " and " +
                                       CuentaCorrientePersonasService.CalendarioPagosCrCliId_NombreCol + " is null";
                    DataTable dt;
                    if(this.sesion != null)
                    {
                        dt = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, this.sesion);
                        this._ctacte_persona_cancelacion = new CuentaCorrientePersonasService[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                            this._ctacte_persona_cancelacion[i] = new CuentaCorrientePersonasService((decimal)dt.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], this.sesion);
                    }
                    else
                    {
                        using (SessionService sesion = new SessionService())
                        {
                            dt = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(clausulas, string.Empty, sesion);
                            this._ctacte_persona_cancelacion = new CuentaCorrientePersonasService[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count; i++)
                                this._ctacte_persona_cancelacion[i] = new CuentaCorrientePersonasService((decimal)dt.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], sesion);
                        }
                    }
                }
                return this._ctacte_persona_cancelacion;
            }
        }

        private CreditosDetallesService[] _detalles_ingreso;
        public CreditosDetallesService[] DetallesIngreso
        {
            get
            {
                if (this._detalles_ingreso == null)
                {
                    this._detalles_ingreso = this.GetFiltrado<CreditosDetallesService>(new Filtro[]
                    {
                        new Filtro { Columna = CreditosDetallesService.Modelo.CREDITO_IDColumnName, Valor = this.Id.Value },
                        new Filtro { Columna = CreditosDetallesService.Modelo.TIPO_TEXTO_PREDEFINIDO_IDColumnName, Valor = Definiciones.TipoTextoPredefinido.CreditosTiposIngreso },
                    });
                }
                return this._detalles_ingreso;
            }
        }

        private CreditosDetallesService[] _detalles_egreso;
        public CreditosDetallesService[] DetallesEgreso
        {
            get
            {
                if (this._detalles_egreso == null)
                {
                    this._detalles_egreso = this.GetFiltrado<CreditosDetallesService>(new Filtro[]
                    {
                        new Filtro { Columna = CreditosDetallesService.Modelo.CREDITO_IDColumnName, Valor = this.Id.Value },
                        new Filtro { Columna = CreditosDetallesService.Modelo.TIPO_TEXTO_PREDEFINIDO_IDColumnName, Valor = Definiciones.TipoTextoPredefinido.CreditosTiposEgreso },
                    });
                }
                return this._detalles_egreso;
            }
        }

        private CreditosDescuentosService[] _descuentos;
        public CreditosDescuentosService[] Descuentos
        {
            get
            {
                if (this._descuentos == null)
                    this._descuentos = this.GetFiltrado<CreditosDescuentosService>(new Filtro { Columna = CalendarioService.Modelo.CREDITO_IDColumnName, Valor = this.Id.Value });
                return this._descuentos;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CREDITOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CREDITOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CREDITOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CreditosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CreditosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CreditosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private CreditosService(CREDITOSRow row)
        {
            Inicializar(row);
        }
        public CreditosService(EdiCBA.Credito campos, SessionService sesion) : this(Definiciones.Error.Valor.EnteroPositivo, sesion)
        {
            this.IniciarUsingSesion(sesion);

            try
            {
                #region validaciones
                if (campos.sucursal_id <= 0)
                    throw new Exception("La sucursal es inválida.");

                if (!campos.funcionario_id.HasValue || campos.funcionario_id <= 0)
                    throw new Exception("El funcionario es inválido.");

                if (!campos.persona_id.HasValue || campos.persona_id.Value <= 0)
                    throw new Exception("La persona es inválida.");

                if (campos.articulo_id <= 0)
                    throw new Exception("Debe indicar un artículo financiero.");

                if (campos.autonumeracion_id <= 0)
                    throw new Exception("Debe indicar una autonumeración para la sucursal seleccionada.");

                if (campos.cantidad_cuotas <= 0)
                    throw new Exception("Debe indicar la cantidad de cuotas.");

                if (campos.monto_capital_solicitado + campos.monto_capital_orden_compra <= 0)
                    throw new Exception("Debe indicar el capital solicitado o el monto de la orden de compra.");
                #endregion validaciones

                #region asignacion de campos
                this.SucursalId = campos.sucursal_id;
                this.PersonaId = campos.persona_id.Value;
                if (campos.persona_garante1_id.HasValue)
                    this.PersonaGarante1Id = campos.persona_garante1_id;
                if (campos.persona_garante2_id.HasValue)
                    this.PersonaGarante2Id = campos.persona_garante2_id;
                this.SeparacionBienes = this.Persona.SeparacionBienes;
                this.FechaSolicitud = campos.fecha_solicitud;
                this.FechaPrimerVencimiento = campos.fecha_primer_vencimiento;
                if (campos.canal_venta_id.HasValue)
                    this.CanalVentaId = campos.canal_venta_id.Value;
                this.FuncionarioId = campos.funcionario_id.Value;
                this.AutonumeracionId = campos.autonumeracion_id;
                this.NroComprobante = campos.nro_comprobante;
                this.NumeroSolicitud = campos.numero_solicitud;
                this.FechaSolicitud = campos.fecha_solicitud;
                this.Aprobacion1 = Definiciones.SiNo.No;
                this.Aprobacion2 = Definiciones.SiNo.No;
                this.Aprobacion3 = Definiciones.SiNo.No;
                this.Observacion = campos.observacion;
                this.AfectaLineaCredito = Definiciones.SiNo.Si;
                this.MontoCapitalSolicitado = campos.monto_capital_solicitado;
                this.MontoCapitalOrdenCompra = campos.monto_capital_orden_compra;
                
                this.Cotizacion = campos.cotizacion;
                if (this.Cotizacion <= 0)
                {
                    this.Cotizacion = CotizacionesService.GetCotizacionMonedaCompra(this.Sucursal.PaisId, this.MonedaId, this.FechaSolicitud, sesion);
                    if (this.Cotizacion <= 0)
                        throw new System.ArgumentException("La moneda no tiene una cotización actualizada.");
                }

                if (campos.articulo_id.HasValue)
                {
                    ArticulosFinancierosService articulo = this.GetPrimero<ArticulosFinancierosService>(new ClaseCBABase.Filtro { Columna = ArticulosFinancierosService.Modelo.ARTICULO_IDColumnName, Valor = campos.articulo_id });
                    this.ArticuloId = articulo.ArticuloId;
                    this.MonedaId = articulo.MonedaId;
                    this.TipoFrecuencia = articulo.TipoFrecuencia;
                    this.Frecuencia = articulo.Frecuencia;
                    this.TipoCreditoId = articulo.TipoCreditoId;
                    this.InteresCompuesto = articulo.TipoArticuloFinanciero.InteresCompuesto;
                    this.TipoInteresAnual = articulo.TipoInteresAnual;
                    this.AnhoComercial = articulo.AnhoComercial;
                    this.DesembolsarParaCliente = articulo.DesembolsarParaCliente;
                    this.MontoRedondeo = articulo.MontoRedondeo;
                    this.FacturarIntereses = articulo.FacturarIntereses;
                    this.FacturarConceptosEnPagos = articulo.FacturarConceptosEnPagos;
                    this.FacturarCapital = articulo.FacturarCapital;
                    this.FacturarBonificacionEnPagos = articulo.FacturarBonificacionEnPagos;
                    this.InteresIncluyeImpuesto = articulo.InteresIncluyeImpuesto;
                    this.BonificacionIncluyeImpuesto = articulo.BonificacionIncluyeImpuesto;
                    this.ConceptoIncluyeImpuesto = articulo.ConceptoIncluyeImpuesto;
                    this.AumentarCapitalPorDescuent = articulo.AumentarCapitalPorDescuent;
                    this.ConRecurso = articulo.ConRecurso;
                    this.CantidadCuotas = campos.cantidad_cuotas;
                    
                    #region Inicializar valores relacionados a rangos
                    ArticulosFinancierosRangosService rango;
                    int cantidadDias = this.CantidadDias;

                    rango = articulo.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.InteresCorriente, this.MontoCapitalSolicitado, this.CantidadCuotas, cantidadDias);
                    if (rango.Monto.HasValue)
                    {
                        this.MontoInteres = rango.Monto.Value;
                        this.PorcentajeInteres = null;
                    }
                    else
                    {
                        this.MontoInteres = null;
                        this.PorcentajeInteres = rango.Porcentaje.Value;
                    }

                    rango = articulo.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo, this.MontoCapitalSolicitado, this.CantidadCuotas, cantidadDias);
                    if (rango.Monto.HasValue)
                    {
                        this.MontoGastoAdministrativo = rango.Monto.Value;
                        this.PorcentajeGastoAdminist = null;
                    }
                    else
                    {
                        this.MontoGastoAdministrativo = null;
                        this.PorcentajeGastoAdminist = rango.Porcentaje.Value;
                    }

                    rango = articulo.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Seguro, this.MontoCapitalSolicitado, this.CantidadCuotas, cantidadDias);
                    if (rango.Monto.HasValue)
                    {
                        this.MontoSeguro = rango.Monto.Value;
                        this.PorcentajeSeguro = null;
                    }
                    else
                    {
                        this.MontoSeguro = null;
                        this.PorcentajeSeguro = rango.Porcentaje.Value;
                    }


                    rango = articulo.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Corretaje, this.MontoCapitalSolicitado, this.CantidadCuotas, cantidadDias);
                    if (rango.Monto.HasValue)
                    {
                        this.MontoCorretaje = rango.Monto.Value;
                        this.PorcentajeCorretaje = null;
                    }
                    else
                    {
                        this.MontoCorretaje = null;
                        this.PorcentajeCorretaje = rango.Porcentaje.Value;
                    }

                    rango = articulo.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.ComisionAdministrativa, this.MontoCapitalSolicitado, this.CantidadCuotas, cantidadDias);
                    if (rango.Monto.HasValue)
                    {
                        this.MontoComisionAdmin = rango.Monto.Value;
                        this.PorcentajeComisionAdmin = null;
                    }
                    else
                    {
                        this.MontoComisionAdmin = null;
                        this.PorcentajeComisionAdmin = rango.Porcentaje.Value;
                    }

                    rango = articulo.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Otros, this.MontoCapitalSolicitado, this.CantidadCuotas, cantidadDias);
                    if (rango.Monto.HasValue)
                    {
                        this.MontoOtros = rango.Monto.Value;
                        this.PorcentajeOtros = null;
                    }
                    else
                    {
                        this.MontoOtros = null;
                        this.PorcentajeOtros = rango.Porcentaje.Value;
                    }

                    rango = articulo.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.BonificacionOrdenCompra, this.MontoCapitalSolicitado, this.CantidadCuotas, cantidadDias);
                    if (rango.Monto.HasValue)
                    {
                        this.MontoBonificacion = rango.Monto.Value;
                        this.PorcentajeBonificacion = null;
                    }
                    else
                    {
                        this.MontoBonificacion = null;
                        this.PorcentajeBonificacion = rango.Porcentaje.Value;
                    }
                    #endregion Inicializar valores relacionados a rangos
                }
                else
                {
                    this.MontoCapitalAprobado = this.MontoCapitalSolicitado; 
                    this.MonedaId = campos.moneda_id;
                    this.TipoFrecuencia = Definiciones.TiposIntervalo.Meses;
                    this.Frecuencia = 1;
                    this.TipoCreditoId = Definiciones.TiposCredito.Frances;
                    this.InteresCompuesto = Definiciones.SiNo.No;
                    this.TipoInteresAnual = Definiciones.SiNo.Si;
                    this.AnhoComercial = Definiciones.SiNo.Si;
                    this.DesembolsarParaCliente = Definiciones.SiNo.Si;
                    this.MontoRedondeo = 0;
                    this.FacturarIntereses = Definiciones.CreditosPoliticaFacturacion.Desembolso;
                    this.FacturarConceptosEnPagos = Definiciones.SiNo.Si;
                    this.FacturarCapital = Definiciones.CreditosPoliticaFacturacion.Desembolso;
                    this.FacturarBonificacionEnPagos = Definiciones.SiNo.No;
                    this.InteresIncluyeImpuesto = Definiciones.SiNo.Si;
                    this.BonificacionIncluyeImpuesto = Definiciones.SiNo.Si;
                    this.ConceptoIncluyeImpuesto = Definiciones.SiNo.Si;
                    this.AumentarCapitalPorDescuent = Definiciones.SiNo.Si;
                    this.ConRecurso = Definiciones.SiNo.No;
                    this.CantidadCuotas = campos.cantidad_cuotas;
                }
                #endregion asignacion de campos

                this.FinalizarUsingSesion();
            }
            catch (Exception e)
            {
                this.FinalizarUsingSesion();
                throw e;
            }
        }
        #endregion Constructores

        #region GetMontos
        public decimal GetMontoGastoAdministrativo(int plazo)
        {
            int diasAnho = this.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;
            decimal monto = 0;

            if (this.PorcentajeGastoAdminist.HasValue)
            {
                monto = this.MontoCapitalAprobado * this.PorcentajeGastoAdminist.Value / 100;

                if (this.ArticuloFinanciero != null)
                {
                    var rango = this.ArticuloFinanciero.GetPrimero<ArticulosFinancierosRangosService>(new Filtro[]
                        { 
                            new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.ArticuloFinanciero.Id.Value },
                            new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo },
                        });

                    if (rango.ConsiderarPlazo == Definiciones.SiNo.Si)
                        monto = monto / diasAnho * plazo;
                }
                else
                {
                    monto = monto / diasAnho * plazo;
                }
            }
            else
            {
                monto = this.MontoGastoAdministrativo.Value;
            }

            if (this.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
            {
                var tipo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo);
                monto *= (1 + ImpuestosService.GetPorcentajePorId(tipo.Articulo.ImpuestoId) / 100);
            }

            return monto;
        }

        public decimal GetMontoSeguro(int plazo)
        {
            int diasAnho = this.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;
            decimal monto = 0;

            if (this.PorcentajeSeguro.HasValue)
            {
                monto = this.MontoCapitalAprobado * this.PorcentajeSeguro.Value / 100;

                if (this.ArticuloFinanciero != null)
                {
                    var rango = this.ArticuloFinanciero.GetPrimero<ArticulosFinancierosRangosService>(new Filtro[]
                    { 
                        new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.ArticuloFinanciero.Id.Value },
                        new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)Definiciones.TiposArticuloFinancieroRango.Seguro },
                    });

                    if (rango.ConsiderarPlazo == Definiciones.SiNo.Si)
                        monto += monto / diasAnho * plazo;
                }
                else
                {
                    monto += monto / diasAnho * plazo;
                }
            }
            else
            {
                monto += this.MontoSeguro.Value;
            }

            if (this.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
            {
                var tipo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Seguro);
                monto *= (1 + ImpuestosService.GetPorcentajePorId(tipo.Articulo.ImpuestoId) / 100);
            }

            return monto;
        }

        public decimal GetMontoCorretaje(int plazo)
        {
            int diasAnho = this.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;
            decimal monto = 0;

            if (this.PorcentajeCorretaje.HasValue)
            {
                monto = this.MontoCapitalAprobado * this.PorcentajeCorretaje.Value / 100;

                if (this.ArticuloFinanciero != null)
                {
                    var rango = this.ArticuloFinanciero.GetPrimero<ArticulosFinancierosRangosService>(new Filtro[]
                    { 
                        new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.ArticuloFinanciero.Id.Value },
                        new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)Definiciones.TiposArticuloFinancieroRango.Corretaje},
                    });

                    if (rango.ConsiderarPlazo == Definiciones.SiNo.Si)
                        monto = monto / diasAnho * plazo;
                }
                else
                {
                    monto = monto / diasAnho * plazo;
                }
            }
            else
            {
                monto = this.MontoCorretaje.Value;
            }

            if (this.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
            {
                var tipo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Corretaje);
                monto *= (1 + ImpuestosService.GetPorcentajePorId(tipo.Articulo.ImpuestoId) / 100);
            }
            return monto;
        }

        public decimal GetMontoComisionAministrativa(int plazo)
        {
            int diasAnho = this.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;
            decimal monto = 0;

            if (this.PorcentajeComisionAdmin.HasValue)
            {
                monto = this.MontoCapitalAprobado * this.PorcentajeComisionAdmin.Value / 100;

                if (this.ArticuloFinanciero != null)
                {
                    var rango = this.ArticuloFinanciero.GetPrimero<ArticulosFinancierosRangosService>(new Filtro[]
                        { 
                            new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.ArticuloFinanciero.Id.Value },
                            new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)Definiciones.TiposArticuloFinancieroRango.ComisionAdministrativa},
                        });

                    if (rango.ConsiderarPlazo == Definiciones.SiNo.Si)
                        monto = monto / diasAnho * plazo;
                }
                else
                {
                    monto = monto / diasAnho * plazo;
                }
            }
            else
            {
                monto = this.MontoComisionAdmin.Value;
            }

            if (this.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
            {
                var tipo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.ComisionAdministrativa);
                monto *= (1 + ImpuestosService.GetPorcentajePorId(tipo.Articulo.ImpuestoId) / 100);
            }

            return monto;
        }

        public decimal GetMontoOtros(int plazo)
        {
            int diasAnho = this.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;
            decimal monto = 0;

            if (this.PorcentajeOtros.HasValue)
            {
                monto = this.MontoCapitalAprobado * this.PorcentajeOtros.Value / 100;

                if (this.ArticuloFinanciero != null)
                {
                    var rango = this.ArticuloFinanciero.GetPrimero<ArticulosFinancierosRangosService>(new Filtro[]
                        { 
                            new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.ArticuloFinanciero.Id.Value },
                            new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)Definiciones.TiposArticuloFinancieroRango.Otros},
                        });

                    if (rango.ConsiderarPlazo == Definiciones.SiNo.Si)
                        monto = monto / diasAnho * plazo;
                }
                else
                {
                    monto = monto / diasAnho * plazo;
                }
            }
            else
            {
                monto = this.MontoOtros.Value;
            }

            if (this.ConceptoIncluyeImpuesto == Definiciones.SiNo.No)
            {
                var tipo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Otros);
                monto *= (1 + ImpuestosService.GetPorcentajePorId(tipo.Articulo.ImpuestoId) / 100);
            }

            return monto;
        }

        public decimal GetMontoBonificacion(int plazo)
        {
            int diasAnho = this.AnhoComercial == Definiciones.SiNo.Si ? 360 : 365;
            decimal monto = 0;
            
            if (this.PorcentajeBonificacion.HasValue)
            {
                monto = this.MontoCapitalOrdenCompra * this.PorcentajeBonificacion.Value / 100;

                if (this.ArticuloFinanciero != null)
                {
                    var rango = this.ArticuloFinanciero.GetPrimero<ArticulosFinancierosRangosService>(new Filtro[]
                        { 
                            new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.ARTICULO_FINANCIERO_IDColumnName, Valor = this.ArticuloFinanciero.Id.Value },
                            new Filtro { Columna = ArticulosFinancierosRangosService.Modelo.TIPO_ARTICULO_FINANC_RANGO_IDColumnName, Valor = (int)Definiciones.TiposArticuloFinancieroRango.BonificacionOrdenCompra},
                        });

                    if (rango.ConsiderarPlazo == Definiciones.SiNo.Si)
                        monto = monto / diasAnho * plazo;
                }
                else
                {
                    monto = monto / diasAnho * plazo;
                }
            }
            else
            {
                monto = this.MontoBonificacion.Value;
            }

            if (this.BonificacionIncluyeImpuesto == Definiciones.SiNo.No)
            {
                var tipo = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.BonificacionOrdenCompra);
                monto *= (1 + ImpuestosService.GetPorcentajePorId(tipo.Articulo.ImpuestoId) / 100);
            }

            return monto;
        }
        #endregion GetMontos

        #region GetPorCaso
        public static CreditosService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static CreditosService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var creditoService = CreditosService.Instancia;
            creditoService.IniciarUsingSesion(sesion);
            var credito = creditoService.GetPrimero<CreditosService>(new Filtro
            {
                Columna = Modelo.CASO_IDColumnName,
                Valor = caso_id
            });
            creditoService.FinalizarUsingSesion();
            return credito;
        }
        #endregion GetPorCaso

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            bool casoNuevo = false;

            try
            {
                if (this.controlarPermisosGuardado && !Permisos.CreditosCrear)
                    throw new Exception("No tiene permisos para guardar");

                #region niveles aprobacion
                if (this.Aprobacion1 != this.rowSinModificar.APROBACION_1)
                {
                    if (this.Aprobacion1 == Definiciones.SiNo.Si && this.Permisos.CreditosEditarAprobacion1)
                    {
                        this.Aprobacion1Fecha = DateTime.Now;
                        this.Aprobacion1UsuarioId = sesion.Usuario_Id;
                    }
                    else
                    {
                        this.Aprobacion1Fecha = null;
                        this.Aprobacion1UsuarioId = null;
                    }
                }

                if (this.Aprobacion2 != this.rowSinModificar.APROBACION_2)
                {
                    if (this.Aprobacion2 == Definiciones.SiNo.Si && this.Permisos.CreditosEditarAprobacion2)
                    {
                        this.Aprobacion2Fecha = DateTime.Now;
                        this.Aprobacion2UsuarioId = sesion.Usuario_Id;
                    }
                    else
                    {
                        this.Aprobacion2Fecha = null;
                        this.Aprobacion2UsuarioId = null;
                    }
                }

                if (this.Aprobacion3 != this.rowSinModificar.APROBACION_3)
                {
                    if (this.Aprobacion3 == Definiciones.SiNo.Si && this.Permisos.CreditosEditarAprobacion2)
                    {
                        this.Aprobacion3Fecha = DateTime.Now;
                        this.Aprobacion3UsuarioId = sesion.Usuario_Id;
                    }
                    else
                    {
                        this.Aprobacion3Fecha = null;
                        this.Aprobacion3UsuarioId = null;
                    }
                }
                #endregion niveles aprobacion

                this.Validar();

                if (!this.ExisteEnDB)
                {
                    casoNuevo = true;
                    CrearCasos CrearCaso = new CrearCasos((int)this.SucursalId, Definiciones.FlujosIDs.CREDITOS, (int)sesion.Usuario_Id, SessionService.GetClienteIP());
                    this.CasoId = int.Parse(CrearCaso.Ejecutar(sesion));
                    this.Estado = Definiciones.Estado.Activo;
                    this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);

                    if (this.InteresCompuesto.Length <= 0)
                        this.InteresCompuesto = Definiciones.SiNo.Si;
                    this.DescuentoCancAntCantNoVen = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CreditosPersonasCancelacionAnticipadaCuotasSinVencer);

                    sesion.db.CREDITOSCollection.Insert(this.row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
                }
                else
                {
                    #region Recalcular cuotas si cambian datos que inciden
                    if (this.Calendario.Length > 0 &&
                        (this.MontoCapitalAprobado != this.rowSinModificar.MONTO_CAPITAL_APROBADO ||
                         this.PorcentajeInteres.HasValue == this.rowSinModificar.IsPORCENTAJE_INTERESNull ||
                         this.PorcentajeInteres.HasValue && this.PorcentajeInteres.Value != this.rowSinModificar.PORCENTAJE_INTERES ||
                         this.MontoInteres.HasValue == this.rowSinModificar.IsMONTO_INTERESNull ||
                         this.MontoInteres.HasValue && this.MontoInteres.Value != this.rowSinModificar.MONTO_INTERES ||
                         this.CantidadCuotas != this.rowSinModificar.CANTIDAD_CUOTAS ||
                         this.Frecuencia != this.rowSinModificar.FRECUENCIA ||
                         this.TipoFrecuencia != this.rowSinModificar.TIPO_FRECUENCIA ||
                         this.TipoCreditoId != this.rowSinModificar.TIPO_CREDITO_ID)
                       )
                    {
                        foreach (var cuota in this.Calendario)
                        {
                            cuota.IniciarUsingSesion(sesion);
                            cuota.Borrar();
                            cuota.FinalizarUsingSesion();
                        }
                        this._calendario = null;

                        this.MontoInteres = 0;
                        foreach (var cuota in TiposCreditoService.CalcularCuotasPorTipo(this))
                        {
                            cuota.IniciarUsingSesion(sesion);
                            this.MontoInteres += cuota.MontoInteresADevengar;
                            cuota.Guardar();
                            cuota.FinalizarUsingSesion();
                        }
                    }
                    #endregion Recalcular cuotas si cambian datos que inciden

                    #region Actualizar fecha primer vencimiento y desplazar cuotas si cambian datos que inciden
                    if (this.Calendario.Length > 0 &&
                        (this.Frecuencia != this.rowSinModificar.FRECUENCIA ||
                         this.TipoFrecuencia != this.rowSinModificar.TIPO_FRECUENCIA ||
                         this.FechaSolicitud != this.rowSinModificar.FECHA_SOLICITUD ||
                         this.FechaPrimerVencimiento != this.rowSinModificar.FECHA_PRIMER_VENCIMIENTO ||
                         this.FechaRetiro.HasValue == this.rowSinModificar.IsFECHA_RETIRONull ||
                         this.FechaRetiro.HasValue && this.FechaRetiro.Value != this.rowSinModificar.FECHA_RETIRO)
                       )
                    {
                        if (this.FechaRetiro.HasValue && (this.rowSinModificar.IsFECHA_RETIRONull || this.FechaRetiro.Value != this.rowSinModificar.FECHA_RETIRO))
                            this.FechaPrimerVencimiento = this.FechaPrimerVencimientoSugerido;

                        CreditosService creditoTmp = new CreditosService(this.row.Clonar());
                        int contador = 0;
                        foreach (var cuota in TiposCreditoService.CalcularCuotasPorTipo(creditoTmp))
                        {
                            var c = this.Calendario[contador++];
                            c.IniciarUsingSesion(sesion);
                            c.FechaVencimiento = cuota.FechaVencimiento.Date;
                            c.Guardar();
                            c.FinalizarUsingSesion();
                        }
                    }
                    #endregion Actualizar fecha primer vencimiento y desplazar cuotas si cambian datos que inciden

                    sesion.db.CREDITOSCollection.Update(this.row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
                }

                //Actualizar total en la tabla de pagaré
                if (CuentaCorrientePagaresService.ExistePorCaso(this.CasoId.Value, this.sesion))
                    this.ActualizarMontoPagareGarantia();

                #region Actualizar datos en tabla casos
                this.Caso.FechaFormulario = this.FechaSolicitud;
                this.Caso.NroComprobante = this.NroComprobante;
                this.Caso.NroComprobante2 = this.NumeroSolicitud;
                this.Caso.PersonaId = this.PersonaId;
                this.Caso.FuncionarioId = this.FuncionarioId;
                this.Caso.SucursalId = this.SucursalId;
                this.Caso.Guardar(this.sesion);
                #endregion Actualizar datos en tabla casos

                this.rowSinModificar = this.row.Clonar();
                return this.Id.Value;
            }
            catch
            {
                //Si el caso fue creado el mismo debe borrarse
                if (casoNuevo && this.CasoId > 0)
                    (new CasosService()).Eliminar(row.CASO_ID, sesion);

                throw;
            }
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if (this.Cotizacion <= 0)
                throw new System.ArgumentException("La moneda no tiene una cotización actualizada.");

            if (this.PersonaId != this.rowSinModificar.PERSONA_ID)
            { 
                if(this.Persona.Estado == Definiciones.Estado.Inactivo)
                    excepciones.Agregar(Traducciones.La_persona_esta_inactiva, null);
                if (PersonasService.EstaBloqueado(this.PersonaId))
                    excepciones.Agregar(Traducciones.La_persona_esta_bloqueada, null);
            }

            if (this.PersonaGarante1Id.HasValue && (this.rowSinModificar.IsPERSONA_GARANTE1_IDNull || this.PersonaGarante1Id.Value != this.rowSinModificar.PERSONA_GARANTE1_ID))
            {
                if (this.PersonaGarante1.Estado == Definiciones.Estado.Inactivo)
                    excepciones.Agregar("El primer garante está inactivo.", null);
                if (PersonasService.EstaBloqueado(this.PersonaGarante1Id.Value))
                    excepciones.Agregar("El primer garante está bloqueado", null);
            }

            if (this.PersonaGarante2Id.HasValue && (this.rowSinModificar.IsPERSONA_GARANTE2_IDNull || this.PersonaGarante2Id.Value != this.rowSinModificar.PERSONA_GARANTE2_ID))
            {
                if (this.PersonaGarante2.Estado == Definiciones.Estado.Inactivo)
                    excepciones.Agregar("El segundo garante está inactivo.", null);
                if (PersonasService.EstaBloqueado(this.PersonaGarante2Id.Value))
                    excepciones.Agregar("El segundo garante está bloqueado", null);
            }

            //Si no tiene separacion de bienes, y tiene una persona asociada como conyuge
            //se controla que el conyuge no este en judicial ni informconf
            if (this.Persona.EnInformconf == Definiciones.SiNo.Si)
                excepciones.Agregar(Traducciones.La_persona_esta_en_informconf, null);
            if (this.Persona.EnJudicial == Definiciones.SiNo.Si)
                excepciones.Agregar(Traducciones.La_persona_esta_en_judicial, null);
            if (this.SeparacionBienes == Definiciones.SiNo.No && this.Persona.PersonaIdConyuge.HasValue)
            {
                if (this.Persona.PersonaConyuge.Estado == Definiciones.Estado.Inactivo)
                    excepciones.Agregar("El cónyuge está inactivo.", null);
                if (PersonasService.EstaBloqueado(this.Persona.PersonaConyuge.Id.Value))
                    excepciones.Agregar("El cónyuge está bloqueado", null);
                if (this.Persona.PersonaConyuge.EnInformconf == Definiciones.SiNo.Si)
                    excepciones.Agregar("El cónyuge está en Informconf.", null);
                if (this.Persona.PersonaConyuge.EnJudicial == Definiciones.SiNo.Si)
                    excepciones.Agregar("El cónyuge está en judicial.", null);
            }

            this.ValidarNroComprobante(excepciones, sesion);

            //Validar que el articulo financiero esta disponible en la fecha de solicitud
            if (this.ArticuloId.HasValue && !this.rowSinModificar.IsARTICULO_IDNull && this.ArticuloId.Value != this.rowSinModificar.ARTICULO_ID)
            {
                var af = this.GetPrimero<ArticulosFinancierosService>(new Filtro { Columna = ArticulosFinancierosService.Modelo.ARTICULO_IDColumnName, Valor = this.ArticuloId.Value });
                if (af.FechaDesde.HasValue && af.FechaDesde.Value.Date > this.FechaSolicitud.Date)
                    excepciones.Agregar("El artículo financiero es válido desde el " + af.FechaDesde.Value.ToShortDateString() + ".", null);
                if (af.FechaHasta.HasValue && af.FechaHasta.Value.Date < this.FechaSolicitud.Date)
                    excepciones.Agregar("El artículo financiero fue válido hasta el " + af.FechaHasta.Value.ToShortDateString() + ".", null);
            }

            if (this.Aprobacion1UsuarioId == this.Aprobacion2UsuarioId && this.Aprobacion1UsuarioId.HasValue)
                excepciones.Agregar("El usuario " + this.Aprobacion1Usuario.Usuario + " no puede aprobar más de una vez.");
            if (this.Aprobacion1UsuarioId == this.Aprobacion3UsuarioId && this.Aprobacion1UsuarioId.HasValue)
                excepciones.Agregar("El usuario " + this.Aprobacion1Usuario.Usuario + " no puede aprobar más de una vez.");
            if (this.Aprobacion2UsuarioId == this.Aprobacion3UsuarioId && this.Aprobacion2UsuarioId.HasValue)
                excepciones.Agregar("El usuario " + this.Aprobacion1Usuario.Usuario + " no puede aprobar más de una vez.");
            
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }

        private void ValidarNroComprobante(CBA.FlowV2.Services.Base.Excepciones excepciones, SessionService sesion)
        {
            switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
            { 
                case Definiciones.Clientes.Apro:
                    ValidarNroComprobante_23(excepciones, sesion);
                    break;
            }
        }

        #region ValidarNroComprobante por cliente
        private void ValidarNroComprobante_23(CBA.FlowV2.Services.Base.Excepciones excepciones, SessionService sesion)
        {
            //El nro comprobante debe ser unico por garante 1, si está definido
            if (this.NroComprobante.Length <= 0)
                return;

            var lFiltros = new List<Filtro>();
            lFiltros.Add(new Filtro() { Columna = Modelo.NRO_COMPROBANTEColumnName, Valor = this.NroComprobante });

            if (this.PersonaGarante1Id.HasValue)
            {
                if (this.PersonaId != this.PersonaGarante1Id.Value)
                    lFiltros.Add(new Filtro() { Columna = Modelo.PERSONA_GARANTE1_IDColumnName, Valor = this.PersonaGarante1Id });
                else
                    lFiltros.Add(new Filtro() { Columna = FiltroExtension.PersonaDeudoraOGaranteId, Valor = this.Persona.Id });
            }
            else
            {
                lFiltros.Add(new Filtro() { Columna = Modelo.PERSONA_GARANTE1_IDColumnName, Comparacion = "is", Valor = "null" });
            }
                
            if (this.CasoId.HasValue)
                lFiltros.Add(new Filtro() { Columna = Modelo.CASO_IDColumnName, Comparacion = "<>", Valor = this.CasoId.Value });

            var creditosMismoNro = this.GetFiltrado<CreditosService>(lFiltros);
            if (creditosMismoNro.Length > 0)
                excepciones.Agregar("La OC " + this.NroComprobante + " ya existe, caso " + creditosMismoNro[0].CasoId.Value.ToString("#") + ".");
        }
        #endregion ValidarNroComprobante por cliente

        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._aprobacion_1_usuario = null;
            this._aprobacion_2_usuario = null;
            this._aprobacion_3_usuario = null; 
            this._articulo = null;
            this._articulo_financiero = null;
            this._activo = null;
            this._canal_venta = null;
            this._caso = null;
            this._funcionario = null;
            this._moneda = null;
            this._persona = null;
            this._persona_garante1 = null;
            this._persona_garante2 = null;
            this._sucursal = null;
            
            this._calendario = null;
            this._detalles_egreso = null;
            this._detalles_ingreso = null;
            this._descuentos = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Borrar
        public void Borrar()
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    this.IniciarUsingSesion(sesion);
                    Borrar(sesion);
                    this.FinalizarUsingSesion();
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public void Borrar(SessionService sesion)
        {
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();

            this.Caso.Estado = Definiciones.Estado.Inactivo;
            this.Caso.Guardar(sesion);
        }
        #endregion Borrar

        #region BorrarDetalle
        public void BorrarDetalle(CreditosDetallesService credito_detalle)
        {
            if (credito_detalle.TipoTextoPredefinidoId == Definiciones.TipoTextoPredefinido.CreditosTiposEgreso)
            {
                this.TotalIngresos -= credito_detalle.Monto;
                this._detalles_ingreso = null;
            }
            else
            {
                this.TotalEgresos -= credito_detalle.Monto;
                this._detalles_egreso = null;
            }

            credito_detalle.Borrar();
        }
        #endregion BorrarDetalle

        #region CrearDetalle
        public void CrearDetalle(CreditosDetallesService credito_detalle)
        {
            credito_detalle.CreditoId = this.Id.Value;
            credito_detalle.Guardar();

            if (credito_detalle.TipoTextoPredefinidoId == Definiciones.TipoTextoPredefinido.CreditosTiposEgreso)
            {
                this.TotalIngresos += credito_detalle.Monto;
                this._detalles_ingreso = null;
            }
            else
            {
                this.TotalEgresos += credito_detalle.Monto;
                this._detalles_egreso = null;
            }
        }
        #endregion CrearDetalle

        #region GenerarOrdenDePago
        private void GenerarOrdenDePago()
        {
            OrdenesPagoService ordenPago = new OrdenesPagoService();
            OrdenesPagoDetalleService ordenPagoDetalle = new OrdenesPagoDetalleService();

            if (!this.CtacteCajaTesoreriaId.HasValue)
                throw new Exception("No existe una caja de tesorería seleccionada.");

            DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.ORDEN_DE_PAGO, this.SucursalId);
            if (dtAutonumeracion.Rows.Count <= 0)
                throw new Exception("No existe una autonumeración para el flujo Orden de Pago.");

            System.Collections.Hashtable campos = new System.Collections.Hashtable();
            campos.Add(OrdenesPagoService.Fecha_NombreCol, this.FechaSolicitud);
            campos.Add(OrdenesPagoService.AutonumeracionId_NombreCol, dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
            campos.Add(OrdenesPagoService.NroReciboBeneficiario_NombreCol, "A confirmar");
            campos.Add(OrdenesPagoService.NombreBeneficiario_NombreCol, this.Persona.NombreCompleto);
            campos.Add(OrdenesPagoService.Observacion_NombreCol, "Orden de pago generada por Crédito N°" + this.NroComprobante);
            campos.Add(OrdenesPagoService.ObservacionInterna_NombreCol, "Orden de pago generada por Crédito N°" + this.NroComprobante);
            campos.Add(OrdenesPagoService.OrdenPagoTipoId_NombreCol, Definiciones.TiposOrdenesPago.PagoAPersona);
            campos.Add(OrdenesPagoService.SucursalOrigenId_NombreCol, this.SucursalId);
            campos.Add(OrdenesPagoService.MonedaId_NombreCol, this.MonedaId);
            campos.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, this.CtacteCajaTesoreriaId.Value);
            campos.Add(OrdenesPagoService.PersonaId_NombreCol, this.PersonaId);
            campos.Add(OrdenesPagoService.CasoOriginarioId_NombreCol, this.CasoId.Value);
            //Guardar los datos
            decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
            string vCasoEstado = string.Empty;
            bool exito = OrdenesPagoService.Guardar(campos, true, ref vCasoId, ref vCasoEstado, this.sesion);
            DataTable dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.CasoId_NombreCol + " = " + vCasoId, string.Empty, this.sesion);

            System.Collections.Hashtable campos2 = new System.Collections.Hashtable();
            DataTable detalles = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + this.CasoId.Value + " and " + CuentaCorrientePersonasService.Debito_NombreCol + " > " + CuentaCorrientePersonasService.Credito_NombreCol, CuentaCorrientePersonasService.Id_NombreCol, this.sesion);
            foreach (DataRow dr in detalles.Rows)
            {
                campos2.Add(OrdenesPagoDetalleService.OrdenPagoId_NombreCol, dtOrdenPago.Rows[0][OrdenesPagoService.Id_NombreCol]);
                campos2.Add(OrdenesPagoDetalleService.CtactePersonaId_NombreCol, dr[CuentaCorrientePersonasService.Id_NombreCol]);
                campos2.Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, dr[CuentaCorrientePersonasService.MonedaId_NombreCol]);
                campos2.Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, dr[CuentaCorrientePersonasService.Debito_NombreCol]);
                campos2.Add(OrdenesPagoDetalleService.Observacion_NombreCol, "Detalle Generado por Crédito N°" + this.NroComprobante);
                campos2.Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, this.CasoId.Value);
                campos2.Add(OrdenesPagoDetalleService.FlujoReferidoId_NombreCol, this.Caso.FlujoId);
                //Guardar los datos
                OrdenesPagoDetalleService.Guardar(campos2, this.sesion);
            }

            this.OrdenesPagoId = (decimal)dtOrdenPago.Rows[0][OrdenesPagoService.Id_NombreCol];
            this.Guardar();
        }
        #endregion GenerarOrdenDePago

        #region GenerarEgresoVarioCaja
        private void GenerarEgresoVarioCaja()
        {
            decimal egresosVariosCajaId = Definiciones.Error.Valor.EnteroPositivo;
            decimal egresosVariosCajaCasoId = Definiciones.Error.Valor.EnteroPositivo;

            DataTable dtTalonarioRetencion = AutonumeracionesService.GetAutonumeracionesPorTabla2(CuentaCorrienteRetencionesEmitidasService.Nombre_Tabla, this.SucursalId);
            if (!(dtTalonarioRetencion.Rows.Count > 0))
                throw new Exception("No existe un talonario de retención activo.");

            //Si no hay un fondo fijo ni una caja de sucursal definida, intentar seleccionar una de sucursal
            if (!this.CtacteFondoFijoId.HasValue && !this.CtacteCajaSucursalId.HasValue)
            {
                this.CtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, this.FuncionarioId);
                if (this.CtacteCajaSucursalId.Value == Definiciones.Error.Valor.EnteroPositivo && !sesion.Usuario.IsFUNCIONARIO_IDNull)
                    this.CtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, sesion.Usuario.FUNCIONARIO_ID);
                if (this.CtacteCajaSucursalId.Value == Definiciones.Error.Valor.EnteroPositivo)
                    throw new Exception("No se encontró una caja abierta en la sucursal " + this.Sucursal.Nombre + " para el funcionario " + this.Funcionario.Nombre + " " + this.Funcionario.Apellido + ".");
            }

            if (!this.CtacteFondoFijoId.HasValue && !this.CtacteCajaSucursalId.HasValue)
                throw new Exception("Debe seleccionarse un fondo fijo o una caja de sucursal.");

            DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.EGRESO_VARIO_CAJA, this.SucursalId);
            if(dtAutonumeracion.Rows.Count <= 0)
                throw new Exception("No existe una autonumeración para el flujo Egreso Vario Caja.");

            DataTable dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + this.CasoId.Value + " and " + CuentaCorrientePersonasService.Debito_NombreCol + " > " + CuentaCorrientePersonasService.Credito_NombreCol, CuentaCorrientePersonasService.Id_NombreCol, this.sesion);
            decimal monto = (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol] - (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol];

            EgresosVariosCajaService.CrearCabecera(this.CtacteFondoFijoId, this.CtacteCajaSucursalId, this.SucursalId, (decimal)dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol], this.MonedaId, this.Cotizacion, monto, DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"), string.Empty, this.Persona.NombreCompleto, string.Empty, string.Empty, false, Definiciones.SiNo.No, (decimal)dtTalonarioRetencion.Rows[0][AutonumeracionesService.Id_NombreCol], ref egresosVariosCajaId, ref egresosVariosCajaCasoId, this.sesion);
            EgresosVariosCajaDetalleService.CrearDetallePersona(egresosVariosCajaId, (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], this.MonedaId, this.Cotizacion, monto, monto, string.Empty, this.PersonaId, this.sesion);

            this.EgresoVarioCajaId = egresosVariosCajaId;
            this.Guardar();
        }
        #endregion GenerarEgresoVarioCaja

        #region CrearPagareGarantia
        public void CrearPagareGarantia()
        {
            DateTime vencimiento = DateTime.Now;

            if (this.Calendario.Length > 0)
                vencimiento = this.Calendario[0].FechaVencimiento;

            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    CuentaCorrientePagaresService.CrearPagareGarantia(this.CasoId.Value, this.MonedaId, this.Cotizacion, this.MontoTotal, vencimiento, this.PersonaId,
                                                              this.PersonaGarante1Id.HasValue ? this.PersonaGarante1Id.Value : Definiciones.Error.Valor.EnteroPositivo,
                                                              this.PersonaGarante2Id.HasValue ? this.PersonaGarante2Id.Value : Definiciones.Error.Valor.EnteroPositivo,
                                                              Definiciones.Error.Valor.EnteroPositivo,
                                                              sesion);
                }
            }
            else
            {
                CuentaCorrientePagaresService.CrearPagareGarantia(this.CasoId.Value, this.MonedaId, this.Cotizacion, this.MontoTotal, vencimiento, this.PersonaId,
                                                                  this.PersonaGarante1Id.HasValue ? this.PersonaGarante1Id.Value : Definiciones.Error.Valor.EnteroPositivo,
                                                                  this.PersonaGarante2Id.HasValue ? this.PersonaGarante2Id.Value : Definiciones.Error.Valor.EnteroPositivo,
                                                                  Definiciones.Error.Valor.EnteroPositivo,
                                                                  this.sesion);
            }
        }
        #endregion CrearPagareGarantia

        #region CrearFacturaComoComprobante
        private decimal CrearFacturaComoComprobante(decimal ctacte_caja_sucursal_id, Hashtable[] hashtableDetalles, decimal[] cuotas_devengadas_anticipadamente)
        {
            //Objetos para crear la factura y los detalles
            CasosService casoService = new CasosService();
            FacturasClienteService facturaClienteService = new FacturasClienteService();
            DataTable dtCtacteCajaSucursal = CuentaCorrienteCajasSucursalService.GetCuentaCorrienteCajasSucursalDataTable2(CuentaCorrienteCajasSucursalService.Id_NombreCol + " = " + ctacte_caja_sucursal_id, string.Empty, this.sesion);
            System.Collections.Hashtable campos;
            string casoFacturaEstado = string.Empty, mensaje;
            decimal casoFacturaId = Definiciones.Error.Valor.EnteroPositivo;
            bool exito;

            DataTable dtLote;
            DataTable dtArticulo;
            DataTable dtFacturaCreada;
            decimal montoTotal;

            DateTime fechaPrimerVencimiento = DateTime.Now, fechaSegundoVencimiento = DateTime.MinValue;
            bool usarFechaPrimerVencimiento = false, usarFechaSegundoVencimiento = false;

            if (!this.FacturaClienteAutonId.HasValue)
                throw new Exception("Debe indicar el talonario para la Factura.");

            #region Crear cabecera FC
            campos = new System.Collections.Hashtable();
            campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, this.FacturaClienteAutonId.Value);
            if (this.CanalVentaId.HasValue)
                campos.Add(FacturasClienteService.CanalVentaId_NombreCol, this.CanalVentaId.Value); 
            campos.Add(FacturasClienteService.CasoOrigenId_NombreCol, this.CasoId.Value);
            campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
            campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CondicionPagoCredito, this.sesion));
            campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, this.Cotizacion);
            campos.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
            campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, DateTime.Now);
            campos.Add(FacturasClienteService.Fecha_NombreCol, DateTime.Now);
            campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, this.MonedaId);
            campos.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
            campos.Add(FacturasClienteService.Observacion_NombreCol, "Factura creada por mora de Cancelación Anticipada caso Nº" + this.CasoId.Value);
            campos.Add(FacturasClienteService.PersonaId_NombreCol, this.PersonaId);
            campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, (decimal)0);
            campos.Add(FacturasClienteService.SucursalId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol]);
            campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, Definiciones.TipoFactura.Credito);
            campos.Add(FacturasClienteService.VendedorId_NombreCol, dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.FuncionarioId_NombreCol]);
            campos.Add(FacturasClienteService.CtaCteCajaSucursalId_NombreCol, ctacte_caja_sucursal_id);
            #region Obtener el primer deposito activo de la sucursal
            
            DataTable dtStockDepositoAux = Stock.StockDepositosService.GetStockDepositosDataTable(this.SucursalId, true, true);
            if (dtStockDepositoAux.Rows.Count <= 0)
                throw new Exception("La sucursal debe tener al menos un depósito en el cual se pueda facturar.");
            campos.Add(FacturasClienteService.DepositoId_NombreCol, dtStockDepositoAux.Rows[0][Stock.StockDepositosService.Id_NombreCol]);
            #endregion Obtener el primer deposito activo de la sucursal
            campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, (decimal)0);

            FacturasClienteService.Guardar(campos, true, ref casoFacturaId, ref casoFacturaEstado, sesion);
            #endregion Crear cabecera FC

            if (casoFacturaId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                return Definiciones.Error.Valor.EnteroPositivo;

            dtFacturaCreada = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoId_NombreCol + " = " + casoFacturaId, string.Empty, sesion);

            for (int i = 0; i < hashtableDetalles.Length; i++)
            {
                dtArticulo = ArticulosService.GetArticulosDataTable(Articulos.ArticulosService.Id_NombreCol + " = " + hashtableDetalles[i][FacturasClienteDetalleService.ArticuloId_NombreCol], string.Empty, false, (decimal)dtCtacteCajaSucursal.Rows[0][CuentaCorrienteCajasSucursalService.SucursalId_NombreCol]);
                dtLote = Articulos.ArticulosLotesService.GetArticulosLotesInfoCompleta2((decimal)dtArticulo.Rows[0][Articulos.ArticulosService.Id_NombreCol], string.Empty);

                if (dtLote.Rows.Count <= 0)
                    throw new Exception("No existe ningún lote para el artículo " + dtArticulo.Rows[0][Articulos.ArticulosService.Id_NombreCol] + " definido en la variable de sistema.");

                #region Agregar detalle
                campos = new System.Collections.Hashtable();
                campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, dtArticulo.Rows[0][Articulos.ArticulosService.Id_NombreCol]);
                campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtLote.Rows[0][Articulos.ArticulosLotesService.Id_NombreCol]);
                campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, dtArticulo.Rows[0][Articulos.ArticulosService.UnidadMedidaId_NombreCol]);
                campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, dtArticulo.Rows[0][Articulos.ArticulosService.ImpuestoId_NombreCol]);
                campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, hashtableDetalles[i][FacturasClienteDetalleService.TotalNeto_NombreCol]);
                campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, hashtableDetalles[i][FacturasClienteDetalleService.Observacion_NombreCol]);

                if (hashtableDetalles[i].Contains(FacturasClienteDetalleService.CtacteRecargoId_NombreCol))
                    campos.Add(FacturasClienteDetalleService.CtacteRecargoId_NombreCol, hashtableDetalles[i][FacturasClienteDetalleService.CtacteRecargoId_NombreCol]);

                FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, sesion);
                #endregion Agregar detalle por pago capital
            }

            montoTotal = 0;
            for (int i = 0; i < hashtableDetalles.Length; i++)
                montoTotal += (decimal)hashtableDetalles[i][FacturasClienteDetalleService.TotalNeto_NombreCol];

            //Crear calendario de pagos
            CalendarioPagosFCClienteService.CrearCuotas((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol],
                                                        montoTotal,
                                                        (DateTime)dtFacturaCreada.Rows[0][FacturasClienteService.Fecha_NombreCol],
                                                        fechaPrimerVencimiento,
                                                        usarFechaPrimerVencimiento,
                                                        fechaSegundoVencimiento,
                                                        usarFechaSegundoVencimiento,
                                                        sesion);

            #region Aprobar el caso de FC Cliente
            //Pasar a Pendiente
            exito = facturaClienteService.ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
            if (exito)
                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, "Transición automática.", sesion);
            if (exito)
                facturaClienteService.EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, sesion);
            if (!exito)
                throw new Exception(mensaje);

            //Pasar a Caja
            exito = facturaClienteService.ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, false, out mensaje, sesion);
            if (exito)
                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, "Transición automática.", sesion);
            if (exito)
                facturaClienteService.EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, sesion);
            if (!exito)
                throw new Exception(mensaje);

            //Pasar a Cerrado
            exito = facturaClienteService.ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
            if (exito)
                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, "Transición automática.", sesion);
            if (exito)
                facturaClienteService.EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, sesion);
            if (!exito)
                throw new Exception(mensaje);
            #endregion Aprobar el caso de FC Cliente

            //Asociar el caso de factura a la cuota para indicar que el devengamiento ya fue facturado
            //Si queda un saldo en intereses a devengar, tuvo que haberse descontado.
            for (int i = 0; i < cuotas_devengadas_anticipadamente.Length; i++)
            {
                var c = new CreditosService.CalendarioService(cuotas_devengadas_anticipadamente[i], sesion);
                if (c.CasoAsociadoId.HasValue)
                    throw new Exception("El devengamiento anticipado de la cuota ya había sido facturado.");
                c.IniciarUsingSesion(sesion);
                c.CasoAsociadoId = casoFacturaId;
                c.Guardar();
                c.FinalizarUsingSesion();
            }

            return (decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol];
        }
        #endregion CrearFacturaComoComprobante

        #region Actualizar Monto Pagaré Garantía
        private void ActualizarMontoPagareGarantia()
        {
            string clausula = CuentaCorrientePagaresService.CasoGarantiaId_NombreCol + " = " + this.CasoId.Value;

            DataTable dt = CuentaCorrientePagaresService.GetCuentaCorrientePagaresDataTable(clausula, string.Empty, this.sesion);

            if (dt.Rows.Count > 0)
                CuentaCorrientePagaresService.ActualizarTotal((decimal)dt.Rows[0][CuentaCorrientePagaresService.Id_NombreCol], this.MontoTotal, true, this.sesion);
        }
        #endregion Actualizar Monto Pagaré Garantía

        #region ConsultarNumeroDocumentoExterno
        public bool ConsultarNumeroDocumentoExterno(out string mensaje, SessionService sesion)
        {
            try
            {
                bool exito = true;
                mensaje = string.Empty;

               

                return exito;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion GetConsultarNumeroDocumentoExterno

        #region ActualizarNumeroDocumentoExterno
        public void ActualizarNumeroDocumentoExterno(out string mensaje, SessionService sesion)
        {
            try
            {
                mensaje = string.Empty;

               
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion ActualizarNumeroDocumentoExterno

        #region CrearAnticipoPersona
        private decimal CrearAnticipoPersona(CreditosDescuentosService descuento)
        {
            if (!this.CtacteCajaSucursalId.HasValue)
                this.CtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, this.FuncionarioId);
            if (this.CtacteCajaSucursalId.Value == Definiciones.Error.Valor.EnteroPositivo && !sesion.Usuario.IsFUNCIONARIO_IDNull)
                this.CtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(this.SucursalId, sesion.Usuario.FUNCIONARIO_ID);
            if (this.CtacteCajaSucursalId.Value == Definiciones.Error.Valor.EnteroPositivo)
                throw new Exception("No se encontró una caja abierta en la sucursal " + this.Sucursal.Nombre + " para el funcionario " + this.Funcionario.Nombre + " " + this.Funcionario.Apellido + ".");

            decimal casoCreadoAnticipoId = Definiciones.Error.Valor.EnteroPositivo;
            decimal casoCreadoAnticipoCasoId = Definiciones.Error.Valor.EnteroPositivo;
            string casoCreadoAnticipoEstadoId = string.Empty, mensajeAnticipo = string.Empty;
            bool exitoAnticipo;

            DataTable dtAutonumeracionAnticipo = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.ANTICIPO_PERSONA, this.SucursalId, this.sesion);
            if (dtAutonumeracionAnticipo.Rows.Count <= 0)
                throw new Exception("No se encontró una autonumeración para el Anticipo en la sucursal " + this.Sucursal.Nombre + ".");

            // Se crea la cabecera del anticipo
            Hashtable camposCasoAnticipo = new Hashtable();
            camposCasoAnticipo.Add(AnticiposPersonaService.SucursalId_NombreCol, this.SucursalId);
            camposCasoAnticipo.Add(AnticiposPersonaService.PersonaId_NombreCol, descuento.PersonaId);
            camposCasoAnticipo.Add(AnticiposPersonaService.Fecha_NombreCol, DateTime.Now);
            camposCasoAnticipo.Add(AnticiposPersonaService.FuncionarioCobradorId_NombreCol, this.FuncionarioId);
            camposCasoAnticipo.Add(AnticiposPersonaService.AutonmeracionReciboId_NombreCol, dtAutonumeracionAnticipo.Rows[0][AutonumeracionesService.Id_NombreCol]);
            camposCasoAnticipo.Add(AnticiposPersonaService.MonedaId_NombreCol, descuento.MonedaId);
            camposCasoAnticipo.Add(AnticiposPersonaService.CotizacionMoneda_NombreCol, descuento.Cotizacion);
            camposCasoAnticipo.Add(AnticiposPersonaService.MontoTotal_NombreCol, descuento.Monto);
            camposCasoAnticipo.Add(AnticiposPersonaService.SaldoPorAplicar_NombreCol, descuento.Monto);
            camposCasoAnticipo.Add(AnticiposPersonaService.Observacion_NombreCol, descuento.Observacion + ". Caso creador " + this.CasoId + ".");
            AnticiposPersonaService.Guardar(camposCasoAnticipo, true, ref casoCreadoAnticipoCasoId, ref casoCreadoAnticipoEstadoId, ref casoCreadoAnticipoId, this.sesion);
            DataTable dtCasoAnticipo = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + casoCreadoAnticipoId, string.Empty, this.sesion);

            // Se crea el detalle del anticipo
            Hashtable camposDetalleAnticipo = new Hashtable();
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol, dtCasoAnticipo.Rows[0][AnticiposPersonaService.Id_NombreCol]);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.MonedaId_NombreCol, descuento.MonedaId);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol, descuento.Cotizacion);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.Monto_NombreCol, descuento.Monto);
            (new AnticiposPersonaDetalleService()).Guardar(camposDetalleAnticipo, this.sesion);

            //Se avanza el caso hasta aprobado
            AnticiposPersonaService anticipoPersona = new AnticiposPersonaService();
            CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();

            //Se reutiliza la pasarela de campos
            anticipoPersona.pasarelaCambioEstadoCampos = this.pasarelaCambioEstadoCampos;

            exitoAnticipo = anticipoPersona.ProcesarCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Pendiente, false, out mensajeAnticipo, this.sesion);
            if (exitoAnticipo)
                exitoAnticipo = ToolbarFlujo.ProcesarCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática por descuento de Crédito a Persona.", this.sesion);
            if (exitoAnticipo)
                anticipoPersona.EjecutarAccionesLuegoDeCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Pendiente, this.sesion);
            if (!exitoAnticipo)
                throw new Exception("Error en CreditosService.ProcesarCambioEstado al pasar el anticipo creado como descuento a pendiente. " + mensajeAnticipo + ".");

            exitoAnticipo = anticipoPersona.ProcesarCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Aprobado, false, out mensajeAnticipo, this.sesion);
            if (exitoAnticipo)
                exitoAnticipo = ToolbarFlujo.ProcesarCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Aprobado, "Transición automática por descuento de Crédito a Persona.", this.sesion);
            if (exitoAnticipo)
                anticipoPersona.EjecutarAccionesLuegoDeCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Aprobado, this.sesion);
            if (!exitoAnticipo)
                throw new Exception("Error en CreditosService.ProcesarCambioEstado al pasar el anticipo creado como descuento a aprobado. " + mensajeAnticipo + ".");

            return casoCreadoAnticipoId;
        }
        #endregion CrearAnticipoPersona

        #region CrearRefinanciacion
        public decimal CrearRefinanciacion()
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    this.IniciarUsingSesion(sesion);
                    sesion.BeginTransaction();
                    
                    decimal casoId = this.CrearRefinanciacion(sesion);

                    sesion.CommitTransaction();
                    this.FinalizarUsingSesion();
                    return casoId;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    this.FinalizarUsingSesion();
                    throw;
                }
            }
        }
        
        public decimal CrearRefinanciacion(SessionService sesion)
        {
            /*
             * Pasos:
             *      Pasar el crédito de EnRevisión a Vigente para preparar las cuotas de cancelación.
             *      Si el paso a Vigente creó una nota de crédito, crear un caso de Aplicación de Documentos
             *          donde se incluyan los documentos del crédito a ser cancelado por el monto y la NC como valor.
             *      Crear un nuevo caso de crédito con el artículo financiero de refinanciación. 
             *          El capital debe ser el capital adeudado del crédito anterior más 
             *          los intereses devengados. Dicho monto, más el pago de personas, 
             *          deben dar por finiquitado el crédito anterior.
             */
            if (this.Caso.EstadoId != Definiciones.EstadosFlujos.EnRevision)
                throw new Exception("El caso debe estar en En-Revisión");

            if (!this.ArticuloId.HasValue || !this.ArticuloFinanciero.ArticuloRefinanciacionId.HasValue)
                throw new Exception("No se encontró el artículo financiero de refinanciación.");

            decimal casoRefinanciacionId = Definiciones.Error.Valor.EnteroPositivo;
            
            var comentario = new ToolbarFlujoService.ComentarioTransicion();
            comentario.texto = "Transición automática por refinanciación.";

            this.ProcesarCambioEstado(Definiciones.EstadosFlujos.Vigente, true, comentario, sesion);

            if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CreditosPersonaCancelacionCrearNotaCreditoPorDescuento) == Definiciones.SiNo.Si)
            {
                //La FC sobre la que se hizo la NC en el paso a Vigente, debió ser la más antigua que tenga como caso asociado al crédito
                //en estado Cerrado (no quedó en Caja por no afectar ctacte)
                var dtFacturaCliente = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoOrigenId_NombreCol + " = " + this.CasoId + " and " + FacturasClienteService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Cerrado + "'", FacturasClienteService.Id_NombreCol, sesion);
                if (dtFacturaCliente.Rows.Count <= 0)
                    throw new Exception("No se encontró una factura sobre la cual se haya hecho la nota de crédito por intereses no devengados.");

                DataTable dtNotasCreditoDetalle = NotasCreditoPersonaDetalleService.GetNotaCreditoPersonaDetalleDataTable(NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol + " = " + dtFacturaCliente.Rows[0][FacturasClienteService.Id_NombreCol], NotasCreditoPersonaDetalleService.Id_NombreCol + " desc", sesion);
                if (dtNotasCreditoDetalle.Rows.Count <= 0)
                    throw new Exception("No se encontró la nota de crédito por intereses no devengados.");
                var notaCreditoCliente = new NotasCreditoPersonaService((decimal)dtNotasCreditoDetalle.Rows[0][NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol], sesion);

                var lAplicacionCtactePersonas = new List<decimal>();
                var lCreditoCtactePersonas = new List<decimal>();
                var lAplicacionMontos = new List<decimal>();
                var lCreditoMontos = new List<decimal>();
                
                decimal saldoNC = notaCreditoCliente.Saldo;
                for (int i = 0; i < this.CtactePersonasCancelacion.Length; i++)
                {
                    decimal monto = this.CtactePersonasCancelacion[i].Credito - this.CtactePersonasCancelacion[i].Debito;
                    decimal montoAplicado = 0;

                    if (saldoNC > 0)
                    {
                        montoAplicado = Math.Min(monto, saldoNC);
                        lAplicacionCtactePersonas.Add(this.CtactePersonasCancelacion[i].Id.Value);
                        lAplicacionMontos.Add(montoAplicado);
                        saldoNC -= montoAplicado;
                    }

                    if (saldoNC <= 0)
                    {
                        lCreditoCtactePersonas.Add(this.CtactePersonasCancelacion[i].Id.Value);
                        lCreditoMontos.Add(monto - montoAplicado);
                    }
                }

                #region Aplicacion Documentos
                decimal casoCreadoAplicacionId = Definiciones.Error.Valor.EnteroPositivo;
                string casoCreadoAplicacionEstadoId = string.Empty, mensajeAplicacion = string.Empty;
                decimal casoCreadoCtacteCajaSucursalId = Definiciones.Error.Valor.EnteroPositivo;
                bool exitoAplicacion;

                DataTable dtAutonumeracionAplicacion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(CBA.FlowV2.Services.Base.Definiciones.FlujosIDs.APLICACION_DOCUMENTOS, notaCreditoCliente.SucursalId);
                if (dtAutonumeracionAplicacion.Rows.Count <= 0)
                    throw new Exception("No se encontró un talonario para Aplicación de Documentos en la sucursal " + notaCreditoCliente.Sucursal.Nombre + ".");

                casoCreadoCtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(notaCreditoCliente.SucursalId, notaCreditoCliente.FuncionarioCobradorId);
                if (casoCreadoCtacteCajaSucursalId == Definiciones.Error.Valor.EnteroPositivo && !sesion.Usuario.IsFUNCIONARIO_IDNull)
                    casoCreadoCtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(notaCreditoCliente.SucursalId, sesion.Usuario.FUNCIONARIO_ID);
                if (casoCreadoCtacteCajaSucursalId == Definiciones.Error.Valor.EnteroPositivo)
                    casoCreadoCtacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(notaCreditoCliente.SucursalId, null);
                if (casoCreadoCtacteCajaSucursalId == Definiciones.Error.Valor.EnteroPositivo)
                	throw new Exception("No se encontró una caja abierta en la sucursal " + notaCreditoCliente.Sucursal.Nombre + " para el funcionario " + notaCreditoCliente.FuncionarioCobrador.Nombre + " " + notaCreditoCliente.FuncionarioCobrador.Apellido + ".");

                #region crear cabecera
                casoCreadoAplicacionId = Definiciones.Error.Valor.EnteroPositivo;
                Hashtable camposAplicacion = new Hashtable();
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol, notaCreditoCliente.SucursalId);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.UsuarioId_NombreCol, sesion.Usuario.ID);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol, this.PersonaId);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.PersonaValoresId_NombreCol, this.PersonaId);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol, notaCreditoCliente.FuncionarioCobradorId);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.CtacteCajaSucursalId_NombreCol, casoCreadoCtacteCajaSucursalId);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol, this.MonedaId);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.Fecha_NombreCol, DateTime.Now);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.Cotizacion_NombreCol, this.Cotizacion);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.AutonumeracionId_NombreCol, dtAutonumeracionAplicacion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.ConsolidacionDeuda_NombreCol, Definiciones.SiNo.No);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol, notaCreditoCliente.Saldo);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.TotalValores_NombreCol, notaCreditoCliente.Saldo);
                camposAplicacion.Add(NotasCreditoPersonaAplicacionesService.Observacion_NombreCol, string.Empty);
                NotasCreditoPersonaAplicacionesService.Guardar(camposAplicacion, true, ref casoCreadoAplicacionId, ref casoCreadoAplicacionEstadoId, this.sesion);
                DataTable dtAplicacionDocumento = NotasCreditoPersonaAplicacionesService.GetNotaCreditoPersonaAplicacionPorCaso(casoCreadoAplicacionId, sesion);
                #endregion crear cabecera

                #region agregar valores
                DataTable dtCtacteNotaCredito = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + notaCreditoCliente.CasoId + " and " + CuentaCorrientePersonasService.Debito_NombreCol + " > " + CuentaCorrientePersonasService.Credito_NombreCol, CuentaCorrientePersonasService.Id_NombreCol, this.sesion);

                Hashtable camposValores = new Hashtable();
                camposValores.Add(NotasCreditoPersonaAplicacionValoresService.CtaCtePersonaId_NombreCol, (decimal)dtCtacteNotaCredito.Rows[0][CuentaCorrientePersonasService.Id_NombreCol]);
                camposValores.Add(NotasCreditoPersonaAplicacionValoresService.Tipo_NombreCol, Definiciones.TipoComprobanteAplicable.Persona);
                camposValores.Add(NotasCreditoPersonaAplicacionValoresService.MontoDestino_NombreCol, notaCreditoCliente.Saldo);
                camposValores.Add(NotasCreditoPersonaAplicacionValoresService.MontoOrigen_NombreCol, notaCreditoCliente.Saldo);
                camposValores.Add(NotasCreditoPersonaAplicacionValoresService.Cotizacion_NombreCol, this.Cotizacion);
                camposValores.Add(NotasCreditoPersonaAplicacionValoresService.MonedaId_NombreCol, this.MonedaId);
                camposValores.Add(NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol, dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol]);
                NotasCreditoPersonaAplicacionValoresService.Guardar(camposValores, sesion);
                #endregion agregar cabecera

                for (int i = 0; i < lAplicacionCtactePersonas.Count; i++)
                {
                    Hashtable camposDocumentos = new Hashtable();
                    camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol, dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol]);
                    camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol, lAplicacionCtactePersonas[i]);
                    camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol, this.MonedaId);
                    camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol, this.Cotizacion);
                    camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoOrigen_NombreCol, lAplicacionMontos[i]);
                    camposDocumentos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol, lAplicacionMontos[i]);
                    NotasCreditoPersonaAplicacionDocumentosService.Guardar(camposDocumentos, this.sesion);
                }

                exitoAplicacion = (new NotasCreditoPersonaAplicacionesService()).ProcesarCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Pendiente, false, out mensajeAplicacion, this.sesion);
                if (exitoAplicacion)
                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Pendiente, "Transición automática por refinanciación de Crédito Persona.", sesion);
                if (exitoAplicacion)
                    (new NotasCreditoPersonaAplicacionesService()).EjecutarAccionesLuegoDeCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Pendiente, this.sesion);

                exitoAplicacion = (new NotasCreditoPersonaAplicacionesService()).ProcesarCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Aprobado, false, out mensajeAplicacion, this.sesion);
                if (exitoAplicacion)
                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Aprobado, "Transición automática por refinanciación de Crédito Persona.", sesion);
                if (exitoAplicacion)
                    (new NotasCreditoPersonaAplicacionesService()).EjecutarAccionesLuegoDeCambioEstado(casoCreadoAplicacionId, Definiciones.EstadosFlujos.Aprobado, this.sesion);
                #endregion Aplicacion Documentos

                #region Credito refinanciacion
                #region campos cabecera
                var creditoRefinanciacion = new CreditosService();
                creditoRefinanciacion.IniciarUsingSesion(sesion);

                creditoRefinanciacion.SucursalId = notaCreditoCliente.SucursalId;

                //Por el momento se toma el primer talonario activo para el flujo y sucursal
                var dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.CREDITOS, creditoRefinanciacion.SucursalId, AutonumeracionesService.Id_NombreCol, sesion);
                if (dtAutonumeracion.Rows.Count <= 0)
                    throw new Exception("No existe una autonumeración para el flujo Créditos en la sucursal " + creditoRefinanciacion.Sucursal.Nombre + ".");
                creditoRefinanciacion.AutonumeracionId = (decimal)dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol];

                creditoRefinanciacion.PersonaId = this.PersonaId;
                creditoRefinanciacion.SeparacionBienes = this.SeparacionBienes;
                creditoRefinanciacion.ActivoId = this.ActivoId;
                creditoRefinanciacion.ArticuloId = this.ArticuloFinanciero.ArticuloRefinanciacionId;
                creditoRefinanciacion.CanalVentaId = this.CanalVentaId;
                creditoRefinanciacion.FuncionarioId = this.FuncionarioId;
                creditoRefinanciacion.FechaSolicitud = DateTime.Now;

                var nroSolicitud = this.GetPasarelaCambioEstadoCampo(CreditosService.Modelo.NUMERO_SOLICITUDColumnName);
                if(nroSolicitud != null)
                    creditoRefinanciacion.NumeroSolicitud = (string)nroSolicitud.valor;

                creditoRefinanciacion.FechaRetiro = DateTime.Now;
                creditoRefinanciacion.Aprobacion1 = Definiciones.SiNo.No;
                creditoRefinanciacion.Aprobacion2 = Definiciones.SiNo.No;
                creditoRefinanciacion.Aprobacion3 = Definiciones.SiNo.No;
                creditoRefinanciacion.Observacion = "Refinanciación de Crédito " + this.NroComprobante + " " + Traducciones.Caso + " " + this.CasoId.Value;
                creditoRefinanciacion.ConRecurso = this.ConRecurso;
                creditoRefinanciacion.AfectaLineaCredito = this.AfectaLineaCredito;
                creditoRefinanciacion.DesembolsarParaCliente = this.DesembolsarParaCliente;

                var facturaClienteAutonumeracion = this.GetPasarelaCambioEstadoCampo(ValoresConstantes.CreditoFacturaAlDesembolsarCajaSucursal);
                if (facturaClienteAutonumeracion != null)
                    creditoRefinanciacion.FacturaClienteAutonId = (decimal)facturaClienteAutonumeracion.valor;
                
                creditoRefinanciacion.MonedaId = this.MonedaId;
                creditoRefinanciacion.Cotizacion = CotizacionesService.GetCotizacionMonedaCompra(creditoRefinanciacion.Sucursal.PaisId, creditoRefinanciacion.MonedaId, creditoRefinanciacion.FechaSolicitud);
                creditoRefinanciacion.TipoInteresAnual = creditoRefinanciacion.ArticuloFinanciero.TipoInteresAnual;
                creditoRefinanciacion.AnhoComercial = creditoRefinanciacion.ArticuloFinanciero.AnhoComercial;
                creditoRefinanciacion.AumentarCapitalPorDescuent = creditoRefinanciacion.ArticuloFinanciero.AumentarCapitalPorDescuent;

                var cantidadCuotas = this.GetPasarelaCambioEstadoCampo(CreditosService.Modelo.CANTIDAD_CUOTASColumnName);
                if (cantidadCuotas != null && (decimal)cantidadCuotas.valor > 0)
                    creditoRefinanciacion.CantidadCuotas = (decimal)cantidadCuotas.valor;
                else
                    creditoRefinanciacion.CantidadCuotas = creditoRefinanciacion.ArticuloFinanciero.CantidadCuotas;
                
                creditoRefinanciacion.MontoCapitalOrdenCompra = 0;
                creditoRefinanciacion.MontoCapitalSolicitado = 0;
                creditoRefinanciacion.MontoCapitalAprobado = 0;
                creditoRefinanciacion.EntregaInicial = 0;
                creditoRefinanciacion.MontoDiarioMora = 0;
                creditoRefinanciacion.PorcentajeDiarioMora = null;

                creditoRefinanciacion.MontoTotal = 0;
                creditoRefinanciacion.MontoRedondeo = creditoRefinanciacion.ArticuloFinanciero.MontoRedondeo;
                creditoRefinanciacion.TipoCreditoId = creditoRefinanciacion.ArticuloFinanciero.TipoCreditoId;
                creditoRefinanciacion.InteresIncluyeImpuesto = creditoRefinanciacion.ArticuloFinanciero.InteresIncluyeImpuesto;
                creditoRefinanciacion.ConceptoIncluyeImpuesto = creditoRefinanciacion.ArticuloFinanciero.ConceptoIncluyeImpuesto;
                creditoRefinanciacion.BonificacionIncluyeImpuesto = creditoRefinanciacion.ArticuloFinanciero.BonificacionIncluyeImpuesto;
                creditoRefinanciacion.TipoFrecuencia = creditoRefinanciacion.ArticuloFinanciero.TipoFrecuencia;
                creditoRefinanciacion.Frecuencia = creditoRefinanciacion.ArticuloFinanciero.Frecuencia;
                creditoRefinanciacion.DiasGracia = 0;
                creditoRefinanciacion.DescuentoCancelacionAnticip = 0;
                
                creditoRefinanciacion.PorcentajeInteres = 0;
                creditoRefinanciacion.PorcentajeGastoAdminist = 0;
                creditoRefinanciacion.MontoGastoAdministrativo = null;
                creditoRefinanciacion.PorcentajeSeguro = 0;
                creditoRefinanciacion.MontoSeguro = null;
                creditoRefinanciacion.PorcentajeCorretaje = 0;
                creditoRefinanciacion.MontoCorretaje = null;
                creditoRefinanciacion.PorcentajeComisionAdmin = 0;
                creditoRefinanciacion.MontoComisionAdmin = null;
                creditoRefinanciacion.PorcentajeOtros = 0;
                creditoRefinanciacion.MontoOtros = null;
                creditoRefinanciacion.PorcentajeBonificacion = 0;
                creditoRefinanciacion.MontoBonificacion = null;
                creditoRefinanciacion.FacturarCapital = creditoRefinanciacion.ArticuloFinanciero.FacturarCapital;
                creditoRefinanciacion.FacturarBonificacionEnPagos = creditoRefinanciacion.ArticuloFinanciero.FacturarBonificacionEnPagos;
                creditoRefinanciacion.FacturarIntereses = creditoRefinanciacion.ArticuloFinanciero.FacturarIntereses;
                creditoRefinanciacion.FacturarConceptosEnPagos = creditoRefinanciacion.ArticuloFinanciero.FacturarConceptosEnPagos;
                creditoRefinanciacion.CtacteCajaSucursalId = casoCreadoCtacteCajaSucursalId;
                creditoRefinanciacion.CtacteFondoFijoId = null;
                creditoRefinanciacion.CtacteCajaTesoreriaId = null;
                #endregion campos cabecera

                creditoRefinanciacion.FechaPrimerVencimiento = creditoRefinanciacion.FechaPrimerVencimientoSugerido;
                
                creditoRefinanciacion.MontoCapitalSolicitado = 0;
                for (int i = 0; i < lCreditoMontos.Count; i++)
			        creditoRefinanciacion.MontoCapitalSolicitado += lCreditoMontos[i];

                #region Inicializar valores relacionados a rangos
                int cantidadDias = creditoRefinanciacion.CantidadDias;
                ArticulosFinancierosRangosService rango;
                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.InteresCorriente, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                if (rango.Monto.HasValue)
                {
                    creditoRefinanciacion.MontoInteres = rango.Monto.Value;
                    creditoRefinanciacion.PorcentajeInteres = null;
                }
                else
                {
                    creditoRefinanciacion.MontoInteres = null;
                    creditoRefinanciacion.PorcentajeInteres = rango.Porcentaje.Value;
                }
                
                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.GastoAdministrativo, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                if (rango.Monto.HasValue)
                {
                    creditoRefinanciacion.MontoGastoAdministrativo = rango.Monto.Value;
                    creditoRefinanciacion.PorcentajeGastoAdminist = null;
                }
                else
                {
                    creditoRefinanciacion.MontoGastoAdministrativo = null;
                    creditoRefinanciacion.PorcentajeGastoAdminist = rango.Porcentaje.Value;
                }

                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Seguro, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                if (rango.Monto.HasValue)
                {
                    creditoRefinanciacion.MontoSeguro = rango.Monto.Value;
                    creditoRefinanciacion.PorcentajeSeguro = null;
                }
                else
                {
                    creditoRefinanciacion.MontoSeguro = null;
                    creditoRefinanciacion.PorcentajeSeguro = rango.Porcentaje.Value;
                }

                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Corretaje, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                if (rango.Monto.HasValue)
                {
                    creditoRefinanciacion.MontoCorretaje = rango.Monto.Value;
                    creditoRefinanciacion.PorcentajeCorretaje = null;
                }
                else
                {
                    creditoRefinanciacion.MontoCorretaje = null;
                    creditoRefinanciacion.PorcentajeCorretaje = rango.Porcentaje.Value;
                }

                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.ComisionAdministrativa, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                if (rango.Monto.HasValue)
                {
                    creditoRefinanciacion.MontoComisionAdmin = rango.Monto.Value;
                    creditoRefinanciacion.PorcentajeComisionAdmin = null;
                }
                else
                {
                    creditoRefinanciacion.MontoComisionAdmin = null;
                    creditoRefinanciacion.PorcentajeComisionAdmin = rango.Porcentaje.Value;
                }

                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Otros, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                if (rango.Monto.HasValue)
                {
                    creditoRefinanciacion.MontoOtros = rango.Monto.Value;
                    creditoRefinanciacion.PorcentajeOtros = null;
                }
                else
                {
                    creditoRefinanciacion.MontoOtros = null;
                    creditoRefinanciacion.PorcentajeOtros = rango.Porcentaje.Value;
                }

                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.BonificacionOrdenCompra, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                if (rango.Monto.HasValue)
                {
                    creditoRefinanciacion.MontoBonificacion = rango.Monto.Value;
                    creditoRefinanciacion.PorcentajeBonificacion = null;
                }
                else
                {
                    creditoRefinanciacion.MontoBonificacion = null;
                    creditoRefinanciacion.PorcentajeBonificacion = rango.Porcentaje.Value;
                }

                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.DiasDeGracia, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                creditoRefinanciacion.DiasGracia = rango.Monto.Value;

                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.Mora, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                if (rango.Monto.HasValue)
                {
                    creditoRefinanciacion.MontoDiarioMora = rango.Monto.Value;
                    creditoRefinanciacion.PorcentajeDiarioMora = null;
                }
                else
                {
                    creditoRefinanciacion.MontoDiarioMora = null;
                    creditoRefinanciacion.PorcentajeDiarioMora = rango.Porcentaje.Value;
                }

                rango = creditoRefinanciacion.ArticuloFinanciero.GetRangoAplica(Definiciones.TiposArticuloFinancieroRango.DescuentoCancelacionAnticipada, creditoRefinanciacion.MontoCapitalSolicitado, creditoRefinanciacion.CantidadCuotas, cantidadDias);
                creditoRefinanciacion.DescuentoCancAntAplicado = rango.Porcentaje.Value;
                #endregion Inicializar valores relacionados a rangos
                
                creditoRefinanciacion.InteresCompuesto = creditoRefinanciacion.ArticuloFinanciero.TipoArticuloFinanciero.InteresCompuesto;
                ArticulosFinancierosService.InicializarValoresFinancieros(ref creditoRefinanciacion, creditoRefinanciacion.ArticuloFinanciero);

                creditoRefinanciacion.Guardar();

                #region agregar descuentos
                for (int i = 0; i < lCreditoCtactePersonas.Count; i++)
                {
                    var cd = new CreditosDescuentosService()
                    {
                        CreditoId = creditoRefinanciacion.Id.Value,
                        PersonaId = creditoRefinanciacion.PersonaId,
                        CtactePersonaId = lCreditoCtactePersonas[i],
                        MonedaId = this.MonedaId,
                        Monto = lCreditoMontos[i],
                        Cotizacion = this.Cotizacion,
                        Observacion = string.Empty,
                    };
                    cd.IniciarUsingSesion(sesion);
                    cd.Guardar();
                    cd.FinalizarUsingSesion();
                }
                #endregion agregar descuentos

                creditoRefinanciacion.pasarelaCambioEstadoCampos = this.pasarelaCambioEstadoCampos;
                creditoRefinanciacion.ProcesarCambioEstado(Definiciones.EstadosFlujos.Pendiente, true, comentario, sesion);
                creditoRefinanciacion.ProcesarCambioEstado(Definiciones.EstadosFlujos.PreAprobado, true, comentario, sesion);
                creditoRefinanciacion.ProcesarCambioEstado(Definiciones.EstadosFlujos.Aprobado, true, comentario, sesion);

                creditoRefinanciacion.FinalizarUsingSesion();
                casoRefinanciacionId = creditoRefinanciacion.CasoId.Value;
                #endregion Credito refinanciacion
            }

            return casoRefinanciacionId;
        }
        #endregion CrearRefinanciacion

        #region Buscar
        protected override CreditosService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.ARTICULO_IDColumnName:
                        case Modelo.AUTONUMERACION_IDColumnName:
                        case Modelo.CASO_IDColumnName:
                        case Modelo.FUNCIONARIO_IDColumnName:
                        case Modelo.CTACTE_CAJA_SUCURSAL_IDColumnName:
                        case Modelo.PERSONA_IDColumnName:
                        case Modelo.PERSONA_GARANTE1_IDColumnName:
                        case Modelo.PERSONA_GARANTE2_IDColumnName:
                        case Modelo.SUCURSAL_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.ANHO_COMERCIALColumnName:
                        case Modelo.AUMENTAR_CAPITAL_POR_DESCUENTColumnName:
                        case Modelo.NRO_COMPROBANTEColumnName:
                        case Modelo.NUMERO_SOLICITUDColumnName:
                        case Modelo.AFECTA_LINEA_CREDITOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.FECHA_RETIROColumnName:
                        case Modelo.FECHA_SOLICITUDColumnName:
                        case Modelo.FECHA_CANCELACION_ANTICIPADAColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        case FiltroExtension.CasoEstadoId:
                            if (f.Exacto)
                            {
                                sb.Append(" exists(select * from " + CasosService.Nombre_Tabla + " a " +
                                             "         where a." + CasosService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.CASO_IDColumnName +
                                             "           and a." + f.Columna + " = '" + f.Valor + "') ");
                            }
                            else
                            {
                                string valores = string.Empty;
                                foreach (var v in (string[])f.Valor)
                                    valores += "'" + v + "', ";
                                valores += "'" + Definiciones.Error.Valor.EnteroPositivo.ToString() + "'";

	                             sb.Append(" exists(select * from " + CasosService.Nombre_Tabla + " a " +
                                             "         where a." + CasosService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.CASO_IDColumnName +
                                             "           and a." + f.Columna + " in (" + valores + ")) ");
                            }
                            break;
                        case FiltroExtension.PersonaDeudoraOGaranteId:
                            sb.Append(" ( " +
                                      "   " + Modelo.PERSONA_IDColumnName + " = " + f.Valor +
                                      " or " +
                                      "   nvl(" + Modelo.PERSONA_GARANTE1_IDColumnName + ", " + Definiciones.Error.Valor.EnteroPositivo + ") = " + f.Valor +
                                      " or " +
                                      "   nvl(" + Modelo.PERSONA_GARANTE2_IDColumnName + ", " + Definiciones.Error.Valor.EnteroPositivo + ") = " + f.Valor +
                                      "  )");
                            break;
                        case FiltroExtension.RequisitosFlujosCasoId:
                            string comparacion = "exists";
                            if (f.Comparacion == "exists" || f.Comparacion == "not exists")
                                comparacion = f.Comparacion;
                            if (f.Exacto)
                            {
                                sb.Append(comparacion + " (select rfd." + RequisitosFlujoDetalleService.CasoId_NombreCol +
                                 "              from " + RequisitosFlujoDetalleService.Nombre_Tabla + " rfd " +
                                 "             where rfd." + RequisitosFlujoDetalleService.RequisitoFlujoId_NombreCol + " in (" + f.Valor + ")" +
                                 "               and rfd." + RequisitosFlujoDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                                 "               and rfd." + RequisitosFlujoDetalleService.CasoId_NombreCol + " = " + Nombre_Tabla + "." + Modelo.CASO_IDColumnName +
                                 ")");
                            }
                            else
                            {
                                string valores = string.Empty;
                                foreach (var v in (string[])f.Valor)
                                    valores += "'" + v + "', ";
                                valores += "'" + Definiciones.Error.Valor.EnteroPositivo.ToString() + "'";
                                sb.Append(comparacion + " (select rfd." + RequisitosFlujoDetalleService.CasoId_NombreCol +
                                 "              from " + RequisitosFlujoDetalleService.Nombre_Tabla + " rfd " +
                                 "             where rfd." + RequisitosFlujoDetalleService.RequisitoFlujoId_NombreCol + " in (" + valores + ")" +
                                 "               and rfd." + RequisitosFlujoDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                                 "               and rfd." + RequisitosFlujoDetalleService.CasoId_NombreCol + " = " + Nombre_Tabla + "." + Modelo.CASO_IDColumnName +
                                 ")");
                            }
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            CREDITOSRow[] rows = sesion.db.CREDITOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CreditosService[] c = new CreditosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                c[i] = new CreditosService(rows[i]);

            return c;
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("Falta implementar.");
        }
        #endregion ToEDI

        #region FechaCuotaMasVencida
        public DateTime? FechaCuotaMasVencida(decimal caso_id)
        {
            string query = "SELECT trunc(min(" + CuentaCorrientePersonasService.FechaVencimiento_NombreCol + ")) fecha_vencimiento, count(*) cantidad \n" +
                           "  FROM " + CuentaCorrientePersonasService.Nombre_Tabla + " cp " +
                           " WHERE cp." + CuentaCorrientePersonasService.CasoId_NombreCol + " = " + caso_id +
                           "   AND round(cp." + CuentaCorrientePersonasService.Credito_NombreCol + " - cp." + CuentaCorrientePersonasService.Debito_NombreCol + ", 0) > 0 " +
                           "   AND cp." + CuentaCorrientePersonasService.CtaCteConceptoId_NombreCol + " = " + Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo +
                           "   AND cp." + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            DataTable dt = this.sesion.db.EjecutarQuery(query);
            if ((decimal)dt.Rows[0]["cantidad"] > 0)
                return DateTime.Parse(dt.Rows[0][CuentaCorrientePersonasService.FechaVencimiento_NombreCol].ToString());
            else
                return null;
        }
        #endregion FechaCuotaMasVencida

        #region Accessors
        public static string Nombre_Tabla = "CREDITOS";
        public static string Nombre_Secuencia = "CREDITOS_SQC";
        #endregion Accessors
    }
}
