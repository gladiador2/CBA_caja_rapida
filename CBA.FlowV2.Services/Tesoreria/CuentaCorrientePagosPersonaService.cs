#region Using
using System;
using System.Collections;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Comercial;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.ToolbarFlujo;
using System.Collections.Generic;
using CBA.FlowV2.Services.NotasCreditoPersona;
using System.Text;
using System.Net;
using System.IO;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.TextosPredefinidos;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class PagosDePersonaService : FlujosServiceBaseWorkaround
    {
        #region Webservices
        public static MensajeExterno[] GetMensajesExternos(decimal persona_id)
        {
            MensajeExterno[] mensajes = new MensajeExterno[0];

            switch (Convert.ToInt32(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.Cliente)))
            {
                case Definiciones.Clientes.Electroban:
                    mensajes = GetMensajesExternos_9(persona_id);
                    break;
            }
            return mensajes;
        }

        private static MensajeExterno[] GetMensajesExternos_9(decimal persona_id)
        {
            PersonasService persona = new PersonasService(persona_id);

            Dictionary<string, object> valor = new Dictionary<string, object>() 
            { 
                { "metodo", "generarComunicadoClienteV2" },
                { "cedula", persona.NumeroDocumento },
                { "origen", "INTRANET" },
                { "disparador", "COBRANZA" },
            };

            string valoresJson = JsonUtil.Serializar(valor);
            byte[] dataStream = Encoding.UTF8.GetBytes(valoresJson);

            WebRequest req = WebRequest.Create("http://192.168.1.216:82/wsAppClientes/ws.php");
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = valoresJson.Length;

            Stream newStream = req.GetRequestStream();
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader readStream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string respuesta = readStream.ReadToEnd();
            var resultado = JsonUtil.Deserializar<MensajeExterno>(respuesta);
            resp.Close();
            readStream.Close();

            if (resultado != null)
                return new MensajeExterno[] { resultado };
            else
                return new MensajeExterno[0];
        }
        #endregion Webservices

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.PAGO_DE_PERSONAS;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var cabecera = (PagosDePersonaService)caso_cabecera;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, cabecera.TextoPredefinidoId);
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
            mensaje = string.Empty;
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                CTACTE_PAGOS_PERSONARow cabeceraRow = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetByCASO_ID(caso_id)[0];
                DataTable dtDetalles = CuentaCorrientePagosPersonaDetalleService.GetCuentaCorrientePagosPersonaDetalleInfoCompleta(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);
                DataTable dtDocumentos = CuentaCorrientePagosPersonaDocumentoService.GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);

                if (cabeceraRow.ESTADO.Equals(Definiciones.Estado.Inactivo))
                    throw new Exception("Error. El caso fue borrado.");

                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Controlar que el pago no este confirmado
                    //Se anula el recibo si fue emitido
                    exito = true;
                    revisarRequisitos = true;

                    //Para prevenir posibles inconsistencias
                    PagosDePersonaService.LimpiarDatosPorPagoFallido(ref cabeceraRow, dtDetalles, dtDocumentos, sesion);

                    if (cabeceraRow.PAGO_CONFIRMADO != Definiciones.SiNo.No)
                    {
                        exito = false;
                        mensaje = "El pago ya fue confirmado, no puede anularse el caso.";
                    }

                    for (int i = 0; i < dtDocumentos.Rows.Count; i++)
                    {
                        //Desbloquear los documentos si no son recargo
                        if (Interprete.EsNullODBNull(dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol]))
                            CuentaCorrientePersonasService.SetBloqueado((decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol], false, sesion);
                    }

                    //Se anula el recibo si fue emitido
                    if (exito && !cabeceraRow.IsCTACTE_RECIBO_IDNull)
                    {
                        DataTable dtCobranzaDetalle = PlanillaCobranzaDetallesService.GetPlanillaDetalles(PlanillaCobranzaDetallesService.CasoPagoId_NombreCol + "=" + cabeceraRow.CASO_ID, string.Empty, sesion);
                        if (dtCobranzaDetalle.Rows.Count == 0)
                        {
                            PagosDePersonaService.AnularRecibo(cabeceraRow.ID, sesion);
                        }
                        else
                        {
                            cabeceraRow.IsCTACTE_RECIBO_IDNull = true;
                            decimal planillaDetalleId = decimal.Parse(dtCobranzaDetalle.Rows[0][PlanillaCobranzaDetallesService.Id_NombreCol].ToString());
                            PlanillaCobranzaDetallesService.ActulizarCasoPago(planillaDetalleId, Definiciones.Error.Valor.EnteroPositivo, sesion);
                        }
                    }
                }
                //Borrador a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Controlar que se haya confirmado el pago.
                    exito = true;
                    revisarRequisitos = true;
                    if (dtDocumentos.Rows.Count < 1)
                    {
                        mensaje = "Debe agregar al menos un detalle al pago.";
                        exito = false;
                    }

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    #region Verificar que no se apliquen retenciones de distintos documentos a los pagados en el caso
                    string clausulas = CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + cabeceraRow.ID + " and " +
                                        CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.RetencionIVA;
                    DataTable dtRetenciones = CuentaCorrientePagosPersonaDetalleService.GetCuentaCorrientePagosPersonaDetalleDataTable(clausulas, string.Empty, sesion);
                    clausulas = CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + cabeceraRow.ID;
                    DataTable dtDocs = CuentaCorrientePagosPersonaDocumentoService.GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(clausulas, string.Empty, sesion);
                    List<decimal> casosDocumentos = new List<decimal>();
                    foreach (DataRow row in dtDocs.Rows)
                    {
                        if (!Interprete.EsNullODBNull(row[CuentaCorrientePagosPersonaDocumentoService.VistaCasoId_NombreCol]))
                            casosDocumentos.Add((decimal)row[CuentaCorrientePagosPersonaDocumentoService.VistaCasoId_NombreCol]);
                    }

                    foreach (DataRow retencion in dtRetenciones.Rows)
                    {
                        if (casosDocumentos.Contains((decimal)retencion[CuentaCorrientePagosPersonaDetalleService.RetencionCasoId_NombreCol]))
                            continue;
                        else
                            throw new Exception("No se puede aprobar el caso. Se está intentando realizar una retención sobre un documento que no se está pagando.");
                    }
                    #endregion Verificar que no se apliquen retenciones de distintos documentos a los pagados en el caso

                    #region Confirmar Pago
                    if (cabeceraRow.PAGO_CONFIRMADO != Definiciones.SiNo.Si && exito)
                    {
                        decimal autonumeracionAnticipoId = Definiciones.Error.Valor.EnteroPositivo;
                        decimal autonumeracionReciboId = Definiciones.Error.Valor.EnteroPositivo;
                        decimal nuevoReciboId;
                        string nroRecibo = string.Empty;

                        if (!cabeceraRow.IsAUTONUMERACION_ANTICIPO_IDNull) autonumeracionAnticipoId = cabeceraRow.AUTONUMERACION_ANTICIPO_ID;
                        if (!cabeceraRow.IsAUTONUMERACION_RECIBO_IDNull) autonumeracionReciboId = cabeceraRow.AUTONUMERACION_RECIBO_ID;
                        if (!Interprete.EsNullODBNull(cabeceraRow.CTACTE_RECIBO_NUMERO)) nroRecibo = cabeceraRow.CTACTE_RECIBO_NUMERO;

                        PagosDePersonaService.ConfirmarPago(ref cabeceraRow, autonumeracionReciboId, nroRecibo, cabeceraRow.VUELTO_CONVERTIDO_A_ANTICIPO.Equals(Definiciones.SiNo.Si), autonumeracionAnticipoId, out nuevoReciboId, sesion);
                    }
                    #endregion Confirmar Pago

                    #region Comisiones y desbloquear documentos
                    if (exito)
                    {
                        foreach (DataRow row in dtDocumentos.Rows)
                        {
                            if (!row[CuentaCorrientePagosPersonaDocumentoService.VistaFlujoId_NombreCol].Equals(DBNull.Value))
                            {
                                if ((decimal)row[CuentaCorrientePagosPersonaDocumentoService.VistaFlujoId_NombreCol] == Definiciones.FlujosIDs.FACTURACION_CLIENTE)
                                {
                                    decimal montoPago = (decimal)row[CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];
                                    decimal monedaId = (decimal)row[CuentaCorrientePagosPersonaDocumentoService.MonedaId_NombreCol];
                                    decimal casoId = (decimal)row[CuentaCorrientePagosPersonaDocumentoService.VistaCasoId_NombreCol];
                                    DataRow facturaClienteRow = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoId_NombreCol + " = " + casoId, string.Empty, sesion).Rows[0];
                                    decimal totalFactura = (decimal)facturaClienteRow[FacturasClienteService.TotalMontoBruto_NombreCol];
                                    decimal totalImpuestoFactura = (decimal)facturaClienteRow[FacturasClienteService.TotalMontoImpuesto_NombreCol];
                                    decimal proporcionPago = montoPago / totalFactura;
                                    decimal montoSinImpuesto = montoPago - totalImpuestoFactura * proporcionPago;

                                    #region Comision Cobrador
                                    if (montoSinImpuesto != 0)
                                    {
                                        decimal cobradorId = Definiciones.Error.Valor.EnteroPositivo;
                                        if (!cabeceraRow.IsFUNCIONARIO_COBRADOR_EXTER_IDNull)
                                        {
                                            cobradorId = cabeceraRow.FUNCIONARIO_COBRADOR_EXTER_ID;
                                        }
                                        else
                                        {
                                            cobradorId = cabeceraRow.FUNCIONARIO_COBRADOR_ID;
                                        }

                                        System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                        campos.Add(FuncionariosMontosCobradosService.CasoId_NombreCol, casoId);
                                        campos.Add(FuncionariosMontosCobradosService.Cotizacion_NombreCol, (decimal)row[CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol]);
                                        campos.Add(FuncionariosMontosCobradosService.Fecha_NombreCol, DateTime.Now);
                                        campos.Add(FuncionariosMontosCobradosService.FuncionarioId_NombreCol, cobradorId);
                                        campos.Add(FuncionariosMontosCobradosService.MonedaId_NombreCol, monedaId);
                                        campos.Add(FuncionariosMontosCobradosService.Monto_NombreCol, montoSinImpuesto);
                                        FuncionariosMontosCobradosService.Guardar(campos, true, sesion);
                                    }
                                    #endregion Comision Cobrador

                                    #region Comision Vendedor
                                    string estrategiaComisionVendedor = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.EstrategiaComision, sesion);
                                    if (estrategiaComisionVendedor.Equals(Definiciones.TiposComision.ComisionPorCobro))
                                    {
                                        DataTable detalles = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + facturaClienteRow[FacturasClienteService.Id_NombreCol], FacturasClienteDetalleService.Id_NombreCol, sesion);
                                        decimal vendedorComisionistaAux = Definiciones.Error.Valor.EnteroPositivo;

                                        System.Collections.Hashtable totalesComision = new System.Collections.Hashtable();
                                        foreach (DataRow detalle in detalles.Rows)
                                        {
                                            //Se toma el vendedor comisionista del detalle o de la cabecera
                                            if (!detalle[FacturasClienteDetalleService.VendedorComisionistaId_NombreCol].Equals(DBNull.Value))
                                                vendedorComisionistaAux = (decimal)detalle[FacturasClienteDetalleService.VendedorComisionistaId_NombreCol];
                                            else if (!facturaClienteRow[FacturasClienteService.VendedorId_NombreCol].Equals(DBNull.Value))
                                                vendedorComisionistaAux = (decimal)facturaClienteRow[FacturasClienteService.VendedorId_NombreCol];
                                            else
                                                vendedorComisionistaAux = Definiciones.Error.Valor.EnteroPositivo;


                                            if (!totalesComision.Contains(vendedorComisionistaAux))
                                                totalesComision[vendedorComisionistaAux] = (decimal)0;

                                            totalesComision[vendedorComisionistaAux] = (decimal)totalesComision[vendedorComisionistaAux] + (decimal)detalle[FacturasClienteDetalleService.MontoComisionVenta_NombreCol];
                                        }

                                        foreach (decimal vendedorComisionistaId in totalesComision.Keys)
                                        {
                                            if ((decimal)totalesComision[vendedorComisionistaId] * proporcionPago == 0 || vendedorComisionistaId == Definiciones.Error.Valor.EnteroPositivo)
                                                continue;

                                            FuncionariosComisionesService funcionarioComisiones = new FuncionariosComisionesService();
                                            System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                            campos.Add(FuncionariosComisionesService.CasoId_NombreCol, casoId);
                                            campos.Add(FuncionariosComisionesService.Cobrado_NombreCol, Definiciones.SiNo.No);
                                            campos.Add(FuncionariosComisionesService.Cotizacion_NombreCol, (decimal)facturaClienteRow[FacturasClienteService.CotizacionDestino_NombreCol]);
                                            campos.Add(FuncionariosComisionesService.CtactePagoPersonaDocId_NombreCol, row[CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol]);
                                            campos.Add(FuncionariosComisionesService.Fecha_NombreCol, DateTime.Now);
                                            campos.Add(FuncionariosComisionesService.FuncionarioId_NombreCol, vendedorComisionistaId);
                                            campos.Add(FuncionariosComisionesService.MonedaId_NombreCol, (decimal)facturaClienteRow[FacturasClienteService.MonedaDestinoId_NombreCol]);
                                            campos.Add(FuncionariosComisionesService.Monto_NombreCol, (decimal)totalesComision[vendedorComisionistaId] * proporcionPago);
                                            campos.Add(FuncionariosComisionesService.TipoComision_NombreCol, Definiciones.TiposComision.ComisionPorCobro);
                                            campos.Add(FuncionariosComisionesService.TipoFuncionario_NombreCol, Definiciones.TipoFuncionarioComision.Vendedor);
                                            funcionarioComisiones.Guardar(campos, true, sesion);
                                        }
                                    }
                                    #endregion Comision Vendedor
                                }
                            }

                            //Desbloquear los documentos si no son recargo
                            if (Interprete.EsNullODBNull(row[CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol]))
                            {
                                CuentaCorrientePersonasService.SetBloqueado((decimal)row[CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol], false, sesion);
                            }
                        }
                    }
                    #endregion Comisiones y desbloquear documentos
                }
                //Aprobado a Borrador
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Deshacer los efectos de aprobar (confirmar) el pago
                    //No se pueden borrar las comisiones al vendedor y cobrador porque no queda FK para individualizar
                    exito = true;
                    revisarRequisitos = true;

                    PagosDePersonaService.LimpiarDatosPorPagoFallido(ref cabeceraRow, dtDetalles, dtDocumentos, sesion);
                }
                //Aprobado a Abierto
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Aprobado) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Abierto))
                {
                    //Acciones
                    //inactivar las compensaciones que pudieron hacerse antes.
                    exito = true;
                    revisarRequisitos = true;

                    string clausulas;

                    DataTable dtEntrantes, dtSalientes;

                    clausulas = CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagosPersonaId_NombreCol + " = " + cabeceraRow.ID + " and " +
                                CuentaCorrientePagosPersonaCompensacionEntradaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    dtEntrantes = CuentaCorrientePagosPersonaCompensacionEntradaService.GetCuentaCorrientePagosPersonaCompensacionEntradaDataTable(clausulas, string.Empty);
                    for (int i = 0; i < dtEntrantes.Rows.Count; i++)
                        CuentaCorrientePagosPersonaCompensacionEntradaService.Inactivar((decimal)dtEntrantes.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.Id_NombreCol], sesion);

                    clausulas = CuentaCorrientePagosPersonaCompensacionSalidaService.CtactePagoPersonaId_NombreCol + " = " + cabeceraRow.ID + " and " +
                                CuentaCorrientePagosPersonaCompensacionSalidaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                    dtSalientes = CuentaCorrientePagosPersonaCompensacionSalidaService.GetCuentaCorrientePagosPersonaCompensacionSalidaDataTable(clausulas, string.Empty);
                    for (int i = 0; i < dtSalientes.Rows.Count; i++)
                        CuentaCorrientePagosPersonaCompensacionSalidaService.Inactivar((decimal)dtSalientes.Rows[i][CuentaCorrientePagosPersonaCompensacionSalidaService.Id_NombreCol], sesion);

                }
                //Abierto a Aprobado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Abierto) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                {
                    //Acciones
                    //Validar que existe una caja abierta
                    //Validar que los documentos salientes sean de monto mayor o igual a los entrantes
                    //
                    //Inactivar los pagos sobre documentos que egresan.
                    //Deshacer los efectos de haber confirmado el pago sobre los documentos que ahora se inactivan
                    //Solo pueden deshacerse pagos sobre movimientos que no sean recargos ya facturados
                    //
                    //Agregar los pagos sobre documentos que ingresan.
                    //Realizar los efectos de confirmadar el pago de lo que ahora se ingresa
                    //Generar las facturas por los recargos agregados
                    exito = true;
                    revisarRequisitos = true;

                    DataTable dtCompensacionSaliente = CuentaCorrientePagosPersonaCompensacionSalidaService.GetCuentaCorrientePagosPersonaCompensacionSalidaDataTable(CuentaCorrientePagosPersonaCompensacionSalidaService.CtactePagoPersonaId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                    DataTable dtCompensacionEntrante = CuentaCorrientePagosPersonaCompensacionEntradaService.GetCuentaCorrientePagosPersonaCompensacionEntradaDataTable(CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagosPersonaId_NombreCol + " = " + cabeceraRow.ID, CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePersonaId_NombreCol);
                    Hashtable[] hashDetallesFactura;
                    Hashtable camposDocumento;
                    decimal[] idCreados = new decimal[dtCompensacionEntrante.Rows.Count];
                    decimal montoFactura, decimalAux, ctacteCajaSucursalId = Definiciones.Error.Valor.EnteroPositivo;
                    int contador = 0;
                    decimal totalEgresado, totalIngresado, totalVuelto;

                    //Validar que existe una caja abierta
                    ctacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(cabeceraRow.SUCURSAL_ID, cabeceraRow.FUNCIONARIO_COBRADOR_ID);

                    //Validar que los documentos salientes sea de monto mayor o igual a los entrantes
                    totalIngresado = CuentaCorrientePagosPersonaCompensacionEntradaService.GetTotal(cabeceraRow.ID);
                    totalEgresado = CuentaCorrientePagosPersonaCompensacionSalidaService.GetTotal(cabeceraRow.ID);
                    totalVuelto = totalEgresado - totalIngresado;
                    if (totalVuelto < 0)
                        throw new Exception("El monto de los documentos que ingresan no puede ser mayor al de los que egresan.");

                    cabeceraRow.MONTO_TOTAL_VUELTO += totalVuelto;

                    if (cabeceraRow.VUELTO_CONVERTIDO_A_ANTICIPO.Equals(Definiciones.SiNo.Si))
                    {
                        if (sesion.Usuario_Funcionario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        {
                            //Se obtiene el id de la caja de sucursal abierta
                            ctacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(cabeceraRow.SUCURSAL_ID, sesion.Usuario_Funcionario_id);
                        }
                    }

                    for (int i = 0; i < dtCompensacionSaliente.Rows.Count; i++)
                    {
                        //Inactivar
                        CuentaCorrientePagosPersonaDocumentoService.Inactivar((decimal)dtCompensacionSaliente.Rows[i][CuentaCorrientePagosPersonaCompensacionSalidaService.CtactePagoPersonaDocId_NombreCol], sesion);

                        //Borrar de la cuenta corriente de recargos
                        CuentaCorrienteRecargosService.BorrarDesdePago((decimal)dtCompensacionSaliente.Rows[i][CuentaCorrientePagosPersonaCompensacionSalidaService.CtactePagoPersonaDocId_NombreCol], sesion);

                        //Deshacer pago
                        CuentaCorrientePersonasService.DeshacerAgregarDebito((decimal)dtCompensacionSaliente.Rows[i][CuentaCorrientePagosPersonaCompensacionSalidaService.CtactePagoPersonaDocId_NombreCol], Definiciones.Error.Valor.EnteroPositivo, sesion);
                    }

                    for (int i = 0; i < dtCompensacionEntrante.Rows.Count; i++)
                    {
                        #region Agregar el documento al pago
                        camposDocumento = new Hashtable();

                        //Si es un documento
                        if (!Interprete.EsNullODBNull(dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePersonaId_NombreCol]))
                        {
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol, cabeceraRow.ID);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePersonaId_NombreCol]);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.MonedaId_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.MonedaId_NombreCol]);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.Monto_NombreCol]);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.CotizacionMoneda_NombreCol]);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.Observacion_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.Observacion_NombreCol]);
                        }

                        //Si es un recargo
                        if (!Interprete.EsNullODBNull(dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagoPersonaRecargoId_NombreCol]))
                        {
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol, cabeceraRow.ID);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePagoPersonaRecargoId_NombreCol]);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.MonedaId_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.MonedaId_NombreCol]);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.CotizacionMoneda_NombreCol]);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.Monto_NombreCol]);
                            camposDocumento.Add(CuentaCorrientePagosPersonaDocumentoService.Observacion_NombreCol, dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.Observacion_NombreCol]);
                        }

                        //Guardar los datos
                        idCreados[contador] = CuentaCorrientePagosPersonaDocumentoService.Guardar(camposDocumento, false, sesion);

                        //Si es un documento se actualiza la compensacion entrante para apuntar al documento creado
                        if (!Interprete.EsNullODBNull(dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.CtactePersonaId_NombreCol]))
                            CuentaCorrientePagosPersonaCompensacionEntradaService.SetCtactePagoPersonaDocumento((decimal)dtCompensacionEntrante.Rows[i][CuentaCorrientePagosPersonaCompensacionEntradaService.Id_NombreCol], idCreados[contador], sesion);

                        contador++;
                        #endregion Agregar el documento al pago
                    }

                    //Hacer el pago
                    CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentosCompensacion(cabeceraRow.ID, idCreados, !cabeceraRow.IsFC_CLIENTE1_COMP_AUTON_IDNull, out hashDetallesFactura, out decimalAux, sesion);

                    montoFactura = 0;
                    for (int i = 0; i < hashDetallesFactura.Length; i++)
                        montoFactura += (decimal)hashDetallesFactura[i][FacturasClienteDetalleService.TotalNeto_NombreCol];

                    if (montoFactura > 0)
                    {
                        if (ctacteCajaSucursalId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("No existe una caja abierta en la sucursal " + SucursalesService.GetNombreSucursal(cabeceraRow.SUCURSAL_ID) + ".");

                        PagosDePersonaService.CrearFacturaComoComprobante(cabeceraRow, ctacteCajaSucursalId, hashDetallesFactura, sesion);
                    }

                    CuentaCorrientePagosPersonaDocumentoService.AccionesPosterioresAConfirmarDocumentos(cabeceraRow.ID, sesion);

                    #region convertir Vuelto a Anticipo
                    //Si se debe, convertir el vuelto a Anticipo
                    if (cabeceraRow.VUELTO_CONVERTIDO_A_ANTICIPO.Equals(Definiciones.SiNo.Si) && totalVuelto > 0)
                    {
                        decimal casoAnticipoId;
                        string mensajeAnticipo;

                        DataTable dtCaja = CuentaCorrienteCajaService.GetCtacteCajaDataTable2(CuentaCorrienteCajaService.CtactePagoPersonaId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                        if (dtCaja.Rows.Count > 0)
                            ctacteCajaSucursalId = (decimal)dtCaja.Rows[0][CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol];

                        if (ctacteCajaSucursalId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            throw new Exception("No existe una caja abierta en la sucursal " + SucursalesService.GetNombreSucursal(cabeceraRow.SUCURSAL_ID) + ".");

                        //Crear el caso de anticipo
                        casoAnticipoId = CrearCasoAnticipoPersona(ref cabeceraRow, sesion, cabeceraRow.AUTONUMERACION_ANTICIPO_ID, ctacteCajaSucursalId);

                        //Se actualizan los datos 
                        #region Actualizar datos en tabla casos
                        Hashtable camposCaso = new Hashtable();
                        camposCaso.Add(CasosService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                        if (!Interprete.EsNullODBNull(cabeceraRow.CTACTE_RECIBO_NUMERO))
                            camposCaso.Add(CasosService.NroComprobante_NombreCol, cabeceraRow.CTACTE_RECIBO_NUMERO);
                        CasosService.ActualizarCampos(casoAnticipoId, camposCaso, sesion);
                        #endregion Actualizar datos en tabla casos

                        //Se avanza el caso hasta aprobado
                        AnticiposPersonaService anticipoPersona = new AnticiposPersonaService();
                        CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();

                        exito = anticipoPersona.ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Pendiente, false, out mensajeAnticipo, sesion);
                        if (exito)
                            exito = ToolbarFlujo.ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática por vuelto de pago convertido a Anticipo.", sesion);
                        if (exito)
                            anticipoPersona.EjecutarAccionesLuegoDeCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Pendiente, sesion);
                        if (!exito)
                            throw new Exception("Error en PagosDePersonaService.ProcesarCambioEstado al pasar el anticipo creado como vuelto a pendiente. " + mensajeAnticipo + ".");

                        exito = anticipoPersona.ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Aprobado, false, out mensajeAnticipo, sesion);
                        if (exito)
                            exito = ToolbarFlujo.ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Aprobado, "Transición automática por vuelto de pago convertido a Anticipo.", sesion);
                        if (exito)
                            anticipoPersona.EjecutarAccionesLuegoDeCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Aprobado, sesion);
                        if (!exito)
                            throw new Exception("Error en PagosDePersonaService.ProcesarCambioEstado al pasar el anticipo creado como vuelto a aprobado. " + mensajeAnticipo + ".");

                        cabeceraRow.CASO_ANTICIPO_ID = casoAnticipoId;
                        sesion.Db.CTACTE_PAGOS_PERSONACollection.Update(cabeceraRow);
                    }
                    #endregion convertir Vuelto a Anticipo

                }

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {
                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.Db.CTACTE_PAGOS_PERSONACollection.Update(cabeceraRow);
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
            return string.Empty;
        }

        #endregion Implementacion de metodos abstract

        #region GetPagosDePersonaInfoCompleta
        /// <summary>
        /// Gets the cuenta corriente pagos persona info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPagosDePersonaInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPagosDePersonaInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetPagosDePersonaInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_PAGOS_PERSONA_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetPagosDePersonaInfoCompleta

        #region GetPagosDePersonaDataTable
        /// <summary>
        /// Gets the cuenta corriente fondos fijos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPagosDePersonaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPagosDePersonaDataTable(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the pagos de persona data table2.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetPagosDePersonaDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_PAGOS_PERSONACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetPagosDePersonaDataTable

        #region GetPago
        /// <summary>
        /// Gets the pago.
        /// </summary>
        /// <param name="pago_id">The pago_id.</param>
        /// <returns></returns>
        public static CTACTE_PAGOS_PERSONARow GetPagoDePersona(decimal pago_id, SessionService sesion)
        {
            string clausulas = PagosDePersonaService.Id_NombreCol + " = " + pago_id + " and " +
                               PagosDePersonaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            CTACTE_PAGOS_PERSONARow[] rows = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetAsArray(clausulas, PagosDePersonaService.Id_NombreCol);
            if (rows.Length > 0)
                return rows[0];
            else
                throw new Exception("Pago no encontrado.");
        }
        #endregion

        #region GetPagoIdSegunCasoId
        public static decimal GetPagoIdSegunCasoId(decimal caso_id)
        {
            try
            {
                string clausula = PagosDePersonaService.CasoId_NombreCol + " = " + caso_id;
                using (SessionService sesion = new SessionService())
                {
                    CTACTE_PAGOS_PERSONARow row = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetRow(clausula);
                    return row.ID;
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetPagoIdSegunCasoId

        #region GetPagoPersonaSegunNroComprobante 
        public static DataTable GetPagoPersonaSegunNroComprobante(String reciboId, String reciboNro, String pagoId)//xxxxx
        {
            try
            {
                string clausula = PagosDePersonaService.AutonumeracionReciboId_NombreCol + " = " + reciboId+
                    " and " + PagosDePersonaService.CtacteReciboNumero_NombreCol + " = '" + reciboNro+"'"+
                    " and " + PagosDePersonaService.Id_NombreCol + " <> " + pagoId;
                using (SessionService sesion = new SessionService())
                {
                    return sesion.Db.CTACTE_PAGOS_PERSONACollection.GetAsDataTable(clausula, String.Empty);
                }
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetPagoPersonaSegunNroComprobante

        #region GetCtacteReciboId
        /// <summary>
        /// Sets the ctacte recibo identifier.
        /// </summary>
        /// <param name="pago_persona_id">The pago_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetCtacteReciboId(decimal caso_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONARow[] row = sesion.db.CTACTE_PAGOS_PERSONACollection.GetByCASO_ID(caso_id);
            if (row[0].IsCTACTE_RECIBO_IDNull) return Definiciones.Error.Valor.EnteroPositivo;
            else return row[0].CTACTE_RECIBO_ID;
        }
        public static decimal GetCtacteReciboId(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCtacteReciboId(caso_id, sesion);
            }
        }
        #endregion GetCtacteReciboId

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, ref decimal pago_id, SessionService sesion)
        {
            try
            {
                UsuariosService usuario = new UsuariosService();
                if (usuario.GetPersonaId(sesion.Usuario_Id) == (decimal)campos[PagosDePersonaService.PersonaId_NombreCol])
                    throw new Exception("El usuario no puede crear un caso de si mismo.");

                CTACTE_PAGOS_PERSONARow filaPagosPersona = new CTACTE_PAGOS_PERSONARow();
                SucursalesService sucursal = new SucursalesService();
                string valorAnterior = string.Empty;

                decimal cotizacionSistema, cotizacionFormulario, porcentajeVariacionPermitido;
                bool banderaActualizarRecibo = false;

                if (insertarNuevo)
                {
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[PagosDePersonaService.SucursalId_NombreCol].ToString()),
                                                          Definiciones.FlujosIDs.PAGO_DE_PERSONAS,
                                                          int.Parse(sesion.Usuario_Id.ToString()),
                                                          SessionService.GetClienteIP());
                    filaPagosPersona.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    filaPagosPersona.ID = sesion.Db.GetSiguienteSecuencia("ctacte_pagos_persona_sqc");
                    filaPagosPersona.USUARIO_CARGA_ID = sesion.Usuario_Id;
                    filaPagosPersona.VUELTO_CONVERTIDO_A_ANTICIPO = Definiciones.SiNo.No;
                    filaPagosPersona.PAGO_CONFIRMADO = Definiciones.SiNo.No;
                    filaPagosPersona.RECIBO_EMITIR_POR_DOCUMENTOS = Definiciones.SiNo.Si;
                    filaPagosPersona.ESTADO = Definiciones.Estado.Activo;
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    caso_id = filaPagosPersona.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                    pago_id = filaPagosPersona.ID;
                }
                else
                {
                    filaPagosPersona = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetRow(PagosDePersonaService.Id_NombreCol + " = " + campos[PagosDePersonaService.Id_NombreCol]);
                    valorAnterior = filaPagosPersona.ToString();
                }

                if (decimal.Parse(campos[PagosDePersonaService.FuncionarioCobradorId_NombreCol].ToString()) == Definiciones.Error.Valor.EnteroPositivo)
                    throw new Exception("El usuario no se encuentra asociado a un funcionario, por tanto, no puede realizar la cobranza.");

                //Si cambia, se controla que la nueva se encuentre activa
                if (!filaPagosPersona.FUNCIONARIO_COBRADOR_ID.Equals(decimal.Parse(campos[PagosDePersonaService.FuncionarioCobradorId_NombreCol].ToString())))
                {
                    if (!FuncionariosService.EstaActivo(decimal.Parse(campos[PagosDePersonaService.FuncionarioCobradorId_NombreCol].ToString())))
                        throw new System.Exception("El funcionario se encuentra inactivo.");
                    else if (!FuncionariosService.EsCobrador(decimal.Parse(campos[PagosDePersonaService.FuncionarioCobradorId_NombreCol].ToString())))
                        throw new System.Exception("El funcionario no es cobrador.");
                    else if(decimal.Parse(campos[PagosDePersonaService.FuncionarioCobradorId_NombreCol].ToString()) != Definiciones.Error.Valor.EnteroPositivo)
                        filaPagosPersona.FUNCIONARIO_COBRADOR_ID = decimal.Parse(campos[PagosDePersonaService.FuncionarioCobradorId_NombreCol].ToString());
                }

                //Si cambia, se controla que la nueva se encuentre activa
                if (campos.Contains(PagosDePersonaService.FuncionarioCobradorExterId_NombreCol))
                {
                    decimal cobradorExternoId = (decimal)campos[PagosDePersonaService.FuncionarioCobradorExterId_NombreCol];

                    if (!cobradorExternoId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        if (filaPagosPersona.IsFUNCIONARIO_COBRADOR_EXTER_IDNull || !filaPagosPersona.FUNCIONARIO_COBRADOR_EXTER_ID.Equals((decimal)campos[PagosDePersonaService.FuncionarioCobradorExterId_NombreCol]))
                        {
                            if (!FuncionariosService.EstaActivo((decimal)campos[PagosDePersonaService.FuncionarioCobradorExterId_NombreCol]))
                                throw new System.Exception("El funcionario externo se encuentra inactivo.");
                            else if (!FuncionariosService.EsCobrador((decimal)campos[PagosDePersonaService.FuncionarioCobradorExterId_NombreCol]))
                                throw new System.Exception("El funcionario externo no es cobrador.");
                            else
                                filaPagosPersona.FUNCIONARIO_COBRADOR_EXTER_ID = (decimal)campos[PagosDePersonaService.FuncionarioCobradorExterId_NombreCol];

                        }
                    }
                }
                else
                {
                    filaPagosPersona.IsFUNCIONARIO_COBRADOR_EXTER_IDNull = true;
                }

                //Si cambia, se controla que la nueva se encuentre activa
                if (!filaPagosPersona.PERSONA_ID.Equals((decimal)campos[PagosDePersonaService.PersonaId_NombreCol]))
                {
                    if (!PersonasService.EstaActivo((decimal)campos[PagosDePersonaService.PersonaId_NombreCol]))
                        throw new System.Exception("La persona se encuentra inactiva.");
                    else
                        filaPagosPersona.PERSONA_ID = (decimal)campos[PagosDePersonaService.PersonaId_NombreCol];
                }

                //Si cambia, se controla que la nueva se encuentre activa
                if (!filaPagosPersona.SUCURSAL_ID.Equals((decimal)campos[PagosDePersonaService.SucursalId_NombreCol]))
                {
                    if (!SucursalesService.EstaActivo((decimal)campos[PagosDePersonaService.SucursalId_NombreCol]))
                        throw new System.Exception("La sede se encuentra inactiva.");
                    else
                    {
                        filaPagosPersona.SUCURSAL_ID = (decimal)campos[PagosDePersonaService.SucursalId_NombreCol];
                        CasosService.ActualizarSucursal(filaPagosPersona.CASO_ID, filaPagosPersona.SUCURSAL_ID, sesion);
                    }
                }

                //Si cambia, se controla que la nueva se encuentre activa
                if (!filaPagosPersona.MONEDA_ID.Equals(decimal.Parse(campos[PagosDePersonaService.MonedaId_NombreCol].ToString())))
                {
                    if (!MonedasService.EstaActivo(decimal.Parse(campos[PagosDePersonaService.MonedaId_NombreCol].ToString())))
                        throw new System.Exception("La moneda se encuentra inactiva.");
                    else
                        filaPagosPersona.MONEDA_ID = decimal.Parse(campos[PagosDePersonaService.MonedaId_NombreCol].ToString());
                }

                if (campos.Contains(PagosDePersonaService.Fecha_NombreCol))
                    filaPagosPersona.FECHA = (DateTime)campos[PagosDePersonaService.Fecha_NombreCol];
                else
                    filaPagosPersona.FECHA = DateTime.Now;

                if (campos.Contains(PagosDePersonaService.TextoPredefinidoId_NombreCol))
                    filaPagosPersona.TEXTO_PREDEFINIDO_ID = (decimal)campos[PagosDePersonaService.TextoPredefinidoId_NombreCol];

                cotizacionSistema = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(filaPagosPersona.SUCURSAL_ID), filaPagosPersona.MONEDA_ID, filaPagosPersona.FECHA, sesion);
                cotizacionFormulario = decimal.Parse(campos[PagosDePersonaService.CotizacionMoneda_NombreCol].ToString());
                porcentajeVariacionPermitido = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CotizacionPorcentajeMaximoPuedeDiferir);

                if (cotizacionSistema.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizarse la cotización de la moneda.");

                if (cotizacionFormulario > cotizacionSistema * (100 + porcentajeVariacionPermitido) / 100 ||
                   cotizacionFormulario < cotizacionSistema * (100 - porcentajeVariacionPermitido) / 100)
                {
                    throw new Exception("La cotización indicada excede el margen permitido respecto a la cotización del sistema.");
                }

                filaPagosPersona.COTIZACION_MONEDA = cotizacionFormulario;

                //Se utilizan la moneda y cotizacion principal de la cabecera
                //como moneda y cotizacion del vuelto
                filaPagosPersona.MONEDA_TOTAL_VUELTO_ID = filaPagosPersona.MONEDA_ID;
                filaPagosPersona.COTIZACION_MONEDA_TOTAL_VUELTO = filaPagosPersona.COTIZACION_MONEDA;

                filaPagosPersona.VUELTO_CONVERTIDO_A_ANTICIPO = (string)campos[PagosDePersonaService.VueltoConvertidoAAnticipo_NombreCol];

                //Si el valor cambia debe recalcularse el total del recibo
                if (!Interprete.EsNullODBNull(filaPagosPersona.RECIBO_EMITIR_POR_DOCUMENTOS)
                    && filaPagosPersona.RECIBO_EMITIR_POR_DOCUMENTOS != (string)campos[PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol])
                {
                    filaPagosPersona.RECIBO_EMITIR_POR_DOCUMENTOS = (string)campos[PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol];
                    banderaActualizarRecibo = true;
                }

                if (campos.Contains(PagosDePersonaService.AutonumeracionAnticipoId_NombreCol))
                    filaPagosPersona.AUTONUMERACION_ANTICIPO_ID = decimal.Parse(campos[PagosDePersonaService.AutonumeracionAnticipoId_NombreCol].ToString());
                else
                    filaPagosPersona.IsAUTONUMERACION_ANTICIPO_IDNull = true;

                if (campos.Contains(PagosDePersonaService.AutonumeracionReciboId_NombreCol))
                {
                    filaPagosPersona.AUTONUMERACION_RECIBO_ID = decimal.Parse(campos[PagosDePersonaService.AutonumeracionReciboId_NombreCol].ToString());

                    if (AutonumeracionesService.EsGeneracionManual(filaPagosPersona.AUTONUMERACION_RECIBO_ID))
                    {
                        DataTable dtRecibos = PagosDePersonaService.GetPagoPersonaSegunNroComprobante(campos[PagosDePersonaService.AutonumeracionReciboId_NombreCol].ToString(), campos[PagosDePersonaService.CtacteReciboNumero_NombreCol].ToString(), campos[PagosDePersonaService.Id_NombreCol].ToString()); //xxxxxx.(clausulas, sesion);
                                            
                        if (dtRecibos.Rows.Count > 0)
							throw new Exception("Número de recibo duplicado: "+campos[PagosDePersonaService.CtacteReciboNumero_NombreCol]);

                        if (campos.Contains(PagosDePersonaService.CtacteReciboNumero_NombreCol))
                        {
                            filaPagosPersona.CTACTE_RECIBO_NUMERO = (string)campos[PagosDePersonaService.CtacteReciboNumero_NombreCol];
                            if (!filaPagosPersona.IsCTACTE_RECIBO_IDNull)
                                CuentaCorrienteRecibosService.ActualizarNumeroRecibo(filaPagosPersona.CTACTE_RECIBO_ID, filaPagosPersona.CTACTE_RECIBO_NUMERO, sesion);
                        }
                    }
                    else
                    {
                        filaPagosPersona.CTACTE_RECIBO_NUMERO = string.Empty;
                    }
                }
                else
                {
                    filaPagosPersona.IsAUTONUMERACION_RECIBO_IDNull = true;
                }

                if (campos.Contains(PagosDePersonaService.FCCliente1CompAutonId_NombreCol))
                    filaPagosPersona.FC_CLIENTE1_COMP_AUTON_ID = (decimal)campos[PagosDePersonaService.FCCliente1CompAutonId_NombreCol];
                else
                    filaPagosPersona.IsFC_CLIENTE1_COMP_AUTON_IDNull = true;

                if (campos.Contains(PagosDePersonaService.FCCliente2CompAutonId_NombreCol))
                    filaPagosPersona.FC_CLIENTE2_COMP_AUTON_ID = (decimal)campos[PagosDePersonaService.FCCliente2CompAutonId_NombreCol];
                else
                    filaPagosPersona.IsFC_CLIENTE2_COMP_AUTON_IDNull = true;

                if (campos.Contains(PagosDePersonaService.CasoAsociadoId_NombreCol))
                    filaPagosPersona.CASO_ASOCIADO_ID = (decimal)campos[PagosDePersonaService.CasoAsociadoId_NombreCol];

                if (insertarNuevo)
                {
                    sesion.Db.CTACTE_PAGOS_PERSONACollection.Insert(filaPagosPersona);
                }
                else
                {
                    CTACTE_PAGOS_PERSONARow filaVieja = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(filaPagosPersona.ID);
                    trigger.BeforeUpdate(ref filaPagosPersona, filaVieja, sesion);
                    sesion.Db.CTACTE_PAGOS_PERSONACollection.Update(filaPagosPersona);
                }
                LogCambiosService.LogDeRegistro(Nombre_Tabla, filaPagosPersona.ID, valorAnterior, filaPagosPersona.ToString(), sesion);

                if (banderaActualizarRecibo)
                {
                    DataTable dtPago = GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + filaPagosPersona.ID, string.Empty, sesion);
                    CuentaCorrienteRecibosService.ActualizarTotal(dtPago, sesion);
                }

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, filaPagosPersona.FECHA);
                if (!Interprete.EsNullODBNull(filaPagosPersona.CTACTE_RECIBO_NUMERO))
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, filaPagosPersona.CTACTE_RECIBO_NUMERO);
                camposCaso.Add(CasosService.FuncionarioId_NombreCol, filaPagosPersona.FUNCIONARIO_COBRADOR_ID);
                camposCaso.Add(CasosService.PersonaId_NombreCol, filaPagosPersona.PERSONA_ID);
                CasosService.ActualizarCampos(filaPagosPersona.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns>Id de la cabecera</returns>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id, ref decimal pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, ref pago_id, sesion);
                    sesion.CommitTransaction();

                    return exito;
                }
                catch (Exception e)
                {
                    sesion.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Guardar

        #region ConfirmarPago
        /// <summary>
        /// Confirmars the pago.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="autonumeracion_recibo_id">The autonumeracion_recibo_id.</param>
        /// <param name="numero_recibo">The numero_recibo.</param>
        /// <param name="convertir_vuelto_a_anticipo">if set to <c>true</c> [convertir_vuelto_a_anticipo].</param>
        /// <param name="autonumeracion_anticipo_id">The autonumeracion_anticipo_id.</param>
        /// <param name="nuevo_recibo_id">The nuevo_recibo_id.</param>
        /// <returns></returns>
        public static string ConfirmarPago(decimal ctacte_pago_persona_id, decimal autonumeracion_recibo_id, string numero_recibo, bool convertir_vuelto_a_anticipo, decimal autonumeracion_anticipo_id, out decimal nuevo_recibo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PAGOS_PERSONARow rowPago = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(ctacte_pago_persona_id);
                string nroRecibo = PagosDePersonaService.ConfirmarPago(ref rowPago, autonumeracion_recibo_id, numero_recibo, convertir_vuelto_a_anticipo, autonumeracion_anticipo_id, out nuevo_recibo_id, sesion);
                sesion.db.CTACTE_PAGOS_PERSONACollection.Update(rowPago);
                return nroRecibo;
            }
        }

        /// <summary>
        /// Confirmars the pago.
        /// </summary>
        /// <param name="rowPago">The row pago.</param>
        /// <param name="autonumeracion_recibo_id">The autonumeracion_recibo_id.</param>
        /// <param name="numero_recibo">The numero_recibo.</param>
        /// <param name="convertir_vuelto_a_anticipo">if set to <c>true</c> [convertir_vuelto_a_anticipo].</param>
        /// <param name="autonumeracion_anticipo_id">The autonumeracion_anticipo_id.</param>
        /// <param name="nuevo_recibo_id">The nuevo_recibo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns>Numero de recibo</returns>
        public static string ConfirmarPago(ref CTACTE_PAGOS_PERSONARow rowPago, decimal autonumeracion_recibo_id, string numero_recibo, bool convertir_vuelto_a_anticipo, decimal autonumeracion_anticipo_id, out decimal nuevo_recibo_id, SessionService sesion)
        {
            try
            {
                CuentaCorrientePagosPersonaDetalleService ctactePagosDetalle = new CuentaCorrientePagosPersonaDetalleService();
                CuentaCorrientePagosPersonaDocumentoService ctactePagosDocumento = new CuentaCorrientePagosPersonaDocumentoService();
                string valorAnterior = rowPago.ToString();
                Hashtable campos;
                Hashtable[] hashDetallesRecibo, hashDetallesFactura1, hashDetallesFactura2;
                decimal montoVuelto, totalValores, totalDocumentos, montoRecibo, montoFactura1, montoFactura2;
                decimal ctacteCajaSucursalId, numeroSecuencia = 0;
                string nroRecibo, strMensajeError;
                bool banderaReciboActualizarTotal = false;

                //no se le puede cobrar a las personas que estan en judicial, a menos que se cuente con el permiso para hacerlo
                if (PersonasService.EnJudicialStatic(rowPago.PERSONA_ID) && !RolesService.Tiene("pagos de persona pagar en judicial"))
                    throw new Exception(Traducciones.La_persona_esta_en_judicial_Resolucion(new PersonasService(rowPago.PERSONA_ID)));

                rowPago.PAGO_CONFIRMADO = Definiciones.SiNo.Si;
                rowPago.FECHA_CONFIRMACION = DateTime.Now;

                //Se obtiene el id de la caja de sucursal abierta
                ctacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(rowPago.SUCURSAL_ID, rowPago.FUNCIONARIO_COBRADOR_ID);

                //Si no se encontro una abierta, se lanza la excepcion
                if (ctacteCajaSucursalId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("No existe una caja abierta.");

                //Si se emitira un anticipo, verificar que se selecciono
                //un talonario
                if (convertir_vuelto_a_anticipo && autonumeracion_anticipo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe especificar el talonario del Anticipo para emitir uno.");

                if (!PagosDePersonaService.ValidarTotales(rowPago.ID, rowPago.MONEDA_ID, out strMensajeError, sesion))
                    throw new Exception(strMensajeError);

                if (!CuentaCorrientePagosPersonaDocumentoService.VerificarDeudaDocumentos(rowPago.ID, out strMensajeError, sesion))
                    throw new Exception(strMensajeError);

                //Se utiliza la misma sesion para no insertar a medias
                //en caso que haya una excepcion en algun sub metodo
                totalValores = CuentaCorrientePagosPersonaDetalleService.ConfirmarDetalles(rowPago.ID, sesion);
                CuentaCorrientePagosPersonaDocumentoService.ConfirmarDocumentos(rowPago.ID,
                                                                                ctacteCajaSucursalId,
                                                                                !rowPago.IsFC_CLIENTE1_COMP_AUTON_IDNull,
                                                                                !rowPago.IsFC_CLIENTE2_COMP_AUTON_IDNull,
                                                                                out hashDetallesRecibo,
                                                                                out hashDetallesFactura1,
                                                                                out hashDetallesFactura2,
                                                                                out totalDocumentos,
                                                                                sesion);

                montoRecibo = 0;
                for (int i = 0; i < hashDetallesRecibo.Length; i++)
                    montoRecibo += (decimal)hashDetallesRecibo[i][FacturasClienteDetalleService.TotalNeto_NombreCol];

                montoFactura1 = 0;
                for (int i = 0; i < hashDetallesFactura1.Length; i++)
                    montoFactura1 += (decimal)hashDetallesFactura1[i][FacturasClienteDetalleService.TotalNeto_NombreCol];

                montoFactura2 = 0;
                for (int i = 0; i < hashDetallesFactura2.Length; i++)
                    montoFactura2 += (decimal)hashDetallesFactura2[i][FacturasClienteDetalleService.TotalNeto_NombreCol];

                //Calcular el vuelto
                montoVuelto = totalValores - totalDocumentos;

                if (montoVuelto > 0)
                    rowPago.MONTO_TOTAL_VUELTO = montoVuelto;
                else
                    rowPago.MONTO_TOTAL_VUELTO = 0;

                rowPago.MONEDA_TOTAL_VUELTO_ID = rowPago.MONEDA_ID;

                //Si se debera emitir un recibo, se verifica que haya una autonumeracion seleccionada
                if (hashDetallesRecibo.Length > 0 && autonumeracion_recibo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("El pago contiene documentos crédito pero no se seleccionó un talonario de recibo.");

                //Ingresar el vuelto con monto negativo a la caja
                if (rowPago.MONTO_TOTAL_VUELTO > 0)
                {
                    campos = new System.Collections.Hashtable();
                    campos.Add(CuentaCorrienteCajaService.Fecha_NombreCol, rowPago.FECHA);
                    campos.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, rowPago.MONEDA_TOTAL_VUELTO_ID);
                    campos.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, rowPago.COTIZACION_MONEDA_TOTAL_VUELTO);
                    campos.Add(CuentaCorrienteCajaService.Monto_NombreCol, -rowPago.MONTO_TOTAL_VUELTO); //Monto negativo por ser un egreso para la caja
                    campos.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                    campos.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario.ID);
                    campos.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, rowPago.SUCURSAL_ID);
                    campos.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, rowPago.FUNCIONARIO_COBRADOR_ID);
                    campos.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.Vuelto);
                    campos.Add(CuentaCorrienteCajaService.CtactePagoPersonaId_NombreCol, rowPago.ID);
                    campos.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, ctacteCajaSucursalId);
                    CuentaCorrienteCajaService.Guardar(campos, sesion);
                }

                rowPago.VUELTO_CONVERTIDO_A_ANTICIPO = convertir_vuelto_a_anticipo ? Definiciones.SiNo.Si : Definiciones.SiNo.No;

                nuevo_recibo_id = Definiciones.Error.Valor.EnteroPositivo;
                nroRecibo = string.Empty;

                bool excluirValores = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PagoPersonasReciboExcluirValores, sesion).Equals(Definiciones.SiNo.Si);
                decimal total = CuentaCorrientePagosPersonaDetalleService.CalcularValores(excluirValores, rowPago.ID, rowPago.MONEDA_ID, rowPago.COTIZACION_MONEDA, sesion);

                if (!(excluirValores && rowPago.RECIBO_EMITIR_POR_DOCUMENTOS.Equals(Definiciones.SiNo.No) && total == 0))
                {
                    if (hashDetallesRecibo.Length > 0)
                    {
                        #region Crear recibo si aun no estaba generado
                        if (rowPago.IsCTACTE_RECIBO_IDNull)
                        {
                            if (autonumeracion_recibo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                throw new Exception("El pago contiene documentos crédito pero no se seleccionó un talonario de recibo.");

                            campos = new System.Collections.Hashtable();
                            if (string.IsNullOrEmpty(numero_recibo))//si no existe numero de recibo, generar
                            {
                                if (AutonumeracionesService.EsGeneracionManual(rowPago.AUTONUMERACION_RECIBO_ID))
                                {
                                    nroRecibo = "Vacio - " + rowPago.ID;
                                }
                                else
                                {
                                    if (!AutonumeracionesService.FuncionarioPuedeUsar(autonumeracion_recibo_id, rowPago.FUNCIONARIO_COBRADOR_ID, sesion) && !rowPago.IsFUNCIONARIO_COBRADOR_EXTER_IDNull && !AutonumeracionesService.FuncionarioPuedeUsar(autonumeracion_recibo_id, rowPago.FUNCIONARIO_COBRADOR_EXTER_ID, sesion))
                                        throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");

                                    nroRecibo = AutonumeracionesService.GetSiguienteNumero2(autonumeracion_recibo_id, out numeroSecuencia, sesion);
                                }
                            }
                            else//si existe numero de recibo, verificar si no se duplica
                            {
                                string clausulas = CuentaCorrienteRecibosService.AutonumeracionId_NombreCol + " = " + autonumeracion_recibo_id + " and " +
                                                   CuentaCorrienteRecibosService.NroComprobante_NombreCol + " = '" + numero_recibo + "'";
                                DataTable dtRecibos = CuentaCorrienteRecibosService.GetCtacteReciboDataTable(clausulas, sesion);
                                if (dtRecibos.Rows.Count > 0)
                                    throw new Exception("Número de recibo duplicado.");
                                numeroSecuencia = Definiciones.Error.Valor.EnteroPositivo;

                                nroRecibo = numero_recibo;
                            }

                            campos.Add(CuentaCorrienteRecibosService.AutonumeracionId_NombreCol, autonumeracion_recibo_id);
                            campos.Add(CuentaCorrienteRecibosService.Estado_NombreCol, Definiciones.Estado.Activo);
                            campos.Add(CuentaCorrienteRecibosService.Fecha_NombreCol, rowPago.FECHA);
                            campos.Add(CuentaCorrienteRecibosService.MonedaId_NombreCol, rowPago.MONEDA_ID);
                            campos.Add(CuentaCorrienteRecibosService.Monto_NombreCol, montoRecibo);
                            campos.Add(CuentaCorrienteRecibosService.NroComprobante_NombreCol, nroRecibo);
                            campos.Add(CuentaCorrienteRecibosService.NroComprobanteSecuencia_NombreCol, numeroSecuencia);
                            campos.Add(CuentaCorrienteRecibosService.PersonaId_NombreCol, rowPago.PERSONA_ID);

                            rowPago.CTACTE_RECIBO_ID = CuentaCorrienteRecibosService.Guardar(campos, true, false, rowPago.ID, sesion);
                            nuevo_recibo_id = rowPago.CTACTE_RECIBO_ID;
                            rowPago.CTACTE_RECIBO_NUMERO = nroRecibo;
                            banderaReciboActualizarTotal = true;
                        }
                        else
                        {
                            nroRecibo = CuentaCorrienteRecibosService.GetNumeroRecibo(rowPago.CTACTE_RECIBO_ID, sesion);
                            nuevo_recibo_id = rowPago.CTACTE_RECIBO_ID;
                            rowPago.CTACTE_RECIBO_NUMERO = nroRecibo;
                        }
                        #endregion Crear recibo si aun no estaba generado
                    }
                }

                //Crear la primera factura que se emite como comprobante
                if (montoFactura1 > 0)
                    rowPago.FC_CLIENTE1_COMPROBANTE_ID = PagosDePersonaService.CrearFacturaComoComprobante(rowPago, ctacteCajaSucursalId, hashDetallesFactura1, sesion);

                //Crear la segunda factura que se emite como comprobante
                if (montoFactura2 > 0)
                    rowPago.FC_CLIENTE2_COMPROBANTE_ID = PagosDePersonaService.CrearFacturaComoComprobante(rowPago, ctacteCajaSucursalId, hashDetallesFactura2, sesion);

                sesion.Db.CTACTE_PAGOS_PERSONACollection.Update(rowPago);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPago.ID, valorAnterior, rowPago.ToString(), sesion);

                CuentaCorrientePagosPersonaDocumentoService.AccionesPosterioresAConfirmarDocumentos(rowPago.ID, sesion);

                //Si se debe, convertir el vuelto a Anticipo
                //Esto se realiza luego del commit de la sesion ya que
                //se utilizan procedures de la db y la informacion debe
                //estar actualizada.
                if (convertir_vuelto_a_anticipo)
                {
                    decimal casoAnticipoId;
                    string mensajeAnticipo;
                    bool exito;

                    //Crear el caso de anticipo
                    casoAnticipoId = CrearCasoAnticipoPersona(ref rowPago, sesion, autonumeracion_anticipo_id, ctacteCajaSucursalId);

                    //Se avanza el caso hasta aprobado
                    AnticiposPersonaService anticipoPersona = new AnticiposPersonaService();
                    CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService ToolbarFlujo = new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService();

                    exito = anticipoPersona.ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Pendiente, false, out mensajeAnticipo, sesion);
                    if (exito)
                        exito = ToolbarFlujo.ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática por vuelto de pago convertido a Anticipo.", sesion);
                    if (exito)
                        anticipoPersona.EjecutarAccionesLuegoDeCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Pendiente, sesion);
                    if (!exito)
                        throw new Exception("Error en PagosDePersonaService.ConfirmarPago al pasar el anticipo creado como vuelto a pendiente. " + mensajeAnticipo + ".");

                    exito = anticipoPersona.ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Aprobado, false, out mensajeAnticipo, sesion);
                    if (exito)
                        exito = ToolbarFlujo.ProcesarCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Aprobado, "Transición automática por vuelto de pago convertido a Anticipo.", sesion);
                    if (exito)
                        anticipoPersona.EjecutarAccionesLuegoDeCambioEstado(casoAnticipoId, Definiciones.EstadosFlujos.Aprobado, sesion);
                    if (!exito)
                        throw new Exception("Error en PagosDePersonaService.ConfirmarPago al pasar el anticipo creado como vuelto a aprobado. " + mensajeAnticipo + ".");

                    valorAnterior = rowPago.ToString();
                    rowPago.CASO_ANTICIPO_ID = casoAnticipoId;
                    sesion.Db.CTACTE_PAGOS_PERSONACollection.Update(rowPago);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPago.ID, valorAnterior, rowPago.ToString(), sesion);
                }

                if (banderaReciboActualizarTotal)
                {
                    DataTable dtPago = GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + rowPago.ID, string.Empty, sesion);
                    CuentaCorrienteRecibosService.ActualizarTotal(dtPago, sesion);
                }

                return nroRecibo;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion ConfirmarPago

        #region CrearCasoAnticipoPersona
        // Metodo que crea el caso de anticipo desde el pago de persona
        private static decimal CrearCasoAnticipoPersona(ref CTACTE_PAGOS_PERSONARow rowPago, SessionService sesion, decimal autonumeracion_anticipo_id, decimal ctacteCajaSucursalId)
        {
            decimal casoCreadoAnticipoId = Definiciones.Error.Valor.EnteroPositivo;
            decimal casoCreadoAnticipoCasoId = Definiciones.Error.Valor.EnteroPositivo;
            string caso_anticipo_estado_id = string.Empty;

            // Se crea la cabecera del anticipo
            Hashtable camposCasoAnticipo = new Hashtable();
            camposCasoAnticipo.Add(AnticiposPersonaService.SucursalId_NombreCol, rowPago.SUCURSAL_ID);
            camposCasoAnticipo.Add(AnticiposPersonaService.PersonaId_NombreCol, rowPago.PERSONA_ID);
            camposCasoAnticipo.Add(AnticiposPersonaService.Fecha_NombreCol, DateTime.Now);
            camposCasoAnticipo.Add(AnticiposPersonaService.FuncionarioCobradorId_NombreCol, rowPago.FUNCIONARIO_COBRADOR_ID);
            camposCasoAnticipo.Add(AnticiposPersonaService.AutonmeracionReciboId_NombreCol, autonumeracion_anticipo_id);
            camposCasoAnticipo.Add(AnticiposPersonaService.MonedaId_NombreCol, rowPago.MONEDA_TOTAL_VUELTO_ID);
            camposCasoAnticipo.Add(AnticiposPersonaService.CotizacionMoneda_NombreCol, rowPago.COTIZACION_MONEDA_TOTAL_VUELTO);
            camposCasoAnticipo.Add(AnticiposPersonaService.MontoTotal_NombreCol, rowPago.MONTO_TOTAL_VUELTO);
            camposCasoAnticipo.Add(AnticiposPersonaService.SaldoPorAplicar_NombreCol, rowPago.MONTO_TOTAL_VUELTO);
            camposCasoAnticipo.Add(AnticiposPersonaService.Observacion_NombreCol, "Anticipo creado por vuelto de pago.");

            var dtTextoPredefinido = TextosPredefinidosService.GetDataTable(TextosPredefinidosService.TipoTextoPredefinidoId_NombreCol + " = " + Definiciones.TipoTextoPredefinido.AnticiposPersona + " and " + TextosPredefinidosService.Texto_NombreCol + " = '" + Definiciones.TextoPredefinido.AnticiposPersonas.VueltoConvertidoAAnticipo + "'", string.Empty);
            if (dtTextoPredefinido.Rows.Count > 0)
                camposCasoAnticipo.Add(AnticiposPersonaService.TextoPredefinidoId_NombreCol, dtTextoPredefinido.Rows[0][TextosPredefinidosService.Id_NombreCol]);

            AnticiposPersonaService.Guardar(camposCasoAnticipo, true, ref casoCreadoAnticipoCasoId, ref caso_anticipo_estado_id, ref casoCreadoAnticipoId, sesion);

            // Se obtiene el id del caso creado
            DataTable dtCasoAnticipo = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + casoCreadoAnticipoId, string.Empty, sesion);
            string anticipo_creado_id = dtCasoAnticipo.Rows[0][AnticiposPersonaService.Id_NombreCol].ToString();

            // Se crea el detalle del anticipo
            Hashtable camposDetalleAnticipo = new Hashtable();
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol, decimal.Parse(anticipo_creado_id));
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.MonedaId_NombreCol, rowPago.MONEDA_TOTAL_VUELTO_ID);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.CotizacionMoneda_NombreCol, rowPago.COTIZACION_MONEDA_TOTAL_VUELTO);
            camposDetalleAnticipo.Add(AnticiposPersonaDetalleService.Monto_NombreCol, rowPago.MONTO_TOTAL_VUELTO);

            (new AnticiposPersonaDetalleService()).Guardar(camposDetalleAnticipo, sesion);

            // Se obtiene el id del detalle creado
            DataTable dtAnticipoDetalle = AnticiposPersonaDetalleService.GetAnticipoPersonaDetalleDataTable2(AnticiposPersonaDetalleService.AnticipoPersonaId_NombreCol + " = " + anticipo_creado_id, string.Empty, sesion);
            string anticipo_detalle_id = dtAnticipoDetalle.Rows[0][AnticiposPersonaDetalleService.Id_NombreCol].ToString();

            // Se crea el ingreso a la caja de sucursal
            Hashtable camposIngresoCaja = new Hashtable();
            camposIngresoCaja.Add(CuentaCorrienteCajaService.Fecha_NombreCol, DateTime.Now);
            camposIngresoCaja.Add(CuentaCorrienteCajaService.MonedaId_NombreCol, rowPago.MONEDA_TOTAL_VUELTO_ID);
            camposIngresoCaja.Add(CuentaCorrienteCajaService.CotizacionMoneda_NombreCol, rowPago.COTIZACION_MONEDA_TOTAL_VUELTO);
            camposIngresoCaja.Add(CuentaCorrienteCajaService.Monto_NombreCol, rowPago.MONTO_TOTAL_VUELTO);
            camposIngresoCaja.Add(CuentaCorrienteCajaService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
            camposIngresoCaja.Add(CuentaCorrienteCajaService.UsuarioId_NombreCol, sesion.Usuario_Id);
            camposIngresoCaja.Add(CuentaCorrienteCajaService.SucursalId_NombreCol, rowPago.SUCURSAL_ID);
            camposIngresoCaja.Add(CuentaCorrienteCajaService.FuncionarioCobradorId_NombreCol, rowPago.FUNCIONARIO_COBRADOR_ID);
            camposIngresoCaja.Add(CuentaCorrienteCajaService.AnticipoPersonaId_NombreCol, decimal.Parse(anticipo_creado_id));
            camposIngresoCaja.Add(CuentaCorrienteCajaService.AnticipoPersonaDetId_NombreCol, decimal.Parse(anticipo_detalle_id));
            camposIngresoCaja.Add(CuentaCorrienteCajaService.CtacteConceptoId_NombreCol, Definiciones.CuentaCorrienteConceptos.DebitoPorPago);
            camposIngresoCaja.Add(CuentaCorrienteCajaService.CtacteCajaSucursalId_NombreCol, ctacteCajaSucursalId);

            CuentaCorrienteCajaService.Guardar(camposIngresoCaja, sesion);

            return casoCreadoAnticipoId;
        }
        #endregion CrearCasoAnticipoPersona

        #region ValidarTotales
        /// <summary>
        /// Validars the totales.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="mensaje">The mensaje.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool ValidarTotales(decimal ctacte_pago_persona_id, decimal moneda_id, out string mensaje, SessionService sesion)
        {
            bool exito = true;

            decimal montoContado, montoCredito, montoFinanciero, montoRecargo;
            decimal totalValores;
            int cantidadDecimales = MonedasService.CantidadDecimalesStatic(moneda_id, sesion);
            mensaje = string.Empty;

            totalValores = CuentaCorrientePagosPersonaDetalleService.GetMontoTotal(ctacte_pago_persona_id, sesion);
            CuentaCorrientePagosPersonaDocumentoService.GetMontoTotal(ctacte_pago_persona_id, out montoContado, out montoCredito, out montoFinanciero, out montoRecargo, sesion);


            if (Math.Round(totalValores, cantidadDecimales) < Math.Round(montoContado + montoCredito + montoFinanciero + montoRecargo, cantidadDecimales))
            {
                exito = false;
                mensaje = "La suma de los valores es menor a la suma de documentos que se desean pagar.";
            }

            return exito;
        }
        #endregion ValidarTotales

        #region CrearFacturaComoComprobante
        /// <summary>
        /// Crears the factura como comprobante.
        /// </summary>
        /// <param name="pago_persona_row">The pago_persona_row.</param>
        /// <param name="monto_credito">The monto_credito.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns>Id de factura cliente creada</returns>
        private static decimal CrearFacturaComoComprobante(CTACTE_PAGOS_PERSONARow pago_persona_row, decimal ctacte_caja_sucursal_id, Hashtable[] hashtableDetalles, SessionService sesion)
        {
            //Objetos para crear la factura y los detalles
            CasosService casoService = new CasosService();
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

            if (pago_persona_row.IsFC_CLIENTE1_COMP_AUTON_IDNull)
                throw new Exception("Debe indicar el talonario para la Factura 1.");

            #region Crear cabecera FC
            campos = new System.Collections.Hashtable();
            campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.No);
            campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, pago_persona_row.FC_CLIENTE1_COMP_AUTON_ID);
            campos.Add(FacturasClienteService.CasoOrigenId_NombreCol, pago_persona_row.CASO_ID);
            campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
            campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, Definiciones.CondicionPago.Contado);
            campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, pago_persona_row.COTIZACION_MONEDA);
            campos.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
            campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, pago_persona_row.FECHA);
            campos.Add(FacturasClienteService.Fecha_NombreCol, pago_persona_row.FECHA);
            campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, pago_persona_row.MONEDA_ID);
            campos.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
            campos.Add(FacturasClienteService.Observacion_NombreCol, "Factura creada como comprobante de pago caso Nº" + pago_persona_row.CASO_ID);
            campos.Add(FacturasClienteService.PersonaId_NombreCol, pago_persona_row.PERSONA_ID);
            campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, (decimal)0);
            campos.Add(FacturasClienteService.SucursalId_NombreCol, pago_persona_row.SUCURSAL_ID);
            campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, Definiciones.TipoFactura.Contado);
            campos.Add(FacturasClienteService.VendedorId_NombreCol, pago_persona_row.FUNCIONARIO_COBRADOR_ID);
            campos.Add(FacturasClienteService.CtaCteCajaSucursalId_NombreCol, ctacte_caja_sucursal_id);
            #region Obtener el primer deposito activo de la sucursal
            DataTable dtStockDepositoAux = Stock.StockDepositosService.GetStockDepositosDataTable(pago_persona_row.SUCURSAL_ID, true, true);
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
                dtArticulo = ArticulosService.GetArticulosDataTable(Articulos.ArticulosService.Id_NombreCol + " = " + hashtableDetalles[i][FacturasClienteDetalleService.ArticuloId_NombreCol], string.Empty, false, pago_persona_row.SUCURSAL_ID);
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

        #region LimpiarDatosPorPagoFallido
        public static void LimpiarDatosPorPagoFallido(decimal ctacte_pago_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PAGOS_PERSONARow cabeceraRow = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(ctacte_pago_persona_id);
                DataTable dtDetalles = CuentaCorrientePagosPersonaDetalleService.GetCuentaCorrientePagosPersonaDetalleInfoCompleta(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + cabeceraRow.ID, string.Empty);
                DataTable dtDocumentos = CuentaCorrientePagosPersonaDocumentoService.GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + cabeceraRow.ID, string.Empty, sesion);

                PagosDePersonaService.LimpiarDatosPorPagoFallido(ref cabeceraRow, dtDetalles, dtDocumentos, sesion);

                sesion.Db.CTACTE_PAGOS_PERSONACollection.Update(cabeceraRow);
            }
        }

        private static void LimpiarDatosPorPagoFallido(ref CTACTE_PAGOS_PERSONARow cabeceraRow, DataTable dtDetalles, DataTable dtDocumentos, SessionService sesion)
        {
            string mensajeAnticipo, estadoActual;
            bool exito;
            List<decimal> ctactePersonasConRecargo = new List<decimal> { };

            //No puede realizarse la transicion si fueron emitidas facturas como comprobante
            if (!cabeceraRow.IsFC_CLIENTE1_COMPROBANTE_IDNull || !cabeceraRow.IsFC_CLIENTE2_COMPROBANTE_IDNull)
                throw new Exception("Transición no válida si existen facturas emitidas como resultado del pago.");

            //Actualizar la cabecera
            cabeceraRow.PAGO_CONFIRMADO = Definiciones.SiNo.No;
            cabeceraRow.IsFECHA_CONFIRMACIONNull = true;

            //Anular el anticipo si fue generado
            if (!cabeceraRow.IsCASO_ANTICIPO_IDNull)
            {
                DataTable dtAnticipo = AnticiposPersonaService.GetAnticipoPersonaDataTable(AnticiposPersonaService.CasoId_NombreCol + " = " + cabeceraRow.CASO_ANTICIPO_ID, string.Empty);
                if ((decimal)dtAnticipo.Rows[0][AnticiposPersonaService.MontoTotal_NombreCol] != (decimal)dtAnticipo.Rows[0][AnticiposPersonaService.SaldoPorAplicar_NombreCol])
                    throw new Exception("El anticipo ya fue utilizado total o parcialmente.");

                estadoActual = CambioEstadoCasoService.BorrarCambioEstado(cabeceraRow.CASO_ANTICIPO_ID, Definiciones.EstadosFlujos.Pendiente, Definiciones.EstadosFlujos.Aprobado, sesion);

                if (estadoActual != Definiciones.EstadosFlujos.Pendiente)
                    throw new Exception("Error en PagosDePersonaService.ProcesarCambioEstado se esperaba que el anticipo con caso " + cabeceraRow.CASO_ANTICIPO_ID + " haya retrocedido a pendiente.");

                exito = new AnticiposPersonaService().ProcesarCambioEstado(cabeceraRow.CASO_ANTICIPO_ID, Definiciones.EstadosFlujos.Anulado, false, out mensajeAnticipo, sesion);
                if (exito)
                    exito = new ToolbarFlujoService().ProcesarCambioEstado(cabeceraRow.CASO_ANTICIPO_ID, Definiciones.EstadosFlujos.Anulado, "Transición automática por pago deshecho.", sesion);
                if (exito)
                    new AnticiposPersonaService().EjecutarAccionesLuegoDeCambioEstado(cabeceraRow.CASO_ANTICIPO_ID, Definiciones.EstadosFlujos.Anulado, sesion);
                if (!exito)
                    throw new Exception("Error en PagosDePersonaService.ProcesarCambioEstado al pasar el anticipo creado como vuelto a anulado. " + mensajeAnticipo + ".");
            }

            //Borrar el ingreso a caja
            CuentaCorrienteCajaService.BorrarPagoPersona(cabeceraRow.ID, sesion);

            //Deshacer el ingreso de los valores
            for (int i = 0; i < dtDetalles.Rows.Count; i++)
            {
                CuentaCorrientePagosPersonaDetalleService.DeschacerConfirmacion((decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.Id_NombreCol], sesion);

                switch (int.Parse(dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol].ToString()))
                {
                    case Definiciones.CuentaCorrienteValores.Efectivo: break;
                    case Definiciones.CuentaCorrienteValores.Cheque:
                        if (Interprete.EsNullODBNull(dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteChequeRecibidoId_NombreCol]))
                            continue;
                        CuentaCorrienteChequesRecibidosService.Borrar((decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteChequeRecibidoId_NombreCol], sesion);
                        break;
                    case Definiciones.CuentaCorrienteValores.RetencionIVA:
                    case Definiciones.CuentaCorrienteValores.RetencionRenta:
                    case Definiciones.CuentaCorrienteValores.RetencionSECP:
                        if (Interprete.EsNullODBNull(dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.RetencionDetalleId_NombreCol]))
                            continue;
                        CuentaCorrienteRetencionesRecibidasService.Borrar((decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.RetencionId_NombreCol], (decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.RetencionDetalleId_NombreCol], sesion);
                        break;
                    case Definiciones.CuentaCorrienteValores.TarjetaDeCredito:
                    case Definiciones.CuentaCorrienteValores.Giro:
                        if (Interprete.EsNullODBNull(dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteGiroId_NombreCol]))
                            continue;
                        Giros.CuentaCorrienteGirosService.Borrar((decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteGiroId_NombreCol], sesion);
                        break;
                    case Definiciones.CuentaCorrienteValores.TransferenciaBancaria: break;
                    case Definiciones.CuentaCorrienteValores.DepositoBancario:
                        CuentaCorrienteCuentasBancariasMovimientosService mov = new CuentaCorrienteCuentasBancariasMovimientosService();
                        mov.IniciarUsingSesion(sesion);
                        var m = mov.GetFiltrado<CuentaCorrienteCuentasBancariasMovimientosService>( new Filtro{ Columna = CuentaCorrienteCuentasBancariasMovimientosService.Modelo.CASO_IDColumnName, Valor = cabeceraRow.CASO_ID});
                        for (int j = 0; j < m.Length; j++)
                            m[j].Borrar(sesion);
                        mov.FinalizarUsingSesion();
                        break;
                    case Definiciones.CuentaCorrienteValores.Ajuste: 
                        break;
                    case Definiciones.CuentaCorrienteValores.Anticipo:
                        #region Anticipo
                        //Deshacer ingreso de debito
                        CuentaCorrientePersonasService.DeshacerAgregarCredito((decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.Id_NombreCol], sesion);

                        //Se aumenta el saldo
                        AnticiposPersonaService.AumentarSaldoDisponible((decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.AnticipoId_NombreCol], (decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol], sesion);

                        #endregion Anticipo
                        break;
                    case Definiciones.CuentaCorrienteValores.NotaDeCredito:
                        #region Nota de Credito
                        //Deshacer ingreso de debito
                        CuentaCorrientePersonasService.DeshacerAgregarCredito((decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.Id_NombreCol], sesion);

                        //Se aumenta el saldo
                        NotasCreditoPersonaService.AumentarSaldoDisponible((decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.NotaCreditoId_NombreCol], (decimal)dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol], sesion);

                        #endregion Nota de Credito
                        break;
                    default:
                        throw new Exception("Error en PagosDePersonaService.ProcesarCambioEstado no puede deshacerse un pago que utiliza el valor tipo " + dtDetalles.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol] + ".");
                }
            }

            for (int i = 0; i < dtDocumentos.Rows.Count; i++)
            {
                if (Interprete.EsNullODBNull(dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol]))
                {
                    //Bloquear los documentos si no son recargo
                    CuentaCorrientePersonasService.SetBloqueado((decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol], true, sesion);
                    CuentaCorrientePersonasService.DeshacerAgregarDebito((decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol], Definiciones.Error.Valor.EnteroPositivo, sesion);
                }
                else
                {
                    ctactePersonasConRecargo.Add((decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol]);

                    //Borrar los recargos si fueron generados
                    CuentaCorrientePagosPersonaDocumentoService.DesvincularCtactePersonaParaBorrarRecargo((decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol], sesion);
                    CuentaCorrienteRecargosService.BorrarDesdePago((decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol], sesion);
                    CuentaCorrientePersonasService.DeshacerAgregarCredito(Definiciones.Error.Valor.EnteroPositivo, (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol], Definiciones.Error.Valor.EnteroPositivo, false, sesion);
                }
            }

            //Borrar el asiento que se creo cuando se aprobo el pago
            CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(
                        cabeceraRow.CASO_ID,
                        TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.PAGO_DE_PERSONAS, Definiciones.EstadosFlujos.Borrador, Definiciones.EstadosFlujos.Aprobado, sesion),
                        sesion);

            CuentaCorrientePagosPersonaDocumentoService.AccionesPosterioresADesconfirmarDocumentos(cabeceraRow.ID, ctactePersonasConRecargo.ToArray(), sesion);
        }
        #endregion LimpiarDatosPorPagoFallido

        #region EmitirRecibo
        /// <summary>
        /// Emitirs the recibo.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="autonumeracion_recibo_id">The autonumeracion_recibo_id.</param>
        /// <param name="nuevo_recibo_id">The nuevo_recibo_id.</param>
        /// <returns></returns>
        public static string EmitirRecibo(decimal ctacte_pago_persona_id, decimal autonumeracion_recibo_id, out decimal nuevo_recibo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CuentaCorrientePagosPersonaDocumentoService ctactePagosDocumento = new CuentaCorrientePagosPersonaDocumentoService();
                    CuentaCorrienteRecibosService ctacteRecibo = new CuentaCorrienteRecibosService();
                    AutonumeracionesService autonumeracion = new AutonumeracionesService();
                    CTACTE_PAGOS_PERSONARow rowPago = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(ctacte_pago_persona_id);
                    DataTable dtPago;
                    string valorAnterior = rowPago.ToString();
                    System.Collections.Hashtable campos;
                    decimal montoVuelto, montoPagado, montoContado, montoCredito, montoFinanciero, montoRecargo, montoRecibo;
                    decimal ctacteCajaSucursalId, numeroSecuencia;
                    string nroRecibo;

                    //Si el numero de recibo ya existe se lanza una excepcion
                    string nroReciboEmitir = AutonumeracionesService.ConsultarSiguienteNumero(autonumeracion_recibo_id);
                    bool existe = CuentaCorrienteRecibosService.ExisteNroRecibo(autonumeracion_recibo_id, nroReciboEmitir);
                    if (existe)
                        throw new Exception("El número de recibo " + nroReciboEmitir + " ya existe");

                    //Se obtiene el id de la caja de sucursal abierta
                    ctacteCajaSucursalId = CuentaCorrienteCajasSucursalService.GetCajaAbiertaParaSucursalYFuncionario(rowPago.SUCURSAL_ID, rowPago.FUNCIONARIO_COBRADOR_ID);

                    //Si no se encontro una abierta, se lanza la excepcion
                    if (ctacteCajaSucursalId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("No existe una caja abierta.");

                    montoPagado = CuentaCorrientePagosPersonaDetalleService.GetMontoTotal(ctacte_pago_persona_id);

                    CuentaCorrientePagosPersonaDocumentoService.GetMontoTotal(ctacte_pago_persona_id, out montoContado, out montoCredito, out montoFinanciero, out montoRecargo);

                    montoRecibo = montoCredito;
                    if (rowPago.IsFC_CLIENTE2_COMP_AUTON_IDNull && rowPago.IsFC_CLIENTE1_COMP_AUTON_IDNull)
                        montoRecibo = montoCredito + montoFinanciero + montoRecargo;
                    else
                        montoRecibo = montoCredito;

                    //Calcular el vuelto
                    montoVuelto = montoPagado - montoContado - montoCredito - montoFinanciero - montoRecargo;

                    if (montoVuelto > 0)
                        rowPago.MONTO_TOTAL_VUELTO = montoVuelto;
                    else
                        rowPago.MONTO_TOTAL_VUELTO = 0;

                    rowPago.MONEDA_TOTAL_VUELTO_ID = rowPago.MONEDA_ID;

                    #region Si aun no esta generado, creacion del recibo nuevo por monto total menos FC contado
                    nuevo_recibo_id = Definiciones.Error.Valor.EnteroPositivo;
                    nroRecibo = string.Empty;
                    if (Math.Round(montoRecibo, MonedasService.CantidadDecimalesStatic(rowPago.MONEDA_ID)) > 0)
                    {
                        if (rowPago.IsCTACTE_RECIBO_IDNull)
                        {
                            if (autonumeracion_recibo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                throw new Exception("El pago contiene documentos crédito pero no se seleccionó un talonario de recibo.");

                            campos = new System.Collections.Hashtable();

                            if (AutonumeracionesService.EsGeneracionManual(autonumeracion_recibo_id))
                            {
                                if (rowPago.CTACTE_RECIBO_NUMERO == null || rowPago.CTACTE_RECIBO_NUMERO.Equals(DBNull.Value))
                                    throw new Exception("El talonario de recibos es manual, debe indicar el número a ser asignado.");
                                nroRecibo = rowPago.CTACTE_RECIBO_NUMERO;
                                numeroSecuencia = Definiciones.Error.Valor.EnteroPositivo;
                            }
                            else
                            {
                                if (!AutonumeracionesService.FuncionarioPuedeUsar(autonumeracion_recibo_id, rowPago.FUNCIONARIO_COBRADOR_ID, sesion) && !AutonumeracionesService.FuncionarioPuedeUsar(autonumeracion_recibo_id, rowPago.FUNCIONARIO_COBRADOR_EXTER_ID, sesion))
                                    throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");
                                
                                nroRecibo = AutonumeracionesService.GetSiguienteNumero2(autonumeracion_recibo_id, out numeroSecuencia, sesion);
                            }

                            campos.Add(CuentaCorrienteRecibosService.AutonumeracionId_NombreCol, autonumeracion_recibo_id);
                            campos.Add(CuentaCorrienteRecibosService.Estado_NombreCol, Definiciones.Estado.Activo);
                            campos.Add(CuentaCorrienteRecibosService.Fecha_NombreCol, rowPago.FECHA);
                            campos.Add(CuentaCorrienteRecibosService.MonedaId_NombreCol, rowPago.MONEDA_ID);
                            campos.Add(CuentaCorrienteRecibosService.Monto_NombreCol, montoRecibo);
                            campos.Add(CuentaCorrienteRecibosService.NroComprobante_NombreCol, nroRecibo);
                            campos.Add(CuentaCorrienteRecibosService.NroComprobanteSecuencia_NombreCol, numeroSecuencia);
                            campos.Add(CuentaCorrienteRecibosService.PersonaId_NombreCol, rowPago.PERSONA_ID);

                            rowPago.CTACTE_RECIBO_ID = CuentaCorrienteRecibosService.Guardar(campos, true, false, rowPago.ID, sesion);
                            nuevo_recibo_id = rowPago.CTACTE_RECIBO_ID;
                            rowPago.CTACTE_RECIBO_NUMERO = nroRecibo;
                        }
                        else
                        {
                            nroRecibo = CuentaCorrienteRecibosService.GetNumeroRecibo(rowPago.CTACTE_RECIBO_ID);
                            nuevo_recibo_id = rowPago.CTACTE_RECIBO_ID;
                            rowPago.CTACTE_RECIBO_NUMERO = nroRecibo;
                        }
                    }
                    #endregion Si aun no esta generado, creacion del recibo nuevo por monto total menos FC contado

                    sesion.Db.CTACTE_PAGOS_PERSONACollection.Update(rowPago);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPago.ID, valorAnterior, rowPago.ToString(), sesion);


                    //Actualizar el total del recibo
                    dtPago = GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + rowPago.ID, string.Empty, sesion);
                    CuentaCorrienteRecibosService.ActualizarTotal(dtPago, sesion);

                    DataTable dtCobranzaDetalle = PlanillaCobranzaDetallesService.GetPlanillaDetalles(PlanillaCobranzaDetallesService.CasoPagoId_NombreCol + "=" + rowPago.CASO_ID, string.Empty, sesion);
                    if (dtCobranzaDetalle.Rows.Count > 0)
                    {
                        decimal planillaDetalleId = decimal.Parse(dtCobranzaDetalle.Rows[0][PlanillaCobranzaDetallesService.Id_NombreCol].ToString());
                        PlanillaCobranzaDetallesService.ActualizarRecibo(planillaDetalleId, rowPago.CTACTE_RECIBO_ID, sesion);
                    }

                    return nroRecibo;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion EmitirRecibo

        #region AnularRecibo
        public static void AnularRecibo(decimal ctacte_pago_persona_id, SessionService sesion)
        {
            try
            {
                CuentaCorrientePagosPersonaDetalleService ctactePagoDetalle = new CuentaCorrientePagosPersonaDetalleService();
                AutonumeracionesService autonumeracion = new AutonumeracionesService();
                CTACTE_PAGOS_PERSONARow rowPago = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(ctacte_pago_persona_id);
                string valorAnterior = rowPago.ToString();
                DataTable dtRecibo;

                dtRecibo = CuentaCorrienteRecibosService.GetCtacteReciboDataTable2(rowPago.CTACTE_RECIBO_ID);

                //Anular recibo anterior
                CuentaCorrienteRecibosService.Anular(rowPago.CTACTE_RECIBO_ID, sesion);
                rowPago.IsCTACTE_RECIBO_IDNull = true;

                sesion.Db.CTACTE_PAGOS_PERSONACollection.Update(rowPago);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, rowPago.ID, valorAnterior, rowPago.ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        /// <summary>
        /// Anulars the recibo.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        public static void AnularRecibo(decimal ctacte_pago_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    AnularRecibo(ctacte_pago_persona_id, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception)
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion AnularRecibo

        #region ActualizarVuelto
        /// <summary>
        /// Actualizars the vuelto.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarVuelto(decimal ctacte_pago_persona_id, SessionService sesion)
        {
            decimal montoCredito, montoContado, montoFinanciero, montoRecargo;
            decimal montoValores;

            CTACTE_PAGOS_PERSONARow row = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(ctacte_pago_persona_id);
            CuentaCorrientePagosPersonaDocumentoService.GetMontoTotal(row.ID, out montoContado, out montoCredito, out montoFinanciero, out montoRecargo, sesion);
            montoValores = CuentaCorrientePagosPersonaDetalleService.GetMontoTotal(row.ID, sesion);

            row.MONTO_TOTAL_VUELTO = montoValores - montoCredito - montoContado - montoFinanciero - montoRecargo;

            if (row.MONTO_TOTAL_VUELTO < 0)
                row.MONTO_TOTAL_VUELTO = 0;

            sesion.db.CTACTE_PAGOS_PERSONACollection.Update(row);
        }
        #endregion ActualizarVuelto

        #region ActualizarCompensacionAnticipoPorVuelto
        /// <summary>
        /// Actualizars the compensacion anticipo por vuelto.
        /// </summary>
        /// <param name="pago_persona_id">The pago_persona_id.</param>
        public static void ActualizarCompensacionAnticipoPorVuelto(decimal pago_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal entrada = CuentaCorrientePagosPersonaCompensacionEntradaService.GetTotal(pago_persona_id);
                decimal salida = CuentaCorrientePagosPersonaCompensacionSalidaService.GetTotal(pago_persona_id);
                decimal vuelto = salida - entrada;

                CTACTE_PAGOS_PERSONARow row = sesion.db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(pago_persona_id);
                string valorAnterior = row.ToString();
                row.VUELTO_CONVERTIDO_A_ANTICIPO = vuelto > 0 ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
                sesion.db.CTACTE_PAGOS_PERSONACollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
        }
        #endregion ActualizarCompensacionAnticipoPorVuelto

        #region GetMontoVuelto
        /// <summary>
        /// Gets the monto vuelto.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static decimal GetMontoVuelto(decimal ctacte_pago_persona_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONARow row = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(ctacte_pago_persona_id);
            return row.MONTO_TOTAL_VUELTO;
        }
        #endregion GetMontoVuelto

        #region GetMontoTotal
        public static decimal GetMontoTotal(decimal cabecera_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal total = decimal.Zero;
                CTACTE_PAGOS_PERSONA_DETRow[] detalles = sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.GetByCTACTE_PAGO_PERSONA_ID(cabecera_id);
                if (detalles.Length > 0)
                {
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        if (detalles[i].ESTADO.Equals(Definiciones.Estado.Activo))
                            total += detalles[i].MONTO;
                    }
                }
                return total;
            }
        }
        #endregion GetMontoTotal

        #region GetMontoEfectivo
        public static decimal GetMontoEfectivo(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal total = decimal.Zero;
                CTACTE_PAGOS_PERSONA_INFO_COMPRow cabecera = sesion.Db.CTACTE_PAGOS_PERSONA_INFO_COMPCollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                CTACTE_PAGOS_PERSONA_DETRow[] detalles = sesion.Db.CTACTE_PAGOS_PERSONA_DETCollection.GetByCTACTE_PAGO_PERSONA_ID(cabecera.ID);
                if (detalles.Length > 0)
                {
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        if (detalles[i].ESTADO.Equals(Definiciones.Estado.Activo) && detalles[i].CTACTE_VALOR_ID == 1)
                            total += detalles[i].MONTO;
                    }
                }
                return total;
            }
        }
        #endregion GetMontoEfectivo

        #region GetInfoPago
        public static string GetInfoPago(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PAGOS_PERSONA_INFO_COMPRow cabecera = sesion.Db.CTACTE_PAGOS_PERSONA_INFO_COMPCollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                return "Caso: " + cabecera.CASO_ID + " \t " + " Cliente: " + cabecera.PERSONA_NOMBRE_COMPLETO + " - Monto: " + cabecera.MONEDA_SIMBOLO + " " + MonedasService.MontoFormateadoString(GetMontoTotal(cabecera.ID), cabecera.MONEDA_ID);
            }
        }
        #endregion GetInfoPago

        #region GetPagoPorPersonaPorDia
        public static DataTable GetPagoPorPersonaPorDia(decimal personaId, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_PAGOS_PERSONA_INFO_COMPCollection.GetAsDataTable(PersonaId_NombreCol + " = " + personaId + " and " +
                                                                    Fecha_NombreCol + " = to_date('" + fecha.ToShortDateString() + "','dd/MM/yyyy')", string.Empty);

            }
        }
        #endregion GetPagoPorPersonaPorDia

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "PAGOS DE PERSONA NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.PagoDePersonasMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region AjustarDocumentos
        /// <summary>
        /// Ajustars the documentos.
        /// </summary>
        /// <param name="pago_persona_id">The pago_persona_id.</param>
        public static void AjustarDocumentos(decimal pago_persona_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    //Se ajusta el monto pagado de cada documento para que coincida 
                    //con el total de valores cargados dando preferencia a la precedencia
                    //de cuota, y en la misma cuota priorizando los recargos
                    decimal totalValores = CuentaCorrientePagosPersonaDetalleService.GetMontoTotal(pago_persona_id, sesion);

                    string sql = "select cppd." + CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol + ", " +
                                 "       1 tipo, " +
                                 "       cppdic." + CuentaCorrientePagosPersonaDocumentoService.VistaCuotaNumero_NombreCol + ", " +
                                 "       cppd." + CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + ", " +
                                 "       cppd." + CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol + ", " +
                                 "       cppdic." + CuentaCorrientePagosPersonaDocumentoService.VistaFechaVencimiento_NombreCol +
                                 "  from " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Tabla + " cppd, " +
                                 "       " + CuentaCorrientePagosPersonaRecargosService.Nombre_Tabla + " cppr, " +
                                 "       " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Vista + " cppdic " +
                                 " where cppd." + CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol + " = cppr." + CuentaCorrientePagosPersonaRecargosService.Id_NombreCol +
                                 "   and cppr." + CuentaCorrientePagosPersonaRecargosService.CtactePagoPersonaDocId_NombreCol + " = cppdic." + CuentaCorrientePagosPersonaRecargosService.Id_NombreCol +
                                 "   and cppd." + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                                 "   and cppr." + CuentaCorrientePagosPersonaRecargosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                                 "   and cppd." + CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + pago_persona_id +
                                 " union " +
                                 "select cppdic." + CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol + ", " +
                                 "       2 tipo, " +
                                 "       cppdic." + CuentaCorrientePagosPersonaDocumentoService.VistaCuotaNumero_NombreCol + ", " +
                                 "       cppdic." + CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol + ", " +
                                 "       cppdic." + CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol + ", " +
                                 "       cppdic." + CuentaCorrientePagosPersonaDocumentoService.VistaFechaVencimiento_NombreCol +
                                 "  from " + CuentaCorrientePagosPersonaDocumentoService.Nombre_Vista + " cppdic " +
                                 " where cppdic." + CuentaCorrientePagosPersonaDocumentoService.CtactePagoPersonaRecargoId_NombreCol + " is null " +
                                 "   and cppdic." + CuentaCorrientePagosPersonaDocumentoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                                 "   and cppdic." + CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol + " = " + pago_persona_id +
                                 " order by " + CuentaCorrientePagosPersonaDocumentoService.VistaFechaVencimiento_NombreCol + ", tipo";

                    DataTable dtPagoPersona = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.Id_NombreCol + " = " + pago_persona_id, string.Empty, sesion);
                    DataTable dtDocumentos = sesion.db.EjecutarQuery(sql);
                    DataTable dtCtaCte;
                    decimal[][] modificaciones = new decimal[dtDocumentos.Rows.Count][];
                    decimal saldoNoConfirmado;

                    Decimal totalDocumentosIncluidos = 0;
                    bool banderaModificacion = false;

                    for (int i = 0; i < dtDocumentos.Rows.Count; i++)
                    {
                        banderaModificacion = false;
                        modificaciones[i] = new decimal[2] { -1, -1 };

                        if (dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol] == null || dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol].Equals(DBNull.Value))
                        {
                            if (totalValores - totalDocumentosIncluidos <= (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol])
                            {
                                banderaModificacion = true;
                                modificaciones[i][0] = (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol];

                                if (totalValores - totalDocumentosIncluidos > 0)
                                    modificaciones[i][1] = totalValores - totalDocumentosIncluidos;
                                else
                                    modificaciones[i][1] = 0;

                                totalDocumentosIncluidos += modificaciones[i][1];
                            }
                            else
                            {
                                totalDocumentosIncluidos += (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];
                                modificaciones[i][0] = (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol];
                                modificaciones[i][1] = (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];
                            }
                        }
                        else
                        {
                            //Se obtiene el monto original de la cuenta corriente
                            dtCtaCte = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol], string.Empty, sesion);
                            saldoNoConfirmado = (-1) * ((decimal)dtCtaCte.Rows[0][CuentaCorrientePersonasService.VistaSaldoDebito_NombreCol] + (decimal)dtCtaCte.Rows[0][CuentaCorrientePersonasService.VistaMontoEnProceso_NombreCol]);
                            saldoNoConfirmado += (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];

                            //Si lo que se paga no puede incluirse entero entonces se ingresa el maximo posible
                            if (totalValores - totalDocumentosIncluidos <= saldoNoConfirmado)
                            {
                                banderaModificacion = true;
                                modificaciones[i][0] = (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol];

                                if (totalValores - totalDocumentosIncluidos > 0)
                                    modificaciones[i][1] = totalValores - totalDocumentosIncluidos;
                                else
                                    modificaciones[i][1] = 0;

                                totalDocumentosIncluidos += modificaciones[i][1];
                            }
                            else
                            {
                                totalDocumentosIncluidos += (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];
                                modificaciones[i][0] = (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Id_NombreCol];
                                modificaciones[i][1] = (decimal)dtDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol];
                            }
                        }
                    }

                    if (banderaModificacion)
                    {
                        CuentaCorrientePagosPersonaDocumentoService.AjsutarDocumentos(dtPagoPersona, modificaciones, sesion);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion AjustarDocumentos

        #region SetCtacteReciboId
        /// <summary>
        /// Sets the ctacte recibo identifier.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <param name="sesion">The sesion.</param>
        private static void SetCtacteReciboId(decimal ctacte_pago_persona_id, decimal ctacte_recibo_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONARow row = sesion.db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(ctacte_pago_persona_id);
            row.CTACTE_RECIBO_ID = ctacte_recibo_id;
            sesion.db.CTACTE_PAGOS_PERSONACollection.Update(row);
        }
        #endregion SetCtacteReciboId

        #region SetCasoAsociadoId
        /// <summary>
        /// Sets the ctacte recibo identifier.
        /// </summary>
        /// <param name="ctacte_pago_persona_id">The ctacte_pago_persona_id.</param>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetCasoAsociado(decimal caso_id, decimal caso_asociado_id, SessionService sesion)
        {
            CTACTE_PAGOS_PERSONARow[] rows = sesion.db.CTACTE_PAGOS_PERSONACollection.GetByCASO_ID(caso_id);
            rows[0].CASO_ASOCIADO_ID = caso_asociado_id;
            sesion.db.CTACTE_PAGOS_PERSONACollection.Update(rows[0]);
        }
        #endregion SetCasoAsociadoId

        #region CrearCaso
        /// <summary>
        /// Crears the caso.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="funcionario_cobrador_id">The funcionario_cobrador_id.</param>
        /// <param name="funcionario_cobrador_externo_id">The funcionario_cobrador_externo_id.</param>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <param name="ctacte_recibo_nro">The ctacte_recibo_nro.</param>
        /// <param name="ctacte_recibo_autonumeracion_id">The ctacte_recibo_autonumeracion_id.</param>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="monto">The monto.</param>
        /// <returns></returns>
        public static decimal CrearCaso(decimal sucursal_id, decimal persona_id, DateTime fecha, decimal moneda_id, decimal funcionario_cobrador_id, decimal funcionario_cobrador_externo_id, decimal ctacte_recibo_id, string ctacte_recibo_nro, decimal ctacte_recibo_autonumeracion_id, decimal[] ctacte_persona_id, decimal[] monto)
        {
            using (SessionService sesion = new SessionService())
            {
                return CrearCaso(sucursal_id, persona_id, fecha, moneda_id, funcionario_cobrador_id, funcionario_cobrador_externo_id, ctacte_recibo_id, ctacte_recibo_nro, ctacte_recibo_autonumeracion_id, ctacte_persona_id, monto, Definiciones.CuentaCorrienteValores.Efectivo, Definiciones.Error.Valor.EnteroPositivo, string.Empty, Definiciones.Error.Valor.EnteroPositivo, true, null, sesion);
            }
        }
        public static decimal CrearCasoDesdePlanilla(decimal sucursal_id, decimal persona_id, DateTime fecha, decimal moneda_id, decimal funcionario_cobrador_id, decimal funcionario_cobrador_externo_id, decimal ctacte_recibo_id, string ctacte_recibo_nro, decimal ctacte_recibo_autonumeracion_id, decimal[] ctacte_persona_id, decimal[] monto)
        {
            using (SessionService sesion = new SessionService())
            {
                return CrearCaso(sucursal_id, persona_id, fecha, moneda_id, funcionario_cobrador_id, funcionario_cobrador_externo_id, ctacte_recibo_id, ctacte_recibo_nro, ctacte_recibo_autonumeracion_id, ctacte_persona_id, monto, Definiciones.CuentaCorrienteValores.Efectivo, Definiciones.Error.Valor.EnteroPositivo, string.Empty, Definiciones.Error.Valor.EnteroPositivo, false, null, sesion);
            }
        }
        public static decimal CrearCasoDesdePlanilla(decimal sucursal_id, decimal persona_id, DateTime fecha, decimal moneda_id, decimal funcionario_cobrador_id, decimal funcionario_cobrador_externo_id, decimal ctacte_recibo_id, string ctacte_recibo_nro, decimal ctacte_recibo_autonumeracion_id, decimal[] ctacte_persona_id, decimal[] monto, SessionService sesion)
        {
            return CrearCaso(sucursal_id, persona_id, fecha, moneda_id, funcionario_cobrador_id, funcionario_cobrador_externo_id, ctacte_recibo_id, ctacte_recibo_nro, ctacte_recibo_autonumeracion_id, ctacte_persona_id, monto, Definiciones.CuentaCorrienteValores.Efectivo, Definiciones.Error.Valor.EnteroPositivo, string.Empty, Definiciones.Error.Valor.EnteroPositivo, false, null, sesion);
        }

        /// <summary>
        /// Crears the caso.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <param name="funcionario_cobrador_id">The funcionario_cobrador_id.</param>
        /// <param name="funcionario_cobrador_externo_id">The funcionario_cobrador_externo_id.</param>
        /// <param name="ctacte_recibo_id">The ctacte_recibo_id.</param>
        /// <param name="ctacte_recibo_nro">The ctacte_recibo_nro.</param>
        /// <param name="ctacte_recibo_autonumeracion_id">The ctacte_recibo_autonumeracion_id.</param>
        /// <param name="ctacte_persona_id">The ctacte_persona_id.</param>
        /// <param name="monto">The monto.</param>
        /// <param name="ctacte_valor_id">The ctacte_valor_id.</param>
        /// <param name="ctacte_red_pago_id">The ctacte_red_pago_id.</param>
        /// <param name="ctacte_red_pago_nro_comprobante">The ctacte_red_pago_nro_comprobante.</param>
        /// <param name="ctacte_plan_desembolso_id">The ctacte_plan_desembolso_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal CrearCaso(decimal sucursal_id, decimal persona_id, DateTime fecha, decimal moneda_id, decimal funcionario_cobrador_id, decimal funcionario_cobrador_externo_id, decimal ctacte_recibo_id, string ctacte_recibo_nro, decimal ctacte_recibo_autonumeracion_id, decimal[] ctacte_persona_id, decimal[] monto, int ctacte_valor_id, decimal ctacte_red_pago_id, string ctacte_red_pago_nro_comprobante, decimal ctacte_plan_desembolso_id, bool verificar_cuenta_bloqueada, decimal? caso_asociado_id, SessionService sesion)
        {
            try
            {
                //Si ctacte es null entonces se trata de una inicializacion
                //del caso y no de un pago cerrado
                if (ctacte_persona_id != null)
                {
                    if (ctacte_persona_id.Length <= 0)
                        throw new Exception("No se indicaron documentos a pagar.");

                    if (ctacte_persona_id.Length != monto.Length)
                        throw new Exception("La cantidad de documentos a pagar difiere de la cantidad de montos proveídos.");
                }

                decimal cabeceraId = Definiciones.Error.Valor.EnteroPositivo;
                decimal totalMontoDocumentos = 0;
                decimal montoAux;
                decimal cotizacion;
                int cantidadDecimales;
                decimal casoId = Definiciones.Error.Valor.EnteroPositivo;
                string estadoId = string.Empty;
                bool exito;
                Hashtable campos;

                cotizacion = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais(sucursal_id), moneda_id, fecha, sesion);
                if (cotizacion.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizar la cotización de la moneda");

                #region Crear cabecera
                campos = new Hashtable();
                campos.Add(PagosDePersonaService.SucursalId_NombreCol, sucursal_id);
                campos.Add(PagosDePersonaService.PersonaId_NombreCol, persona_id);
                campos.Add(PagosDePersonaService.Fecha_NombreCol, fecha);
                campos.Add(PagosDePersonaService.MonedaId_NombreCol, moneda_id);
                if (caso_asociado_id.HasValue)
                    campos.Add(PagosDePersonaService.CasoAsociadoId_NombreCol, caso_asociado_id.Value);

                if (!funcionario_cobrador_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    campos.Add(PagosDePersonaService.FuncionarioCobradorId_NombreCol, funcionario_cobrador_id);
                }
                else
                {
                    if (sesion.Usuario_Funcionario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        throw new Exception("El usuario no está asociado con un funcionario.");
                    campos.Add(PagosDePersonaService.FuncionarioCobradorId_NombreCol, sesion.Usuario_Funcionario_id);
                }

                if (!funcionario_cobrador_externo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PagosDePersonaService.FuncionarioCobradorExterId_NombreCol, funcionario_cobrador_externo_id);
                campos.Add(PagosDePersonaService.CotizacionMoneda_NombreCol, cotizacion);
                if (!ctacte_recibo_autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PagosDePersonaService.AutonumeracionReciboId_NombreCol, ctacte_recibo_autonumeracion_id);
                if (ctacte_recibo_nro.Length > 0)
                    campos.Add(PagosDePersonaService.CtacteReciboNumero_NombreCol, ctacte_recibo_nro);
                campos.Add(PagosDePersonaService.VueltoConvertidoAAnticipo_NombreCol, Definiciones.SiNo.No);
                campos.Add(PagosDePersonaService.ReciboEmitirPorDocumentos_NombreCol, Definiciones.SiNo.Si);

                exito = PagosDePersonaService.Guardar(campos, true, ref casoId, ref estadoId, ref cabeceraId, sesion);

                if (exito && !ctacte_recibo_autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo) && !ctacte_recibo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    PagosDePersonaService.SetCtacteReciboId(cabeceraId, ctacte_recibo_id, sesion);
                }
                #endregion Crear cabecera

                totalMontoDocumentos = 0;
                for (int j = 0; j < monto.Length; j++)
                {
                    totalMontoDocumentos += monto[j];
                }

                #region Agregar valores
                campos = new Hashtable();
                campos.Add(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol, cabeceraId);
                campos.Add(CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol, ctacte_valor_id);
                campos.Add(CuentaCorrientePagosPersonaDetalleService.MonedaId_NombreCol, moneda_id);
                campos.Add(CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol, totalMontoDocumentos);
                campos.Add(CuentaCorrientePagosPersonaDetalleService.CotizacionMoneda_NombreCol, cotizacion);
                campos.Add(CuentaCorrientePagosPersonaDetalleService.Observaciones_NombreCol, string.Empty);

                switch (ctacte_valor_id)
                {
                    case Definiciones.CuentaCorrienteValores.Efectivo: break;
                    case Definiciones.CuentaCorrienteValores.Giro:
                        campos.Add(CuentaCorrientePagosPersonaDetalleService.CtaCteRedPagoId_NombreCol, ctacte_red_pago_id);
                        campos.Add(CuentaCorrientePagosPersonaDetalleService.CtaCtePlanDesembolsoId_NombreCol, ctacte_plan_desembolso_id);
                        campos.Add(CuentaCorrientePagosPersonaDetalleService.GiroComprobante_NombreCol, ctacte_red_pago_nro_comprobante);
                        break;
                    default:
                        throw new Exception("Error en PagosDePersonaService.CrearCaso(). Tipo de valor no implementado.");
                }
                CuentaCorrientePagosPersonaDetalleService.Guardar(campos, sesion);
                #endregion Agregar valores

                if (ctacte_persona_id != null)
                {
                    #region Agregar documentos
                    for (int i = 0; i < ctacte_persona_id.Length; i++)
                    {
                        if (!ctacte_persona_id[i].Equals(Definiciones.Error.Valor.EnteroPositivo))
                        {
                            campos = new Hashtable();

                            DataTable dtCtactePersona = CuentaCorrientePersonasService.GetCuentaCorrientePersonasInfoCompleta2(CuentaCorrientePersonasService.Id_NombreCol + " = " + ctacte_persona_id[i], string.Empty, sesion);
                            if (dtCtactePersona.Rows.Count != 1)
                                throw new Exception("Error en PagosDePersonaService.CrearCaso. No existe la cuenta corriente de la persona con valor " + ctacte_persona_id[i]);

                            //Verificar que si es una factura contado no se realiza un pago parcial sino total
                            if (!dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFacturaClienteTipo_NombreCol].Equals(DBNull.Value) &&
                               (string)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaFacturaClienteTipo_NombreCol] == Definiciones.TipoFactura.Contado)
                            {
                                cantidadDecimales = int.Parse(MonedasService.CantidadDecimalesStatic((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.MonedaId_NombreCol], sesion).ToString());
                                montoAux = Math.Round((decimal)dtCtactePersona.Rows[0][CuentaCorrientePersonasService.Credito_NombreCol], cantidadDecimales);
                                if (Math.Round(monto[i], cantidadDecimales) != montoAux)
                                    throw new Exception("No se admiten pagos parciales sobre facturas contado");
                            }

                            campos.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol, cabeceraId);
                            campos.Add(CuentaCorrientePagosPersonaDocumentoService.Monto_NombreCol, monto[i]);
                            campos.Add(CuentaCorrientePagosPersonaDocumentoService.CotizacionMoneda_NombreCol, dtCtactePersona.Rows[0][CuentaCorrientePersonasService.CotizacionMoneda_NombreCol]);
                            campos.Add(CuentaCorrientePagosPersonaDocumentoService.CtactePersonaId_NombreCol, ctacte_persona_id[i]);
                            campos.Add(CuentaCorrientePagosPersonaDocumentoService.Observacion_NombreCol, dtCtactePersona.Rows[0][CuentaCorrientePersonasService.VistaObservacion_NombreCol]);
                            CuentaCorrientePagosPersonaDocumentoService.Guardar(campos, verificar_cuenta_bloqueada, sesion);
                        }
                    }
                    #endregion Agregar documentos
                }
                else
                {
                    #region Agregar documentos en forma automatica
                    CuentaCorrientePagosPersonaDocumentoService.GuardarMejorEsfuerzo(cabeceraId, totalMontoDocumentos, sesion);
                    #endregion Agregar documentos en forma automatica
                }

                return casoId;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion CrearCaso

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PAGOS_PERSONA"; }
        }

        public static string Nombre_Vista
        {
            get { return "CTACTE_PAGOS_PERSONA_INFO_COMP"; }
        }

        public static string AutonumeracionAnticipoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.AUTONUMERACION_ANTICIPO_IDColumnName; }
        }

        public static string CasoAsociadoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.CASO_ASOCIADO_IDColumnName; }
        }

        public static string AutonumeracionReciboId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.AUTONUMERACION_RECIBO_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.CASO_IDColumnName; }
        }
        public static string CasoAnticipoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.CASO_ANTICIPO_IDColumnName; }
        }
        public static string CotizacionMoneda_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.COTIZACION_MONEDAColumnName; }
        }
        public static string CotizacionMonedaTotalVuelto_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.COTIZACION_MONEDA_TOTAL_VUELTOColumnName; }
        }
        public static string CtacteReciboId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.CTACTE_RECIBO_IDColumnName; }
        }
        public static string CtacteReciboNumero_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.CTACTE_RECIBO_NUMEROColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.FECHAColumnName; }
        }
        public static string FCCliente1CompAutonId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.FC_CLIENTE1_COMP_AUTON_IDColumnName; }
        }
        public static string FCCliente2CompAutonId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.FC_CLIENTE2_COMP_AUTON_IDColumnName; }
        }
        public static string FCCliente1ComprobanteId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.FC_CLIENTE1_COMPROBANTE_IDColumnName; }
        }
        public static string FCCliente2ComprobanteId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.FC_CLIENTE2_COMPROBANTE_IDColumnName; }
        }
        public static string FuncionarioCobradorId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.FUNCIONARIO_COBRADOR_IDColumnName; }
        }
        public static string FuncionarioCobradorExterId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.FUNCIONARIO_COBRADOR_EXTER_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.MONEDA_IDColumnName; }
        }
        public static string MonedaTotalVueltoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.MONEDA_TOTAL_VUELTO_IDColumnName; }
        }
        public static string MontoTotalVuelto_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.MONTO_TOTAL_VUELTOColumnName; }
        }
        public static string PagoConfirmado_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.PAGO_CONFIRMADOColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.PERSONA_IDColumnName; }
        }
        public static string ReciboEmitirPorDocumentos_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.RECIBO_EMITIR_POR_DOCUMENTOSColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.SUCURSAL_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string UsuarioCargaId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.USUARIO_CARGA_IDColumnName; }
        }
        public static string VueltoConvertidoAAnticipo_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.VUELTO_CONVERTIDO_A_ANTICIPOColumnName; }
        }
        public static string FechaConfirmacion_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONACollection.FECHA_CONFIRMACIONColumnName; }
        }
        public static string VistaCtacteReciboNroComprobante_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.CTACTE_RECIBO_NRO_COMPROBANTEColumnName; }
        }
        public static string FacturaFacturaClientecomp1CasoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.FACTURA_CLIENTE_COMP1_CASO_IDColumnName; }
        }
        public static string FacturaFacturaClientecomp2CasoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.FACTURA_CLIENTE_COMP2_CASO_IDColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaPersonaRuc_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.PERSONA_RUCColumnName; }
        }
        public static string VistaUsuarioNombreCompleto_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.USUARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaFuncionarioCobrExtNombre_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.FUNCIONARIO_COBR_EXT_NOMBREColumnName; }
        }
        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaMonedaTotalVueltoNombre_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.MONEDA_TOTAL_VUELTO_NOMBREColumnName; }
        }
        public static string VistaMonedaTotalVueltoSimbolo_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.MONEDA_TOTAL_VUELTO_SIMBOLOColumnName; }
        }
        public static string VistaCasoAnticipoEstadoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.CASO_ANTICIPO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.CASO_ESTADO_IDColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.CASO_IDColumnName; }
        }
        public static string VistaNombreTextoPredefinido_NombreCol
        {
            get { return CTACTE_PAGOS_PERSONA_INFO_COMPCollection.NOMBRE_TEXTO_PREDEFINIDOColumnName; }
        }
        #endregion Accessors

        #region Triggers
        private static TriggerPagoDePersonas trigger = new TriggerPagoDePersonas();

        private class TriggerPagoDePersonas : TriggerBase<CTACTE_PAGOS_PERSONARow>
        {
            public override void BeforeUpdate(ref CTACTE_PAGOS_PERSONARow fila_nueva, CTACTE_PAGOS_PERSONARow fila_vieja, SessionService sesion)
            {
                if (!fila_nueva.FECHA.Equals(fila_vieja.FECHA))
                    AlCambiarFecha(ref fila_nueva, fila_vieja, sesion);
            }

            private void AlCambiarFecha(ref CTACTE_PAGOS_PERSONARow fila_nueva, CTACTE_PAGOS_PERSONARow fila_vieja, SessionService sesion)
            {
                CASOSRow caso = CasosService.GetCasoPorId(fila_nueva.CASO_ID);
                caso.FECHA_CREACION = fila_nueva.FECHA.Date;
                CasosService.Actualizar(caso, sesion);
            }
        }
        #endregion Triggers

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static PagosDePersonaService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new PagosDePersonaService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable
        
        #region Propiedades
        protected CTACTE_PAGOS_PERSONARow row;
        protected CTACTE_PAGOS_PERSONARow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AutonumeracionAnticipoId { get { if (row.IsAUTONUMERACION_ANTICIPO_IDNull) return null; else return row.AUTONUMERACION_ANTICIPO_ID; } set { if (value.HasValue) row.AUTONUMERACION_ANTICIPO_ID = value.Value; else row.IsAUTONUMERACION_ANTICIPO_IDNull = true; } }
        public decimal? AutonumeracionReciboId { get { if (row.IsAUTONUMERACION_RECIBO_IDNull) return null; else return row.AUTONUMERACION_RECIBO_ID; } set { if (value.HasValue) row.AUTONUMERACION_RECIBO_ID = value.Value; else row.IsAUTONUMERACION_RECIBO_IDNull = true; } }
        public decimal? CasoAnticipoId { get { if (row.IsCASO_ANTICIPO_IDNull) return null; else return row.CASO_ANTICIPO_ID; } set { if (value.HasValue) row.CASO_ANTICIPO_ID = value.Value; else row.IsCASO_ANTICIPO_IDNull = true; } }
        public decimal? CasoAsociadoId { get { if (row.IsCASO_ASOCIADO_IDNull) return null; else return row.CASO_ASOCIADO_ID; } set { if (value.HasValue) row.CASO_ASOCIADO_ID = value.Value; else row.IsCASO_ASOCIADO_IDNull = true; } }
        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal CotizacionMoneda { get { return row.COTIZACION_MONEDA; } set { row.COTIZACION_MONEDA = value; } }
        public decimal CotizacionMonedaTotalVuelto { get { return row.COTIZACION_MONEDA_TOTAL_VUELTO; } set { row.COTIZACION_MONEDA_TOTAL_VUELTO = value; } }
        public decimal? CtacteReciboId { get { if (row.IsCTACTE_RECIBO_IDNull) return null; else return row.CTACTE_RECIBO_ID; } set { if (value.HasValue) row.CTACTE_RECIBO_ID = value.Value; else row.IsCTACTE_RECIBO_IDNull = true; } }
        public string CtacteReciboNumero { get { return ClaseCBABase.GetStringHelper(row.CTACTE_RECIBO_NUMERO); } set { row.CTACTE_RECIBO_NUMERO = value; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? FCCliente1CompAutonId { get { if (row.IsFC_CLIENTE1_COMP_AUTON_IDNull) return null; else return row.FC_CLIENTE1_COMP_AUTON_ID; } set { if (value.HasValue) row.FC_CLIENTE1_COMP_AUTON_ID = value.Value; else row.IsFC_CLIENTE1_COMP_AUTON_IDNull = true; } }
        public decimal? FCCliente1ComprobanteId { get { if (row.IsFC_CLIENTE1_COMPROBANTE_IDNull) return null; else return row.FC_CLIENTE1_COMPROBANTE_ID; } set { if (value.HasValue) row.FC_CLIENTE1_COMPROBANTE_ID = value.Value; else row.IsFC_CLIENTE1_COMPROBANTE_IDNull = true; } }
        public decimal? FCCliente2CompAutonId { get { if (row.IsFC_CLIENTE2_COMP_AUTON_IDNull) return null; else return row.FC_CLIENTE2_COMP_AUTON_ID; } set { if (value.HasValue) row.FC_CLIENTE2_COMP_AUTON_ID = value.Value; else row.IsFC_CLIENTE2_COMP_AUTON_IDNull = true; } }
        public decimal? FCCliente2ComprobanteId { get { if (row.IsFC_CLIENTE2_COMPROBANTE_IDNull) return null; else return row.FC_CLIENTE2_COMPROBANTE_ID; } set { if (value.HasValue) row.FC_CLIENTE2_COMPROBANTE_ID = value.Value; else row.IsFC_CLIENTE2_COMPROBANTE_IDNull = true; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public DateTime? FechaConfirmacion { get { if (row.IsFECHA_CONFIRMACIONNull) return null; else return row.FECHA_CONFIRMACION; } set { if (value.HasValue) row.FECHA_CONFIRMACION = value.Value; else row.IsFECHA_CONFIRMACIONNull = true; } }
        public decimal? FuncionarioCobradorExternoId { get { if (row.IsFUNCIONARIO_COBRADOR_EXTER_IDNull) return null; else return row.FUNCIONARIO_COBRADOR_EXTER_ID; } set { if (value.HasValue) row.FUNCIONARIO_COBRADOR_EXTER_ID = value.Value; else row.IsFUNCIONARIO_COBRADOR_EXTER_IDNull = true; } }
        public decimal FuncionarioCobradorId { get { return row.FUNCIONARIO_COBRADOR_ID; } set { row.FUNCIONARIO_COBRADOR_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MonedaTotalVueltoId { get { return row.MONEDA_TOTAL_VUELTO_ID; } set { row.MONEDA_TOTAL_VUELTO_ID = value; } }
        public decimal MontoTotalVuelto { get { return row.MONTO_TOTAL_VUELTO; } set { row.MONTO_TOTAL_VUELTO = value; } }
        public string PagoConfirmado { get { return ClaseCBABase.GetStringHelper(row.PAGO_CONFIRMADO); } set { row.PAGO_CONFIRMADO = value; } }
        public decimal PersonaId { get { return row.PERSONA_ID; } set { row.PERSONA_ID = value; } }
        public string ReciboEmitirPorDocumentos { get { return ClaseCBABase.GetStringHelper(row.RECIBO_EMITIR_POR_DOCUMENTOS); } set { row.RECIBO_EMITIR_POR_DOCUMENTOS = value; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        public decimal UsuarioCargaId { get { return row.USUARIO_CARGA_ID; } set { row.USUARIO_CARGA_ID = value; } }
        public string VueltoConvertidoAAnticipo { get { return ClaseCBABase.GetStringHelper(row.VUELTO_CONVERTIDO_A_ANTICIPO); } set { row.VUELTO_CONVERTIDO_A_ANTICIPO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    if (this.sesion != null)
                        this._caso = new CasosService(this.CasoId, this.sesion);
                    else
                        this._caso = new CasosService(this.CasoId);
                }
                return this._caso;
            }
        }
        
        private CasosService _caso_anticipo;
        public CasosService CasoAnticipo
        {
            get
            {
                if (this._caso_anticipo == null)
                {
                    if (this.sesion != null)
                        this._caso_anticipo = new CasosService(this.CasoAnticipoId.Value, this.sesion);
                    else
                        this._caso_anticipo = new CasosService(this.CasoAnticipoId.Value);
                }
                return this._caso_anticipo;
            }
        }

        private CasosService _caso_asociado;
        public CasosService CasoAsociado
        {
            get
            {
                if (this._caso_asociado == null)
                {
                    if (this.sesion != null)
                        this._caso_asociado = new CasosService(this.CasoAsociadoId.Value, this.sesion);
                    else
                        this._caso_asociado = new CasosService(this.CasoAsociadoId.Value);
                }
                return this._caso_asociado;
            }
        }

        private CuentaCorrienteRecibosService _ctacte_recibo;
        public CuentaCorrienteRecibosService CtacteRecibo
        {
            get
            {
                if (this._ctacte_recibo == null)
                {
                    if (this.sesion != null)
                        this._ctacte_recibo = new CuentaCorrienteRecibosService(this.CtacteReciboId.Value, this.sesion);
                    else
                        this._ctacte_recibo = new CuentaCorrienteRecibosService(this.CtacteReciboId.Value);
                }
                return this._ctacte_recibo;
            }
        }

        private FuncionariosService _funcionario_cobrador;
        public FuncionariosService FuncionarioCobrador
        {
            get
            {
                if (this._funcionario_cobrador == null)
                {
                    if (this.sesion != null)
                        this._funcionario_cobrador = new FuncionariosService(this.FuncionarioCobradorId, this.sesion);
                    else
                        this._funcionario_cobrador = new FuncionariosService(this.FuncionarioCobradorId);
                }
                return this._funcionario_cobrador;
            }
        }

        private FuncionariosService _funcionario_cobrador_externo;
        public FuncionariosService FuncionarioCobradorExterno
        {
            get
            {
                if (this._funcionario_cobrador_externo == null)
                {
                    if (this.sesion != null)
                        this._funcionario_cobrador_externo = new FuncionariosService(this.FuncionarioCobradorExternoId.Value, this.sesion);
                    else
                        this._funcionario_cobrador_externo = new FuncionariosService(this.FuncionarioCobradorExternoId.Value);
                }
                return this._funcionario_cobrador_externo;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                {
                    if (this.sesion != null)
                        this._moneda = new MonedasService(this.MonedaId, this.sesion);
                    else
                        this._moneda = new MonedasService(this.MonedaId);
                }
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

        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_PAGOS_PERSONARow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_PAGOS_PERSONARow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public PagosDePersonaService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PagosDePersonaService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PagosDePersonaService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public PagosDePersonaService(EdiCBA.Cobranza edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = PagosDePersonaService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.CasoId = edi.caso_id;

            if (edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionMoneda = edi.cotizacion.compra;
            this.CotizacionMonedaTotalVuelto = this.CotizacionMoneda;
            this.Estado = Definiciones.Estado.Activo;

            #region recibo
            if (!string.IsNullOrEmpty(edi.recibo_uuid))
                this._ctacte_recibo = CuentaCorrienteRecibosService.GetPorUUID(edi.recibo_uuid, sesion);
            if (this._ctacte_recibo == null && edi.recibo != null)
                this._ctacte_recibo = new CuentaCorrienteRecibosService(edi.recibo, almacenar_localmente, sesion);
            if (this._ctacte_recibo == null)
                throw new Exception("No se encontró el UUID " + edi.recibo_uuid + " ni se definieron los datos del objeto.");

            if (!this.CtacteRecibo.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.CtacteRecibo.Id.HasValue)
                this.CtacteReciboId = this.CtacteRecibo.Id.Value;
            #endregion recibo

            if (this.CtacteReciboId.HasValue)
                this.CtacteReciboNumero = this.CtacteRecibo.NroComprobante;
            this.Fecha = edi.fecha;

            #region funcionario cobrador
            if (!string.IsNullOrEmpty(edi.funcionario_uuid))
                this._funcionario_cobrador = FuncionariosService.GetPorUUID(edi.funcionario_uuid, sesion);
            if (this._funcionario_cobrador == null && edi.funcionario != null)
                this._funcionario_cobrador = new FuncionariosService(edi.funcionario, almacenar_localmente, sesion);
            if (this._funcionario_cobrador == null)
                throw new Exception("No se encontró el UUID " + edi.funcionario_uuid + " ni se definieron los datos del objeto.");

            if (!this.FuncionarioCobrador.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.FuncionarioCobrador.Id.HasValue)
                this.FuncionarioCobradorId = this.FuncionarioCobrador.Id.Value;
            #endregion funcionario cobrador

            #region funcionario cobrador externo
            if (!string.IsNullOrEmpty(edi.cobrador_externo_uuid))
                this._funcionario_cobrador_externo = FuncionariosService.GetPorUUID(edi.cobrador_externo_uuid, sesion);
            if (this._funcionario_cobrador_externo == null && edi.cobrador_externo != null)
                this._funcionario_cobrador_externo = new FuncionariosService(edi.cobrador_externo, almacenar_localmente, sesion);
            if (this._funcionario_cobrador_externo != null)
            {
                if (!this.FuncionarioCobradorExterno.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.FuncionarioCobradorExterno.Id.HasValue)
                    this.FuncionarioCobradorExternoId = this.FuncionarioCobradorExterno.Id.Value;
            }
            #endregion funcionario cobrador externo

            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.Moneda.ExisteEnDB && almacenar_localmente)
            {
                this.Moneda.IniciarUsingSesion(sesion);
                this.Moneda.Guardar();
                this.Moneda.FinalizarUsingSesion();
            }
            if (this.Moneda.Id.HasValue)
                this.MonedaId = this.Moneda.Id.Value;
            #endregion moneda

            this.MonedaTotalVueltoId = this.MonedaId;
            this.MontoTotalVuelto = edi.total_vuelto;
            this.PagoConfirmado = Definiciones.SiNo.No; //Se inicializa por defecto

            #region persona
            if (!string.IsNullOrEmpty(edi.persona_uuid))
                this._persona = PersonasService.GetPorUUID(edi.persona_uuid, sesion);
            if (this._persona == null && edi.persona != null)
                this._persona = new PersonasService(edi.persona, almacenar_localmente, sesion);
            if (this._persona == null)
                throw new Exception("No se encontró el UUID " + edi.persona_uuid + " ni se definieron los datos del objeto.");

            if (!this.Persona.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Persona.Id.HasValue)
                this.PersonaId = this.Persona.Id.Value;
            #endregion persona

            this.ReciboEmitirPorDocumentos = Definiciones.SiNo.Si; //Se inicializa por defecto

            #region sucursal
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal == null && edi.sucursal != null)
                this._sucursal = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this._sucursal == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");

            if (!this.Sucursal.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Sucursal.Id.HasValue)
                this.SucursalId = this.Sucursal.Id.Value;
            #endregion sucursal

            this.UsuarioCargaId = Definiciones.Usuarios.Soporte; //Se inicializa por defecto
            this.VueltoConvertidoAAnticipo = edi.vuelto_convertido_a_anticipo ? Definiciones.SiNo.Si : Definiciones.SiNo.No;

            #region caso
            if (!this.ExisteEnDB)
            {
                this._caso = new CasosService(
                    new EdiCBA.Caso()
                    {
                        estado_id = edi.estado_id,
                        funcionario_uuid = edi.funcionario_uuid,
                        funcionario = edi.funcionario,
                        nro_comprobante = edi.nro_comprobante,
                        persona_uuid = edi.persona_uuid,
                        persona = edi.persona,
                        proveedor_uuid = edi.proveedor_uuid,
                        proveedor = edi.proveedor,
                        sucursal_uuid = edi.sucursal_uuid,
                        sucursal = edi.sucursal
                    }, almacenar_localmente, sesion
                );
                this.Caso.FechaCreacion = edi.fecha;
                this.Caso.FechaFormulario = edi.fecha;
                this.Caso.FlujoId = Definiciones.FlujosIDs.PAGO_DE_PERSONAS;
                this.Caso.NroComprobante2 = string.Empty;
            }
            #endregion caso
        }
        private PagosDePersonaService(CTACTE_PAGOS_PERSONARow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCaso
        public static PagosDePersonaService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static PagosDePersonaService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.CTACTE_PAGOS_PERSONACollection.GetByCASO_ID(caso_id)[0];
            return new PagosDePersonaService(row);
        }
        #endregion GetPorCaso

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.Cobranza()
            {
                caso_id = this.CasoId,
                persona_uuid = this.Persona.GetOrCreateUUID(sesion),
                funcionario_uuid = this.FuncionarioCobrador.GetOrCreateUUID(sesion),
                cobrador_externo_uuid = this.FuncionarioCobradorExternoId.HasValue ? this.FuncionarioCobradorExterno.GetOrCreateUUID(sesion) : null,
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, PagosDePersonaService.CotizacionMoneda_NombreCol, this.Id.Value, sesion),
                estado_id = this.Caso.EstadoId,
                fecha = this.Fecha,
                moneda_uuid = this.Moneda.GetOrCreateUUID(sesion),
                recibo_uuid = this.CtacteReciboId.HasValue ? this.CtacteRecibo.GetOrCreateUUID(sesion) : null,
                sucursal_uuid = this.Sucursal.GetOrCreateUUID(sesion),
                total_vuelto = this.MontoTotalVuelto,
                vuelto_convertido_a_anticipo = this.VueltoConvertidoAAnticipo == Definiciones.SiNo.Si
            };

            var documentos = CuentaCorrientePagosPersonaDocumentoService.GetPorCabecera(this.Id.Value, sesion);
            e.cobranza_documentos_uuid = new string[documentos.Length];
            for (int i = 0; i < documentos.Length; i++)
                e.cobranza_documentos_uuid[i] = documentos[i].GetOrCreateUUID(sesion);

            var valores = CuentaCorrientePagosPersonaDetalleService.GetPorCabecera(this.Id.Value, sesion);
            e.cobranza_valores_uuid = new string[valores.Length];
            for (int i = 0; i < valores.Length; i++)
                e.cobranza_valores_uuid[i] = valores[i].GetOrCreateUUID(sesion);

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            { 
                e.persona = (EdiCBA.Persona)this.Persona.ToEDI(nueva_profundidad, sesion);
                e.funcionario = (EdiCBA.Funcionario)this.FuncionarioCobrador.ToEDI(nueva_profundidad, sesion);
                e.cobrador_externo = this.FuncionarioCobradorExternoId.HasValue ? (EdiCBA.Funcionario)this.FuncionarioCobradorExterno.ToEDI(nueva_profundidad, sesion) : null;
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.Fecha,
                    moneda_uuid = e.moneda_uuid,
                    venta = this.CotizacionMoneda
                };
                e.moneda = (EdiCBA.Moneda)this.Moneda.ToEDI(nueva_profundidad, sesion);
                e.recibo = this.CtacteReciboId.HasValue ? (EdiCBA.Recibo)this.CtacteRecibo.ToEDI(nueva_profundidad, sesion) : null;
                e.sucursal = (EdiCBA.Sucursal)this.Sucursal.ToEDI(nueva_profundidad, sesion);

                e.cobranza_documentos = new EdiCBA.CobranzaDocumento[documentos.Length];
                for (int i = 0; i < documentos.Length; i++)
                    e.cobranza_documentos[i] = (EdiCBA.CobranzaDocumento)documentos[i].ToEDI(nueva_profundidad, sesion);

                e.cobranza_valores = new EdiCBA.CobranzaValor[valores.Length];
                for (int i = 0; i < valores.Length; i++)
                    e.cobranza_valores[i] = (EdiCBA.CobranzaValor)valores[i].ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS        
    }
}
