using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Facturacion;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.NotasCreditoPersona;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class PlanillaCobranzaService : FlujosServiceBaseWorkaround
    {

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.PLANILLA_COBRANZA;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }

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
        public override bool ProcesarCambioEstado(decimal caso_id, string estado_destino, bool cambio_pedido_por_usuario, out string mensaje, SessionService sesion)
        {
            bool exito = false;
            bool revisarRequisitos = false;
            mensaje = "";
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                PLANILLA_COBRANZARow cabeceraRow = sesion.Db.PLANILLA_COBRANZACollection.GetByCASO_ID(caso_id)[0];
                PLANILLA_COBRANZA_DETALLESRow[] detalleRows = sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.GetByPLANILLA_COBRANZA_ID(cabeceraRow.ID);
                PLANILLA_PARA_COBRANZARow[] paraCobranzaRows;

                //Borrador a EnProceso
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.EnProceso))
                {
                    //Acciones
                    //Se genera la numeracion a la planilla de cobrnza a partir de la autonumeracion que haya indicado el usuario
                    exito = true;
                    revisarRequisitos = true;

                    if (!(detalleRows.Length > 0))
                    {
                        exito = false;
                        mensaje = "La planilla no contiene detalles";
                    }

                    #region Se genera el numero de comprobante
                    if (cabeceraRow.NRO_COMPROBANTE == null)
                    {
                        cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, sesion);

                        //Controlar que se logro asignar una numeracion
                        if (cabeceraRow.NRO_COMPROBANTE.Equals(""))
                            throw new Exception("No se pudo asignar una numeración válida");
                    }
                    #endregion Se genera el numero de comprobante
                }
                //Borrador a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Se anulan los recibos que hayan sido emitidos
                    exito = true;
                    revisarRequisitos = true;

                    for (int i = 0; i < detalleRows.Length;i++ )
                    {
                        PlanillaParaCobranzaService.BorrarPorPlanillaDetalle(detalleRows[i].ID, sesion);
                        if (!detalleRows[i].IsCTACTE_RECIBO_IMPRESO_IDNull)
                            CuentaCorrienteRecibosService.Anular(detalleRows[i].CTACTE_RECIBO_IMPRESO_ID, sesion);
                    }
                }
                //EnProceso a Borrador 
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //ninguna.
                    exito = true;
                }
                //EnProceso a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Se anulan los recibos que hayan sido emitidos
                    exito = true;
                    revisarRequisitos = true;

                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        PlanillaParaCobranzaService.BorrarPorPlanillaDetalle(detalleRows[i].ID, sesion);
                        if (!detalleRows[i].IsCTACTE_RECIBO_IMPRESO_IDNull)
                            CuentaCorrienteRecibosService.Anular(detalleRows[i].CTACTE_RECIBO_IMPRESO_ID, sesion);
                    }
                }
                //EnProceso a Rendicion
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Rendicion))
                {
                    //Acciones
                    //Si no se generan pagos, validar que documentos y valores más comisión suman lo mismo
                    //Inicializar el recibo entregado con el recibo impreso, si existe.
                    exito = true;
                    revisarRequisitos = true;

                    #region Si no se genearn pagos, validar que documentos y valores más comisión suman lo mismo
                    if (cabeceraRow.GENERAR_PAGO == Definiciones.SiNo.No)
                    {
                        decimal totalValores, totalDetalles;

                        #region Validar saldo suficiente
                        totalDetalles = totalValores = 0;
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (detalleRows[i].MONEDA_ID == cabeceraRow.MONEDA_ID)
                                totalDetalles += detalleRows[i].MONTO_COBRADO;
                            else
                                totalDetalles += detalleRows[i].MONTO_COBRADO / detalleRows[i].COTIZACION_COBRADA * cabeceraRow.COTIZACION;
                        }
                        
                        foreach (var v in PlanillaCobranzaValoresService.Instancia.GetFiltrado<PlanillaCobranzaValoresService>(new ClaseCBABase.Filtro { Columna = PlanillaCobranzaValoresService.Modelo.PLANILLA_COBRANZA_IDColumnName, Valor = cabeceraRow.ID }))
                        {
                            if (v.MonedaId == cabeceraRow.MONEDA_ID)
                                totalValores += v.MontoUtilizar;
                            else
                                totalValores += v.MontoUtilizar / v.Cotizacion * cabeceraRow.COTIZACION;
                        }

                        MonedasService moneda = new MonedasService(cabeceraRow.MONEDA_ID, sesion);
                        totalDetalles = Math.Round(totalDetalles, moneda.CantidadDecimales);
                        totalValores = Math.Round(totalValores, moneda.CantidadDecimales);
                        if (totalValores + Math.Round(cabeceraRow.MONTO_COMISION, moneda.CantidadDecimales) != totalDetalles)
                            throw new Exception("Los documentos suman " + totalDetalles.ToString(moneda.CadenaDecimales) + " y los valores más comisión " + (totalValores + cabeceraRow.MONTO_COMISION).ToString(moneda.CadenaDecimales) + ".");
                        #endregion Validar saldo suficiente
                    }
                    #endregion Si no se genearn pagos, validar que documentos y valores más comisión suman lo mismo

                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        if (!detalleRows[i].IsCTACTE_RECIBO_IMPRESO_IDNull)
                            detalleRows[i].CTACTE_RECIBO_ENTREGADO_ID = detalleRows[i].CTACTE_RECIBO_IMPRESO_ID;
                        sesion.Db.PLANILLA_COBRANZA_DETALLESCollection.Update(detalleRows[i]);
                    }
                }
                //Rendicion a Caja
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Rendicion) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Caja))
                {
                    //Acciones
                    //Crear casos Pago de Personas si esta marcado Generar Pagos
                    //Crear casos Aplicacion Documentos si no esta marcado Generar Pagos
                    exito = true;
                    revisarRequisitos = true;

                    if (cabeceraRow.IsFUNCIONARIO_CAJERO_IDNull)
                        throw new Exception("Debe definir al funcionario cajero.");

                    string nroRecibo = string.Empty;

                    #region Crear casos Pago de Personas
                    //Generamos los pagos si esta marcado para generar y tiene un cajero asignado
                    if (cabeceraRow.GENERAR_PAGO == Definiciones.SiNo.Si)
                    {
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (detalleRows[i].IsCTACTE_RECIBO_ENTREGADO_IDNull)
                                throw new Exception("Existen Detalles sin Recibos");
                        }

                        decimal reciboId;
                        decimal talonarioId;
                        decimal[] ctacteId;
                        decimal[] montos;
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            reciboId = detalleRows[i].CTACTE_RECIBO_ENTREGADO_ID;

                            DataTable dtRecibo = CuentaCorrienteRecibosService.GetCtacteReciboDataTable2(reciboId, sesion);
                            nroRecibo = dtRecibo.Rows[0][CuentaCorrienteRecibosService.NroComprobante_NombreCol].ToString();
                            talonarioId = (decimal)dtRecibo.Rows[0][CuentaCorrienteRecibosService.AutonumeracionId_NombreCol];

                            paraCobranzaRows = sesion.db.PLANILLA_PARA_COBRANZACollection.GetByPLANILLA_DE_COBRANZA_DET_ID(detalleRows[i].ID);
                            decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                            ctacteId = new decimal[paraCobranzaRows.Length];
                            montos = new decimal[paraCobranzaRows.Length];
                            for (int j = 0; j < paraCobranzaRows.Length; j++)
                            {
                                ctacteId[j] = paraCobranzaRows[j].CTACTE_PERSONA_ID;
                                montos[j] = paraCobranzaRows[j].COBRADO;
                            }

                            casoCreadoId = PagosDePersonaService.CrearCasoDesdePlanilla(cabeceraRow.SUCURSAL_ID,
                                                                           detalleRows[i].PERSONA_ID,
                                                                           DateTime.Now,
                                                                           detalleRows[i].MONEDA_COBRADO_ID,
                                                                           cabeceraRow.FUNCIONARIO_CAJERO_ID,
                                                                           cabeceraRow.FUNCIONARIO_ID,
                                                                           reciboId,
                                                                           nroRecibo,
                                                                           talonarioId,
                                                                           ctacteId,
                                                                           montos, 
                                                                           sesion);
                            PlanillaCobranzaDetallesService.ActulizarCasoPago(detalleRows[i].ID, casoCreadoId, sesion);
                        }
                    }
                    #endregion Crear casos Pago de Personas

                    #region Crear casos Aplicacion Documentos
                    if (cabeceraRow.GENERAR_PAGO == Definiciones.SiNo.No)
                    {
                        DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorFlujo2(CBA.FlowV2.Services.Base.Definiciones.FlujosIDs.APLICACION_DOCUMENTOS, cabeceraRow.SUCURSAL_ID);
                        if (dtAutonumeracion.Rows.Count <= 0)
                            throw new Exception("No se encontró un talonario para Aplicación de Documentos.");

                        DataTable dtAplicacionDocumento, dtCtactePersona = null;
                        PlanillaCobranzaValoresService valorEnUso = null;
                        decimal saldoValor, saldoDocumento, saldoMora, saldoAplicarDocumento, saldoAplicarMora, factorConversion;
                        int indiceValor, aumentarParaRepetir = 0;
                        string casoCreadoEstado = string.Empty, casoCreadoMensaje;
                        decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                        bool exitoAplicacion;
                        MonedasService moneda = new MonedasService(cabeceraRow.MONEDA_ID, sesion);
                        TiposArticuloFinancieroRangoService tipoRangoMora = TiposArticuloFinancieroRangoService.Instancia.Get<TiposArticuloFinancieroRangoService>((decimal)Definiciones.TiposArticuloFinancieroRango.Mora);

                        #region Crear anticipo de persona por comisión y agregar como valor
                        var pcv = PlanillaCobranzaValoresService.Instancia;
                        if (cabeceraRow.MONTO_COMISION > 0)
                        {
                            decimal casoAnticipoId = PlanillaCobranzaService.CrearAnticipoPersona(cabeceraRow, sesion);
                            pcv.PlanillaCobranzaId = cabeceraRow.ID;
                            pcv.CasoId = casoAnticipoId;
                            pcv.MontoUtilizar = cabeceraRow.MONTO_COMISION;
                            pcv.MonedaId = cabeceraRow.MONEDA_ID;
                            pcv.Cotizacion = cabeceraRow.COTIZACION;
                            pcv.IniciarUsingSesion(sesion);
                            pcv.Guardar();
                            pcv.FinalizarUsingSesion();
                        }
                        #endregion Crear anticipo de persona por comisión y agregar como valor
                        pcv.IniciarUsingSesion(sesion);
                        var valores = pcv.GetFiltrado<PlanillaCobranzaValoresService>(new ClaseCBABase.Filtro { Columna = PlanillaCobranzaValoresService.Modelo.PLANILLA_COBRANZA_IDColumnName, Valor = cabeceraRow.ID });
                        pcv.FinalizarUsingSesion();

                        indiceValor = Definiciones.Error.Valor.IntPositivo;
                        factorConversion = Definiciones.Error.Valor.EnteroPositivo;
                        saldoValor = saldoDocumento = saldoMora = 0;
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            DataTable dtPlanillaParaCobranza = PlanillaParaCobranzaService.GetPlanillaParaCobranzaInfoCompleta(PlanillaParaCobranzaService.PlanillaDeCobranzaDetalleId_NombreCol + " = " + detalleRows[i].ID, PlanillaParaCobranzaService.Id_NombreCol, sesion);
                            for (int j = 0; j < dtPlanillaParaCobranza.Rows.Count + aumentarParaRepetir; j++)
                            {
                                aumentarParaRepetir = 0;
                                if (saldoValor <= 0)
                                {
                                    indiceValor++;
                                    valorEnUso = valores[indiceValor];

                                    saldoValor = valorEnUso.MontoUtilizar;

                                    switch ((int)valorEnUso.Caso.FlujoId)
                                    {
                                        case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                                            DataTable dtAnticipoCliente = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + valorEnUso.CasoId, string.Empty, sesion);
                                            if ((decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.MonedaId_NombreCol] != cabeceraRow.MONEDA_ID)
                                                factorConversion = cabeceraRow.COTIZACION / (decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.CotizacionMoneda_NombreCol];
                                            else
                                                factorConversion = 1;
                                            nroRecibo = CuentaCorrienteRecibosService.GetNumeroRecibo((decimal)dtAnticipoCliente.Rows[0][AnticiposPersonaService.CtacteReciboId_NombreCol], sesion);
                                            break;
                                        case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                                            DataTable dtNotaCredito = NotasCreditoPersonaService.GetNotaCreditoPersonaPorCasoDataTable2(valorEnUso.CasoId, sesion);
                                            if ((decimal)dtNotaCredito.Rows[0][NotasCreditoPersonaService.MonedaId_NombreCol] != cabeceraRow.MONEDA_ID)
                                                factorConversion = cabeceraRow.COTIZACION / (decimal)dtNotaCredito.Rows[0][NotasCreditoPersonaService.CotizacionMoneda_NombreCol];
                                            else
                                                factorConversion = 1;
                                            nroRecibo = string.Empty;
                                            break;
                                        default: throw new Exception("Valor de pago no impelmentado: " + valorEnUso.Caso.Flujo.DescripcionImpresion);
                                    }

                                    dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + valorEnUso.CasoId, string.Empty, sesion);
                                }

                                //Repetir el detalle si es que hay que crear un nuevo caso debido
                                //a que el valor no fue suficiente para aplicar en forma entera
                                if (saldoDocumento > 0)
                                {
                                    j--;
                                }
                                else
                                {
                                    decimal montoACobrar = (decimal)dtPlanillaParaCobranza.Rows[j][PlanillaParaCobranzaService.Cobrado_NombreCol];
                                    saldoMora = Math.Min((decimal)dtPlanillaParaCobranza.Rows[j][PlanillaParaCobranzaService.MontoMora_NombreCol], montoACobrar);
                                    
                                    montoACobrar -= saldoMora;
                                    saldoDocumento = Math.Min((decimal)dtPlanillaParaCobranza.Rows[j][PlanillaParaCobranzaService.MontoCuota_NombreCol], montoACobrar);
                                }

                                saldoAplicarMora = Math.Min(saldoMora, saldoValor);
                                saldoAplicarDocumento = Math.Min(saldoDocumento, saldoValor - saldoAplicarMora);

                                saldoDocumento -= saldoAplicarDocumento;
                                saldoValor -= (saldoAplicarMora + saldoAplicarDocumento);

                                //Si queda saldo de cuota para una siguietne iteración y era 
                                //el último documento de la persona, entonces usar el 
                                //aumento temporal para no salir de bucle
                                if (saldoDocumento > 0 && j >= dtPlanillaParaCobranza.Rows.Count - 1)
                                    aumentarParaRepetir = 1;
                                    
                                #region crear cabecera
                                casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                                Hashtable campos = new Hashtable();
                                campos.Add(NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                                campos.Add(NotasCreditoPersonaAplicacionesService.UsuarioId_NombreCol, sesion.Usuario.ID);
                                campos.Add(NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol, detalleRows[i].PERSONA_ID);
                                campos.Add(NotasCreditoPersonaAplicacionesService.PersonaValoresId_NombreCol, valorEnUso.Caso.PersonaId.Value);
                                campos.Add(NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol, cabeceraRow.FUNCIONARIO_CAJERO_ID);
                                if (!cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                                    campos.Add(NotasCreditoPersonaAplicacionesService.CtacteCajaSucursalId_NombreCol, cabeceraRow.CTACTE_CAJA_SUCURSAL_ID);
                                if (!cabeceraRow.IsFC_AUTONUMERACION_IDNull)
                                    campos.Add(NotasCreditoPersonaAplicacionesService.FCAutonumeracionId_NombreCol, cabeceraRow.FC_AUTONUMERACION_ID);
                                campos.Add(NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol, cabeceraRow.MONEDA_ID);
                                campos.Add(NotasCreditoPersonaAplicacionesService.Fecha_NombreCol, DateTime.Now);
                                campos.Add(NotasCreditoPersonaAplicacionesService.Cotizacion_NombreCol, cabeceraRow.COTIZACION);
                                campos.Add(NotasCreditoPersonaAplicacionesService.AutonumeracionId_NombreCol, dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                                campos.Add(NotasCreditoPersonaAplicacionesService.ConsolidacionDeuda_NombreCol, Definiciones.SiNo.No);
                                campos.Add(NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol, saldoAplicarMora + saldoAplicarDocumento);
                                campos.Add(NotasCreditoPersonaAplicacionesService.TotalValores_NombreCol, saldoAplicarMora + saldoAplicarDocumento);
                                campos.Add(NotasCreditoPersonaAplicacionesService.Observacion_NombreCol, nroRecibo);
                                NotasCreditoPersonaAplicacionesService.Guardar(campos, true, ref casoCreadoId, ref casoCreadoEstado, sesion);
                                dtAplicacionDocumento = NotasCreditoPersonaAplicacionesService.GetNotaCreditoPersonaAplicacionPorCaso(casoCreadoId, sesion);
                                #endregion crear cabecera

                                #region agregar valores
                                campos = new Hashtable();
                                campos.Add(NotasCreditoPersonaAplicacionValoresService.CtaCtePersonaId_NombreCol, (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol]);
                                campos.Add(NotasCreditoPersonaAplicacionValoresService.Tipo_NombreCol, Definiciones.TipoComprobanteAplicable.Persona);
                                campos.Add(NotasCreditoPersonaAplicacionValoresService.MontoDestino_NombreCol, saldoAplicarMora + saldoAplicarDocumento);
                                campos.Add(NotasCreditoPersonaAplicacionValoresService.MontoOrigen_NombreCol, (saldoAplicarMora + saldoAplicarDocumento) / factorConversion);
                                campos.Add(NotasCreditoPersonaAplicacionValoresService.Cotizacion_NombreCol, cabeceraRow.COTIZACION);
                                campos.Add(NotasCreditoPersonaAplicacionValoresService.MonedaId_NombreCol, cabeceraRow.MONEDA_ID);
                                campos.Add(NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol, dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol]);
                                NotasCreditoPersonaAplicacionValoresService.Guardar(campos, sesion);
                                #endregion agregar cabecera

                                #region agregar documentos
                                campos = new Hashtable();
                                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol, dtPlanillaParaCobranza.Rows[j][PlanillaParaCobranzaService.CtaCtePersonaId_NombreCol]);
                                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol, detalleRows[i].MONEDA_ID);
                                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol, dtPlanillaParaCobranza.Rows[j][PlanillaParaCobranzaService.VistaCotizacionMoneda_NombreCol]);
                                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol, saldoAplicarDocumento);
                                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoOrigen_NombreCol, saldoAplicarDocumento);
                                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol, dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionesService.Id_NombreCol]);
                                decimal detalleDocumentoId = NotasCreditoPersonaAplicacionDocumentosService.Guardar(campos, sesion);

                                if (saldoAplicarMora > 0)
                                {
                                    var adr = new AplicacionDocumentosRecargosService() 
                                    {
                                         AplicacionDcoumentoDocId = detalleDocumentoId,
                                         Cotizacion = (decimal)dtPlanillaParaCobranza.Rows[j][PlanillaParaCobranzaService.VistaCotizacionMoneda_NombreCol],
                                         CtacteConceptoId = Definiciones.CuentaCorrienteConceptos.Recargo,
                                         ImpuestoId = tipoRangoMora.Articulo.ImpuestoId,
                                         MonedaId = detalleRows[i].MONEDA_ID,
                                         Monto = saldoAplicarMora,
                                         Observacion = "Mora",
                                         TipoRecargo = Definiciones.TipoRecargo.Mora
                                    };

                                    adr.IniciarUsingSesion(sesion);
                                    adr.Guardar();
                                    adr.FinalizarUsingSesion();
                                }
                                #endregion agregar documentos

                                PlanillaCobranzaDetallesService.ActulizarCasoPago(detalleRows[i].ID, casoCreadoId, sesion);

                                exitoAplicacion = (new NotasCreditoPersonaAplicacionesService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, false, out casoCreadoMensaje, sesion);
                                if (exitoAplicacion)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, "Transición Automática por Planilla de Asociación de Funcionarios.", sesion);
                                if (exitoAplicacion)
                                    (new NotasCreditoPersonaAplicacionesService()).EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, this.sesion);

                                exitoAplicacion = (new NotasCreditoPersonaAplicacionesService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, false, out casoCreadoMensaje, sesion);
                                if (exitoAplicacion)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, "Transición Automática por Planilla de Asociación de Funcionarios.", sesion);
                                if (exitoAplicacion)
                                    (new NotasCreditoPersonaAplicacionesService()).EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Proforma, this.sesion);
                            }
                        }
                    }
                    #endregion Crear casos Aplicacion Documentos
                }
                //Caja a Cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Caja) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //Desbloquear cuotas

                    exito = true;
                    revisarRequisitos = true;

                    // se asegura que ningun item de la ctacte quede bloqueado
                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        if(detalleRows[i].IsCASO_PAGO_IDNull)
                            PlanillaParaCobranzaService.DesbloqueCtactePorPlanillaDetalle(detalleRows[i].ID, sesion);
                    }
                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);

                if (exito)
                {
                    sesion.Db.PLANILLA_COBRANZACollection.Update(cabeceraRow);
                }
            }
            catch (Exception exp)
            {
                exito = false;
                throw exp;
            }
            return exito;
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            PLANILLA_COBRANZARow row = sesion.Db.PLANILLA_COBRANZACollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }
        #endregion Implementacion de metodos abstract
        
        #region GetPlanillaCobranza
        /// <summary>
        /// Gets the planilla Cobranza.
        /// </summary>
        /// <param name="planilla_id">The planilla_id.</param>
        /// <returns></returns>
        public static DataTable GetPlanillaCobranza(decimal planilla_id) 
        {
            using(SessionService sesion = new SessionService())
            {
                return GetPlanillaCobranza(planilla_id, sesion);
            }
        }

        public static DataTable GetPlanillaCobranza(decimal planilla_id, SessionService sesion)
        {
            string where = PlanillaCobranzaService.Id_NombreCol + " = " + planilla_id;
            return sesion.Db.PLANILLA_COBRANZACollection.GetAsDataTable(where, PlanillaCobranzaService.Id_NombreCol);
        }

         /// <summary>
        /// Gets the planilla cobranza.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static DataTable GetPlanillaCobranzaPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = PlanillaCobranzaService.CasoId_NombreCol + " = " + caso_id;

                return sesion.Db.PLANILLA_COBRANZA_INFO_COMPLCollection.GetAsDataTable(where, PlanillaCobranzaService.Id_NombreCol);
            }

        }
        /// <summary>
        /// Gets the planilla cobranza.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <returns></returns>
        public static DataTable GetPlanillaCobranzaInfoCompleta(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = PlanillaCobranzaService.VistasCasoEntidadId_NombreCol + " = " + sesion.EntidadActual_Id;

                if (!clausula.Equals(string.Empty)) where += " and " + clausula;
               
                
                return sesion.Db.PLANILLA_COBRANZA_INFO_COMPLCollection.GetAsDataTable(where, PlantillasService.Id_NombreCol);
            }

        }
        #endregion GetPlanillaCobranza

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static bool Guardar(System.Collections.Hashtable campos,  bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    string valorAnterior = string.Empty;
                    PLANILLA_COBRANZARow row = new PLANILLA_COBRANZARow();
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("planilla_cobranza_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[PlanillaCobranzaService.SucursalId_NombreCol].ToString()),
                                                              int.Parse(Definiciones.FlujosIDs.PLANILLA_COBRANZA.ToString()),
                                                              int.Parse(sesion.Usuario_Id.ToString()),
                                                              SessionService.GetClienteIP());
                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                        
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador;
                    }
                    else
                    {
                        row = sesion.Db.PLANILLA_COBRANZACollection.GetByPrimaryKey(decimal.Parse(campos[PlanillasPagosService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    //datos de la cabecera
                    row.AUTONUMERACION_ID = decimal.Parse(campos[PlanillaCobranzaService.AutonumeracionId_NombreCol].ToString());
                    row.SUCURSAL_ID = decimal.Parse(campos[PlanillaCobranzaService.SucursalId_NombreCol].ToString());
                    row.FECHA_INICIO = DateTime.Parse(campos[PlanillaCobranzaService.FechaInicio_NombreCol].ToString());
                    row.FECHA_FIN = DateTime.Parse(campos[PlanillaCobranzaService.FechaFin_NombreCol].ToString());
                    row.FUNCIONARIO_ID = decimal.Parse(campos[PlanillaCobranzaService.FuncionarioId_NombreCol].ToString());
                    row.MONEDA_ID = (decimal)campos[PlanillaCobranzaService.MonedaId_NombreCol];
                    row.COTIZACION = (decimal)campos[PlanillaCobranzaService.Cotizacion_NombreCol];
                    if (row.COTIZACION == Definiciones.Error.Valor.EnteroPositivo)
                        throw new Exception("La cotización no es válida.");
                    row.MONTO_COMISION = (decimal)campos[PlanillaCobranzaService.MontoComision_NombreCol];
                    row.INCLUIR_MORA = (string)campos[PlanillaCobranzaService.IncluirMora_NombreCol];

                    if (campos.Contains(PlanillaCobranzaService.PersonaId_NombreCol))
                        row.PERSONA_ID = (decimal)campos[PlanillaCobranzaService.PersonaId_NombreCol];
                    else
                        row.IsPERSONA_IDNull = true;

                    if (campos.Contains(PlanillaCobranzaService.NroComprobante_NombreCol))
                        row.NRO_COMPROBANTE = campos[PlanillaCobranzaService.NroComprobante_NombreCol].ToString();

                    if (campos.Contains(PlanillaCobranzaService.GenerarPago_NombreCol))
                        row.GENERAR_PAGO = campos[PlanillaCobranzaService.GenerarPago_NombreCol].ToString();
                    else
                        row.GENERAR_PAGO = Definiciones.SiNo.No;

                    if (row.GENERAR_PAGO.Equals(Definiciones.SiNo.Si))
                    {
                        if (campos.Contains(PlanillaCobranzaService.FuncionarioCajeroId_NombreCol))
                            row.FUNCIONARIO_CAJERO_ID = (decimal)campos[PlanillaCobranzaService.FuncionarioCajeroId_NombreCol];
                        else
                            throw new Exception("Debe seleccionar un Cajero");
                    }
                    else 
                    {
                        if (campos.Contains(PlanillaCobranzaService.FuncionarioCajeroId_NombreCol))
                            row.FUNCIONARIO_CAJERO_ID = (decimal)campos[PlanillaCobranzaService.FuncionarioCajeroId_NombreCol];
                    }

                    if (campos.Contains(PlanillaCobranzaService.CtacteCajaSucursal_NombreCol))
                        row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[PlanillaCobranzaService.CtacteCajaSucursal_NombreCol];
                    else
                        row.IsCTACTE_CAJA_SUCURSAL_IDNull = true;

                    if (campos.Contains(PlanillaCobranzaService.FCAutonumeracionId_NombreCol))
                        row.FC_AUTONUMERACION_ID = (decimal)campos[PlanillaCobranzaService.FCAutonumeracionId_NombreCol];
                    else
                        row.IsFC_AUTONUMERACION_IDNull = true;

                    if (insertarNuevo) sesion.Db.PLANILLA_COBRANZACollection.Insert(row);
                        else sesion.Db.PLANILLA_COBRANZACollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA_INICIO);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
                    if (!row.IsPERSONA_IDNull)
                        camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    sesion.CommitTransaction();
                    return true;
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion guardar

        #region Borrar
        /// <summary>
        /// Borra de la base de datos el caso y la cabecera del flujo
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = true;
                    string mensaje = "Error.";

                    //Se obtienen el caso y la factura a ser borrados
                    CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    PLANILLA_COBRANZARow cabecera = sesion.Db.PLANILLA_COBRANZACollection.GetByCASO_ID(caso_id)[0];

                    if (!caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        exito = false;
                        mensaje = "El caso no puede borrarse ya que debe estar en el estado borrador.";
                    }

                    //Si no se cumple alguna condicion, se lanza la excepcion
                    //caso contrario se elimina el caso de la tabla casos y de la cabecera
                    if (exito)
                    {
                        sesion.Db.PLANILLA_COBRANZACollection.DeleteByCASO_ID(caso_id);
                        LogCambiosService.LogDeRegistro(PlanillaCobranzaService.Nombre_Tabla, cabecera.ID, cabecera.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                        //Se borra el caso
                        (new CasosService()).Eliminar(caso_id, sesion);
                    }
                    else
                    {
                        throw new System.ArgumentException(mensaje);
                    }

                    sesion.CommitTransaction();
                    return exito;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region CrearAnticipoPersona
        private static decimal CrearAnticipoPersona(PLANILLA_COBRANZARow row, SessionService sesion)
        {
            if (row.IsCTACTE_CAJA_SUCURSAL_IDNull)
                row.CTACTE_CAJA_SUCURSAL_ID = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(row.SUCURSAL_ID, row.FUNCIONARIO_CAJERO_ID);
            if (row.IsCTACTE_CAJA_SUCURSAL_IDNull)
                row.CTACTE_CAJA_SUCURSAL_ID = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(row.SUCURSAL_ID, row.FUNCIONARIO_ID);
            if (row.CTACTE_CAJA_SUCURSAL_ID == Definiciones.Error.Valor.EnteroPositivo)
                throw new Exception("No se encontró una caja abierta en la sucursal " + new SucursalesService(row.SUCURSAL_ID, sesion).Nombre + " para el funcionario.");

            decimal casoCreadoAnticipoCasoId = Definiciones.Error.Valor.EnteroPositivo;
            string casoCreadoAnticipoEstadoId = string.Empty, mensajeAnticipo = string.Empty;
            decimal casoCreadoAnticipoId = Definiciones.Error.Valor.EnteroPositivo;
            bool exitoAnticipo;

            DataTable dtAutonumeracionAnticipo = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.ANTICIPO_PERSONA, row.SUCURSAL_ID, sesion);
            if (dtAutonumeracionAnticipo.Rows.Count <= 0)
                throw new Exception("No se encontró una autonumeración para el Anticipo en la sucursal " + new SucursalesService(row.SUCURSAL_ID, sesion).Nombre + ".");

            // Se crea la cabecera del anticipo
            Hashtable camposCasoAnticipo = new Hashtable();
            camposCasoAnticipo.Add(AnticiposPersonaService.SucursalId_NombreCol, row.SUCURSAL_ID);
            camposCasoAnticipo.Add(AnticiposPersonaService.PersonaId_NombreCol, row.PERSONA_ID);
            camposCasoAnticipo.Add(AnticiposPersonaService.Fecha_NombreCol, row.FECHA_FIN);
            camposCasoAnticipo.Add(AnticiposPersonaService.FuncionarioCobradorId_NombreCol, row.IsFUNCIONARIO_CAJERO_IDNull ? row.FUNCIONARIO_CAJERO_ID : row.FUNCIONARIO_ID);
            camposCasoAnticipo.Add(AnticiposPersonaService.AutonmeracionReciboId_NombreCol, dtAutonumeracionAnticipo.Rows[0][AutonumeracionesService.Id_NombreCol]);
            camposCasoAnticipo.Add(AnticiposPersonaService.MonedaId_NombreCol, row.MONEDA_ID);
            camposCasoAnticipo.Add(AnticiposPersonaService.CotizacionMoneda_NombreCol, row.COTIZACION);
            camposCasoAnticipo.Add(AnticiposPersonaService.MontoTotal_NombreCol, row.MONTO_COMISION);
            camposCasoAnticipo.Add(AnticiposPersonaService.SaldoPorAplicar_NombreCol, row.MONTO_COMISION);
            camposCasoAnticipo.Add(AnticiposPersonaService.Observacion_NombreCol, "Comisión de Planilla de Cobranza " + row.NRO_COMPROBANTE + " Caso " + row.CASO_ID + ".");
            AnticiposPersonaService.Guardar(camposCasoAnticipo, true, ref casoCreadoAnticipoCasoId, ref casoCreadoAnticipoEstadoId, ref casoCreadoAnticipoId, sesion);
            DataTable dtCasoAnticipo = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + casoCreadoAnticipoId, string.Empty, sesion);

            // Se crea el detalle del anticipo
            Hashtable camposDetalleAnticipo = new Hashtable();
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol, dtCasoAnticipo.Rows[0][AnticiposPersonaService.Id_NombreCol]);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Ajuste);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.MonedaId_NombreCol, row.MONEDA_ID);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol, row.COTIZACION);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.Monto_NombreCol, row.MONTO_COMISION);
            (new AnticiposPersonaDetalleService()).Guardar(camposDetalleAnticipo, sesion);

            //Se avanza el caso hasta aprobado
            AnticiposPersonaService anticipoPersona = new AnticiposPersonaService();
            CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();

            exitoAnticipo = anticipoPersona.ProcesarCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Pendiente, false, out mensajeAnticipo, sesion);
            if (exitoAnticipo)
                exitoAnticipo = ToolbarFlujo.ProcesarCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática por comisión de Planilla de Cobranza.", sesion);
            if (exitoAnticipo)
                anticipoPersona.EjecutarAccionesLuegoDeCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Pendiente, sesion);
            if (!exitoAnticipo)
                throw new Exception("Error en PlanillaCobranzaService.CrearAnticipoPersona al pasar el anticipo creado como comisión a pendiente. " + mensajeAnticipo + ".");

            exitoAnticipo = anticipoPersona.ProcesarCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Aprobado, false, out mensajeAnticipo, sesion);
            if (exitoAnticipo)
                exitoAnticipo = ToolbarFlujo.ProcesarCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Aprobado, "Transición automática por comisión de Planilla de Cobranza.", sesion);
            if (exitoAnticipo)
                anticipoPersona.EjecutarAccionesLuegoDeCambioEstado(casoCreadoAnticipoId, Definiciones.EstadosFlujos.Aprobado, sesion);
            if (!exitoAnticipo)
                throw new Exception("Error en PlanillaCobranzaService.CrearAnticipoPersona al pasar el anticipo creado como comisión a aprobado. " + mensajeAnticipo + ".");

            return casoCreadoAnticipoId;
        }
        #endregion CrearAnticipoPersona

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PLANILLA_COBRANZA"; }
        }
        public static string CtacteCajaSucursalId_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.IDColumnName; }
        }
        public static string IncluirMora_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.INCLUIR_MORAColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.AUTONUMERACION_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.COTIZACIONColumnName; }
        }
        public static string FCAutonumeracionId_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.FC_AUTONUMERACION_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.FUNCIONARIO_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.CASO_IDColumnName; }
        }
        public static string CtacteCajaSucursal_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.FECHA_FINColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.FECHA_INICIOColumnName; }
        }
        public static string FuncionarioCajeroId_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.FUNCIONARIO_CAJERO_IDColumnName; }
        }
        public static string GenerarPago_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.GENERAR_PAGOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.MONEDA_IDColumnName; }
        }
        public static string MontoComision_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.MONTO_COMISIONColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.NRO_COMPROBANTEColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.PERSONA_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return PLANILLA_COBRANZACollection.SUCURSAL_IDColumnName; }
        }
        public static string VistasCasoEstado_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.CASO_ESTADOColumnName; }
        }
        public static string VistasCasoUsuarioId_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.CASO_USUARIO_IDColumnName; }
        }
        public static string VistasCasoUsuarioNombre_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.CASO_USUARIO_NOMBREColumnName; }
        }
        public static string VistasFuncionarioCodigo_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistasFuncionarioNombre_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistasSucursalAbreviatura_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistasSucursalNombre_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistasCasoEntidadId_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.CASO_ENTIDAD_IDColumnName; }
        }
        public static string VistasFuncionarioCajeroNombre_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.FUNCIONARIO_CAJERO_NOMBREColumnName; }
        }
        public static string VistasFuncionarioCajeroCodigo_NombreCol
        {
            get { return PLANILLA_COBRANZA_INFO_COMPLCollection.FUNCIONNARIO_CAJERO_CODIGOColumnName; }
        }
        #endregion Accessors
    }
}
