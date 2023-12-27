#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Comercial;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.NotasDebitoPersona;
using System.Text;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.NotasDebitoProveedor;
using CBA.FlowV2.Services.ListaDePrecio;
using System.Globalization;
using CBA.FlowV2.Services.ToolbarFlujo;
#endregion Using

namespace CBA.FlowV2.Services.NotasCreditoPersona
{
    public class NotasCreditoPersonaAplicacionesService : FlujosServiceBaseWorkaround
    {
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

        #region GetNotaCreditoAplicacionDataTable

        public static DataTable GetNotaCreditoAplicacionDataTable(decimal idAplicacion)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoAplicacionDataTable(idAplicacion, sesion);
            }
        }

        public static DataTable GetNotaCreditoAplicacionDataTable(decimal idAplicacion, SessionService sesion)
        {
            string clausulas = NotasCreditoPersonaAplicacionesService.Id_NombreCol + " = " + idAplicacion;
            return GetNotaCreditoAplicacionDataTable(clausulas, NotasCreditoPersonaAplicacionesService.Id_NombreCol, sesion);
        }

        public static DataTable GetNotaCreditoAplicacionDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoAplicacionDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaCreditoAplicacionDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.APLICACION_DOCUMENTOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaCreditoAplicacionDataTable

        #region GetNotaCreditoPersonaAplicacionPorCaso
        public static DataTable GetNotaCreditoPersonaAplicacionPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoPersonaAplicacionPorCaso(caso_id, sesion);
            }
        }
        public static DataTable GetNotaCreditoPersonaAplicacionPorCaso(decimal caso_id, SessionService sesion)
        {
            return sesion.Db.APLICACION_DOCUMENTOSCollection.GetAsDataTable(NotasCreditoPersonaService.CasoId_NombreCol + " = " + caso_id, string.Empty);
        }

        public static DataTable GetNotaCreditoPersonaPorCasoInfoCompleta(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaCreditoPersonaPorCasoInfoCompleta(caso_id, sesion);
            }
        }

        public static DataTable GetNotaCreditoPersonaPorCasoInfoCompleta(decimal caso_id, SessionService sesion)
        {
            return sesion.Db.APLICACION_DOCUMENTOS_INFO_COMCollection.GetAsDataTable(NotasCreditoPersonaService.CasoId_NombreCol + " = " + caso_id, string.Empty);
        }
        #endregion GetNotaCreditoPersonaPorCaso

        #region Implementacion de metodos abstract
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
            mensaje = " ";
            bool revisarRequisitos = false;
            mensaje = string.Empty;
            int idTransaccion = 0;
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                APLICACION_DOCUMENTOSRow cabeceraRow = sesion.Db.APLICACION_DOCUMENTOSCollection.GetByCASO_ID(caso_id)[0];
                APLICACION_DOCUMENTOS_VALRow[] AplicacionValorRow = sesion.Db.APLICACION_DOCUMENTOS_VALCollection.GetByAPLICACION_DOCUMENTO_ID(cabeceraRow.ID);
                APLICACION_DOCUMENTOS_DOCRow[] AplicacionDocumentoRow = sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.GetByAPLICACION_DOCUMENTO_ID(cabeceraRow.ID);
                MONEDASRow moneda = sesion.db.MONEDASCollection.GetByPrimaryKey(cabeceraRow.MONEDA_ID);
                int cantidadDecimales = int.Parse(moneda.CANTIDADES_DECIMALES.ToString());

                #region BORRADOR A ANULADO
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {

                    for (int i = 0; i < AplicacionDocumentoRow.Length; i++)
                    {
                        if (!AplicacionDocumentoRow[i].IsCTACTE_PERSONA_IDNull)
                            CuentaCorrientePersonasService.SetBloqueado(AplicacionDocumentoRow[i].CTACTE_PERSONA_ID, false, sesion);
                    }
                    //Acciones
                    //Ninguna
                    exito = true;
                }
                #endregion BORRADOR A ANULADO

                #region BORRADOR A PENDIENTE
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    #region Controles
                    revisarRequisitos = false;
                    exito = true;

                    if (!cabeceraRow.CONSOLIDACION_DEUDA.Equals(Definiciones.SiNo.Si))
                    {
                        if (AplicacionDocumentoRow.Length == 0 && exito)
                        {
                            exito = false;
                            mensaje = "El caso no tiene Notas de Creditos ser aplicadas";
                        }

                        if (cabeceraRow.TOTAL_VALORES <= 0 && exito)
                        {
                            exito = false;
                            mensaje = "El total de los Valores No puede ser cero";
                        }

                        if (Interprete.Redondear(cabeceraRow.TOTAL_DOCUMENTOS, cantidadDecimales) != Interprete.Redondear(cabeceraRow.TOTAL_VALORES, cantidadDecimales) && exito)
                        {
                            exito = false;
                            mensaje = "El monto de los valores no es igual a los documentos a pagar";
                        }
                    }

                    if (cabeceraRow.TOTAL_DOCUMENTOS <= 0 && exito)
                    {
                        exito = false;
                        mensaje = "El total de los Documentos no pueden ser cero";
                    }

                    if (AplicacionDocumentoRow.Length == 0)
                    {
                        exito = false;
                        mensaje = "El caso no tiene Documentos Adheridos";
                    }

                    if (cabeceraRow.CONSOLIDACION_DEUDA.Equals(Definiciones.SiNo.Si) && exito)
                    {
                        if (NotasCreditoPersonaAplicacionValoresService.ObtenerTotalValores(cabeceraRow.ID) > 0 && exito)
                        {
                            exito = false;
                            mensaje = "No puede consolidar deudas habiendo Valores seleccionados. Quite estos valores e intente de nuevo";
                        }

                        bool esTotalDeDeuda = ControlarDeudaCliente(cabeceraRow.ID, cabeceraRow.PERSONA_DOCUMENTOS_ID, sesion);
                        if (!esTotalDeDeuda && exito)
                        {
                            exito = false;
                            mensaje = "El total de documentos seleccionados no coincide con el total de la deuda del Cliente";
                        }
                    }

                    if (exito && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.AplicacionDocumentosValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                        exito = GetConsultarNumeroDocumentoExterno(cabeceraRow, out mensaje, sesion);
                    #endregion Controles

                }
                #endregion BORRADOR A PENDIENTE

                #region PENDIENTE A BORRADOR
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    /****AGREGAR CONTROLES****/
                    //Acciones
                    //ninguna.
                    exito = true;
                }
                #endregion PENDIENTE A BORRADOR

                #region PENDIENTE A APROBADO
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {

                    #region Controles
                    revisarRequisitos = false;
                    exito = true;

                    if (!cabeceraRow.CONSOLIDACION_DEUDA.Equals(Definiciones.SiNo.Si))
                    {
                        if (AplicacionDocumentoRow.Length == 0 && exito)
                        {
                            exito = false;
                            mensaje = "El caso no tiene Notas de Creditos ser aplicadas";
                        }
                        if (cabeceraRow.TOTAL_VALORES <= 0 && exito)
                        {
                            exito = false;
                            mensaje = "El total de los Valores No puede ser cero";
                        }
                        if (AplicacionDocumentoRow.Length == 0 && exito)
                        {
                            exito = false;
                            mensaje = "El caso no tiene Documentos Adheridos";
                        }
                        if (AplicacionDocumentoRow.Length == 0 && exito)
                        {
                            exito = false;
                            mensaje = "El caso no tiene Notas de Creditos ser aplicadas";
                        }
                        if (Interprete.Redondear(cabeceraRow.TOTAL_DOCUMENTOS, cantidadDecimales) != Interprete.Redondear(cabeceraRow.TOTAL_VALORES, cantidadDecimales) && exito)
                        {
                            exito = false;
                            mensaje = "El monto de los valores no es igual a los documentos a pagar";
                        }
                    }

                    if (AplicacionDocumentoRow.Length == 0)
                    {
                        exito = false;
                        mensaje = "El caso no tiene Documentos Adheridos";
                    }

                    if (cabeceraRow.TOTAL_DOCUMENTOS <= 0 && exito)
                    {
                        exito = false;
                        mensaje = "El total de los Documentos no pueden ser cero";
                    }

                    if (cabeceraRow.CONSOLIDACION_DEUDA.Equals(Definiciones.SiNo.Si) && exito)
                    {
                        if (NotasCreditoPersonaAplicacionValoresService.ObtenerTotalValores(cabeceraRow.ID) > 0 && exito)
                        {
                            exito = false;
                            mensaje = "No puede consolidar deudas habiendo Valores seleccionados. Quite estos valores e intente de nuevo";
                        }

                        bool esTotalDeDeuda = ControlarDeudaCliente(cabeceraRow.ID, cabeceraRow.PERSONA_DOCUMENTOS_ID, sesion);
                        if (!esTotalDeDeuda && exito)
                        {
                            exito = false;
                            mensaje = "El total de documentos seleccionados no coincide con el total de la deuda del Cliente";
                        }
                    }
                    #endregion Controles

                    #region Consolidación Deuda
                    if (cabeceraRow.CONSOLIDACION_DEUDA.Equals(Definiciones.SiNo.Si) && exito)
                    {
                        string texto = string.Empty;
                        int plazo = -1;
                        double totalNuevaFactura = 0;
                        DateTime fechaVencimiento = new DateTime();

                        AccionConsolidacionDeuda((int)cabeceraRow.PERSONA_DOCUMENTOS_ID, ref texto, ref plazo, ref totalNuevaFactura, ref fechaVencimiento, ref idTransaccion, sesion);

                        #region Validación
                        if (plazo < 1 || plazo > 48)
                        {
                            exito = false;
                            throw new Exception(texto);
                        }
                        #endregion Validación

                        if (exito)
                        {
                            // CREACIÓN DE LA NOTA DE CRÉDITO
                            exito = CrearNotaDeCredito(cabeceraRow, sesion, NotasCreditoPersonaAplicacionDocumentosService.ObtenerTotalDocumentos(cabeceraRow.ID, sesion));
                        }

                        if (exito)
                        {
                            decimal condicionPagoId = Definiciones.Error.Valor.EnteroPositivo;
                            DataTable dtCondicionPago = CondicionesPagoService.GetCondicionesDataTable(CondicionesPagoService.CantidadPagos_NombreCol + " = " + plazo, true, sesion);

                            if (dtCondicionPago.Rows.Count > 0)
                            {
                                decimal casoFacturaId = Definiciones.Error.Valor.EnteroPositivo;
                                condicionPagoId = (decimal)dtCondicionPago.Rows[0][CondicionesPagoService.Id_NombreCol];

                                // CREACIÓN DE LA FACTURA
                                exito = CrearFacturaCliente(cabeceraRow, sesion, caso_id, totalNuevaFactura, condicionPagoId, ref casoFacturaId, idTransaccion, fechaVencimiento);

                                // GUARDAR EL CASO_ID DE LA FACTURA EN LA CABECERA DE APLICACION DOCUMENTO
                                cabeceraRow.FC_CASO_ID = casoFacturaId;
                                sesion.Db.APLICACION_DOCUMENTOSCollection.Update(cabeceraRow);
                            }
                            else
                            {
                                exito = false;
                            }
                        }
                    }
                    #endregion Consolidación Deuda

                    if (exito)
                    {
                        ConfirmarDetalles(cabeceraRow.ID, sesion);
                        ConfirmarDocumentos(cabeceraRow.ID, sesion);
                        NotasCreditoPersonaAplicacionDocumentosService.DesbloquearDetalles(cabeceraRow.ID, sesion);

                        if (exito && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.AplicacionDocumentosValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                            ActualizarNumeroDocumentoExterno(cabeceraRow, out mensaje, sesion);
                    }
                }
                #endregion PENDIENTE A APROBADO

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.APLICACION_DOCUMENTOSCollection.Update(cabeceraRow);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, cabeceraRow.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, cabeceraRow.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, cabeceraRow.NRO_COMPROBANTE_EXTERNO);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                    if (!Interprete.EsNullODBNull(cabeceraRow.NRO_RECIBO_MANUAL))
                        camposCaso.Add(CasosService.NroComprobante2_NombreCol, cabeceraRow.NRO_RECIBO_MANUAL);
                    camposCaso.Add(CasosService.PersonaId_NombreCol, cabeceraRow.PERSONA_DOCUMENTOS_ID);
                    CasosService.ActualizarCampos(cabeceraRow.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos
                }

                if (cabeceraRow.CONSOLIDACION_DEUDA.Equals(Definiciones.SiNo.Si) && exito)
                {
                    AccionConfirmarConsolidacion(idTransaccion, ref mensaje, sesion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public bool ControlarDeudaCliente(decimal aplicacionDocumentoId, decimal personaId, SessionService sesion)
        {
            decimal totalDocumentos = 0;
            object credito = 0;
            object debito = 0;
            decimal deudaTotalCliente = 0;

            DataTable dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + personaId + " AND " + CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol, string.Empty, sesion);
            if (dtCtactePersona.Rows.Count > 0)
            {
                credito = dtCtactePersona.Compute("Sum(" + CuentaCorrientePersonasService.Credito_NombreCol + ")", "");
                debito = dtCtactePersona.Compute("Sum(" + CuentaCorrientePersonasService.Debito_NombreCol + ")", "");
            }

            deudaTotalCliente = (decimal)credito - (decimal)debito;
            totalDocumentos = NotasCreditoPersonaAplicacionDocumentosService.ObtenerTotalDocumentos(aplicacionDocumentoId);

            // Comparar total de documentos seleccionados con el total de la deuda del cliente
            return (deudaTotalCliente == totalDocumentos);
        }

        public bool CrearNotaDeCredito(APLICACION_DOCUMENTOSRow cabeceraRow, SessionService sesion, decimal totalDocumentos)
        {
            bool exito = false;

            #region Cabecera Nota de Crédito
            string nroComprobanteNC = string.Empty;
            if ((!Interprete.EsNullODBNull(cabeceraRow.NC_NRO_COMPROBANTE)))
                nroComprobanteNC = cabeceraRow.NC_NRO_COMPROBANTE;

            Hashtable campos = new Hashtable()
                        {
                            {NotasCreditoPersonaService.SucursalId_NombreCol, (decimal)cabeceraRow.SUCURSAL_ID}
                            , {NotasCreditoPersonaService.DepositoId_NombreCol, (decimal)cabeceraRow.NC_DEPOSITO_ID}
                            , {NotasCreditoPersonaService.PersonaId_NombreCol, (decimal)cabeceraRow.PERSONA_DOCUMENTOS_ID}
                            , {NotasCreditoPersonaService.MonedaId_NombreCol, (decimal)cabeceraRow.MONEDA_ID}
                            , {NotasCreditoPersonaService.FuncionarioCobradorId_NombreCol, (decimal)cabeceraRow.FUNCIONARIO_ID}
                            , {NotasCreditoPersonaService.AutonumeracionId_NombreCol, (decimal)cabeceraRow.NC_AUTONUMERACION_ID}

                            , {NotasCreditoPersonaService.NroComprobante_NombreCol, nroComprobanteNC}
                            , {NotasCreditoPersonaService.Fecha_NombreCol, DateTime.Now}
                            , {NotasCreditoPersonaService.TipoNotaCreditoId_NombreCol, (decimal)Definiciones.TiposNotasCredito.UnificacionDeuda}
                            , {NotasCreditoPersonaService.Observacion_NombreCol, string.Empty}
                            , {NotasCreditoPersonaService.CtaCteCajaSucursalId_NombreCol, (decimal)cabeceraRow.NC_CTACTE_CAJA_SUCURSAL_ID}
                            
                        };

            decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
            string vCasoEstado = string.Empty;
            exito = NotasCreditoPersonaService.Guardar2(campos, true, ref vCasoId, ref vCasoEstado, sesion);
            #endregion Cabecera Nota de Crédito

            #region Detalle Nota de Crédito
            DataTable dtNotasCreditoPersonaAplicacionDocumento = NotasCreditoPersonaAplicacionDocumentosService.GetNotaCreditoAplicacionDocumentosDataTable(NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol + " = " + cabeceraRow.ID, NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol, sesion);

            object notaCreditoId = 0;

            DataTable dtNotaCreditoPersona = NotasCreditoPersonaService.GetNotaCreditoPersonaPorCasoDataTable2(vCasoId, sesion);

            notaCreditoId = dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.Id_NombreCol];

            if (totalDocumentos > 0)
            {
                // Crear detalle de la NC Cliente
                campos = new Hashtable();
                campos.Add(NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol, decimal.Parse(notaCreditoId.ToString()));
                campos.Add(NotasCreditoPersonaDetalleService.TextoPredefinidoId_NombreCol, (decimal)851);
                campos.Add(NotasCreditoPersonaDetalleService.ImpuestoId_NombreCol, (decimal)1);
                campos.Add(NotasCreditoPersonaDetalleService.MontoConcepto_NombreCol, totalDocumentos);

                campos.Add(NotasCreditoPersonaDetalleService.Observacion_NombreCol, string.Empty);

                NotasCreditoPersonaDetalleService.Guardar2(campos, sesion);
            }
            #endregion Detalle Nota de Crédito

            #region Paso de Estado de la NC Cliente - Borrador a Aprobado
            if (dtNotasCreditoPersonaAplicacionDocumento.Rows.Count > 0)
            {
                string msgCasoAsociado;

                exito = (new NotasCreditoPersonaService()).ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, false, out msgCasoAsociado, sesion);
                if (exito)
                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, "Transición Automática por Consolidación de Deudas", sesion);

                if (!AutonumeracionesService.EsGeneracionManual((decimal)cabeceraRow.NC_AUTONUMERACION_ID, sesion))
                {
                    // Generación de Número de Comprobante
                    decimal nroSecuencia = -1;
                    string nroComprobante = (new NotasCreditoPersonaService()).GenerarNumeroComprobante(vCasoId, out nroSecuencia, sesion);
                    campos = new Hashtable();
                    campos.Add(NotasCreditoPersonaService.Id_NombreCol, decimal.Parse(dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.Id_NombreCol].ToString()));
                    campos.Add(NotasCreditoPersonaService.NroComprobante_NombreCol, nroComprobante);
                    campos.Add(NotasCreditoPersonaService.NroComprobanteSecuencia_NombreCol, nroSecuencia);
                    campos.Add(NotasCreditoPersonaService.SucursalId_NombreCol, decimal.Parse(dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.SucursalId_NombreCol].ToString()));
                    campos.Add(NotasCreditoPersonaService.PersonaId_NombreCol, decimal.Parse(dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.PersonaId_NombreCol].ToString()));
                    campos.Add(NotasCreditoPersonaService.FuncionarioCobradorId_NombreCol, decimal.Parse(dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.FuncionarioCobradorId_NombreCol].ToString()));
                    campos.Add(NotasCreditoPersonaService.MonedaId_NombreCol, decimal.Parse(dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.MonedaId_NombreCol].ToString()));
                    campos.Add(NotasCreditoPersonaService.Fecha_NombreCol, DateTime.Parse(dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.Fecha_NombreCol].ToString()));
                    campos.Add(NotasCreditoPersonaService.Observacion_NombreCol, dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.Fecha_NombreCol].ToString());
                    campos.Add(NotasCreditoPersonaService.CtaCteCajaSucursalId_NombreCol, decimal.Parse(dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.CtaCteCajaSucursalId_NombreCol].ToString()));
                    exito = NotasCreditoPersonaService.Guardar2(campos, false, ref vCasoId, ref vCasoEstado, sesion);
                }

                exito = (new NotasCreditoPersonaService()).ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.PreAprobado, false, out msgCasoAsociado, sesion);
                if (exito)
                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.PreAprobado, "Transición Automática por Consolidación de Deudas", sesion);

                exito = (new NotasCreditoPersonaService()).ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, false, out msgCasoAsociado, sesion);
                if (exito)
                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, "Transición Automática por Consolidación de Deudas", sesion);

                DataTable dtNCGenerada = NotasCreditoPersonaService.GetNotaCreditoPersonaPorCasoDataTable2(vCasoId, sesion);
                DataTable dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + vCasoId, string.Empty, sesion);

                // Insertar detalle en NotasCreditoPersonaAplicacionValores
                campos = new Hashtable();
                campos.Add(NotasCreditoPersonaAplicacionValoresService.CtaCtePersonaId_NombreCol, dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol]);
                campos.Add(NotasCreditoPersonaAplicacionValoresService.Tipo_NombreCol, (decimal)0);
                campos.Add(NotasCreditoPersonaAplicacionValoresService.MontoDestino_NombreCol, dtNCGenerada.Rows[0][NotasCreditoPersonaService.MontoTotal_NombreCol]);
                campos.Add(NotasCreditoPersonaAplicacionValoresService.MontoOrigen_NombreCol, dtNCGenerada.Rows[0][NotasCreditoPersonaService.MontoTotal_NombreCol]);
                campos.Add(NotasCreditoPersonaAplicacionValoresService.Cotizacion_NombreCol, dtNCGenerada.Rows[0][NotasCreditoPersonaService.CotizacionMoneda_NombreCol]);
                campos.Add(NotasCreditoPersonaAplicacionValoresService.MonedaId_NombreCol, dtNCGenerada.Rows[0][NotasCreditoPersonaService.MonedaId_NombreCol]);
                campos.Add(NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol, cabeceraRow.ID);

                NotasCreditoPersonaAplicacionValoresService.Guardar(campos, sesion);
            }
            #endregion Paso de Estado de la NC Cliente - Borrador a Aprobado

            return exito;
        }

        public bool CrearFacturaCliente(APLICACION_DOCUMENTOSRow cabeceraRow, SessionService sesion, decimal caso_id, double totalFactura, decimal condicionPagoId, ref decimal casoFacturaId, decimal transaccion_id, DateTime fecha_vencimiento)
        {
            bool exito = true;

            #region Cabecera FC Cliente
            FacturasClienteService facturaClienteService = new FacturasClienteService();

            Hashtable campos = new System.Collections.Hashtable();
            campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.Si);
            campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.Si);
            campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, cabeceraRow.FC_AUTONUMERACION_ID);
            campos.Add(FacturasClienteService.CasoOrigenId_NombreCol, caso_id);
            campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
            campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, condicionPagoId);
            campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, cabeceraRow.COTIZACION);
            campos.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
            campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, DateTime.Now);
            campos.Add(FacturasClienteService.Fecha_NombreCol, DateTime.Now);
            campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, cabeceraRow.MONEDA_ID);
            campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, (decimal)0);
            campos.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
            campos.Add(FacturasClienteService.Observacion_NombreCol, "Factura creada por Aplicación de Documentos " + Traducciones.Caso + " Nº" + cabeceraRow.CASO_ID);
            campos.Add(FacturasClienteService.PersonaId_NombreCol, cabeceraRow.PERSONA_DOCUMENTOS_ID);
            campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, (decimal)0);
            campos.Add(FacturasClienteService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
            campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, Definiciones.TipoFactura.Contado);
            campos.Add(FacturasClienteService.VendedorId_NombreCol, cabeceraRow.FUNCIONARIO_ID);
            campos.Add(FacturasClienteService.NroDocumentoExterno_NombreCol, "0");
            campos.Add(FacturasClienteService.SucursalVentaId_NombreCol, cabeceraRow.SUCURSAL_ID);
            campos.Add(FacturasClienteService.CtaCteCajaSucursalId_NombreCol, cabeceraRow.FC_CTACTE_CAJA_SUCURSAL_ID);
            campos.Add(FacturasClienteService.DepositoId_NombreCol, cabeceraRow.FC_DEPOSITO_ID);

            string clausula = ListasDePrecioService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
               " and " + ListasDePrecioService.MonedaId_NombreCol + " = " + cabeceraRow.MONEDA_ID +
               " and ((" + ListasDePrecioService.FechaInicio_NombreCol + " is null or " +
               ListasDePrecioService.FechaInicio_NombreCol + " <= to_date('" + DateTime.Now.ToShortDateString() + "','dd/mm/yyyy')) and (" +
               ListasDePrecioService.FechaFin_NombreCol + " is null or " +
               ListasDePrecioService.FechaFin_NombreCol + " >= to_date('" + DateTime.Now.ToShortDateString() + "','dd/mm/yyyy'))) and " +
               "(" + ListaDePrecio.ListasDePrecioService.RegionId_NombreCol + " is null or " + ListaDePrecio.ListasDePrecioService.RegionId_NombreCol + " = " + new SucursalesService(cabeceraRow.SUCURSAL_ID, sesion).RegionId.Value + ") and " +
               "(" + ListaDePrecio.ListasDePrecioService.SucursalId_NombreCol + " is null or " + ListaDePrecio.ListasDePrecioService.SucursalId_NombreCol + " = " + cabeceraRow.SUCURSAL_ID + ")";

            DataTable dtListasPrecio = (new ListasDePrecioService()).GetListasDePrecioInfoCompleta(clausula, ListasDePrecioService.Id_NombreCol, sesion);
            campos.Add(FacturasClienteService.ListaPrecioId_NombreCol, (decimal)dtListasPrecio.Rows[0][ListasDePrecioService.Id_NombreCol]);


            string casoFacturaEstado = string.Empty;

            exito = FacturasClienteService.Guardar(campos, true, ref casoFacturaId, ref casoFacturaEstado, sesion);

            if (casoFacturaId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                throw new Exception("No pudo crearse la Factura");

            DataTable dtFacturaCreada = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoId_NombreCol + " = " + casoFacturaId, string.Empty, sesion);

            #endregion Cabecera FC Cliente

            #region Detalle FC Cliente
            DataTable dtArticulo = Articulos.ArticulosService.GetArticulos(Articulos.ArticulosService.Id_NombreCol + " = " + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteArticuloPorConsolidacionDeuda), string.Empty, false, cabeceraRow.SUCURSAL_ID, sesion);
            DataTable dtLote = Articulos.ArticulosLotesService.GetArticulosLotesInfoCompleta2((decimal)dtArticulo.Rows[0][Articulos.ArticulosService.Id_NombreCol], string.Empty, sesion);

            if (dtLote.Rows.Count <= 0)
                throw new Exception("No existe ningún lote para el artículo " + dtArticulo.Rows[0][Articulos.ArticulosService.Id_NombreCol] + " definido en la variable de sistema FCClienteComoComprobantePagoCapitalArticulo.");

            campos = new System.Collections.Hashtable();
            campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
            campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteArticuloPorConsolidacionDeuda));
            campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtLote.Rows[0][Articulos.ArticulosLotesService.Id_NombreCol]);
            campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, dtArticulo.Rows[0][Articulos.ArticulosService.UnidadMedidaId_NombreCol]);
            campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
            campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
            campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, Definiciones.Impuestos.IVA_10);
            campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, totalFactura);
            campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
            campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
            campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, "Correspondiente a Consolidación de Deudas. Caso Nº" + cabeceraRow.CASO_ID);

            DateTime fechaPrimerVencimiento = DateTime.Today, fechaSegundoVencimiento = DateTime.MinValue;
            bool usarFechaPrimerVencimiento = false, usarFechaSegundoVencimiento = false;

            FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, sesion);

            #endregion Detalle FC Cliente

            #region ActualizarFechaVencimiento
            if (exito)
                FacturasClienteService.ActualizarCuotas((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], fecha_vencimiento, DateTime.MinValue, sesion);
            #endregion ActualizarFechaVencimiento

            #region Paso de Estado de la FC Cliente - Borrador a Caja

            string msgCasoFactura;

            exito = (new FacturasClienteService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, false, out msgCasoFactura, sesion);
            if (exito)
                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Pendiente, "Transición Automática por Consolidación de Deudas", sesion);

            exito = (new FacturasClienteService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, false, out msgCasoFactura, sesion);
            if (exito)
                (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, "Transición Automática por Consolidación de Deudas", sesion);

            #endregion Paso de Estado de la FC Cliente - Borrador a Caja

            #region cambiarOC
            if (exito)
                FacturasClienteService.CambiarOC((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], transaccion_id.ToString(), sesion);
            #endregion cambiarOC

            return exito;
        }

        public void AccionConsolidacionDeuda(int persona_id, ref string mensaje, ref int plazo, ref double total_factura, ref DateTime fecha_vencimiento, ref int transaccion_id, SessionService sesion)
        {
            switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
            {
                
                default:
                    throw new Exception("Error en NotasCreditoPersonaAplicacionService.AccionConsolidadDeuda(), el cliente no tiene implementado un cálculo.");
            }
        }

        public void AccionConfirmarConsolidacion(int transaccion_id, ref string mensaje, SessionService sesion)
        {
            switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
            {
                
                default:
                    throw new Exception("Error en NotasCreditoPersonaAplicacionService.AccionConfirmarConsolidacion(), el cliente no tiene implementado un cálculo.");
            }
        }

        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion)
        {
            //throw new NotImplementedException();
        }

        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            throw new NotImplementedException();
        }


        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.APLICACION_DOCUMENTOS;
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion Implementacion de metodos abstract

        #region ConfirmarDocumentos
        /// <summary>
        /// Confirmars the documentos.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="emitir_factura1">if set to <c>true</c> [emitir_factura1].</param>
        /// <param name="emitir_factura2">if set to <c>true</c> [emitir_factura2].</param>
        /// <param name="detalles_recibo">The detalles_recibo.</param>
        /// <param name="detalles_factura1">The detalles_factura1.</param>
        /// <param name="detalles_factura2">The detalles_factura2.</param>
        /// <param name="total_documentos">The total_documentos.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ConfirmarDocumentos(decimal nc_aplicacion_id, SessionService sesion)
        {
            DataTable dtCtactePersona, dtCtactePersonaTotal;
            decimal saldo;
            string mensaje;

            DataTable dtCtactePersonaDet;
            Hashtable montoPorImpuesto;
            Hashtable[] detallesFactura;
            decimal[] impuestoId, monto;
            int indiceAux;
            decimal montoVerificacion;
            string clausulas;

            decimal articuloGastoCobranza = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoGastoCobranza);
            decimal articuloMora = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoMoraArticulo);
            decimal articuloInteresPunitorio = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoInteresPunitorio);

            //Obtenemos la cabecera del caso
            APLICACION_DOCUMENTOSRow cabeceraRow = sesion.db.APLICACION_DOCUMENTOSCollection.GetByPrimaryKey(nc_aplicacion_id);

            //Documentos pagados
            APLICACION_DOCUMENTOS_DOCRow[] rows = sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.GetAsArray(NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol + " = " + nc_aplicacion_id + " and " + NotasCreditoPersonaAplicacionDocumentosService.CtaCtePersonaId_NombreCol + " is not null", NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol);

            //Realizar acciones por cada documento
            for (int i = 0; i < rows.Length; i++)
            {
                //Se obtiene el registro de la cuenta corriente de la persona
                dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + rows[i].CTACTE_PERSONA_ID, string.Empty, sesion);

                #region Calcular monto por tipo de impuesto
                montoPorImpuesto = new System.Collections.Hashtable();
                dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol], sesion);

                for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                {
                    if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                        montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol];
                    else
                        montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol]);
                }

                impuestoId = new decimal[montoPorImpuesto.Count];
                monto = new decimal[montoPorImpuesto.Count];

                indiceAux = 0;
                montoVerificacion = 0;
                foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                {
                    impuestoId[indiceAux] = (decimal)par.Key;
                    monto[indiceAux] = (decimal)par.Value / Math.Max((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol], (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol]) * rows[i].MONTO_ORIGEN;

                    montoVerificacion += monto[indiceAux];

                    indiceAux++;
                }


                if (Math.Round(rows[i].MONTO_ORIGEN, MonedasService.CantidadDecimalesStatic(rows[i].MONEDA_ID)) != Math.Round(montoVerificacion, MonedasService.CantidadDecimalesStatic(rows[i].MONEDA_ID)))
                    throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + rows[i].MONTO_DESTINO + ".");
                #endregion Calcular monto por tipo de impuesto

                //Ingresar el debito
                CuentaCorrientePersonasService.AgregarDebito((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.PersonaId_NombreCol],
                                            (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Id_NombreCol],
                                            Definiciones.CuentaCorrienteConceptos.DebitoPorPago,
                                            Definiciones.CuentaCorrienteValores.Efectivo, //Se agrega efectivo por completar el dato simplemente
                                            cabeceraRow.CASO_ID,
                                            rows[i].MONEDA_ID,
                                            rows[i].COTIZACION,
                                            impuestoId,
                                            monto,
                                            string.Empty,
                                            cabeceraRow.FECHA,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            Definiciones.Error.Valor.EnteroPositivo,
                                            sesion);

                //Saldo antes del pago actual
                saldo = (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol] -
                        (decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Debito_NombreCol];

                //Saldo luego del pago actual
                saldo -= rows[i].MONTO_ORIGEN;

                if (!rows[i].IsCTACTE_PERSONA_IDNull)
                    CuentaCorrientePersonasService.SetBloqueado(rows[i].CTACTE_PERSONA_ID, false, sesion);
                
                //Se obtienen todos los registros relacionados con saldo mayor a 0.01 salvo el que se esta pagando
                if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol].Equals(DBNull.Value))
                {
                    clausulas = CuentaCorrientePersonasService.CasoId_NombreCol + " = " + dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol] + " and " +
                                "(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                }
                else
                {
                    if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol].Equals(DBNull.Value))
                    {
                        clausulas = CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol + " = " + dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaCtactePagareId_NombreCol] + " and " +
                                   "(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                    }
                    else
                    {
                        clausulas = "(" + CuentaCorrientePersonasService.Credito_NombreCol + " - " + CuentaCorrientePersonasService.Debito_NombreCol + ") > 0.01 ";
                    }
                }

                dtCtactePersonaTotal = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(clausulas, string.Empty, sesion);

                //Si es FC, ND o credito de clientes, el saldo es cero y no existe otros movimientos con saldo debe cerrarse el caso pagado
                if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol].Equals(DBNull.Value) &&
                    !dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CtaCteConceptoId_NombreCol].Equals(Definiciones.CuentaCorrienteConceptos.Recargo) &&
                     Math.Round(saldo, MonedasService.CantidadDecimalesStatic(rows[i].MONEDA_ID)) == 0 && dtCtactePersonaTotal.Rows.Count <= 0)
                {
                    int flujoId = Convert.ToInt32(dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFlujoId_NombreCol]);
                    bool exitoCasoAsociado = false;

                    switch (flujoId)
                    {
                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                            FacturasClienteService facturaCliente = new FacturasClienteService();
                            exitoCasoAsociado = facturaCliente.ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                            if (exitoCasoAsociado)
                                exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                            if (exitoCasoAsociado)
                                facturaCliente.EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                            if (!exitoCasoAsociado)
                                throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos, Facturacion Cliente. " + mensaje + ".");
                            break;
                        case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                            NotasDebitoPersonaService notaDebitoPersona = new NotasDebitoPersonaService();
                            exitoCasoAsociado = notaDebitoPersona.ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                            if (exitoCasoAsociado)
                                exitoCasoAsociado = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                            if (exitoCasoAsociado)
                                notaDebitoPersona.EjecutarAccionesLuegoDeCambioEstado((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], Definiciones.EstadosFlujos.Cerrado, sesion);

                            if (!exitoCasoAsociado)
                                throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos, Nota de débito persona. " + mensaje + ".");
                            break;
                        case Definiciones.FlujosIDs.CREDITOS:
                            var credito = CreditosService.GetPorCaso((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CasoId_NombreCol], sesion);
                            credito.IniciarUsingSesion(sesion);
                            credito.ProcesarCambioEstado(Definiciones.EstadosFlujos.Cerrado, false, new ToolbarFlujoService.ComentarioTransicion { texto = "Transición automática por deuda finiquitada." }, sesion);
                            credito.FinalizarUsingSesion();
                            break;
                    }
                }

                #region Crear los recargos relacionados al documento
                var recargos = AplicacionDocumentosRecargosService.GetRecargosSobreDocumento(rows[i].ID, sesion);
                for (int j = 0; j < recargos.Length; j++)
                {
                    var documentoRecargoRow = sesion.db.APLICACION_DOCUMENTOS_DOCCollection.GetByPrimaryKey(recargos[j].AplicacionDcoumentoDocId.Value);

                    //debe ser creado en la cuenta corriente para luego ser pagado
                    recargos[j].IniciarUsingSesion(sesion);
                    documentoRecargoRow.CTACTE_PERSONA_ID = recargos[j].CrearCredito();
                    recargos[j].FinalizarUsingSesion();

                    sesion.Db.APLICACION_DOCUMENTOS_DOCCollection.Update(documentoRecargoRow);

                    //Se obtiene el registro de la cuenta corriente de la persona
                    var ctactePersona = new CuentaCorrientePersonasService(documentoRecargoRow.CTACTE_PERSONA_ID, sesion);

                    #region Calcular monto por tipo de impuesto
                    montoPorImpuesto = new System.Collections.Hashtable();
                    dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable(ctactePersona.Id.Value, sesion);

                    for (int k = 0; k < dtCtactePersonaDet.Rows.Count; k++)
                    {
                        if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                            montoPorImpuesto[dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + (decimal)dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.Monto_NombreCol];
                        else
                            montoPorImpuesto.Add(dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], dtCtactePersonaDet.Rows[k][CuentaCorrientePersonasDetalleService.Monto_NombreCol]);
                    }

                    impuestoId = new decimal[montoPorImpuesto.Count];
                    monto = new decimal[montoPorImpuesto.Count];

                    indiceAux = 0;
                    montoVerificacion = 0;
                    foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                    {
                        impuestoId[indiceAux] = (decimal)par.Key;
                        monto[indiceAux] = (decimal)par.Value / Math.Max(ctactePersona.Credito, ctactePersona.Debito) * documentoRecargoRow.MONTO_ORIGEN;

                        montoVerificacion += monto[indiceAux];

                        indiceAux++;
                    }

                    if (Math.Round(documentoRecargoRow.MONTO_ORIGEN, 4) != Math.Round(montoVerificacion, 4))
                        throw new Exception("Error en CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + documentoRecargoRow.MONTO_ORIGEN + ".");
                    #endregion Calcular monto por tipo de impuesto

                    #region AgregarDebito
                    //Ingresar el debito
                    ctactePersona.Debito += documentoRecargoRow.MONTO_ORIGEN; //quitar esta linea cuando AgregarDebito utilice orientacion a objeto
                    CuentaCorrientePersonasService.AgregarDebito(ctactePersona.PersonaId,
                                                ctactePersona.Id.Value,
                                                Definiciones.CuentaCorrienteConceptos.DebitoPorPago,
                                                Definiciones.CuentaCorrienteValores.Efectivo, //Se agrega efectivo por completar el dato simplemente
                                                cabeceraRow.CASO_ID,
                                                recargos[j].MonedaId,
                                                recargos[j].Cotizacion,
                                                impuestoId,
                                                monto,
                                                string.Empty,
                                                cabeceraRow.FECHA,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                Definiciones.Error.Valor.EnteroPositivo,
                                                recargos[j].Id.Value,
                                                sesion);
                    #endregion AgregarDebito

                    #region Registrar el recargo en ctacte_recargos
                    Hashtable camposRecargo = new Hashtable();
                    camposRecargo.Add(CuentaCorrienteRecargosService.CasoOrigenId_NombreCol, cabeceraRow.CASO_ID);
                    camposRecargo.Add(CuentaCorrienteRecargosService.Cotizacion_NombreCol, recargos[j].Cotizacion);
                    camposRecargo.Add(CuentaCorrienteRecargosService.AplicacionDcoumentoDocId_NombreCol, recargos[j].AplicacionDcoumentoDocId);
                    camposRecargo.Add(CuentaCorrienteRecargosService.AplicacionDcoumentoDocReId_NombreCol, recargos[j].Id.Value);
                    camposRecargo.Add(CuentaCorrienteRecargosService.Fecha_NombreCol, DateTime.Now);
                    camposRecargo.Add(CuentaCorrienteRecargosService.FuncionarioId_NombreCol, cabeceraRow.FUNCIONARIO_ID);
                    camposRecargo.Add(CuentaCorrienteRecargosService.MonedaId_NombreCol, recargos[j].MonedaId);
                    camposRecargo.Add(CuentaCorrienteRecargosService.Monto_NombreCol, recargos[j].Monto);
                    camposRecargo.Add(CuentaCorrienteRecargosService.PersonaId_NombreCol, cabeceraRow.PERSONA_DOCUMENTOS_ID);
                    camposRecargo.Add(CuentaCorrienteRecargosService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                    camposRecargo.Add(CuentaCorrienteRecargosService.TipoRecargo_NombreCol, recargos[j].TipoRecargo);

                    //Si no se emite la factura entonces todavia no se define la caja de sucursal
                    if (!cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                        camposRecargo.Add(CuentaCorrienteRecargosService.CtacteCajaSucursalId_NombreCol, cabeceraRow.CTACTE_CAJA_SUCURSAL_ID);

                    if (recargos[j].TipoRecargo == Definiciones.TipoRecargo.GastoCobranza)
                        camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, Articulos.ArticulosService.GetImpuestoId(articuloGastoCobranza));
                    else if (recargos[j].TipoRecargo == Definiciones.TipoRecargo.InteresPunitorio)
                        camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, Articulos.ArticulosService.GetImpuestoId(articuloInteresPunitorio));
                    else if (recargos[j].TipoRecargo == Definiciones.TipoRecargo.Mora)
                        camposRecargo.Add(CuentaCorrienteRecargosService.ImpuestoId_NombreCol, Articulos.ArticulosService.GetImpuestoId(articuloMora));

                    decimal ctacteRecargoId = CuentaCorrienteRecargosService.Guardar(camposRecargo, sesion);
                    #endregion Registrar el recargo en ctacte_recargos

                    if (!cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                    {
                        detallesFactura = new Hashtable[1];
                        detallesFactura[0] = new Hashtable();

                        detallesFactura[0][FacturasClienteDetalleService.CtacteRecargoId_NombreCol] = ctacteRecargoId;

                        if (recargos[j].TipoRecargo == Definiciones.TipoRecargo.GastoCobranza)
                        {
                            detallesFactura[0][FacturasClienteDetalleService.ArticuloId_NombreCol] = articuloGastoCobranza;
                            detallesFactura[0][FacturasClienteDetalleService.Observacion_NombreCol] = "Gasto de Cobranza " + Traducciones.Caso + " Nº" + cabeceraRow.CASO_ID;
                        }
                        else if (recargos[j].TipoRecargo == Definiciones.TipoRecargo.InteresPunitorio)
                        {
                            detallesFactura[0][FacturasClienteDetalleService.ArticuloId_NombreCol] = articuloInteresPunitorio;
                            detallesFactura[0][FacturasClienteDetalleService.Observacion_NombreCol] = "Interés Punitorio " + Traducciones.Caso + " Nº" + cabeceraRow.CASO_ID;
                        }
                        else if (recargos[j].TipoRecargo == Definiciones.TipoRecargo.Mora)
                        {
                            detallesFactura[0][FacturasClienteDetalleService.ArticuloId_NombreCol] = articuloMora;
                            detallesFactura[0][FacturasClienteDetalleService.Observacion_NombreCol] = "Mora " + Traducciones.Caso + " Nº" + cabeceraRow.CASO_ID;
                        }
                        else
                        {
                            throw new Exception("NotasCreditoPersonaAplicacionesService.ConfirmarDocumentos. Tipo de recargo no implementado.");
                        }

                        if (documentoRecargoRow.MONEDA_ID == recargos[j].MonedaId)
                            detallesFactura[0][FacturasClienteDetalleService.TotalNeto_NombreCol] = recargos[j].Monto;
                        else
                            detallesFactura[0][FacturasClienteDetalleService.TotalNeto_NombreCol] = recargos[j].Monto / recargos[j].Cotizacion * cabeceraRow.COTIZACION;

                        NotasCreditoPersonaAplicacionesService.CrearFacturaComoComprobante(cabeceraRow, detallesFactura, sesion);
                    }
                }
                #endregion Crear los recargos relacionados al documento
            }

        }
        #endregion ConfirmarDocumentos

        #region ConfirmarDetalles
        /// <summary>
        /// Confirmars the detalles.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal ConfirmarDetalles(decimal nc_aplicacion_id, SessionService sesion)
        {
            DataTable dtCtactePersonaPrincipal;
            string clausulas;

            clausulas = NotasCreditoPersonaAplicacionValoresService.VistaAplicaiconDocumentoId_NombreCol + " = " + nc_aplicacion_id.ToString();
            DataTable dtNotaCreditoAplicacionValores = NotasCreditoPersonaAplicacionValoresService.GetNotaCreditoAplicacionValoresInfoCompleta(clausulas);
            decimal montoTotal = 0;

            //Obtenemos los valores agregados en la nota de crédito aplicación
            APLICACION_DOCUMENTOSRow cabeceraRow = sesion.Db.APLICACION_DOCUMENTOSCollection.GetByPrimaryKey(nc_aplicacion_id);
            clausulas = NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol + "=" + cabeceraRow.ID;
            APLICACION_DOCUMEN_VAL_INFO_CORow[] rows = sesion.Db.APLICACION_DOCUMEN_VAL_INFO_COCollection.GetAsArray(clausulas, string.Empty);

            //Realizar acciones por cada tipo de valor
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].TIPO == Definiciones.TipoComprobanteAplicable.Persona)
                {
                    if (rows[i].IsCTACTE_PERSONA_IDNull)
                        continue;
                    int ctacteFlujoId = decimal.ToInt32(rows[i].FLUJO_ID);
                    switch (ctacteFlujoId)
                    {
                        case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                            //Debe afectarse el saldo del anticipo
                            //e incluirse a la cuenta corriente
                            //Debe incluirse la aplicacion del anticipo a la caja
                            DataTable dtAnticipoPersona;

                            //Se obtiene la cabecera del anticipo
                            dtAnticipoPersona = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + rows[i].CASO_ID, string.Empty, sesion);

                            //Se agrega el credito para disminuir el debito del anticipo
                            CuentaCorrientePersonasService.AgregarCredito(cabeceraRow.PERSONA_VALORES_ID,
                                                         rows[i].CTACTE_PERSONA_ID,
                                                         Definiciones.CuentaCorrienteConceptos.CreditoPorPago,
                                                         cabeceraRow.CASO_ID,
                                                         rows[i].MONEDA_ID,
                                                         rows[i].COTIZACION_MONEDA,
                                                         new decimal[] { Definiciones.Impuestos.Exenta },
                                                         new decimal[] { rows[i].MONTO_ORIGEN },
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
                                                         cabeceraRow.ID,
                                                         rows[i].ID,
                                                         Definiciones.Error.Valor.EnteroPositivo,
                                                         1,
                                                         1,
                                                         sesion);

                            //Se afecta el saldo en la cabecera del anticipo
                            AnticiposPersonaService.DisminuirSaldoDisponible((decimal)dtAnticipoPersona.Rows[0][AnticiposPersonaService.Id_NombreCol], rows[i].MONTO_ORIGEN, false, sesion);


                            //Debe convertirse si la moneda del valor es distinta a la moneda principal del pago
                            if (rows[i].MONEDA_ID.Equals(cabeceraRow.MONEDA_ID))
                            {
                                montoTotal += rows[i].MONTO_ORIGEN;
                            }
                            else
                            {
                                montoTotal += rows[i].MONTO_ORIGEN / rows[i].COTIZACION_MONEDA * (decimal)dtAnticipoPersona.Rows[0][AnticiposPersonaService.CotizacionMoneda_NombreCol];
                            }
                            break;

                        case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                            //Debe afectarse el saldo de la NC
                            //e incluirse a la cuenta corriente
                            DataTable dtNotaCreditoPersona;

                            //Se obtiene la cabecera del anticipo
                            dtNotaCreditoPersona = NotasCreditoPersonaService.GetNotaCreditoPersonaPorCasoDataTable2(rows[i].CASO_ID, sesion);

                            //Se obtiene el movimiento principal de la cuenta corriente

                            DataTable dtCtactePersonaDet;
                            System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                            decimal[] impuestoId, monto;
                            int indiceAux;
                            decimal montoVerificacion, montoAux;
                            var moneda = new MonedasService(cabeceraRow.MONEDA_ID, sesion);

                            #region Calcular monto por tipo de impuesto
                            dtCtactePersonaDet = CuentaCorrientePersonasDetalleService.GetCuentaCorrientePersonasDetalleDataTable(rows[i].CTACTE_PERSONA_ID, sesion);

                            for (int j = 0; j < dtCtactePersonaDet.Rows.Count; j++)
                            {
                                // monto que se paga por el porcentaje en que participa el impuesto dentro del total
                                montoAux = rows[i].MONTO_ORIGEN * (decimal)dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.Monto_NombreCol] / (decimal)dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.MontoTotal_NombreCol];

                                if (montoPorImpuesto.Contains(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]))
                                    montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] = (decimal)montoPorImpuesto[dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol]] + montoAux;
                                else
                                    montoPorImpuesto.Add(dtCtactePersonaDet.Rows[j][CuentaCorrientePersonasDetalleService.ImpuestoId_NombreCol], montoAux);
                            }

                            impuestoId = new decimal[montoPorImpuesto.Count];
                            monto = new decimal[montoPorImpuesto.Count];

                            indiceAux = 0;
                            montoVerificacion = 0;
                            foreach (System.Collections.DictionaryEntry par in montoPorImpuesto)
                            {
                                impuestoId[indiceAux] = (decimal)par.Key;
                                monto[indiceAux] = (decimal)par.Value;

                                montoVerificacion += (decimal)par.Value;

                                indiceAux++;
                            }

                            if (Math.Round(rows[i].MONTO_ORIGEN, moneda.CantidadDecimales) != Math.Round(montoVerificacion, moneda.CantidadDecimales))
                                throw new Exception("Error en NotasCreditoPersonaAplicacionesService.ConfirmarDetalles(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + rows[i].MONTO_ORIGEN + ".");
                            #endregion Calcular monto por tipo de impuesto

                            //Se agrega el credito para disminuir el debito de la NC
                            CuentaCorrientePersonasService.AgregarCredito(cabeceraRow.PERSONA_VALORES_ID,
                                                         rows[i].CTACTE_PERSONA_ID,
                                                         Definiciones.CuentaCorrienteConceptos.CreditoPorPago,
                                                         cabeceraRow.CASO_ID,
                                                         rows[i].MONEDA_ID_DETALLE,
                                                         rows[i].COTIZACION_DETALLE,
                                                         impuestoId,
                                                         monto,
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
                                                         rows[i].APLICACION_DOCUMENTO_ID,
                                                         rows[i].ID,
                                                         Definiciones.Error.Valor.EnteroPositivo,
                                                         1,
                                                         1,
                                                         sesion);

                            //Se afecta el saldo en la cabecera de la NC
                            NotasCreditoPersonaService.DisminuirSaldoDisponible((decimal)dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.Id_NombreCol], rows[i].MONTO_ORIGEN, false, sesion);


                            //Debe convertirse si la moneda del valor es distinta a la moneda principal del pago
                            if (rows[i].MONEDA_ID.Equals(cabeceraRow.MONEDA_ID))
                            {
                                montoTotal += rows[i].MONTO_ORIGEN;
                            }
                            else
                            {
                                montoTotal += rows[i].MONTO_ORIGEN / rows[i].COTIZACION_MONEDA * (decimal)dtNotaCreditoPersona.Rows[0][NotasCreditoPersonaService.CotizacionMoneda_NombreCol];
                            }
                            break;

                        default: throw new Exception("Error. El tipo de valor indefinido.");
                    }
                }
                else
                {
                    if (!rows[i].IsCTACTE_PROVEEDOR_IDNull)
                    {
                        decimal deudaMovimiento = CuentaCorrienteProveedoresService.GetDeudaDeMovimiento(rows[i].CTACTE_PROVEEDOR_ID, sesion);

                        if (Math.Round(rows[i].MONTO_ORIGEN, 4) > Math.Round(deudaMovimiento, 4))
                            throw new Exception("No pueden descontarse " + rows[i].MONTO_ORIGEN + " ya que el movimiento actualmente tiene una deuda de " + deudaMovimiento + ".");


                        CuentaCorrienteProveedoresService.AgregarDebito(rows[i].PROVEEDOR_ID,
                                        rows[i].CTACTE_PROVEEDOR_ID,
                                        Definiciones.CuentaCorrienteConceptos.DebitoPorFlujo,
                                        Definiciones.CuentaCorrienteValores.OrdenDePago,
                                        cabeceraRow.CASO_ID,
                                        rows[i].MONEDA_ID_DETALLE,
                                        rows[i].MONTO_ORIGEN,
                                        string.Empty,
                                        DateTime.Now,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        Definiciones.Error.Valor.EnteroPositivo,
                                        cabeceraRow.ID,
                                        rows[i].ID,
                                        sesion);


                        deudaMovimiento = CuentaCorrienteProveedoresService.GetDeudaTotal(rows[i].CTACTE_PROVEEDOR_ID, sesion);

                        //Cerrar la FC de Proveedor si el saldo es cero
                        if (Math.Round(deudaMovimiento, 4) == 0)
                        {
                            DataTable dtCtacteProv = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(CuentaCorrienteProveedoresService.Id_NombreCol + " = " + rows[i].CTACTE_PROVEEDOR_ID, string.Empty, sesion);
                            int flujoId = int.Parse(rows[i].FLUJO_ID.ToString());
                            string msg = string.Empty;
                            bool exitoCasoAsociado = false;
                            switch (flujoId)
                            {
                                case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                    exitoCasoAsociado = (new FacturasProveedorService()).ProcesarCambioEstado(rows[i].CASO_ID, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                    if (exitoCasoAsociado)
                                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(rows[i].CASO_ID, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de Compensación de Deudas " + cabeceraRow.CASO_ID + " al estado APROBADO.", sesion);
                                    if (exitoCasoAsociado)
                                        (new FacturasProveedorService()).EjecutarAccionesLuegoDeCambioEstado(rows[i].CASO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);

                                    if (!exitoCasoAsociado)
                                        throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(), FC Proveedor. " + msg + ".");
                                    break;
                                case Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR:
                                    exitoCasoAsociado = (new NotasDebitoProveedorService()).ProcesarCambioEstado(rows[i].CASO_ID, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                    if (exitoCasoAsociado)
                                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(rows[i].CASO_ID, Definiciones.EstadosFlujos.Cerrado, "Transición automática por paso de Compensación de Deudas " + cabeceraRow.CASO_ID + " al estado APROBADO.", sesion);
                                    if (exitoCasoAsociado)
                                        (new NotasDebitoProveedorService()).EjecutarAccionesLuegoDeCambioEstado(rows[i].CASO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);
                                    break;

                                    if (!exitoCasoAsociado)
                                        throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(), ND Proveedor. " + msg + ".");
                                    break;
                                case Definiciones.FlujosIDs.CREDITOS_PROVEEDOR:
                                    exitoCasoAsociado = (new CreditosProveedorService()).ProcesarCambioEstado(rows[i].CASO_ID, Definiciones.EstadosFlujos.Cerrado, false, out msg, sesion);
                                    if (exitoCasoAsociado)
                                        (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(rows[i].CASO_ID, Definiciones.EstadosFlujos.Cerrado, "Transición automática por deuda finiquitada.", sesion);
                                    if (exitoCasoAsociado)
                                        (new NotasDebitoProveedorService()).EjecutarAccionesLuegoDeCambioEstado(rows[i].CASO_ID, Definiciones.EstadosFlujos.Cerrado, sesion);

                                    if (!exitoCasoAsociado)
                                        throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(), Crédito Proveedor. " + msg + ".");
                                    break;
                                default:
                                    throw new Exception("Error en OrdenesPagoService.EjecutarAccionesLuegoDeCambioEstado(). Flujo no implementado para pago a proveedor.");
                            }
                        }
                    }

                }


            }

            return montoTotal;
        }
        #endregion ConfirmarDetalles

        #region Tiene Detalles
        public static bool NotaCreditoAplicacionTieneDetalles(decimal NotaCreditoAplicacionId)
        {
            using (SessionService session = new SessionService())
            {
                string clausulas = NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol + " = " + NotaCreditoAplicacionId.ToString();
                string clausulas2 = NotasCreditoPersonaAplicacionValoresService.AplicacionDocumentoId_NombreCol + " = " + NotaCreditoAplicacionId.ToString();

                if (NotasCreditoPersonaAplicacionDocumentosService.GetNotaCreditoAplicacionDocumentosInfoCompleta(clausulas).Rows.Count > 0)
                    return true;
                if (NotasCreditoPersonaAplicacionValoresService.GetNotaCreditoAplicacionValoresInfoCompleta(clausulas2).Rows.Count > 0)
                    return true;
                return false;

            }
        }
        #endregion Tiene Detalles

        #region Generar Numero Comprobante
        public string GenerarNumeroComprobante(decimal caso_id)
        {
            decimal numero;
            return GenerarNumeroComprobante(caso_id, out numero);
        }
        #endregion Generar Numero Comprobante

        #region Generar Nro. de Comprobante
        public static string GenerarNumeroComprobante(decimal caso_id, out decimal numero_actual)
        {
            using (SessionService sesion = new SessionService())
            {
                APLICACION_DOCUMENTOSRow cabeceraRow = sesion.Db.APLICACION_DOCUMENTOSCollection.GetByCASO_ID(caso_id)[0];
                string nroComprobante = string.Empty;
                numero_actual = Definiciones.IdNull;
                if (cabeceraRow.IsAUTONUMERACION_IDNull)
                {
                    throw new Exception("Debe indicarse el talonario o un número de comprobante manual.");
                }

                //Si no existe un nro. de comprobante se crea.
                if (cabeceraRow.NRO_COMPROBANTE == null)
                {
                    if (!AutonumeracionesService.FuncionarioPuedeUsar(cabeceraRow.AUTONUMERACION_ID, cabeceraRow.FUNCIONARIO_ID, sesion))
                        throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");
                    
                    nroComprobante = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, out numero_actual, sesion);

                    if (GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, nroComprobante, sesion))
                    {
                        throw new Exception("Ya existe una factura con el mismo número de comprobante.");
                    }
                }

                //Controlar que se logro asignar una numeracion
                if (nroComprobante.Equals(""))
                {
                    throw new Exception("No se pudo asignar una numeración válida");
                }

                return nroComprobante;
            }
        }

        #endregion Generar Nro. de Comprobante

        #region GetExisteNroComprobante
        private static bool GetExisteNroComprobante(decimal notaCredito_id, decimal autonumeracion_id, string nro_comprobante, SessionService sesion)
        {
            bool existe = false;
            string clausulas = string.Empty;

            /* string clausulas = FacturasClienteService.VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID; // Esta línea corresponde al flujo Facturas de Clientes.
             * No encontré el equivalente para el flujo de Notas de Crédito Personas.
             */

            if (!autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                clausulas += NotasCreditoPersonaService.AutonumeracionId_NombreCol + " = " + autonumeracion_id;
            }

            clausulas += " and " + NotasCreditoPersonaService.NroComprobante_NombreCol + " = '" + nro_comprobante + "' " +
                         " and " + NotasCreditoPersonaService.Id_NombreCol + " <> " + notaCredito_id;

            NOTAS_CREDITO_PERSONA_INF_COMPRow[] rows = sesion.Db.NOTAS_CREDITO_PERSONA_INF_COMPCollection.GetAsArray(clausulas, string.Empty);

            existe = rows.Length > 0;

            return existe;
        }
        #endregion GetExisteNroComprobante

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
            }
        }

        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, SessionService sesion)
        {
            bool exito = false;
            APLICACION_DOCUMENTOSRow row = new APLICACION_DOCUMENTOSRow();

            try
            {
                SucursalesService sucursal = new SucursalesService();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol].ToString()),
                                                          int.Parse(Definiciones.FlujosIDs.APLICACION_DOCUMENTOS.ToString()),
                                                          int.Parse(sesion.Usuario_Id.ToString()),
                                                          SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));

                    row.ID = sesion.Db.GetSiguienteSecuencia("APLICACION_DOCUMENTOS_SQC");
                    row.FECHA = DateTime.Now;
                    row.TOTAL_DOCUMENTOS = (decimal)campos[NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol];
                    row.TOTAL_VALORES = (decimal)campos[NotasCreditoPersonaAplicacionesService.TotalValores_NombreCol];
                    row.USUARIO_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.UsuarioId_NombreCol];

                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                }
                else
                {
                    row = sesion.Db.APLICACION_DOCUMENTOSCollection.GetByPrimaryKey((decimal)campos[NotasCreditoPersonaAplicacionesService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                if (row.SUCURSAL_ID != (decimal)campos[NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol])
                {
                    if (SucursalesService.EstaActivo((decimal)campos[NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol]))
                    {
                        row.SUCURSAL_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.SucursalId_NombreCol];
                        CasosService.ActualizarSucursal(row.CASO_ID, row.SUCURSAL_ID, sesion);
                    }
                    else
                        throw new System.Exception("La sede se encuentra inactiva.");
                }

                if (campos.Contains(NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol))
                    row.FUNCIONARIO_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.FuncionarioId_NombreCol];
                else
                    throw new System.Exception("Debe indicar el funcionario");

                if (row.PERSONA_DOCUMENTOS_ID != (decimal)campos[NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol])
                {
                    if (PersonasService.EstaActivo((decimal)campos[NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol]))
                        row.PERSONA_DOCUMENTOS_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol];
                    else
                        throw new System.Exception("La persona se encuentra inactiva.");
                }
                
                if (campos.Contains(NotasCreditoPersonaAplicacionesService.AutonumeracionReciboId_NombreCol))
                    row.AUTONUMERACION_RECIBO_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.AutonumeracionReciboId_NombreCol];

                if (campos.Contains(NotasCreditoPersonaAplicacionesService.NroReciboManual_NombreCol))
                    row.NRO_RECIBO_MANUAL = (string)campos[NotasCreditoPersonaAplicacionesService.NroReciboManual_NombreCol];

                if (row.PERSONA_VALORES_ID != (decimal)campos[NotasCreditoPersonaAplicacionesService.PersonaValoresId_NombreCol])
                {
                    if (PersonasService.EstaActivo((decimal)campos[NotasCreditoPersonaAplicacionesService.PersonaValoresId_NombreCol]))
                        row.PERSONA_VALORES_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.PersonaValoresId_NombreCol];
                    else
                        throw new System.Exception("La persona se encuentra inactiva.");
                }

                row.NRO_COMPROBANTE = (string)campos[NotasCreditoPersonaAplicacionesService.NroComprobante_NombreCol];
                row.NRO_COMPROBANTE_EXTERNO = (string)campos[NotasCreditoPersonaAplicacionesService.NroComprobanteExterno_NombreCol];
                row.TOTAL_DOCUMENTOS = (decimal)campos[NotasCreditoPersonaAplicacionesService.TotalDocumentos_NombreCol];
                row.TOTAL_VALORES = (decimal)campos[NotasCreditoPersonaAplicacionesService.TotalValores_NombreCol];

                //Si cambia, se verifica que este activo
                if (campos.Contains(NotasCreditoPersonaAplicacionesService.AutonumeracionId_NombreCol))
                {
                    if (row.IsAUTONUMERACION_IDNull || !row.AUTONUMERACION_ID.Equals((decimal)campos[NotasCreditoPersonaAplicacionesService.AutonumeracionId_NombreCol]))
                    {
                        if (!AutonumeracionesService.EstaActivo((decimal)campos[NotasCreditoPersonaAplicacionesService.AutonumeracionId_NombreCol]))
                            throw new Exception("El talonario se encuentra inactivo");
                        row.AUTONUMERACION_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.AutonumeracionId_NombreCol];
                    }
                }
                else
                {
                    row.IsAUTONUMERACION_IDNull = true;
                }

                if (!MonedasService.EstaActivo((decimal)campos[NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol]))
                {
                    throw new System.Exception("La moneda se encuentra inactiva.");
                }
                else
                {
                    row.MONEDA_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.MonedaId_NombreCol];

                    row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, row.FECHA, sesion);

                    // Si no existe una cotización definida para la fecha, intentar con la fecha de creación del caso
                    if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        DateTime fecha = (DateTime)CasosService.GetCasoPorId(Convert.ToDecimal(caso_id)).FECHA_CREACION;
                        row.COTIZACION = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_ID, fecha, sesion);
                    }

                    if (row.COTIZACION.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("Debe actualizarse la cotización de la moneda.");
                }

                row.CONSOLIDACION_DEUDA = campos[NotasCreditoPersonaAplicacionesService.ConsolidacionDeuda_NombreCol].ToString();

                if (campos.Contains(NotasCreditoPersonaAplicacionesService.NCAutonumeracionId_NombreCol))
                {
                    row.NC_AUTONUMERACION_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.NCAutonumeracionId_NombreCol];
                }
                if (campos.Contains(NotasCreditoPersonaAplicacionesService.NCCtacteCajaSucursalId_NombreCol))
                {
                    row.NC_CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.NCCtacteCajaSucursalId_NombreCol];
                }
                if (campos.Contains(NotasCreditoPersonaAplicacionesService.NCDepositoId_NombreCol))
                {
                    row.NC_DEPOSITO_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.NCDepositoId_NombreCol];
                }
                if (campos.Contains(NotasCreditoPersonaAplicacionesService.NCNroComprobante_NombreCol))
                {
                    row.NC_NRO_COMPROBANTE = (string)campos[NotasCreditoPersonaAplicacionesService.NCNroComprobante_NombreCol];
                }

                if (campos.Contains(NotasCreditoPersonaAplicacionesService.FCAutonumeracionId_NombreCol))
                {
                    row.FC_AUTONUMERACION_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.FCAutonumeracionId_NombreCol];
                }
                if (campos.Contains(NotasCreditoPersonaAplicacionesService.FCCtacteCajaSucursalId_NombreCol))
                {
                    row.FC_CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.FCCtacteCajaSucursalId_NombreCol];
                }
                if (campos.Contains(NotasCreditoPersonaAplicacionesService.FCDepositoId_NombreCol))
                {
                    row.FC_DEPOSITO_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.FCDepositoId_NombreCol];
                }
                if (campos.Contains(NotasCreditoPersonaAplicacionesService.FCNroComprobante_NombreCol))
                {
                    row.FC_NRO_COMPROBANTE = (string)campos[NotasCreditoPersonaAplicacionesService.FCNroComprobante_NombreCol];
                }

                if (campos.Contains(NotasCreditoPersonaAplicacionesService.Observacion_NombreCol))
                    row.OBSERVACION = (string)campos[NotasCreditoPersonaAplicacionesService.Observacion_NombreCol];

                if (campos.Contains(NotasCreditoPersonaAplicacionesService.CtacteCajaSucursalId_NombreCol))
                    row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[NotasCreditoPersonaAplicacionesService.CtacteCajaSucursalId_NombreCol];
                else
                    row.IsCTACTE_CAJA_SUCURSAL_IDNull = true;

                if (insertarNuevo) sesion.Db.APLICACION_DOCUMENTOSCollection.Insert(row);
                else sesion.Db.APLICACION_DOCUMENTOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                if (!Interprete.EsNullODBNull(row.NRO_RECIBO_MANUAL))
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, row.NRO_RECIBO_MANUAL);
                camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_DOCUMENTOS_ID);
                CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos
                
                exito = true;
            }
            catch
            {
                //Si el caso fue creado el mismo debe borrarse
                if (insertarNuevo && row.CASO_ID > 0)
                {
                    (new CasosService()).Eliminar(row.CASO_ID, sesion);
                    caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    estado_id = string.Empty;
                }

                throw;
            }
            return exito;
        }

        #endregion Guardar

        #region Generar Recibos

        public static decimal GenerarReciboEntregado(Hashtable campos, decimal aplicacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();


                    APLICACION_DOCUMENTOSRow row = sesion.db.APLICACION_DOCUMENTOSCollection.GetByPrimaryKey(aplicacion_id);
                    string anterior = row.ToString();

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, anterior, row.ToString(), sesion);
                    row.CTACTE_RECIBO_ID = CuentaCorrienteRecibosService.Guardar(campos, true, false, Definiciones.Error.Valor.EnteroPositivo, sesion);


                    sesion.db.APLICACION_DOCUMENTOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, anterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                    return row.CTACTE_RECIBO_ID;

                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    return Definiciones.Error.Valor.EnteroPositivo;

                    throw exp;
                }
            }
        }
        #endregion Generar Recibos

        #region Anular Recibos
        public static void AnularRecibo(decimal recibo_id, decimal aplicacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    APLICACION_DOCUMENTOSRow row = sesion.db.APLICACION_DOCUMENTOSCollection.GetByPrimaryKey(aplicacion_id);
                    string anterior = row.ToString();


                    CuentaCorrienteRecibosService.Anular(recibo_id, sesion);


                    row.IsCTACTE_RECIBO_IDNull = true;
                    row.NRO_RECIBO_MANUAL = String.Empty;
                    sesion.db.APLICACION_DOCUMENTOSCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, anterior, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();

                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Anular Recibos

        #region ActualizarRecibo
        public static void ActualizarRecibo(decimal aplicacion_id, decimal recibo_id, string nro_recibo_manual, SessionService sesion)
        {
            APLICACION_DOCUMENTOSRow row = sesion.db.APLICACION_DOCUMENTOSCollection.GetByPrimaryKey(aplicacion_id);
            string anterior = row.ToString();
            row.CTACTE_RECIBO_ID = recibo_id;
            row.NRO_RECIBO_MANUAL = nro_recibo_manual;
            sesion.db.APLICACION_DOCUMENTOSCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, anterior, row.ToString(), sesion);

        }
        #endregion ActualizarRecibo

        #region ObtenerDatosParaListadoEnPantalla
        public static DataTable ObtenerDatosListadoPantalla(string clausulas)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("select ad.caso_id caso, \n");
                    query.Append("       ad.sucursal_abreviatura, \n");
                    query.Append("       ad.persona_codigo_doc, \n");
                    query.Append("       ad.persona_nombre_doc, \n");
                    query.Append("       ad.persona_codigo_val, \n");
                    query.Append("       ad.persona_nombre_val, \n");
                    query.Append("       add.caso_nro_comprobante doc_comprobante, \n");
                    query.Append("       add.caso_id documento_caso_id, \n");
                    query.Append("       add.cuota_numero, \n");
                    query.Append("       adv.caso_id nc_caso_id, \n");
                    query.Append("       adv.caso_nro_comprobante nc_comprobante, \n");
                    query.Append("       add.monto_destino monto_aplicado, \n");
                    query.Append("       add.moneda_id, \n");
                    query.Append("       add.moneda_simbolo, \n");
                    query.Append("       ad.fecha fecha_aplicacion \n");
                    query.Append("  from " + NotasCreditoPersonaAplicacionesService.Nombre_Vista + " ad \n");
                    query.Append("  join " + NotasCreditoPersonaAplicacionDocumentosService.Nombre_Vista + " add on ad.id = add.nc_aplicacion_id \n");
                    query.Append("  join " + NotasCreditoPersonaAplicacionValoresService.Nombre_Vista + " adv on ad.id = adv.nc_aplicacion_id \n");
                    query.Append(" where 1 = 1 \n");
                    if (clausulas.Length > 0)
                        query.Append(clausulas);

                    return sesion.Db.EjecutarQuery(query.ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion ObtenerDatosParaListadoEnPantalla

        #region CrearFacturaComoComprobante
        private static decimal CrearFacturaComoComprobante(APLICACION_DOCUMENTOSRow aplicacion_documento_row, Hashtable[] hashtableDetalles, SessionService sesion)
        {
            //Objetos para crear la factura y los detalles
            FacturasClienteService facturaClienteService = new FacturasClienteService();
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

            if (aplicacion_documento_row.IsFC_AUTONUMERACION_IDNull)
                throw new Exception("Debe indicar el talonario para la Factura.");

            #region Crear cabecera FC
            campos = new System.Collections.Hashtable();
            campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, aplicacion_documento_row.FC_AUTONUMERACION_ID);
            campos.Add(FacturasClienteService.CasoOrigenId_NombreCol, aplicacion_documento_row.CASO_ID);
            campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
            campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CondicionPagoCredito));
            campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, aplicacion_documento_row.COTIZACION);
            campos.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
            campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, aplicacion_documento_row.FECHA);
            campos.Add(FacturasClienteService.Fecha_NombreCol, aplicacion_documento_row.FECHA);
            campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, aplicacion_documento_row.MONEDA_ID);
            campos.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
            campos.Add(FacturasClienteService.Observacion_NombreCol, "Factura creada como comprobante de Planilla de Cobranza caso Nº" + aplicacion_documento_row.CASO_ID);
            campos.Add(FacturasClienteService.PersonaId_NombreCol, aplicacion_documento_row.PERSONA_DOCUMENTOS_ID);
            campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, (decimal)0);
            campos.Add(FacturasClienteService.SucursalId_NombreCol, aplicacion_documento_row.SUCURSAL_ID);
            campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, Definiciones.TipoFactura.Contado);
            campos.Add(FacturasClienteService.VendedorId_NombreCol, aplicacion_documento_row.FUNCIONARIO_ID);
            campos.Add(FacturasClienteService.CtaCteCajaSucursalId_NombreCol, aplicacion_documento_row.CTACTE_CAJA_SUCURSAL_ID);
            #region Obtener el primer deposito activo de la sucursal
            DataTable dtStockDepositoAux = Stock.StockDepositosService.GetStockDepositosDataTable(aplicacion_documento_row.SUCURSAL_ID, true, true);
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
                dtArticulo = ArticulosService.GetArticulosDataTable(Articulos.ArticulosService.Id_NombreCol + " = " + hashtableDetalles[i][FacturasClienteDetalleService.ArticuloId_NombreCol], string.Empty, false, aplicacion_documento_row.SUCURSAL_ID, sesion);
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

            return (decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol];
        }
        #endregion CrearFacturaComoComprobante

        #region ActualizarNumeroDocumentoExterno
        public static void ActualizarNumeroDocumentoExterno(APLICACION_DOCUMENTOSRow aplicacion, out string mensaje, SessionService sesion)
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

        #region GetConsultarNumeroDocumentoExterno
        /// <summary>
        /// Gets the consultar numero documento externo.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="mensaje">The mensaje.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool GetConsultarNumeroDocumentoExterno(APLICACION_DOCUMENTOSRow aplicacion, out string mensaje, SessionService sesion)
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

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "APLICACION_DOCUMENTOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "APLICACION_DOCUMENTOS_INFO_COM"; }
        }

        public static string AutonumeracionId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.AUTONUMERACION_IDColumnName; }
        }

        public static string CasoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.CASO_IDColumnName; }
        }

        public static string Cotizacion_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.COTIZACIONColumnName; }
        }

        public static string CtacteCajaSucursalId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }

        public static string Fecha_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.FECHAColumnName; }
        }

        public static string Id_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.IDColumnName; }
        }

        public static string MonedaId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.MONEDA_IDColumnName; }
        }

        public static string NroComprobante_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroComprobanteExterno_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.NRO_COMPROBANTE_EXTERNOColumnName; }
        }

        public static string PersonaDocumentoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.PERSONA_DOCUMENTOS_IDColumnName; }
        }

        public static string PersonaValoresId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.PERSONA_VALORES_IDColumnName; }
        }

        public static string FuncionarioId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.FUNCIONARIO_IDColumnName; }
        }

        public static string SucursalId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.SUCURSAL_IDColumnName; }
        }

        public static string TotalDocumentos_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.TOTAL_DOCUMENTOSColumnName; }
        }

        public static string TotalValores_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.TOTAL_VALORESColumnName; }
        }

        public static string UsuarioId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.USUARIO_IDColumnName; }
        }
        public static string AutonumeracionReciboId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.AUTONUMERACION_RECIBO_IDColumnName; }
        }
        public static string ReciboId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.CTACTE_RECIBO_IDColumnName; }
        }
        public static string NroReciboManual_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.NRO_RECIBO_MANUALColumnName; }
        }

        public static string ConsolidacionDeuda_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.CONSOLIDACION_DEUDAColumnName; }
        }

        public static string NCAutonumeracionId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.NC_AUTONUMERACION_IDColumnName; }
        }
        public static string NCCtacteCajaSucursalId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.NC_CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string NCDepositoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.NC_DEPOSITO_IDColumnName; }
        }
        public static string NCNroComprobante_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.NC_NRO_COMPROBANTEColumnName; }
        }
        public static string FCAutonumeracionId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.FC_AUTONUMERACION_IDColumnName; }
        }
        public static string FCCtacteCajaSucursalId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.FC_CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string FCDepositoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.FC_DEPOSITO_IDColumnName; }
        }
        public static string FCNroComprobante_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.FC_NRO_COMPROBANTEColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return APLICACION_DOCUMENTOSCollection.OBSERVACIONColumnName; }
        }
        public static string FCCasoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FC_CASO_IDColumnName; }
        }
        public static string MontoNuevaCuota_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.MONTO_NUEVA_CUOTAColumnName; }
        }

        #endregion Tabla

        #region Vista
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.ESTADO_IDColumnName; }
        }

        public static string VistaAutonumeracionId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.AUTONUMERACION_IDColumnName; }
        }

        public static string VistaPersonaDocumentoNombre_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.PERSONA_NOMBRE_DOCColumnName; }
        }

        public static string VistaPersonaValoresCodigo_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.PERSONA_CODIGO_VALColumnName; }
        }

        public static string VistaPersonaDocumentoCodigo_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.PERSONA_NOMBRE_DOCColumnName; }
        }

        public static string VistaPersonaValoresNombre_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.PERSONA_NOMBRE_VALColumnName; }
        }

        public static string VistaCasoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.CASO_IDColumnName; }
        }

        public static string VistaCotizacion_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.COTIZACIONColumnName; }
        }

        public static string VistaFecha_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FECHAColumnName; }
        }

        public static string VistaId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.IDColumnName; }
        }

        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.MONEDA_CADENA_DECIMALESColumnName; }
        }

        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }

        public static string VistadadMonedaId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.MONEDA_IDColumnName; }
        }

        public static string VistaMonedaNombre_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.MONEDA_NOMBREColumnName; }
        }

        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.MONEDA_SIMBOLOColumnName; }
        }

        public static string VistaNroComprobanteNombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.NRO_COMPROBANTEColumnName; }
        }

        public static string VistaDocumentosPersonaId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.PERSONA_DOCUMENTOS_IDColumnName; }
        }

        public static string VistaValoresPersonaId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.PERSONA_VALORES_IDColumnName; }
        }

        public static string VistaFuncionarioId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FUNCIONARIO_IDColumnName; }
        }

        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FUNCIONARIO_CODIGOColumnName; }
        }

        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }

        public static string VistaSucursalId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.SUCURSAL_IDColumnName; }
        }

        public static string VistaTotalDocumentos_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.TOTAL_DOCUMENTOSColumnName; }
        }

        public static string VistaTotalValores_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.TOTAL_VALORESColumnName; }
        }

        public static string VistaUsuarioId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.USUARIO_IDColumnName; }
        }

        public static string VistaUsuarioNombreCompleto_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.USUARIO_NOMBRE_COMPLETOColumnName; }
        }

        public static string VistaUsuario_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.USUARIOColumnName; }
        }

        public static string VistaAutonumeracionReciboCodigo_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.AUTONUMERACION_RECIBO_CODIGOColumnName; }
        }
        public static string VistaReciboNro_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.RECIBO_NUMEROColumnName; }
        }

        public static string VistaConsolidacionDeuda_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.CONSOLIDACION_DEUDAColumnName; }
        }

        public static string VistaNCAutonumeracionId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.NC_AUTONUMERACION_IDColumnName; }
        }
        public static string VistaNCCtacteCajaSucursalId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.NC_CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string VistaNCDepositoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.NC_DEPOSITO_IDColumnName; }
        }
        public static string VistaNCNroComprobante_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.NC_NRO_COMPROBANTEColumnName; }
        }
        public static string VistaFCAutonumeracionId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FC_AUTONUMERACION_IDColumnName; }
        }
        public static string VistaFCCtacteCajaSucursalId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FC_CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string VistaFCDepositoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FC_DEPOSITO_IDColumnName; }
        }
        public static string VistaFCNroComprobante_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FC_NRO_COMPROBANTEColumnName; }
        }
        public static string VistaFCCasoId_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.FC_CASO_IDColumnName; }
        }
        public static string VistaMontoNuevaCuota_NombreCol
        {
            get { return APLICACION_DOCUMENTOS_INFO_COMCollection.MONTO_NUEVA_CUOTAColumnName; }
        }

        #endregion Vista

        #endregion Accessors
    }
}
