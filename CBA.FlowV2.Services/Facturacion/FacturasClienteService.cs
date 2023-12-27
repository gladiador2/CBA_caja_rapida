#region Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Comercial;
using CBA.FlowV2.Services.Contabilidad;
using CBA.FlowV2.Services.DetallesPersonalizados;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.NotasCreditoPersona;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.ToolbarFlujo;
using System.Net;
using System.Text;
using System.IO;
using CBA.FlowV2.Services.General;
using Oracle.ManagedDataAccess.Client;

#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class FacturasClienteService : FlujosServiceBaseWorkaround
    {
        #region Clase Webmethods
        private static class Webmethods
        {
            #region Clase ConsultarNumeroDocumentoExterno
            public static class ConsultarNumeroDocumentoExterno
            {
                

                #region Cliente_13
                /// <summary>
                /// Cliente_13s the specified nro_documento_externo.
                /// </summary>
                /// <param name="nro_documento_externo">The nro_documento_externo.</param>
                /// <param name="nro_documento_persona">The nro_documento_persona.</param>
                /// <param name="nro_documento_garante1">The nro_documento_garante1.</param>
                /// <param name="nro_documento_garante2">The nro_documento_garante2.</param>
                /// <param name="nro_documento_garante3">The nro_documento_garante3.</param>
                /// <param name="cantidad_cuotas">The cantidad_cuotas.</param>
                /// <param name="monto_total">The monto_total.</param>
                /// <param name="mensaje">The mensaje.</param>
                /// <returns></returns>
                public static bool Cliente_13(FACTURAS_CLIENTERow factura_cliente, out string mensaje, SessionService sesion)
                {
                    decimal parametroId = Definiciones.Error.Valor.EnteroPositivo;

                    try
                    {
                        bool exito = false;
                        mensaje = string.Empty;
                        //Solo controlar si el estado es Pendiente o Caja
                        string estadoId = CasosService.GetEstadoCaso(factura_cliente.CASO_ID, sesion);
                        if (estadoId != Definiciones.EstadosFlujos.Pendiente && estadoId != Definiciones.EstadosFlujos.Caja)
                            return true;

                        if (factura_cliente.TIPO_FACTURA_ID == Definiciones.TipoFactura.Credito)
                            return true;

                        if (factura_cliente.TIPO_FACTURA_ID == Definiciones.TipoFactura.Contado && Interprete.EsNullODBNull(factura_cliente.NRO_DOCUMENTO_EXTERNO))
                        {
                            //Se obliga a que contenga nro documento externo si la factura
                            //incluye al articulo 033 Certificado Digital
                            string clausulas = FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + factura_cliente.ID + " and " +
                                               FacturasClienteDetalleService.ArticuloId_NombreCol + " = " + ArticulosService.GetArticuloId("033", factura_cliente.SUCURSAL_ID);
                            DataTable dtFacturaDetalles = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(clausulas, string.Empty);
                            if (dtFacturaDetalles.Rows.Count > 0)
                                throw new Exception("Las facturas contado que incluyen Certificado Digital deben definir el número de transacción.");
                            else 
                                return true;
                        }

                        DataTable dtPersona = null;
                        string nroDocPersona = string.Empty, nroRucPersona = string.Empty;
                        dtPersona = PersonasService.GetPersonasDataTable(PersonasService.Id_NombreCol + " = " + factura_cliente.PERSONA_ID, string.Empty);
                        nroDocPersona = (string)dtPersona.Rows[0][PersonasService.NumeroDocumento_NombreCol];
                        nroRucPersona = (string)dtPersona.Rows[0][PersonasService.Ruc_NombreCol] + "-" + TiposDocumentosIdentidadService.GetDigitoVerificadorRUC(dtPersona.Rows[0][PersonasService.Ruc_NombreCol].ToString());
                        parametroId = WebservicesParametrosService.Guardar(
                                                         Definiciones.Error.Valor.EnteroPositivo,
                                                         "validaTrx/findDigitoTrx",
                                                         factura_cliente.NRO_DOCUMENTO_EXTERNO + "@CBA@" + factura_cliente.CASO_ID + "@CBA@" + nroDocPersona + "@CBA@" + factura_cliente.TOTAL_NETO,
                                                         string.Empty,
                                                         true);
                        WebRequest req = WebRequest.Create("http://ws.documenta.com.py:8099/VistasRest/webresources/validaTrx/findDigitoTrx/" + factura_cliente.NRO_DOCUMENTO_EXTERNO.Trim());
                        req.Method = "GET";
                        req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("cbaflow:cbaflow"));
                        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                        StreamReader readStream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                        string respuesta = readStream.ReadToEnd();
                        Dictionary<string, object> resultado = JsonUtil.Deserializar<Dictionary<string, object>>(respuesta);
                        resp.Close();
                        readStream.Close();
                        if (resultado == null)
                            throw new Exception("Hubo un error en la respuesta a " + req.RequestUri.ToString());

                        WebservicesParametrosService.GuardarRespuesta(parametroId, respuesta);
                        mensaje = resultado["descRespuesta"].ToString();
                        switch (resultado["codRespuesta"].ToString())
                        {
                            case "1":
                                exito = true;
                                break;
                            case "2":
                                exito = false;
                                break;
                            case "3":
                                exito = false;
                                break;
                            default: throw new Exception("ConsultarNumeroDocumentoExterno. Código de respuesta no implementado.");
                        }

                        //Inicialmente se validaba persona y monto
                        //Finalmente Documenta decidio no controlar ninguna de las dos cosas
                        //if (exito)
                        //{
                        //    decimal montoTransaccion = decimal.Parse(resultado["monto"].ToString());
                        //    string nroDocumento = resultado["referencia"].ToString().Trim();

                        //    //Quitar los puntos
                        //    nroDocumento = nroDocumento.Replace(".", string.Empty);

                            //if (exito && montoTransaccion != factura_cliente.TOTAL_NETO)
                            //{
                            //    exito = false;
                            //    mensaje = "El pago realizado fue de " + montoTransaccion + " y el monto facturado es de " + factura_cliente.TOTAL_NETO + ".";
                            //}

                            //if (exito && nroDocumento != nroDocPersona && nroDocumento != nroRucPersona)
                            //{
                            //    exito = false;
                            //    mensaje = "El pago realizado fue con documento " + nroDocumento + " y la factura con " + nroDocPersona + ".";
                            //}
                        //}

                        return exito;
                    }
                    catch (Exception e)
                    {
                        if (!parametroId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            WebservicesParametrosService.GuardarRespuesta(parametroId, e.Message);

                        throw e;
                    }
                }
                #endregion Cliente_13
            }
            #endregion ConsultarNumeroDocumentoExterno

            #region Clase ActualizarNumeroDocumentoExterno
            public static class ActualizarNumeroDocumentoExterno
            {
               

                #region Cliente_13
                public static void Cliente_13(FACTURAS_CLIENTERow factura_cliente, out string mensaje, SessionService sesion)
                {
                    mensaje = string.Empty;
                    return;
                }
                #endregion Cliente_13
            }
            #endregion ActualizarNumeroDocumentoExterno
        }
        #endregion Clase Webmethods

        #region Implementacion de metodos abstract
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.FACTURACION_CLIENTE;
        }

        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var cabecera = (FacturasClienteService)caso_cabecera;
            var detalle = (FacturasClienteDetalleService)caso_detalle;
            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            if (cabecera.SucursalVentaId.HasValue)
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.SucursalRelacionada, cabecera.SucursalVentaId.Value);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, cabecera.DepositoId.Value);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, detalle.ArticuloId);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
            if(detalle.ActivoId.HasValue)
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, detalle.ActivoId.Value);
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
                FACTURAS_CLIENTERow cabeceraRow = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
                FACTURAS_CLIENTE_DETALLERow[] detalleRows = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByFACTURAS_CLIENTE_ID(cabeceraRow.ID);
                string valorAnteriorFactura = cabeceraRow.ToString();
                bool afectarStock = cabeceraRow.AFECTA_STOCK.Equals(Definiciones.SiNo.Si);
                bool afectarCtaCte = cabeceraRow.AFECTA_CTACTE.Equals(Definiciones.SiNo.Si);
                PersonasService persona = new PersonasService(cabeceraRow.PERSONA_ID, sesion);
                PersonasService personaGarante1 = null, personaGarante2 = null, personaGarante3 = null;
                if (!cabeceraRow.IsPERSONA_GARANTE_1_IDNull)
                    personaGarante1 = new PersonasService(cabeceraRow.PERSONA_GARANTE_1_ID, sesion);
                if (!cabeceraRow.IsPERSONA_GARANTE_2_IDNull)
                    personaGarante2 = new PersonasService(cabeceraRow.PERSONA_GARANTE_2_ID, sesion);
                if (!cabeceraRow.IsPERSONA_GARANTE_3_IDNull)
                    personaGarante3 = new PersonasService(cabeceraRow.PERSONA_GARANTE_3_ID, sesion);
                if (cabeceraRow.ESTADO.Equals(Definiciones.Estado.Inactivo))
                    throw new Exception("Error. El caso fue borrado.");

                #region Borrador a Anulado
                //Borrador a Anulado
                if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                   estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Acciones
                    //Se devuelven los articulos al stock pero no se borran del 
                    //detalle de la NP dejandolos a modo informativo.

                    #region Modificar stock
                    foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                    {
                        StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                             detalle.ARTICULO_ID,
                                             Interprete.Redondear(-detalle.CANTIDAD_UNITARIA_TOTAL_ORIG, 2),
                                             Definiciones.Stock.TipoMovimiento.Venta, caso_id, detalle.LOTE_ID, estado_destino,
                                             sesion, null, detalle.IMPUESTO_ID, detalle.ID);
                        //Si es un Combo Representativo lo desconsolida para devolver los componentes del mismo
                        if (ArticulosService.EsComboRepresentativo(detalle.ARTICULO_ID))
                            ArticulosCombosStockService.DesconsolidarCombo(detalle.CANTIDAD_UNITARIA_TOTAL_DEST, detalle.LOTE_ID, cabeceraRow.DEPOSITO_ID, cabeceraRow.CASO_ID, sesion, estado_destino);
                        //Se modifica la cantidad de las relaciones con las notas de pedido y remisiones, si las hubiera
                        decimal auxNotaPedidoDetalle = NotasDePedidoDetalleFacturaClienteRelacionesService.GetPedidosClienteDetalleIdPorFacturaDetalleId(detalle.ID);
                        if (auxNotaPedidoDetalle != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            decimal auxNotaPedido = NotasDePedidoDetalleService.GetNotaDePedidoIdPorId(auxNotaPedidoDetalle);
                            var estadoCaso = CasosService.GetEstadoCaso(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido));
                            if (!estadoCaso.Equals(Definiciones.EstadosFlujos.Preparado))
                            {
                                NotasDePedidosService NotasDePedido = new NotasDePedidosService();
                                NotasDePedido.CambiarAPreparado(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido));
                            }
                            NotasDePedidoDetalleFacturaClienteRelacionesService.ModificarDetallePorIdFacturaCliente(detalle.ID, detalle.CANTIDAD_UNIDAD_DESTINO, sesion, true);
                        }
                        RemisionesDetalleFacturaClienteRelacionesService.ModificarDetallePorIdFacturaCliente(detalle.ID, detalle.CANTIDAD_UNIDAD_DESTINO, sesion, true);
                    }
                    #endregion Modificar stock

                    exito = true;
                    revisarRequisitos = true;
                }
                #endregion Borrador a Anulado

                #region Borrador a Pendiente
                //Borrador a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //Copiar los detalles personalizados de referencia al historico para que no sean modificables
                    //Si la variable de sistema FCClienteValidarNroDocumentoExterno es S entonces controlar el numero de documento externo
                    exito = true;
                    revisarRequisitos = true;
                    string clausulas;
                    DataTable dtDetallesPersonalizados;
                    if (detalleRows.Length <= 0)
                    {
                        mensaje = "La factura no tiene detalles.";
                        exito = false;
                    }
                    if (cabeceraRow.TOTAL_MONTO_BRUTO <= 0)
                    {
                        mensaje = "La factura debe tener un monto mayor a cero.";
                        exito = false;
                    }

                    PersonasBloqueosService personasBloqueos = new PersonasBloqueosService();
                    if (exito && cambio_pedido_por_usuario && personasBloqueos.PersonaBloqueada(persona.Id.Value))
                    {
                        mensaje = Traducciones.La_persona_esta_bloqueada;
                        exito = false;
                    }

                    #region Verificar linea de credito persona y co-deudores
                    if (exito && cabeceraRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCControlLineaCredito).Equals(Definiciones.SiNo.Si))
                    {
                        if (!persona.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("La persona no cuenta con suficiente saldo en su línea de crédito.");
                        if (personaGarante1 != null && !personaGarante1.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("El garante 1 no cuenta con suficiente saldo en su línea de crédito.");
                        if (personaGarante2 != null && !personaGarante1.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("El garante 2 no cuenta con suficiente saldo en su línea de crédito.");
                        if (personaGarante3 != null && !personaGarante1.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("El garante 3 no cuenta con suficiente saldo en su línea de crédito.");
                    }
                    #endregion Verificar linea de credito persona y co-deudores

                    //Validar el documento externo si la estrategia de precios es WebService
                    int estrategiaPrecio = int.Parse(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio).ToString());
                    if (exito && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                        exito = GetConsultarNumeroDocumentoExterno(cabeceraRow, out mensaje, sesion);

                    #region Verificar Cantidad Minima y Porcentaje maximo de descuento por lista de precio
                    if (estrategiaPrecio == Definiciones.EstrategiaPrecio.FlujoModificacionListaPrecios && cabeceraRow.CONTROLAR_CANT_MIN_DESC_MAX.Equals(Definiciones.SiNo.Si))
                    {
                        for (int i = 0; i < detalleRows.Length; i++)
                        {
                            if (!ListaDePrecio.ListasDePrecioService.CumpleConCantMinimaDescMaximo(cabeceraRow.LISTA_PRECIO_ID, detalleRows[i].ARTICULO_ID, detalleRows[0].CANTIDAD_UNITARIA_TOTAL_DEST, detalleRows[i].PORCENTAJE_DTO))
                            {
                                string codigoArticulo = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + detalleRows[i].ARTICULO_ID, string.Empty, false, cabeceraRow.SUCURSAL_ID).Rows[0][ArticulosService.CodigoEmpresa_NombreCol].ToString();
                                mensaje += " No se cumple con la cantidad mínima o descuento máximo establecidos en la lista de precios para el artículo " + codigoArticulo + "\n";
                                exito = false;
                            }
                        }
                    }
                    #endregion Verificar Cantidad Minima y Porcentaje maximo de descuento por lista de precio

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    //Copiar los detalles personalizados de referencias al historico para que no sean modificables
                    if (exito)
                    {
                        #region Detalles personalizados - Referencia creditos de terceros
                        clausulas = LegajoService.PersonaId_NombreCol + " = " + cabeceraRow.PERSONA_ID + " and " +
                                    LegajoService.VistaTipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros + " and " +
                                    LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                        dtDetallesPersonalizados = LegajoService.GetLegajoInfoCompleta(clausulas, string.Empty);
                        if (dtDetallesPersonalizados.Rows.Count > 0)
                            DetallesPersonalizados.DetallesPersonalizadosHistoricoService.Guardar(Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, dtDetallesPersonalizados.Rows[0][LegajoService.Id_NombreCol].ToString(), true, cabeceraRow.CASO_ID, sesion);
                        #endregion Detalles personalizados - Referencia creditos de terceros

                        #region Detalles personalizados - Referencias personales
                        clausulas = LegajoService.PersonaId_NombreCol + " = " + cabeceraRow.PERSONA_ID + " and " +
                                    LegajoService.VistaTipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasPersonales + " and " +
                                    LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                        dtDetallesPersonalizados = LegajoService.GetLegajoInfoCompleta(clausulas, string.Empty);
                        if (dtDetallesPersonalizados.Rows.Count > 0)
                            DetallesPersonalizados.DetallesPersonalizadosHistoricoService.Guardar(Definiciones.TiposDetallesPersonalizado.ReferenciasPersonales, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, dtDetallesPersonalizados.Rows[0][LegajoService.Id_NombreCol].ToString(), true, cabeceraRow.CASO_ID, sesion);
                        #endregion Detalles personalizados - Referencias personales

                        #region Detalles personalizados - Referencias Laborales
                        clausulas = LegajoService.PersonaId_NombreCol + " = " + cabeceraRow.PERSONA_ID + " and " +
                                    LegajoService.VistaTipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasLaborales + " and " +
                                    LegajoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                        dtDetallesPersonalizados = LegajoService.GetLegajoInfoCompleta(clausulas, string.Empty);
                        if (dtDetallesPersonalizados.Rows.Count > 0)
                            DetallesPersonalizados.DetallesPersonalizadosHistoricoService.Guardar(Definiciones.TiposDetallesPersonalizado.ReferenciasLaborales, LegajoService.Nombre_Tabla, LegajoService.Id_NombreCol, dtDetallesPersonalizados.Rows[0][LegajoService.Id_NombreCol].ToString(), true, cabeceraRow.CASO_ID, sesion);
                        #endregion Detalles personalizados - Referencias Laborales
                    }
                }
                #endregion Borrador a Pendiente

                #region Pendiente a Borrador
                //Pendiente a Borrador 
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                {
                    //Acciones
                    //Se actualiza el monto en que afecta la FC a la linea de credito.
                    //Borrar los detalles personalizados de referencias del historico para que puedan volver a ser editados
                    exito = true;
                    string clausulas;
                    DataTable dtDetallesActuales;
                    // si se tiene el permiso de imprimir en Pendiente se debe controlar que la factura no fue impresa par
                    // para que los datos del documento impreso no difieran a los datos del sistema.
                    // tener en cuenta que si se tiene el rol de "Editar en pendiente" no se debe permitir la impresión en Pendiente.
                    if (exito && cabeceraRow.IMPRESO.Equals(Definiciones.SiNo.Si))
                    {
                        mensaje = "La Factura ya fue impresa, ya no puede volver al estado Borrador";
                    }
                    //Si el caso afecta a la linea de credito
                    if (exito && cabeceraRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si)
                    {
                        //Se disminuye de la linea el monto total de la FC
                        cabeceraRow.MONTO_AFECTA_LINEA_CREDITO = 0;
                    }
                    //Borrar los detalles personalizados de referencias del historico para que puedan volver a ser editados
                    if (exito)
                    {
                        #region Detalles personalizados - Referencia creditos de terceros
                        //Borrar posibles valores almacenados previamente para el tipo de detalle y caso dados
                        clausulas = DetallesPersonalizadosHistoricoService.TipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasCreditoTerceros + " and " +
                                    DetallesPersonalizadosHistoricoService.CasoId_NombreCol + " = " + caso_id;
                        dtDetallesActuales = sesion.Db.DETALLES_PERSONALIZADOS_HISTCollection.GetAsDataTable(clausulas, string.Empty);
                        for (int i = 0; i < dtDetallesActuales.Rows.Count; i++)
                        {
                            DetallesPersonalizadosHistoricoDetallesService.Borrar((decimal)dtDetallesActuales.Rows[i][DetallesPersonalizadosHistoricoService.Id_NombreCol], sesion);
                        }
                        #endregion Detalles personalizados - Referencia creditos de terceros

                        #region Detalles personalizados - Referencias personales
                        //Borrar posibles valores almacenados previamente para el tipo de detalle y caso dados
                        clausulas = DetallesPersonalizadosHistoricoService.TipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasPersonales + " and " +
                                    DetallesPersonalizadosHistoricoService.CasoId_NombreCol + " = " + caso_id;
                        dtDetallesActuales = sesion.Db.DETALLES_PERSONALIZADOS_HISTCollection.GetAsDataTable(clausulas, string.Empty);
                        for (int i = 0; i < dtDetallesActuales.Rows.Count; i++)
                        {
                            DetallesPersonalizadosHistoricoDetallesService.Borrar((decimal)dtDetallesActuales.Rows[i][DetallesPersonalizadosHistoricoService.Id_NombreCol], sesion);
                        }
                        #endregion Detalles personalizados - Referencias personales

                        #region Detalles personalizados - Referencias Laborales
                        //Borrar posibles valores almacenados previamente para el tipo de detalle y caso dados
                        clausulas = DetallesPersonalizadosHistoricoService.TipoDetallePersonalizadoId_NombreCol + " = " + Definiciones.TiposDetallesPersonalizado.ReferenciasLaborales + " and " +
                                    DetallesPersonalizadosHistoricoService.CasoId_NombreCol + " = " + caso_id;
                        dtDetallesActuales = sesion.Db.DETALLES_PERSONALIZADOS_HISTCollection.GetAsDataTable(clausulas, string.Empty);
                        for (int i = 0; i < dtDetallesActuales.Rows.Count; i++)
                        {
                            DetallesPersonalizadosHistoricoDetallesService.Borrar((decimal)dtDetallesActuales.Rows[i][DetallesPersonalizadosHistoricoService.Id_NombreCol], sesion);
                        }
                        #endregion Detalles personalizados - Referencias Laborales
                    }
                }
                #endregion Pendiente a Borrador

                #region Pendiente a Para-Reparto
                //Pendiente a Para-Reparto
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.ParaReparto))
                {
                    //Acciones:
                    //Ninguna                        
                    //Si algun articulo del detalle no tiene codigo interno de la Empresa, el caso no puede ser pasado a ParaReparto
                    //Si la variable de sistema FCClienteValidarNroDocumentoExterno es S entonces controlar el numero de documento externo
                    exito = true;
                    revisarRequisitos = true;
                    if (detalleRows.Length <= 0)
                    {
                        mensaje = "La factura no tiene detalles.";
                        exito = false;
                    }
                    if (cabeceraRow.TOTAL_MONTO_BRUTO <= 0)
                    {
                        mensaje = "La factura debe tener un monto mayor a cero.";
                        exito = false;
                    }
                    if (exito && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                        exito = GetConsultarNumeroDocumentoExterno(cabeceraRow, out mensaje, sesion);

                    #region Controla que los articulos tengan codigo de empresa
                    if (exito)
                    {
                        foreach (FACTURAS_CLIENTE_DETALLERow d in detalleRows)
                        {
                            ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(d.ARTICULO_ID);
                            //no pueden facturarse articulos sin codigo interno (de la Empresa)
                            if (articulo.CODIGO_EMPRESA == null)
                            {
                                exito = false;
                                mensaje = "El artículo con descripción '" + articulo.DESCRIPCION_INTERNA + "' no tiene definido el código interno. \nArtículos sin código interno no pueden ser facturados.";
                                break;
                            }
                        }
                    }
                    #endregion Controla que los articulos tengan codigo de empresa

                    #region Control de familia exclusiva
                    if (exito)
                    {
                        ARTICULOS_FAMILIASRow familiaExclusiva = null;
                        foreach (FACTURAS_CLIENTE_DETALLERow d in detalleRows)
                        {
                            ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(d.ARTICULO_ID);
                            ARTICULOS_FAMILIASRow familia = sesion.Db.ARTICULOS_FAMILIASCollection.GetByPrimaryKey(articulo.FAMILIA_ID);
                            if (familia.EXCLUSIVO == Definiciones.SiNo.Si)
                            {
                                familiaExclusiva = familia;
                                break;
                            }
                        }

                        if (familiaExclusiva != null)
                        {
                            foreach (FACTURAS_CLIENTE_DETALLERow d in detalleRows)
                            {
                                ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(d.ARTICULO_ID);
                                ARTICULOS_FAMILIASRow familia = sesion.Db.ARTICULOS_FAMILIASCollection.GetByPrimaryKey(articulo.FAMILIA_ID);
                                if (familia.ID != familiaExclusiva.ID)
                                {
                                    mensaje = string.Format("La familia {0} es exclusiva y se agregaron artículos de la familia {1}",
                                        familiaExclusiva.NOMBRE,
                                        familia.NOMBRE);
                                    exito = false;
                                    break;
                                }
                            }
                        }
                    }
                    #endregion Control de familia exclusiva

                    #region Control de calendario pagos (suma igual a total factura)
                    if (exito)
                    {
                        try
                        {
                            decimal totalPagos = cabeceraRow.TOTAL_ENTREGA_INICIAL + CalendarioPagosFCClienteService.GetTotal(cabeceraRow.ID, sesion);
                            if (Interprete.Redondear(totalPagos, 2) != Interprete.Redondear(cabeceraRow.TOTAL_NETO, 2))
                            {
                                exito = false;
                                mensaje = "La suma de los Pagos no coinciden con el total de la factura";
                            }
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }
                    #endregion Control de calendario pagos (suma igual a total factura)

                    #region Verificar linea de credito persona y co-deudores
                    if (exito && cabeceraRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCControlLineaCredito).Equals(Definiciones.SiNo.Si))
                    {
                        if (!persona.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("La persona no cuenta con suficiente saldo en su línea de crédito.");
                        if (personaGarante1 != null && !personaGarante1.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("El garante 1 no cuenta con suficiente saldo en su línea de crédito.");
                        if (personaGarante2 != null && !personaGarante1.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("El garante 2 no cuenta con suficiente saldo en su línea de crédito.");
                        if (personaGarante3 != null && !personaGarante1.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("El garante 3 no cuenta con suficiente saldo en su línea de crédito.");
                    }
                    #endregion Verificar linea de credito persona y co-deudores

                    #region Actualizar datos linea credito
                    if (cabeceraRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si && cabeceraRow.IsCASO_ORIGEN_IDNull)
                    {
                        decimal factor = 1;
                        decimal cotizacionLineaCredito = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(cabeceraRow.SUCURSAL_ID), persona.MonedaLimiteCreditoId, cabeceraRow.FECHA, sesion);
                        if (persona.MonedaLimiteCreditoId != cabeceraRow.MONEDA_DESTINO_ID)
                            factor = cotizacionLineaCredito / cabeceraRow.COTIZACION_DESTINO;

                        //Se actualiza la cotizacion de la moneda de la linea de credito, en el detalle
                        foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                        {
                            detalle.COTIZACION_MONEDA_LINEA_CRED = cotizacionLineaCredito;
                            sesion.Db.FACTURAS_CLIENTE_DETALLECollection.Update(detalle);
                        }

                        //Se actualiza el monto en el que afecta la FC a la linea de credito
                        cabeceraRow.MONTO_AFECTA_LINEA_CREDITO = factor * cabeceraRow.TOTAL_NETO;
                    }
                    #endregion Actualizar datos linea credito

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado
                }
                #endregion Pendiente a Para-Reparto

                #region Para-Reparto a Pendiente
                //Para-Reparto a Pendiente
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.ParaReparto) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Acciones
                    //ninguna
                    exito = true;
                }
                #endregion Para-Reparto a Pendiente

                #region Para-Reparto a En-Reparto
                //Para-reparto a En-reparto
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.ParaReparto) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.EnReparto))
                {
                    //Solo el sistema puede utilizar esta transicion. Lo hace cuando una FC disponible para-reparto se incluye en
                    //un caso de reparto.
                    if (cambio_pedido_por_usuario)
                    {
                        exito = false;
                        mensaje = "Solo el sistema puede utilizar la transición 'Para Reparto' -> 'En Reparto'";
                    }

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado
                }
                #endregion Para-Reparto a En-Reparto

                #region En-Reparto a Para-Reparto
                //En-reparto a Para-reparto
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnReparto) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.ParaReparto))
                {
                    //Solo el sistema puede utilizar esta transicion. Lo hace cuando el caso de
                    //reparto que incluye a la FC NO se entrego correctamente y debe ser reasignado a otro posterior caso de reparto.
                    if (cambio_pedido_por_usuario)
                    {
                        exito = false;
                    }
                    else
                    {
                        exito = true;
                    }
                }
                #endregion En-Reparto a Para-Reparto

                #region En-Reparto a Caja
                //En-reparto a Caja
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnReparto) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Caja))
                {
                    //Solo el sistema puede utilizar esta transicion. Lo hace cuando el caso de
                    //reparto que incluye a la FC se entrego correctamente

                    //Acciones: 
                    //Se controla que tenga una caja de sucursal asignada
                    //Se bloquea a la persona si utilizo un aumento temporal de linea de credito.
                    //Se afecta la ctacte.

                    #region ControlesGenerales
                    CalendarioPagosFCClienteService pagos = new CalendarioPagosFCClienteService();
                    exito = true;
                    revisarRequisitos = true;
                    System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                    decimal[] impuestoId, monto, montoCuota;
                    decimal montoVerificacion;
                    int indiceAux;
                    #endregion ControlesGenerales

                    #region Controlar que tenga una caja asignada
                    if (cabeceraRow.ES_RAPIDA == Definiciones.SiNo.No)
                    {
                        if (cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                            throw new Exception("No se definió la caja de sucursal asignada.");
                    }                     
                    #endregion Controlar que tenga una caja asignada

                    #region Generar numeracion
                    if (cabeceraRow.IsVENDEDOR_IDNull)
                        throw new Exception("Debe indicar el vendedor");

                    decimal funcionarioId = Definiciones.Error.Valor.EnteroPositivo;
                    if (!cabeceraRow.IsVENDEDOR_IDNull)
                        funcionarioId = cabeceraRow.VENDEDOR_ID;
                    else if (!sesion.Usuario.IsFUNCIONARIO_IDNull)
                        funcionarioId = sesion.Usuario.FUNCIONARIO_ID;
                    if (!AutonumeracionesService.FuncionarioPuedeUsar(cabeceraRow.AUTONUMERACION_ID, funcionarioId, sesion))
                        throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");

                    if (AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_ID, sesion))
                    {
                        if (cabeceraRow.NRO_COMPROBANTE.Length != AutonumeracionesService.GetCantidadCaracteres(cabeceraRow.AUTONUMERACION_ID, sesion))
                        {
                            throw new Exception("Debe indicarse el Numero correcto de comprobante");

                        }
                    }
                    if (exito && (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length <= 0 || cabeceraRow.NRO_COMPROBANTE.Length <= 8))
                    {
                        try
                        {
                            if (cabeceraRow.IsAUTONUMERACION_IDNull)
                                throw new Exception("Debe indicarse el talonario o un número de comprobante manual.");
                            if (AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_ID, sesion))
                                throw new Exception("Debe indicar el número de comprobante que es de numeración manual.");
                            //Se debe traer el siguiente numero para completar las validaciones. Aun no se debe actualizar el talonario
                            string nroComprobanteAux = AutonumeracionesService.ConsultarSiguienteNumero(cabeceraRow.AUTONUMERACION_ID, sesion);
                            decimal nroComprobanteNumerico = Definiciones.Error.Valor.EnteroPositivo;
                            if (FacturasClienteService.GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, nroComprobanteAux, sesion))
                                throw new Exception("Ya existe una factura con el mismo número de comprobante.");

                            //Controlar que se logro asignar una numeracion
                            if (nroComprobanteAux.Equals(""))
                            {
                                exito = false;
                                mensaje = "No se pudo asignar una numeración válida";
                            }
                            //Si se pasaron todas las validaciones. Generar comprobante.
                            cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, out nroComprobanteNumerico, sesion);
                            cabeceraRow.NRO_COMPROBANTE_SECUENCIA = nroComprobanteNumerico;
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                            throw exp;
                        }
                    }
                    #endregion Generar numeracion

                    #region Calcular monto por tipo de impuesto
                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        if (montoPorImpuesto.Contains(detalleRows[i].IMPUESTO_ID))
                            montoPorImpuesto[detalleRows[i].IMPUESTO_ID] = (decimal)montoPorImpuesto[detalleRows[i].IMPUESTO_ID] + detalleRows[i].TOTAL_NETO * (100 - cabeceraRow.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;
                        else
                            montoPorImpuesto.Add(detalleRows[i].IMPUESTO_ID, detalleRows[i].TOTAL_NETO * (100 - cabeceraRow.PORCENTAJE_DESC_SOBRE_TOTAL) / 100);
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

                    if (cabeceraRow.TOTAL_NETO != montoVerificacion)
                        throw new Exception("Error en FacturasClienteService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + cabeceraRow.TOTAL_NETO + ".");
                    #endregion Calcular monto por tipo de impuesto

                    #region Afectar ctacte
                    if (exito && afectarCtaCte)
                    {
                        try
                        {
                            //Ingresar el credito
                            DataTable dtAux = CalendarioPagosFCClienteService.GetCalendariosPagosPorFactura(cabeceraRow.ID);
                            DataTable dtPagos = CalendarioPagosFCClienteService.RedondeoCuotasFc(cabeceraRow, sesion, dtAux);

                            if (dtPagos.Rows.Count > 0)
                            {
                                #region Ingresar entrega inicial
                                if (cabeceraRow.TOTAL_ENTREGA_INICIAL > 0)
                                {
                                    montoCuota = new decimal[monto.Length];

                                    //Como el monto por impuesto contiene el total de la factura
                                    //Se distribuye dicho total segun el monto de la cuota
                                    for (int j = 0; j < monto.Length; j++)
                                        montoCuota[j] = monto[j] / cabeceraRow.TOTAL_NETO * cabeceraRow.TOTAL_ENTREGA_INICIAL;

                                    CuentaCorrientePersonasService.AgregarCredito((decimal)cabeceraRow.PERSONA_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteConceptos.EntregaInicial,
                                                            cabeceraRow.CASO_ID,
                                                            cabeceraRow.MONEDA_DESTINO_ID,
                                                            cabeceraRow.COTIZACION_DESTINO,
                                                            impuestoId,
                                                            montoCuota,
                                                            string.Empty,
                                                            cabeceraRow.FECHA,
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
                                                            dtPagos.Rows.Count,
                                                            sesion);
                                }
                                #endregion Ingresar entrega inicial

                                for (int i = 0; i < dtPagos.Rows.Count; i++)
                                {
                                    montoCuota = new decimal[monto.Length];

                                    //Como el monto por impuesto contiene el total de la factura
                                    //Se distribuye dicho total segun el monto de la cuota
                                    for (int j = 0; j < monto.Length; j++)
                                    {
                                        if (!(cabeceraRow.TOTAL_NETO * (decimal)dtPagos.Rows[i][CalendarioPagosFCClienteService.MontoCapital_NombreCol]).Equals(0))
                                            montoCuota[j] = monto[j] / cabeceraRow.TOTAL_NETO * (decimal)dtPagos.Rows[i][CalendarioPagosFCClienteService.MontoCapital_NombreCol];
                                        else
                                            montoCuota[j] = 0;
                                    }

                                    CuentaCorrientePersonasService.AgregarCredito((decimal)cabeceraRow.PERSONA_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                            cabeceraRow.CASO_ID,
                                                            cabeceraRow.MONEDA_DESTINO_ID,
                                                            cabeceraRow.COTIZACION_DESTINO,
                                                            impuestoId,
                                                            montoCuota,
                                                            string.Empty,
                                                            (DateTime)dtPagos.Rows[i][CalendarioPagosFCClienteService.FechaVencimiento_NombreCol],
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            (decimal)dtPagos.Rows[i][CalendarioPagosFCClienteService.Id_NombreCol],
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            i + 1,
                                                            dtPagos.Rows.Count,
                                                            sesion);
                                }
                            }
                            else
                            {
                                exito = false;
                                mensaje = "No existen Pagos para esta factura";
                            }
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }
                    #endregion afectar ctacte

                    #region Comisiones
                    string estrategiaComisionVendedor = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.EstrategiaComision);
                    if (exito && estrategiaComisionVendedor.Equals(Definiciones.TiposComision.ComisionPorVenta) && cabeceraRow.AFECTA_CTACTE.Equals(Definiciones.SiNo.Si))
                    {
                        System.Collections.Hashtable totalesComision = new System.Collections.Hashtable();
                        foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                        {
                            if (detalle.IsVENDEDOR_COMISIONISTA_IDNull)
                                continue;

                            if (!totalesComision.Contains(detalle.VENDEDOR_COMISIONISTA_ID))
                                totalesComision[detalle.VENDEDOR_COMISIONISTA_ID] = (decimal)0;

                            totalesComision[detalle.VENDEDOR_COMISIONISTA_ID] = (decimal)totalesComision[detalle.VENDEDOR_COMISIONISTA_ID] + detalle.MONTO_COMISION_VEN;
                        }

                        foreach (decimal vendedorComisionistaId in totalesComision.Keys)
                        {
                            if ((decimal)totalesComision[vendedorComisionistaId] == 0)
                                continue;

                            FuncionariosComisionesService funcionarioComisiones = new FuncionariosComisionesService();
                            System.Collections.Hashtable campos = new System.Collections.Hashtable();
                            campos.Add(FuncionariosComisionesService.CasoId_NombreCol, casoRow.ID);
                            campos.Add(FuncionariosComisionesService.Cobrado_NombreCol, Definiciones.SiNo.No);
                            campos.Add(FuncionariosComisionesService.Cotizacion_NombreCol, cabeceraRow.COTIZACION_DESTINO);
                            campos.Add(FuncionariosComisionesService.Fecha_NombreCol, DateTime.Now);
                            campos.Add(FuncionariosComisionesService.FuncionarioId_NombreCol, vendedorComisionistaId);
                            campos.Add(FuncionariosComisionesService.MonedaId_NombreCol, cabeceraRow.MONEDA_DESTINO_ID);
                            campos.Add(FuncionariosComisionesService.Monto_NombreCol, totalesComision[vendedorComisionistaId]);
                            campos.Add(FuncionariosComisionesService.TipoComision_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                            campos.Add(FuncionariosComisionesService.TipoFuncionario_NombreCol, Definiciones.TipoFuncionarioComision.Vendedor);
                            funcionarioComisiones.Guardar(campos, true, sesion);
                        }

                        DataTable dtPromotores = PromotoresService.GetPromotoresDeClientesInfoCompleta(cabeceraRow.PERSONA_ID);

                        foreach (DataRow rowPromotor in dtPromotores.Rows)
                        {
                            string clausulas = ObjetivosPromotorasService.Anho_NombreCol + " = " + DateTime.Now.Year +
                                " and " + ObjetivosPromotorasService.PersonaId_NombreCol + " = " + cabeceraRow.PERSONA_ID +
                                " and " + ObjetivosPromotorasService.FuncionarioId_NombreCol + " = " + rowPromotor[PromotoresService.FuncionarioId_NombreCol].ToString();
                            DataTable dtObjetivosPromotoras = ObjetivosPromotorasService.GetObjetivosPromotorasDataTable(clausulas, string.Empty);
                            if (dtObjetivosPromotoras.Rows.Count > 0)
                            {
                                decimal montoComision = (cabeceraRow.TOTAL_NETO - cabeceraRow.TOTAL_MONTO_IMPUESTO) * (decimal)dtObjetivosPromotoras.Rows[0][ObjetivosPromotorasService.PorcentajeComision_NombreCol] / 100;
                                if (montoComision != 0)
                                {
                                    FuncionariosComisionesService funcionarioComisiones = new FuncionariosComisionesService();
                                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                    campos.Add(FuncionariosComisionesService.CasoId_NombreCol, casoRow.ID);
                                    campos.Add(FuncionariosComisionesService.Cobrado_NombreCol, Definiciones.SiNo.No);
                                    campos.Add(FuncionariosComisionesService.Cotizacion_NombreCol, cabeceraRow.COTIZACION_DESTINO);
                                    campos.Add(FuncionariosComisionesService.Fecha_NombreCol, DateTime.Now);
                                    campos.Add(FuncionariosComisionesService.FuncionarioId_NombreCol, rowPromotor[PromotoresService.FuncionarioId_NombreCol]);
                                    campos.Add(FuncionariosComisionesService.MonedaId_NombreCol, cabeceraRow.MONEDA_DESTINO_ID);
                                    campos.Add(FuncionariosComisionesService.Monto_NombreCol, montoComision);
                                    campos.Add(FuncionariosComisionesService.TipoComision_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                                    campos.Add(FuncionariosComisionesService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                                    campos.Add(FuncionariosComisionesService.TipoFuncionario_NombreCol, Definiciones.TipoFuncionarioComision.Promotor);
                                    funcionarioComisiones.Guardar(campos, true, sesion);
                                }
                            }
                        }
                    }

                    #endregion Comisiones

                    #region Modificar stock
                    if (exito && afectarStock)
                    {
                        foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                        {
                            decimal deposito = cabeceraRow.DEPOSITO_ID;
                            if (!detalle.IsDEPOSITO_IDNull)
                                deposito = detalle.DEPOSITO_ID;
                            StockService.modificarStock(deposito,
                                                   detalle.ARTICULO_ID,
                                                   Interprete.Redondear(detalle.CANTIDAD_UNITARIA_TOTAL_ORIG, 2),
                                                   Definiciones.Stock.TipoMovimiento.Venta, caso_id, detalle.LOTE_ID, estado_destino,
                                                   sesion, null, detalle.IMPUESTO_ID, detalle.ID);
                        }
                    }
                    #endregion Modificar stock

                    if (cambio_pedido_por_usuario)
                    {
                        exito = false;
                        mensaje = "Solo el sistema puede utilizar la transición 'En Reparto' -> 'Caja'";
                    }
                }
                #endregion En-Reparto a Caja

                #region Pendiente a Caja
                //Pendiente a Caja
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Caja))
                {
                    //Acciones
                    //Se controla que tenga una caja de sucursal asignada
                    //Si la variable de sistema FCClienteValidarNroDocumentoExterno es S entonces controlar el numero de documento externo
                    //Se genera la numeracion de la FC a partir de la autonumeracion que haya indicado el usuario, si el 
                    //caso no tenia previamente un numero asignado (i.e. realizo la transicion anteriormete). 
                    //Se actualizan los datos de como afecta la FC a la linea de credito.
                    //Se bloquea a la persona si utilizo un aumento temporal de linea de credito.
                    //Se afecta la ctacte.

                    #region ControlesGenerales
                    CalendarioPagosFCClienteService pagos = new CalendarioPagosFCClienteService();
                    // Este cambio se realiza cuando no es necesario un reparto para el paso de la factura por el flujo reparto
                    exito = true;
                    revisarRequisitos = false;

                    System.Collections.Hashtable montoPorImpuesto = new System.Collections.Hashtable();
                    decimal[] impuestoId, monto, montoCuota;
                    decimal montoVerificacion;
                    int indiceAux;

                    if (detalleRows.Length <= 0)
                    {
                        mensaje = "La factura no tiene detalles.";
                        exito = false;
                    }
                    if (cabeceraRow.TOTAL_MONTO_BRUTO <= 0)
                    {
                        mensaje = "La factura debe tener un monto mayor a cero.";
                        exito = false;
                    }

                    PersonasBloqueosService personasBloqueos = new PersonasBloqueosService();
                    if (exito && cambio_pedido_por_usuario && personasBloqueos.PersonaBloqueada(persona.Id.Value))
                    {
                        mensaje = "La pesona se encuentra bloqueada";
                        exito = false;
                    }
                    #endregion ControlesGenerales

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    if (exito && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                        exito = GetConsultarNumeroDocumentoExterno(cabeceraRow, out mensaje, sesion);

                    #region Controlar que tenga una caja asignada
                    if (cabeceraRow.ES_RAPIDA == Definiciones.SiNo.No)
                    {
                        if (cabeceraRow.IsCTACTE_CAJA_SUCURSAL_IDNull)
                            throw new Exception("No se definió la caja de sucursal asignada.");
                    }
                  
                    #endregion Controlar que tenga una caja asignada

                    #region Control de familias exclusivas
                    if (exito)
                    {
                        ARTICULOS_FAMILIASRow familiaExclusiva = null;
                        foreach (FACTURAS_CLIENTE_DETALLERow d in detalleRows)
                        {
                            ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(d.ARTICULO_ID);
                            ARTICULOS_FAMILIASRow familia = sesion.Db.ARTICULOS_FAMILIASCollection.GetByPrimaryKey(articulo.FAMILIA_ID);
                            if (familia.EXCLUSIVO == Definiciones.SiNo.Si)
                            {
                                familiaExclusiva = familia;
                                break;
                            }
                        }
                        if (familiaExclusiva != null)
                        {
                            foreach (FACTURAS_CLIENTE_DETALLERow d in detalleRows)
                            {
                                ARTICULOSRow articulo = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(d.ARTICULO_ID);
                                ARTICULOS_FAMILIASRow familia = sesion.Db.ARTICULOS_FAMILIASCollection.GetByPrimaryKey(articulo.FAMILIA_ID);
                                if (familia.ID != familiaExclusiva.ID)
                                {
                                    mensaje = string.Format("La familia {0} es exclusiva y se agregaron artículos de la familia {1}",
                                        familiaExclusiva.NOMBRE,
                                        familia.NOMBRE);
                                    exito = false;
                                    break;
                                }
                            }
                        }
                    }
                    #endregion Control de familias exclusivas

                    #region Control de calendario pagos (suma igual al monto factura)
                    if (exito)
                    {
                        try
                        {
                            decimal totalPagos = cabeceraRow.TOTAL_ENTREGA_INICIAL + CalendarioPagosFCClienteService.GetTotal(cabeceraRow.ID, sesion);
                            if (Interprete.Redondear(totalPagos, 2) != Interprete.Redondear(cabeceraRow.TOTAL_NETO, 2))
                            {
                                exito = false;
                                mensaje = "La suma de los Pagos no coinciden con el total de la factura";
                            }

                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }
                    #endregion Control de calendario pagos (suma igual al monto factura)

                    #region Verificar linea de credito persona y co-deudores
                    if (exito && cabeceraRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCControlLineaCredito).Equals(Definiciones.SiNo.Si))
                    {
                        if (!persona.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("La persona no cuenta con suficiente saldo en su línea de crédito.");

                        if (personaGarante1 != null && !personaGarante1.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("El garante 1 no cuenta con suficiente saldo en su línea de crédito.");

                        if (personaGarante2 != null && !personaGarante1.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("El garante 2 no cuenta con suficiente saldo en su línea de crédito.");

                        if (personaGarante3 != null && !personaGarante1.ControlLineaCredito(cabeceraRow.CASO_ID, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.TOTAL_NETO, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.SUCURSAL_ID, cabeceraRow.FECHA, sesion))
                            throw new Exception("El garante 3 no cuenta con suficiente saldo en su línea de crédito.");
                    }
                    #endregion Verificar linea de credito persona y co-deudores

                    #region Actualizar datos linea credito
                    if (cabeceraRow.AFECTA_LINEA_CREDITO == Definiciones.SiNo.Si && cabeceraRow.IsCASO_ORIGEN_IDNull)
                    {
                        decimal factor = 1;
                        decimal cotizacionLineaCredito = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(cabeceraRow.SUCURSAL_ID), persona.MonedaLimiteCreditoId, cabeceraRow.FECHA, sesion);

                        if (persona.MonedaLimiteCreditoId != cabeceraRow.MONEDA_DESTINO_ID)
                            factor = cotizacionLineaCredito / cabeceraRow.COTIZACION_DESTINO;

                        //Se actualiza la cotizacion de la moneda de la linea de credito, en el detalle
                        foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                        {
                            detalle.COTIZACION_MONEDA_LINEA_CRED = cotizacionLineaCredito;
                            sesion.Db.FACTURAS_CLIENTE_DETALLECollection.Update(detalle);
                        }

                        //Se actualiza el monto en el que afecta la FC a la linea de credito
                        cabeceraRow.MONTO_AFECTA_LINEA_CREDITO = factor * cabeceraRow.TOTAL_NETO;
                    }
                    #endregion Actualizar datos linea credito

                    #region Generar numeracion
                    decimal funcionarioId = Definiciones.Error.Valor.EnteroPositivo;
                    if (!cabeceraRow.IsVENDEDOR_IDNull)
                        funcionarioId = cabeceraRow.VENDEDOR_ID;
                    else if (!sesion.Usuario.IsFUNCIONARIO_IDNull)
                        funcionarioId = sesion.Usuario.FUNCIONARIO_ID;
                    if (!AutonumeracionesService.FuncionarioPuedeUsar(cabeceraRow.AUTONUMERACION_ID, funcionarioId, sesion))
                        throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");

                    if (AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_ID, sesion))
                    {
                        if (cabeceraRow.NRO_COMPROBANTE.Length != AutonumeracionesService.GetCantidadCaracteres(cabeceraRow.AUTONUMERACION_ID, sesion))
                        {
                            throw new Exception("Debe indicarse el Numero correcto de comprobante");

                        }
                    }

                    if (exito && (cabeceraRow.NRO_COMPROBANTE == null || cabeceraRow.NRO_COMPROBANTE.Length <= 0 || cabeceraRow.NRO_COMPROBANTE.Length <= 8))
                    {
                        try
                        {
                            if (cabeceraRow.IsAUTONUMERACION_IDNull)
                                throw new Exception("Debe indicarse el talonario o un número de comprobante manual.");

                            if (AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_ID, sesion))
                            {
                                throw new Exception("Debe indicar el número de comprobante que es de numeración manual.");
                            }
                            else
                            {
                                //Se debe traer el siguiente numero para completar las validaciones. Aun no se debe actualizar el talonario
                                string nroComprobanteAux = AutonumeracionesService.ConsultarSiguienteNumero(cabeceraRow.AUTONUMERACION_ID, sesion);
                                decimal nroComprobanteNumerico = Definiciones.Error.Valor.EnteroPositivo;

                                if (FacturasClienteService.GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, nroComprobanteAux, sesion))
                                    throw new Exception("Ya existe una factura con el mismo número de comprobante.");

                                //Controlar que se logro asignar una numeracion
                                if (nroComprobanteAux.Equals(""))
                                {
                                    exito = false;
                                    mensaje = "No se pudo asignar una numeración válida";
                                }

                                //Si se pasaron todas las validaciones. Generar comprobante.
                                cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, out nroComprobanteNumerico, sesion);
                                cabeceraRow.NRO_COMPROBANTE_SECUENCIA = nroComprobanteNumerico;
                            }
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                            throw exp;
                        }
                    }
                    #endregion Generar numeracion

                    #region Calcular monto por tipo de impuesto
                    for (int i = 0; i < detalleRows.Length; i++)
                    {
                        if (montoPorImpuesto.Contains(detalleRows[i].IMPUESTO_ID))
                            montoPorImpuesto[detalleRows[i].IMPUESTO_ID] = (decimal)montoPorImpuesto[detalleRows[i].IMPUESTO_ID] + detalleRows[i].TOTAL_NETO * (100 - cabeceraRow.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;
                        else
                            montoPorImpuesto.Add(detalleRows[i].IMPUESTO_ID, detalleRows[i].TOTAL_NETO * (100 - cabeceraRow.PORCENTAJE_DESC_SOBRE_TOTAL) / 100);
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

                    if (cabeceraRow.TOTAL_NETO != montoVerificacion)
                        throw new Exception("Error en FacturasClienteService.ProcesarCambioEstado(). El desglose de monto por impuesto suma " + montoVerificacion + " mientras que el total en cabecera suma " + cabeceraRow.TOTAL_NETO + ".");
                    #endregion Calcular monto por tipo de impuesto

                    decimal ctactePersonaId = Definiciones.Error.Valor.EnteroPositivo;
                    #region Afectar ctacte
                    if (exito && afectarCtaCte)
                    {
                        try
                        {
                            //Ingresar el credito
                            DataTable dtAux = CalendarioPagosFCClienteService.GetCalendariosPagosPorFactura(cabeceraRow.ID, sesion);
                            DataTable dtPagos = CalendarioPagosFCClienteService.RedondeoCuotasFc(cabeceraRow, sesion, dtAux);


                            if (dtPagos.Rows.Count > 0)
                            {
                                #region Ingresar entrega inicial
                                if (cabeceraRow.TOTAL_ENTREGA_INICIAL > 0)
                                {
                                    montoCuota = new decimal[monto.Length];

                                    //Como el monto por impuesto contiene el total de la factura
                                    //Se distribuye dicho total segun el monto de la cuota
                                    for (int j = 0; j < monto.Length; j++)
                                        montoCuota[j] = monto[j] / cabeceraRow.TOTAL_NETO * cabeceraRow.TOTAL_ENTREGA_INICIAL;

                                    CuentaCorrientePersonasService.AgregarCredito((decimal)cabeceraRow.PERSONA_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteConceptos.EntregaInicial,
                                                            cabeceraRow.CASO_ID,
                                                            cabeceraRow.MONEDA_DESTINO_ID,
                                                            cabeceraRow.COTIZACION_DESTINO,
                                                            impuestoId,
                                                            montoCuota,
                                                            string.Empty,
                                                            cabeceraRow.FECHA,
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
                                                            dtPagos.Rows.Count,
                                                            sesion);
                                }
                                #endregion Ingresar entrega inicial

                                for (int i = 0; i < dtPagos.Rows.Count; i++)
                                {
                                    montoCuota = new decimal[monto.Length];

                                    //Como el monto por impuesto contiene el total de la factura
                                    //Se distribuye dicho total segun el monto de la cuota
                                    for (int j = 0; j < monto.Length; j++)
                                        if (!(cabeceraRow.TOTAL_NETO * (decimal)dtPagos.Rows[i][CalendarioPagosFCClienteService.MontoCapital_NombreCol]).Equals(0))
                                            montoCuota[j] = monto[j] / cabeceraRow.TOTAL_NETO * (decimal)dtPagos.Rows[i][CalendarioPagosFCClienteService.MontoCapital_NombreCol];
                                        else
                                            montoCuota[j] = 0;

                                    ctactePersonaId = CuentaCorrientePersonasService.AgregarCredito((decimal)cabeceraRow.PERSONA_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.CuentaCorrienteConceptos.CreditoPorFlujo,
                                                            cabeceraRow.CASO_ID,
                                                            cabeceraRow.MONEDA_DESTINO_ID,
                                                            cabeceraRow.COTIZACION_DESTINO,
                                                            impuestoId,
                                                            montoCuota,
                                                            string.Empty,
                                                            (DateTime)dtPagos.Rows[i][CalendarioPagosFCClienteService.FechaVencimiento_NombreCol],
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            (decimal)dtPagos.Rows[i][CalendarioPagosFCClienteService.Id_NombreCol],
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            i + 1,
                                                            dtPagos.Rows.Count,
                                                            sesion);
                                }
                            }
                            else if (cabeceraRow.TOTAL_NETO == 0)
                            {
                                //Si el total neto es cero es correcto que no se inserten cuotas
                                //ni se lance un error
                            }
                            else
                            {
                                exito = false;
                                mensaje = "No existen Pagos para esta factura";
                            }
                        }
                        catch (Exception exp)
                        {
                            mensaje = exp.Message.ToString();
                            exito = false;
                        }
                    }
                    #endregion afectar ctacte

                    #region Comisiones
                    string estrategiaComisionVendedor = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.EstrategiaComision);
                    if (exito && estrategiaComisionVendedor.Equals(Definiciones.TiposComision.ComisionPorVenta) && afectarCtaCte)
                    {
                        System.Collections.Hashtable totalesComision = new System.Collections.Hashtable();
                        foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                        {
                            if (detalle.IsVENDEDOR_COMISIONISTA_IDNull)
                                continue;

                            if (!totalesComision.Contains(detalle.VENDEDOR_COMISIONISTA_ID))
                                totalesComision[detalle.VENDEDOR_COMISIONISTA_ID] = (decimal)0;

                            totalesComision[detalle.VENDEDOR_COMISIONISTA_ID] = (decimal)totalesComision[detalle.VENDEDOR_COMISIONISTA_ID] + detalle.MONTO_COMISION_VEN;
                        }

                        foreach (decimal vendedorComisionistaId in totalesComision.Keys)
                        {
                            if ((decimal)totalesComision[vendedorComisionistaId] > 0)
                            {
                                FuncionariosComisionesService funcionarioComisiones = new FuncionariosComisionesService();
                                System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                campos.Add(FuncionariosComisionesService.CasoId_NombreCol, casoRow.ID);
                                campos.Add(FuncionariosComisionesService.Cobrado_NombreCol, Definiciones.SiNo.No);
                                campos.Add(FuncionariosComisionesService.Cotizacion_NombreCol, cabeceraRow.COTIZACION_DESTINO);
                                campos.Add(FuncionariosComisionesService.Fecha_NombreCol, DateTime.Now);
                                campos.Add(FuncionariosComisionesService.FuncionarioId_NombreCol, vendedorComisionistaId);
                                campos.Add(FuncionariosComisionesService.MonedaId_NombreCol, cabeceraRow.MONEDA_DESTINO_ID);
                                campos.Add(FuncionariosComisionesService.Monto_NombreCol, totalesComision[vendedorComisionistaId]);
                                campos.Add(FuncionariosComisionesService.TipoComision_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                                campos.Add(FuncionariosComisionesService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                                campos.Add(FuncionariosComisionesService.TipoFuncionario_NombreCol, Definiciones.TipoFuncionarioComision.Vendedor);
                                funcionarioComisiones.Guardar(campos, true, sesion);
                            }
                        }

                        DataTable dtPromotores = PromotoresService.GetPromotoresDeClientesInfoCompleta(cabeceraRow.PERSONA_ID);

                        foreach (DataRow rowPromotor in dtPromotores.Rows)
                        {
                            string clausulas = ObjetivosPromotorasService.Anho_NombreCol + " = " + DateTime.Now.Year +
                                " and " + ObjetivosPromotorasService.PersonaId_NombreCol + " = " + cabeceraRow.PERSONA_ID +
                                " and " + ObjetivosPromotorasService.FuncionarioId_NombreCol + " = " + rowPromotor[PromotoresService.FuncionarioId_NombreCol].ToString();
                            DataTable dtObjetivosPromotoras = ObjetivosPromotorasService.GetObjetivosPromotorasDataTable(clausulas, string.Empty);
                            if (dtObjetivosPromotoras.Rows.Count > 0)
                            {
                                decimal montoComision = (cabeceraRow.TOTAL_NETO - cabeceraRow.TOTAL_MONTO_IMPUESTO) * (decimal)dtObjetivosPromotoras.Rows[0][ObjetivosPromotorasService.PorcentajeComision_NombreCol] / 100;
                                if (montoComision != 0)
                                {
                                    FuncionariosComisionesService funcionarioComisiones = new FuncionariosComisionesService();
                                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                                    campos.Add(FuncionariosComisionesService.CasoId_NombreCol, casoRow.ID);
                                    campos.Add(FuncionariosComisionesService.Cobrado_NombreCol, Definiciones.SiNo.No);
                                    campos.Add(FuncionariosComisionesService.Cotizacion_NombreCol, cabeceraRow.COTIZACION_DESTINO);
                                    campos.Add(FuncionariosComisionesService.Fecha_NombreCol, DateTime.Now);
                                    campos.Add(FuncionariosComisionesService.FuncionarioId_NombreCol, rowPromotor[PromotoresService.FuncionarioId_NombreCol]);
                                    campos.Add(FuncionariosComisionesService.MonedaId_NombreCol, cabeceraRow.MONEDA_DESTINO_ID);
                                    campos.Add(FuncionariosComisionesService.Monto_NombreCol, montoComision);
                                    campos.Add(FuncionariosComisionesService.TipoComision_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                                    campos.Add(FuncionariosComisionesService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                                    campos.Add(FuncionariosComisionesService.TipoFuncionario_NombreCol, Definiciones.TipoFuncionarioComision.Promotor);
                                    funcionarioComisiones.Guardar(campos, true, sesion);
                                }
                            }
                        }
                    }
                    #endregion Comisiones

                    #region Modificar stock
                    if (exito && afectarStock)
                    {
                        foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                        {
                            if (detalle.IsDEPOSITO_IDNull)
                            {
                                StockService.modificarStock(cabeceraRow.DEPOSITO_ID,
                                       detalle.ARTICULO_ID,
                                       Interprete.Redondear(detalle.CANTIDAD_UNITARIA_TOTAL_ORIG, 2),
                                       Definiciones.Stock.TipoMovimiento.Venta, caso_id, detalle.LOTE_ID, estado_destino,
                                       sesion, null, detalle.IMPUESTO_ID, detalle.ID);
                            }
                            else
                            {
                                StockService.modificarStock(detalle.DEPOSITO_ID,
                                   detalle.ARTICULO_ID,
                                   Interprete.Redondear(detalle.CANTIDAD_UNITARIA_TOTAL_ORIG, 2),
                                   Definiciones.Stock.TipoMovimiento.Venta, caso_id, detalle.LOTE_ID, estado_destino,
                                   sesion, null, detalle.IMPUESTO_ID, detalle.ID);
                            }

                        }
                    }
                    #endregion Modificar stock

                    #region Crear Transferencia y Factura Proveedor

                    //si se selecciona transferencia

                    if (cabeceraRow.GENERAR_TRANSFERENCIA.Equals(Definiciones.SiNo.Si))
                    {
                        //genera la cabecera de transferencia
                        decimal sucursalDestinoId = StockDepositosService.GetSucursalId(cabeceraRow.DEPOSITO_DESTINO_ID);

                        decimal caso_transferencia = Definiciones.Error.Valor.EnteroPositivo;
                        string estado_transferencia = string.Empty;

                        StockTransferenciasService transferenciaService = new StockTransferenciasService();
                        ToolbarFlujoService toolbarService = new ToolbarFlujoService();

                        exito = StockTransferenciasService.CrearTransferencia(sucursalDestinoId, cabeceraRow.SUCURSAL_ID, cabeceraRow.DEPOSITO_ID, cabeceraRow.DEPOSITO_DESTINO_ID, cabeceraRow.FECHA, cabeceraRow.MONEDA_DESTINO_ID, 0, cabeceraRow.COTIZACION_DESTINO, cabeceraRow.AUTONUMERACION_TRANSF_ID, ref caso_transferencia, ref estado_transferencia, sesion);

                        //genera el detalle de transferencia 
                        if (exito)
                        {
                            for (int i = 0; i < detalleRows.Length; i++)
                            {
                                StockTransferenciaDetalleService.CrearTransferenciaDetalle(caso_transferencia, detalleRows[i].ARTICULO_ID, detalleRows[i].LOTE_ID, detalleRows[i].UNIDAD_DESTINO_ID, detalleRows[i].CANTIDAD_UNIDAD_DESTINO, detalleRows[i].CANTIDAD_EMBALADA, detalleRows[i].CANTIDAD_POR_CAJA_DESTINO, detalleRows[i].COSTO_MONEDA_ID, detalleRows[i].COTIZACION_ORIGEN, detalleRows[i].CANTIDAD_UNITARIA_TOTAL_DEST, detalleRows[i].COSTO_ID, sesion);
                            }
                        }

                        //se cambia de estado el caso de trasnferencia y se genera el caso espejo
                        exito = transferenciaService.ProcesarCambioEstado(caso_transferencia, Definiciones.EstadosFlujos.Pendiente, true, out mensaje, sesion);
                        if (exito)
                            exito = toolbarService.ProcesarCambioEstado(caso_transferencia, Definiciones.EstadosFlujos.Pendiente, "Paso de Estado Automatico por Aprobacion de Factura Caso Nro.: " + caso_id, sesion);
                        if (exito)
                            transferenciaService.EjecutarAccionesLuegoDeCambioEstado(caso_transferencia, Definiciones.EstadosFlujos.Pendiente, sesion);

                        if (exito)
                            exito = transferenciaService.ProcesarCambioEstado(caso_transferencia, Definiciones.EstadosFlujos.Aprobado, true, out mensaje, sesion);
                        if (exito)
                            exito = toolbarService.ProcesarCambioEstado(caso_transferencia, Definiciones.EstadosFlujos.Aprobado, "Paso de Estado Automatico por Aprobacion de Factura Caso Nro.: " + caso_id, sesion);
                        if (exito)
                            transferenciaService.EjecutarAccionesLuegoDeCambioEstado(caso_transferencia, Definiciones.EstadosFlujos.Aprobado, sesion);

                        if (exito)
                            exito = transferenciaService.ProcesarCambioEstado(caso_transferencia, Definiciones.EstadosFlujos.Viajando, true, out mensaje, sesion);
                        if (exito)
                            exito = toolbarService.ProcesarCambioEstado(caso_transferencia, Definiciones.EstadosFlujos.Viajando, "Paso de Estado Automatico por Aprobacion de Factura Caso Nro.: " + caso_id, sesion);
                        if (exito)
                            transferenciaService.EjecutarAccionesLuegoDeCambioEstado(caso_transferencia, Definiciones.EstadosFlujos.Viajando, sesion);

                        if (exito)
                        {
                            //se genera cabecera de factura proveedor
                            FacturasProveedorService.PropiedadesCabecera cabeceraProveedor = new FacturasProveedorService.PropiedadesCabecera();
                            decimal facturaProveedorCasoId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal facturaProveedorId = Definiciones.Error.Valor.EnteroPositivo;

                            cabeceraProveedor = FacturasProveedorService.CrearCabecera(sucursalDestinoId, cabeceraRow.DEPOSITO_DESTINO_ID, cabeceraRow.PERSONA_ID, cabeceraRow.FECHA, cabeceraRow.MONEDA_DESTINO_ID, cabeceraRow.OBSERVACION, cabeceraRow.NRO_TIMBRADO_FACT_PRO, cabeceraRow.FECHA_VENC_TIMBRADO_FACT_PRO, cabeceraRow.NRO_COMPROBANTE_FACT_PRO, cabeceraRow.CASO_ID, ref facturaProveedorCasoId, ref facturaProveedorId, cabeceraRow.CONDICION_PAGO_ID, cabeceraRow.PORCENTAJE_DESC_SOBRE_TOTAL, cabeceraRow.AFECTA_CTACTE.Equals(Definiciones.SiNo.No), sesion);
                            if (!facturaProveedorCasoId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            {
                                //se genera el detalle de factura proveedor
                                FacturasProveedorDetalleService.PropiedadesDetalle detalleProveedor = new FacturasProveedorDetalleService.PropiedadesDetalle();
                                for (int i = 0; i < detalleRows.Length; i++)
                                {
                                    detalleProveedor = FacturasProveedorDetalleService.CrearDetalle(facturaProveedorId, detalleRows[i].ARTICULO_ID, detalleRows[i].CANTIDAD_UNIDAD_DESTINO, detalleRows[i].LOTE_ID, detalleRows[i].PRECIO_LISTA_DESTINO, false, sesion);
                                }

                                //se cambia de estado la factura proveedor de borrador a aprobado
                                FacturasProveedorService facturaProveedorService = new FacturasProveedorService();
                                if (exito)
                                    exito = facturaProveedorService.ProcesarCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Pendiente, true, out mensaje, sesion);
                                if (exito)
                                    exito = toolbarService.ProcesarCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Pendiente, "Paso de Estado Automatico por Aprobacion de Factura Caso Nro.: " + facturaProveedorCasoId, sesion);
                                if (exito)
                                    facturaProveedorService.EjecutarAccionesLuegoDeCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                                if (exito)
                                    exito = facturaProveedorService.ProcesarCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Aprobado, true, out mensaje, sesion);
                                if (exito)
                                    toolbarService.ProcesarCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Aprobado, "Paso de Estado Automatico por Aprobacion de Factura Caso Nro.: " + facturaProveedorCasoId, sesion);
                                if (exito)
                                    facturaProveedorService.EjecutarAccionesLuegoDeCambioEstado(facturaProveedorCasoId, Definiciones.EstadosFlujos.Aprobado, sesion);
                            }
                            else
                            {
                                exito = false;
                                mensaje = "No se puede realizar la transferencia de articulo. No se encontro ningun Proveedor asignado.";
                            }
                        }
                    }
                    #endregion Crear Transferencia y Factura Proveedor

                    #region Nota de Pedido
                    foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                    {
                        var notaPedidoDetalleId = NotasDePedidoDetalleFacturaClienteRelacionesService.GetPedidosClienteDetalleIdPorFacturaDetalleId(detalle.ID);
                        if (notaPedidoDetalleId != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            var notaPedidoId = NotasDePedidoDetalleService.GetNotaDePedidoIdPorId(notaPedidoDetalleId);

                            var estadoCaso = CasosService.GetEstadoCaso(NotasDePedidosService.GetCasoIdPorId(notaPedidoId));

                            if (!estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                decimal cantidadFacturada = NotasDePedidosService.GetCantidadFacturada(notaPedidoId);
                                decimal cantidadPedida = NotasDePedidosService.GetCantidadPedida(notaPedidoId);

                                if (cantidadFacturada - cantidadPedida == 0)
                                {
                                    NotasDePedidosService NotasDePedido = new NotasDePedidosService();
                                    NotasDePedido.CambiarAAprobado(NotasDePedidosService.GetCasoIdPorId(notaPedidoId));
                                }
                            }
                        }
                    }
                    #endregion Nota de Pedido
                    
                    var cobranzaContado = this.GetPasarelaCambioEstadoCampo("FacturaClienteCobranzaContado");
                    if (cobranzaContado != null)
                    {
                        if (ctactePersonaId != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            PagosDePersonaService.CrearCaso((decimal)cabeceraRow.SUCURSAL_ID,
                                                            (decimal)cabeceraRow.PERSONA_ID,
                                                            DateTime.Now,
                                                            (decimal)cabeceraRow.MONEDA_DESTINO_ID,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            string.Empty,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            new decimal[] { ctactePersonaId },
                                                            new decimal[] { (decimal)cabeceraRow.TOTAL_NETO },
                                                            Definiciones.CuentaCorrienteValores.Efectivo,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            string.Empty,
                                                            Definiciones.Error.Valor.EnteroPositivo,
                                                            false,
                                                            (decimal)cabeceraRow.CASO_ID,
                                                            sesion);
                        }
                    }

                    #region Notificar cliente
                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.NotificarFacturasPendienteCaja) == Definiciones.SiNo.Si)
                    {
                        if (persona.Email1 != string.Empty)
                        {
                            using (EmailService correo = new EmailService(false, sesion))
                            {
                                string asunto = "Notificacion de Facturas";
                                CTACTE_PERSONAS_INFO_COMPLETARow[] ctacte = sesion.db.CTACTE_PERSONAS_INFO_COMPLETACollection.GetAsArray(CuentaCorrientePersonasService.PersonaId_NombreCol + " = " + cabeceraRow.PERSONA_ID +
                                                    " and " + CuentaCorrientePersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo +
                                                    "' and " + CuentaCorrientePersonasService.Credito_NombreCol + " > " + CuentaCorrientePersonasService.Debito_NombreCol,
                                                    CuentaCorrientePersonasService.Id_NombreCol + " desc");
                                string mailCuerpo = @"
                <html>
                    <head>
		                <title>Reporte</title>
		                <style>
			                h2, h3 { color: darkslategray; }
			                td { 
				                width: 100px;
				                padding-right: 10px;
			                }
		                </style>
	                </head>
                    <body>
                        <h2>" + asunto + @"</h2>
                        <table>
                            <tr>
                                <td><strong>N° de Factura</strong></td>
                                <td><strong>Timbrado</strong></td>
                                <td><strong>Fecha</strong></td>
                                <td><strong>Saldo</strong></td>
                            </tr> 
                            <tr>
                                <td>" + cabeceraRow.NRO_COMPROBANTE + @"</td>
                                <td>" + AutonumeracionesService.GetAutonumeracionesDataTable(AutonumeracionesService.Id_NombreCol + " = " + cabeceraRow.AUTONUMERACION_ID, string.Empty).Rows[0][AutonumeracionesService.NumeroTimbrado_NombreCol].ToString() + @"</td>
                                <td>" + cabeceraRow.FECHA.ToShortDateString() + @"</td>
                                <td>" + cabeceraRow.TOTAL_NETO + @"</td>
                            </tr>
                        </table>
                        <h3>Detalles</h3>
                        <table>
                            <tr>
                                <td><strong>Articulo</strong></td>
                                <td><strong>Cantidad</strong></td>
                                <td><strong>Total</strong></td>
                            </tr>";
                                foreach (var det in detalleRows)
                                {
                                    mailCuerpo += @"
                            <tr> 
                                <td>" + ArticulosService.GetDescripcionInterna(det.ARTICULO_ID) + @"</td>
                                <td>" + det.CANTIDAD_UNIDAD_DESTINO + @"</td>
                                <td>" + det.TOTAL_NETO + @"</td>
                            </tr>";
                                }
                                mailCuerpo += @"
                        </table>
                        <br><br>";
                                if (ctacte.Length > 0)
                                {
                                    mailCuerpo += @"
                        <h2>Facturas Pendientes</h2>
                        <table>
                            <tr>
                                <td><strong>N° de Factura</strong></td>
                                <td><strong>Fecha</strong></td>
                                <td><strong>Saldo</strong></td>
                            </tr>";
                                    foreach (var row in ctacte)
                                    {
                                        mailCuerpo += @"
                            <tr>
                                <td>" + row.CASO_NRO_COMPROBANTE + @"</td>
                                <td>" + row.FECHA_VENCIMIENTO.ToShortDateString() + @"</td>
                                <td>" + (row.CREDITO - row.DEBITO) + @"</td>
                            </tr>";
                                    }
                                    mailCuerpo += @"
                        </table>";
                                }
                                mailCuerpo += @"
                    </body>
                </html>";
                                correo.EnviarMail(persona.Email1, asunto, mailCuerpo, sesion);
                            }
                        }
                    }
                    #endregion Notificar cliente
                }
                #endregion Pendiente a Caja

                #region Caja a Anulado
                //Caja a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Caja) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                {
                    //Puede utilizarse la transición si aún no fueron realizados
                    //pagos sobre el documento. 


                    //Acciones:
                    //Se deshace la deuda de la persona
                    //Se devuelven los articulos al stock pero no se borran del detalle de la NP dejandolos a modo informativo.

                    exito = true;
                    revisarRequisitos = true;
                    decimal totalCredito, totalDebito;

                    #region Verificar Puede Avanzar Estado
                    if (exito)
                    {
                        exito = VerificarPuedeAvanzarEstado(caso_id, out mensaje, sesion);
                    }
                    #endregion Verificar Puede Avanzar Estado

                    DataTable dtCtacteExistente = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + cabeceraRow.CASO_ID, string.Empty, sesion);
                    if (afectarCtaCte)
                    {
                        if (dtCtacteExistente.Rows.Count <= 0)
                            throw new Exception("No se encontró la deuda generada por la factura.");
                    }

                    for (int i = 0; i < dtCtacteExistente.Rows.Count; i++)
                    {
                        if (CuentaCorrientePersonasService.TienePagoConfirmado((decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Id_NombreCol]))
                        {
                            throw new Exception("La factura tiene un caso de Pago confirmado.");
                        }
                    }

                    totalCredito = 0;
                    totalDebito = 0;
                    for (int i = 0; i < dtCtacteExistente.Rows.Count; i++)
                    {
                        totalCredito += (decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol];
                        totalDebito += (decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol];
                    }

                    if (exito && totalDebito > 0)
                    {
                        exito = false;
                        mensaje = "La factura que desea anular ya contiene pagos parciales o totales.";
                    }
                    if (exito && afectarStock)
                    {
                        //Se devuelven los articulos al stock pero no se borran del 
                        //detalle dejandolos a modo informativo.
                        #region Afectarstock

                        if (afectarStock)
                        {
                            foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                            {
                                if (!ArticulosService.EsServicio(detalle.ARTICULO_ID))
                                {
                                    decimal deposito = cabeceraRow.DEPOSITO_ID;
                                    if(!detalle.IsDEPOSITO_IDNull)
                                        deposito = detalle.DEPOSITO_ID;
                                    StockService.modificarStock(deposito,
                                                            detalle.ARTICULO_ID,
                                                            Interprete.Redondear(-detalle.CANTIDAD_UNITARIA_TOTAL_ORIG, 2),
                                                            Definiciones.Stock.TipoMovimiento.Venta, caso_id, detalle.LOTE_ID, estado_destino,
                                                            sesion, null, detalle.IMPUESTO_ID, detalle.ID);

                                    //Si es un Combo Representativo lo desconsolida para devolver los componentes del mismo
                                    bool esComboRepresentativo = ArticulosService.EsComboRepresentativo(detalle.ARTICULO_ID);
                                    if (esComboRepresentativo)
                                        ArticulosCombosStockService.DesconsolidarCombo(detalle.CANTIDAD_UNITARIA_TOTAL_DEST, detalle.LOTE_ID, deposito, cabeceraRow.CASO_ID, sesion, estado_destino);
                                }
                            }
                        }
                        #endregion Afectarstock
                    }

                    //Borrar el credito
                    if (exito && afectarCtaCte)
                    {
                        for (int i = 0; i < dtCtacteExistente.Rows.Count; i++)
                            CuentaCorrientePersonasService.Borrar((decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], sesion);
                    }

                    //Se modifica la cantidad de las relaciones con las notas de pedido y remisiones, si las hubiera
                    foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                    {
                        decimal auxNotaPedidoDetalle = NotasDePedidoDetalleFacturaClienteRelacionesService.GetPedidosClienteDetalleIdPorFacturaDetalleId(detalle.ID);
                        if (auxNotaPedidoDetalle != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            decimal auxNotaPedido = NotasDePedidoDetalleService.GetNotaDePedidoIdPorId(auxNotaPedidoDetalle);
                            NotasDePedidosService NotasDePedido = new NotasDePedidosService();
                            NotasDePedido.CambiarAPreparado(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido));
                            NotasDePedidoDetalleFacturaClienteRelacionesService.ModificarDetallePorIdFacturaCliente(detalle.ID, detalle.CANTIDAD_UNIDAD_DESTINO, sesion, true);
                        }
                        RemisionesDetalleFacturaClienteRelacionesService.ModificarDetallePorIdFacturaCliente(detalle.ID, detalle.CANTIDAD_UNIDAD_DESTINO, sesion, true);
                    }
                }
                #endregion Caja a Anulado

                #region Caja a Pendiente
                //Caja a Anulado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Caja) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    //Puede utilizarse la transición si aún no fueron realizados
                    //pagos sobre el documento. 

                    //Acciones:
                    //Se deshace la deuda de la persona
                    //Se devuelven los articulos al stock
                    //Se borra el asiento contable

                    exito = true;
                    revisarRequisitos = true;
                    decimal totalCredito, totalDebito;

                    DataTable dtCtacteExistente = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + cabeceraRow.CASO_ID, string.Empty);
                    if (afectarCtaCte)
                    {
                        if (dtCtacteExistente.Rows.Count <= 0)
                            throw new Exception("No se encontró la deuda generada por la factura.");
                    }

                    for (int i = 0; i < dtCtacteExistente.Rows.Count; i++)
                    {
                        if (CuentaCorrientePersonasService.TienePagoConfirmado((decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Id_NombreCol]))
                        {
                            throw new Exception("La factura tiene un caso de Pago confirmado.");
                        }
                    }

                    totalCredito = 0;
                    totalDebito = 0;
                    for (int i = 0; i < dtCtacteExistente.Rows.Count; i++)
                    {
                        totalCredito += (decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol];
                        totalDebito += (decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Debito_NombreCol];
                    }

                    if (exito && totalDebito > 0)
                    {
                        exito = false;
                        mensaje = "La factura que desea anular ya contiene pagos parciales o totales.";
                    }
                    if (exito && afectarStock)
                    {
                        //Se devuelven los articulos al stock pero no se borran del 
                        //detalle dejandolos a modo informativo.
                        #region Afectarstock

                        if (afectarStock)
                        {
                            foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                            {
                                if (!ArticulosService.EsServicio(detalle.ARTICULO_ID))
                                {
                                    decimal deposito = cabeceraRow.DEPOSITO_ID;
                                    if (!detalle.IsDEPOSITO_IDNull)
                                        deposito = detalle.DEPOSITO_ID;
                                    StockService.modificarStock(deposito,
                                                            detalle.ARTICULO_ID,
                                                            Interprete.Redondear(-detalle.CANTIDAD_UNITARIA_TOTAL_ORIG, 2),
                                                            Definiciones.Stock.TipoMovimiento.Venta, caso_id, detalle.LOTE_ID, estado_destino,
                                                            sesion, null, detalle.IMPUESTO_ID, detalle.ID);
                                }
                            }
                        }
                        #endregion Afectarstock
                    }

                    //Borrar el credito
                    if (exito && afectarCtaCte)
                    {
                        for (int i = 0; i < dtCtacteExistente.Rows.Count; i++)
                        {
                            decimal ctaCteId = (decimal)dtCtacteExistente.Rows[i][CuentaCorrientePersonasService.Id_NombreCol];
                            CuentaCorrientePagosPersonaDocumentoService.BorrarByCtaCtePersonaId(ctaCteId, caso_id, sesion);
                            CuentaCorrientePersonasService.Borrar(ctaCteId, sesion);
                        }
                    }

                    //Borrar asiento contable
                    if (exito)
                    {
                        decimal transicionId;
                        transicionId = TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.FACTURACION_CLIENTE, Definiciones.EstadosFlujos.Pendiente, Definiciones.EstadosFlujos.Caja, sesion);
                        Contabilidad.AsientosService.BorrarPorCasoYTransicion(caso_id, transicionId, sesion);

                        transicionId = TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.FACTURACION_CLIENTE, Definiciones.EstadosFlujos.EnReparto, Definiciones.EstadosFlujos.Caja, sesion);
                        Contabilidad.AsientosService.BorrarPorCasoYTransicion(caso_id, transicionId, sesion);
                    }

                    //Se modifica la cantidad de las relaciones con las notas de pedido y remisiones, si las hubiera
                    foreach (FACTURAS_CLIENTE_DETALLERow detalle in detalleRows)
                    {
                        decimal auxNotaPedidoDetalle = NotasDePedidoDetalleFacturaClienteRelacionesService.GetPedidosClienteDetalleIdPorFacturaDetalleId(detalle.ID);
                        if (auxNotaPedidoDetalle != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            decimal auxNotaPedido = NotasDePedidoDetalleService.GetNotaDePedidoIdPorId(auxNotaPedidoDetalle);
                            NotasDePedidosService NotasDePedido = new NotasDePedidosService();
                            NotasDePedido.CambiarAPreparado(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido));
                            NotasDePedidoDetalleFacturaClienteRelacionesService.ModificarDetallePorIdFacturaCliente(detalle.ID, detalle.CANTIDAD_UNIDAD_DESTINO, sesion, false);
                        }
                        RemisionesDetalleFacturaClienteRelacionesService.ModificarDetallePorIdFacturaCliente(detalle.ID, detalle.CANTIDAD_UNIDAD_DESTINO, sesion, false);
                    }
                }
                #endregion Caja a Pendiente

                #region Caja a Cerrado
                //Caja a Cerrado
                else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Caja) &&
                        estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                {
                    //Acciones
                    //Una vez que el documento fue pagado el caso es pasado en forma automatica a cerrado.

                    exito = true;
                    revisarRequisitos = true;

                    /* TODO: 
                     * considerar acciones a realizarse si la estrategia de comision del 
                     * vendedor es por venta.
                     * 
                     * actualizar la ctacte de la persona
                    */
                }
                #endregion Caja a Cerrado

                //Verificar si se cumplen los requisitos
                if (exito && revisarRequisitos)
                {
                    exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                }

                if (exito)
                {

                    sesion.Db.CASOSCollection.Update(casoRow);
                    sesion.db.FACTURAS_CLIENTECollection.Update(cabeceraRow);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, cabeceraRow.ID, valorAnteriorFactura, cabeceraRow.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, cabeceraRow.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, cabeceraRow.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, cabeceraRow.SUCURSAL_ID);
                    if (!Interprete.EsNullODBNull(cabeceraRow.NRO_DOCUMENTO_EXTERNO))
                        camposCaso.Add(CasosService.NroComprobante2_NombreCol, cabeceraRow.NRO_DOCUMENTO_EXTERNO);
                    if (!cabeceraRow.IsPERSONA_IDNull)
                        camposCaso.Add(CasosService.PersonaId_NombreCol, cabeceraRow.PERSONA_ID);
                    if (!cabeceraRow.IsVENDEDOR_IDNull)
                        camposCaso.Add(CasosService.FuncionarioId_NombreCol, cabeceraRow.VENDEDOR_ID);
                    CasosService.ActualizarCampos(cabeceraRow.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                exito = false;

                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.STOCK_INCONSISTENCIA:
                        throw new System.ArgumentException("Inconsistencia de stock. Favor comuníquese con el soporte técnico.");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar.");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar.");
                    default: throw exp;
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
        public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion)
        {
            try
            {
                CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                FACTURAS_CLIENTERow cabeceraRow = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
                string mensaje;
                bool exito = true;

                if (casoRow.ESTADO_ANTERIOR_ID == Definiciones.EstadosFlujos.Pendiente && casoRow.ESTADO_ID == Definiciones.EstadosFlujos.Caja)
                {
                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                        ActualizarNumeroDocumentoExterno(cabeceraRow, out mensaje, sesion);

                    //Se controla el nro comprobante pra evitar duplicaciones por concurrencia, 
                    //se usa el metodo sin paso de sesion para poder leer lo que otros usuarios pudieran haber escritos 
                    //en sus propias sesiones
                    if (FacturasClienteService.GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, cabeceraRow.NRO_COMPROBANTE))
                        throw new Exception("Ya existe una factura con el mismo número de comprobante.");


                    //Si la factura es por monot 0 debe pasarse a cerrado
                    if (cabeceraRow.TOTAL_NETO == 0)
                    {
                        FacturasClienteService facturaCliente = new FacturasClienteService();
                        if (exito)
                            exito = facturaCliente.ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                        if (exito)
                            exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                        if (exito)
                            facturaCliente.EjecutarAccionesLuegoDeCambioEstado(caso_id, Definiciones.EstadosFlujos.Cerrado, sesion);
                    }

                    var cobranzaContado = this.GetPasarelaCambioEstadoCampo("FacturaClienteCobranzaContado");
                    if (cobranzaContado != null)
                    {
                        if (cobranzaContado.valor == Definiciones.SiNo.Si)
                        {
                            DataTable cobranza = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.CasoAsociadoId_NombreCol + " = " + caso_id, string.Empty, sesion);
                            decimal caso_cobranza_id = decimal.Parse(cobranza.Rows[0][PagosDePersonaService.CasoId_NombreCol].ToString());
                            PagosDePersonaService pago = new PagosDePersonaService();
                            if (exito)
                                exito = pago.ProcesarCambioEstado(caso_cobranza_id, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                            if (exito)
                                exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_cobranza_id, Definiciones.EstadosFlujos.Aprobado, string.Empty, sesion);
                            if (exito)
                                pago.EjecutarAccionesLuegoDeCambioEstado(caso_cobranza_id, Definiciones.EstadosFlujos.Aprobado, sesion);
                        }
                    }
                }
                else if (casoRow.ESTADO_ANTERIOR_ID == Definiciones.EstadosFlujos.EnReparto && casoRow.ESTADO_ID == Definiciones.EstadosFlujos.Caja)
                {
                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteValidarNroDocumentoExterno) == Definiciones.SiNo.Si)
                        ActualizarNumeroDocumentoExterno(cabeceraRow, out mensaje, sesion);
                    
                    //Se controla el nro comprobante pra evitar duplicacicones por concurrencia, 
                    //se usa el metodo sin paso de sesion para poder leer lo que otros usuarios pudieran haber escritos 
                    //en sus propias sesiones
                    if (FacturasClienteService.GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, cabeceraRow.NRO_COMPROBANTE))
                        throw new Exception("Ya existe una factura con el mismo número de comprobante.");

                    //Si la factura es por monot 0 debe pasarse a cerrado
                    if (cabeceraRow.TOTAL_NETO == 0)
                    {
                        FacturasClienteService facturaCliente = new FacturasClienteService();
                        if (exito)
                            exito = facturaCliente.ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                        if (exito)
                            exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso_id, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                        if (exito)
                            facturaCliente.EjecutarAccionesLuegoDeCambioEstado(caso_id, Definiciones.EstadosFlujos.Cerrado, sesion);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            FACTURAS_CLIENTERow row = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
            return row.NRO_COMPROBANTE == null ? "" : row.NRO_COMPROBANTE;
        }

        #endregion Implementacion de metodos abstract       

        #region Getters
        #region GetPorcentajeMora
        /// <summary>
        /// Gets the porcentaje mora.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static decimal GetPorcentajeMora(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0].MORA_PORCENTAJE;
            }
        }
        #endregion GetPorcentajeMora

        #region GetDiasGracia
        /// <summary>
        /// Gets the dias gracia.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static decimal GetDiasGracia(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0].MORA_DIAS_GRACIA;
            }
        }
        #endregion GetDiasGracia

        #region GetTotalNetoLuegoNC
        public static decimal GetTotalNetoLuegoNC(decimal factura_cliente_id, SessionService sesion)
        {
            DataTable dt = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + factura_cliente_id, string.Empty, sesion);
            decimal total = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
                total += (decimal)dt.Rows[i][FacturasClienteDetalleService.TotalNetoLuegoDeNC_NombreCol];
            return total;
        }
        #endregion GetDiasGracia

        #region GetCantidadDetalles
        /// <summary>
        /// Gets the cantidad detalles.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static decimal GetCantidadDetalles(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FACTURAS_CLIENTERow[] row = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id);
                DataTable dt = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + row[0].ID, string.Empty);

                return dt.Rows.Count;
            }
        }
        #endregion GetCantidadDetalles

        #region GetTipoFactura
        public static string GetTipoFactura(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTipoFactura(caso_id, sesion);
            }
        }

        public static string GetTipoFactura(decimal caso_id, SessionService sesion)
        {
            return sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0].TIPO_FACTURA_ID;
        }
        #endregion GetTipoFactura

        #region GetNroComprobantePorCaso
        public static string GetFacturaNroComprobantePorCaso(decimal Caso_Nro)
        {
            string clausula = FacturasClienteService.CasoId_NombreCol + "=" + Caso_Nro;
            DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(clausula, FacturasClienteService.Id_NombreCol);
            if (dtFactura.Rows.Count > 0)
                return dtFactura.Rows[0][FacturasClienteService.NroComprobante_NombreCol].ToString();
            else
                return string.Empty;
        }
        #endregion

        #region GetMonedaId
        public static decimal GetMonedaId(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMonedaId(clausula, sesion);
            }
        }
        public static decimal GetMonedaId(string clausula, SessionService sesion)
        {
            FACTURAS_CLIENTERow row = sesion.Db.FACTURAS_CLIENTECollection.GetRow(clausula);
            return row.MONEDA_DESTINO_ID;
        }

        #endregion GetMonedaId

        #region GetFacturaCliente
        /// <summary>
        /// Gets the facturacion cliente.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <returns></returns>
        public static FACTURAS_CLIENTERow GetFacturaCliente(decimal facturacion_cliente_id, SessionService sesion)
        {
            string clausulas = FacturasClienteService.Id_NombreCol + " = " + facturacion_cliente_id + " and " +
                               FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            FACTURAS_CLIENTERow[] rows = sesion.Db.FACTURAS_CLIENTECollection.GetAsArray(clausulas, FacturasClienteService.Id_NombreCol);
            if (rows.Length > 0)
                return rows[0];
            else
                throw new Exception("Factura no encontrada.");
        }

        public static DataTable GetFacturaClienteDataTable(decimal facturacion_cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturaClienteDataTable(facturacion_cliente_id, sesion);
            }
        }

        public static DataTable GetFacturaClienteDataTable(decimal facturacion_cliente_id, SessionService sesion)
        {

            return GetFacturaClienteDataTable(FacturasClienteService.Id_NombreCol + " = " + facturacion_cliente_id, FacturasClienteService.Id_NombreCol, sesion);

        }

        public static DataTable GetFacturaClienteDataTable(string clausulas, string order_by)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturaClienteDataTable(clausulas, order_by, sesion);
            }
        }

        public static DataTable GetFacturaClienteDataTable(string clausulas, string order_by, SessionService sesion)
        {
            string where = FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.FACTURAS_CLIENTECollection.GetAsDataTable(where, order_by);
        }
        #endregion GetFacturaCliente

        #region GetFacturaClienteInfoCompleta
        /// <summary>
        /// Gets the factura cliente info completa.
        /// </summary>
        /// <returns></returns>
        public DataTable GetFacturaClienteInfoCompleta(string whereSql)
        {
            using (SessionService sesion = new SessionService())
            {
                return FacturasClienteService.GetFacturaClienteInfoCompleta(whereSql, string.Empty);
            }
        }

        /// <summary>
        /// Gets the factura cliente info completa.
        /// </summary>
        /// <returns></returns>
        public DataTable GetFacturaClienteInfoCompleta()
        {
            using (SessionService sesion = new SessionService())
            {
                return FacturasClienteService.GetFacturaClienteInfoCompleta(string.Empty, string.Empty);
            }
        }

        public static DataTable GetFacturaClienteInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturaClienteInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetFacturaClienteInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;
            return sesion.Db.FACTURAS_CLIENTE_INFO_COMPLETACollection.GetAsDataTable(where, orden);
        }
        #endregion GetFacturaClienteInfoCompleta

        #region GetFacturaClientePorPersonaMonedaEstado

        /// <summary>
        /// Gets the factura cliente por persona info completa.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public DataTable GetFacturaClientePorPersonaInfoCompleta(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                   FacturasClienteService.PersonaId_NombreCol + " = " + persona_id;

                return sesion.Db.FACTURAS_CLIENTE_INFO_COMPLETACollection.GetAsDataTable(clausulas, FacturasClienteService.Id_NombreCol);
            }
        }

        /// <summary>
        /// Gets the factura cliente por persona estado info completa.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="estados">The estados.</param>
        /// <returns></returns>
        public DataTable GetFacturaClientePorPersonaEstadoInfoCompleta(decimal persona_id, string estados)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                   FacturasClienteService.PersonaId_NombreCol + " = " + persona_id + " and " +
                                   FacturasClienteService.VistaCasoEstadoId_NombreCol + " in ('" + estados + "') ";

                return sesion.Db.FACTURAS_CLIENTE_INFO_COMPLETACollection.GetAsDataTable(clausulas, FacturasClienteService.Id_NombreCol);
            }
        }
        #endregion GetFacturaClientePorPersonaMonedaEstado

        #region GetFacturaClientePorCasos
        /// <summary>
        /// Gets the factura cliente por casos.
        /// </summary>
        /// <param name="lista_de_casos_id">The lista_de_casos_id.</param>
        /// <returns></returns>
        public DataTable GetFacturaClientePorCasos(int[] lista_de_casos_id)
        {
            using (SessionService sesion = new SessionService())
            {
                //Si el array esta vacio devuelve un DataTable vacio
                if (!(lista_de_casos_id.Length > 0)) return new DataTable();

                //Convertir el array de int a una cadena separada por comas
                string casos = String.Join(",", Array.ConvertAll<int, string>(lista_de_casos_id, delegate(int i) { return i.ToString(); }));

                //Realizar la consulta y devolver los datos
                string clausulas = FacturasClienteService.CasoId_NombreCol + " in (" + casos + ") and " +
                                   FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                return sesion.Db.FACTURAS_CLIENTE_INFO_COMPLETACollection.GetAsDataTable(clausulas, FacturasClienteService.Id_NombreCol);
            }
        }
        #endregion GetFacturaClientePorCasos

        #region GetExisteNroComprobante

        private static bool GetExisteNroComprobante(decimal factura_id, decimal autonumeracion_id, string nro_comprobante)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetExisteNroComprobante(factura_id, autonumeracion_id, nro_comprobante, sesion);

            }
        }
        /// <summary>
        /// Gets the existe nro comprobante.
        /// </summary>
        /// <param name="factura_id">The factura_id.</param>
        /// <param name="autonumeracion_id">The autonumeracion_id.</param>
        /// <param name="nro_comprobante">The nro_comprobante.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        private static bool GetExisteNroComprobante(decimal factura_id, decimal autonumeracion_id, string nro_comprobante, SessionService sesion)
        {
            bool existe = false;
            string clausulas = FacturasClienteService.VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID;

            if (!autonumeracion_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                clausulas += " and " + FacturasClienteService.AutonumeracionId_NombreCol + " = " + autonumeracion_id;

            clausulas += " and " + FacturasClienteService.NroComprobante_NombreCol + " = '" + nro_comprobante + "' " +
                         " and " + FacturasClienteService.Id_NombreCol + " <> " + factura_id +
                         " and " + FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

            FACTURAS_CLIENTE_INFO_COMPLETARow[] rows = sesion.Db.FACTURAS_CLIENTE_INFO_COMPLETACollection.GetAsArray(clausulas, string.Empty);

            existe = rows.Length > 0;

            return existe;
        }
        #endregion GetExisteNroComprobante

        #region GetSumaImpuestos
        [Obsolete("utilizar metodos estaticos")]
        /// <summary>
        /// Gets the suma impuestos.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="impuesto_id">The impuesto_id.</param>
        /// <returns></returns>
        public decimal GetSumaImpuestos(decimal factura_cliente_id, decimal impuesto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FACTURAS_CLIENTERow factura = sesion.Db.FACTURAS_CLIENTECollection.GetByPrimaryKey(factura_cliente_id);
                decimal impuestos = 0;
                DataTable dt = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + factura_cliente_id, string.Empty, sesion);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((decimal)dt.Rows[i][FacturasClienteDetalleService.ImpuestoId_NombreCol] == impuesto_id)
                    {
                        impuestos += (decimal)dt.Rows[i][FacturasClienteDetalleService.TotalMontoImpuesto_NombreCol];
                    }
                }
                if (!factura.IsPORCENTAJE_DESC_SOBRE_TOTALNull)
                    return impuestos * (100 - factura.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;
                else
                    return impuestos;
            }
        }

        /// <summary>
        /// Gets the suma impuestos.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="impuesto_id">The impuesto_id.</param>
        /// <returns></returns>
        public static decimal GetSumaImpuestos2(decimal factura_cliente_id, decimal impuesto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FACTURAS_CLIENTERow factura = sesion.Db.FACTURAS_CLIENTECollection.GetByPrimaryKey(factura_cliente_id);
                decimal impuestos = 0;
                DataTable dt = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + factura_cliente_id, string.Empty, sesion);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((decimal)dt.Rows[i][FacturasClienteDetalleService.ImpuestoId_NombreCol] == impuesto_id)
                        impuestos += (decimal)dt.Rows[i][FacturasClienteDetalleService.TotalMontoImpuesto_NombreCol];
                }

                if (!factura.IsPORCENTAJE_DESC_SOBRE_TOTALNull)
                    return impuestos * (100 - factura.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;
                else
                    return impuestos;
            }
        }

        #endregion GetSumaImpuestos

        #region GetConsultarNumeroDocumentoExterno
        /// <summary>
        /// Gets the consultar numero documento externo.
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="mensaje">The mensaje.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool GetConsultarNumeroDocumentoExterno(FACTURAS_CLIENTERow factura_cliente, out string mensaje, SessionService sesion)
        {
            try
            {
                bool exito = true;
                mensaje = string.Empty;

                switch (Convert.ToInt32(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.Cliente)))
                {
                    case Definiciones.Clientes.Electroban:
                       
                        break;
                    case Definiciones.Clientes.Documenta:
                        exito = Webmethods.ConsultarNumeroDocumentoExterno.Cliente_13(factura_cliente, out mensaje, sesion);
                        break;
                }

                return exito;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion GetConsultarNumeroDocumentoExterno
        
        #endregion Getters

        #region DesmarcarImpreso
        public static void DesmarcarImpreso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FACTURAS_CLIENTERow row = new FACTURAS_CLIENTERow();
                string valorAnterior = String.Empty;
                try
                {
                    row = sesion.Db.FACTURAS_CLIENTECollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                    valorAnterior = row.ToString();

                    row.IMPRESO = Definiciones.SiNo.No;
                    sesion.db.FACTURAS_CLIENTECollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exp)
                {
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                            throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                        case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                            throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                        default: throw exp;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion DesmarcarImpreso

        #region ActualizarImpreso
        public static void ActualizarFecha(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarFecha(caso_id, sesion);
            }
        }

        public static void ActualizarFecha(decimal caso_id, SessionService sesion)
        {
            FACTURAS_CLIENTERow row = new FACTURAS_CLIENTERow();
            string valorAnterior = String.Empty;
            try
            {
                row = sesion.Db.FACTURAS_CLIENTECollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                valorAnterior = row.ToString();

                if (row.IMPRESO == Definiciones.SiNo.No && EsActualizable && !AutonumeracionesService.EsGeneracionManual(row.AUTONUMERACION_ID, sesion))
                    row.FECHA = DateTime.Today.Date;

                sesion.db.FACTURAS_CLIENTECollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                Hashtable campos = new Hashtable();
                campos.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                campos.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                campos.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                if (!Interprete.EsNullODBNull(row.NRO_DOCUMENTO_EXTERNO))
                    campos.Add(CasosService.NroComprobante2_NombreCol, row.NRO_DOCUMENTO_EXTERNO);
                if (!row.IsPERSONA_IDNull)
                    campos.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                if (!row.IsVENDEDOR_IDNull)
                    campos.Add(CasosService.FuncionarioId_NombreCol, row.VENDEDOR_ID);
                CasosService.ActualizarCampos(row.CASO_ID, campos, sesion);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ActualizarImpreso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarImpreso(caso_id, sesion);
            }
        }

        public static void ActualizarImpreso(decimal caso_id, SessionService sesion)
        {
            ActualizarFecha(caso_id, sesion);

            FACTURAS_CLIENTERow row = sesion.Db.FACTURAS_CLIENTECollection.GetRow(CasoId_NombreCol + " = " + caso_id);
            string valorAnterior = row.ToString();
            
            row.IMPRESO = Definiciones.SiNo.Si;
            sesion.db.FACTURAS_CLIENTECollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        /// <summary>
        /// Auxiliar que nos indica si la entidad debe actualizar la fecha al imprimir el reporte por primera vez
        /// </summary>
        public static bool EsActualizable
        {
            get { return VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ReportesActualizarImpreso).Equals(Definiciones.SiNo.Si); }

        }
        /// <summary>
        /// Metodo auxiliar para saber si un caso ya fue impreso
        /// </summary>
        /// <param name="casoId">El Id del Caso.</param>
        /// <returns>True si fue impreso, False en caso contrario.</returns>

        public static bool FueImpreso(decimal casoId)
        {
            if (casoId == Definiciones.Error.Valor.EnteroPositivo) return false;
            using (SessionService sesion = new SessionService())
            {
                FACTURAS_CLIENTERow row = sesion.Db.FACTURAS_CLIENTECollection.GetRow(CasoId_NombreCol + " = " + casoId);
                return row.IMPRESO.Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion ActualizarImpreso
       
        #region FacturaTieneNCAsociada
        public static bool FacturaTieneNCAsociada(decimal fc_cliente_id, decimal nc_excluir_id)
        {
            string[] estados = {
                Definiciones.EstadosFlujos.Borrador,
                Definiciones.EstadosFlujos.Pendiente,
                Definiciones.EstadosFlujos.PreAprobado,
            };
            string clausula = NotasCreditoPersonaDetalleService.FacturaClienteId_NombreCol + " = " + fc_cliente_id +
                " and " + NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol + " != " + nc_excluir_id;
            DataTable notas_credito_detalle = NotasCreditoPersonaDetalleService.GetNotaCreditoPersonaDetalleInfoCompleta(clausula, string.Empty);
            foreach (DataRow detalle in notas_credito_detalle.Rows)
            {
                //si la nota de credito de este detalle esta en un estado que peude ir a ANULADO, consideramos que la factura esta asociada a una NC
                decimal nc_cliente_id = (decimal)detalle[NotasCreditoPersonaDetalleService.NotaCreditoPersonaId_NombreCol];
                DataTable nc_cliente = NotasCreditoPersonaService.GetNotaCreditoPersonaInfoCompleta2(nc_cliente_id);
                foreach (DataRow nc in nc_cliente.Rows)
                {
                    if (estados.Contains((string)nc[NotasCreditoPersonaService.VistaCasoEstadoId_NombreCol]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion FacturaTieneNCAsociada

        #region VerificarFacturasPendientes
        public static bool VerificarFacturasPendientes(DateTime fecha, decimal personaId)
        {
            string clausula = FacturasClienteService.VistaCasoEstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.Borrador + "', '" + Definiciones.EstadosFlujos.Pendiente + "')" + " and " + FacturasClienteService.VistaFecha_NombreCol + " < " + "to_date('" + fecha.ToShortDateString() + "', 'dd/mm/yyyy')" + " and " + FacturasClienteService.PersonaId_NombreCol + " = " + personaId;
            DataTable dt = GetFacturaClienteInfoCompleta(clausula, string.Empty);

            if (dt.Rows.Count > 0) return true;
            else return false;
        }
        #endregion VerificarFacturasPendientes

        #region VerificarPuedeAvanzarEstado
        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, "FC CLIENTE NO CONTROLAR MARGEN DIAS PUEDE AVANZAR", Definiciones.VariablesDeSistema.FCClienteMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado
        
        #region ActualizarNumeroDocumentoExterno
        public static void ActualizarNumeroDocumentoExterno(FACTURAS_CLIENTERow factura_cliente, out string mensaje, SessionService sesion)
        {
            try
            {
                mensaje = string.Empty;

                switch (Convert.ToInt32(VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.Cliente)))
                {
                    case Definiciones.Clientes.Electroban:
                        
                        break;
                    case Definiciones.Clientes.Documenta:
                        Webmethods.ActualizarNumeroDocumentoExterno.Cliente_13(factura_cliente, out mensaje, sesion);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion ActualizarNumeroDocumentoExterno

        #region PuedeModificarComprobante
        /// <summary>
        /// Devuelve true o false si es que se puede modificar el comprobante de la  factura.
        /// </summary>
        /// <param name="factura_cliente_id">The factura caso_id.</param>
        public static bool PuedeModificarComprobante(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                if(caso_id == Definiciones.Error.Valor.EnteroPositivo)
                    return true;

                FACTURAS_CLIENTE_INFO_COMPLETARow factura = sesion.Db.FACTURAS_CLIENTE_INFO_COMPLETACollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                if (factura.IsAUTONUMERACION_IDNull)
                    return true;

                if (AutonumeracionesService.GetTipoGeneracion(factura.AUTONUMERACION_ID) == Definiciones.TiposGeneracionAutonumeraciones.Automatico_Nombre)
                    return false;

                if (factura.CASO_ESTADO_ID == Definiciones.EstadosFlujos.Borrador)
                    return true;
                else if (factura.CASO_ESTADO_ID == Definiciones.EstadosFlujos.Pendiente)
                    return RolesService.Tiene("fc cliente asignar numero en pendiente");
                else if (factura.CASO_ESTADO_ID == Definiciones.EstadosFlujos.Caja)
                    return RolesService.Tiene("fc cliente asignar numero en caja");
                else if (factura.CASO_ESTADO_ID == Definiciones.EstadosFlujos.Cerrado)
                    return RolesService.Tiene("fc cliente asignar numero en cerrado");
                else
                    return false;
            }
        }

        #endregion PuedeModificarComprobante

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    bool exito = FacturasClienteService.Guardar(campos, insertarNuevo, ref caso_id, ref estado_id, sesion);
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

        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref String estado_id, SessionService sesion)
        {
            bool exito = false;
            bool actualizarCuotas = false;
            bool actualizarCotizacion = false;
            bool regenerarAsiento = false;
            FACTURAS_CLIENTERow row = new FACTURAS_CLIENTERow();
            DateTime fechaPrimerVencimiento = DateTime.Now;
            DateTime fechaSegundoVencimiento = DateTime.MinValue;
            bool usarFechaPrimerVencimiento = false;
            bool usarFechaSegundoVencimiento = false;
            string estadoId;

            try
            {
                string valorAnterior = "";
                UsuariosService usuario = new UsuariosService();
                if (usuario.GetPersonaId(sesion.Usuario_Id) == decimal.Parse(campos[FacturasClienteService.PersonaId_NombreCol].ToString()))
                    throw new Exception("El usuario no puede crear un caso de si mismo.");

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;                   
                    CrearCasos CrearCaso = new CrearCasos(int.Parse(campos[FacturasClienteService.SucursalId_NombreCol].ToString()),
                                                                                  int.Parse(Definiciones.FlujosIDs.FACTURACION_CLIENTE.ToString()),
                                                                                  int.Parse(sesion.Usuario_Id.ToString()),
                                                                                  SessionService.GetClienteIP());
                    row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion));
                    if (campos.Contains(Definiciones.Flujo.CajaRapida.nombre))
                        row.ES_RAPIDA = Definiciones.SiNo.Si;
                    
                    row.ID = sesion.Db.GetSiguienteSecuencia("facturas_cliente_sqc");
                    caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                    estado_id = Definiciones.EstadosFlujos.Borrador;
                    row.AFECTA_CTACTE = Definiciones.SiNo.Si;
                    row.ESTADO = Definiciones.Estado.Activo;
                    row.IMPRESO = Definiciones.SiNo.No;
                    row.TOTAL_COMISION_VENDEDOR = 0;
                    row.TOTAL_COSTO_BRUTO = 0;
                    row.TOTAL_COSTO_NETO = 0;
                    row.TOTAL_MONTO_BRUTO = 0;
                    row.TOTAL_MONTO_DTO = 0;
                    row.TOTAL_MONTO_IMPUESTO = 0;
                    row.TOTAL_NETO = 0;
                    row.TOTAL_ENTREGA_INICIAL = 0;
                    row.MONTO_AFECTA_LINEA_CREDITO = 0;
                    row.CONTROLAR_CANT_MIN_DESC_MAX = Definiciones.SiNo.No;
                }
                else
                {
                    row = sesion.Db.FACTURAS_CLIENTECollection.GetRow(FacturasClienteService.Id_NombreCol + " = " + campos[FacturasClienteService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                //Panel Factura
                if (campos.Contains(FacturasClienteService.SucursalId_NombreCol))
                {
                    row.SUCURSAL_ID = (decimal)campos[FacturasClienteService.SucursalId_NombreCol];
                    CasosService.ActualizarSucursal(row.CASO_ID, row.SUCURSAL_ID, sesion);
                }
                else
                    row.IsSUCURSAL_IDNull = true;

                if (campos.Contains(FacturasClienteService.SucursalVentaId_NombreCol))
                    row.SUCURSAL_VENTA_ID = (decimal)campos[FacturasClienteService.SucursalVentaId_NombreCol];
                else
                    row.IsSUCURSAL_VENTA_IDNull = true;

                if (campos.Contains(FacturasClienteService.DepositoId_NombreCol))
                {
                    row.DEPOSITO_ID = decimal.Parse(campos[FacturasClienteService.DepositoId_NombreCol].ToString());
                    if (StockDepositosService.GetStockDeposito(row.DEPOSITO_ID).PARA_FACTURAR == Definiciones.SiNo.No)
                    {
                        throw new Exception("No se puede facturar del deposito seleccionado.");
                    }
                }

                if (campos.Contains(FacturasClienteService.DepositoDestinoId_NombreCol))
                {
                    row.DEPOSITO_DESTINO_ID = (decimal)campos[FacturasClienteService.DepositoDestinoId_NombreCol];
                }
                else
                {
                    row.IsDEPOSITO_DESTINO_IDNull = true;
                }

                if (campos.Contains(FacturasClienteService.Fecha_NombreCol))
                {
                    if (row.IsFECHANull || row.FECHA.Date != ((DateTime)campos[FacturasClienteService.Fecha_NombreCol]).Date)
                    {
                        actualizarCuotas = true;
                        actualizarCotizacion = true;
                        regenerarAsiento = true;
                    }

                    row.FECHA = (DateTime)campos[FacturasClienteService.Fecha_NombreCol];
                }
                else
                {
                    row.IsFECHANull = true;
                }

                if (campos.Contains(FacturasClienteService.PersonaId_NombreCol))
                {
                    row.PERSONA_ID = decimal.Parse(campos[FacturasClienteService.PersonaId_NombreCol].ToString());
                    if (!PersonasService.EstaActivo(row.PERSONA_ID))
                        throw new Exception(Traducciones.La_persona_esta_inactiva);
                }
                else
                {
                    row.IsPERSONA_IDNull = true;
                }

                if (campos.Contains(FacturasClienteService.ControlarCantidadMinimaDescuentoMaximo_NombreCol))
                {
                    row.CONTROLAR_CANT_MIN_DESC_MAX = campos[FacturasClienteService.ControlarCantidadMinimaDescuentoMaximo_NombreCol].ToString();
                }

                if (campos.Contains(FacturasClienteService.PersonaGarante1Id_NombreCol))
                    row.PERSONA_GARANTE_1_ID = (decimal)campos[FacturasClienteService.PersonaGarante1Id_NombreCol];
                else
                    row.IsPERSONA_GARANTE_1_IDNull = true;

                if (campos.Contains(FacturasClienteService.PersonaGarante2Id_NombreCol))
                    row.PERSONA_GARANTE_2_ID = (decimal)campos[FacturasClienteService.PersonaGarante2Id_NombreCol];
                else
                    row.IsPERSONA_GARANTE_2_IDNull = true;

                if (campos.Contains(FacturasClienteService.PersonaGarante3Id_NombreCol))
                    row.PERSONA_GARANTE_3_ID = (decimal)campos[FacturasClienteService.PersonaGarante3Id_NombreCol];
                else
                    row.IsPERSONA_GARANTE_3_IDNull = true;

                row.FECHA_VENCIMIENTO = (DateTime)campos[FacturasClienteService.FechaVencimiento_NombreCol];

                if (campos.Contains(FacturasClienteService.AutonumeracionId_NombreCol))
                    row.AUTONUMERACION_ID = decimal.Parse(campos[FacturasClienteService.AutonumeracionId_NombreCol].ToString());
                else
                    row.IsAUTONUMERACION_IDNull = true;

                if (campos.Contains(FacturasClienteService.CtaCteCajaSucursalId_NombreCol))
                {
                    row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[FacturasClienteService.CtaCteCajaSucursalId_NombreCol];
                }
                else
                {
                    estadoId = CasosService.GetEstadoCaso(row.CASO_ID, sesion);
                    if (estadoId.Equals(Definiciones.EstadosFlujos.Borrador) || estadoId.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        row.IsCTACTE_CAJA_SUCURSAL_IDNull = true;
                    }
                }

                if (campos.Contains(FacturasClienteService.NroComprobante_NombreCol))
                {
                    if (row.IsAUTONUMERACION_IDNull)
                    {
                        if (row.NRO_COMPROBANTE != null)
                        {
                            if (row.NRO_COMPROBANTE != (string)campos[FacturasClienteService.NroComprobante_NombreCol])
                            {
                                if (FacturasClienteService.GetExisteNroComprobante(row.ID, Definiciones.Error.Valor.EnteroPositivo, (string)campos[FacturasClienteService.NroComprobante_NombreCol], sesion))
                                    throw new Exception("Ya existe una factura con el mismo número de comprobante.");
                            }
                        }
                    }
                    else
                    {
                        if (FacturasClienteService.GetExisteNroComprobante(row.ID, row.AUTONUMERACION_ID, (string)campos[FacturasClienteService.NroComprobante_NombreCol], sesion))
                            throw new Exception("Ya existe una factura con el mismo número de comprobante.");

                        if (row.NRO_COMPROBANTE != (string)campos[FacturasClienteService.NroComprobante_NombreCol])
                        {
                            string estadoActual = CasosService.GetEstadoCaso(row.CASO_ID,sesion);
                            switch (estadoActual)
                            {
                                case Definiciones.EstadosFlujos.Caja:
                                    if (!RolesService.Tiene("fc cliente asignar numero en caja"))
                                        throw new Exception("El caso está en " + estadoActual + ", no puede cambiar el número de comprobante.");
                                    break;
                                case Definiciones.EstadosFlujos.Cerrado:
                                    if (!RolesService.Tiene("fc cliente asignar numero en cerrado"))
                                        throw new Exception("El caso está en " + estadoActual + ", no puede cambiar el número de comprobante.");
                                    break;
                                case Definiciones.EstadosFlujos.Anulado:
                                    throw new Exception("El caso está en " + estadoActual + ", no puede cambiar el número de comprobante.");
                                    break;
                            }
                        }
                    }

                    row.NRO_COMPROBANTE = campos[FacturasClienteService.NroComprobante_NombreCol].ToString();
                    if(campos.Contains(FacturasClienteService.NroComprobanteSecuencia_NombreCol))
                        row.NRO_COMPROBANTE_SECUENCIA = decimal.Parse(campos[FacturasClienteService.NroComprobanteSecuencia_NombreCol].ToString());
                }
                else
                {
                    //string estadoActual = CasosService.GetEstadoCaso(row.CASO_ID);
                    if (!insertarNuevo)
                    {
                        if (row.NRO_COMPROBANTE == string.Empty )
                        {
                            row.NRO_COMPROBANTE = string.Empty;
                            row.IsNRO_COMPROBANTE_SECUENCIANull = true; 
                        }
                     }
                }

                if (row.TOTAL_ENTREGA_INICIAL != decimal.Parse(campos[FacturasClienteService.TotalEntregaInicial_NombreCol].ToString()))
                {
                    row.TOTAL_ENTREGA_INICIAL = decimal.Parse(campos[FacturasClienteService.TotalEntregaInicial_NombreCol].ToString());
                    actualizarCuotas = true;
                }

                if (row.IsCONDICION_PAGO_IDNull || row.CONDICION_PAGO_ID != decimal.Parse(campos[FacturasClienteService.CondicionPagoId_NombreCol].ToString()))
                {
                    row.CONDICION_PAGO_ID = decimal.Parse(campos[FacturasClienteService.CondicionPagoId_NombreCol].ToString());
                    actualizarCuotas = true;
                }

                if (CondicionesPagoService.EsContado(row.CONDICION_PAGO_ID))
                    row.TIPO_FACTURA_ID = Definiciones.TipoFactura.Contado;
                else
                    row.TIPO_FACTURA_ID = Definiciones.TipoFactura.Credito;

                //Se actualiza si la FC afecta o no la cuenta corriente
                if (campos.Contains(FacturasClienteService.AfectaCtacte_NombreCol))
                    row.AFECTA_CTACTE = (string)campos[FacturasClienteService.AfectaCtacte_NombreCol];
                if (row.AFECTA_CTACTE == Definiciones.SiNo.No)
                    row.AFECTA_LINEA_CREDITO = Definiciones.SiNo.No;

                if (campos.Contains(FacturasClienteService.MontoAfectaLineaCredito_NombreCol))
                    row.MONTO_AFECTA_LINEA_CREDITO = (decimal)campos[FacturasClienteService.MontoAfectaLineaCredito_NombreCol];

                if (campos.Contains(FacturasClienteService.AfectaStock_NombreCol))
                    row.AFECTA_STOCK = (string)campos[FacturasClienteService.AfectaStock_NombreCol];

                if (campos.Contains(FacturasClienteService.MonedaDestinoId_NombreCol))
                {
                    if (!row.IsFECHANull &&
                        (row.IsMONEDA_DESTINO_IDNull || row.MONEDA_DESTINO_ID != decimal.Parse(campos[FacturasClienteService.MonedaDestinoId_NombreCol].ToString())))
                    {
                        actualizarCotizacion = true;
                        regenerarAsiento = true;
                        //Si la moneda es distinta a la moneda principal de la sucursal
                        //el usuario debe contar con el permiso apropiado
                        if (!RolesService.Tiene("FC CLIENTE PUEDE USAR MONEDA DISTINTA A PRINCIPAL DE SUCURSAL"))
                        {
                            if (decimal.Parse(campos[FacturasClienteService.MonedaDestinoId_NombreCol].ToString()) != SucursalesService.GetMonedaSucursal(row.SUCURSAL_ID, sesion))
                                throw new Exception("No tiene permiso para facturar en la moneda seleccionada.");
                        }
                    }
                    row.MONEDA_DESTINO_ID = decimal.Parse(campos[FacturasClienteService.MonedaDestinoId_NombreCol].ToString());
                }
                else
                {
                    row.IsMONEDA_DESTINO_IDNull = true;
                }

                if (campos.Contains(FacturasClienteService.CotizacionDestino_NombreCol))
                {
                    if (row.IsCOTIZACION_DESTINONull || row.COTIZACION_DESTINO != decimal.Parse(campos[FacturasClienteService.MonedaDestinoId_NombreCol].ToString()))
                    {
                        actualizarCotizacion = false;
                        regenerarAsiento = true;
                        row.COTIZACION_DESTINO = decimal.Parse(campos[FacturasClienteService.CotizacionDestino_NombreCol].ToString());
                    }
                }
                else
                {
                    row.IsCOTIZACION_DESTINONull = true;
                }

                if (campos.Contains(FacturasClienteService.CondicionDescripcion_NombreCol))
                    row.CONDICION_DESCRIPCION = (string)campos[FacturasClienteService.CondicionDescripcion_NombreCol];

                //TODO: desarrollar la funcionalidad para
                //que un usuario pueda autorizar mayor descuento
                //row.DESCUENTO_MAX_AUTORIZADO;
                //row.FECHA_AUTORIZACION_DESCUENTO;
                //row.USUARIO_ID_AUTORIZA_DESCUENTO;

                //Panel Vendedor
                if (campos.Contains(FacturasClienteService.VendedorId_NombreCol))
                {
                    if (row.IsVENDEDOR_IDNull || row.VENDEDOR_ID != (decimal)campos[FacturasClienteService.VendedorId_NombreCol])
                    {
                        row.VENDEDOR_ID = (decimal)campos[FacturasClienteService.VendedorId_NombreCol];
                        FuncionariosService funcionario = new FuncionariosService(row.VENDEDOR_ID, sesion);
                        //Validar que si el funcionario no es promotor, entonces
                        //el usuario tiene permiso sobre la sucursal asiganda al funcionario en su ficha
                        if (!RolesService.Tiene("FC CLIENTE NO VALIDAR SUCURSAL VENDEDOR"))
                        {
                            if (!funcionario.SucursalId.HasValue)
                                throw new Exception("El vendedor debe tener una sucursal asiganda.");
                            //Si el funcionario no es promotor, la sucursal del funcionario 
                            //debe estar entre las permitidas al usuario. Si es promotor entonces
                            //no se controla la sucursal
                            if (funcionario.EsPromotor == Definiciones.SiNo.No)
                            {
                                if (!UsuariosSucursalesService.TieneAcceso(funcionario.SucursalId.Value, sesion.Usuario.ID, sesion))
                                    throw new Exception("El vendedor debe ser promotor o pertenecer a la sucursal del usuario.");
                            }
                        }
                        
                        if (funcionario.CanalVentaId.HasValue)
                            row.CANAL_VENTA_ID = funcionario.CanalVentaId.Value;

                        if (funcionario.esVendedor == Definiciones.SiNo.Si && row.IsCANAL_VENTA_IDNull)
                        {
                            if(VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FacturaClienteCanalVentasObligatorioSiHayVendedor) == Definiciones.SiNo.Si)
                                throw new Exception("Debe asignar un canal de venta.");
                        }
                    }
                }
                else
                {
                    row.IsVENDEDOR_IDNull = true;
                }

                if (campos.Contains(FacturasClienteService.CanalVentaId_NombreCol))
                    row.CANAL_VENTA_ID = (decimal)campos[FacturasClienteService.CanalVentaId_NombreCol];

                if (!Interprete.EsNullODBNull(campos[FacturasClienteService.ListaPrecioId_NombreCol]))
                    row.LISTA_PRECIO_ID = decimal.Parse(campos[FacturasClienteService.ListaPrecioId_NombreCol].ToString());
                else
                    row.IsLISTA_PRECIO_IDNull = true;

                row.COMISION_POR_VENTA = (string)campos[FacturasClienteService.ComisionPorVenta_NombreCol];
                //Panel Linea de Credito
                row.AFECTA_LINEA_CREDITO = (string)campos[FacturasClienteService.AfectaLineaCredito_NombreCol];

                if (row.AFECTA_CTACTE == Definiciones.SiNo.No)
                    row.AFECTA_LINEA_CREDITO = Definiciones.SiNo.No;
                //Panel Observacion
                row.OBSERVACION = (string)campos[FacturasClienteService.Observacion_NombreCol];
                row.PORCENTAJE_DESC_SOBRE_TOTAL = decimal.Parse(campos[FacturasClienteService.PorcentajeDescSobreTotal_NombreCol].ToString());
                row.A_CONSIGNACION = (string)campos[FacturasClienteService.AConsignacion_NombreCol];
                if (campos.Contains(FacturasClienteService.Direccion_NombreCol))
                    row.DIRECCION = (string)campos[FacturasClienteService.Direccion_NombreCol];
                else
                    row.DIRECCION = string.Empty;

                if (campos.Contains(FacturasClienteService.Latitud_NombreCol) || campos.Contains(FacturasClienteService.Longitud_NombreCol))
                {
                    if (!(campos.Contains(FacturasClienteService.Latitud_NombreCol) && campos.Contains(FacturasClienteService.Longitud_NombreCol)))
                        throw new Exception("Debe establecer tanto la latitud como la longitud.");

                    row.LATITUD = decimal.Parse(campos[FacturasClienteService.Latitud_NombreCol].ToString());
                    row.LONGITUD = decimal.Parse(campos[FacturasClienteService.Longitud_NombreCol].ToString());
                }
                else
                {
                    row.IsLATITUDNull = true;
                    row.IsLONGITUDNull = true;
                }

                if (campos.Contains(FacturasClienteService.CasoOrigenId_NombreCol))
                    row.CASO_ORIGEN_ID = (decimal)campos[FacturasClienteService.CasoOrigenId_NombreCol];

                if (campos.Contains(FacturasClienteService.MoraPorcentaje_NombreCol))
                    row.MORA_PORCENTAJE = decimal.Parse(campos[FacturasClienteService.MoraPorcentaje_NombreCol].ToString());
                else
                    row.MORA_PORCENTAJE = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FacturaClientePorcentajeMora);

                if (campos.Contains(FacturasClienteService.MoraPorcentaje_NombreCol))
                    row.MORA_DIAS_GRACIA = decimal.Parse(campos[FacturasClienteService.MoraDiasGracia_NombreCol].ToString());
                else
                    row.MORA_DIAS_GRACIA = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PagoDePersonasAplicarMoraFCDesdeDias);

                if (campos.Contains(FacturasClienteService.NroDocumentoExterno_NombreCol))
                    row.NRO_DOCUMENTO_EXTERNO = (string)campos[FacturasClienteService.NroDocumentoExterno_NombreCol];
                else
                    row.NRO_DOCUMENTO_EXTERNO = string.Empty;

                if(row.NRO_DOCUMENTO_EXTERNO.Length > 0 && VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FCClienteValidarNroDocumentoExternoUnico) == Definiciones.SiNo.Si)
                {
                    string clausulas = FacturasClienteService.NroDocumentoExterno_NombreCol + " = '" + row.NRO_DOCUMENTO_EXTERNO.Trim() + "' and " + 
                                       FacturasClienteService.Id_NombreCol + " <> " + row.ID + " and " + 
                                       FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                       FacturasClienteService.VistaCasoEstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "'";
                    DataTable dt = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.NroDocumentoExterno_NombreCol + " = '" + row.NRO_DOCUMENTO_EXTERNO + "' and " + FacturasClienteService.Id_NombreCol + " <> " + row.ID, string.Empty, sesion);
                    if (dt.Rows.Count > 0)
                        throw new Exception("El caso " + dt.Rows[0][FacturasClienteService.CasoId_NombreCol] + " ya está relacionado al número de documento externo " + row.NRO_DOCUMENTO_EXTERNO + ".");
                }

                //Panel Generar Transferencia
                if (campos.Contains(FacturasClienteService.GenerarTransferencia_NombreCol))
                {
                    row.GENERAR_TRANSFERENCIA = (string)campos[FacturasClienteService.GenerarTransferencia_NombreCol];

                    if (row.GENERAR_TRANSFERENCIA == Definiciones.SiNo.Si)
                    {
                        DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesDataTable(AutonumeracionesService.Id_NombreCol + " = " + row.AUTONUMERACION_ID, string.Empty);
                        row.NRO_TIMBRADO_FACT_PRO = GetStringHelper(dtAutonumeracion.Rows[0][AutonumeracionesService.NumeroTimbrado_NombreCol]);
                        if (Interprete.EsNullODBNull(dtAutonumeracion.Rows[0][AutonumeracionesService.Vencimiento_NombreCol]))
                            row.FECHA_VENC_TIMBRADO_FACT_PRO = DateTime.Now;
                        else
                            row.FECHA_VENC_TIMBRADO_FACT_PRO = (DateTime)dtAutonumeracion.Rows[0][AutonumeracionesService.Vencimiento_NombreCol];
                        row.NRO_COMPROBANTE_FACT_PRO = row.NRO_COMPROBANTE;
                    }
                }
                else
                {
                    row.GENERAR_TRANSFERENCIA = Definiciones.SiNo.No;
                    row.NRO_TIMBRADO_FACT_PRO = string.Empty;
                    row.IsFECHA_VENC_TIMBRADO_FACT_PRONull = true;
                    row.NRO_COMPROBANTE_FACT_PRO = string.Empty;
                }

                if (campos.Contains(FacturasClienteService.AutonumeracionTransferenciaId_NombreCol))
                    row.AUTONUMERACION_TRANSF_ID = (decimal)campos[FacturasClienteService.AutonumeracionTransferenciaId_NombreCol];
                else
                    row.IsAUTONUMERACION_TRANSF_IDNull = true;
                
                if (insertarNuevo)
                {
                    sesion.Db.FACTURAS_CLIENTECollection.Insert(row);
                }
                else
                {
                    FACTURAS_CLIENTERow old = sesion.db.FACTURAS_CLIENTECollection.GetByPrimaryKey(row.ID);
                    trigger.BeforeUpdate(ref row, old, sesion);
                    sesion.Db.FACTURAS_CLIENTECollection.Update(row);
                }
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                #region Actualizar el calendario de pagos si la factura no es nueva
                if (actualizarCuotas)
                {
                    #region obtener fecha vencimiento estrategia es por WebService
                    //Si la estrategia de precios es webservice deben actualizarse los totales por cada articulo
                    if ((VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio) == Definiciones.EstrategiaPrecio.WebService))
                    {
                        List<decimal> listArticulos = new List<decimal>();
                        List<decimal> listArticulosCantidades = new List<decimal>();
                        List<decimal> listArticulosDescuentoPorcentaje = new List<decimal>();
                        decimal[] articulosId, articulosCantidades, articulosDescuentoPorcentaje;
                        decimal[] articulosPrecios;
                        decimal monedaOrigen, cotizacionOrigen, listaPrecioId;
                        DataTable dtDetalles = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + row.ID, string.Empty, sesion);

                        for (int i = 0; i < dtDetalles.Rows.Count; i++)
                        {
                            if (!ArticulosService.GetControlarPrecio((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.ArticuloId_NombreCol], sesion))
                                continue;

                            listArticulos.Add((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.ArticuloId_NombreCol]);
                            listArticulosCantidades.Add((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol]);
                            listArticulosDescuentoPorcentaje.Add((decimal)dtDetalles.Rows[i][FacturasClienteDetalleService.PorcentajeDescuento_NombreCol]);
                        }

                        articulosId = listArticulos.ToArray();
                        articulosCantidades = listArticulosCantidades.ToArray();
                        articulosDescuentoPorcentaje = listArticulosDescuentoPorcentaje.ToArray();

                        if (row.IsLISTA_PRECIO_IDNull)
                            listaPrecioId = Definiciones.Error.Valor.EnteroPositivo;
                        else
                            listaPrecioId = row.LISTA_PRECIO_ID;

                        PreciosService.GetPrecioPorArticulo(row.PERSONA_ID, articulosId, articulosCantidades, row.MONEDA_DESTINO_ID, row.SUCURSAL_ID, row.CASO_ID, row.COTIZACION_DESTINO, listaPrecioId, row.CONDICION_PAGO_ID,
                                                            row.TOTAL_ENTREGA_INICIAL, row.FECHA, ref articulosDescuentoPorcentaje, out articulosPrecios, out monedaOrigen, out cotizacionOrigen,
                                                            out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, false, sesion);
                    }
                    #endregion obtener fecha vencimiento estrategia es por WebService

                    decimal cantidadCuotas = CondicionesPagoService.GetCantidadPagos(row.CONDICION_PAGO_ID);
                    CalendarioPagosFCClienteService.CrearCuotas(row.ID, (row.TOTAL_NETO - row.TOTAL_ENTREGA_INICIAL) / cantidadCuotas, row.FECHA, fechaPrimerVencimiento, usarFechaPrimerVencimiento, fechaSegundoVencimiento, usarFechaSegundoVencimiento, sesion);
                }
                #endregion Actualizar el calendario de pagos si la factura no es nueva               

                #region Actualizar la cotización
                //La actualización se da si se cambió la fecha o la moneda y no se definió una cotización específica
                if (actualizarCotizacion)
                {
                    //Actualizar la cabecera
                    row.COTIZACION_DESTINO = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(row.SUCURSAL_ID), row.MONEDA_DESTINO_ID, row.FECHA, sesion);
                }
                #endregion Actualizar la cotización

                estadoId = CasosService.GetEstadoCaso(row.CASO_ID, sesion);
                if (estadoId.Equals(Definiciones.EstadosFlujos.Borrador) || estadoId.Equals(Definiciones.EstadosFlujos.Pendiente))
                {
                    RecalcularTotales(row.ID, fechaPrimerVencimiento, usarFechaPrimerVencimiento, fechaSegundoVencimiento, usarFechaSegundoVencimiento, sesion);
                }

                #region Actualizar datos en tabla casos
                Hashtable camposCaso = new Hashtable();
                camposCaso.Add(CasosService.FechaFormulario_NombreCol, row.FECHA);
                camposCaso.Add(CasosService.NroComprobante_NombreCol, row.NRO_COMPROBANTE);
                camposCaso.Add(CasosService.SucursalId_NombreCol, row.SUCURSAL_ID);
                if (!Interprete.EsNullODBNull(row.NRO_DOCUMENTO_EXTERNO))
                    camposCaso.Add(CasosService.NroComprobante2_NombreCol, row.NRO_DOCUMENTO_EXTERNO);
                if (!row.IsPERSONA_IDNull)
                    camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                if (!row.IsVENDEDOR_IDNull)
                    camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.VENDEDOR_ID);
                CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                #endregion Actualizar datos en tabla casos

                #region Regenear Asiento
                if (regenerarAsiento && estadoId != Definiciones.EstadosFlujos.Borrador && estadoId != Definiciones.EstadosFlujos.Pendiente)
                {
                    DataTable dtAsientos = AsientosService.GetAsientosDataTable(AsientosService.CasoRelacionadoId_NombreCol + " = " + row.CASO_ID, AsientosService.Id_NombreCol, sesion);
                    for (int i = 0; i < dtAsientos.Rows.Count; i++)
                    {
                        AsientosService.Borrar((decimal)dtAsientos.Rows[i][AsientosService.Id_NombreCol], sesion);
                        AsientosAutomaticosService.GenerarAsientosPorTransicion((decimal)dtAsientos.Rows[i][AsientosService.TransicionId_NombreCol], row.CASO_ID, Definiciones.FlujosIDs.FACTURACION_CLIENTE, true, row.FECHA, sesion);
                    }
                }
                #endregion Regenear Asiento

                exito = true;
            }                 
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                exito = false;
                //Si el caso fue creado el mismo debe borrarse
                if (insertarNuevo && row.CASO_ID > 0)
                {
                    (new CasosService()).Eliminar(row.CASO_ID, sesion);
                    caso_id = Definiciones.Error.Valor.EnteroPositivo;
                    estado_id = string.Empty;
                }
                
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch (Exception)
            {
                exito = false;
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

        #region Es caja rapida
        public static bool EsCajaRapida(Decimal casoid) 
        {

            using (SessionService sesion = new SessionService())
            {
                FACTURAS_CLIENTERow FC = sesion.db.FACTURAS_CLIENTECollection.GetByCASO_ID(casoid).First();
                return FC.ES_RAPIDA == Definiciones.SiNo.Si;
            }
            
        }
        #endregion Es caja rapida

        #region ActualizarCuotas
        public static void ActualizarCuotas(decimal factura_id, DateTime fecha_primer_vencimiento, DateTime fecha_segundo_vencimiento, SessionService sesion)
        {
            try
            {
                FACTURAS_CLIENTERow row = new FACTURAS_CLIENTERow();
                row = sesion.Db.FACTURAS_CLIENTECollection.GetRow(FacturasClienteService.Id_NombreCol + " = " + factura_id);

                DataTable dtCuotas;
                bool usarFechaPrimerVencimiento, usarFechaSegundoVencimiento;

                dtCuotas = CalendarioPagosFCClienteService.GetCalendarioPagosDataTable(CalendarioPagosFCClienteService.FacturaClienteId_NombreCol + " = " + row.ID, CalendarioPagosFCClienteService.NumeroCuota_NombreCol, sesion);

                if (dtCuotas.Rows.Count > 0)
                {
                    usarFechaPrimerVencimiento = true;
                    usarFechaSegundoVencimiento = fecha_segundo_vencimiento != DateTime.MinValue;

                    decimal cantidadCuotas = CondicionesPagoService.GetCantidadPagos(row.CONDICION_PAGO_ID);
                    CalendarioPagosFCClienteService.CrearCuotas(row.ID, (row.TOTAL_NETO - row.TOTAL_ENTREGA_INICIAL) / cantidadCuotas, row.FECHA, fecha_primer_vencimiento, usarFechaPrimerVencimiento, fecha_segundo_vencimiento, usarFechaSegundoVencimiento, sesion);
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion ActualizarCuotas

        #region SetCondicionPago
        public static void SetCondicionPago(decimal factura_cliente_id, decimal condicion_pago_id, SessionService sesion)
        {
            FACTURAS_CLIENTERow row = new FACTURAS_CLIENTERow();

            try
            {
                row = sesion.Db.FACTURAS_CLIENTECollection.GetRow(Id_NombreCol + " = " + factura_cliente_id);
                string valorAnteriorFactura = row.ToString();
                row.CONDICION_PAGO_ID = condicion_pago_id;
                row.TIPO_FACTURA_ID = CondicionesPagoService.GetTipoCondicionPago(condicion_pago_id);
                sesion.db.FACTURAS_CLIENTECollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnteriorFactura, row.ToString(), sesion);

                DateTime fechaPrimerVencimiento = DateTime.Now;
                DateTime fechaSegundoVencimiento = DateTime.MinValue;
                bool usarFechaPrimerVencimiento = false;
                bool usarFechaSegundoVencimiento = false;
                DataTable dtCuotas = CalendarioPagosFCClienteService.GetCalendarioPagosDataTable(CalendarioPagosFCClienteService.FacturaClienteId_NombreCol + " = " + row.ID, CalendarioPagosFCClienteService.NumeroCuota_NombreCol);
                if (dtCuotas.Rows.Count > 0)
                    fechaPrimerVencimiento = (DateTime)dtCuotas.Rows[0][CalendarioPagosFCClienteService.FechaVencimiento_NombreCol];

                RecalcularTotales(factura_cliente_id, fechaPrimerVencimiento, usarFechaPrimerVencimiento, fechaSegundoVencimiento, usarFechaSegundoVencimiento, sesion);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion SetCondicionPago

        #region SetCajaSucursal
        /// <summary>
        /// Sets the ctacte_caja_sucursal_id.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetCajaSucursal(decimal caso_id, decimal ctacte_caja_sucursal_id, SessionService sesion)
        {
            FACTURAS_CLIENTERow row = new FACTURAS_CLIENTERow();

            try
            {
                row = sesion.Db.FACTURAS_CLIENTECollection.GetRow(CasoId_NombreCol + " = " + caso_id);
                string valorAnteriorFactura = row.ToString();
                row.CTACTE_CAJA_SUCURSAL_ID = ctacte_caja_sucursal_id;
                sesion.db.FACTURAS_CLIENTECollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnteriorFactura, row.ToString(), sesion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion SetCajaSucursal

        #region SetNroComprobanteExterno
        public static void SetNroComprobanteExterno(decimal factura_cliente_id, string nro_comprobante_externo, SessionService sesion)
        {
            FACTURAS_CLIENTERow row = sesion.db.FACTURAS_CLIENTECollection.GetByPrimaryKey(factura_cliente_id);
            row.NRO_DOCUMENTO_EXTERNO = nro_comprobante_externo;
            sesion.db.FACTURAS_CLIENTECollection.Update(row);
        }
        #endregion SetNroComprobanteExterno

        #region GenerarNumeroComprobante
        public static string GenerarNumeroComprobante(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    FACTURAS_CLIENTERow cabeceraRow = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
                    string valorAnterior = cabeceraRow.ToString();

                    if (cabeceraRow.IsAUTONUMERACION_IDNull)
                        throw new Exception("Debe indicarse el talonario o un número de comprobante manual.");

                    decimal funcionarioId = Definiciones.Error.Valor.EnteroPositivo;
                    if (!cabeceraRow.IsVENDEDOR_IDNull)
                        funcionarioId = cabeceraRow.VENDEDOR_ID;
                    else if (!sesion.Usuario.IsFUNCIONARIO_IDNull)
                        funcionarioId = sesion.Usuario.FUNCIONARIO_ID;
                    if (!AutonumeracionesService.FuncionarioPuedeUsar(cabeceraRow.AUTONUMERACION_ID, funcionarioId, sesion))
                        throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");

                    if (AutonumeracionesService.EsGeneracionManual(cabeceraRow.AUTONUMERACION_ID, sesion))
                        throw new Exception("Debe indicar el número de comprobante que es de numeración manual.");
                    
                    //Se debe traer el siguiente numero para completar las validaciones. Aun no se debe actualizar el talonario
                    string nroComprobanteAux = AutonumeracionesService.ConsultarSiguienteNumero(cabeceraRow.AUTONUMERACION_ID, sesion);
                    decimal nroComprobanteNumerico = Definiciones.Error.Valor.EnteroPositivo;

                    if (FacturasClienteService.GetExisteNroComprobante(cabeceraRow.ID, cabeceraRow.AUTONUMERACION_ID, nroComprobanteAux, sesion))
                        throw new Exception("Ya existe una factura con el mismo número de comprobante.");

                    //Controlar que se logro asignar una numeracion
                    if (nroComprobanteAux.Equals(""))
                        throw new Exception("No se pudo asignar una numeración válida");

                    //Si se pasaron todas las validaciones. Generar comprobante.
                    cabeceraRow.NRO_COMPROBANTE = AutonumeracionesService.GetSiguienteNumero2(cabeceraRow.AUTONUMERACION_ID, out nroComprobanteNumerico, sesion);
                    cabeceraRow.NRO_COMPROBANTE_SECUENCIA = nroComprobanteNumerico;

                    sesion.db.FACTURAS_CLIENTECollection.Update(cabeceraRow);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, cabeceraRow.ID, valorAnterior, cabeceraRow.ToString(), sesion);

                    sesion.CommitTransaction();
                    return cabeceraRow.NRO_COMPROBANTE;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion GenerarNumeroComprobante

        #region CrearPagareGarantia
        /// <summary>
        /// Crears the pagare garantia.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static string CrearPagareGarantia(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    DataTable dtFactura = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoId_NombreCol + " = " + caso_id, string.Empty);
                    decimal garante1 = Definiciones.Error.Valor.EnteroPositivo;
                    decimal garante2 = Definiciones.Error.Valor.EnteroPositivo;
                    decimal ctactePagareId;
                    DateTime vencimiento;
                    string nroComprobante;

                    if (!Interprete.EsNullODBNull(dtFactura.Rows[0][FacturasClienteService.PersonaGarante1Id_NombreCol]))
                        garante1 = (decimal)dtFactura.Rows[0][FacturasClienteService.PersonaGarante1Id_NombreCol];

                    if (!Interprete.EsNullODBNull(dtFactura.Rows[0][FacturasClienteService.PersonaGarante2Id_NombreCol]))
                        garante2 = (decimal)dtFactura.Rows[0][FacturasClienteService.PersonaGarante2Id_NombreCol];

                    if (!Interprete.EsNullODBNull(dtFactura.Rows[0][FacturasClienteService.FechaVencimiento_NombreCol]))
                        vencimiento = (DateTime)dtFactura.Rows[0][FacturasClienteService.FechaVencimiento_NombreCol];
                    else
                        vencimiento = (DateTime)dtFactura.Rows[0][FacturasClienteService.Fecha_NombreCol];

                    ctactePagareId = CuentaCorrientePagaresService.CrearPagareGarantia(caso_id,
                                          (decimal)dtFactura.Rows[0][FacturasClienteService.MonedaDestinoId_NombreCol],
                                          (decimal)dtFactura.Rows[0][FacturasClienteService.CotizacionDestino_NombreCol],
                                          (decimal)dtFactura.Rows[0][FacturasClienteService.TotalNeto_NombreCol],
                                          vencimiento,
                                          (decimal)dtFactura.Rows[0][FacturasClienteService.PersonaId_NombreCol],
                                          garante1,
                                          garante2,
                                          Definiciones.Error.Valor.EnteroPositivo,
                                          sesion);

                    nroComprobante = CuentaCorrientePagaresService.SetJuegoAprobado(ctactePagareId);
                    return nroComprobante;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion CrearPagareGarantia

        #region CrearPorRecargos
        public static decimal CrearPorRecargos(DateTime fecha_desde, DateTime fecha_hasta, decimal moneda_id, decimal sucursal_id, decimal deposito_id, decimal ctacte_caja_sucursal_id, DateTime fecha_factura, decimal autonumeracion_id, string nro_comprobante, decimal persona_id, decimal funcionario_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    //Objetos para crear la factura y los detalles
                    CasosService casoService = new CasosService();
                    FacturasClienteService facturaClienteService = new FacturasClienteService();
                    System.Collections.Hashtable campos;
                    string casoFacturaEstado = string.Empty, mensaje;
                    decimal casoFacturaId = Definiciones.Error.Valor.EnteroPositivo;
                    decimal ctacteCondicionPagoId;
                    DateTime fechaVencimiento;
                    bool exito;

                    DataTable articuloGastoCobranza, articuloInteresPunitorio, articuloMora;
                    DataTable loteGastoCobranza, loteInteresPunitorio, loteMora;
                    DataTable dtRecargos;
                    DataTable dtFacturaCreada;
                    decimal montoTotal;

                    DateTime fechaPrimerVencimiento = DateTime.Now;
                    DateTime fechaSegundoVencimiento = DateTime.MinValue;
                    bool usarFechaPrimerVencimiento = false;
                    bool usarFechaSegundoVencimiento = false;

                    string clausulas = CuentaCorrienteRecargosService.CasoFacturaId_NombreCol + " is null and " +
                                   CuentaCorrienteRecargosService.Monto_NombreCol + " > 0 and " +
                                   "trunc(" + CuentaCorrienteRecargosService.Fecha_NombreCol + ") between " +
                                   "      to_date('" + fecha_desde.ToShortDateString() + "', 'dd/mm/yyyy') and " +
                                   "      to_date('" + fecha_hasta.ToShortDateString() + "', 'dd/mm/yyyy') ";
                    dtRecargos = CuentaCorrienteRecargosService.GetCtacteRecargosDataTable(clausulas, string.Empty);

                    if (dtRecargos.Rows.Count <= 0)
                        throw new Exception("No existen recargos a facturar en el rango de fechas y moneda seleccionados.");

                    articuloGastoCobranza = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoGastoCobranza), string.Empty, false, sucursal_id);
                    articuloMora = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoMoraArticulo), string.Empty, false, sucursal_id);
                    articuloInteresPunitorio = ArticulosService.GetArticulos(ArticulosService.Id_NombreCol + " = " + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClienteComoComprobantePagoInteresPunitorio), string.Empty, false, sucursal_id);

                    loteGastoCobranza = ArticulosLotesService.GetArticulosLotesInfoCompleta2((decimal)articuloGastoCobranza.Rows[0][Articulos.ArticulosService.Id_NombreCol], string.Empty);
                    loteMora = ArticulosLotesService.GetArticulosLotesInfoCompleta2((decimal)articuloMora.Rows[0][Articulos.ArticulosService.Id_NombreCol], string.Empty);
                    loteInteresPunitorio = ArticulosLotesService.GetArticulosLotesInfoCompleta2((decimal)articuloInteresPunitorio.Rows[0][Articulos.ArticulosService.Id_NombreCol], string.Empty);

                    if (loteGastoCobranza.Rows.Count <= 0)
                        throw new Exception("No existe ningún lote para el artículo " + articuloGastoCobranza.Rows[0][Articulos.ArticulosService.Id_NombreCol] + " definido en la variable de sistema.");
                    if (loteMora.Rows.Count <= 0)
                        throw new Exception("No existe ningún lote para el artículo " + articuloMora.Rows[0][Articulos.ArticulosService.Id_NombreCol] + " definido en la variable de sistema.");
                    if (loteInteresPunitorio.Rows.Count <= 0)
                        throw new Exception("No existe ningún lote para el artículo " + articuloInteresPunitorio.Rows[0][Articulos.ArticulosService.Id_NombreCol] + " definido en la variable de sistema.");

                    ctacteCondicionPagoId = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CondicionPagoCredito);
                    fechaVencimiento = CondicionesPagoService.GetUltimoVencimiento(ctacteCondicionPagoId, fecha_factura, sesion);

                    #region Crear cabecera FC
                    campos = new System.Collections.Hashtable();
                    campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.No);
                    campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, autonumeracion_id);
                    campos.Add(FacturasClienteService.NroComprobante_NombreCol, nro_comprobante);
                    campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                    campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, ctacteCondicionPagoId);
                    campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(sucursal_id), moneda_id, fecha_factura, sesion));
                    campos.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, fechaVencimiento);
                    campos.Add(FacturasClienteService.Fecha_NombreCol, fecha_factura);
                    campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, moneda_id);
                    campos.Add(FacturasClienteService.NroDocumentoExterno_NombreCol, "0");
                    campos.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
                    campos.Add(FacturasClienteService.Observacion_NombreCol, "Factura creada como comprobante de recargos.");
                    campos.Add(FacturasClienteService.PersonaId_NombreCol, persona_id);
                    campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, (decimal)0);
                    campos.Add(FacturasClienteService.SucursalId_NombreCol, sucursal_id);
                    campos.Add(FacturasClienteService.SucursalVentaId_NombreCol, sucursal_id);
                    campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, CondicionesPagoService.EsContado(ctacteCondicionPagoId) ? Definiciones.TipoFactura.Contado : Definiciones.TipoFactura.Credito);
                    campos.Add(FacturasClienteService.VendedorId_NombreCol, funcionario_id);
                    campos.Add(FacturasClienteService.CtaCteCajaSucursalId_NombreCol, ctacte_caja_sucursal_id);
                    campos.Add(FacturasClienteService.DepositoId_NombreCol, deposito_id);
                    campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, (decimal)0);

                    //El campo no es obligatorio al guardar, pero si posteriormente en el cambio de estado
                    string clausulasListaPrecios = ListaDePrecio.ListasDePrecioService.MonedaId_NombreCol + " = " + moneda_id + " and " +
                                                   ListaDePrecio.ListasDePrecioService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                                   "(" + ListaDePrecio.ListasDePrecioService.RegionId_NombreCol + " is null or " + ListaDePrecio.ListasDePrecioService.RegionId_NombreCol + " = " + new SucursalesService(sucursal_id, sesion).RegionId.Value + ") and " +
                                                   "(" + ListaDePrecio.ListasDePrecioService.SucursalId_NombreCol + " is null or " + ListaDePrecio.ListasDePrecioService.SucursalId_NombreCol + " = " + sucursal_id + ") ";
                    DataTable dtListaPrecios = ListaDePrecio.ListasDePrecioService.GetListasDePrecioDataTable2(clausulasListaPrecios, ListaDePrecio.ListasDePrecioService.Id_NombreCol);
                    if (dtListaPrecios.Rows.Count > 0)
                        campos.Add(FacturasClienteService.ListaPrecioId_NombreCol, dtListaPrecios.Rows[0][ListaDePrecio.ListasDePrecioService.Id_NombreCol]);

                    FacturasClienteService.Guardar(campos, true, ref casoFacturaId, ref casoFacturaEstado, sesion);
                    #endregion Crear cabecera FC

                    if (casoFacturaId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        return Definiciones.Error.Valor.EnteroPositivo;

                    dtFacturaCreada = FacturasClienteService.GetFacturaClienteInfoCompleta(FacturasClienteService.CasoId_NombreCol + " = " + casoFacturaId, string.Empty, sesion);

                    #region Crear detalle por recargo
                    montoTotal = 0;
                    for (int i = 0; i < dtRecargos.Rows.Count; i++)
                    {
                        DataTable dtArticulo, dtLote;

                        #region inicializar articulo y lote
                        if (dtRecargos.Rows[i][CuentaCorrienteRecargosService.TipoRecargo_NombreCol].Equals(Definiciones.TipoRecargo.Mora))
                        {
                            dtArticulo = articuloMora;
                            dtLote = loteMora;
                        }
                        else if (dtRecargos.Rows[i][CuentaCorrienteRecargosService.TipoRecargo_NombreCol].Equals(Definiciones.TipoRecargo.GastoCobranza))
                        {
                            dtArticulo = articuloGastoCobranza;
                            dtLote = loteGastoCobranza;
                        }
                        else if (dtRecargos.Rows[i][CuentaCorrienteRecargosService.TipoRecargo_NombreCol].Equals(Definiciones.TipoRecargo.InteresPunitorio))
                        {
                            dtArticulo = articuloInteresPunitorio;
                            dtLote = loteInteresPunitorio;
                        }
                        else
                        {
                            throw new Exception("Error en FacturaClienteService.CrearPorRecargos(). Tipo de recargo no implementado.");
                        }
                        #endregion inicializar articulo y lote

                        campos = new System.Collections.Hashtable();
                        campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, dtArticulo.Rows[0][Articulos.ArticulosService.Id_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, dtLote.Rows[0][Articulos.ArticulosLotesService.Id_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, dtArticulo.Rows[0][Articulos.ArticulosService.UnidadMedidaId_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                        campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                        campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, dtArticulo.Rows[0][Articulos.ArticulosService.ImpuestoId_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, dtRecargos.Rows[i][CuentaCorrienteRecargosService.Monto_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                        campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                        campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, "Originado en caso " + dtRecargos.Rows[i][CuentaCorrienteRecargosService.CasoOrigenId_NombreCol]);
                        campos.Add(FacturasClienteDetalleService.CtacteRecargoId_NombreCol, dtRecargos.Rows[i][CuentaCorrienteRecargosService.Id_NombreCol]);

                        FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, i == (dtRecargos.Rows.Count - 1), out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, sesion);
                        montoTotal += (decimal)dtRecargos.Rows[i][CuentaCorrienteRecargosService.Monto_NombreCol];
                    }
                    #endregion Crear detalle por recargo

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
                    if (exito)
                    {
                        exito = facturaClienteService.ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, false, out mensaje, sesion);
                        if (exito)
                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, "Transición automática.", sesion);
                        if (exito)
                            facturaClienteService.EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Caja, sesion);
                        if (!exito)
                            throw new Exception(mensaje);
                    }

                    //Pasar a Cerrado
                    if (exito)
                    {
                        exito = facturaClienteService.ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                        if (exito)
                            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, "Transición automática.", sesion);
                        if (exito)
                            facturaClienteService.EjecutarAccionesLuegoDeCambioEstado(casoFacturaId, Definiciones.EstadosFlujos.Cerrado, sesion);
                        if (!exito)
                            throw new Exception(mensaje);
                    }
                    #endregion Aprobar el caso de FC Cliente

                    return (decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol];
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion CrearPorRecargos

        #region CambiarOC
        public static void CambiarOC(decimal factura_cliente_id, string nro_comprobante_externo, SessionService sesion)
        {
            try
            {
                FACTURAS_CLIENTERow factura = FacturasClienteService.GetFacturaCliente(factura_cliente_id, sesion);
                factura.NRO_DOCUMENTO_EXTERNO = nro_comprobante_externo;

                sesion.db.FACTURAS_CLIENTECollection.Update(factura);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion ActualizarOC

        #region Recalcular totales
        /// <summary>
        /// Recalcular totales en la cabecera. La transaccion no es abierta ni cerrada dentro del metodo
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void RecalcularTotales(decimal factura_cliente_id, DateTime fecha_primer_vencimiento, bool usar_fecha_primer_vencimiento, DateTime fecha_segundo_vencimiento, bool usar_fecha_segundo_vencimiento, SessionService sesion)
        {
            try
            {
                FACTURAS_CLIENTERow factura = FacturasClienteService.GetFacturaCliente(factura_cliente_id, sesion);
                FACTURAS_CLIENTE_DETALLERow[] detalles = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByFACTURAS_CLIENTE_ID(factura_cliente_id);
                decimal totalNetoAnterior = factura.TOTAL_NETO;

                #region Actualizar precios si estrategia es por WebService
                //Si la estrategia de precios es webservice deben actualizarse los totales por cada articulo
                if ((VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio) == Definiciones.EstrategiaPrecio.WebService))
                {
                    List<decimal> listArticulos = new List<decimal>();
                    List<decimal> listArticulosCantidades = new List<decimal>();
                    List<decimal> listArticulosDescuentoPorcentaje = new List<decimal>();
                    decimal[] articulosId, articulosCantidades, articulosDescuentoPorcentaje;
                    decimal[] articulosPrecios;
                    decimal monedaOrigen, cotizacionOrigen, listaPrecioId;

                    for (int i = 0; i < detalles.Length; i++)
                    {
                        if (!ArticulosService.GetControlarPrecio(detalles[i].ARTICULO_ID))
                            continue;

                        listArticulos.Add(detalles[i].ARTICULO_ID);
                        listArticulosCantidades.Add(detalles[i].CANTIDAD_UNITARIA_TOTAL_DEST);
                        listArticulosDescuentoPorcentaje.Add(detalles[i].PORCENTAJE_DTO);
                    }

                    articulosId = listArticulos.ToArray();
                    articulosCantidades = listArticulosCantidades.ToArray();
                    articulosDescuentoPorcentaje = listArticulosDescuentoPorcentaje.ToArray();

                    if (factura.IsLISTA_PRECIO_IDNull)
                        listaPrecioId = Definiciones.Error.Valor.EnteroPositivo;
                    else
                        listaPrecioId = factura.LISTA_PRECIO_ID;

                    PreciosService.GetPrecioPorArticulo(factura.PERSONA_ID, articulosId, articulosCantidades, factura.MONEDA_DESTINO_ID, factura.SUCURSAL_ID, factura.CASO_ID, factura.COTIZACION_DESTINO, listaPrecioId, factura.CONDICION_PAGO_ID,
                                                        factura.TOTAL_ENTREGA_INICIAL, factura.FECHA, ref articulosDescuentoPorcentaje, out articulosPrecios, out monedaOrigen, out cotizacionOrigen,
                                                        out fecha_primer_vencimiento, out usar_fecha_primer_vencimiento, out fecha_segundo_vencimiento, out usar_fecha_segundo_vencimiento, false, sesion);

                    int contador = 0; //Utilizado para iterar sobre la respuesta
                    for (int i = 0; i < detalles.Length; i++)
                    {
                        if (!ArticulosService.GetControlarPrecio(detalles[i].ARTICULO_ID))
                            continue;

                        string valorAnterior = detalles[i].ToString();

                        detalles[i].PRECIO_LISTA_ORIGEN = articulosPrecios[contador];
                        detalles[i].PRECIO_LISTA_DESTINO = articulosPrecios[contador];
                        detalles[i].TOTAL_MONTO_BRUTO = detalles[i].PRECIO_LISTA_DESTINO * detalles[i].CANTIDAD_UNITARIA_TOTAL_DEST;
                        detalles[i].PORCENTAJE_DTO = articulosDescuentoPorcentaje[contador];
                        detalles[i].MONTO_DESCUENTO = articulosPrecios[contador] * articulosDescuentoPorcentaje[contador] / 100;

                        contador++;

                        detalles[i].TOTAL_RECARGO_FINANCIERO = 0;
                        //Si la operacion no es contado
                        if (factura.TIPO_FACTURA_ID == Definiciones.TipoFactura.Credito)
                        {
                            #region Calcular recargo financiero
                            //Si el articulo tiene recargo financiero guardar el monto
                            DataTable dtArticulos = ArticulosService.GetArticuloInfoCompletaPorID(detalles[i].ARTICULO_ID, factura.SUCURSAL_ID, sesion);
                            if ((string)dtArticulos.Rows[0][ArticulosService.RecargoFinanciero_NombreCol] == Definiciones.SiNo.Si)
                            {
                                //Monto neto por recargo mensual por cantidad de pagos
                                // neto - neto / (1 + recargo * meses)
                                detalles[i].TOTAL_RECARGO_FINANCIERO = detalles[i].TOTAL_MONTO_BRUTO - detalles[i].TOTAL_MONTO_BRUTO /
                                                               (1 + VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.FCClientePorcentajeRecargoFinanciero) / 100 * CondicionesPagoService.GetCantidadPagos(factura.CONDICION_PAGO_ID));
                            }
                            #endregion Calcular recargo financiero
                        }

                        detalles[i].TOTAL_MONTO_DTO = detalles[i].MONTO_DESCUENTO * detalles[i].CANTIDAD_UNITARIA_TOTAL_DEST;
                        detalles[i].TOTAL_NETO = detalles[i].TOTAL_MONTO_BRUTO - detalles[i].TOTAL_MONTO_DTO - detalles[i].TOTAL_RECARGO_FINANCIERO;
                        detalles[i].TOTAL_NETO_LUEGO_DE_NC = detalles[i].TOTAL_NETO;

                        if (detalles[i].PORCENTAJE_IMPUESTO == 0)
                            detalles[i].TOTAL_MONTO_IMPUESTO = 0;
                        else
                            detalles[i].TOTAL_MONTO_IMPUESTO = detalles[i].TOTAL_NETO / ((100 / detalles[i].PORCENTAJE_IMPUESTO) + 1);

                        detalles[i].MONTO_COMISION_VEN = (detalles[i].PORCENTAJE_COMISION_VEN * (detalles[i].TOTAL_NETO - detalles[i].TOTAL_MONTO_IMPUESTO)) / 100;

                        sesion.Db.FACTURAS_CLIENTE_DETALLECollection.Update(detalles[i]);
                        LogCambiosService.LogDeRegistro(FacturasClienteDetalleService.Nombre_Tabla, detalles[i].ID, valorAnterior, detalles[i].ToString(), sesion);
                    }
                }
                #endregion Actualizar precios si estrategia es por WebService

                factura.TOTAL_RECARGO_FINANCIERO = 0;
                for (int i = 0; i < detalles.Length; i++)
                    factura.TOTAL_RECARGO_FINANCIERO += detalles[i].TOTAL_RECARGO_FINANCIERO;

                FacturasClienteDetalleService.ActualizarArticuloRecargoFinanciero(factura.ID, factura.CASO_ID, factura.TOTAL_RECARGO_FINANCIERO, sesion);

                //Se recargan los detalles ya habiendo actualizado el articulo por recargo financiero
                detalles = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByFACTURAS_CLIENTE_ID(factura_cliente_id);
                string valorAnteriorFactura = factura.ToString();
                factura.TOTAL_MONTO_BRUTO = 0;
                factura.TOTAL_MONTO_DTO = 0;
                factura.TOTAL_MONTO_IMPUESTO = 0;
                factura.TOTAL_NETO = 0;
                factura.TOTAL_RECARGO_FINANCIERO = 0;

                for (int i = 0; i < detalles.Length; i++)
                {
                    factura.TOTAL_MONTO_BRUTO += detalles[i].TOTAL_MONTO_BRUTO;
                    factura.TOTAL_MONTO_DTO += detalles[i].TOTAL_MONTO_DTO;
                    factura.TOTAL_MONTO_IMPUESTO += detalles[i].TOTAL_MONTO_IMPUESTO;
                    factura.TOTAL_NETO += detalles[i].TOTAL_NETO;
                    factura.TOTAL_RECARGO_FINANCIERO += detalles[i].TOTAL_RECARGO_FINANCIERO;
                }

                decimal descuento = factura.TOTAL_NETO;
                if (!factura.IsPORCENTAJE_DESC_SOBRE_TOTALNull)
                    descuento = (factura.TOTAL_NETO * factura.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;

                factura.TOTAL_MONTO_DTO += descuento;
                factura.TOTAL_MONTO_IMPUESTO = factura.TOTAL_MONTO_IMPUESTO * (100 - factura.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;
                factura.TOTAL_NETO -= descuento;

                sesion.db.FACTURAS_CLIENTECollection.Update(factura);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, factura.ID, valorAnteriorFactura, factura.ToString(), sesion);

                //Si cambia recalcular las cuotas
                if (totalNetoAnterior != factura.TOTAL_NETO)
                {
                    if (factura.TOTAL_NETO - factura.TOTAL_ENTREGA_INICIAL <= 0)
                    {
                        CalendarioPagosFCClienteService.BorrarPorFactura(factura.ID, sesion);
                    }
                    else
                    {
                        decimal cantidadCuotas = CondicionesPagoService.GetCantidadPagos(factura.CONDICION_PAGO_ID);
                        CalendarioPagosFCClienteService.CrearCuotas(factura.ID, (factura.TOTAL_NETO - factura.TOTAL_ENTREGA_INICIAL) / cantidadCuotas, factura.FECHA, fecha_primer_vencimiento, usar_fecha_primer_vencimiento, fecha_segundo_vencimiento, usar_fecha_segundo_vencimiento, sesion);
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Recalcular totales en la cabecera. La transaccion no es abierta ni cerrada dentro del metodo
        /// para redondear los totales cada 50guaraniees 
        /// solo usar si la moneda es guaranies
        /// </summary>
        /// <param name="factura_cliente_id">The factura_cliente_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void totalesCajarapida(decimal factura_cliente_id, SessionService sesion)
        {
            try
            {
                FACTURAS_CLIENTERow factura = FacturasClienteService.GetFacturaCliente(factura_cliente_id, sesion);
                FACTURAS_CLIENTE_DETALLERow[] detalles = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByFACTURAS_CLIENTE_ID(factura_cliente_id);
                decimal totalNetoAnterior = factura.TOTAL_NETO;
                factura.TOTAL_RECARGO_FINANCIERO = 0;
                for (int i = 0; i < detalles.Length; i++)
                    factura.TOTAL_RECARGO_FINANCIERO += detalles[i].TOTAL_RECARGO_FINANCIERO;

                FacturasClienteDetalleService.ActualizarArticuloRecargoFinanciero(factura.ID, factura.CASO_ID, factura.TOTAL_RECARGO_FINANCIERO, sesion);

                //Se recargan los detalles ya habiendo actualizado el articulo por recargo financiero
                detalles = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByFACTURAS_CLIENTE_ID(factura_cliente_id);
                string valorAnteriorFactura = factura.ToString();
                factura.TOTAL_MONTO_BRUTO = 0;
                factura.TOTAL_MONTO_DTO = 0;
                factura.TOTAL_MONTO_IMPUESTO = 0;
                factura.TOTAL_NETO = 0;
                factura.TOTAL_RECARGO_FINANCIERO = 0;

                for (int i = 0; i < detalles.Length; i++)
                {
                    factura.TOTAL_MONTO_BRUTO += detalles[i].TOTAL_MONTO_BRUTO;
                    factura.TOTAL_MONTO_DTO += detalles[i].TOTAL_MONTO_DTO;
                    factura.TOTAL_MONTO_IMPUESTO += detalles[i].TOTAL_MONTO_IMPUESTO;
                    factura.TOTAL_NETO += detalles[i].TOTAL_NETO;
                    factura.TOTAL_RECARGO_FINANCIERO += detalles[i].TOTAL_RECARGO_FINANCIERO;
                }

                
                
                double residuo = (double)factura.TOTAL_MONTO_BRUTO % 50;
                double valorRedondeado = (double)factura.TOTAL_MONTO_BRUTO - residuo;
                double porcentajeDescuento = (((double)factura.TOTAL_MONTO_BRUTO - valorRedondeado) / (double)factura.TOTAL_MONTO_BRUTO) * 100;
                decimal descuento = (decimal)residuo;
                factura.PORCENTAJE_DESC_SOBRE_TOTAL = (decimal)porcentajeDescuento;
                factura.TOTAL_MONTO_BRUTO = (decimal)valorRedondeado ;
                factura.TOTAL_MONTO_DTO = descuento;
                factura.TOTAL_MONTO_IMPUESTO = factura.TOTAL_MONTO_IMPUESTO * (100 - factura.PORCENTAJE_DESC_SOBRE_TOTAL) / 100;
                factura.TOTAL_NETO -= descuento;

                sesion.db.FACTURAS_CLIENTECollection.Update(factura);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, factura.ID, valorAnteriorFactura, factura.ToString(), sesion);

            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Recalcular totales

        #region RecalcularTotalNetoDespuesDeNC
        /// <summary>
        /// Se llama unicamente cuando la NC NO es por devolucion, y por lo tanto debe distribuirse el cambio a todos los detalles
        /// de manera proporcional
        /// </summary>
        /// <param name="fc_cliente_id">The fc_cliente_id.</param>
        /// <param name="total">The total.</param>
        /// <param name="sesion">The sesion.</param>
        public static void RecalcularTotalNetoDespuesDeNC(decimal fc_cliente_id, decimal total, SessionService sesion)
        {
            string clausulas = FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + fc_cliente_id;
            //se obtienen los detalles de la factura
            DataTable detalles = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(clausulas, string.Empty, sesion);
            FACTURAS_CLIENTERow facturaRow = FacturasClienteService.GetFacturaCliente(fc_cliente_id, sesion);
            decimal sum_total_neto_despues_nc = 0;
            foreach (DataRow detalle in detalles.Rows)
            {
                sum_total_neto_despues_nc += (decimal)detalle[FacturasClienteDetalleService.TotalNetoLuegoDeNC_NombreCol];
            }

            // los detalles no consideran el descuento global, por lo tanto se calcula el maximo monto de la NC admitido
            decimal total_neto_con_descuento = facturaRow.IsPORCENTAJE_DESC_SOBRE_TOTALNull || facturaRow.PORCENTAJE_DESC_SOBRE_TOTAL == 0 ? sum_total_neto_despues_nc : sum_total_neto_despues_nc * (1 - facturaRow.PORCENTAJE_DESC_SOBRE_TOTAL / 100);
            // solamente es adminisible el calculo si el total es menor o igual al total de los detalles con el descuento global aplicado
            if (total_neto_con_descuento >= total)
            {
                // los detalles no consideran el descuento global, por lo tanto se calcula el total a distribuir (el total de la NC sin el descuento global)
                decimal total_sin_descuento = facturaRow.IsPORCENTAJE_DESC_SOBRE_TOTALNull || facturaRow.PORCENTAJE_DESC_SOBRE_TOTAL == 0 ? total : total / (1 - facturaRow.PORCENTAJE_DESC_SOBRE_TOTAL / 100);
                foreach (DataRow detalle in detalles.Rows)
                {
                    decimal detalle_id = (decimal)detalle[FacturasClienteDetalleService.Id_NombreCol];
                    decimal total_neto_luego_de_nc = (decimal)detalle[FacturasClienteDetalleService.TotalNetoLuegoDeNC_NombreCol];

                    //Segun la factura haya o no sido devuelta en un 100% por concepto
                    decimal porcentaje;
                    if (sum_total_neto_despues_nc != 0)
                        porcentaje = total_neto_luego_de_nc / sum_total_neto_despues_nc;
                    else
                        porcentaje = (decimal)detalle[FacturasClienteDetalleService.TotalNeto_NombreCol] / facturaRow.TOTAL_NETO;

                    decimal nuevo_total = total_neto_luego_de_nc - total_sin_descuento * porcentaje;
                    FacturasClienteDetalleService.ActualizarTotalNetoLuegoDeNC(detalle_id, nuevo_total, sesion);
                }
            }
        }
        #endregion RecalcularTotalNetoDespuesDeNC
        
        #region Borrar
        public static bool Borrar(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    bool exito = true;
                    sesion.BeginTransaction();
                    exito = Borrar(caso_id, sesion);
                    sesion.CommitTransaction();
                    return exito;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static bool Borrar(decimal caso_id, SessionService sesion)
        {
            try
            {
                bool exito = true;
                string mensaje = "Error.";

                // Se obtienen el caso y la factura a ser borrados
                CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                FACTURAS_CLIENTERow factura = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
                string valorAnterior = factura.ToString();

                // SI EL TALONARIO ES AUTOMATICO Y YA TIENE NUMERO DE FACTURA, NO PUEDE ELIMINARSE EL CASO
                if (!factura.IsAUTONUMERACION_IDNull && factura.NRO_COMPROBANTE != null)
                {
                    //exito = false;
                    //mensaje = "El caso no puede borrarse. Factura con Nro Comprobante";
                    throw new Exception("Este caso no puede Borrarse...");
                }

                if (exito)
                {
                    // Se obtienen los detalles del caso a ser borrados.
                    DataTable detalles = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.FacturaClienteId_NombreCol + " = " + factura.ID, FacturasClienteDetalleService.Id_NombreCol);

                    // Si el caso esta en BORRADOR, se pide que se borren los detalles
                    if (caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //se borra los detalles
                        if (detalles.Rows.Count > 0)
                        {
                            foreach (DataRow detalle in detalles.Rows)
                                FacturasClienteDetalleService.Borrar((decimal)detalle[FacturasClienteDetalleService.Id_NombreCol], factura.CASO_ID, true, sesion);
                        }
                    }
                    // Si el caso esta en PENDIENTE, se borran los detalles
                    else if (caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        // Se borran los detalles. El borrado en FacturasClienteDetalleService ya tiene en cuenta el retorno de stock
                        if (detalles.Rows.Count > 0)
                        {
                            foreach (DataRow detalle in detalles.Rows)
                                FacturasClienteDetalleService.Borrar((decimal)detalle[FacturasClienteDetalleService.Id_NombreCol], factura.CASO_ID, true, sesion);
                        }
                    }
                    // Si el caso esta en ANULADO, se borran los detalles y se borran los asientos
                    else if (caso.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        // Se borran los detalles. El borrado en FacturasClienteDetalleService ya tiene en cuenta el retorno de stock
                        if (detalles.Rows.Count > 0)
                        {
                            foreach (DataRow detalle in detalles.Rows)
                                FacturasClienteDetalleService.Borrar((decimal)detalle[FacturasClienteDetalleService.Id_NombreCol], factura.CASO_ID, true, sesion);
                        }

                        // Se borra la asociacion entre los asientos, si el caso llego a CAJA
                        DataTable dtAsientos = AsientosService.GetAsientosDataTable(AsientosService.CasoRelacionadoId_NombreCol + " = " + factura.CASO_ID, string.Empty, sesion);
                        if (dtAsientos.Rows.Count > 0)
                        {
                            // Se borra la asociacion entre los asientos y el caso a borrar y se inactivan los asientos
                            foreach (DataRow asiento in dtAsientos.Rows)
                            {
                                // Se borra la asociacion
                                AsientosService.SetCasoRelacionadoNull((decimal)asiento[AsientosService.Id_NombreCol], true, sesion);

                                // Se inactiva el asiento
                                AsientosService.Borrar((decimal)asiento[AsientosService.Id_NombreCol]);
                            }
                        }
                    }
                }
                else
                {
                    exito = false;
                    mensaje = "El caso solo puede borrarse en los estados BORRADOR, PENDIENTE o ANULADO.";
                }

                // En todos los casos, se borra el calendario de pagos
                if (exito)
                {
                    CalendarioPagosFCClienteService.BorrarPorFactura(factura.ID, sesion);
                }

                // Si no se cumple alguna condicion, se lanza la excepcion
                // Caso contrario se elimina el caso de las tablas Comentarios Casos, Comentarios Transiciones, Operaciones, Stock_Movimientos, Facturas y Casos.
                if (exito)
                {
                    var sm = new StockMovimientoService();
                    sm.IniciarUsingSesion(sesion);
                    foreach (var m in sm.GetFiltrado<StockMovimientoService>(new Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = factura.CASO_ID }))
                    {
                        m.IniciarUsingSesion(sesion);
                        m.Borrar();
                        m.FinalizarUsingSesion();
                    }
                    sm.FinalizarUsingSesion();

                    factura.ESTADO = Definiciones.Estado.Inactivo;
                    factura.NRO_COMPROBANTE += "-" + factura.ID;
                    sesion.Db.FACTURAS_CLIENTECollection.Update(factura);
                    LogCambiosService.LogDeRegistro(FacturasClienteService.Nombre_Tabla, factura.ID, valorAnterior, factura.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
                    camposCaso.Add(CasosService.FechaFormulario_NombreCol, factura.FECHA);
                    camposCaso.Add(CasosService.NroComprobante_NombreCol, factura.NRO_COMPROBANTE);
                    camposCaso.Add(CasosService.SucursalId_NombreCol, factura.SUCURSAL_ID);
                    if (!Interprete.EsNullODBNull(factura.NRO_DOCUMENTO_EXTERNO))
                        camposCaso.Add(CasosService.NroComprobante2_NombreCol, factura.NRO_DOCUMENTO_EXTERNO);
                    if (!factura.IsPERSONA_IDNull)
                        camposCaso.Add(CasosService.PersonaId_NombreCol, factura.PERSONA_ID);
                    if (!factura.IsVENDEDOR_IDNull)
                        camposCaso.Add(CasosService.FuncionarioId_NombreCol, factura.VENDEDOR_ID);
                    CasosService.ActualizarCampos(factura.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    //Se borra el caso
                    (new CasosService()).Eliminar(caso_id, sesion);
                }
                else
                {
                    throw new System.ArgumentException(mensaje);
                }

                return exito;
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion Borrar

        #region ActualizarFechaVencimiento
        /// <summary>
        /// Actualizars the fecha vencimiento.
        /// </summary>
        /// <param name="factura_id">The factura_id.</param>
        /// <param name="fechaPago">The fecha pago.</param>
        /// <param name="borrado">if set to <c>true</c> [borrado].</param>
        /// <param name="sinPagos">if set to <c>true</c> [sin pagos].</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarFechaVencimiento(decimal factura_id, DateTime fechaPago, bool borrado, bool sinPagos, SessionService sesion)
        {
            try
            {
                FACTURAS_CLIENTERow row = sesion.Db.FACTURAS_CLIENTECollection.GetByPrimaryKey(factura_id);
                string valorAnterior = row.ToString();

                if (borrado)
                {
                    if (sinPagos)
                    {
                        row.FECHA_VENCIMIENTO = row.FECHA;
                    }
                    else
                    {
                        row.FECHA_VENCIMIENTO = fechaPago;
                    }
                }
                else
                {
                    if (row.FECHA_VENCIMIENTO < fechaPago)
                        row.FECHA_VENCIMIENTO = fechaPago;
                }
                sesion.db.FACTURAS_CLIENTECollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_DUPLICADO:
                        throw new System.ArgumentException("Número de Comprobante Duplicado. Favor Verificar");
                    case Definiciones.OracleNumeroExcepcion.COMPROBANTE_SALTEADO:
                        throw new System.ArgumentException("Número de Comprobante Salteado. Favor Verificar");
                    default: throw exp;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #region Actualizar Costo Total de la factura
        /// <summary>
        /// Actualización del Costo Total de la factura según los artículos incluídos en el detalle.
        /// </summary>
        /// <param name="facturaId">El ID de la factura.</param>
        /// <param name="costoTotal">El costo total se lo incluído en el detalle.</param>
        /// <param name="sesion">La sesión.</param>
        public static void ActualizarCostoTotal(decimal facturaId, decimal costoTotal, SessionService sesion)
        {
            try
            {
                FACTURAS_CLIENTERow fila = sesion.Db.FACTURAS_CLIENTECollection.GetByPrimaryKey(facturaId);
                string valorAnterior = fila.ToString();
                fila.TOTAL_COSTO_NETO = costoTotal;
                sesion.db.FACTURAS_CLIENTECollection.Update(fila);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, fila.ID, valorAnterior, fila.ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Actualizar Costo Total de la factura

        /// <summary>
        /// Actualizars the fecha vencimiento.
        /// </summary>
        /// <param name="factura_id">The factura_id.</param>
        /// <param name="ctacte_caja_sucursal_id">The ctacte_caja_sucursal_id.</param>
        /// <param name="fecha_nueva">The fecha_nueva.</param>
        /// <exception cref="System.Exception">Sólo puede actualizarse la fecha a facturas contado</exception>
        public static void ActualizarFechaVencimiento(decimal factura_id, decimal ctacte_caja_sucursal_id, DateTime fecha_nueva)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    FACTURAS_CLIENTERow row = sesion.db.FACTURAS_CLIENTECollection.GetByPrimaryKey(factura_id);
                    string valorAnterior = row.ToString();

                    //Validar que la factura es contado
                    if (!FacturasClienteService.GetTipoFactura(row.CASO_ID).Equals(Definiciones.TipoFactura.Contado))
                        throw new Exception("Sólo puede actualizarse la fecha a facturas contado");

                    #region Actualizar cabecera de factura
                    row.FECHA = fecha_nueva;
                    row.FECHA_VENCIMIENTO = fecha_nueva;
                    sesion.db.FACTURAS_CLIENTECollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    #endregion Actualizar cabecera de factura

                    #region Actualizar calendario pagos
                    DataTable dtCalendario = CalendarioPagosFCClienteService.GetCalendarioPagosDataTable(CalendarioPagosFCClienteService.FacturaClienteId_NombreCol + " = " + factura_id, string.Empty);
                    for (int i = 0; i < dtCalendario.Rows.Count; i++)
                    {
                        CalendarioPagosFCClienteService.ModificarVencimiento((decimal)dtCalendario.Rows[i][CalendarioPagosFCClienteService.Id_NombreCol], fecha_nueva, sesion);
                    }
                    #endregion Actualizar calendario pagos

                    #region Actualizar cuenta corriente
                    DataTable dtCtacte = CuentaCorrientePersonasService.GetCuentaCorrientePersonasDataTable(CuentaCorrientePersonasService.CasoId_NombreCol + " = " + row.CASO_ID, string.Empty, sesion);
                    for (int i = 0; i < dtCtacte.Rows.Count; i++)
                    {
                        CuentaCorrientePersonasService.ActualizarFechaVencimientoYMonto((decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Id_NombreCol], fecha_nueva, (decimal)dtCtacte.Rows[i][CuentaCorrientePersonasService.Credito_NombreCol], false, sesion);
                    }
                    #endregion Actualizar cuenta corriente

                    #region Actualizar pagos en caja
                    //Obtener los pagos de persona que involucran a la FC
                    DataTable dtPagosPersonaDocumentos = CuentaCorrientePagosPersonaDocumentoService.GetCuentaCorrientePagosPersonaDocumentoInfoCompleta(CuentaCorrientePagosPersonaDocumentoService.VistaCasoId_NombreCol + " = " + row.CASO_ID, string.Empty, sesion);
                    string strAux = "-1";
                    for (int i = 0; i < dtPagosPersonaDocumentos.Rows.Count; i++)
                    {
                        strAux += ", " + dtPagosPersonaDocumentos.Rows[i][CuentaCorrientePagosPersonaDocumentoService.CtactePagosPersonaId_NombreCol];
                    }

                    if (dtPagosPersonaDocumentos.Rows.Count > 0 && !ctacte_caja_sucursal_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        for (int i = 0; i < dtPagosPersonaDocumentos.Rows.Count; i++)
                        {
                            DataTable dtCtacteCaja = CuentaCorrienteCajaService.GetCtacteCajaDataTable2(CuentaCorrienteCajaService.CtactePagoPersonaId_NombreCol + " in (" + strAux + ")", string.Empty);

                            for (int j = 0; j < dtCtacteCaja.Rows.Count; j++)
                            {
                                CuentaCorrienteCajaService.ActualizarMovimiento((decimal)dtCtacteCaja.Rows[j][CuentaCorrienteCajaService.Id_NombreCol], ctacte_caja_sucursal_id, fecha_nueva, sesion);
                            }
                        }
                    }
                    #endregion Actualizar pagos en caja

                    #region Actualizar fecha de asiento contable
                    CBA.FlowV2.Services.Contabilidad.AsientosService.ModificarFechaPorCaso(row.CASO_ID, fecha_nueva, sesion);
                    #endregion Actualizar fecha de asiento contable

                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion ActualizarFechaVencimiento

        #region CargarTablaFactClienteDetImpresion
        public static void CargarFactClienteDetImpresion(decimal casoId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string procedimientoAlamacenado = "trc.cargar_fact_cliente_det_imp";

                    OracleCommand cmd = new OracleCommand(procedimientoAlamacenado, sesion.db.Connection as OracleConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CASOID", OracleDbType.Decimal));
                    cmd.Parameters["CASOID"].Direction = ParameterDirection.Input;

                    cmd.Parameters["CASOID"].Value = casoId;

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion CargarTablaFactClienteDetImpresion

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "FACTURAS_CLIENTE"; }
        }

        public static string Nombre_Vista
        {
            get { return "FACTURAS_CLIENTE_INFO_COMPLETA"; }
        }

        public static string AfectaCtacte_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.AFECTA_CTACTEColumnName; }
        }
        public static string AfectaLineaCredito_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.AFECTA_LINEA_CREDITOColumnName; }
        }
        public static string AfectaStock_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.AFECTA_STOCKColumnName; }
        }
        public static string CondicionPagoId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.CONDICION_PAGO_IDColumnName; }
        }
        public static string CondicionDescripcion_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.CONDICION_DESCRIPCIONColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.AUTONUMERACION_IDColumnName; }
        }

        public static string AutonumeracionTransferenciaId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.AUTONUMERACION_TRANSF_IDColumnName; }
        }
        public static string CanalVentaId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.CANAL_VENTA_IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.CASO_IDColumnName; }
        }

        public static string ComisionPorVenta_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.COMISION_POR_VENTAColumnName; }
        }
        public static string CotizacionDestino_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.COTIZACION_DESTINOColumnName; }
        }

        public static string ControlarCantidadMinimaDescuentoMaximo_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.CONTROLAR_CANT_MIN_DESC_MAXColumnName; }
        }

        public static string DepositoDestinoId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.DEPOSITO_DESTINO_IDColumnName; }
        }

        public static string DepositoId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.DEPOSITO_IDColumnName; }
        }
        public static string DescuentoMaxAutorizado_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.DESCUENTO_MAX_AUTORIZADOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.ESTADOColumnName; }
        }
        public static string FechaAutorizacionDescuento_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.FECHA_AUTORIZACION_DESCUENTOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.FECHAColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string FechaVencimientoTimbradoFactProveedor_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.FECHA_VENC_TIMBRADO_FACT_PROColumnName; }
        }
        public static string GenerarTransferencia_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.GENERAR_TRANSFERENCIAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.IDColumnName; }
        }
        public static string Impreso_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.IMPRESOColumnName; }
        }
        public static string ListaPrecioId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.LISTA_PRECIO_IDColumnName; }
        }

        public static string MonedaDestinoId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.MONEDA_DESTINO_IDColumnName; }
        }

        public static string MontoAfectaLineaCredito_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.MONTO_AFECTA_LINEA_CREDITOColumnName; }
        }

        public static string MoraDiasGracia_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.MORA_DIAS_GRACIAColumnName; }
        }

        public static string MoraPorcentaje_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.MORA_PORCENTAJEColumnName; }
        }

        public static string NroComprobante_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.NRO_COMPROBANTEColumnName; }
        }

        public static string NroDocumentoExterno_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.NRO_DOCUMENTO_EXTERNOColumnName; }
        }

        public static string NroComprobanteSecuencia_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.NRO_COMPROBANTE_SECUENCIAColumnName; }
        }

        public static string NroComprobanteFactProveedor_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.NRO_COMPROBANTE_FACT_PROColumnName; }
        }

        public static string NroTimbradoFactProveedor_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.NRO_TIMBRADO_FACT_PROColumnName; }
        }

        public static string Observacion_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.OBSERVACIONColumnName; }
        }

        public static string CasoOrigenId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.CASO_ORIGEN_IDColumnName; }
        }

        public static string PersonaId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.PERSONA_IDColumnName; }
        }

        public static string PersonaGarante1Id_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.PERSONA_GARANTE_1_IDColumnName; }
        }

        public static string PersonaGarante2Id_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.PERSONA_GARANTE_2_IDColumnName; }
        }

        public static string PersonaGarante3Id_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.PERSONA_GARANTE_3_IDColumnName; }
        }

        public static string SucursalId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.SUCURSAL_IDColumnName; }
        }

        public static string TipoFacturaId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TIPO_FACTURA_IDColumnName; }
        }

        public static string TotalComisionVendedor_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TOTAL_COMISION_VENDEDORColumnName; }
        }

        public static string TotalCostoBruto_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TOTAL_COSTO_BRUTOColumnName; }
        }

        public static string TotalCostoNeto_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TOTAL_COSTO_NETOColumnName; }
        }

        public static string TotalMontoBruto_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TOTAL_MONTO_BRUTOColumnName; }
        }

        public static string TotalEntregaInicial_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TOTAL_ENTREGA_INICIALColumnName; }
        }

        public static string TotalMontoDto_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TOTAL_MONTO_DTOColumnName; }
        }

        public static string TotalMontoImpuesto_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TOTAL_MONTO_IMPUESTOColumnName; }
        }

        public static string TotalNeto_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TOTAL_NETOColumnName; }
        }
        public static string TotalRecargoFinanciero_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.TOTAL_RECARGO_FINANCIEROColumnName; }
        }
        public static string UsuarioIdAutorizaDescuento_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.USUARIO_ID_AUTORIZA_DESCUENTOColumnName; }
        }
        public static string VendedorId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.VENDEDOR_IDColumnName; }
        }
        public static string PorcentajeDescSobreTotal_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.PORCENTAJE_DESC_SOBRE_TOTALColumnName; }
        }
        public static string AConsignacion_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.A_CONSIGNACIONColumnName; }
        }

        public static string Direccion_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.DIRECCIONColumnName; }
        }

        public static string Latitud_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.LATITUDColumnName; }
        }
        public static string Longitud_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.LONGITUDColumnName; }
        }

        public static string EsRapida_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.ES_RAPIDAColumnName; }
        }

        public static string ObservacionEntrega_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.OBSERVACION_ENTREGAColumnName; }
        }
        public static string SucursalVentaId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.SUCURSAL_VENTA_IDColumnName; }
        }
        public static string CtaCteCajaSucursalId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }


        #endregion Tabla

        #region Vista
        public static string VistaAutonumeracionesCodigo_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.AUTONUMERACIONES_CODIGOColumnName; }
        }
        public static string VistaAutonumeracionTimbrado_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.AUTONUMERACION_TIMBRADOColumnName; }
        }
        public static string VistaCasoEstadoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.CASO_ESTADO_IDColumnName; }
        }

        public static string VistaCasoRepartoVinculaFC_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.CASO_REPARTO_VINCULA_FCColumnName; }
        }

        public static string VistaCondicionPagoDescripcion_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.CONDICION_DESCRIPCIONColumnName; }
        }

        public static string VistaCondicionPagoNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.CONDICION_PAGO_NOMBREColumnName; }
        }

        public static string VistaDepositoAbreviatura_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.DEPOSITO_ABREVIATURAColumnName; }
        }

        public static string VistaDepositoNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.DEPOSITO_NOMBREColumnName; }
        }

        public static string VistaEntidadId_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }

        public static string VistaCasoEstado_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.CASO_ESTADOColumnName; }
        }      

        public static string VistaMonedaNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaPersonaBarrioCobranzaNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_BARRIO_COBRANZA_NOMBREColumnName; }
        }

        public static string VistaPersonaBarrio1Nombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_BARRIO1_NOMBREColumnName; }
        }

        public static string VistaPersonaBarrio2Nombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_BARRIO2_NOMBREColumnName; }
        }

        public static string VistaPersonaCalleCobranza_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_CALLE_COBRANZAColumnName; }
        }

        public static string VistaPersonaCalle1_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_CALLE1ColumnName; }
        }

        public static string VistaPersonaCalle2_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_CALLE2ColumnName; }
        }

        public static string VistaPersonaCiudadCobranzaNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_CIUDAD_COBRANZA_NOMBREColumnName; }
        }

        public static string VistaPersonaCiudad1Nombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_CIUDAD1_NOMBREColumnName; }
        }

        public static string VistaPersonaCiudad2Nombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_CIUDAD2_NOMBREColumnName; }
        }

        public static string VistaPersonaDepartamento1Nombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_DEPARTAMENTO1_NOMBREColumnName; }
        }

        public static string VistaPersonaDepartamento2Nombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_DEPARTAMENTO2_NOMBREColumnName; }
        }

        public static string VistaDepartamentoCobranzaNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_DEPTO_COBRANZA_NOMBREColumnName; }
        }

        public static string VistaPersonaNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }

        public static string VistaPersonaCodigo_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_CODIGOColumnName; }
        }

        public static string VistaPersonaPaisResidenciaNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.PERSONA_PAIS_RESIDENCIA_NOMBREColumnName; }
        }

        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }

        public static string VistaSucursalNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }

        public static string VistaUsuarioAutorizaDescuentoNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.USUARIO_AUTORIZA_DTO_NOMBREColumnName; }
        }

        public static string VistaVendedorNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.VENDEDOR_NOMBREColumnName; }
        }

        public static string VistaCasoId_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.CASO_IDColumnName; }
        }

        public static string VistaFecha_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.FECHAColumnName; }
        }

        public static string VistaNroComprobante_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.NRO_COMPROBANTEColumnName; }
        }

        public static string VistaTotalMontoNeto_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.TOTAL_NETOColumnName; }
        }

        public static string VistaCasoOrigen_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.CASO_ORIGEN_IDColumnName; }
        }

        public static string VistaMonedaId_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.MONEDA_DESTINO_IDColumnName; }
        }
        public static string VistaTipoCondicionPago_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.TIPO_CONDICION_PAGOColumnName; }
        }
        public static string VistaSucursalVentaId_NombreCol
        {
            get { return FACTURAS_CLIENTECollection.SUCURSAL_VENTA_IDColumnName; }
        }
        public static string VistaSucursalVentaNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.SUCURSAL_VENTA_NOMBREColumnName; }
        }
        public static string VistaSucursalVentaAbreviatura_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.SUCURSAL_VENTA_ABREVIATURAColumnName; }
        }
        public static string VistaTipoClienteNombre_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.TIPO_CLIENTES_NOMBREColumnName; }
        }
        public static string VistaTipoClienteId_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.TIPO_CLIENTE_IDColumnName; }
        }
        public static string VistaDepositoDestino_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.DEPOSITO_DESTINO_NOMBREColumnName; }
        }
        public static string VistaSucursalDestino_NombreCol
        {
            get { return FACTURAS_CLIENTE_INFO_COMPLETACollection.SUCURSAL_DESTINO_NOMBREColumnName; }
        }

        #endregion Vista
        #endregion Accessors

        #region Triggers
        // Se usa una clase que herada de trigger con el fin de tener consistencia en la nomenclatura
        // son siempre privadas para evitar que se usen fuera de este service
        private static TriggerFacturaCliente trigger = new TriggerFacturaCliente();
        private class TriggerFacturaCliente : TriggerBase<FACTURAS_CLIENTERow>
        {
            public override void BeforeInsert(ref FACTURAS_CLIENTERow fila_nueva, SessionService sesion) { }

            public override void AfterInsert(FACTURAS_CLIENTERow fila_nueva, SessionService sesion) { }

            public override void BeforeUpdate(ref FACTURAS_CLIENTERow fila_nueva, FACTURAS_CLIENTERow fila_vieja, SessionService sesion)
            {
                if (!fila_nueva.FECHA.Date.Equals(fila_vieja.FECHA.Date))
                {
                    AlCambiarFecha(ref fila_nueva, fila_vieja, sesion);
                }

                return;

            }

            public override void AfterUpdate(FACTURAS_CLIENTERow fila_nueva, FACTURAS_CLIENTERow fila_vieja, SessionService sesion) { }

            #region Triggers Before
            private void AlCambiarFecha(ref FACTURAS_CLIENTERow filaNueva, FACTURAS_CLIENTERow filaVieja, SessionService sesion)
            {
                string valorAnterior = String.Empty;
                string clausulas;
                try
                {
                    clausulas = CalendarioPagosFCClienteService.FacturaClienteId_NombreCol + " = " + filaNueva.ID + " and " +
                                CalendarioPagosFCClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                    CALENDARIO_PAGOS_FC_CLIENTERow[] calendarios = sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetAsArray(clausulas, CalendarioPagosFCClienteService.NumeroCuota_NombreCol);
                    foreach (CALENDARIO_PAGOS_FC_CLIENTERow calendario in calendarios)
                    {
                        valorAnterior = calendario.ToString();
                        calendario.FECHA_VENCIMIENTO = calendario.FECHA_VENCIMIENTO.Date + (filaNueva.FECHA.Date - filaVieja.FECHA.Date);
                        LogCambiosService.LogDeRegistro(CalendarioPagosFCClienteService.Nombre_Tabla, calendario.ID, valorAnterior, calendario.ToString(), sesion);
                        sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.Update(calendario);
                        valorAnterior = String.Empty;

                        CuentaCorrientePersonasService.ActualizarFechaVencimientoPorCalendarioFC(calendario.ID, calendario.FECHA_VENCIMIENTO, sesion);
                    }

                    int nFilas = -1;

                    CALENDARIO_PAGOS_FC_CLIENTERow[] resultado =
                        sesion.db.CALENDARIO_PAGOS_FC_CLIENTECollection.GetAsArray(clausulas,
                        CalendarioPagosFCClienteService.FechaVencimiento_NombreCol + " DESC",
                        0, 1, ref nFilas);
                    if (nFilas > 1 && resultado.Length < 1) throw new Exception("La factura no tiene ningun calendario de pagos asociado");

                    if (resultado.Length > 0)
                        filaNueva.FECHA_VENCIMIENTO = resultado[0].FECHA_VENCIMIENTO;
                    else
                        filaNueva.FECHA_VENCIMIENTO = filaNueva.FECHA;
                }
                catch (Exception e)
                {
                    throw e;
                }
                return;
            }
            #endregion Trigger Before
            #region Triggers After

            #endregion Triggers After


        }

        #endregion Triggers

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static FacturasClienteService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new FacturasClienteService(e.RegistroId, sesion);
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
        protected FACTURAS_CLIENTERow row;
        protected FACTURAS_CLIENTERow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string AConsignacion { get { return GetStringHelper(row.A_CONSIGNACION); } set { row.A_CONSIGNACION = value; } }
        public string AfectaCtacte { get { return GetStringHelper(row.AFECTA_CTACTE); } set { row.AFECTA_CTACTE = value; } }
        public string AfectaLineaCredito { get { return GetStringHelper(row.AFECTA_LINEA_CREDITO); } set { row.AFECTA_LINEA_CREDITO = value; } }
        public string AfectaStock { get { return GetStringHelper(row.AFECTA_STOCK); } set { row.AFECTA_STOCK = value; } }
        public decimal? AutonumeracionId { get { if (row.IsAUTONUMERACION_IDNull) return null; else return row.AUTONUMERACION_ID; } set { if (value.HasValue) row.AUTONUMERACION_ID = value.Value; else row.IsAUTONUMERACION_IDNull = true; } }
        public decimal? AutonumeracionTransfId { get { if (row.IsAUTONUMERACION_TRANSF_IDNull) return null; else return row.AUTONUMERACION_TRANSF_ID; } set { if (value.HasValue) row.AUTONUMERACION_TRANSF_ID = value.Value; else row.IsAUTONUMERACION_TRANSF_IDNull = true; } }
        public decimal? CanalVentaId { get { if (row.IsCANAL_VENTA_IDNull) return null; else return row.CANAL_VENTA_ID; } set { if (value.HasValue) row.CANAL_VENTA_ID = value.Value; else row.IsCANAL_VENTA_IDNull = true; } }
        public decimal? CasoOrigenId { get { if (row.IsCASO_ORIGEN_IDNull) return null; else return row.CASO_ORIGEN_ID; } set { if (value.HasValue) row.CASO_ORIGEN_ID = value.Value; else row.IsCASO_ORIGEN_IDNull = true; } }
        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public string ComisionPorVenta { get { return GetStringHelper(row.COMISION_POR_VENTA); } set { row.COMISION_POR_VENTA = value; } }
        public string CondicionDescripcion { get { return GetStringHelper(row.CONDICION_DESCRIPCION); } set { row.CONDICION_DESCRIPCION = value; } }
        public decimal? CondicionPagoId { get { if (row.IsCONDICION_PAGO_IDNull) return null; else return row.CONDICION_PAGO_ID; } set { if (value.HasValue) row.CONDICION_PAGO_ID = value.Value; else row.IsCONDICION_PAGO_IDNull = true; } }
        public string ControlarCantMinDescMax { get { return GetStringHelper(row.CONTROLAR_CANT_MIN_DESC_MAX); } set { row.CONTROLAR_CANT_MIN_DESC_MAX = value; } }
        public decimal? CotizacionDestino { get { if (row.IsCOTIZACION_DESTINONull) return null; else return row.COTIZACION_DESTINO; } set { if (value.HasValue) row.COTIZACION_DESTINO = value.Value; else row.IsCOTIZACION_DESTINONull = true; } }
        public decimal? CtacteCajaSucursalId { get { if (row.IsCTACTE_CAJA_SUCURSAL_IDNull) return null; else return row.CTACTE_CAJA_SUCURSAL_ID; } set { if (value.HasValue) row.CTACTE_CAJA_SUCURSAL_ID = value.Value; else row.IsCTACTE_CAJA_SUCURSAL_IDNull = true; } }
        public decimal? DepositoDestionId { get { if (row.IsDEPOSITO_DESTINO_IDNull) return null; else return row.DEPOSITO_DESTINO_ID; } set { if (value.HasValue) row.DEPOSITO_DESTINO_ID = value.Value; else row.IsDEPOSITO_DESTINO_IDNull = true; } }
        public decimal? DepositoId { get { if (row.IsDEPOSITO_IDNull) return null; else return row.DEPOSITO_ID; } set { if (value.HasValue) row.DEPOSITO_ID = value.Value; else row.IsDEPOSITO_IDNull = true; } }
        public decimal? DescuentoMaxAutorizado { get { if (row.IsDESCUENTO_MAX_AUTORIZADONull) return null; else return row.DESCUENTO_MAX_AUTORIZADO; } set { if (value.HasValue) row.DESCUENTO_MAX_AUTORIZADO = value.Value; else row.IsDESCUENTO_MAX_AUTORIZADONull = true; } }
        public string Direccion { get { return GetStringHelper(row.DIRECCION); } set { row.DIRECCION = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public DateTime? Fecha { get { if (row.IsFECHANull ) return null; else return row.FECHA; } set { if (value.HasValue) row.FECHA = value.Value; else row.IsFECHANull = true; } }
        public DateTime? FechaAutorizacionDescuento { get { if (row.IsFECHA_AUTORIZACION_DESCUENTONull ) return null; else return row.FECHA_AUTORIZACION_DESCUENTO; } set { if (value.HasValue) row.FECHA_AUTORIZACION_DESCUENTO = value.Value; else row.IsFECHA_AUTORIZACION_DESCUENTONull = true; } }
        public DateTime? FechaVencTimbradoFactPro { get { if (row.IsFECHA_VENC_TIMBRADO_FACT_PRONull ) return null; else return row.FECHA_VENC_TIMBRADO_FACT_PRO; } set { if (value.HasValue) row.FECHA_VENC_TIMBRADO_FACT_PRO = value.Value; else row.IsFECHA_VENC_TIMBRADO_FACT_PRONull = true; } }
        public DateTime FechaVencimiento { get { return row.FECHA_VENCIMIENTO; } set { row.FECHA_VENCIMIENTO = value; } }
        public string GenerarTransferencia { get { return GetStringHelper(row.GENERAR_TRANSFERENCIA); } set { row.GENERAR_TRANSFERENCIA = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Impreso { get { return GetStringHelper(row.IMPRESO); } set { row.IMPRESO = value; } }
        public decimal? Latitud { get { if (row.IsLATITUDNull) return null; else return row.LATITUD; } set { if (value.HasValue) row.LATITUD = value.Value; else row.IsLATITUDNull = true; } }
        public decimal? ListaPrecioId { get { if (row.IsLISTA_PRECIO_IDNull) return null; else return row.LISTA_PRECIO_ID; } set { if (value.HasValue) row.LISTA_PRECIO_ID = value.Value; else row.IsLISTA_PRECIO_IDNull = true; } }
        public decimal? Longitud { get { if (row.IsLONGITUDNull) return null; else return row.LONGITUD; } set { if (value.HasValue) row.LONGITUD = value.Value; else row.IsLONGITUDNull = true; } }
        public decimal? MonedaDestinoId { get { if (row.IsMONEDA_DESTINO_IDNull) return null; else return row.MONEDA_DESTINO_ID; } set { if (value.HasValue) row.MONEDA_DESTINO_ID = value.Value; else row.IsMONEDA_DESTINO_IDNull = true; } }
        public decimal? MontoAfectaLineaCredito { get { if (row.IsMONTO_AFECTA_LINEA_CREDITONull) return null; else return row.MONTO_AFECTA_LINEA_CREDITO; } set { if (value.HasValue) row.MONTO_AFECTA_LINEA_CREDITO = value.Value; else row.IsMONTO_AFECTA_LINEA_CREDITONull = true; } }
        public decimal MoraDiasGracia { get { return row.MORA_DIAS_GRACIA; } set { row.MORA_DIAS_GRACIA = value; } }
        public decimal MoraPorcentaje { get { return row.MORA_PORCENTAJE; } set { row.MORA_PORCENTAJE = value; } }
        public string NroComprobante { get { return GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string NroComprobanteFactPro { get { return GetStringHelper(row.NRO_COMPROBANTE_FACT_PRO); } set { row.NRO_COMPROBANTE_FACT_PRO = value; } }
        public decimal? NroComprobanteSecuencia { get { if (row.IsNRO_COMPROBANTE_SECUENCIANull) return null; else return row.NRO_COMPROBANTE_SECUENCIA; } set { if (value.HasValue) row.NRO_COMPROBANTE_SECUENCIA = value.Value; else row.IsNRO_COMPROBANTE_SECUENCIANull = true; } }
        public string NroDocumentoExterno { get { return GetStringHelper(row.NRO_DOCUMENTO_EXTERNO); } set { row.NRO_DOCUMENTO_EXTERNO = value; } }
        public string NroTimbradoFactPro { get { return GetStringHelper(row.NRO_TIMBRADO_FACT_PRO); } set { row.NRO_TIMBRADO_FACT_PRO = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public string ObservacionEntrega { get { return GetStringHelper(row.OBSERVACION_ENTREGA); } set { row.OBSERVACION_ENTREGA = value; } }
        public decimal? PersonaGarante1Id { get { if (row.IsPERSONA_GARANTE_1_IDNull) return null; else return row.PERSONA_GARANTE_1_ID; } set { if (value.HasValue) row.PERSONA_GARANTE_1_ID = value.Value; else row.IsPERSONA_GARANTE_1_IDNull = true; } }
        public decimal? PersonaGarante2Id { get { if (row.IsPERSONA_GARANTE_2_IDNull) return null; else return row.PERSONA_GARANTE_2_ID; } set { if (value.HasValue) row.PERSONA_GARANTE_2_ID = value.Value; else row.IsPERSONA_GARANTE_2_IDNull = true; } }
        public decimal? PersonaGarante3Id { get { if (row.IsPERSONA_GARANTE_3_IDNull) return null; else return row.PERSONA_GARANTE_3_ID; } set { if (value.HasValue) row.PERSONA_GARANTE_3_ID = value.Value; else row.IsPERSONA_GARANTE_3_IDNull = true; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public decimal? PorcentajeDescSobreTotal { get { if (row.IsPORCENTAJE_DESC_SOBRE_TOTALNull) return null; else return row.PORCENTAJE_DESC_SOBRE_TOTAL; } set { if (value.HasValue) row.PORCENTAJE_DESC_SOBRE_TOTAL = value.Value; else row.IsPORCENTAJE_DESC_SOBRE_TOTALNull = true; } }
        public decimal? SucursalId { get { if (row.IsSUCURSAL_IDNull) return null; else return row.SUCURSAL_ID; } set { if (value.HasValue) row.SUCURSAL_ID = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        public decimal? SucursalVentaId { get { if (row.IsSUCURSAL_VENTA_IDNull) return null; else return row.SUCURSAL_VENTA_ID; } set { if (value.HasValue) row.SUCURSAL_VENTA_ID = value.Value; else row.IsSUCURSAL_VENTA_IDNull = true; } }
        public string TipoFacturaId { get { return GetStringHelper(row.TIPO_FACTURA_ID); } set { row.TIPO_FACTURA_ID = value; } }
        public decimal? TotalComision { get { if (row.IsTOTAL_COMISION_VENDEDORNull) return null; else return row.TOTAL_COMISION_VENDEDOR; } set { if (value.HasValue) row.TOTAL_COMISION_VENDEDOR = value.Value; else row.IsTOTAL_COMISION_VENDEDORNull = true; } }
        public decimal? TotalCostoBruto { get { if (row.IsTOTAL_COSTO_BRUTONull) return null; else return row.TOTAL_COSTO_BRUTO; } set { if (value.HasValue) row.TOTAL_COSTO_BRUTO = value.Value; else row.IsTOTAL_COSTO_BRUTONull = true; } }
        public decimal? TotalCostoNeto { get { if (row.IsTOTAL_COSTO_NETONull) return null; else return row.TOTAL_COSTO_NETO; } set { if (value.HasValue) row.TOTAL_COSTO_NETO = value.Value; else row.IsTOTAL_COSTO_NETONull = true; } }
        public decimal TotalEntregaInicial { get { return row.TOTAL_ENTREGA_INICIAL; } set { row.TOTAL_ENTREGA_INICIAL = value; } }
        public decimal? TotalMontoBruto { get { if (row.IsTOTAL_MONTO_BRUTONull) return null; else return row.TOTAL_MONTO_BRUTO; } set { if (value.HasValue) row.TOTAL_MONTO_BRUTO = value.Value; else row.IsTOTAL_MONTO_BRUTONull = true; } }
        public decimal? TotalMontoDto { get { if (row.IsTOTAL_MONTO_DTONull) return null; else return row.TOTAL_MONTO_DTO; } set { if (value.HasValue) row.TOTAL_MONTO_DTO = value.Value; else row.IsTOTAL_MONTO_DTONull = true; } }
        public decimal? TotalMontoImpuesto { get { if (row.IsTOTAL_MONTO_IMPUESTONull) return null; else return row.TOTAL_MONTO_IMPUESTO; } set { if (value.HasValue) row.TOTAL_MONTO_IMPUESTO = value.Value; else row.IsTOTAL_MONTO_IMPUESTONull = true; } }
        public decimal? TotalNeto { get { if (row.IsTOTAL_NETONull) return null; else return row.TOTAL_NETO; } set { if (value.HasValue) row.TOTAL_NETO = value.Value; else row.IsTOTAL_NETONull = true; } }
        public decimal TotalRecargoFinanciero { get { return row.TOTAL_RECARGO_FINANCIERO; } set { row.TOTAL_RECARGO_FINANCIERO = value; } }
        public decimal? UsuarioIdAutorizaDescuento { get { if (row.IsUSUARIO_ID_AUTORIZA_DESCUENTONull) return null; else return row.USUARIO_ID_AUTORIZA_DESCUENTO; } set { if (value.HasValue) row.USUARIO_ID_AUTORIZA_DESCUENTO = value.Value; else row.IsUSUARIO_ID_AUTORIZA_DESCUENTONull = true; } }
        public decimal? VendedorId { get { if (row.IsVENDEDOR_IDNull) return null; else return row.VENDEDOR_ID; } set { if (value.HasValue) row.VENDEDOR_ID = value.Value; else row.IsVENDEDOR_IDNull = true; } }
        #endregion Propiedades

        #region Propiedades Extendidas
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
                    if (this.sesion != null)
                        this._caso = new CasosService(this.CasoId, this.sesion);
                    else
                        this._caso = new CasosService(this.CasoId);
                }
                return this._caso;
            }
        }

        private CasosService _caso_origen;
        public CasosService CasoOrigen
        {
            get
            {
                if (this._caso_origen == null)
                {
                    if (this.sesion != null)
                        this._caso_origen = new CasosService(this.CasoOrigenId.Value, this.sesion);
                    else
                        this._caso_origen = new CasosService(this.CasoOrigenId.Value);
                }
                return this._caso_origen;
            }
        }

        private CondicionesPagoService _condicion_pago;
        public CondicionesPagoService CondicionPago
        {
            get
            {
                if (this._condicion_pago == null)
                {
                    if (this.sesion != null)
                        this._condicion_pago = new CondicionesPagoService(this.CondicionPagoId.Value, this.sesion);
                    else
                        this._condicion_pago = new CondicionesPagoService(this.CondicionPagoId.Value);
                }
                return this._condicion_pago;
            }
        }

        private StockDepositosService _deposito;
        public StockDepositosService Deposito
        {
            get
            {
                if (this._deposito == null)
                {
                    if (this.sesion != null)
                        this._deposito = new StockDepositosService(this.DepositoId.Value, this.sesion);
                    else
                        this._deposito = new StockDepositosService(this.DepositoId.Value);
                }
                return this._deposito;
            }
        }

        private MonedasService _moneda_destino;
        public MonedasService MonedaDestino
        {
            get
            {
                if (this._moneda_destino == null)
                {
                    if (this.sesion != null)
                        this._moneda_destino = new MonedasService(this.MonedaDestinoId.Value, this.sesion);
                    else
                        this._moneda_destino = new MonedasService(this.MonedaDestinoId.Value);
                }
                return this._moneda_destino;
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
                        this._persona = new PersonasService(this.PersonaId.Value, this.sesion);
                    else
                        this._persona = new PersonasService(this.PersonaId.Value);
                }
                return this._persona;
            }
        }

        private PersonasService _persona_garante_1;
        public PersonasService PersonaGarante1
        {
            get
            {
                if (this._persona_garante_1 == null)
                {
                    if (this.sesion != null)
                        this._persona_garante_1 = new PersonasService(this.PersonaGarante1Id.Value, this.sesion);
                    else
                        this._persona_garante_1 = new PersonasService(this.PersonaGarante1Id.Value);
                }
                return this._persona_garante_1;
            }
        }

        private PersonasService _persona_garante_2;
        public PersonasService PersonaGarante2
        {
            get
            {
                if (this._persona_garante_2 == null)
                {
                    if (this.sesion != null)
                        this._persona_garante_2 = new PersonasService(this.PersonaGarante2Id.Value, this.sesion);
                    else
                        this._persona_garante_2 = new PersonasService(this.PersonaGarante2Id.Value);
                }
                return this._persona_garante_2;
            }
        }

        private PersonasService _persona_garante_3;
        public PersonasService PersonaGarante3
        {
            get
            {
                if (this._persona_garante_3 == null)
                {
                    if (this.sesion != null)
                        this._persona_garante_3 = new PersonasService(this.PersonaGarante3Id.Value, this.sesion);
                    else
                        this._persona_garante_3 = new PersonasService(this.PersonaGarante3Id.Value);
                }
                return this._persona_garante_3;
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
                        this._sucursal = new SucursalesService(this.SucursalId.Value, this.sesion);
                    else
                        this._sucursal = new SucursalesService(this.SucursalId.Value);
                }
                return this._sucursal;
            }
        }

        private FuncionariosService _vendedor;
        public FuncionariosService Vendedor
        {
            get
            {
                if (this._vendedor == null)
                {
                    if (this.sesion != null)
                        this._vendedor = new FuncionariosService(this.VendedorId.Value, this.sesion);
                    else
                        this._vendedor = new FuncionariosService(this.VendedorId.Value);
                }
                return this._vendedor;
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private FacturasClienteDetalleService[] _factura_cliente_detalles;
        public FacturasClienteDetalleService[] FacturaClienteDetalles
        {
            get
            {
                if (this._factura_cliente_detalles == null)
                    this._factura_cliente_detalles = FacturasClienteDetalleService.GetPorCabecera(this.Id.Value);
                return this._factura_cliente_detalles;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.FACTURAS_CLIENTECollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new FACTURAS_CLIENTERow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(FACTURAS_CLIENTERow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public FacturasClienteService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public FacturasClienteService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public FacturasClienteService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }

        public FacturasClienteService(EdiCBA.FacturaCliente edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = FacturasClienteService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.CasoId = edi.caso_id;
            
            #region condicion pago
            if (!string.IsNullOrEmpty(edi.condicion_pago_uuid))
                this._condicion_pago = CondicionesPagoService.GetPorUUID(edi.condicion_pago_uuid, sesion);
            if (this._condicion_pago == null && edi.condicion_pago != null)
                this._condicion_pago = new CondicionesPagoService(edi.condicion_pago, almacenar_localmente, sesion);
            if (this._condicion_pago == null)
                throw new Exception("No se encontró el UUID " + edi.condicion_pago_uuid + " ni se definieron los datos del objeto.");
            
            if(!this.CondicionPago.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.CondicionPago.Id.HasValue)
                this.CondicionPagoId = this.CondicionPago.Id.Value;
            #endregion condicion pago
            
            this.CondicionDescripcion = this.CondicionPago.TipoCondicionPago;

            if(edi.cotizacion == null)
                throw new Exception("El EDI debe contener el objeto 'cotizacion'.");
            this.CotizacionDestino = edi.cotizacion.compra;
            
            #region deposito
            if (!string.IsNullOrEmpty(edi.deposito_uuid))
                this._deposito = StockDepositosService.GetPorUUID(edi.deposito_uuid, sesion);
            if (this._deposito == null && edi.deposito != null)
                this._deposito = new StockDepositosService(edi.deposito, almacenar_localmente, sesion);
            if (this._deposito == null)
                throw new Exception("No se encontró el UUID " + edi.deposito_uuid + " ni se definieron los datos del objeto.");

            if (!this.Deposito.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Deposito.Id.HasValue)
                this.DepositoId = this.Deposito.Id.Value;
            #endregion deposito

            this.Estado = Definiciones.Estado.Activo;
            this.Fecha = edi.fecha;
            this.FechaVencimiento = edi.fecha_vencimiento;
            
            #region moneda
            if (!string.IsNullOrEmpty(edi.moneda_uuid))
                this._moneda_destino = MonedasService.GetPorUUID(edi.moneda_uuid, sesion);
           
            if (this._moneda_destino == null)
                throw new Exception("No se encontró el UUID " + edi.moneda_uuid + " ni se definieron los datos del objeto.");

            if (!this.MonedaDestino.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.MonedaDestino.Id.HasValue)
                this.MonedaDestinoId = this.MonedaDestino.Id.Value;
            #endregion moneda
            
            this.MontoAfectaLineaCredito = edi.total_neto;
            this.NroComprobante = edi.nro_comprobante;
            this.NroComprobanteSecuencia = edi.nro_comprobante_numerico;
            this.NroDocumentoExterno = edi.nro_comprobante_externo;
            this.Observacion = edi.observacion;
            
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

            //todo: falta implementar persona garante 1, 2 y 3 primero por uuid y luego por objeto

            this.PorcentajeDescSobreTotal = edi.porcentaje_descuento_sobre_total;

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

            this.TipoFacturaId = this.CondicionPago.TipoCondicionPago; 
            
            this.TotalCostoBruto = edi.total_costo;
            this.TotalCostoNeto = edi.total_costo;
            this.TotalMontoBruto = edi.total_bruto;
            this.TotalMontoDto = edi.total_descuento;
            this.TotalMontoImpuesto = edi.total_impuesto;
            this.TotalNeto = edi.total_neto;
            this.UsuarioIdAutorizaDescuento = null;

            #region vendedor
            if (!string.IsNullOrEmpty(edi.funcionario_uuid))
                this._vendedor = FuncionariosService.GetPorUUID(edi.funcionario_uuid, sesion);
            if (this._vendedor == null && edi.funcionario != null)
                this._vendedor = new FuncionariosService(edi.funcionario, almacenar_localmente, sesion);
            if (this._vendedor != null)
            {
                if (!this.Vendedor.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.Vendedor.Id.HasValue)
                    this.VendedorId = this.Vendedor.Id.Value;
            }
            #endregion vendedor

            #region canal venta
            if (!string.IsNullOrEmpty(edi.canal_venta_uuid))
                this._canal_venta = CanalesVentaService.GetPorUUID(edi.canal_venta_uuid, sesion);
            if (this._canal_venta == null && edi.funcionario != null)
                this._canal_venta = new CanalesVentaService(edi.canal_venta, almacenar_localmente, sesion);
            if (this._canal_venta != null)
            {
                if (!this._canal_venta.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.CanalVenta.Id.HasValue)
                    this.CanalVentaId = this.CanalVenta.Id.Value;
            }
            #endregion canal venta

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
                this.Caso.FechaCreacion = edi.fecha_creacion;
                this.Caso.FechaFormulario = edi.fecha;
                this.Caso.FlujoId = Definiciones.FlujosIDs.FACTURACION_CLIENTE;
                this.Caso.NroComprobante2 = edi.nro_comprobante_externo;
            }
            #endregion caso

            #region inicializar campos no contemplados en el EDI si el dato no existe localmente
            if (!this.ExisteEnDB)
            {
                this.AConsignacion = Definiciones.SiNo.No;
                this.AfectaCtacte = Definiciones.SiNo.Si;
                this.AfectaStock = Definiciones.SiNo.Si;
                this.AfectaLineaCredito = Definiciones.SiNo.Si;
                this.ComisionPorVenta = Definiciones.SiNo.Si;
                this.ControlarCantMinDescMax = Definiciones.SiNo.No;
                this.GenerarTransferencia = Definiciones.SiNo.No;
                this.Impreso = Definiciones.SiNo.No;
            }
            #endregion campos no contemplados en el EDI si el dato no existe localmente
        }
        private FacturasClienteService(FACTURAS_CLIENTERow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._canal_venta = null;
            this._caso = null;
            this._caso_origen = null;
            this._condicion_pago = null;
            this._deposito = null;
            this._factura_cliente_detalles = null;
            this._moneda_destino = null;
            this._persona = null;
            this._persona_garante_1 = null;
            this._persona_garante_2 = null;
            this._persona_garante_3 = null;
            this._sucursal = null;
            this._vendedor = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region GetPorCaso
        public static FacturasClienteService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static FacturasClienteService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var row = sesion.db.FACTURAS_CLIENTECollection.GetByCASO_ID(caso_id)[0];
            return new FacturasClienteService(row);
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

            var e = new EdiCBA.FacturaCliente()
            {
                caso_id = this.CasoId,
                persona_uuid = this.Persona.GetOrCreateUUID(sesion),
                condicion_pago_uuid = this.CondicionPago.GetOrCreateUUID(sesion),
                cotizacion_uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, FacturasClienteService.CotizacionDestino_NombreCol, this.Id.Value, sesion),
                deposito_uuid = this.Deposito.GetOrCreateUUID(sesion),
                canal_venta_uuid = this.CanalVentaId.HasValue ? this.CanalVenta.GetOrCreateUUID(sesion) : null,
                estado_id = this.Caso.EstadoId,
                fecha = this.Fecha.Value,
                fecha_creacion = this.Caso.FechaCreacion,
                fecha_vencimiento = this.FechaVencimiento,
                moneda_uuid = this.MonedaDestino.GetOrCreateUUID(sesion),
                nro_comprobante = this.NroComprobante,
                nro_comprobante_externo = this.NroDocumentoExterno,
                nro_comprobante_numerico = this.NroComprobanteSecuencia,
                observacion = this.Observacion,
                sucursal_uuid = this.Sucursal.GetOrCreateUUID(sesion),
                total_bruto = this.TotalMontoBruto.HasValue ?  this.TotalMontoBruto.Value : 0,
                total_descuento = this.TotalMontoDto.HasValue ? this.TotalMontoDto.Value : 0,
                total_impuesto = this.TotalMontoImpuesto.HasValue ? this.TotalMontoImpuesto.Value : 0,
                total_neto = this.TotalNeto.HasValue ? this.TotalNeto.Value : 0,
                funcionario_uuid = this.VendedorId.HasValue ? this.Vendedor.GetOrCreateUUID(sesion) : null,
            };

            var detalles = FacturasClienteDetalleService.GetPorCabecera(this.Id.Value, sesion);
            e.factura_cliente_detalles_uuid = new string[detalles.Length];
            for (int i = 0; i < detalles.Length; i++)
                e.factura_cliente_detalles_uuid[i] = detalles[i].GetOrCreateUUID(sesion);

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.persona = (EdiCBA.Persona)this.Persona.ToEDI(nueva_profundidad, sesion);
                e.canal_venta = this.CanalVentaId.HasValue ? (EdiCBA.CanalVenta)this.CanalVenta.ToEDI(nueva_profundidad, sesion) : null;
                e.condicion_pago = (EdiCBA.CondicionPago)this.CondicionPago.ToEDI(nueva_profundidad, sesion);
                e.cotizacion = new EdiCBA.Cotizacion()
                {
                    uuid = e.cotizacion_uuid,
                    fecha = this.Fecha.Value,
                    moneda_uuid = e.moneda_uuid,
                    compra = this.CotizacionDestino.Value
                };
                e.deposito = (EdiCBA.Deposito)this.Deposito.ToEDI(nueva_profundidad, sesion);
                e.moneda = (EdiCBA.Moneda)this.MonedaDestino.ToEDI(nueva_profundidad, sesion);
                e.sucursal = (EdiCBA.Sucursal)this.Sucursal.ToEDI(nueva_profundidad, sesion);
                e.funcionario = this.VendedorId.HasValue ? (EdiCBA.Funcionario)this.Vendedor.ToEDI(nueva_profundidad, sesion) : null;

                e.factura_cliente_detalles = new EdiCBA.FacturaClienteDetalle[detalles.Length];
                
            }

            #region personas relacionadas
            var lPersonasRelacionadasUUID = new List<string>();
            var lPersonasRelacionadas = new List<EdiCBA.Persona>();
            if (this.PersonaGarante1Id.HasValue)
            {
                lPersonasRelacionadasUUID.Add(this.PersonaGarante1.GetOrCreateUUID(sesion));
                if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
                    lPersonasRelacionadas.Add((EdiCBA.Persona)this.PersonaGarante1.ToEDI(nueva_profundidad, sesion));
            }
            if (this.PersonaGarante2Id.HasValue)
            {
                lPersonasRelacionadasUUID.Add(this.PersonaGarante2.GetOrCreateUUID(sesion));
                if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
                    lPersonasRelacionadas.Add((EdiCBA.Persona)this.PersonaGarante2.ToEDI(nueva_profundidad, sesion));
            }
            if (this.PersonaGarante3Id.HasValue)
            {
                lPersonasRelacionadasUUID.Add(this.PersonaGarante3.GetOrCreateUUID(sesion));
                if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
                    lPersonasRelacionadas.Add((EdiCBA.Persona)this.PersonaGarante3.ToEDI(nueva_profundidad, sesion));
            }
            #endregion personas relacionadas

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
